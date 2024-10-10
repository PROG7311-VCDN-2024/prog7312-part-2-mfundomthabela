using System;
using System.Windows;

namespace MetroConnectApp
{
    /// <summary>
    /// Interaction logic for StartupWindow.
    /// </summary>
    public partial class StartupWindow : Window
    {
        public StartupWindow()
        {
            InitializeComponent();
        }

   
        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            
            // Create and show the MainWindow
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close(); // Close the startup window
        }

 
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // This will shutdown the application
        }
    }
}
