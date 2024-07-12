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
using CAJ.CapaNegocio;
using EntityLayer;
using Microsoft.Reporting.WinForms;

namespace CAJ.Presentacion
{
    public partial class frmRptRegComprasProveedor : frmBase
    {
        /****************************************
        Tipos de Reportes:
        1 --> Reporte por tipo de Destino
        2 --> Reporte por Proveedor
        3 --> Reporte opr tipo comprobante
        *****************************************/
        clsCNCajaChica rptComprobante = new clsCNCajaChica();
        private int idRep = 2;
        private int idCli = 0;
        
        public frmRptRegComprasProveedor()
        {
            InitializeComponent();
            dtpFecInicial.Value = clsVarGlobal.dFecSystem;
            dtpFecFinal.Value = clsVarGlobal.dFecSystem;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string dFecIni = this.dtpFecInicial.Value.ToShortDateString();
            string dFecFin = this.dtpFecFinal.Value.ToShortDateString();
            int idAgencia = Convert.ToInt32(cboAgencia.SelectedValue.ToString());
            if (chcTodos.Checked)
            {
                idCli = 0;
            }
            else
            {
                if (string.IsNullOrEmpty(conBusCli.txtNroDoc.Text))
                {
                    MessageBox.Show("Debe Buscar el Proveedor...", "Reporte de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                idCli = Convert.ToInt32(conBusCli.txtCodCli.Text);
            }

            if (!chcTodos.Checked && (string.IsNullOrEmpty(conBusCli.txtCodCli.Text) || string.IsNullOrEmpty(conBusCli.txtNroDoc.Text)))
            {
                MessageBox.Show("Seleccione un proveedor.", "Reporte de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboAgencia.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una agencia.", "Reporte de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpFecFinal.Value < dtpFecInicial.Value)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor a la fecha final.", "Reporte de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (rbtFecPago.Checked && new clsCNCajaChica().RptRegCompras(dtpFecInicial.Value, dtpFecFinal.Value, idAgencia, idRep, idCli).Rows.Count <= 0)
            {
                MessageBox.Show("No existen datos para mostrar.", "Reporte de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            

            List<ReportParameter> paramlist = new List<ReportParameter>();            
            DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;
            String cNomAgen = clsVarGlobal.cNomAge;
            String cRutLogo = clsVarApl.dicVarGen["CRUTALOGO"];

            paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen.ToString(), false));
            paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString(), false));
            paramlist.Add(new ReportParameter("x_dFechaINI", dFecIni, false));
            paramlist.Add(new ReportParameter("x_dFechaFIN", dFecFin, false));
            paramlist.Add(new ReportParameter("x_cRutLogo", cRutLogo.ToString(), false));
            paramlist.Add(new ReportParameter("x_nIdAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("x_nidTipRep", idRep.ToString(), false));
            paramlist.Add(new ReportParameter("x_nidFiltro", idCli.ToString(), false));

            if (rbtFecPago.Checked)
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Add(new ReportDataSource("DsCpg", new clsCNCajaChica().RptRegCompras(dtpFecInicial.Value, dtpFecFinal.Value, idAgencia, idRep, idCli)));

                string reportpath = "RptCpgCajGenProovedorPag.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                this.btnImprimir.Enabled = true;
            }
            else
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Add(new ReportDataSource("DsCpg", new clsCNCajaChica().RptRegComprasEmitidos(dtpFecInicial.Value, dtpFecFinal.Value, idAgencia, idRep, idCli)));

                string reportpath = "RptCpgCajGenProovedorEmi.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                this.btnImprimir.Enabled = true;
            }
            
        }

        private void chcTodos_CheckedChanged(object sender, EventArgs e)
        {
            conBusCli.txtCodAge.Clear();
            conBusCli.txtCodInst.Clear();
            conBusCli.txtCodCli.Clear();
            conBusCli.txtNombre.Clear();
            conBusCli.txtNroDoc.Clear();
            conBusCli.txtDireccion.Clear();
            conBusCli.txtCodCli.Enabled = !chcTodos.Checked;
            conBusCli.btnBusCliente.Enabled = !chcTodos.Checked;
        }

        private void frmRptRegComprasProveedor_Load(object sender, EventArgs e)
        {

        }
    }
}
