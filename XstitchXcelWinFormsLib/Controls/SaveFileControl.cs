using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XstitchXcelWinFormsLib.Controls
{
    public partial class SaveFileControl : UserControl
    {
        public event EventHandler FileNameChanged
        {
            add => textBox1.TextChanged += value;
            remove => textBox1.TextChanged -= value;
        }
        public event KeyPressEventHandler FileNameKeyPress
        {
            add => textBox1.KeyPress += value;
            remove => textBox1.KeyPress -= value;
        }

        public string DialogTitle { get; set; }
        public string FileTypeName { get; set; }
        public string FileExtension { get; set; }

        public string LabelText
        {
            get => this.label1.Text;
            set => this.label1.Text = value;
        }

        // expose to code, hide from designer
        [Browsable(false)]
        public string TextBoxText
        {
            get => this.textBox1.Text;
            set => this.textBox1.Text = value;
        }

        public SaveFileControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = this.DialogTitle,

                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = this.FileExtension,
                FileName = textBox1.Text,
                Filter = $"{this.FileTypeName} (*.{this.FileExtension})|*.{this.FileExtension}|All files (*.*)|*.*",
                FilterIndex = 0,
                Multiselect = false
            };
            dialog.FileOk += (_, __) => textBox1.Text = dialog.FileName;
            dialog.ShowDialog();
        }
    }
}
