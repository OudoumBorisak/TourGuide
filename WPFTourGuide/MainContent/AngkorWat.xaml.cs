using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPFTourGuide.MainContent
{
    /// <summary>
    /// Interaction logic for AngkorWat.xaml
    /// </summary>
    public partial class AngkorWat : UserControl
    {
        public AngkorWat()
        {
            InitializeComponent();
        }

        //saves to the default working directory of the application
        private void SaveToPDFButton_Click(object sender, RoutedEventArgs e)
        {
            var bitmap = RenderUserControlToBitmap(this, (int)ActualWidth, (int)ActualHeight);

            // Create a new PDF document
            var document = new PdfDocument();
            document.Info.Title = "Angkor Wat Temple";

            // Create an empty page
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            // Save the Bitmap to a file
            string tempImagePath = "temp_image.png";
            bitmap.Save(tempImagePath, System.Drawing.Imaging.ImageFormat.Png);

            // Load the image from the file
            var image = XImage.FromFile(tempImagePath);

            // Draw the image on the PDF page
            gfx.DrawImage(image, 0, 0, page.Width, page.Height);

            // Save the document
            string filename = "AngkorWat.pdf";
            document.Save(filename);

            // Clean up
            File.Delete(tempImagePath);

            MessageBox.Show("PDF saved successfully!");
        }

        private System.Drawing.Bitmap RenderUserControlToBitmap(UserControl control, int width, int height)
        {
            var renderBitmap = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);
            var visualBrush = new VisualBrush(control);
            var drawingVisual = new DrawingVisual();

            using (var drawingContext = drawingVisual.RenderOpen())
            {
                // Explicitly specify the namespace for Point and Size
                drawingContext.DrawRectangle(visualBrush, null, new System.Windows.Rect(new System.Windows.Point(), new System.Windows.Size(width, height)));
            }

            renderBitmap.Render(drawingVisual);

            using (var ms = new MemoryStream())
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                encoder.Save(ms);
                return new System.Drawing.Bitmap(ms);
            }
        }
    }
}
