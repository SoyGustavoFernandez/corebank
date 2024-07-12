using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using EntityLayer;
using GEN.Funciones;

namespace GEN.ControlesBase
{
    public partial class frmAdministrarFiles : frmBase
    {
        public int idSol;
        bool readOnly;
        public int obligatorios=-1;
        CRE.CapaNegocio.clsCNAdministracionFiles clsFiles = new CRE.CapaNegocio.clsCNAdministracionFiles();
        List<string> fileVistos = new List<string>();

        public frmAdministrarFiles(int idSolicitud, bool lectura)
        {
            idSol = idSolicitud;
            readOnly = lectura;
            InitializeComponent();
        }

        public int getObligatorios()
        {
            return obligatorios;
        }

        private void frmAdministrarFiles_Load(object sender, EventArgs e)
        {
            cargarDatosIni();
            formatearDTG();
            panelFile.Visible = false;
            btnGrabar1.Visible = !readOnly;
        }

        public void cargarDatosIni()
        {
            
            DataTable dt = clsFiles.ListarTiposDocumentosEvaluacion(idSol);
            dt.Columns.Add("lInsertado", typeof(System.Boolean));
            foreach (DataColumn item in dt.Columns)
                item.ReadOnly = false;
            dtgFiles.DataSource = dt;
        }

