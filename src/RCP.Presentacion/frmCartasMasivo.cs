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
using EntityLayer;
using RCP.CapaNegocio;
using System.IO;
using System.Drawing.Imaging;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;
using System.Globalization;
using RPT.CapaNegocio;

namespace RCP.Presentacion
{
    public partial class frmCartasMasivo : frmBase
    {
        #region Variables Globales
        clsCNReportes cnReportes = new clsCNReportes();
        clsCNCartaRecupera cartarecupera = new clsCNCartaRecupera();
        clsCNHojaRuta cnHojaRuta = new clsCNHojaRuta();
        #endregion

        public frmCartasMasivo()
        {
            InitializeComponent();
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            cboUsuRecuperadores1.cargarTodosGestoresUnicos();
            conBusUbig1.cargar();
            conBusUbig1.cboPais.SelectedValue = 173;
            conBusUbig1.cboPais.Enabled = false;
            conBusUbig1.cboDepartamento.SelectedValue = 1632;
            conBusUbig1.cboProvincia.SelectedValue = 1633;
            btnGenerar1.Enabled = false;
        }

        private void btnGenerar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                foreach (DataGridViewRow row in dtgCreditos.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["lImprimir"].Value))
                    {
                        DateTime dFecha = clsVarGlobal.dFecSystem;
                        string cLugarFecha = row.Cells["cUbigeo"].Value.ToString().ToUpperInvariant() + ", " + dFecha.ToString("D", new CultureInfo("es-ES")).ToUpperInvariant();
                        int idCuenta = Convert.ToInt32(row.Cells["idCuenta"].Value);                        

                        List<ReportDataSource> dtsList = new List<ReportDataSource>();
                        
                        List<ReportParameter> paramList = new List<ReportParameter>();
                        paramList.Add(new ReportParameter("cLugarFecha", cLugarFecha, false));
                        paramList.Add(new ReportParameter("nCodCliente", row.Cells["idCli"].Value.ToString(), false));
                        paramList.Add(new ReportParameter("cNombreCliente", row.Cells["cNombreCliente"].Value.ToString(), false));
                        paramList.Add(new ReportParameter("cDomicilio", row.Cells["cDireccion"].Value.ToString(), false));
                        paramList.Add(new ReportParameter("cDistrito", row.Cells["cUbigeo"].Value.ToString(), false));
                        paramList.Add(new ReportParameter("nNroCredito", row.Cells["idCuenta"].Value.ToString(), false));
                        paramList.Add(new ReportParameter("cNombreAsesor", row.Cells["cNombreAsesor"].Value.ToString(), false));
                        paramList.Add(new ReportParameter("cNombreOficina", row.Cells["cNombreOficina"].Value.ToString(), false));
                        paramList.Add(new ReportParameter("nMontoDeuda", row.Cells["cSimbolo"].Value.ToString() + Convert.ToDecimal(row.Cells["nMonto"].Value).ToString("0.00"), false));
                        paramList.Add(new ReportParameter("nDiasAtraso", row.Cells["nDiasAtraso"].Value.ToString(), false));
                        paramList.Add(new ReportParameter("cDireccionOficina", row.Cells["cDireccionOficina"].Value.ToString(), false));
                        paramList.Add(new ReportParameter("cNombreTitular", row.Cells["cNombreTitular"].Value.ToString(), false));
                        paramList.Add(new ReportParameter("cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString(), false));
                        paramList.Add(new ReportParameter("nCuotasAtraso", row.Cells["nCuotasAtraso"].Value.ToString(), false));
                        paramList.Add(new ReportParameter("cNombreGestor", row.Cells["cNombreGestor"].Value.ToString(), false));

                        try
                        {
                            string reportPath = row.Cells["cReporte"].Value.ToString();
                            if (String.IsNullOrEmpty(reportPath))
                            {
                                MessageBox.Show("No se encontro el reporte para la impresión.", "Impresión de documentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                continue;
                            }
                            bool lImpDir = chcImpDir.Checked;
                            frmReporteLocal frmReporte = null;
                            if (lImpDir)
                            {
                                frmReporte = new frmReporteLocal(dtsList, reportPath, paramList, lImpDir);
                            }
                            else
                            {
                                frmReporte = new frmReporteLocal(dtsList, reportPath, paramList, enuFormatoReporte.Pdf);
                            }
                            frmReporte.ShowDialog();
                        }
                        catch
                        {
                            MessageBox.Show("Error al generar la notificación", "Impresión de documentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            cargarCreditos();
        }

        #endregion

        #region Metodos

        private void cargarCreditos()
        {
            DataTable dtCreditos = cnReportes.CreditosParaImpresionMasiva(Convert.ToInt32(cboUsuRecuperadores1.SelectedValue), Convert.ToInt32(cboAgencia1.SelectedValue), conBusUbig1.nIdNodo, Convert.ToDecimal(txtAtrasoMin.Text), Convert.ToDecimal(txtAtrasoMax.Text));
            if (dtCreditos.Rows.Count > 0)
            {
                dtCreditos.Columns["lImprimir"].ReadOnly = false;            
                dtgCreditos.DataSource = dtCreditos;
                formatoGridCreditos();
                btnGenerar1.Enabled = true;
                dtgCreditos.ReadOnly = false;
                dtgCreditos.Columns["lImprimir"].ReadOnly = false;            
            }
        }

        private bool validar()
        {
            bool lCorrecto = false;
            foreach (DataGridViewRow row in dtgCreditos.Rows)
            {
                if (Convert.ToBoolean(row.Cells["lImprimir"].Value))
                {
                    lCorrecto = true;
                    break;
                }
            }
            if (!lCorrecto)
            {
                MessageBox.Show("Debe de seleccionar al menos un crédito para imprimir", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return lCorrecto;
        }

        private void formatoGridCreditos()
        {
            foreach (DataGridViewColumn columna in dtgCreditos.Columns)
            {
                columna.Visible = false;
            }

            dtgCreditos.Columns["lImprimir"].Visible = true;
            dtgCreditos.Columns["idCli"].Visible = true;
            dtgCreditos.Columns["idCuenta"].Visible = true;
            dtgCreditos.Columns["cNombreCliente"].Visible = true;
            dtgCreditos.Columns["cTipoNotificacion"].Visible = true;
            dtgCreditos.Columns["nMonto"].Visible = true;
            dtgCreditos.Columns["nDiasAtraso"].Visible = true;
            dtgCreditos.Columns["cSimbolo"].Visible = true;

            dtgCreditos.Columns["lImprimir"].HeaderText = "";
            dtgCreditos.Columns["idCli"].HeaderText = "Cliente";
            dtgCreditos.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgCreditos.Columns["cNombreCliente"].HeaderText = "Nombre Cliente";
            dtgCreditos.Columns["nDiasAtraso"].HeaderText = "Atraso";
            dtgCreditos.Columns["cTipoNotificacion"].HeaderText = "Notificación";
            dtgCreditos.Columns["nMonto"].HeaderText = "Monto";
            dtgCreditos.Columns["cSimbolo"].HeaderText = "Mon.";

            dtgCreditos.Columns["lImprimir"].Width = 25;
            dtgCreditos.Columns["idCli"].Width = 50;
            dtgCreditos.Columns["idCuenta"].Width = 50;
            dtgCreditos.Columns["cNombreCliente"].Width = 120;
            dtgCreditos.Columns["nDiasAtraso"].Width = 50;
            dtgCreditos.Columns["cTipoNotificacion"].Width = 100;
            dtgCreditos.Columns["nMonto"].Width = 50;
            dtgCreditos.Columns["cSimbolo"].Width = 50;

            dtgCreditos.Columns["lImprimir"].DisplayIndex = 0;
            dtgCreditos.Columns["idCli"].DisplayIndex = 1;
            dtgCreditos.Columns["idCuenta"].DisplayIndex = 2;
            dtgCreditos.Columns["cNombreCliente"].DisplayIndex = 3;
            dtgCreditos.Columns["nDiasAtraso"].DisplayIndex = 4;
            dtgCreditos.Columns["cTipoNotificacion"].DisplayIndex = 5;
            dtgCreditos.Columns["cSimbolo"].DisplayIndex = 6;
            dtgCreditos.Columns["nMonto"].DisplayIndex = 7;

            dtgCreditos.Columns["lImprimir"].ReadOnly = false;
        }

        #endregion
    }
}
