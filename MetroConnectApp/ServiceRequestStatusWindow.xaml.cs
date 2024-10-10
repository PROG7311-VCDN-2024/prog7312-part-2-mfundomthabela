using System.Collections.Generic;
using System.Windows;

namespace MetroConnectApp
{
    public partial class ServiceRequestStatusWindow : Window
    {
        private List<ServiceRequest> serviceRequests; // List to hold service requests

        public ServiceRequestStatusWindow()
        {
            InitializeComponent();
            LoadServiceRequests(); // Load service requests on initialization
        }

        private void LoadServiceRequests()
        {
            // Sample data for demonstration purposes
            serviceRequests = new List<ServiceRequest>
            {
                new ServiceRequest { RequestID = "REQ001", Status = "In Progress", Description = "Fixing the server issue." },
                new ServiceRequest { RequestID = "REQ002", Status = "Completed", Description = "Update on the application." },
                new ServiceRequest { RequestID = "REQ003", Status = "Pending", Description = "New feature request." }
            };

            lvServiceRequests.ItemsSource = serviceRequests; // Bind the list to the ListView
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            var filteredRequests = serviceRequests;

            // Filter the list based on the search text
            if (!string.IsNullOrWhiteSpace(searchText) && searchText != "search requests...")
            {
                filteredRequests = filteredRequests.FindAll(sr =>
                    sr.RequestID.ToLower().Contains(searchText) ||
                    sr.Status.ToLower().Contains(searchText) ||
                    sr.Description.ToLower().Contains(searchText));
            }

            lvServiceRequests.ItemsSource = filteredRequests; // Update ListView with filtered results
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the window when back button is clicked
        }

        // Event handler for GotFocus
        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "Search requests...")
            {
                txtSearch.Text = string.Empty; // Clear placeholder text on focus
                txtSearch.Foreground = System.Windows.Media.Brushes.Black; // Change text color to black
            }
        }

        // Event handler for LostFocus
        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search requests..."; // Reset placeholder text if nothing is entered
                txtSearch.Foreground = System.Windows.Media.Brushes.Gray; // Change text color to gray
            }
        }
    }

    // ServiceRequest class definition
    public class ServiceRequest
    {
        public string RequestID { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
