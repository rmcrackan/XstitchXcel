using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dinah.Core.Threading;

namespace XstitchXcelWinFormsLib
{
    public static class RunnerExtensions
    {
        public class DynamicRunCommand : IRunCommand
        {
            public Action<CancellationToken> RunActionDelegate { get; set; }
            public Action CompleteActionDelegate { get; set; }
            public Action SuccessActionDelegate { get; set; }
            public Action CancelledActionDelegate { get; set; }
            public Action FailureActionDelegate { get; set; }

            public bool IsValid() => true;
            public void Run(CancellationToken cancellationToken) => RunActionDelegate?.Invoke(cancellationToken);
            public void OnComplete() => CompleteActionDelegate?.Invoke();
            public void OnSuccess() => SuccessActionDelegate?.Invoke();
            public void OnCancelled() => CancelledActionDelegate?.Invoke();
            public void OnFailure() => FailureActionDelegate?.Invoke();
        }

        public static async Task TextBoxEnterKeyAsync(this Runner runner, KeyPressEventArgs e, Action<CancellationToken> action, Control focusControl = null)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                // silence the 'ding'
                e.Handled = true;

                await runner.RunAsync(action, focusControl);
            }
        }

        public static Task RunAsync(this Runner runner, Action<CancellationToken> action, Control focusControl = null)
            => runner.RunAsync(new DynamicRunCommand()
            {
                RunActionDelegate = action,
                SuccessActionDelegate = () =>
                {
                    if (focusControl is null)
                        MessageBox.Show("Successfully completed");
                },
                CompleteActionDelegate = () =>
                {
                    focusControl?.UIThreadAsync(() => {
                        if (focusControl is TextBoxBase tb)
                            tb.SelectAll();
                        focusControl.Focus();
                    });
                }
            });
    }
}
