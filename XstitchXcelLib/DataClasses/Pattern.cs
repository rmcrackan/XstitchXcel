using System;
using System.Collections.Generic;

namespace XstitchXcelLib.DataClasses
{
	public class Pattern
	{
		public Sprite Sprite = new();
		public List<Symbol> Symbols = new();

		public string InputFile { get; }

		public Pattern(string inputFile) => InputFile = inputFile;
	}
}
