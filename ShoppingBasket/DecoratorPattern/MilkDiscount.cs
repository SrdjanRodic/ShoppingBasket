using ShoppingBasket.Model;

namespace ShoppingBasket.DecoratorPattern
{
    public class MilkDiscount : Discount
    {
        public MilkDiscount(IProduct product) : base(product)
        {
        }

        public override string GetName()
        {
            return product.GetName() + " free of charge";
        }

        public override double GetPrice()
        {
            return - product.GetPrice();
        }
    }
}
