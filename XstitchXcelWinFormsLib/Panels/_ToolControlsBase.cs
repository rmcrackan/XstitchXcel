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
    public partial class _ToolControlsBase : __ToolPaneBase, IRunCommand
    {
        public record Configuration(string Instructions, string SubmitButtonText);

        public string Instructions { get; }

        public _ToolControlsBase() : this(null) { }
        public _ToolControlsBase(Configuration configuration) : base()
        {
            InitializeComponent();

            if (configuration is null)
                return;

            this.Instructions = configuration.Instructions;

            // this even works for designer
            this.button1.Text = configuration.SubmitButtonText;
        }

        protected IMasterForm MasterForm { get; private set; }

        public void RegisterMasterForm(IMasterForm masterForm)
        {
            MasterForm = masterForm;
            Register();
        }
        protected virtual void Register() { }

        #region IRunCommand
        public virtual void RunAction() { }
        public virtual void SuccessAction() { }
        public virtual void FailureAction() { }

        public virtual bool ShowSuccessDialog => true;
        public virtual Control FocusControl { get; }

        private async void button1_Click(object sender, EventArgs e) => await MasterForm.RunAsync(this);
        #endregion
    }
}
