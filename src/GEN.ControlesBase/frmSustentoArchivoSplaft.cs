using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using SPL.CapaNegocio;
using EntityLayer;
using System.IO;
using GEN.Funciones;
using System.Diagnostics;

namespace GEN.ControlesBase
{
    public partial class frmSustentoArchivoSplaft : frmBase
    {
        #region Variables
        private clsCNBuscaKardex busKardex = new clsCNBuscaKardex();
        private string cEtapaOperacion = "busqueda";
        decimal nMontoOpera; 
        int idMoneda; 
        int idTipoOperacion; 
        int idMotivoOperacion; 
        int idSubProducto; 
        int idTipoPago;
        int idTipoUmbralSustentoOpe = 0;
        int idCodOperacion = 0;
        bool lContinuaOperacion = true;
        int idKardex = 0;
        string dFechaOpe;
        string cTipoOperacion;
        int idCuenta;
        bool lMostrarBoton = true;
        bool lGuardado = false;
        bool lCargaArchivos = false;
        string cMensajeTitulo = "Sustento Operacion";
        #endregion

        #region Metodos
        public frmSustentoArchivoSplaft()
        {
            InitializeComponent();
            this.lCargaArchivos = true;
        }
        
        public frmSustentoArchivoSplaft(int _idKardex)
        {
            InitializeComponent();
            this.idKardex = _idKardex;
            this.cargarDatos();
            this.lCargaArchivos = false;
            if (validarUmbral())
            {
                lMostrarBoton = true;
            }
            else 
            {
                lMostrarBoton = false;
            }
        }

        public frmSustentoArchivoSplaft(decimal _nMontoOpera, int _idMoneda, int _idTipoOperacion, int _idMotivoOperacion, int _idSubProducto, int _idTipoPago)
        {
            InitializeComponent();

            this.nMontoOpera = _nMontoOpera; 
            this.idMoneda = _idMoneda; 
            this.idTipoOperacion = _idTipoOperacion; 
            this.idMotivoOperacion = _idMotivoOperacion; 
            this.idSubProducto = _idSubProducto; 
            this.idTipoPago = _idTipoPago;

            if (validarUmbral())
            {
                DialogResult dr = cargaMensajeAlerta();
                if (dr == DialogResult.Yes)
                {
                    lContinuaOperacion = true;
                }
                else
                {
                    this.cargaMensajeNoContinuaOpe();
                    lContinuaOperacion = false;
                }
            }
        }

