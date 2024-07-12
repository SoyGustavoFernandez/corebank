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
using Excel = Microsoft.Office.Interop.Excel;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Reporting.WinForms;

namespace CRE.Presentacion
{
    public partial class frmAsignaMetasArchivo : frmBase
    {
        #region Variables Globales

        private clsCNMeta objCNMeta { get; set; }
        private Excel.Application appExcel { get; set; }
        private Excel.Workbook workBookExcel { get; set; }
        private Excel.Worksheet workSheetExcel { get; set; }
        private string cDireccionRuta { get; set; }
        private int idUsuario { get; set; }
        private string xmlMetasCredito { get; set; }
        private List<clsMetaCreditoCarga> lstMetaCreditoCargaOriginal { get; set; }
        private List<clsMetaCreditoCarga> lstMetaCreditoCargaArchivo { get; set; }
        private List<clsMetaCreditoCarga> lstMetaCreditoCargaActual { get; set; }
        private BindingSource bsMetaCredito { get; set; }

        private int nIndexUltimoCambio { get; set; }
        private string cValorCeldaActual { get; set; }
        private TextBox txtActual { get; set; }
        private bool lCancelar { get; set; }


        #endregion

        public frmAsignaMetasArchivo()
        {
            InitializeComponent();
            CargarVariableDefecto();
            ActivarControles(1);
        }

        #region Eventos
        private void frmAsignaMetas_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            nudAnio.Value = clsVarGlobal.dFecSystem.Year;
            cboMes.SelectedValue = clsVarGlobal.dFecSystem.Month;
            CargarComponentes();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            ActivarControles(4);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int idAgencia = (cboAgencia.SelectedIndex != -1) ? Convert.ToInt32(cboAgencia.SelectedValue) : -1 ;
            int nMes = (cboMes.SelectedIndex != -1) ? Convert.ToInt32(cboMes.SelectedValue) : -1 ;
            int nAnio = Convert.ToInt32(nudAnio.Value);
            bool lSoloAsesoresNuevos = chcAsesoresNuevos.Checked;
            bool lSoloAsesoresCesados = chcAsesoresCesados.Checked;

