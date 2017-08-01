using System;
using System.Collections.Generic;
using System.Linq;
using static ConsoleTest.Class;
using static ConsoleTest.Search;
namespace ConsoleTest
{/// <summary>
 /// Programming Exercise for GFT Hiring Process
 /// Author:Hugo Araujo
 /// Date:12/07/2017
 /// According:https://github.com/GFTRecruitmentCR/programming_exercise
 /// </summary>
	class Program
	{   

		/// <summary>
		/// Main Function to the Markov Solution proposed
		/// </summary>
		static void Main()
		{	
			Solution();
			Console.ReadLine();
		}

		static void Solution()
		{
			//Populate data
			getLists();
			//Aplying Markov
			GetMarkov();
			//Print Matrix
			PrintMatrix();
			Search.Searchwords(AllLists.Lstwords);
			FormatOutput.Json();
			Console.WriteLine("Press any Key to Continue...");

		}
		/// <summary>
		/// Populate List to be used
		/// </summary>
		static void getLists()
		{
			loader newloader = new loader();
			AllLists.Lstbase = newloader.GetReaderBase("base.json");
			AllLists.Lstwords = newloader.GetWords("words.json");
			AllLists.LstWordsCyp = newloader.GetCypher("cypher.json");
			AllLists.xLstValues = newloader.GetValues("values.json");
		}
		/// <summary>
		/// Markov substitution function.
		/// </summary>
		static void GetMarkov()
		{
			var n = 0;
			var m = 0;

			var terminate = false;
			// <summary>
			///  Part 1: Markov Algorithm 
			/// </summary>
			if (AllLists.xLstValues != null)
				while (n < AllLists.xLstValues.Count() && (!terminate))
				{
					while (m < AllLists.xLstValues[n].Count())
					{
						var textline = AllLists.LstWordsCyp[m];
						var listelement = AllLists.xLstValues[n][m];
						Array.Sort(listelement, (x, y) => x.order.CompareTo(y.order));
						for (int ii = 0; ii < listelement.Count(); ii++)
						{
							var aux = (listelement[ii]);
							if (textline.IndexOf(AllLists.Lstbase[aux.rule].source) > -1)
							{
								textline = textline.Replace(AllLists.Lstbase[aux.rule].source, AllLists.Lstbase[aux.rule].replacement);
							}
							if (aux.isTermination) terminate = true;
						}
						m++;
						AllLists.MatrixResult.Add(textline);
					}

					n++;
				}
		}
		/// <summary>
		///  Print Matrix at Console
		///  Part 1: Result
		/// </summary>
		static void PrintMatrix()
		{
			Console.WriteLine("This is the Matrix Decyphered:");
			for (int a = 0; a < AllLists.MatrixResult.Count(); a++)
			{
				for (int b = 0; b < AllLists.MatrixResult[a].Length; b++)
				Console.Write(AllLists.MatrixResult[a][b] + " ");
				Console.WriteLine("");
			}
		}
	}
}

