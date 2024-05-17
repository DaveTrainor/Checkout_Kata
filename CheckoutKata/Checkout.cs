using System.Data;

namespace CheckoutKata
{
    public class Checkout
    {
        public int Total { get; set; }
        public List<Product> Basket { get; set; } = [];

        public int GetTotal()
        {
            Dictionary<Product, int> aggregatedBasket = new();
            foreach(var product in Basket.Distinct())
            {
                aggregatedBasket.Add(product, Basket.Count(p => p.Id == product.Id));
            }
            
            foreach(var item in aggregatedBasket) 
            {
                var product = item.Key;
                var productQuantity = item.Value;

                foreach(var offer in SpecialPrices.OfferList)
                {
                    if(product.Id == offer.productId)
                    {
                        Total += productQuantity / offer.quantity * offer.specialPrice;
                        productQuantity = productQuantity % offer.quantity;
                    }
                }
                Total += productQuantity * product.Price;
            }

                return Total;
        }

        public void AddProduct(Product product)
        {
            Basket.Add(product);
        }

    }
}