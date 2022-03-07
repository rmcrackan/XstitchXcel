using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.Word;
using XstitchXcelLib.DataClasses;
using Word = Microsoft.Office.Interop.Word;
using Range = Microsoft.Office.Interop.Word.Range;

namespace XstitchXcelLib.Interop
{
	public class WordReader : WordBase
	{
		protected override bool SaveFile => false;

		public WordReader(string fileName) : base(fileName) { }

		public static string[] DISALLOWED_CHARS { get; } = new string[] { " ", "\r", "\n", "\t", "\v" };
		public List<Glyph> GetGlyphs()
		{
			if (Document.Paragraphs.Count == 0)
				return new List<Glyph>();

			return Document
				// 1-based indexing: Paragraphs[1]
				.Paragraphs
				.Cast<Paragraph>()
				.SelectMany(p =>
					p.Range.Characters
					.Cast<Range>()
					.Where(r => !DISALLOWED_CHARS.Contains(r.Text))
					.Select(r => new Glyph
					{
						Character = r.Text,
						FontName = r.Font.Name,
						Bold = r.Font.Bold != 0,
						Italic = r.Font.Italic != 0,
						StrikeThrough = r.Font.StrikeThrough != 0,
						Subscript = r.Font.Subscript != 0,
						Superscript = r.Font.Superscript != 0,
						Underline = r.Font.Underline != 0
					})
				)
				.Distinct()
				.ToList();
		}
	}
}
