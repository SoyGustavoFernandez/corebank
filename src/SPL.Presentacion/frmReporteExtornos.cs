using GEN.ControlesBase;
using SPL.CapaNegocio;
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
using CLI.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using CLI.Presentacion;
using GEN.BotonesBase;
using EntityLayer;



namespace SPL.Presentacion
{
    public partial class frmReporteExtornosSPL : frmBase
    {

        #region Variables Globales
        string cTitulo = "Reporte Extorno SPLAFT";

        #endregion

        #region Eventos
        public frmReporteExtornosSPL()
        {
            InitializeComponent();
        }


        #endregion

        #region Metodos

        private void btnImprimir1_Click(object sender, EventArgs e)
        {

            DateTime dFechaDesde = Convert.ToDateTime(dtDesde.Value.ToString());
            DateTime dFechaHasta = Convert.ToDateTime(dtHasta.Value.ToString());


            if (dFechaDesde < dFechaHasta)
            {
                string cNomAgencia = clsVarGlobal.cNomAge.ToString();
                string dFecOpe = clsVarGlobal.dFecSystem.ToString();
                string cNomUser = clsVarGlobal.User.cNomUsu.ToString();
                string dFechaDes = dFechaDesde.ToString("yyyy/MM/dd");
                string dFechaHas = dFechaHasta.ToString("yyyy/MM/dd");


                DataTable dtExtorno = new clsRPTCNSplaft().CNReporteExtornoSPL(dFechaDes, dFechaHas);
                if (dtExtorno.Rows.Count == 0)
                {
                    MessageBox.Show("No existen datos para este reporte.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();
                    dtsList.Add(new ReportDataSource("dsExtornos", dtExtorno));

                    List<ReportParameter> paramlist = new List<ReportParameter>();
                    paramlist.Add(new ReportParameter("dFecOpe", dFecOpe.ToString(), false));
                    paramlist.Add(new ReportParameter("cNomAgen", cNomAgencia.ToString(), false));
                    paramlist.Add(new ReportParameter("cNomUser", cNomUser.ToString(), false));
                    paramlist.Add(new ReportParameter("dFechaDesde", dFechaDes.ToString(), true));
                    paramlist.Add(new ReportParameter("dFechaHasta", dFechaHas.ToString(), true));

                    string reportPath = "rptExtornosSPL.rdlc";
                    new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();

                }
            }
            else
            {
                MessageBox.Show("Existen inconsistencias con las fechas.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        #endregion

        }
    }
}
