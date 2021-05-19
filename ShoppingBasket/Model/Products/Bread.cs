namespace ShoppingBasket.Model.Products
{
    public class Bread : IProduct
    {
        public string GetName()
        {
            return "Black bread";
        }

        public double GetPrice()
        {
            return 1;
        }
    }
}
