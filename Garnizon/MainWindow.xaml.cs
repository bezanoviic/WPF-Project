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
        private ObservableCollection<ImageSource> Ikonice = new ObservableCollection<ImageSource>();
        private Garnizoni samostalni = new Garnizoni("SAMOSTALNI", 0, "AA", "Images/Samostalna_Vojska.png");
        public MainWindow()
        {
            InitializeComponent();
            Ikonice.Add((ImageSource)new ImageSourceConverter().ConvertFromString("Images/Samostalna_Vojska.png"));
            Ikonice.Add((ImageSource)new ImageSourceConverter().ConvertFromString("Images/Garnizon_1.png"));
            ///Garnizoni samostalni = new Garnizoni("SAMOSTALNI", 0, "AA", "Images/124684_41993003_grb_vojska_srbije.png");
            Garnizoni g1 = new Garnizoni("Avalski Štit", 1, "Mileta Kitica 77", "Images/Garnizon_1.png");
            Garnizoni g2 = new Garnizoni("Stitnici Svetla", 2, "BB", "Images/Garnizon_1.png");
            Jedinica j1 = new Jedinica("1.Pesadija", "Mileta Kitica 77", "");
            ikonicex.ItemsSource = Ikonice;
            g1.Jedinice.Add(j1);
            garnizoni.Add(samostalni);
            garnizoni.Add(g1);
            garnizoni.Add(g2);
            Garnizoni.ItemsSource =
            GarnizoniMapa.ItemsSource =
            GarnizoniRaspored1.ItemsSource =
            GarnizoniRaspored2.ItemsSource = garnizoni;

        }

        private void Jedinice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Garnizoni_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Garnizoni g = Garnizoni.SelectedItem as Garnizoni;
            if (g != null)
            {
                if(g.ID==0)
                {
                    idx.IsEnabled = false;
                    nazivx.IsEnabled = false;
                    obrisix.IsEnabled = false;
                }
                else
                {
                    idx.IsEnabled = true;
                    nazivx.IsEnabled = true;
                    obrisix.IsEnabled = true;
                }
                Ikonica1.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(g.Ikonica);
                Jedinice.ItemsSource = g.Jedinice;
                idx.Text = g.ID.ToString();
                nazivx.Text = g.Naziv;
                adresax.Text = g.Adresa;
                ikonicex.SelectedItem = g.Ikonica;
            }
            
        }

        private void GarnizoniRaspored1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Garnizoni g = GarnizoniRaspored1.SelectedItem as Garnizoni;
            Ikonica2.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(g.Ikonica);
            JediniceRaspored1.ItemsSource = g.Jedinice;
        }

        private void GarnizoniRaspored2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Garnizoni g = GarnizoniRaspored2.SelectedItem as Garnizoni;
            Ikonica3.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(g.Ikonica);
            JediniceRaspored2.ItemsSource = g.Jedinice;
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

        private void ikonicex_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(ikonicex.SelectedItem as string);
        }

        private void dodajx_Click(object sender, RoutedEventArgs e)
        {
            foreach(Garnizoni d in garnizoni)
            {
                if(Int32.Parse(idx.Text)==d.ID)
                {
                    
                }
            }
                Garnizoni g = new Garnizoni(nazivx.Text, Int32.Parse(idx.Text), adresax.Text, ikonicex.SelectedItem.ToString());
                garnizoni.Add(g);
        }

        private bool IDprovera()
        {
            int x;
            if (Int32.TryParse(idx.Text, out x))
            {
                foreach (Garnizoni d in garnizoni)
                {
                    if (Int32.Parse(idx.Text) == d.ID)
                    {
                        return false;
                    }
                    else
                    {

                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void izmenix_Click(object sender, RoutedEventArgs e)
        {
            Garnizoni g = Garnizoni.SelectedItem as Garnizoni;
            if (IDprovera())
            {
                g.ID = Int32.Parse(idx.Text);
                g.Adresa = adresax.Text;
                g.Naziv = nazivx.Text;
                ///g.Ikonica = ikonicex.SelectedItem as string;
                MessageBox.Show("Garnizon uspesno izmenjen!");
            }
            else
            {
                MessageBox.Show("ID Nevazeci!");
            }
        }

        private void obrisix_Click(object sender, RoutedEventArgs e)
        {
            Garnizoni g = Garnizoni.SelectedItem as Garnizoni;
            garnizoni.Remove(g);
            idx.Text = "";
            nazivx.Text = "";
            adresax.Text = "";
            Ikonica1.Source = null;
            foreach(Jedinica j in g.Jedinice)
            {
                samostalni.Jedinice.Add(j);
            }
            Jedinice.ItemsSource = null;
           
        }

        private void GarnizoniMapa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Garnizoni g = GarnizoniMapa.SelectedItem as Garnizoni;
            IkonicaMapa.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(g.Ikonica);
            JediniceMapa.ItemsSource = g.Jedinice;
        }

        private void JediniceMapa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
