using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace XstitchXcelLib.DataClasses
{
	public class Sprite
	{
		public string Name { get; set; }
		public List<Pixel> Pixels { get; set; } = new List<Pixel>();

		public Point Location => new(
			Pixels.Any()
				? Pixels.Min(p => p.ColumnNumber)
				: 0,
			Pixels.Any()
				? Pixels.Min(p => p.RowNumber)
				: 0
			);
		public Size Size => new(
			Pixels.Any()
				? Pixels.Max(p => p.ColumnNumber) - Pixels.Min(p => p.ColumnNumber) + 1
				: 0,
			Pixels.Any()
				? Pixels.Max(p => p.RowNumber) - Pixels.Min(p => p.RowNumber) + 1
				: 0
			);

		public void Add(Pixel pixel) => Pixels.Add(pixel);
		public void AddRange(IEnumerable<Pixel> pixels) => Pixels.AddRange(pixels);

		/// <summary>Trim dead-beginning and dead-end : rows and columns</summary>
		public void Crop()
		{
			Pixels = Pixels.Where(p => !p.Color.IsTransparent()).ToList();

			if (!Pixels.Any())
			{
				Pixels = new List<Pixel>();
				return;
			}

			var minRowNumber = Pixels.Min(p => p.RowNumber);
			var maxRowNumber = Pixels.Max(p => p.RowNumber);
			var minColumnNumber = Pixels.Min(p => p.ColumnNumber);
			var maxColumnNumber = Pixels.Max(p => p.ColumnNumber);

			Pixels = Pixels
				.Where(p =>
					p.RowNumber >= minRowNumber &&
					p.RowNumber <= maxRowNumber &&
					p.ColumnNumber >= minColumnNumber &&
					p.ColumnNumber <= maxColumnNumber)
				.ToList();
		}

		public override string ToString() => $"{Name}: {Size} @ {Location}";
	}
}
