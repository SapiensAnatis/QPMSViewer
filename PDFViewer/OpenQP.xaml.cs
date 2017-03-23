using System;
using System.Windows;

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
                if ((bool)QP_UseFilepath.IsChecked) { return QP_FilepathTextBox.Text; }
                else if ((bool)QP_Use_URL.IsChecked) { return QP_URL_TextBox.Text; }
                else { return null; }
            }
        }

        public OpenQP()
        {
            InitializeComponent();
        }

        private void QP_BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            QP_FilepathTextBox.Text = App.FileGrabbingUtils.BrowseForFilepath(".pdf", "Question papers |*.pdf|All files|*");
        }

        private void QP_ProceedButton_Click(object sender, RoutedEventArgs e)
        {


            // TODO: Check that the filepaths and stuff are valid before we proceed. 
            // Also scan for mark scheme and only do the following if we can't find it

            var MSPrompt = new OpenMS(QP_Path);
            MSPrompt.Show();
            Close();
        }

        
    }
}
