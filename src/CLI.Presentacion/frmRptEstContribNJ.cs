using CLI.CapaNegocio;
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

namespace CLI.Presentacion
{
    public partial class frmRptEstContribNJ : frmBase
    {
        public frmRptEstContribNJ()
        {
            InitializeComponent();
        }

        private void frmRptEstContribPJ_Load(object sender, EventArgs e)
        {
            iniciarComboEstContribuyente();
            dtpFechaInicial.Value = clsVarGlobal.dFecSystem;
            dtpFechaFinal.Value = clsVarGlobal.dFecSystem;
        }

        private void iniciarComboEstContribuyente()
        {
            DataTable dtLista = new clsCNCliente().CNListarEstContribuyente();
            this.cboEstContribu.DataSource = dtLista;

            if (dtLista.Rows.Count > 0)
            {
                this.cboEstContribu.ValueMember = dtLista.Columns[0].ToString();
                this.cboEstContribu.DisplayMember = dtLista.Columns[1].ToString();
            }
            else
            {
                MessageBox.Show("No Existe Responsable de Agencia Seleccionada. Verifique", "Reporte Estado de Contribuyente PN-PJ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (cboEstContribu.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un estado", "Reporte Estado de Contribuyente PN-PJ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dtpFechaInicial.Value > dtpFechaFinal.Value)
            {
                MessageBox.Show("La Fecha Inicial no puede ser mayor a la Fecha Final", "Reporte Estado de Contribuyente PN-PJ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                return;
            }

            if (dtpFechaInicial.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La Fecha Inicial de Busqueda no puede ser mayor a la Fecha del Sistema", "Reporte Estado de Contribuyente PN-PJ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFechaInicial.Value = clsVarGlobal.dFecSystem.Date;
                return;
            }

            int idEstado = Convert.ToInt32(cboEstContribu.SelectedValue);
            DateTime dFechaInicial = this.dtpFechaInicial.Value;
            DateTime dFechaFinal = this.dtpFechaFinal.Value;

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            DataTable dtRpt = new clsCNCliente().CNRptEstadoContribuyenteNJ(idEstado, dFechaInicial, dFechaFinal);
            if (dtRpt.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_dFechaInicio", dFechaInicial.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_dFechaFin", dFechaFinal.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));                
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString(), false));
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsEstContribNJ", dtRpt));

                string reportpath = "rptEstContribNJ.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Reporte Estado de Contribuyente PN-PJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }        
    }
}
