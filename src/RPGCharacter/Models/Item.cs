using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace RPGCharacter.Models
{
    public class Item : INotifyPropertyChanged
    {

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

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private double _weight;
        public double Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                OnPropertyChanged();
            }
        }

        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged();
            }
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
