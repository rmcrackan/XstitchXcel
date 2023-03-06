using System;

namespace XstitchXcelLib.Config
{
    public class DmcColorEntry
    {
        public string DmcNumber { get; set; }
        public string Name { get; set; }

        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }

        /// <summary>
        /// Replacement colors are listed by priority. Earlier announcments are at the end of the list; newer updated announcements are at the beginning.
        /// </summary>
        public List<string> Replacements { get; set; } = new();
        public bool Discontinued => Replacements is null || !Replacements.Any();

        public override string ToString() => $"{(Discontinued ? "[Discontinued] " : "")}{Name}, {DmcNumber}, #{Red:X2}{Green:X2}{Blue:X2}";
    }
}
