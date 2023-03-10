using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
        public RelayCommand PlusButtonCommand { get; set; }
        public RelayCommand MinusButtonCommand { get; set; }
        public RelayCommand CountCommand { get; set; }

        public MainViewModel(Label countLbl)
        {
            BeerRepository = new FakeRepo();
            AllBeers = new ObservableCollection<Beer>(BeerRepository.GetAll());
            Beer = new Beer();


            SelectedCommand = new RelayCommand((obj) =>
            {
                var item = obj as Beer;
                Beer = item;
            });

            PlusButtonCommand = new RelayCommand((obj) =>
            {
                var temp = Beer.Price;
                Beer.Price += temp;
                var temp1 = int.Parse(countLbl.Content.ToString());
                temp1 += 1;
                countLbl.Content = temp1.ToString();
            }, (pred) =>
            {
                if (Beer.Id == 0)
                {
                    return false;
                }
                return true;
            });

            MinusButtonCommand = new RelayCommand((obj) =>
            {
                var temp = Beer.Price;
                if (temp > Beer.Price)
                {
                    Beer.Price -= temp;
                }
                var temp1 = int.Parse(countLbl.Content.ToString());
                if (temp1 > 0)
                {
                    temp1 -= 1;
                }
                countLbl.Content = temp1.ToString();
            }, (pred) =>
            {
                if (Beer.Id == 0)
                {
                    return false;
                }
                return true;
            });



        }


    }
}
