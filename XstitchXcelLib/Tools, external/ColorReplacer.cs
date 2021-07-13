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

		#region TargetedReplace

		/// <summary>
		/// Replace per scanned model stored in Sprite, Pixels, json, et al.
		/// </summary>
		public void TargetedReplace(string oldColorHex, string newColorHex)
			=> TargetedReplace(DmcColorProcessor.SmartColorFinder(oldColorHex), DmcColorProcessor.SmartColorFinder(newColorHex));

		/// <summary>
		/// Replace per scanned model stored in Sprite, Pixels, json, et al.
		/// </summary>
		public void TargetedReplace(Color oldColor, Color newColor)
		{
			if (oldColor.ReplacementIsInvalid(newColor))
				return;

			spriteReplace(Pattern.Sprite, oldColor, newColor);
			Config.Configuration.SaveSprite(Pattern.Sprite, Pattern.InputFile);
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
				editor
					.GetCell(px.RowNumber, px.ColumnNumber)
					.SetColor(newColorOle, isTransparent);
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

		#endregion

		#region NaiveReplace

		/// <summary>
		/// Iterate through every pixel. If color matches: replace it
		/// </summary>
		public void NaiveReplace(string oldColorHex, string newColorHex)
			=> NaiveReplace(DmcColorProcessor.SmartColorFinder(oldColorHex), DmcColorProcessor.SmartColorFinder(newColorHex));

		/// <summary>
		/// Iterate through every pixel. If color matches: replace it
		/// </summary>
		public void NaiveReplace(Color oldColor, Color newColor)
			=> NaiveReplace(Pattern.InputFile, oldColor, newColor, CreateBackupFile);

		public static void NaiveReplace(string file, string oldColorHex, string newColorHex, bool createBackupFile = false)
		{
			var processor = new DmcColorProcessor();
			NaiveReplace(file, processor.SmartColorFinder(oldColorHex), processor.SmartColorFinder(newColorHex), createBackupFile);
		}
		public static void NaiveReplace(string inputFile, Color oldColor, Color newColor, bool createBackupFile = false)
		{
			if (oldColor.ReplacementIsInvalid(newColor))
				return;

			var newColorOle = newColor.ToOle();
			var isTransparent = newColor.IsTransparent();

			bool isMatch(Range c) => ColorTranslator.FromOle((int)c.Interior.Color).IsEquivalent(oldColor);

			using var editor = new ExcelEditor(inputFile) { CreateBackupFile = createBackupFile };
			editor.Iterate(isMatch, cell => cell.SetColor(newColorOle, isTransparent));
		}

		#endregion
	}
	public static class ColorReplacerExtMethods
	{
		public static bool ReplacementIsInvalid(this Color oldColor, Color newColor)
			=> oldColor.IsEquivalent(newColor)
			|| oldColor.IsEquivalent(Color.Empty)
			|| newColor.IsEquivalent(Color.Empty);

		public static void SetColor(this Range cell, int newColorOle, bool isTransparent)
		{
			if (isTransparent)
				cell.Interior.ColorIndex = 0;
			else
				cell.Interior.Color = newColorOle;
		}
	}
}
