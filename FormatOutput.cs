using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using  static ConsoleTest.Class;

namespace ConsoleTest
{
	static public class FormatOutput
	{
		static public coordinateExtended CalculateNextposition(coordinateExtended pre)
		{
			var d = pre.z;
			var xi = pre.x;
			var yi = pre.y;
			//Calculate next position of character to format output breakdown
			//Verticals
			if (d == Direction.VR)
				xi--;
			if (d == Direction.V)
				xi++;
			//HOrizontals
			if (d == Direction.H)
				yi++;
			if (d == Direction.HR)
				yi--;
			//Diagonal Right
			if (d == Direction.DR)
			{
				yi++;
				xi++;
			}
			if (d == Direction.DRR)
			{
				yi--;
				xi--;
			}
			//Diagonal Left
			if (d == Direction.DL)
			{
				yi--;
				xi++;
			}
			if (d == Direction.DLR)
			{
				yi++;
				xi--;
			}
			return new coordinateExtended(xi, yi, d);
		}
		static public void Json()
		{
		

			foreach (PreResults pr in PreList)
			{
				int xi = pr.X;
				int yi = pr.Y;
				Direction d = pr.Z;
				coordinateExtended ce = new coordinateExtended(xi, yi, d);
					List<Breakdown> Lstpos = new List<Breakdown>();

				for (int l = 0; l < pr.Word.Length; l++)
				{
					
					Lstpos.Add(new Breakdown { character = pr.Word[l], row = xi, column = yi });
					ce = CalculateNextposition(ce);
					xi = ce.x;
					yi = ce.y;


				}
				LstResult.Add(new Results { word = pr.Word, breakdown = Lstpos });

			}
		
			CreateFile("Result.Json",LstResult);
		}
		static public void CreateFile(string xfilename,List<Results> listResult)
		{
			using (StreamWriter file = File.CreateText(@xfilename))
			{
				JsonSerializer serializer = new JsonSerializer();
				//serialize object directly into file stream
				serializer.Serialize(file,listResult);

					}
			Console.WriteLine("Se ha grabado en su disco el archivo:{0}", xfilename);
			Console.WriteLine("en el directorio de la Solucion.");
		}
	}
}
