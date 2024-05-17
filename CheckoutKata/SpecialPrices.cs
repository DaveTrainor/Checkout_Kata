namespace CheckoutKata
{
    internal class SpecialPrices
    {
        public static IEnumerable<SpecialPrice> OfferList = new List<SpecialPrice>()
        {
            new SpecialPrice
            {
                productId = 0,
                quantity = 3,
                specialPrice = 25
            },
            new SpecialPrice
            {
                productId = 1,
                quantity = 2,
                specialPrice = 30
            }
        };
    }
}
