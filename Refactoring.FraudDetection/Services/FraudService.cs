using Refactoring.FraudDetection.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.FraudDetection.Services
{
    public class FraudService : FraudDetectionRules, IFraudService
    {
        public IEnumerable<FraudResult> GetFrauds(List<Order> orders)
        {
            var fraudResults = new List<FraudResult>();
            // CHECK FRAUD
            for (int i = 0; i < orders.Count; i++)
            {
                var baseOrder = orders[i];

                for (int j = i + 1; j < orders.Count; j++)
                {
                    var currentOrder = orders[j];
                    var isFraudulent = IsFraudulentOrder(baseOrder, currentOrder);

                    if (isFraudulent)
                    {
                        fraudResults.Add(CreateFraudulentResult(currentOrder));
                    }
                }
            }
            return fraudResults;
        }

        private FraudResult CreateFraudulentResult(Order order)
        {
            return new FraudResult { IsFraudulent = true, OrderId = order.OrderId };
        }
    }
}
