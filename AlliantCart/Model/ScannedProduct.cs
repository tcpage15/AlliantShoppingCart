using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantCart.Model
{
    /// <summary>
    /// Object that will contain the scanned products and their quantities
    /// </summary>
    public class ScannedProduct
    {
        public required string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
}
