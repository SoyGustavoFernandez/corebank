using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using System.IO;
using GEN.Funciones;

namespace CLI.Servicio
{
    public partial class frmDisplayPDF : Form
    {
        #region Variables Globales
        string cNombreDoc;
        string cExtencion;
        byte[] bDocument;
        #endregion

        #region Constructores
        public frmDisplayPDF()
        {
            InitializeComponent();
        }

        public frmDisplayPDF(string _cNombreDoc, string _cExtencion, byte[] _bDocument)
        {
            InitializeComponent();
            this.cNombreDoc = _cNombreDoc;
            this.cExtencion = _cExtencion;
            this.bDocument = _bDocument;
        }
        #endregion

        #region Metodos
        private void renderizarDocumentoPDF()
        {
            string sFile = cNombreDoc;

            string ruta = Directory.GetCurrentDirectory() + "\\PDFSustentoExpBio";
            if (!Directory.Exists(ruta))
            {
                DirectoryInfo di = Directory.CreateDirectory(ruta);
            }

            FileStream fs = new FileStream("PDFSustentoExpBio\\" + sFile, FileMode.Create);
            fs.Write(bDocument, 0, Convert.ToInt32(bDocument.Length));

            fs.Close();

            ruta = ruta + "\\" + sFile;
            contPdf.src = ruta;
        }
        #endregion

        #region Eventos
        private void frmDisplayPDF_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.cNombreDoc))
            {
                renderizarDocumentoPDF();
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion
    }
}
