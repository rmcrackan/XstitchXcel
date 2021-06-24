using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using XstitchXcelLib.DataClasses;
using XstitchXcelLib.Interop;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace XstitchXcelLib.Tools
{
	// ExcelReader: read from existing excel file
	// ExcelWriter: write to new excel file
	// ExcelEditor: open existing excel file. read/overwrite selective content. resave same file
	public class PatternBuilder : ToolBase
	{
		public string OutputFile { get; set; }

		public bool PrintColorsGrid { get; set; } = true;
		public bool PrintSymbolsGrid { get; set; } = true;
		public bool PrintColorsAndSymbolsGrid { get; set; } = true;
		public bool PrintLineNumbers { get; set; } = true;
		public bool PrintGridLines { get; set; } = true;
		public bool PrintArrowsAtMidpoints { get; set; } = true;
		public bool PrintLegend { get; set; } = true;

		private Sprite sprite => Pattern.Sprites[0];

		public PatternBuilder(Pattern pattern) : base(pattern)
		{
			OutputFile = Path.Combine(Path.GetDirectoryName(pattern.InputFile), Path.GetFileNameWithoutExtension(pattern.InputFile) + " - output" + Path.GetExtension(pattern.InputFile));

			if (pattern?.Sprites is null || pattern.Sprites.Count != 1)
				throw new Exception("unexpected image qty");

			if (pattern?.Symbols is null || pattern.Symbols.Count == 0)
				throw new Exception("no symbols loaded");
		}

		/// <summary>
		/// Utility method to print colored design only. No pattern artifacts. eg: gridlines, arrows, symbols, legend
		/// </summary>
		public void PrintDesignOnly()
		{
			PrintColorsGrid = true;

			PrintColorsAndSymbolsGrid = false;
			PrintSymbolsGrid = false;
			PrintLineNumbers = false;
			PrintGridLines = false;
			PrintArrowsAtMidpoints = false;
			PrintLegend = false;

			ConvertToPattern();
		}

		/// <summary>Convert input Excel layout to printable cross stitch patterns</summary>
		public void ConvertToPattern()
		{
			var grids = getGrids().ToList();
			if (grids.Count < 1)
				return;

			var colorsAndSymbols = getSortedColorsAndSymbols();

			// aka offset within the original picture from 0,0 (aka 1,1)
			var location = sprite.Location;

			var size = sprite.Size;
			var rows = size.Height;
			var cols = size.Width;

			// top and left gutters for row/col numbers
			var numberRowsTop = 0;
			var numberColsLeft = 0;
			if (PrintLineNumbers)
			{
				numberRowsTop = (int)Math.Log10(cols) + 1;
				numberColsLeft = (int)Math.Log10(rows) + 1;
			}

			// bottom and right row for center triangles
			var bottomArrowCellSize = 0;
			var rightArrowCellSize = 0;
			if (PrintArrowsAtMidpoints)
			{
				bottomArrowCellSize = 1;
				rightArrowCellSize = 1;
			}

			// right buffer between pattern and legend
			var bufferBeforeLegend = 1;

			// legend:
			//   2 columns for colors/symbols
			//   1 column DMC color # and name
			var legendWidth = 3;

			var gridHeight = numberRowsTop + size.Height + bottomArrowCellSize;
			var bufferBetweenGrids = 1;

			// grid offset
			// 1st grid with 0 offset starts at top left 1,1
			// 14px tall picture + 2 top + 1 bottom for center-arrow + 1 row buffer = 18 gridOffset
			// - 1st grid will begin at 1,1 + (18*0) = 1, 1 aka  A1
			// - 2nd grid will begin at 1,1 + (18*1) = 1,19 aka A19
			// - 3rd grid will begin at 1,1 + (18*2) = 1,37 aka A37
			var gridOffset = gridHeight + bufferBetweenGrids;

			// total cell range needed for all 3 grids
			var totalHeight = (grids.Count * gridHeight) + ((grids.Count - 1) * bufferBetweenGrids);
			var totalWidth = numberColsLeft + size.Width + rightArrowCellSize + bufferBeforeLegend + legendWidth;

			// these columns are same for all grids
			var contentColOffset = numberColsLeft;
			var rightArrowBuffer = contentColOffset + cols + rightArrowCellSize;

			using var writer = new ExcelWriter(OutputFile);
			// within total cell range:
			// - adjust col width and row height
			// - global font default: calibri. size 8. align middle and center
			{
				var totalRange = writer.GetRange(1, 1, totalHeight, totalWidth);

				//for (var r = 1; r <= totalHeight; r++)
				//	writer.Worksheet.Rows[r].RowHeight = 9.75; // =13px
				//for (var c = 1; c <= totalWidth; c++)
				//	writer.Worksheet.Columns[c].ColumnWidth = 1.14; // =13px
				totalRange.RowHeight = 9.75; // =13px
				totalRange.ColumnWidth = 1.14; // =13px

				// DO NOT use these. they also alter the app's font: writer.App.StandardFont , writer.App.StandardFontSize

				// note, do NOT use totalRange.Style. This gets the style in that range and changes it. This change propogates to all other elements using that style which may include the client app itself.
				totalRange.Font.Name = "Calibri";
				totalRange.Font.Size = 8;
				totalRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
				totalRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
			}

			for (var g = 0; g < grids.Count; g++)
			{
				//// to put on different tabs instead of same:
				//// - uncomment this
				//// - apply above global stuff to all tabs
				//// - remove vertical offsets
				//// other possible configuration: print each to its own file
				//switch (g)
				//{
				//	case 0:
				//		// we already start with a worksheet. don't need to add one for 1st grid
				//		writer.Worksheet.Name = "Colors";
				//		break;
				//	case 1:
				//		writer.AddWorksheet();
				//		writer.Worksheet.Name = "Symbols";
				//		break;
				//	case 2:
				//	default:
				//		writer.AddWorksheet();
				//		writer.Worksheet.Name = "Colors and symbols";
				//		break;
				//}

				// eg: 18 gridOffset
				// - 1st grid will begin at 1,1 + (gridOffset*0) = 1, 1 : aka  A1
				// - 2nd grid will begin at 1,1 + (gridOffset*1) = 1,19 : aka A19
				// - 3rd grid will begin at 1,1 + (gridOffset*2) = 1,37 : aka A37

				var grid = grids[g];

				var offset = gridOffset * g;
				var contentRowOffset = offset + numberRowsTop;

				if (PrintLineNumbers)
				{
					// top line numbers
					for (var x = 0; x < numberRowsTop; x++)
						for (var c = 1; c <= cols; c++)
							writer.GetCell(
								1 + x + offset,
								c + numberColsLeft)
								.Value = c.ToString().PadLeft(numberRowsTop)[x].ToString().Trim();

					// left line numbers
					for (var x = 1; x <= rows; x++)
						for (var c = 0; c < numberColsLeft; c++)
							writer.GetCell(
								x + offset + numberRowsTop,
								1 + c)
								.Value = x.ToString().PadLeft(numberColsLeft)[c].ToString().Trim();
				}

				// pattern/content area:
				// - dotted grid 1x1
				// - thin solid line grid 5x5
				// - thick solid line grid 10x10
				// - thick exterior solid line border
				if (PrintGridLines)
				{
					// 1x1
					var contentRange = writer.GetRange(1 + contentRowOffset, 1 + contentColOffset, rows + contentRowOffset, cols + contentColOffset);
					contentRange.DrawInternalBorders(2, XlLineStyle.xlDash);

					// 5x5, 10x10
					for (var r = 1; r <= rows; r++)
					{
						// run this before getting range. Range inerop is significantly more expensive
						if (r % 5 != 0)
							continue;

						var rangeRow = contentRowOffset + r;
						var rowRange = writer.GetRange(rangeRow, contentColOffset + 1, rangeRow, contentColOffset + size.Width);
						rowRange.Borders[XlBordersIndex.xlEdgeBottom].DrawEdgeBorder(r % 10 == 0 ? 3 : 2, XlLineStyle.xlContinuous);
					}
					for (var c = 1; c <= cols; c++)
					{
						// run this before getting range. Range inerop is significantly more expensive
						if (c % 5 != 0)
							continue;

						var rangeCol = contentColOffset + c;
						var colRange = writer.GetRange(contentRowOffset + 1, rangeCol, contentRowOffset + size.Height, rangeCol);
						colRange.Borders[XlBordersIndex.xlEdgeRight].DrawEdgeBorder(c % 10 == 0 ? 3 : 2, XlLineStyle.xlContinuous);
					}

					// outer borders
					var patternRange = writer.GetRange(contentRowOffset + 1, contentColOffset + 1, contentRowOffset + size.Height, contentColOffset + size.Width);
					patternRange.DrawAllEdgeBorders(3, XlLineStyle.xlContinuous);
				}

				if (PrintArrowsAtMidpoints)
				{
					// right arrow. merge. Wingdings 3. left-facing arrow is 't'
					var rightArrowRange = writer.GetRange(contentRowOffset + 1, rightArrowBuffer, contentRowOffset + size.Height, rightArrowBuffer);
					rightArrowRange.Merge();
					rightArrowRange.Value = "t";
					rightArrowRange.Font.Name = "Wingdings 3";

					// bottom arrow. merge. Wingdings 3. top-facing arrow is 'p'
					var rangeRow = contentRowOffset + rows + bottomArrowCellSize;
					var bottomArrowRange = writer.GetRange(rangeRow, contentColOffset + 1, rangeRow, contentColOffset + size.Width);
					bottomArrowRange.Merge();
					bottomArrowRange.Value = "p";
					bottomArrowRange.Font.Name = "Wingdings 3";
				}

				// legend
				// all grid:
				//   print legend. each color:
				//   col 2: color box with thin black border
				//   col 3: DMC color # and name. align bottom left
				// conditional grids:
				//   grid 1: no changes
				//   grid 2: col 1: symbols
				//   grid 3: col 2: symbols. this will combine the color box and symbols
				if (PrintLegend)
				{
					var legendColBuffer = rightArrowBuffer + bufferBeforeLegend;
					var legendCol1 = legendColBuffer + 1;
					var legendCol2 = legendColBuffer + 2;
					var legendCol3 = legendColBuffer + 3;

					// set all borders with 1 command per grid over entire range
					var legendBorderedRange = writer.GetRange(contentRowOffset + 1, legendCol2, contentRowOffset + colorsAndSymbols.Count, legendCol2);
					legendBorderedRange.DrawInternalBorders(2, XlLineStyle.xlContinuous);

					for (var cs = 0; cs < colorsAndSymbols.Count; cs++)
					{
						var (color, symbol) = colorsAndSymbols[cs];

						var legendRowOffset = contentRowOffset + cs + 1;

						var legend1cell = writer.GetCell(legendRowOffset, legendCol1);
						var legend2cell = writer.GetCell(legendRowOffset, legendCol2);
						var legend3cell = writer.GetCell(legendRowOffset, legendCol3);

						// column 1
						if (grid.LegendSymbolsColumn1)
							legend1cell.WriteSymbol(symbol);

						// column 2
						legend2cell.Interior.Color = color.ToOle();
						if (grid.LegendSymbolsColumn2)
						{
							legend2cell.WriteSymbol(symbol);
							legend2cell.EnsureTextContrast(color);
						}

						// column 3
						legend3cell.Value
							= DmcColorProcessor.TryGetMatch(color, out var dmcColor)
							? $"{dmcColor.DmcNumber} - {dmcColor.Name}"
							: $"Non-DMC: #{color.ToHex()}";
						legend3cell.HorizontalAlignment = XlHAlign.xlHAlignLeft;
						legend3cell.VerticalAlignment = XlVAlign.xlVAlignBottom;
					}
				}

				// content
				// grid 1 content: print pattern pixel colors
				// grid 2 content: print pattern pixel symbols
				// grid 3 content: print pattern pixel colors and symbols
				foreach (var p in sprite.Pixels.Where(p => !p.Color.IsTransparent()))
				{
					var row = p.RowNumber + contentRowOffset - location.Y + 1;
					var column = p.ColumnNumber + contentColOffset - location.X + 1;
					var cell = writer.GetCell(row, column);

					if (grid.PatternColors)
						cell.Interior.Color = p.Color.ToOle();

					if (grid.PatternSymbols)
						cell.WriteSymbol(colorsAndSymbols.Single(cs => p.Color.IsEquivalent(cs.Color)).Symbol);

					if (grid.PatternColors && grid.PatternSymbols)
						cell.EnsureTextContrast(p.Color);
				}
			}
		}

		record grid
		{
			public bool LegendSymbolsColumn1 { get; set; }
			public bool LegendSymbolsColumn2 { get; set; }
			public bool PatternColors { get; set; }
			public bool PatternSymbols { get; set; }
		}

		private IEnumerable<grid> getGrids()
		{
			if (PrintColorsGrid)
				yield return new grid
				{
					PatternColors = true
				};

			if (PrintSymbolsGrid)
				yield return new grid
				{
					LegendSymbolsColumn1 = true,
					PatternSymbols = true
				};

			if (PrintColorsAndSymbolsGrid)
				yield return new grid
				{
					LegendSymbolsColumn2 = true,
					PatternColors = true,
					PatternSymbols = true
				};
		}

		private List<(Color Color, Symbol Symbol)> getSortedColorsAndSymbols()
			=> DmcColorProcessor
			.GetSortedColors(sprite.Pixels)
			.Select((color, i) => (color, Pattern.Symbols[i]))
			.ToList();
	}
	public static class PatternBuilderExtMethods
	{
		private static readonly int WHITE_OLEDB = Color.White.ToOle();
		public static void EnsureTextContrast(this Range cell, Color backgroundColor)
		{
			if (backgroundColor.GetContrastColor().IsWhite())
				cell.Font.Color = WHITE_OLEDB;
		}

		public static void WriteSymbol(this Range cell, Symbol symbol)
		{
			cell.Value = symbol.Character;

			if (cell.Font.Name != symbol.FontName) cell.Font.Name = symbol.FontName;
			if (symbol.Bold) cell.Font.Bold = symbol.Bold;
			if (symbol.Italic) cell.Font.Italic = symbol.Italic;
			if (symbol.StrikeThrough) cell.Font.Strikethrough = symbol.StrikeThrough;
			if (symbol.Subscript) cell.Font.Subscript = symbol.Subscript;
			if (symbol.Superscript) cell.Font.Superscript = symbol.Superscript;
			if (symbol.Underline) cell.Font.Underline = symbol.Underline;
		}

		public static void DrawAllEdgeBorders(this Range range, int weight, XlLineStyle lineStyle)
		{
			var edges = new[] {
				XlBordersIndex.xlEdgeTop,
				XlBordersIndex.xlEdgeBottom,
				XlBordersIndex.xlEdgeLeft,
				XlBordersIndex.xlEdgeRight };
			foreach (var edge in edges)
				range.Borders[edge].DrawEdgeBorder(weight, lineStyle);
		}

		public static void DrawEdgeBorder(this Border border, int weight, XlLineStyle lineStyle)
		{
			border.Weight = weight;
			border.LineStyle = lineStyle;
		}

		// edge borders AND all internal borders
		public static void DrawInternalBorders(this Range range, int weight, XlLineStyle lineStyle)
		{
			range.Borders.Weight = weight;
			range.Borders.LineStyle = lineStyle;
		}
	}
}
