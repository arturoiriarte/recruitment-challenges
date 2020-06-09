using Refactoring.FraudDetection.Factory;
using Refactoring.FraudDetection.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Refactoring.FraudDetection.Services
{
    public class OrderReader : IOrderFileReader
    {
        private OrderFactory factory;

        public OrderReader(OrderFactory factory)
        {
            this.factory = factory;
        }

        public IEnumerable<Order> Read(FileStream stream)
        {
            var lines = BreakLine(ReadFileContent(stream));
            ICollection<Order> orders = new List<Order>();
            foreach (var item in lines)
            {
                orders.Add(factory.BuildOrder(item));
            }
            return orders;
        }

        private IEnumerable<string> BreakLine(string fileContent)
        {
            return fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }

        private string ReadFileContent(FileStream orderStream)
        {
            string fileContent;
            using (StreamReader reader = new StreamReader(orderStream))
            {
                fileContent = reader.ReadToEnd();
            }
            return fileContent;
        }
    }
}
