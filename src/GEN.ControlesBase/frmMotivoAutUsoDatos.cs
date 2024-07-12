using EntityLayer;
using GEN.Funciones;
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

namespace GEN.ControlesBase
{
    public partial class frmMotivoAutUsoDatos : frmBase
    {
        public bool lAceptar = false;
        public int idMotivo = 0;
        public byte[] bArchivoBinary=null;
        public string cExtension;
        public string cNombreDocumento;
        public byte[] pbArchivoBinary = null;
        public string pcArchivo;
        public frmMotivoAutUsoDatos()
        {
            InitializeComponent();
        }

        public frmMotivoAutUsoDatos(string carchivo,byte[] bArchivoBinary)
        {
            InitializeComponent();
            pbArchivoBinary = bArchivoBinary;
            pcArchivo = carchivo;
        }
        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if(this.bArchivoBinary==null){
                MessageBox.Show("Debe cargar el archivo físico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboMotivoAutUsoDatos1.SelectedIndex != -1)
            {
                this.idMotivo =(int)cboMotivoAutUsoDatos1.SelectedValue;
                this.lAceptar = true;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Debe elegir el motivo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        
        }

        private void frmMotivoAutUsoDatos_Load(object sender, EventArgs e)
        {
            cboMotivoAutUsoDatos1.CargaMotAutUsoDatoTodos();
            cboMotivoAutUsoDatos1.SelectedIndex = -1;
            this.btnLeer1.Enabled = false;
        }

        private void btnAdjuntarFile1_Click(object sender, EventArgs e)
        {
            this.bArchivoBinary = null;
            btnLeer1.Enabled = false;
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Abrir archivo";
            fDialog.InitialDirectory = clsVarGlobal.cRutPathApp;
            fDialog.Multiselect = false;
            fDialog.Filter = "PDF Documents|*.pdf";

            if (fDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fi = new FileInfo(fDialog.FileName);
                long fileSize = fi.Length;
                int maxSize = clsVarApl.dicVarGen["cMaxFileAutUsoDat"];
                if (fileSize > maxSize)
                    MessageBox.Show("El archivo es de " + fileSize + "bytes, exedio el limite de subida de archivos, maximo de " + maxSize + " bytes", "Adjuntar Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    string cArchivo = fDialog.FileName;
                    FileInfo fInfo = new FileInfo(cArchivo);
                    long numBytes = fInfo.Length;
                    FileStream fStream = new FileStream(cArchivo, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fStream);

                    string nameFile = cArchivo;
                    this.cNombreDocumento = fInfo.Name;
                    byte[] vDocumentoSesion = br.ReadBytes((int)numBytes);
                    this.cExtension = fInfo.Extension;
                    fStream.Flush();
                    fStream.Close();
                    br.Close();

                    bArchivoBinary = Compresion.CompressedByte(vDocumentoSesion);
                    btnLeer1.Enabled = true;
                 }
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLeer1_Click(object sender, EventArgs e)
        {
            frmVerPdf frmdoc = new frmVerPdf();
            frmdoc.cArchivo = this.cNombreDocumento;
            frmdoc.bArchivoBinary = this.bArchivoBinary;
            frmdoc.ShowDialog();
        }

        private void btnImprimir2_Click(object sender, EventArgs e)
        {
            frmVerPdf frmdoc = new frmVerPdf();
            frmdoc.cArchivo = pcArchivo;
            frmdoc.bArchivoBinary = pbArchivoBinary;
            frmdoc.ShowDialog();
            this.btnAdjuntarFile1.Enabled = true;
        }
    }
}
