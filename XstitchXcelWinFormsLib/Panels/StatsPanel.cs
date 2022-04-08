using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XstitchXcelLib;
using XstitchXcelLib.DataClasses;
using XstitchXcelLib.Tools;

namespace XstitchXcelWinFormsLib.Panels
{
    public partial class StatsPanel : _ToolControlsBase
    {
        private const string SUBMIT_BUTTON_TEXT = "Generate Stats";
        private const string INSTRUCTIONS = null;

        private Pattern statsPattern;

        public StatsPanel() : base(new(INSTRUCTIONS, SUBMIT_BUTTON_TEXT))
        {
            InitializeComponent();

            statsCountNum.Value = 14;
            statsUnitCb.SelectedIndex = 0;

            updateStatsOut();
        }

        public override bool ShowSuccessDialog => false;

        public override void Run() => statsPattern = MasterForm.GetPattern();
        public override void OnSuccess()
        {
            var reporter = new StatsReporter(statsPattern);
            var results = reporter.StitchStatsReport();

            statsDgv.Rows.Clear();
            foreach (var x in results)
            {
                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell { Value = $"{x.Count}" });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = $"{x.MinSkeins:F1}" });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = $"{x.MaxSkeins:F1}" });

                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = $"{x.Hex}",
                    Style = new DataGridViewCellStyle
                    {
                        BackColor = x.Color,
                        ForeColor = x.Color.GetContrastColor()
                    }
                });

                row.Cells.Add(new DataGridViewTextBoxCell { Value = $"{x.DmcNumber}" });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = $"{x.DmcName}" });
                statsDgv.Rows.Add(row);
            }

            updateStatsOut();
        }
        public override void OnFailure() => statsPattern = null;

        private void updateStatsOut(object sender = null, EventArgs e = null)
        {
            var hasData = statsPattern is not null && statsDgv.RowCount > 0;

            var ct = Convert.ToDouble(statsCountNum.Value);

            var isValid = hasData && ct > 0;

            statsOutTb.Visible = isValid;

            if (!isValid)
                return;

            var sprite = statsPattern.Sprite;
            var heightInInches = sprite.Size.Height / ct;
            var widthInInches = sprite.Size.Width / ct;
            var unit = ((string)statsUnitCb.SelectedItem).ToLower().Trim();

            var tuple = unit switch
            {
                "inches" => (1, "inches"),
                "cm" => (2.54, "cm"),
                _ => throw new Exception()
            };
            (var multiplier, var abbrev) = tuple;

            statsOutTb.Text = $"{sprite.Pixels.Count:n0} stitches  {heightInInches * multiplier:F2}h x {widthInInches * multiplier:F2}w {abbrev}";
        }
    }
}
