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
    public partial class frmReporteAhoLinea : frmBase
    {
        public frmReporteAhoLinea()
        {
            InitializeComponent();
        }


        private void frmReporteAhoLinea_Load(object sender, EventArgs e)
        {
            this.cboProducto1.CargarProducto(46);
            cboMoneda1.MonedasYTodos();
        }


        private void btnImprimir1_Click_1(object sender, EventArgs e)
        {
            if (cboMoneda1.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione la moneda", "Reporte de ahorro en linea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }           
            
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarGlobal.cNomAge;
            string dMoneda = cboMoneda1.Text;
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
                MessageBox.Show("Seleccione el tipo de producto", "Reporte de ahorro en linea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int idMoneda = Convert.ToInt32(cboMoneda1.SelectedValue);
            int idAgencia = Convert.ToInt32(cboAgencia1.SelectedValue);
            DataTable dtDatosAperturas = new clsRPTCNDeposito().CNSaldoLinea(idMoneda, idProduc, idAgencia);
            if (dtDatosAperturas.Rows.Count==0)
            {
                 MessageBox.Show("No existen datos para el reporte", "Reporte de ahorro en linea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("idMoneda", idMoneda.ToString(), false));
            paramlist.Add(new ReportParameter("idProducto", idProduc, false));
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarGlobal.cRutPathApp, false));
            paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                
            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("DsSaldoAhoLinea", dtDatosAperturas));
            

            string reportpath = "RptAhoLinea.rdlc";

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
            if (cboMoneda1.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione la moneda", "Reporte de ahorro en linea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarGlobal.cNomAge;
            string dMoneda = cboMoneda1.Text;
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
                MessageBox.Show("Seleccione el tipo de producto", "Reporte de ahorro en linea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int idMoneda = Convert.ToInt32(cboMoneda1.SelectedValue);
            int idAgencia = Convert.ToInt32(cboAgencia1.SelectedValue);
            DataTable dtDatosAperturas = new clsRPTCNDeposito().CNDetSaldoLinea(idMoneda, idProduc, idAgencia);
            if (dtDatosAperturas.Rows.Count==0)
            {
                MessageBox.Show("No existen datos para el reporte", "Reporte de ahorro en linea", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("idMoneda", idMoneda.ToString(), false));
            paramlist.Add(new ReportParameter("idProducto", idProduc, false));
            paramlist.Add(new ReportParameter("idAgencia", idAgencia.ToString(), false));
            paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarGlobal.cRutPathApp, false));
            paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("DsDetSaldoAhoLinea", dtDatosAperturas));


            string reportpath = "RptDetAhoLinea.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
    }
}

