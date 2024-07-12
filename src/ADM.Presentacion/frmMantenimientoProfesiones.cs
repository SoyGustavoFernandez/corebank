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
using GEN.CapaNegocio;

namespace ADM.Presentacion
{
    public partial class frmMantenimientoProfesiones : frmBase
    {
        private clsCNProfesion Profesion = new clsCNProfesion();
        private DataTable dtProfesion = new DataTable();
        int idProfesion = 0;
        string cOpcion = "O";
        public frmMantenimientoProfesiones()
        {
            InitializeComponent();
        }

        private void frmMantenimientoProfesiones_Load(object sender, EventArgs e)
        {
            ListaEntidadReg();
        }
        private void ListaEntidadReg()
        {
            DataTable dtEntidadReg = Profesion.CNListaEntidadReg();
            cboEntidadReg.DataSource = dtEntidadReg;
            cboEntidadReg.DisplayMember = dtEntidadReg.Columns["cNombreCorto"].ToString();
            cboEntidadReg.ValueMember = dtEntidadReg.Columns["idEntidadReg"].ToString();
            txtCodSunat.Enabled = false;
            txtCodSBS.Enabled = false;
            
            cboEntidadReg.SelectedValue = 0;
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            //cboEntidadReg.SelectedIndex = 0;
            cOpcion = "N";
            idProfesion = 0;
            Limpiar();
            
            Habilitar(true);
            

            chcVigente.Enabled = false;
            chcVigente.Checked = true;
            btnNuevo1.Enabled = false;
            btnEditar1.Enabled = false;
            btnGrabar1.Enabled = true;
            btnCancelar1.Enabled = true;
            cboEntidadReg.Enabled = false;
            dtgProfesion.Enabled = false;

            txtProfesion.Text = "";
            txtCodSunat.Enabled = false;
            txtCodSBS.Enabled = false;
            txtCodSunat.Text = "99";
            txtCodSBS.Text = "999";
            txtProfesion.Focus();
            chcAplicaSunat.Checked = false;
            chcAplicaSBS.Checked = false;
        }
        private void Habilitar(bool val)
        {
            txtProfesion.Enabled = val;
            txtCodSBS.Enabled = val;
            txtCodSunat.Enabled = val;
            chcAplicaSBS.Enabled = val;
            chcAplicaSunat.Enabled = val;
            
            chcVigente.Enabled = val;
        }

        private void chcAplicaSunat_CheckedChanged(object sender, EventArgs e)
        {
            if (chcAplicaSunat.Checked == true && cOpcion!="O")
            {
                txtCodSunat.Enabled = true;
            }
            else
            {
                txtCodSunat.Enabled = false;
                
            }
        }

        private void chcAplicaSBS_CheckedChanged(object sender, EventArgs e)
        {
            if (chcAplicaSBS.Checked == true && cOpcion != "O")
            {
                txtCodSBS.Enabled = true;
            }
            else
            {
                txtCodSBS.Enabled = false;
                
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            cOpcion = "O";
            idProfesion = 0;
            btnGrabar1.Enabled = false;
            btnNuevo1.Enabled = true;
            btnCancelar1.Enabled = false;
            
            cboEntidadReg.SelectedIndex = 3;
            Habilitar(false);
            dtgProfesion.Enabled = true;
            cboEntidadReg.Enabled = true;
            cargarProfesion(dtgProfesion.CurrentRow.Index);
            btnEditar1.Enabled = true;
        }
        private void Limpiar()
        {
            
            chcAplicaSBS.Checked = false;
            chcAplicaSunat.Checked = false;
            chcVigente.Checked = false;
        }

        private void cboEntidadReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            cOpcion = "O";
            Limpiar();
            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = false;
            btnNuevo1.Enabled = true;
            Habilitar(false);
            if (cboEntidadReg.SelectedIndex>0)
            {
                int idEntidad = Convert.ToInt32(cboEntidadReg.SelectedValue);
                dtProfesion = Profesion.CNListaProfesionByEntidad(idEntidad);
                dtgProfesion.DataSource = dtProfesion;
                FormatoGrid();
                btnEditar1.Enabled = true;
            }
            else
            {
                dtgProfesion.DataSource = "";
            }
            
        }
        private void FormatoGrid()
        {
            dtgProfesion.Columns["lVigente"].Visible = false;
            dtgProfesion.Columns["lAplicaSunat"].Visible = false;
            dtgProfesion.Columns["lAplicaSBS"].Visible = false;

            dtgProfesion.Columns["idProfesion"].Width = 20;
            dtgProfesion.Columns["cProfesion"].Width = 100;
            dtgProfesion.Columns["cCodSunat"].Width = 30;
            dtgProfesion.Columns["cCodSBS"].Width = 30;

            dtgProfesion.Columns["idProfesion"].HeaderText = "Cod.";
            dtgProfesion.Columns["cProfesion"].HeaderText = "Profesión u Ocupación";
            dtgProfesion.Columns["cCodSunat"].HeaderText = "Cod.Sunat";
            dtgProfesion.Columns["cCodSBS"].HeaderText = "Cod.Sbs";
        }

