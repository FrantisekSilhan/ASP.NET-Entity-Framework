﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly ASP.NET_Entity_Framework.Data.DatabaseContext _context;

        public IndexModel(ASP.NET_Entity_Framework.Data.DatabaseContext context)
        {
            _context = context;
        }

        public IList<GameGenre> GameGenre { get;set; } = default!;

        public async Task OnGetAsync()
        {
            GameGenre = await _context.GameGenre
                .Include(g => g.Game)
                .Include(g => g.Genre).ToListAsync();
        }
    }
}
