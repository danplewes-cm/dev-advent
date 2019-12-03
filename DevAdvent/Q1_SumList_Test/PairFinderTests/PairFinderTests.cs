using System.Collections.Generic;
using NUnit.Framework;
using Q1_SumList;

// Some simple tests for PairFinder. Haven't really used NUnit (at least not in a while), so used this
// as an oportunity to test it out
namespace Q1_SumList_Test.PairFinderTests
{
	[TestFixture]
    class PairFinderTests
    {
	    [TestCase(-1)]
	    [TestCase(0)]
	    [TestCase(1)]
		public void When_ListIsEmpty_Then_ShouldReturnNull(int num)
	    {
			List<int> a = new List<int>();

			PairFinder pf = new PairFinder(a);

			Assert.IsNull(pf.FindPairForNum(num));
	    }

		[Test]
	    public void When_NoMatchFound_Then_ShouldReturnNull()
	    {
			List<int> a = new List<int> { 1, 2 };

			PairFinder pf = new PairFinder(a);

			Assert.IsNull(pf.FindPairForNum(4));
	    }

	    [Test]
	    public void When_PositiveMatchFound_Then_ShouldReturnNull()
	    {
		    List<int> a = new List<int> { 1, 2 };

		    PairFinder pf = new PairFinder(a);

		    Assert.IsNotNull(pf.FindPairForNum(3));
	    }

	    [Test]
	    public void When_NegativeMatchFound_Then_ShouldReturnNull()
	    {
		    List<int> a = new List<int> { -5, -2 };

		    PairFinder pf = new PairFinder(a);

		    Assert.IsNotNull(pf.FindPairForNum(-7));
	    }
	}
}
