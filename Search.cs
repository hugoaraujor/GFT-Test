
using System;
using System.Collections.Generic;
using static ConsoleTest.Class;
using static ConsoleTest.AllLists;
namespace ConsoleTest
{
	public class Search
	{
		
	
		/// <summary>
		///  Search function to find word in puzzle Exercise Part 2 
		/// </summary>
		/// <param name="ListWords"></param>
		public static void Searchwords(List<String> ListWords)
		{
			for (int w = 0; w < ListWords.Count; w++)
			{
				var word = ListWords[w];
				Console.Write("Searching..."+word);
				var aux = Search.FindWord(word, MatrixResult);
				if (!aux)
					Console.Write(" Not Found");
				Console.WriteLine("");
			}
		}
		/// <summary>
		/// Find a word (s) in the puzzle
		/// </summary>
		/// <param name="s"></param>
		/// <param name="Matrix"></param>
		/// <returns></returns>
		public static bool FindWord(string s, List<String> Matrix)
		{
			bool resp = false;
			for (int a = 0; a < Matrix.NumberRows(); a++)
			{
				for (int b = 0; b < Matrix.NumberColumns(); b++)
				{
					var founded = FindFirst(s[0], (Char)Matrix[a][b]);
					if (founded)
					{
						Direction lookupdir = getdirection(s[1], Matrix, new coordinateExtended(a, b,0));
						var readw = readWord(s, Matrix, new coordinateExtended(a, b, lookupdir));
						if ((lookupdir != Direction.NONE) && (readw))
						{
							Console.Write(" Founded at ({0},{1}) Direction:{2}",a,b,lookupdir );
							AdditemFound(s, a, b, lookupdir);
							resp = true;
						}
					}
				}
			}
			return resp;
		}
		/// <summary>
		/// readWord: Function returns true if a complete word is readed in the direction specified not returns false
		/// </summary>
		/// <param name="s">Word to Search</param>
		/// <param name="Matrix">The Matrix</param>
		/// <param name="ce">Coodinate extended x,y plus direction to follow</param>
		/// <returns></returns>
		public static bool readWord(string s, List<String> Matrix, coordinateExtended ce)
		{
			var px = ce.x;
			var py = ce.y;
			var n = 0;
			var ci = 0;
			bool resp=false;
			coordinateExtended d = new coordinateExtended(px, py, ce.z);
			while ( (n != -1) && ci < s.Length && py < Matrix[0].Length && px < Matrix.Count)
			{
				if (py < Matrix[0].Length)
				{
					if (s[ci] == (Char)Matrix[px][py])
					{
						d = FormatOutput.CalculateNextposition(new coordinateExtended(d.x, d.y, d.z));
						px = d.x;
						py = d.y;
						n++;
					}
					else
						n = -1;
				}
				ci++;
			}
			if (n == s.Length)
			{
				resp = true;
			}
			return resp;
		}
		/// <summary>
		/// Find the first letter of each word in the puzzle with each position
		/// comparing first letter and current position
		/// </summary>
		/// <param name="c">Char to be compared</param>
		/// <param name="m">m char </param>
		/// <returns></returns>
		public static bool FindFirst(Char c, Char m)
		{
			if (m == c)
			{
				return true;
			}
			return false;
		}
		public static Direction getdirection(char c, List<String> puzzle, coordinateExtended pos)
		{
			Direction dtosearch = Direction.NONE;
			int px = pos.x;
			int py = pos.y;
			int width = puzzle.NumberColumns();
			int rows = puzzle.NumberRows();

			if (px - 1 > 0)
			{
				if (puzzle[px - 1][py] == c) dtosearch = Direction.VR;
				if (py - 1 > 0 && puzzle[px - 1][py - 1] == c) dtosearch = Direction.DRR;
				if (py + 1 < width && puzzle[px - 1][py + 1] == c) dtosearch = Direction.DLR;
			}
			    if (py + 1 < width && puzzle[px][py + 1] == c) dtosearch = Direction.H;
			    if (py - 1 > 0 && puzzle[px][py - 1] == c) dtosearch = Direction.HR;
			    if (px + 1 < rows && py + 1 < width)
			{
				if (py + 1 < width && puzzle[px + 1][py + 1] == c) dtosearch = Direction.DR;
				if (puzzle[px + 1][py] == c) dtosearch = Direction.V;
				if (py - 1 > 0 && puzzle[px + 1][pos.y - 1] == c) dtosearch = Direction.DL;
			}

			return dtosearch;
		}
		private static void AdditemFound(string w, int x, int y, Direction p)
		{
			PreList.Add(new PreResults { Word = w, X = x, Y = y, Z = p });

		}

	}
}