        private bool cargarDatos()
        {
            DataTable datosKardex = this.getDataKardex(idKardex);
            if (datosKardex.Rows.Count == 0)
            {
                MessageBox.Show("Nro. Kardex no ha devuelto resultado.\n Favor de verificar el Nro. Kardex.", cMensajeTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            this.nMontoOpera = Convert.ToDecimal(datosKardex.Rows[0]["nMontoOperacion"].ToString());
            this.idMoneda = (int)datosKardex.Rows[0]["idMoneda"];
            this.idTipoOperacion = (int)datosKardex.Rows[0]["idTipoOperacion"];
            this.idMotivoOperacion = (int)((datosKardex.Rows[0]["idMotivoOperacion"] == DBNull.Value)? 0: datosKardex.Rows[0]["idMotivoOperacion"]);
            this.idSubProducto = (int)datosKardex.Rows[0]["idProducto"];
            this.idTipoPago = (int)datosKardex.Rows[0]["idTipoPago"];
            this.idKardex  = (int) datosKardex.Rows[0]["IdKardex"];
            this.dFechaOpe = datosKardex.Rows[0]["dFechaOpe"].ToString();
            this.cTipoOperacion = datosKardex.Rows[0]["cTipoOperacion"].ToString();
            this.idCuenta = (int)datosKardex.Rows[0]["idCuenta"];
            this.idCodOperacion = (int)datosKardex.Rows[0]["idCodOperacion"];
            cargarDatosKardex();

            return true;
        }

        public bool obtenerContinuaOperacion()
        {
            return this.lContinuaOperacion;
        }
        public bool obtenerMostrarBoton()
        {
            return this.lMostrarBoton;
        }

        public bool obtenerGuardado() 
        {
            return this.lGuardado;
        }

        private bool validarUmbral()
        {
            DataTable dtRes = busKardex.CNValidarUmbralSustento(this.nMontoOpera, this.idMoneda, this.idTipoOperacion, this.idMotivoOperacion, this.idSubProducto, this.idTipoPago);
            if (dtRes.Rows.Count == 0)
                return false;

            idTipoUmbralSustentoOpe = Convert.ToInt32(dtRes.Rows[0]["idTipoUmbralSustentoOpe"].ToString());
            return (idTipoUmbralSustentoOpe!= 0)? true: false;
        }

        private DataTable getDataKardex(int idKardex)
        {
            DataTable datosKardex = busKardex.busquedaKardex(idKardex);
            
            foreach (DataColumn item in datosKardex.Columns)
	        {
                item.ReadOnly = false;
	        }
            return datosKardex;
        }

        private DialogResult cargaMensajeAlerta()
        {
            return MessageBox.Show("“El Monto de la operación de moneda extranjera, supera el umbral SOF del SPLAFT”, \n ¿Cliente cuenta con el SUSTENTO DE ORIGEN de FONDOS (SOF)?", cMensajeTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private DialogResult cargaMensajeNoContinuaOpe()
        {
            return MessageBox.Show("Usted ha seleccionado que el cliente no tiene sustento de sus origenes de fondo, por lo que la operacion no procede.", cMensajeTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cargarDatosKardex()
        {
            txtIdKardex.Text = this.idKardex.ToString();
            txtFechaO.Text = this.dFechaOpe.ToString();
            txtOperacion.Text = this.cTipoOperacion;
            txtMonto.Text = this.nMontoOpera.ToString();
            txtCuenta.Text = this.idCuenta.ToString();
            cboMoneda1.SelectedValue = this.idMoneda;
        }

        private void formatoDtgSustento()
        {
            foreach (DataGridViewColumn item in dtgSustentos.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }
            
            dtgSustentos.Columns["idSustento"].Visible = false;
            dtgSustentos.Columns["idTipoDocumento"].Visible = false;
            dtgSustentos.Columns["cTipoDocumento"].Visible = true;
            dtgSustentos.Columns["cDescSustento"].Visible = true;
            dtgSustentos.Columns["cNombreDoc"].Visible = lCargaArchivos;

            dtgSustentos.Columns["cTipoDocumento"].HeaderText = "Tipo de Documento";
            dtgSustentos.Columns["cDescSustento"].HeaderText = "Sustento";
            dtgSustentos.Columns["cNombreDoc"].HeaderText = "Nombre del Documento";



            dtgSustentos.Columns["cTipoDocumento"].DisplayIndex = 1;
            dtgSustentos.Columns["cDescSustento"].DisplayIndex = 2;
            dtgSustentos.Columns["cNombreDoc"].DisplayIndex = 3;

            dtgSustentos.Columns["cTipoDocumento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSustentos.Columns["cDescSustento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgSustentos.Columns["cNombreDoc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (!dtgSustentos.Columns.Contains("btnAddFile"))
            {
                DataGridViewButtonColumn btnAdd = new DataGridViewButtonColumn();
                {
                    btnAdd.Name = "btnAddFile";
                    btnAdd.HeaderText = "Subir";
                    btnAdd.Text = "+";
                    btnAdd.UseColumnTextForButtonValue = true;
                    btnAdd.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    btnAdd.FlatStyle = FlatStyle.Standard;
                    btnAdd.CellTemplate.Style.BackColor = Color.Honeydew;
                    btnAdd.Visible = true;
                    dtgSustentos.Columns.Add(btnAdd);
                }
            }

            if (!dtgSustentos.Columns.Contains("btnDeleteFile"))
            {
                DataGridViewButtonColumn btnRemove = new DataGridViewButtonColumn();
                {
                    btnRemove.Name = "btnDeleteFile";
                    btnRemove.HeaderText = "Quitar";
                    btnRemove.Text = "-";
                    btnRemove.UseColumnTextForButtonValue = true;
                    btnRemove.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    btnRemove.FlatStyle = FlatStyle.Standard;
                    btnRemove.CellTemplate.Style.BackColor = Color.Honeydew;
                    btnRemove.Visible = true;
                    dtgSustentos.Columns.Add(btnRemove);
                }
            }

            if (!dtgSustentos.Columns.Contains("btnViewFile"))
            {
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
                    dtgSustentos.Columns.Add(btnView);
                }
            }

            dtgSustentos.Columns["btnAddFile"].Visible = lCargaArchivos;
            dtgSustentos.Columns["btnDeleteFile"].Visible = lCargaArchivos;
            dtgSustentos.Columns["btnViewFile"].Visible = lCargaArchivos;
        }

        private void mostrarSustentosOperacion(int idKardex)
        {
            DataTable dt = busKardex.CNGetSustentosOperacion(idKardex);
            foreach (DataColumn item in dt.Columns)
            {
                item.ReadOnly = false;
            }

            if (dt.Rows.Count > 0)
                this.lGuardado = true;

            dtgSustentos.DataSource = dt;
            formatoDtgSustento();
        }

        private void buscarKardex(int idKardex)
        {
            getDataKardex(idKardex);
            mostrarSustentosOperacion(idKardex);
        }
        #endregion

        #region Eventos
        private void txtIdKardex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (string.IsNullOrEmpty(txtIdKardex.Text))
                {
                    MessageBox.Show("Nro. Kardex esta vacio", cMensajeTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                this.idKardex = Convert.ToInt32(txtIdKardex.Text);
                if (!this.cargarDatos())
                    return;

                if (validarUmbral())
                {
                    MessageBox.Show("Esta operación supera el umbral SOF del SPLAFT. \n Debe cargar archivos de sustento.", cMensajeTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lContinuaOperacion = true;
                    controlFormularios(Transaccion.Selecciona);
                    this.mostrarSustentosOperacion(this.idKardex);
                }
                else
                {
                    lContinuaOperacion = false;
                    MessageBox.Show("Esta operación no supera el umbral SOF del SPLAFT.", cMensajeTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnEditar1.Enabled = false;
                    btnGrabar1.Enabled = false;
                }
            }
        }

         private void frmSustentoArchivoSplaft_Load(object sender, EventArgs e)
         {
             if (txtIdKardex.Text != "")
             {
                 mostrarSustentosOperacion(Convert.ToInt32(txtIdKardex.Text));
             }
                
             cboTipoDocSustento.cargaDatos();
             cboTipoDocSustento.SelectedIndex = -1;
             if(this.idKardex !=0)
             {
                 controlFormularios(Transaccion.Edita);
                 btnCancelar1.Enabled = false;
             }
             else
	         {
                 controlFormularios(Transaccion.Nuevo);
	         }

             if(this.idKardex!=0)
                cargarDatosKardex();

         }

         private void btnAgregar1_Click(object sender, EventArgs e)
         {
             if (cboTipoDocSustento.SelectedIndex == -1)
             {
                 MessageBox.Show("Seleccione un Tipo de Documento", cMensajeTitulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return;
             }
             if (txtDescSustento.Text == "")
             {
                 MessageBox.Show("Describa el Sustento", cMensajeTitulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return;
             }

             DataTable dt2 = new DataTable();
             dt2 = dtgSustentos.DataSource as DataTable;

             DataRow datarow = dt2.NewRow();
             datarow["idSustento"] = 0;
             datarow["idTipoDocumento"] = Convert.ToInt32(cboTipoDocSustento.SelectedValue);
             datarow["cTipoDocumento"] = cboTipoDocSustento.Text;
             datarow["cDescSustento"] = txtDescSustento.Text;
             datarow["cNombreDoc"] = "";
             datarow["cExtencion"] = "";
             datarow["lInsertado"] = 0;
             datarow["idCodOperacion"] = this.idCodOperacion;
             datarow["vBinaryDoc"] = new byte[0];
             dt2.Rows.Add(datarow);

             cboTipoDocSustento.SelectedIndex = -1;
             txtDescSustento.Text = "";
         }

         private void controlFormularios(Transaccion tTran)
         {
             switch (tTran)
             {
                 case Transaccion.Nuevo:
                     txtIdKardex.Enabled = true;
                     txtFechaO.Enabled = false;
                     txtCuenta.Enabled = false;
                     txtMonto.Enabled = false;
                     txtOperacion.Enabled = false;
                     cboMoneda1.Enabled = false;
                     cboTipoDocSustento.Enabled = false;
                     txtDescSustento.Enabled = false;
                     btnAgregar1.Enabled = false;
                     btnCancelar1.Enabled = true;
                     dtgSustentos.Enabled = false;
                     btnEditar1.Enabled = false;
                     btnGrabar1.Enabled = false;
                     break;
                 case Transaccion.Edita:
                     txtIdKardex.Enabled = false;
                     txtFechaO.Enabled = false;
                     txtCuenta.Enabled = false;
                     txtMonto.Enabled = false;
                     txtOperacion.Enabled = false;
                     cboMoneda1.Enabled = false;
                     cboTipoDocSustento.Enabled = true;
                     txtDescSustento.Enabled = true;
                     btnAgregar1.Enabled = true;
                     btnCancelar1.Enabled = true;
                     dtgSustentos.Enabled = true;
                     btnEditar1.Enabled = false;
                     btnGrabar1.Enabled = true;
                     break;
                 case Transaccion.Selecciona:
                     txtIdKardex.Enabled = false;
                     txtFechaO.Enabled = false;
                     txtCuenta.Enabled = false;
                     txtMonto.Enabled = false;
                     txtOperacion.Enabled = false;
                     cboMoneda1.Enabled = false;
                     cboTipoDocSustento.Enabled = false;
                     txtDescSustento.Enabled = false;
                     btnAgregar1.Enabled = false;
                     btnCancelar1.Enabled = true;
                     dtgSustentos.Enabled = false;
                     btnEditar1.Enabled = true;
                     btnGrabar1.Enabled = false;
                     
                     break;
                 default:
                     break;
             }
         }

         private void limpiarFormulario()
         {
             txtIdKardex.Clear();
             txtFechaO.Clear();
             txtCuenta.Clear();
             txtMonto.Clear();
             txtOperacion.Clear();
             cboMoneda1.SelectedIndex = -1;
             cboTipoDocSustento.SelectedIndex = -1;
             txtDescSustento.Clear();
             txtIdKardex.Enabled= true;
             if (dtgSustentos.DataSource != null)
             {
                 ((DataTable)dtgSustentos.DataSource).Clear();
             }
         }
        #endregion

         private void dtgSustentos_CellClick(object sender, DataGridViewCellEventArgs e)
         {
             int addFile = dtgSustentos.Columns["btnAddFile"].Index;
             int deleteFile = dtgSustentos.Columns["btnDeleteFile"].Index;
             int viewFile = dtgSustentos.Columns["btnViewFile"].Index;

             int nFila = dtgSustentos.CurrentCell.RowIndex;

             if (dtgSustentos.CurrentCell == null)
                 return;

             if (dtgSustentos.CurrentCell.ColumnIndex.Equals(addFile))
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
                         MessageBox.Show("El archivo es de " + fileSize + "bytes, exedio el limite de subida de archivos, maximo de " + maxSize + " bytes", cMensajeTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                         if (cExtension.ToLower() == ".pdf")
                         {
                             dtgSustentos.Rows[nFila].Cells["cNombreDoc"].Value = cDocumentoSesion;
                             dtgSustentos.Rows[nFila].Cells["cExtencion"].Value = cExtension;
                             dtgSustentos.Rows[nFila].Cells["vBinaryDoc"].Value = Compresion.CompressedByte(vDocumentoSesion);
                             dtgSustentos.Rows[nFila].Cells["lInsertado"].Value = 0;
                         }
                         else
                         {
                             MessageBox.Show("Archivo no válido, se debe cargar archivo de tipo PDF", cMensajeTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                         }
                         
                     }

                 }
             }
             else if (dtgSustentos.CurrentCell.ColumnIndex.Equals(deleteFile))
             {
                 dtgSustentos.Rows[nFila].Cells["cNombreDoc"].Value = "";
                 dtgSustentos.Rows[nFila].Cells["cExtencion"].Value = "";
                 dtgSustentos.Rows[nFila].Cells["vBinaryDoc"].Value = new byte[0];
                 dtgSustentos.Rows[nFila].Cells["lInsertado"].Value = 0;
             }
             else if (dtgSustentos.CurrentCell.ColumnIndex.Equals(viewFile))
             {
                 if (Convert.ToBoolean(dtgSustentos.Rows[nFila].Cells["lInsertado"].Value))
                 {
                     if (dtgSustentos.Rows[nFila].Cells["cNombreDoc"].Value.ToString() != "")
                     {
                         byte[] bits;
                         if (dtgSustentos.Rows[nFila].Cells["cExtencion"].Value.ToString() == "")
                         {
                             DataTable res = busKardex.CNBuscarArchivo(Convert.ToInt32(dtgSustentos.Rows[nFila].Cells["idSustento"].Value));

                             dtgSustentos.Rows[nFila].Cells["cExtencion"].Value = res.Rows[0]["cExtencion"].ToString();
                             bits = (byte[])Compresion.DescompressedByte((byte[])res.Rows[0]["vBinaryDoc"]);
                             dtgSustentos.Rows[nFila].Cells["vBinaryDoc"].Value = bits;

                         }
                         else
                         {
                             bits = Compresion.DescompressedByte((byte[])dtgSustentos.Rows[nFila].Cells["vBinaryDoc"].Value);
                         }
                         panel2.Visible = true;
                         this.renderizarDocumentoPDF(dtgSustentos.Rows[nFila].Cells["cNombreDoc"].Value.ToString(), dtgSustentos.Rows[nFila].Cells["cExtencion"].Value.ToString(), bits);
                     }
                     else
                     {
                         panel2.Visible = false;
                         MessageBox.Show("No se cargó ningun Documento", cMensajeTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     }
                 }
                 else
                 {
                     if (dtgSustentos.Rows[nFila].Cells["cNombreDoc"].Value.ToString() != "")
                     {
                         byte[] bits;
                         panel2.Visible = true;
                         bits = Compresion.DescompressedByte((byte[])dtgSustentos.Rows[nFila].Cells["vBinaryDoc"].Value);
                         this.renderizarDocumentoPDF(dtgSustentos.Rows[nFila].Cells["cNombreDoc"].Value.ToString(), dtgSustentos.Rows[nFila].Cells["cExtencion"].Value.ToString(), bits);
                     }
                 }
             }
         }

         private void renderizarDocumentoPDF(string cNombreDoc, string cExtencion, byte[] bDocument )
         {
             string sFile = cNombreDoc +
                            "-" + clsVarGlobal.User.idUsuario.ToString() +
                            cExtencion;

             string ruta = Directory.GetCurrentDirectory() + "\\documentosTmp";
             if (!Directory.Exists(ruta))
             {
                 DirectoryInfo di = Directory.CreateDirectory(ruta);
             }

             FileStream fs = new FileStream("documentosTmp\\" + sFile, FileMode.Create);
             fs.Write(bDocument, 0, Convert.ToInt32(bDocument.Length));

             fs.Close();

             ruta = ruta + "\\" + sFile;
             contPdf.src = ruta;
             panelFile.Visible = true;
         }

         private void btnGrabar1_Click(object sender, EventArgs e)
         {
             
             for (int i = 0; i < dtgSustentos.Rows.Count; i++)
             {
                 if (!Convert.ToBoolean(dtgSustentos.Rows[i].Cells["lInsertado"].Value))
                 {
                     DataTable res = busKardex.CNGuardarArchivos(
                         dtgSustentos.Rows[i].Cells["cNombreDoc"].Value.ToString(),
                         (byte[] )dtgSustentos.Rows[i].Cells["vBinaryDoc"].Value,
                         dtgSustentos.Rows[i].Cells["cExtencion"].Value.ToString(),
                         Convert.ToInt32(txtIdKardex.Text.ToString()),
                         (int) dtgSustentos.Rows[i].Cells["idSustento"].Value,
                         (int) dtgSustentos.Rows[i].Cells["idTipoDocumento"].Value,
                         dtgSustentos.Rows[i].Cells["cDescSustento"].Value.ToString(),
                         true,
                         clsVarGlobal.User.idUsuario,
                         clsVarGlobal.dFecSystem,
                         (int)dtgSustentos.Rows[i].Cells["idCodOperacion"].Value
                     );
                     if (res.Rows.Count > 0)
                     {
                         dtgSustentos.Rows[i].Cells["lInsertado"].Value = res.Rows[0]["estado"];
                         dtgSustentos.Rows[i].Cells["idSustento"].Value = (int) res.Rows[0]["idSustento"];
                     }
                     else
                     {
                         dtgSustentos.Rows[i].Cells["lInsertado"].Value = 0;
                     }
                 }
             }
             if (verificarEnvios())
             {
                 lGuardado = true;
                 controlFormularios(Transaccion.Selecciona);
                 MessageBox.Show("Se registró correctamente los archivos", cMensajeTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             else
             {
                 lGuardado = false;
                 MessageBox.Show("Ocurrió un error al subir uno de los archivos, intente de nuevo..", cMensajeTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }
         }
         
        private bool verificarEnvios()
         {
             for (int i = 0; i < dtgSustentos.Rows.Count; i++)
             {
                 if (dtgSustentos.Rows[i].Cells["vBinaryDoc"].Value.ToString() != "" && !Convert.ToBoolean(dtgSustentos.Rows[i].Cells["lInsertado"].Value))
                     return false;
             }

             return true;
         }

         private void btnEditar1_Click(object sender, EventArgs e)
         {
             if (string.IsNullOrEmpty(txtIdKardex.Text))
             {
                 MessageBox.Show("Nro. Kardex esta vacio", cMensajeTitulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 return;
             }

             controlFormularios(Transaccion.Edita);
         }

         private void btnCancelar1_Click(object sender, EventArgs e)
         {
             controlFormularios(Transaccion.Selecciona);
             limpiarFormulario();

         }

         private void btnSalir1_Click(object sender, EventArgs e)
         {
             this.Dispose();
         }
    }
}
