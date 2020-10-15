using System.IO;
using FlomNotes.Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace FlomNotes.Backend.RoamImporter
{
    class Program
    {
        /// <summary>
        /// args[0] exported Roam file (.json format)
        /// args[1] folder to store the database in
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string dbPath = Path.Join(args[1], "notes.db");
            File.Delete(dbPath);
            
            var options = new DbContextOptionsBuilder<NotesContext>()
                .UseSqlite($"Data Source={dbPath}")
                .Options;
            
            var context = new NotesContext(options);
            context.Database.EnsureCreated();
        }
    }
}