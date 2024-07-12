using GEN.ControlesBase;
using SPL.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPL.Presentacion
{
    public partial class frmMantenimientoEstrucMapeo : frmBase
    {
        #region Variables Globales
        String cTipoOperacion = "N";
        String cTituloMensajes = "Mantenimiento de actividades por Mapeo";
        int idActividadXTipoMapeo = 0;
        int idActividad = 0;
        clsCNMapeoRiesgoYOpeInusual cnmapeoriesgoyopeinusual = new clsCNMapeoRiesgoYOpeInusual();
        #endregion

        public frmMantenimientoEstrucMapeo()
        {
            InitializeComponent();
        }
        #region Eventos
        private void frmMantenimientoEstrucMapeo_Load(object sender, EventArgs e)
        {
            cargarListaActividades();
            cargarCboActividades();
            habilitarControles(false);
        }
        private void cboTipoMapeoSPLAFT1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarListaActividades();
        }
        private void dtgActividades_SelectionChanged(object sender, EventArgs e)
        {
            verDetalleActividades();
        }
        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            habilitarControles(true);
            limpiarControles();
            this.cTipoOperacion = "N";
            this.cboActividades.Focus();
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (this.dtgActividades.Rows.Count <= 0)
            {
                MessageBox.Show("No existen productos para editar", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            habilitarControles(true);
            this.cTipoOperacion = "A";
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarControles();
            habilitarControles(false);
            cargarListaActividades();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {            
            if (verificaNoRepetidos())
            {
                return;
            }
            if (this.cTipoOperacion == "N")
            {                
                DataTable dtInsercion = cnmapeoriesgoyopeinusual.insertarActividadesXTipoMapeo(0, Convert.ToInt32(this.cboTipoMapeoSPLAFT1.SelectedValue), Convert.ToInt32(this.cboActividades.SelectedValue), this.chcVigencia.Checked);
                MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(), cTituloMensajes, MessageBoxButtons.OK, ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
            else if (this.cTipoOperacion == "A")
            {
                DataTable dtInsercion = cnmapeoriesgoyopeinusual.insertarActividadesXTipoMapeo(this.idActividadXTipoMapeo, Convert.ToInt32(this.cboTipoMapeoSPLAFT1.SelectedValue), Convert.ToInt32(this.cboActividades.SelectedValue), this.chcVigencia.Checked);
                MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(), cTituloMensajes, MessageBoxButtons.OK, ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
            limpiarControles();
            habilitarControles(false);
            cargarListaActividades();
        }
        #endregion  
        #region Metodos
        
        private void cargarListaActividades()
        {
            DataTable dtActividades = cnmapeoriesgoyopeinusual.listaActividadesXTipoMapeo(Convert.ToInt32(this.cboTipoMapeoSPLAFT1.SelectedValue));

            this.dtgActividades.DataSource = dtActividades;
            formatoDTGActividades();
        }
        private void formatoDTGActividades()
        {
            foreach (DataGridViewColumn item in this.dtgActividades.Columns)
            {
                item.Visible = false;
            }
            this.dtgActividades.Columns["cActividadRiesgo"].Visible = true;
            this.dtgActividades.Columns["lVigente"].Visible = true;

            this.dtgActividades.Columns["lVigente"].Width = 100;

            this.dtgActividades.Columns["cActividadRiesgo"].HeaderText = "Actividad riesgo";
            this.dtgActividades.Columns["lVigente"].HeaderText = "Vigencia";
        }
        private void verDetalleActividades()
        {
            if (this.dtgActividades.SelectedRows.Count > 0)
            {
                this.idActividadXTipoMapeo = Convert.ToInt32(this.dtgActividades.SelectedRows[0].Cells["idActividadXMapeo"].Value);
                this.chcVigencia.Checked = Convert.ToBoolean(this.dtgActividades.SelectedRows[0].Cells["lVigente"].Value);
                this.cboActividades.SelectedValue = Convert.ToInt32(this.dtgActividades.SelectedRows[0].Cells["idActividadRiesgo"].Value);
                this.idActividad = Convert.ToInt32(this.dtgActividades.SelectedRows[0].Cells["idActividadRiesgo"].Value);
            }
            else
            {
                limpiarControles();
            }
        }
        private void cargarCboActividades()
        {
            DataTable dtActividades = cnmapeoriesgoyopeinusual.listaActividadesRiesgo(0);
            dtActividades.DefaultView.RowFilter = "lVigente = 1";
            this.cboActividades.ValueMember = "idActividadRiesgo";
            this.cboActividades.DisplayMember = "cActividadRiesgo";
            this.cboActividades.DataSource = dtActividades.DefaultView;
        }
        private void habilitarControles(Boolean Val)
        {
            this.cboActividades.Enabled = Val;
            this.chcVigencia.Enabled = Val;
            this.dtgActividades.Enabled = !Val;
            this.cboTipoMapeoSPLAFT1.Enabled = !Val;

            this.btnNuevo1.Enabled = !Val;
            this.btnEditar1.Enabled = !Val;
            this.btnCancelar1.Enabled = Val;
            this.btnGrabar1.Enabled = Val;

        }
        private void limpiarControles()
        {
            this.idActividad = 0;
            this.cboActividades.SelectedIndex = -1;
            this.chcVigencia.Checked = true;
        }
        private Boolean verificaNoRepetidos()
        {
            if (this.cboActividades.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una actividad", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboActividades.Focus();
                return true;
            }
            foreach (DataGridViewRow item in this.dtgActividades.Rows)
            {
                if (Convert.ToInt32(this.cboActividades.SelectedValue) != this.idActividad)
	            {
                    if (Convert.ToInt32(item.Cells["idActividadRiesgo"].Value) == Convert.ToInt32(this.cboActividades.SelectedValue))
                    {
                        MessageBox.Show("La actividad ya está en la lista, elija otra", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return true;
                    }
	            }
                
            }
            return false;
        }
        #endregion

              

        
    }
}
