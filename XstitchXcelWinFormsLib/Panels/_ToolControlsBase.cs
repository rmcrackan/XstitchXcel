using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XstitchXcelWinFormsLib.Controls;

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

        protected IMasterForm<Control> MasterForm { get; private set; }
        protected Runner Runner { get; private set; }

        public void RegisterMasterForm(IMasterForm<Control> masterForm)
        {
            MasterForm = masterForm;
            Runner = new(MasterForm.GetInstance());
            Register();
        }
        protected virtual void Register() { }

        #region IRunCommand
        public bool IsValid()
        {
            if (this.UseGlobalExcelFile && string.IsNullOrWhiteSpace(MasterForm.FileName))
            {
                MessageBox.Show("Choose a valid input excel file");
                return false;
            }

            foreach (var control in this.GetChildrenByType<_PickerBaseControl>())
                if (!control.IsValid())
                    return false;

            return true;
        }

        public virtual void Run(CancellationToken cancellationToken) { }

        public virtual void OnComplete() { }

        public virtual bool ShowSuccessDialog => true;
        public virtual void OnSuccess()
        {
            if (ShowSuccessDialog)
                MessageBox.Show("Successfully completed");
        }

        public virtual void OnCancelled() { }

        public virtual void OnFailure() { }

        private void cancelBtn_Click(object sender, EventArgs e) => Runner.Cancel();

        private async void button1_Click(object sender, EventArgs e) => await Runner.RunAsync(this);
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
