using System;
using System.Net;
using System.Windows;


/* Naming conventions:
 * CamelCase (ThisIsAnExample) with underscores to differentiate between events and acronyms
 * e.g. MS_BrowseButton_Click - MS is an acronum, and Click is the event
 * local variables may be in lowercase
*/

namespace PDFViewer
{
    /// <summary>
    /// Interaction logic for Open.xaml
    /// </summary>
    public partial class OpenMS : Window
    {
        public string QP_Path { get; set; }
        public string MS_DownloadedTo_Path { get; set; }

        private string MS_Path
        {
            get
            {
                if ((bool)MS_UseFilepath.IsChecked) { return MS_FilepathTextBox.Text; }
                else if ((bool)MS_Use_URL.IsChecked) { return MS_URL_TextBox.Text; }
                else { return null; }
            }
        }

        public OpenMS(string QP_Path_In)
        {
            InitializeComponent();
            QP_Path = QP_Path_In;
        }

        private void MS_BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            MS_FilepathTextBox.Text = App.FileGrabbingUtils.BrowseForFilepath(".pdf", "Mark schemes|*.pdf|All files|*");
        }

        private async void MS_ProceedButton_Click(object sender, RoutedEventArgs e)
        {
            if (!MS_Use_URL.IsChecked.HasValue) { MS_Use_URL.IsChecked = false; } // Prepare for cast by preventing InvalidOperationException
            if ((bool)MS_Use_URL.IsChecked)
            {
                MS_DownloadGrid.Visibility = Visibility.Visible;
                using (var WC = new WebClient())
                {
                    WC.DownloadProgressChanged += MS_DownloadProgressUpdate;
                    await WC.DownloadFileTaskAsync(new Uri(MS_URL_TextBox.Text), System.IO.Path.GetTempPath() + "MS.pdf");
                    // TODO: Input validation on URI
                    MS_DownloadedTo_Path = System.IO.Path.GetTempPath() + "MS.pdf"; // now that it's downloaded we can safely put it there
                }
            }
        }

        private void MS_DownloadProgressUpdate(object sender, DownloadProgressChangedEventArgs e)
        {
            MS_URL_ProgressBar.Value = e.ProgressPercentage;
            double KBDownloaded = ((double)e.BytesReceived) / 1000;
            double KBToDownload = ((double)e.TotalBytesToReceive) / 1000;
            KBDownloaded = Math.Round(KBDownloaded, 0);
            KBToDownload = Math.Round(KBToDownload, 0);

            MS_URL_ProgressLabel.Content = $"{KBDownloaded}/{KBToDownload} KB";
        }
    }
}
