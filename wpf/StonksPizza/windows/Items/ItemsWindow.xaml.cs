using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StonksPizza.Models;

namespace StonksPizza.windows.Items
{
    /// <summary>
    /// Interaction logic for ItemsWindow.xaml
    /// </summary>
    public partial class ItemsWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        ClassDB _db = new ClassDB();

        private ObservableCollection<DBitems> obvItems = new ObservableCollection<DBitems>();
        public ObservableCollection<DBitems> Items
        {
            get { return obvItems; }
            set { obvItems = value; }
        }

        private DBitems selectedItem;
        public DBitems SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; }
        }

        public ItemsWindow()
        {
            InitializeComponent();
            LoadItems();
            DataContext = this;
        }

        public void LoadItems()
        {
            Items.Clear();
            foreach(DBitems items in _db.GetAllItems())
            {
                if (items == null)
                {
                    MessageBox.Show("De database is leeg");
                }
                Items.Add(items);
            }
        }

        private void BT_Add_Click(object sender, RoutedEventArgs e)
        {
            Add windowA = new Add();
            this.Close();
            windowA.ShowDialog();
        }

        private void BT_Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show($"Weet u zeker dat u item {selectedItem.ItemID} wilt verwijderen?", "Warning", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (SelectedItem == null) MessageBox.Show("U heeft geen item gekozen om te verwijderen");
                else
                {
                    _db.DeleteItem(SelectedItem);
                    LoadItems();
                }
            }
        }

        private void BT_Edit_Click(object sender, RoutedEventArgs e)
        {
            Edit WindowE = new Edit(SelectedItem.ItemID);
            WindowE.ShowDialog();
        }
    }
}
