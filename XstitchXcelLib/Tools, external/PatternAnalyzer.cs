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
		public void ReportNonDmc()
		{
			Console.WriteLine(Pattern.Sprite);

			// print all colors contained in sprite. get unmatched colors
			var unmatchedColors = NonDmcColors();

			if (!unmatchedColors.Any())
			{
				Console.WriteLine("all colors match a DMC floss color");
				Console.WriteLine();
				return;
			}

			// only export to excel if there are unresolved dmc colors
			var colorPickerOutputXlsx = HelperMethods.GetUniqueFileName(Path.Combine(reportExportDirectory, $"{Pattern.Sprite.Name} - color picker.xlsx"));
			using var writer = new Utilities.EzExcelWriter(colorPickerOutputXlsx);
			writer.WriteRow(Pattern.Sprite.Name);
			writer.WriteRow("", "hex", "DMC", "R", "G", "B");

			foreach (var unmatchedColor in unmatchedColors)
			{
				// print unmatched color
				Console.WriteLine($"{unmatchedColor.ToHex()} : {unmatchedColor}");
				writer.WriteRow("", unmatchedColor.ToHex(), "", unmatchedColor.R, unmatchedColor.G, unmatchedColor.B, unmatchedColor);

				// print 3 naive and weighted matches
				printScores(writer, unmatchedColor, DmcColorProcessor.GetNearestNaive, "n", 3);
				printScores(writer, unmatchedColor, DmcColorProcessor.GetNearestWeighted, "w", 3);

				// blank row between colors
				writer.WriteRow();
			}
		}

		public List<Color> NonDmcColors()
		{
			var unmatchedColors = new List<Color>();

			foreach (var (clr, cnt) in Pattern.Sprite.Pixels.GetColorsAndCounts())
			{
				if (!DmcColorProcessor.TryGetMatch(clr, out var dmcMatch))
					unmatchedColors.Add(clr);

				Console.WriteLine($"- {cnt,3}: #{clr.ToHex()}. {(dmcMatch == default ? "NOT DMC" : $"DMC # {dmcMatch.DmcNumber} - {dmcMatch.Name}")}");
			}
			Console.WriteLine();

			return unmatchedColors;
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

				Console.WriteLine($"- {label} {d.DmcNumber,6} #{d.Color.ToHex()} R={d.Color.R,3} G={d.Color.G,3} B={d.Color.B,3}");
				writer.WriteRow(label, d.Color.ToHex(), d.DmcNumber, d.Color.R, d.Color.G, d.Color.B, unmatchedColor, d.Color);
			}
			Console.WriteLine();
		}
	}
}
