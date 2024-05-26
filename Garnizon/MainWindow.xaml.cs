using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
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
        private ObservableCollection<BitmapImage> Ikonice = new ObservableCollection<BitmapImage>();
        private ObservableCollection<Jedinica> Jedinicee = new ObservableCollection<Jedinica>();
        private Garnizoni samostalni = new Garnizoni("SAMOSTALNI", 0, "AA", new BitmapImage(new Uri("Images/Samostalna_Vojska.png", UriKind.Relative)));
        BitmapImage Image1 = new BitmapImage();
        BitmapImage Image2 = new BitmapImage();
        Point startPoint = new Point();
        Point endPoint = new Point();
        private Point _enterPoint;
        private UIElement draggedItem;
        private Point itemRelativePosition;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Garnizoni g1 = new Garnizoni("Avalski Štit", 1, "Mileta Kitica 77", new BitmapImage(new Uri("Images/Garnizon_1.png", UriKind.Relative)));
            Garnizoni g2 = new Garnizoni("Stitnici Svetla", 2, "BB", new BitmapImage(new Uri("Images/Garnizon_1.png", UriKind.Relative)));
            Jedinica j1 = new Jedinica("1.Pesadija", "Mileta Kitica 77", new BitmapImage(new Uri("Images/Bataljon_1.png", UriKind.Relative)));
            Jedinica j2 = new Jedinica("2.Pesadija", "Mileta Kitica 77", new BitmapImage(new Uri("Images/Bataljon_2.png", UriKind.Relative)));
            Jedinica j3 = new Jedinica("3.Pesadija", "Mileta Kitica 77", new BitmapImage(new Uri("Images/Bataljon_3.png", UriKind.Relative)));
            Jedinica j4 = new Jedinica("4.Pesadija", "Mileta Kitica 77", new BitmapImage(new Uri("Images/Bataljon_4.png", UriKind.Relative)));
            g1.Jedinice.Add(j1); g1.Jedinice.Add(j2); g1.Jedinice.Add(j3); g1.Jedinice.Add(j4);
            Jedinicee.Add(j1); Jedinicee.Add(j2); Jedinicee.Add(j3); Jedinicee.Add(j4);
            garnizoni.Add(samostalni);
            garnizoni.Add(g1);
            garnizoni.Add(g2);
            Garnizoni.ItemsSource = garnizoni;
            GarnizoniRaspored1.ItemsSource = garnizoni;
            GarnizoniRaspored2.ItemsSource = garnizoni;
            GarnizoniKarta.ItemsSource = garnizoni;

            dodajj.IsEnabled = false;
            izmenij.IsEnabled = false;
            obrisij.IsEnabled = false;

            dodajx.IsEnabled = false;
            obrisix.IsEnabled = false;
            izmenix.IsEnabled = false;
        }

        private void Jedinice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Jedinica j = Jedinice.SelectedItem as Jedinica;
            if(j!=null)
            {
                izmenij.IsEnabled = true;
                obrisij.IsEnabled = true;
                nazivj.Text = j.Naziv;
                adresaj.Text = j.Adresa;
                Image2 = j.Ikonica;
            }
            else
            {
                izmenij.IsEnabled = false;
                obrisij.IsEnabled = false;
            }
        }

        private void Garnizoni_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Garnizoni g = Garnizoni.SelectedItem as Garnizoni;
            if (g != null)
            {
                if (g.ID == 0)
                {
                    obrisix.IsEnabled = false;
                    izmenix.IsEnabled = false;
                }
                else
                {
                    obrisix.IsEnabled = true;
                    izmenix.IsEnabled = true;
                }
                if (g != null)
                {
                    nazivj.Text = "";
                    adresaj.Text = "";

                    Image1 = g.Ikonica;
                    Ikonica1.Source = g.Ikonica;
                    Jedinice.ItemsSource = g.Jedinice;
                    idx.Text = (g.ID).ToString();
                    nazivx.Text = g.Naziv;
                    adresax.Text = g.Adresa;
                }
            }
            else
            {
                dodajx.IsEnabled = false;
                obrisix.IsEnabled = false;
                izmenix.IsEnabled = false;
            }
            
        }

        private void GarnizoniRaspored1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Garnizoni g = GarnizoniRaspored1.SelectedItem as Garnizoni;
            Ikonica2.Source = g.Ikonica;
            JediniceRaspored1.ItemsSource = g.Jedinice;
        }

        private void GarnizoniRaspored2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Garnizoni g = GarnizoniRaspored2.SelectedItem as Garnizoni;
            Ikonica3.Source = g.Ikonica;
            JediniceRaspored2.ItemsSource = g.Jedinice;
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void JediniceRaspored1_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;
            Jedinica jj = JediniceRaspored1.SelectedItem as Jedinica;

            if(e.LeftButton == MouseButtonState.Pressed && 
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance) && jj != null)
            {
                ListView listView = sender as ListView;
                ListViewItem listViewItem =
                    FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                if (listViewItem != null)
                {
                    Jedinica j = (Jedinica)listView.ItemContainerGenerator.
                    ItemFromContainer(listViewItem);

                    DataObject dragData = new DataObject("myFormat", j);
                    DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
                }
            }
        }

        private void JediniceRaspored1_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void JediniceRaspored1_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Jedinica j = e.Data.GetData("myFormat") as Jedinica;
                Garnizoni g1 = GarnizoniRaspored1.SelectedItem as Garnizoni;
                Garnizoni g2 = GarnizoniRaspored2.SelectedItem as Garnizoni;
                if (g1 != g2 && g1 != null && g2 != null && g2.Jedinice.Contains(j))
                {
                    g2.Jedinice.Remove(j);
                    g1.Jedinice.Add(j);
                    JediniceRaspored2.Items.Refresh();
                    JediniceRaspored1.Items.Refresh();
                }
            }
        }

        private void JediniceRaspored2_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;
            Jedinica jj = JediniceRaspored2.SelectedItem as Jedinica;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                ListView listView = sender as ListView;
                ListViewItem listViewItem =
                    FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                if (listViewItem != null)
                {
                    Jedinica j = (Jedinica)listView.ItemContainerGenerator.
                        ItemFromContainer(listViewItem);

                    DataObject dragData = new DataObject("myFormat", j);
                    DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
                }
            }
        }

        private void JediniceRaspored2_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Jedinica j = e.Data.GetData("myFormat") as Jedinica;
                Garnizoni g1 = GarnizoniRaspored1.SelectedItem as Garnizoni;
                Garnizoni g2 = GarnizoniRaspored2.SelectedItem as Garnizoni;
                if (g1 != g2 && g1 != null && g2 != null && g1.Jedinice.Contains(j))
                {
                    g1.Jedinice.Remove(j);
                    g2.Jedinice.Add(j);
                    JediniceRaspored2.Items.Refresh();
                    JediniceRaspored1.Items.Refresh();
                }
            }
        }

        private void JediniceRaspored2_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void dodajx_Click(object sender, RoutedEventArgs e)
        {
            if (IDprovera() && nazivx.Text!="" && adresax.Text!="")
            {
                foreach(Garnizoni k in garnizoni.ToList())
                {
                    if(Int32.Parse(idx.Text)!= k.ID)
                    {
                        Garnizoni g = new Garnizoni(nazivx.Text, Int32.Parse(idx.Text), adresax.Text, Image1);
                        garnizoni.Add(g);
                        dodajx.IsEnabled = false;
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Greska pri dodavanju garnizona!");
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Greska pri dodavanju garnizona!");
            }
            dodajx.IsEnabled = false;
        }

        private bool IDprovera()
        {
            Garnizoni g = Garnizoni.SelectedItem as Garnizoni;
            int x;
            if (Int32.TryParse(idx.Text, out x))
            {
                foreach (Garnizoni d in garnizoni)
                {
                    if (Int32.Parse(idx.Text) == d.ID && Int32.Parse(idx.Text)!=g.ID)
                    {
                        return false;
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
            if (IDprovera() && nazivx.Text != "" && adresax.Text != "")
            {
                g.ID = Int32.Parse(idx.Text);
                g.Adresa = adresax.Text;
                g.Naziv = nazivx.Text;
                g.Ikonica = Image1;
                Ikonica1.Source = Image1;
                MessageBox.Show("Garnizon uspesno izmenjen!");
            }
            else
            {
                MessageBox.Show("Greska pri izmeni garnizona!");
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
            MessageBox.Show("Garnizon uspesno obrisan!");
        }

        private void ikonicax_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Image1 = new BitmapImage(new Uri(openFileDialog.FileName));
                dodajx.IsEnabled = true;
            }
        }

        private void GarnizoniKarta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Garnizoni g = GarnizoniKarta.SelectedItem as Garnizoni;
            if (g != null)
            {
                IkonicaKarta.Source = g.Ikonica;
                JediniceKarta.ItemsSource = g.Jedinice;
            }
        }

        private void ikonicaj_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Image2 = new BitmapImage(new Uri(openFileDialog.FileName));
                dodajj.IsEnabled = true;
            }
        }

        private bool ProveraJedinice()
        {
            foreach (Jedinica j in Jedinicee)
            {
                if (nazivj.Text == j.Naziv)
                {
                    return false;
                }
            }
            return true;
        }

        private void dodajj_Click(object sender, RoutedEventArgs e)
        {
            if (ProveraJedinice() && nazivj.Text != "" && adresaj.Text != "")
            {
                if (Garnizoni.SelectedItem != null)
                {
                    Garnizoni g = Garnizoni.SelectedItem as Garnizoni;
                    g.Jedinice.Add(new Jedinica(nazivj.Text, adresaj.Text, Image2));
                    Jedinicee.Add(new Jedinica(nazivj.Text, adresaj.Text, Image2));
                }
                else
                {
                    samostalni.Jedinice.Add(new Jedinica(nazivj.Text, adresaj.Text, Image2));
                    Jedinicee.Add(new Jedinica(nazivj.Text, adresaj.Text, Image2));
                }
                MessageBox.Show("Jedinica uspesno dodata!");
            }
            else
            {
                MessageBox.Show("Greska pri dodavanju jedinice!");
            }
            dodajj.IsEnabled = false;
            Jedinice.Items.Refresh();
        }

        private void izmenij_Click(object sender, RoutedEventArgs e)
        {
            if (ProveraJedinice() && nazivj.Text != "" && adresaj.Text != "")
            {
                if(Jedinice.SelectedItem != null)
                {
                    Jedinica j = Jedinice.SelectedItem as Jedinica;
                    j.Ikonica = Image2;
                    j.Naziv = nazivj.Text;
                    j.Adresa = adresaj.Text;
                    MessageBox.Show("Jedinica uspesno izmenjena!");
                    Jedinice.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Greska pri izmeni jedinice!");
            }
        }

        private void obrisij_Click(object sender, RoutedEventArgs e)
        {
            Garnizoni g = Garnizoni.SelectedItem as Garnizoni;
            Jedinica j = Jedinice.SelectedItem as Jedinica;
            Jedinicee.Remove(j);
            g.Jedinice.Remove(j);
            nazivj.Text = "";
            adresaj.Text = "";
            Jedinice.Items.Refresh();
            MessageBox.Show("Jedinica uspesno obrisana!");
        }

        private void export_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("Podaci.txt"))
            {

                foreach (Garnizoni g in garnizoni)
                {
                    writer.WriteLine(g.ID.ToString() + "\t" + g.Naziv + "\t" + g.Adresa + "\t" + g.Ikonica.ToString());
                    foreach (Jedinica j in g.Jedinice)
                    {
                        writer.WriteLine("\t" + j.Naziv + "\t" + j.Ikonica.ToString() + "\t" + j.Adresa);
                    }
                    writer.WriteLine("");
                }
            }
        }

        private void JediniceRaspored1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void JediniceRaspored2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void JediniceKarta_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;
            Jedinica jj = JediniceRaspored1.SelectedItem as Jedinica;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance) && jj != null)
            {
                ListView listView = sender as ListView;
                ListViewItem listViewItem =
                    FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                if (listViewItem != null)
                {
                    Jedinica j = (Jedinica)listView.ItemContainerGenerator.
                    ItemFromContainer(listViewItem);

                    DataObject dragData = new DataObject("myFormat", j);
                    DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Copy);
                }
            }
        }
        private void JediniceKarta_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = e.Source as Image;
            DataObject data = new DataObject(typeof(Uri), image.Source);
            DragDrop.DoDragDrop(image, data, DragDropEffects.All);
        }

        private void Canvas_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.Copy;
            }
        }

        private void Canvas_Drop(object sender, DragEventArgs e)
        {
            Jedinica j = JediniceKarta.SelectedItem as Jedinica;
            if (e.Data.GetDataPresent("MyFormat") && j!=null)
            {

                Canvas canvas = sender as Canvas;

                Image imagec = new Image();
                imagec.Source = j.Ikonica;
                imagec.SetValue(Canvas.LeftProperty,_enterPoint.X);
                imagec.SetValue(Canvas.TopProperty, _enterPoint.Y);

                canvas.Children.Add(imagec);
            }

        }

        private void canvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (this.draggedItem == null)
                return;
            var newPos = e.GetPosition(canvas) - itemRelativePosition;
            Canvas.SetTop(this.draggedItem, newPos.Y);
            Canvas.SetLeft(this.draggedItem, newPos.X);
            canvas.CaptureMouse();
            e.Handled = true;
        }

        private void imagec_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.draggedItem = (UIElement)sender;
            itemRelativePosition = e.GetPosition(this.draggedItem);
            e.Handled = true;
        }

        private void canvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.draggedItem != null)
            {
                this.draggedItem = null;
                canvas.ReleaseMouseCapture();
                e.Handled = true;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}