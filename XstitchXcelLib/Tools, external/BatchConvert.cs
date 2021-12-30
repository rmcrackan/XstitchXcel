using XstitchXcelLib.Config;

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
            await Task.Run(() => xlsx2Pattern(xlsx));
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
            new ArtMaker(img, xlsx).StartSync();
            return xlsx;
        }

        private void xlsx2Pattern(string xlsx)
        {
            // back up the original
            var newFile = HelperMethods.AddFileSuffix(xlsx, " - original");
            File.Copy(xlsx, Path.Combine(Path.GetDirectoryName(xlsx), newFile), true);

            var pattern = Configuration.GetPattern(xlsx);
        }
    }
}
