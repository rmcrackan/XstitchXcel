using System;
using System.Windows.Forms;

namespace XstitchXcelWinFormsLib
{
    public interface IRunCommand
    {
        bool ShowSuccessDialog { get; }
        Control FocusControl { get; }

        void RunAction();
        void SuccessAction();
        void FailureAction();
    }
}
