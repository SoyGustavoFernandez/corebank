using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using Microsoft.Office.Interop.Word;

namespace RCP.Presentacion
{
    public partial class frmVisualizarDocRecuperaciones : frmBase
    {
        public string cRutaNombre, cRutaNombreAnt,cRutaOrigen;
        public string cRuta { get; set; }
        public string nombreArchivo { get; set; }
        public string extencion { get; set; }

        public frmVisualizarDocRecuperaciones()
        {
            InitializeComponent();
        }

        public frmVisualizarDocRecuperaciones(string _cRuta, string _nombreArchivo, string _extencion)
        {
            InitializeComponent();
            cRuta = _cRuta;
            nombreArchivo = _nombreArchivo;
            extencion = _extencion;
           
        }

        public void KillAppWord()
        {
            System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName("WINWORD");
            for (int i = 0; i < p.Length; i++)
            {
                try
                {
                    p[i].Kill();
                    p[i].WaitForExit(1000);
                }
                catch (Exception ex)
                {
                        continue;
                }
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        }

        private void frmVisualizarDocRecuperaciones_Load(object sender, EventArgs e)
        {
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(777, 407);
            this.webBrowser1.TabIndex = 2;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.Controls.Add(this.webBrowser1);
            this.Controls.SetChildIndex(this.webBrowser1, 0);
            // 



            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            cRutaOrigen = cRuta;
            cRuta = cRuta + "\\" + nombreArchivo;// + "." + extencion;
            this.Text = nombreArchivo;
            cRutaNombreAnt = cRuta;
            if (cRuta.Length != 0 && (extencion.ToUpper().Equals(".DOC") || extencion.ToUpper().Equals(".DOCX")))
            {
                Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                Document doc = word.Documents.Open(cRuta, ReadOnly: true);
                doc.Activate();
                cRuta = cRuta.Replace(extencion, ".pdf");
                doc.SaveAs(cRuta, WdSaveFormat.wdFormatPDF);
                object saveChanges = WdSaveOptions.wdDoNotSaveChanges;
                ((_Document)doc).Close(ref saveChanges);
                doc = null;
                ((_Application)word).Quit();
                word = null;
            }
            FileInfo fileInfo = new FileInfo(cRuta);
            if (extencion.ToUpper().Equals(".PDF"))
            {
                cRuta = cRuta + "#toolbar=0&navpanes=0";
            }
            webBrowser1.Navigate(cRuta, false);
        }

        private void frmVisualizarDocRecuperaciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                int count = webBrowser1.Document.Cookie.Length;
                webBrowser1.Document.Cookie.Remove(0, count);

                string cIndice = cRutaNombreAnt.Substring(cRutaNombreAnt.LastIndexOf("."));
                if (File.Exists(cRutaNombreAnt) && (cIndice.ToUpper().Equals(".DOC") || cIndice.ToUpper().Equals(".DOCX")))
                {
                    KillAppWord();
                    File.Delete(cRutaNombreAnt);
                }
            }
            catch (Exception ex)
            {
                ;
            }
        }
    }

    
}
