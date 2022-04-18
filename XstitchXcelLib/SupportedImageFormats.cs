using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XstitchXcelLib
{
    public static class SupportedImageFormats
    {
        public const string DefaultExtension = "png";
        public static List<string> Extensions { get; } = new()
        {
            "bmp",
            "jpg",
            "gif",
            DefaultExtension
        };

        public static string GetDelimited()
            => Extensions
            .Select(a => $"*.{a}")
            .Aggregate((a, b) => $"{a};{b}");
    }
}
