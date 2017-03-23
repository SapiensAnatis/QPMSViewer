using System;
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
            MS_FilepathTextBox.Text = BrowseForFilepath(".pdf", "Mark schemes|*.pdf|All files|*");
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
