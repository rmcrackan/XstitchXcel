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
using XstitchXcelWinFormsLib;

namespace XstitchXcel
{
    public partial class Form1 : XstitchXcelWinForm, IMasterForm
    {
        public event EventHandler NewExcelFileSelected
        {
            add => this.fileNameTb.TextChanged += value;
            remove => this.fileNameTb.TextChanged -= value;
        }
        public string FileName => fileNameTb.Text;
        public Pattern GetPattern() => Configuration.GetPattern(fileNameTb.Text);

        private DmcColorProcessor dmcColorProcessor { get; } = new DmcColorProcessor();

        public Form1()
        {
            InitializeComponent();

            initToPngTab();
        }

        private static void openFile(string title, TextBox textBox, string filetype, string fileExtension)
        {
            var dialog = new OpenFileDialog
            {
                Title = title,

                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = fileExtension,
                FileName = textBox.Text,
                Filter = $"{filetype} (*.{fileExtension})|*.{fileExtension}|All files (*.*)|*.*",
                FilterIndex = 0,
                Multiselect = false
            };
            dialog.FileOk += (_, __) => textBox.Text = dialog.FileName;
            dialog.ShowDialog();
        }

        private static void saveFile(string title, TextBox textBox, string filetype, string fileExtension)
        {
            var dialog = new SaveFileDialog
            {
                Title = $"Save {title}",

                AddExtension = true,
                DefaultExt = fileExtension,
                FileName = textBox.Text,
                Filter = $"{filetype} (*.{fileExtension})|*.{fileExtension}|All files (*.*)|*.*",
                FilterIndex = 0,
                OverwritePrompt = true
            };
            dialog.FileOk += (_, __) => textBox.Text = dialog.FileName;
            dialog.ShowDialog();
        }

        #region main form
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var tc in GetChildrenToolControls())
                tc.RegisterMasterForm(this);
        }

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
            toPngNewFileSelected();
            crtNewFileSelected();
        }

        private void fileNameBtn_Click(object sender, EventArgs e) => openFile("Select the Excel file with your design", fileNameTb, "Excel Spreadsheet", "xlsx");
        #endregion

        // convenience methods to avoid using 'this.' in this class
        // might be unneeded after refactor
        private Task RunAsync(Action action) => RunnerExtensions.RunAsync(this, action);
        private Task TextBoxEnterKeyAsync(KeyPressEventArgs e, Action action, Control focusControl = null) => RunnerExtensions.TextBoxEnterKeyAsync(this, e, action, focusControl);

        #region tab: Find DMC Colors
        private async void findDmcColorsBtn_Click(object sender, EventArgs e) => await RunAsync(() => new PatternAnalyzer(GetPattern()).ReportNonDmc());
        #endregion

        #region tab: Replace Color
        private void oldColorTb_TextChanged(object sender, EventArgs e) => setDmcPictureBox(oldColorTb, oldColorPb, oldIsDmcLbl);
        private void newColorTb_TextChanged(object sender, EventArgs e) => setDmcPictureBox(newColorTb, newColorPb, newIsDmcLbl);

        private async void oldColorTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, replaceColor);
        private async void newColorTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, replaceColor);
        private async void beginColorReplaceBtn_Click(object sender, EventArgs e) => await RunAsync(replaceColor);
        private void replaceColor()
            => new ColorReplacer(GetPattern())
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
        private async void beginColorReplaceNaiveBtn_Click(object sender, EventArgs e) => await RunAsync(replaceNaiveColor);
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
        private async void batchConvertStart_Click(object sender, EventArgs e) => await RunAsync(batchConvert);
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

        private void toPngOutputBtn_Click(object sender, EventArgs e) => saveFile("generated png image file", toPngOutputTb, "PNG", "png");

        private void enableScaleUpDown(object sender, EventArgs e) => toPngNud.Enabled = toPngScaleRb.Checked;

        private async void toPngOutputTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, createPng);
        private async void createPngBtn_Click(object sender, EventArgs e) => await RunAsync(createPng);
        private void createPng()
        {
            var pattern = GetPattern();

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

        private void crtBlurOutputBtn_Click(object sender, EventArgs e) => saveFile("generated CRT Blur file", crtBlurOutputTb, "Excel Spreadsheet", "xlsx");

        private async void crtBlurOutputTb_KeyPress(object sender, KeyPressEventArgs e) => await TextBoxEnterKeyAsync(e, createCrtBlur);
        private async void createCrtBlurBtn_Click(object sender, EventArgs e) => await RunAsync(createCrtBlur);
        private void createCrtBlur()
        {
            var pattern = GetPattern();

            var crtBlurer = new CrtBlurer(pattern)
            {
                OutputFile = crtBlurOutputTb.Text
            };

            crtBlurer.SaveToFile();
        }
        #endregion
    }
}
