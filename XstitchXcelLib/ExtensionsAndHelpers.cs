using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using XstitchXcelLib.DataClasses;

namespace XstitchXcelLib
{
	public static class HelperMethods
	{
		private static Regex isHex { get; } = new("^\\s*(#[0-9a-f]{3}|#?[0-9a-f]{6})\\s*$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
		public static Color SmartColorFinder(string colorString, DmcColorProcessor processor)
		{
			// try to convert from hex:
			//   #hhh
			//   #hhhhhh
			//   hhhhhh
			if (isHex.IsMatch(colorString))
				return HexToColor(colorString);

			// transparent
			if (colorString.Trim().ToUpper() == "T")
				return Color.Transparent;

			// else: try DMC
			var dmc = processor.GetByDmcNumber(colorString);
			if (dmc is not null)
				return dmc.Color;

			return Color.Empty;
		}

		public static Color HexToColor(string hex)
		{
			if (hex is null)
				return Color.Empty;

			hex = hex.Trim().Trim('#').Trim();

			if (hex.Length != 3 && hex.Length != 6)
				return Color.Empty;

			try
			{
				return ColorTranslator.FromHtml("#" + hex);
			}
			catch
			{
				return Color.Empty;
			}
		}

		public static string GetUniqueFileName(string fileName)
		{
			if (!File.Exists(fileName))
				return fileName;

			var output = fileName;

			var i = 0;
			while (File.Exists(output))
				output = AddFileSuffix(fileName, $" ({++i})");

			return output;
		}

		public static string AddFileSuffix(string fileName, string suffix)
			=> Path.Combine(
				Path.GetDirectoryName(fileName),
				$"{Path.GetFileNameWithoutExtension(fileName)}{suffix}{Path.GetExtension(fileName)}");
	}

	public static class ExtensionMethods
	{
		public static bool IsEquivalent(this Color color1, Color color2) => color1.ToArgb() == color2.ToArgb();
		public static bool IsTransparent(this Color color) => color.IsEquivalent(Color.Transparent);
		public static bool IsWhite(this Color color) => color.IsEquivalent(Color.White);
		public static int ToOle(this Color color) => ColorTranslator.ToOle(color);

		public static List<Color> GetColors(this IEnumerable<Pixel> pixels)
			=> pixels
			.GetColorsAndCounts()
			.Select(g => g.Color)
			.ToList();

		/// <summary>
		/// default: omit transparent
		/// </summary>
		/// <param name="pixels"></param>
		/// <returns></returns>
		public static List<(Color Color, int Count)> GetColorsAndCounts(this IEnumerable<Pixel> pixels)
			=> pixels.GetColorsAndCounts(false);

		public static List<(Color Color, int Count)> GetColorsAndCounts(this IEnumerable<Pixel> pixels, bool includeTransparent)
			=> pixels
			.Where(p => !p.Color.IsTransparent() || includeTransparent)
			.Select(p => p.Color)
			.GroupBy(p => p)
			.Select(g => (Metric: g.Key, Count: g.Count()))
			.OrderByDescending(x => x.Count)
			.ToList();

		public static string ToHex(this Color color)
			=> color.IsTransparent()
			? "Transparent"
			: $"{color.R:X2}{color.G:X2}{color.B:X2}";

		// https://stackoverflow.com/a/1855903
		public static Color GetContrastColor(this Color color)
		{
			// Counting the perceptive luminance - human eye favors green color... 
			var luminance = (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;

			// bright colors - black font
			// dark colors - white font
			var d = luminance > 0.5 ? 0 : 255;
			return Color.FromArgb(d, d, d);
		}
	}
}
