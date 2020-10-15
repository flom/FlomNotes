using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FlomNotes.Backend.RoamImporter.RoamModel
{
    public class RoamChildren
    {
        [JsonPropertyName("string")]
        public string String { get; set; }

        [JsonPropertyName("uid")]
        public string Uid { get; set; }
        
        [JsonPropertyName("create-time")]
        public long CreateTime { get; set; }

        [JsonPropertyName("edit-time")]
        public long EditTime { get; set; }

        [JsonPropertyName("children")]
        public List<RoamChildren> Children { get; set; }
    }
}