using System;
using System.Drawing;

namespace XstitchXcelLib.DataClasses
{
    public record DmcColor
    {
        private string _dmcNumber;
        public string DmcNumber
        {
            get => _dmcNumber;
            init
            {
                // 01-09 have one leading 0
                if (int.TryParse(value, out var i))
                    value = i.ToString().PadLeft(2, '0');
                _dmcNumber = value;
            }
        }
        public string Name { get; init; }
        public Color Color { get; init; }

        /// <summary>
        /// Replacement colors are listed by priority. Earlier announcments are at the end of the list; newer updated announcements are at the beginning.
        /// </summary>
        public List<string> Replacements { get; set; } = new();
        public bool Discontinued => Replacements is not null && Replacements.Any();

        public override string ToString() => $"{(Discontinued ? "[Discontinued] " : "")}{Name}, {DmcNumber}, #{Color.ToHex()}";
    }
}
