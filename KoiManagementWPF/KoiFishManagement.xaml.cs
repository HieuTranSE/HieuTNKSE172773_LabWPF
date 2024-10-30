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
    /// Interaction logic for KoiFishManagement.xaml
    /// </summary>
    public partial class KoiFishManagement : Window
    {
        private KoiFishService _koiService;
        private FengshuiElementService _fengshuiElementService;

        public KoiFishManagement()
        {
            InitializeComponent();

            _koiService = new KoiFishServiceImpl();
            _fengshuiElementService = new FengshuiElementServiceImpl();

            LoadKoiFishes();
            LoadFengshuiElements();
        }
        private void LoadFengshuiElements()
        {
            cbbFengShuiElement.ItemsSource = _fengshuiElementService.GetAllFengShuiElements(); ;
        }
        private void LoadKoiFishes()
        {      
            KoiFishGrid.ItemsSource = _koiService.GetAllKoiFish();
        }

        private void tb_koifish_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {        
                if (KoiFishGrid.SelectedItem is KoiFish selectedKoiFish)
                {
                    txtKoiFishName.Text = selectedKoiFish.KoiFishName;
                    txtKoiFishColor.Text = selectedKoiFish.KoiFishColor;
                    txtKoiFishSize.Text = selectedKoiFish.KoiFishSize.ToString();
                    txtKoiFishAge.Text = selectedKoiFish.KoiFishAge.ToString();
                    txtSymbolicMeaning.Text = selectedKoiFish.SymbolicMeaning;
                    txtEnergyType.Text = selectedKoiFish.EnergyType;
                    txtFavorableNumber.Text = selectedKoiFish.FavorableNumber?.ToString(); // Nullable
                    txtOrigin.Text = selectedKoiFish.Origin;
                    txtPrice.Text = selectedKoiFish.Price.ToString();
                    cbbFengShuiElement.SelectedValue = selectedKoiFish.FengShuiElementId;
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Input validation
                if (string.IsNullOrWhiteSpace(txtKoiFishName.Text))
                {
                    MessageBox.Show("Koi Fish Name is required.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtKoiFishColor.Text))
                {
                    MessageBox.Show("Koi Fish Color is required.");
                    return;
                }

                if (!decimal.TryParse(txtKoiFishSize.Text, out decimal koiFishSize))
                {
                    MessageBox.Show("Invalid size. Please enter a valid number.");
                    return;
                }

                if (!int.TryParse(txtKoiFishAge.Text, out int koiFishAge))
                {
                    MessageBox.Show("Invalid age. Please enter a valid number.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSymbolicMeaning.Text))
                {
                    MessageBox.Show("Symbolic Meaning is required.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEnergyType.Text))
                {
                    MessageBox.Show("Energy Type is required.");
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Invalid price. Please enter a valid number.");
                    return;
                }

                if (cbbFengShuiElement.SelectedValue == null)
                {
                    MessageBox.Show("Please select a Feng Shui Element.");
                    return;
                }

                // Creating a new KoiFish object
                KoiFish koiFish = new KoiFish()
                {
                    KoiFishName = txtKoiFishName.Text,
                    KoiFishColor = txtKoiFishColor.Text,
                    KoiFishSize = koiFishSize,
                    KoiFishAge = koiFishAge,
                    SymbolicMeaning = txtSymbolicMeaning.Text,
                    EnergyType = txtEnergyType.Text,
                    FavorableNumber = int.TryParse(txtFavorableNumber.Text, out int favorableNumber) ? (int?)favorableNumber : null,
                    Origin = txtOrigin.Text,
                    Price = price,
                    FengShuiElementId = (int) cbbFengShuiElement.SelectedValue
                };

                // Add the KoiFish to the repository
                bool isAdded = _koiService.AddKoiFish(koiFish);

                if (isAdded)
                {
                    MessageBox.Show("Koi Fish added successfully!");

                    // Reload Koi Fish data and clear the input fields
                    LoadKoiFishes();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Failed to add Koi Fish.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ClearInputFields()
        {
            txtKoiFishName.Clear();
            txtKoiFishColor.Clear();
            txtKoiFishSize.Clear();
            txtKoiFishAge.Clear();
            txtSymbolicMeaning.Clear();
            txtEnergyType.Clear();
            txtFavorableNumber.Clear();
            txtOrigin.Clear();
            txtPrice.Clear();
            cbbFengShuiElement.SelectedIndex = -1;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if a KoiFish is selected in the DataGrid
                if (KoiFishGrid.SelectedItem is KoiFish selectedKoiFish)
                {
                    // Validate input fields
                    if (string.IsNullOrWhiteSpace(txtKoiFishName.Text) ||
                        string.IsNullOrWhiteSpace(txtKoiFishColor.Text) ||
                        !decimal.TryParse(txtKoiFishSize.Text, out decimal koiFishSize) ||
                        !int.TryParse(txtKoiFishAge.Text, out int koiFishAge) ||
                        string.IsNullOrWhiteSpace(txtSymbolicMeaning.Text) ||
                        string.IsNullOrWhiteSpace(txtEnergyType.Text) ||
                        !int.TryParse(txtFavorableNumber.Text, out int favorableNumber) ||
                        string.IsNullOrWhiteSpace(txtOrigin.Text) ||
                        !decimal.TryParse(txtPrice.Text, out decimal price) ||
                        cbbFengShuiElement.SelectedIndex == null)
                    {
                        MessageBox.Show("Please fill out all fields correctly.");
                        return;
                    }

                    // Update the selected KoiFish with new values
                    selectedKoiFish.KoiFishName = txtKoiFishName.Text;
                    selectedKoiFish.KoiFishColor = txtKoiFishColor.Text;
                    selectedKoiFish.KoiFishSize = koiFishSize;
                    selectedKoiFish.KoiFishAge = koiFishAge;
                    selectedKoiFish.SymbolicMeaning = txtSymbolicMeaning.Text;
                    selectedKoiFish.EnergyType = txtEnergyType.Text;
                    selectedKoiFish.FavorableNumber = favorableNumber;
                    selectedKoiFish.Origin = txtOrigin.Text;
                    selectedKoiFish.Price = price;
                    selectedKoiFish.FengShuiElementId = (int) cbbFengShuiElement.SelectedIndex;

                    // Save changes in the KoiFish repository
                    _koiService.UpdateKoiFish(selectedKoiFish);

                    MessageBox.Show("Koi fish updated successfully!");
                }
                else
                {
                    MessageBox.Show("Please select a Koi fish to update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                // Reload the KoiFish list and clear the input fields
                LoadKoiFishes();
                ClearInputFields();
            }
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if a KoiFish is selected in the DataGrid
                if (KoiFishGrid.SelectedItem is KoiFish selectedKoiFish)
                {
                    // Confirm deletion
                    MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete '{selectedKoiFish.KoiFishName}'?",
                        "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        // Delete the KoiFish
                        _koiService.DeleteKoiFish(selectedKoiFish.KoiFishId);
                        MessageBox.Show("Koi fish deleted successfully!");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a Koi fish to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                // Reload the KoiFish list and clear the input fields
                LoadKoiFishes();
                ClearInputFields();
            }
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();

            this.Hide();
        }
    }
}
