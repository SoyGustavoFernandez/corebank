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
using LOG.CapaNegocio;

namespace LOG.Presentacion
{
    public partial class frmMantenimientoActividades : frmBase
    {
        CNTipoActividades objTipAct = new CNTipoActividades();
        string mensajeDialog = "Mantenimiento de Actividades";
        clsCNActividadPerfil objActPerf;
        Transaccion tTran;
        int idActivLog;
        public frmMantenimientoActividades()
        {  
            InitializeComponent();
            objActPerf = new clsCNActividadPerfil();
            tTran = Transaccion.Selecciona;
            ControlBotones();
            idActivLog = 0;
        }

        private void frmMantenimientoActividades_Load(object sender, EventArgs e)
        {
            limpiarControles();
            activarControles(false);
            cargarCombos();
            cargarActividad();
            seleccionarCombo();
        }

        private void cargarActividad()
        {
            DataTable dtActLog = objActPerf.CNCargarActividadLog(0, 0);
            dtgActividades.DataSource = dtActLog;
            formatogrid();
        }

        private void formatogrid()
        {
            foreach (DataGridViewColumn  item in dtgActividades.Columns)
            {
                item.Visible = false;
                //item.DefaultCellStyle
            }

            dtgActividades.Columns["idActividadLog"].Visible = true;
            dtgActividades.Columns["cActividadLog"].Visible = true;
            dtgActividades.Columns["cTipoActividadLog"].Visible = true;
            dtgActividades.Columns["cNombreAgencia"].Visible = true;
            dtgActividades.Columns["cArea"].Visible = true;
            dtgActividades.Columns["lvigente"].Visible = true;

            dtgActividades.Columns["lvigente"].DisplayIndex = 0;

            dtgActividades.Columns["idActividadLog"].HeaderText = "Código Act.";
            dtgActividades.Columns["cActividadLog"].HeaderText = "Actividad";
            dtgActividades.Columns["cTipoActividadLog"].HeaderText = "Tipo Actividad";
            dtgActividades.Columns["cNombreAgencia"].HeaderText = "Oficina";
            dtgActividades.Columns["cArea"].HeaderText = "Área"; 
            dtgActividades.Columns["lvigente"].HeaderText = "Vigente";
        }

        private void cargarTipoActidadLogistica()
        {
            DataTable dtTipAct = objTipAct.CNMostrarTipoActividades();
            cboTipActLogistica.DataSource = dtTipAct;
            cboTipActLogistica.ValueMember = dtTipAct.Columns[0].ToString();
            cboTipActLogistica.DisplayMember = dtTipAct.Columns[1].ToString();   
        }

        private void cargarCombos()
        {
            cboArea.CargarArea(1);
            cargarTipoActidadLogistica();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarControles();
            activarControles(true);
            cargarCombos();

            tTran = Transaccion.Edita;
            ControlBotones();
        }

        private void limpiarControles()
        {
            cboArea.SelectedIndex = -1;
            cboAgencias.SelectedIndex = -1;
            cboTipActLogistica.SelectedIndex = -1;

            txtCodigoActividad.Text = String.Empty;
            txtDescripcion.Text = string.Empty;
            chcHabilitarActividad.Checked = false;
            idActivLog = 0;
        }

        private void activarControles(bool val)
        {
            cboArea.Enabled = val;
            cboAgencias.Enabled = val;
            cboTipActLogistica.Enabled = val;

            btnNuevo.Enabled = !val;
            btnCancelar.Enabled = val;
            btnGrabar.Enabled = val;

            txtCodigoActividad.Enabled = !val;
            txtDescripcion.Enabled = val;
            btnMiniBusq.Enabled = !val;

            dtgActividades.Enabled = !val;

            chcHabilitarActividad.Enabled = val;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }
            
