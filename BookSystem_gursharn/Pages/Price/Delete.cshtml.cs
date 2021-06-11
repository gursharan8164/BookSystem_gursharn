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
    public class DeleteModel : PageModel
    {
        private readonly BookSystem_gursharn.Data.ApplicationDbContext _context;

        public DeleteModel(BookSystem_gursharn.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Biz.Price Price { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Price = await _context.Prices.FirstOrDefaultAsync(m => m.ID == id);

            if (Price == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Price = await _context.Prices.FindAsync(id);

            if (Price != null)
            {
                _context.Prices.Remove(Price);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
