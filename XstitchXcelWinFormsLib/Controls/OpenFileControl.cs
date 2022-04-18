using System;
using System.Windows.Forms;

namespace XstitchXcelWinFormsLib.Controls
{
    public partial class OpenFileControl : _PickerBaseControl
    {
        public OpenFileControl()
        {
            InitializeComponent();
        }

        private void OpenFileControl_SelectButtonClick(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = this.DialogTitle,

                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = this.FileExtension,
                FileName = this.FileName,
                Filter = GetFilter(),
                FilterIndex = 0,
                Multiselect = false
            };
            dialog.FileOk += (_, __) => this.FileName = dialog.FileName;
            dialog.ShowDialog();
        }
    }
}
