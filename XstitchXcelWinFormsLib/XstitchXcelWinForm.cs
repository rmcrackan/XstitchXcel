using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dinah.Core.Threading;

namespace XstitchXcelWinFormsLib
{
	public partial class XstitchXcelWinForm : Form
	{
		public XstitchXcelWinForm()
		{
			InitializeComponent();
		}

		#region run tool async
		public record RunSettings(bool ShowCompletedDialog, Control Focus);
		private static RunSettings DefaultRunSettings { get; } = new RunSettings(true, null);

		protected Task TextBoxEnterKeyAsync(KeyPressEventArgs e, Action action) => TextBoxEnterKeyAsync(e, action, DefaultRunSettings);
		protected async Task TextBoxEnterKeyAsync(KeyPressEventArgs e, Action action, RunSettings settings)
		{
			if (e.KeyChar == (char)Keys.Return)
			{
				// silence the 'ding'
				e.Handled = true;

				await RunFullAsync(action, settings);
			}
		}

		protected Task RunFullAsync(Action action) => RunFullAsync(action, DefaultRunSettings);
		protected async Task RunFullAsync(Action action, RunSettings settings)
		{
			var ex = await RunAsync(action, settings);

			if (ex is not null)
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else if (settings.ShowCompletedDialog)
				MessageBox.Show("Successfully completed");
		}

		protected Task<Exception> RunAsync(Action action) => RunAsync(action, DefaultRunSettings);
		protected async Task<Exception> RunAsync(Action action, RunSettings settings)
		{
			try
			{
				disableUI();

				await Task.Run(action);

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

				settings?.Focus?.UIThreadAsync(() => {
					var control = settings.Focus;
					if (control is TextBoxBase tb)
						tb.SelectAll();
					control.Focus();
				});
			}
		}

		private void disableUI() => setEnable(false);
		private void enableUI() => setEnable(true);
		private void setEnable(bool enable)
		{
			// set enable for each control in form, not on Form/"this" (which would freezes the form itself in place)
			foreach (var c in this.Controls.Cast<Control>())
				setEnableRecurs(c, enable);
		}
		private static void setEnableRecurs(Control control, bool enable)
		{
			foreach (var c in control.Controls.Cast<Control>())
				setEnableRecurs(c, enable);

			control.Enabled = enable;
		}
		#endregion
	}
}
