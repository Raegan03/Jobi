using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Jobi.Models;
using Newtonsoft.Json;

namespace Jobi.Services
{
    public class JobsDataStore
    {
        private readonly List<JobItem> items;
        private readonly string _jobsDataPath;

        public JobsDataStore()
        {
            _jobsDataPath = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData), "savedJobs.json");

            items = new List<JobItem>();
            if (File.Exists(_jobsDataPath))
            {
                var jobsJson = File.ReadAllText(_jobsDataPath);
                items = JsonConvert.DeserializeObject<List<JobItem>>(jobsJson);
            }
        }

        public IReadOnlyList<JobItem> GetItems() => items;

        public async Task<IReadOnlyList<JobItem>> FetchItems(JobsSearchItem jobSearchItem)
        {
            var newItems = await App.ApiHelper.GetJobsAsync(jobSearchItem);

            items.Clear();
            foreach (var item in newItems)
            {
                items.Add(item);
            }

            return items;
        }
    }
}