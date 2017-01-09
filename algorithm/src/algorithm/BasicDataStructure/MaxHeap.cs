using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace algorithm.BasicDataStructure
{
	// Test case:
	// T P R N H O A E I G
	
	// Add S:
	// step 1: add to the end
	// step 2: swim
	//	T S R N P O A E I G H

	// Remove T:
	// step 1: Exchange with the last (with H)
	// step 2: sink
	//		S P R N H O A E I G

	// Remove S:
	//		R P O N H G A E I

	// Add S:
	//		S R O N P G A E I H

    public class MaxHeap<KeyT> where KeyT:IComparable
	{
		private int _count;
		private KeyT[] _maxHeap;

		public bool IsAny()
		{
			return _count != 0;
		}

		public MaxHeap(int capacity)
		{
			if (capacity <= 0) throw new ArgumentOutOfRangeException("Capacity should be greater than 0.");
			_maxHeap = new KeyT[capacity + 1];
		}

		public void Push(KeyT key)
		{
			_maxHeap[++_count] = key;
			Swim(_count);
		}

		public KeyT Pop()
		{
			KeyT max = _maxHeap[1];
			Exchange(1, _count--);
			Sink(1);
			_maxHeap[_count + 1] = default(KeyT);
			return max;
		}

		public KeyT Peek() => _maxHeap[1];

		public int Count => _count;

		// Swim to the top (larger than one or both) of its children's
		private void Swim(int k)
		{
			while (k > 1 && Less(k / 2, k))
			{
				Exchange(k, k / 2);
				k = k / 2;
			}
		}

		private void Sink(int k)
		{
			while (2 * k <= _count)
			{
				int j = 2 * k;
				if (j < _count && Less(j, j + 1)) j++;

				if (!Less(k, j)) break;

				Exchange(k, j);
				k = j;
			}
		}

		private bool Less(int i, int j)
		{
			return _maxHeap[i].CompareTo(_maxHeap[j]) < 0;
		}

		private void Exchange(int i, int j)
		{
			var temp = _maxHeap[i];
			_maxHeap[i] = _maxHeap[j];
			_maxHeap[j] = temp;
		}
    }
}
