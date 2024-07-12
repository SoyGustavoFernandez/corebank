using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
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

using GEN.LibreriaOffice;

namespace CRE.Presentacion
{
    public partial class frmCobAfectaciones : frmBase
    {
        #region Variables
        clsCNCondonacion cnCondonacion = new clsCNCondonacion();
        private OpenFileDialog OpenDialog;
        string errorExcel = "";
        DataTable dtErrores;
        int rowIndex = -1;
        int idGrupoAfect = 0;

        bool readOnly;
        int idGrupo;
        #endregion


        public frmCobAfectaciones()
        {
            InitializeComponent();
            OpenDialog = new OpenFileDialog();
        }

        public frmCobAfectaciones(bool readOnly_ = false, int idgrupo_=0)
        {
            InitializeComponent();
            OpenDialog = new OpenFileDialog();
            this.readOnly = readOnly_;
            this.idGrupo = idgrupo_;
        }

        private void frmCobAfectaciones_Load(object sender, EventArgs e)
        {
            cargarDatosIni();
            if (readOnly)
            {
                panelBotones.Visible = false;
                txtIdGrupo.Text = idGrupo.ToString();
                txtIdGrupo.ReadOnly = true;
                buscarGrupo(idGrupo);
            }
        }

        public void cargarDatosIni()
        {
            int idAgencia_ = 0;
            DataTable dt = cnCondonacion.getCobsDisponibles(idAgencia_);
            foreach (DataColumn item in dt.Columns)
            {
                item.ReadOnly = false;
            }


            dtgCobs.DataSource = dt;

            formatearDTG(ref dtgCobs, false);
            btnImprimir1.Enabled = true;
        }

