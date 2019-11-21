using System.Collections.Generic;
using ASPNET108.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {

        public List<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}