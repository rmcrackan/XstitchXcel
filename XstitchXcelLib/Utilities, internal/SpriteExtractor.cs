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
	internal static class SpriteExtractor
	{
		public static Sprite GetSprite(string inputFile)
		{
			using var reader = new ExcelReader(inputFile);
			
			var sprite = new Sprite { Name = inputFile};

			if (reader.UsedRangeIsEmpty)
				return sprite;

			for (var r = 1; r <= reader.UsedRowCount; r++)
			{
				var row = new Pixel[reader.UsedColumnCount];

				for (var c = 1; c <= reader.UsedColumnCount; c++)
					row[c - 1] = parsePixel(reader.GetCellfromUsedRange(r, c));

				sprite.AddRange(row);
			}

			// crop sprites. delete blank sprites
			sprite.Crop();

			return sprite;
		}

		private static Pixel parsePixel(Range cell)
		{
			var color = System.Drawing.ColorTranslator.FromOle((int)cell.Interior.Color);

			if ((color.A & color.R & color.G & color.B) == 255 && cell.Interior.ColorIndex == -4142)
				color = System.Drawing.Color.Transparent;

			// var text = (cell.Value2 is string str ? str : cell.Value2?.ToString())?.Trim() ?? "";

			var pixel = new Pixel
			{
				RowNumber = cell.Row, // not the same as 'r' if there are unused blank rows before UsedRange
				ColumnNumber = cell.Column, // not the same as 'r' if there are unused blank columns before UsedRange
				Color = color,
			};
			return pixel;
		}
	}
}