        private void formatearDTG(ref dtgBase dtg, bool lMsg, bool editable = false)
        {
            dtg.ReadOnly = false;
            foreach (DataGridViewColumn item in dtg.Columns)
            {
                item.ReadOnly = true;
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            /*if (!editable)
                dtgCobs.CellValueChanged -= dtgCobs_CellValueChanged;
            else dtgCobs.CellValueChanged += dtgCobs_CellValueChanged;*/

            dtg.Columns["cNombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtg.Columns["lAfectar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtg.Columns["cMsgError"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtg.Columns["cNombreAge"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dtg.Columns["idTipoAfectacion"].Visible = false;
            dtg.Columns["idCli"].Visible = true;
            dtg.Columns["dFecha"].Visible = true;
            dtg.Columns["cNombreAge"].Visible = true;
            dtg.Columns["cNombre"].Visible = !lMsg;
            dtg.Columns["cMoneda"].Visible = !lMsg;
            dtg.Columns["IdKardex"].Visible = true;
            dtg.Columns["nMontoTot"].Visible = true;
            dtg.Columns["idCuenta"].Visible = true;
            dtg.Columns["estadoContable"].Visible = true;
            dtg.Columns["cTipoAfectacion"].Visible = true;
            dtg.Columns["lAfectar"].Visible = true;
            dtg.Columns["cMsgError"].Visible = lMsg;
            dtg.Columns["lVinculo"].Visible = false;

            dtg.Columns["idCli"].HeaderText = "CLIENTE";
            dtg.Columns["dFecha"].HeaderText = "FECHA";
            dtg.Columns["cNombreAge"].HeaderText = "AGENCIA";
            dtg.Columns["cNombre"].HeaderText = "NOMBRES Y APELLIDOS";
            dtg.Columns["cMoneda"].HeaderText = "MON";
            dtg.Columns["IdKardex"].HeaderText = "OPERACION";
            dtg.Columns["nMontoTot"].HeaderText = "MONTO";
            dtg.Columns["idCuenta"].HeaderText = "CUENTA";
            dtg.Columns["estadoContable"].HeaderText = "ESTADO";
            dtg.Columns["cTipoAfectacion"].HeaderText = "ACCION";
            dtg.Columns["lAfectar"].HeaderText = "";
            dtg.Columns["cMsgError"].HeaderText = "Error";

            dtg.Columns["idCli"].ReadOnly = !lMsg;
            dtg.Columns["idCuenta"].ReadOnly = !editable;//false;//!lMsg;
            dtg.Columns["IdKardex"].ReadOnly = !lMsg;
            dtg.Columns["cTipoAfectacion"].ReadOnly = !editable;//false; // --lMsg;
            dtg.Columns["lVinculo"].ReadOnly = false;

            dtg.Columns["dFecha"].DefaultCellStyle.Format = "yyyy-MM-dd";
            dtg.Columns["cMoneda"].Width = 20;

            DataTable dt = (DataTable)dtgCobs.DataSource;
            dtErrores = dt.Clone();
            dtgCobsError.DataSource = dtErrores;

        }

        private void btnExporExcel1_Click(object sender, EventArgs e)
        {
            if (chcExportExcel.Checked)
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Microsoft.Office.Interop.Excel.Application aplicacion;
                        Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                        Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                        aplicacion = new Microsoft.Office.Interop.Excel.Application();
                        libros_trabajo = aplicacion.Workbooks.Add();
                        hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                        int a = 0, b = 0;
                        for (int i = 0; i < dtgCobs.Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                for (int j = 0; j < dtgCobs.Columns.Count; j++)
                                {
                                    if (j <= 9)
                                    {
                                        hoja_trabajo.Cells[i + 1, b + 1] = dtgCobs.Columns[j].HeaderText;
                                        b++;
                                    }
                                }
                            }
                            b = 0;
                            for (int j = 0; j < dtgCobs.Columns.Count; j++)
                            {
                                //if (j != 1 && j <= 8)
                                if (j <= 9)
                                {
                                    if (j == 0)
                                        hoja_trabajo.Cells[i + 2, b + 1] = Convert.ToDateTime(dtgCobs.Rows[i].Cells[j].Value).ToString("yyyy-MM-dd");
                                    else
                                    hoja_trabajo.Cells[i + 2, b + 1] = dtgCobs.Rows[i].Cells[j].Value.ToString();
                                    b++;
                                }
                            }
                        }
                        libros_trabajo.SaveAs(fichero.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                        libros_trabajo.Close(true);
                        MessageBox.Show("Exportado completo", "Busqueda Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        aplicacion.Quit();
                    }
                    catch (SystemException ex)
                    {
                        MessageBox.Show("Error al guardar el archivo \n" + ex.Message, "Busqueda Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                OpenDialog.Filter = "Hojas de Excel(*.xls)|*.xls";
                OpenDialog.ShowDialog();
                string cPath = OpenDialog.FileName;

                try
                {
                    if (String.IsNullOrEmpty(cPath))
                    {
                        return;
                    }
                    btnImprimir1.Enabled = false;
                    formatearDTG(ref dtgCobsError, true, true);

                    ExcelHandler ex = new ExcelHandler();
                    DataTable tabla = ex.ImportExcelToDataTable(cPath);
                    tabla.Columns.Add("lAfectar", typeof(bool));
                    tabla.Columns.Add("cMsgError", typeof(string));
                    tabla.Columns.Add("lVinculo", typeof(int));
                    tabla.Columns.Add("estadoContable", typeof(string));
                    tabla.Columns.Add("idTipoAfectacion", typeof(int));

                    tabla.Columns["CLIENTE"].ColumnName = "idCli";
                    tabla.Columns["CUENTA"].ColumnName = "idCuenta";
                    //tabla.Columns["CODIGO CREDITO"].ColumnName = "idCuenta";
                    tabla.Columns["FECHA"].ColumnName = "dFecha";
                    tabla.Columns["AGENCIA"].ColumnName = "cNombreAge";
                    tabla.Columns["NOMBRES Y APELLIDOS"].ColumnName = "cNombre";
                    tabla.Columns["MON"].ColumnName = "cMoneda";
                    tabla.Columns["OPERACION"].ColumnName = "IdKardex";
                    tabla.Columns["MONTO"].ColumnName = "nMontoTot";
                    tabla.Columns["ACCION"].ColumnName = "cTipoAfectacion";

                    string xmlCOBs = convertDtgXml(tabla);
                    DataTable consultaCOBs = cnCondonacion.validarCOBs(xmlCOBs);

                    foreach (DataRow dtRow in consultaCOBs.Rows)
                    {
                        if (Convert.ToBoolean(dtRow["lKardex"]) && Convert.ToBoolean(dtRow["lCli"]) &&
                            Convert.ToInt32(dtRow["lCuenta"]) == 1 && Convert.ToBoolean(dtRow["lAccion"]) && Convert.ToBoolean(dtRow["lEstadoCuenta"]))
                            activarCobCorrecto(dtRow);
                        else insertarCobError(dtRow);
                    }
                    contarChecks();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Archivo y/o Datos no Válidos, Error al cargar el archivo. \n" + ex.Message, "Cargar archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void activarCobCorrecto(DataRow dtRow)
        {
            //dtgCobs.CellValueChanged -= dtgCobs_CellValueChanged;
            foreach (DataGridViewRow row in dtgCobs.Rows)
            {
                if (row.Cells["IdKardex"].Value.ToString() == dtRow["IdKardex"].ToString())
                {
                    row.Cells["idCuenta"].Value = dtRow["idCuenta"].ToString();
                    row.Cells["estadoContable"].Value = dtRow["estadoContable"].ToString();
                    row.Cells["cTipoAfectacion"].Value = dtRow["cTipoAfectacion"].ToString();
                    row.Cells["idTipoAfectacion"].Value = Convert.ToInt32(dtRow["idTipoAfectacion"]);
                    row.Cells["lAfectar"].Value = 1;
                    row.Cells["lVinculo"].Value = Convert.ToInt32(dtRow["lVinculo"]);
                    break;
                }
            }
            btnGrabar1.Enabled = true;
            //dtgCobs.CellValueChanged += dtgCobs_CellValueChanged;
        }

        public void insertarCobError(DataRow dtRow)
        {
            dtErrores = (DataTable)dtgCobsError.DataSource;
            dtErrores.ImportRow(dtRow);
            panelContent.Visible = true;
        }

        public void addError(string error)
        {
            if (errorExcel != "")
                errorExcel += ", ";
            errorExcel += error;
        }

        private void codCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buscar_datos("idCli", txtIdCliente.Text);
            }
        }

        public void buscar_datos(string campo, string valor)
        {
            bool encontro = false;
           
            foreach (DataGridViewRow Row in dtgCobs.Rows)
            {
                String strFila = Row.Index.ToString();
                string Valor = Convert.ToString(Row.Cells[campo].Value);

                if (Valor == valor)
                {
                    dtgCobs.Rows[Convert.ToInt32(strFila)].Selected = true;
                    dtgCobs.FirstDisplayedScrollingRowIndex = Convert.ToInt32(strFila);
                    dtgCobs.Focus();
                    encontro = true;
                    break;
                }
            }

            if (encontro == false)
            {
                MessageBox.Show("Codigo no encontrado", "Busqueda Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private bool verificarDecimal(string nValue)
        {
            decimal d;
            if (decimal.TryParse(nValue, out d))
            {
                return false;
            }

            else
            {
                return true;
            }

        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            cargarDatosIni();
            panelContent.Visible = false;
            contarChecks();
            txtIdGrupo.Text = "";
            btnExporExcel1.Enabled = true;
            lEditado.Enabled = true;
            btnImprimir1.Enabled = true;
            idGrupoAfect = 0;
            chcExportExcel.Enabled = true;
            txtComentario.Text = "";
        }

        public void contarChecks()
        {
            int correctos = 0;
            int incorrectos = 0;
            decimal monto = 0;
            foreach (DataGridViewRow Row in dtgCobs.Rows)
            {
                if (Convert.ToBoolean(Row.Cells["lAfectar"].Value))
                {
                    correctos++;
                    monto += Convert.ToDecimal(Row.Cells["nMontoTot"].Value);
                }
            }
            incorrectos = dtgCobsError.RowCount;
            txtCorrectos.Text = correctos.ToString();
            txtIncorrectos.Text = incorrectos.ToString();
            txtTotal.Text = (correctos + incorrectos).ToString();
            btnGrabar1.Enabled = Convert.ToBoolean(correctos);
            panelContent.Visible = Convert.ToBoolean(incorrectos);
            if (correctos == 0)
                btnGrabar1.Enabled = false;
            txtMontoTotal.Text = monto.ToString();
        }

        private void buscar_operacion(int i)
        {
            bool encontro = false;
            foreach (DataGridViewRow Row in dtgCobs.Rows)
            {
                //String strFila = Row.Index.ToString();
                string Valor = Convert.ToString(Row.Cells["idCli"].Value);

                if (Row.Cells["IdKardex"].Value.ToString() == dtgCobsError.Rows[i].Cells["IdKardex"].Value.ToString())
                {
                    dtgCobs.Rows[Row.Index].Selected = true;
                    dtgCobs.FirstDisplayedScrollingRowIndex = Row.Index;
                    dtgCobs.Focus();
                    encontro = true;
                    break;
                }
            }
            if (!encontro)
            {
                dtgCobs.ClearSelection();
            }
        }

        private void dtgCobsError_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            if (rowIndex >= 0)
                btnAceptarCob.Enabled = true;
            else btnAceptarCob.Enabled = false;
            if (e.RowIndex >= 0)
                buscar_operacion(e.RowIndex);
        }

        public string convertDtgXml(DataTable dt)
        {
            dt.TableName = "cobs";
            DataSet ds = new DataSet();
            if (dt.DataSet != null)
                ds = dt.DataSet;
            else
                ds.Tables.Add(dt);
            return ds.GetXml();
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (rowIndex != -1)
            {
                validarVincCuenta(dtgCobsError.Rows[rowIndex].Cells["idCli"].Value.ToString()
                    , dtgCobsError.Rows[rowIndex].Cells["idCuenta"].Value.ToString()
                    , Convert.ToDateTime(dtgCobsError.Rows[rowIndex].Cells["dFecha"].Value).ToString("yyyy-MM-dd")
                    , dtgCobsError.Rows[rowIndex].Cells["cNombre"].Value.ToString()
                    , dtgCobsError.Rows[rowIndex].Cells["cMoneda"].Value.ToString()
                    , dtgCobsError.Rows[rowIndex].Cells["IdKardex"].Value.ToString()
                    , dtgCobsError.Rows[rowIndex].Cells["nMontoTot"].Value.ToString()
                    , dtgCobsError.Rows[rowIndex].Cells["cTipoAfectacion"].Value.ToString()
                    );
            }
        }

        private void validarVincCuenta(string cIdCli, string cIdCuenta, string dFecha, string cNombre, string cMoneda, string IdKardex, string cMontoTotal, string cTipoAfectacion, bool lSubirCob = true)
        {
            string xmlRow = "<NewDataSet><cobs><idCli>"
                + cIdCli +
                "</idCli><idCuenta>"
                + cIdCuenta +
                "</idCuenta><dFecha>"
                + dFecha +
                "</dFecha><cNombre>"
                + cNombre +
                "</cNombre><cMoneda>"
                + cMoneda +
                "</cMoneda><IdKardex>"
                + IdKardex +
                "</IdKardex><nMontoTot>"
                + cMontoTotal +
                "</nMontoTot><cTipoAfectacion>"
                + cTipoAfectacion +
                "</cTipoAfectacion></cobs></NewDataSet>";
            DataTable consultaCOBs = cnCondonacion.validarCOBs(xmlRow);
            if (Convert.ToBoolean(consultaCOBs.Rows[0]["lKardex"]) && Convert.ToBoolean(consultaCOBs.Rows[0]["lCli"]) &&
                Convert.ToInt32(consultaCOBs.Rows[0]["lCuenta"]) == 1 && Convert.ToBoolean(consultaCOBs.Rows[0]["lAccion"]) && Convert.ToBoolean(consultaCOBs.Rows[0]["lEstadoCuenta"]) )
            {
                activarCobCorrecto(consultaCOBs.Rows[0]);
                if (lSubirCob)
                    dtgCobsError.Rows.RemoveAt(rowIndex);
                rowIndex = -1;
            }
            else if (Convert.ToBoolean(consultaCOBs.Rows[0]["lKardex"]) && Convert.ToBoolean(consultaCOBs.Rows[0]["lCli"]) && !Convert.ToBoolean(consultaCOBs.Rows[0]["lCuenta"]) && Convert.ToBoolean(consultaCOBs.Rows[0]["lAccion"]) )
            {
                frmMsgAdvertencia msg = new frmMsgAdvertencia("Advertencia de Vinculación de COB's de Terceros", "Se está intentando vincular la COB de terceros de código de operación Nro.:" + consultaCOBs.Rows[0]["IdKardex"] + ". Cualquier responsabilidad será asumida por su usuario: " + clsVarGlobal.User.cWinUser);
                msg.ShowDialog();
                DialogResult dr = msg.dRes;

                if (dr == DialogResult.OK)
                {
                    consultaCOBs.Columns["lVinculo"].ReadOnly = false;
                    consultaCOBs.Rows[0]["lVinculo"] = 0;
                    activarCobCorrecto(consultaCOBs.Rows[0]);
                    if (lSubirCob)
                    {
                        dtgCobsError.Rows.RemoveAt(rowIndex);
                        rowIndex = -1;
                    }
                }
            }
            else
            {
                MessageBox.Show(consultaCOBs.Rows[0]["cMsgError"].ToString(), "Busqueda Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (lSubirCob)
                    dtgCobsError.Rows[rowIndex].Cells["cMsgError"].Value = consultaCOBs.Rows[0]["cMsgError"].ToString();
            }
            contarChecks();
        }

        private void dtgCobs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgCobs.Columns["lAfectar"].Index && lEditado.Checked)
            {
                dtgCobs.Rows[e.RowIndex].Cells["lAfectar"].Value = 0;
                dtgCobs.Rows[e.RowIndex].Cells["idCuenta"].Value = "";
                dtgCobs.Rows[e.RowIndex].Cells["estadoContable"].Value = "";
                dtgCobs.Rows[e.RowIndex].Cells["cTipoAfectacion"].Value = "";
                dtgCobs.Rows[e.RowIndex].Cells["idTipoAfectacion"].Value = 0;
                dtgCobs.Rows[e.RowIndex].Cells["lVinculo"].Value = 1;
                contarChecks();
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if(txtComentario.Text == "")
                MessageBox.Show("Debe registrar el Comentario para este Grupo", "Registro Grupo de COBs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (Convert.ToInt32(txtCorrectos.Text) != 0)
            {
                string CobsXml = convertDtgXml((DataTable)dtgCobs.DataSource);
            
                DataTable res = cnCondonacion.insertarGrupoCobsAfectaciones(CobsXml, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, TiposGrupoAfectacion.AfectacionGrupal,txtComentario.Text);

                MessageBoxIcon icono = new MessageBoxIcon();
                icono = MessageBoxIcon.Exclamation;
                string mensaje = res.Rows[0]["cMensaje"].ToString();
                if (Convert.ToBoolean(res.Rows[0]["lEstadoProc"]))
                {
                    icono = MessageBoxIcon.Information;
                    clsGestionaNivelAprobacion objNivelAproba = new clsGestionaNivelAprobacion(Convert.ToInt32(res.Rows[0]["idSolicitudAproba"]), Convert.ToInt32(res.Rows[0]["idModulo"]), Convert.ToInt32(res.Rows[0]["idTipoOperacion"]));
                    mensaje = mensaje + "\n" + objNivelAproba.obtenerNivelAprobacionSolicitud(EstadoAprobacion.SolicitadoAfectacion);
                    //MessageBox.Show(objNivelAproba.obtenerNivelAprobacionSolicitud(), this.cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                MessageBox.Show(mensaje, "Registro Grupo de COBs", MessageBoxButtons.OK, icono);
                txtIdGrupo.Text = res.Rows[0]["idGrupo"].ToString();
                if (Convert.ToBoolean(res.Rows[0]["lEstadoProc"]))
                    buscarGrupo(Convert.ToInt32(res.Rows[0]["idGrupo"]));
            }
            else
                MessageBox.Show("Debe registrar almenos una COB", "Registro Grupo de COBs", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 
        }

        private void txtIdGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buscarGrupo(Convert.ToInt32(txtIdGrupo.Text));
               
            }
        }

        public void buscarGrupo(int idGrupo)
        {
            idGrupoAfect = idGrupo;
            btnExporExcel1.Enabled = false;
            lEditado.Enabled = false;
            chcExportExcel.Enabled = false;
            ((DataTable)dtgCobsError.DataSource).Clear();
            DataTable cobsGrupo = cnCondonacion.ListarCobsGrupo(idGrupo);
            if (cobsGrupo.Rows.Count > 0)
            {
                txtComentario.Text = cobsGrupo.Rows[0]["sustento"].ToString();
                cobsGrupo.Columns.Remove("sustento");
            }
            if (cobsGrupo.Rows.Count > 0)
            {
                dtgCobs.DataSource = cobsGrupo;
                contarChecks();
                btnGrabar1.Enabled = false;
                btnImprimir1.Enabled = true;
            }
            else
            {
                MessageBox.Show("No se encontro Grupo", "Busqueda de Grupo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //btnImprimir1.Enabled = false;
                ((DataTable)dtgCobs.DataSource).Clear();
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            List<ReportParameter> paramList = new List<ReportParameter>();
            List<ReportDataSource> dtsList = new List<ReportDataSource>();
            DataTable datos = (DataTable)dtgCobs.DataSource;
            dtsList.Add(new ReportDataSource("dtsCobs", datos));

            paramList.Add(new ReportParameter("idGrupo", idGrupoAfect.ToString(), false));
            paramList.Add(new ReportParameter("cNomUser", clsVarGlobal.User.cWinUser, false));
            paramList.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
            paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            string reportPath = "rptCobsGrupo.rdlc";
            new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
        }

        private void btnExporExcel2_Click(object sender, EventArgs e)
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xlsx)|*.xlsx";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add();
                    hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                    for (int i = 0; i < dtgCobsError.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            for (int j = 0; j < dtgCobsError.Columns.Count; j++)
                            {
                                if (j != 8 || j != 10)
                                    hoja_trabajo.Cells[i + 1, j + 1] = dtgCobsError.Columns[j].HeaderText;
                            }
                        }
                        for (int j = 0; j < dtgCobsError.Columns.Count; j++)
                        {
                            if (j != 8 || j != 10)
                                hoja_trabajo.Cells[i + 2, j + 1] = dtgCobsError.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    libros_trabajo.SaveAs(fichero.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    MessageBox.Show("Exportado completo", "Busqueda Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    aplicacion.Quit();
                }
                catch (SystemException ex)
                {
                    MessageBox.Show("Error al guardar el archivo", "Busqueda Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void txtIdCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buscar_datos("idCuenta", txtIdCuenta.Text);
            }
        }

        private void txtIdKardex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buscar_datos("IdKardex", txtIdKardex.Text);
            }
        }

        private void chcExportExcel_CheckedChanged(object sender, EventArgs e)
        {
            cargarDatosIni();
            panelContent.Visible = false;
            lEditado.Checked = false;
            bool est = chcExportExcel.Checked;
            btnCancelar1.Visible = !est;
            btnGrabar1.Visible = !est;
            btnImprimir1.Visible = !est;
            txtComentario.Text = "";
        }

        private void lEditado_CheckedChanged(object sender, EventArgs e)
        {
            chcExportExcel.Checked = false;
            btnExporExcel1.Enabled = !lEditado.Checked;
            btnGrabar1.Enabled = !lEditado.Checked;
            btnImprimir1.Enabled = !lEditado.Checked;
            contarChecks();
        }
        
    }

}
