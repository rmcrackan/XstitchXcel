using System;
using System.Threading;
using System.Windows.Forms;
using XstitchXcelLib.Tools;

namespace XstitchXcelWinFormsLib.Panels
{
    public partial class BatchConvertPanel : _ToolControlsBase
    {
        public override bool UseGlobalExcelFile => false;

        private const string INSTRUCTIONS = @"
For each image in source directory:

* copy to destination directory
* convert to xlsx
* match colors to nearest DMC
* create cross stitch pattern
";
        private const string SUBMIT_BUTTON_TEXT = "Start Batch Convert";

        public BatchConvertPanel() : base(new(INSTRUCTIONS, SUBMIT_BUTTON_TEXT))
        {
            InitializeComponent();
        }

        private async void fileNameKeyPress(object sender, KeyPressEventArgs e) => await Runner.TextBoxEnterKeyAsync(e, Run);

        public override void Run(CancellationToken cancellationToken) => new BatchConvert(this.sourceBrowseFolderControl.FileName, this.destinationBrowseFolderControl.FileName).Start();
    }
}