            if (idAgencia == -1 &&  nMes == -1)
            {
                MessageBox.Show("Debe seleccionar la agencia, el año y el mes para generar el reporte", "Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DataTable dtMetasCreditos = objCNMeta.CNConsultaDatosMetaActualReporte(idAgencia, nMes, nAnio, lSoloAsesoresNuevos, lSoloAsesoresCesados);

            paramlist.Add(new ReportParameter("cNomEmp", clsVarApl.dicVarGen["cNomEmpresa"], false));
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cUsuWin", clsVarGlobal.User.cNomUsu, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            dtslist.Add(new ReportDataSource("dsMetasCreditos", dtMetasCreditos));

            string reportpath = "rptMetasCreditos.rdlc";

            frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmReporte.rpvReporteLocal.SetDisplayMode(DisplayMode.PrintLayout);
            frmReporte.ShowDialog();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ConsultarDatosMetas();
            ActivarControles(2);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            int nMesActual = clsVarGlobal.dFecSystem.Month;
            int nAnioActual = clsVarGlobal.dFecSystem.Year;

            int idAgencia = (cboAgencia.SelectedIndex != -1) ? Convert.ToInt32(cboAgencia.SelectedValue) : 0;
            int nMes = (cboMes.SelectedIndex != -1) ? Convert.ToInt32(cboMes.SelectedValue) : 0;
            int nAnio = Convert.ToInt32(nudAnio.Value);
            string cMes = (cboMes.SelectedIndex != -1) ? Convert.ToString(cboMes.Text) : String.Empty;

            if (!(nMesActual == nMes && nAnioActual == nAnio))
            {
                if (nMesActual != nMes && nAnioActual != nAnio)
                {
                    DialogResult drRespuesta = MessageBox.Show("Las metas se grabará en el mes de: " + cMes + " del " + nAnio + ". ¿Está seguro de continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (drRespuesta == DialogResult.No)
                    {
                        return;
                    }
                }
                else if (nMesActual != nMes)
                {
                    DialogResult drRespuesta = MessageBox.Show("Las metas se grabará en el mes de: " + cMes + ". ¿Está seguro de continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (drRespuesta == DialogResult.No)
                    {
                        return;
                    }
                }
                else if(nAnioActual != nAnio)
                {
                    DialogResult drRespuesta = MessageBox.Show("Las metas se grabará en el mes de: " + cMes + " del "+ nAnio+". ¿Está seguro de continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (drRespuesta == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            else
            {
                DialogResult drRespuesta = MessageBox.Show("Las Metas van ha ser grabadas ¿Está seguro de continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (drRespuesta == DialogResult.No)
                {
                    return;
                }
            }

            List<clsMetaCreditoCarga> lstRegistrosModificados = ObtenerListaMetasModificadas();
            DataSet dsMetasCreditos = new DataSet();
            DataTable dtRegistroModificados = ConvertirDataTable(lstRegistrosModificados);

            dsMetasCreditos.DataSetName = "dsMetasCreditos";
            dtRegistroModificados.TableName = "dtMetasCreditoModificado";
            
            dsMetasCreditos.Tables.Add(dtRegistroModificados);
            xmlMetasCredito = dsMetasCreditos.GetXml();
            xmlMetasCredito = clsCNFormatoXML.EncodingXML(xmlMetasCredito);

            DataTable dtResultado = objCNMeta.CNActualizarMetasCreditosModificados(xmlMetasCredito, idAgencia, nMes, nAnio);
            if(Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) != -1)
            {
                MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), "Registro Metas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnConsultar.PerformClick();
            }
            else
            {
                MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), "Registro Metas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "Office Files|*.xls;*.xlsx";
            objOpenFileDialog.InitialDirectory = @"C:\";
            objOpenFileDialog.Title = "Seleccion el archivo de carga de metas";

            DialogResult drResultado = objOpenFileDialog.ShowDialog();

            if (drResultado == DialogResult.OK)
            {
                if (objOpenFileDialog.SafeFileName != String.Empty)
                {
                    DialogResult drConsulta = MessageBox.Show("¿Está seguro de cargar el archivo seleccionado?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (drConsulta == DialogResult.Yes)
                    {
                        cDireccionRuta = objOpenFileDialog.FileName;
                        this.txtUbicacionArchivo.Text = cDireccionRuta;
                        CargarDatosMetaCredito();
                        if (lCancelar == true)
                            return;
                        FormatearModificacion();
                        ActivarControles(5);
                    }
                    else
                    {
                        txtUbicacionArchivo.Clear();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No selecciono un archivo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void dtgMetas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dtgMetas.CurrentCell.Value != null)
            {
                this.cValorCeldaActual = this.dtgMetas.CurrentCell.Value.ToString();
            }

            txtActual = e.Control as TextBox;
            if (txtActual != null)
            {
                txtActual.LostFocus -= new EventHandler(txtActual_LostFocus);
                txtActual.LostFocus += new EventHandler(txtActual_LostFocus);
            }
        }

        private void txtActual_LostFocus(object sender, EventArgs e)
        {
            if (!this.txtActual.Text.Equals(this.cValorCeldaActual))
            {
                this.dtgMetas.CurrentRow.Cells["idEstadoMetaModificacion"].Value = 2;
                this.dtgMetas.CurrentRow.DefaultCellStyle.BackColor = Color.LightBlue;
                if (Convert.ToInt32(this.dtgMetas.CurrentRow.Cells["idEstadoAsesor"].Value) == 2)
                {
                    this.dtgMetas.CurrentRow.DefaultCellStyle.BackColor = Color.MistyRose;
                }
                CalcularTotales(lstMetaCreditoCargaActual);
            }
        }

        private void btnExporExcel_Click(object sender, EventArgs e)
        {
            int idAgencia = 0;
            int nMes = (cboMes.SelectedIndex != -1) ? Convert.ToInt32(cboMes.SelectedValue) : -1;
            int nAnio = Convert.ToInt32(nudAnio.Value);
            bool lSoloAsesoresNuevos = chcAsesoresNuevos.Checked;
            bool lSoloAsesoresCesados = chcAsesoresCesados.Checked;

            if (idAgencia == -1 && nMes == -1)
            {
                MessageBox.Show("Debe seleccionar la agencia, el año y el mes para generar el reporte", "Plan de Pagos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            DataTable dtMetasCreditos = objCNMeta.CNConsultaDatosMetaActualReporte(idAgencia, nMes, nAnio, lSoloAsesoresNuevos, lSoloAsesoresCesados);

            paramlist.Add(new ReportParameter("cNomEmp", clsVarApl.dicVarGen["cNomEmpresa"], false));
            paramlist.Add(new ReportParameter("cNombreAge", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cUsuWin", clsVarGlobal.User.cNomUsu, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

            dtslist.Add(new ReportDataSource("dsMetasCreditos", dtMetasCreditos));

            string reportpath = "rptMetasCreditosExcel.rdlc";

            frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportpath, paramlist, enuFormatoReporte.Excel);
            frmReporte.ShowDialog();
        }

        private void dtgMetas_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dtgMetas.CurrentCell.Style = new DataGridViewCellStyle { SelectionBackColor = System.Drawing.SystemColors.Highlight, ForeColor = System.Drawing.Color.Black };
        }

        private void dtgMetas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.dtgMetas.CurrentCell.ReadOnly)
            {
                dtgMetas.CurrentCell.Style = new DataGridViewCellStyle { SelectionBackColor = System.Drawing.Color.White, ForeColor = System.Drawing.Color.Black };
            }
        }

        #endregion

        #region Métodos
        private void CargarVariableDefecto()
        {
            txtActual = new TextBox();
            objCNMeta                   = new clsCNMeta();
            appExcel                    = null;
            workBookExcel               = null;
            workSheetExcel              = null;
            cDireccionRuta              = String.Empty;
            idUsuario                   = clsVarGlobal.User.idUsuario;
            xmlMetasCredito             = String.Empty;
            lstMetaCreditoCargaOriginal = new List<clsMetaCreditoCarga>();
            lstMetaCreditoCargaArchivo  = new List<clsMetaCreditoCarga>();
            lstMetaCreditoCargaActual   = new List<clsMetaCreditoCarga>();
            bsMetaCredito               = new BindingSource();
            bsMetaCredito.DataSource    = lstMetaCreditoCargaActual;
            dtgMetas.DataSource         = bsMetaCredito;
            bsMetaCredito.ResetBindings(false);
            txtActual.Text              = String.Empty;
            lCancelar                   = false;
            dtgMetas.Refresh();
        }

        private void CargarComponentes()
        {
            cboAgencia.AgenciasYTodos();
            cboAgencia.SelectedValue = 0;
            FormatearGridMetas();
        }

        private void FormatearGridMetas()
        {
            dtgMetas.ReadOnly = false;
            dtgMetas.CellBorderStyle = DataGridViewCellBorderStyle.Raised;

            foreach(DataGridViewColumn column in dtgMetas.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.Visible = false;
                column.HeaderText = column.Name;
                column.ReadOnly = true;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }
            dtgMetas.Columns["cDesZona"].Visible                    = true;
            dtgMetas.Columns["idAgencia"].Visible                   = true;
            dtgMetas.Columns["cAgenciaCarga"].Visible               = true;
            dtgMetas.Columns["cEstablecimientoEOBCarga"].Visible    = true;
            dtgMetas.Columns["idUsuario"].Visible                   = true;
            dtgMetas.Columns["cAsesorCarga"].Visible                = true;
            dtgMetas.Columns["cCargo"].Visible                      = true;
            dtgMetas.Columns["nCrecimientoClientes"].Visible        = true;
            dtgMetas.Columns["nClientesNuevos"].Visible             = true;
            dtgMetas.Columns["nMetaSaldo"].Visible                  = true;

            dtgMetas.Columns["cDesZona"].HeaderText                     = "Zona";
            dtgMetas.Columns["idAgencia"].HeaderText                    = "Cod. Agencia";
            dtgMetas.Columns["cAgenciaCarga"].HeaderText                = "Agencia";
            dtgMetas.Columns["cEstablecimientoEOBCarga"].HeaderText     = "EOB";
            dtgMetas.Columns["idUsuario"].HeaderText                    = "Cod. Usuario";
            dtgMetas.Columns["cAsesorCarga"].HeaderText                 = "Nombre Asesor";
            dtgMetas.Columns["cCargo"].HeaderText                       = "Cargo";
            dtgMetas.Columns["nCrecimientoClientes"].HeaderText         = "Meta Crecimiento";
            dtgMetas.Columns["nClientesNuevos"].HeaderText              = "Meta Clientes Nuevos";
            dtgMetas.Columns["nMetaSaldo"].HeaderText                   = "Meta Saldo";

            dtgMetas.Columns["cDesZona"].Width                  = 100;
            dtgMetas.Columns["idAgencia"].Width                 = 60;
            dtgMetas.Columns["cAgenciaCarga"].Width             = 140;
            dtgMetas.Columns["cEstablecimientoEOBCarga"].Width  = 120;
            dtgMetas.Columns["idUsuario"].Width                 = 60;
            dtgMetas.Columns["cAsesorCarga"].Width              = 150;
            dtgMetas.Columns["cCargo"].Width                    = 100;
            dtgMetas.Columns["nCrecimientoClientes"].Width      = 100;
            dtgMetas.Columns["nClientesNuevos"].Width           = 75;
            dtgMetas.Columns["nMetaSaldo"].Width                = 75;


            dtgMetas.Columns["nCrecimientoClientes"].ReadOnly   = false;
            dtgMetas.Columns["nClientesNuevos"].ReadOnly        = false;
            dtgMetas.Columns["nMetaSaldo"].ReadOnly             = false;

        }

        public void FormatearModificacion()
        {
            foreach(DataGridViewRow dgrMeta in dtgMetas.Rows)
            {
                clsMetaCreditoCarga objMeta = (clsMetaCreditoCarga)dgrMeta.DataBoundItem;

                if(objMeta.idEstadoMetaModificacion == 2)
                {
                    dgrMeta.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                if(objMeta.idEstadoAsesor == 2)
                {
                    dgrMeta.DefaultCellStyle.BackColor = Color.LightPink;
                }
                else if(objMeta.idEstadoAsesor == 3)
                {
                    dgrMeta.DefaultCellStyle.BackColor = Color.PaleGreen;
                }
            }
        }

        public void CalcularTotales(List<clsMetaCreditoCarga> lstMetaCreditosCalculo)
        {
            decimal nTotalMetaSaldo = 0;
            int nTotalMetaCrecimiento = 0;
            int nTotalMetaClientesNuevos = 0;

            nTotalMetaSaldo = lstMetaCreditosCalculo.Sum(item => item.nMetaSaldo);
            nTotalMetaCrecimiento = lstMetaCreditosCalculo.Sum(item => Convert.ToInt32(item.nCrecimientoClientes));
            nTotalMetaClientesNuevos = lstMetaCreditosCalculo.Sum(item => Convert.ToInt32(item.nClientesNuevos));

            txtMetaSaldo.Text = Convert.ToString(nTotalMetaSaldo);
            txtMetaCrecimiento.Text = Convert.ToString(nTotalMetaCrecimiento);
            txtMetaCienteNuevo.Text = Convert.ToString(nTotalMetaClientesNuevos);
        }

        private void CargarDatosMetaCredito()
        {
            bool lValor = true;
            appExcel = new Excel.Application();
            workBookExcel = appExcel.Workbooks.Open(cDireccionRuta, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            workSheetExcel = workBookExcel.Worksheets.get_Item(1);
            lstMetaCreditoCargaArchivo.Clear();

            int i = 2;
            
            while(lValor)
            {
                clsMetaCreditoCarga objMetaCreditoCarga = new clsMetaCreditoCarga();
                objMetaCreditoCarga.cDesZona                        = Convert.ToString((workSheetExcel.Cells[i, 1] as Excel.Range).Value2);
                objMetaCreditoCarga.idAgencia                       = Convert.ToInt32((workSheetExcel.Cells[i, 2] as Excel.Range).Value2);
                objMetaCreditoCarga.cAgenciaCarga                   = Convert.ToString((workSheetExcel.Cells[i, 3] as Excel.Range).Value2);
                objMetaCreditoCarga.cEstablecimientoEOBCarga        = Convert.ToString((workSheetExcel.Cells[i, 4] as Excel.Range).Value2);
                objMetaCreditoCarga.idUsuario                       = Convert.ToInt32((workSheetExcel.Cells[i, 5] as Excel.Range).Value2);
                objMetaCreditoCarga.cAsesorCarga                    = Convert.ToString((workSheetExcel.Cells[i, 6] as Excel.Range).Value2);
                objMetaCreditoCarga.idTipoMetaSaldo                 = 2;
                objMetaCreditoCarga.nMetaSaldo                      = Convert.ToDecimal((workSheetExcel.Cells[i, 7] as Excel.Range).Value2);
                objMetaCreditoCarga.idTipoMetaCrecimiento           = 1;
                objMetaCreditoCarga.nCrecimientoClientes            = Convert.ToInt32((workSheetExcel.Cells[i, 8] as Excel.Range).Value2);
                objMetaCreditoCarga.idTipoMetaClientesNuevos        = 11;
                objMetaCreditoCarga.nClientesNuevos                 = Convert.ToInt32((workSheetExcel.Cells[i, 9] as Excel.Range).Value2);
                objMetaCreditoCarga.idEstadoMetaModificacion        = 2;
                objMetaCreditoCarga.idEstadoAsesor                  = 1 ;

                bool lValidar = String.IsNullOrEmpty(objMetaCreditoCarga.cDesZona) &&
                                objMetaCreditoCarga.idAgencia == 0 &&
                                String.IsNullOrEmpty(objMetaCreditoCarga.cAgenciaCarga) &&
                                String.IsNullOrEmpty(objMetaCreditoCarga.cEstablecimientoEOBCarga) &&
                                objMetaCreditoCarga.idUsuario == 0 &&
                                String.IsNullOrEmpty(objMetaCreditoCarga.cAsesorCarga) &&
                                objMetaCreditoCarga.nMetaSaldo == 0 &&
                                objMetaCreditoCarga.nCrecimientoClientes == 0 &&
                                objMetaCreditoCarga.nClientesNuevos == 0;
                if (lValidar)
                {
                    lValor = false;
                }
                else
                {
                    lstMetaCreditoCargaArchivo.Add(objMetaCreditoCarga);
                }
                i++;
            }
            List<int> lstIdDuplicados = lstMetaCreditoCargaArchivo.GroupBy(x => x.idUsuario).Where(item => item.Count() > 1).Select(item => item.Key).ToList();
            List<clsMetaCreditoCarga> lstTemporal = lstMetaCreditoCargaArchivo.Where(item => lstIdDuplicados.Contains(item.idUsuario) && item.idUsuario != 0).OrderBy(item => item.idUsuario).ToList();

            string cMensaje = String.Empty;
            int nMaxLista = 5;
            int nNumeroMostrado = 0;
            cMensaje = "Se está intentando cargar las metas de los siguientes asesores múltiples veces, revisar el archivo cargado:\n";
            foreach (clsMetaCreditoCarga objMetaCredito in lstTemporal)
            {
                if (nNumeroMostrado == nMaxLista)
                {
                    int nTotalRestante = lstTemporal.Count - nNumeroMostrado;
                    cMensaje += (nTotalRestante > 0) ? "(" + nTotalRestante + ") Mas." : String.Empty;
                    break;
                }

                string cEOL = (nNumeroMostrado < nMaxLista) ? "\n" : String.Empty;
                cMensaje += "-  " + objMetaCredito.idUsuario + " - " + objMetaCredito.cAsesorCarga + "." + cEOL;
                nNumeroMostrado++;
            }
            if (lstTemporal.Count > 0)
            {
                MessageBox.Show(cMensaje, "Asignación Metas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                ActivarControles(4);
                lCancelar = true;
                return;
            }

            CombinarDatosActualArchivo();

            CalcularTotales(lstMetaCreditoCargaActual);

            bsMetaCredito.ResetBindings(false);
            dtgMetas.Refresh();

            workBookExcel.Close(false, null, null);
            appExcel.Quit();
            LiberarObjeto(workSheetExcel);
            LiberarObjeto(workBookExcel);
            LiberarObjeto(appExcel);
        }

        private void ConsultarDatosMetas()
        {
            int nMes = Convert.ToInt32(cboMes.SelectedValue);
            int nAnio = Convert.ToInt32(nudAnio.Value);
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
            bool lSoloAsesoresNuevos = chcAsesoresNuevos.Checked;
            bool lSoloAsesoresCesados = chcAsesoresCesados.Checked;

            lstMetaCreditoCargaOriginal = objCNMeta.CNConsultaDatosMetaActual(idAgencia, nMes, nAnio, lSoloAsesoresNuevos, lSoloAsesoresCesados);
            lstMetaCreditoCargaActual = lstMetaCreditoCargaOriginal;
            
            bsMetaCredito.DataSource = lstMetaCreditoCargaActual;
            bsMetaCredito.ResetBindings(false);
            dtgMetas.Refresh();

            if (lstMetaCreditoCargaActual.Count == 0)
            {
                MessageBox.Show("Aun no estan asignadas las metas", "Asignación Metas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            CalcularTotales(lstMetaCreditoCargaActual);

            btnGrabar.Enabled = true;
            FormatearModificacion();
        }

        private void CombinarDatosActualArchivo()
        {
            lstMetaCreditoCargaOriginal = lstMetaCreditoCargaActual;
            int nMes = Convert.ToInt32(cboMes.SelectedValue);
            int nAnio = Convert.ToInt32(nudAnio.Value);
            int idAgencia = (cboAgencia.SelectedIndex != -1) ? Convert.ToInt32(cboAgencia.SelectedValue) : 0 ;

            List<clsMetaCreditoCarga> lstMetaCreditoFiltrado = lstMetaCreditoCargaArchivo;
            List<clsMetaCreditoCarga> lstMetaCreditoConsulta = objCNMeta.CNConsultaDatosMetaActual(0, nMes, nAnio);


            List<clsMetaCreditoCarga> lstMetasExcluidos = lstMetaCreditoFiltrado.Except(lstMetaCreditoConsulta, new clsMetaCreditoCompareExcluidos()).OrderBy(item => item.idUsuario).ToList();

            string cMensaje = String.Empty;
            int nMaxLista = 5;
            int nNumeroMostrado = 0;
            cMensaje = "Los siguientes Asesores no tiene la configuracion adecuada para la asignación de Metas:\n";
            foreach(clsMetaCreditoCarga objMetaCredito in lstMetasExcluidos)
            {
                if (nNumeroMostrado == nMaxLista)
                {
                    int nTotalRestante = lstMetasExcluidos.Count - nNumeroMostrado;
                    cMensaje += (nTotalRestante > 0) ? "(" + nTotalRestante + ") Mas." : String.Empty;
                    break;
                }

                string cEOL = (nNumeroMostrado < nMaxLista) ? "\n" : String.Empty;
                if(objMetaCredito.idUsuario == 0)
                    cMensaje += "-  1 o mas Asesores sin código asignado" + cEOL;
                
                else
                    cMensaje += "-  " + objMetaCredito.idUsuario + " - " + objMetaCredito.cAsesorCarga + "." + cEOL;
                
                nNumeroMostrado++;
            }
            if(lstMetasExcluidos.Count > 0)
            {
                MessageBox.Show(cMensaje, "Asignación Metas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            List<clsMetaCreditoCarga> lstMetaCreditoArchivoFiltrado = lstMetaCreditoFiltrado.Intersect(lstMetaCreditoConsulta, new clsMetaCreditoCompareSimple()).ToList();
            List<clsMetaCreditoCarga> lstMetaCreditoModificados = lstMetaCreditoArchivoFiltrado.Except(lstMetaCreditoConsulta, new clsMetaCreditoCompare()).ToList();
            List<clsMetaCreditoCarga> lstMetaCreditosActualizados = lstMetaCreditoConsulta.GroupJoin(lstMetaCreditoModificados, k1 => k1.idUsuario, k2 => k2.idUsuario, (k1, k2) => new clsMetaCreditoCarga
            {
                cDesZona                    = (k2.SingleOrDefault() == null) ? k1.cDesZona                  : k2.SingleOrDefault().cDesZona,
                idAgencia                   = (k2.SingleOrDefault() == null) ? k1.idAgencia                 : k2.SingleOrDefault().idAgencia,
                cAgenciaCarga               = (k2.SingleOrDefault() == null) ? k1.cAgenciaCarga             : k2.SingleOrDefault().cAgenciaCarga,
                cEstablecimientoEOBCarga    = (k2.SingleOrDefault() == null) ? k1.cEstablecimientoEOBCarga  : k2.SingleOrDefault().cEstablecimientoEOBCarga,
                idUsuario                   = (k2.SingleOrDefault() == null) ? k1.idUsuario                 : k2.SingleOrDefault().idUsuario,
                cAsesorCarga                = (k2.SingleOrDefault() == null) ? k1.cAsesorCarga              : k2.SingleOrDefault().cAsesorCarga,
                cCargo                      = (k2.SingleOrDefault() == null) ? k1.cCargo                    : k2.SingleOrDefault().cCargo,
                idTipoMetaSaldo             = (k2.SingleOrDefault() == null) ? k1.idTipoMetaSaldo           : k2.SingleOrDefault().idTipoMetaSaldo,
                nMetaSaldo                  = (k2.SingleOrDefault() == null) ? k1.nMetaSaldo                : k2.SingleOrDefault().nMetaSaldo,
                idTipoMetaCrecimiento       = (k2.SingleOrDefault() == null) ? k1.idTipoMetaCrecimiento     : k2.SingleOrDefault().idTipoMetaCrecimiento,
                nCrecimientoClientes        = (k2.SingleOrDefault() == null) ? k1.nCrecimientoClientes      : k2.SingleOrDefault().nCrecimientoClientes,
                idTipoMetaClientesNuevos    = (k2.SingleOrDefault() == null) ? k1.idTipoMetaClientesNuevos  : k2.SingleOrDefault().idTipoMetaClientesNuevos,
                nClientesNuevos             = (k2.SingleOrDefault() == null) ? k1.nClientesNuevos           : k2.SingleOrDefault().nClientesNuevos,
                idEstadoMetaModificacion    = (k2.SingleOrDefault() == null) ? k1.idEstadoMetaModificacion  : k2.SingleOrDefault().idEstadoMetaModificacion,
                idEstadoAsesor              = (k2.SingleOrDefault() == null) ? k1.idEstadoAsesor            : k2.SingleOrDefault().idEstadoAsesor
            }).ToList();

            lstMetaCreditoCargaActual = lstMetaCreditosActualizados.Where(item => item.idEstadoMetaModificacion == 2).ToList();

            if(lstMetaCreditoCargaActual.Count == 0)
            {
                MessageBox.Show("Las metas asignadas del Archivo ya fueron Cargadas", "Asignación Metas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            bsMetaCredito.DataSource = lstMetaCreditoCargaActual;
            bsMetaCredito.ResetBindings(false);
            dtgMetas.Refresh();
        }


        private List<clsMetaCreditoCarga> ObtenerListaMetasModificadas()
        {
            List<clsMetaCreditoCarga> lstMetasModificadas = ((BindingSource)dtgMetas.DataSource).List as List<clsMetaCreditoCarga>;

            return lstMetasModificadas.Where(item => item.idEstadoMetaModificacion == 2).ToList();
        }

        private void Limpiar()
        {
            CargarVariableDefecto();
            txtUbicacionArchivo.Text = String.Empty;
            btnImportar.Enabled = false;
            cboAgencia.SelectedIndex = -1;
            nudAnio.Value = clsVarGlobal.dFecSystem.Year;
            cboMes.SelectedValue = clsVarGlobal.dFecSystem.Month;
        }

        public void ActivarControles(int idEstado)
        {
            switch (idEstado)
            {
                case 1: //Por Defecto
                    nudAnio.Enabled             = true;
                    cboMes.Enabled              = true;
                    cboAgencia.Enabled          = true;
                    chcAsesoresNuevos.Enabled   = true;
                    chcAsesoresCesados.Enabled  = true;
                    btnConsultar.Enabled        = true;
                    btnImprimir.Enabled         = false;
                    btnGrabar.Enabled           = false;
                    btnCancelar.Enabled         = false;
                    btnImportar.Enabled         = true;
                    btnExporExcel.Enabled       = true;
                    dtgMetas.Enabled            = false;
                    break;
                case 2: //Recuperado
                    nudAnio.Enabled             = true;
                    cboMes.Enabled              = true;
                    cboAgencia.Enabled          = true;
                    chcAsesoresNuevos.Enabled   = true;
                    chcAsesoresCesados.Enabled  = true;
                    btnConsultar.Enabled        = true;
                    btnImprimir.Enabled         = true;
                    btnGrabar.Enabled           = true;
                    btnCancelar.Enabled         = true;
                    btnImportar.Enabled         = true;
                    btnExporExcel.Enabled       = true;
                    dtgMetas.Enabled            = true;
                    break;
                case 3: //Guardado
                    nudAnio.Enabled             = true;
                    cboMes.Enabled              = true;
                    cboAgencia.Enabled          = true;
                    chcAsesoresNuevos.Enabled   = true;
                    chcAsesoresCesados.Enabled  = true;
                    btnConsultar.Enabled        = true;
                    btnImprimir.Enabled         = true;
                    btnGrabar.Enabled           = false;
                    btnCancelar.Enabled         = true;
                    btnImportar.Enabled         = false;
                    btnExporExcel.Enabled       = true;
                    dtgMetas.Enabled            = true;
                    break;
                case 4: // Cancelado
                    nudAnio.Enabled             = true;
                    cboMes.Enabled              = true;
                    cboAgencia.Enabled          = true;
                    chcAsesoresNuevos.Enabled   = true;
                    chcAsesoresCesados.Enabled  = true;
                    btnConsultar.Enabled        = true;
                    btnImprimir.Enabled         = false;
                    btnGrabar.Enabled           = false;
                    btnCancelar.Enabled         = false;
                    btnImportar.Enabled         = true;
                    btnExporExcel.Enabled       = true;
                    dtgMetas.Enabled            = false;
                    break;
                case 5: // Importado
                    nudAnio.Enabled             = true;
                    cboMes.Enabled              = true;
                    cboAgencia.Enabled          = true;
                    chcAsesoresNuevos.Enabled   = true;
                    chcAsesoresCesados.Enabled  = true;
                    btnConsultar.Enabled        = true;
                    btnImprimir.Enabled         = false;
                    btnGrabar.Enabled           = true;
                    btnCancelar.Enabled         = true;
                    btnImportar.Enabled         = false;
                    btnExporExcel.Enabled       = true;
                    dtgMetas.Enabled            = true;
                    break;
            }
        }

        private void LiberarObjeto(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("No se puede liberar el objeto: " + ex.ToString());
            }
            finally
            {
                GC.Collect();

                int id = GetIDProcess("EXCEL");

                if(id != -1)
                {
                    try
                    {
                        System.Diagnostics.Process.GetProcessById(id).Kill();
                    }
                    catch(Exception)
                    {

                    }
                }
            }
        }
        private int GetIDProcess(string nameProcess)
        {
            try
            {
                System.Diagnostics.Process[] asProcess = System.Diagnostics.Process.GetProcessesByName(nameProcess);
                foreach( System.Diagnostics.Process pProcess in asProcess )
                {
                    if (pProcess.MainWindowTitle == "")
                        return pProcess.Id;
                }
                return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        DataTable ConvertirDataTable<TSource>(IEnumerable<TSource> source)
        {
            var props = typeof(TSource).GetProperties();

            var dt = new DataTable();
            dt.Columns.AddRange(
              props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray()
            );

            source.ToList().ForEach(
              i => dt.Rows.Add(props.Select(p => p.GetValue(i, null)).ToArray())
            );

            return dt;
        }

        #endregion
    }
}