using FlomNotes.Backend.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlomNotes.Backend.Model
{
    public class NotesContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }

        public DbSet<Entry> Entries { get; set; }

        public NotesContext(DbContextOptions<NotesContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}