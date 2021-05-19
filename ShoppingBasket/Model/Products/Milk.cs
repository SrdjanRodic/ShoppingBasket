namespace ShoppingBasket.Model.Products
{
    public class Milk : IProduct
    {
        public string GetName()
        {
            return "Super milk";
        }

        public double GetPrice()
        {
            return 1.15;
        }
    }
}
