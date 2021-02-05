using System;
using System.IO;
using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace XstitchXcelLib.Interop
{
	// ExcelReader: read from existing excel file
	// ExcelWriter: write to new excel file
	// ExcelEditor: open existing excel file. read/overwrite selective content. resave same file
	public class ExcelEditor : ExcelBase
	{
		public bool CreateBackupFile { get; set; }

		protected override bool SaveFile => true;

		protected override Workbook GetWorkbook(Workbooks workbooks) => workbooks.Open(FileName);

		public ExcelEditor(string fileName) : base(fileName)
		{
			//// back up orig file
			if (CreateBackupFile)
				File.Copy(FileName, HelperMethods.GetUniqueFileName(HelperMethods.AddFileSuffix(FileName, " - backup")));
		}
	}
}
