using System;
using System.Collections.Generic;
using System.Linq;

namespace XstitchXcelLib.Config
{
	public class PatternEntry
	{
		public DateTime XlsxLastModified { get; set; }
		public DateTime DocxLastModified { get; set; }

		public List<SpriteEntry> Sprites = new List<SpriteEntry>();
		public List<SymbolEntry> Symbols = new List<SymbolEntry>();
	}
}
