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
using LOG.CapaNegocio;
using GEN.CapaNegocio;
using EntityLayer;

namespace LOG.Presentacion
{
    public partial class frmActividadLogisticaPerfil : frmBase
    {
        clsCNActividadPerfil objActPerf = new clsCNActividadPerfil();
        clsCNActividadLog objActPerfil = new clsCNActividadLog();
        string messageDialog = "";
        Transaccion nTran;

        private int idActByPerfil = 0;

        public frmActividadLogisticaPerfil()
        {
            InitializeComponent();
        }

        private void frmActividadLogistica_Load(object sender, EventArgs e)
        {
            limpiarControles();
            habilitarControles(false);
            cboAgencia1.cargarSoloAgencias();
            cargarPerfilUsuario();
            cargarActividadLogistica();
            cargarActPorPerfil();
            nTran = Transaccion.Selecciona;
            ControlBotones();
            
        }

        private void cargarActPorPerfil()
        {
            DataTable dtActXPerfil = objActPerfil.CNListaActividadLog(0, 0);
            dtgActXPerfil.DataSource = dtActXPerfil;
            formatoGrid();
            cargaCombosSeleccion();
        }

        private void formatoGrid()
        {
            foreach (DataGridViewColumn item in dtgActXPerfil.Columns)
            {
                item.Visible = false;
                //item.DefaultCellStyle
            }

            dtgActXPerfil.Columns["idActLogbyPerfil"].Visible = true;
            dtgActXPerfil.Columns["cActividadLog"].Visible = true;
            dtgActXPerfil.Columns["lIndEstadoAct"].Visible = true;
            dtgActXPerfil.Columns["lIndEstadoPerf"].Visible = true;
            dtgActXPerfil.Columns["cPerfil"].Visible = true;
            dtgActXPerfil.Columns["cNombreAgencia"].Visible = true;

            dtgActXPerfil.Columns["idActLogbyPerfil"].HeaderText = "Código Act. Perf.";
            dtgActXPerfil.Columns["cActividadLog"].HeaderText = "Actividad";
            dtgActXPerfil.Columns["lIndEstadoAct"].HeaderText = "Estado Actividad";
            dtgActXPerfil.Columns["lIndEstadoPerf"].HeaderText = "Estado Perfil Act.";
            dtgActXPerfil.Columns["cPerfil"].HeaderText = "Perfil";
            dtgActXPerfil.Columns["cNombreAgencia"].HeaderText = "Oficina";
        }
        public void cargarPerfilUsuario()
        {
            DataTable dtPerfUsu = objActPerf.CNCargarPerfilUsuario();
            cboPerfilUsuario.DataSource = dtPerfUsu;
            cboPerfilUsuario.ValueMember = dtPerfUsu.Columns[0].ToString();
            cboPerfilUsuario.DisplayMember = dtPerfUsu.Columns[1].ToString();
        }

        public void cargarActividadLogistica()
        { 
            DataTable dtActLog = objActPerf.CNCargarActividadLog(0, 1);
            cboActividadLog.DataSource = dtActLog;
            cboActividadLog.ValueMember = dtActLog.Columns[0].ToString();
            cboActividadLog.DisplayMember = dtActLog.Columns[1].ToString();
        }

        private void cargarCombos()
        {
            cargarPerfilUsuario();
            cargarActividadLogistica();
        }

        private void limpiarControles()
        {
            txtCodigo.Text = String.Empty;
            cboPerfilUsuario.SelectedIndex = -1;
            cboActividadLog.SelectedIndex = -1;
            cboAgencia1.SelectedIndex = -1;
            chcHabActPerf.Checked = false;
        }

