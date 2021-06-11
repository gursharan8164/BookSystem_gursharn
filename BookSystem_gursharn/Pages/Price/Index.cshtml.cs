using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookSystem_gursharn.Biz;
using BookSystem_gursharn.Data;

namespace BookSystem_gursharn.Pages.Price
{
    public class IndexModel : PageModel
    {
        private readonly BookSystem_gursharn.Data.ApplicationDbContext _context;

        public IndexModel(BookSystem_gursharn.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Biz.Price> Price { get;set; }

        public async Task OnGetAsync()
        {
            Price = await _context.Prices.ToListAsync();
        }
    }
}
