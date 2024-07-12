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
using CNT.CapaNegocio;
using System.IO;

namespace CNT.Presentacion
{
    public partial class frmLibroMayor : frmBase
    {
        public DataTable dtLibroMayor;
        public frmLibroMayor()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmLibroMayor_Load(object sender, EventArgs e)
        {
            this.dtpFecIni.Value = clsVarGlobal.dFecSystem;
            this.dtpFecFin.Value = clsVarGlobal.dFecSystem;
            cboMoneda.CargaDatosContaIntegrado();
            btnExportar.Enabled = false;
            btnImprimir1.Enabled = false;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                DateTime dFecIni = dtpFecIni.Value.Date;
                DateTime dFecFin = dtpFecFin.Value.Date;
                int idMoneda = (int)cboMoneda.SelectedValue;
                string pcCuentaiIni = txtCtaCtbIni.Text ;
                string pcCuentaiFin = txtCtaCtbFin.Text ;
                string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];

                paramlist.Add(new ReportParameter("x_dFechaFinal", dFecFin.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRUC", clsVarApl.dicVarGen["cRUC"], false));
                paramlist.Add(new ReportParameter("x_cCuenta", pcCuentaiIni +"-" + pcCuentaiFin, false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dtsLibroMayor",dtLibroMayor));

                string reportpath = "RptLibroMayor.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void txtCtaCtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnProcesar1_Click(sender,e);   
            }
        }

        private void dtgLibroMayor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgLibroMayor.Rows.Count>0)
            {
                if (dtgLibroMayor.CurrentRow!=null)
                {                 
                    int nVoucher = Convert.ToInt32(dtgLibroMayor.CurrentRow.Cells["nVoucher"].Value);                  
                    frmAsientoManual frmasientomanual = new frmAsientoManual(nVoucher);
                    frmasientomanual.ShowDialog();
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            exportarLibroMayor();
        }

        #endregion

        #region Metodos

        private Boolean validar()
        {
            if (dtpFecIni.Value > dtpFecFin.Value)
            {
                MessageBox.Show("La fecha final debe ser mayor o igual a la Incial", "Libro Mayor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtCtaCtbFin.Text))
            {
                MessageBox.Show("Debe ingresar una cuenta contable valida", "Libro Mayor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtCtaCtbFin.Text.Length == 1)
            {
                MessageBox.Show("Debe ingresar una cuenta contable valida", "Libro Mayor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void formatoGridLibroMayor()
        {
            foreach (DataGridViewColumn item in dtgLibroMayor.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }

            dtgLibroMayor.Columns["dfecha"].Visible = true;
            dtgLibroMayor.Columns["nVoucher"].Visible = true;
            dtgLibroMayor.Columns["cNombreAge"].Visible = true;
            dtgLibroMayor.Columns["cAsiento"].Visible = true;
            dtgLibroMayor.Columns["nDebe"].Visible = true;
            dtgLibroMayor.Columns["nHabe"].Visible = true;
            dtgLibroMayor.Columns["cCtaCtb"].Visible = true;
            dtgLibroMayor.Columns["cDesCta"].Visible = true;

            dtgLibroMayor.Columns["dfecha"].HeaderText = "Fecha";
            dtgLibroMayor.Columns["nVoucher"].HeaderText = "Voucher";
            dtgLibroMayor.Columns["cNombreAge"].HeaderText = "Agencia";
            dtgLibroMayor.Columns["cAsiento"].HeaderText = "Asiento";
            dtgLibroMayor.Columns["nDebe"].HeaderText = "Debe";
            dtgLibroMayor.Columns["nHabe"].HeaderText = "Haber";
            dtgLibroMayor.Columns["cCtaCtb"].HeaderText = "Cuenta";
            dtgLibroMayor.Columns["cDesCta"].HeaderText = "Descripción";

            dtgLibroMayor.Columns["dfecha"].Width = 75;
            dtgLibroMayor.Columns["nVoucher"].Width = 48;
            dtgLibroMayor.Columns["cNombreAge"].Width = 90;
            dtgLibroMayor.Columns["cAsiento"].Width = 120;
            dtgLibroMayor.Columns["nDebe"].Width = 100;
            dtgLibroMayor.Columns["nHabe"].Width = 100;
            dtgLibroMayor.Columns["cCtaCtb"].Width =80;

            dtgLibroMayor.Columns["nDebe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgLibroMayor.Columns["nDebe"].DefaultCellStyle.Format = "N2";

            dtgLibroMayor.Columns["nHabe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgLibroMayor.Columns["nHabe"].DefaultCellStyle.Format = "N2";

            dtgLibroMayor.Columns["nDebe"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgLibroMayor.Columns["nHabe"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgLibroMayor.Columns["dfecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void sumarSubtotales(DataTable dtLibro)
        {
            var nDebe = dtLibro.AsEnumerable().Sum(x => (decimal)x["nDebe"]);
            var nHabe = dtLibro.AsEnumerable().Sum(x => (decimal)x["nHabe"]);

            txtSubDebe.Text = string.Format("{0:0.00}", nDebe);
            txtSubHaber.Text = string.Format("{0:0.00}", nHabe);
                       
        }

        private void exportarLibroMayor()
        {
            if (dtpFecIni.Value > dtpFecFin.Value)
            {
                MessageBox.Show("La fecha final debe ser mayor o igual a la Incial", "Libro Mayor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime dFechIni = dtpFecIni.Value;
            DateTime dFechaFin = dtpFecFin.Value;
            int idMoneda = Convert.ToInt16(cboMoneda.SelectedValue);

            DataTable dtLibroMayor = new clsCNAsiento().CNPLELibroMayor(dFechIni,dFechaFin,idMoneda);
            DialogResult result;
            result = folderBrowserDialog.ShowDialog();

            string cRuta;
            string cNomArc;
            if (result == DialogResult.OK)
            {
                cRuta = folderBrowserDialog.SelectedPath;
                cNomArc = cRuta + "\\" + new clsCNAsiento().cNomArcPLELibroMayor(cboMoneda.SelectedValue.ToString(), dtLibroMayor.Rows.Count, dFechaFin);
                StreamWriter sr = new StreamWriter(@cNomArc);
                string cCadena;
                for (int i = 0; i < dtLibroMayor.Rows.Count; i++)
                {
                    cCadena = dtLibroMayor.Rows[i]["cCadena"].ToString();
                    sr.WriteLine(cCadena);
                }
                sr.Close();
                MessageBox.Show("El archivo " + cNomArc + " Se generó correctamente", "PLE - Libro Mayor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        #endregion

        private void txtCtaCtbFin_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnProcesar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                DateTime dFecIni = dtpFecIni.Value.Date;
                DateTime dFecFin = dtpFecFin.Value.Date;
                int idMoneda = (int)cboMoneda.SelectedValue;
                string pcCuentaiIni = txtCtaCtbIni.Text;
                string pcCuentaiFin = txtCtaCtbFin.Text;
                string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
                dtLibroMayor = new clsRPTCNContabilidad().CNLibroMayor(idMoneda, dFecIni, dFecFin, Convert.ToInt32(pcCuentaiIni), Convert.ToInt32(pcCuentaiFin));
                if (dtLibroMayor.Rows.Count > 0)
                {
                    dtgLibroMayor.DataSource = dtLibroMayor;
                    sumarSubtotales(dtLibroMayor);
                    formatoGridLibroMayor();
                    dtgLibroMayor.Focus();
                    
                }
                else
                {
                    txtCtaCtbFin.SelectAll();
                    txtSubDebe.Text = "0.00";
                    txtSubHaber.Text = "0.00";
                    dtgLibroMayor.DataSource = null;
                }
                btnCancelar1.Enabled = true;
                btnProcesar1.Enabled = false;
                btnImprimir1.Enabled = true;
                grbFiltros.Enabled = false;
                chcActExpot.Enabled = false;
            }
            else
            {
                txtCtaCtbFin.SelectAll();
                txtSubDebe.Text = "0.00";
                txtSubHaber.Text = "0.00";
                dtgLibroMayor.DataSource = null;
            }
        }

        private void chcActExpot_CheckedChanged(object sender, EventArgs e)
        {
            if (chcActExpot.Checked)
            {
                txtCtaCtbFin.Clear();
                txtCtaCtbIni.Clear();
                grbCtaContable.Enabled = false;
                btnProcesar1.Enabled = false;
                btnCancelar1.Enabled = false;
                btnImprimir1.Enabled = false;
                btnExportar.Enabled = true;
                dtgLibroMayor.DataSource = null;
                txtSubDebe.Text = "0.00";
                txtSubHaber.Text = "0.00";
            }
            else
            {
                grbCtaContable.Enabled = true;
                btnProcesar1.Enabled = true;
                btnCancelar1.Enabled = true;
                btnExportar.Enabled = false;
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            btnCancelar1.Enabled = false;
            btnProcesar1.Enabled = true;
            btnImprimir1.Enabled = false;
            grbFiltros.Enabled = true;
            chcActExpot.Enabled = true;
            dtgLibroMayor.DataSource = null;
            txtSubDebe.Text = "0.00";
            txtSubHaber.Text = "0.00";
        }


    }
}
