using System.ComponentModel;
using XstitchXcelLib;
using XstitchXcelLib.Tools;

namespace ExCell_Art
{
    public partial class MainForm : Form
    {
        private ImageToExcel artMaker;

        private string imagePath;
        private string outputPath;

        public MainForm() => InitializeComponent();

        private void imageBtn_Click(object sender, EventArgs e)
        {
            var types = SupportedImageFormats.GetDelimited();

            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Title = "ExCell Art generator",
                FileName = "",
                Filter = $"Image Files({types})|{types}",
                CheckFileExists = true,
                CheckPathExists = true
            };
            openFileDialog.FileOk += (_, __) => InputName.Text = imagePath = openFileDialog.FileName;
            openFileDialog.ShowDialog();
        }

        private void outputBtn_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                CheckPathExists = true,
                Filter = "Excel (*.xlsx)|*.xlsx",
                DefaultExt = ".xlsx",
                AddExtension = true
            };
            saveFileDialog.FileOk += (_, __) => OutputPathLabel.Text = outputPath = saveFileDialog.FileName;
            saveFileDialog.ShowDialog();
        }

        private async void startBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
            {
                MessageBox.Show("Please choose a valid input image");
                return;
            }

            if (string.IsNullOrWhiteSpace(outputPath))
            {
                MessageBox.Show("Please choose a valid output path");
                return;
            }

            start();

            // must create before 1st await
            var progress = new Progress<int>(percent => progressChanged(percent));
            cancellationTokenSource = new CancellationTokenSource();
            artMaker = new ImageToExcel(imagePath, outputPath);
            await Task.Run(() => artMaker.Start(progress, cancellationTokenSource.Token));
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e) => progressChanged(e.ProgressPercentage);
        private void progressChanged(int progress)
        {
            progressBar.Value = Math.Min(progress, 100);

            if (progress == ImageToExcel.Complete)
                stop("Finished!");
        }

        CancellationTokenSource cancellationTokenSource;
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
            stop("Cancelled!");
        }

        private void start() => setControls(true);

        private void stop(string dialogMessage)
        {
            MessageBox.Show(dialogMessage);

            setControls(false);

            progressBar.Value = 0;
        }

        private void setControls(bool isRunning)
        {
            cancelBtn.Enabled = isRunning;
            startBtn.Enabled = !isRunning;
        }
    }
}