            DataTable objResult = objTipAct.CNGrabarActividadLogistica(idActivLog, (int)cboAgencias.SelectedValue, (int)cboArea.SelectedValue, (int)cboTipActLogistica.SelectedValue, txtDescripcion.Text.ToString(), (bool)chcHabilitarActividad.Checked);
            if ((int)objResult.Rows[0]["nResultado"] > 0)
            {
                MessageBox.Show(objResult.Rows[0]["cMensaje"].ToString(), mensajeDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                idActivLog = (int)objResult.Rows[0]["idActLog"];
                txtCodigoActividad.Text = idActivLog.ToString();

            }
            else {
                MessageBox.Show(objResult.Rows[0]["cMensaje"].ToString(), mensajeDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            activarControles(false);
            tTran = Transaccion.Selecciona;
            ControlBotones();
            cargarActividad();
            seleccionarCombo();
        }

        private bool validar()
        { 
            if(cboAgencias.SelectedIndex < 0)
            {
                MessageBox.Show("Elija una Agencia por favor!", mensajeDialog,MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgencias.Focus();
                return false;
            }
            if (cboArea.SelectedIndex < 0)
            {
                MessageBox.Show("Elija un Area por favor!", mensajeDialog, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboArea.Focus();
                return false;
            }
            if (cboTipActLogistica.SelectedIndex < 0)
            {
                MessageBox.Show("Elija un tipo de actividad Logística", mensajeDialog, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipActLogistica.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Inserte la Actividad a generar", mensajeDialog, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescripcion.Focus();
                return false;
            }
            return true;
        }

        private void btnMiniBusq_Click(object sender, EventArgs e)
        {
            buscarActividad();   
        }

        private void buscarActividad()
        {
            if (String.IsNullOrEmpty(txtCodigoActividad.Text))
            {
                MessageBox.Show("Ingrese el código actividad", mensajeDialog, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int nCodAct = Convert.ToInt32(txtCodigoActividad.Text);
            DataTable dtActLog = objActPerf.CNCargarActividadLog(nCodAct, 0);

            if (dtActLog.Rows.Count == 0)
            {
                MessageBox.Show("No se ha encontrado ninguna actividad con código: " + nCodAct.ToString(), mensajeDialog, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            completarCombos(dtActLog.Rows[0]);
            SeleccionarItemGrid(nCodAct);
        }

        private void dtgActividades_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgActividades.RowCount < 1)
            {
                MessageBox.Show("No hay datos seleccionados", mensajeDialog, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            seleccionarCombo();
        }

        private void seleccionarCombo() {
            DataRow dr = obtenerRowSeleccionado();
            completarCombos(dr);
        }

        private DataRow obtenerRowSeleccionado()
        {
            if (dtgActividades.SelectedRows.Count == 0)
            {
                return null;
            }
            int idActividadLog = Convert.ToInt32(dtgActividades.SelectedRows[0].Cells["idActividadLog"].Value);

            DataTable dt = ((DataTable)dtgActividades.DataSource);
            DataRow dr = null;
            foreach (DataRow item in dt.Rows)
            {
                if (idActividadLog == Convert.ToInt32(item["idActividadLog"]))
                {
                    dr = item;
                }
            }
            return dr;
        }

        private void completarCombos(DataRow dr)
        {
            if (dr == null)
            { return; }

            txtCodigoActividad.Text = dr["idActividadLog"].ToString();
            idActivLog = Convert.ToInt32(dr["idActividadLog"]);

            cboAgencias.SelectedValue = Convert.ToInt32(dr["idAgencia"]);
            cboArea.SelectedValue = Convert.ToInt32(dr["idArea"]);
            cboTipActLogistica.SelectedValue = Convert.ToInt32(dr["idTipoActividadLog"]);
            txtDescripcion.Text = dr["cActividadLog"].ToString();
            chcHabilitarActividad.Checked = Convert.ToBoolean(dr["lvigente"]);
        }

        private void SeleccionarItemGrid(int nCod)
        {
            foreach (DataGridViewRow item in dtgActividades.Rows)
            {
                if (Convert.ToInt32(item.Cells["idActividadLog"].Value) == nCod)
                {
                    item.Selected = true;
                    dtgActividades.FirstDisplayedScrollingRowIndex = item.Index;
                    return;
                }
            }
        }

        private void ControlBotones()
        {
            switch (tTran) { 
                case Transaccion.Nuevo :
                    btnNuevo.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnCancelar.Enabled = true;
                    break;
                case Transaccion.Edita:
                    btnNuevo.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnCancelar.Enabled = true;
                    break;
                case Transaccion.Selecciona:
                    btnNuevo.Enabled = true;
                    btnEditar1.Enabled = true;
                    btnGrabar.Enabled = false;
                    btnCancelar.Enabled = false;
                    break;
            }
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            tTran = Transaccion.Edita;
            ControlBotones();
            activarControles(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tTran = Transaccion.Selecciona;
            ControlBotones();
            activarControles(false);
        }

        private void txtCodigoActividad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscarActividad();
            }
        }

        private void dtgActividades_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgActividades.RowCount < 1)
            {
                MessageBox.Show("No hay datos seleccionados", mensajeDialog, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataRow dr = obtenerRowSeleccionado();
            completarCombos(dr);
        }

        private void txtCodigoActividad_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
