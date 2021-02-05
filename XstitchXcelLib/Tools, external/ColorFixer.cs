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

		/// <summary>fix colors from non-DMC => dmc</summary>
		/// <param name="oldColorHex"></param>
		/// <param name="newDmcColorHex"></param>
		public void Replace(string oldColorHex, string newDmcColorHex)
		{
			var oldColor = HelperMethods.HexToColor(oldColorHex);
			var newColor = HelperMethods.HexToColor(newDmcColorHex);

			if (oldColor.IsEquivalent(newColor))
				return;

			var newColorOle = newColor.ToOle();

			bool isMatch(Range c) => ColorTranslator.FromOle((int)c.Interior.Color).IsEquivalent(oldColor);

			void change(Range cell) => cell.Interior.Color = newColorOle;

			using var editor = new ExcelEditor(Pattern.InputFile) { CreateBackupFile = CreateBackupFile };
			editor.Iterate(isMatch, change);
		}
	}
}
