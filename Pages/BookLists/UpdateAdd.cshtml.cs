using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookList.Pages
{
    public class UpdateAddModel : PageModel
    {

        private  readonly BLDbContext _db;

        public UpdateAddModel(BLDbContext db)
        {
            _db = db;

        }
        //OnGet metoduna ba�lamak i�in kulland�m.
        [BindProperty]
        public Book Book { get; set; }
        public async Task<IActionResult> OnGet(int? id)//Gelen id nin durumuna g�re i�lem yapma dolu ise g�ncelleme bo� ise ekleme gibi. 
        {
            //Yeni Kitap ekleme
            Book = new Book();
            if(id==null)
            {
                return Page();
            }
            //Kitap g�ncelleme
            Book = await _db.Book.FirstOrDefaultAsync(x => x.Id == id);
            if(Book==null)
            {
                return NotFound();  
            }
            return Page();
        }


        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if(Book.Id==0)
                {
                    _db.Book.Add(Book);
                }
                else
                {
                    _db.Book.Update(Book);
                }
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
