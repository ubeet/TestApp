using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TestApp.Model;
using TestApp.View;

namespace TestApp.ViewModel
{
    internal class MainVM : VMBase
    {
        private Page Home = new HomePage();
        private Page Exchange = new ExchangePage();
        private Page Search = new SearchPage();
        private Page Settings = new SettingsPage();
        private Page _StartPage = new HomePage();

        private Cryptocurrency selectedCryptocurrency;
        private ObservableCollection<Cryptocurrency> cryptocurrencies;
        public Page StartPage
        {
            get => _StartPage;
            set => Set(ref _StartPage, value);
        }

        public ICommand OpenHomePage
        {
            get => new RelayCommand(() => StartPage = Home);
        }
        public ICommand OpenExchangePage
        {
            get => new RelayCommand(() => StartPage = Exchange);
        }
        public ICommand OpenSearchPage
        {
            get => new RelayCommand(() => StartPage = Search);
        }
        public ICommand OpenSettingsPage
        {
            get => new RelayCommand(() => StartPage = Settings);
        }

        public Cryptocurrency SelectedCryptocurrency
        {
            get
            {
                return selectedCryptocurrency;
            }

            set
            {
                selectedCryptocurrency = value;
                OnPropertyChanged("SelectedCustomer");
            }
        }

        public ObservableCollection<Cryptocurrency> Cryptocurrencies
        {
            get
            {
                return cryptocurrencies;
            }
            set
            {
                cryptocurrencies = value;
                OnPropertyChanged("Cryptocurrencies");
            }
        }
    }

}
