using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace algorithm.BasicDataStructure
{
	// Balanced Search Tree
    public class RedBlackBST<KeyT, ValueT> where KeyT:IComparable
    {
		public Node<KeyT, ValueT> Root;
		public ValueT Get(KeyT key)
		{
			var temp = Root;
			while (temp != null)
			{
				int cmp = key.CompareTo(temp.Key);

				if (cmp < 0) temp = temp.Left;
				else if (cmp > 0) temp = temp.Right;
				else return temp.Value;
			}

			return default(ValueT);
		}

		public void Put(KeyT key, ValueT value)
		{
			Root = Put(Root, key, value);
			Root.IsRed = false;
		}

		private Node<KeyT, ValueT> Put(Node<KeyT, ValueT> node, KeyT key, ValueT value)
		{
			// insert at bottom (and color red)
			if (node == null) return new Node<KeyT, ValueT>(key, value, true);

			var compare = key.CompareTo(node.Key);

			if (compare < 0) node.Left = Put(node.Left, key, value);
			else if (compare > 0) node.Right = Put(node.Right, key, value);
			else node.Value = value;

			// Case 1. Lean Left: Right child red, left child black: rotate left
			if (IsRed(node.Right) && !IsRed(node.Left))  node = RotateLeft(node);
			// Case 2. Balance 4-node: Left child, left-left grand child red: rotate right.
			if (IsRed(node.Left) && IsRed(node.Left.Left)) node = RotateRight(node);
			// Case 3. Split 4-node: Both children red: flip colors
			if (IsRed(node.Left) && IsRed(node.Right)) FlipColors(node);

			return node;
		}

		// Orient a (temporarily) right-leaning red link to lean left.
		private Node<KeyT, ValueT> RotateLeft(Node<KeyT, ValueT> node)
		{
			var temp = node.Right;
			node.Right = temp.Left;
			temp.Left = node;
			temp.IsRed = node.IsRed;
			node.IsRed = true;

			return temp;
		}

		// Orient a left-leaning red link to (temporarily) lean right.
		private Node<KeyT, ValueT> RotateRight(Node<KeyT, ValueT> node)
		{
			var temp = node.Left;
			node.Left = temp.Right;
			temp.Right = node;
			temp.IsRed = node.IsRed;
			node.IsRed = true;
			return temp;
		}

		private void FlipColors(Node<KeyT, ValueT> node)
		{
			node.IsRed = true;
			node.Left.IsRed = false;
			node.Right.IsRed = false;
		}

		private bool IsRed(Node<KeyT, ValueT> node)
		{
			if (node == null) return false;
			return node.IsRed == true;
		}
    }

	public class Node<KeyT, ValueT>
	{
		public Node<KeyT, ValueT> Left;
		public Node<KeyT, ValueT> Right;

		public KeyT Key;
		public ValueT Value;

		public bool IsRed;	// only red and black

		public Node(KeyT key, ValueT value, bool isRed)
		{
			Key = key;
			Value = value;
			IsRed = isRed;
		}
	}
}
