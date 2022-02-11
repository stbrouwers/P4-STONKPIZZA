using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StonksPizza.Inlog
{
    /// <summary>
    /// Interaction logic for Medewerker_Inlog.xaml
    /// </summary>
    public partial class Medewerker_Inlog : Window
    {
        public Medewerker_Inlog()
        {
            InitializeComponent();
        }

        private void BT_InloggenMedewerker_Click(object sender, RoutedEventArgs e)
        {
            if(MedewerkerID.Text == "123" && Naam.Text == "test" && Wachtwoord.Text == "aaa")
            {
                MessageBox.Show("U bent ingelogd!", "Ingelogd", MessageBoxButton.OK, MessageBoxImage.Information);
                MedewerkerWindow meW = new MedewerkerWindow();
                meW.ShowDialog();
            }
        }
    }
}
