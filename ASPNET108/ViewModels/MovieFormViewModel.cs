using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPNET108.Models;

namespace ASPNET108.ViewModels
{
    public class MovieFormViewModel
    {
        public List<Genre> Genres { get; set; }

        public Movie Movie { get; set; }
    }
}