using System;
using System.Collections.Generic;

namespace D2_Q1_Largest_Product
{
    class Program
    {
        static void Main(string[] args)
        {           
	        List<int> input = DataGenerator.DataGeneratorUtils.FetchData(-10, 10, 10);

	        if (input.Count > 3)
	        {
				ProductFinder pf = new ProductFinder(input);
				Console.WriteLine(pf.GetLargestProduct());
	        }

			Console.WriteLine("Done");
			Console.Read();
		}
    }
}
