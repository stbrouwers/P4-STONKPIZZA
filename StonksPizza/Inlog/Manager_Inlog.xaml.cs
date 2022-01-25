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
    /// Interaction logic for Manager_Inlog.xaml
    /// </summary>
    public partial class Manager_Inlog : Window
    {
        public Manager_Inlog()
        {
            InitializeComponent();
        }

        private void BT_InloggenManager_Click(object sender, RoutedEventArgs e)
        {
            if(ManagerID.Text == "123" && Naam.Text == "test" && Wachtwoord.Text == "test")
            {
                ManagerWindow maW = new ManagerWindow();
                maW.ShowDialog();
            }
        }
    }
}
