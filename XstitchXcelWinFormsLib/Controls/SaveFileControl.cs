using System;
using System.Windows.Forms;

namespace XstitchXcelWinFormsLib.Controls
{
    public partial class SaveFileControl : _PickerBaseControl
    {
        public SaveFileControl()
        {
            InitializeComponent();
        }

        private void SaveFileControl_SelectButtonClick(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Title = this.DialogTitle,

                AddExtension = true,
                CheckPathExists = true,
                DefaultExt = this.FileExtension,
                FileName = this.FileName,
                Filter = GetFilter(),
                FilterIndex = 0,
                OverwritePrompt = true
            };

            dialog.FileOk += (_, __) => this.FileName = dialog.FileName;
            dialog.ShowDialog();
        }
    }
}
