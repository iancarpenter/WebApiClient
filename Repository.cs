using System;
using System.Text.Json.Serialization;
using System.Globalization;

namespace WebApiClient
{
    public class Repository
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("html_url")]
        public Uri GitHubHomeUrl { get; set; }
        [JsonPropertyName("homepage")]
        public Uri Homepage { get; set; }
        [JsonPropertyName("watchers")]
        public int Watchers { get; set; }

        [JsonPropertyName("pushed_at")]
        public string JsonDate { get; set; }

        public DateTime lastPush => 
           DateTime.ParseExact(JsonDate, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
    }
}