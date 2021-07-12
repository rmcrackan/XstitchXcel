using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dinah.Core.Windows.Forms;
using XstitchXcelLib;
using XstitchXcelLib.Config;
using XstitchXcelLib.DataClasses;
using XstitchXcelLib.Tools;

namespace XstitchXcel
{
	public partial class Form1 : Form
	{
		private DmcColorProcessor dmcColorProcessor { get; } = new DmcColorProcessor();

		public Form1()
		{
			InitializeComponent();

			initStats();
			initInventory();
		}

		#region main form
		private void Form1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
		}

		private void Form1_DragDrop(object sender, DragEventArgs e)
		{
			var files = (string[])e.Data.GetData(DataFormats.FileDrop);

			var xlsx = files.FirstOrDefault(f => Path.GetExtension(f).Trim('.') == "xlsx");
			if (xlsx is not null)
				fileNameTb.Text = xlsx;
		}

		private void fileNameTb_TextChanged(object sender, EventArgs e)
		{
			var output = HelperMethods.GetUniqueFileName(HelperMethods.AddFileSuffix(fileNameTb.Text, " - output"));

			patternOutputTb.Text = output;
			crtBlurOutputTb.Text = output;
		}

		private void fileNameBtn_Click(object sender, EventArgs e)
		{
			var dialog = new OpenFileDialog
			{
				Title = "Select the Excel file with your design",

				CheckFileExists = true,
				CheckPathExists = true,
				DefaultExt = "xlsx",
				FileName = fileNameTb.Text,
				Filter = "Excel Spreadsheet (*.xlsx)|*.xlsx|All files (*.*)|*.*",
				FilterIndex = 0,
				Multiselect = false
			};

			if (dialog.ShowDialog() == DialogResult.OK)
				fileNameTb.Text = dialog.FileName;
		}
		#endregion

		private Pattern getPattern() => Configuration.GetPattern(fileNameTb.Text);

		#region tab: Create Pattern
		private void patternOutputBtn_Click(object sender, EventArgs e)
		{
			var dialog = new SaveFileDialog
			{
				Title = "Save generated pattern file",

				AddExtension = true,
				DefaultExt = "xlsx",
				FileName = patternOutputTb.Text,
				Filter = "Excel Spreadsheet (*.xlsx)|*.xlsx|All files (*.*)|*.*",
				FilterIndex = 0,
				OverwritePrompt = true
			};

			if (dialog.ShowDialog() == DialogResult.OK)
				patternOutputTb.Text = dialog.FileName;
		}

