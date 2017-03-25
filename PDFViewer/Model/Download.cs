using System;
using System.Net;
using System.Text.RegularExpressions;

namespace PDFViewer.Model
{
    public class Download
    {
        private WebClient WC;
        private string FolderPath = System.IO.Path.GetTempPath();

        public Download()
        {
            WC = new WebClient();
        }

        public Download(string overrideDir)
        {
            WC = new WebClient();
            FolderPath = overrideDir;
        }

        public string Check_URL_IsValid(string url) // We will call this in our VM so we can tell the user if there's an issue
        {
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "HEAD";
            var response = request.GetResponse();
            return "OK!"; // We will also handle exceptions in the VM to show the users more info.
        }

        public void Download_PDF_TMP(string url, bool MS = false, bool QP = false)
        {
            string Filename;

            if (QP) { Filename = "QP.pdf"; }
            else if (MS) { Filename = "MS.pdf"; }
            else { throw new System.InvalidOperationException("Illegally attempted to download file that was neither a mark scheme nor question paper."); }

            WC.DownloadFile(url, FolderPath + Filename);
        }
    }
}
