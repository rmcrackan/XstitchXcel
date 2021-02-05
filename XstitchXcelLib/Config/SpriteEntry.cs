using System;
using System.Collections.Generic;

namespace XstitchXcelLib.Config
{
	public class SpriteEntry
	{
		public string Name { get; set; }
		public List<PixelEntry> Pixels { get; set; } = new List<PixelEntry>();

		public void Add(PixelEntry pixel) => Pixels.Add(pixel);
		public void AddRange(IEnumerable<PixelEntry> pixels) => Pixels.AddRange(pixels);

		public override string ToString() => $"{Name}: {Pixels.Count} px";
	}
}
