using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StonksPizza.Models;

namespace StonksPizza.windows.Units
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
        private DBunits unit = new DBunits();

        public DBunits Unit
        {
            get { return unit; }
            set { unit = value; OnPropertyChanged(); }
        }

        ClassDB _db = new ClassDB();
        public Edit(int unitid)
        {
            InitializeComponent();
            LoadUnit(unitid);
            DataContext = this;
        }
        public void LoadUnit(int unitid)
        {
            Unit = _db.GetSpecificUnit(unitid);
            if (Unit == null)
            {
                MessageBox.Show("De database is leeg");
                Close();
            }
        }

        private void BT_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (Unit == null)
            {
                MessageBox.Show("Lege invulveld. Probeer opnieuw"); return;
            }
            else
            {
                _db.EditUnit(Unit);
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
