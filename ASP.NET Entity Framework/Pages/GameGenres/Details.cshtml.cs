using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASP.NET_Entity_Framework.Data;
using ASP.NET_Entity_Framework.Models;

namespace ASP.NET_Entity_Framework.Pages.GameGenres
{
    public class DetailsModel : PageModel
    {
        private readonly ASP.NET_Entity_Framework.Data.DatabaseContext _context;

        public DetailsModel(ASP.NET_Entity_Framework.Data.DatabaseContext context)
        {
            _context = context;
        }

        public GameGenre GameGenre { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamegenre = await _context.GameGenre.FirstOrDefaultAsync(m => m.GameId == id);
            if (gamegenre == null)
            {
                return NotFound();
            }
            else
            {
                GameGenre = gamegenre;
            }
            return Page();
        }
    }
}
