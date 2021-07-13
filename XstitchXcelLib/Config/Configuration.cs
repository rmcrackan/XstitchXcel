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

			var patternEntry = loadPattern(inputFile);

			var saveFile = false;

			saveFile |= xlsxToSprite(patternEntry);
			saveFile |= docxToSymbols(patternEntry);

			if (saveFile)
				savePattern(patternEntry);

			// pad with any default symbols which aren't already present. don't save to file
			var defaultSymbols = GetDefaultSymbolEntries();
			var newSymbols = defaultSymbols.Where(s => !patternEntry.Symbols.Contains(s)).ToList();
			patternEntry.Symbols.AddRange(newSymbols);

			return patternEntry.ToPattern();
		}

		public static List<SymbolEntry> GetDefaultSymbolEntries() => JsonConvert.DeserializeObject<List<SymbolEntry>>(File.ReadAllText(@"Config\symbols.json"));

		private static bool xlsxToSprite(PatternEntry patternEntry)
		{
			if (patternEntry?.Sprite is not null &&
				File.GetLastWriteTimeUtc(patternEntry.InputFile) <= patternEntry.XlsxLastModified)
				return false;

			patternEntry.RefreshXlsxLastModified();

			patternEntry.Sprite = SpriteExtractor
				.GetSprite(patternEntry.InputFile)
				.ToSpriteEntry();

			if (patternEntry?.Sprite is not null && string.IsNullOrWhiteSpace(patternEntry.Sprite.Name))
				patternEntry.Sprite.Name = Path.GetFileNameWithoutExtension(patternEntry.InputFile);

			return true;
		}

		private static bool docxToSymbols(PatternEntry patternEntry)
		{
			var docxFile = Path.Combine(Path.GetDirectoryName(patternEntry.InputFile), Path.GetFileNameWithoutExtension(patternEntry.InputFile) + ".docx");

			if (!File.Exists(docxFile) ||
				File.GetLastWriteTimeUtc(docxFile) <= patternEntry.DocxLastModified)
				return false;

			patternEntry.RefreshDocxLastModified();

			using var reader = new WordReader(docxFile);
			patternEntry.Symbols = reader.GetSymbols().ToSymbolEntries();

			return true;
		}

		public static void SaveSprite(Sprite sprite, string inputFile)
		{
			var patternEntry = loadPattern(inputFile);
			patternEntry.Sprite = sprite.ToSpriteEntry();
			patternEntry.RefreshXlsxLastModified();
			savePattern(patternEntry);
		}

		/// <summary>
		/// this is the ONLY place PatternEntry should be constructed. This ensures inputFile is always correctly populated
		/// </summary>
		/// <param name="inputFile"></param>
		/// <returns></returns>
		private static PatternEntry loadPattern(string inputFile)
		{
			var jsonFilename = getJsonFilename(inputFile);

			if (!File.Exists(jsonFilename))
				return new(inputFile);

			var patternEntry = JsonConvert.DeserializeObject<PatternEntry>(File.ReadAllText(jsonFilename));
			patternEntry.InputFile = inputFile;

			return patternEntry;
		}

		private static void savePattern(PatternEntry patternEntry)
		{
			var filename = getJsonFilename(patternEntry.InputFile);
			var json = JsonConvert.SerializeObject(patternEntry, Formatting.Indented);
			File.WriteAllText(filename, json);
		}

		private static string getJsonFilename(string inputFile) => Path.Combine(Path.GetDirectoryName(inputFile), Path.GetFileNameWithoutExtension(inputFile) + ".json");
	}
	internal static class ConfigurationHelpers
	{
		public static void RefreshXlsxLastModified(this PatternEntry patternEntry)
			=> refreshLastModified(
				patternEntry.InputFile,
				patternEntry.XlsxLastModified,
				dt => patternEntry.XlsxLastModified = dt);

		public static void RefreshDocxLastModified(this PatternEntry patternEntry)
			=> refreshLastModified(
				Path.Combine(Path.GetDirectoryName(patternEntry.InputFile), Path.GetFileNameWithoutExtension(patternEntry.InputFile) + ".docx"),
				patternEntry.DocxLastModified,
				dt => patternEntry.DocxLastModified = dt);

		private static void refreshLastModified(
			string filepath,
			DateTime fileLastModified,
			Action<DateTime> setDateTime)
		{
			if (!File.Exists(filepath))
				return;

			var lastModified = File.GetLastWriteTimeUtc(filepath);

			if (lastModified <= fileLastModified)
				return;

			setDateTime(lastModified);
		}
	}
}