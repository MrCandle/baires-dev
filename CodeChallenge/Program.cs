using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace CodeChallenge
{
	class Program
	{
		static void Main(string[] args)
		{
			var people = new List<Person>();
			var reader = new AppSettingsReader();
			string filename = reader.GetValue("filename", typeof(string)).ToString();

			Console.Write("Reading File...");
			using (StreamReader sr = new StreamReader(filename))
			{
				while (sr.Peek() >= 0)
				{
					var split = sr.ReadLine().Split('|');
					people.Add(new Person(split[0], split[1], split[2], split[3], split[4], split[5], split[6], split[7]));
				}
			}

			Console.WriteLine("DONE");
			Console.WriteLine("Lines found: " + people.Count);

			string output = reader.GetValue("output", typeof(string)).ToString();
			Console.Write("Writing File...");
			using (StreamWriter sw = new StreamWriter(output))
			{
				people.OrderByDescending(x => ponderate(x)).ToList().GetRange(0, 100).ForEach(y => sw.WriteLine(y.Id));
			}

			Console.WriteLine("DONE");
			Console.ReadLine();
		}

		private static int ponderate(Person x)
		{
			var points = 0;
			points += ponderateRole(x);
			points += ponderateRecommendations(x);
			points += ponderateConnections(x);
			points += ponderateIndustry(x);
			points += ponderateCountry(x);
			return points;
		}

		private static int ponderateCountry(Person p)
		{
			string[] latam = new string[] { "argentina", "bolivia", "brasil", "chile", "colombia", "ecuador", "paraguay", "perú", "uruguay", "venezuela" };
			if (latam.Contains(p.Country.ToLower()))
			{
				return 125;
			}
			return 0;
		}

		private static int ponderateIndustry(Person p)
		{
			string[] industries = new string[] { "it", "technology", "information", "software", "engineering", "internet", "outsourcing", "telecommunications" };
			var split = p.Industry.Split(' ');
			foreach (var item in split)
			{
				if (industries.Contains(item.ToLower()))
				{
					return 100;
				}
			}
			return 0;
		}

		private static int ponderateConnections(Person p)
		{
			return Convert.ToInt32(int.Parse(p.NumberOfConnections) / 10);
		}

		private static int ponderateRecommendations(Person p)
		{
			if (!string.IsNullOrWhiteSpace(p.NumberOfRecommendations))
				return Convert.ToInt32(int.Parse(p.NumberOfRecommendations) / 2);
			return 0;
		}

		private static int ponderateRole(Person p)
		{
			string[] titles = new string[] { "cto", "ceo", "technologist", "engineering", "coo", "recruitment", "founder", "owner", "telecommunications" };
			foreach (var item in p.CurrentRole.Split(' '))
			{
				if (titles.Contains(item.ToLower()))
				{
					return 120;
				}
			}
			return 0;
		}
		
	}
}
