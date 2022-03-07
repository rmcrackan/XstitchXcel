using System;
using System.Collections.Generic;

namespace XstitchXcelLib.DataClasses
{
	public class Pattern
	{
		public Sprite Sprite = new();
		public List<Glyph> Glyphs = new();

		public string InputFile { get; }

		public Pattern(string inputFile) => InputFile = inputFile;
	}
}
