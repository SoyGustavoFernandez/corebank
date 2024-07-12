using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using RCP.CapaNegocio;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization; 

namespace RCP.Presentacion
{
    public partial class frmRptCredCastigadosMayorTresUit : frmBase
    {
        #region Variables
        private clsCNReportes cnReportes = new clsCNReportes();
        private DataTable dtCastigados;
        #endregion
        #region Metodos
        
        public frmRptCredCastigadosMayorTresUit()
        {
            InitializeComponent();
        }

        private void agregarAnioMes()
        {
            int nAnio = clsVarGlobal.dFecSystem.Year;
            int nMes = clsVarGlobal.dFecSystem.Month;

            DataTable dtAnio = new DataTable();
            DataColumn dc = new DataColumn("nAnio", typeof(int));
            dtAnio.Columns.Add(dc);
            dc = new DataColumn("cAnio", typeof(string));
            dtAnio.Columns.Add(dc);

            for (int i = nAnio; i >= 2001; i--)
            {
                DataRow row = dtAnio.NewRow();
                row["nAnio"] = i;
                row["cAnio"] = i.ToString();
                dtAnio.Rows.Add(row);
            }

            DataTable dtMes = new DataTable();
            DataColumn dc1 = new DataColumn("nMes", typeof(int));
            dtMes.Columns.Add(dc1);
            dc1 = new DataColumn("cMes", typeof(string));
            dtMes.Columns.Add(dc1);
            for (int i = 1; i <= 12; i++)
            {
                DataRow row = dtMes.NewRow();
                row["nMes"] = i;
                row["cMes"] = i.ToString();
                dtMes.Rows.Add(row);
            }

            cboAnio.ValueMember = "nAnio";
            cboAnio.DisplayMember = "cAnio";
            cboAnio.DataSource = dtAnio;

            cboMes.ValueMember = "nMes";
            cboMes.DisplayMember = "cMes";
            cboMes.DataSource = dtMes;

            cboAnio.SelectedValue = nAnio;
            cboMes.SelectedValue = nMes;
        }

        private void getRptCastigados()
        {
            dtCastigados = cnReportes.rptCastigadosTresUit(Convert.ToInt32(cboAnio.SelectedValue), Convert.ToInt32(cboMes.SelectedValue));
        }

        private void bloquearProceso(bool lBloqueo){
            grbDatosProcesar.Enabled = !lBloqueo;
            grbReportes.Enabled = lBloqueo;
            btnImprimir1.Enabled = lBloqueo;
        }
        #endregion
        #region Eventos
        private void frmRptCredCastigadosMayorTresUit_Load(object sender, EventArgs e)
        {
            agregarAnioMes();
            bloquearProceso(false);

            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            string cFecha = "Puno, " + clsVarGlobal.dFecSystem.Day + " de " + dtinfo.GetMonthName(clsVarGlobal.dFecSystem.Month) + " del " + clsVarGlobal.dFecSystem.Year;
            txtFechaReporte.Text = cFecha;
        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            getRptCastigados();
            bloquearProceso(true);
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            bloquearProceso(false);
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (rptCarta.Checked)
            {
                if (txtNombre.Text == "")
                {
                    MessageBox.Show("Se debe llenar el campo Nombre", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (txtPeriodo.Text == "")
                {
                    MessageBox.Show("Se debe llenar el campo Periodo", "Validaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            List<ReportDataSource> dtsList = new List<ReportDataSource>();
            dtsList.Add(new ReportDataSource("dtCastigados", dtCastigados));

            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

            string reportPath = "";
            if (rptCastigados.Checked)
            {
                reportPath = "rptCastigadosMayorTresUit.rdlc";
            }
            else if(rptCarta.Checked)
            {
                paramList.Add(new ReportParameter("cFechaReporte", txtFechaReporte.Text));
                paramList.Add(new ReportParameter("cNombre", txtNombre.Text));
                paramList.Add(new ReportParameter("cCarta", txtNumCarta.Text));
                paramList.Add(new ReportParameter("cPeriodo", txtPeriodo.Text));
                paramList.Add(new ReportParameter("nAnio", cboAnio.Text));

                reportPath = "rptCastigadosMayorTresUitCarta.rdlc";
            }else if(rptSustento.Checked)
            {
                reportPath = "rptCastigadosMayorTresUitSustento.rdlc";
            }


            new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
        }
        #endregion
    }
}
