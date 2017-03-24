using System;
using System.Net;
using System.Windows;


/* Naming conventions:
 * CamelCase (ThisIsAnExample) with underscores to differentiate between events and acronyms
 * e.g. MS_BrowseButton_Click - MS is an acronum, and Click is the event
 * local variables may be in lowercase
*/

namespace PDFViewer.View
{
    /// <summary>
    /// Interaction logic for Open.xaml
    /// </summary>
    public partial class OpenMS : Window
    {
        public OpenMS()
        {
            InitializeComponent();
        }
    }
}
