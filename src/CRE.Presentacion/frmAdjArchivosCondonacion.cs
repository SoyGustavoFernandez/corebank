using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;


using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using GEN.ControlesBase;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
namespace CRE.Presentacion
{
    public partial class frmAdjArchivosCondonacion : frmBase
    {
        #region Variables
        clsCNCondonacion SolicCondonacion = new clsCNCondonacion();
        
        public DataTable dtgFilesTmp;
        List<string> fileVistos = new List<string>();
        
        #endregion
        public frmAdjArchivosCondonacion(DataTable archivos, int tipoFormulario)
        {
            InitializeComponent();
            dtgFilesTmp = archivos.Copy();
            dtgFiles.CurrentCellChanged -= dtgFiles_CurrentCellChanged;
            dtgFiles.DataSource = archivos;
            dtgFiles.CurrentCellChanged += dtgFiles_CurrentCellChanged;

            bool estado = true;
            if (tipoFormulario > 0)
                estado = false;
            dtgFiles.Columns["btnAddFile"].Visible = estado;
            dtgFiles.Columns["btnDeleteFile"].Visible = estado;
            dtgFiles.Columns["lEstado"].Visible = estado;

            dtgFiles.Columns["btnViewFile"].Visible = !estado;

            btnAceptar1.Visible = estado;
            btnCancelar1.Visible = estado;
        }

        public DataTable getDtgFiles()
        {
            return dtgFilesTmp;
        }


        private void dtgFiles_CurrentCellChanged(object sender, EventArgs e)
        {
            int addFile = dtgFiles.Columns["btnAddFile"].Index;
            int deleteFile = dtgFiles.Columns["btnDeleteFile"].Index;
            int viewFile = dtgFiles.Columns["btnViewFile"].Index;

            if(dtgFiles.CurrentCell == null)
                return;

            if (dtgFiles.CurrentCell.ColumnIndex.Equals(addFile))
            {
                OpenFileDialog fDialog = new OpenFileDialog();
                fDialog.Title = "Abrir archivo";
                fDialog.InitialDirectory = clsVarGlobal.cRutPathApp;
                fDialog.Multiselect = false;
                fDialog.Filter = "PDF Documents|*.pdf";

                if (fDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(fDialog.FileName);
                    long fileSize = fi.Length;
                    int maxSize = clsVarApl.dicVarGen["cMaxFile"];
                    if (fileSize > maxSize)
                        MessageBox.Show("El archivo es de " + fileSize + "bytes, exedio el limite de subida de archivos, maximo de " + maxSize + " bytes", "Adjuntar Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    {
                    string cArchivo = fDialog.FileName;
                    FileInfo fInfo = new FileInfo(cArchivo);
                    long numBytes = fInfo.Length;
                    FileStream fStream = new FileStream(cArchivo, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fStream);

                    //dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells[0].Value = cArchivo;

                    string nameFile = cArchivo;
                    string cDocumentoSesion = fInfo.Name;
                    byte[] vDocumentoSesion = br.ReadBytes((int)numBytes);
                    string cExtension = fInfo.Extension;
                    fStream.Flush();
                    fStream.Close();
                    br.Close();
                    
                    dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cNombreDoc"].Value = cDocumentoSesion;

                    dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cExtencion"].Value = cExtension;
                        dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["vDocBase"].Value = Convert.ToBase64String(vDocumentoSesion);
                    }

                }
            }
            else if (dtgFiles.CurrentCell.ColumnIndex.Equals(deleteFile))
            {
                dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cNombreDoc"].Value = "";
                dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cExtencion"].Value = "";
                dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["vDocBase"].Value = "";
            }
            else if (dtgFiles.CurrentCell.ColumnIndex.Equals(viewFile))
            {
                if (dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cNombreDoc"].Value.ToString() != "")
                {
                    string str = dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["vDocBase"].Value.ToString();
                    byte[] bits = Convert.FromBase64String(str);

                    string sFile = dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cDocumento"].Value.ToString() +
                                    "-" + clsVarGlobal.User.idUsuario.ToString() +
                                    dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cExtencion"].Value.ToString()
                                    ;
                    string ruta = Directory.GetCurrentDirectory() + "\\documentosTmp";
                    if (!Directory.Exists(ruta))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(ruta);
                    }

                    FileStream fs = new FileStream("documentosTmp\\" + sFile, FileMode.Create);
                    fs.Write(bits, 0, Convert.ToInt32(bits.Length));
                    fs.Close();

                    ruta = ruta + "\\" + sFile;
                    contPdf.src = ruta;
                    panelFile.Visible = true;

                    int i = 0;
                    for (i = 0; i < fileVistos.Count(); i++)
                    {
                        if (fileVistos[i] == ruta.ToString())
                            break;
                    }
                    if (fileVistos.Count() == i)
                        fileVistos.Add(ruta.ToString());
                }
                else
                {
                    MessageBox.Show("No se cargó ningun Documento", "Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    panelFile.Visible = false;
                }
            }
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            dtgFilesTmp = (DataTable)dtgFiles.DataSource;
            this.Close();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAdjArchivosCondonacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < fileVistos.Count(); i++)
            {
                if (System.IO.File.Exists(fileVistos[i]))
                {
                    // Use a try block to catch IOExceptions, to
                    // handle the case of the file already being
                    // opened by another process.
                    try
                    {
                        System.IO.File.Delete(fileVistos[i]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }
            }
        }        
    }
}