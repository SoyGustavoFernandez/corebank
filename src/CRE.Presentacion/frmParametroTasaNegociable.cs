#region Referencias
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
using GEN.Funciones;
#endregion


namespace CRE.Presentacion
{
    public partial class frmParametroTasaNegociable : frmBase
    {
        #region Variables Globales
        List<clsTasaNegociadaPerfil> lstAprobacion { get; set; }
        List<clsParametroAprobTasaNegociable> lstVistoBueno { get; set; }
        BindingSource bsAprobacion { get; set; }
        BindingSource bsVistoBueno { get; set; }
        clsCNCredito objCNCredito { get; set; }
        #endregion

        #region Constructores
        public frmParametroTasaNegociable()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        private void cargarComponentes()
        {
            objCNCredito = new clsCNCredito();

            DataTable dtTipoTasa = objCNCredito.CNListarTipoTasaNegociable();
            cboTipoTasaAprobacion.DataSource = dtTipoTasa;
            cboTipoTasaAprobacion.DisplayMember = dtTipoTasa.Columns["cTipoTasa"].ColumnName;
            cboTipoTasaAprobacion.ValueMember = dtTipoTasa.Columns["idTipoTasa"].ColumnName;

            cboTipoTasaVistoBueno.DataSource = dtTipoTasa;
            cboTipoTasaVistoBueno.DisplayMember = dtTipoTasa.Columns["cTipoTasa"].ColumnName;
            cboTipoTasaVistoBueno.ValueMember = dtTipoTasa.Columns["idTipoTasa"].ColumnName;


            lstAprobacion = new List<clsTasaNegociadaPerfil>();
            bsAprobacion = new BindingSource();
            bsAprobacion.DataSource = lstAprobacion;
            dtgAprobacion.DataSource = bsAprobacion.DataSource;
            bsAprobacion.ResetBindings(false);
            formatearGridAprobacion();
            dtgAprobacion.Refresh();

            lstVistoBueno = new List<clsParametroAprobTasaNegociable>();
            bsVistoBueno = new BindingSource();
            bsVistoBueno.DataSource = lstVistoBueno;
            dtgVistoBueno.DataSource = bsVistoBueno.DataSource;
            bsVistoBueno.ResetBindings(false);
            formatearGridVistoBueno();
            dtgVistoBueno.Refresh();

        }
        private void cargarDatosDefecto()
        {
            actualizarDatosAprobacion();
            actualizarDatosVistoBueno();
        }

        private void actualizarDatosAprobacion()
        {
            List<clsTasaNegociadaPerfil> lstTasaPerfil = objCNCredito.CNObtenerTasaNegociadaPerfil();
            lstAprobacion.Clear();
            lstAprobacion.AddRange(lstTasaPerfil);
            bsAprobacion.DataSource = lstAprobacion;
            dtgAprobacion.DataSource = bsAprobacion;
            bsAprobacion.ResetBindings(false);
            formatearGridAprobacion();
            dtgAprobacion.Refresh();
        }

        private void actualizarDatosVistoBueno()
        {
            List<clsParametroAprobTasaNegociable> lstTasaPerfilVistoBueno = objCNCredito.CNObtenerParametroTasaNegociable();
            lstVistoBueno.Clear();
            lstVistoBueno.AddRange(lstTasaPerfilVistoBueno);
            bsVistoBueno.DataSource = lstVistoBueno;
            dtgVistoBueno.DataSource = bsVistoBueno;
            bsVistoBueno.ResetBindings(false);
            formatearGridVistoBueno();
            dtgVistoBueno.Refresh();
        }

