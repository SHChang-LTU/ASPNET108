using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPNET108.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name = "會員等級")]
        public MembershipType MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }

        [Display(Name = "生日")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "會員初始點數")]
        public short Credit { get; set; }

    }
}