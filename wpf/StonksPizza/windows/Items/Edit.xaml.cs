using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StonksPizza.Models;

namespace StonksPizza.windows.Items
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public event PropertyChangedEventHandler Propertychanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            Propertychanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private DBitems item = new DBitems();

        public DBitems Item
        {
            get { return item; }
            set { item = value; OnPropertyChanged(); }
        }


        ClassDB _db = new ClassDB();
        public Edit(int itemid)
        {
            InitializeComponent();
            LoadItem(itemid);
            DataContext = this;
        }

        public void LoadItem(int itemid)
        {
            Item = _db.GetSpecificItem(itemid);
            if (item == null)
            { 
                MessageBox.Show("De database is leeg");
                Close();
            }
        }

        private void BT_Edit_Click(object sender, RoutedEventArgs e)
        {
            if(Item == null)
            {
                MessageBox.Show("Lege invulveld(en). Probeer opnieuw"); return;
            }
            else
            {
                _db.EditItem(Item);
                this.Close();
                ItemsWindow WindowI = new ItemsWindow();
                WindowI.ShowDialog();
            }
        }

        private void BT_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
