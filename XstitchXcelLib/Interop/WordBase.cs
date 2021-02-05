using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;
using Range = Microsoft.Office.Interop.Word.Range;

namespace XstitchXcelLib.Interop
{
	public abstract class WordBase : OfficeBase
	{
		protected abstract bool SaveFile { get; }

		private Application app { get; }
		protected Document Document { get; }

		protected WordBase(string fileName) : base(fileName)
		{
			app = Push(new Application { Visible = true });
			var documents = Push(app.Documents);
			Document = Push(Push(app.Documents).Open(FileName));
		}

		protected Selection GetSelection() => Push(app.Selection);

		protected override void DisposeHook()
		{
			if (SaveFile)
				try { Document?.SaveAs(FileName); }
				catch { }
			Document?.Close();
			app?.Quit();
		}
	}
}
