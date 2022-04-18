using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XstitchXcelLib;
using XstitchXcelLib.Tools;

namespace XstitchXcelWinFormsLib.Panels
{
    public partial class ImageToExcelPanel : _ToolControlsBase
    {
        public override bool UseGlobalExcelFile => false;
        private const string INSTRUCTIONS = "Convert image file to excel file.";
        private const string SUBMIT_BUTTON_TEXT = "Create excel file";
        public override bool IsCancellable => true;

        private Progress<int> progress { get; }

        public ImageToExcelPanel() : base(new(INSTRUCTIONS, SUBMIT_BUTTON_TEXT))
        {
            InitializeComponent();

            var types = SupportedImageFormats.GetDelimited();
            openFileControl1.LabelText = "Source image";
            openFileControl1.FileExtension = SupportedImageFormats.DefaultExtension;
            openFileControl1.FileFilterOverride = $"Image Files({types})|{types}";

            saveFileControl1.LabelText = "Excel file path";
            saveFileControl1.FileTypeName = "Excel";
            saveFileControl1.FileExtension = "xlsx";

            progress = new Progress<int>(percent => this.progressBar1.Value = percent);
        }

        public override void Run(CancellationToken cancellationToken)
            => new ImageToExcel(openFileControl1.FileName, saveFileControl1.FileName).Start(progress, cancellationToken);

        public override void OnSuccess() => reset();
        public override void OnCancelled() => reset();
        public override void OnFailure() => reset();
        private void reset() => this.progressBar1.Value = 0;

        private async void fileNameKeyPress(object sender, KeyPressEventArgs e) => await Runner.TextBoxEnterKeyAsync(e, Run);
    }
}