		private async void patternOutputTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, createPattern);
		private async void createPatternBtn_Click(object sender, EventArgs e) => await RunFullAsync(createPattern);
		private void createPattern()
		{
			var pattern = getPattern();

			var builder = new PatternBuilder(pattern)
			{
				OutputFile = patternOutputTb.Text,
				PrintColorsGrid = colorsCb.Checked,
				PrintSymbolsGrid = symbolsCb.Checked,
				PrintColorsAndSymbolsGrid = colorsAndSymbolsCb.Checked,
			};

			builder.ConvertToPattern();
		}
		#endregion

		#region tab: Stats
		private void initStats()
		{
			statsCountNum.Value = 14;
			statsUnitCb.SelectedIndex = 0;

			updateStatsOut(null, null);
		}

		private Pattern statsPattern;
		private async void generateStatsBtn_Click(object sender, EventArgs e)
		{
			var ex = await RunAsync(() => statsPattern = getPattern());
			if (ex is not null)
			{
				statsPattern = null;
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var reporter = new StatsReporter(statsPattern);
			var results = reporter.StitchStatsReport();

			statsDgv.Rows.Clear();
			foreach (var x in results)
			{
				var row = new DataGridViewRow();
				row.Cells.Add(new DataGridViewTextBoxCell { Value = $"{x.Count}" });
				row.Cells.Add(new DataGridViewTextBoxCell { Value = $"{x.MinSkeins:F1}" });
				row.Cells.Add(new DataGridViewTextBoxCell { Value = $"{x.MaxSkeins:F1}" });

				row.Cells.Add(new DataGridViewTextBoxCell
				{
					Value = $"{x.Hex}",
					Style = new DataGridViewCellStyle
					{
						BackColor = x.Color,
						ForeColor = x.Color.GetContrastColor()
					}
				});

				row.Cells.Add(new DataGridViewTextBoxCell { Value = $"{x.DmcNumber}" });
				row.Cells.Add(new DataGridViewTextBoxCell { Value = $"{x.DmcName}" });
				statsDgv.Rows.Add(row);
			}

			updateStatsOut(sender, e);
		}

		private void updateStatsOut(object sender, EventArgs e)
		{
			var hasData = statsPattern is not null && statsDgv.RowCount > 0;

			var ct = Convert.ToDouble(statsCountNum.Value);

			var isValid = hasData && ct > 0;

			statsOutTb.Visible = isValid;

			if (!isValid)
				return;

			var sprite = statsPattern.Sprites[0];
			var heightInInches = sprite.Size.Height / ct;
			var widthInInches = sprite.Size.Width / ct;
			var unit = ((string)statsUnitCb.SelectedItem).ToLower().Trim();

			var tuple = unit switch
			{
				"inches" => (1, "inches"),
				"cm" => (2.54, "cm"),
				_ => throw new Exception()
			};
			(var multiplier, var symbol) = tuple;

			statsOutTb.Text = $"{sprite.Pixels.Count:n0} stitches  {heightInInches * multiplier:F2}h x {widthInInches * multiplier:F2}w {symbol}";
		}
		#endregion

		#region tab: Find DMC Colors
		private async void findDmcColorsBtn_Click(object sender, EventArgs e) => await RunFullAsync(() => new PatternAnalyzer(getPattern()).DiscoverNonDmcAllSprites());
		#endregion

		#region tab: Replace Color
		private void oldColorTb_TextChanged(object sender, EventArgs e) => setPictureBox(oldColorTb, oldColorPb, oldIsDmcLbl);
		private void newColorTb_TextChanged(object sender, EventArgs e) => setPictureBox(newColorTb, newColorPb, newIsDmcLbl);
		private void setPictureBox(TextBox tb, PictureBox pb, Label isDmcLbl)
		{
			var color = HelperMethods.SmartColorFinder(tb.Text, dmcColorProcessor);

			var isValidColor = !color.IsEquivalent(Color.Empty);

			pb.Visible = isValidColor && !color.IsTransparent();
			isDmcLbl.Visible = isValidColor;
			if (!isValidColor)
				return;

			pb.BackColor = color;

			isDmcLbl.Text
				= color.IsTransparent() ? "Transparent"
				: dmcColorProcessor.TryGetMatch(color, out var dmcColor) ? $"DMC # {dmcColor.DmcNumber} - {dmcColor.Name}"
				: "Non-DMC";
		}

		private async void oldColorTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, replaceColor);
		private async void newColorTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, replaceColor);
		private async void beginColorReplaceBtn_Click(object sender, EventArgs e) => await RunFullAsync(replaceColor);
		private void replaceColor()
			=> new ColorReplacer(getPattern())
			{
				CreateBackupFile = replaceColorBakCb.Checked
			}
			.Replace(oldColorTb.Text, newColorTb.Text);
		#endregion

		#region tab: CRT Blur
		private void crtBlurOutputBtn_Click(object sender, EventArgs e)
		{
			var dialog = new SaveFileDialog
			{
				Title = "Save generated CRT Blur file",

				AddExtension = true,
				DefaultExt = "xlsx",
				FileName = crtBlurOutputTb.Text,
				Filter = "Excel Spreadsheet (*.xlsx)|*.xlsx|All files (*.*)|*.*",
				FilterIndex = 0,
				OverwritePrompt = true
			};

			if (dialog.ShowDialog() == DialogResult.OK)
				crtBlurOutputTb.Text = dialog.FileName;
		}

		private async void crtBlurOutputTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, createCrtBlur);
		private async void createCrtBlurBtn_Click(object sender, EventArgs e) => await RunFullAsync(createCrtBlur);
		private void createCrtBlur()
		{
			var pattern = getPattern();

			var crtBlurer = new CrtBlurer(pattern)
			{
				OutputFile = crtBlurOutputTb.Text
			};

			crtBlurer.SaveToFile();
		}
		#endregion

		#region tab: Inventory
		private string InventoryFilePath
		{
			get
			{
				var contents = File.ReadAllText("appsettings.json");
				var jObj = Newtonsoft.Json.Linq.JObject.Parse(contents);
				var inventoryFilePath = jObj.Value<string>("InventoryFile");
				return inventoryFilePath;
			}
		}

		private void initInventory()
		{
			// load file name into form
			inventoryFileTb.Text = InventoryFilePath;
		}

		private void inventoryFileTb_TextChanged(object sender, EventArgs e)
			=> inventoryFileSaveBtn.Enabled = inventoryFileTb.Text != InventoryFilePath;

		private void inventoryFileBtn_Click(object sender, EventArgs e)
		{
			var dialog = new OpenFileDialog
			{
				Title = "Select the Excel file with your inventory",

				CheckFileExists = true,
				CheckPathExists = true,
				DefaultExt = "xlsx",
				FileName = inventoryFileTb.Text,
				Filter = "Excel Spreadsheet (*.xlsx)|*.xlsx|All files (*.*)|*.*",
				FilterIndex = 0,
				Multiselect = false
			};

			if (dialog.ShowDialog() == DialogResult.OK)
				inventoryFileTb.Text = dialog.FileName;
		}

		private void inventoryFileSaveBtn_Click(object sender, EventArgs e)
		{
			var contents = File.ReadAllText("appsettings.json");
			var jObj = Newtonsoft.Json.Linq.JObject.Parse(contents);
			jObj["InventoryFile"] = inventoryFileTb.Text;

			var json = jObj.ToString(Newtonsoft.Json.Formatting.Indented);
			File.WriteAllText("appsettings.json", json);
		}

		private async void inventoryAddTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, addToInventory, new RunSettings(false, inventoryAddTb));
		private async void inventoryAddLBtn_Click(object sender, EventArgs e) => await RunFullAsync(addToInventory, new RunSettings(false, inventoryAddTb));
		private void addToInventory()
		{
			var success = getInventory().TryAddToInventory(inventoryAddTb.Text, out var inventoryEntries);
			_addToInventory("inventory", success, inventoryEntries);
			inventoryOutWriteLine("");
		}

		private async void inventoryRemoveTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, removeFromInventory, new RunSettings(false, inventoryRemoveTb));
		private async void inventoryRemoveBtn_Click(object sender, EventArgs e) => await RunFullAsync(removeFromInventory, new RunSettings(false, inventoryRemoveTb));
		private void removeFromInventory()
		{
			var success = getInventory().TryRemoveFromInventory(this.inventoryRemoveTb.Text, out var inventoryEntries);
			_removeFromInventory("inventory", this.inventoryRemoveTb.Text, success, inventoryEntries);
			inventoryOutWriteLine("");
		}

		private async void inventorySearchTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, searchInventory, new RunSettings(false, inventorySearchTb));
		private async void inventorySearchBtn_Click(object sender, EventArgs e) => await RunFullAsync(searchInventory, new RunSettings(false, inventorySearchTb));
		private void searchInventory()
		{
			var listType = "inventory";

			var success = getInventory().SearchInventory(this.inventorySearchTb.Text, out var inventoryEntries);
			if (!success)
				inventoryOutWriteLine($"{this.inventorySearchTb.Text} not in {listType}");
			else
				foreach (var (color, qty) in inventoryEntries)
					inventoryOutWriteLine($"{color}: {qty}");
			inventoryOutWriteLine("");
		}

		private async void shoppingListAddTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, addToShoppingList, new RunSettings(false, shoppingListAddTb));
		private async void shoppingListAddBtn_Click(object sender, EventArgs e) => await RunFullAsync(addToShoppingList, new RunSettings(false, shoppingListAddTb));
		private void addToShoppingList()
		{
			var success = getInventory().TryAddToShoppingList(shoppingListAddTb.Text, out var inventoryEntries);
			_addToInventory("shopping list", success, inventoryEntries);
			inventoryOutWriteLine("");
		}

		private async void shoppingListRemoveTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, removeFromShoppingList, new RunSettings(false, shoppingListRemoveTb));
		private async void shoppingListRemoveBtn_Click(object sender, EventArgs e) => await RunFullAsync(removeFromShoppingList, new RunSettings(false, shoppingListRemoveTb));
		private void removeFromShoppingList()
		{
			var success = getInventory().TryRemoveFromShoppingList(this.shoppingListRemoveTb.Text, out var inventoryEntries);
			_removeFromInventory("shopping list", this.inventoryRemoveTb.Text, success, inventoryEntries);
			inventoryOutWriteLine("");
		}

		private void _addToInventory(string listType, bool success, List<(DmcColorName color, int qty, bool isWarned)> inventoryEntries)
		{
			if (!success)
			{
				inventoryOutWriteLine("ERROR: not a valid color\r\n");
				return;
			}

			inventoryOutWriteLine("Added. New qty:");
			foreach (var (color, qty, isWarned) in inventoryEntries)
			{
				if (isWarned)
					inventoryOutWriteLine($"Warning: {color} is not a recognized DMC color but was still added to the {listType}");
				inventoryOutWriteLine($"{color} : {qty}");
			}
		}

		private void _removeFromInventory(string listType, string orig, bool success, List<(DmcColorName color, int qty, bool wasPresent)> inventoryEntries)
		{
			if (!success)
			{
				// invalid color
				if (!inventoryEntries.Any())
				{
					inventoryOutWriteLine($"{orig} not in {listType}");
					return;
				}
				foreach (var (color, qty, wasPresent) in inventoryEntries)
				{
					// actual color
					if (!wasPresent)
						inventoryOutWriteLine($"{color} not in {listType}");
					// variant
					else
						inventoryOutWriteLine($"Variant '{color}' is still in {listType}. Qty: {qty}");
				}
				return;
			}

			// else: color was present
			var found = inventoryEntries.Single();
			inventoryOutWriteLine($"{found.color} removed. New qty: {found.qty}");
		}

		private Inventory getInventory() => new Inventory(this.inventoryFileTb.Text);

		private void inventoryOutWriteLine(string str)
			=> inventoryOutTb.UIThread(() => inventoryOutTb.AppendText($"{str}\r\n"));

		private void openBtn_Click(object sender, EventArgs e)
		{
			try
			{
				new System.Diagnostics.Process
				{
					StartInfo = new System.Diagnostics.ProcessStartInfo(inventoryFileTb.Text.Trim())
					{
						UseShellExecute = true
					}
				}
				.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		#endregion tab: Inventory

		record RunSettings(bool ShowCompletedDialog, Control Focus);
		private static RunSettings DefaultRunSettings { get; } = new RunSettings(true, null);

		#region run tool async
		private Task TextBoxEnterKeyAsync(KeyPressEventArgs e, Action action) => TextBoxEnterKeyAsync(e, action, DefaultRunSettings);
		private async Task TextBoxEnterKeyAsync(KeyPressEventArgs e, Action action, RunSettings settings)
		{
			if (e.KeyChar == (char)Keys.Return)
			{
				// silence the 'ding'
				e.Handled = true;

				await RunFullAsync(action, settings);
			}
		}

		private Task RunFullAsync(Action action) => RunFullAsync(action, DefaultRunSettings);
		private async Task RunFullAsync(Action action, RunSettings settings)
		{
			var ex = await RunAsync(action, settings);

			if (ex is not null)
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else if (settings.ShowCompletedDialog)
				MessageBox.Show("Successfully completed");
		}

		private Task<Exception> RunAsync(Action action) => RunAsync(action, DefaultRunSettings);
		private async Task<Exception> RunAsync(Action action, RunSettings settings)
		{
			try
			{
				disableUI();

				await Task.Run(action);

				return null;
			}
			catch (Exception e)
			{
				return e;
			}
			finally
			{
				GC.Collect();
				GC.WaitForPendingFinalizers();

				enableUI();

				settings?.Focus?.UIThread(() => {
					var control = settings.Focus;
					if (control is TextBoxBase tb)
						tb.SelectAll();
					control.Focus();
				});
			}
		}

		private void disableUI() => setEnable(false);
		private void enableUI() => setEnable(true);
		private void setEnable(bool enable)
		{
			// set enable for each control in form, not on Form/"this" (which would freezes the form itself in place)
			foreach (var c in this.Controls.Cast<Control>())
				setEnableRecurs(c, enable);
		}
		private static void setEnableRecurs(Control control, bool enable)
		{
			foreach (var c in control.Controls.Cast<Control>())
				setEnableRecurs(c, enable);

			control.Enabled = enable;
		}
		#endregion
	}
}
