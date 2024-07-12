using EntityLayer;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEP.Presentacion
{
    public partial class frmReporteAhoHis : frmBase
    {
        public frmReporteAhoHis()
        {
            InitializeComponent();
        }

        private void frmReporteAhoHis_Load(object sender, EventArgs e)
        {
            this.cboProducto1.CargarProducto(46);
            CBTodo.Checked = true;
            dtFecProceso.Value = clsVarGlobal.dFecSystem.Date;
            cboAgencia1.SelectedIndex = -1;
            cboMoneda1.MonedasYTodos();
            cboMoneda1.SelectedIndex = -1;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            dtFecProceso.Value = clsVarGlobal.dFecSystem.Date;
            cboAgencia1.SelectedIndex = -1;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (cboAgencia1.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione la agencia", "Reporte histórico de ahorro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboMoneda1.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione la moneda", "Reporte histórico de ahorro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DateTime dFecProceso= dtFecProceso.Value;
            int idAgencia = Convert.ToInt32(cboAgencia1.SelectedValue);
            int idMoneda = Convert.ToInt32(cboMoneda1.SelectedValue);          
            string cNomAgen = clsVarGlobal.cNomAge;
            string idProduc = "";
            string Produc = "";

            if (CBTodo.Checked == true)
            {
                idProduc = "0";
                Produc = "TODOS";
            }
            else if (CBTodo.Checked == false)
            {
                if (Convert.ToString(cboProducto4.SelectedValue) == "0")
                {
                    int i = 1;
                    foreach (DataRowView item in cboProducto4.Items)
                    {
                        if (i < cboProducto4.Items.Count && i > 1)
                            idProduc += item[0] + ",";

                        i++;
                    }
                    idProduc = idProduc.Remove((idProduc.Length - 1), 1);
                    Produc = "TODOS LOS SUBPRODUCTOS DE " + Convert.ToString(cboProducto3.Text);
                }

                else if (Convert.ToString(cboProducto4.SelectedValue) != "0")
                {
                    idProduc = Convert.ToString(cboProducto4.SelectedValue);
                    Produc = Convert.ToString(cboProducto4.Text);
                }
            }
            if (cboProducto4.Text.Trim() == "" & CBTodo.Checked == false)
            {
                MessageBox.Show("Seleccione el tipo de producto", "Reporte histórico de ahorro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtDatosAperturas = new clsRPTCNDeposito().CNSaldoAHo(idMoneda, idProduc, idAgencia, dFecProceso);
            if (dtDatosAperturas.Rows.Count==0)
            {
                MessageBox.Show("No existen datos para el reporte","Reporte histórico de ahorro",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("idMoneda", idMoneda.ToString(), false));
            paramlist.Add(new ReportParameter("idProducto", idProduc, false));
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("dFecProc", dFecProceso.ToString(), false));
            paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarGlobal.cRutPathApp, false));
            paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("DsSaldoAhoHist", dtDatosAperturas));
            string reportpath = "RptSaldoAhoHis.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void CBTodo_CheckedChanged(object sender, EventArgs e)
        {
            cboProducto1.Enabled = !CBTodo.Checked;
            cboProducto1.SelectedIndex = -1;
            cboProducto2.Enabled = !CBTodo.Checked;
            cboProducto2.SelectedIndex = -1;
            cboProducto3.Enabled = !CBTodo.Checked;
            cboProducto3.SelectedIndex = -1;
            cboProducto4.Enabled = !CBTodo.Checked;
            cboProducto4.SelectedIndex = -1;
        }

        private void cboProducto1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto1.SelectedIndex > 0)
            {
                this.cboProducto2.CargarProducto(Convert.ToInt32(cboProducto1.SelectedValue));
                this.cboProducto2.SelectedIndex = 1;
            }
            else
            {
                this.cboProducto2.CargarProducto(-1);
            }
        }

        private void cboProducto2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto2.SelectedIndex > 0)
            {
                this.cboProducto3.CargarProducto(Convert.ToInt32(cboProducto2.SelectedValue));
                this.cboProducto3.SelectedIndex = 1;
            }
            else
            {
                this.cboProducto3.CargarProducto(-1);
            }
        }

        private void cboProducto3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto3.SelectedIndex > 0)
            {
                this.cboProducto4.ProductosYTodos(Convert.ToInt32(cboProducto3.SelectedValue));
                this.cboProducto4.SelectedIndex = 1;
            }
            else
            {
                this.cboProducto3.CargarProducto(-1);
            }
        }

        private void btnImprimir2_Click(object sender, EventArgs e)
        {
            if (cboAgencia1.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione la Agencia", "Reporte histórico de ahorro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboMoneda1.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione la moneda", "Reporte histórico de ahorro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DateTime dFecProceso = dtFecProceso.Value;
            int idAgencia = Convert.ToInt32(cboAgencia1.SelectedValue);
            int idMoneda = Convert.ToInt32(cboMoneda1.SelectedValue);
            string cNomAgen = clsVarGlobal.cNomAge;
            string idProduc = "";
            string Produc = "";

            if (CBTodo.Checked == true)
            {
                idProduc = "0";
                Produc = "TODOS";
            }
            else if (CBTodo.Checked == false)
            {
                if (Convert.ToString(cboProducto4.SelectedValue) == "0")
                {
                    int i = 1;
                    foreach (DataRowView item in cboProducto4.Items)
                    {
                        if (i < cboProducto4.Items.Count && i > 1)
                            idProduc += item[0] + ",";

                        i++;
                    }
                    idProduc = idProduc.Remove((idProduc.Length - 1), 1);
                    Produc = "TODOS LOS SUBPRODUCTOS DE " + Convert.ToString(cboProducto3.Text);
                }

                else if (Convert.ToString(cboProducto4.SelectedValue) != "0")
                {
                    idProduc = Convert.ToString(cboProducto4.SelectedValue);
                    Produc = Convert.ToString(cboProducto4.Text);
                }
            }
            if (cboProducto4.Text.Trim() == "" & CBTodo.Checked == false)
            {
                MessageBox.Show("Seleccione el tipo de producto", "Reporte histórico de ahorro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtDatosAperturas = new clsRPTCNDeposito().CNDetSaldoAHo(idMoneda, idProduc, idAgencia, dFecProceso);

            if (dtDatosAperturas.Rows.Count==0)
            {
                MessageBox.Show("No existen datos para el reporte","Reporte histórico de ahorro",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("idMoneda", idMoneda.ToString(), false));
            paramlist.Add(new ReportParameter("idProducto", idProduc, false));
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("dFecProc", dFecProceso.ToString(), false));
            paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarGlobal.cRutPathApp, false));
            paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();
            dtslist.Add(new ReportDataSource("DsDetSaldoAhoHist", dtDatosAperturas));
            string reportpath = "RptDetSaldoAhoHis.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

    }
}
