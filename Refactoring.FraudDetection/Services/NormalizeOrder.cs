using Refactoring.FraudDetection.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.FraudDetection.Services
{
    public class NormalizeOrder
    {
        public Order Normilize(Order order)
        {
            order.Email = NormilizeEmail(order.Email);
            order.State = NormilizeState(order.State);
            order.Street = NormilizeStreet(order.Street);

            return order;
        }

        protected virtual string NormilizeEmail(string email)
        {
            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return string.Join("@", new string[] { aux[0], aux[1] });
        }

        protected virtual string NormilizeState(string state)
        {
            return state
                .Replace("il", "illinois")
                .Replace("ca", "california")
                .Replace("ny", "new york");
        }

        protected virtual string NormilizeStreet(string street)
        {
            return street
                .Replace("st.", "street")
                .Replace("rd.", "road");
        }
    }
}
