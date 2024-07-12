using EntityLayer;
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

namespace CNT.Presentacion
{
    public partial class frmVistaPreviaNotasEEFF : Form
    {

      
        private string pnombreArchivo { get; set; }
        private byte[] pcValorPDF { get; set; }
        private string pextencion { get; set; }
        public frmVistaPreviaNotasEEFF()
        {
            InitializeComponent();
        }
        public frmVistaPreviaNotasEEFF(byte[] cValorPDF,string nombreArchivo,string extencion)
        {
            InitializeComponent();
            pnombreArchivo  = nombreArchivo;
            pcValorPDF      = cValorPDF;
            pextencion      = extencion;
        }
        private void frmVistaPreviaNotasEEFF_Load(object sender, EventArgs e)
        {
         
            //webBrowser1.IsWebBrowserContextMenuEnabled = false;
            webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
    
            string cDirectorioRiesgos = "Contabilidad";
            //string cDirectorio = String.Format("{0}\\{1}", clsVarGlobal.cRutPathApp, cDirectorioRiesgos);
            string cDirectorio = String.Format("{0}\\{1}", "C:", cDirectorioRiesgos);

            if (!Directory.Exists(cDirectorio))
            {
                Directory.CreateDirectory(cDirectorio);
            }

            string cRuta = String.Format("{0}\\{1}", cDirectorio, pnombreArchivo);
            FileInfo fileInfo = new FileInfo(cRuta);
            File.WriteAllBytes(cRuta, pcValorPDF);


            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        
            this.Text = pnombreArchivo;

            if (pextencion.ToUpper().Equals(".PDF"))
            {
                cRuta = cRuta + "#toolbar=1&navpanes=0";
            }
            webBrowser1.Navigate(cRuta, false);
        }

        private void frmVistaPreviaNotasEEFF_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        }

    }
}
