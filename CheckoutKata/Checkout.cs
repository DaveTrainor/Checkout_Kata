using System.Data;

namespace CheckoutKata
{
    public class Checkout
    {
        public int Total { get; set; }
        public List<Product> Basket { get; set; } = [];

        public int GetTotal()
        {
            var aggregatedBasket = new List<ProductWithQuantity>();
            foreach(var product in Basket.Distinct())
            {
                aggregatedBasket.Add(new ProductWithQuantity() 
                { 
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = Basket.Count(p => p.Id == product.Id)
                });
            }
            
            foreach(var productWithQuantity in aggregatedBasket) 
            {
                applySpecialPrices(productWithQuantity);
                Total += productWithQuantity.Quantity * productWithQuantity.Price;
            }
            return Total;
        }

        private void applySpecialPrices(ProductWithQuantity productWithQuantity)
        {
            foreach (var offer in SpecialPrices.OfferList)
            {
                if (productWithQuantity.Id == offer.productId)
                {
                    Total += productWithQuantity.Quantity / offer.quantity * offer.specialPrice;
                    productWithQuantity.Quantity = productWithQuantity.Quantity % offer.quantity;
                }
            }
        }

        public void AddProduct(Product product)
        {
            Basket.Add(product);
        }

    }
}