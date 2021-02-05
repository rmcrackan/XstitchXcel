using System;
using System.Collections.Generic;

namespace XstitchXcelLib.DataClasses
{
	public class Pattern
	{
		public List<Sprite> Sprites = new List<Sprite>();
		public List<Symbol> Symbols = new List<Symbol>();

		public string InputFile { get; }

		public Pattern(string inputFile) => InputFile = inputFile;
	}
}
