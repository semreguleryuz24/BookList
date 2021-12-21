using BookList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly BLDbContext _db;
        public BookController(BLDbContext db)
        {
            _db = db;          
        }
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            return Json(new {data=await _db.Book.ToListAsync()});
        }
       
        public async Task<IActionResult> Delete(int id)
        {
            var DbComingBook = await _db.Book.FirstOrDefaultAsync(x => x.Id == id);
            if(DbComingBook==null)
            {
                return Json(new { success = false, message = "Silme İşleminde Hata oluştu.!!" });

            }
            _db.Book.Remove(DbComingBook);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Silme işlemi başarıyla gerçekleşti." });
        }
    }
}
