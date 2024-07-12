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
    public partial class frmReporteExoneracionITF : frmBase
    {
        int idTipoOperacion = 0;

        public frmReporteExoneracionITF()
        {
            InitializeComponent();
        }

        private void frmReporteExoneracionITF_Load(object sender, EventArgs e)
        {
            this.cboProducto1.CargarProducto(46);
            CBTodo.Checked = true;
            dtFecInicio.Value = clsVarGlobal.dFecSystem.Date;
            dtFecFin.Value = clsVarGlobal.dFecSystem.Date; 
            cboAgencia1.SelectedIndex = -1;
            RBFecha.Checked = true;
            dtFecFin.Enabled = false;
            dtFecInicio.Enabled = false;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            dtFecInicio.Value = clsVarGlobal.dFecSystem.Date;
            dtFecFin.Value = clsVarGlobal.dFecSystem.Date; 
            cboAgencia1.SelectedIndex = -1;
            RBFecha.Checked=true;
        }

        private void RBPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            dtFecFin.Enabled = RBPeriodo.Checked;
            dtFecInicio.Enabled = RBPeriodo.Checked;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            //VALIDACIONES
            if (Convert.ToDateTime(dtFecFin.Value.ToShortDateString()) < Convert.ToDateTime(dtFecInicio.Value.ToShortDateString()))
            {
                MessageBox.Show("Periodo Incorrecto: La fecha de Inicio es posterior a la Final", "Reporte de Exoneración de ITF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboAgencia1.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione la Agencia", "Reporte de Exoneración de ITF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string TipoBusqueda = ""; // Convert.ToString(Convert.ToInt32(RBPeriodo.Checked));

            if (RBPeriodo.Checked)
            {
                TipoBusqueda = "1";
            }
            else
            {
                TipoBusqueda = "0";
            }

            DateTime dFecInicio = dtFecInicio.Value;
            DateTime dFecFin = dtFecFin.Value;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];
            string cAgenciaExtornos = cboAgencia1.Text;
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

            if (rbtExoItf.Checked)
            {
                idTipoOperacion = 49;
            }
            if (rbtAfeITF.Checked)
            {
                idTipoOperacion = 53;
            }


            DataTable dtDatosExoneracion = new clsRPTCNDeposito().CNExoneracionITF(idProduc, TipoBusqueda, dFecInicio, dFecFin, Convert.ToInt32(cboAgencia1.SelectedValue),idTipoOperacion);


            if (dtDatosExoneracion.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte para dicho intervalo de Fechas", "Reporte de Exoneración de ITF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_TipBusqueda", TipoBusqueda, false));
                paramlist.Add(new ReportParameter("x_dFechaINI", dFecInicio.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_dFechaFIN", dFecFin.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cAgencia", cAgenciaExtornos, false));
                paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmp, false));
                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_cProducto", Produc, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString()));
                paramlist.Add(new ReportParameter("idTipoOper", idTipoOperacion.ToString(), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsDatosExoneracionITF", dtDatosExoneracion));                

                string reportpath = "rptExoneracionITF.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

            }
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

        private void grbBase2_Enter(object sender, EventArgs e)
        {
            
        }
     
        private void rbtExoItf_CheckedChanged(object sender, EventArgs e)
        {   
            if (rbtExoItf.Checked)
            {
                idTipoOperacion = 49;
            }
        }

        private void rbtAfeITF_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtAfeITF.Checked)
            {
                idTipoOperacion = 53;
            }
        }
    }
}
