using DEP.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
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
    public partial class frmMantenimientoCuentasEspeciales : frmBase
    {
        clsCNDeposito clsDeposito = new clsCNDeposito();

        #region Variables Globales
        int idMCtaEsp = 0; // 0: Nuevo, Otros:Editar
        #endregion

        #region Metodos
        public frmMantenimientoCuentasEspeciales()
        {
            InitializeComponent();
        }

        private void DatosCuenta(int idCta)
        {
            DataTable dtbNumCuentas = clsDeposito.CNRetornaDatosCuenta(idCta, "1", 12);

            if (dtbNumCuentas.Rows.Count > 0)
            {
                txtProducto.Text = dtbNumCuentas.Rows[0]["cProducto"].ToString();
                cboMoneda.SelectedValue = Convert.ToInt16(dtbNumCuentas.Rows[0]["idMoneda"].ToString());
                txtMonto.Text = dtbNumCuentas.Rows[0]["nMontoDeposito"].ToString();

                int idCuenta = Convert.ToInt32(dtbNumCuentas.Rows[0]["idCuenta"]);
                idMCtaEsp = 0;

                DataTable dtRegCtaEspecial = new clsCNDeposito().CNObtenerManCtasEspeciales(idCuenta);

                if (dtRegCtaEspecial.Rows.Count != 0)
                {
                    idMCtaEsp = Convert.ToInt32(dtRegCtaEspecial.Rows[0]["idMCtaEsp"]);
                    txtMotivoRest.Text = Convert.ToString(dtRegCtaEspecial.Rows[0]["cMotivo"]);
                    bool bActivo = Convert.ToBoolean(dtRegCtaEspecial.Rows[0]["lVigente"]);

                    if (bActivo == true)
                    {
                        rbtActivo.Checked = true;
                        rbtInactivo.Checked = false;
                    }
                    else
                    {
                        rbtActivo.Checked = false;
                        rbtInactivo.Checked = true;
                    }
                }
                else
                {
                    if (MessageBox.Show(this, "¿Desea registrar la cuenta como cuenta especial?", "INFORMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        return;
                    }
                }

                HabilitarControles(true);
            }
        }

        private void limpiarcontroles()
        {

            conBusCtaAho.LimpiarControles();

            txtProducto.Text = "";
            cboMoneda.SelectedIndex = -1;
            txtMonto.Text = "0.00";
            txtMotivoRest.Text = "";
            rbtActivo.Checked = true;
            rbtInactivo.Checked = false;
        }

        private void HabilitarControles(bool Val)
        {
            conBusCtaAho.HabDeshabilitarCtrl(!Val);
            conBusCtaAho.btnBusCliente.Enabled = !Val;

            txtMotivoRest.Enabled = Val;
            rbtActivo.Enabled = Val;
            rbtInactivo.Enabled = Val;

            btnGrabar.Enabled = Val;
        }
        #endregion

        #region Eventos
        private void frmMantenimientoCuentasEspeciales_Load(object sender, EventArgs e)
        {
            conBusCtaAho.nTipOpe = 12;
            conBusCtaAho.idMoneda = 0;    
            
            cboMoneda.SelectedIndex = -1;
            HabilitarControles(false);
            conBusCtaAho.idcuenta = 0;
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            conBusCtaAho.txtCodAge.Focus();
        }

        private void conBusCtaAho_ClicBusCta(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(conBusCtaAho.txtNombre.Text))
            {
                DatosCuenta(Convert.ToInt32(conBusCtaAho.idcuenta));
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text))
            {
                MessageBox.Show("Debe Seleccionar primero la Cuenta y/o Cliente", "Validación de Mantenimiento de Cuentas Especiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(conBusCtaAho.txtNombre.Text))
            {
                MessageBox.Show("No Existe cliente para la búsqueda", "Validación de Mantenimiento de Cuentas Especiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Convert.ToInt32(conBusCtaAho.txtNroCta.Text.Trim()) == 0)
            {
                MessageBox.Show("El valor de búsqueda no puede ser igual a cero(0)", "Validación de Mantenimiento de Cuentas Especiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtMotivoRest.Text.Trim() == "")
            {
                MessageBox.Show("Debe especificar un motivo de reestricción", "Validación de Mantenimiento de Cuentas Especiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMotivoRest.Focus();
                return;
            }
            if (rbtActivo.Checked == false && rbtInactivo.Checked == false)
            {
                MessageBox.Show("Debe seleccionar entre Activo e Inactivo", "Validación de Mantenimiento de Cuentas Especiales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                return;
            }

            btnGrabar.Enabled = false;

            txtMotivoRest.Enabled = false;
            rbtActivo.Enabled = false;
            rbtInactivo.Enabled = false;

            int idCuenta = conBusCtaAho.idcuenta;
            int idCliente = Convert.ToInt32(conBusCtaAho.txtCodCli.Text);
            string cMotivo = txtMotivoRest.Text.Trim();
            bool bActivo = rbtActivo.Checked;
            int idUsuario = clsVarGlobal.User.idUsuario;
            int idAgencia = clsVarGlobal.nIdAgencia;

            DataTable dtRegCtaEspecial = null;
            if (idMCtaEsp == 0)
            {
                dtRegCtaEspecial = new clsCNDeposito().CNRegistraManCtasEspeciales(idCuenta, idCliente, cMotivo, idUsuario, idAgencia, bActivo);    
            }
            else
	        {
                dtRegCtaEspecial = new clsCNDeposito().CNActualizarManCtasEspeciales(idMCtaEsp, idCuenta, idCliente, cMotivo, idUsuario, idAgencia, bActivo);    
	        }            

            if (Convert.ToInt32(dtRegCtaEspecial.Rows[0][0]) == 0)
            {
                MessageBox.Show("Error al registrar", "Mantenimiento de Cuentas Especiales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {                
                MessageBox.Show("Registro completado", "Mantenimiento de Cuentas Especiales", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            idMCtaEsp = 0;

            conBusCtaAho.LimpiarControles();
            limpiarcontroles();
            HabilitarControles(false);
        }
        #endregion
    }
}
