using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNET108.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        public string Name { get; set; }

        public short SignUpFee { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }

        public string GetDiscountName()
        {
            var discount = "";
            if (DiscountRate == 0)
            {
                discount = "無折扣";
            }
            else if (DiscountRate == 10)
            {
                discount = "九折";
            }
            else if (DiscountRate == 15)
            {
                discount = "八五折";
            }

            return discount;
        }
    }
}