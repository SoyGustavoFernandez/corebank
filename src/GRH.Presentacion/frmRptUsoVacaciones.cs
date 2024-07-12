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
using GEN.LibreriaOffice;
using GRH.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace GRH.Presentacion
{
    public partial class frmRptUsoVacaciones : frmBase
    {
        #region Variables Globales

        private const string cTituloMsjes = "Reporte de uso de vacaciones";

        #endregion

        #region Eventos
        

        private void Form_Load(object sender, EventArgs e)
        {
            cboAgencias.SelectedIndex = -1;
            dtpFecIni.Value = clsVarGlobal.dFecSystem;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            int idAge = Convert.ToInt16(cboAgencias.SelectedValue);

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            DateTime dFecIni = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;

            DataTable dtRpt = new clsRPTCNRecurHum().CNRptUsoVacaciones(idAge, dFecIni, dFecFin);
            if (dtRpt.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));


                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsData", dtRpt));
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));


                string reportpath = "RptUsoVacaciones.rdlc";

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

        public frmRptUsoVacaciones()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            if (cboAgencias.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la agencia.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion 

    }
}
