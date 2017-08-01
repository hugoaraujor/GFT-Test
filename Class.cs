using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
	public class Class
	{
		public static List<Results> LstResult = new List<Results>();
		public static List<PreResults> PreList = new List<PreResults>();

		//base.json structure of the file
		// Classes to produce the output
		public class PreResults
		{
			public string Word { get; set; }
			public int X { get; set; }
			public int Y { get; set; }
			public Direction Z { get; set; }
		}
		public class Results
		{
			public string word { get; set; }
			public List<Breakdown> breakdown { get; set; }

		}
		

		public class coordinateExtended
		{
			public coordinateExtended(int value1, int value2, Direction value3)
			{
				this.x = value1;
				this.y = value2;
				this.z = value3;
			}
			public int x { get; set; }
			public int y { get; set; }
			public Direction z { get; set; }
		}

		public class Breakdown
		{
			public char character { get; set; }
			public int row { get; set; }
			public int column { get; set; }
			

		}

		public enum Direction
		{
			H,//HOrizontal
			V,//Vertical
			HR,//Horizontal Backward
			VR,//Vertical Backward
			DL,//Diagonal
			DLR,//Diagonal reverse
			DR,//Diagonal UP to theRight
			DRR,
			//Diagonal Up to Right  Reverse
			NONE
		};



		//base.json structure of the file
		public class Ibase
		{
			public string source { get; set; }
			public string replacement { get; set; }

		}

		//words.json structure of the file		
		public class IWords
		{
			public string word { get; set; }


		}

		/// <summary>
		///Values.json structure of the file 
		/// </summary>
		public class Rootobject
		{
			public noderesult[][] items { get; set; }
		}

		public class noderesult
		{
			public int order { get; set; }
			public int rule { get; set; }
			public bool isTermination { get; set; }
		}
		//-end of the classes defined to Values.json

	}
}
