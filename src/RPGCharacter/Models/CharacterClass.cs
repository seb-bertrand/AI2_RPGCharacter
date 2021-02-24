using System;
using System.Collections.Generic;
using System.Text;

namespace RPGCharacter.Models
{
    public class CharacterClass
    {
        public CharacterClass(string label, string iconFolderPath, string imageExtension)
        {
            Label = label;
            ClassIcon = iconFolderPath + label + "_Icon" + imageExtension;
        }

        public string Label { get; set; }
        public string ClassIcon { get; set; }

        public override string ToString()
        {
            return Label;
        }
    }
}
