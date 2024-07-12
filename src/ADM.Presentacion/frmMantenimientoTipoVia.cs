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
    public partial class frmMantenimientoTipoVia : frmBase
    {
        clsCNRegionZona cnTipoVia = new clsCNRegionZona();
        int nfilas_dtg;
        int nfila_actu;
        bool lActualiza = false;

        public frmMantenimientoTipoVia()
        {
            InitializeComponent();
        }

        private void frmMantenimientoTipoVia_Load(object sender, EventArgs e)
        {
            listarTipoVia();
        }

        private void listarTipoVia()
        {
            DataTable dtTipoVia = new DataTable();
            dtTipoVia = cnTipoVia.CNListarTipoVia();
            dtgTipoVia.DataSource = dtTipoVia;
            dtgTipoVia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dtgTipoVia.Columns["Orden"].Width = 40;
            dtgTipoVia.Columns["Via"].Width = 250;
            dtgTipoVia.Columns["idTipoVia"].Visible = false;
            dtgTipoVia.Columns["cCodSunat"].Visible = false;
            dtgTipoVia.Columns["Via"].HeaderText = "Vía";
            dtgTipoVia.Columns["lVigente"].HeaderText = "Vigencia";
            dtgTipoVia.ClearSelection();

            nfilas_dtg = dtTipoVia.Rows.Count;
        }

        private void habilitarcontrolesEditar()
        {
            btnGrabar1.Enabled = true;
            btnCancelar1.Enabled = true;
            txtDescripcion.Enabled = true;
            txtCodSunat.Enabled = true;
            btnEditar1.Enabled = false;
            btnEliminar1.Enabled = false;
            btnNuevo1.Enabled = false;
            btnBajar.Enabled = false;
            btnSubir.Enabled = false;
            dtgTipoVia.Enabled = false;
            lActualiza = true;
        }

        private void habilitarcontroles()
        {
            rbtActivo.Checked = true;
            btnGrabar1.Enabled = true;
            btnCancelar1.Enabled = true;
            txtDescripcion.Enabled = true;
            txtCodSunat.Enabled = true;
            btnEditar1.Enabled = false;
            btnEliminar1.Enabled = false;
            btnNuevo1.Enabled = false;
            btnBajar.Enabled = false;
            btnSubir.Enabled = false;
            dtgTipoVia.Enabled = false;
            txtId.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            txtCodSunat.Text = "12";
            dtgTipoVia.ClearSelection();
        }

        private void deshabilitarcontroles()
        {
            rbtActivo.Checked = false;
            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = false;
            txtDescripcion.Enabled = false;
            txtCodSunat.Enabled = false;
            btnEditar1.Enabled = true;
            btnEliminar1.Enabled = true;
            btnNuevo1.Enabled = true;
            btnBajar.Enabled = true;
            btnSubir.Enabled = true;
            dtgTipoVia.Enabled = true;
            rbtActivo.Enabled = false; rbtActivo.Checked = false;
            rbtnInactivo.Enabled = false; rbtnInactivo.Checked = false;
            txtId.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            txtCodSunat.Text = String.Empty;
            dtgTipoVia.ClearSelection();
            lActualiza = false;
        }

        private void dtgTipoVia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSubir.Enabled = true; 
            btnBajar.Enabled = true;
            nfila_actu = Convert.ToInt32(dtgTipoVia.CurrentRow.Index);
            if (Convert.ToInt32(dtgTipoVia.CurrentRow.Cells[0].Value) == 1)
            {
                btnSubir.Enabled = false; btnBajar.Enabled = true;
            }
            if (Convert.ToInt32(dtgTipoVia.CurrentRow.Cells[0].Value) == nfilas_dtg)
            {
                btnSubir.Enabled = true; btnBajar.Enabled = false;
            }

            txtId.Text = Convert.ToString(dtgTipoVia.CurrentRow.Cells[3].Value);
            txtDescripcion.Text = Convert.ToString(dtgTipoVia.CurrentRow.Cells[1].Value);
            txtCodSunat.Text = Convert.ToString(dtgTipoVia.CurrentRow.Cells[4].Value);
            if (Convert.ToBoolean(dtgTipoVia.CurrentRow.Cells[2].Value) == true)
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
            Font myFont = new System.Drawing.Font(dtgTipoVia.Font, FontStyle.Bold);
            dtCambiaOrden = cnTipoVia.CNCambiaOrdenAscTipoVia(Convert.ToInt32(dtgTipoVia.Rows[nfila_actu].Cells[0].Value));
            listarTipoVia();
            dtgTipoVia.Rows[nfila_actu - 1].Cells["Via"].Style.Font = myFont;
            dtgTipoVia.Rows[nfila_actu - 1].Cells["Orden"].Style.Font = myFont;
            dtgTipoVia.Rows[nfila_actu - 1].Cells["lVigente"].Style.Font = myFont;
            txtId.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            txtCodSunat.Text = String.Empty;

            dtgTipoVia.Rows[nfila_actu - 1].Selected = true;

            nfila_actu = nfila_actu - 1;

            if (nfila_actu == 0)
            {
                btnSubir.Enabled = false; btnBajar.Enabled = true;
            }
            if (nfila_actu == nfilas_dtg - 1)
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
            Font myFont = new System.Drawing.Font(dtgTipoVia.Font, FontStyle.Bold);
            dtCambiaOrden = cnTipoVia.CNCambiaOrdenDescTipoVia(Convert.ToInt32(dtgTipoVia.Rows[nfila_actu].Cells[0].Value));
            listarTipoVia();
            dtgTipoVia.Rows[nfila_actu + 1].Cells["Via"].Style.Font = myFont;
            dtgTipoVia.Rows[nfila_actu + 1].Cells["Orden"].Style.Font = myFont;
            dtgTipoVia.Rows[nfila_actu + 1].Cells["lVigente"].Style.Font = myFont;
            txtId.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            txtCodSunat.Text = String.Empty;

            dtgTipoVia.Rows[nfila_actu + 1].Selected = true;

            nfila_actu = nfila_actu + 1;

            if (nfila_actu == 0)
            {
                btnSubir.Enabled = false; btnBajar.Enabled = true;
            }
            if (nfila_actu == nfilas_dtg - 1)
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
                MessageBox.Show("Debe Registrar Nombre de Tipo Vía.", "Registro Tipo Vía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtCodSunat.Text.Trim() == "")
            {
                MessageBox.Show("Debe Registrar Código Sunat.", "Registro Tipo Vía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (lActualiza == false)
            {
                DataTable dtRegistraTipoVia = new DataTable();
                dtRegistraTipoVia = cnTipoVia.CNRegistraTipoVia(txtDescripcion.Text, txtCodSunat.Text);

                if (Convert.ToInt32(dtRegistraTipoVia.Rows[0]["idRpta"]) == 1)
                {
                    MessageBox.Show(dtRegistraTipoVia.Rows[0]["cMensage"].ToString(), "Registro Tipo Vía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listarTipoVia();
                    deshabilitarcontroles();
                }
                else
                {
                    MessageBox.Show(dtRegistraTipoVia.Rows[0]["cMensage"].ToString(), "Registro Tipo Vía", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                DataTable dtActualizaTipoVia = new DataTable();
                dtActualizaTipoVia = cnTipoVia.CNActualizarTipoVia(Convert.ToInt32(txtId.Text), txtDescripcion.Text, txtCodSunat.Text, lVigente);
                if (Convert.ToInt32(dtActualizaTipoVia.Rows[0]["idRpta"]) == 1)
                {
                    MessageBox.Show(dtActualizaTipoVia.Rows[0]["cMensage"].ToString(), "Registro Tipo Vía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listarTipoVia();
                }
                else
                {
                    MessageBox.Show(dtActualizaTipoVia.Rows[0]["cMensage"].ToString(), "Registro Tipo Vía", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (dtgTipoVia.SelectedRows.Count == 0 || txtDescripcion.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar un registro.", "Editar Tipo Vía", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (dtgTipoVia.SelectedRows.Count == 0 || txtDescripcion.Text.Trim() == "")
            {
                MessageBox.Show("Debe Seleccionar un registro.", "Eliminar Tipo Vía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult respMsg = MessageBox.Show("Desea eliminar Tipo Vía?", "Eliminar Tipo Vía", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (respMsg == DialogResult.Yes)
            {
                DataTable dtEliminaTipoVia = new DataTable();
                dtEliminaTipoVia = cnTipoVia.CNEliminarTipoVia(Convert.ToInt32(txtId.Text));
                if (dtEliminaTipoVia.Rows.Count > 0)
                {
                    MessageBox.Show(dtEliminaTipoVia.Rows[0]["cMensaje"].ToString(), "Eliminar Tipo Vía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                listarTipoVia();
                deshabilitarcontroles();
            } 
        }
    }
}
