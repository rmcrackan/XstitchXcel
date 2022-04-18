using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XstitchXcelLib.DataClasses;

namespace XstitchXcelWinFormsLib
{
    public interface IMasterForm : IRunner
    {
        string FileName { get; }

        event EventHandler NewExcelFileSelected;

        Pattern GetPattern();
    }

    public interface IRunner
    {
        Task RunAsync(IRunCommand runCommand);
        void Cancel();
    }

    public static class RunnerExtensions
    {
        public class DynamicRunCommand : IRunCommand
        {
            public bool ShowSuccessDialog { get; set; } = true;
            public Control FocusControl { get; set; }

            public Action<CancellationToken> RunActionDelegate { get; set; }
            public Action SuccessActionDelegate { get; set; }
            public Action CancelledActionDelegate { get; set; }
            public Action FailureActionDelegate { get; set; }

            public bool IsValid() => true;
            public void Run(CancellationToken cancellationToken) => RunActionDelegate?.Invoke(cancellationToken);
            public void OnSuccess() => SuccessActionDelegate?.Invoke();
            public void OnCancelled() => CancelledActionDelegate?.Invoke();
            public void OnFailure() => FailureActionDelegate?.Invoke();
        }
        public static async Task TextBoxEnterKeyAsync(this IRunner runner, KeyPressEventArgs e, Action<CancellationToken> action, Control focusControl = null)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                // silence the 'ding'
                e.Handled = true;

                await runner.RunAsync(action, focusControl);
            }
        }

        public static Task RunAsync(this IRunner runner, Action<CancellationToken> action, Control focusControl = null)
            => runner.RunAsync(new DynamicRunCommand()
            {
                RunActionDelegate = action,
                FocusControl = focusControl,
                ShowSuccessDialog = focusControl is null
            });
    }
}