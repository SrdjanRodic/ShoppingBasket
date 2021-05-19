using ShoppingBasket.Model;

namespace ShoppingBasket.DecoratorPattern
{
    public class BreadDiscount : Discount
    {
        private const double _50_PERCENTAGE_DISCOUNT = 0.5;

        public BreadDiscount(IProduct product) : base(product)
        {
        }

        public override string GetName()
        {
            return product.GetName() + " dicounted 50%";
        }

        public override double GetPrice()
        {
            return - product.GetPrice() * _50_PERCENTAGE_DISCOUNT;
        }
    }
}
