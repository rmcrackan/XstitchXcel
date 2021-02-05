using System;
using Microsoft.Office.Interop.Excel;

namespace XstitchXcelLib.Interop
{
	// ExcelReader: read from existing excel file
	// ExcelWriter: write to new excel file
	// ExcelEditor: open existing excel file. read/overwrite selective content. resave same file
	public class ExcelWriter : ExcelBase
	{
		protected override bool SaveFile => true;

		protected override Workbook GetWorkbook(Workbooks workbooks) => workbooks.Add();

		public ExcelWriter(string fileName) : base(fileName) { }
	}
}
