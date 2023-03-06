using System;
using System.Drawing;

namespace XstitchXcelLib.DataClasses
{
    public record DmcColor
    {
        public string DmcNumber { get; init; }
        public string Name { get; init; }
        public Color Color { get; init; }

        public List<string> Replacements { get; set; } = new();
        public bool Discontinued => Replacements is null || !Replacements.Any();

        public override string ToString() => $"{(Discontinued ? "[Discontinued] " : "")}{Name}, {DmcNumber}, #{Color.ToHex()}";
    }
}
