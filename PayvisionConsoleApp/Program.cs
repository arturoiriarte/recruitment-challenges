using Algorithms.CountingBits;
using System;

namespace PayvisionConsoleApp
{
    class Program
    {
        //just for some extra debugging experience
        static void Main(string[] args)
        {
            var positiveBitCounte = new PositiveBitCounter();
            positiveBitCounte.Count(161);
        }
    }
}
