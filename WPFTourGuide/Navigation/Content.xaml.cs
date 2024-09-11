using System.Windows;
using System.Windows.Controls;

namespace WPFTourGuide.Navigation
{
    /// <summary>
    /// Interaction logic for Content.xaml
    /// </summary>
    public partial class Content : UserControl
    {
        private Dictionary<string, UserControl> _touristPoints; //list to store tourist points
        public Content()
        {
            InitializeComponent();
            // Initialize with some data
            LoadTouristPoints();
        }
        private void LoadTouristPoints()
        {
            _touristPoints = new Dictionary<string, UserControl>
            {
                { "Angkor Wat", new MainContent.AngkorWat() },
                { "Bali Beach", new MainContent.Bali() },
                { "Eiffel Tower", new MainContent.EiffelTower() },
                { "Big Ben", new MainContent.BigBen() },
                { "Venice", new MainContent.Venice() },
                { "Budapest", new MainContent.Budapest() },
                { "Garden By The Bay", new MainContent.GardenByTheBay() },
                { "Ha Long Bay", new MainContent.HaLongBay() }
            };
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var searchTerm = SearchTextBox.Text.ToLower();
            var results = _touristPoints
                .Where(tp => tp.Key.ToLower().Contains(searchTerm))
                .ToList();

            ResultsListBox.ItemsSource = results.Select(tp => tp.Key).ToList(); // Display only names
        }

        private void ResultsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ResultsListBox.SelectedItem != null)
            {
                var selectedItem = ResultsListBox.SelectedItem.ToString();
                if (_touristPoints.TryGetValue(selectedItem, out var userControl))
                {
                    var parentWindow = Window.GetWindow(this) as MainWindow;
                    if (parentWindow != null)
                    {
                        parentWindow.RightContentControl.Content = userControl;
                    }
                }
            }
        }
        private void SEAButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the parent window's ContentControl and switch the content to SEA UserControl
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.LeftContentControl.Content = new SEA();
            }
        }

        private void EuropeButton_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.LeftContentControl.Content = new Europe();
            }
        }
    }
}
