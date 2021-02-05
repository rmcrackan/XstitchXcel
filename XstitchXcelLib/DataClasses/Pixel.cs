using System;
using System.Drawing;

namespace XstitchXcelLib.DataClasses
{
	public record Pixel
	{
		public string Text { get; set; }

		/// <summary>1-based index</summary>
		public int RowNumber { get; init; }
		/// <summary>1-based index</summary>
		public int ColumnNumber { get; init; }

		private Color _color;
		public Color Color
		{
			get => _color;
			set => _color = Color.FromArgb(value.ToArgb());
		}

		public override string ToString()
		{
			var text
				= Text is null ? "[null]"
				: Text == "" ? "[empty]"
				: Text;

			var color
				= Color.IsTransparent()
				? "Transparent"
				: Color.GetHexColor();

			return $"[{RowNumber},{ColumnNumber}] {text}: {color}";
		}
	}
}
