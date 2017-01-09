using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace algorithm.QuickSort
{
    public class QuickUnionFind
    {
		private int[] id;
		private int[] size;

		public QuickUnionFind(int n)
		{
			id = new int[n];
			size = new int[n];

			// set id of each object to iteself
			for (int i = 0; i < n; i++)
			{
				id[i] = i;
			}
		}

		private int root(int i)
		{
			while (i != id[i])
			{
				id[i] = id[id[i]];	// path compression
				i = id[i];
			}
			return i;
		}

		public bool connected(int p, int q)
		{
			return root(p) == root(q);
		}

		public void union(int p, int q)
		{
			int i = root(p);
			int j = root(q);

			if (size[i] < size[j])
			{
				id[i] = j;
				size[j] += size[i];
			}
			else
			{
				id[j] = i;
				size[i] += size[j];
			}

			id[i] = j;
		}
    }
}
