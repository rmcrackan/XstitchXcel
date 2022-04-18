using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XstitchXcelLib;
using XstitchXcelLib.Tools;

namespace XstitchXcelWinFormsLib.Panels
{
    public partial class CrtBlurPanel : _ToolControlsBase
    {
        private const string INSTRUCTIONS = @"Apply a CRT blur effect to your design.

ALL non-transparent pixels are treated as white, then the CRT blur effect is applied.
";
        private const string SUBMIT_BUTTON_TEXT = "Create CRT Blur";

        public CrtBlurPanel() : base(new(INSTRUCTIONS, SUBMIT_BUTTON_TEXT))
        {
            InitializeComponent();
        }

        protected override void Register()
            => MasterForm.NewExcelFileSelected += (_, __)
                => this.saveFileControl1.FileName = HelperMethods.GetUniqueFileName(HelperMethods.AddFileSuffix(MasterForm.FileName, " - output"));

        private async void saveFileControl1_FileNameKeyPress(object sender, KeyPressEventArgs e) => await Runner.TextBoxEnterKeyAsync(e, Run);

        public override void Run(CancellationToken cancellationToken)
        {
            var pattern = MasterForm.GetPattern();

            var crtBlurer = new CrtBlurer(pattern)
            {
                OutputFile = saveFileControl1.FileName
            };

            crtBlurer.SaveToFile();
        }
    }
}
