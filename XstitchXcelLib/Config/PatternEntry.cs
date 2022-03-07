using System;
using System.Collections.Generic;

namespace XstitchXcelLib.Config
{
	public class PatternEntry
	{
		[Newtonsoft.Json.JsonConstructor]
		private PatternEntry() { }

		public PatternEntry(string inputFile) => InputFile = inputFile;

		[Newtonsoft.Json.JsonIgnore]
		public string InputFile { get; set; }

		public DateTime XlsxLastModified { get; set; }
		public DateTime DocxLastModified { get; set; }

		public SpriteEntry Sprite = new();
		public List<GlyphEntry> Glyphs = new();
	}
}