        private void habilitarControles(bool val)
        {
            txtCodigo.Enabled = !val;
            btnMiniBusq.Enabled = !val;
            btnNuevo.Enabled = !val;

            cboPerfilUsuario.Enabled = val;
            cboActividadLog.Enabled = val;
            chcHabActPerf.Enabled = val;
            cboAgencia1.Enabled = val;

            btnGrabar.Enabled = val;
            btnCancelar.Enabled = val;
            btnEditar1.Enabled = val;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            habilitarControles(true);
            limpiarControles();
            nTran = Transaccion.Nuevo;
            ControlBotones();
            dtgActXPerfil.Enabled = true;
            idActByPerfil = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarControles();
            habilitarControles(false);
            dtgActXPerfil.Enabled = true;
            btnEditar1.Enabled = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }
            int idperfil = (int)cboPerfilUsuario.SelectedValue;
            int idActividadLog = (int)cboActividadLog.SelectedValue;
            bool @lvigente = chcHabActPerf.Checked;
            DataTable dtResult = objActPerf.CNGuardarActLogPerfil(idActByPerfil, idperfil, idActividadLog, @lvigente);
            if ((int)dtResult.Rows[0]["nResultado"] > 0)
            {
                MessageBox.Show(dtResult.Rows[0]["cMensaje"].ToString(), messageDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                nTran = Transaccion.Selecciona;
                ControlBotones();
            }else{
                MessageBox.Show(dtResult.Rows[0]["cMensaje"].ToString(), messageDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            recargarGridActPerfil();
            habilitarControles(false);
            dtgActXPerfil.Enabled = true;
            btnEditar1.Enabled = true;
        }

        private bool validar()
        {
            
            if (cboPerfilUsuario.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un perfil de usuario", messageDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboPerfilUsuario.Focus();
                return false;
            }
            if (cboAgencia1.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una agencia", messageDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboAgencia1.Focus();
                return false;
            }
            if (cboActividadLog.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione Actividad Logística", messageDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboActividadLog.Focus();
                return false;
            }
            return true;

        }

        private void dtgActXPerfil_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            cargaCombosSeleccion();
        }

        private void cargaCombosSeleccion()
        {
            if (dtgActXPerfil.RowCount == 0)
            {
                MessageBox.Show("No hay filas a seleccionar", messageDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataRow dr = obtenerRowSeleccionado();
            seleccionarValoresCombos(dr);
        }

        private DataRow obtenerRowSeleccionado()
        {
            if (dtgActXPerfil.SelectedRows.Count == 0)
            {
                return null;
            }
            int idActividadLog = Convert.ToInt32(dtgActXPerfil.SelectedRows[0].Cells["idActLogbyPerfil"].Value);

            DataTable dt = ((DataTable)dtgActXPerfil.DataSource);
            DataRow dr = null;
            foreach (DataRow item in dt.Rows)
            {
                if (idActividadLog == Convert.ToInt32(item["idActLogbyPerfil"]))
                {
                    dr = item;
                }
            }
            return dr;
        }

        private void seleccionarValoresCombos(DataRow dr)
        {
            if (dr == null)
            {
                return; 
            }
            cboPerfilUsuario.SelectedValue = Convert.ToInt32(dr["idPerfil"]);
            cboAgencia1.SelectedValue = Convert.ToInt32(dr["idAgencia"]);
            cboActividadLog.SelectedValue = Convert.ToInt32(dr["idActividadLog"]);
            chcHabActPerf.Checked = Convert.ToBoolean(dr["lIndEstadoPerf"]);
            idActByPerfil = Convert.ToInt32(dr["idActLogbyPerfil"]);
            txtCodigo.Text = dr["idActLogbyPerfil"].ToString();
        }

        private void cboAgencia1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencia1.SelectedIndex < 0)
            {
                return;
            }
            
            int idAgencia = Convert.ToInt32(cboAgencia1.SelectedValue);
            DataTable dtAct =  objActPerf.CNCargarActividadLogAgencia(idAgencia);

            cboActividadLog.DisplayMember = dtAct.Columns[1].ToString();
            cboActividadLog.ValueMember = dtAct.Columns[0].ToString();
            cboActividadLog.DataSource = dtAct;
        }

        private void ControlBotones()
        {
            switch (nTran)
            { 
                case Transaccion.Edita:
                    btnNuevo.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnGrabar.Enabled = true;
                    btnCancelar.Enabled = true;
                    break;
                case Transaccion.Nuevo:
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
            nTran = Transaccion.Edita;
            habilitarControles(true);
            ControlBotones();
            dtgActXPerfil.Enabled = false;
        }

        private void btnMiniBusq_Click(object sender, EventArgs e)
        {
            buscarActividad();
        }
        private void recargarGridActPerfil()
        {
            cargarActPorPerfil();
        }

        private void buscarActividad()
        {
            if (String.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Ingrese el código", "Verificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int nCodAct = Convert.ToInt32(txtCodigo.Text);
            DataTable dtActLog = (DataTable) dtgActXPerfil.DataSource;
            DataRow dr = dtActLog.NewRow();
            bool lExiste = false;
            foreach (DataRow item in dtActLog.Rows)
            {
                if (Convert.ToInt32(item["idActLogbyPerfil"]) == nCodAct)
                {
                    dr = item;
                    lExiste = true;
                }
            }
            
            if (dtActLog.Rows.Count == 0)
            {
                MessageBox.Show("No se ha encontrado ninguna actividad con código: " + nCodAct.ToString(), "Verificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!lExiste)
            {
                MessageBox.Show("No existe la actividad con codigo: " + nCodAct.ToString(), "Verificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            seleccionarValoresCombos(dr);
            SeleccionarItemGrid(nCodAct);
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscarActividad();
            }
        }

        private void SeleccionarItemGrid(int nCod)
        {
            foreach (DataGridViewRow item in dtgActXPerfil.Rows)
            {
                if (Convert.ToInt32(item.Cells["idActLogbyPerfil"].Value) == nCod)
                {
                    item.Selected = true;
                    dtgActXPerfil.FirstDisplayedScrollingRowIndex = item.Index;
                    return;
                }
            }
        }
    }
}
