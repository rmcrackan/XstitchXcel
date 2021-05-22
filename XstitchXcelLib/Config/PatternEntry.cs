using System;
using System.Collections.Generic;

namespace XstitchXcelLib.Config
{
	public class PatternEntry
	{
		public DateTime XlsxLastModified { get; set; }
		public DateTime DocxLastModified { get; set; }

		public List<SpriteEntry> Sprites = new();
		public List<SymbolEntry> Symbols = new();
	}
}
