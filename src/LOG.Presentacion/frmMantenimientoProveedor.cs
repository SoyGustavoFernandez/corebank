using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using LOG.CapaNegocio;

namespace LOG.Presentacion
{
    public partial class frmMantenimientoProveedor : frmBase
    {
        #region Variables
        clsCNProveedor objProveedor = new clsCNProveedor();

        #endregion

        #region Eventos

        private void frmMantenimientoProveedor_Load(object sender, EventArgs e)
        {
            IniForm();
        }

        private void conBusCliente_ClicBuscar(object sender, EventArgs e)
        {
            int idCli = conBusCliente.idCli;

            if (idCli == 0)
            {
                IniForm();
                return;
            }
            MostrarDatosProveedor(idCli);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IniForm();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            bool lResultado = false;
            if (!Validar())
                return;

            HabilitarControles("I");

            if (string.IsNullOrEmpty(txtIdProveedor.Text.Trim()))
            {
                lResultado = InsertarProveedor(conBusCliente.idCli, txtCtaDetraccion.Text, txtCuentaCorriente.Text);
            }
            else
            {
                lResultado = ActualizarProveedor(Convert.ToInt32(txtIdProveedor.Text), txtCtaDetraccion.Text, txtCuentaCorriente.Text);
            }

            if (lResultado)
            {
                MostrarDatosProveedor(conBusCliente.idCli);
                HabilitarControles("P");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de eliminar el proveedor?", "Mantenimiento de Proveedores", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (EliminarProveedor(Convert.ToInt32(txtIdProveedor.Text)))
                {
                    IniForm();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles("AN");
            txtCtaDetraccion.Focus();
        }

        #endregion

        #region Metodos

        public frmMantenimientoProveedor()
        {
            InitializeComponent();
        }     

        private void MostrarDatosProveedor(int idCli)
        {
            DataTable dtProveedor = objProveedor.CNMostrarDatosProveedorIdCli(idCli);

            if (dtProveedor.Rows.Count == 0)
            {
                DialogResult result = MessageBox.Show("Cliente no esta registrado como Proveedor, ¿Desea registrarlo?", "Mantenimiento de Proveedores", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    txtIdProveedor.Clear();
                    txtCtaDetraccion.Clear();
                    HabilitarControles("AN");
                    txtCtaDetraccion.Focus();
                }
                else
                {
                    IniForm();
                    return;
                }
            }
            else
            {
                txtIdProveedor.Text = dtProveedor.Rows[0]["idProveedor"].ToString();
                txtCtaDetraccion.Text = dtProveedor.Rows[0]["cCtaDetraccion"].ToString();
                txtCuentaCorriente.Text = dtProveedor.Rows[0]["cCuentaCorriente"].ToString();
                HabilitarControles("P");
            }
        }

        private void IniForm()
        {
            LimpiarControles();
            conBusCliente.limpiarControles();
            HabilitarControles("N");
            conBusCliente.txtCodCli.Focus();
        }

        private bool InsertarProveedor(int idCli, string cCtaDetraccion, string cCuentaCorriente)
        {
            DataTable dtResultado = objProveedor.CNInsertarProveedor(idCli, cCtaDetraccion, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, cCuentaCorriente);
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Proveedores", MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            return (Convert.ToInt32(dtResultado.Rows[0]["idError"]) == 0 ? true : false);
        }

        private bool ActualizarProveedor(int idProveedor, string cCtaDetraccion, string cCuentaCorriente)
        {
            DataTable dtResultado = objProveedor.CNActualizarProveedor(idProveedor, cCtaDetraccion, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, cCuentaCorriente);
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Proveedores", MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            return (Convert.ToInt32(dtResultado.Rows[0]["idError"]) == 0 ? true : false);
        }

        private bool EliminarProveedor(int idProveedor)
        {
            DataTable dtResultado = objProveedor.CNEliminarProveedor(idProveedor, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Mantenimiento de Proveedores", MessageBoxButtons.OK, ((int)dtResultado.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            return ((int)dtResultado.Rows[0]["idError"] == 0 ? true : false);
        }

        private bool Validar()
        {
            if (string.IsNullOrEmpty(conBusCliente.txtCodCli.Text.Trim()))
            {
                MessageBox.Show("Seleccione el cliente que desea registrar como proveedor.", "Mantenimiento de proveedores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //if (string.IsNullOrEmpty(txtCtaDetraccion.Text.Trim()))
            //{
            //    MessageBox.Show("Ingrese la cuenta de detracciones del proveedor.", "Mantenimiento de proveedores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            return true;
        }

        private void LimpiarControles()
        {
            txtIdProveedor.Clear();
            txtCtaDetraccion.Clear();
            txtCuentaCorriente.Clear();
        }

        private void HabilitarControles(string cTipAccion)
        {
            conBusCliente.txtCodCli.Enabled = false;
            conBusCliente.btnBusCliente.Enabled = false;
            txtCtaDetraccion.Enabled = false;
            txtCuentaCorriente.Enabled = false;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            if (cTipAccion == "N") //Click en Nuevo
            {
                conBusCliente.txtCodCli.Enabled = true;
                conBusCliente.btnBusCliente.Enabled = true;
            }
            else if (cTipAccion == "AN") //Aceptar Nuevo o click Editar
            {
                txtCtaDetraccion.Enabled = true;
                txtCuentaCorriente.Enabled = true;

                btnCancelar.Enabled = true;
                btnGrabar.Enabled = true;
            }
            else if (cTipAccion == "P") //Mostrar Proveedor o click en grabar
            {
                btnEliminar.Enabled = true;
                btnEditar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }

        #endregion       
    }
}
