using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookList.Pages.BookLists
{
    public class SettingModel : PageModel
    {
        private BLDbContext _db;
      
        public SettingModel(BLDbContext db)
        {
            _db = db;

        }
        //OnGet metoduna baðlamak için kullandým.
        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await _db.Book.FindAsync(id);    
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var DbComingBook = await _db.Book.FindAsync(Book.Id);
                DbComingBook.BookName = Book.BookName;
                DbComingBook.Author = Book.Author;
                DbComingBook.ISBN = Book.ISBN;
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
             }
            return RedirectToPage();
        }
    }
}
