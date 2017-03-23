using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PDFViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static class FileGrabbingUtils
        {
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
}
