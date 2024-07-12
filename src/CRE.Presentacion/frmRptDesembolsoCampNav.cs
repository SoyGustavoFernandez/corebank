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
using System.Data;
using GEN.CapaNegocio;
using CLI.Presentacion;
using GEN.ControlesBase;
using System.Xml.Serialization;
using GEN.Funciones;
using System.Text.RegularExpressions;
using CLI.CapaNegocio;
using GEN.ControlesBase;
using GEN.BotonesBase;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Net;
using System.Collections;
using CLI.Servicio;
using GEN.Funciones;
using EntityLayer;
using CRE.CapaNegocio;


namespace CRE.Presentacion
{
    public partial class frmRptDesembolsoCampNav : frmBase
    {
        #region Variables Globales
        string cTituloMsje = "Reporte de Desembolso de Campaña Navideña (BONOS)";
        ClsCNClienteExclusivo objCE = new ClsCNClienteExclusivo();


        #endregion

        #region Eventos

        public frmRptDesembolsoCampNav()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtpDesde.Value) > Convert.ToDateTime(dtpHasta.Value))
            {
                MessageBox.Show("La fecha seleccionada es mayor a la de hoy.", cTituloMsje, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            ImprimirReporte();
        }

        #endregion



        #region Metodos


        private void ImprimirReporte()
        {
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();

            ClsCNClienteExclusivo objCE = new ClsCNClienteExclusivo();

            DataTable dsReporte = objCE.CNReporteDesembolsoCampNav(Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));

            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("UserID", clsVarGlobal.User.cNomUsu, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("dFechaSis", Convert.ToString(clsVarGlobal.dFecSystem), false));

            paramlist.Add(new ReportParameter("dFechaIni", Convert.ToString(dtpDesde.Value), false));
            paramlist.Add(new ReportParameter("dFechaFin", Convert.ToString(dtpHasta.Value), false));

            dtslist.Add(new ReportDataSource("dsReporteDesembolso", dsReporte));

            string reportpath = "rptDesembolsoCampNavi.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }

        #endregion

       


       


    }
}
