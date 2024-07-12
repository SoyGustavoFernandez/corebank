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
using EntityLayer;
using GEN.ControlesBase;
using RCP.CapaNegocio;


namespace RCP.Presentacion
{
    public partial class frmSolicitudPasoJudicial : frmBase
    {
        #region Variables
        clsCNHojaRuta cnHojaRuta = new clsCNHojaRuta();
        DataTable dtCreditos = new DataTable();
        DataTable dtHojaRuta = new DataTable();
        clsCNSolicitudRecuperacion solicitud = new clsCNSolicitudRecuperacion();
        

        OpenFileDialog dialog = new OpenFileDialog();
        short nInsertActualiza = 1;//Si es  1: insertará un nuevo informe
        //clsCNSolicitud SolCre = new clsCNSolicitud();//Par recuperar los datos de la solicitud de crédito, ejm datos del clientes, etc.

        DataTable dtDocumentos = new DataTable();//Contendrá los datos de los documentos que se adjuntarán al Informe(No se muestra al cliente)
        DataTable dtAuxDocs = new DataTable();//Tabla para mostrar los documentos que se van adjuntando(Se muestra al usuario - gridview)
        #endregion

        public frmSolicitudPasoJudicial()
        {
            InitializeComponent();

            //GRID  de documentos, aquí el usuario añadirá documentos en su informe de riesgos
            dtDocumentos.Columns.Add("idDocInfRiesgo", typeof(int));
            dtDocumentos.Columns.Add("cNombreArchivo", typeof(string));
            dtDocumentos.Columns.Add("bArchivo", typeof(object));
            dtDocumentos.Columns.Add("lLeido", typeof(bool));


            dtAuxDocs.Columns.Add("idDocInfRiesgo", typeof(int));
            dtAuxDocs.Columns.Add("IconoArchivo", typeof(Image));
            dtAuxDocs.Columns.Add("cNombreArchivo", typeof(string));
            dtAuxDocs.Columns.Add("cDireccionArchivo", typeof(string));
            dtAuxDocs.Columns.Add("lvigente", typeof(bool));
            dtAuxDocs.Columns.Add("lLeido", typeof(bool));

            dtgDocumentos.DataSource = dtAuxDocs;
            dtgDocumentos.Columns["cNombreArchivo"].HeaderText = "Nombre del Archivo";

            //MostrarAlerta();//Si existen solicitudes de Informes de riesgo pendientes de atención se mostrará la cantidad de ellas

            //dialog.Filter = "Documentos Word(*.doc, *.docx)|*.docx;*.doc|Documentos Excel(*.xlsx, *.xls)|*.xlsx;*.xls|Imagenes(*.png, *jpg)|*.png;*.jpg|PDF(*.pdf)|*.pdf";
            dialog.Filter = "Documentos Word(*.doc, *.docx)|*.docx;*.doc|Imagenes(*.png, *jpg)|*.png;*.jpg|PDF(*.pdf)|*.pdf";
        }

        private void frmSolicitudPasoJudicial_Load(object sender, EventArgs e)
        {
            dtCreditos = cnHojaRuta.listaCarteraRecuPasoJudicial(clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.PerfilUsu.idPerfil);
            //dtCreditos = cnHojaRuta.listaCarteraRecuperaciones(clsVarGlobal.PerfilUsu.idUsuario, idUbigeo, nAtrazoMin, nAtrazoMax, nSaldoCapitalMin, nSaldoCapitalMax, chbDireccionPrincipal.Checked, (cboTipoIntervCre1.SelectedIndex == -1) ? 0 : Convert.ToInt32(cboTipoIntervCre1.SelectedValue), clsVarGlobal.PerfilUsu.idPerfil);
           
            dtCreditos.Columns.Add("btnAgregar");

            dtgCarteraCreditos.DataSource = dtCreditos;
            if (dtgCarteraCreditos.RowCount > 0)
            {
                txtNombreCliente.Text = dtgCarteraCreditos.SelectedRows[0].Cells["cNombre"].Value.ToString();
                conDatCredito1.cargardatoscreditoRec(Convert.ToInt32(dtgCarteraCreditos.SelectedRows[0].Cells["idCuenta"].Value)); //////
            }
            DarFormatoGridDocumentos();
            
        }

