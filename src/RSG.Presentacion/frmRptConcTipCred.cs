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
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace RSG.Presentacion
{
    public partial class frmRptConcTipCred : frmBase
    {

        #region Variables Globales

        const string cTituloMsjes = "Reporte de concentración por tipo de crédito.";
        int nNumReport = 0;

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            grbFecha.Enabled = true;
            grbRango.Enabled = false;
            dtpFecha.Value = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1).AddDays(-1).Date;
            dtpFecIni.Value = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1).AddDays(-1).Date;
            dtpFecIni.Value = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1).AddDays(-1).AddYears(-1).Date;
            nNumReport = 1;
            activarGrafico(false);
        }

        private void rbtnConc_CheckedChanged(object sender, EventArgs e)
        {
            grbFecha.Enabled = rbtnConc.Checked;
            grbRango.Enabled = !rbtnConc.Checked;
            nNumReport = 1;
            activarGrafico(false);
        }

        private void rbtnHistCap_CheckedChanged(object sender, EventArgs e)
        {
            grbFecha.Enabled = !rbtnHistCap.Checked;
            grbRango.Enabled = rbtnHistCap.Checked;
            nNumReport = 2;
            activarGrafico(true);
        }

        private void rbtnHistCapMora_CheckedChanged(object sender, EventArgs e)
        {
            grbFecha.Enabled = !rbtnHistCapMora.Checked;
            grbRango.Enabled = rbtnHistCapMora.Checked;
            nNumReport = 3;
            activarGrafico(true);
        }

        private void rbtnHistMora_CheckedChanged(object sender, EventArgs e)
        {
            grbFecha.Enabled = !rbtnHistMora.Checked;
            grbRango.Enabled = rbtnHistMora.Checked;
            nNumReport = 4;
            activarGrafico(true);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            DateTime dFecha = dtpFecha.Value.Date;
            DateTime dFecIni = dtpFecIni.Value.Date;
            DateTime dFecFin = dtpFecFin.Value.Date;

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            string reportpath = String.Empty;
            string cNomRep = "";

            DataTable dtData = null;

            List<ReportParameter> paramlist = new List<ReportParameter>();

            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();

            

            switch (nNumReport)
            {
                case 1:
                    dtData = new clsRPTCNRiesgos().CNRptConcTipCredito(dFecha);
                    reportpath = "rptConcTipCredRiesgos.rdlc";
                    paramlist.Add(new ReportParameter("dFecha", dFecha.ToString(), false));
                    cNomRep = dFecha.ToString("yyyy_MM_dd") + " REPORTE DE CONCENTRACIÓN DE CARTERA POR TIPO DE CRÉDITO";
                    dtslist.Add(new ReportDataSource("dsData", dtData));
        
                    break;
                case 2:
                    dtData = new clsRPTCNRiesgos().CNRptHistConTipCredito(dFecIni, dFecFin);
                    if (rbtDetalle.Checked)
                    {
                        reportpath = "rptHistConcTipCredCapital.rdlc";
                        cNomRep = dFecIni.ToString("yyyy_MM_dd") + "-" + dFecFin.ToString("yyyy_MM_dd") + " REPORTE HISTÓRICO DE CONCENTRACIÓN DE CARTERA POR TIPO DE CRÉDITO - CAPITAL";
                        dtslist.Add(new ReportDataSource("dsData", dtData));
                    }
                    else
                    {
                        reportpath = "rptGraHisCapTipoCre.rdlc";
                        cNomRep = dFecIni.ToString("yyyy_MM_dd") + "-" + dFecFin.ToString("yyyy_MM_dd") + " HISTÓRICO CONCENTRACIÓN DE CARTERA POR TIPO CRÉDITO - CAPITAL";
                        dtslist.Add(new ReportDataSource("DataSet1", dtData));
                    }
                    break;
                case 3:
                    dtData = new clsRPTCNRiesgos().CNRptHistConTipCredito(dFecIni, dFecFin);
                    if (rbtDetalle.Checked)
                    {
                        reportpath = "rptHistConcTipCredCapitalMora.rdlc";
                        cNomRep = dFecIni.ToString("yyyy_MM_dd") + "-" + dFecFin.ToString("yyyy_MM_dd") + " REPORTE HISTÓRICO DE CONCENTRACIÓN DE CARTERA POR TIPO DE CRÉDITO - CAPITAL VENCIDO";
                        dtslist.Add(new ReportDataSource("dsData", dtData));
                    }
                    else
                    {
                        reportpath = "rptGraHisCapVencidoTipoCre.rdlc";
                        cNomRep = dFecIni.ToString("yyyy_MM_dd") + "-" + dFecFin.ToString("yyyy_MM_dd") + " HISTÓRICO CONCENTRACIÓN DE CARTERA POR TIPO CRÉDITO - CAPITAL VENCIDO";
                        dtslist.Add(new ReportDataSource("DataSet1", dtData));
                    }
                    break;
                case 4:
                    dtData = new clsRPTCNRiesgos().CNRptHistConTipCredito(dFecIni, dFecFin);
                    if (rbtDetalle.Checked)
                    {
                        reportpath = "rptHistConcTipCredMora.rdlc";
                        cNomRep = dFecIni.ToString("yyyy_MM_dd") + "-" + dFecFin.ToString("yyyy_MM_dd") + " REPORTE HISTÓRICO DE CONCENTRACIÓN DE CARTERA POR TIPO DE CRÉDITO - MORA";
                        dtslist.Add(new ReportDataSource("dsData", dtData));
                    }
                    else
                    {
                        reportpath = "rptGraHisIndiceMoraTipoCre.rdlc";
                        cNomRep = dFecIni.ToString("yyyy_MM_dd") + "-" + dFecFin.ToString("yyyy_MM_dd") + " HISTÓRICO CONCENTRACIÓN DE CARTERA POR TIPO CRÉDITO - MORA";
                        dtslist.Add(new ReportDataSource("DataSet1", dtData));
                    }
                    
                    break;
                default:
                    break;
            }

            if (dtData.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmReporte.rpvReporteLocal.LocalReport.DisplayName = cNomRep;
            frmReporte.ShowDialog();
        }

        #endregion

        #region Metodos

        private void activarGrafico(Boolean lBol)
        {
            grbBase2.Enabled = lBol;
            if (!lBol)
                rbtDetalle.Checked = true;
        }

        public frmRptConcTipCred()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            if (!rbtnConc.Checked && !rbtnHistCap.Checked && !rbtnHistCapMora.Checked && !rbtnHistMora.Checked)
            {
                MessageBox.Show("Seleccione el reporte a mostrar", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (rbtnHistCap.Checked || rbtnHistCapMora.Checked || rbtnHistMora.Checked)
            {
                if (dtpFecIni.Value.Date > dtpFecFin.Value.Date)
                {
                    MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha final.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        #endregion

    }
}
