using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class MainWindow : Window
    {
        private const string _imageFolder = "/Images/";
        private const string _imageExtension = ".jpg";
        private const string _iconExtension = ".png";

        public List<CharacterClass> Classes { get; set; }
        public string SelectedClassImage { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            InitializeClasses();
            this.DataContext = this;
            LstClasses.SelectedIndex = 0;
               
        }

        private void InitializeClasses()
        {
            Classes = new List<CharacterClass>
            {
                new CharacterClass("Barbare",_imageFolder, _iconExtension),
                new CharacterClass("Barde",_imageFolder, _iconExtension),
                new CharacterClass("Druide",_imageFolder, _iconExtension),
                new CharacterClass("Ensorceleur",_imageFolder, _iconExtension),
                new CharacterClass("Guerrier",_imageFolder, _iconExtension),
                new CharacterClass("Magicien",_imageFolder, _iconExtension),
                new CharacterClass("Moine",_imageFolder, _iconExtension),
                new CharacterClass("Paladin",_imageFolder, _iconExtension),
                new CharacterClass("Pretre",_imageFolder, _iconExtension),
                new CharacterClass("Rodeur",_imageFolder, _iconExtension),
                new CharacterClass("Roublard",_imageFolder, _iconExtension)
            };

            LstClasses.ItemsSource = Classes;
        }

        private void LstClasses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedClassImage = _imageFolder + LstClasses.SelectedItem.ToString() + _imageExtension;
            ImgClass.Source = new BitmapImage(new Uri(SelectedClassImage, UriKind.Relative));

            string className = LstClasses.SelectedItem.ToString();
            string resourceName = className + "Background";

            App.Current.Resources["SelectedClassBackground"] = App.Current.Resources[resourceName];
        }

    }
}
