using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RCP.CapaNegocio;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCP.Presentacion
{
    public partial class frmImpresionNotificaciones : frmBase
    {
        clsCNHojaRuta cnHojaRuta = new clsCNHojaRuta();
        public int idHojaRuta = 0;
        int idEstadoHojaRuta = 0;
        public frmImpresionNotificaciones()
        {
            InitializeComponent();
        }
        private void frmImpresionNotificaciones_Load(object sender, EventArgs e)
        {
            frmSeleccionarHojaRuta frmSeleccionarHojaRuta = new frmSeleccionarHojaRuta(clsVarGlobal.User.idUsuario);
            frmSeleccionarHojaRuta.ShowDialog();
            if (!frmSeleccionarHojaRuta.lAceptar || frmSeleccionarHojaRuta.idHojaRutaSeleccinada == 0)
            {
                this.Dispose();
                return;
            }
            idHojaRuta = frmSeleccionarHojaRuta.idHojaRutaSeleccinada;
            cargarHojaRuta();
        }
        private void cargarHojaRuta()
        {
            DataTable dtHojaRuta = cnHojaRuta.obtenerHojaRuta(idHojaRuta);
            if (dtHojaRuta.Rows.Count > 0)
            {
                dtpFechaInicio.Value = dtHojaRuta.Rows[0]["dFechaInicio"];
                dtpFechaFin.Value = dtHojaRuta.Rows[0]["dFechaFin"];
                txtKilometrajeInicio.Text = dtHojaRuta.Rows[0]["nTacometroInicio"].ToString();
                txtEstadoHojaRuta.Text = dtHojaRuta.Rows[0]["cEstadoHojaRuta"].ToString();
                idEstadoHojaRuta = Convert.ToInt32(dtHojaRuta.Rows[0]["idEstado"]);

                DataTable dtNotifiaciones = cnHojaRuta.obtenerNotificacionesHojaRuta(idHojaRuta);
                dtNotifiaciones.Columns["lImprimir"].ReadOnly = false;
                dtgNotificaciones.DataSource = dtNotifiaciones;
                FormatoGrid();
                txtTotalCreditos.Text = dtNotifiaciones.Rows.Count + "";
            }
        }
        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dtgNotificaciones.Rows)
            {
                if (Convert.ToBoolean(row.Cells["lImprimir"].Value))
                {
                    DateTime dFecha = Convert.ToDateTime(row.Cells["dFechaRegistrado"].Value);
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
        private void FormatoGrid()
        {
            dtgNotificaciones.ReadOnly = false;
            foreach (DataGridViewColumn column in dtgNotificaciones.Columns)
            {
                column.Visible = false;
                column.ReadOnly = true;
            }

            dtgNotificaciones.Columns["lImprimir"].Visible = true;
            dtgNotificaciones.Columns["idCuenta"].Visible = true;
            dtgNotificaciones.Columns["cNombreCliente"].Visible = true;
            dtgNotificaciones.Columns["cDireccion"].Visible = true;
            dtgNotificaciones.Columns["cSimbolo"].Visible = true;
            dtgNotificaciones.Columns["nMonto"].Visible = true;
            dtgNotificaciones.Columns["cTipoNotificacion"].Visible = true;

            dtgNotificaciones.Columns["lImprimir"].HeaderText = "Imprimir";
            dtgNotificaciones.Columns["idCuenta"].HeaderText = "Cod.Cred.";
            dtgNotificaciones.Columns["cNombreCliente"].HeaderText = "Nombre";
            dtgNotificaciones.Columns["cDireccion"].HeaderText = "Direccion";
            dtgNotificaciones.Columns["cSimbolo"].HeaderText = "Moneda";
            dtgNotificaciones.Columns["nMonto"].HeaderText = "Monto";
            dtgNotificaciones.Columns["cTipoNotificacion"].HeaderText = "Tipo Notificacion";

            dtgNotificaciones.Columns["lImprimir"].Width = 20;
            dtgNotificaciones.Columns["idCuenta"].Width = 30;
            dtgNotificaciones.Columns["cNombreCliente"].Width = 90;
            dtgNotificaciones.Columns["cDireccion"].Width = 90;
            dtgNotificaciones.Columns["cSimbolo"].Width = 25;
            dtgNotificaciones.Columns["nMonto"].Width = 40;
            dtgNotificaciones.Columns["cTipoNotificacion"].Width = 90;

            dtgNotificaciones.Columns["nMonto"].DefaultCellStyle.Format = "#,0.00";

            dtgNotificaciones.Columns["lImprimir"].ReadOnly = false;
        }
    }
}
