using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace XstitchXcelLib
{
	// json de/ser
	public partial class Palette
	{
		public class JsonColor
		{
			// canonical value
			public int Argb { get; }

			// for readability only
			public string Hex => Color.ToHex();

			[Newtonsoft.Json.JsonIgnore]
			public Color Color => Color.FromArgb(Argb);

			[Newtonsoft.Json.JsonConstructor]
			public JsonColor(int argb, string hex) : this(Color.FromArgb(argb)) { }

			public JsonColor(Color color) => Argb = color.ToArgb();
		}

		[Newtonsoft.Json.JsonProperty]
		private List<KeyValuePair<PaletteEntry, JsonColor>> jsonColorMap => ColorMap.Select(kvp => new KeyValuePair<PaletteEntry, JsonColor>(kvp.Key, new JsonColor(kvp.Value))).ToList();

		[Newtonsoft.Json.JsonConstructor]
		private Palette(string name, string notes, List<KeyValuePair<PaletteEntry, JsonColor>> jsonColorMap)
		{
			Name = name;
			Notes = notes;
			ColorMap = jsonColorMap.ToDictionary(
				kv => kv.Key,
				kv => kv.Value.Color);
		}

		// https://stackoverflow.com/questions/42677693/serialize-deserialize-a-dictionary-that-contain-a-class-key
		public static string SerializeDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary) where TKey : notnull
			=> Newtonsoft.Json.JsonConvert.SerializeObject(dictionary.ToList());

		public static Dictionary<TKey, TValue> DeserializeDictionary<TKey, TValue>(string json)
			=> Newtonsoft.Json.JsonConvert.DeserializeObject<List<KeyValuePair<TKey, TValue>>>(json)
			.ToDictionary(
				kv => kv.Key,
				kv => kv.Value);
	}
}
