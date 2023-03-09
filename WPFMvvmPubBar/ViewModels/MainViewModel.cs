using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WPFMvvmPubBar.Commands;
using WPFMvvmPubBar.Models;
using WPFMvvmPubBar.Repositories;

namespace WPFMvvmPubBar.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public FakeRepo BeerRepository { get; set; }

        private ObservableCollection<Beer> allBeers;

        public ObservableCollection<Beer> AllBeers
        {
            get { return allBeers; }
            set { allBeers = value; OnPropertyChanged(); }
        }

        private Beer beer;

        public Beer Beer
        {
            get { return beer; }
            set { beer = value; OnPropertyChanged(); }
        }

        public RelayCommand SelectedCommand { get; set; }

        public MainViewModel()
        {
            BeerRepository = new FakeRepo();
            AllBeers = new ObservableCollection<Beer>(BeerRepository.GetAll());
            Beer = new Beer();

            SelectedCommand = new RelayCommand((obj) =>
            {
                var item = obj as Beer;
                Beer = item;
            });
        }


    }
}
