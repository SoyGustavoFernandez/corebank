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
    public partial class frmCtasPorCliente : frmBase
    {
        #region Metodos
        public frmCtasPorCliente()
        {
            InitializeComponent();
            cboEstadoCuentaCli.SelectedValue = -1;
        }
        #endregion

        #region Eventos
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //VALIDACIONES
            if (string.IsNullOrEmpty(this.conBusCliente.txtCodCli.Text))
            {
                MessageBox.Show("Seleccione un cliente antes de generar el reporte", "Reporte de Cuentas por Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(this.conBusCliente.txtNombre.Text))
            {
                MessageBox.Show("Seleccione un cliente antes de generar el reporte", "Reporte de Cuentas por Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.cboEstadoCuentaCli.Text == "")
            {
                MessageBox.Show("Seleccione un estado de cuenta", "Reporte de Cuentas por Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int idCliente = Convert.ToInt32(this.conBusCliente.txtCodCli.Text);            
            string idEstado = "";
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];            

            idEstado = Convert.ToString(cboEstadoCuentaCli.SelectedValue);

            DataTable dtDatosCtasPorCliente = new clsRPTCNDeposito().ADDatosCtasPorCliente(idCliente, idEstado);

            if (dtDatosCtasPorCliente.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte de Cuentas por Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_cEstadoCuenta", cboEstadoCuentaCli.Text, false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString(), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsCtasPorCliente", dtDatosCtasPorCliente));

                string reportpath = "rptCtasPorCliente.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            conBusCliente.limpiarControles();
            cboEstadoCuentaCli.SelectedValue = -1;
            conBusCliente.txtCodCli.Enabled = true;
            conBusCliente.txtCodCli.Focus();
        }
        #endregion

        private void cboEstadoCuentaCli_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
