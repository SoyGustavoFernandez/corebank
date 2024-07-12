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
using CRE.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;

namespace CRE.Presentacion
{
    public partial class frmCreditosDesembOfertaCamp : frmBase
    {
        private ClsCNClienteExclusivo objCNClienteExclusivo = new ClsCNClienteExclusivo();
        public frmCreditosDesembOfertaCamp()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!this.validarSeleccion()) return;

            DataTable dtReporteDesembolso = objCNClienteExclusivo.CNRPTDesembolsoCampEscolar(this.dtpDesde.Value, this.dtpHasta.Value);

            List<ReportParameter> paramList = new List<ReportParameter>();
            List<ReportDataSource> dtsList = new List<ReportDataSource>();

            dtsList.Add(new ReportDataSource("dsDesembolsoCamp", dtReporteDesembolso));
            
            paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));
            paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy")));
            paramList.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge ));
            paramList.Add(new ReportParameter("dFechaDesde", this.dtpDesde.Value.ToString("dd/MM/yyyy"), false));
            paramList.Add(new ReportParameter("dFechaHasta", this.dtpHasta.Value.ToString("dd/MM/yyyy"), false));

            string reportPath = "rptDesembolsoCampEscolar.rdlc";
            new frmReporteLocal(dtsList, reportPath, paramList).ShowDialog();
        }

        private bool validarSeleccion()
        {
            if (this.dtpDesde.Value > clsVarGlobal.dFecSystem || this.dtpHasta.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show(string.Concat("Las fechas de inicio y fin deben ser menores a la fecha del sistema (", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), ")."),
                    "RANGO DE FECHAS INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (this.dtpHasta.Value < this.dtpDesde.Value)
            {
                MessageBox.Show(string.Concat("La fecha de inicio debe ser menor a la fecha de fin (", this.dtpHasta.Value.ToString("dd/MM/yyyy"), ")."),
                    "RANGO DE FECHAS INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void frmCreditosDesembOfertaCamp_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = clsVarGlobal.dFecSystem;
            dtpHasta.Value = clsVarGlobal.dFecSystem;
        }
    }
}
