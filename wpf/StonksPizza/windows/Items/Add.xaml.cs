using System.Windows;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using StonksPizza.Models;

namespace StonksPizza.windows.Items
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public event PropertyChangedEventHandler Propertchanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            Propertchanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private DBitems items = new DBitems();

        public DBitems Items
        {
            get { return items; }
            set { items = value; OnPropertyChanged(); }
        }

        ClassDB _db = new ClassDB();
        public Add()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void BT_Add_Click(object sender, RoutedEventArgs e)
        {
            if(items == null)
            {
                MessageBox.Show("Lege invulveld(en). Probeer opnieuw."); return;
            }
            else
            {
                _db.CreateItem(Items);
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
