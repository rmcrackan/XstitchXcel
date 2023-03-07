using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using Dinah.Core;
using Dinah.Core.Collections.Generic;
using XstitchXcelLib.DataClasses;

namespace XstitchXcelLib.Tools
{
	public record DmcColorName : IComparable<DmcColorName>
	{
		private static Regex regex { get; } = new Regex(
			@"
^\s*(
# letters only: White, Ecru, CEcru
(?<word>[a-zA-Z]+)

# digits only
| (?<number>\d+)

# single letter followed by digits: S820, B5200, C310, E1010
| (?<letter>[a-zA-Z])\s*(?<number>\d+)
)\s*$
",
			RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace | RegexOptions.ExplicitCapture
			);

		public char? Prefix { get; }

		// name is actually a string. eg: "310", "5200", "Ecru"
		// however, numbers should still sort like int
		public int Number { get; }
		public string Name { get; }

		public DmcColorName(int number)
		{
			Number = number;
			Name = number.ToString();
		}
		public DmcColorName(string name) => Name = name;
		public DmcColorName(char prefix, int number) : this(number) => Prefix = char.ToUpper(prefix);
		public DmcColorName(char prefix, string name) : this(name) => Prefix = char.ToUpper(prefix);

		public bool IsVariant(DmcColorName dmcColorName) => this != dmcColorName && this.Name.EqualsInsensitive(dmcColorName.Name);

		public static bool TryParse(string colorName, out DmcColorName dmcColorName)
		{
			dmcColorName = null;
			
			colorName = colorName ?? throw new ArgumentNullException(nameof(colorName));

			var match = regex.Match(colorName);
			if (!match.Success)
				return false;

			var word = match.Groups["word"].ToString();
			if (!string.IsNullOrWhiteSpace(word))
			{
				if (word.EqualsInsensitive("CBlanc"))
				{
					dmcColorName = new DmcColorName('C', "Blanc");
					return true;
				}
				if (word.EqualsInsensitive("CEcru"))
				{
					dmcColorName = new DmcColorName('C', "Ecru");
					return true;
				}
				dmcColorName = new DmcColorName(word);
				return true;
			}

			var n = match.Groups["number"].ToString();
			var number = int.Parse(n);

			var letter = match.Groups["letter"].ToString();
			if (!string.IsNullOrWhiteSpace(letter))
			{
				dmcColorName = new DmcColorName(letter[0], number);
				return true;
			}

			dmcColorName = new DmcColorName(number);
			return true;
		}

		// these should sort first and in this order
		private static string[] first { get; } = new string[] { "B5200", "WHITE", "BLANC", "CBLANC", "ECRU", "CECRU" };
		public int CompareTo(DmcColorName obj)
		{
			if (obj is null)
				return -1;

			var thisPos = Array.IndexOf<string>(first, this.ToString().ToUpper());
			var objPos = Array.IndexOf<string>(first, obj.ToString().ToUpper());

			if (thisPos >= 0 && objPos < 0)
				return -1;
			if (thisPos < 0 && objPos >= 0)
				return 1;
			if (thisPos >= 0 && objPos >= 0)
				return thisPos < objPos ? -1 : 1;

			if (this.Number != 0 && obj.Number != 0)
			{
				if (this.Number != obj.Number)
					return this.Number.CompareTo(obj.Number);
				if (this.Prefix is null)
					return -1;
				return ((int)this.Prefix).CompareTo((obj.Prefix));
			}

			// numbers come first
			if (this.Number == 0 && obj.Number != 0)
				return 1;
			if (this.Number != 0 && obj.Number == 0)
				return -1;

			else // this.Number == 0 && obj.Number == 0
			{
				if (this.Name != obj.Name)
					return this.Name.CompareTo(obj.Name);
				return ((int)this.Prefix).CompareTo((obj.Prefix));
			}
		}

		public override string ToString() => $"{Prefix}{Name}";
	}
	public class InventoryEntry
	{
		public List<SectionEntry> Sections { get; set; } = new();
	}
	public class SectionEntry
	{
		public string Header { get; set; }
		public List<ColorEntry> Rows { get; set; } = new();
	}
	public class ColorEntry
	{
		public DmcColorName DmcColorName { get; set; }
		public int Quantity { get; set; }
	}
	public enum Section
	{
		None,

        [Description("INVENTORY")]
        Inventory,

