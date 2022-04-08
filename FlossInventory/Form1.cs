using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dinah.Core.Threading;
using XstitchXcelLib;
using XstitchXcelLib.Config;
using XstitchXcelLib.DataClasses;
using XstitchXcelLib.Tools;
using XstitchXcelWinFormsLib;

namespace FlossInventory
{
	public partial class Form1 : XstitchXcelWinForm
	{
		private static string InventoryFilePath
		{
			get
			{
				var contents = File.ReadAllText("appsettings.json");
				var jObj = Newtonsoft.Json.Linq.JObject.Parse(contents);
				var inventoryFilePath = jObj.Value<string>("InventoryFile");
				return inventoryFilePath;
			}
		}

		public Form1()
		{
			InitializeComponent();

			// load file name into form
			inventoryFileTb.Text = InventoryFilePath;

			// start cursor in 'inventory add' textbox
			this.inventoryAddTb.Select();
		}

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

		#region Inventory

		private void inventoryFileTb_TextChanged(object sender, EventArgs e)
			=> inventoryFileSaveBtn.Enabled = inventoryFileTb.Text != InventoryFilePath;

		private async void inventoryAddTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, addToInventory, inventoryAddTb);
		private async void inventoryAddBtn_Click(object sender, EventArgs e) => await RunAsync(addToInventory, inventoryAddTb);
		private void addToInventory()
		{
			var success = getInventory().TryAddToInventory(inventoryAddTb.Text, out var inventoryEntries);
			_addToInventory("inventory", success, inventoryEntries);
			inventoryOutWriteLine("");
		}

		private async void inventoryRemoveTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, removeFromInventory, inventoryRemoveTb);
		private async void inventoryRemoveBtn_Click(object sender, EventArgs e) => await RunAsync(removeFromInventory, inventoryRemoveTb);
		private void removeFromInventory()
		{
			var success = getInventory().TryRemoveFromInventory(this.inventoryRemoveTb.Text, out var inventoryEntries);
			_removeFromInventory("inventory", this.inventoryRemoveTb.Text, success, inventoryEntries);
			inventoryOutWriteLine("");
		}

		private async void inventorySearchTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, searchInventory, inventorySearchTb);
		private async void inventorySearchBtn_Click(object sender, EventArgs e) => await RunAsync(searchInventory, inventorySearchTb);
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

		#endregion

		#region Shopping List

		private async void shoppingListAddTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, addToShoppingList, shoppingListAddTb);
		private async void shoppingListAddBtn_Click(object sender, EventArgs e) => await RunAsync(addToShoppingList, shoppingListAddTb);
		private void addToShoppingList()
		{
			var success = getInventory().TryAddToShoppingList(shoppingListAddTb.Text, out var inventoryEntries);
			_addToInventory("shopping list", success, inventoryEntries);
			inventoryOutWriteLine("");
		}

		private async void shoppingListRemoveTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, removeFromShoppingList, shoppingListRemoveTb);
		private async void shoppingListRemoveBtn_Click(object sender, EventArgs e) => await RunAsync(removeFromShoppingList, shoppingListRemoveTb);
		private void removeFromShoppingList()
		{
			var success = getInventory().TryRemoveFromShoppingList(this.shoppingListRemoveTb.Text, out var inventoryEntries);
			_removeFromInventory("shopping list", this.inventoryRemoveTb.Text, success, inventoryEntries);
			inventoryOutWriteLine("");
		}

		#endregion

		// convenience method to avoid using 'this.' in this class
		private Task RunAsync(Action action, Control focusControl) => RunnerExtensions.RunAsync(this, action, focusControl);
		private Task TextBoxEnterKeyAsync(KeyPressEventArgs e, Action action, Control focusControl = null) => RunnerExtensions.TextBoxEnterKeyAsync(this, e, action, focusControl);

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
			=> inventoryOutTb.UIThreadSync(() => inventoryOutTb.AppendText($"{str}\r\n"));
	}
}
