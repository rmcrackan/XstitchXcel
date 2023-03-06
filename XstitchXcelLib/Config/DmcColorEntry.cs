using System;

namespace XstitchXcelLib.Config
{
	public class DmcColorEntry
	{
        public string DmcNumber { get; set; }
		public string Name { get; set; }

		public int Red { get; set; }
		public int Green { get; set; }
		public int Blue { get; set; }

		public bool Discontinued { get; set; }
		public List<string> Replacements { get; set; } = new();

        public override string ToString() => $"{Name}, {DmcNumber}, #{Red:X2}{Green:X2}{Blue:X2}";
	}
}
