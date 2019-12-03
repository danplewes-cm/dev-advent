using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DataGenerator;

namespace Q1_SumList
{
    class Program
    {
	    private static PairFinder _finder;

		static void Main(string[] args)
		{
			List<int> inputFiles = DataGeneratorUtils.FetchData(-20000, 20000, 100000);
				
			_finder = new PairFinder(inputFiles);

			Random r = new Random();
			List<TimeSpan> stats = new List<TimeSpan>();
			for (int i = 0; i < 1000; i++)
			{
				stats.Add(ComputeSum(r.Next(-20000, 20000)));
			}

			Console.WriteLine($"Total Time: {stats.Sum(a => a.Milliseconds)}ms ({stats.Sum(a => a.Ticks)} ticks)");
			Console.WriteLine($"Average Time: {stats.Average(a => a.Milliseconds)}ms ({stats.Average(a => a.Ticks)} ticks)");

			Console.Read();
        }

	    private static TimeSpan ComputeSum(int k)
	    {
		    Stopwatch s = new Stopwatch();
		    s.Start();
		    Tuple<int, int> pair = _finder.FindPairForNum(k);
		    s.Stop();

		    if (pair != null)
		    {
			    Console.WriteLine($"{pair.Item1} + {pair.Item2} = {k}. Found in {s.ElapsedMilliseconds}ms ({s.ElapsedTicks} ticks)");
		    }
		    else
		    {
			    Console.WriteLine($"No match for {k} found in {s.ElapsedMilliseconds}ms ({s.ElapsedTicks} ticks)");
		    }

		    return s.Elapsed;
	    }	    
    }
}
