using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Models
{
    public class BLDbContext:DbContext
    {
        public BLDbContext(DbContextOptions<BLDbContext> options):base(options)
        {

        }
        public DbSet<Book> Book { get; set; }
    }
}
//"Server=(localdb)\\DESKTOP-CEEOKCM;Database=DBBookList;Trusted_Connection=True;"