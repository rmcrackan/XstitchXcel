using System;
using XstitchXcelLib.Tools;

namespace XstitchXcelWinFormsLib.Panels
{
    public partial class FindDmcColorsPanel : _ToolControlsBase
    {
        private const string INSTRUCTIONS = @"Finds the non-DMC colors in your file. Creates report with the closest DMC matches";
        private const string SUBMIT_BUTTON_TEXT = "Create Reports";

        public FindDmcColorsPanel() : base(new(INSTRUCTIONS, SUBMIT_BUTTON_TEXT))
        {
            InitializeComponent();
        }

        public override void Run()
            => new PatternAnalyzer(MasterForm.GetPattern())
            .ReportNonDmc();
    }
}
