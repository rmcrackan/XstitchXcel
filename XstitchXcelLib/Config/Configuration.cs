using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using XstitchXcelLib.DataClasses;
using XstitchXcelLib.Interop;
using XstitchXcelLib.Utilities;

namespace XstitchXcelLib.Config
{
	public class Configuration
	{
		public static List<DmcColor> GetDmcColors()
		{
			// load DMC colors
			var json = File.ReadAllText(@"Config\dmc_colors.json");
			var dmcColors = JsonConvert
				.DeserializeObject<List<DmcColorEntry>>(json)
				.Select(d => d.ToDmcColor())
				.ToList();
			return dmcColors;
		}

		/// <summary>Can call expensive ExcelReader GetSprites</summary>
		public static Pattern GetPattern(string inputFile)
		{
			if (string.IsNullOrWhiteSpace(inputFile))
				throw new Exception("Must provide a file name");

			if (Path.GetExtension(inputFile).Trim('.').ToLower() != "xlsx")
				throw new Exception("unexpected file extension");

			var jsonFilename = Path.Combine(Path.GetDirectoryName(inputFile), Path.GetFileNameWithoutExtension(inputFile) + ".json");
			var patternEntry = File.Exists(jsonFilename)
				? JsonConvert.DeserializeObject<PatternEntry>(File.ReadAllText(jsonFilename))
				: new PatternEntry();

			var saveFile = false;

			saveFile |= xlsxToSprites(patternEntry, inputFile);
			saveFile |= docxToSymbols(patternEntry, inputFile);

			if (saveFile)
			{
				var json = JsonConvert.SerializeObject(patternEntry, Formatting.Indented);
				File.WriteAllText(jsonFilename, json);
			}

			// pad with any default symbols which aren't already present. don't save to file
			var defaultSymbols = JsonConvert.DeserializeObject<List<SymbolEntry>>(File.ReadAllText(@"Config\symbols.json"));
			var newSymbols = defaultSymbols.Where(s => !patternEntry.Symbols.Contains(s)).ToList();
			patternEntry.Symbols.AddRange(newSymbols);

			return patternEntry.ToPattern(inputFile);
		}

		private static bool xlsxToSprites(PatternEntry patternEntry, string inputFile)
		{
			var xlsxInputFileLastModified = File.GetLastWriteTimeUtc(inputFile);

			if (patternEntry?.Sprites is not null && patternEntry.Sprites.Any() && xlsxInputFileLastModified <= patternEntry.XlsxLastModified)
				return false;

			patternEntry.XlsxLastModified = xlsxInputFileLastModified;

			var spriteExtractor = new SpriteExtractor(inputFile);
			patternEntry.Sprites = spriteExtractor.GetSprites().ToSpriteEntries();

			if (patternEntry?.Sprites is not null && patternEntry.Sprites.Any() && string.IsNullOrWhiteSpace(patternEntry.Sprites[0].Name))
				patternEntry.Sprites[0].Name = Path.GetFileNameWithoutExtension(inputFile);

			return true;
		}

		private static bool docxToSymbols(PatternEntry patternEntry, string xlsxInputFile)
		{
			var docxFile = Path.Combine(Path.GetDirectoryName(xlsxInputFile), Path.GetFileNameWithoutExtension(xlsxInputFile) + ".docx");

			if (!File.Exists(docxFile))
				return false;

			var docxInputFileLastModified = File.GetLastWriteTimeUtc(docxFile);

			if (docxInputFileLastModified <= patternEntry.DocxLastModified)
				return false;

			patternEntry.DocxLastModified = docxInputFileLastModified;

			using var reader = new WordReader(docxFile);
			patternEntry.Symbols = reader.GetSymbols().ToSymbolEntries();

			return true;
		}
	}
}