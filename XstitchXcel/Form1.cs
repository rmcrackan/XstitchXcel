using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XstitchXcelLib;
using XstitchXcelLib.Config;
using XstitchXcelLib.DataClasses;
using XstitchXcelLib.Tools;

namespace XstitchXcel
{
	public partial class Form1 : Form
	{
		private DmcColorProcessor dmcColorProcessor { get; } = new DmcColorProcessor();

		public Form1() => InitializeComponent();

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
		private async void generateStatsBtn_Click(object sender, EventArgs e)
		{
			Pattern pattern = null;
			var ex = await RunAsync(() => pattern = getPattern());
			if (ex is not null)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var reporter = new StatsReporter(pattern);
			var results = reporter.StitchStatsReport();

			statsDgv.Rows.Clear();
			foreach (var x in results)
			{
				var row = new DataGridViewRow();
				row.Cells.Add(new DataGridViewTextBoxCell { Value = $"{x.Count}" });
				row.Cells.Add(new DataGridViewTextBoxCell { Value = $"{x.MinSkeins:F2}" });
				row.Cells.Add(new DataGridViewTextBoxCell { Value = $"{x.MaxSkeins:F2}" });

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

		#region run tool async
		private async Task TextBoxEnterKeyAsync(KeyPressEventArgs e, Action action)
		{
			if (e.KeyChar == (char)Keys.Return)
			{
				// silence the 'ding'
				e.Handled = true;

				await RunFullAsync(action);
			}
		}
		private async Task RunFullAsync(Action action)
		{
			var ex = await RunAsync(action);

			if (ex is null)
				MessageBox.Show("Successfully completed");
			else
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		private async Task<Exception> RunAsync(Action action)
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
