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
        /*
         * I added the first 3 solutions I could think and find of when solving this problem
         * 
         * The first one is the best I could think of performance wise as it only perform logical operations 
         * 
         * The second and third one are easier to understand and extend because it works with strings
         * The third one is the same one as the second but without the need of reversing the string as it was suggested on the tips of the instruction file
         */ 

        public IEnumerable<int> Count(int input)
        {
            if (input < 0)
                throw new ArgumentException("The input must be a positive value");

            if (input == 0)
                return new List<int> { 0 };

            List<int> result = new List<int>();
            for (int i = 0; input > 0; i++)
            {
                //The & operator computes the bitwise logical AND of its operands
                if ((input & 1) == 1)
                {
                    result.Add(i);
                }
                //using the right-shit operator
                input >>= 1;
            }

            result.Insert(0, result.Count);
            return result;
        }

        /* Using linq to reverse the binary string
         * And then looping through the string to take
         * the 1-bits position and finally count them
         */
        //public IEnumerable<int> Count(int input)
        //{
        //    if (input < 0)
        //        throw new ArgumentException("The input must be a positive value");

        //    if (input == 0)
        //        return new List<int> { 0 };

        //    List<int> list = new List<int>();
        //    var bits = Convert.ToString(input, 2).Reverse();

        //    for (int i = 0, len = bits.Count(); i < len; i++)
        //    {
        //        if (bits.ElementAt(i) == '1')
        //        {
        //            list.Add(i);
        //        }
        //    }

        //    list.Insert(0, list.Count);
        //    return list;
        //}

        //this is the same one as the second solution but without reversing the result string
        //public IEnumerable<int> Count(int input)
        //{
        //    if (input < 0)
        //        throw new ArgumentException("The input must be a positive value");

        //    if (input == 0)
        //        return new List<int> { 0 };

        //    List<int> list = new List<int>();
        //    var bits = Convert.ToString(input, 2);

        //    for (int i = 0, len = bits.Count(); i < len; i++)
        //    {
        //        if (bits.ElementAt((len - 1) - i) == '1')
        //        {
        //            list.Add(i);
        //        }
        //    }

        //    list.Insert(0, list.Count);
        //    return list;
        //}
    }
}
