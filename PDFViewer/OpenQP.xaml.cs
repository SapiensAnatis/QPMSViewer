using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PDFViewer
{
    /// <summary>
    /// Interaction logic for Open.xaml
    /// </summary>
    public partial class OpenQP : Window
    {
        private string QP_Path
        {
            get
            {
                if (!QP_Use_URL.IsChecked.HasValue) { QP_Use_URL.IsChecked = false; } // Prepare for safe casting
                if (!QP_UseFilepath.IsChecked.HasValue) { QP_UseFilepath.IsChecked = false; }

                if ((bool)QP_UseFilepath.IsChecked) { return QP_FilepathTextBox.Text; }
                else if ((bool)QP_Use_URL.IsChecked) { return QP_DownloadedTo_Path ?? "Not yet downloaded"; }
                else { return null; }
            }
        }

        public string QP_DownloadedTo_Path { get; set; }

        public OpenQP()
        {
            InitializeComponent();
        }

        private void QP_BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            QP_FilepathTextBox.Text = App.FileGrabbingUtils.BrowseForFilepath(".pdf", "Question papers |*.pdf|All files|*");
        }

        private async void QP_ProceedButton_Click(object sender, RoutedEventArgs e)
        {
            if (!QP_Use_URL.IsChecked.HasValue) { QP_Use_URL.IsChecked = false; } // Prepare for cast by preventing InvalidOperationException
            if ((bool)QP_Use_URL.IsChecked)
            {
                QP_DownloadGrid.Visibility = Visibility.Visible;
                using (var WC = new WebClient())
                {
                    WC.DownloadProgressChanged += QP_DownloadProgressUpdate;
                    await WC.DownloadFileTaskAsync(new Uri(QP_URL_TextBox.Text), System.IO.Path.GetTempPath() + "QP.pdf");
                    QP_DownloadedTo_Path = System.IO.Path.GetTempPath() + "QP.pdf"; // now that it's downloaded we can safely put it there
                }
            }

            // TODO: Check that the filepaths and stuff are valid before we proceed. 
            // Also scan for mark scheme and only do the following if we can't find it

            var MSPrompt = new OpenMS(QP_Path);
            MSPrompt.Show();
            Close();
        }

        private void QP_DownloadProgressUpdate(object sender, DownloadProgressChangedEventArgs e)
        {
            QP_URL_ProgressBar.Value = e.ProgressPercentage;
            double KBDownloaded = ((double)e.BytesReceived) / 1000;
            double KBToDownload = ((double)e.TotalBytesToReceive) / 1000;
            KBDownloaded = Math.Round(KBDownloaded, 0);
            KBToDownload = Math.Round(KBToDownload, 0);

            QP_URL_ProgressLabel.Content = $"{KBDownloaded}/{KBToDownload} KB";
        }

        
    }
}
