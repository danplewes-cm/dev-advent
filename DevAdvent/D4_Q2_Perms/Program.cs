using System;
using System.Collections.Generic;

namespace D4_Q2_Perms
{
    class Program
    {
	    public static void Main()
	    {
		    Process(new List<int>() { 1, 2, 3, 4, 5 });

		    Console.Read();
	    }

	    private static void Process(List<int> input)
	    {
		    List<List<int>> perms = GetPermutations(input);

		    foreach (var perm in perms)
		    {
			    Console.WriteLine("[" + string.Join(",", perm) + "]");
		    }
	    }

	    public static List<List<int>> GetPermutations(List<int> input, int startIndex = 0)
	    {
		    List<List<int>> output = new List<List<int>>();

		    if (startIndex == input.Count - 1)
		    {
			    output.Add(new List<int>(input));
		    }
		    else
		    {
			    for (int i = startIndex; i < input.Count; i++)
			    {
				    int temp = input[startIndex];
				    input[startIndex] = input[i];
				    input[i] = temp;

				    output.AddRange(GetPermutations(input, startIndex + 1));
			    }
		    }

		    return output;
	    }
	}
}
