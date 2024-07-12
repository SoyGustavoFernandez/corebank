﻿using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmRptAnalisisCartera : frmBase
    {
        public frmRptAnalisisCartera()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dtpFecSistema.Value >= clsVarGlobal.dFecSystem.Date)
            {
                MessageBox.Show("Fecha debe ser máximo a un día antes de la fecha del sistema", "Análisis de Cartera", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DateTime dFecAct = dtpFecSistema.Value, dFecTmp, 
                    dAnioAnt = Convert.ToDateTime("1900-01-01"),
                    dMesAnt = Convert.ToDateTime("1900-01-01");
            DataTable dtAnual = new DataTable();
            DataTable dtMeses = new DataTable(), dtSaldoContable;
            dtAnual.Columns.Add("dFecha", typeof(DateTime));
            dtMeses.Columns.Add("dFecha", typeof(DateTime));

            dFecTmp = dFecAct;
            for (int i = 0; i <= 12; i++)
            {
                switch (i)
                {
                    case 0:
                        dtMeses.Rows.Add(dFecTmp);
                        break;
                    case 1:
                        dtMeses.Rows.Add(dFecTmp);
                        dMesAnt = dFecTmp;
                        break;
                    default:
                        break;
                }
                if (dFecTmp.Month == 12)
                {
                    dtMeses.Rows.Add(dFecTmp);
                    dAnioAnt = dFecTmp;
                }
                dtAnual.Rows.Add(dFecTmp);
                dFecTmp = dFecTmp.AddDays((dFecTmp.Day) * -1);
            }
            DataSet dsAnual = new DataSet("dsFecha");
            DataSet dsMeses = new DataSet("dsFecha");
            dsAnual.Tables.Add(dtAnual);
            String XmlAnual = dsAnual.GetXml();
            XmlAnual = clsCNFormatoXML.EncodingXML(XmlAnual);

            dsMeses.Tables.Add(dtMeses);
            String XmlMeses = dsMeses.GetXml();
            XmlMeses = clsCNFormatoXML.EncodingXML(XmlMeses);

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtSaldoContable = new clsRPTCNCredito().CNSaldoContableAnual(XmlAnual);
            decimal pnMaxFecha = Convert.ToDecimal(dtSaldoContable.Rows[0]["nSaldoMax"]);
            
            dtslist.Add(new ReportDataSource("dtsRutaRep", new clsRPTCNAgencia().CNRutaLogo()));
            dtslist.Add(new ReportDataSource("dtsProvision", new clsRPTCNCredito().CNSaldoProvision(XmlMeses)));
            dtslist.Add(new ReportDataSource("dtsProvisionAnual", new clsRPTCNCredito().CNSaldoProvisionAnual(XmlAnual)));
            dtslist.Add(new ReportDataSource("dtsSaldoContableAnu", dtSaldoContable));
            dtslist.Add(new ReportDataSource("dtsSaldoContable", new clsRPTCNCredito().CNSaldoContable(XmlMeses)));
            dtslist.Add(new ReportDataSource("dtsSaldoProvision", new clsRPTCNCredito().CNSaldodeProvision(XmlAnual)));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("x_dFecha", dtpFecSistema.Value.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFecMesAnt", dMesAnt.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("dFecAnioAnt", dAnioAnt.ToString("dd/MM/yyyy"), false));
            paramlist.Add(new ReportParameter("nMaxAnu", pnMaxFecha.ToString(), false));

            string reportpath = "RPTAnalisisCartera.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void frmRptAnalisisCartera_Load(object sender, EventArgs e)
        {
            dtpFecSistema.Value = clsVarGlobal.dFecSystem.Date;
        }
    }
}
