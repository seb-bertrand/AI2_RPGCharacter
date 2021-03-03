using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RPGCharacter.Models;

namespace RPGCharacter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        
        private const string _imageFolder = "/Images/";
        private const string _imageExtension = ".jpg";
        private const string _iconExtension = ".png";

        public event PropertyChangedEventHandler PropertyChanged;

        public Character Character { get; set; }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        

        public ObservableCollection<CharacterClass> Classes { get; set; }
        public string SelectedClassImage { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            InitializeClasses();
            DataContext = this;            
            Character = new Character();
            Character.Class = Classes.First();
            
            
        }

        private void InitializeClasses()
        {
            Classes = new ObservableCollection<CharacterClass>
            {
                new CharacterClass("Barbare",_imageFolder, _imageExtension, _iconExtension),
                new CharacterClass("Barde",_imageFolder, _imageExtension, _iconExtension),
                new CharacterClass("Druide",_imageFolder, _imageExtension, _iconExtension),
                new CharacterClass("Ensorceleur",_imageFolder, _imageExtension, _iconExtension),
                new CharacterClass("Guerrier",_imageFolder, _imageExtension, _iconExtension),
                new CharacterClass("Magicien",_imageFolder, _imageExtension, _iconExtension),
                new CharacterClass("Moine",_imageFolder, _imageExtension, _iconExtension),
                new CharacterClass("Paladin",_imageFolder, _imageExtension, _iconExtension),
                new CharacterClass("Pretre",_imageFolder, _imageExtension, _iconExtension),
                new CharacterClass("Rodeur",_imageFolder, _imageExtension, _iconExtension),
                new CharacterClass("Roublard",_imageFolder, _imageExtension, _iconExtension),
            };
        }

        private void LstClasses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {           
            string className = LstClasses.SelectedItem.ToString();
            string resourceName = className + "Background";
            App.Current.Resources["SelectedClassBackground"] = App.Current.Resources[resourceName];
        }

    }
}
