﻿using System;
using XstitchXcelLib.Config;
using XstitchXcelLib.DataClasses;
using XstitchXcelLib.Tools;

namespace XstitchXcelConsole
{
	/// <summary>streamline access to all tools</summary>
	public class EzApi
	{
		private Pattern pattern { get; }

		// loading pattern can be expensive. "LoadPattern" is more expressive os this than ctor
		private EzApi(Pattern pattern) => this.pattern = pattern;
		public static EzApi LoadPattern(string patternInputFile) => new EzApi(Configuration.GetPattern(patternInputFile));

		public void DiscoverNonDmcAllSprites() => new PatternAnalyzer(pattern).DiscoverNonDmcAllSprites();

		public void ReplaceColors(string oldHex, string newHex) => new ColorFixer(pattern).Replace(oldHex, newHex);

		public void PrintStitchStatsReport()
		{
			Console.WriteLine($"{"stitches"}\t{"min skeins"}\t{"max skeins"}\t{"hex #",6}\t{"dmc #",5}\t{"name"}");
			foreach (var x in new StatsReporter(pattern).StitchStatsReport())
				Console.WriteLine($"{x.Count,8}\t{x.MinSkeins,10:F2}\t{x.MaxSkeins,10:F2}\t{x.Hex}\t{x.DmcNumber,5}\t{x.DmcName}");
		}

		public void ConvertToPattern() => new PatternBuilder(pattern).ConvertToPattern();
	}
}
