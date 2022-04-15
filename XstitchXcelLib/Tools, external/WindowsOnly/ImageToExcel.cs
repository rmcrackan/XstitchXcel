using System;
using System.Drawing;

using Excel = Microsoft.Office.Interop.Excel;

namespace XstitchXcelLib.Tools
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
    public class ImageToExcel
    {
        public const int Complete = 101;

        private string _imagePath { get; }
        private string _outputPath { get; }

        public Excel.Application xlApp = new();

        public ImageToExcel(string imagePath, string outputPath)
        {
            _imagePath = imagePath;
            _outputPath = outputPath;
        }

        // these seemingly intuitive ways of loading an image will lock the file
        // - with a stream
        // - Image.FromFile()
        // use this method instead: https://stackoverflow.com/a/8701772
        private static Bitmap toImage(string filepath)
        {
            using var bmpTemp = new Bitmap(filepath);
            return new Bitmap(bmpTemp);
        }

        public void Start(IProgress<int> progress = null, CancellationToken token = default)
        {
            var bitmap = toImage(_imagePath);

            //create a new excel document
            var xlWorkbook = xlApp.Workbooks.Add();
            var xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
            xlWorksheet.Unprotect();
            xlWorksheet.StandardWidth = 20 / 7.25;

            var xlRange = xlWorksheet.UsedRange;

            // assign it here rather than in the for loop to avoid multithreading calamities
            var width = bitmap.Width;
            var height = bitmap.Height;

            // using 'float' here avoids casts when calc'ing %
            float totalPixels = width * height;
            var pixelCounter = 0;

            var locker = new object();

            try
            {
                // i = across, j = up, image coordinates start from bottom left corner whereas excel starts from top left
                Parallel.For(0, height, (j, loopState) =>
                {
                    for (var i = 0; i < width; i++)
                    {
                        if (token.IsCancellationRequested)
                            break;

                        var cell = xlRange.Cells[j + 1, i + 1];

                        // GetPixel and SetPixel are SLOW. Improvements:
                        // - https://csharpexamples.com/tag/parallel-bitmap-processing/
                        // - https://codereview.stackexchange.com/questions/78835/parallelizing-bitmap-methods
                        // - https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap.lockbits?redirectedfrom=MSDN&view=dotnet-plat-ext-6.0#overloads
                        Color color;
                        // even though file access is safe, the GDI+ object isn't threadsafe
                        lock (locker)
                            color = bitmap.GetPixel(i, j);

                        // transparent
                        if (color.A == 0)
                            cell.Interior.ColorIndex = 0;
                        // non-transparent
                        else
                            cell.Interior.Color = ColorTranslator.ToOle(color);

                        pixelCounter++;
                    }
                    
                    if (token.IsCancellationRequested)
                        loopState.Stop();

                    var progressFloat = pixelCounter / totalPixels * 100;
                    var progressInt = Convert.ToInt32(progressFloat);
                    progress?.Report(progressInt);
                });

                // skip save as. skip report progress complete
                if (token.IsCancellationRequested)
                    return;
                
                xlWorkbook.SaveAs(_outputPath);
            }
            finally
            {
                xlWorkbook.Close(0);
                xlApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            }

            progress?.Report(Complete);
        }
    }
}