        [Description("SHOPPING LIST")]
        ShoppingList
    }
	public static class InventoryCommon
	{
		public const string INVENTORY_SECTION = "INVENTORY";
		public const string SHOPPING_LIST_SECTION = "SHOPPING LIST";
		public const string DIVIDER = "=============";
	}
	public interface IInventoryDataLayer
	{
		InventoryEntry Load();
		void Save(InventoryEntry inventoryEntry);
	}
	public class InventoryDataLayer : IInventoryDataLayer
	{
		private string _filename { get; }

		public InventoryDataLayer(string filename) => _filename = filename ?? throw new ArgumentNullException(nameof(filename));

		public InventoryEntry Load()
		{
			var inventoryEntry = new InventoryEntry();

			var lines = System.IO.File.ReadAllLines(_filename);
			SectionEntry sectionEntry = null;
			foreach (var line in lines)
			{
				if (string.IsNullOrWhiteSpace(line))
					continue;

				if (line.EqualsInsensitive(InventoryCommon.INVENTORY_SECTION))
				{
					sectionEntry = new SectionEntry { Header = InventoryCommon.INVENTORY_SECTION };
					inventoryEntry.Sections.Add(sectionEntry);
					continue;
				}

				if (line.EqualsInsensitive(InventoryCommon.SHOPPING_LIST_SECTION))
				{
					sectionEntry = new SectionEntry { Header = InventoryCommon.SHOPPING_LIST_SECTION };
					inventoryEntry.Sections.Add(sectionEntry);
					continue;
				}

				// divider line
				if (line.Distinct().Count() == 1)
				{
					continue;
				}

				// else: color
				var parts = line.Split('\t');
				if (!DmcColorName.TryParse(parts[0], out var color))
					throw new Exception($"This line does not start with a DMC color:\r\n{line}");
				var qty = (parts.Length == 1) ? 0 : int.Parse(parts[1]);

				sectionEntry.Rows.Add(new() { DmcColorName = color, Quantity = qty });
			}

			if (!inventoryEntry.Sections.Any(s => s.Header == InventoryCommon.SHOPPING_LIST_SECTION))
				inventoryEntry.Sections.Add(new SectionEntry { Header = InventoryCommon.SHOPPING_LIST_SECTION });

			if (!inventoryEntry.Sections.Any(s => s.Header == InventoryCommon.INVENTORY_SECTION))
				inventoryEntry.Sections.Add(new SectionEntry { Header = InventoryCommon.INVENTORY_SECTION });

			return inventoryEntry;
		}

		public void Save(InventoryEntry inventoryEntry)
		{
			var sb = new System.Text.StringBuilder();
			foreach (var sectionEntry in inventoryEntry.Sections)
			{
				sb.AppendLine(sectionEntry.Header);
				sb.AppendLine(InventoryCommon.DIVIDER);

				foreach (var row in sectionEntry.Rows.OrderBy(r => r.DmcColorName))
					sb.AppendLine($"{row.DmcColorName}\t{row.Quantity}");

				sb.AppendLine();
			}

			System.IO.File.WriteAllText(_filename, sb.ToString());
		}
	}
	public class Inventory
	{
		private IInventoryDataLayer _inventoryDataLayer { get; }

		public Inventory(string filename) : this(new InventoryDataLayer(filename)) { }
		public Inventory(IInventoryDataLayer inventoryDataLayer) => _inventoryDataLayer = inventoryDataLayer ?? throw new ArgumentNullException(nameof(inventoryDataLayer));

        public bool TryAdd(string dmc, Section section, out List<(DmcColorName color, int qty, bool isWarned)> inventoryEntries)
            => tryAdd(dmc, section.GetDescription(), out inventoryEntries);
        public bool TryAddToInventory(string dmc, out List<(DmcColorName color, int qty, bool isWarned)> inventoryEntries)
			=> tryAdd(dmc, InventoryCommon.INVENTORY_SECTION, out inventoryEntries);
		public bool TryAddToShoppingList(string dmc, out List<(DmcColorName color, int qty, bool isWarned)> inventoryEntries)
			=> tryAdd(dmc, InventoryCommon.SHOPPING_LIST_SECTION, out inventoryEntries);
		private bool tryAdd(string dmc, string header, out List<(DmcColorName color, int qty, bool isWarned)> inventoryEntries)
		{
			inventoryEntries = new();

			var success = DmcColorName.TryParse(dmc, out var dmcColorName);
			if (!success)
				return false;

			var inventoryEntry = _inventoryDataLayer.Load();

			var inventorySection = inventoryEntry.Sections.Single(s => s.Header == header);

			// add color
			var colorEntry = inventorySection.Rows.SingleOrDefault(r => r.DmcColorName == dmcColorName);
			if (colorEntry is null)
			{
				colorEntry = new ColorEntry { DmcColorName = dmcColorName, Quantity = 0 };
				inventorySection.Rows.Add(colorEntry);
			}
			colorEntry.Quantity++;
			inventoryEntries.Add((dmcColorName, colorEntry.Quantity, getIsWarned(dmcColorName)));

			var variants = inventorySection.Rows.Where(r => r.DmcColorName.IsVariant(dmcColorName)).ToList();
			foreach (var variant in variants)
				inventoryEntries.Add((variant.DmcColorName, variant.Quantity, false));

			_inventoryDataLayer.Save(inventoryEntry);

			return true;
		}

