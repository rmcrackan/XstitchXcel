using System;
using XstitchXcelLib.Tools;

namespace XstitchXcelWinFormsLib.Panels
{
    public partial class ReplaceColorInPatternPanel : ReplaceColorBasePanel
    {
        private const string INSTRUCTIONS = @"Replace all of one color with a different color

This will makes changes to your file. To create a back up of the original file before changine it, use the checkbox.
Note: when this box is checked, a new backup file will be created each time you click the button

Options:
- Hex code. Eg: #123456 , f0f0f0
- DMC number. Eg: 310, B5200
- Transparent: T

Use ""T""ransparent as the ""old color"" to change the transparent background to a color
Use ""T""ransparent as the ""new color"" to remove the background color
";

        public ReplaceColorInPatternPanel() : base(INSTRUCTIONS)
        {
            InitializeComponent();
        }

        public override void Run()
            => new ColorReplacer(MasterForm.GetPattern()) { CreateBackupFile = BackupChecked }
            .TargetedReplace(OldColorName, NewColorName);
    }
}
