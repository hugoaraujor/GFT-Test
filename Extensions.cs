using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
	public static class Extensions
	{
		public static int NumberRows(this List<string> value)
		{
			return value.Count;
			
		}
		public static int NumberColumns(this List<string> value)
		{
			return value[0].Length;
			
		}
	}
}

