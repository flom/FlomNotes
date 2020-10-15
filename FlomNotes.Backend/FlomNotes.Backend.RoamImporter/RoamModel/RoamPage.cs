using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FlomNotes.Backend.RoamImporter.RoamModel
{
    public class RoamPage
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("edit-time")]
        public long EditTime { get; set; }

        [JsonPropertyName("children")]
        public List<RoamChildren> Children { get; set; }
    }
}