﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using EntityLayer;

namespace CNT.Presentacion
{
    public partial class frmRptResumenCastigosCNT : frmBase
    {
        public frmRptResumenCastigosCNT()
        {
            InitializeComponent();
        }
        private void frmRptResumenCastigosCNT_Load(object sender, EventArgs e)
        {
            dtpFechaIni.Value = clsVarGlobal.dFecSystem;
            dtpFechaFin.Value = clsVarGlobal.dFecSystem;
            cboMoneda.MonedasYTodos();
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFechaIni = dtpFechaIni.Value.Date;
            DateTime dFechaFin = dtpFechaFin.Value.Date;
            if (clsVarGlobal.dFecSystem < dFechaFin)
            {
                MessageBox.Show("La fecha final debe ser menor o igual a la fecha del sistema", "Valida resumen castigos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dFechaIni > dFechaFin)
            {
                MessageBox.Show("La fecha de inicio debe ser menor o igual a la fecha final", "Valida resumen castigos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue);
            int idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
       
            string cRutaLogo = clsVarApl.dicVarGen["CRUTALOGO"];
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("x_cAgencia", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("x_cRutaLogo", cRutaLogo, false));
            paramlist.Add(new ReportParameter("dFecIniCastigo", dtpFechaIni.Value.ToString(), false));
            paramlist.Add(new ReportParameter("dFecFinCastigo", dtpFechaFin.Value.ToString(), false));
  
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsCastigosCNT", new clsRPTCNContabilidad().CNRptResumenCastigadosCNT(dFechaIni ,dFechaFin ,idAgencia,idMoneda)));

            string reportpath = "rptResumenCastigadoCnt.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

   

    

    }
}
