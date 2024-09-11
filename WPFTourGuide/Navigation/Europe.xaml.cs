using System.Windows;
using System.Windows.Controls;
using WPFTourGuide.MainContent;

namespace WPFTourGuide.Navigation
{
    /// <summary>
    /// Interaction logic for Europe.xaml
    /// </summary>
    public partial class Europe : UserControl
    {
        public Europe()
        {
            InitializeComponent();
        }

        private void BigBenButton_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.RightContentControl.Content = new BigBen();
            }
        }

        private void BudapestButton_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.RightContentControl.Content = new Budapest();
            }
        }

        private void EiffelTower_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.RightContentControl.Content = new EiffelTower();
            }
        }

        private void VeniceButton_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                parentWindow.RightContentControl.Content = new Venice();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;
            if (parentWindow != null)
            {
                // Navigate back to the previous content
                parentWindow.LeftContentControl.Content = new Content();
            }
        }
    }
}
