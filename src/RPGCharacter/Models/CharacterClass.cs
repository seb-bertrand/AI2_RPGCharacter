﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace RPGCharacter.Models
{
    public class CharacterClass : INotifyPropertyChanged
    {
        public CharacterClass(string label, string imageFolderPath, string imageExtension, string iconExtension)
        {
            Label = label;
            ClassIcon = imageFolderPath + label + "_Icon" + iconExtension;
            ClassImage = imageFolderPath + label + imageExtension;
        }

        private string _label;
        public string Label
        {
            get { return _label; }
            set
            {
                _label = value;
                OnPropertyChanged();
            }
        }

        private string _classIcon;
        public string ClassIcon
        {
            get { return _classIcon; }
            set
            {
                _classIcon = value;
                OnPropertyChanged();
            }
        }

        private string _classImage;
        public string ClassImage
        {
            get { return _classImage; }
            set
            {
                _classImage = value;
                OnPropertyChanged();
            }
        }


        public override string ToString()
        {
            return Label;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