        private void formatearDTG()
        {
            dtgFiles.Columns["cPertenencia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgFiles.Columns["cDocumento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgFiles.Columns["lEstado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgFiles.Columns["idTipoDoc"].Visible = false;
            dtgFiles.Columns["cExtencion"].Visible = false;
            dtgFiles.Columns["vDocBase"].Visible = false;
            dtgFiles.Columns["vBinaryDocBase"].Visible = false;
            dtgFiles.Columns["lObligatorios"].Visible = false;
            dtgFiles.Columns["cPertenencia"].HeaderText = "Tipo Cliente";
            dtgFiles.Columns["cDocumento"].HeaderText = "Tipo Documento";
            dtgFiles.Columns["lEstado"].HeaderText = "Obl";
            dtgFiles.Columns["cNombreDoc"].HeaderText = "NombreDoc";
            dtgFiles.Columns["cExtencion"].HeaderText = "extencion";
            dtgFiles.Columns["vDocBase"].HeaderText = "vinary";
            dtgFiles.Columns["cPertenencia"].Visible = true;
            dtgFiles.Columns["cNombreDoc"].Visible = true;
            dtgFiles.Columns["lInsertado"].Visible = false;
            dtgFiles.Columns["lComprimido"].Visible = false;

            dtgFiles.Columns["cPertenencia"].DisplayIndex = 1;
            dtgFiles.Columns["cDocumento"].DisplayIndex = 2;
            dtgFiles.Columns["cNombreDoc"].DisplayIndex = 3;
            dtgFiles.Columns["lEstado"].DisplayIndex = 4;

            DataGridViewButtonColumn btnAdd = new DataGridViewButtonColumn();
                {
                    btnAdd.Name = "btnAddFile";
                    btnAdd.HeaderText = "Subir";
                    btnAdd.Text = "+";
                    btnAdd.UseColumnTextForButtonValue = true;
                    btnAdd.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    btnAdd.FlatStyle = FlatStyle.Standard;
                    btnAdd.CellTemplate.Style.BackColor = Color.Honeydew;
                    btnAdd.Visible = !readOnly;
                    dtgFiles.Columns.Add(btnAdd);
                }

                DataGridViewButtonColumn btnRemove = new DataGridViewButtonColumn();
                {
                    btnRemove.Name = "btnDeleteFile";
                    btnRemove.HeaderText = "Quitar";
                    btnRemove.Text = "-";
                    btnRemove.UseColumnTextForButtonValue = true;
                    btnRemove.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    btnRemove.FlatStyle = FlatStyle.Standard;
                    btnRemove.CellTemplate.Style.BackColor = Color.Honeydew;
                    btnRemove.Visible = !readOnly;
                    dtgFiles.Columns.Add(btnRemove);
                }

            DataGridViewButtonColumn btnView = new DataGridViewButtonColumn();
            {
                btnView.Name = "btnViewFile";
                btnView.HeaderText = "Ver";
                btnView.Text = "Ver";
                btnView.UseColumnTextForButtonValue = true;
                btnView.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnView.FlatStyle = FlatStyle.Standard;
                btnView.CellTemplate.Style.BackColor = Color.Honeydew;
                btnView.DefaultCellStyle.BackColor = Color.LightGray;
                dtgFiles.Columns.Add(btnView);
            }
            for (int i = 0; i < dtgFiles.Rows.Count; i++)
            {
                dtgFiles.Rows[i].Cells["lInsertado"].Value = 1;
                /*if (dtgFiles.Rows[i].Cells["cNombreDoc"].Value.ToString() == "")
                    dtgFiles.Rows[i].Cells["lInsertado"].Value = 1;
                else dtgFiles.Rows[i].Cells["lInsertado"].Value = 0;*/
            }
                
        }

        private void dtgFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int addFile = dtgFiles.Columns["btnAddFile"].Index;
            int deleteFile = dtgFiles.Columns["btnDeleteFile"].Index;
            int viewFile = dtgFiles.Columns["btnViewFile"].Index;

            if (dtgFiles.CurrentCell == null)
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

                        string nameFile = cArchivo;
                        string cDocumentoSesion = fInfo.Name;
                        byte[] vDocumentoSesion = br.ReadBytes((int)numBytes);
                        string cExtension = fInfo.Extension;
                        fStream.Flush();
                        fStream.Close();
                        br.Close();

                        dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cNombreDoc"].Value = cDocumentoSesion;

                        dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cExtencion"].Value = cExtension;
                        /**********Compresion de byte[] a base64**************/
                        string vDocBase64 = "";//Compresion.ByteToBase64(vDocumentoSesion);
                        dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["vDocBase"].Value = vDocBase64;
                        dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["vBinaryDocBase"].Value = Compresion.CompressedByte(vDocumentoSesion);
                        dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lInsertado"].Value = 0;
                    }

                }
            }
            else if (dtgFiles.CurrentCell.ColumnIndex.Equals(deleteFile))
            {
                dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cNombreDoc"].Value = "";
                dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cExtencion"].Value = "";
                dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["vDocBase"].Value = "";
                dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["vBinaryDocBase"].Value = new byte[0];
                dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["lInsertado"].Value = 0;
            }
            else if (dtgFiles.CurrentCell.ColumnIndex.Equals(viewFile))
            {
                if (dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cNombreDoc"].Value.ToString() != "")
                {
                    //string str = dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["vDocBase"].Value.ToString();
                    //byte[] bits = Convert.FromBase64String(str);
                    
                    //byte[] bits = Compresion.DescmpBase64ToByte(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["vDocBase"].Value.ToString());
                    byte[] bits;
                    if (dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cExtencion"].Value.ToString() == "")
                    {
                        DataTable res = clsFiles.getArchivoSolicitud(idSol, Convert.ToInt32(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["idTipoDOc"].Value));
                        dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["cExtencion"].Value = res.Rows[0]["cExtencion"].ToString();
                        if (Convert.ToBoolean(res.Rows[0]["lComprimido"]))
                        {
                            bits = Compresion.DescompressedByte((byte[])res.Rows[0]["vBinaryDocBase"]);
                            dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["vDocBase"].Value = res.Rows[0]["vDocBase"].ToString();
                            dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["vBinaryDocBase"].Value = bits;
                        }
                        else
                        {
                            bits = (byte[])res.Rows[0]["vBinaryDocBase"];
                            dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["vDocBase"].Value = Compresion.ByteToBase64(Convert.FromBase64String(res.Rows[0]["vDocBase"].ToString()));
                            dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["vBinaryDocBase"].Value = bits;
                        }
                    }
                    else
                    {
                        //bits = Convert.FromBase64String(Convert.ToBase64String(Compresion.DescmpBase64ToByte(dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["vDocBase"].Value.ToString())));
                        bits = (byte[])dtgFiles.Rows[dtgFiles.CurrentCell.RowIndex].Cells["vBinaryDocBase"].Value;
                    }
                    

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
                    panelFile.Visible = false;
                    MessageBox.Show("No se cargó ningun Documento", "Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtgFiles.Rows.Count; i++)
            {
                if (!Convert.ToBoolean(dtgFiles.Rows[i].Cells["lInsertado"].Value) )
                {
                    DataTable res = clsFiles.insertarDocumentosEvaluacion(
                        idSol,
                        Convert.ToInt32(dtgFiles.Rows[i].Cells["idTipoDoc"].Value),
                        dtgFiles.Rows[i].Cells["cNombreDoc"].Value.ToString(),
                        dtgFiles.Rows[i].Cells["vDocBase"].Value.ToString(),
                        (byte[])dtgFiles.Rows[i].Cells["vBinaryDocBase"].Value,
                        dtgFiles.Rows[i].Cells["cExtencion"].Value.ToString()
                    );
                    if(res.Rows.Count>0)
                        dtgFiles.Rows[i].Cells["lInsertado"].Value = res.Rows[0]["estado"];
                    else dtgFiles.Rows[i].Cells["lInsertado"].Value = 0;
                }
            }
            if(verificarEnvios())
                MessageBox.Show("Se registró correctamente los archivos", "Documentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Ocurrió un error al subir uno de los archivos, intente de nuevo..", "Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            /*
            DataTable res = clsFiles.insertFilesEvaluacion(convertXMLFiles((DataTable)dtgFiles.DataSource), idSol);
            if (Convert.ToBoolean(res.Rows[0]["estado"]))
                MessageBox.Show(res.Rows[0]["msg"].ToString(), "Guardar Documentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show(res.Rows[0]["msg"].ToString(), "Guardar Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            obligatorios = Convert.ToInt32(res.Rows[0]["obligatorios"]);
             * */
        }

        private bool verificarEnvios()
        {
            for (int i = 0; i < dtgFiles.Rows.Count; i++)
            {
                if (dtgFiles.Rows[i].Cells["vDocBase"].Value.ToString() != "" && !Convert.ToBoolean(dtgFiles.Rows[i].Cells["lInsertado"].Value))
                    return false;
            }

            return true;
        }

        public string convertXMLFiles(DataTable dt)
        {
            dt.TableName = "files";
            DataSet ds = new DataSet();
            if (dt.DataSet != null)
            {
                ds = dt.DataSet;
            }
            else
            {
                ds.Tables.Add(dt);
            }


            return ds.GetXml();
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAdministrarFiles_SizeChanged(object sender, EventArgs e)
        {
            int width = this.Size.Width;
            int height = this.Size.Height;
            int borde = 20;
            if (this.Visible)
            {
                this.dtgFiles.Size = new Size(width-borde,148);
                this.panelBotones.Size = new Size(width-borde,53);
            }
            if (height > 683)
            {
                this.panelFile.Size = new Size(width - borde, height - 281);
                this.contPdf.Size = new Size(width - borde - 2, height - 282);
            }
            else
            {
                this.panelFile.Size = new Size(923, 397);
                this.contPdf.Size = new Size(923, 396);
            }
        }

        private void frmAdministrarFiles_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < fileVistos.Count(); i++)
            {
                if (System.IO.File.Exists(fileVistos[i]))
                {
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
