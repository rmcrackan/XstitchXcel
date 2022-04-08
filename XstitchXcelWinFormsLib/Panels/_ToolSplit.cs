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
    public partial class _ToolSplit : __ToolPaneBase
    {
        private _ToolControlsBase child;

        public _ToolSplit() : base()
        {
            InitializeComponent();
        }

        private void _ToolSplit_Load(object sender, EventArgs e)
        {
            child = findChild_recurs();

            // find first _ToolControlsBase and load Instructions into textbox. this even works for designer
            this.instructionsTb.Text = child?.Instructions;
        }

        #region find child
        private _ToolControlsBase findChild_recurs()
        {
            foreach (var c in Controls.Cast<Control>())
            {
                var result = findChild_recurs(c);
                if (result is not null)
                    return result;
            }

            return null;
        }

        private static _ToolControlsBase findChild_recurs(Control control)
        {
            if (control is _ToolControlsBase toolControls)
                return toolControls;

            foreach (var c in control.Controls.Cast<Control>())
            {
                var result = findChild_recurs(c);
                if (result is not null)
                    return result;
            }

            return null;
        }
        #endregion
    }
}
