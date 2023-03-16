using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPFMvvmPubBar.Commands;
using WPFMvvmPubBar.Models;
using WPFMvvmPubBar.Repositories;
using WPFMvvmPubBar.Views;

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
        public RelayCommand ResetButtonCommand { get; set; }
        public RelayCommand BuyCommand { get; set; }
        public RelayCommand HistoryCommand { get; set; }

        public List<Sales> Products { get; set; } = new List<Sales>();


        private double total;

        public double Total
        {
            get { return total; }
            set { total = value; OnPropertyChanged(); }
        }


        private int count = 0;

        public int Count
        {
            get { return count; }
            set { count = value; OnPropertyChanged(); }
        }



        public MainViewModel()
        {
            BeerRepository = new FakeRepo();
            AllBeers = new ObservableCollection<Beer>(BeerRepository.GetAll());
            Beer = new Beer();


            SelectedCommand = new RelayCommand((obj) =>
            {
                Total = 0;
                Count = 0;
                var item = obj as Beer;
                Beer = item;
            });

            PlusButtonCommand = new RelayCommand((obj) =>
            {
                Total += Beer.Price;
                Count++;
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
                if (Total >= Beer.Price)
                {
                    Total -= Beer.Price;
                }
                if (Count != 0) { Count--; }
            }, (pred) =>
            {
                if (Beer.Id == 0)
                {
                    return false;
                }
                return true;
            });

            ResetButtonCommand = new RelayCommand((obj) =>
            {
                Total = 0;
                Count = 0;
            }, (pred) =>
            {
                if (Beer.Id == 0)
                {
                    return false;
                }
                return true;
            });


            BuyCommand = new RelayCommand((obj) =>
            {
                var result = MessageBox.Show("Do you buy your picks?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {

                    Sales product = new Sales
                    {
                        Name = Beer.Name,
                        ProductPrice = Beer.Price,
                        Price = Beer.Price * Count,
                        Count = Count
                    };

                    Products.Add(product);

                    FileHelper.Write(Products);

                    Total = 0;
                    Count = 0;
                }
            }, (pred) =>
            {
                if (Beer.Id == 0 || Count == 0)
                {
                    return false;
                }
                return true;
            });

            HistoryCommand = new RelayCommand((obj) =>
            {
                HistoryWindow hWindow = new HistoryWindow();

                HistoryViewModel vm = new HistoryViewModel();
                vm.HistoryWindow = hWindow;
                vm.Sales = FileHelper.Read("Sales.json");

                hWindow.DataContext = vm;
                hWindow.ShowDialog();

            });

        }


    }
}
