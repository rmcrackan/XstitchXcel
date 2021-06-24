using System;
using System.Drawing;

namespace XstitchXcelLib.DataClasses
{
	public record DmcColor
	{
		public string DmcNumber { get; init; }
		public string Name { get; init; }
		public Color Color { get; init; }

		public override string ToString() => $"{Name}, {DmcNumber}, #{Color.ToHex()}";
	}
}
