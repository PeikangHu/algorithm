using algorithm.BasicDataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace algorithm.test.BasicDataStructure
{
    public class MaxHeapTest : IDisposable
	{
		private ITestOutputHelper _output;

		public MaxHeapTest(ITestOutputHelper output)
		{
			this._output = output;
			_output.WriteLine("Execute constructor!");
		}

		private MaxHeap<int> InitMaxHeap()
		{
			// Test case:
			// 17 15 12 10 8 7 6 5 3 1
			var maxHeap = new MaxHeap<int>(11);
			maxHeap.Push(10);
			maxHeap.Push(6);
			maxHeap.Push(15);
			maxHeap.Push(3);
			maxHeap.Push(8);
			maxHeap.Push(12);
			maxHeap.Push(17);
			maxHeap.Push(1);
			maxHeap.Push(5);
			maxHeap.Push(7);
			return maxHeap;
		}

		private string GetStringResult(MaxHeap<int> maxHeap)
		{
			var stringBuilder = new StringBuilder();
			while (maxHeap.IsAny())
			{
				var maxValue = maxHeap.Pop();
				stringBuilder.Append(maxValue);
				stringBuilder.Append(" ");
			}

			return stringBuilder.ToString();
		}

		[Fact]
		public void MaxHeapInitial()
		{
			var maxHeap = InitMaxHeap();
			Assert.Equal("17 15 12 10 8 7 6 5 3 1 ", GetStringResult(maxHeap));
		}


		[Fact]
		public void MaxHeapCombined()
		{
			var maxHeap = InitMaxHeap();

			// 17 15 12 10 8 7 6 5 3 1 
			maxHeap.Push(7);
			Assert.Equal("17 15 12 10 8 7 7 6 5 3 1 ", GetStringResult(maxHeap));

			maxHeap = InitMaxHeap();
			maxHeap.Pop();
			Assert.Equal("15 12 10 8 7 6 5 3 1 ", GetStringResult(maxHeap));

			maxHeap = InitMaxHeap();
			maxHeap.Push(1);
			Assert.Equal("17 15 12 10 8 7 6 5 3 1 1 ", GetStringResult(maxHeap));

			maxHeap = InitMaxHeap();
			maxHeap.Push(18);
			Assert.Equal("18 17 15 12 10 8 7 6 5 3 1 ", GetStringResult(maxHeap));

		}

		public void Dispose()
		{
			_output.WriteLine("Execute dispose!");
		}
	}
}
