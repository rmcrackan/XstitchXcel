using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using XstitchXcelLib.DataClasses;

namespace XstitchXcelLib.Config
{
	public static class Converters
	{
		public static Symbol ToSymbol(this SymbolEntry symbolEntry) => new Symbol
		{
			FontName = symbolEntry.FontName,
			Bold = symbolEntry.Bold,
			Italic = symbolEntry.Italic,
			StrikeThrough = symbolEntry.StrikeThrough,
			Subscript = symbolEntry.Subscript,
			Superscript = symbolEntry.Superscript,
			Underline = symbolEntry.Underline,
			Character = symbolEntry.GetCharacter()
		};
		public static SymbolEntry ToSymbolEntry(this Symbol symbol) => new SymbolEntry
		{
			FontName = symbol.FontName,
			Bold = symbol.Bold,
			Italic = symbol.Italic,
			StrikeThrough = symbol.StrikeThrough,
			Subscript = symbol.Subscript,
			Superscript = symbol.Superscript,
			Underline = symbol.Underline,
			Utf32 = char.ConvertToUtf32(symbol.Character, 0)
		};

		public static List<SymbolEntry> ToSymbolEntries(this IEnumerable<Symbol> symbols) => symbols.Select(s => s.ToSymbolEntry()).ToList();

		public static Pixel ToPixel(this PixelEntry pixelEntry) => new Pixel
		{
			Text = pixelEntry.Text,
			RowNumber = pixelEntry.RowNumber,
			ColumnNumber = pixelEntry.ColumnNumber,
			Color = Color.FromArgb(pixelEntry.Argb)
		};
		public static PixelEntry ToPixelEntry(this Pixel pixel) => new PixelEntry
		{
			Text = pixel.Text,
			RowNumber = pixel.RowNumber,
			ColumnNumber = pixel.ColumnNumber,
			Argb = pixel.Color.ToArgb()
		};

		public static Sprite ToSprite(this SpriteEntry spriteEntry) => new Sprite
		{
			Name = spriteEntry.Name,
			Pixels = spriteEntry.Pixels.Select(p => p.ToPixel()).ToList()
		};
		public static SpriteEntry ToSpriteEntry(this Sprite sprite) => new SpriteEntry
		{
			Name = sprite.Name,
			Pixels = sprite.Pixels.Select(p => p.ToPixelEntry()).ToList()
		};

		public static List<SpriteEntry> ToSpriteEntries(this IEnumerable<Sprite> sprites) => sprites.Select(s => s.ToSpriteEntry()).ToList();

		public static Pattern ToPattern(this PatternEntry patternEntry, string inputFile) => new Pattern(inputFile)
		{
			Sprites = patternEntry.Sprites.Select(s => s.ToSprite()).ToList(),
			Symbols = patternEntry.Symbols.Select(s => s.ToSymbol()).ToList()
		};

		public static DmcColor ToDmcColor(this DmcColorEntry dmcColorEntry) => new DmcColor
		{
			DmcNumber = dmcColorEntry.DmcNumber,
			Name = dmcColorEntry.Name,
			Color = Color.FromArgb(dmcColorEntry.Red, dmcColorEntry.Green, dmcColorEntry.Blue)
		};
		public static DmcColorEntry ToDmcColorEntry(this DmcColor dmcColor) => new DmcColorEntry
		{
			DmcNumber = dmcColor.DmcNumber,
			Name = dmcColor.Name,
			Red = dmcColor.Color.R,
			Green = dmcColor.Color.G,
			Blue = dmcColor.Color.B
		};
	}
}
