using System;
using System.Collections.Generic;

namespace D4_Q1_Contiguous_Sum
{
    class Program
    {
		public static void Main()
	    {
		    Process(new List<int> { 15, 16, -66, 17, 18 });
		    Process(new List<int> { 34, -50, 42, 14, -5, 86, -50, -50, -38 });
		    Process(new List<int> { 34, -50, 42, 14, -5, 86 });
		    Process(new List<int> { -5, -1, -8, -9 });

		    Console.Read();
	    }

	    private static void Process(List<int> input)
	    {
		    int maxSum = FindMaxSum(input);

		    Console.WriteLine(string.Join(",", input));
		    Console.WriteLine("Max Sum: " + maxSum);
	    }

	    private static int FindMaxSum(List<int> inputData)
	    {
		    if (inputData.Count == 0)
			    return 0;

		    int currTestSum = 0;
		    int bestSum = int.MinValue;

		    for (int i = 0; i < inputData.Count; i++)
		    {
			    currTestSum += inputData[i];

			    if (currTestSum > bestSum)
				    bestSum = currTestSum;

			    if (currTestSum < 0)
				    currTestSum = 0;
		    }

		    if (bestSum < 0)
			    bestSum = 0;

		    return bestSum;
	    }
	}
}
