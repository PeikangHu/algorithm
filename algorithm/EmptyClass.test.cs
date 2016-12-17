using System;
using Xunit;

namespace algorithm
{
    public class EmptyClassTest
	{
		[Fact]
		public void test1()
		{
			Assert.Equal(3, Math.Max(3, 2));
		}
	}
}
