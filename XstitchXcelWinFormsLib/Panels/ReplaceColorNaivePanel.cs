using System;
using System.Threading;
using XstitchXcelLib.Tools;

namespace XstitchXcelWinFormsLib.Panels
{
    public partial class ReplaceColorNaivePanel : ReplaceColorBasePanel
    {
        private const string INSTRUCTIONS = @"Replace color can use a pre-scan of the spreadsheet (as with the other tabs)
and quickly only replace the matching colors.

Naive replace color is the same except this scans the whole spreadsheet
each time and changes matching colors. No sprite parsing or preferred formatting.

Naive replace is more versitile, less efficient
";

        public ReplaceColorNaivePanel() : base(INSTRUCTIONS)
        {
            InitializeComponent();
        }

        public override void Run(CancellationToken cancellationToken)
            => ColorReplacer.NaiveReplace(MasterForm.FileName, OldColorName, NewColorName, BackupChecked);
    }
}
