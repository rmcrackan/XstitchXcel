using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ExCell_Art
{
    public partial class MainForm : Form
    {
        private ArtMaker artMaker;

        private string imagePath;
        private string outputPath;

        public MainForm() => InitializeComponent();

        private void imageBtn_Click(object sender, EventArgs e)
        {
			var openFileDialog = new OpenFileDialog
			{
				InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
				Title = "ExCell Art generator",
				FileName = "",
				Filter = "Image Files(*.BMP; *.JPG; *.GIF; *.PNG;)| *.BMP; *.JPG; *.GIF; *.PNG;",
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
			saveFileDialog.FileOk += (_,__) => OutputPathLabel.Text = outputPath = saveFileDialog.FileName;
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

            artMaker = new ArtMaker(imagePath, outputPath);
            artMaker.bw.ProgressChanged += bw_ProgressChanged;
            artMaker.Start();
        }

		//for estimated time to completion counter
		DateTime lastPercentageTime = DateTime.Now;
        decimal lastPercentageValue = 0;
        List<decimal> averageTimeFor1Percent { get; } = new List<decimal>();

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //if not initiliased, or percentage has not increased since last execution
            if (lastPercentageValue == 0 || e.ProgressPercentage == 0 || lastPercentageValue == e.ProgressPercentage)
            {
                lastPercentageTime = DateTime.Now;
                lastPercentageValue = e.ProgressPercentage;
            }
            else
            {
                var percentageDifference = e.ProgressPercentage - lastPercentageValue;
                var timeDifference = DateTime.Now - lastPercentageTime;

                //time for 1% = (1/percentageDifference * Time Difference)
                var timeFor1Percent = (1 / percentageDifference) * Convert.ToDecimal(timeDifference.TotalSeconds);
                averageTimeFor1Percent.Add(timeFor1Percent);

                if (averageTimeFor1Percent.Count > 5)
                    averageTimeFor1Percent.Remove(averageTimeFor1Percent.First());

                //now multiply time for 1% by the percentage remianing e.g. 45% done would be 55% percent to go
                decimal SecondsRemaining = (averageTimeFor1Percent.Average() * (100 - e.ProgressPercentage));
                SecondsRemaining = Math.Floor(SecondsRemaining);

                if (SecondsRemaining > 0)
                {
                    updateTimeRemaining(SecondsRemaining);
                    lastPercentageTime = DateTime.Now;
                    lastPercentageValue = e.ProgressPercentage;
                }
            }

            int percentage = Convert.ToInt32(e.ProgressPercentage);

            progressBar.Value = Math.Min(percentage, 100);

            // 101 signifies finished, stop multithread sending multiple "finished" signal
            if (percentage == 101)
            {
                updateTimeRemaining(0);
                stop("Finished!");
            }
        }

        private void updateTimeRemaining(decimal secondsRemaining) => TimeRemainingLabel.Text = ($"Time Remaining: {secondsRemaining} seconds");

        private void cancelBtn_Click(object sender, EventArgs e) => stop("Cancelled!");

        private void stop(string dialogMessage)
        {
            artMaker.Stop();

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
