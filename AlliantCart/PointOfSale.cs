using AlliantCart.Model;

namespace AlliantCart
{
    public class PointOfSale : ITerminal
    {
        private List<ScannedProduct>? productsInCart;

        public List<ScannedProduct> ProductsInCart
        {
            get
            {
                return productsInCart;
            }
            set
            {
                productsInCart = value;
            }
        }


        /// <summary>
        /// Point of Sale Constructor where we initiate the collection of scanned products
        /// </summary>
        public PointOfSale()
        {
            productsInCart = new List<ScannedProduct>();
        }


        /// <summary>
        /// Organize each of the itmes placed on the counter to prepare them for individual scans
        /// </summary>
        /// <param name="items">Collection of items to be scanned</param>
        public List<string> AddToCheckoutCounter(string items)
        {
            List<string> counterItems = new List<string>();

            foreach(var item in items)
            {
                counterItems.Add(Convert.ToString(item));
            }

            return counterItems;
        }


        /// <summary>
        /// Scan an individual product.  This process checks to see if the product type has
        /// already been scanned and placed in the cart.  It if doesn't exist, a new item is
        /// created in the scannedProd collection, Else if it does exist, the scannedProd collection
        /// quantity is updated.
        /// </summary>
        /// <param name="item">Product item to be scanned</param>
        public void Scan(string item)
        {
            bool productTypeExistsInCart = false;
            ScannedProduct? scannedProd = null;

            // See if any of these products exist in the cart.
            // If it doesn't, create the product object and add it to the cart
            // Else if it does in creat the Quantity
            productTypeExistsInCart = ProductTypeExistsInCart(item);
            if (!productTypeExistsInCart)
            {
                scannedProd = new ScannedProduct() { ProductCode = item, Quantity = 1};
                productsInCart.Add(scannedProd);
            }
            else
            {
                scannedProd = FindProductObject(item);
                scannedProd.Quantity += 1;
            }
        }


        /// <summary>
        /// Find a specific product object based on the productCode
        /// </summary>
        /// <param name="productCode">Product code that is targeted</param>
        /// <returns>ScannedProduct object that matches the product code</returns>
        public ScannedProduct? FindProductObject(string productCode)
        {
            ScannedProduct? productToReturn = null;

            foreach (var product in productsInCart)
            {
                if (product.ProductCode == productCode)
                {
                    productToReturn = product;
                }
            }

            return productToReturn;
        }


        /// <summary>
        /// Check to see if the product type exists in item collection that has
        /// been scanned
        /// </summary>
        /// <param name="productCode">Product code of the item we are checking</param>
        /// <returns></returns>
        public bool ProductTypeExistsInCart(string productCode)
        {
            bool exists = false;

            foreach (var product in productsInCart)
            {
                if (product.ProductCode == productCode)
                {
                    exists = true;
                }
            }

            return exists;
        }


        /// <summary>
        /// Join the product menu collection with the scanned items to calculate the total
        /// </summary>
        /// <returns>Total of the items scanned</returns>
        public decimal Total()
        {
            Utilities cartUtil = new Utilities();
            decimal total = 0;

            //Get the product menu and join it with the scanned items so we can total the values
            var productMenu = cartUtil.GetProductListFromMenu();
            var scannedMenuItems = from p in productMenu
                                join s in productsInCart on p.Code equals s.ProductCode
                                select new { p, s };

            //Run through each of the scanned items and check if there is a discount.  If there
            //is a discount available, subtract the discounted items from the total quantity and
            //continue to do this to check for multiple discounts, until our left over value is
            //less than the discounted quantity
            foreach(var item in scannedMenuItems)
            {
                if (item.p.AvailableDiscount)
                {
                    if (item.s.Quantity >= item.p.DiscountQty)
                    {
                        int loQty = item.s.Quantity;
                        do
                        {
                            total += item.p.DiscountValue;
                            loQty -= item.p.DiscountQty;

                        } while (loQty >= item.p.DiscountQty);

                        total += (loQty * item.p.Value);
                    }
                    else
                    {
                        total += (item.s.Quantity * item.p.Value);
                    }
                }
                else
                {
                    total += (item.s.Quantity * item.p.Value);
                }
            }

            return total;
        }
    }
}