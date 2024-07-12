using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmRptCompraVenta : frmBase
    {
        public frmRptCompraVenta()
        {
            InitializeComponent();
        }
        #region Variables Globales
        clsRPTCNDeposito cndeposito = new clsRPTCNDeposito();
        #endregion
        #region Eventos
        private void RptCompraVenta_Load(object sender, EventArgs e)
        {
            dtpFecIni.Value = clsVarGlobal.dFecSystem;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
            ListarTiposComVenta();
            ListarEstadosComVenta();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (cboAgencias.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar la Agencia", "Reporte de Ctas Bloqueadas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboAgencias.Focus();
                return;
            }
            if (cboTipoComVenta.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar un tipo de operaciòn", "Reporte de Ctas Bloqueadas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoComVenta.Focus();
                return;
            }
            if (cboEstadoComVenta.SelectedIndex == -1)
            {
                MessageBox.Show("Debe Seleccionar un estado", "Reporte de Ctas Bloqueadas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboEstadoComVenta.Focus();
                return;
            }
            if (Convert.ToDateTime(dtpFecFin.Value.ToShortDateString()) < Convert.ToDateTime(dtpFecIni.Value.ToShortDateString()))
            {
                MessageBox.Show("La Fecha de Inicio no Puede Ser Mayor que la Fecha Final", "Reporte de Compra/Venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime dFecInicio = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;
            int idAge = Convert.ToInt16(cboAgencias.SelectedValue);
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            int nTipoComVenta = Convert.ToInt16(cboTipoComVenta.SelectedValue);
            int nEstadoComVenta = Convert.ToInt16(cboEstadoComVenta.SelectedValue);

            DataTable dtRpt = new clsRPTCNDeposito().CNDatosCompraVenta(idAge, dFecInicio, dFecFin, nTipoComVenta, nEstadoComVenta);
            if (dtRpt.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("x_cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                paramlist.Add(new ReportParameter("x_idAgencia", idAge.ToString(), false));
                paramlist.Add(new ReportParameter("x_dFecIni", dFecInicio.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_dFecFin", dFecFin.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsCompraVenta", dtRpt));

                string reportpath = "RptCompraVenta.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Reporte de Compra/Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        #endregion
        #region Metodos
        private void ListarTiposComVenta()
        {
            DataTable dtTipoComVenta = cndeposito.CNListarTipoComVenta();
            DataRow row = dtTipoComVenta.NewRow();
            row["idTipComVen"] = 0;
            row["cDescripcion"] = "TODOS";
            dtTipoComVenta.Rows.Add(row);

            cboTipoComVenta.DataSource = dtTipoComVenta;
            cboTipoComVenta.ValueMember = dtTipoComVenta.Columns[0].ToString();
            cboTipoComVenta.DisplayMember = dtTipoComVenta.Columns[1].ToString();
        }
        private void ListarEstadosComVenta()
        {
            DataTable dtEstadoComVenta = cndeposito.CNListarEstadoComVenta();
            DataRow row = dtEstadoComVenta.NewRow();
            row["IdEstado"] = 0;
            row["cDescripcion"] = "TODOS";
            dtEstadoComVenta.Rows.Add(row);

            cboEstadoComVenta.DataSource = dtEstadoComVenta;
            cboEstadoComVenta.ValueMember = dtEstadoComVenta.Columns[0].ToString();
            cboEstadoComVenta.DisplayMember = dtEstadoComVenta.Columns[1].ToString();
        }
        #endregion
    }
}
