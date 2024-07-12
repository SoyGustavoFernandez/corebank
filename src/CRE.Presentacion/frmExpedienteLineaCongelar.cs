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
using GEN.Servicio;

namespace CRE.Presentacion
{
    public partial class frmExpedienteLineaCongelar : frmBase
    {
        #region Variables
        private clsExpedienteLinea clsExpediente = new clsExpedienteLinea();
        #endregion
        #region Metodos
        public frmExpedienteLineaCongelar()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void frmExpedienteLineaCongelar_Load(object sender, EventArgs e)
        {
            cargarGrupoExpediente();
        }

        private void txtSolicitud_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                string cTipoSolicitud = "individual";
                if (!rbtIndividual.Checked)
                {
                    cTipoSolicitud = "grupal";
                }

                int idSolicitud = Convert.ToInt32(txtSolicitud.Text);
                this.cboGrupoExpediente1.cboCargarGrupoExpedientes(idSolicitud, cTipoSolicitud);
                cboGrupoExpediente1.SelectedIndex = -1;

                DataTable dtDatosSol = clsExpediente.getDatosSolicitud(Convert.ToInt32(txtSolicitud.Text), cTipoSolicitud);
                if (dtDatosSol.Rows.Count > 0)
                {
                    txtFechaSolicitud.Text = dtDatosSol.Rows[0]["dFechaRegistro"].ToString();
                    txtOperacion.Text = dtDatosSol.Rows[0]["cOperacion"].ToString();
                    txtProducto.Text = dtDatosSol.Rows[0]["Producto"].ToString();
                    txtAsesor.Text = dtDatosSol.Rows[0]["cNombre"].ToString();
                    txtTipoCliente.Text = dtDatosSol.Rows[0]["cTipoCli"].ToString();
                }
                else{
                    limpiarCampos();
                    MessageBox.Show("No se ha encontrado datos para dicha Solicitud", "Guardado de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void rbtIndividual_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrupoExpediente();
        }

        private void rbtGrupal_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrupoExpediente();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (txtSolicitud.Text == "")
            {
                MessageBox.Show("Debe ingresar una Solicitud válida", "Guardado de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.cboGrupoExpediente1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el Grupo de Expediente", "Guardado de Expedientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string cTipoSolicitud = "individual";
            if (!rbtIndividual.Checked)
            {
                cTipoSolicitud = "grupal";
            }
            clsExpediente.guardarCopiaExpediente(this.cboGrupoExpediente1.Text, Convert.ToInt32(txtSolicitud.Text), this, cTipoSolicitud);
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }
        #endregion

        #region Metodos
        private void cargarGrupoExpediente(){
            string cTipoSolicitud = "individual";
            if (!rbtIndividual.Checked)
            {
                cTipoSolicitud = "grupal";
            }
            int idSolicitud = 0;
            if (txtSolicitud.Text != "")
            {
                idSolicitud = Convert.ToInt32(txtSolicitud.Text);
            }
            this.cboGrupoExpediente1.cboCargarGrupoExpedientes(idSolicitud, cTipoSolicitud);
            this.cboGrupoExpediente1.SelectedIndex = -1;
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            txtSolicitud.Text = "";
            txtFechaSolicitud.Text = "";
            txtOperacion.Text = "";
            txtProducto.Text = "";
            txtAsesor.Text = "";
            txtTipoCliente.Text = "";

            cboGrupoExpediente1.SelectedIndex = -1;
            cboGrupoExpediente1.DataSource = null;
        }
        #endregion
    }
}
