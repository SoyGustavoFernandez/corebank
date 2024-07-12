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
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class FrmBusUsuComite : frmBase
    {

        #region Variables Globales

        public string cPerfilesBusq = "0";
        public clsUsuComite objUsuComite = null;
        public bool lUsuAutBiometrico = false;
        public bool lComiteVirtual = false;
        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            dtgColaborador.AutoGenerateColumns = false;
            lblCriterio.Text = "Ape. y Nombres:";
            cboTipoParticip.SelectedValue = 1;
            txtDniNom.Focus();
            txtDniNom.Select();

            if (lComiteVirtual)
            {
                cboTipoParticip.SelectedValue = 3;
                cboTipoParticip.Enabled = false;
            }
        }

        private void cboCriBusCol_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cCriBus;
            cCriBus = cboCriBusCol.SelectedValue.ToString();
            if (cCriBus == "1")
            {
                lblCriterio.Text = "DNI:";
            }
            else if (cCriBus == "2")
            {
                lblCriterio.Text = "Ape. y Nombres:";
            }
            txtDniNom.Focus();
        }

        private void txtDniNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnBusqueda.PerformClick();
            }
        }

        //private void dtgColaborador_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 13)
        //    {
        //        btnAceptar.PerformClick();
        //    }
        //}

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            string cCriBus, cDatoIngr;
            cCriBus = Convert.ToString(cboCriBusCol.SelectedValue);
            cDatoIngr = txtDniNom.Text.Trim();

            if (cboCriBusCol.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el criterio de búsqueda", "Busqueda de Colaborador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboCriBusCol.Focus();
                return;
            }

            if (cDatoIngr == "")
            {
                MessageBox.Show("Debe ingresar los datos a buscar", "Busqueda de Colaborador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDniNom.Focus();
                return;
            }

            clsCNUsuComite objCNUsuComite = new clsCNUsuComite();
            DataTable dtPer = objCNUsuComite.CNBusPersonalComite(cCriBus, cDatoIngr);
            dtgColaborador.DataSource = dtPer;

            if (dtgColaborador.RowCount == 0)
            {
                MessageBox.Show("No existen datos con el criterio de busqueda", "Busqueda de Colaborador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDniNom.Focus();
                return;
            }
            dtgColaborador.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void dtgColaborador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Aceptar();
            }
        }

        #endregion

        #region Metodos

        public FrmBusUsuComite()
        {
            InitializeComponent();
            this.cboCriBusCol.Focus();
        }

        public void Aceptar()
        {
            if (cboTipoParticip.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de participación del usuario.", "Busqueda de Colaborador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoParticip.Focus();
                return;
            }

            clsCNUsuComite objCNUsuComite = new clsCNUsuComite();

            DataTable dtVerificarRegionComite = objCNUsuComite.CNVerificarRegionComite(clsVarGlobal.nIdAgencia, Convert.ToInt32(dtgColaborador.SelectedRows[0].Cells["idUsuario"].Value));

            if (!lComiteVirtual)
            {
                if (Convert.ToInt32(dtVerificarRegionComite.Rows[0]["cRegion"]) == 0 && Convert.ToInt32(cboTipoParticip.SelectedValue) == 3 && Convert.ToInt32(dtVerificarRegionComite.Rows[0]["cCargo"]) == 1)
                {
                    MessageBox.Show("El participante virtual no pertenece a la Región.", "Búsqueda de Colaborador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //dtgColaborador.Rows.Clear();
                    dtgColaborador.DataSource = null;
                    return;
                }
            }

            DataTable dtRes = objCNUsuComite.CNBuscarUsuarioExoneradoLoginComiteCred(Convert.ToString(dtgColaborador.SelectedRows[0].Cells["cWinUser"].Value));

            if (dtRes.Rows.Count == 0 && Convert.ToInt32(cboTipoParticip.SelectedValue) == 1) //cliente no exonerado
            {
                frmCredenciales frmCred = new frmCredenciales(false, clsVarGlobal.User.lAutBiometricaComite);
                frmCred.cWinUser = Convert.ToString(dtgColaborador.SelectedRows[0].Cells["cWinUser"].Value);
                frmCred.ShowDialog();

                if (!frmCred.lValido)
                {
                    MessageBox.Show("No se ha ingresado las credenciales del participante, no se puede incluir al participante en el comité de créditos", "Busqueda de Colaborador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                lUsuAutBiometrico = frmCred.lUsuAutBiometrico;
            }
            

            if (dtgColaborador.SelectedRows.Count > 0)
            {
                objUsuComite = new clsUsuComite();
                objUsuComite.idUsuario = Convert.ToInt32(dtgColaborador.SelectedRows[0].Cells["idUsuario"].Value);
                objUsuComite.cNombre = Convert.ToString(dtgColaborador.SelectedRows[0].Cells["cNombre"].Value);
                objUsuComite.idCargo = Convert.ToInt32(dtgColaborador.SelectedRows[0].Cells["idCargo"].Value);
                objUsuComite.cWinUser = Convert.ToString(dtgColaborador.SelectedRows[0].Cells["cWinUser"].Value);
                objUsuComite.cCargo = Convert.ToString(dtgColaborador.SelectedRows[0].Cells["cCargo"].Value);
                objUsuComite.idTipoParticip = Convert.ToInt32(cboTipoParticip.SelectedValue);
                objUsuComite.cTipoParticip = cboTipoParticip.Text;
                objUsuComite.lConfirmAsis = false;
                objUsuComite.lAutenticacionBiometrica = lUsuAutBiometrico;
            }
            else
            {
                objUsuComite = null;
            }
            this.Dispose();
        }

        #endregion

    }
}
