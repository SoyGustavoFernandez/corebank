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
using GEN.Funciones;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmRptPlazoFijoxVencer : frmBase
    {
        #region Variables Globales

        private const string cTituloMsjes = "Reporte de plazos fijos.";

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            IniForm();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            int idAgencia = Convert.ToInt16(cboAgencia.SelectedValue);
            int idMoneda = Convert.ToInt16(cboMoneda.SelectedValue);
            DateTime dFecSis = clsVarGlobal.dFecSystem;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            string cRutaLogo =  clsVarApl.dicVarGen["CRUTALOGO"];
            int nNumDiasAntes = Convert.ToInt16(nudDiasAntes.Value);
            int lindRen = 0;
            string x_cNomRen = "";

            DataTable dtData = null;

            if (chcAutorenovables.Checked)
            {
                lindRen = 1;  //--Solo renovables
                x_cNomRen = "(SOLO RENOVABLES)";               
            }
            else
            {
                lindRen = 0;   //--Todos
                x_cNomRen = "(RENOVABLES Y NO RENOVABLES)";
            }
            dtData = new clsRPTCNDeposito().CNRptCuentasPlazosFijoxVencer(dFecSis, idAgencia, idMoneda, nNumDiasAntes, lindRen);

            if (dtData.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_idAgencia", idAgencia.ToString(), false));
                paramlist.Add(new ReportParameter("x_idMoneda", idMoneda.ToString(), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_dFecSis", dFecSis.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_nNumDiasAntes", Convert.ToString(nudDiasAntes.Value), false));
                paramlist.Add(new ReportParameter("cRenovable", x_cNomRen, false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", cRutaLogo, false));
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsData", dtData));

                string reportpath = string.Empty;

                reportpath = "RptCuentasPlazosFijoxVencer.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        #endregion

        #region Metodos

        public frmRptPlazoFijoxVencer()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            if (cboAgencia.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la agencia.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cboMoneda.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la moneda.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true; ;
        }

        private void IniForm()
        {
            cboMoneda.MonedasYTodos();
            cboMoneda.SelectedIndex = -1;
            cboAgencia.SelectedIndex = -1;
        }

        #endregion

    }
}
