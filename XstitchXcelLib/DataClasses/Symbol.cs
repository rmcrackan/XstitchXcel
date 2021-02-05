using System;

namespace XstitchXcelLib.DataClasses
{
	public record Symbol
	{
		public string Character { get; init; }

		public string FontName { get; init; }

		public bool Bold { get; init; }
		public bool Italic { get; init; }
		public bool StrikeThrough { get; init; }
		public bool Subscript { get; init; }
		public bool Superscript { get; init; }
		public bool Underline { get; init; }

		public override string ToString()
		{
			var str = $"'{Character}' {FontName} ";

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
