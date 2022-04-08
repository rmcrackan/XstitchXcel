using System;
using System.Collections.Generic;
using System.Linq;
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

            this.Instructions = configuration.Instructions?.Trim();

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
        public virtual void Run() { }
        public virtual void OnSuccess() { }
        public virtual void OnFailure() { }

        public virtual bool ShowSuccessDialog => true;
        public virtual Control FocusControl { get; }

        private async void button1_Click(object sender, EventArgs e) => await MasterForm.RunAsync(this);
        #endregion
    }
}
