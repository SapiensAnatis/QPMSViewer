using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PDFViewer.Model
{
    public class Download
    {
        private WebClient client;
        public string path = System.IO.Path.GetTempPath();

        public Download()
        {
            client = new WebClient();
        }

        public Download(string overrideDir)
        {
            client = new WebClient();
            path = overrideDir;
        }

        public string Download_PDF_TMP(string url, string filename)
        {
            client.DownloadFile(url, path + filename + ".pdf");
            return path + filename + ".pdf";
        }
    }
}
