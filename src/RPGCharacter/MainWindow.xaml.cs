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

namespace RPGCharacter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _imageFolder = "/Images/";
        private string _imageExtension = ".jpg";

        public List<string> Classes { get; set; }
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
            Classes = new List<string>
            {
                "Barbare",
                "Barde",
                "Druide",
                "Ensorceleur",
                "Guerrier",
                "Magicien",
                "Moine",
                "Paladin",
                "Pretre",
                "Rodeur",
                "Roublard"
            };

            LstClasses.ItemsSource = Classes;
        }

        private void LstClasses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedClassImage = _imageFolder + LstClasses.SelectedItem.ToString() + _imageExtension;
            ImgClass.Source = new BitmapImage(new Uri(SelectedClassImage, UriKind.Relative));
            
        }

    }
}
