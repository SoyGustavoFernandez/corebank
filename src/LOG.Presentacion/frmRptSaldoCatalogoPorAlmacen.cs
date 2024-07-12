using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace LOG.Presentacion
{
    public partial class frmRptSaldoCatalogoPorAlmacen : frmBase
    {
        public frmRptSaldoCatalogoPorAlmacen()
        {
            InitializeComponent();
        }

        private void frmRptSaldoCatalogoPorAlmacen_Load(object sender, EventArgs e)
        {
            cboTipoBien.cargarTipoBien(0, true);
            cboTipoBien.SelectedValue = 0;
            cboMoneda.MonedasYTodos();
            cboMoneda.SelectedValue = 0;
            chcHistorico.Checked = false;
            dtpFecha.Enabled = false;
            dtpFecha.MaxDate = clsVarGlobal.dFecSystem;
            dtpFecha.Value = clsVarGlobal.dFecSystem;
            cboAgencia.AgenciasYTodos();
            if (cboAgencia.SelectedIndex >= 0)
            {
                cboAlmacen.CargarAlmacen((int)cboAgencia.SelectedValue);
            }

            if (clsVarGlobal.nIdAgencia == 1)
            {
                cboAgencia.Enabled = true;
            }
            else
            {
                cboAgencia.SelectedValue = clsVarGlobal.nIdAgencia;
                cboAgencia.Enabled = false;
            }
        }

        private void cboTipoBien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTipoBien.SelectedIndex > 0)
            {
                this.cboSubTipoBien.ListarGrupo(0, Convert.ToInt32(this.cboTipoBien.SelectedValue), true);
            }
            else
            {
                this.cboSubTipoBien.SelectedValue = 0;
                this.cboGrupoBien.SelectedValue = 0;
                this.cboSubGrupo.SelectedValue = 0;
            }
        }

        private void cboSubTipoBien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboSubTipoBien.SelectedIndex > 0)
            {
                this.cboGrupoBien.ListarGrupo(Convert.ToInt32(this.cboSubTipoBien.SelectedValue), Convert.ToInt32(this.cboTipoBien.SelectedValue), true);
            }
            else
            {
                this.cboGrupoBien.SelectedValue = 0;
                this.cboSubGrupo.SelectedValue = 0;
            }
        }

        private void cboGrupoBien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboGrupoBien.SelectedIndex > 0)
            {
                this.cboSubGrupo.ListarGrupo(Convert.ToInt32(this.cboGrupoBien.SelectedValue), Convert.ToInt32(this.cboTipoBien.SelectedValue), true);
            }
            else
            {
                this.cboSubGrupo.SelectedValue = 0;
            }
        }

        private void cboAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencia.SelectedIndex >= 0)
            {
                cboAlmacen.CargarAlmacen((int)cboAgencia.SelectedValue);
            }
        }

        private void chcHistorico_CheckedChanged(object sender, EventArgs e)
        {
            dtpFecha.Enabled = chcHistorico.Checked;

            if (!chcHistorico.Checked)
            {
                dtpFecha.Value = clsVarGlobal.dFecSystem;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            clsRPTCNLogistica objLogistica = new clsRPTCNLogistica();
            DataTable dtSaldoCatalogoAlmacen;
            DataTable dtTipoCambio = new DataTable();

            DateTime dFecha = dtpFecha.Value;
            int idAlmacen = (int)cboAlmacen.SelectedValue;
            string cAlmacen = cboAlmacen.Text;

            int idMoneda = (int)cboMoneda.SelectedValue;
            string cTipoMoneda = cboMoneda.Text;

            int idTipoBien = (int)cboTipoBien.SelectedValue;
            int idGrupo = 0;
            if ((int)cboSubTipoBien.SelectedIndex >= 0)
            {
                idGrupo = (int)cboSubTipoBien.SelectedValue;
            }
            int idSubGrupo = 0;
            if ((int)cboGrupoBien.SelectedIndex >= 0)
            {
                idSubGrupo = (int)cboGrupoBien.SelectedValue;
            }
            int idRubro = 0;
            if ((int)cboSubGrupo.SelectedIndex >= 0)
            {
                idRubro = (int)cboSubGrupo.SelectedValue;
            }

            string cRubro = cboSubGrupo.Text;

            dtTipoCambio = objLogistica.CNTipoCambioFijo(dFecha);
            decimal nTipoCambio = Convert.ToDecimal(dtTipoCambio.Rows[0]["nTipCamFij"].ToString());

            if (chcHistorico.Checked)
            {
                dtSaldoCatalogoAlmacen = objLogistica.CNHistoricoSaldoCatalogoPorAlmacen(dFecha, idAlmacen, idMoneda, idTipoBien, idGrupo, idSubGrupo, idRubro);
            }
            else
            {
                dtSaldoCatalogoAlmacen = objLogistica.CNSaldoCatalogoPorAlmacen(dFecha, idAlmacen, idMoneda, idTipoBien, idGrupo, idSubGrupo, idRubro);
            }

            string reportPath = "rptSaldoCatalogoPorAlmacen.rdlc";
            if (rbtDetalle.Checked)
            {
                reportPath = "rptSaldoCatalogoPorAlmacenDetalle.rdlc";
            }
            else if(rbtGeneral.Checked)
            {
                reportPath = "rptSaldoCatalogoBienPorAlmacen.rdlc";
            }

            if (dtSaldoCatalogoAlmacen.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();

                dtsList.Add(new ReportDataSource("dsSaldoCatalogoAlmacen", dtSaldoCatalogoAlmacen));

                List<ReportParameter> paramList = new List<ReportParameter>();

                paramList.Add(new ReportParameter("cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                paramList.Add(new ReportParameter("cNomAgencia", clsVarApl.dicVarGen["cNomAge"], false));
                paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                paramList.Add(new ReportParameter("dFecha", dFecha.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("idAlmacen", idAlmacen.ToString(), false));
                paramList.Add(new ReportParameter("cAlmacen", cAlmacen, false));
                paramList.Add(new ReportParameter("idMoneda", idMoneda.ToString(), false));
                paramList.Add(new ReportParameter("idRubro", idRubro.ToString(), false));

                new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos", "Reporte de Saldos por Almacen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
