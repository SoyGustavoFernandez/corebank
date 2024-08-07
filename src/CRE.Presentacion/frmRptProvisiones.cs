﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmRptProvisiones : frmBase
    {
        public frmRptProvisiones()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            string pcAgencia = cboAgencia1.Text;
            int pidAgencia =Convert.ToInt32(cboAgencia1.SelectedValue);
            DateTime pdFecha = dtpFecha.Value;
            DataTable dtSaldo = new clsRPTCNCredito().CNProvisiones(pdFecha, pidAgencia);
            if (dtSaldo.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para los parametros seleccionados", "Provisiones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsProvision", dtSaldo));
            dtslist.Add(new ReportDataSource("dtsRutaRep", new clsRPTCNAgencia().CNRutaLogo()));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFecha", pdFecha.ToString(), false));
            paramlist.Add(new ReportParameter("x_idAgencia", pidAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("x_cAgencia", pcAgencia.ToString(), false));
            string reportpath = "RptProvisiones.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void frmRptMoraProducto_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem.Date;
            
        }
    }
}
