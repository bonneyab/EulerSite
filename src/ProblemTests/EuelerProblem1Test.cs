using System.Collections.Generic;
using Contract;
using Problems;

namespace ProblemTests
{
    public class EulerProblem1 : IProblemTest
    {
        

        public bool Execute()
        {
            return GetSumOfMultiplesBelowNumber_below1000_returns233168();
        }

        public string Description => "If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23. " +
                                     "Find the sum of all the multiples of 3 or 5 below 1000.";
        public string Title => "Euler Problem 1";
        public string Answer => "233168";
        public string FileName => "Problem1.cs";

        public bool GetSumOfMultiplesBelowNumber_below1000_returns233168()
        {
            var problem1 = new Problem1();
            List<int> multiples = new List<int> { 3, 5 };
            var actual = problem1.GetSumOfMultiplesBelowNumber(1000, multiples);
            return 233168 == actual;
        }
    }
}