        private void dtgCarteraCreditos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            conDatCredito1.limpiarcontroles();
            if (dtgCarteraCreditos.Rows.Count > 0)
            {
                txtNombreCliente.Text = dtgCarteraCreditos.SelectedRows[0].Cells["cNombre"].Value.ToString();
                conDatCredito1.cargardatoscreditoRec(Convert.ToInt32(dtgCarteraCreditos.SelectedRows[0].Cells["idCuenta"].Value)); //////
                LimpiarDocs();
                
            }
            txtMotivoTransferencia.Text = "";
        }
        private bool validar()
        {
            bool lVal = false;

            if (dtgCarteraCreditos.CurrentRow == null)
            {
                MessageBox.Show("Por favor seleccione la cuenta de crédito", "Validación de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            if (txtMotivoTransferencia.Text == "")
            {
                MessageBox.Show("Debe hacer ingreso de su Justificación", "Validación de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }
            /*if (Convert.ToBoolean(dtgCarteraCreditos.SelectedRows[0].Cells["lRecupera"].Value) == true)
            {
                MessageBox.Show("Crédito ya se encuentra en recuperación", "Validación de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }*/

            lVal = true;
            return lVal;
        }
        public byte[] CodificarArchivoABytes(string cNombreArchivo)
        {
            return System.IO.File.ReadAllBytes(cNombreArchivo);
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            DataTable dtTempCarteraOrigen = new DataTable();
            DataSet ds = new DataSet();
            ds.Tables.Add(dtTempCarteraOrigen);
            string xml = ds.GetXml();
            if (validar())
            {
                btnGrabar1.Enabled = false;

                int idCuenta = Convert.ToInt32(dtgCarteraCreditos.CurrentRow.Cells["idCuenta"].Value);
                int idCliente = Convert.ToInt32(dtgCarteraCreditos.CurrentRow.Cells["idCli"].Value);

                int nIdInformeJudicial = 0;
                string cMensaje = "";
                for (int i = 0; i < dtAuxDocs.Rows.Count; i++)
                {
                    DataTable dtRespuestaRegSolicitud = solicitud.InsertSolicitudPasoJudicial(idCuenta, 1, clsVarGlobal.dFecSystem,
                        clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, txtMotivoTransferencia.Text,
                        idCliente, (Object)CodificarArchivoABytes(dtAuxDocs.Rows[i]["cDireccionArchivo"].ToString()),
                        dtAuxDocs.Rows[i]["cNombreArchivo"].ToString(), nIdInformeJudicial);
                    if(dtRespuestaRegSolicitud.Rows.Count > 0)
                    {
                        cMensaje = dtRespuestaRegSolicitud.Rows[0][1].ToString();
                        nIdInformeJudicial = Convert.ToInt32(dtRespuestaRegSolicitud.Rows[0][0]);
                        if (nIdInformeJudicial == -1 || nIdInformeJudicial == -2)
                        {
                            break;
                        }
                    }
                }
                if (nIdInformeJudicial == 0)
                {
                    MessageBox.Show("Debe Adjuntar el Sustento para su pase a judicial", "Solicitud paso a Judicial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGrabar1.Enabled = true;
                }
                else if (nIdInformeJudicial == -1)
                {
                    MessageBox.Show("No se a podido realizar el Registro", "Solicitud paso a Judicial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGrabar1.Enabled = true;
                }
                else if (nIdInformeJudicial == -2)
                {
                    MessageBox.Show(cMensaje, "Solicitud paso a Judicial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGrabar1.Enabled = true;
                } 
                else
                {
                    MessageBox.Show("Se ha registrado correctamente la Solicitud a Judicial", "Solicitud paso a Judicial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGrabar1.Enabled = true;
                }
                
            }
        }

        private bool NombreArchivoEsRepetido(string cNombreArchivoASubir)
        {
            bool lRespuesta = false;
            for (int i = 0; i < dtAuxDocs.Rows.Count; i++)
            {
                if (dtAuxDocs.Rows[i]["cNombreArchivo"].ToString().ToUpper().Equals(cNombreArchivoASubir.ToUpper()))
                {
                    lRespuesta = true;
                    break;
                }
            }

            return lRespuesta;
        }

        private void DarFormatoGridDocumentos()
        {
            foreach (DataGridViewColumn column in dtgDocumentos.Columns)
            {
                column.Visible = false;
            }

            dtgDocumentos.Columns["IconoArchivo"].Visible = true;
            dtgDocumentos.Columns["cNombreArchivo"].Visible = true;

            dtgDocumentos.Columns["IconoArchivo"].HeaderText = "";
            dtgDocumentos.Columns["cNombreArchivo"].HeaderText = "Nombre del Archivo";

            dtgDocumentos.Columns["IconoArchivo"].Width = 30;


            //Inmovilizar la clasificación del Grid
            dtgDocumentos.Columns["cNombreArchivo"].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        private void btnAgrDoc_Click(object sender, EventArgs e)//'BOTON AGREGAR Y QUITAR DOCUMENTOS' debebn ser visibles sólo para el perfil que va leer los inf. de riesgos
        {
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //Recuperar el nombre del archivo a Subir
                string[] cAuxNombreArchivo = dialog.FileName.Split('\\');
                string cNombreArchivo = cAuxNombreArchivo[cAuxNombreArchivo.Length - 1];

                if (NombreArchivoEsRepetido(cNombreArchivo))
                {
                    MessageBox.Show("El nombre del archivo ya existe", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //Data que se guardará
                DataRow drDocumento = dtDocumentos.NewRow();
                drDocumento["idDocInfRiesgo"] = 0;
                drDocumento["cNombreArchivo"] = cNombreArchivo;
                dtDocumentos.Rows.Add(drDocumento);

                //Para mostrarlos en pantalla
                DataRow drAuxDoc = dtAuxDocs.NewRow();
                drAuxDoc["idDocInfRiesgo"] = 0;
                drAuxDoc["cNombreArchivo"] = cNombreArchivo;
                drAuxDoc["cDireccionArchivo"] = dialog.FileName;
                drAuxDoc["lVigente"] = true;
                dtAuxDocs.Rows.Add(drAuxDoc);

                CargarIconoArchivosAGrid();
                btnQuitDoc.Enabled = true;

                dtgDocumentos.CurrentCell = null;
                for (int i = 0; i < dtAuxDocs.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dtAuxDocs.Rows[i]["lVigente"]) == false)
                    {
                        dtgDocumentos.Rows[i].Visible = false;
                    }
                }

            }
        }

        private void CargarIconoArchivosAGrid()
        {
            //Asignar el icono del archivo de acuerdo al
            for (int i = 0; i < dtAuxDocs.Rows.Count; i++)
            {
                string[] cExtensionArchivo = dtAuxDocs.Rows[i]["cNombreArchivo"].ToString().Split('.');

                switch (cExtensionArchivo[cExtensionArchivo.Length - 1].ToUpper())
                {
                    case "JPG":
                        //dtgDocumentos.Rows[i].Cells["IconoArchivo"].Value = Properties.Resources.ImgPng;
                        dtgDocumentos.Rows[i].Cells["IconoArchivo"].Value = Properties.Resources.ImgPng;
                        break;
                    case "PNG":
                        dtgDocumentos.Rows[i].Cells["IconoArchivo"].Value = Properties.Resources.ImgPng;
                        break;
                    case "DOC":
                        dtgDocumentos.Rows[i].Cells["IconoArchivo"].Value = Properties.Resources.ImgWord;
                        break;
                    case "DOCX":
                        dtgDocumentos.Rows[i].Cells["IconoArchivo"].Value = Properties.Resources.ImgWord;
                        break;
                    case "XLS":
                        dtgDocumentos.Rows[i].Cells["IconoArchivo"].Value = Properties.Resources.ImgExcel;
                        break;
                    case "XLSX":
                        dtgDocumentos.Rows[i].Cells["IconoArchivo"].Value = Properties.Resources.ImgExcel;
                        break;
                    case "PDF":
                        dtgDocumentos.Rows[i].Cells["IconoArchivo"].Value = Properties.Resources.ImgPdf;
                        break;
                }
            }
        }

        private void btnQuitDoc_Click(object sender, EventArgs e)//'BOTON AGREGAR Y QUITAR DOCUMENTOS' debebn ser visibles sólo para el perfil que va leer los inf. de riesgos
        {
            if (dtgDocumentos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar el documento a eliminar", "Informe de Riesgos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nfilaseleccionada = Convert.ToInt32(this.dtgDocumentos.SelectedRows[0].Index);

            if (nInsertActualiza == 1)//El botón Guardar Insertará un nuevo informe
            {
                dtAuxDocs.Rows.RemoveAt(nfilaseleccionada);
                dtDocumentos.Rows.RemoveAt(nfilaseleccionada);
            }
            else//El botón Guardar editará un informe
            {
                if (Convert.ToInt32(dtAuxDocs.Rows[nfilaseleccionada]["idDocInfRiesgo"]) == 0)//Recién se ha insertado en aplicativo, pero no se insertado en Base de datos
                {
                    //Quitar fila de dtTable (el que se va enviar a Base de Datos)
                    for (int i = 0; i < dtDocumentos.Rows.Count; i++)
                    {
                        if (dtDocumentos.Rows[i]["cNombreArchivo"].ToString().Trim().ToUpper().Equals(dtAuxDocs.Rows[nfilaseleccionada]["cNombreArchivo"].ToString().Trim().ToUpper()))
                        {
                            //Quitar fila de dtTable (el que se va enviar a Base de Datos)
                            dtDocumentos.Rows.RemoveAt(i);
                            break;
                        }
                    }
                    //Quitar fila de dtTable (el que se va mostrar en pantalla)
                    dtAuxDocs.Rows.RemoveAt(nfilaseleccionada);
                }
                else
                {
                    dtAuxDocs.Rows[nfilaseleccionada]["lvigente"] = 0;
                    dtgDocumentos.CurrentCell = null;
                    dtgDocumentos.Rows[nfilaseleccionada].Visible = false;
                }
            }

            if (dtAuxDocs.Rows.Count == 0)
            {
                btnQuitDoc.Enabled = false;
            }
        }
        private void LimpiarDocs()
        {
            int nFilas = dtDocumentos.Rows.Count;
            for (int i = 0; i < nFilas; i++)
            {
                dtAuxDocs.Rows.RemoveAt(0);
                dtDocumentos.Rows.RemoveAt(0);
            }
        }

        private void btnMiniCancelEst1_Click(object sender, EventArgs e)
        {
            LimpiarDocs();
            MessageBox.Show("Los archivos se han eliminado correctamente", "Solicitud paso a Judicial", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dtgCarteraCreditos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
