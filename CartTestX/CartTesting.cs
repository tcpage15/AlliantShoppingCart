namespace CartTestX
{
    public class CartTesting
    {
        [Theory]
        [InlineData("CCCCCCC", 7.25)]
        [InlineData("ABCDABAA", 32.40)]
        [InlineData("ABCD", 15.40)]
        [InlineData("CCCCCCCCCCCCC", 13.25)]
        [InlineData("AAAAAAAAACCCCCCC", 23.25)]
        [InlineData("BBBBBDDDDD", 60.75)]
        [InlineData("CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC", 31.25)]
        [InlineData("AAAAAAAAAAAACCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC", 52.25)]
        public void TestShoppingCartProductsAndTotals(string productItems, decimal expectedTotal)
        {
            //Arrange
            AlliantCart.PointOfSale cartSale = new AlliantCart.PointOfSale();

            //Act
            // Add all items from the basket to the checkout counter, preparing to scan each item
            var counterItems = cartSale.AddToCheckoutCounter(productItems);
            foreach (var item in counterItems)
            {
                cartSale.Scan(item);
            }

            //Assert
            Assert.Equal(expectedTotal, cartSale.Total());
        }
    }
}