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
    public partial class frmMantRegimenPensionario : frmBase
    {
        DataTable dtRegimen;
        public string pcTipOpe = "N"; //Puede ser N --> Nuevo, A--> Actualizar
        clsCNMantRegimen MantRegimen = new clsCNMantRegimen();

        public frmMantRegimenPensionario()
        {
            InitializeComponent();
        }

        private void frmMantRegimenPensionario_Load(object sender, EventArgs e)
        {
            Limpiar();
            HabilitarControles(false);
            BuscarRegimen();
        }
        private void BuscarRegimen()
        {
            dtRegimen = MantRegimen.ListarRegimen();

            if (dtgRegimen.ColumnCount > 0)
            {
                dtgRegimen.Columns.Remove("idRegimen");
                dtgRegimen.Columns.Remove("cRegimen");
                dtgRegimen.Columns.Remove("idTipoRegimen");
                dtgRegimen.Columns.Remove("cTipoRegimen");
                dtgRegimen.Columns.Remove("nPorcentSNP");
                dtgRegimen.Columns.Remove("nPorcentVarFlujoSPP");
                dtgRegimen.Columns.Remove("nPorcentVarMixtaSPP");
                dtgRegimen.Columns.Remove("nPorcentSeguroSPP");
                dtgRegimen.Columns.Remove("nPorcentAporteSPP");
                dtgRegimen.Columns.Remove("lVigente");
            }
            dtgRegimen.DataSource = dtRegimen.DefaultView;

            dtgRegimen.Columns["idRegimen"].Visible = false;

            dtgRegimen.Columns["cRegimen"].Width = 60;
            dtgRegimen.Columns["cRegimen"].HeaderText = "Régimen";
            dtgRegimen.Columns["cRegimen"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgRegimen.Columns["idTipoRegimen"].Visible = false;

            dtgRegimen.Columns["cTipoRegimen"].Width = 40;
            dtgRegimen.Columns["cTipoRegimen"].HeaderText = "Tipo de Régimen";
            dtgRegimen.Columns["cTipoRegimen"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgRegimen.Columns["nPorcentSNP"].Visible = false;
            dtgRegimen.Columns["nPorcentVarFlujoSPP"].Visible = false;
            dtgRegimen.Columns["nPorcentVarMixtaSPP"].Visible = false;
            dtgRegimen.Columns["nPorcentSeguroSPP"].Visible = false;
            dtgRegimen.Columns["nPorcentAporteSPP"].Visible = false;
            
            dtgRegimen.Columns["lVigente"].Width = 65;
            dtgRegimen.Columns["lVigente"].HeaderText = "Vig";
            dtgRegimen.Columns["lVigente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void Limpiar()
        {
            this.txtNomRegimen.Clear();
            this.cboTipoRegimenPens1.SelectedValue = 0;
            this.txtPorcSNP.Clear();
            this.txtPorcFlujoSPP.Clear();
            this.txtPorcMixtaSPP.Clear();
            this.txtPorcSeguroSPP.Clear();
            this.txtPorcAporteSPP.Clear();
            this.CBVigente.Checked = false;
        }

        private void HabilitarControles(Boolean Val)
        {            
            this.txtNomRegimen.Enabled = Val;
            this.cboTipoRegimenPens1.Enabled = Val;
            this.txtPorcSNP.Enabled = Val;
            this.txtPorcFlujoSPP.Enabled = Val;
            this.txtPorcMixtaSPP.Enabled = Val;
            this.txtPorcSeguroSPP.Enabled = Val;
            this.txtPorcAporteSPP.Enabled = Val;
            this.CBVigente.Enabled = Val;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            pcTipOpe = "N";
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;           
            this.btnCancelar1.Enabled = true;
            Limpiar();
            HabilitarControles(true);
            this.CBVigente.Enabled = false;
            this.CBVigente.Checked = true;

            this.txtPorcSNP.Enabled = false;
            this.txtPorcFlujoSPP.Enabled = false;
            this.txtPorcMixtaSPP.Enabled = false;
            this.txtPorcSeguroSPP.Enabled = false;
            this.txtPorcAporteSPP.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            pcTipOpe = "A";
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;          
            this.btnCancelar1.Enabled = true;
            HabilitarControles(true);

            if (Convert.ToInt32(cboTipoRegimenPens1.SelectedValue) == 1)
            {
                this.txtPorcSNP.Enabled = true;
                this.txtPorcFlujoSPP.Enabled = false;
                this.txtPorcMixtaSPP.Enabled = false;
                this.txtPorcSeguroSPP.Enabled = false;
                this.txtPorcAporteSPP.Enabled = false;
            }
            if (Convert.ToInt32(cboTipoRegimenPens1.SelectedValue) == 2)
            {
                this.txtPorcSNP.Enabled = false;
                this.txtPorcFlujoSPP.Enabled = true;
                this.txtPorcMixtaSPP.Enabled = true;
                this.txtPorcSeguroSPP.Enabled = true;
                this.txtPorcAporteSPP.Enabled = true;
            }
            if (Convert.ToInt32(cboTipoRegimenPens1.SelectedValue) >= 3)
            {
                this.txtPorcSNP.Enabled = false;
                this.txtPorcFlujoSPP.Enabled = false;
                this.txtPorcMixtaSPP.Enabled = false;
                this.txtPorcSeguroSPP.Enabled = false;
                this.txtPorcAporteSPP.Enabled = false;
            }

        }

        private string ValidarDatos()
        {
            if (txtNomRegimen.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre del Régimen Pensionario", "Mantenimiento de Régimen Pensionario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNomRegimen.Focus();
                return "ERROR";
            }
            if (cboTipoRegimenPens1.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el Tipo de Régimen Pensionario", "Mantenimiento de Régimen Pensionario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoRegimenPens1.Focus();
                return "ERROR";
            }
            if (Convert.ToInt32(cboTipoRegimenPens1.SelectedValue) >= 3 && pcTipOpe == "N")
            {
                MessageBox.Show("El tipo de Régimen es Inválido, Por favor elija otro", "Mantenimiento de Régimen Pensionario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoRegimenPens1.Focus();
                return "ERROR";
            }
            if (Convert.ToInt32(cboTipoRegimenPens1.SelectedValue) == 1)
            {
                if (txtPorcSNP.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el porcentaje de SNP", "Mantenimiento de Régimen Pensionario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPorcSNP.Focus();
                    return "ERROR";
                }
            }
            if (Convert.ToInt32(cboTipoRegimenPens1.SelectedValue) == 2)
            {
                if (txtPorcFlujoSPP.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el porcentaje de Flujo de SPP", "Mantenimiento de Régimen Pensionario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPorcFlujoSPP.Focus();
                    return "ERROR";
                }
                if (txtPorcMixtaSPP.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el porcentaje Mixto de SPP", "Mantenimiento de Régimen Pensionario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPorcMixtaSPP.Focus();
                    return "ERROR";
                }
                if (txtPorcSeguroSPP.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el porcentaje de Seguro de SPP", "Mantenimiento de Régimen Pensionario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPorcSeguroSPP.Focus();
                    return "ERROR";
                }
                if (txtPorcAporteSPP.Text.Trim() == "")
                {
                    MessageBox.Show("Ingrese el porcentaje de Aporte de SPP", "Mantenimiento de Régimen Pensionario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPorcAporteSPP.Focus();
                    return "ERROR";
                }
            }

            //NO REPETIR EL NOMBRE DEL RÉGIMEN
            if (pcTipOpe == "N")
            {
                for (int i = 0; i < dtgRegimen.Rows.Count; i++)
                {
                    if (Convert.ToString(dtgRegimen.Rows[i].Cells["cRegimen"].Value) == txtNomRegimen.Text.Trim())
                    {
                        MessageBox.Show("Ya existe un Régimen con ese nombre", "Mantenimiento de Régimen Pensionario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNomRegimen.Focus();
                        return "ERROR";
                    }
                }
            }

            if (pcTipOpe == "A")
            {
                int filaseleccionada = Convert.ToInt32(this.dtgRegimen.CurrentRow.Index);
                for (int i = 0; i < dtgRegimen.Rows.Count; i++)
                {
                    if (filaseleccionada != i)
                    {
                        if (Convert.ToString(dtgRegimen.Rows[i].Cells["cRegimen"].Value) == txtNomRegimen.Text.Trim())
                        {
                            MessageBox.Show("Ya existe un Régimen con ese nombre", "Mantenimiento de Régimen Pensionario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNomRegimen.Focus();
                            return "ERROR";
                        }
                    }
                }
            }

            return "OK";
        }

        private void MostrarDatos()
        {
            if (dtgRegimen.SelectedRows.Count > 0)
            {
                Int32 filaseleccionada = Convert.ToInt32(dtgRegimen.SelectedCells[1].RowIndex);

                //int filaseleccionada = Convert.ToInt32(this.dtgRegimen.CurrentRow.Index);

                this.txtNomRegimen.Text = Convert.ToString(this.dtgRegimen.Rows[filaseleccionada].Cells["cRegimen"].Value);
                this.cboTipoRegimenPens1.SelectedValue = Convert.ToInt32(this.dtgRegimen.Rows[filaseleccionada].Cells["idTipoRegimen"].Value);
                this.txtPorcSNP.Text = Convert.ToString(this.dtgRegimen.Rows[filaseleccionada].Cells["nPorcentSNP"].Value.ToString());
                this.txtPorcFlujoSPP.Text = Convert.ToString(this.dtgRegimen.Rows[filaseleccionada].Cells["nPorcentVarFlujoSPP"].Value);
                this.txtPorcMixtaSPP.Text = Convert.ToString(this.dtgRegimen.Rows[filaseleccionada].Cells["nPorcentVarMixtaSPP"].Value);
                this.txtPorcSeguroSPP.Text = Convert.ToString(this.dtgRegimen.Rows[filaseleccionada].Cells["nPorcentSeguroSPP"].Value);
                this.txtPorcAporteSPP.Text = Convert.ToString(this.dtgRegimen.Rows[filaseleccionada].Cells["nPorcentAporteSPP"].Value);
                this.CBVigente.Checked = Convert.ToBoolean(this.dtgRegimen.Rows[filaseleccionada].Cells["lVigente"].Value);

                HabilitarControles(false);
                pcTipOpe = "A";
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = true;              
                this.btnGrabar.Enabled = false;
                this.btnCancelar1.Enabled = false;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos() == "ERROR")
            {
                return;
            }
            string cNombreReg = Convert.ToString(txtNomRegimen.Text.Trim());
            int idTipoRegimen = Convert.ToInt32(cboTipoRegimenPens1.SelectedValue);
            decimal cPorcSNP = 0;
            if (txtPorcSNP.Text.Trim()!="")
                cPorcSNP = Convert.ToDecimal(txtPorcSNP.Text.Trim());
            decimal cPorcFlujoSPP = 0;
            if (txtPorcFlujoSPP.Text.Trim() != "")
                cPorcFlujoSPP = Convert.ToDecimal(txtPorcFlujoSPP.Text.Trim());
            decimal cPorcMixtaSPP = 0;
            if (txtPorcMixtaSPP.Text.Trim()!="")
                cPorcMixtaSPP = Convert.ToDecimal(txtPorcMixtaSPP.Text.Trim());
            decimal cPorcSeguroSPP = 0;
            if (txtPorcSeguroSPP.Text.Trim() != "")
                cPorcSeguroSPP = Convert.ToDecimal(txtPorcSeguroSPP.Text.Trim());
            decimal cPorcAporteSPP = 0;
            if (txtPorcAporteSPP.Text.Trim() != "")
                cPorcAporteSPP = Convert.ToDecimal(txtPorcAporteSPP.Text.Trim());
            int lVigente = Convert.ToInt32(CBVigente.Checked);
                   
            
            if (pcTipOpe == "A")
            {
                int filaseleccionada = Convert.ToInt32(this.dtgRegimen.CurrentRow.Index);
                int idRegimen = Convert.ToInt32(dtgRegimen.Rows[filaseleccionada].Cells["idRegimen"].Value);

                //TipOpercion 1=Modificar, 0=eliminar
                MantRegimen.ActualizarRegimen(idRegimen, cNombreReg, idTipoRegimen, cPorcSNP, cPorcFlujoSPP, cPorcMixtaSPP,
                                                  cPorcSeguroSPP, cPorcAporteSPP, lVigente);
                MessageBox.Show("Se han actualizado correctamente los Datos ", "Mantenimiento de Régimen Pensionario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                //cargar de nuevo y seleccionar la primera de todos los registros que fueroon modificados

                BuscarRegimen();
                int n = 0;
                foreach (DataGridViewRow fila in dtgRegimen.Rows)
                {
                    n += 1;
                    if (Convert.ToInt32(fila.Cells["idRegimen"].Value) == idRegimen)
                    {                        
                        dtgRegimen.CurrentCell = dtgRegimen.Rows[n - 1].Cells[1];
                        MostrarDatos();
                    }
                }
            }

            else if (pcTipOpe == "N")
            {

                int NuevoId = MantRegimen.GuardarRegimen(cNombreReg, idTipoRegimen, cPorcSNP, cPorcFlujoSPP, cPorcMixtaSPP,
                                                  cPorcSeguroSPP, cPorcAporteSPP, lVigente);
                MessageBox.Show("Se han Registrado los Datos Correctamente", "Mantenimiento de Régimen Pensionario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //cargar de nuevo y seleccionar el registros con la tasa recien añadida

                BuscarRegimen();
                int n = 0;
                foreach (DataGridViewRow fila in dtgRegimen.Rows)
                {
                    n += 1;
                    if (Convert.ToInt32(fila.Cells["idRegimen"].Value) == NuevoId)
                    {
                        dtgRegimen.CurrentCell = dtgRegimen.Rows[n - 1].Cells[1];
                        MostrarDatos();
                    }
                }

                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnGrabar.Enabled = false;               
                this.btnCancelar1.Enabled = false;
            }
        }

        private void dtgRegimen_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            HabilitarControles(false);
            MostrarDatos();
        }

        private void cboTipoRegimenPens1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoRegimenPens1.SelectedValue) == 1) {
                this.txtPorcSNP.Enabled = true;
                this.txtPorcFlujoSPP.Enabled = false;
                this.txtPorcMixtaSPP.Enabled = false;
                this.txtPorcSeguroSPP.Enabled = false;
                this.txtPorcAporteSPP.Enabled = false;
                this.txtPorcFlujoSPP.Clear();      
                this.txtPorcMixtaSPP.Clear(); 
                this.txtPorcSeguroSPP.Clear();
                this.txtPorcAporteSPP.Clear(); 
            }
            if (Convert.ToInt32(cboTipoRegimenPens1.SelectedValue) == 2)
            {
                this.txtPorcSNP.Enabled = false;
                this.txtPorcFlujoSPP.Enabled = true;
                this.txtPorcMixtaSPP.Enabled = true;
                this.txtPorcSeguroSPP.Enabled = true;
                this.txtPorcAporteSPP.Enabled = true;
                this.txtPorcSNP.Clear(); 
            }
            if (Convert.ToInt32(cboTipoRegimenPens1.SelectedValue) >= 3)
            {
                this.txtPorcSNP.Enabled = false;
                this.txtPorcFlujoSPP.Enabled = false;
                this.txtPorcMixtaSPP.Enabled = false;
                this.txtPorcSeguroSPP.Enabled = false;
                this.txtPorcAporteSPP.Enabled = false;
                this.txtPorcSNP.Clear(); 
                this.txtPorcFlujoSPP.Clear();
                this.txtPorcMixtaSPP.Clear();
                this.txtPorcSeguroSPP.Clear();
                this.txtPorcAporteSPP.Clear(); 
            }
        }
    }
}
