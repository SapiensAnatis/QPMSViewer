using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PDFViewer.ViewModel
{
    class PDFViewPresenter : ObservableObject
    {
        private static string QP_Path { get; set; }
        private static string MS_Path { get; set; }

        private static Window MainWindow { get; set; }

        public static void Start()
        {
            MainWindow = Application.Current.MainWindow;

            QP_Path = GetPathFromDialogue<View.GetQP>(new View.GetQP());
            MS_Path = GetPathFromDialogue<View.GetMS>(new View.GetMS());

            System.Windows.MessageBox.Show($"QP path: {QP_Path}; MS path: {MS_Path}");

            // Lcoal function: we want to do basically the same thing twice but this is a unique case and the function doesn't need to be exposed
            // (also new in C# 7.0)
            string GetPathFromDialogue<T>(T DialogIn)
            {
                dynamic Dialog = Convert.ChangeType(DialogIn, typeof(T));
                Dialog.ShowDialog();
                bool Result = Dialog.DialogResult ?? false;

                if (Result) { return Dialog.ResultantPath; }
                else {
                    MainWindow.Close();
                    Application.Current.Shutdown();
                    return null;
                }
            }
        }
    }
}
