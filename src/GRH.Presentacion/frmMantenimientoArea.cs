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

namespace GRH.Presentacion
{
    public partial class frmMantenimientoArea : frmBase
    {
        DataTable dtAreas;
        public string pcTipOpe = "N"; //Puede ser N --> Nuevo, A--> Actualizar
        clsCNMantAreas MantAreas = new clsCNMantAreas();
        
        public frmMantenimientoArea()
        {
            InitializeComponent();
        }

        private void frmMantenimientoArea_Load(object sender, EventArgs e)
        {            
            Limpiar();
            HabilitarControles(false);
            BuscarAreas();
        }
        private void BuscarAreas()
        {
            dtAreas = MantAreas.ListarAreas();
            if (dtgAreas.ColumnCount > 0)
            {
                dtgAreas.Columns.Remove("idArea");
                dtgAreas.Columns.Remove("cArea");
                dtgAreas.Columns.Remove("lVigente");
            }
            dtgAreas.DataSource = dtAreas.DefaultView;
            
            dtgAreas.Columns["idArea"].Visible = false;
            dtgAreas.Columns["cArea"].Width = 60;
            dtgAreas.Columns["cArea"].HeaderText = "Nombre del Área";
            dtgAreas.Columns["cArea"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgAreas.Columns["lVigente"].Width = 60;
            dtgAreas.Columns["lVigente"].HeaderText = "Vig.";
            dtgAreas.Columns["lVigente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void Limpiar()
        {
            this.txtNomArea.Clear();           
            this.CBVigente.Checked = false;
        }
        private void HabilitarControles(Boolean Val)
        {
            this.txtNomArea.Enabled = Val;           
            this.CBVigente.Enabled = Val;
        }
        private string ValidarDatos()
        {
            if (txtNomArea.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre del Área", "Mantenimiento de Áreas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNomArea.Focus();
                return "ERROR";
            }
           

            if (pcTipOpe == "N")
            {
                for (int i = 0; i < dtgAreas.Rows.Count; i++)
                {
                    if (Convert.ToString(dtgAreas.Rows[i].Cells["cArea"].Value) == txtNomArea.Text.Trim())
                    {
                        MessageBox.Show("Ya existe un Área con ese nombre. Verifique", "Mantenimiento de Áreas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNomArea.Focus();
                        return "ERROR";
                    }
                }
            }

            if (pcTipOpe == "A")
            {
                //int filaseleccionada = Convert.ToInt32(this.dtgAreas.CurrentRow.Index);
                int filaseleccionada = Convert.ToInt32(this.dtgAreas.SelectedCells[0].RowIndex);

                for (int i = 0; i < dtgAreas.Rows.Count; i++)
                {
                    if (filaseleccionada != i)
                    {
                        if (Convert.ToString(dtgAreas.Rows[i].Cells["cArea"].Value) == txtNomArea.Text.Trim())
                        {
                            MessageBox.Show("Ya existe un Área con ese nombre. Verifique", "Mantenimiento de Áreas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNomArea.Focus();
                            return "ERROR";
                        }
                    }
                }
            }

            return "OK";
        }
        private void MostrarDatos()
        {
            if (dtgAreas.SelectedRows.Count > 0)
            {               
                int filaseleccionada = Convert.ToInt32(dtgAreas.SelectedCells[1].RowIndex);

                this.txtNomArea.Text = Convert.ToString(this.dtgAreas.Rows[filaseleccionada].Cells["cArea"].Value);
                this.CBVigente.Checked = Convert.ToBoolean(this.dtgAreas.Rows[filaseleccionada].Cells["lVigente"].Value);

                HabilitarControles(false);
                pcTipOpe = "A";
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            pcTipOpe = "N";
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
            Limpiar();
            HabilitarControles(true);

            CBVigente.Checked = true;
            CBVigente.Enabled = false;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            pcTipOpe = "A";
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
            HabilitarControles(true);     
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos() == "ERROR")
            {
                return;
            }
            string cNomArea = txtNomArea.Text.Trim();           
            int lVigente = Convert.ToInt32(CBVigente.Checked);

            if (pcTipOpe == "A")
            {
                //int filaseleccionada = Convert.ToInt32(this.dtgAreas.CurrentRow.Index);
                int filaseleccionada = Convert.ToInt32(this.dtgAreas.SelectedCells[0].RowIndex);
                int idArea = Convert.ToInt32(dtgAreas.Rows[filaseleccionada].Cells["idArea"].Value);

                MantAreas.ActualizarAreas(idArea, cNomArea, lVigente);
                MessageBox.Show("Se han actualizado correctamente los Datos ", "Mantenimiento de Áreas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                //cargar de nuevo y seleccionar la primera de todos los registros que fueroon modificados
                BuscarAreas();
                int n = 0;
                foreach (DataGridViewRow fila in dtgAreas.Rows)
                {
                    n += 1;
                    if (Convert.ToInt32(fila.Cells["idArea"].Value) == idArea)
                    {
                        dtgAreas.CurrentCell = dtgAreas.Rows[n - 1].Cells[1];
                        MostrarDatos();
                    }
                }
            }

            else if (pcTipOpe == "N")
            {
                int NuevoId = MantAreas.GuardarAreas(cNomArea, lVigente);
                MessageBox.Show("Se han Registrado los Datos Correctamente", "Mantenimiento de Áreas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //cargar de nuevo y seleccionar el registros con la tasa recien añadida

                BuscarAreas();
                int n = 0;
                foreach (DataGridViewRow fila in dtgAreas.Rows)
                {
                    n += 1;
                    if (Convert.ToInt32(fila.Cells["idArea"].Value) == NuevoId)
                    {
                        dtgAreas.CurrentCell = dtgAreas.Rows[n - 1].Cells[1];
                        MostrarDatos();
                    }
                }

                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarControles(false);
            MostrarDatos();
        }
        
        private void dtgAreas_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        
    }
}
