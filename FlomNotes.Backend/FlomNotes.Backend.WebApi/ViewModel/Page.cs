using System;
using System.Collections.Generic;

namespace FlomNotes.Backend.WebApi.ViewModel
{
    public class Page
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime EditTime { get; set; }

        public bool IsShortcut { get; set; }

        public List<Entry> Entries { get; set; }
    }
}