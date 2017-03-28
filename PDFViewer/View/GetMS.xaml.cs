using System.ComponentModel;
using System.Windows;

namespace PDFViewer.View
{
    /// <summary>
    /// Interaction logic for GetMS.xaml
    /// </summary>
    public partial class GetMS : Window
    {
        public GetMS()
        {
            InitializeComponent();
            Closing += new CancelEventHandler(ViewModel.GetFilePresenter.Cleanup);
        }

        public string ResultantPath { get; set; }

        private void GetFileControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Once we're loaded, just clarify that this is the QP window for downloading purposes
            Title = "Mark scheme";
        }
    }
}
