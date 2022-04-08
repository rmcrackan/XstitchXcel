using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XstitchXcelLib;

namespace XstitchXcelWinFormsLib.Controls
{
    public partial class ColorBoxControl : UserControl
    {
        public event KeyPressEventHandler ColorTextBoxKeyPress
        {
            add => colorTb.KeyPress += value;
            remove => colorTb.KeyPress -= value;
        }

        // designer
        public string Title
        {
            get => this.titleLbl.Text;
            set => this.titleLbl.Text = value;
        }

        // expose to code, hide from designer
        [Browsable(false)]
        public string ColorName
        {
            get => this.colorTb.Text;
            set => this.colorTb.Text = value;
        }

        public ColorBoxControl()
        {
            InitializeComponent();
        }

        private void colorTb_TextChanged(object sender, EventArgs e) => setDmcPictureBox(colorTb, colorPb, colorLbl);

        private static DmcColorProcessor dmcColorProcessor { get; } = new DmcColorProcessor();

        private static void setDmcPictureBox(TextBox tb, PictureBox pb, Label isDmcLbl)
        {
            var color = dmcColorProcessor.SmartColorFinder(tb.Text);

            var isValidColor = !color.IsEquivalent(Color.Empty);

            pb.Visible = isValidColor && !color.IsTransparent();
            isDmcLbl.Visible = isValidColor;
            if (!isValidColor)
                return;

            pb.BackColor = color;

            isDmcLbl.Text
                = color.IsTransparent() ? "Transparent"
                : dmcColorProcessor.TryGetMatch(color, out var dmcColor) ? $"DMC # {dmcColor.DmcNumber} - {dmcColor.Name}"
                : "Non-DMC";
        }
    }
}
