using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPNET108.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Display(Name = "影片類型")]
        public string Name { get; set; }

    }
}