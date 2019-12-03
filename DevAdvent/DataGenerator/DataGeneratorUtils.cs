using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataGenerator
{
    public static class DataGeneratorUtils
    {
	    public static List<int> FetchData(int min, int max, int count)
	    {
			Random r = new Random();
		    List<int> rand = new List<int>(count);
		    for (int i = 0; i < count; i++)
		    {
			    rand.Add(r.Next(min, max));
		    }

		    return rand;
	    }
	}
}
