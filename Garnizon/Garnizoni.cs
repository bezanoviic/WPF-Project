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
    internal class Garnizoni : INotifyPropertyChanged
    {
        private string naziv;
        private int id;
        private string adresa;
        private BitmapImage ikonica;
        private List<Jedinica> jedinice;


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string v)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(v));
        }

        public Garnizoni()
        {
            this.naziv = "";
            this.id = 0;
            this.adresa = "";
            this.ikonica = new BitmapImage(new Uri("", UriKind.Relative));
            this.jedinice = new List<Jedinica>();
        }

        public Garnizoni(string naziv,int id,string adresa,BitmapImage ikonica)
        {
            this.naziv = naziv;
            this.id = id;
            this.adresa = adresa;
            this.ikonica = ikonica;
            this.jedinice = new List<Jedinica>();
        }

        public string Naziv
        {
            get { return this.naziv; }
            set
            {
                if (this.naziv != value)
                {
                    this.naziv = value;
                    this.NotifyPropertyChanged("Naziv");
                }
            }
        }

        public int ID
        {
            get { return this.id; }
            set
            {
                if(this.id!=value)
                {
                    this.id = value;
                    this.NotifyPropertyChanged("ID");
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

        public List<Jedinica> Jedinice
        {
            get { return this.jedinice; }
            set
            {
                if(this.jedinice!=value)
                {

                }
            }
        }
    }
}
