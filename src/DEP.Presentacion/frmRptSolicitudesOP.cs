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
    public partial class frmRptSolicitudesOP : frmBase
    {
        clsCNValorados clsOpeValorado = new clsCNValorados();

        public frmRptSolicitudesOP()
        {
            InitializeComponent();            
        }

        private void frmRptSolicitudesOP_Load(object sender, EventArgs e)
        {
            this.cboAgencias.AgenciasYTodos();
            this.iniciarCboEstSolOP();
        }

        private void iniciarCboEstSolOP()
        {
            DataTable dtEstSolOP = clsOpeValorado.CNListEstSolOP();

            this.cboEstSolOP.DataSource = dtEstSolOP;
            this.cboEstSolOP.ValueMember = dtEstSolOP.Columns[0].ColumnName;
            this.cboEstSolOP.DisplayMember = dtEstSolOP.Columns[1].ColumnName;            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //Validaciones
            if (this.cboAgencias.SelectedIndex == -1)
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Reporte de Solicitudes de Ordenes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.dtpFechaCorte.Value > clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha ingresada no puede ser mayor a la fecha actual", "Reporte de Solicitudes de Ordenes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtpFechaCorte.Value = clsVarGlobal.dFecSystem;
                return;
            }

            if (this.cboEstSolOP.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un estado antes de continuar", "Reporte de Solicitudes de Ordenes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idAgencia = Convert.ToInt32(this.cboAgencias.SelectedValue);
            int idEstado = Convert.ToInt32(this.cboEstSolOP.SelectedValue);
            DateTime dFechaCorte = this.dtpFechaCorte.Value;
            string cNomEmpresa = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgencia = clsVarApl.dicVarGen["cNomAge"];
            DateTime dFechaSis = clsVarGlobal.dFecSystem;

            DataTable dtSolOP = clsOpeValorado.CNRptSolOP(idAgencia, idEstado, dFechaCorte);
            if (dtSolOP.Rows.Count > 0)
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_dFechaCorte", dFechaCorte.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmpresa, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgencia, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString("dd/MM/yyyy"), false));                
                paramlist.Add(new ReportParameter("x_cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString(), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsRptSolOP", dtSolOP));

                string reportpath = "rptSolicitudesOrdPago.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No Existen Datos para el Reporte", "Reporte de Solicitudes de Ordenes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }        
    }
}
