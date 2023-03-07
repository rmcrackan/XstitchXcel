using System;
using XstitchXcelLib.DataClasses;

namespace XstitchXcelWinFormsLib
{
    public interface IMasterForm<T> where T : System.Windows.Forms.Control
    {
        event EventHandler NewExcelFileSelected;

        string FileName { get; set; }

        T GetInstance();

        Pattern GetPattern();
    }
}