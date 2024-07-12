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
using EntityLayer;
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmMantTipoMedJud : frmBase
    {
        #region Variables Globales

        Transaccion cEvento = Transaccion.Nuevo;
        clsCNProcJud procesojudicial = new clsCNProcJud();

        #endregion


        public frmMantTipoMedJud()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            cargarTipoMedJud();
        }

        private void cargarTipoMedJud()
        {
            if (this.cboTipMedJud1.Items.Count > 0)
            {
                var estado = (DataRowView)cboTipMedJud1.SelectedItem;
                txtDescripcion.Text = estado["cTipoMedJud"].ToString();
                if (Convert.ToBoolean(estado["lVigente"]) == false)
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
            bool lVal = false;
            if (this.txtDescripcion.Text.Trim() == "")
            {
                MessageBox.Show("Debe de ingresar ddescripción del estado", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return lVal;
            }

            if (!rbtActivo.Checked && !rbtnInactivo.Checked)
            {
                MessageBox.Show("Debe seleccionar un estado", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rbtActivo.Focus();
                return lVal;
            }

            if (this.cboTipMedJud1.Items.Count > 0 && cEvento == Transaccion.Nuevo)
            {
                var dtRegistros = (DataTable)cboTipMedJud1.DataSource;

                int nExiste = dtRegistros.AsEnumerable().Where(x => x["cTipoMedJud"].ToString() == this.txtDescripcion.Text.Trim()).Count();

                if (nExiste > 0)
                {
                    MessageBox.Show("Ya existe un registro con la descripción ingresada", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDescripcion.Focus();
                    return lVal;
                }
            }

            lVal = true;
            return lVal;
        }

        private void limpiarControles()
        {
            txtDescripcion.Text = "";
            rbtnInactivo.Checked = false;
            rbtActivo.Checked = false;
        }

        private void habilitarControles(bool estado)
        {
            txtDescripcion.Enabled = estado;
            rbtActivo.Enabled = estado;
            rbtnInactivo.Enabled = estado;
            this.cboTipMedJud1.Enabled = !estado;
        }


        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            cEvento = Transaccion.Nuevo;
            btnEditar1.Enabled = false;
            btnNuevo1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            limpiarControles();
            habilitarControles(true);
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (this.cboTipMedJud1.Items.Count == 0)
            {
                MessageBox.Show("No existe registros por editar", "Validación de registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cEvento = Transaccion.Edita;
            btnEditar1.Enabled = false;
            btnNuevo1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            habilitarControles(true);

            activarControlObjetos(this, EventoFormulario.EDITAR);
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            btnEditar1.Enabled = true;
            btnNuevo1.Enabled = true;
            btnCancelar1.Enabled = false;
            btnGrabar1.Enabled = false;
            cargarTipoMedJud();
            habilitarControles(false);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!validar())
                return;

            string cmensaje = "";
            if (cEvento == Transaccion.Nuevo)
            {
                procesojudicial.InsertarTipoMedJud(txtDescripcion.Text.Trim(), rbtActivo.Checked);
                cmensaje = "Se registro correctamente los datos ingresado";
            }
            else
            {
                procesojudicial.ActualizarTipoMedJud(Convert.ToInt32(this.cboTipMedJud1.SelectedValue), txtDescripcion.Text.Trim(), rbtActivo.Checked);
                cmensaje = "Se actualizaron correctamente los datos ingresados";
            }

            MessageBox.Show(cmensaje, "Registro de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnEditar1.Enabled = true;
            btnNuevo1.Enabled = true;
            btnCancelar1.Enabled = false;
            btnGrabar1.Enabled = false;
            this.cboTipMedJud1.cargarDatos();
            cargarTipoMedJud();
            habilitarControles(false);
        }

        private void cboTipMedJud1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarTipoMedJud();
        }
    }
}
