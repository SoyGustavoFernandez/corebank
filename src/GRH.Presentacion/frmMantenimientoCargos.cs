using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GEN.CapaNegocio;
using GRH.CapaNegocio;
using EntityLayer;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace GRH.Presentacion
{
    public partial class frmMantenimientoCargos : frmBase
    {
        DataTable dtCargos;
        public string pcTipOpe = "N"; //Puede ser N --> Nuevo, A--> Actualizar
        clsCNMantCargos MantCargos = new clsCNMantCargos();

        public frmMantenimientoCargos()
        {
            InitializeComponent();
        }

        private void frmMantenimientoCargos_Load(object sender, EventArgs e)
        {
            cboArea1.CargarTodasArea();
            CargarcboTipoCargo();
            Limpiar();
            HabilitarControles(false);
            BuscarCargos();
        }

        private void CargarcboTipoCargo()
        {
            DataTable dt = new clsCNMantCargos().ListarTipoCargo();
            cboTipoCargo.DataSource = dt;
            cboTipoCargo.ValueMember = dt.Columns[0].ToString();
            cboTipoCargo.DisplayMember = dt.Columns[1].ToString();           
        }

        private void BuscarCargos()
        {
            dtCargos = MantCargos.ListarCargos();

            if (dtgCargos.ColumnCount > 0)
            {                
                dtgCargos.Columns.Remove("cCargo");
                dtgCargos.Columns.Remove("idCargo");
                dtgCargos.Columns.Remove("nPorcenLibreVia");
                dtgCargos.Columns.Remove("cArea");
                dtgCargos.Columns.Remove("lVigente");
                dtgCargos.Columns.Remove("idArea");
                dtgCargos.Columns.Remove("idNivel");
                dtgCargos.Columns.Remove("idTipoCargo");
                
            }
            dtgCargos.DataSource = dtCargos.DefaultView;

            dtgCargos.Columns["cCargo"].Width = 60;
            dtgCargos.Columns["cCargo"].HeaderText = "Nombre del Cargo";
            dtgCargos.Columns["cCargo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgCargos.Columns["idCargo"].Visible = false;
            dtgCargos.Columns["nPorcenLibreVia"].Visible = false;
            
            dtgCargos.Columns["cArea"].Width = 40;
            dtgCargos.Columns["cArea"].HeaderText = "Área";
            dtgCargos.Columns["cArea"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dtgCargos.Columns["lVigente"].Width = 10;
            dtgCargos.Columns["lVigente"].HeaderText = "Vig.";
            dtgCargos.Columns["lVigente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dtgCargos.Columns["idArea"].Visible = false;
            dtgCargos.Columns["idNivel"].Visible = false;
            dtgCargos.Columns["idTipoCargo"].Visible = false;
            dtgCargos.Columns["cGrupoCorreoB"].Visible = false;

            if (dtgCargos.Rows.Count == 0) {
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        private void Limpiar()
        {
            this.txtNombCargo.Clear();
            this.cboArea1.SelectedIndex = -1;
            this.cboNivelPersonal1.SelectedIndex = -1;
            this.txtPorcentaje.Clear();
            this.CBVigente.Checked = false;
            this.cboTipoCargo.SelectedIndex = -1;
            this.txtCorreoB.Clear();
        }

        private void HabilitarControles(Boolean Val)
        {
            this.txtNombCargo.Enabled = Val;
            this.cboArea1.Enabled = Val;
            this.cboNivelPersonal1.Enabled = Val;
            this.txtPorcentaje.Enabled = Val;
            this.CBVigente.Enabled = Val;
            this.cboTipoCargo.Enabled = Val;
            this.txtCorreoB.Enabled = Val;

            this.btnNuevo.Enabled = !Val;
            if (dtgCargos.RowCount > 0)
            {
                this.btnEditar.Enabled = !Val;
            }
            else
            {
                this.btnEditar.Enabled = false;
            }
            this.btnGrabar.Enabled = Val;
            this.btnCancelar.Enabled = Val;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            pcTipOpe = "N";
            Limpiar();
            HabilitarControles(true);

            CBVigente.Checked = true;
            CBVigente.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            pcTipOpe = "A";
            HabilitarControles(true);     
        }

        public bool validarCorreos(string cCorreos)
        {
            string[] aCorreos = cCorreos.Split(';');
            foreach (string cCorreo in aCorreos)
            {
                if (cCorreo.Trim() != "")
                {
                    Regex regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match matchEmail = regexEmail.Match(cCorreo.Trim());
                    if (!matchEmail.Success)
                        return false;
                }
            }
            return true;
        }

        private string ValidarDatos()
        {
            if (txtNombCargo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre del Cargo", "Mantenimiento de Cargos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombCargo.Focus();
                return "ERROR";
            }
            if (cboArea1.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el Área", "Mantenimiento de Cargos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboArea1.Focus();
                return "ERROR";
            }
            if (cboNivelPersonal1.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el Nivel", "Mantenimiento de Cargos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboNivelPersonal1.Focus();
                return "ERROR";
            }
            if (cboTipoCargo.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el Tipo de Cargo", "Mantenimiento de Cargos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoCargo.Focus();
                return "ERROR";
            }
            if (txtPorcentaje.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el porcentaje para los Viáticos", "Mantenimiento de Cargos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPorcentaje.Focus();
                return "ERROR";
            }
            if (!this.validarCorreos(txtCorreoB.Text.Trim()))
            {
                MessageBox.Show("Ingrese los grupos de correos institucionales válidos.\nEjemplos:\n* ejemplo@cajalosandes.pe\n* ejemplo@cajalosandes.pe;otro@cajalosandes.pe", "Mantenimiento de Cargos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCorreoB.Focus();
                return "ERROR";
            }

            if (pcTipOpe == "N")
            {
                for (int i = 0; i < dtgCargos.Rows.Count; i++)
                {
                    if (Convert.ToString(dtgCargos.Rows[i].Cells["cCargo"].Value) == txtNombCargo.Text.Trim())
                    {
                        MessageBox.Show("Ya existe un Cargo con ese nombre. Verifique", "Mantenimiento de Cargos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNombCargo.Focus();
                        return "ERROR";
                    }
                }
            }

            if (pcTipOpe == "A")
            {
                int filaseleccionada = Convert.ToInt32(this.dtgCargos.CurrentRow.Index);

                for (int i = 0; i < dtgCargos.Rows.Count; i++)
                {
                    if (filaseleccionada != i)
                    {
                        if (Convert.ToString(dtgCargos.Rows[i].Cells["cCargo"].Value) == txtNombCargo.Text.Trim())
                        {
                            MessageBox.Show("Ya existe un Cargo con ese nombre. Verifique", "Mantenimiento de Cargos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNombCargo.Focus();
                            return "ERROR";
                        }
                    }
                }
            }

            return "OK";
        }

        private void MostrarDatos()
        {
            if (dtgCargos.SelectedRows.Count > 0)
            {
                int filaseleccionada = Convert.ToInt32(this.dtgCargos.CurrentRow.Index);

                this.txtNombCargo.Text = Convert.ToString(this.dtgCargos.Rows[filaseleccionada].Cells["cCargo"].Value);
                this.cboArea1.SelectedValue = Convert.ToInt32(this.dtgCargos.Rows[filaseleccionada].Cells["idArea"].Value);
                this.cboNivelPersonal1.SelectedValue = Convert.ToInt32(this.dtgCargos.Rows[filaseleccionada].Cells["idNivel"].Value.ToString());
                this.cboTipoCargo.SelectedValue = Convert.ToInt32(this.dtgCargos.Rows[filaseleccionada].Cells["idTipoCargo"].Value.ToString());
                this.txtPorcentaje.Text = Convert.ToString(this.dtgCargos.Rows[filaseleccionada].Cells["nPorcenLibreVia"].Value);
                this.CBVigente.Checked = Convert.ToBoolean(this.dtgCargos.Rows[filaseleccionada].Cells["lVigente"].Value);
                this.txtCorreoB.Text = this.dtgCargos.Rows[filaseleccionada].Cells["cGrupoCorreoB"].Value.ToString();
           
                HabilitarControles(false);
                pcTipOpe = "A";
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = true;             
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
            else
            {
                Limpiar();
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos() == "ERROR")
            {
                return;
            }

            string NombCargo = txtNombCargo.Text.Trim();
            string GrupoCorreoB = this.txtCorreoB.Text.Trim();
            int idArea = Convert.ToInt32(cboArea1.SelectedValue);
            int idNivelPersonal = Convert.ToInt32(cboNivelPersonal1.SelectedValue);
            int idTipoCargo = Convert.ToInt32(cboTipoCargo.SelectedValue);
            int nPorcentaje = Convert.ToInt32(txtPorcentaje.Text);
            int lVigente = Convert.ToInt32(CBVigente.Checked);

            if (pcTipOpe == "A")
            {
                int filaseleccionada = Convert.ToInt32(this.dtgCargos.CurrentRow.Index);
                int idCargo = Convert.ToInt32(dtgCargos.Rows[filaseleccionada].Cells["idCargo"].Value);

                MantCargos.ActualizarCargos(idCargo, NombCargo, idArea, idNivelPersonal, idTipoCargo, nPorcentaje, lVigente, GrupoCorreoB);
                MessageBox.Show("Se han actualizado correctamente los Datos ", "Mantenimiento de Cargos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BuscarCargos();
                int n = 0;
                foreach (DataGridViewRow fila in dtgCargos.Rows)
                {
                    n += 1;
                    if (Convert.ToInt32(fila.Cells["idCargo"].Value) == idCargo)
                    {
                        dtgCargos.CurrentCell = dtgCargos.Rows[n - 1].Cells[0];
                        MostrarDatos();
                    }
                }
            }

            else if (pcTipOpe == "N")
            {
                int NuevoId = MantCargos.GuardarCargos(NombCargo, idArea, idNivelPersonal,idTipoCargo, nPorcentaje, lVigente, GrupoCorreoB);
                MessageBox.Show("Se han Registrado los Datos Correctamente", "Mantenimiento de Cargos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //cargar de nuevo y seleccionar el registros con la tasa recien añadida

                BuscarCargos();
                int n = 0;
                foreach (DataGridViewRow fila in dtgCargos.Rows)
                {
                    n += 1;
                    if (Convert.ToInt32(fila.Cells["idCargo"].Value) == NuevoId)
                    {
                        dtgCargos.CurrentCell = dtgCargos.Rows[n - 1].Cells[0];
                        MostrarDatos();
                    }
                }
            }

            HabilitarControles(false);
        }

        private void dtgCargos_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarControles(false);
            MostrarDatos();
        }
    }
}
