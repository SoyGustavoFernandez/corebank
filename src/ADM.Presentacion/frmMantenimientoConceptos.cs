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
using ADM.CapaNegocio;

namespace ADM.Presentacion
{
    public partial class frmMantenimientoConceptos : frmBase
    {
        DataTable tbConceptos;
        String TipOpe;
        int idConcep;  
        public frmMantenimientoConceptos()
        {
            InitializeComponent();
        }

        private void MantenimientoConceptos_Load(object sender, EventArgs e)
        {
            CargarGrupo();                      
            HabilitarControles(false);                       
            CargarConceptos();           
        }

        
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            TipOpe = "EA";//Editar un Recibo Antiguo
            HabilitarControles(true);
            btnNuevo1.Enabled = false;
            btnEditar1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            cboGrupo.Enabled = CBGrupo.Checked;
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {            
                Limpiar();
                HabilitarControles(false);
                btnNuevo1.Enabled = true;
                btnCancelar1.Enabled = false;
                btnGrabar1.Enabled = false;
                if (dtgConceptos.SelectedRows.Count > 0)
                    btnEditar1.Enabled = true;
                else
                    btnEditar1.Enabled = false;            
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {         
                        
                    if (Validaciones() == "ERROR")
                    {
                        return;
                    }
                    
                    int idGrupo;
                    if (CBGrupo.Checked == true)                    
                        idGrupo= Convert.ToInt32(cboGrupo.SelectedValue);
                    else             
                        idGrupo = 0;   
                    clsCNMantConceptos Conceptos = new clsCNMantConceptos();
                    if (TipOpe == "EA")//MODIFICAR CONCEPTO
                    {
                        Int32 nFila = Convert.ToInt32(dtgConceptos.SelectedCells[0].RowIndex);
                        idConcep = Conceptos.ActualizarConceptos(Convert.ToInt32(dtgConceptos.Rows[nFila].Cells["idConcepto"].Value), "E", Convert.ToString(txtNombConcepto.Text.Trim()), Convert.ToString(txtNombreCorto.Text.Trim()),
                                                       idGrupo, Convert.ToInt32(CBAplicaCont.Checked),
                                                       Convert.ToInt32(CBVigente.Checked));
                        MessageBox.Show("Los datos se Actualizaron Correctamente", "Mantenimiento de Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    if (TipOpe == "EN")//REG. CONCEPTO NUEVO
                    {
                        idConcep = Conceptos.ActualizarConceptos(0, "N", Convert.ToString(txtNombConcepto.Text.Trim()), Convert.ToString(txtNombreCorto.Text.Trim()),
                                                       idGrupo, Convert.ToInt32(CBAplicaCont.Checked),
                                                       Convert.ToInt32(CBVigente.Checked));
                        MessageBox.Show("Los datos se Guardaron Correctamente", "Mantenimiento de Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                                      
                    CargarConceptos();
                    int n = 0;
                    foreach (DataGridViewRow fila in dtgConceptos.Rows)
                    {
                        n += 1;
                        if (Convert.ToInt32(fila.Cells["idConcepto"].Value) == idConcep)
                        {
                            dtgConceptos.CurrentCell = dtgConceptos.Rows[n - 1].Cells["cConcepto"];
                            MostrarDatos();
                        }
                    }
                
            
            
            HabilitarControles(false);
            btnNuevo1.Enabled = true;
            btnEditar1.Enabled = true;
            btnCancelar1.Enabled = false;
            btnGrabar1.Enabled = false;
        }
        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            TipOpe = "EN";//Editar un Nuevo Recibo
            btnNuevo1.Enabled = false;
            btnEditar1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            Limpiar();
            HabilitarControles(true);

            CBGrupo.Checked = true;
            CBVigente.Checked = true;
            CBVigente.Enabled = false;  
        }
        private void dtgConceptos_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos() { 
            if (dtgConceptos.SelectedRows.Count > 0)
            {
                int FilaSeleccionada = Convert.ToInt32(dtgConceptos.SelectedCells[2].RowIndex);

                txtNombConcepto.Text = Convert.ToString(dtgConceptos.Rows[FilaSeleccionada].Cells["cConcepto"].Value);

                txtNombreCorto.Text = Convert.ToString(dtgConceptos.Rows[FilaSeleccionada].Cells["cNombreCorto"].Value);
                if (Convert.ToInt32(dtgConceptos.Rows[FilaSeleccionada].Cells["idGrupoCon"].Value) == 0)
                {
                    CBGrupo.Checked = false;
                    cboGrupo.SelectedValue = 0;
                }
                else {
                    CBGrupo.Checked = true;
                    cboGrupo.SelectedValue = Convert.ToInt32(dtgConceptos.Rows[FilaSeleccionada].Cells["idGrupoCon"].Value);
                    cboGrupo.Enabled = false;
                }
                
                CBAplicaCont.Checked = Convert.ToBoolean(dtgConceptos.Rows[FilaSeleccionada].Cells["lAplicaContable"].Value);
                CBVigente.Checked = Convert.ToBoolean(dtgConceptos.Rows[FilaSeleccionada].Cells["lVigente"].Value);
                                
                HabilitarControles(false);
                btnNuevo1.Enabled = true;
                btnEditar1.Enabled = true;
                btnCancelar1.Enabled = false;
                btnGrabar1.Enabled = false;
            }
                
        }
        private void CBGrupo_CheckedChanged(object sender, EventArgs e)
        {
            cboGrupo.Enabled = CBGrupo.Checked;
            if (CBGrupo.Checked == false)
                cboGrupo.SelectedIndex = -1;
        }

        private void CargarGrupo() {
            clsCNConfigGastComiSeg ListaGrupo = new clsCNConfigGastComiSeg();
            DataTable dt = ListaGrupo.CargarGrupoGasto();
            cboGrupo.DataSource = dt;
            cboGrupo.ValueMember = dt.Columns["idGrupoConcepto"].ToString();
            cboGrupo.DisplayMember = dt.Columns["cGrupoConcepto"].ToString();   
        }
        private void CargarConceptos()
        {
            clsCNMantConceptos Conceptos = new clsCNMantConceptos();
            tbConceptos = Conceptos.ListarConceptos();

            if (dtgConceptos.ColumnCount > 0)
            {
                dtgConceptos.Columns.Remove("Estado");
                dtgConceptos.Columns.Remove("idConcepto");
                dtgConceptos.Columns.Remove("cConcepto");
                dtgConceptos.Columns.Remove("cNombreCorto");
                dtgConceptos.Columns.Remove("idGrupoCon");
                dtgConceptos.Columns.Remove("cGrupoCon");
                dtgConceptos.Columns.Remove("lAplicaContable");
                dtgConceptos.Columns.Remove("lVigente");
                dtgConceptos.Columns.Remove("cVigencia");
            }

            dtgConceptos.DataSource = tbConceptos.DefaultView;
            FormatoDtgConceptos();
        }
        private void FormatoDtgConceptos()
        {
            dtgConceptos.Columns["Estado"].Visible = false;
            dtgConceptos.Columns["idConcepto"].Visible = false;
            dtgConceptos.Columns["cConcepto"].Width = 80;
            dtgConceptos.Columns["cConcepto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgConceptos.Columns["cConcepto"].HeaderText = "Concepto";
            dtgConceptos.Columns["cNombreCorto"].Visible = false;
            dtgConceptos.Columns["idGrupoCon"].Visible = false;
            dtgConceptos.Columns["cGrupoCon"].Width = 60;
            dtgConceptos.Columns["cGrupoCon"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgConceptos.Columns["cGrupoCon"].HeaderText = "Grupo";
            dtgConceptos.Columns["cVigencia"].Width = 35;
            dtgConceptos.Columns["cVigencia"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgConceptos.Columns["cVigencia"].HeaderText = "Vigencia";
            dtgConceptos.Columns["lAplicaContable"].Visible = false;
            dtgConceptos.Columns["lVigente"].Visible = false;

        }
        private string Validaciones()
        {            
            if (txtNombConcepto.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Nombre del Concepto", "Mantenimiento de Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombConcepto.Focus();
                return "ERROR";
            }
            if (txtNombreCorto.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Nombre Corto del Concepto", "Mantenimiento de Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombreCorto.Focus();
                return "ERROR";
            }

            if (cboGrupo.Text.Trim() == "" && CBGrupo.Checked==true)
            {
                MessageBox.Show("Seleccione el Grupo al que Pertenece", "Mantenimiento de Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboGrupo.Focus();
                return "ERROR";
            }
            
            if (TipOpe == "EA")
            {
                int filaSeleccionada = Convert.ToInt32(dtgConceptos.SelectedCells[2].RowIndex);

                for (int i = 0; i <= (dtgConceptos.Rows.Count - 1); i++)
                {
                    if (i != filaSeleccionada)
                        if (Convert.ToString(dtgConceptos.Rows[i].Cells["cConcepto"].Value).Trim() == txtNombConcepto.Text.Trim())
                        {
                            MessageBox.Show("Ya existe un Concepto con el mismo Nombre", "Mantenimiento de Montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNombConcepto.Focus();
                            return "ERROR";
                        }
                }

            }
            if (TipOpe == "EN")
            {
                for (int i = 0; i <= (dtgConceptos.Rows.Count - 1); i++)
                {
                    if (Convert.ToString(dtgConceptos.Rows[i].Cells["cConcepto"].Value).Trim() == txtNombConcepto.Text.Trim())
                    {
                        MessageBox.Show("Ya existe una Concepto con el mismo Nombre", "Mantenimiento de Montos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNombConcepto.Focus();
                        return "ERROR";
                    }
                }
            }

            return "OK";

        }
        private void Limpiar()
        {
            txtNombConcepto.Text = "";
            txtNombreCorto.Text = "";
            CBGrupo.Checked = false;
            cboGrupo.SelectedIndex = -1;
            CBAplicaCont.Checked = false;           
            CBVigente.Checked = false;
        }
        private void HabilitarControles(Boolean var)
        {
            txtNombConcepto.Enabled = var;
            txtNombreCorto.Enabled = var;
            CBGrupo.Enabled = var;
            cboGrupo.Enabled = var;
            CBAplicaCont.Enabled = var;           
            CBVigente.Enabled = var;
        }


    }
}
