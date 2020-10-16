using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using FlomNotes.Backend.Model;
using FlomNotes.Backend.WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FlomNotes.Backend.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagesController : ControllerBase
    {
        private readonly NotesContext _context;

        public PagesController(NotesContext context)
        {
            _context = context;
        }

        public IEnumerable<Page> Get()
        {
            var pages = new List<Page>();
            
            foreach (var page in _context.Pages.ToList())
            {
                var vmPage = new Page()
                {
                    Id = page.Id,
                    Title = page.Title,
                    CreationTime = page.CreationTime,
                    EditTime = page.EditTime,
                    IsShortcut = page.IsShortcut
                };
                
                if (page.Entries != null)
                {
                    vmPage.Entries = JsonSerializer.Deserialize<List<Entry>>(page.Entries);
                }
                
                pages.Add(vmPage);
            }

            return pages;
        }
    }
}