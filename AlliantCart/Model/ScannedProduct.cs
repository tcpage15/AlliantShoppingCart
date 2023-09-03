using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantCart.Model
{
    public class ScannedProduct
    {
        public required string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
}
