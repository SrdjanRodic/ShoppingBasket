using ShoppingBasket.DecoratorPattern;
using ShoppingBasket.Model;
using ShoppingBasket.Model.Products;
using ShoppingBasket.Logger;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket.Service
{
    public class Order
    {
        private ConsoleLogger logger;
        private IList<IProduct> products;

        public Order(IList<IProduct> products)
        {
            logger = new ConsoleLogger();
            this.products = products;
        }

        public double CalculateTotalPrice()
        {
            const int AMOUNT_OF_MILK_FOR_DISCOUNT = 4;
            const int AMOUNT_OF_BUTTER_FOR_DISCOUNT = 2;

            logger.LogArticleInTheChart(products.Select(p => p.GetName()));

            double totalPrice = GetTotalPriceWithoutDiscount();

            totalPrice += IncludeDiscountFor<Milk>(new MilkDiscount(new Milk()), AMOUNT_OF_MILK_FOR_DISCOUNT);
            totalPrice += IncludeDiscountFor<Butter>(new BreadDiscount(new Bread()), AMOUNT_OF_BUTTER_FOR_DISCOUNT);

            logger.LogTotalPrice(totalPrice);

            return totalPrice;
        }

        private double GetTotalPriceWithoutDiscount()
        {
            return products.Sum(p => p.GetPrice());
        }

        private double IncludeDiscountFor<T>(Discount discountProduct, int amountOfProductForDiscount) where T : class
        {
            int numOfProductOfTypeInChart = GetNumOfProductOfTypeInChart<T>();
            int numOfProductForDiscount = GetNumOfProductForDiscount(numOfProductOfTypeInChart, amountOfProductForDiscount);

            logger.LogArticleWithDiscount(discountProduct.GetName(), numOfProductForDiscount);

            return GetTotalDiscountPrice(discountProduct, numOfProductForDiscount);
        }

        private int GetNumOfProductOfTypeInChart<T>() where T : class
        {
            return products.Where(p => p is T).Count();
        }

        private int GetNumOfProductForDiscount(int numOfProductOfTypeInChart, int amountOfProductForDiscount)
        {
            return numOfProductOfTypeInChart / amountOfProductForDiscount;
        }

        private double GetTotalDiscountPrice(Discount discountProduct, int numOfProductForDiscount)
        {
            return discountProduct.GetPrice() * numOfProductForDiscount;
        }
    }
}
