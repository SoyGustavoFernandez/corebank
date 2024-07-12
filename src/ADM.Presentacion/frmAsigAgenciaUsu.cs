using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ADM.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;


namespace ADM.Presentacion
{
    public partial class frmAsigAgenciaUsu : frmBase
    {

        #region Variables Globales

        private const string cTituloMsjes = "Asignación de agencias a usuarios.";
        private clsAgenByUsu objAgenByUsu = null;

        #endregion

        #region Eventos
        
        private void Form_Load(object sender, EventArgs e)
        {
            cboAgencias.AgenciasYTodos();
            cboAgencias.SelectedIndex = -1;
            Habilitar(false);

            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;

            conBusCol.Focus();
            conBusCol.txtCod.Focus();
            conBusCol.txtCod.Select();
        }

        private void dtgAgenciasAsig_SelectionChanged(object sender, EventArgs e)
        {
            LimpiarControles();
            if (dtgAgenciasAsig.SelectedRows.Count > 0)
            {
                
                clsAgenByUsu objAgenByUsu = (clsAgenByUsu)dtgAgenciasAsig.SelectedRows[0].DataBoundItem;
                MapeaDatosControl(objAgenByUsu);

                btnNuevo.Enabled = true;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = true;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            AsignarValores();

            clsDBResp objDbResp = new clsCNAsigAgenByUsu().CNGuardarAgenByUsu(objAgenByUsu);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarDatos();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            Habilitar(true);
            objAgenByUsu = new clsAgenByUsu();

            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;

            cboAgencias.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgAgenciasAsig.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a editar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            objAgenByUsu = (clsAgenByUsu)dtgAgenciasAsig.SelectedRows[0].DataBoundItem;
            Habilitar(true);
            cboAgencias.Enabled = false;

            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;

            chcPrincipal.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgAgenciasAsig.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a eliminar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsAgenByUsu objAgenByUsu = (clsAgenByUsu)dtgAgenciasAsig.SelectedRows[0].DataBoundItem;
            objAgenByUsu.lVigente = false;
            objAgenByUsu.dFecha = clsVarGlobal.dFecSystem.Date;
            objAgenByUsu.idUsuario = clsVarGlobal.User.idUsuario;

            clsDBResp objDbResp = new clsCNAsigAgenByUsu().CNGuardarAgenByUsu(objAgenByUsu);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarDatos();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            dtgAgenciasAsig.DataSource = new List<clsAgenByUsu>();
            Habilitar(false);

            conBusCol.LimpiarDatos();
            conBusCol.txtCod.Enabled = true;
            conBusCol.btnConsultar.Enabled = true;

            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;

            conBusCol.Focus();
            conBusCol.txtCod.Focus();
            conBusCol.txtCod.Select();
        }

        private void conBusCol_BuscarUsuario(object sender, EventArgs e)
        {
            CargarDatos();
        }

        #endregion

        #region Metodos

        public frmAsigAgenciaUsu()
        {
            InitializeComponent();
        }

        private bool Validar()
        {
            if (cboAgencias.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la agencia a asignar.", cTituloMsjes, 
                                                                MessageBoxButtons.OK, 
                                                                MessageBoxIcon.Warning);
                return false;
            }

            if (dtgAgenciasAsig.Rows.Count == 0 && !chcPrincipal.Checked)
            {
                MessageBox.Show("Seleccione la agencia como principal. No existe ninguna agencia principal.", cTituloMsjes, 
                                                                                                    MessageBoxButtons.OK, 
                                                                                                    MessageBoxIcon.Warning);
                return false;
            }
        
            return true;
        }

        private void LimpiarControles()
        {
            cboAgencias.SelectedIndex = -1;
            chcPrincipal.Checked = false;            
        }

        private void CargarDatos()
        {
            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;

            Habilitar(false);

            if (String.IsNullOrEmpty(conBusCol.idUsu))
            {
                MessageBox.Show("Seleccione a un colaborador.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusCol.txtCod.Focus();
                return;
            }

            dtgAgenciasAsig.SelectionChanged -= dtgAgenciasAsig_SelectionChanged;

            List<clsAgenByUsu> lstAgenByUsu = new clsCNAsigAgenByUsu().CNGetAgenByUsu(Convert.ToInt32(conBusCol.idUsu));
            dtgAgenciasAsig.DataSource = lstAgenByUsu.ToList();

            conBusCol.btnConsultar.Enabled = false;
            conBusCol.txtCod.Enabled = false;
            btnCancelar.Enabled = true;

            dtgAgenciasAsig_SelectionChanged(dtgAgenciasAsig, new EventArgs());

            dtgAgenciasAsig.SelectionChanged += dtgAgenciasAsig_SelectionChanged;

            dtgAgenciasAsig.Focus();
        }

        private void Habilitar(bool lHabil)
        {
            cboAgencias.Enabled = lHabil;
            chcPrincipal.Enabled = lHabil;
            dtgAgenciasAsig.Enabled = !lHabil;
        }

        private void MapeaDatosControl(clsAgenByUsu objAgenByUsu)
        {
            cboAgencias.SelectedValue = objAgenByUsu.idAgencia;
            chcPrincipal.Checked = objAgenByUsu.lPrincipal;
        }

        private void AsignarValores()
        {
            objAgenByUsu.idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            objAgenByUsu.idUsuAsig = Convert.ToInt32(conBusCol.idUsu.Trim());
            objAgenByUsu.lPrincipal = chcPrincipal.Checked;
            objAgenByUsu.dFecha = clsVarGlobal.dFecSystem.Date;
            objAgenByUsu.idUsuario = clsVarGlobal.User.idUsuario;
        }

        #endregion     

    }
}
