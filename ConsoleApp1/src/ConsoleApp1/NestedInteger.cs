using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public class NestedInteger
	{
		public NestedInteger() { }

		// Constructor initializes a single integer.
		public NestedInteger(int value) { }
		// @return true if this NestedInteger holds a single integer, rather than a nested list.
		public bool IsInteger() { return true; }

		// @return the single integer that this NestedInteger holds, if it holds a single integer
		// Return null if this NestedInteger holds a nested list
		public int GetInteger() { return 1; }

		// Set this NestedInteger to hold a single integer.
		public void SetInteger(int value) { }

		// Set this NestedInteger to hold a nested list and adds a nested integer to it.
		public void Add(NestedInteger ni) { }

		// @return the nested list that this NestedInteger holds, if it holds a nested list
		// Return null if this NestedInteger holds a single integer
		public IList<NestedInteger> GetList() { return null; }
	}
}
