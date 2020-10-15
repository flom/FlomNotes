using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FlomNotes.Backend.Model;
using FlomNotes.Backend.Model.Entities;
using FlomNotes.Backend.RoamImporter.RoamModel;
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
            string roamBackupPath = args[0];

            var context = CreateDb(dbPath);
            List<RoamPage> roamPages = ReadRoamBackup(roamBackupPath);
            List<Page> pages = MapRoamModelToDataModel(roamPages);

            context.Pages.AddRange(pages);
            context.SaveChanges();
        }

        static NotesContext CreateDb(string dbPath)
        {
            File.Delete(dbPath);

            var options = new DbContextOptionsBuilder<NotesContext>()
                .UseSqlite($"Data Source={dbPath}")
                .Options;

            var context = new NotesContext(options);
            context.Database.EnsureCreated();

            return context;
        }

        static List<RoamPage> ReadRoamBackup(string path)
        {
            var roamPages = JsonSerializer.Deserialize<List<RoamPage>>(File.ReadAllText(path));

            return roamPages;
        }

        static List<Page> MapRoamModelToDataModel(List<RoamPage> roamPages)
        {
            var pages = new List<Page>();

            foreach (var roamPage in roamPages)
            {
                pages.Add(MapRoamPageToNotePage(roamPage));
            }

            return pages;
        }

        static Page MapRoamPageToNotePage(RoamPage roamPage)
        {
            var page = new Page()
            {
                Title = roamPage.Title,
                CreationTime = ConvertToDateTime(roamPage.EditTime),
                EditTime = ConvertToDateTime(roamPage.EditTime)
            };

            if (roamPage.Children != null)
            {
                page.Entries = JsonSerializer.Serialize(MapRoamChildrenToNoteEntries(roamPage.Children));
            }

            return page;
        }

        static List<Entry> MapRoamChildrenToNoteEntries(List<RoamChildren> roamChildren)
        {
            var entries = new List<Entry>();

            foreach (var child in roamChildren)
            {
                var entry = new Entry()
                {
                    Content = child.String,
                    CreationTime = ConvertToDateTime(child.CreateTime),
                    EditTime = ConvertToDateTime(child.EditTime)
                };

                if (child.Children != null)
                {
                    entry.Children = MapRoamChildrenToNoteEntries(child.Children);
                }
                
                entries.Add(entry);
            }
            
            return entries;
        }

        static DateTime ConvertToDateTime(long unixMilliseconds)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(unixMilliseconds).UtcDateTime;
        }
    }
}