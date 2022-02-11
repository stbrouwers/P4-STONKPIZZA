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
using StonksPizza.windows.Bestellingen;
using StonksPizza.windows.Items;
using StonksPizza.windows.Units;

namespace StonksPizza
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();
        }

        private void Bestellingen_Click(object sender, RoutedEventArgs e)
        {
            BestellingenWindow WindowB = new BestellingenWindow();
            WindowB.ShowDialog();
        }

        private void Units_Click(object sender, RoutedEventArgs e)
        {
            UnitsWindow WindowU = new UnitsWindow();
            WindowU.ShowDialog();
        }

        private void Items_Click(object sender, RoutedEventArgs e)
        {
            ItemsWindow WindowI = new ItemsWindow();
            WindowI.ShowDialog();
        }

        private void Pizzas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Accounts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Producten_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Transacties_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Voertuigen_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
