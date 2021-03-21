using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BlazorApp.Shared
{
    public class TimetableItem
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = "";

        [JsonPropertyName("age")]
        public List<int> Age { get; set; } = new List<int>();

        [JsonPropertyName("icon")]
        public string Icon { get; set; } = "";

        [JsonPropertyName("description")]
        public string Description { get; set; } = "";

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";
    }
}
