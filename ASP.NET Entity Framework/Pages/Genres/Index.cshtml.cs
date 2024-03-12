using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASP.NET_Entity_Framework.Data;
using ASP.NET_Entity_Framework.Models;

namespace ASP.NET_Entity_Framework.Pages.Genres
{
    public class IndexModel : PageModel
    {
        private readonly ASP.NET_Entity_Framework.Data.DatabaseContext _context;

        public IndexModel(ASP.NET_Entity_Framework.Data.DatabaseContext context)
        {
            _context = context;
        }

        public IList<Genre> Genre { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Genre = await _context.Genres.ToListAsync();
        }
    }
}
