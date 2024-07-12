using System;
using System.Windows.Forms;
using EntityLayer;
using GEN.BotonesBase;
using GEN.ControlesBase;
using GEN.CapaNegocio;


namespace CRE.Presentacion
{
    public partial class frmApruebaDeniegaSolCre : frmBase
    {
        #region Variables Globales

        private const string cTituloMsjes = "Aprobaciones y denegaciones de créditos";

        #endregion

        public frmApruebaDeniegaSolCre()
        {
            InitializeComponent();
        }

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            txtNumSolCre.Focus();
        }

        private void btnAprobarDenegar_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            int idSolicitud = Convert.ToInt32(txtNumSolCre.Text.Trim());
            int idEstado = Convert.ToInt32(((Boton)sender).Tag);
            clsDBResp objDbResp = new clsCNSolicitud().CNAprobacionesCapacitacion(idSolicitud, idEstado);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Metodos

        private bool Validar()
        {
            if (String.IsNullOrEmpty(txtNumSolCre.Text))
            {
                MessageBox.Show("Ingrese el número de solicitud de crédito.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void LimpiarCampos()
        {
            txtNumSolCre.Text = String.Empty;
        }

        #endregion

    }
}
