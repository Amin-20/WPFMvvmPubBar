using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMvvmPubBar.Commands;
using WPFMvvmPubBar.Models;
using WPFMvvmPubBar.Views;

namespace WPFMvvmPubBar.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        public HistoryWindow HistoryWindow { get; set; }
        private List<Sales> sales;

        public List<Sales> Sales
        {
            get { return sales; }
            set { sales = value; }
        }

        public RelayCommand OkCommand { get; set; }

        public HistoryViewModel()
        {
            sales = new List<Sales>();

            OkCommand = new RelayCommand((obj) =>
            {
                HistoryWindow.Close();
            });
        }


    }
}
