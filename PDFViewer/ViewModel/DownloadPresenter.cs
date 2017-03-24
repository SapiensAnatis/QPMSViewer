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

        private string _WindowTitle = "eeee";
        public string WindowTitle // Helps to differentiate between QP and MS without having different DelegateCommands
        {
            get { return _WindowTitle; }
            set
            {
                _WindowTitle = value;
                //NotifyPropertyChanged("Title"); Not needed: we're not changing the property of any ObservableObjects here, just the window.
            }
        }

        public ICommand DownloadCommand // Fire Emblem: The Binding Blade
        {
            get
            {
                return new DelegateCommand(DownloadFile);
            }
        }

        public ICommand DownloadMSCommand // Fire Emblem: The Binding Blade
        {
            get
            {
                return new DelegateCommand(DownloadFile);
            }
        }

        private void DownloadFile()
        {
            System.Windows.MessageBox.Show($"The window title is {WindowTitle}.");
            if (WindowTitle == "Question paper") { _downloader.Download_PDF_TMP(URL, QP: true); }
            else if (WindowTitle == "Mark scheme") { _downloader.Download_PDF_TMP(URL, MS: true); }
            else { throw new InvalidOperationException("The data's purpose could not be inferred from the window title."); }
        }
    }
}
