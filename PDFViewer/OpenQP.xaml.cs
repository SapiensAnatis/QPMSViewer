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
            QP_FilepathTextBox.Text = BrowseForFilepath(".pdf", "Question papers |*.pdf|All files|*");
        }

        private void QP_ProceedButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Check that the filepaths and stuff are valid before we proceed. 
            // Also scan for mark scheme and only do the following if we can't find it

            var MSPrompt = new OpenMS(QP_Path);
            MSPrompt.Show();
            Close();
        }

        public static string BrowseForFilepath(string defaultExt, string filters)
        {
            Microsoft.Win32.OpenFileDialog OpenPDFDialogue = new Microsoft.Win32.OpenFileDialog(); // Win32

            OpenPDFDialogue.DefaultExt = defaultExt;
            OpenPDFDialogue.Filter = filters;

            bool? Result = OpenPDFDialogue.ShowDialog();

            if (Result.HasValue && Result.Value) // Perform validity checks
            {
                return OpenPDFDialogue.FileName;
            }
            else { return null; }
        }
    }
}
