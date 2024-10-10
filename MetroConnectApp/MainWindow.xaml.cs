using System.Windows;

namespace MetroConnectApp
{
    public partial class MainWindow : Window
    {
        private List<Issue> Issues { get; set; } = new List<Issue>();
        private List<Event> Events { get; set; } = new List<Event>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ViewReportsButton_Click(object sender, RoutedEventArgs e)
        {
            ViewReportsWindow reportsWindow = new ViewReportsWindow(IssueRepository.GetReportedIssues());
            reportsWindow.ShowDialog();
        }

        private void ReportIssuesButton_Click(object sender, RoutedEventArgs e)
        {
            ReportIssuesWindow reportWindow = new ReportIssuesWindow();
            reportWindow.Show();
        }

        private void LocalEventsButton_Click(object sender, RoutedEventArgs e)
        {
            LocalEventsWindow localEventsWindow = new LocalEventsWindow();
            localEventsWindow.Show();
        }

        private void ServiceRequestButton_Click(object sender, RoutedEventArgs e)
        {
            ServiceRequestStatusWindow serviceStatusWindow = new ServiceRequestStatusWindow();
            serviceStatusWindow.Show();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
