using System;
using System.Drawing;
using XstitchXcelLib.Interop;

namespace XstitchXcelLib.Utilities
{
	internal class EzExcelWriter : ExcelWriter
	{
		public EzExcelWriter(string fileName) : base(fileName) { }

		private int currRow = 1;
		public void WriteRow(params object[] objects)
		{
			for (var i = 1; i <= objects.Length; i++)
			{
				var o = objects[i - 1];

				if (o is Color cc)
					GetCell(currRow, i).Interior.Color = cc.ToOle();
				else if (o is string ss)
					GetCell(currRow, i).Value = ss;
				else
					GetCell(currRow, i).Value = o.ToString();
			}

			currRow++;
		}

		public void WriteRow() => currRow++;
	}
}
