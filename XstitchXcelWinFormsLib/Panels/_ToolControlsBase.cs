using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XstitchXcelWinFormsLib.Panels
{
    public partial class _ToolControlsBase : __ToolPaneBase, IRunCommand
    {
        public record Configuration(string Instructions, string SubmitButtonText);

        public string Instructions { get; }
        public virtual bool UseGlobalExcelFile { get; } = true;
        public virtual bool IsCancellable { get; } = false;

        public _ToolControlsBase() : this(null) { }
        public _ToolControlsBase(Configuration configuration) : base()
        {
            InitializeComponent();

            if (configuration is null)
                return;

            this.Instructions = configuration.Instructions?.Trim();

            // this even works for designer
            this.button1.Text = configuration.SubmitButtonText;
            this.cancelBtn.Visible = IsCancellable;
        }

        protected IMasterForm MasterForm { get; private set; }

        public void RegisterMasterForm(IMasterForm masterForm)
        {
            MasterForm = masterForm;
            Register();
        }
        protected virtual void Register() { }

        #region IRunCommand
        public virtual bool IsValid() => true;
        public virtual void Run(CancellationToken cancellationToken) { }
        public virtual void OnSuccess() { }
        public virtual void OnCancelled() { }
        public virtual void OnFailure() { }

        public virtual bool ShowSuccessDialog => true;
        public virtual Control FocusControl { get; }

        private void cancelBtn_Click(object sender, EventArgs e) => MasterForm.Cancel();

        private async void button1_Click(object sender, EventArgs e) => await MasterForm.RunAsync(this);
        #endregion

        public virtual void SetEnable(bool enable)
        {
            foreach (var c in Controls.Cast<Control>())
                setEnableRecurs(c, enable);
        }
        private void setEnableRecurs(Control control, bool enable)
        {
            if (control == cancelBtn || control is ProgressBar)
            {
                control.Enabled = !enable;
                return;
            }

            foreach (var c in control.Controls.Cast<Control>())
                setEnableRecurs(c, enable);

            control.Enabled = enable;
        }
    }
}
