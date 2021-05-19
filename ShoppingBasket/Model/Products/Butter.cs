namespace ShoppingBasket.Model.Products
{
    public class Butter : IProduct
    {
        public string GetName()
        {
            return "Super butter";
        }

        public double GetPrice()
        {
            return 0.8;
        }
    }
}
