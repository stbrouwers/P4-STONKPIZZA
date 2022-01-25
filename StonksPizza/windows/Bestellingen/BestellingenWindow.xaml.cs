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

        protected void OnPropertyChanged([CallerMemberName] string bestelling = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(bestelling));
        }

        ClassDB _db = new ClassDB();

        private ObservableCollection<DBbestellingen> ObvBestellingen = new ObservableCollection<DBbestellingen>();

        public ObservableCollection<DBbestellingen> obvBestelling
        {
            get { return ObvBestellingen; }
            set { ObvBestellingen = value; }
        }

        private DBbestellingen SelectedBestelling;

        public DBbestellingen selectedBestelling
        {
            get { return SelectedBestelling; }
            set { SelectedBestelling = value; }
        }

            public BestellingenWindow()
            {
                InitializeComponent();
                LoadBestellingen();
            }

            public void LoadBestellingen()
            {
                obvBestelling.Clear();
                foreach(DBbestellingen k in _db.GetAllBestellingen())
                {
                    if (k == null) MessageBox.Show("De database is leeg");
                    obvBestelling.Add(k);
                    OnPropertyChanged("lstBestellingen");
                }
            }

            private void BT_Add_Click(object sender, RoutedEventArgs e)
            {
                add add = new add();
                add.ShowDialog();
            }
    }
}
