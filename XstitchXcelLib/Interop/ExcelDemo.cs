using System;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace XstitchXcelLib.Interop
{
	public class ExcelDemo
    {
        public static void Demo()
        {
            //
            // Excel interop .NET5/.NETCore proof of concept. Still has the bug that leaves Excel process open even after application is closed:
            // https://github.com/dotnet/samples/tree/master/core/extensions/ExcelDemo
            //

            var excel = new Excel.Application { Visible = true };
			var workbook = excel.Workbooks.Add(Missing.Value);
            var sheet = (Excel.Worksheet)workbook.ActiveSheet;

            // Add table headers going cell by cell
            sheet.Cells[1, 1] = "First Name";
            sheet.Cells[1, 2] = "Last Name";
            sheet.Cells[1, 3] = "Full Name";
            sheet.Cells[1, 4] = "Salary";

            // Format A1:D1 as bold, vertical alignment = center
            sheet.get_Range("A1", "D1").Font.Bold = true;
            sheet.get_Range("A1", "D1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            // Create an array to multiple values at once
            var saNames = new string[5, 2];

            saNames[0, 0] = "John";
            saNames[0, 1] = "Smith";
            saNames[1, 0] = "Tom";
            saNames[1, 1] = "Brown";
            saNames[2, 0] = "Sue";
            saNames[2, 1] = "Thomas";
            saNames[3, 0] = "Jane";
            saNames[3, 1] = "Jones";
            saNames[4, 0] = "Adam";
            saNames[4, 1] = "Johnson";

            // Fill A2:B6 with an array of values (First and Last Names)
            sheet.get_Range("A2", "B6").Value2 = saNames;

            // Fill C2:C6 with a relative formula (=A2 & " " & B2)
            var range = sheet.get_Range("C2", "C6");
            range.Formula = "=A2 & \" \" & B2";

            // Fill D2:D6 with a formula(=RAND()*100000) and apply format
            range = sheet.get_Range("D2", "D6");
            range.Formula = "=RAND()*100000";
            range.NumberFormat = "$0.00";

            // AutoFit columns A:D
            range = sheet.get_Range("A1", "D1");
            range.EntireColumn.AutoFit();

            // Make sure Excel is visible and give the user control of Microsoft Excel's lifetime
            excel.Visible = true;
            excel.UserControl = true;
        }

        public static void PrintExample(string fileName)
        {
            var app = new Application { Visible = true };
            var workbook = app.Workbooks.Open(fileName);

            // get first sheet
            var Worksheet = (Worksheet)workbook.Worksheets.get_Item(1);

            // or get active // worksheet = workbook.ActiveSheet;

            // all occupied/used cells
            var range = Worksheet.UsedRange;

            // or get specific cell // range = (Range)worksheet.Cells[10, 10];


            var rw = range.Rows.Count;
            var cl = range.Columns.Count;

            // 1-based indexing. WTF Excel?!
            for (var i = 1; i <= rw; i++)
            {
                for (var j = 1; j <= cl; j++)
                {
                    var cell = range.Cells[i, j] as Range;
                    Console.Write($"[{cell.Row},{cell.Column}]");

                    var str = (string)cell.Value2;

                    // objects with ".Color": Border, Borders (all 4 it not all the same), Font, Interior, Tab
                    var c = cell.Interior.Color;

                    var col = System.Drawing.ColorTranslator.FromOle((int)c);

                    // to get transparent/no-fill: ColorIndex == -4142
                    // to set transparent/no-fill: ColorIndex = 0
                    var isTransparent = (col.A & col.R & col.G & col.B) == 255 && cell.Interior.ColorIndex == -4142;

                    Console.Write($"{i},{j}={str} | bg=#{col.GetHexColor()}");
                    if (!isTransparent && (col.IsKnownColor || col.IsNamedColor || col.IsSystemColor))
                        Console.Write($" [{col.Name}]");

                    Console.WriteLine();
                }
            }
        }
    }
}