using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Garnizon
{
    internal class Jedinica : INotifyPropertyChanged
    {
        private string naziv;
        private string adresa;
        private string ikonica;

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
            this.ikonica = "";
        }
        public Jedinica(string naziv,string adresa,string ikonica)
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

        public string Ikonica
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
