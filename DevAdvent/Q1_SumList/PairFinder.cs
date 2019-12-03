using System;
using System.Collections.Generic;
using System.Linq;

namespace Q1_SumList
{
	public class PairFinder
	{
		private readonly List<int> _inputFiles;

		public PairFinder(int[] inputFiles) : this(inputFiles.ToList()) { }
		public PairFinder(List<int> inputFiles)
		{
			_inputFiles = inputFiles;
		}

		// Shitty O(n2) version to start testing with
		// Had considered the top >--< bottom squeeze version, but was trying to think of a version without sort
		// Then everyone started blabbing about their own version so it felt like cheating to do something different
		public Tuple<int, int> FindPairForNum(int num)
		{
			for (int i = 0; i < _inputFiles.Count - 1; i++)
			{
				int searchKey = num - _inputFiles[i];

				for (int j = i + 1; j < _inputFiles.Count; j++)
				{
					if (_inputFiles[j] == searchKey)
					{
						return new Tuple<int, int>(_inputFiles[i], _inputFiles[j]);
					}
				}
			}

			return null;
		}
	}
}
