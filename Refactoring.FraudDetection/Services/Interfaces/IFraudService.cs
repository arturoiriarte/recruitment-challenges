using Refactoring.FraudDetection.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.FraudDetection.Services.Interfaces
{
    public interface IFraudService
    {
        IEnumerable<FraudResult> GetFrauds(List<Order> orders);
    }
}
