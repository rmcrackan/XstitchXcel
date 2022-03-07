using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using XstitchXcelLib.DataClasses;

namespace XstitchXcelLib.Tools
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles")]
    public class ExcelToImage : ToolBase
    {
        public string OutputFile { get; set; }

        public ExcelToImage(Pattern pattern) : base(pattern)
        {
            OutputFile = Path.ChangeExtension(Pattern.InputFile, ".png");
        }

        public void SaveToPng()
        {
            using var bitmap = patternToBitmap(Pattern.Sprite.Size);

            bitmap.Save(OutputFile, ImageFormat.Png);
        }

        public void SaveToPngResize(int scale)
        {
            var size = Pattern.Sprite.Size;

            using var bitmap = patternToBitmap(size);

            var scaleWidth = size.Width * scale;
            var scaleHeight = size.Height * scale;

            var destImage = new Bitmap(scaleWidth, scaleHeight);
            destImage.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);

            var graphics = Graphics.FromImage(destImage);
            graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphics.PixelOffsetMode = PixelOffsetMode.Half;

            var destRect = new Rectangle(0, 0, scaleWidth, scaleHeight);

            using var wrapMode = new ImageAttributes();
            wrapMode.SetWrapMode(WrapMode.TileFlipXY);
            graphics.DrawImage(bitmap, destRect, 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, wrapMode);

            destImage.Save(OutputFile, ImageFormat.Png);
        }

        private Bitmap patternToBitmap(Size size)
        {
            var bitmap = new Bitmap(size.Width, size.Height);
            foreach (var p in Pattern.Sprite.Pixels)
                bitmap.SetPixel(p.ColumnNumber - 1, p.RowNumber - 1, p.Color);
            return bitmap;
        }
    }
}
