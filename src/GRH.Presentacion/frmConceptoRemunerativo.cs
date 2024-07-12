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
    public partial class frmConceptoRemunerativo : frmBase
    {
        DataTable dtConceptos;
        public string pcTipOpe = "N"; //Puede ser N --> Nuevo, A--> Actualizar
        clsCNMantConceptosRem MantConceptos = new clsCNMantConceptosRem();

        public frmConceptoRemunerativo()
        {
            InitializeComponent();
        }

        private void frmConceptoRemunerativo_Load(object sender, EventArgs e)
        {
            Limpiar();
            HabilitarControles(false);
            BuscarConceptos();
        }
        private void BuscarConceptos()
        {
            dtConceptos = MantConceptos.ListarConceptos();

            if (dtgConceptosRem.ColumnCount > 0)
            {
                dtgConceptosRem.Columns.Remove("cConcepto");
                dtgConceptosRem.Columns.Remove("idConcepto");
                dtgConceptosRem.Columns.Remove("idTipoConcepto");
                dtgConceptosRem.Columns.Remove("cTipoConcepto"); 
                dtgConceptosRem.Columns.Remove("lVigente");              
            }
            dtgConceptosRem.DataSource = dtConceptos.DefaultView;

            dtgConceptosRem.Columns["cConcepto"].Width = 140;
            dtgConceptosRem.Columns["cConcepto"].HeaderText = "Nombre del Concepto";
            dtgConceptosRem.Columns["cConcepto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgConceptosRem.Columns["idConcepto"].Visible = false;
            dtgConceptosRem.Columns["idTipoConcepto"].Visible = false;

            dtgConceptosRem.Columns["cTipoConcepto"].Width = 110;
            dtgConceptosRem.Columns["cTipoConcepto"].HeaderText = "Tipo de Concepto";
            dtgConceptosRem.Columns["cTipoConcepto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgConceptosRem.Columns["lVigente"].Width = 30;
            dtgConceptosRem.Columns["lVigente"].HeaderText = "Vig.";
            dtgConceptosRem.Columns["lVigente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        
        }
        private void Limpiar()
        {
            this.txtNomConcepto.Clear();
            this.cboTipConceptoRemuner1.SelectedIndex = -1;        
            this.CBVigente.Checked = false;
        }
        private void HabilitarControles(Boolean Val)
        {
            this.txtNomConcepto.Enabled = Val;
            this.cboTipConceptoRemuner1.Enabled = Val;         
            this.CBVigente.Enabled = Val;
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
        private string ValidarDatos()
        {
            if (txtNomConcepto.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre del Concepto Remunerativo", "Mantenimiento de Conceptos Remunerativos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNomConcepto.Focus();
                return "ERROR";
            }
            if (cboTipConceptoRemuner1.Text.Trim() == "")
            {
                MessageBox.Show("Seleccione el Tipo de Concepto Remunerativo", "Mantenimiento de Conceptos Remunerativos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipConceptoRemuner1.Focus();
                return "ERROR";
            }
           

            if (pcTipOpe == "N")
            {
                for (int i = 0; i < dtgConceptosRem.Rows.Count; i++)
                {
                    if (Convert.ToString(dtgConceptosRem.Rows[i].Cells["cConcepto"].Value) == txtNomConcepto.Text.Trim())
                    {
                        MessageBox.Show("Ya existe un Concepto con ese nombre. Verifique", "Mantenimiento de Conceptos Remunerativos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNomConcepto.Focus();
                        return "ERROR";
                    }
                }
            }

            if (pcTipOpe == "A")
            {
                int filaseleccionada = Convert.ToInt32(this.dtgConceptosRem.CurrentRow.Index);

                for (int i = 0; i < dtgConceptosRem.Rows.Count; i++)
                {
                    if (filaseleccionada != i)
                    {
                        if (Convert.ToString(dtgConceptosRem.Rows[i].Cells["cConcepto"].Value) == txtNomConcepto.Text.Trim())
                        {
                            MessageBox.Show("Ya existe un Concepto con ese nombre. Verifique", "Mantenimiento de Conceptos Remunerativos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNomConcepto.Focus();
                            return "ERROR";
                        }
                    }
                }
            }

            return "OK";
        }

        private void MostrarDatos()
        {

            if (dtgConceptosRem.SelectedRows.Count > 0)
            {
                int filaseleccionada = Convert.ToInt32(this.dtgConceptosRem.CurrentRow.Index);

                this.txtNomConcepto.Text = Convert.ToString(this.dtgConceptosRem.Rows[filaseleccionada].Cells["cConcepto"].Value);
                this.cboTipConceptoRemuner1.SelectedValue = Convert.ToInt32(this.dtgConceptosRem.Rows[filaseleccionada].Cells["idTipoConcepto"].Value);

                this.CBVigente.Checked = Convert.ToBoolean(this.dtgConceptosRem.Rows[filaseleccionada].Cells["lVigente"].Value);

                HabilitarControles(false);
                pcTipOpe = "A";
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = true;
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

            string NombConcepto = txtNomConcepto.Text.Trim();
            int idTipoConcepto = Convert.ToInt32(cboTipConceptoRemuner1.SelectedValue);           
            int lVigente = Convert.ToInt32(CBVigente.Checked);


            if (pcTipOpe == "A")
            {
                int filaseleccionada = Convert.ToInt32(this.dtgConceptosRem.CurrentRow.Index);
                int idConcepto = Convert.ToInt32(dtgConceptosRem.Rows[filaseleccionada].Cells["idConcepto"].Value);


                MantConceptos.ActualizarConcepto(idConcepto, NombConcepto, idTipoConcepto, lVigente);
                MessageBox.Show("Se han actualizado correctamente los Datos ", "Mantenimiento de Conceptos Remunerativos", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //cargar de nuevo y seleccionar el registro modificado

                BuscarConceptos();
                int n = 0;
                foreach (DataGridViewRow fila in dtgConceptosRem.Rows)
                {
                    n += 1;
                    if (Convert.ToInt32(fila.Cells["idConcepto"].Value) == idConcepto)
                    {
                        dtgConceptosRem.CurrentCell = dtgConceptosRem.Rows[n - 1].Cells[0];
                        MostrarDatos();
                    }
                }

            }

            else if (pcTipOpe == "N")
            {

                int NuevoId = MantConceptos.GuardarConcepto(NombConcepto, idTipoConcepto, lVigente);
                MessageBox.Show("Se han Registrado los Datos Correctamente", "Mantenimiento de Conceptos Remunerativos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //cargar de nuevo y seleccionar el registros con la tasa recien añadida

                BuscarConceptos();
                int n = 0;
                foreach (DataGridViewRow fila in dtgConceptosRem.Rows)
                {
                    n += 1;
                    if (Convert.ToInt32(fila.Cells["idConcepto"].Value) == NuevoId)
                    {
                        dtgConceptosRem.CurrentCell = dtgConceptosRem.Rows[n - 1].Cells[0];
                        MostrarDatos();
                    }
                }


                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;

            }
        }

        private void dtgConceptosRem_SelectionChanged(object sender, EventArgs e)
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
