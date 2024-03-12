using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NET_Entity_Framework.Data;
using ASP.NET_Entity_Framework.Models;

namespace ASP.NET_Entity_Framework.Pages.GameGenres
{
    public class EditModel : PageModel
    {
        private readonly ASP.NET_Entity_Framework.Data.DatabaseContext _context;

        public EditModel(ASP.NET_Entity_Framework.Data.DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GameGenre GameGenre { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamegenre =  await _context.GameGenre.FirstOrDefaultAsync(m => m.GameId == id);
            if (gamegenre == null)
            {
                return NotFound();
            }
            GameGenre = gamegenre;
           ViewData["GameId"] = new SelectList(_context.Games, "GameId", "Name");
           ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GameGenre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameGenreExists(GameGenre.GameId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GameGenreExists(int id)
        {
            return _context.GameGenre.Any(e => e.GameId == id);
        }
    }
}
