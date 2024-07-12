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
using GEN.CapaNegocio;
using RPT.Presentacion;
using Microsoft.Reporting.WinForms;
using DEP.CapaNegocio;
using GEN.Funciones;
using EntityLayer;
using System.Collections;
using RPT.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmDepositosXProd : frmBase
    {
        private String Producto = "";
        private String Moneda = "";
        private String Estado = "";
        private String TipPersona = "";
        private String Caracteristica = "";
        private String Agencia = "";
        private DataTable dtDepositos;        
        private String AgenEmision= clsVarApl.dicVarGen["cNomAge"];

        public frmDepositosXProd()
        {
            InitializeComponent();
        }

        private void frmDepositosXProd_Load(object sender, EventArgs e)
        {
            cboMoneda1.MonedasYTodos();
            cboCaracteristicaCta1.CaractCtaYTodos();
            cboTipoPersona1.TipospersonaYTodos();
            cboEstadoCtaDeposito1.EstadoCtaYTodos();
            cboAgencias1.AgenciasYTodos();
            this.cboProducto1.CargarProducto(46);            
            Limpiar();
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


        private string validaciones() {
            if (CBTodo.Checked == false)
            {
                if (cboProducto4.Text.Trim() == "" || cboProducto3.Text.Trim() == "" || cboProducto2.Text.Trim() == "" || cboProducto1.Text.Trim() == "")
                {
                    MessageBox.Show("Seleccione el Producto", "Depositos por Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return "ERROR";
                }
                if (cboMoneda1.Text == "")
                {
                    MessageBox.Show("Seleccione el Tipo de Moneda", "Depositos por Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return "ERROR";
                }
                if (cboAgencias1.SelectedIndex == -1 || cboAgencias1.Text == "")
                {
                    MessageBox.Show("Seleccione la Agencia", "Depositos por Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return "ERROR";
                }
                if (cboEstadoCtaDeposito1.Text == "")
                {
                    MessageBox.Show("Seleccione el Estado de la Cuenta", "Depositos por Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return "ERROR";
                }
                if (cboTipoPersona1.Text == "")
                {
                    MessageBox.Show("Seleccione el Tipo de Persona", "Depositos por Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return "ERROR";
                }
                if (cboCaracteristicaCta1.Text == "")
                {
                    MessageBox.Show("Seleccione Característica", "Depositos por Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return "ERROR";
                }
            }
            return "OK";        
        }

        private void Limpiar() 
        {
            
            this.cboProducto1.SelectedIndex = -1;
            this.cboProducto2.SelectedIndex = -1;
            this.cboProducto3.SelectedIndex = -1;
            this.cboProducto4.SelectedIndex = -1;
            this.cboMoneda1.SelectedIndex = -1;
            this.cboAgencias1.SelectedIndex = -1;
            this.cboEstadoCtaDeposito1.SelectedIndex = -1;  
            this.cboTipoPersona1.SelectedIndex = -1;                      
            this.cboCaracteristicaCta1.SelectedIndex = -1;
            this.CBTodo.Checked = false;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {                    
            if (validaciones() == "ERROR") {
                return;
            }  
    
            //-----------------------------
            int x_idProducto = 0,
                x_idMoneda = 0,
                x_idEstado = 0,
                x_idTipPersona = 0,
                x_idCaracteristica = 0,
                x_idAgencia = 0;

            if (CBTodo.Checked == true)
            {
                x_idProducto = 0;
                x_idMoneda = 0;
                x_idEstado = 0;
                x_idTipPersona = 0;
                x_idCaracteristica = 0;
                x_idAgencia = 0;
            }
            else
            {
                x_idProducto = Convert.ToInt32(cboProducto4.SelectedValue);
                x_idMoneda = Convert.ToInt32(cboMoneda1.SelectedValue);
                x_idEstado = Convert.ToInt32(cboEstadoCtaDeposito1.SelectedValue);
                x_idTipPersona = Convert.ToInt32(cboTipoPersona1.SelectedValue);
                x_idCaracteristica = Convert.ToInt32(cboCaracteristicaCta1.SelectedValue);
                x_idAgencia = Convert.ToInt32(cboAgencias1.SelectedValue);
            }
            //-------------------------------

            String idProducto = "";
            String idMoneda = "";
            String idEstado = "";
            String idTipPersona = "";
            String idCaracteristica = "";
            String idAgencia = "";


            if (CBTodo.Checked == false)
            {
                Moneda = Convert.ToString(cboMoneda1.Text);
                Estado = Convert.ToString(cboEstadoCtaDeposito1.Text);
                TipPersona = Convert.ToString(cboTipoPersona1.Text);
                Caracteristica = Convert.ToString(cboCaracteristicaCta1.Text);
                Agencia = Convert.ToString(cboAgencias1.Text);
            }
            //Obtener idProducto//
            if (CBTodo.Checked == true)
            {
                idProducto = "0";
                Producto = "TODOS";
                Moneda = "TODOS";
                Estado = "TODOS";
                TipPersona = "TODOS";
                Caracteristica = "TODOS";
                Agencia = "TODOS";

            }
            else if (CBTodo.Checked == false)
            {
                if (Convert.ToString(cboProducto4.SelectedValue) == "0")
                {
                    int i = 1;
                    foreach (DataRowView item in cboProducto4.Items)
                    {
                        if (i < cboProducto4.Items.Count && i > 1)
                            idProducto += item[0] + ",";
                        i++;
                    }
                    idProducto = idProducto.Remove((idProducto.Length - 1), 1);

                    Producto = "TODOS LOS SUBPRODUCTOS DE " + Convert.ToString(cboProducto3.Text);
                }

                else if (Convert.ToString(cboProducto4.SelectedValue) != "0")
                {
                    idProducto = Convert.ToString(cboProducto4.SelectedValue);
                    Producto = Convert.ToString(cboProducto4.Text);
                }
            }                     
 
            //Cargar Datos para el reporte
            clsCNDepositosXProd DepositosProd = new clsCNDepositosXProd();
            dtDepositos = DepositosProd.ListarDepXProd(idProducto, x_idMoneda, x_idAgencia, x_idEstado, x_idTipPersona, x_idCaracteristica);
            
            if (dtDepositos.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte", "Depositos por Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("x_cProducto", Producto, false));
                paramlist.Add(new ReportParameter("x_cMoneda", Moneda, false));
                paramlist.Add(new ReportParameter("x_Agencias", Agencia, false));
                paramlist.Add(new ReportParameter("x_cEstado", Estado, false));
                paramlist.Add(new ReportParameter("x_cTipPersona", TipPersona, false));
                paramlist.Add(new ReportParameter("x_cCaracteristica", Caracteristica, false));
                paramlist.Add(new ReportParameter("x_cNombEmpresa", cNomEmp, false));                
                paramlist.Add(new ReportParameter("x_AgenEmision", AgenEmision, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", clsVarGlobal.dFecSystem.Date.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("x_cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString(), false));                

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsDepositosXProductos", dtDepositos));                

                string reportpath = "rptDepositosXProd.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            } 
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void CBTodo_CheckedChanged(object sender, EventArgs e)
        {
            cboProducto1.Enabled =! CBTodo.Checked;
            cboProducto1.SelectedIndex = -1;
            cboProducto2.Enabled =! CBTodo.Checked;
            cboProducto2.SelectedIndex = -1;
            cboProducto3.Enabled =! CBTodo.Checked;
            cboProducto3.SelectedIndex = -1;
            cboProducto4.Enabled =! CBTodo.Checked;
            cboProducto4.SelectedIndex = -1;
            cboMoneda1.Enabled =! CBTodo.Checked;
            cboMoneda1.SelectedIndex = -1;
            cboEstadoCtaDeposito1.Enabled = !CBTodo.Checked;
            cboEstadoCtaDeposito1.SelectedIndex = -1;
            cboTipoPersona1.Enabled =!CBTodo.Checked;
            cboTipoPersona1.SelectedIndex = -1;
            cboCaracteristicaCta1.Enabled =!CBTodo.Checked;
            cboCaracteristicaCta1.SelectedIndex = -1;
            cboAgencias1.Enabled =!CBTodo.Checked;
            cboAgencias1.SelectedIndex = -1;
        }
    }
}
