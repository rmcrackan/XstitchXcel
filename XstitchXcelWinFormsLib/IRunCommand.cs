using System;
using System.Threading;
using System.Windows.Forms;

namespace XstitchXcelWinFormsLib
{
    public interface IRunCommand
    {
        bool ShowSuccessDialog { get; }
        Control FocusControl { get; }

        bool IsValid();
        void Run(CancellationToken cancellationToken);
        void OnSuccess();
        void OnCancelled();
        void OnFailure();
    }
}
