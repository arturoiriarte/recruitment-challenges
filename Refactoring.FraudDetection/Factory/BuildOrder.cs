using Refactoring.FraudDetection.Models;
using Refactoring.FraudDetection.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.FraudDetection.Factory
{
    public class BuildOrder : OrderFactory
    {
        public BuildOrder(NormalizeOrder normalizeRules) : base(normalizeRules)
        {
        }

        public enum ArrayItem
        {
            OrderId,
            DealId,
            Email ,
            Street,
            City,
            State,
            ZipCode,
            CreditCard,
        }

        protected override Order CreateOrder(string[] items)
        {
            return new Order
            {
                OrderId = int.Parse(items[(int)ArrayItem.OrderId]),
                DealId = int.Parse(items[(int)ArrayItem.DealId]),
                Email = items[(int)ArrayItem.Email].ToLower(),
                Street = items[(int)ArrayItem.Street].ToLower(),
                City = items[(int)ArrayItem.City].ToLower(),
                State = items[(int)ArrayItem.State].ToLower(),
                ZipCode = items[(int)ArrayItem.ZipCode],
                CreditCard = items[(int)ArrayItem.CreditCard]
            };
        }
    }
}
