﻿using Newtonsoft.Json;
using System;

namespace Jobi.Models
{
    [Serializable]
    public class User
    {
        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("search_term")]
        public string SearchTerms { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("use_geolocation")]
        public bool UseGeolocation { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("full_time")]
        public bool FullTime { get; set; }
    }
}
