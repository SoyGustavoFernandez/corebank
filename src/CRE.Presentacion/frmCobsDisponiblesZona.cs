using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmCobsDisponiblesZona : frmBase
    {
        clsCNCondonacion cnCondonacion = new clsCNCondonacion();
        int idZona = 0;
        string cDesZona = "";
        public frmCobsDisponiblesZona()
        {
            InitializeComponent();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            int idAgencia = clsVarGlobal.nIdAgencia;
            DataTable datos = cnCondonacion.getCobsDisponiblesZona(idAgencia);

            List<ReportParameter> paramList = new List<ReportParameter>();
            List<ReportDataSource> dtsList = new List<ReportDataSource>();
            //DataTable datos = (DataTable)dtgCobs.DataSource;
            dtsList.Add(new ReportDataSource("datos", datos));

            paramList.Add(new ReportParameter("cNomUser", clsVarGlobal.User.cWinUser, false));
            paramList.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
            paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
            paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramList.Add(new ReportParameter("cTitulo", "ZONA: " + cDesZona, false));
            //paramList.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));

            string reportPath = "rptCobsDisponibles.rdlc";
            new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
        }

        private void frmCobsDisponiblesZona_Load(object sender, EventArgs e)
        {
            DataTable zona = cnCondonacion.nombreZona(clsVarGlobal.nIdAgencia);
            if (zona.Rows.Count > 0)
            {
                txtZona.Text = zona.Rows[0]["cDesZona"].ToString();
                cDesZona = zona.Rows[0]["cDesZona"].ToString();
                int idZona = Convert.ToInt32(zona.Rows[0]["idZona"]);
            }
        }
    }
}
