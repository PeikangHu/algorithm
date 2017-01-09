using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public class Solution
	{
		public string ToHex(int num)
		{
			var result = "";

			for (int i = 0; num != 0 && i < 8; i++)
			{
				int t = num & 0xf;
				if (t >= 10) result = (char)('a' + t - 10) + result;
				else result = (char)('0' + t) + result;
				num >>= 4;
			}

			return result == "" ? "0" : result;
		}
	}
}