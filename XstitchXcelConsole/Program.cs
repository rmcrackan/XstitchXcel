using System;
using System.Collections.Generic;
using System.Linq;
using XstitchXcelLib.Tools;

namespace XstitchXcelConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Run();
			}
			//catch (Exception e) { Console.WriteLine(e); }
			finally
			{
				GC.Collect();
				GC.WaitForPendingFinalizers();

				Console.WriteLine();
				Console.WriteLine("====");
				Console.WriteLine("DONE");
			}
		}
		static void Run()
		{
			//var patternInputFile = @"C:\my\example\file.xlsx";

			//var api = EzApi.LoadPattern(patternInputFile);


			//api.DiscoverNonDmcAllSprites();


			//var oldHex = "C00000"; // non dmc
			//var newHex = "BB051F"; // dmc
			//api.ReplaceColors(oldHex, newHex);


			//api.PrintStitchStatsReport();


			//api.ConvertToPattern();


			//api.PrintCrtBlurConsole();
			//api.SaveCrtBlurFile();


			var list = new List<DmcColorName>
			{
				new DmcColorName(456),
				new DmcColorName(123),
				new DmcColorName('E', 123),
				new DmcColorName("white"),
				new DmcColorName("ecru"),
				new DmcColorName('C', "ecru"),
			};
			list.Sort();
		}
	}
}