		private bool getIsWarned(DmcColorName dmcColorName)
		{
			var processor = new DmcColorProcessor();
			return processor.GetByDmcNumber(dmcColorName.Name) is null && processor.GetByDmcNumber(dmcColorName.ToString()) is null;
        }

        public bool TryRemove(string dmc, Section section, out List<(DmcColorName color, int qty, bool wasPresent)> inventoryEntries)
            => tryRemove(dmc, section.GetDescription(), out inventoryEntries);
        public bool TryRemoveFromInventory(string dmc, out List<(DmcColorName color, int qty, bool wasPresent)> inventoryEntries)
			=> tryRemove(dmc, InventoryCommon.INVENTORY_SECTION, out inventoryEntries);
		public bool TryRemoveFromShoppingList(string dmc, out List<(DmcColorName color, int qty, bool wasPresent)> inventoryEntries)
			=> tryRemove(dmc, InventoryCommon.SHOPPING_LIST_SECTION, out inventoryEntries);
		private bool tryRemove(string dmc, string header, out List<(DmcColorName color, int qty, bool wasPresent)> inventoryEntries)
		{
			inventoryEntries = new();

			var success = DmcColorName.TryParse(dmc, out var dmcColorName);
			if (!success)
				return false;

			var inventoryEntry = _inventoryDataLayer.Load();

			var inventorySection = inventoryEntry.Sections.Single(s => s.Header == header);

			var colorEntry = inventorySection.Rows.SingleOrDefault(r => r.DmcColorName == dmcColorName);

			if (colorEntry is null)
			{
				inventoryEntries.Add((dmcColorName, 0, false));

				// do not remove variants. just report them
				var variants = inventorySection.Rows.Where(r => r.DmcColorName.IsVariant(dmcColorName)).ToList();
				foreach (var variant in variants)
					inventoryEntries.Add((variant.DmcColorName, variant.Quantity, true));

				return false;
			}

			colorEntry.Quantity--;

			if (colorEntry.Quantity == 0)
				inventorySection.Rows.Remove(colorEntry);

			inventoryEntries.Add((dmcColorName, colorEntry.Quantity, true));

			_inventoryDataLayer.Save(inventoryEntry);

			return true;
		}

        public bool Search(string dmc, Section section, out List<(DmcColorName color, int qty)> inventoryEntries)
            => search(dmc, section.GetDescription(), out inventoryEntries);
        public bool SearchInventory(string dmc, out List<(DmcColorName color, int qty)> inventoryEntries)
			=> search(dmc, InventoryCommon.INVENTORY_SECTION, out inventoryEntries);
		private bool search(string dmc, string header, out List<(DmcColorName color, int qty)> inventoryEntries)
		{
			inventoryEntries = new();

			var success = DmcColorName.TryParse(dmc, out var dmcColorName);
			if (!success)
				return false;

			var inventoryEntry = _inventoryDataLayer.Load();

			var inventorySection = inventoryEntry.Sections.Single(s => s.Header == header);

			var colorEntry = inventorySection.Rows.SingleOrDefault(r => r.DmcColorName == dmcColorName);
			if (colorEntry is not null)
				inventoryEntries.Add((colorEntry.DmcColorName, colorEntry.Quantity));

			var variants = inventorySection.Rows.Where(r => r.DmcColorName.IsVariant(dmcColorName)).ToList();
			foreach (var variant in variants)
				inventoryEntries.Add((variant.DmcColorName, variant.Quantity));

			return inventoryEntries.Any();
		}

		public List<DmcColor> FindAllMissingDmcColors()
        {
			var owned = _inventoryDataLayer.Load()
				.Sections.Single(s => s.Header == InventoryCommon.INVENTORY_SECTION)
				.Rows.Select(r => r.DmcColorName.ToString())
				.ToList();
			var except = Config.Configuration
				.GetDmcColors()
				.Where(dmc => !owned.ContainsInsensative(dmc.DmcNumber))
				.ToList();
			return except;
		}
    }
}
