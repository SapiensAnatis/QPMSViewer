using PDFViewer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PDFViewer.ViewModel
{
    class Presenter : ObservableObject
    {
        private readonly Download _downloader = new Download();

        private string _URL = "Enter a URL to download...";
        public string URL // Represents the text box's URL property
        {
            get
            {
                return _URL;
            }
            set
            {
                _URL = value;
                NotifyPropertyChanged("URL");
            }
        }

        public ICommand DownloadMSCommand
        {
            get { return new DelegateCommand(DownloadMS); }
        }

        public ICommand DownloadQPCommand
        {
            get {
                System.Windows.MessageBox.Show("Test");
                return new DelegateCommand(DownloadQP);
            }
        }

        private void DownloadQP()
        {
            // TODO: Perform URL validation here
            System.Windows.MessageBox.Show("Test");
            _downloader.Download_PDF_TMP(URL, "QP");
        }

        private void DownloadMS()
        {
            // TODO: Perform URL validation here
            _downloader.Download_PDF_TMP(URL, "MS");
        }
    }
}
