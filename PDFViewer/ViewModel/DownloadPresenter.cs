using PDFViewer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PDFViewer.ViewModel
{
    class DownloadPresenter : ObservableObject
    {
        private readonly Download _downloader = new Download();

        private string _URL = "http://pmt.physicsandmathstutor.com/download/Maths/A-level/M1/Papers-Edexcel/January%202013%20QP%20-%20M1%20Edexcel.pdf";
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

        public ICommand DownloadFileCommand // Fire Emblem: The Binding Blade
        {
            get { System.Windows.MessageBox.Show("hacking"); return new DelegateCommand(DownloadFile); }
        }

        private void DownloadFile()
        {
            System.Windows.MessageBox.Show("actually hacking");
            _downloader.Download_PDF_TMP(URL);
        }
    }
}
