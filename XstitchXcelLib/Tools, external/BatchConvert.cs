using XstitchXcelLib.Config;
using XstitchXcelLib.DataClasses;

namespace XstitchXcelLib.Tools
{
    public class BatchConvert
    {
        private string sourceDir { get; }
        private string destDir { get; }

        public BatchConvert(string sourceDir, string destDir)
        {
            this.sourceDir = sourceDir;
            this.destDir = destDir;
        }

        public void Start()
        {
            var extensions = SupportedImageFormats.Extensions.Select(a => $"*.{a}");
            var imgs = HelperMethods.GetFiles(sourceDir, extensions).ToList();

            var tasks = new List<Task>();
            foreach (var p in imgs)
                tasks.Add(Task.Run(() => processOne(p)));
            Task.WaitAll(tasks.ToArray());
        }

        private async Task processOne(string source)
        {
            var img = await Task.Run(() => copyImage(source));
            var xlsx = await Task.Run(() => image2Xlsx(img));
            var pattern = await Task.Run(() => xlsx2Pattern(xlsx));
            await Task.Run(() => matchToDmcColors(pattern));
            await Task.Run(() => createPattern(pattern));
            await Task.Run(() => cleanUpFiles(pattern));
        }

        private string copyImage(string source)
        {
            var dest = Path.Combine(destDir, Path.GetFileName(source));
            File.Copy(source, dest, true);
            return dest;
        }

        private string image2Xlsx(string img)
        {
            var xlsx = Path.Combine(destDir, Path.GetFileNameWithoutExtension(img) + ".xlsx");
            new ImageToExcel(img, xlsx).Start();
            return xlsx;
        }

        private Pattern xlsx2Pattern(string xlsx)
        {
            // back up the original
            var newFile = HelperMethods.AddFilePrefix(xlsx, "___original - ");
            File.Copy(xlsx, Path.Combine(Path.GetDirectoryName(xlsx), newFile), true);

            return Configuration.GetPattern(xlsx);
        }

        private DmcColorProcessor DmcColorProcessor { get; } = new();
        private void matchToDmcColors(Pattern pattern)
        {
            var unmatchedColors = new PatternAnalyzer(pattern).NonDmcColors();

            if (!unmatchedColors.Any())
                return;

            var colorReplacer = new ColorReplacer(pattern);

            foreach (var unmatchedColor in unmatchedColors)
            {
                var matchedColor = DmcColorProcessor.GetNearestNaive(unmatchedColor)
                    .First()
                    .Color;
                colorReplacer.TargetedReplace(unmatchedColor, matchedColor);
            }
        }

        private void createPattern(Pattern pattern)
        {
            var outputFile = HelperMethods.AddFilePrefix(pattern.InputFile, "_pattern - ");
            var builder = new PatternBuilder(pattern)
            {
                OutputFile = outputFile,
                // PrintColorsGrid = true
            };
            builder.ConvertToPattern();
        }

        private void cleanUpFiles(Pattern pattern)
        {
            var xlsxSource = pattern.InputFile;
            var xlsxDestination = HelperMethods.AddFilePrefix(xlsxSource, "__dmc - ");
            File.Move(xlsxSource, xlsxDestination);

            var jsonSource = Path.ChangeExtension(xlsxSource, ".json");
            File.Delete(jsonSource);
        }
    }
}
