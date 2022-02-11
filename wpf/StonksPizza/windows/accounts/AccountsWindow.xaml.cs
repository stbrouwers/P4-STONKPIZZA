using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StonksPizza.Models;

namespace StonksPizza.windows.accounts
{
    /// <summary>
    /// Interaction logic for AccountsWindow.xaml
    /// </summary>
    public partial class AccountsWindow : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        ClassDB _db = new ClassDB();

        private ObservableCollection<DBaccounts> obvaccounts = new ObservableCollection<DBaccounts>();
        public ObservableCollection<DBaccounts> Accounts
        {
            get { return obvaccounts; }
            set { obvaccounts = value; }
        }

        private DBitems selectedAccount;
        public DBitems SelectedAccount
        {
            get { return selectedAccount; }
            set { selectedAccount = value; }
        }

        public AccountsWindow()
        {
            InitializeComponent();
            LoadAccounts();
            DataContext = this;
        }

        public void LoadAccounts()
        {
            Accounts.Clear();
            foreach (DBaccounts accounts in _db.GetAllAccounts())
            {
                if (accounts == null)
                {
                    MessageBox.Show("De database is leeg");
                }
                Accounts.Add(accounts);
            }
        }

        private void BT_Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BT_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BT_Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
