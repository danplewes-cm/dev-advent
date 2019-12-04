using System;
using System.Collections.Generic;

namespace D2_Q2_Stock_Calc
{
    class Program
    {
        static void Main(string[] args)
        {
	        List<int> input = DataGenerator.DataGeneratorUtils.FetchData(0, 10000,100);

			StockPicker sp = new StockPicker(input);
	        StockPicker.StockResult sr = sp.DetermineMaxProfit();

			Console.WriteLine($"Data: [{string.Join(",", input)}]");
	        if (sr != null)
	        {
				Console.WriteLine(sr);
	        }
			
			Console.WriteLine("Done");
	        Console.Read();
        }
    }
}
