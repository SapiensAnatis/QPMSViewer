using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFViewer.Model
{
    internal static class ModelData // I know global variables are a sin, but with MVVM the namespaces are seperate, so it's not as bad(?)
    {
        internal static string QP_Path { get; set; }
        internal static string MS_Path { get; set; }
    }
}
