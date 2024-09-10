using System.Windows;

namespace WPFTourGuide
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadLeftContent(); // Automatically load the UserControl
        }

        private void LoadLeftContent()
        {
            //create an instance of the Content UserControl
            var contentControl = new Navigation.Content();

            //Assign it to the LeftContentControl
            LeftContentControl.Content = contentControl;
        }
    }
}