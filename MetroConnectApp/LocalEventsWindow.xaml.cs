using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MetroConnectApp
{
    public partial class LocalEventsWindow : Window
    {
        private List<Event> events; // List to hold the events

        public LocalEventsWindow(List<Event> events)
        {
            InitializeComponent();
            this.events = events; // Initialize with passed events
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string selectedCategory = (cmbCategory.SelectedItem as ComboBoxItem)?.Content.ToString();
            string searchText = txtSearch.Text.Trim();

            // Filter the events based on the selected category and search text
            var filteredEvents = new List<Event>();
            foreach (var eventItem in events)
            {
                if ((selectedCategory == "All Categories" || eventItem.Category == selectedCategory) &&
                    eventItem.Name.ToLower().Contains(searchText.ToLower()))
                {
                    filteredEvents.Add(eventItem);
                }
            }

            lvEvents.ItemsSource = filteredEvents; // Update the ListView with filtered events
        }

        // Other event handler methods like txtSearch_GotFocus and txtSearch_LostFocus remain unchanged...
    }
}
