using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace ADM.Presentacion
{
    public partial class frmRptRastreo : frmBase
    {
        clsCNValidaReglasDinamicas objOpciones = new clsCNValidaReglasDinamicas();
        clsRPTCNAdministracion objAdministracion = new clsRPTCNAdministracion();

        public frmRptRastreo()
        {
            InitializeComponent();
        }

        private void cboModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargaropciones();
        }

        private void cargaropciones()
        {
            if (cboModulo.SelectedIndex > -1)
            {
                if (cboModulo.SelectedValue is DataRowView) return;

                int idModulo = (int)cboModulo.SelectedValue;
                DataTable dt = objOpciones.CargarListaOpciones(idModulo);

                cboMenu.DataSource = dt;
                cboMenu.ValueMember = dt.Columns["idMenu"].ToString();
                cboMenu.DisplayMember = dt.Columns["cMenu"].ToString();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int idModulo = (int)cboModulo.SelectedValue;
            int idMenu = (int)cboMenu.SelectedValue;
            DateTime dFecHorInicio = dtpFechaInicio.Value.Date;
            DateTime dFecHorFinal = dtpFechaFinal.Value.Date;

            DataTable dtRegistrosRastreo = objAdministracion.CNListarRegistrosRastreo(idModulo, idMenu, dFecHorInicio, dFecHorFinal);
            
            if (dtRegistrosRastreo.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsRegistrosRastreo", dtRegistrosRastreo));
                List<ReportParameter> paramList = new List<ReportParameter>();

                paramList.Add(new ReportParameter("x_cNomEmpresa", clsVarApl.dicVarGen["cNomEmpresa"], false));
                paramList.Add(new ReportParameter("x_cNomAgencia", clsVarApl.dicVarGen["cNomAge"], false));
                paramList.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("x_cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                paramList.Add(new ReportParameter("x_idModulo", idModulo.ToString(), false));
                paramList.Add(new ReportParameter("x_idMenu", idMenu.ToString(), false));
                paramList.Add(new ReportParameter("x_dFecHorInicio", dFecHorInicio.ToString("dd/MM/yyyy"), false));
                paramList.Add(new ReportParameter("x_dFecHorFinal", dFecHorFinal.ToString("dd/MM/yyyy"), false));

                string reportPath = "rptRegistrosRastreo.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos", "Reporte de Rastreo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmRptRastreo_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            cboModulo.SelectedValue = 1;
            cargaropciones();
        }
    }
}
