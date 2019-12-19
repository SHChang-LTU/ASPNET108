using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPNET108.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "片名")]
        public string Name { get; set; }

        [Display(Name = "上映日期")]
        public DateTime? ReleasedDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Display(Name = "庫存量")]
        public short NumberInStocks { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }

        public List<Rental> CustomerMovies { get; set; }
    }
}