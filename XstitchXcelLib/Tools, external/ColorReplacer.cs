using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using XstitchXcelLib.DataClasses;
using XstitchXcelLib.Interop;
using Excel = Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace XstitchXcelLib.Tools
{
	public class ColorReplacer : ToolBase
	{
		public bool CreateBackupFile { get; set; }

		public ColorReplacer(Pattern pattern) : base(pattern) { }

		public void Replace(string oldColorHex, string newColorHex)
		{
			var oldColor = HelperMethods.SmartColorFinder(oldColorHex, DmcColorProcessor);
			var newColor = HelperMethods.SmartColorFinder(newColorHex, DmcColorProcessor);

			//NaiveReplace(oldColor, newColor);
			TargetedReplace(oldColor, newColor);
		}

		/// <summary>
		/// Replace per scanned model stored in Sprite, Pixels, json, et al.
		/// </summary>
		/// <param name="oldColor"></param>
		/// <param name="newColor"></param>
		public void TargetedReplace(Color oldColor, Color newColor)
		{
			if (replacementIsInvalid(oldColor, newColor))
				return;

			foreach (var sprite in Pattern.Sprites)
				spriteReplace(sprite, oldColor, newColor);

			Config.Configuration.SaveSprites(Pattern.Sprites, Pattern.InputFile);
		}

		private void spriteReplace(Sprite sprite, Color oldColor, Color newColor)
		{
			var matches = getMatchingPixels(sprite, oldColor);
			if (!matches.Any())
				return;

			xlsxReplace(matches, newColor);
			modelReplace(sprite, matches, oldColor, newColor);
		}

		private static List<Pixel> getMatchingPixels(Sprite sprite, Color oldColor)
		{
			if (!oldColor.IsTransparent())
				return sprite.Pixels.Where(p => p.Color.IsEquivalent(oldColor)).ToList();

			// ensure it sprite contains no transparent px
			sprite.Crop();

			// sprite is now guaranteed to be tracking all non-transparent px only.
			// when oldColor is transparent, we need all px in range that the sprite isn't tracking.
			var xEnd = sprite.Location.X + sprite.Size.Width;
			var yEnd = sprite.Location.Y + sprite.Size.Height;

			var matches = new List<Pixel>();
			for (var x = sprite.Location.X; x < xEnd; x++)
				for (var y = sprite.Location.Y; y < yEnd; y++)
					if (sprite.Pixels.SingleOrDefault(px => px.ColumnNumber == x && px.RowNumber == y) is null)
						matches.Add(new() { Color = Color.Transparent, ColumnNumber = x, RowNumber = y });
			return matches;
		}

		private void xlsxReplace(List<Pixel> matches, Color newColor)
		{
			var isTransparent = newColor.IsTransparent();
			var newColorOle = newColor.ToOle();

			using var editor = new ExcelEditor(Pattern.InputFile) { CreateBackupFile = CreateBackupFile };
			foreach (var px in matches)
			{
				var cell = editor.GetCell(px.RowNumber, px.ColumnNumber);
				setColor(cell, isTransparent, newColorOle);
			}
		}

		private static void modelReplace(Sprite sprite, List<Pixel> matches, Color oldColor, Color newColor)
		{
			// new is transparent. just remove entries
			if (newColor.IsTransparent())
			{
				foreach (var px in matches)
					sprite.Pixels.Remove(px);
				sprite.Crop();
				return;
			}

			// old is transparent. add entries. next step will fix color
			if (oldColor.IsTransparent())
				sprite.Pixels.AddRange(matches);

			// update color
			foreach (var px in matches)
				px.Color = newColor;
		}

		/// <summary>
		/// Iterate through every pixel. If color matches: replace it
		/// </summary>
		/// <param name="oldColor"></param>
		/// <param name="newColor"></param>
		public void NaiveReplace(Color oldColor, Color newColor)
		{
			if (replacementIsInvalid(oldColor, newColor))
				return;

			var newColorOle = newColor.ToOle();
			var isTransparent = newColor.IsTransparent();

			bool isMatch(Range c) => ColorTranslator.FromOle((int)c.Interior.Color).IsEquivalent(oldColor);

			using var editor = new ExcelEditor(Pattern.InputFile) { CreateBackupFile = CreateBackupFile };
			editor.Iterate(isMatch, cell => setColor(cell, isTransparent, newColorOle));
		}

		static void setColor(Range cell, bool isTransparent, int newColorOle)
		{
			if (isTransparent)
				cell.Interior.ColorIndex = 0;
			else
				cell.Interior.Color = newColorOle;
		}

		private static bool replacementIsInvalid(Color oldColor, Color newColor)
			=> oldColor.IsEquivalent(newColor)
			|| oldColor.IsEquivalent(Color.Empty)
			|| newColor.IsEquivalent(Color.Empty);
	}
}
