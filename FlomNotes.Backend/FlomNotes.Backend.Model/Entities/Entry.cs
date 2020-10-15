using System;
using System.Collections.Generic;

namespace FlomNotes.Backend.Model.Entities
{
    public class Entry
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public int Order { get; set; }
        
        public DateTime CreationTime { get; set; }

        public DateTime EditTime { get; set; }

        public Guid? PageId { get; set; }

        public Page Page { get; set; }

        public Guid? ParentEntryId { get; set; }

        public Entry ParentEntry { get; set; }

        public List<Entry> Children { get; set; }
    }
}