using DEP.CapaNegocio;
using EntityLayer;
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

namespace DEP.Presentacion
{
    public partial class frmRptCuentasEspeciales : frmBase
    {
        clsCNDeposito objDeposito = new clsCNDeposito();

        public frmRptCuentasEspeciales()
        {
            InitializeComponent();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (this.dtFechaInicial.Value > this.dtFechaFinal.Value)
            {
                MessageBox.Show("La Fecha Inicial de Busqueda no puede ser mayor a la Fecha Final", "Reporte de Cuentas Especiales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;    
            }

            if (this.dtFechaInicial.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La Fecha Inicial de Busqueda no puede ser mayor a la Fecha del Sistema", "Reporte de Cuentas Especiales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtFechaInicial.Value = clsVarGlobal.dFecSystem;
                return;
            }

            bool bActivo;
            if (rbtActivo.Checked)
            {
                bActivo = true;
            }
            else if (rbtInactivo.Checked)
            {
                bActivo = false;
            }
            else
            {
                MessageBox.Show("Seleccione Activo o Inactivo", "Reporte de Cuentas Especiales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime dFechaInicial = this.dtFechaInicial.Value;
            DateTime dFechaFinal = this.dtFechaFinal.Value;
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            var dtCuentasEspeciales = objDeposito.CNRptManCtasEspeciales(bActivo, dFechaInicial, dFechaFinal);

            if (dtCuentasEspeciales.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte de Cuentas Especiales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {                
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();                
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen.ToString(), false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString(), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsListaCuentasEspeciales", dtCuentasEspeciales));

                string reportpath = "rptCuentasEspeciales.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
                dtCuentasEspeciales.Dispose();
            }
        }
    }
}
