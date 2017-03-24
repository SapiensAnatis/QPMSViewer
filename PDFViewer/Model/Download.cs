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
