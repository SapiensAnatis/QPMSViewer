using System.ComponentModel;
using System.Windows;

namespace PDFViewer.View
{
    /// <summary>
    /// Interaction logic for GetQP.xaml
    /// </summary>
    public partial class GetQP : Window
    {
        public GetQP()
        {
            InitializeComponent();
            Closing += new CancelEventHandler(ViewModel.DownloadPresenter.Cleanup);
        }

        private void GetFileControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Once we're loaded, just clarify that this is the QP window for downloading purposes
            Title = "Question paper";
        }
    }
}
