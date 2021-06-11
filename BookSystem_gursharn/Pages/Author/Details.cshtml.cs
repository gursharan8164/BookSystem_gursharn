using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookSystem_gursharn.Biz;
using BookSystem_gursharn.Data;

namespace BookSystem_gursharn.Pages.Author
{
    public class DetailsModel : PageModel
    {
        private readonly BookSystem_gursharn.Data.ApplicationDbContext _context;

        public DetailsModel(BookSystem_gursharn.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Biz.Author Author { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Author = await _context.Authors.FirstOrDefaultAsync(m => m.ID == id);

            if (Author == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
