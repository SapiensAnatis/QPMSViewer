using System;
using System.Net;
using System.Text.RegularExpressions;

namespace PDFViewer.Model
{
    public class Download
    {
        private WebClient WC;
        private string FolderPath;

        public Download()
        {
            WC = new WebClient();
            if (Properties.Settings.Default.StorePerm)
            {
                FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Downloaded Past Papers\\";
                // CreateDirecoty does not create if the dir already exists, so there's no point checking first:
                System.IO.Directory.CreateDirectory(FolderPath);
            }
            else { FolderPath = System.IO.Path.GetTempPath(); }
        }

        public Download(string overrideDir)
        {
            WC = new WebClient();
            FolderPath = overrideDir;
        }

        public string Check_URL_IsValid(string url) // Exceptions are handled in the VM to better communicate them to users.
        {
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "HEAD";
            var response = request.GetResponse();
            response.Close(); // You must close the response otherwise the next request will hang due to an active request.
                              // Because GetResponse() throws the exceptions we need to perform validation, we can do this directly after.
            return "OK!";
        }

        public string Download_PDF_TMP(string url, bool MS = false, bool QP = false)
        {
            string Filename;

            if (QP) { Filename = "QP.pdf"; }
            else if (MS) { Filename = "MS.pdf"; }
            else { throw new System.InvalidOperationException("Illegally attempted to download file that was neither a mark scheme nor question paper."); }
            string FinalPath = FolderPath + Filename;
            WC.DownloadFile(url, FinalPath);
            return FinalPath;
        }
    }
}
