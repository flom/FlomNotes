namespace FlomNotes.Backend.Model.Entities
{
    public class Entry
    {
        public long Id { get; set; }

        public string Content { get; set; }

        public int Order { get; set; }

        public long PageId { get; set; }

        public Page Page { get; set; }

        public long? ParentEntryId { get; set; }

        public Entry ParentEntry { get; set; }
    }
}