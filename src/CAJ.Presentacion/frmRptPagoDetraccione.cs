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
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace CAJ.Presentacion
{
    public partial class frmRptPagoDetraccione : frmBase
    {
        clsCNComprobantes objCaja = new clsCNComprobantes();

        public frmRptPagoDetraccione()
        {
            InitializeComponent();
        }

        private void frmRptPagoDetraccione_Load(object sender, EventArgs e)
        {
            dtpFecInicial.Value = clsVarGlobal.dFecSystem;
            dtpFecFinal.Value = clsVarGlobal.dFecSystem;
        }

        private void dtpFecInicial_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtpFecInicial.Value>this.dtpFecFinal.Value)
            {
                MessageBox.Show("La Fecha Inicial debe Ser Menor o Igual a la Fecha Final", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpFecInicial.Value = this.dtpFecFinal.Value;
            }
            btnImprimir.Enabled = false;
            btnGrupo.Enabled = true;
        }

        private void dtpFecFinal_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtpFecInicial.Value > this.dtpFecFinal.Value)
            {
                MessageBox.Show("La Fecha Final debe Ser Mayor o Igual a la Fecha Inicial", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpFecFinal.Value = this.dtpFecInicial.Value;
            }
            btnImprimir.Enabled = false;
            btnGrupo.Enabled = true;
        }

        private void btnGrupo_Click(object sender, EventArgs e)
        {
            DateTime dFecIni = this.dtpFecInicial.Value;
            DateTime dFecFin = this.dtpFecFinal.Value;
            DataTable tblista = objCaja.CNListarPagoDetracProveedor(clsVarGlobal.nIdAgencia, dFecIni, dFecFin);
            cboGrupo.DataSource = tblista;
            cboGrupo.ValueMember = tblista.Columns["idGrupo"].ToString();
            cboGrupo.DisplayMember = tblista.Columns["cGrupo"].ToString();
            if (tblista.Rows.Count<=0)
            {
                MessageBox.Show("Para el Rango Indicado no Existe Pagos Generados", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboGrupo.Enabled = false;
                btnImprimir.Enabled = false;
                return;
            }
            cboGrupo.Enabled = true;
            btnImprimir.Enabled = true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {           
            List<ReportParameter> paramlist = new List<ReportParameter>();
            int idGrupo = Convert.ToInt32(cboGrupo.SelectedValue.ToString());

            paramlist.Add(new ReportParameter("x_idGrupo", idGrupo.ToString(), false));            

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Add(new ReportDataSource("DsGrupoCpg", new clsCNComprobantes().CNRptGrupoDetracProveedor(idGrupo)));

            string reportpath = "RptGrupoPagDetraccion.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }
}
