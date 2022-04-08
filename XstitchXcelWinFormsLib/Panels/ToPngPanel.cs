using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XstitchXcelLib;
using XstitchXcelLib.Tools;

namespace XstitchXcelWinFormsLib.Panels
{
    public partial class ToPngPanel : _ToolControlsBase
    {
        private const string INSTRUCTIONS = @"Convert xlsx file to png image file.

If scaling the image up, the scale number is the multiplier for both directions: height and width.

Eg: scale=3: each new pixel/cell will be 3 cells across and 3 high.
";
        private const string SUBMIT_BUTTON_TEXT = "Create png";

        public ToPngPanel() : base(new(INSTRUCTIONS, SUBMIT_BUTTON_TEXT))
        {
            InitializeComponent();
            enableScaleUpDown(null, null);
        }

        protected override void Register()
        {
            MasterForm.NewExcelFileSelected += (_, __) =>
            {
                var newExt = Path.ChangeExtension(MasterForm.FileName, ".png");
                var withSuffix = HelperMethods.AddFileSuffix(newExt, " - output");
                var unique = HelperMethods.GetUniqueFileName(withSuffix);

                this.saveFileControl1.FileName = unique;
            };
        }

        private void enableScaleUpDown(object sender, EventArgs e) => toPngNud.Enabled = toPngScaleRb.Checked;

        private async void saveFileControl1_FileNameKeyPress(object sender, KeyPressEventArgs e) => await MasterForm.TextBoxEnterKeyAsync(e, Run);

        public override void Run()
        {
            var excelToImage = new ExcelToImage(MasterForm.GetPattern())
            {
                OutputFile = saveFileControl1.FileName
            };

            if (toPngScaleRb.Checked && toPngNud.Value > 1)
                excelToImage.SaveToPngResize((int)toPngNud.Value);
            else
                excelToImage.SaveToPng();
        }
    }
}
