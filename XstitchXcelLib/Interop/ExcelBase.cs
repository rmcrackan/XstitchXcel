using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace XstitchXcelLib.Interop
{
	public abstract class ExcelBase : OfficeBase
	{
		protected abstract bool SaveFile { get; }

		private Application app { get; }
		private Workbook workbook { get; set; }
		private Worksheet worksheet { get; }
		private Range usedRange { get; }

		public int UsedRows => usedRange.Rows.Count;
		public int UsedColumns => usedRange.Columns.Count;

		protected abstract Workbook GetWorkbook(Workbooks workbooks);

		protected ExcelBase(string fileName) : base(fileName)
		{
			app = Push(new Application { Visible = true });
			workbook = Push(GetWorkbook(Push(app.Workbooks)));

			// get first sheet
			worksheet = Push(workbook.Worksheets[1]);

			usedRange = Push(worksheet.UsedRange);

			// alternate: // worksheet = (Worksheet)workbook.Worksheets.get_Item(1);

			// add 2nd sheet after the first
			// var worksheetWrite2 = app.Worksheets.Add(After: Worksheet);

			// optional
			// worksheet.Name = "color options";

			// or get active // worksheet = workbook.ActiveSheet;

			// or get specific cell // range = (Range)worksheet.Cells[10, 10];
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="row">1-based index</param>
		/// <param name="column">1-based index</param>
		/// <returns></returns>
		public Range GetCell(int row, int column) => getCell(worksheet.Cells, row, column);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="row">1-based index</param>
		/// <param name="column">1-based index</param>
		/// <returns></returns>
		public Range GetCellfromUsedRange(int row, int column) => getCell(usedRange, row, column);

		private Range getCell(Range range, int row, int column) => Push(range[row, column] as Range);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fromRow">1-based index</param>
		/// <param name="fromColumn">1-based index</param>
		/// <param name="toRow">1-based index</param>
		/// <param name="toColumn">1-based index</param>
		/// <returns></returns>
		public Range GetRange(int fromRow, int fromColumn, int toRow, int toColumn)
			=> Push(
				worksheet.Range[
					Push(worksheet.Cells[fromRow, fromColumn]),
					Push(worksheet.Cells[toRow, toColumn])
					] as Range
				);

		public void Iterate(Func<Range, bool> conditionalFunc, Action<Range> conditionalAction)
		{
			for (int i = 1; i <= UsedRows; i++)
			{
				for (int j = 1; j <= UsedColumns; j++)
				{
					var cell = GetCell(i, j);
					if (conditionalFunc(cell))
						conditionalAction(cell);
				}
			}
		}

		protected override void DisposeHook()
		{
			if (SaveFile)
				try { workbook?.SaveAs(FileName); }
				catch { }

			workbook?.Close();
			app?.Quit();
		}
	}
}
