using Refactoring.FraudDetection.Models;
using Refactoring.FraudDetection.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.FraudDetection.Services
{
    public class FraudDetectionRules : IFraudDetection
    {
        public bool IsFraudulentOrder(Order baseOrder, Order currentOrder)
        {
            return IsFraudByIdentity(baseOrder, currentOrder) ||
                IsFraudByAddress(baseOrder, currentOrder);
        }

        private bool IsFraudByIdentity(Order baseOrder, Order currentOrder)
        {
            if (baseOrder.DealId == currentOrder.DealId
                        && baseOrder.Email == currentOrder.Email
                        && baseOrder.CreditCard != currentOrder.CreditCard)
            {
                return true;
            }
            return false;
        }

        private bool IsFraudByAddress(Order baseOrder, Order currentOrder)
        {
            if (baseOrder.DealId == currentOrder.DealId
                && baseOrder.State == currentOrder.State
                && baseOrder.ZipCode == currentOrder.ZipCode
                && baseOrder.Street == currentOrder.Street
                && baseOrder.City == currentOrder.City
                && baseOrder.CreditCard != currentOrder.CreditCard)
            {
                return true;
            }
            return false;
        }
    }
}
