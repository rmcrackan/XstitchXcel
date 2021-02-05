using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.Word;
using XstitchXcelLib.DataClasses;
using Word = Microsoft.Office.Interop.Word;
using Range = Microsoft.Office.Interop.Word.Range;

namespace XstitchXcelLib.Interop
{
	public class WordWriter : WordBase
	{
		protected override bool SaveFile => true;

		public WordWriter(string fileName) : base(fileName) { }

		public void Overwrite(string text)
		{
			var content = Push(Document.Content);
			content.SetRange(0, 0);
			content.Text = text;
		}

		public void Append(string text)
		{
			// https://stackoverflow.com/a/32694286
			Document.Characters.Last.Select();
			var selection = GetSelection();
			selection.Collapse();
			selection.TypeText(text);
		}
	}
}
