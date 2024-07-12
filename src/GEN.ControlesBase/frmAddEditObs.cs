using System;
using System.Data;
using System.Windows.Forms;
using EntityLayer;

namespace GEN.ControlesBase
{
    public partial class frmAddEditObs : frmBase
    {

        #region Variables Globales
        public int idOrigenObs = 0;
        public clsObservacion objObservacion = null;
        public bool lAceptado = false;
        private const string cTituloMsjes = "Validación de campos.";

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            cboGrupoObs.CargarTodos();
            if (objObservacion != null)
            {
                cboTipObs.SelectedValue = objObservacion.idTipObs;
                txtDetObservacion.Text = objObservacion.cObservacion;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            objObservacion.idTipObs = Convert.ToInt32(cboTipObs.SelectedValue);
            objObservacion.cTipObs = cboTipObs.Text;
            objObservacion.cObservacion = txtDetObservacion.Text;
            objObservacion.idUsuario = clsVarGlobal.User.idUsuario;
            objObservacion.dFecha = clsVarGlobal.dFecSystem.Date;

            lAceptado = true;

            this.Dispose();
        }

        private void cboGrupoObs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGrupoObs.SelectedValue != null)
            {
                DataRowView dr = cboGrupoObs.SelectedItem as DataRowView;
                int idGrupoObs = Convert.ToInt32(dr["idGrupoObs"]);
                cboTipObs.LisTipObs(idOrigenObs, idGrupoObs, 0);
            }
        }

        #endregion

        #region Metodos

        public frmAddEditObs()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            if (cboTipObs.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de observación.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtDetObservacion.Text.Trim()))
            {
                MessageBox.Show("Ingrese el detalle de la observación.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion

    }
}
