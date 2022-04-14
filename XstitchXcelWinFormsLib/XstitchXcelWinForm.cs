using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dinah.Core.Threading;
using XstitchXcelWinFormsLib.Panels;

namespace XstitchXcelWinFormsLib
{
	public partial class XstitchXcelWinForm : Form, IRunner
	{
		public XstitchXcelWinForm()
		{
			InitializeComponent();
		}

		#region run tool async
		public async Task RunAsync(IRunCommand runCommand)
		{
			var ex = await runAsync(runCommand);

			if (ex is not null)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				runCommand.OnFailure();
				return;
			}

			if (runCommand.ShowSuccessDialog)
				MessageBox.Show("Successfully completed");

			runCommand.OnSuccess();
		}

		private async Task<Exception> runAsync(IRunCommand runCommand)
		{
			try
			{
				disableUI();

				await Task.Run(runCommand.Run);

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

				enableUI();

				var focusControl = runCommand.FocusControl;
				focusControl?.UIThreadAsync(() => {
					if (focusControl is TextBoxBase tb)
						tb.SelectAll();
					focusControl.Focus();
				});
			}
		}

		/// <summary>
		/// set enable for each control in form, not on Form/"this" (which would freezes the form itself in place)
		/// </summary>
		private void disableUI() => setEnable(false);
		private void enableUI() => setEnable(true);
		private void setEnable(bool enable)
		{
			foreach (var c in Controls.Cast<Control>())
				setEnableRecurs(c, enable);
		}
		private static void setEnableRecurs(Control control, bool enable)
		{
			foreach (var c in control.Controls.Cast<Control>())
				setEnableRecurs(c, enable);

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
