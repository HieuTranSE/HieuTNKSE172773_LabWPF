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

namespace KoiManagementWPF
{
    /// <summary>
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Window
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }


        private void ManageKoiFish_Click(object sender, RoutedEventArgs e)
        {
            KoiFishManagement koifishManagement = new KoiFishManagement();
            koifishManagement.Show();
            this.Hide();
        }

        private void ManageAds_Click(object sender, RoutedEventArgs e)
        {
            AdvertisementManagement adsManagement = new AdvertisementManagement();
            adsManagement.Show();
            this.Hide();
        }

        private void ManageAccount_Click(object sender, RoutedEventArgs e)
        {
            AccountManagement accountManagement = new AccountManagement();
            accountManagement.Show();
            this.Hide();
        }
    }
}
