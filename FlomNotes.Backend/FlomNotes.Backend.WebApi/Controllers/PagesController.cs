using System.Collections.Generic;
using System.Linq;
using FlomNotes.Backend.Model;
using FlomNotes.Backend.Model.Entities;
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
            return _context.Pages.ToList();
        }
    }
}