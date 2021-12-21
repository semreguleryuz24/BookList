using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Kitap adı boş geçilemez!!")]
        public String BookName { get; set; }
        [Required(ErrorMessage = "Yazar adı boş geçilemez!!")]
        public String Author { get; set; }
        [Required(ErrorMessage = "ISBN alanı  boş geçilemez!!")]
        public String ISBN { get; set; }
    }
}
