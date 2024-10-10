using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Microsoft.Win32;

namespace MetroConnectApp
{
    public partial class ReportIssuesWindow : Window
    {
        public ReportIssuesWindow()
        {
            InitializeComponent();
        }

        // Method to get the description from the RichTextBox
        public string GetIssueDescription()
        {
            var issueDescription = new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text;
            return string.IsNullOrWhiteSpace(issueDescription) ? string.Empty : issueDescription.Trim();
        }

        // Event handler for TextBox GotFocus to remove placeholder
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtLocationPlaceholder.Visibility == Visibility.Visible)
            {
                txtLocationPlaceholder.Visibility = Visibility.Collapsed;
            }
        }

        // Event handler for TextBox LostFocus to show placeholder if empty
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                txtLocationPlaceholder.Visibility = Visibility.Visible;
            }
        }

        // Event handler for TextBox TextChanged to manage placeholder visibility
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtLocationPlaceholder.Visibility = string.IsNullOrWhiteSpace(txtLocation.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        // Event handler for RichTextBox GotFocus to remove placeholder
        private void RichTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (rtbDescriptionPlaceholder.Visibility == Visibility.Visible)
            {
                rtbDescriptionPlaceholder.Visibility = Visibility.Collapsed;
            }
        }

        // Event handler for RichTextBox LostFocus to show placeholder if empty
        private void RichTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var issueDescription = new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text;
            if (string.IsNullOrWhiteSpace(issueDescription))
            {
                rtbDescriptionPlaceholder.Visibility = Visibility.Visible;
            }
        }

        // Event handler for RichTextBox TextChanged to manage placeholder visibility
        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var issueDescription = new TextRange(rtbDescription.Document.ContentStart, rtbDescription.Document.ContentEnd).Text;
            rtbDescriptionPlaceholder.Visibility = string.IsNullOrWhiteSpace(issueDescription) ? Visibility.Visible : Visibility.Collapsed;
        }

        // Event handler for the Submit button
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string location = txtLocation.Text;
            string category = (cmbCategory.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "No Category Selected"; // Handle null safely
            string description = GetIssueDescription();

            MessageBox.Show($"Issue reported:\nLocation: {location}\nCategory: {category}\nDescription: {description}");

            // Clear the fields after submission
            txtLocation.Text = string.Empty;
            cmbCategory.SelectedIndex = 0;
            rtbDescription.Document.Blocks.Clear();
            txtLocationPlaceholder.Visibility = Visibility.Visible;
            rtbDescriptionPlaceholder.Visibility = Visibility.Visible;
        }

        // Event handler for View Reports button
        private void BtnViewReports_Click(object sender, RoutedEventArgs e)
        {
            ViewReportsWindow viewReportsWindow = new ViewReportsWindow();
            viewReportsWindow.Show();
            this.Close();
        }

        // Event handler for the Back button to go back to main menu
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Event handler for Attach Media button (new)
        private void BtnAttachMedia_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select Media File",
                Filter = "Image Files|*.jpg;*.jpeg;*.png|Video Files|*.mp4;*.mov|All Files|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                MessageBox.Show($"Attached file: {openFileDialog.FileName}");
            }
        }
    }
}
