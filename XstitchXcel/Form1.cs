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
using XstitchXcelWinFormsLib;

namespace XstitchXcel
{
	public partial class Form1 : XstitchXcelWinForm
	{
		private DmcColorProcessor dmcColorProcessor { get; } = new DmcColorProcessor();

		public Form1()
		{
			InitializeComponent();

			initStatsTab();
			initToPngTab();
		}

		#region main form
		private void Form1_DragEnter(object sender, DragEventArgs e)
		{
			if (!ChildrenEnabled)
				return;

			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
		}

		private void Form1_DragDrop(object sender, DragEventArgs e)
		{
			if (!ChildrenEnabled)
				return;

			var files = (string[])e.Data.GetData(DataFormats.FileDrop);

			var xlsx = files.FirstOrDefault(f => Path.GetExtension(f).Trim('.') == "xlsx");
			if (xlsx is not null)
				fileNameTb.Text = xlsx;
		}

		private void fileNameTb_TextChanged(object sender, EventArgs e)
		{
			patternNewFileSelected();
			toPngNewFileSelected();
			crtNewFileSelected();
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
		private void patternNewFileSelected()
		{
			var output = HelperMethods.GetUniqueFileName(HelperMethods.AddFileSuffix(fileNameTb.Text, " - output"));

			patternOutputTb.Text = output;
		}

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
				PrintGlyphsGrid = glyphsCb.Checked,
				PrintColorsAndGlyphsGrid = colorsAndGlyphsCb.Checked,
			};

			builder.ConvertToPattern();
		}
		#endregion

		#region tab: Stats
		private void initStatsTab()
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

			var sprite = statsPattern.Sprite;
			var heightInInches = sprite.Size.Height / ct;
			var widthInInches = sprite.Size.Width / ct;
			var unit = ((string)statsUnitCb.SelectedItem).ToLower().Trim();

			var tuple = unit switch
			{
				"inches" => (1, "inches"),
				"cm" => (2.54, "cm"),
				_ => throw new Exception()
			};
			(var multiplier, var abbrev) = tuple;

			statsOutTb.Text = $"{sprite.Pixels.Count:n0} stitches  {heightInInches * multiplier:F2}h x {widthInInches * multiplier:F2}w {abbrev}";
		}
		#endregion

		#region tab: Find DMC Colors
		private async void findDmcColorsBtn_Click(object sender, EventArgs e) => await RunFullAsync(() => new PatternAnalyzer(getPattern()).ReportNonDmc());
		#endregion

		#region tab: Replace Color
		private void oldColorTb_TextChanged(object sender, EventArgs e) => setDmcPictureBox(oldColorTb, oldColorPb, oldIsDmcLbl);
		private void newColorTb_TextChanged(object sender, EventArgs e) => setDmcPictureBox(newColorTb, newColorPb, newIsDmcLbl);

		private async void oldColorTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, replaceColor);
		private async void newColorTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, replaceColor);
		private async void beginColorReplaceBtn_Click(object sender, EventArgs e) => await RunFullAsync(replaceColor);
		private void replaceColor()
			=> new ColorReplacer(getPattern())
			{
				CreateBackupFile = replaceColorBakCb.Checked
			}
			.TargetedReplace(oldColorTb.Text, newColorTb.Text);
		#endregion

		#region tab: Replace Color (naive)
		private void oldColorNaiveTb_TextChanged(object sender, EventArgs e) => setDmcPictureBox(oldColorNaiveTb, oldColorNaivePb, oldIsDmcNaiveLbl);
		private void newColorNaiveTb_TextChanged(object sender, EventArgs e) => setDmcPictureBox(newColorNaiveTb, newColorNaivePb, newIsDmcNaiveLbl);

		private async void oldColorNaiveTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, replaceNaiveColor);
		private async void newColorNaiveTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, replaceNaiveColor);
		private async void beginColorReplaceNaiveBtn_Click(object sender, EventArgs e) => await RunFullAsync(replaceNaiveColor);
		private void replaceNaiveColor()
			=> ColorReplacer.NaiveReplace(fileNameTb.Text, oldColorNaiveTb.Text, newColorNaiveTb.Text, replaceColorNaiveBakCb.Checked);
		#endregion

		private void setDmcPictureBox(TextBox tb, PictureBox pb, Label isDmcLbl)
		{
			var color = dmcColorProcessor.SmartColorFinder(tb.Text);

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

		#region tab: Batch Convert
		private void batchConvertSourceBtn_Click(object sender, EventArgs e)
		{
			var dialog = new FolderBrowserDialog { ShowNewFolderButton = true };

			if (dialog.ShowDialog() == DialogResult.OK)
				batchConvertSourceTb.Text = dialog.SelectedPath;
		}
		private void batchConvertDestinationBtn_Click(object sender, EventArgs e)
		{
			var dialog = new FolderBrowserDialog { ShowNewFolderButton = true };

			if (dialog.ShowDialog() == DialogResult.OK)
				batchConvertDestinationTb.Text = dialog.SelectedPath;
		}

		private async void batchConvertSourceTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, batchConvert);
		private async void batchConvertDestinationTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, batchConvert);
		private async void batchConvertStart_Click(object sender, EventArgs e) => await RunFullAsync(batchConvert);
		private void batchConvert()
			=> new BatchConvert(batchConvertSourceTb.Text, batchConvertDestinationTb.Text).Start();
		#endregion

		#region tab: To png
		private void initToPngTab()
		{
			enableScaleUpDown(null, null);
		}

		private void toPngNewFileSelected()
		{
			var newExt = Path.ChangeExtension(fileNameTb.Text, ".png");
			var withSuffix = HelperMethods.AddFileSuffix(newExt, " - output");
			var unique = HelperMethods.GetUniqueFileName(withSuffix);

			toPngOutputTb.Text = unique;
		}

		private void toPngOutputBtn_Click(object sender, EventArgs e)
		{
			var dialog = new SaveFileDialog
			{
				Title = "Save generated png image file",

				AddExtension = true,
				DefaultExt = "png",
				FileName = toPngOutputTb.Text,
				Filter = "PNG (*.png)|*.png|All files (*.*)|*.*",
				FilterIndex = 0,
				OverwritePrompt = true
			};

			if (dialog.ShowDialog() == DialogResult.OK)
				toPngOutputTb.Text = dialog.FileName;

		}

        private void enableScaleUpDown(object sender, EventArgs e) => toPngNud.Enabled = toPngScaleRb.Checked;

        private async void toPngOutputTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, createPng);
		private async void createPngBtn_Click(object sender, EventArgs e) => await RunFullAsync(createPng);
		private void createPng()
		{
			var pattern = getPattern();

			var excelToImage = new ExcelToImage(pattern)
			{
				OutputFile = toPngOutputTb.Text
			};

			if (toPngScaleRb.Checked && toPngNud.Value > 1)
				excelToImage.SaveToPngResize((int)toPngNud.Value);
			else
				excelToImage.SaveToPng();
		}
		#endregion

		#region tab: CRT Blur
		private void crtNewFileSelected()
		{
			var output = HelperMethods.GetUniqueFileName(HelperMethods.AddFileSuffix(fileNameTb.Text, " - output"));

			crtBlurOutputTb.Text = output;
		}

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
    }
}
