using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPNET108.Models
{
    public class Rental
    {
        [Key, Column(Order = 1, TypeName = "int")]
        [ForeignKey(name: "Customer")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }


        [Key, Column(Order = 2, TypeName = "int")]
        [ForeignKey(name: "Movie")]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}