using System;

namespace XstitchXcelLib.Config
{
	public class SymbolEntry
	{
		public int Utf32 { get; set; }

		public string GetCharacter() => char.ConvertFromUtf32(Utf32);

		public string FontName { get; set; }

		public bool Bold { get; set; }
		public bool Italic { get; set; }
		public bool StrikeThrough { get; set; }
		public bool Subscript { get; set; }
		public bool Superscript { get; set; }
		public bool Underline { get; set; }

		public override string ToString()
		{
			var str = $"'{GetCharacter()}' (Utf32={Utf32}) {FontName} ";

			var str2 = "";
			if (Bold) str2 += ",Bold";
			if (Italic) str2 += ",Italic";
			if (StrikeThrough) str2 += ",StrikeThrough";
			if (Subscript) str2 += ",Subscript";
			if (Superscript) str2 += ",Superscript";
			if (Underline) str2 += ",Underline";
			str2 = str2.Trim(',');

			var str3 = str + str2;
			return str3.Trim();
		}
	}
}
