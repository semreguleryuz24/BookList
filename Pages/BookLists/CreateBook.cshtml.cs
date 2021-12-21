using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookList.Pages.BookLists
{
    public class CreateBookModel : PageModel
    {
        private readonly BLDbContext _db;
        public CreateBookModel(BLDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
              if(ModelState.IsValid)
            {
               await _db.Book.AddAsync(Book);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index") ;
            }
            else
            {
                return Page();
            }
        }
    }
}
