using PDFViewer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public static void Cleanup(object sender, CancelEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private string _WindowTitle = "Undefined";
        public string WindowTitle // Helps to differentiate between QP and MS without having different DelegateCommands
        {
            get { return _WindowTitle; }
            set
            {
                _WindowTitle = value;
                //NotifyPropertyChanged("Title"); Not needed: we're not changing the property of any ObservableObjects here, just the window.
            }
        }

        private bool IsQP
        {
            get { return (WindowTitle == "Question paper"); }
        }

        private bool IsMS
        {
            get { return (WindowTitle == "Mark scheme"); }
        }

        public ICommand DownloadCommand // Fire Emblem: The Binding Blade
        {
            get { return new DelegateCommand(DownloadFile); }
        }
        
        private void DownloadFile()
        {
            // This is a placeholder for more responsive error handling later
            try
            {
                if (string.IsNullOrEmpty(URL)) // Validate URL with the simplest measures
                    { throw new UriFormatException("The URL text box was empty!"); }

                // Now: our actual download code. Lots of potential for exceptions, which will be handled below.
                System.Windows.MessageBox.Show($"Response: {_downloader.Check_URL_IsValid(URL)}");

                if (!(IsQP || IsMS)) { throw new InvalidOperationException("The data's purpose could not be inferred from the window title."); }
                //MessageBox.Show($"Time to go! IsQP = {IsQP}, IsMS = {IsMS}.");
                _downloader.Download_PDF_TMP(URL, QP: IsQP, MS: IsMS);

                // Once completed, close the window and advance to the next step
               
                var AllWindows = Application.Current.Windows;
                if (IsQP)
                {
                    var QPWindow = AllWindows.OfType<View.GetQP>().Single();
                    var MSWindow = new View.GetMS();
                    MSWindow.Show();
                    QPWindow.Close();
                }
                if (IsMS)
                {
                    var MSWindow = AllWindows.OfType<View.GetMS>().Single();
                    MSWindow.Close();
                }
                
            }
            catch (UriFormatException ex)
            {
                MessageBox.Show($"The URL you provided was invalid. Error information: {ex.Message}");
            }
            catch (WebException ex)
            {
                // How to get the status code feat stackoverflow
                HttpWebResponse error = (ex.Response as HttpWebResponse);
                MessageBox.Show($"Web request returned an erorr! Error information: \"{error.StatusCode.ToString()}: {error.StatusDescription}\"\nIt is likely that either the site is down or your URL was validly formatted but pointed to an inaccessible or non-existent web resource.");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("The program could not figure out whether it was a mark scheme or question paper being downloaded. Please report this (because it isn't your fault).\n" +
                    $"WindowTitle = {WindowTitle}, IsQP = {IsQP}, IsMS = {IsMS}");
            }
            
        }

  
    }
}
