using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using RCP.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace RCP.Presentacion
{
    public partial class frmRptSeguimientoCliente : frmBase
    {

        clsCNSolicitudRecuperacion cnsolicitudrecupera = new clsCNSolicitudRecuperacion();

        public frmRptSeguimientoCliente()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboPersonalCargo1.cargarPersonal("nCargosRecuperadores", 0);
            dtFechaInicio.Value = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            dtFechaFinal.Value = clsVarGlobal.dFecSystem;
        }

        private bool validar()
        {
            bool lVal = false;

            if ((dtFechaInicio.Value-dtFechaFinal.Value).Days > 0)
            {
                MessageBox.Show("La Fecha Final debe de ser mayor o igual a la fecha inicial", "Validacón ed fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lVal;
            }

            lVal = true;
            return lVal;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var idRecuperador=Convert.ToInt32(this.cboPersonalCargo1.SelectedValue);
                var eventos = cnsolicitudrecupera.RptEventosTransRecuperaFiltro(dtFechaInicio.Value.Date,dtFechaFinal.Value.Date,idRecuperador);

                if (eventos.Rows.Count > 0)
                {
                    List<ReportDataSource> dtsList = new List<ReportDataSource>();
                    dtsList.Add(new ReportDataSource("dsEventosTrans", eventos));

                    List<ReportParameter> paramList = new List<ReportParameter>();
                    paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                    paramList.Add(new ReportParameter("idCuenta", "0", false));
                    paramList.Add(new ReportParameter("cNomAgen", clsVarApl.dicVarGen["cNomAge"], false));
                    paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));


                    string reportPath = "rptContactoCliente.rdlc";
                    new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
                }
                else
                {
                    MessageBox.Show("No existen datos", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

    }
}
