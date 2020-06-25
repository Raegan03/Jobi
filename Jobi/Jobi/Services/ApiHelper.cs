using Jobi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace Jobi.Helpers
{
    public class ApiHelper
    {
        private ApiSettings _apiSettings;

        public ApiHelper()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Jobi.config.json";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                _apiSettings = JsonConvert.DeserializeObject<ApiSettings>(result);
            }
        }

        public async Task<List<JobItem>> GetJobsAsync(JobsSearchItem jobSearchItem)
        {
            using (HttpClient client = new HttpClient())
            {
                var queries = new List<string>
                {
                    string.Format(_apiSettings.ApiSearch, jobSearchItem.SearchTerms),
                    string.Format(_apiSettings.ApiFullTime, jobSearchItem.FullTime),
                };

                if (jobSearchItem.UseGeolocation)
                {
                    queries.Add(string.Format(_apiSettings.ApiLat, jobSearchItem.Latitude));
                    queries.Add(string.Format(_apiSettings.ApiLong, jobSearchItem.Longitude));
                }
                else
                {
                    queries.Add(string.Format(_apiSettings.ApiLocation, jobSearchItem.Location));
                }

                var uri = BuildGetUri(queries);
                try
                {
                    var response = await client.GetAsync(uri);
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        var resTxt = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<JobItem>>(resTxt);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (ArgumentNullException argumentError)
                {
                    return null;
                }
                catch (HttpRequestException httpError)
                {
                    return null;
                }
            };
        }

        private Uri BuildGetUri(List<string> queries = null)
        {
            var apiUriWithArg = _apiSettings.ApiUrl;
            var uriBuilder = new UriBuilder(apiUriWithArg);
            if (queries != null)
            {
                foreach (var query in queries)
                {
                    uriBuilder.Query += $"{query}&";
                }
            }
            return uriBuilder.Uri;
        }
    }
}
