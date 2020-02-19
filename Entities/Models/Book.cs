using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Author { get; set; }

        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Range(1, 2000, ErrorMessage = "This field cannot have value 0")]
        public int Pages { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Range(1, 2000, ErrorMessage = "This field cannot have value 0")]
        [UIHint("DisplayCurrency")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Range(1, 2000, ErrorMessage = "This field cannot have value 0")]
        [Display(Name = "In stock")]
        public int InStock { get; set; }
    }
}
