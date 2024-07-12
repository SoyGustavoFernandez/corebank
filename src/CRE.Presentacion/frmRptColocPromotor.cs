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
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using Microsoft.Reporting.WinForms;
using GEN.CapaNegocio;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmRptColocPromotor : frmBase
    {
        #region Variables Globales

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = clsVarGlobal.dFecSystem.AddDays(-1).Date;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            DateTime dFecha = dtpFecha.Value.Date;
            DateTime dFecIni = new DateTime(dFecha.Year, dFecha.Month, 1);

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            decimal nTipoCambio = 0;

            DataTable dtTiposCambios = new clsCNGenAdmOpe().RetornaTiposCambio(dFecha);
            nTipoCambio = Convert.ToDecimal(dtTiposCambios.Rows[0]["nTipCamFij"]);

            DataTable dtData = new clsRPTCNCredito().CNrptColocPromotores(dFecha);

            if (dtData.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte de Apertura de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString()));
            paramlist.Add(new ReportParameter("nTipoCambio", nTipoCambio.ToString(), false));
            paramlist.Add(new ReportParameter("dFecha", dFecha.ToString(), false));
            paramlist.Add(new ReportParameter("dFecIni", dFecIni.Date.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsData", dtData));

            string reportpath = "rptColocPromotor.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }

        #endregion

        #region Metodos

        public frmRptColocPromotor()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            if (dtpFecha.Value >= clsVarGlobal.dFecSystem.Date)
            {
                MessageBox.Show("Seleccione una fecha válida para procesar el reporte.", "Validación de datos",
                                                                                            MessageBoxButtons.OK,
                                                                                            MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion

    }
}
