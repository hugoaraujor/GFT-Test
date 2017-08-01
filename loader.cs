using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using System;
using static ConsoleTest.Class;

namespace ConsoleTest
{
	public class loader
	{
		
	//--------------------------------------------------------------------------
	// Read the base json file by deserializing from Json file base.json
	// and allocates the result in a list 
	//--------------------------------------------------------------------------
	public  List<Ibase> GetReaderBase(string filename)
		{
			List<Ibase> Lstbaseit = new List<Ibase>();
			using (StreamReader reader = new StreamReader(filename))
			{
				var jsonbase = File.ReadAllText(filename);

				Lstbaseit = JsonConvert.DeserializeObject<List<Ibase>>(jsonbase);
			}
			return Lstbaseit;
		}
		public List<noderesult[][]> GetValues(string filename)
		{
			List<noderesult[][]> vr = new List<noderesult[][]>();
			using (StreamReader reader = new StreamReader(filename))
			{
				var jsonbase = File.ReadAllText(filename);
				Rootobject vr2 = new Rootobject();
				vr2.items = JsonConvert.DeserializeObject<noderesult[][]>(jsonbase);
				vr.Add(vr2.items);
			}


			return vr;
		}
		//--------------------------------------------------------------------------
		// Read the words json file by deserializing from Json file words.json
		// and allocates the result in a list 
		//--------------------------------------------------------------------------
		public List<String> GetWords(string filename)
		{
			List<String> Lstwords = new List<String>();
			using (StreamReader reader = new StreamReader(filename))
			{
				var jsonbase = File.ReadAllText(filename);
				Lstwords = JsonConvert.DeserializeObject<List<String>>(jsonbase);
			}
			return Lstwords;
		}
		//--------------------------------------------------------------------------
		// Read the cypher json file by deserializing from Json file cypher.json
		// and allocates the result in a list 
		//--------------------------------------------------------------------------
		public List<String> GetCypher(string filename)
		{
			List<String> WordsCyphered = new List<String>();
			using (StreamReader reader = new StreamReader(filename))
			{
				var jsonbase = File.ReadAllText(filename);
				WordsCyphered = JsonConvert.DeserializeObject<List<String>>(jsonbase);
			}
			return WordsCyphered;
		}

	}
}
