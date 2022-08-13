using Project_002.Core;
using Project_002.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project_002.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {

        /* commands */
        public  RelayCommand MoveWindowCommand { get; set; }
        public  RelayCommand ShutdownWindowCommand { get; set; }
        public  RelayCommand MaximizeWindowCommand { get; set; }
        public  RelayCommand MinimizeWindowCommand { get; set; }
        public RelayCommand CloseAccountCommand { get; set; }
        public RelayCommand OpenAccountCommand { get; set; }
        public RelayCommand ReplenishmentCommand { get; set; }
        public RelayCommand TranferCommand { get; set; }

        RepositoryModel<BankAccount> bankAccountRepository = new RepositoryModel<BankAccount>();
        public ObservableCollection<BankAccount> BankAccountsGroup { get; set; }
        public int SelectedIndex { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public int Amount { get; set; }
        public MainViewModel()
        {
            Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MoveWindowCommand = new RelayCommand(o => { Application.Current.MainWindow.DragMove(); });
            ShutdownWindowCommand = new RelayCommand(o => { Application.Current.Shutdown(); });
            MaximizeWindowCommand = new RelayCommand(o => 
            {
                if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                else
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
            });
            MinimizeWindowCommand = new RelayCommand(o => { Application.Current.MainWindow.WindowState = WindowState.Minimized; });
            CloseAccountCommand = new RelayCommand(o =>
            {
                if (BankAccountsGroup[SelectedIndex].Status == true)
                {
                    BankAccountsGroup[SelectedIndex].Status = false;
                    RepositoryModel<BankAccount>.SaveToDataBase(BankAccountsGroup);
                }
            });
            OpenAccountCommand = new RelayCommand(o =>
            {
                if (BankAccountsGroup[SelectedIndex].Status == false)
                {
                    BankAccountsGroup[SelectedIndex].Status = true;
                    RepositoryModel<BankAccount>.SaveToDataBase(BankAccountsGroup);
                }
            });
            ReplenishmentCommand = new RelayCommand(o =>
            {
                    BankAccountsGroup[SelectedIndex].Balance += Amount;
                    RepositoryModel<BankAccount>.SaveToDataBase(BankAccountsGroup);
            });
            TranferCommand = new RelayCommand(o =>
            {
                foreach (var item in BankAccountsGroup)
                {
                    if (item.Number == Sender)
                    {
                        item.Balance -= Amount;
                    }
                }
                foreach (var item in BankAccountsGroup)
                {
                    if (item.Number == Recipient)
                    {
                        item.Balance += Amount;
                    }
                }
                RepositoryModel<BankAccount>.SaveToDataBase(BankAccountsGroup);
            });

            BankAccountsGroup = bankAccountRepository.UploadData(LoadData.LoadDataBankAccount());
        }
    }
}