        private void formatearGridAprobacion()
        {
            dtgAprobacion.ReadOnly = true;
            foreach(DataGridViewColumn dgvColumna in dtgAprobacion.Columns)
            {
                dgvColumna.Visible = false;
                dgvColumna.HeaderText = dgvColumna.Name;
                dgvColumna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dtgAprobacion.Columns["cTipoTasa"].Visible  = true;
            dtgAprobacion.Columns["cPerfil"].Visible    = true;
            dtgAprobacion.Columns["lVigente"].Visible   = true;

            dtgAprobacion.Columns["cTipoTasa"].HeaderText   = "Tipo de Tasa";
            dtgAprobacion.Columns["cPerfil"].HeaderText     = "Perfil";
            dtgAprobacion.Columns["lVigente"].HeaderText    = "Vigente";

        }

        private void formatearGridVistoBueno()
        {
            dtgVistoBueno.ReadOnly = true;
            foreach (DataGridViewColumn dgvColumna in dtgVistoBueno.Columns)
            {
                dgvColumna.Visible = false;
                dgvColumna.HeaderText = dgvColumna.Name;
                dgvColumna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dtgVistoBueno.Columns["cTipoTasa"].Visible          = true;
            dtgVistoBueno.Columns["nNumeroVistoBueno"].Visible  = true;
            dtgVistoBueno.Columns["lVigente"].Visible           = true;

            dtgVistoBueno.Columns["cTipoTasa"].HeaderText           = "Tipo de Tasa";
            dtgVistoBueno.Columns["nNumeroVistoBueno"].HeaderText   = "Max. Nivel Visto Bueno";
            dtgVistoBueno.Columns["lVigente"].HeaderText            = "Vigente";
        }

        private void limpiarAprobacion()
        {
            cboTipoTasaAprobacion.SelectedIndex = -1;
            cboListaPerfil.SelectedIndex = -1;
            chcVigenteAprobacion.Checked = false;
        }

        private void limpiarVistoBueno()
        {
            cboTipoTasaVistoBueno.SelectedIndex = -1;
            nudMaxVistoBueno.Value = 0;
            chcVigenteVistoBueno.Checked = false;
        }

        private bool validacionAprobacion()
        {
            bool lResultado = true;

            if(cboTipoTasaAprobacion.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el Tipo de Tasa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lResultado = false;
                return lResultado;
            }
            if(cboListaPerfil.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el Perfil.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lResultado = false;
                return lResultado;
            }
            return lResultado;
        }

        private bool validacionVistoBueno()
        {
            bool lResultado = true;

            if (cboTipoTasaVistoBueno.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el Tipo de Tasa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lResultado = false;
                return lResultado;
            }
            if (nudMaxVistoBueno.Value < 0)
            {
                MessageBox.Show("Debe ingresar un Nivel Correcto.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lResultado = false;
                return lResultado;
            }
            return lResultado;
        }

        private void activarControles(AccionFormulario eAccionFormulario)
        {
            switch (eAccionFormulario)
            {
                case AccionFormulario.APR_DEFECTO:
                case AccionFormulario.APR_RECUPERADO:
                case AccionFormulario.APR_GRABADO:
                    #region
                    cboListaPerfil.Enabled          = false;
                    cboTipoTasaAprobacion.Enabled   = false;
                    chcVigenteAprobacion.Enabled    = false;
                    dtgAprobacion.Enabled           = true;
                    btnNuevoAprobacion.Enabled      = true;
                    btnGrabarAprobacion.Enabled     = false;
                    btnEditarAprobacion.Enabled     = true;
                    btnCancelarAprobacion.Enabled   = false;

                    cboTipoTasaVistoBueno.Enabled   = false;
                    nudMaxVistoBueno.Enabled        = false;
                    chcVigenteVistoBueno.Enabled    = false;
                    dtgVistoBueno.Enabled           = false;
                    btnNuevoVistoBueno.Enabled      = false;
                    btnGrabarVistoBueno.Enabled     = false;
                    btnEditarVistoBueno.Enabled     = false;
                    btnCancelarVistoBueno.Enabled   = false;
                    #endregion
                    break;
                case AccionFormulario.APR_EDITADO:
                    #region
                    cboListaPerfil.Enabled          = true;
                    cboTipoTasaAprobacion.Enabled   = true;
                    chcVigenteAprobacion.Enabled    = true;
                    dtgAprobacion.Enabled           = false;
                    btnNuevoAprobacion.Enabled      = false;
                    btnGrabarAprobacion.Enabled     = true;
                    btnEditarAprobacion.Enabled     = false;
                    btnCancelarAprobacion.Enabled   = true;

                    cboTipoTasaVistoBueno.Enabled   = false;
                    nudMaxVistoBueno.Enabled        = false;
                    chcVigenteVistoBueno.Enabled    = false;
                    dtgVistoBueno.Enabled           = false;
                    btnNuevoVistoBueno.Enabled      = false;
                    btnGrabarVistoBueno.Enabled     = false;
                    btnEditarVistoBueno.Enabled     = false;
                    btnCancelarVistoBueno.Enabled   = false;
                    #endregion
                    break;


                case AccionFormulario.VSB_DEFECTO:
                case AccionFormulario.VSB_RECUPERADO:
                case AccionFormulario.VSB_GRABADO:
                    #region
                    cboListaPerfil.Enabled          = false;
                    cboTipoTasaAprobacion.Enabled   = false;
                    chcVigenteAprobacion.Enabled    = false;
                    dtgAprobacion.Enabled           = false;
                    btnNuevoAprobacion.Enabled      = false;
                    btnGrabarAprobacion.Enabled     = false;
                    btnEditarAprobacion.Enabled     = false;
                    btnCancelarAprobacion.Enabled   = false;

                    cboTipoTasaVistoBueno.Enabled   = false;
                    nudMaxVistoBueno.Enabled        = false;
                    chcVigenteVistoBueno.Enabled    = false;
                    dtgVistoBueno.Enabled           = true;
                    btnNuevoVistoBueno.Enabled      = true;
                    btnGrabarVistoBueno.Enabled     = false;
                    btnEditarVistoBueno.Enabled     = true;
                    btnCancelarVistoBueno.Enabled   = false;
                    #endregion
                    break;

                case AccionFormulario.VSB_EDITADO:
                    #region
                    cboListaPerfil.Enabled          = false;
                    cboTipoTasaAprobacion.Enabled   = false;
                    chcVigenteAprobacion.Enabled    = false;
                    dtgAprobacion.Enabled           = false;
                    btnNuevoAprobacion.Enabled      = false;
                    btnGrabarAprobacion.Enabled     = false;
                    btnEditarAprobacion.Enabled     = false;
                    btnCancelarAprobacion.Enabled   = false;

                    cboTipoTasaVistoBueno.Enabled   = true;
                    nudMaxVistoBueno.Enabled        = true;
                    chcVigenteVistoBueno.Enabled    = true;
                    dtgVistoBueno.Enabled           = false;
                    btnNuevoVistoBueno.Enabled      = false;
                    btnGrabarVistoBueno.Enabled     = true;
                    btnEditarVistoBueno.Enabled     = false;
                    btnCancelarVistoBueno.Enabled   = true;
                    #endregion
                    break;


            }
        }

        private void cargarTabParametrosTasaNegociable()
        {
            if (tbcParametrosTasaNegociable.SelectedTab != null)
            {
                if (tbcParametrosTasaNegociable.SelectedTab.Name == "tabAprobacion")
                {
                    activarControles(AccionFormulario.APR_DEFECTO);
                    seleccionarGridAprobacion();
                }
                else
                {
                    activarControles(AccionFormulario.VSB_DEFECTO);
                    seleccionarGridVistoBueno();
                }
            }
        }

        private void seleccionarGridAprobacion()
        {
            if (dtgAprobacion.SelectedRows.Count > 0)
            {
                clsTasaNegociadaPerfil objNegociada = (clsTasaNegociadaPerfil)dtgAprobacion.SelectedRows[0].DataBoundItem;
                cboTipoTasaAprobacion.SelectedValue = objNegociada.idTipoTasa;
                cboListaPerfil.SelectedValue = objNegociada.idPerfil;
                chcVigenteAprobacion.Checked = objNegociada.lVigente;
                activarControles(AccionFormulario.APR_RECUPERADO);
            }
        }

        private void seleccionarGridVistoBueno()
        {
            if (dtgVistoBueno.SelectedRows.Count > 0)
            {
                clsParametroAprobTasaNegociable objParametro = (clsParametroAprobTasaNegociable)dtgVistoBueno.SelectedRows[0].DataBoundItem;
                cboTipoTasaVistoBueno.SelectedValue = objParametro.idTipoTasa;
                nudMaxVistoBueno.Value = objParametro.nNumeroVistoBueno;
                chcVigenteVistoBueno.Checked = objParametro.lVigente;
                activarControles(AccionFormulario.VSB_RECUPERADO);
            }
        }

        #endregion

        #region Eventos
        private void frmParametroTasaNegociable_Load(object sender, EventArgs e)
        {
            cargarComponentes();
            cargarDatosDefecto();
            activarControles(AccionFormulario.APR_DEFECTO);

            activarControlObjetos(this, EventoFormulario.INICIO);
            cargarTabParametrosTasaNegociable();
        }

        private void tbcParametrosTasaNegociable_Selected(object sender, TabControlEventArgs e)
        {
            cargarTabParametrosTasaNegociable();
        }

        private void btnNuevoAprobacion_Click(object sender, EventArgs e)
        {
            limpiarAprobacion();
            activarControles(AccionFormulario.APR_EDITADO);
            chcVigenteAprobacion.Checked = true;
        }

        private void btnGrabarAprobacion_Click(object sender, EventArgs e)
        {
            if(!validacionAprobacion())
            {
                return;
            }

            clsTasaNegociadaPerfil objTasaNegociada = new clsTasaNegociadaPerfil();
            objTasaNegociada.idTipoTasa = Convert.ToInt32(cboTipoTasaAprobacion.SelectedValue);
            objTasaNegociada.idPerfil = Convert.ToInt32(cboListaPerfil.SelectedValue);
            objTasaNegociada.lVigente = chcVigenteAprobacion.Checked;

            List<clsTasaNegociadaPerfil> lstRegistro = new List<clsTasaNegociadaPerfil>();
            lstRegistro.Add(objTasaNegociada);

            string xmlAprobacion = lstRegistro.GetXml();

            DataTable dtResultado = objCNCredito.CNRegistrarTasaNegociadaPerfil(xmlAprobacion, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario);

            if(dtResultado.Rows.Count > 0)
            {
                if(Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) != 0)
                {
                    MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    actualizarDatosAprobacion();
                    activarControles(AccionFormulario.APR_GRABADO);
                }
                else
                {
                    MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error al registrar la configuración", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnEditarAprobacion_Click(object sender, EventArgs e)
        {
            activarControles(AccionFormulario.APR_EDITADO);
        }

        private void btnCancelarAprobacion_Click(object sender, EventArgs e)
        {
            limpiarAprobacion();
            activarControles(AccionFormulario.APR_DEFECTO);
        }

        private void btnSalirAprobacion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgAprobacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarGridAprobacion();
        }

        private void btnNuevoVistoBueno_Click(object sender, EventArgs e)
        {
            limpiarVistoBueno();
            activarControles(AccionFormulario.VSB_EDITADO);
            chcVigenteVistoBueno.Checked = true;
        }

        private void btnGrabarVistoBueno_Click(object sender, EventArgs e)
        {
            if (!validacionVistoBueno())
            {
                return;
            }

            clsParametroAprobTasaNegociable objTasaNegociada = new clsParametroAprobTasaNegociable();
            objTasaNegociada.idTipoTasa = Convert.ToInt32(cboTipoTasaVistoBueno.SelectedValue);
            objTasaNegociada.nNumeroVistoBueno = Convert.ToInt32(nudMaxVistoBueno.Value);
            objTasaNegociada.lVigente = chcVigenteVistoBueno.Checked;

            List<clsParametroAprobTasaNegociable> lstRegistro = new List<clsParametroAprobTasaNegociable>();
            lstRegistro.Add(objTasaNegociada);

            string xmlVistoBueno = lstRegistro.GetXml();

            DataTable dtResultado = objCNCredito.CNRegistrarParametroAprobTasaNegociable(xmlVistoBueno, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario);

            if (dtResultado.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) != 0)
                {
                    MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    actualizarDatosVistoBueno();
                    activarControles(AccionFormulario.VSB_GRABADO);
                }
                else
                {
                    MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error al registrar la configuración", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEditarVistoBueno_Click(object sender, EventArgs e)
        {
            activarControles(AccionFormulario.VSB_EDITADO);
        }

        private void btnCancelarVistoBueno_Click(object sender, EventArgs e)
        {
            limpiarVistoBueno();
            activarControles(AccionFormulario.VSB_DEFECTO);
        }

        private void btnSalirVistoBueno_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dtgVistoBueno_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarGridVistoBueno();
        }

        #endregion

        #region Enumeradores
        private enum AccionFormulario
        {
            APR_DEFECTO     = 0,
            APR_RECUPERADO  = 1,
            APR_EDITADO     = 2,
            APR_GRABADO     = 3,

            VSB_DEFECTO     = 4,
            VSB_RECUPERADO  = 5,
            VSB_EDITADO     = 6,
            VSB_GRABADO     = 7,
        }

        #endregion
    }
}

