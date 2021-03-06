﻿using System;
using System.Collections.Generic;
using System.Linq;
using Problems.Helpers;

namespace EulerProblems
{
//The prime 41, can be written as the sum of six consecutive primes:
//41 = 2 + 3 + 5 + 7 + 11 + 13
//This is the longest sum of consecutive primes that adds to a prime below one-hundred.
//The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.
//Which prime, below one-million, can be written as the sum of the most consecutive primes?
    public class Problem50
    {
        public int ConsecutivePrimeSum(int max)
        {
            var primes = PrimeNumberHelper.GetPrimeNumbersBelowNumber(max);

            var allSums = new List<List<Tuple<int, int>>>();
            int i = 0;
            while (i < primes.Count)
            {
                var sums = new List<Tuple<int, int>>();
                var next = 0;
                var terms = 0;
                foreach (var prime in primes.Skip(i))
                {
                    terms++;
                    next += prime;
                    if (next > max)
                    {
                        allSums.Add(sums);
                        break;
                    }
                    sums.Add(new Tuple<int, int>(terms, next));
                }
                i++;
            }
            var combinedSums = allSums.SelectMany(x => x).OrderByDescending(x => x.Item1).ToList();

            foreach (var sum in combinedSums)
            {
                if (primes.Contains(sum.Item2))
                    return sum.Item2;
            }
            return -1;
        }
    }
}