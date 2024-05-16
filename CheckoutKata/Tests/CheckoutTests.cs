namespace CheckoutKata.Tests
{
    public class CheckoutTests
    {
        public class ProgramTests
        {
            [Fact]
            public void main_givenValidProduct_UpdatesTotal()
            {
                //Arrange
                var exampleProduct = new Product { Name = "exampleProduct1", Id = 1, Price = 3 };
                var checkout = new Checkout();
                var expected = 3;
                //Act
                checkout.AddProduct(exampleProduct);
                var result = checkout.GetTotal();
                //Assert
                Assert.Equal(expected, result);
            }

            [Fact]
            public void main_givenTwoValidProducts_returnsTotal()
            {
                //Arrange
                var exampleProduct = new Product { Name = "exampleProduct1", Id = 1, Price = 3 };
                var exampleProduct2 = new Product { Name = "exampleProduct2", Id = 2, Price = 4 };
                var program = new Checkout();
                var expected = 7;
                //Act
                program.AddProduct(exampleProduct);
                program.AddProduct(exampleProduct2);
                var result = program.GetTotal();
                //Assert
                Assert.Equal(expected, result);

            }
        }
    }
}
