using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using StonksPizza.Models;

namespace StonksPizza.windows.Bestellingen
{
    /// <summary>
    /// Interaction logic for BestellingenWindow.xaml
    /// </summary>
    
    public partial class BestellingenWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        ClassDB _db = new ClassDB();

        private ObservableCollection<DBbestellingen> obvBestellingen = new ObservableCollection<DBbestellingen>();

        public ObservableCollection<DBbestellingen> Bestellingen
        {
            get { return obvBestellingen; }
            set { obvBestellingen = value; }
        }

        private DBbestellingen selectedBestelling;

        public DBbestellingen SelectedBestelling
        {
            get { return selectedBestelling; }
            set { selectedBestelling = value; }
        }

        public BestellingenWindow()
        {
            InitializeComponent();
            LoadBestellingen();
        DataContext = this;
        }

        public void LoadBestellingen()
        {
            Bestellingen.Clear();
            foreach(DBbestellingen bestellingen in _db.GetAllBestellingen())
            {
            if (bestellingen == null)
            {
                MessageBox.Show("De database is leeg");
            }
            Bestellingen.Add(bestellingen);
            }
        }

        private void BT_Edit_Click(object sender, RoutedEventArgs e)
        {
            Edit Windowe = new Edit(SelectedBestelling.BestellingID);
            Windowe.ShowDialog();
        }

        private void BT_Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show($"Weet u zeker dat u bestelling {selectedBestelling.BestellingID} wilt verwijderen?", "Warning", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (SelectedBestelling == null)
                {
                    MessageBox.Show("U heeft geen item gekozen om te verwijderen");
                }
                else
                {
                    _db.DeleteBestelling(SelectedBestelling);
                    LoadBestellingen();
                }
            }
        }
    }
}
