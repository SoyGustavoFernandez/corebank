using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using GEN.Servicio;
using GEN.Funciones;
using System.IO;
using CLI.Servicio;

namespace CRE.Presentacion
{
    public partial class frmExpedienteGrupoSolidario : frmBase
    {
        #region Variable
        public int idSolicitud;
        public int idGrupo;
        private clsCNGrupoSolidario objCNGrupoSolidario = new clsCNGrupoSolidario();
        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();
        private CRE.CapaNegocio.clsCNAdministracionFiles clsFiles = new CRE.CapaNegocio.clsCNAdministracionFiles();
        public bool lEditar = true;
        #endregion

        #region Metodos
        public frmExpedienteGrupoSolidario()
        {
            InitializeComponent();
        }

        private int GetDataGridViewHeight(DataGridView dataGridView)
        {
            var sum = (dataGridView.ColumnHeadersVisible ? dataGridView.ColumnHeadersHeight : 0) +
                      dataGridView.Rows.OfType<DataGridViewRow>().Where(r => r.Visible).Sum(r => r.Height);

            return sum;
        }

        private void formatearDtg()
        {
            foreach (DataGridViewColumn column in dtgIntegrantes.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgIntegrantes.Columns["idCli"].HeaderText = "Código";
            dtgIntegrantes.Columns["cNombre"].HeaderText = "Nombre y Apellidos";
            dtgIntegrantes.Columns["cDocumentoID"].HeaderText = "Documento";
            dtgIntegrantes.Columns["cDni"].HeaderText = "DNI";
            dtgIntegrantes.Columns["cSentinel"].HeaderText = "Sentinel";
            dtgIntegrantes.Columns["cPosIntg"].HeaderText = "Posición Integral";

            dtgIntegrantes.Columns["cDni"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgIntegrantes.Columns["cPosIntg"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgIntegrantes.Columns["cSentinel"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgIntegrantes.Columns["idCli"].FillWeight = 10;
            dtgIntegrantes.Columns["cNombre"].FillWeight = 31;
            dtgIntegrantes.Columns["cDocumentoID"].FillWeight = 10;
            dtgIntegrantes.Columns["cDni"].FillWeight = 13;
            dtgIntegrantes.Columns["cSentinel"].FillWeight = 13;
            dtgIntegrantes.Columns["cPosIntg"].FillWeight = 13;

            dtgIntegrantes.Columns["idCli"].Visible = true;
            dtgIntegrantes.Columns["cNombre"].Visible = true;
            dtgIntegrantes.Columns["cDocumentoID"].Visible = true;
            dtgIntegrantes.Columns["cDni"].Visible = true;
            dtgIntegrantes.Columns["cSentinel"].Visible = true;
            dtgIntegrantes.Columns["cPosIntg"].Visible = true;

            dtgIntegrantes.Columns["cSentinel"].DefaultCellStyle.Font =  new Font("Ariel", 8, FontStyle.Bold | FontStyle.Underline);

            dtgIntegrantes.Columns["cNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private bool faltaConsultarDni()
        {
            bool falta = false;
            foreach (DataGridViewRow dtRow in dtgIntegrantes.Rows)
            {
                if (!Convert.ToBoolean(dtRow.Cells["lDni"].Value))
                {
                    falta = true;
                    break;
                }
            }
            return falta;
        }

        private bool faltaGuardarPosicionIntegral()
        {
            bool falta = false;
            foreach (DataGridViewRow dtRow in dtgIntegrantes.Rows)
            {
                if (!Convert.ToBoolean(dtRow.Cells["lPosIntg"].Value))
                {
                    falta = true;
                    break;
                }
            }
            return falta;
        }
        #endregion

        #region Eventos
        private void frmExpedienteGrupoSolidario_Load(object sender, EventArgs e)
        {
            DataTable dtExpediente = objCNGrupoSolidario.validarExpedienteGrupoSolidario(idSolicitud);
            foreach (DataColumn col in dtExpediente.Columns)
                col.ReadOnly = false;
            dtgIntegrantes.DataSource = dtExpediente;
            this.dtgIntegrantes.Height = this.GetDataGridViewHeight(this.dtgIntegrantes) +3;
            formatearDtg();
            pnlAcciones.Enabled = lEditar;
            pnlIntegrantes.Enabled = lEditar;
        }

        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dtgIntegrantes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int cDni = dtgIntegrantes.Columns["cDni"].Index;
            int cSentinel = dtgIntegrantes.Columns["cSentinel"].Index;
            int cPosIntg = dtgIntegrantes.Columns["cPosIntg"].Index;

            if (dtgIntegrantes.CurrentCell.ColumnIndex.Equals(cSentinel))
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
                        MessageBox.Show("El archivo es de " + fileSize + "bytes, exedió el limite de subida de archivos, maximo de " + maxSize + " bytes", "Adjuntar Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        string cExtension = fInfo.Extension.ToLower();

                        if (cExtension != ".pdf")
                        {
                            MessageBox.Show("El archivo seleccionado no tiene la extensión PDF", "Adjuntar Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        fStream.Flush();
                        fStream.Close();
                        br.Close();

                        byte[] bFileBinary = Compresion.CompressedByte(vDocumentoSesion);

                        DataTable res = clsFiles.cargarArchivo(
                                                                Convert.ToInt32(dtgIntegrantes.Rows[e.RowIndex].Cells["idSolicitud"].Value),
                                                                Convert.ToInt32(dtgIntegrantes.Rows[e.RowIndex].Cells["idDescTipoDocSentinel"].Value), // idDesTipoDoc - Evaluación de Créditos
                                                                Convert.ToInt32(dtgIntegrantes.Rows[e.RowIndex].Cells["idSentinel"].Value), // idTipoArchivo [SI_FinTipoArchivoEscaneado] - Sentinel
                                                                cDocumentoSesion, // Nombre de Archivo
                                                                bFileBinary,
                                                                cExtension,
                                                                clsVarGlobal.User.idUsuario
                                                               );
                        if (Convert.ToInt32(res.Rows[0]["idEstado"]) == 1)
                        {
                            dtgIntegrantes.Rows[e.RowIndex].Cells["cSentinel"].Value = "Ok";
                            dtgIntegrantes.Rows[e.RowIndex].Cells["lSentinel"].Value = true;
                            MessageBox.Show("El archivo se ha cargado correctamente", "Adjuntar Documentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            dtgIntegrantes.Rows[e.RowIndex].Cells["cSentinel"].Value = "Error";
                            MessageBox.Show("Ocurrió un error al cargar el archivo, intente de nuevo..", "Adjuntar Documentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                }
            }
        }

        private void btnConsultarReniec_Click(object sender, EventArgs e)
        {
            if (!faltaConsultarDni())
            {
                MessageBox.Show("Todos los Clientes ya tienen consulta a RENIEC", "Consulta a RENIEC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if(MessageBox.Show("¿Seguro que desea consultar a RENIEC los DNI's faltantes?", "Consulta a RENIEC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            btnConsultarReniec.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            foreach (DataGridViewRow dtRow in dtgIntegrantes.Rows)
            {
                if (!Convert.ToBoolean(dtRow.Cells["lDni"].Value))
                {
                    dtRow.Cells["cDni"].Value = "Consultando";
                    dtgIntegrantes.Refresh();

                    clsCliParamEnvioReniec objParam = new clsCliParamEnvioReniec(Convert.ToString(dtRow.Cells["cDocumentoID"].Value), clsVarGlobal.User.idUsuario, 1);
                    clsConfReniec objReniec = new clsConfReniec(clsVarApl.dicVarGen["cServicioWCFRen"]);
                    clsReniec obj = new clsReniec(objParam, objReniec);
                    clsProcesaDatosRen objTitular = obj.GetReniec();

                    if (objTitular == null)
                    {
                        dtRow.Cells["cDni"].Value = "Error";
                    }
                    else
                    {
                        dtRow.Cells["cDni"].Value = "Ok";
                        dtRow.Cells["lDni"].Value = true;
                        dtgIntegrantes.Refresh();
                    }
                }
            }
            btnConsultarReniec.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void btnCongelarPosicion_Click(object sender, EventArgs e)
        {
            string cMsg = "Se procederá a Guardar los reportes de Posición Integral de: \n\n                       LOS FALTANTES";
            bool lFaltante = faltaGuardarPosicionIntegral();

            if (!lFaltante)
            {
                cMsg = "Se procederá a Guardar los reportes de Posición Integral de: \n\n TODOS LOS CLIENTES";    
            }
            cMsg += "\n\n ¿Desea continuar?";

            if (MessageBox.Show(cMsg, "Guardado de Expediente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            btnConsultarReniec.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            foreach (DataGridViewRow dtRow in dtgIntegrantes.Rows)
            {
                if (!lFaltante || !Convert.ToBoolean(dtRow.Cells["lPosIntg"].Value))
                {
                    dtRow.Cells["cPosIntg"].Value = "Guardando";
                    dtgIntegrantes.Refresh();

                    /*  Guardar Expedientes - Posicion Integral de Intervinientes  */
                    bool lResultado = clsProcesoExp.guardarCopiaExpediente("Posicion Integral de Intervinientes", Convert.ToInt32(dtRow.Cells["idSolicitud"].Value), this, "individual", false);

                    if (!lResultado)
                    {
                        dtRow.Cells["cPosIntg"].Value = "Error";
                    }
                    else
                    {
                        dtRow.Cells["cPosIntg"].Value = "Ok";
                        dtRow.Cells["lPosIntg"].Value = true;
                        dtgIntegrantes.Refresh();
                    }
                }
            }
            btnConsultarReniec.Enabled = true;
            Cursor.Current = Cursors.Default;
            
        }
        #endregion
    }
}
