using Refactoring.FraudDetection.Models;
using Refactoring.FraudDetection.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.FraudDetection.Factory
{
    public abstract class OrderFactory
    {
        protected char FileSepatator { get; set; } = ',';
        NormalizeOrder normalizeRules;

        public  OrderFactory(NormalizeOrder normalizeRules) {
            this.normalizeRules = normalizeRules;
        }

        public Order BuildOrder(string line)
        {
            string[] items = spliItem(line);
            return normalizeRules.Normilize(CreateOrder(items));
        }

        private string[] spliItem(string line)
        {
            return line.Split(new[] { FileSepatator }, StringSplitOptions.RemoveEmptyEntries);
        }

        protected abstract Order CreateOrder(string[] items);
    }
}
