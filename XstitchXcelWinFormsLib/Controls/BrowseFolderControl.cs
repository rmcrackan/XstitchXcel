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
    public partial class BrowseFolderControl : _PickerBaseControl
    {
        public BrowseFolderControl()
        {
            InitializeComponent();
        }

        private void BrowseFolderControl_SelectButtonClick(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog { ShowNewFolderButton = true };

            if (dialog.ShowDialog() == DialogResult.OK)
                this.FileName = dialog.SelectedPath;
        }
    }
}
