using ShoppingBasket.Logger;
using ShoppingBasket.Model;
using System;
using System.Collections.Generic;

namespace ShoppingBasket.Service
{
    public class ShoppingOrder
    {
        private ConsoleLogger consoleLogger;
        private IList<IProduct> productsInChart;

        public ShoppingOrder()
        {
            consoleLogger = new ConsoleLogger();
            productsInChart = new List<IProduct>();
        }

        public void AddProductToChart(IProduct product, int quantity)
        {
            try
            {
                if (product != null)
                {
                    while (quantity-- > 0)
                    {
                        productsInChart.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {
                consoleLogger.LogError(ex);
                throw ex;
            }
        }

        public double GetTotalPrice()
        {
            try
            {
                Order order = new Order(productsInChart);
                return Math.Round(order.CalculateTotalPrice(), 2);
            }
            catch (DivideByZeroException dze)
            {
                consoleLogger.LogError(dze);
                throw dze;
            }
            catch (NullReferenceException nre)
            {
                consoleLogger.LogError(nre);
                throw nre;
            }
            catch (Exception ex)
            {
                consoleLogger.LogError(ex);
                throw ex;
            }
        }
    }
}
