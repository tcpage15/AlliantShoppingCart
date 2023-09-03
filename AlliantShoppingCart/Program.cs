using Newtonsoft.Json;
using System.Dynamic;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;

namespace AlliantShoppingCart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? productCodesToScan = null;
            List<string> counterItems = new List<string>();

            AlliantCart.PointOfSale cartSale = new AlliantCart.PointOfSale();

            Console.WriteLine("----- Alliant Shopping Cart -----");
            Console.WriteLine("Please enter the Product Codes you wish to scan: ");

            // Read the items to be scanned and prepare them to be scanned individually
            productCodesToScan = Console.ReadLine();
            if(productCodesToScan != null)
            {
                counterItems = cartSale.AddToCheckoutCounter(productCodesToScan);
            }


            // If there are items to be scanned, scan them individually
            foreach(var item in counterItems)
            {
                cartSale.Scan(item);
            }

            // Get the scanned items to prepare them to be totaled

            var total = cartSale.Total();

            Console.WriteLine("\nTheTotal is {0}", total);
            Console.ReadLine();
        }
    }
}