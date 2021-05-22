using System;
using System.Drawing;
using Microsoft.Office.Interop.Excel;
using XstitchXcelLib.DataClasses;
using XstitchXcelLib.Interop;
using Excel = Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace XstitchXcelLib.Tools
{
	public class ColorFixer : ToolBase
	{
		public bool CreateBackupFile { get; set; }

		public ColorFixer(Pattern pattern) : base(pattern) { }

		public void Replace(string oldColorHex, string newColorHex)
		{
			var oldColor = HelperMethods.SmartColorFinder(oldColorHex, DmcColorProcessor);
			var newColor = HelperMethods.SmartColorFinder(newColorHex, DmcColorProcessor);

			Replace(oldColor, newColor);
		}

		public void Replace(Color oldColor, Color newColor)
		{
			if (oldColor.IsEquivalent(newColor) ||
				oldColor.IsEquivalent(Color.Empty) ||
				newColor.IsEquivalent(Color.Empty))
				return;

			var newColorOle = newColor.ToOle();

			bool isMatch(Range c) => ColorTranslator.FromOle((int)c.Interior.Color).IsEquivalent(oldColor);

			void change(Range cell) => cell.Interior.Color = newColorOle;

			using var editor = new ExcelEditor(Pattern.InputFile) { CreateBackupFile = CreateBackupFile };
			editor.Iterate(isMatch, change);
		}
	}
}
