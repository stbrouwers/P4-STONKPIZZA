using System.Windows;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using StonksPizza.Models;

namespace StonksPizza.windows.Units
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

        private DBunits unit = new DBunits();

        public DBunits Unit
        {
            get { return unit; }
            set { unit = value; OnPropertyChanged(); }
        }

        ClassDB _db = new ClassDB();
        public Add()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void BT_Add_Click(object sender, RoutedEventArgs e)
        {
            if (unit == null)
            {
                MessageBox.Show("Lege invulveld(en). Probeer opnieuw."); return;
            }
            else
            {
                _db.CreateUnit(Unit);
                this.Close();
                UnitsWindow WindowU = new UnitsWindow();
                WindowU.ShowDialog();
            }
        }

        private void BT_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
