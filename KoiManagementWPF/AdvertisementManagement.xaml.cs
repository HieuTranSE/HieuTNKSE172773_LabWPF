using BusinessObjects.Models;
using Services;
using Services.Impl;
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
    /// Interaction logic for AdvertisementManagement.xaml
    /// </summary>
    public partial class AdvertisementManagement : Window
    {
        private AdvertisementService _advertisementService;
        public AdvertisementManagement()
        {
            InitializeComponent();
            _advertisementService = new AdvertisementServiceImpl();
            LoadAdvertisements();
        }

        private void LoadAdvertisements()
        {
            try
            {
                // Get all advertisements from the service
                var advertisements = _advertisementService.GetAllAdvertisements();

                // Set the ItemsSource of the DataGrid to the advertisements list
                AdsGrid.ItemsSource = advertisements;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading advertisements: {ex.Message}");
            }
        }

        private void ApproveButton_Click(object sender, RoutedEventArgs e)
        {
            if (AdsGrid.SelectedItem is Advertisement selectedAdvertisement)
            {
                selectedAdvertisement.Verified = true; // Set status to Approved
                _advertisementService.UpdateAdvertisement(selectedAdvertisement);
                MessageBox.Show("Advertisement approved successfully!");
                LoadAdvertisements(); // Reloads updated data into DataGrid
            }
            else
            {
                MessageBox.Show("Please select an advertisement to approve.");
            }
        }

        private void DenyButton_Click(object sender, RoutedEventArgs e)
        {
            if (AdsGrid.SelectedItem is Advertisement selectedAdvertisement)
            {
                selectedAdvertisement.Verified = false; // Set status to Denied
                _advertisementService.UpdateAdvertisement(selectedAdvertisement);
                MessageBox.Show("Advertisement denied successfully!");
                LoadAdvertisements(); // Reloads updated data into DataGrid
            }
            else
            {
                MessageBox.Show("Please select an advertisement to deny.");
            }
        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AdsGrid.SelectedItem is Advertisement selectedAdvertisement)
            {
                // Populate form fields with the selected advertisement's details
                txtTitle.Text = selectedAdvertisement.Title;
                txtDescription.Text = selectedAdvertisement.Description;
                //txtKoiFishId.Text = selectedAdvertisement.KoiFishId.ToString();
                //txtPostedBy.Text = selectedAdvertisement.PostedBy.ToString();
                txtCreatedAt.Text = selectedAdvertisement.CreatedAt.ToString("yyyy-MM-dd");
                txtUpdatedAt.Text = selectedAdvertisement.UpdatedAt?.ToString("yyyy-MM-dd");
                chkVerified.IsChecked = selectedAdvertisement.Verified;

                // Optional: Load related KoiFish and Account information
                if (selectedAdvertisement.KoiFish != null)
                {
                    txtKoiFishId.Text = selectedAdvertisement.KoiFish.KoiFishName;
                }

                if (selectedAdvertisement.PostedByNavigation != null)
                {
                    txtPostedBy.Text = selectedAdvertisement.PostedByNavigation.Username;
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();

            this.Hide();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
