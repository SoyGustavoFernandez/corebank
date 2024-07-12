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
    public partial class frmMantenimientoActividadRiesgo : frmBase
    {
        #region Variables Globales
        String cTipoOperacion = "N";
        clsCNMapeoRiesgoYOpeInusual cnmapeoriesgoyopeinusual = new clsCNMapeoRiesgoYOpeInusual();
        String cTituloMensajes = "Mantenimiento de actividades";
        #endregion
        public frmMantenimientoActividadRiesgo()
        {
            InitializeComponent();
        }
        #region Eventos
        private void frmMantenimientoActividadRiesgo_Load(object sender, EventArgs e)
        {
            cargarActividades();
            habilitarControles(false);
        }               
        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            habilitarControles(true);
            limpiarControles();
            this.cTipoOperacion = "N";
            this.txtNombreAct.Focus();
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (this.dtgActividades.SelectedRows.Count == 0)
            {
                MessageBox.Show("No existen actividades para editar", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            habilitarControles(true);
            this.cTipoOperacion = "A";
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarControles();
            habilitarControles(false);
            cargarActividades();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txtNombreAct.Text))
            {
                MessageBox.Show("Ingrese una actividad", cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNombreAct.Focus();
                return;
            }
            if (this.cTipoOperacion == "N")
            {
                DataTable dtInsercion = cnmapeoriesgoyopeinusual.insertarActividadesRiesgo(0, this.txtNombreAct.Text.ToString(), true);
                MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(), cTituloMensajes, MessageBoxButtons.OK, ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
            else if (this.cTipoOperacion == "A")
            {
                DataTable dtInsercion = cnmapeoriesgoyopeinusual.insertarActividadesRiesgo(Convert.ToInt32(this.dtgActividades.SelectedRows[0].Cells["idActividadRiesgo"].Value), this.txtNombreAct.Text.ToString(), this.chcVigencia.Checked);
                MessageBox.Show(dtInsercion.Rows[0]["cMensaje"].ToString(), cTituloMensajes, MessageBoxButtons.OK, ((int)dtInsercion.Rows[0]["idError"] == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation));
            }
            limpiarControles();
            habilitarControles(false);
            cargarActividades();
        }

        private void dtgActividades_SelectionChanged(object sender, EventArgs e)
        {
            verDetalleActividad();
        }
        #endregion

        #region Metodos 
        private void cargarActividades()
        {
            DataTable dtActividades = cnmapeoriesgoyopeinusual.listaActividadesRiesgo(0);
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

            this.dtgActividades.Columns["cActividadRiesgo"].HeaderText = "Descripción";
            this.dtgActividades.Columns["lVigente"].HeaderText = "Vigencia";
        }
        private void verDetalleActividad()
        {
            if (this.dtgActividades.SelectedRows.Count > 0)
            {
                this.chcVigencia.Checked = Convert.ToBoolean(this.dtgActividades.SelectedRows[0].Cells["lVigente"].Value);
                this.txtNombreAct.Text = Convert.ToString(this.dtgActividades.SelectedRows[0].Cells["cActividadRiesgo"].Value);
            }
            else
            {
                limpiarControles();
            }
        }
        private void habilitarControles(Boolean Val)
        {
            this.txtNombreAct.Enabled = Val;
            this.chcVigencia.Enabled = Val;
            this.dtgActividades.Enabled = !Val;

            this.btnNuevo1.Enabled = !Val;
            this.btnEditar1.Enabled = !Val;
            this.btnCancelar1.Enabled = Val;
            this.btnGrabar1.Enabled = Val;
            
        }
        private void limpiarControles()
        {
            this.txtNombreAct.Clear();
            this.chcVigencia.Checked = true;
        }
        #endregion
        
        
    }
}
