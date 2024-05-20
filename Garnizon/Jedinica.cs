using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
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
    internal class Jedinica : INotifyPropertyChanged
    {
        private string naziv;
        private string adresa;
        private BitmapImage ikonica;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(v));
        }

        public Jedinica()
        {
            this.naziv = "";
            this.adresa = "";
            this.ikonica = new BitmapImage(new Uri("", UriKind.Relative));
        }
        public Jedinica(string naziv,string adresa,BitmapImage ikonica)
        {
            this.naziv = naziv;
            this.adresa = adresa;
            this.ikonica = ikonica;
        }

        public string Naziv
        {
            get { return this.naziv; }
            set
            {
                if(this.naziv != value)
                {
                    this.naziv = value;
                    this.NotifyPropertyChanged("BrojIndeksa");
                }
            }
        }

        public string Adresa
        {
            get { return this.adresa; }
            set
            {
                if (this.adresa != value)
                {
                    this.adresa = value;
                    this.NotifyPropertyChanged("Adresa");
                }
            }
        }

        public BitmapImage Ikonica
        {
            get { return this.ikonica; }
            set
            {
                if (this.ikonica != value)
                {
                    this.ikonica = value;
                    this.NotifyPropertyChanged("Ikonica");
                }
            }
        }
    }
}
