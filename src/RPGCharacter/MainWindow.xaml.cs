using System;
using System.Collections.Generic;
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

        private Character _character;
        public Character Character
        {
            get { return _character; }
            set
            {
                _character = value;
                OnPropertyChanged();
            }
        }
        public List<CharacterClass> Classes { get; set; }

        private CharacterClass _selectedCharacterClass;
        public CharacterClass SelectedCharacterClass
        {
            get { return _selectedCharacterClass; }
            set
            {
                _selectedCharacterClass = value;
                Character.Class = value;
                NewItem = new Item();
                OnPropertyChanged();
            }
        }

        private Item _newItem;
        public Item NewItem
        {
            get { return _newItem; }
            set
            {
                _newItem = value;
                OnPropertyChanged();
            }
        }

        public string SelectedClassImage { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            InitializeClasses();
            this.DataContext = this;
            Character = new Character();
            SelectedCharacterClass = Classes.FirstOrDefault();
        }

        private void InitializeClasses()
        {
            Classes = new List<CharacterClass>
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
                new CharacterClass("Roublard",_imageFolder, _imageExtension, _iconExtension)
            };

            LstClasses.ItemsSource = Classes;
        }

        private void LstClasses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string className = LstClasses.SelectedItem.ToString();
            string resourceName = SelectedCharacterClass.Label + "Background";

            App.Current.Resources["SelectedClassBackground"] = App.Current.Resources[resourceName];
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            bool result = Character.AddItem(NewItem);

            if(!result)
            {
                //Permet d'afficher un message dans une pop-up
                MessageBox.Show("Votre héros ne plus pas porter plus.", //Le contenu du message
                                "Poids maximum atteint !", //Le titre de la pop-up
                                MessageBoxButton.OK,  //Le type de bouton à afficher. Ici, un simple bouton OK, mais d'autres options sont possibles
                                MessageBoxImage.Error); //Le type d'icone à afficher (Icone d'erreur, d'information, warning, ...)
            }
            else
            {
                NewItem = new Item(); //Réinitialisation de l'objet pour créer une nouvelle instance et vider le formulaire. Ceci évite aussi de modifier l'item stocké dans le DataGrid
            }
            
        }
    }
}
