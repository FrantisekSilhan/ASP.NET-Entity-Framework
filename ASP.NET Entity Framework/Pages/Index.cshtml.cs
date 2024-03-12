using ASP.NET_Entity_Framework.Data;
using ASP.NET_Entity_Framework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Entity_Framework.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;
        private readonly DatabaseContext _context;

        public Models.Game Game { get; set; }

        public IndexModel(ILogger<IndexModel> logger, DatabaseContext context) {
            _logger = logger;
            _context = context;
        }

        public void OnGet() {
            Game = _context.Games
                .Include(g => g.GameGenres)
                .ThenInclude(gg => gg.Genre)
                .FirstOrDefault();
        }
    }
}
