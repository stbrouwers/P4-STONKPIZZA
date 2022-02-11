using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StonksPizza.Models;

namespace StonksPizza.windows.Bestellingen
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
        private DBbestellingen bestelling = new DBbestellingen();

        public DBbestellingen Bestelling
        {
            get { return bestelling; }
            set { bestelling = value; OnPropertyChanged(); }
        }

        ClassDB _db = new ClassDB();
        public Edit(int bestellingid)
        {
            InitializeComponent();
            LoadBestelling(bestellingid);
            DataContext = this;
        }

        public void LoadBestelling(int bestellingid)
        {
            Bestelling = _db.GetSpecificBestelling(bestellingid);
            if (bestelling == null)
            {
                MessageBox.Show("De database is leeg");
                Close();
            }
        }

        private void BT_Edit_Click(object sender, RoutedEventArgs e)
        {
            if (Bestelling == null)
            {
                MessageBox.Show("Lege invulveld(en). Probeer opnieuw"); return;
            }
            else
            {
                _db.EditBestelling(Bestelling);
                this.Close();
                BestellingenWindow WindowI = new BestellingenWindow();
                WindowI.ShowDialog();
            }
        }

        private void BT_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
