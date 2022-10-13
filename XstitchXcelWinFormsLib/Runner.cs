using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dinah.Core.Threading;

namespace XstitchXcelWinFormsLib
{
	public class Runner
	{
		private CancellationTokenSource cancellationTokenSource;

		private Control control { get; }

		public Runner(Control control) => this.control = control ?? throw new ArgumentNullException(nameof(control));

		public async Task RunAsync(IRunCommand runCommand)
		{
			if (!runCommand.IsValid())
				return;

			cancellationTokenSource = new();
			var cancellationToken = cancellationTokenSource.Token;

			var ex = await runAsync(runCommand, cancellationToken);

			runCommand.OnComplete();

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

			runCommand.OnSuccess();
		}

		private async Task<Exception> runAsync(IRunCommand runCommand, CancellationToken cancellationToken)
		{
			try
			{
				control.DisableUI();

				await Task.Run(() => runCommand.Run(cancellationToken), cancellationToken);

				return null;
			}
			catch (Exception e)
			{
				return e;
			}
			finally
			{
				// unfortunately needed to ensure headless excel is closed
				GC.Collect();
				GC.WaitForPendingFinalizers();

				control.EnableUI();
			}
		}

		public void Cancel() => cancellationTokenSource.Cancel();
	}
}
