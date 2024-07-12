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
using CRE.CapaNegocio;
using EntityLayer;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class frmMantMargenGanaciaActividadInt : frmBase
    {
        public clsCNActividadInternaConfig objCNActividadConfig { get; set; }
        public List<clsActividadEconomicaConfig> lstActividadEconConfig { get; set; }
        public clsActividadEconomicaConfig objActividadEconConfig { get; set; }
        public BindingSource bsConfigActividadEcon { get; set; }

        public frmMantMargenGanaciaActividadInt()
        {
            InitializeComponent();
            InicializarComponentes();
            cargarDatosDefecto();
        }
        public void InicializarComponentes()
        {
            objCNActividadConfig = new clsCNActividadInternaConfig();
            lstActividadEconConfig = new List<clsActividadEconomicaConfig>();
            objActividadEconConfig = new clsActividadEconomicaConfig();
            bsConfigActividadEcon = new BindingSource();
        }

        private void cargarDatosDefecto()
        {
            DataTable dtSectorEconomico = new DataTable();
            cboSectorEconomico.DataSource = objCNActividadConfig.CNRecuperarSectorEconomico("1,2,3");
            cboSectorEconomico.DisplayMember = "cDescripcion";
            cboSectorEconomico.ValueMember = "idSectorEcon";

            cboSectorEconomico.SelectedIndex = -1;
            cboSectorCliente.SelectedIndex = -1;

            habilitarControles(ACCION.RECUPERAR);

            ActualizarListaActividadConfig();

            FormatearDataGridView();
            formatearGridActividaEconConfig();
            dtgActividadConfiguracion.Refresh();

        }
        private void FormatearDataGridView()
        {
            this.dtgActividadConfiguracion.Margin = new System.Windows.Forms.Padding(0);
            this.dtgActividadConfiguracion.MultiSelect = false;
            this.dtgActividadConfiguracion.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgActividadConfiguracion.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgActividadConfiguracion.RowHeadersVisible = false;
            this.dtgActividadConfiguracion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void formatearGridActividaEconConfig()
        {
            foreach (DataGridViewColumn column in this.dtgActividadConfiguracion.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            dtgActividadConfiguracion.Columns["idActividadEconomicaConfig"].DisplayIndex = 0;
            dtgActividadConfiguracion.Columns["cActividadInterna"].DisplayIndex = 1;
            dtgActividadConfiguracion.Columns["nMargenGanancia"].DisplayIndex = 2;
            dtgActividadConfiguracion.Columns["cSectorEcon"].DisplayIndex = 3;
            dtgActividadConfiguracion.Columns["cSector"].DisplayIndex = 4;
            dtgActividadConfiguracion.Columns["cActividad"].DisplayIndex = 5;
            
            dtgActividadConfiguracion.Columns["idActividadEconomicaConfig"].Visible = true;
            dtgActividadConfiguracion.Columns["cActividadInterna"].Visible = true;
            dtgActividadConfiguracion.Columns["cActividad"].Visible = true;
            dtgActividadConfiguracion.Columns["cSectorEcon"].Visible = true;
            dtgActividadConfiguracion.Columns["cSector"].Visible = true;
            dtgActividadConfiguracion.Columns["nMargenGanancia"].Visible = true;
            
            dtgActividadConfiguracion.Columns["idActividadEconomicaConfig"].HeaderText = "Cod. Config.";
            dtgActividadConfiguracion.Columns["cActividadInterna"].HeaderText = "Actividad Interna";
            dtgActividadConfiguracion.Columns["cActividad"].HeaderText = "Actividad";
            dtgActividadConfiguracion.Columns["cSectorEcon"].HeaderText = "Sector Economico";
            dtgActividadConfiguracion.Columns["cSector"].HeaderText = "Sector";
            dtgActividadConfiguracion.Columns["nMargenGanancia"].HeaderText = "Margen de Ganancia";
            
            dtgActividadConfiguracion.Columns["nMargenGanancia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dtgActividadConfiguracion.Columns["nMargenGanancia"].DefaultCellStyle.Format = "n2";
            dtgActividadConfiguracion.Refresh();
        }

        private void ActualizarListaActividadConfig()
        {
            DataTable dtActConfig = objCNActividadConfig.CNRecuperarListaConfigActividadInterna();
            lstActividadEconConfig = (dtActConfig.Rows.Count > 0) ? dtActConfig.ToList<clsActividadEconomicaConfig>() as List<clsActividadEconomicaConfig> : new List<clsActividadEconomicaConfig>();
            bsConfigActividadEcon.DataSource = lstActividadEconConfig;
            dtgActividadConfiguracion.DataSource = bsConfigActividadEcon;

            bsConfigActividadEcon.ResetBindings(false);
            dtgActividadConfiguracion.Refresh();
        }

        private void limpiarControles()
        {
            conActividadCIIU.limpiarCombosCIIU();
            cboSectorEconomico.SelectedIndex = -1;
            cboSectorCliente.SelectedIndex = -1;
            txtMargenGanancia.Text = String.Empty;

            ActualizarListaActividadConfig();
            objActividadEconConfig = new clsActividadEconomicaConfig();
        }

        private void habilitarControles(ACCION objAccion)
        {
            switch(objAccion)
            {
                case ACCION.NUEVO:
                    conActividadCIIU.Enabled    = true;
                    cboSectorEconomico.Enabled  = true;
                    cboSectorCliente.Enabled    = true;
                    txtMargenGanancia.Enabled   = true;
                    btnNuevo.Enabled            = false;
                    btnGrabar.Enabled           = true;
                    btnEditar.Enabled           = false;
                    btnCancelar.Enabled         = true;
                    break;
                case ACCION.EDITAR:
                    conActividadCIIU.Enabled    = false;
                    cboSectorEconomico.Enabled  = false;
                    cboSectorCliente.Enabled    = false;
                    txtMargenGanancia.Enabled   = true;
                    btnNuevo.Enabled            = false;
                    btnGrabar.Enabled           = true;
                    btnEditar.Enabled           = false;
                    btnCancelar.Enabled         = true;
                    break;
                case ACCION.GRABAR:
                    conActividadCIIU.Enabled    = false;
                    cboSectorEconomico.Enabled  = false;
                    cboSectorCliente.Enabled    = false;
                    txtMargenGanancia.Enabled   = false;
                    btnNuevo.Enabled            = true;
                    btnGrabar.Enabled           = false;
                    btnEditar.Enabled           = true;
                    btnCancelar.Enabled         = false;
                    break;
                case ACCION.RECUPERAR:
                    conActividadCIIU.Enabled    = false;
                    cboSectorEconomico.Enabled  = false;
                    cboSectorCliente.Enabled    = false;
                    txtMargenGanancia.Enabled   = false;
                    btnNuevo.Enabled            = true;
                    btnGrabar.Enabled           = false;
                    btnEditar.Enabled           = true;
                    btnCancelar.Enabled         = false;
                    break;
                default:
                    conActividadCIIU.Enabled    = false;
                    cboSectorEconomico.Enabled  = false;
                    cboSectorCliente.Enabled    = false;
                    txtMargenGanancia.Enabled   = false;
                    btnNuevo.Enabled            = false;
                    btnGrabar.Enabled           = false;
                    btnEditar.Enabled           = false;
                    btnCancelar.Enabled         = false;
                    break;

            }
        }

        private bool validar()
        {
            bool lValidar = true;
            if(conActividadCIIU.cboActividadInterna1.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona una actividad interna", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lValidar = false;
                return lValidar;
            }
            if (cboSectorEconomico.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un sector Economico", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lValidar = false;
                return lValidar;
            }
            if (cboSectorCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un Sector del cliente ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lValidar = false;
                return lValidar;
            }
            if (String.IsNullOrWhiteSpace(txtMargenGanancia.Text))
            {
                MessageBox.Show("Ingresar un Monto del Margen", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lValidar = false;
                return lValidar;
            }
            return lValidar;
        }

        enum ACCION{
            NUEVO = 0,
            EDITAR = 1,
            GRABAR = 2,
            RECUPERAR = 3
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            habilitarControles(ACCION.NUEVO);
            dtgActividadConfiguracion.ClearSelection();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if(!validar())
            {
                return;
            }

            objActividadEconConfig.idActividadInterna = Convert.ToInt32(conActividadCIIU.cboActividadInterna1.SelectedValue);
            objActividadEconConfig.idActividad = Convert.ToInt32(conActividadCIIU.cboCIIU.SelectedValue);
            objActividadEconConfig.idSectorEcon = Convert.ToInt32(cboSectorEconomico.SelectedValue);
            objActividadEconConfig.idSector = Convert.ToInt32(cboSectorCliente.SelectedValue);

            objActividadEconConfig.nMargenGanancia = Convert.ToDecimal(txtMargenGanancia.Text);
            string xmlConfig = this.objActividadEconConfig.GetXml();

            DataTable dtRespuesta = objCNActividadConfig.CNRegActualizarActividadEconomicaConfig(xmlConfig, clsVarGlobal.User.idUsuario);

            if(dtRespuesta.Rows.Count > 0)
            {
                if(Convert.ToInt32(dtRespuesta.Rows[0]["nRespuesta"]) == 1)
                {
                    MessageBox.Show(Convert.ToString(dtRespuesta.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarListaActividadConfig();
                    habilitarControles(ACCION.GRABAR);
                }
                else
                {
                    MessageBox.Show("Ocurrio un Error al registrar la configuracion ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    habilitarControles(ACCION.EDITAR);
                }
            }
            else
            {
                MessageBox.Show("Ocurrio un Error al registrar la configuracion ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                habilitarControles(ACCION.EDITAR);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            habilitarControles(ACCION.EDITAR);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarControles();
            habilitarControles(ACCION.RECUPERAR);
        }

        private void dtgActividadConfiguracion_SelectionChanged(object sender, EventArgs e)
        {
            if(dtgActividadConfiguracion.SelectedRows.Count > 0)
            {
                objActividadEconConfig = (clsActividadEconomicaConfig)dtgActividadConfiguracion.SelectedRows[0].DataBoundItem;

                conActividadCIIU.cargarActividadInterna(objActividadEconConfig.idActividadInterna);
                cboSectorEconomico.SelectedValue = objActividadEconConfig.idSectorEcon;
                cboSectorCliente.SelectedValue = objActividadEconConfig.idSector;
                txtMargenGanancia.Text = String.Format(objActividadEconConfig.nMargenGanancia.ToString(), "F2");

                habilitarControles(ACCION.RECUPERAR);
            }
            else
            {
                objActividadEconConfig = new clsActividadEconomicaConfig();
            }
        }
    }
}
