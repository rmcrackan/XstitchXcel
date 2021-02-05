﻿using System;
using System.Drawing;

namespace XstitchXcelLib.Config
{
	public class PixelEntry
	{
		public string Text { get; set; }

		/// <summary>1-based index</summary>
		public int RowNumber { get; set; }
		/// <summary>1-based index</summary>
		public int ColumnNumber { get; set; }

		public int Argb { get; set; }

		public override string ToString()
		{
			var text
				= Text is null ? "[null]"
				: Text == "" ? "[empty]"
				: Text;

			var color
				= Color.FromArgb(Argb).IsTransparent()
				? "Transparent"
				: Color.FromArgb(Argb).GetHexColor();

			return $"[{RowNumber},{ColumnNumber}] {text}: {color}";
		}
	}
}
