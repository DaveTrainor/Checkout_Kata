namespace CheckoutKata
{
    public class Checkout
    {
        public int Total { get; set; }

        public int GetTotal()
        {
            return Total;
        }

        public void AddProduct(Product product)
        {
            Total += product.Price;
        }

    }
}
