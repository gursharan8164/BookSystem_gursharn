using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookSystem_gursharn.Biz;
using BookSystem_gursharn.Data;

namespace BookSystem_gursharn.Pages.Book
{
    public class CreateModel : PageModel
    {
        private readonly BookSystem_gursharn.Data.ApplicationDbContext _context;

        public CreateModel(BookSystem_gursharn.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AuthorID"] = new SelectList(_context.Authors, "ID", "Name");
        ViewData["PriceID"] = new SelectList(_context.Prices, "ID", "Rate");
            return Page();
        }

        [BindProperty]
        public Biz.Book Book { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
