using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace RPGCharacter.Models
{
    public class Character : INotifyPropertyChanged
    {
        public Character()
        {
            Items = new ObservableCollection<Item>();
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        private double _maxWeight;
        public double MaxWeight
        {
            get { return _maxWeight; }
            set
            {
                _maxWeight = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Item> _items;
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public bool AddItem(Item item)
        {
            var currentWeight = Items.Sum(item => item.Weight);
            if (currentWeight + item.Weight <= MaxWeight)
            {
                Items.Add(item);
                return true;
            }

            return false;
        }

        private CharacterClass _class;
        public CharacterClass Class
        {
            get { return _class; }
            set
            {
                _class = value;
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
