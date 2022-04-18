using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XstitchXcelWinFormsLib.Panels
{
    public partial class ReplaceColorBasePanel : _ToolControlsBase
    {
        public bool BackupChecked => this.backupCb.Checked;
        public string OldColorName => this.colorBoxControl1.ColorName;
        public string NewColorName => this.colorBoxControl2.ColorName;

        public ReplaceColorBasePanel() : this(null) { }
        public ReplaceColorBasePanel(string instructions) : base(new(instructions, "Begin color replace"))
        {
            InitializeComponent();
        }

        private async void colorTextBoxKeyPress(object sender, KeyPressEventArgs e) => await Runner.TextBoxEnterKeyAsync(e, Run);
    }
}
