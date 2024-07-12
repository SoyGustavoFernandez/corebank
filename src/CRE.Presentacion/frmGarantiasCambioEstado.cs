using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using CRE.CapaNegocio;
using CLI.CapaNegocio;
using DEP.CapaNegocio;
using GEN.CapaNegocio;
using System.Collections.Generic;


namespace CRE.Presentacion
{
    public partial class frmGarantiasCambioEstado : frmBase
    {

        #region de Variables
        private const string cTituloMsjes = "Registro de garantías";
        private clsCNGarantia _objCNGarantia;
        private clsGarantia _objGarantia;
        #endregion
        public frmGarantiasCambioEstado()
        {
            InitializeComponent();

            _objCNGarantia = new clsCNGarantia();
        }

        private void frmGarantiasCambioEstado_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);

            dtgGarantias.AutoGenerateColumns = false;

            conBusCliente.txtCodCli.Focus();
            cboGrupoGarantia.Enabled = false;
            cboClaseGarantia.Enabled = false;
            cboTipoGarantia.Enabled = false;

            cboGrupoGarantia.SelectedValue = -1;
            cboTipoGarantia.SelectedValue = -1;
            cboClaseGarantia.SelectedValue = -1;
        }

        private void conBusCliente_ClicBuscar(object sender, EventArgs e)
        {
            CargarCliente();
        }

        private void CargarCliente()
        {
            if (conBusCliente.idCli == 0)
            {
                MessageBox.Show("Debe Buscar Primero un Cliente", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusCliente.btnBusCliente.Focus();
                btnCancelar.Enabled = false;
                return;
            }
            /***************************************************************************/
            //cboClaseGarantia.SelectedIndexChanged -= cboClaseGarantia_SelectedIndexChanged;
            
            ListarGarantiasCliente(conBusCliente.idCli);
            dtgGarantias.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = true;
            
        }

        private void CargarDatosGarantia(clsGarantia objgarantia)
        {            
            rbtHipoteca.Enabled = false;
            rbtPersonal.Enabled = false;
            rbtTituloValor.Enabled = false;
            rbtVehiculo.Enabled = false;
            rbtElectros.Enabled = false;

            txtDescripcion.Text = (objgarantia.idGarantia).ToString()+" - "+objgarantia.cGarantia;
            txtDescripcion.Enabled = false;

            cboGrupoGarantia.SelectedValue = objgarantia.idGrupoGarantia;
            
            cboClaseGarantia.cargarClaseByGrupo((int)cboGrupoGarantia.SelectedValue);
            cboGrupoGarantia.Enabled = false;
            
            cboClaseGarantia.SelectedValue = objgarantia.idClaseGarantia;
            cboClaseGarantia.Enabled = false;
            cboTipoGarantia.SelectedValue = objgarantia.idTipoGarantia;
            cboTipoGarantia.Enabled = false;
            
            if (objgarantia.idGrupoGarantia == 1)
                btnEditar.Enabled = false;
            else btnEditar.Enabled = true;
            CargarEspecificacion(objgarantia.idGarantia);
            
        }

        private void dtgGarantias_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgGarantias.SelectedRows.Count > 0)
            {
                _objGarantia = (clsGarantia)dtgGarantias.SelectedRows[0].DataBoundItem;
                CargarDatosGarantia(_objGarantia);
                
                if (_objGarantia.idGrupoGarantia == 1)
                { btnEditar.Enabled = true; }
                else
                { 
                    btnEditar.Enabled = false;
                    MessageBox.Show("Este Grupo de Garantía no permite Edición", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ListarGarantiasCliente(int idCli)
        {
            dtgGarantias.SelectionChanged -= dtgGarantias_SelectionChanged;

            clsListGarantia listGarantia = _objCNGarantia.listarGarantias(idCli);

            dtgGarantias.DataSource = listGarantia;
            dtgGarantias.ClearSelection();

            dtgGarantias.SelectionChanged += dtgGarantias_SelectionChanged;

            if (dtgGarantias.RowCount > 0)
                dtgGarantias.Rows[0].Selected = true;
            /***********************************************************************/
            //cboTipoGarantia.cargarTipoByClase((int)cboClaseGarantia.SelectedValue);            
        }

        

        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            
            dtgGarantias.DataSource = null;

            btnEditar.Enabled = false;
            btnGrabar.Enabled = false;
            conBusCliente.limpiarControles();
            conBusCliente.Enabled = true;
            conBusCliente.txtCodCli.Enabled = true;
            cboGrupoGarantia.SelectedValue = -1;
            cboTipoGarantia.SelectedValue = -1;
            cboClaseGarantia.SelectedValue = -1;
            cboClaseGarantia.Enabled = false;
            cboTipoGarantia.Enabled = false;

            conBusCliente.Focus();
            conBusCliente.txtCodCli.Focus();

            cboClaseGarantia.SelectedIndexChanged -= cboClaseGarantia_SelectedIndexChanged2;
            cboClaseGarantia.SelectedIndexChanged += cboClaseGarantia_SelectedIndexChanged;
        }

        private void cboClaseGarantia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClaseGarantia.SelectedIndex >= 0)
            {
                cboTipoGarantia.cargarTipoByClase((int)cboClaseGarantia.SelectedValue);
            }
        }

        private void cboClaseGarantia_SelectedIndexChanged2(object sender, EventArgs e)
        {
            if (cboClaseGarantia.SelectedIndex >= 0)
            {
                cboTipoGarantia.cargarTipoByClaseFiltroCambioEstado((int)cboClaseGarantia.SelectedValue);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cboClaseGarantia.SelectedIndexChanged -= cboClaseGarantia_SelectedIndexChanged;
            cboClaseGarantia.SelectedIndexChanged += cboClaseGarantia_SelectedIndexChanged2;
            cboTipoGarantia.cargarTipoByClaseFiltroCambioEstado((int)cboClaseGarantia.SelectedValue);
            cboClaseGarantia.Enabled = true;
            cboTipoGarantia.Enabled = true;

            btnEditar.Enabled = false;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            dtgGarantias.Enabled = false;
        }

        private void cboGrupoGarantia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGrupoGarantia.SelectedIndex >= 0)
            {
                cboClaseGarantia.cargarClaseByGrupo((int)cboGrupoGarantia.SelectedValue);
            }
        }
        private void CargarEspecificacion(int idGar)
        {
            clsLisEspecificacioGarantia listaespecifica = _objCNGarantia.listarespecificacion(idGar);

            if (listaespecifica.Count() > 0)
            {
                string cTipo = listaespecifica.Where(x => x.cCampo == "tipo").FirstOrDefault().cValCampo.ToUpper();
                switch (cTipo)
                {
                    case "H":
                        rbtHipoteca.Checked = true;
                        break;
                    case "V":
                        rbtVehiculo.Checked = true;
                        break;
                    case "T":
                        rbtTituloValor.Checked = true;
                        break;
                    case "P":
                        rbtPersonal.Checked = true;
                        break;
                    case "E":
                        rbtElectros.Checked = true;
                        break;
                }
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //registrarRastreo(Convert.ToInt32(conBusCliente.idCli), 0, "Inicio - Cambio de Estado de Garantía", btnGrabar);
            //_objGarantia.idGarantia = Convert.ToInt32(objgarantia.idGarantia);
            _objGarantia.idClaseGarantia = Convert.ToInt32(cboClaseGarantia.SelectedValue);
            _objGarantia.idTipoGarantia = Convert.ToInt32(cboTipoGarantia.SelectedValue);

            clsDBResp objDbResp = _objCNGarantia.cambiarEstadoGarantia(_objGarantia, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cboClaseGarantia.Enabled = false;
                cboTipoGarantia.Enabled = false;

                btnEditar.Enabled = true;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = false;
                dtgGarantias.Enabled = true;
            }
            
            //registrarRastreo(Convert.ToInt32(conBusCliente.idCli), 0, "Fin - Cambio de Estado de Garantía", btnGrabar);
        }
    }
}
