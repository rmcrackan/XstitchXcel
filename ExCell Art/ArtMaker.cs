﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

// originally from https://github.com/JamesMatchett/ExCell-Art-Generator
// heavily adapted
namespace ExCell_Art
{
    public class ArtMaker
    {
        public BackgroundWorker bw { get; } = new BackgroundWorker
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true
        };

        private string _imagePath { get; }
        private string _outputPath { get; }

        private bool quitting = false;

        public Excel.Application xlApp = new Excel.Application();

        public ArtMaker(string imagePath, string outputPath)
        {
            _imagePath = imagePath;
            _outputPath = outputPath;

            bw.DoWork += bw_makeArt;
        }

        public void Start() => bw.RunWorkerAsync();

        public void Stop()
        {
            quitting = true;
            bw.CancelAsync();
            bw.Dispose();
        }

        private void bw_makeArt(object sender, EventArgs e)
        {
            //read input image
            Bitmap bm = new Bitmap(_imagePath);

            //create a new excel document
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
            Excel._Worksheet xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
            xlWorksheet.Unprotect();
            xlWorksheet.StandardWidth = 20 / 7.25;

            var xlRange = xlWorksheet.UsedRange;

            //assign it here rather than in the for loop to avoid multithreading calamities
            var width = bm.Width;
            var height = bm.Height;

            // using 'float' here avoids casts when calc'ing %
            float totalPixels = width * height;
            int pixelCounter = 0;

            object locker = new object();

            //i = across, j = up, image coordinates start from bottom left corner whereas excel starts from top left
            Parallel.For(0, height, (j, loopState) =>
            {
                for (var i = 0; i < width; i++)
                {
                    if (quitting)
                        break;

                    Color color;
                    lock (locker)
                        color = bm.GetPixel(i, j);

                    var cell = xlRange.Cells[j + 1, i + 1];

                    // transparent
                    if (color.A == 0)
                        cell.Interior.ColorIndex = 0;
                    // non-transparent
                    else
                        cell.Interior.Color = ColorTranslator.ToOle(color);

                    pixelCounter++;
                }

                if (quitting)
                    loopState.Stop();

                var progress = ((pixelCounter / totalPixels) * 100);
                var progressInt = Convert.ToInt32(progress);
                bw.ReportProgress(progressInt);
            });

            if (!quitting)
                xlWorkbook.SaveAs(_outputPath);

            xlWorkbook.Close(0);
            xlApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

            if (!quitting)
                bw.ReportProgress(101);
        }
    }
}
