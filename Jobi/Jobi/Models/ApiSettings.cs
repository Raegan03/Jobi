using Newtonsoft.Json;
using System;

namespace Jobi.Models
{
    [Serializable]
    public class ApiSettings
    {
        [JsonProperty("api_url")]
        public string ApiUrl { get; set; }

        [JsonProperty("api_search")]
        public string ApiSearch { get; set; }

        [JsonProperty("api_location")]
        public string ApiLocation { get; set; }

        [JsonProperty("api_full_time")]
        public string ApiFullTime { get; set; }

        [JsonProperty("api_lat")]
        public string ApiLat { get; set; }

        [JsonProperty("api_long")]
        public string ApiLong { get; set; }
    }
}
