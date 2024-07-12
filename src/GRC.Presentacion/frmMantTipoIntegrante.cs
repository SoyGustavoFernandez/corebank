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
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using GRC.CapaNegocio;

namespace GRC.Presentacion
{
    public partial class frmMantTipoIntegrante : frmBase
    {
        #region Variables
        //N-->nuevo
        //E-->Editar
        string cEvento = "";

        clsCNTipoIntegranteConsejo tipointegrante = new clsCNTipoIntegranteConsejo();

        #endregion

        public frmMantTipoIntegrante()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            cargarTipoIntegrante();
        }

        private void cboTipoIntegranteConsejo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarTipoIntegrante();
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            cEvento = "N";
            btnEditar.Enabled = false;
            btnNuevo1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            limpiarcontroles();
            habilitarcontroles(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.cboTipoIntegranteConsejo1.Items.Count == 0)
            {
                MessageBox.Show("No existe registros por editar", "Validación de registros", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cEvento = "E";
            btnEditar.Enabled = false;
            btnNuevo1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            habilitarcontroles(true);

            activarControlObjetos(this, EventoFormulario.EDITAR);
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnNuevo1.Enabled = true;
            btnCancelar1.Enabled = false;
            btnGrabar1.Enabled = false;
            cargarTipoIntegrante();
            habilitarcontroles(false);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                string cmensaje = "";
                if (cEvento == "N")
                {

                    tipointegrante.InsertarTipoIntegranteConsejo((int)cboTipoConsejo1.SelectedValue, txtDescripcion.Text.Trim(), rbtnSi.Checked, rbtActivo.Checked);

                    cmensaje = "Se registro correctamente los datos ingresado";
                }
                else
                {
                    tipointegrante.ActualizarTipoIntegranteConsejo((int)cboTipoConsejo1.SelectedValue, txtDescripcion.Text.Trim(), rbtnSi.Checked, rbtActivo.Checked, Convert.ToInt32(cboTipoIntegranteConsejo1.SelectedValue));
                    cmensaje = "Se actualizaron correctamente los datos ingresados";
                }

                MessageBox.Show(cmensaje, "Titulo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnEditar.Enabled = true;
                btnNuevo1.Enabled = true;
                btnCancelar1.Enabled = false;
                btnGrabar1.Enabled = false;
                cargarTipoIntegrante();
                habilitarcontroles(false);
            }
        }
        private void limpiarcontroles()
        {
            txtDescripcion.Text = "";
            rbtnInactivo.Checked = false;
            rbtActivo.Checked = false;
            rbtnSi.Checked = false;
            rbtnNo.Checked = false;
        }

        private void habilitarcontroles(bool estado)
        {
            txtDescripcion.Enabled = estado;
            rbtActivo.Enabled = estado;
            rbtnInactivo.Enabled = estado;
            rbtnSi.Enabled = estado;
            rbtnNo.Enabled = estado;
            cboTipoIntegranteConsejo1.Enabled = !estado;
            cboTipoConsejo1.Enabled = estado;
        }

        private void cargarTipoIntegrante()
        {
            if (this.cboTipoIntegranteConsejo1.Items.Count > 0)
            {
                var contacto = (DataRowView)cboTipoIntegranteConsejo1.SelectedItem;

                txtDescripcion.Text = contacto["cTipoIntegranteConsejo"].ToString();
                cboTipoConsejo1.SelectedValue = (int)contacto["idTipoConsejo"];
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

                if (Convert.ToBoolean(contacto["lDerechoVoto"]) == false)
                {
                    rbtnNo.Checked = true;
                    rbtnSi.Checked = false;
                }
                else
                {
                    rbtnNo.Checked = false;
                    rbtnSi.Checked = true;
                }
            }
        }

        private bool validar()
        {
            bool lVal = false;

            if (txtDescripcion.Text=="")
            {
                MessageBox.Show("Debe de ingresar una descripción válida", "Validación de Tipo de Integrante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return lVal;
            }

            if (!rbtnSi.Checked  && !rbtnNo.Checked)
            {
                MessageBox.Show("Debe seleccionar si tiene derecho a voto si o no", "Validación de Tipo de Integrante", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
                return lVal;
            }
            if (!rbtActivo.Checked && !rbtnInactivo.Checked)
            {
                MessageBox.Show("Debe seleccionar si es activo o inactivo", "Validación de Tipo de Integrante", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
                return lVal;
            }

            lVal = true;
            return lVal;
        }
    }
}
