using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using XstitchXcelLib.DataClasses;

namespace XstitchXcelLib.Config
{
	public static class Converters
	{
		public static Glyph ToGlyph(this GlyphEntry glyphEntry) => new()
		{
			FontName = glyphEntry.FontName,
			Bold = glyphEntry.Bold,
			Italic = glyphEntry.Italic,
			StrikeThrough = glyphEntry.StrikeThrough,
			Subscript = glyphEntry.Subscript,
			Superscript = glyphEntry.Superscript,
			Underline = glyphEntry.Underline,
			Character = glyphEntry.GetCharacter()
		};
		public static GlyphEntry ToGlyphEntry(this Glyph glyph) => new()
		{
			FontName = glyph.FontName,
			Bold = glyph.Bold,
			Italic = glyph.Italic,
			StrikeThrough = glyph.StrikeThrough,
			Subscript = glyph.Subscript,
			Superscript = glyph.Superscript,
			Underline = glyph.Underline,
			Utf32 = char.ConvertToUtf32(glyph.Character, 0)
		};

		public static List<GlyphEntry> ToGlyphEntries(this IEnumerable<Glyph> glyphs) => glyphs.Select(s => s.ToGlyphEntry()).ToList();

		public static Pixel ToPixel(this PixelEntry pixelEntry) => new()
		{
			RowNumber = pixelEntry.RowNumber,
			ColumnNumber = pixelEntry.ColumnNumber,
			Color = Color.FromArgb(pixelEntry.Argb)
		};
		public static PixelEntry ToPixelEntry(this Pixel pixel) => new()
		{
			RowNumber = pixel.RowNumber,
			ColumnNumber = pixel.ColumnNumber,
			Argb = pixel.Color.ToArgb()
		};

		public static Sprite ToSprite(this SpriteEntry spriteEntry) => new()
		{
			Name = spriteEntry.Name,
			Pixels = spriteEntry.Pixels.Select(p => p.ToPixel()).ToList()
		};
		public static SpriteEntry ToSpriteEntry(this Sprite sprite) => new()
		{
			Name = sprite.Name,
			Pixels = sprite.Pixels.Select(p => p.ToPixelEntry()).ToList()
		};

		public static Pattern ToPattern(this PatternEntry patternEntry) => new(patternEntry.InputFile)
		{
			Sprite = patternEntry.Sprite.ToSprite(),
			Glyphs = patternEntry.Glyphs.Select(s => s.ToGlyph()).ToList()
		};

		public static DmcColor ToDmcColor(this DmcColorEntry dmcColorEntry) => new()
		{
			DmcNumber = dmcColorEntry.DmcNumber,
			Name = dmcColorEntry.Name,
			Color = Color.FromArgb(dmcColorEntry.Red, dmcColorEntry.Green, dmcColorEntry.Blue),
            Discontinued = dmcColorEntry.Discontinued,
            Replacements = dmcColorEntry.Replacements ?? new()
        };
		public static DmcColorEntry ToDmcColorEntry(this DmcColor dmcColor) => new()
		{
			DmcNumber = dmcColor.DmcNumber,
			Name = dmcColor.Name,
			Red = dmcColor.Color.R,
			Green = dmcColor.Color.G,
			Blue = dmcColor.Color.B,
			Discontinued = dmcColor.Discontinued,
			Replacements = dmcColor.Replacements ?? new()
        };
	}
}
