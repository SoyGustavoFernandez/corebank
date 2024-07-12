using GEN.CapaNegocio;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADM.Presentacion
{
    public partial class frmMantenimientoTipoZona : frmBase
    {

        clsCNRegionZona cnTipoZona = new clsCNRegionZona();
        int nfilas_dtg  = -1;
        int nfila_actu  = -1;

        bool lActualiza = false;

        public frmMantenimientoTipoZona()
        {
            InitializeComponent();
        }

        private void frmMantenimientoTipoZona_Load(object sender, EventArgs e)
        {
            listarTipoZona();
        }

        private void listarTipoZona() 
        {
            DataTable dtTipoZona = new DataTable();
            dtTipoZona = cnTipoZona.CNListarTipoZona();
            dtgTipoZona.DataSource = dtTipoZona;
            dtgTipoZona.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dtgTipoZona.Columns["Orden"].Width = 40;
            dtgTipoZona.Columns["Zona"].Width = 200;
            dtgTipoZona.Columns["lVigente"].Width = 50;
            dtgTipoZona.Columns["idTipoZona"].Visible = false;
            dtgTipoZona.Columns["cCodSunat"].Visible = false;
            dtgTipoZona.Columns["idSector"].Visible = false;
            dtgTipoZona.Columns["lVigente"].HeaderText = "Vigencia";
            dtgTipoZona.ClearSelection();

            nfilas_dtg = dtTipoZona.Rows.Count;

        }

        private void habilitarcontrolesEditar()
        {
            btnGrabar1.Enabled = true;
            btnCancelar1.Enabled = true;
            cboSector1.Enabled = true;
            txtDescripcion.Enabled = true;
            txtCodSunat.Enabled = true;
            btnEditar1.Enabled = false;
            btnEliminar1.Enabled = false;
            btnNuevo1.Enabled = false;
            btnBajar.Enabled = false;
            btnSubir.Enabled = false;
            dtgTipoZona.Enabled = false;
            lActualiza = true;
        }

        private void habilitarcontroles() 
        {
            rbtActivo.Checked = true;
            btnGrabar1.Enabled = true;
            btnCancelar1.Enabled = true;  
            cboSector1.Enabled = true;
            txtDescripcion.Enabled = true;
            txtCodSunat.Enabled = true;
            btnEditar1.Enabled = false;
            btnEliminar1.Enabled = false;
            btnNuevo1.Enabled = false;
            btnBajar.Enabled = false;
            btnSubir.Enabled = false;
            dtgTipoZona.Enabled = false;
            txtId.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            txtCodSunat.Text = "12";
            dtgTipoZona.ClearSelection();
        }

        private void deshabilitarcontroles()
        {
            rbtActivo.Checked = false;
            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = false;
            cboSector1.Enabled = false;
            txtDescripcion.Enabled = false;
            txtCodSunat.Enabled = false;
            btnEditar1.Enabled = true;
            btnEliminar1.Enabled = true;
            btnNuevo1.Enabled = true;
            btnBajar.Enabled = true;
            btnSubir.Enabled = true;
            dtgTipoZona.Enabled = true;
            rbtActivo.Enabled = false; rbtActivo.Checked = false;
            rbtnInactivo.Enabled = false; rbtnInactivo.Checked = false;
            txtId.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            txtCodSunat.Text = String.Empty;
            dtgTipoZona.ClearSelection();
            lActualiza = false;
        }

        private void dtgTipoZona_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSubir.Enabled = true; 
            btnBajar.Enabled = true;
            nfila_actu = Convert.ToInt32(dtgTipoZona.CurrentRow.Index);
            if (Convert.ToInt32(dtgTipoZona.CurrentRow.Cells[0].Value) == 1)
            {
                btnSubir.Enabled = false; btnBajar.Enabled = true;
            }
            if (Convert.ToInt32(dtgTipoZona.CurrentRow.Cells[0].Value) == nfilas_dtg)
            {
                btnSubir.Enabled = true; btnBajar.Enabled = false;
            }

            txtId.Text = Convert.ToString(dtgTipoZona.CurrentRow.Cells[4].Value);
            txtDescripcion.Text = Convert.ToString(dtgTipoZona.CurrentRow.Cells[1].Value);
            txtCodSunat.Text = Convert.ToString(dtgTipoZona.CurrentRow.Cells[5].Value);
            cboSector1.SelectedValue = Convert.ToInt32(dtgTipoZona.CurrentRow.Cells[6].Value);
            if (Convert.ToBoolean(dtgTipoZona.CurrentRow.Cells[3].Value) == true)
            {
                rbtActivo.Checked = true;
                rbtnInactivo.Checked = false;
            }
            else
            {
                rbtActivo.Checked = false;
                rbtnInactivo.Checked = true;
            }
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            if (nfila_actu == -1)
            {
                MessageBox.Show("Debe seleccionar Item", "Subir Item.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtCambiaOrden = new DataTable();
            Font myFont = new System.Drawing.Font(dtgTipoZona.Font, FontStyle.Bold);
            dtCambiaOrden = cnTipoZona.CNCambiaOrdenAscTipoZona(Convert.ToInt32(dtgTipoZona.Rows[nfila_actu].Cells[0].Value));
            listarTipoZona();
            dtgTipoZona.Rows[nfila_actu - 1].Cells["Zona"].Style.Font = myFont;
            dtgTipoZona.Rows[nfila_actu - 1].Cells["Orden"].Style.Font = myFont;
            dtgTipoZona.Rows[nfila_actu - 1].Cells["lVigente"].Style.Font = myFont;
            txtId.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            txtCodSunat.Text = String.Empty;

            dtgTipoZona.Rows[nfila_actu - 1].Selected = true;

            nfila_actu = nfila_actu - 1;

            if (nfila_actu == 0)
            {
                btnSubir.Enabled = false; btnBajar.Enabled = true;
            }
            if (nfila_actu == nfilas_dtg-1)
            {
                btnSubir.Enabled = true; btnBajar.Enabled = false;
            }
        }

        private void btnBajar_Click(object sender, EventArgs e)
        {
            if (nfila_actu == -1)
            {
                MessageBox.Show("Debe seleccionar Item", "Bajar Item.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dtCambiaOrden = new DataTable();
            Font myFont = new System.Drawing.Font(dtgTipoZona.Font, FontStyle.Bold);
            dtCambiaOrden = cnTipoZona.CNCambiaOrdenDescTipoZona(Convert.ToInt32(dtgTipoZona.Rows[nfila_actu].Cells[0].Value));
            listarTipoZona();
            dtgTipoZona.Rows[nfila_actu + 1].Cells["Zona"].Style.Font = myFont;
            dtgTipoZona.Rows[nfila_actu + 1].Cells["Orden"].Style.Font = myFont;
            dtgTipoZona.Rows[nfila_actu + 1].Cells["lVigente"].Style.Font = myFont;
            txtId.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            txtCodSunat.Text = String.Empty;

            dtgTipoZona.Rows[nfila_actu + 1].Selected = true;

            nfila_actu = nfila_actu + 1;

            if (nfila_actu == 0)
            {
                btnSubir.Enabled = false; btnBajar.Enabled = true;
            }
            if (nfila_actu == nfilas_dtg-1)
            {
                btnSubir.Enabled = true; btnBajar.Enabled = false;
            }
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            habilitarcontroles(); 
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.Trim() == "") 
            {
                MessageBox.Show("Debe Registrar Nombre de Tipo Zona.", "Registro Tipo Zona.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtCodSunat.Text.Trim() == "")
            {
                MessageBox.Show("Debe Registrar Codigo Sunat.", "Registro Tipo Zona.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }           
            
            if (lActualiza == false)
            {
                DataTable dtRegistraTipoZona = new DataTable();
                dtRegistraTipoZona = cnTipoZona.CNRegistraTipoZona(txtDescripcion.Text, txtCodSunat.Text, Convert.ToInt32(cboSector1.SelectedValue.ToString()));

                if (Convert.ToInt32(dtRegistraTipoZona.Rows[0]["idRpta"]) == 1)
                {
                    MessageBox.Show(dtRegistraTipoZona.Rows[0]["cMensage"].ToString(), "Registro Tipo Zona.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listarTipoZona();
                    deshabilitarcontroles();
                }
                else
                {
                    MessageBox.Show(dtRegistraTipoZona.Rows[0]["cMensage"].ToString(), "Registro Tipo Zona.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
            }
            else 
            {
                bool lVigente;
                if (rbtActivo.Checked == true)
                {
                    lVigente = true;
                }
                else
                {
                    lVigente = false;
                }

                DataTable dtActualizaTipoZona = new DataTable();
                dtActualizaTipoZona = cnTipoZona.CNActualizarTipoZona(Convert.ToInt32(txtId.Text), txtDescripcion.Text, txtCodSunat.Text, lVigente, Convert.ToInt32(cboSector1.SelectedValue.ToString()));
                if (Convert.ToInt32(dtActualizaTipoZona.Rows[0]["idRpta"]) == 1)
                {
                    MessageBox.Show(dtActualizaTipoZona.Rows[0]["cMensage"].ToString(), "Registro Tipo Zona.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listarTipoZona();
                }
                else
                {
                    MessageBox.Show(dtActualizaTipoZona.Rows[0]["cMensage"].ToString(), "Registro Tipo Zona.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                deshabilitarcontroles();
                rbtActivo.Enabled = false; rbtActivo.Checked = false;
                rbtnInactivo.Enabled = false; rbtnInactivo.Checked = false; 
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            deshabilitarcontroles();
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (dtgTipoZona.SelectedRows.Count == 0 || txtDescripcion.Text.Trim() == "") 
            {
                MessageBox.Show("Debe Seleccionar un registro.", "Editar Tipo Zona.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            habilitarcontrolesEditar();
            rbtActivo.Enabled = true;
            rbtnInactivo.Enabled = true;
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ' ')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            if (e.KeyChar == ' ')
            {
                TextBox textBox = (TextBox)sender;
                int selectionStart = textBox.SelectionStart;

                if (selectionStart > 0 && textBox.Text[selectionStart - 1] == ' ')
                {
                    e.Handled = true;
                }
            }

            if (e.KeyChar == '\n' || e.KeyChar == '\r')
            {
                TextBox textBox = (TextBox)sender;
                int currentLineIndex = textBox.GetLineFromCharIndex(textBox.SelectionStart);
                string currentLineText = textBox.Lines[currentLineIndex];

                if (string.IsNullOrWhiteSpace(currentLineText))
                {
                    e.Handled = true;
                }
            } 
        }

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            if (dtgTipoZona.SelectedRows.Count == 0 || txtDescripcion.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar un registro.", "Eliminar Tipo Zona", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult respMsg = MessageBox.Show("Desea eliminar Tipo Zona?", "Eliminar Tipo Zona", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (respMsg == DialogResult.Yes)
            {
                DataTable dtEliminaTipoZona = new DataTable();
                dtEliminaTipoZona = cnTipoZona.CNEliminarTipoZona(Convert.ToInt32(txtId.Text));
                if (dtEliminaTipoZona.Rows.Count > 0)
                {
                    MessageBox.Show(dtEliminaTipoZona.Rows[0]["cMensaje"].ToString(), "Eliminar Tipo Zona", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                listarTipoZona();
                deshabilitarcontroles();
            }
        }
    }
}
