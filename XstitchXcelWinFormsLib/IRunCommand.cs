using System;
using System.Threading;
using System.Windows.Forms;

namespace XstitchXcelWinFormsLib
{
    public interface IRunCommand
    {
        bool IsValid();
        void Run(CancellationToken cancellationToken);

        /// <summary>Run on completion, regardless of failure, success, cancelled</summary>
        void OnComplete();

        void OnSuccess();
        void OnCancelled();
        void OnFailure();
    }
}
