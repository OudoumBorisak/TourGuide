using System.Windows;
using System.Windows.Controls;

namespace WPFTourGuide.Navigation
{
    /// <summary>
    /// Interaction logic for Content.xaml
    /// </summary>
    public partial class Content : UserControl
    {
        public Content()
        {
            InitializeComponent();
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
