using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Model
{
    class Cryptocurrency : INotifyPropertyChanged
    {
        private string id;
        private int rank;
        private string symbol;
        private string name;
        private double marketCapUsd;
        private double volumeUsd24Hr;
        private double priceUsd;
        private double changePercent24Hr;

        

        public Cryptocurrency(string id, int rank, string symbol, string name, double marketCapUsd, double volumeUsd24Hr, double priceUsd, double changePercent24Hr)
        {
            this.id = id;
            this.rank = rank;
            this.symbol = symbol;
            this.name = name;
            this.marketCapUsd = marketCapUsd;
            this.volumeUsd24Hr = volumeUsd24Hr;
            this.priceUsd = priceUsd;
            this.changePercent24Hr = changePercent24Hr;
        }

        public string Id
        {
            get
            {
                return this.id;
            }
        }

        public int Rank
        {
            get
            {
                return this.rank;
            }
            set
            {
                this.rank = value;
                OnPropertyChanged("Rank");
            }
        }

        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public double MarketCapUsd
        {
            get
            {
                return this.marketCapUsd;
            }
            set
            {
                this.marketCapUsd = value;
                OnPropertyChanged("MarketCapUsd");
            }
        }

        public double VolumeUsd24Hr
        {
            get
            {
                return this.volumeUsd24Hr;
            }
            set
            {
                this.volumeUsd24Hr = value;
                OnPropertyChanged("VolumeUsd24Hr");
            }
        }

        public double PriceUsd
        {
            get
            {
                return this.priceUsd;
            }
            set
            {
                this.priceUsd = value;
                OnPropertyChanged("PriceUsd");
            }
        }

        public double ChangePercent24Hr
        {
            get
            {
                return this.changePercent24Hr;
            }
            set
            {
                this.changePercent24Hr = value;
                OnPropertyChanged("ChangePercent24Hr");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
