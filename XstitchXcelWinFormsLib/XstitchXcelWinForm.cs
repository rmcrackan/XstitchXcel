using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dinah.Core.Threading;
using XstitchXcelWinFormsLib.Panels;

namespace XstitchXcelWinFormsLib
{
	public partial class XstitchXcelWinForm : Form, IRunner
	{
		public XstitchXcelWinForm() => InitializeComponent();

		#region run tool async
		private CancellationTokenSource cancellationTokenSource;
		public async Task RunAsync(IRunCommand runCommand)
		{
			if (!runCommand.IsValid())
				return;

			cancellationTokenSource = new();
			var cancellationToken = cancellationTokenSource.Token;

			var ex = await runAsync(runCommand, cancellationToken);

			// should come after the cleanup in runAsync's "finally"
			if (ex is not null)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				runCommand.OnFailure();
				return;
			}

			if (cancellationToken.IsCancellationRequested)
            {
				MessageBox.Show("Cancelled");
				runCommand.OnCancelled();
				return;
			}

			if (runCommand.ShowSuccessDialog)
				MessageBox.Show("Successfully completed");

			runCommand.OnSuccess();
		}

		private async Task<Exception> runAsync(IRunCommand runCommand, CancellationToken cancellationToken)
		{
			try
			{
				disableUI();

				await Task.Run(() => runCommand.Run(cancellationToken), cancellationToken);

				return null;
			}
			catch (Exception e)
			{
				return e;
			}
			finally
			{
				GC.Collect();
				GC.WaitForPendingFinalizers();

				EnableUI();

				var focusControl = runCommand.FocusControl;
				focusControl?.UIThreadAsync(() => {
					if (focusControl is TextBoxBase tb)
						tb.SelectAll();
					focusControl.Focus();
				});
			}
		}
		public void Cancel() => cancellationTokenSource.Cancel();

		/// <summary>
		/// set enable for each control in form, not on Form/"this" (which would freezes the form itself in place)
		/// </summary>
		protected void EnableUI() => setEnable(true);
		private void disableUI() => setEnable(false);
		private void setEnable(bool enable)
		{
			foreach (var c in Controls.Cast<Control>())
				setEnableRecurs(c, enable);
		}
		private static void setEnableRecurs(Control control, bool enable)
		{
			// these handle themselves. don't dig deeper
			if (control is _ToolControlsBase toolControlsBase)
			{
				toolControlsBase.SetEnable(enable);
				return;
			}

			foreach (var c in control.Controls.Cast<Control>())
				setEnableRecurs(c, enable);

			// these are containers. don't freeze them. do traverse.
			// later add these containers and their elements. eg: TabControl has TabPage elements
			// - FlowLayoutPanel
			// - GroupBox
			// - SplitContainer
			// - TableLayoutPanel
			if (control is not TabControl &&
				control is not TabPage &&
				control is not Panel &&
				control is not __ToolPaneBase)
				control.Enabled = enable;
		}
		#endregion

		protected List<_ToolControlsBase> GetChildrenToolControls(Control control)
		{
			var list = new List<_ToolControlsBase>();
			getChildrenToolControls(control, list);
			return list;
		}
		private static void getChildrenToolControls(Control control, List<_ToolControlsBase> list)
		{
			if (control is _ToolControlsBase toolControl)
				list.Add(toolControl);

			foreach (var c in control.Controls.Cast<Control>())
				getChildrenToolControls(c, list);
		}
	}
}
