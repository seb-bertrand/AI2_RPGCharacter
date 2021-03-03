using System;
using System.Collections.Generic;
using System.Text;

namespace RPGCharacter.Models
{
    public class CharacterClass
    {
        public CharacterClass(string label, string imageFolderPath, string imageExtension, string iconExtension)
        {
            Label = label;
            ClassIcon = imageFolderPath + label + "_Icon" + iconExtension;
            ClassImage = imageFolderPath + label + imageExtension;
        }

        public string Label { get; set; }
        public string ClassIcon { get; set; }
        public string ClassImage { get; set; }

        public override string ToString()
        {
            return Label;
        }
    }
}
