// <copyright file="PositiveBitCounter.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Algorithms.CountingBits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PositiveBitCounter
    {
        /* Using linq to reverse the binary string
         * And then looping through the string to take
         * the 1-bits position and finally count them
         */
        public IEnumerable<int> Count(int input)
        {
            if (input < 0)
                throw new ArgumentException("The input must be a positive value");

            if (input == 0)
                return new List<int> { 0 };

            List<int> list = new List<int>();
            var bits = Convert.ToString(input, 2).Reverse();

            for (int i = 0, len = bits.Count(); i < len; i++)
            {
                if (bits.ElementAt(i) == '1')
                {
                    list.Add(i);
                }
            }

            return list.Prepend(list.Count);
        }
    }
}
