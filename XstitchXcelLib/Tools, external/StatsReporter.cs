using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using XstitchXcelLib.DataClasses;

namespace XstitchXcelLib.Tools
{
	public record StatEntry(int Count, Color Color, DmcColor DmcColor)
	{
		// https://lordlibidan.com/how-many-stitches-can-you-get-out-of-a-8m-skein/
		// 14 count
		private const float EFFICIENT_STITCHES = 1850;
		private const float AVERAGE_STITCHES = 1750;
		private const float INEFFICIENT_STITCHES = 1650;

		public float MinSkeins => Count / EFFICIENT_STITCHES;
		public float MaxSkeins => Count / INEFFICIENT_STITCHES;
		public string Hex => Color.GetHexColor();
		public string DmcNumber => DmcColor?.DmcNumber ?? "[not dmc]";
		public string DmcName => DmcColor?.Name ?? "[not dmc]";
	}

	public class StatsReporter : ToolBase
	{
		public StatsReporter(Pattern pattern) : base(pattern) { }

		/// <summary>find needed floss. print number of stitches and skeins needed</summary>
		public List<StatEntry> StitchStatsReport()
			=> Pattern.Sprites
			.SelectMany(s => s.Pixels)
			.GetColorsAndCounts()
			.Select(cc => new StatEntry(
				cc.Count,
				cc.Color,
				DmcColorProcessor.TryGetMatch(cc.Color, out var dmcColor) ? dmcColor : null)
			)
			.ToList();
	}
}
