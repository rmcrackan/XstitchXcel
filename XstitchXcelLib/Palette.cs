using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace XstitchXcelLib
{
	public partial class Palette
	{
		public string Name { get; set; }
		public string Notes { get; set; }

		[Newtonsoft.Json.JsonIgnore]
		public Dictionary<PaletteEntry, Color> ColorMap { get; } = new Dictionary<PaletteEntry, Color>();

		public Palette() { }

		public override string ToString()
		{
			var types = ColorMap.Select(kvp => kvp.Key.PaletteType).Distinct();
			var t = types.Any() ? types.Aggregate((a, b) => $"{a},{b}") : "[none]";
			return $"{Name} [{ColorMap.Count}]. Type: {t}";
		}
	}
}
