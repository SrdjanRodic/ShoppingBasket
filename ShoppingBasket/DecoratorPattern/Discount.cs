using ShoppingBasket.Model;

namespace ShoppingBasket.DecoratorPattern
{
    public abstract class Discount : IProduct
    {
        protected IProduct product;

        public Discount(IProduct product)
        {
            this.product = product;
        }

        public virtual string GetName()
        {
            return product.GetName();
        }

        public virtual double GetPrice()
        {
            return product.GetPrice();
        }
    }
}
