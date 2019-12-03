using System;
using System.Collections.Generic;
using DataGenerator;

namespace Q2_Medians
{
    class Program
    {
        static void Main(string[] args)
        {
	        List<int> inputData = DataGeneratorUtils.FetchData(-10, 10, 10);
			List<int> sortedData = new List<int>(inputData);
			sortedData.Sort();

	        SelfBalancingTree tree = new SelfBalancingTree();

			Console.WriteLine(string.Join(",", inputData));
			Console.WriteLine(string.Join(",", sortedData));

	        for (var i = 0; i < inputData.Count; i++)
	        {		        
		        tree.AddValue(inputData[i]);
			    Console.WriteLine(tree.GetMedian());				
	        }

	        Console.WriteLine("Done");
	        Console.Read();
        }
    }
}

