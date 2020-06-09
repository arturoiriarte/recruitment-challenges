using Algorithms.CountingBits;
using Refactoring.FraudDetection;
using Refactoring.FraudDetection.Factory;
using Refactoring.FraudDetection.Services;
using System;
using System.IO;

namespace PayvisionConsoleApp
{
    class Program
    {
        //just for some extra debugging experience
        static void Main(string[] args)
        {
            //var positiveBitCounter = new PositiveBitCounter();
            //var positiveBitResult = positiveBitCounter.Count(161);

            var fileName = "../../../../Refactoring.FraudDetection.Tests/Files/ThreeLines_FraudulentSecond.txt";

            //var fraudRadar = new FraudRadar();
            //var fraudResult = fraudRadar.Check(fileName);

            using FileStream fs = File.OpenRead(fileName);

            NormalizeOrder normalizeRule = new NormalizeOrder();
            OrderReader reader = new OrderReader(new BuildOrder(normalizeRule));
            FraudRadar fraudRadar = new FraudRadar(reader);
            fraudRadar.Check(fs);

        }
    }
}
