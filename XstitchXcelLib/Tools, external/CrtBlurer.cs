﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using XstitchXcelLib.Config;
using XstitchXcelLib.DataClasses;

namespace XstitchXcelLib.Tools
{
	public class CrtBlurer : ToolBase
	{
		public string OutputFile { get; set; }

		private int[,] _matrix { get; }
		private Dictionary<int, Color> colorMap { get; }

		public CrtBlurer(Pattern pattern) : base(pattern)
		{
			OutputFile = Path.Combine(Path.GetDirectoryName(pattern.InputFile), Path.GetFileNameWithoutExtension(pattern.InputFile) + " - output" + Path.GetExtension(pattern.InputFile));

			if (pattern?.Sprite is null)
				throw new NullReferenceException(nameof(pattern.Sprite));

			// must be inside this ctor so base ctor has already init'd dmcProcessor
			colorMap = createColorMap();

			_matrix = buildMatrix(Pattern.Sprite);
		}

		private static int[,] buildMatrix(Sprite sprite)
		{
			var matrix = new int[sprite.Size.Width + 2, sprite.Size.Height];

			foreach (var pixel in sprite.Pixels)
			{
				var x = pixel.ColumnNumber - sprite.Location.X + 1;
				var y = pixel.RowNumber - sprite.Location.Y;

				var x_left = x - 1;
				var x_right = x + 1;

				matrix[x_left, y] += 100;
				matrix[x, y] += 10;
				matrix[x_right, y] += 1;
			}

			return matrix;
		}

		private Dictionary<int, Color> createColorMap() => new Dictionary<int, Color>
		{
			[000] = Color.Black, // unoccupied
			[001] = DmcColorProcessor.GetByDmcNumber("820").Color, // Very Dark Royal Blue
			[010] = DmcColorProcessor.GetByDmcNumber("907").Color, // Light Parrot Green
			[011] = DmcColorProcessor.GetByDmcNumber("3846").Color, // Light Bright Turquoise
			[100] = DmcColorProcessor.GetByDmcNumber("606").Color, // Bright Orange-Red
			[101] = DmcColorProcessor.GetByDmcNumber("956").Color, // Geranium pink
			[110] = DmcColorProcessor.GetByDmcNumber("973").Color, // Bright Canary yellow
			[111] = Color.White,
		};

		public void PrintToConsole()
		{
			for (var y = 0; y < _matrix.GetLength(1); y++)
			{
				for (var x = 0; x < _matrix.GetLength(0); x++)
				{
					var color = _matrix[x, y] switch
					{
						000 => ConsoleColor.Black, // unoccupied
						001 => ConsoleColor.DarkBlue,
						010 => ConsoleColor.Green,
						011 => ConsoleColor.Cyan,
						100 => ConsoleColor.Red,
						101 => ConsoleColor.Magenta,
						110 => ConsoleColor.Yellow,
						111 => ConsoleColor.White,
						_ => throw new Exception("oops")
					};

					Console.ForegroundColor = color;
					Console.Write("\u2588" + "\u2588");
				}
				Console.WriteLine();
			}
		}

		public void SaveToFile()
		{
			var sprite = matrixToSprite();

			// build pattern
			var pattern = new Pattern(Pattern.InputFile) { Sprite = sprite };
			var defaultGlyphs = Configuration.GetDefaultGlyphEntries().Select(se => Converters.ToGlyph(se));
			pattern.Glyphs.AddRange(defaultGlyphs);

			var builder = new PatternBuilder(pattern) { OutputFile = OutputFile };
			builder.PrintDesignOnly();
		}

		private Sprite matrixToSprite(bool showBackground = false)
		{
			var sprite = new Sprite { Name = Pattern.InputFile };

			for (var y = 0; y < _matrix.GetLength(1); y++)
			{
				for (var x = 0; x < _matrix.GetLength(0); x++)
				{
					var value = _matrix[x, y];

					if (!showBackground && value == 0)
						continue;

					sprite.Add(new()
					{
						Color = colorMap[value],
						ColumnNumber = x + 1,
						RowNumber = y + 1
					});
				}
			}

			return sprite;
		}
	}
}
