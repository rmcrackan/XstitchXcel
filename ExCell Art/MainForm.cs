// heavily adapted from https://github.com/JamesMatchett/ExCell-Art-Generator
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

        private void startBtn_Click(object sender, EventArgs e)
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

            artMaker = new ImageToExcel(imagePath, outputPath);
            artMaker.bw.ProgressChanged += bw_ProgressChanged;
            artMaker.StartAsync();
        }

        // for estimated time to completion counter
        DateTime lastPercentageTime = DateTime.Now;
        decimal lastPercentageValue = 0;
        List<decimal> averageTimeFor1Percent { get; } = new();

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var progress = e.ProgressPercentage;

            // if not initiliased, or percentage has not increased since last execution
            if (lastPercentageValue == 0 || progress == 0 || lastPercentageValue == progress)
            {
                lastPercentageTime = DateTime.Now;
                lastPercentageValue = progress;
            }
            else
            {
                var secondsRemaining = calcSecondsRemaining(progress);

                if (secondsRemaining > 0)
                {
                    updateTimeRemaining(secondsRemaining);
                    lastPercentageTime = DateTime.Now;
                    lastPercentageValue = progress;
                }
            }

            updateProgressBar(progress);
        }

        private void updateProgressBar(int progress)
        {
            var percentage = Convert.ToInt32(progress);

            progressBar.Value = Math.Min(percentage, 100);

            // 101 signifies finished, stop multithread sending multiple "finished" signal
            if (percentage == ImageToExcel.Complete)
            {
                updateTimeRemaining(0);
                stop("Finished!");
            }
        }

        private decimal calcSecondsRemaining(int progress)
        {
            var percentageDifference = progress - lastPercentageValue;
            var timeDifference = DateTime.Now - lastPercentageTime;

            //time for 1% = (1/percentageDifference * Time Difference)
            var timeFor1Percent = (1 / percentageDifference) * Convert.ToDecimal(timeDifference.TotalSeconds);
            averageTimeFor1Percent.Add(timeFor1Percent);

            if (averageTimeFor1Percent.Count > 5)
                averageTimeFor1Percent.Remove(averageTimeFor1Percent.First());

            //now multiply time for 1% by the percentage remianing e.g. 45% done would be 55% percent to go
            var SecondsRemaining = averageTimeFor1Percent.Average() * (100 - progress);
            return Math.Floor(SecondsRemaining);
        }

        private void updateTimeRemaining(decimal secondsRemaining) => TimeRemainingLabel.Text = ($"Time Remaining: {secondsRemaining} seconds");

        private void cancelBtn_Click(object sender, EventArgs e) => stop("Cancelled!");

        private void stop(string dialogMessage)
        {
            artMaker.StopAsync();

            MessageBox.Show(dialogMessage);

            setControls(false);

            progressBar.Value = 0;
        }

        private void start() => setControls(true);

        private void setControls(bool isRunning)
        {
            cancelBtn.Enabled = isRunning;
            startBtn.Enabled = !isRunning;
        }
    }
}