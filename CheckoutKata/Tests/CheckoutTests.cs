using System.Diagnostics;
using System.Xml.Linq;

namespace CheckoutKata.Tests
{
    public class CheckoutTests
    {
        public class ProgramTests
        {
            [Fact]
            public void checkout_givenValidProduct_UpdatesTotal()
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
            public void checkout_givenTwoValidProducts_returnsTotal()
            {
                //Arrange
                var exampleProduct = new Product { Name = "exampleProduct1", Id = 1, Price = 3 };
                var exampleProduct2 = new Product { Name = "exampleProduct2", Id = 2, Price = 4 };
                var checkout = new Checkout();
                var expected = 7;

                //Act
                checkout.AddProduct(exampleProduct);
                checkout.AddProduct(exampleProduct2);
                var result = checkout.GetTotal();

                //Assert
                Assert.Equal(expected, result);
            }

            [Fact]
            public void checkout_givenOfferQualifyingBaskets_AppliesOffer()
            {
                //Arrange
                var basket = new List<Product>()
                {
                    productA,
                    productB,
                    productA,
                    productA
                };
                var checkout = new Checkout();
                var expected = 45;

                //Act
                foreach (var product in basket)
                {
                    checkout.AddProduct(product);
                }
                var result = checkout.GetTotal();
                
                //Assert
                Assert.Equal(expected, result);

            }

            [Theory]
            [MemberData(nameof(ValidBasketsWithTotalCost))]
            public void checkout_givenMultipleProductsQualifyingForOffers_CalculatesTotal(int expected, List<Product> basket)
            {
                //Arrange
                
                var checkout = new Checkout();

                //Act
                foreach (var product in basket)
                {
                    checkout.AddProduct(product);
                }
                var result = checkout.GetTotal();

                //Assert
                Assert.Equal(expected, result);
            }

            public static TheoryData<int, List<Product>> ValidBasketsWithTotalCost()
            {
                return new TheoryData<int, List<Product>>
                {
                    {45, [productA, productA, productA, productC] },
                    {95, [productA, productA, productA, productC, productB, productB, productB] },
                    {50, [productA, productA, productA, productA, productA, productA]}
                };
            }

            private static readonly Product productA = new()
            {
                Id = 0,
                Name = "A",
                Price = 10
            };

            private static readonly Product productB = new()
            {
                Id = 1,
                Name = "B",
                Price = 20,
            };

            private static readonly Product productC = new()
            {
                Id = 3,
                Name = "C",
                Price = 20,
            };
        }
    }
}