        private void dtgProfesion_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgProfesion.Rows.Count>0)
            {
                cargarProfesion(e.RowIndex);
            }
        }
        private void cargarProfesion(int nIndex)
        {
            int nFila = nIndex;
            txtProfesion.Text = dtProfesion.Rows[nFila]["cProfesion"].ToString();
            txtCodSBS.Text = dtProfesion.Rows[nFila]["cCodSBS"].ToString();
            txtCodSunat.Text = dtProfesion.Rows[nFila]["cCodSunat"].ToString();
            chcAplicaSBS.Checked = Convert.ToBoolean(dtProfesion.Rows[nFila]["lAplicaSBS"].ToString());
            chcAplicaSunat.Checked = Convert.ToBoolean(dtProfesion.Rows[nFila]["lAplicaSunat"].ToString());
            chcVigente.Checked = Convert.ToBoolean(dtProfesion.Rows[nFila]["lVigente"].ToString());
            idProfesion = Convert.ToInt32(dtProfesion.Rows[nFila]["idProfesion"].ToString());
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            //VALIDAR DATOS DE REGISTRO
            //============================
            if (string.IsNullOrEmpty(txtProfesion.Text) )
	        {
                MessageBox.Show("Registre el nombre de la profesión", "Registro de Profesiones u ocupaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
	        }
            if (string.IsNullOrEmpty(txtCodSunat.Text) && chcAplicaSunat.Checked == true && txtCodSunat.Text.ToString().Length < 3)
	        {
                MessageBox.Show("Registre un valor válido para el código de SUNAT de 3 caracteres", "Registro de Profesiones u ocupaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
	        }
            if (string.IsNullOrEmpty(txtCodSBS.Text) && chcAplicaSBS.Checked == true && txtCodSBS.Text.ToString().Length < 3)
	        {
                MessageBox.Show("Registre un valor válido para el código de SBS de 3 caracteres", "Registro de Profesiones u ocupaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
	        }

            string cProfesion = txtProfesion.Text;
            string cCodSBS = txtCodSBS.Text.Trim();
            string cCodSUNAT = txtCodSunat.Text.Trim();
            bool lAplicaSBS = chcAplicaSBS.Checked;
            bool lAplicaSunat = chcAplicaSunat.Checked;
            bool lVigente = chcVigente.Checked;
            //VALIDA SI YA EXISTE EL REGISTRO
            DataTable dtValida = Profesion.CNValidaregProfesion(cProfesion);
            if (cOpcion == "N" &&Convert.ToInt32(dtValida.Rows[0]["Rpta"])>0)
            {
                MessageBox.Show(dtValida.Rows[0]["cMensaje"].ToString(), "Registro de Profesiones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //GRABAR
            //============================
            DataTable dtProfesion = Profesion.CNGrabaProfesion(idProfesion, cProfesion, cCodSUNAT, cCodSBS, lAplicaSunat, lAplicaSBS, lVigente);
            if (Convert.ToInt32(dtProfesion.Rows[0]["nRpta"])>0)
	        {
                MessageBox.Show("Los cambios se guardaron correctamente", "Registro de profesiones u ocupaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaEntidadReg();
	        }
            else
            {
                MessageBox.Show("Error al momento de grabar. Verifique", "Registro de profesiones u ocupaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Habilitar(false);
            cboEntidadReg.Enabled = true;
            dtgProfesion.Enabled = true;
            btnGrabar1.Enabled = false;
            cboEntidadReg.SelectedIndex = 3;
            btnEditar1.Enabled = true;
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            cOpcion = "A";
            btnGrabar1.Enabled = true;
            btnNuevo1.Enabled = false;
            btnCancelar1.Enabled = true;
            cboEntidadReg.Enabled = false;
            dtgProfesion.Enabled = false;
            Habilitar(true);
            btnEditar1.Enabled = false;
            if (chcAplicaSBS.Checked)
                txtCodSBS.Enabled = true;
            else
                txtCodSBS.Enabled = false;

            if (chcAplicaSunat.Checked)
                txtCodSunat.Enabled = true;
            else
                txtCodSunat.Enabled = false;
        }
    }
}
