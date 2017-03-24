using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
        }

        private void GetFileControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Once we're loaded, just clarify that this is the QP window for downloading purposes
            Title = "Question paper";
        }
    }
}
