using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingBasket.Model.Products;

namespace ShoppingBasket.Service.Tests
{
    [TestClass()]
    public class ShoppingOrderTests
    {
        private ShoppingOrder shoppingOrder = new ShoppingOrder();

        [TestMethod()]
        public void GetTotalPriceTest_NoDiscount_ReturnsCorrectTotalPrice()
        {
            shoppingOrder.AddProductToChart(new Butter(), 1);
            shoppingOrder.AddProductToChart(new Milk(), 1);
            shoppingOrder.AddProductToChart(new Bread(), 1);
            Assert.AreEqual(2.95, shoppingOrder.GetTotalPrice());
        }

        [TestMethod()]
        public void GetTotalPriceTest_BreadDiscount_ReturnsCorrectTotalPrice()
        {
            shoppingOrder.AddProductToChart(new Butter(), 2);
            shoppingOrder.AddProductToChart(new Bread(), 2);
            Assert.AreEqual(3.1, shoppingOrder.GetTotalPrice());
        }

        [TestMethod()]
        public void GetTotalPriceTest_MilkDiscount_ReturnsCorrectTotalPrice()
        {
            shoppingOrder.AddProductToChart(new Milk(), 4);
            Assert.AreEqual(3.45, shoppingOrder.GetTotalPrice());
        }

        [TestMethod()]
        public void GetTotalPriceTest_MilkAndBreadDiscount_ReturnsCorrectTotalPrice()
        {
            shoppingOrder.AddProductToChart(new Butter(), 2);
            shoppingOrder.AddProductToChart(new Milk(), 8);
            shoppingOrder.AddProductToChart(new Bread(), 1);
            Assert.AreEqual(9, shoppingOrder.GetTotalPrice());
        }
    }
}