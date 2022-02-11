using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StonksPizza.Models;

namespace StonksPizza.windows.Units
{
    /// <summary>
    /// Interaction logic for UnitsWindow.xaml
    /// </summary>
    public partial class UnitsWindow : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        ClassDB _db = new ClassDB();

        private ObservableCollection<DBunits> obvUnits = new ObservableCollection<DBunits>();
        public ObservableCollection<DBunits> Units
        {
            get { return obvUnits; }
            set { obvUnits = value; }
        }

        private DBunits selectedUnit;
        public DBunits SelectedUnit
        {
            get { return selectedUnit; }
            set { selectedUnit = value; }
        }
        public UnitsWindow()
        {
            InitializeComponent();
            LoadUnits();
            DataContext = this;
        }

        public void LoadUnits()
        {
            Units.Clear();
            foreach(DBunits units in _db.GetAllUnits())
            {
                if(units == null)
                {
                    MessageBox.Show("De database is leeg");
                }
                Units.Add(units);
            }
        }

        private void BT_Add_Click(object sender, RoutedEventArgs e)
        {
            Add WindowA = new Add();
            WindowA.ShowDialog();
        }

        private void BT_Edit_Click(object sender, RoutedEventArgs e)
        {
            Edit WindowE = new Edit(selectedUnit.UnitID);
            WindowE.ShowDialog();
        }

        private void BT_Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show($"Weet u zeker dat u unit {selectedUnit.UnitID} wilt verwijderen?", "Warning", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (SelectedUnit == null)
                {
                    MessageBox.Show("U heeft geen unit gekozen om te verwijderen");
                }
                else
                {
                    _db.DeleteUnit(SelectedUnit);
                    LoadUnits();
                }
            }
        }
    }
}
