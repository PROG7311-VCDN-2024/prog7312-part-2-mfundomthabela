using System;
using System.Collections.Generic;
using System.Windows;

namespace MetroConnectApp
{
    public partial class ViewReportsWindow : Window
    {
        private List<Report> reports; // Store submitted reports

        public ViewReportsWindow(List<Report> reports)
        {
            InitializeComponent();
            this.reports = reports; // Initialize with passed reports
            LoadReports(); // Load reports on initialization
        }

        private void LoadReports()
        {
            lvReports.ItemsSource = reports; // Bind reports to ListView
        }

        // Handle the button click to submit the report
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var requestId = Guid.NewGuid().ToString(); // Generate a unique RequestID
            var report = new Report
            {
                RequestID = requestId,
                Description = txtDescription.Text,
                MediaPath = txtMediaPath.Text // Assume a TextBox for media path input
            };

            // Add the report to the list
            reports.Add(report);
            LoadReports(); // Refresh the ListView

            // Show confirmation message
            MessageBox.Show($"Report submitted with Request ID: {requestId}");
        }

        // Handle the Back to Menu button click
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the ViewReportsWindow
        }
    }

    public class Report
    {
        public string RequestID { get; set; }
        public string Description { get; set; }
        public string MediaPath { get; set; } // Path to the media file
    }
}
