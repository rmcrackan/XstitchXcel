using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dinah.Core;
using Dinah.Core.Threading;
using XstitchXcelLib.Tools;
using XstitchXcelWinFormsLib;

namespace FlossInventory
{
	public partial class Form1 : Form
	{
        #region appsettings.json
        private const string APPSETTINGS_JSON = "appsettings.json";
        private const string INVENTORY_FILE = "InventoryFile";

        private static string GetInventoryFilePath()
        {
            var contents = File.ReadAllText(APPSETTINGS_JSON);
            var jObj = Newtonsoft.Json.Linq.JObject.Parse(contents);
            var inventoryFilePath = jObj.Value<string>(INVENTORY_FILE);
            return inventoryFilePath;
        }
        private static void SetInventoryFilePath(string value)
        {
            var contents = File.ReadAllText(APPSETTINGS_JSON);
            var jObj = Newtonsoft.Json.Linq.JObject.Parse(contents);
            jObj[INVENTORY_FILE] = value;

            var json = jObj.ToString(Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(APPSETTINGS_JSON, json);
        }
        #endregion

        private Runner runner { get; }

		// convenience methods
		private Task RunAsync(Action<CancellationToken> action, Control focusControl) => runner.RunAsync(action, focusControl);
		private Task TextBoxEnterKeyAsync(KeyPressEventArgs e, Action<CancellationToken> action, Control focusControl = null) => runner.TextBoxEnterKeyAsync(e, action, focusControl);

		public Form1()
		{
			InitializeComponent();
			runner = new(this);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			if (this.DesignMode)
				return;

			// load file name into form
			inventoryFileTb.Text = GetInventoryFilePath();

			// start cursor in 'inventory add' textbox
			this.inventoryAddTb.Select();
		}

		private void inventoryFileBtn_Click(object sender, EventArgs e)
		{
			var dialog = new OpenFileDialog
			{
				Title = "Select the text file with your inventory",

				CheckFileExists = true,
				CheckPathExists = true,
				DefaultExt = "txt",
				FileName = inventoryFileTb.Text,
				Filter = "Text document (*.txt)|*.txt|All files (*.*)|*.*",
				FilterIndex = 0,
				Multiselect = false
			};

			if (dialog.ShowDialog() == DialogResult.OK)
				inventoryFileTb.Text = dialog.FileName;
		}

		private void inventoryFileTb_TextChanged(object sender, EventArgs e) => inventoryFileSaveBtn.Enabled = inventoryFileTb.Text != GetInventoryFilePath();

        private void openBtn_Click(object sender, EventArgs e)
		{
			try
			{
				new System.Diagnostics.Process
				{
                    StartInfo = new(inventoryFileTb.Text.Trim())
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

		private void inventoryFileSaveBtn_Click(object sender, EventArgs e) => SetInventoryFilePath(inventoryFileTb.Text);

		#region Inventory

		private async void inventoryAddTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, addToInventory, inventoryAddTb);
		private async void inventoryAddBtn_Click(object sender, EventArgs e) => await RunAsync(addToInventory, inventoryAddTb);
		private void addToInventory(CancellationToken cancellationToken) => _addToInventory(inventoryAddTb.Text, Section.Inventory);

        private async void inventoryRemoveTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, removeFromInventory, inventoryRemoveTb);
		private async void inventoryRemoveBtn_Click(object sender, EventArgs e) => await RunAsync(removeFromInventory, inventoryRemoveTb);
		private void removeFromInventory(CancellationToken cancellationToken) => _removeFromInventory(this.inventoryRemoveTb.Text, Section.Inventory);

        private async void inventorySearchTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, searchInventory, inventorySearchTb);
		private async void inventorySearchBtn_Click(object sender, EventArgs e) => await RunAsync(searchInventory, inventorySearchTb);
		private void searchInventory(CancellationToken cancellationToken) => _searchInventory(this.inventorySearchTb.Text, Section.Inventory);

        #endregion

        #region Bulk Inventory
        private async void bulkInventoryAddBtn_Click(object sender, EventArgs e) => await RunAsync(bulkAddToInventory, bulkInventoryAddTb);
        private void bulkAddToInventory(CancellationToken cancellationToken)
        {
            var values = bulkInventoryAddTb.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
			foreach (var value in values)
				_addToInventory(value, Section.Inventory);
        }
        #endregion

        #region Shopping List

        private async void shoppingListAddTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, addToShoppingList, shoppingListAddTb);
		private async void shoppingListAddBtn_Click(object sender, EventArgs e) => await RunAsync(addToShoppingList, shoppingListAddTb);
		private void addToShoppingList(CancellationToken cancellationToken) => _addToInventory(shoppingListAddTb.Text, Section.ShoppingList);

        private async void shoppingListRemoveTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, removeFromShoppingList, shoppingListRemoveTb);
		private async void shoppingListRemoveBtn_Click(object sender, EventArgs e) => await RunAsync(removeFromShoppingList, shoppingListRemoveTb);
		private void removeFromShoppingList(CancellationToken cancellationToken) => _removeFromInventory(this.shoppingListRemoveTb.Text, Section.ShoppingList);

        #endregion

        #region Output
        private void inventoryOutBtn_Click(object sender, EventArgs e) => inventoryOutTb.Clear();
        #endregion

        private void _addToInventory(string value, Section section)
		{
			var listType = section.GetDescription().ToLower();

			var success = getInventory().TryAdd(value, section, out var inventoryEntries);
            if (!success)
            {
                inventoryOutWriteLine("ERROR: not a valid color\r\n\r\n");
                return;
            }

            inventoryOutWriteLine("Added. New qty:");
            foreach (var (color, qty, isWarned) in inventoryEntries)
            {
                if (isWarned)
                    inventoryOutWriteLine($"Warning: {color} is not a recognized DMC color but was still added to the {listType}");
                inventoryOutWriteLine($"{color} : {qty}");
            }
            inventoryOutWriteLine();
        }

		private void _removeFromInventory(string orig, Section section)
        {
            var listType = section.GetDescription().ToLower();

            var success = getInventory().TryRemove(orig, section, out var inventoryEntries);
			if (success)
            {
                // color was present
                var (color, qty, wasPresent) = inventoryEntries.Single();
                inventoryOutWriteLine($"{color} removed. New qty: {qty}\r\n");
                return;
            }

            // invalid color
            if (!inventoryEntries.Any())
            {
                inventoryOutWriteLine($"{orig} not in {listType}\r\n");
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

            inventoryOutWriteLine();
        }

        private void _searchInventory(string value, Section section)
        {
            var listType = section.GetDescription().ToLower();

            var success = getInventory().Search(value, section, out var inventoryEntries);
            if (!success)
                inventoryOutWriteLine($"{value} not in {listType}");
            else
                foreach (var (color, qty) in inventoryEntries)
                    inventoryOutWriteLine($"{color}: {qty}");
            inventoryOutWriteLine();
        }

        private Inventory getInventory() => new(this.inventoryFileTb.Text);

		private void inventoryOutWriteLine(string str = null) => inventoryOutTb.UIThreadSync(() => inventoryOutTb.AppendText($"{str}\r\n"));
    }
}
