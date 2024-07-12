using CNT.CapaNegocio;
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

namespace CNT.Presentacion
{
    public partial class frmAsientoTrx : frmBase
    {
        public frmAsientoTrx()
        {
            InitializeComponent();
            dtpFecIni.Value = clsVarGlobal.dFecSystem;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
            clsCNMaestroCuenta ListaTipAsiento = new clsCNMaestroCuenta();
            DataTable dt = ListaTipAsiento.CNListaTipoAsiento();
            this.cboTipoAsiento.DataSource = dt;
            this.cboTipoAsiento.ValueMember = dt.Columns[0].ToString();
            this.cboTipoAsiento.DisplayMember = dt.Columns[1].ToString();
            this.cboTipoAsiento.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private Boolean Validar()
        {
            if (string.IsNullOrEmpty(txtCuenta.Text) || Convert.ToInt32(txtCuenta.Text)==0)
            {
                MessageBox.Show("Debe registrar el Número de Cuenta de la Operación", "Asiento Transacción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            if (dtpFecIni.Value>dtpFecFin.Value)
            {
                MessageBox.Show("La fecha final debe ser mayor o igual a la Inicial", "Asiento Transacción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            return false;
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                return;
            }
            DateTime dFecIni = dtpFecIni.Value.Date;
            DateTime dFecFin = dtpFecFin.Value.Date;
            int idAsiento =Convert.ToInt32(cboTipoAsiento.SelectedValue);
            decimal nTipCambio = clsVarApl.dicVarGen["nTipoCambio"];
            int nCuenta = Convert.ToInt32(txtCuenta.Text);

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("x_dfecini", dFecIni.ToString(), false));
            paramlist.Add(new ReportParameter("x_dFecFin", dFecFin.ToString(), false));
            paramlist.Add(new ReportParameter("x_idCuenta", nCuenta.ToString(), false));
            paramlist.Add(new ReportParameter("x_TipoCambio", nTipCambio.ToString(), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("dtsAsientoCuenta", new clsRPTCNContabilidad().CNAsientoTRX(dFecIni, dFecFin, nCuenta, idAsiento)));

            string reportpath = "RptAsientoTrx.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }
}
