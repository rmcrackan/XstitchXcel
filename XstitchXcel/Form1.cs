using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using XstitchXcelLib.Config;
using XstitchXcelLib.DataClasses;
using XstitchXcelWinFormsLib;

namespace XstitchXcel
{
    public partial class Form1 : XstitchXcelWinForm, IMasterForm
    {
        public event EventHandler NewExcelFileSelected
        {
            add => this.openFileControl1.FileNameChanged += value;
            remove => this.openFileControl1.FileNameChanged -= value;
        }
        public string FileName => this.openFileControl1.FileName;
        public Pattern GetPattern() => Configuration.GetPattern(FileName);

        public Form1() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var tc in GetChildrenToolControls())
                tc.RegisterMasterForm(this);
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (!this.openFileControl1.Enabled)
                return;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (!this.openFileControl1.Enabled)
                return;

            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            var xlsx = files.FirstOrDefault(f => Path.GetExtension(f).Trim('.') == "xlsx");
            if (xlsx is not null)
                this.openFileControl1.FileName = xlsx;
        }
    }
}
