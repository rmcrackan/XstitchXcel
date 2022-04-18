using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace XstitchXcelWinFormsLib.Controls
{
    public partial class _PickerBaseControl : UserControl
    {
        public event EventHandler FileNameChanged
        {
            add => this.textBox1.TextChanged += value;
            remove => this.textBox1.TextChanged -= value;
        }
        public event KeyPressEventHandler FileNameKeyPress
        {
            add => this.textBox1.KeyPress += value;
            remove => this.textBox1.KeyPress -= value;
        }

        public event EventHandler SelectButtonClick
        {
            add => this.button1.Click += value;
            remove => this.button1.Click -= value;
        }

        public string DialogTitle { get; set; }
        public string FileTypeName { get; set; }
        public string FileExtension { get; set; }

        public string FileFilterOverride { get; set; }

        protected string GetFilter()
            => !string.IsNullOrWhiteSpace(this.FileFilterOverride)
            ? this.FileFilterOverride
            : $"{this.FileTypeName} (*.{this.FileExtension})|*.{this.FileExtension}|All files (*.*)|*.*";

        public string LabelText
        {
            get => this.label1.Text;
            set => this.label1.Text = value;
        }

        // expose to code, hide from designer
        [Browsable(false)]
        public string FileName
        {
            get => this.textBox1.Text;
            set => this.textBox1.Text = value;
        }

        public _PickerBaseControl()
        {
            InitializeComponent();
        }
    }
}
