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
using RCP.CapaNegocio;

namespace RCP.Presentacion
{
    public partial class frmMantEstadoSolRecupera : frmBase
    {
        #region Variables
        //N-->nuevo
        //E-->Editar
        string cEvento = "";

        clsCNEstadoSolRecupera contactorecu = new clsCNEstadoSolRecupera();

        #endregion

        public frmMantEstadoSolRecupera()
        {
            InitializeComponent();
        }

        #region Eventos

        private void Form1_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
            cargarEstadoSol();
        }

        private void cboEstadoSolRecupera1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarEstadoSol();
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
            if (this.cboEstadoSolRecupera1.Items.Count == 0)
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
            cargarEstadoSol();
            habilitarcontroles(false);
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            string cmensaje = "";
            if (cEvento == "N")
            {

                contactorecu.InsertarEstadoSolRecupera(txtDescripcion.Text.Trim(), rbtActivo.Checked);

                cmensaje = "Se registro correctamente los datos ingresado";
            }
            else
            {
                contactorecu.ActualizarEstadoSolRecupera(txtDescripcion.Text.Trim(), rbtActivo.Checked, Convert.ToInt32(cboEstadoSolRecupera1.SelectedValue));
                cmensaje = "Se actualizaron correctamente los datos ingresados";
            }

            MessageBox.Show(cmensaje, "Titulo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnEditar.Enabled = true;
            btnNuevo1.Enabled = true;
            btnCancelar1.Enabled = false;
            btnGrabar1.Enabled = false;
            this.cboEstadoSolRecupera1.Update();
            cargarEstadoSol();
            habilitarcontroles(false);
        }

        #endregion

        #region Metodos

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
            cboEstadoSolRecupera1.Enabled = !estado;
        }

        private void cargarEstadoSol()
        {
            if (this.cboEstadoSolRecupera1.Items.Count > 0)
            {
                var contacto = (DataRowView)cboEstadoSolRecupera1.SelectedItem;

                txtDescripcion.Text = contacto["cEstadoSolRec"].ToString();
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

        #endregion
    }
}
