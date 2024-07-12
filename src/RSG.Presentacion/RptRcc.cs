﻿using System;
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
    public partial class RptRcc : frmBase
    {

        #region Variables Globales

        private const string cTituloMsjes = "Reporte consolidado de créditos.";
        private int nNumReport = 0;

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1).AddDays(-1).Date;
            nNumReport = 1;
        }

        private void rbtnGeneral_CheckedChanged(object sender, EventArgs e)
        {
            nNumReport = 1;
        }

        private void rbtnCapital_CheckedChanged(object sender, EventArgs e)
        {
            nNumReport = 2;
        }

        private void rbtnClientes_CheckedChanged(object sender, EventArgs e)
        {
            nNumReport = 3;
        }

        private void rbtnCapitalMora_CheckedChanged(object sender, EventArgs e)
        {
            nNumReport = 4;
        }

        private void rbtnCliMora_CheckedChanged(object sender, EventArgs e)
        {
            nNumReport = 5;
        }

        private void rbtnMora_CheckedChanged(object sender, EventArgs e)
        {
            nNumReport = 6;
        }

        private void rbtnRccRse_CheckedChanged(object sender, EventArgs e)
        {
            nNumReport = 7;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            DateTime dFecha = dtpFecha.Value.Date;

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            string cNomRep = "";

            DataTable dtData = new clsRPTCNRiesgos().CNRptRCC(dFecha);

            if (dtData.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));
            paramlist.Add(new ReportParameter("dFecha", dFecha.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsData", dtData));

            string reportpath = String.Empty;

            switch (nNumReport)
            {
                case 1: reportpath = "RptRccRiesgos.rdlc";
                    cNomRep = dFecha.ToString("yyyy_MM_dd") + " REPORTE DE RIESGO CAMBIARIO CREDITICIO";
                    break;
                case 2: reportpath = "RptRccCap.rdlc";
                    cNomRep = dFecha.ToString("yyyy_MM_dd") + " REPORTE DE RIESGO CAMBIARIO CREDITICIO - CAPITAL";
                    break;
                case 3: reportpath = "RptRccCli.rdlc";
                    cNomRep = dFecha.ToString("yyyy_MM_dd") + " REPORTE DE RIESGO CAMBIARIO CREDITICIO - CLIENTES";
                    break;
                case 4: reportpath = "RptRccCapMora.rdlc";
                    cNomRep = dFecha.ToString("yyyy_MM_dd") + " REPORTE DE RIESGO CAMBIARIO CREDITICIO - CAPITAL VENCIDO";
                    break;
                case 5: reportpath = "RptRccCliMora.rdlc";
                    cNomRep = dFecha.ToString("yyyy_MM_dd") + " REPORTE DE RIESGO CAMBIARIO CREDITICIO - CLIENTES VENCIDOS";
                    break;
                case 6: reportpath = "RptRccMora.rdlc";
                    cNomRep = dFecha.ToString("yyyy_MM_dd") + " REPORTE DE RIESGO CAMBIARIO CREDITICIO - MORA";
                    break;
                case 7: reportpath = "RptRcc_Rse.rdlc";
                    cNomRep = dFecha.ToString("yyyy_MM_dd") + " REPORTE DE RIESGO CAMBIARIO CREDITICIO";
                    break;
                default:
                    break;
            }
            
            frmReporteLocal frmReporte = new frmReporteLocal(dtslist, reportpath, paramlist);
            frmReporte.rpvReporteLocal.LocalReport.DisplayName = cNomRep;
            frmReporte.ShowDialog();
        }

        #endregion

        #region Metodos

        public RptRcc()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            if (!rbtnGeneral.Checked && !rbtnCapital.Checked && !rbtnClientes.Checked && !rbtnCapitalMora.Checked
                    && !rbtnCliMora.Checked && !rbtnMora.Checked && !rbtnRccRse.Checked)
            {
                MessageBox.Show("Seleccione el reporte a mostrar", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion

    }
}
