using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GRH.CapaNegocio;

namespace GRH.Presentacion
{
    public partial class frmMantenimientoCategoria : frmBase
    {
        #region Variable Globales

        clsCNMantCargos cncategoria = new clsCNMantCargos();
        Transaccion operacion = Transaccion.Selecciona;

        #endregion

        public frmMantenimientoCategoria()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            cboArea1.CargarTodasArea();
            habilitarcontroles(false);
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            if (cboCargoPersonalcs1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe de seleccionar un cargo válido", "Validación de cargos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            operacion = Transaccion.Nuevo;
            btnEditar1.Enabled = false;
            btnNuevo1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            limpiarcontroles();
            habilitarcontroles(true);
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (this.cboCategoriaPersonal1.Items.Count == 0)
            {
                MessageBox.Show("No existe registros por editar", "Validación de registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            operacion = Transaccion.Edita;
            btnEditar1.Enabled = false;
            btnNuevo1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            habilitarcontroles(true);

            activarControlObjetos(this, EventoFormulario.EDITAR);
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            btnEditar1.Enabled = true;
            btnNuevo1.Enabled = true;
            btnCancelar1.Enabled = false;
            btnGrabar1.Enabled = false;
            cargarCategoria();
            habilitarcontroles(false);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                string cmensaje = "";
                if (operacion == Transaccion.Nuevo)
                {

                    this.cncategoria.CNInsertarCategoriaPersonal(txtDescripcion.Text.Trim(), (int)cboCargoPersonalcs1.SelectedValue, rbtActivo.Checked);

                    cmensaje = "Se registró correctamente los datos ingresado";
                }
                else
                {
                    cncategoria.CNActualizarCategoriaPersonal(Convert.ToInt32(this.cboCategoriaPersonal1.SelectedValue), txtDescripcion.Text.Trim(), (int)cboCargoPersonalcs1.SelectedValue, rbtActivo.Checked);
                    cmensaje = "Se actualizaron correctamente los datos ingresados";
                }

                MessageBox.Show(cmensaje, "Registro Categoría", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnEditar1.Enabled = true;
                btnNuevo1.Enabled = true;
                btnCancelar1.Enabled = false;
                btnGrabar1.Enabled = false;

                habilitarcontroles(false);
            }
        }

        private void cboCargoPersonalcs1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCargoPersonalcs1.SelectedIndex > -1)
            {
                if (cboCargoPersonalcs1.SelectedValue is DataRowView) return;
                cboCategoriaPersonal1.cargarCategoria((int)cboCargoPersonalcs1.SelectedValue);
            }
        }

        private void cboCategoriaPersonal1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategoriaPersonal1.SelectedIndex > -1)
            {
                cargarCategoria();
            }
        }

        private void cboArea1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboArea1.SelectedIndex > -1)
            {
                if (cboArea1.SelectedValue is DataRowView) return;
                cboCargoPersonalcs1.CargarCargo((int)cboArea1.SelectedValue);
            }
        }

        #endregion

        #region Métodos

        private void cargarCategoria()
        {
            if (this.cboCategoriaPersonal1.Items.Count > 0)
            {
                var contacto = (DataRowView)cboCategoriaPersonal1.SelectedItem;

                txtDescripcion.Text = contacto["cCategoria"].ToString();
                if (Convert.ToBoolean(contacto["lVigente"]) == false)
                {
                    rbtnInactivo.Checked = true;
                    rbtActivo.Checked = false;
                }
                else
                {
                    rbtnInactivo.Checked = false;
                    rbtActivo.Checked = true;
                }
            }
        }

        private bool validar()
        {
            bool lValida = false;

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese la descripción de la categoría por favor", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return lValida;
            }

            if (!rbtActivo.Checked && !rbtnInactivo.Checked)
            {
                MessageBox.Show("Seleccione el estado por favor", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValida;
            }

            lValida = true;
            return lValida;
        }

        private void limpiarcontroles()
        {
            txtDescripcion.Text = "";
            rbtnInactivo.Checked = false;
            rbtActivo.Checked = false;
        }

        private void habilitarcontroles(bool estado)
        {
            txtDescripcion.Enabled = estado;
            rbtActivo.Enabled = estado;
            rbtnInactivo.Enabled = estado;
            this.cboCategoriaPersonal1.Enabled = !estado;
            this.cboCargoPersonalcs1.Enabled = !estado;
            this.cboArea1.Enabled = !estado;
        }

        #endregion
    }
}
