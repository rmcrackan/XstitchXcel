using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using XstitchXcelLib.Config;
using XstitchXcelLib.DataClasses;

namespace XstitchXcelLib
{
	public class DmcColorProcessor
	{
		private List<DmcColor> dmcColors { get; } = Configuration.GetDmcColors();

		public bool TryGetMatch(Color color, out DmcColor dmcColor)
		{
			dmcColor = GetMatch(color);
			return dmcColor is not null;
		}

		public DmcColor GetMatch(Color color) => dmcColors.SingleOrDefault(d => color.IsEquivalent(d.Color));

		public DmcColor GetByDmcNumber(string color) => dmcColors.SingleOrDefault(d => string.Equals(d.DmcNumber, color.Trim(), StringComparison.OrdinalIgnoreCase));

		/// <summary>sort by DMC color name, then by hex for non-DMC</summary>
		public IOrderedEnumerable<Color> GetSortedColors(List<Pixel> pixels) =>
			pixels
			.GetColors()
			// sort DMC numbers, then non-DMC
			.OrderBy(c => TryGetMatch(c, out var d) ? d.DmcNumber : "ZZZ" + c.GetHexColor());

		private Dictionary<int, List<(DmcColor dmcColor, double score)>> naiveCache { get; } = new Dictionary<int, List<(DmcColor dmcColor, double score)>>();
		public List<DmcColor> GetNearestNaive(Color color)
		{
			var argb = color.ToArgb();
			if (!naiveCache.ContainsKey(argb))
				calculateWeights(color);
			return naiveCache[argb]
				.OrderBy(l => l.score)
				.Select(l => l.dmcColor)
				.ToList();
		}

		private Dictionary<int, List<(DmcColor dmcColor, double score)>> weightedCache { get; } = new Dictionary<int, List<(DmcColor dmcColor, double score)>>();
		public List<DmcColor> GetNearestWeighted(Color color)
		{
			var argb = color.ToArgb();
			if (!weightedCache.ContainsKey(argb))
				calculateWeights(color);
			return weightedCache[argb]
				.OrderBy(l => l.score)
				.Select(l => l.dmcColor)
				.ToList();
		}

		// calc both naive and weighted in 1 pass
		private void calculateWeights(Color color)
		{
			var argb = color.ToArgb();

			var naive = new List<(DmcColor, double)>();
			naiveCache.Add(argb, naive);

			var weighted = new List<(DmcColor, double)>();
			weightedCache.Add(argb, weighted);

			// calc closest colors
			foreach (var dmcColor in dmcColors)
			{
				// https://stackoverflow.com/a/1847112

				// d = (r2-r1)^2 + (g2-g1)^2 + (b2-b1)^2
				var d1
					= Math.Pow(color.R - dmcColor.Color.R, 2)
					+ Math.Pow(color.G - dmcColor.Color.G, 2)
					+ Math.Pow(color.B - dmcColor.Color.B, 2);
				naive.Add((dmcColor, d1));

				// d = ((r2-r1)*0.3)^2 + ((g2-g1)*0.59)^2 + ((b2-b1)*0.11)^2
				var d2
					= Math.Pow((color.R - dmcColor.Color.R) * 0.3, 2)
					+ Math.Pow((color.G - dmcColor.Color.G) * 0.59, 2)
					+ Math.Pow((color.B - dmcColor.Color.B) * 0.11, 2);
				weighted.Add((dmcColor, d2));
			}
		}
	}
}
