using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Logger
{
    public class ConsoleLogger
    {
        public void LogArticleInTheChart(IEnumerable<string> productsName)
        {
            Console.WriteLine("List of products in the chart:");
            Console.WriteLine(string.Join(",\n", productsName));
        }

        public void LogArticleWithDiscount(string product, int quantity)
        {
            StringBuilder statisticsInfo = new StringBuilder();
            statisticsInfo.Append(product).Append(" - ").Append(quantity).Append(" pieces");
            Console.WriteLine(statisticsInfo);
        }

        public void LogTotalPrice(double totalPrice)
        {
            Console.WriteLine("Total price for this order: ");
            Console.WriteLine(totalPrice.ToString());
        }

        public void LogError(Exception ex)
        {
            string stackTrace = ex.StackTrace;
            while (ex.Message.Contains("inner exception"))
            {
                ex = ex.InnerException;
            }
            Console.WriteLine(ex.Message);
            Console.WriteLine(stackTrace);
        }

        internal void LogError(object dze)
        {
            throw new NotImplementedException();
        }
    }
}
