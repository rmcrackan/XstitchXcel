using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XstitchXcelLib;
using XstitchXcelLib.Tools;

namespace XstitchXcelWinFormsLib.Panels
{
    public partial class CreatePatternPanel : _ToolControlsBase
    {
        private const string INSTRUCTIONS = @"Convert your excel design to a new excel file: formatted as 1 or more printable patterns

Default symbols will be used. To create your own symbols/glyphs, type your symbols into a word file. Name the word file the same thing as your excel file.
Example:
    C:\what\ever\My Design.xlsx
    C:\what\ever\My Design.docx
We'll match font and style choices like bold, italics, etc.
";
        private const string SUBMIT_BUTTON_TEXT = "Create Pattern";

        public CreatePatternPanel() : base(new(INSTRUCTIONS, SUBMIT_BUTTON_TEXT))
        {
            InitializeComponent();
        }

        protected override void Register()
            => MasterForm.NewExcelFileSelected += (_, __)
                => this.saveFileControl1.TextBoxText = HelperMethods.GetUniqueFileName(HelperMethods.AddFileSuffix(MasterForm.FileName, " - output"));

        private async void saveFileControl1_FileNameKeyPress(object sender, KeyPressEventArgs e) => await MasterForm.TextBoxEnterKeyAsync(e, Run);

        public override void Run()
            => new PatternBuilder(MasterForm.GetPattern())
            {
                OutputFile = saveFileControl1.TextBoxText,
                PrintColorsGrid = colorsCb.Checked,
                PrintGlyphsGrid = glyphsCb.Checked,
                PrintColorsAndGlyphsGrid = colorsAndGlyphsCb.Checked,
            }
            .ConvertToPattern();
    }
}
