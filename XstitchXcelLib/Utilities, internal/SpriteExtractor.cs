using System;
using System.Collections.Generic;
using System.Linq;
using XstitchXcelLib.DataClasses;
using XstitchXcelLib.Interop;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace XstitchXcelLib.Utilities
{
	internal class SpriteExtractor
	{
		private List<Sprite> spritesCache;

		private string inputFile { get; }

		public SpriteExtractor(string inputFile) => this.inputFile = inputFile;

		public List<Sprite> GetSprites()
		{
			if (spritesCache is null)
			{
				using var reader = new ExcelReader(inputFile);
				parse(reader);
			}

			return spritesCache;
		}

		private void parse(ExcelReader reader)
		{
			// init with 1 sprite. this will catch [1] sprite before first label [2] only contains 1 unlabeled picture.
			// If this is never used, it will be deleted during 'crop sprites'
			spritesCache = new List<Sprite> { new Sprite() };

			if (reader.UsedRows == 0 || reader.UsedColumns == 0)
				return;

			for (var r = 1; r <= reader.UsedRows; r++)
			{
				var row = new Pixel[reader.UsedColumns];

				for (var c = 1; c <= reader.UsedColumns; c++)
					row[c - 1] = parsePixel(reader.GetCellfromUsedRange(r, c));

				if (row.IsNameRow())
					spritesCache.Add(new Sprite { Name = row[0].Text });
				else
					spritesCache.LastOrDefault()?.AddRange(row);
			}

			// crop sprites. delete blank sprites
			for (var i = spritesCache.Count - 1; i >= 0; i--)
			{
				var sprite = spritesCache[i];
				sprite.Crop();
				if (sprite.Size.Width == 0 || sprite.Size.Height == 0)
					spritesCache.RemoveAt(i);
			}

			// ensure unique names
			var names = new List<string>();
			foreach (var sprite in spritesCache)
			{
				var n = sprite.Name;

				var i = 0;
				while (names.Contains(n))
					n = $"{sprite.Name} {++i}";

				names.Add(n);
				sprite.Name = n;
			}
		}

		private static Pixel parsePixel(Range cell)
		{
			var color = System.Drawing.ColorTranslator.FromOle((int)cell.Interior.Color);

			if ((color.A & color.R & color.G & color.B) == 255 && cell.Interior.ColorIndex == -4142)
				color = System.Drawing.Color.Transparent;

			var text = cell.Value2 is string str ? str : cell.Value2?.ToString();

			var pixel = new Pixel
			{
				RowNumber = cell.Row, // not the same as 'r' if there are unused blank rows before UsedRange
				ColumnNumber = cell.Column, // not the same as 'r' if there are unused blank columns before UsedRange
				Text = text?.Trim() ?? "",
				Color = color,
			};
			return pixel;
		}
	}
}
