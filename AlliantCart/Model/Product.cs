using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantCart.Model
{
    /// <summary>
    /// Object that will contain the Product Item and available pricing
    /// </summary>
    public class Product
    {
        public required string Code { get; set; }
        public decimal Value { get; set; }
        public bool AvailableDiscount { get; set; }
        public int DiscountQty { get; set; }
        public decimal DiscountValue { get; set; }
    }
}
