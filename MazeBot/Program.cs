using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Options;

namespace MazeBot
{
	class Program
	{
		static void Main(string[] args)
		{
			string xmlFile = "";
			string lang = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
			bool show_help = false;


			OptionSet p = new OptionSet() {
				{
					"i|input=", "input XML with game definition. REQUIRED",
					v => xmlFile = v
				},
				{
					"l|lang=", "language of the program. OPTIONAL",
					v => lang = v
				},
				{ 
					"h|help",  "show this message and exit", 
					v => show_help = v != null 
				}
			};

			List<string> extra;
			try
			{
				extra = p.Parse(args);
			}
			catch (OptionException e)
			{
				Console.Write("MazeBot: ");
				Console.WriteLine(e.Message);
				Console.WriteLine("Try `MazeBot --help' for more information.");
				return;
			}

			CultureInfo ci = new CultureInfo(lang);
			CultureInfo.DefaultThreadCurrentUICulture = ci;


			if (show_help)
			{
				ShowHelp(p);
				return;
			}

			if (String.IsNullOrEmpty(xmlFile))
			{
				Console.WriteLine(Resources.sErrMissingOptionXmlFile);
				ShowHelp(p);
				return;
			}


			try
			{
				Play(xmlFile);
			}
			catch(Exception e)
			{
				Console.WriteLine("\n****************************************************************");
				Console.WriteLine(String.Format(Resources.sError, e.Message));
				Console.WriteLine("****************************************************************\n");
				ShowHelp(p);
			}
		}

		static void ShowHelp(OptionSet p)
		{
			Console.WriteLine("Usage: MazeBot [OPTIONS]");
			Console.WriteLine();
			Console.WriteLine("Options:");
			p.WriteOptionDescriptions(Console.Out);
		}

		private static void Play(string xmlFile)
		{
			string xmlString = File.ReadAllText(xmlFile);
			Game game = new Game();
			game.Initialize(xmlString);
			game.Play();
		}

	}
}
