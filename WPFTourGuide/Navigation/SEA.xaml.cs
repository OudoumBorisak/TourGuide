using System.Windows;
using System.Windows.Controls;
using WPFTourGuide.MainContent;

namespace WPFTourGuide.Navigation
{
    /// <summary>
    /// Interaction logic for SEA.xaml
    /// </summary>
    public partial class SEA : UserControl
    {
        public SEA()
        {
            InitializeComponent();
        }

        private void AngkorWatButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the parent window's ContentControl and switch the content to Cambodia UserControl
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.RightContentControl.Content = new AngkorWat();
            }
        }

        private void BaliButton_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.RightContentControl.Content = new Bali();
            }
        }

        private void HaLongBayButton_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.RightContentControl.Content = new HaLongBay();
            }
        }

        private void GardenByTheBayButton_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.RightContentControl.Content = new GardenByTheBay();
            }
        }
    }
}
