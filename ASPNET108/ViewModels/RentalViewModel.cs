using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPNET108.Models;

namespace ASPNET108.ViewModels
{
    public class RentalViewModel
    {
        public Customer Customer { get; set; }

        public List<Movie> CustomerMovies { get; set; }
    }
}