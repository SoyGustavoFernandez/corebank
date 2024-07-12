using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using DEP.CapaNegocio;
using EntityLayer;

namespace DEP.Presentacion
{
    public partial class frmEntregaProducto : frmBase
    {
        int idcuenta = 0;
        clsCNDeposito clsCNDep = new clsCNDeposito();
        public frmEntregaProducto()
        {
            InitializeComponent();
            this.conBusCuentaCli1.cTipoBusqueda = "D";
            this.conBusCuentaCli1.cEstado = "[1]";
        }

        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(conBusCuentaCli1.txtNroBusqueda.Text))
            {
                idcuenta = 0;
            }
            else
            {
                idcuenta = Convert.ToInt32(this.conBusCuentaCli1.txtNroBusqueda.Text);
                if (idcuenta != 0)
                {
                    clsCNDep.CNUpdUsoCuenta(idcuenta, clsVarGlobal.User.idUsuario);
                    ConsultaDatos(idcuenta);
                }
            }
          
        }
        private void ConsultaDatos(int idCta)
        {
            DataTable dtDatCta = clsCNDep.CNConsultaDatosAbono(idCta,"O");
            int idagencia = 0;
            int idproducto = 0;
            this.txtMontoDeposito.Text = dtDatCta.Rows[0]["nMontoDeposito"].ToString();
            this.txtAgencia.Text = dtDatCta.Rows[0]["cNombreAge"].ToString();
            this.txtProducto.Text = dtDatCta.Rows[0]["cProducto"].ToString();
            idagencia = Convert.ToInt32(dtDatCta.Rows[0]["idAgencia"]);
            idproducto = Convert.ToInt32(dtDatCta.Rows[0]["idProducto"]);
            if (idagencia!=clsVarGlobal.nIdAgencia)
            {
                MessageBox.Show("Cuenta no pertenece a esta agencia", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar();
                return;
            }
            if (idproducto!=17)//solo canasta navidenia
            {
                MessageBox.Show("Producto no pertenece a la promocion", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar();
                return;
            }
            if (Convert.ToDecimal(this.txtMontoDeposito.Text) < 100)//No cumple con el deposito
            {
                MessageBox.Show("El cliente no cumple con el monto minimo de deposito", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar();
                return;
            }
            this.btnGrabar.Enabled = true;
        }

        private void limpiar()
        {
            clsCNDep.CNUpdNoUsoCuenta(idcuenta);
            this.conBusCuentaCli1.txtEstado.Text = "";
            this.conBusCuentaCli1.txtNombreCli.Text = "";
            this.conBusCuentaCli1.txtNroBusqueda.Text = "";
            this.txtAgencia.Text = "";
            this.txtMontoDeposito.Text = "";
            this.txtProducto.Text = "";
            this.btnGrabar.Enabled = false;
        }

        private void conBusCuentaCli1_MyKey(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(conBusCuentaCli1.txtNroBusqueda.Text))
            {
                idcuenta = 0;
            }
            else
            {
                idcuenta = Convert.ToInt32(this.conBusCuentaCli1.txtNroBusqueda.Text);
                if (idcuenta != 0)
                {
                    clsCNDep.CNUpdUsoCuenta(idcuenta, clsVarGlobal.User.idUsuario);
                    ConsultaDatos(idcuenta);
                }
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DataTable dtInserta = clsCNDep.CNEntregaProducto(idcuenta);
            if (Convert.ToInt16(dtInserta.Rows[0]["nResultado"])==0)
            {
                MessageBox.Show(dtInserta.Rows[0]["cResultado"].ToString(), "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar();
                return;
            }
            else
            {
                MessageBox.Show("Operacion grabada correctamente", "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (Convert.ToDecimal(dtInserta.Rows[0]["nExceso"])>0)
            {
                MessageBox.Show("Cliente posteriormente puede reitrar " + dtInserta.Rows[0]["nExceso"].ToString(), "Grabar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            limpiar();
        }
    }
}
