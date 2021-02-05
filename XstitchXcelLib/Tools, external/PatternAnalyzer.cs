using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using XstitchXcelLib.DataClasses;

namespace XstitchXcelLib.Tools
{
	public class PatternAnalyzer : ToolBase
	{
		private string reportExportDirectory { get; }

		public PatternAnalyzer(Pattern pattern) : base(pattern) => reportExportDirectory = Path.GetDirectoryName(pattern.InputFile);

		/// <summary>create reports of non-DMC colors</summary>
		public void DiscoverNonDmcAllSprites()
		{
			foreach (var sprite in Pattern.Sprites)
				DiscoverNonDmc(sprite);
		}

		/// <summary>create reports of non-DMC colors</summary>
		/// <param name="sprite"></param>
		public void DiscoverNonDmc(Sprite sprite)
		{
			Console.WriteLine(sprite);

			// print all colors contained in sprite. get unmatched colors
			var unmatchedColors = getUnmatchedColors(sprite);

			if (!unmatchedColors.Any())
			{
				Console.WriteLine("all colors match a DMC floss color");
				Console.WriteLine();
				return;
			}

			// only export to excel if there are unresolved dmc colors
			using var writer = new Utilities.EzExcelWriter(getFileName(sprite));
			writer.WriteRow(sprite.Name);
			writer.WriteRow("", "hex", "DMC", "R", "G", "B");

			foreach (var unmatchedColor in unmatchedColors)
			{
				// print unmatched color
				Console.WriteLine($"{unmatchedColor.GetHexColor()} : {unmatchedColor}");
				writer.WriteRow("", unmatchedColor.GetHexColor(), "", unmatchedColor.R, unmatchedColor.G, unmatchedColor.B, unmatchedColor);

				// print 3 naive and weighted matches
				printScores(writer, unmatchedColor, DmcColorProcessor.GetNearestNaive, "n", 3);
				printScores(writer, unmatchedColor, DmcColorProcessor.GetNearestWeighted, "w", 3);

				// blank row between colors
				writer.WriteRow();
			}
		}

		private List<Color> getUnmatchedColors(Sprite sprite)
		{
			var unmatchedColors = new List<Color>();

			foreach (var (clr, cnt) in sprite.Pixels.GetColorsAndCounts())
			{
				if (!DmcColorProcessor.TryGetMatch(clr, out var dmcMatch))
					unmatchedColors.Add(clr);

				Console.WriteLine($"- {cnt,3}: #{clr.GetHexColor()}. {(dmcMatch == default ? "NOT DMC" : $"DMC # {dmcMatch.DmcNumber} - {dmcMatch.Name}")}");
			}
			Console.WriteLine();

			return unmatchedColors;
		}

		private string getFileName(Sprite sprite)
		{
			const string lbl = "color picker";

			// put these into new dir which we must 1st create
			var colorPickerDir = Path.Combine(reportExportDirectory, lbl);
			Directory.CreateDirectory(colorPickerDir);

			return HelperMethods.GetUniqueFileName(Path.Combine(colorPickerDir, $"{lbl} - {sprite.Name}.xlsx"));
		}

		private static void printScores(Utilities.EzExcelWriter writer, Color unmatchedColor, Func<Color, List<DmcColor>> fn, string prefix, int takeCount)
		{
			var list = fn(unmatchedColor)
				.Take(takeCount)
				.ToList();

			for (var i = 0; i < list.Count; i++)
			{
				var label = $"{prefix}{i}";
				var d = list[i];

				Console.WriteLine($"- {label} {d.DmcNumber,6} #{d.Color.GetHexColor()} R={d.Color.R,3} G={d.Color.G,3} B={d.Color.B,3}");
				writer.WriteRow(label, d.Color.GetHexColor(), d.DmcNumber, d.Color.R, d.Color.G, d.Color.B, unmatchedColor, d.Color);
			}
			Console.WriteLine();
		}
	}
}
