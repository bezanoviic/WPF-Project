using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Garnizon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Garnizoni> garnizoni = new ObservableCollection<Garnizoni>();
        public MainWindow()
        {
            InitializeComponent();
            Garnizoni g1 = new Garnizoni("Avalski Štit", "1", "Mileta Kitica 77", "D:/Faks/OOT/Projekat/Slike/amblem-vojnobezbednosne-agencije.png");
            Jedinica j1 = new Jedinica("1.Pesadija", "Mileta Kitica 77", "");
            g1.Jedinice.Add(j1);
            garnizoni.Add(g1);
            Garnizoni.ItemsSource = garnizoni;
        }

        private void Jedinice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Garnizoni_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Garnizoni g = Garnizoni.SelectedItem as Garnizoni;
            Ikonica1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(g.Ikonica);
        }

        private void GarnizoniRaspored1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void GarnizoniRaspored2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void JediniceRaspored1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void JediniceRaspored1_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void JediniceRaspored1_Drop(object sender, DragEventArgs e)
        {

        }

        private void JediniceRaspored2_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void JediniceRaspored2_Drop(object sender, DragEventArgs e)
        {

        }

        private void JediniceRaspored2_DragEnter(object sender, DragEventArgs e)
        {

        }
    }
}
