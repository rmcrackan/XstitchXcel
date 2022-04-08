using System;
using System.Windows.Forms;

namespace XstitchXcelWinFormsLib
{
    public interface IRunCommand
    {
        bool ShowSuccessDialog { get; }
        Control FocusControl { get; }

        void Run();
        void OnSuccess();
        void OnFailure();
    }
}
