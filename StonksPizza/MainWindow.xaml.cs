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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StonksPizza
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BT_medewerker_Click(object sender, RoutedEventArgs e)
        {
            Inlog.Medewerker_Inlog medewerker = new Inlog.Medewerker_Inlog();
            medewerker.ShowDialog();
        }

        private void BT_manager_Click(object sender, RoutedEventArgs e)
        {
            Inlog.Manager_Inlog manager = new Inlog.Manager_Inlog();
            manager.ShowDialog();
        }
    }
}
