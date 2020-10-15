using System;
using System.Collections.Generic;

namespace FlomNotes.Backend.Model.Entities
{
    public class Entry
    {
        public string Content { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime EditTime { get; set; }

        public List<Entry> Children { get; set; }
    }
}