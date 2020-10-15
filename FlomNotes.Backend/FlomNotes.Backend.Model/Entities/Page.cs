using System;
using System.Collections.Generic;

namespace FlomNotes.Backend.Model.Entities
{
    public class Page
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string NormalizedTitle { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime EditTime { get; set; }

        public bool IsShortcut { get; set; }

        public List<Entry> Entries { get; set; }
    }
}