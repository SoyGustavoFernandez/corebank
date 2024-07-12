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
    public partial class frmMantenPeriodoPlanilla : frmBase
    {
        DataTable dtPeriodos;
        string pcTipOpe="N";

        public frmMantenPeriodoPlanilla()
        {
            InitializeComponent();
        }

        private void frmMantenPeriodoPlanilla_Load(object sender, EventArgs e)
        {            
            HabilitarControles(false);            
            cboRelacionLabInst1.SelectedIndex = -1;
            cboRelacionLabInst1.Enabled = true;
            cboTipoPlanilla1.Enabled = true;
            BuscarPeriodos();
            Limpiar();
            this.btnNuevo.Enabled = false;
            this.btnCancelar.Enabled = false;
        }

        private void BuscarPeriodos()
        {
            int idTipoPlanilla = Convert.ToInt32(cboTipoPlanilla1.SelectedValue);
            clsCNPeriodoPlanilla LitaHorarios = new clsCNPeriodoPlanilla();
            dtPeriodos = LitaHorarios.CNListarPeriodosPlanilla(idTipoPlanilla);

            if (dtgPeriodos.ColumnCount > 0)
            {
                dtgPeriodos.Columns.Remove("cPeriodoPlanilla"); 
                dtgPeriodos.Columns.Remove("idPeriodoPlanilla");              
                dtgPeriodos.Columns.Remove("dFechaInicio");
                dtgPeriodos.Columns.Remove("dFechaFin");
                dtgPeriodos.Columns.Remove("cEstado");
                dtgPeriodos.Columns.Remove("idEstado");
            }
            dtgPeriodos.DataSource = dtPeriodos.DefaultView;
            
            dtgPeriodos.Columns["cPeriodoPlanilla"].Width = 30;
            dtgPeriodos.Columns["cPeriodoPlanilla"].HeaderText = "Denominación";
            dtgPeriodos.Columns["cPeriodoPlanilla"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dtgPeriodos.Columns["idPeriodoPlanilla"].Visible = false;

            dtgPeriodos.Columns["dFechaInicio"].Width = 40;
            dtgPeriodos.Columns["dFechaInicio"].HeaderText = "Fecha de Inicio";
            dtgPeriodos.Columns["dFechaInicio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgPeriodos.Columns["dFechaFin"].Width = 40;
            dtgPeriodos.Columns["dFechaFin"].HeaderText = "Fecha de Fin";
            dtgPeriodos.Columns["dFechaFin"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgPeriodos.Columns["cEstado"].Width = 50;
            dtgPeriodos.Columns["cEstado"].HeaderText = "Estado";
            dtgPeriodos.Columns["cEstado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgPeriodos.Columns["idEstado"].Visible = false;
                       
            MostrarDatos();

        }
        private void Limpiar()
        {      
            this.dtpFecInicio.Value = clsVarGlobal.dFecSystem;
            this.dtpFecFin.Value = clsVarGlobal.dFecSystem;
            this.txtDenominacion.Clear();
            this.cboEstadoPeriodo1.SelectedIndex = 1;            
        }
        private void HabilitarControles(Boolean Val)
        {            
            this.txtDenominacion.Enabled = Val;
            this.dtpFecInicio.Enabled = Val;
            this.dtpFecFin.Enabled = Val;
            this.cboEstadoPeriodo1.Enabled = Val;
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            pcTipOpe = "A";
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.btnEliminar.Enabled = false;
            
            HabilitarControles(true);   
            cboRelacionLabInst1.Enabled = false;
            cboTipoPlanilla1.Enabled = false;
            if (dtpFecInicio.Value.Date <= clsVarGlobal.dFecSystem.Date)
            {
                dtpFecInicio.Enabled = false;
                dtpFecFin.Enabled = false;
            }
              
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            pcTipOpe = "N";
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.btnEliminar.Enabled = false;
            cboRelacionLabInst1.Enabled = false;
            cboTipoPlanilla1.Enabled = false;

            Limpiar();
            HabilitarControles(true);
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dtgPeriodos.Rows.Count > 0)
                dtPeriodos.Rows.Clear();
            Limpiar();
            cboRelacionLabInst1.SelectedValue = -1;
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnEliminar.Enabled = false;
          
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos() == "ERROR")
            {
                return;
            }

            int idTipoPlanilla = Convert.ToInt32(cboTipoPlanilla1.SelectedValue);
            string cDenominacion = Convert.ToString(txtDenominacion.Text);
            DateTime dFechaInicio = Convert.ToDateTime(dtpFecInicio.Text);
            DateTime dFechaFin = Convert.ToDateTime(dtpFecFin.Text);
            int idEstadoPeriodo=Convert.ToInt32(cboEstadoPeriodo1.SelectedValue);

            clsCNPeriodoPlanilla GuardaPeriodos = new clsCNPeriodoPlanilla();

            if (pcTipOpe == "A")
            {              
                int filaseleccionada = Convert.ToInt32(this.dtgPeriodos.CurrentRow.Index);
                int idPeriodo = Convert.ToInt32(dtgPeriodos.Rows[filaseleccionada].Cells["idPeriodoPlanilla"].Value);
                                                        
                    GuardaPeriodos.CNActualizarPeriodoPlanila(idPeriodo, cDenominacion, dFechaInicio, dFechaFin,
                                                            idEstadoPeriodo, 1);
                    MessageBox.Show("Se han actualizado correctamente los Datos ", "Mantenimiento de Periodos de Planilla", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    //cargar de nuevo y seleccionar la primera de todos los registros que fueroon modificados

                    BuscarPeriodos();
                    int n = 0;
                    foreach (DataGridViewRow fila in dtgPeriodos.Rows)
                    {
                        n += 1;
                        if (Convert.ToInt32(fila.Cells["idPeriodoPlanilla"].Value) == idPeriodo)
                        {
                            dtgPeriodos.CurrentCell = dtgPeriodos.Rows[n - 1].Cells[0];
                            MostrarDatos();
                        }
                    }
            }

            else if (pcTipOpe == "N")
            {
                int NuevoId = GuardaPeriodos.CNGuardarPeriodoPlanilla(idTipoPlanilla, cDenominacion, dFechaInicio, dFechaFin,
                                                                        idEstadoPeriodo);
                    MessageBox.Show("Se han Registrado los Datos Correctamente", "Mantenimiento de Periodos de Planilla", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //cargar de nuevo y seleccionar el registros con la tasa recien añadida

                    BuscarPeriodos();
                    int n = 0;
                    foreach (DataGridViewRow fila in dtgPeriodos.Rows)
                    {
                        n += 1;
                        if (Convert.ToInt32(fila.Cells["idPeriodoPlanilla"].Value) == NuevoId)
                        {
                            dtgPeriodos.CurrentCell = dtgPeriodos.Rows[n - 1].Cells[0];
                            MostrarDatos();
                        }
                    }                    
                  
            }
        }
        private string ValidarDatos()
        {
            if (cboTipoPlanilla1.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el Tipo de Planilla", "Mantenimiento de Periodos de Planilla", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoPlanilla1.Focus();
                return "ERROR";
            }
            if (txtDenominacion.Text.Trim() == "")
            {
                MessageBox.Show("Indique la denominación del Periodo", "Mantenimiento de Periodos de Planilla", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDenominacion.Focus();
                return "ERROR";
            }
            if (dtpFecInicio.Value.Date == dtpFecFin.Value.Date)
            {
                MessageBox.Show("La fecha de Inicio y la fecha Final no deben ser iguales", "Mantenimiento de Periodos de Planilla", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFecInicio.Focus();
                return "ERROR";
            }
            if (dtpFecInicio.Value.Date > dtpFecFin.Value.Date)
            {
                MessageBox.Show("La fecha de Inicio no puede ser mayor que la fecha Final ", "Mantenimiento de Periodos de Planilla", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFecInicio.Focus();
                return "ERROR";
            }

            if (cboEstadoPeriodo1.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el estado del periodo", "Mantenimiento de Periodos de Planilla", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboEstadoPeriodo1.Focus();
                return "ERROR";
            }
            if (pcTipOpe == "N") {
                if (dtgPeriodos.Rows.Count > 0)
                {
                    DateTime FechaInicioMayor = Convert.ToDateTime(dtgPeriodos.Rows[0].Cells["dFechaInicio"].Value).Date;
                    DateTime FechaFinalMayor = Convert.ToDateTime(dtgPeriodos.Rows[0].Cells["dFechaFin"].Value).Date;
                    foreach (DataGridViewRow fila in dtgPeriodos.Rows)
                    {
                        if (Convert.ToDateTime(fila.Cells["dFechaInicio"].Value).Date > FechaInicioMayor)
                        {
                            FechaInicioMayor = Convert.ToDateTime(fila.Cells["dFechaInicio"].Value).Date;
                            FechaFinalMayor = Convert.ToDateTime(fila.Cells["dFechaFin"].Value).Date;
                        }
                    }
                    if (dtpFecInicio.Value.Date <= FechaInicioMayor)
                    {
                        MessageBox.Show("No se puede establecer periodos anteriores o iguales al periodo más reciente", "Mantenimiento de Periodos de Planilla", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return "ERROR";
                    }
                    if (dtpFecInicio.Value.Date <= FechaFinalMayor)
                    {
                        MessageBox.Show("La fecha Inicial no puede ser anterior o igual a la Fecha final del último periodo", "Mantenimiento de Periodos de Planilla", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return "ERROR";
                    }
                }
            
            }
            if (pcTipOpe == "A") {
                DateTime dInicio=dtpFecInicio.Value.Date;
                DateTime dFin =dtpFecFin.Value.Date;
                
                for (int i = 0; i <= dtgPeriodos.Rows.Count - 1;i++ )
                {
                    DateTime dFecInicioAnterior = Convert.ToDateTime(dtgPeriodos.Rows[i].Cells["dFechaInicio"].Value).Date;
                    DateTime dFecFinAnterior = Convert.ToDateTime(dtgPeriodos.Rows[i].Cells["dFechaFin"].Value).Date;

                    int filaseleccionada = Convert.ToInt32(this.dtgPeriodos.CurrentRow.Index);

                    if (filaseleccionada != i)
                    {
                        if (dInicio == dFecInicioAnterior && dFin == dFecFinAnterior)
                        {
                            MessageBox.Show("Ya existe un periodo con el mismo intervalo de Fechas denominado " + Convert.ToString(dtgPeriodos.Rows[i].Cells["cPeriodoPlanilla"].Value) + ". Verifique", "Mantenimiento de Periodos de Planilla", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return "ERROR";
                        }

                        if ((dInicio <= dFecInicioAnterior && dFin >= dFecInicioAnterior) || (dInicio <= dFecFinAnterior && dFin >= dFecFinAnterior) || (dInicio > dFecInicioAnterior && dFin < dFecFinAnterior))
                        {
                            MessageBox.Show("El Intervalo del Periodo o parte de éste, se encuentra contenido en el Periodo denominado " + Convert.ToString(dtgPeriodos.Rows[i].Cells["cPeriodoPlanilla"].Value) + ". Verifique", "Mantenimiento de Periodos de Planilla", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return "ERROR";
                        }
                    }
                }
            }
            
            return "OK";        
        }

        private void MostrarDatos()
        {
            if (this.dtgPeriodos.SelectedRows.Count > 0)
            {
                int filaseleccionada = Convert.ToInt32(this.dtgPeriodos.CurrentRow.Index);

                this.txtDenominacion.Text = Convert.ToString(this.dtgPeriodos.Rows[filaseleccionada].Cells["cPeriodoPlanilla"].Value);
                this.dtpFecInicio.Value = Convert.ToDateTime(this.dtgPeriodos.Rows[filaseleccionada].Cells["dFechaInicio"].Value.ToString());
                this.dtpFecFin.Value = Convert.ToDateTime(this.dtgPeriodos.Rows[filaseleccionada].Cells["dFechaFin"].Value.ToString());
                this.cboEstadoPeriodo1.SelectedValue = Convert.ToString(this.dtgPeriodos.Rows[filaseleccionada].Cells["idEstado"].Value);

                HabilitarControles(false);
                pcTipOpe = "A";
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnEliminar.Enabled = true;
                cboRelacionLabInst1.Enabled = true;
                cboTipoPlanilla1.Enabled = true;
            }
            else
            {
                Limpiar();
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnEliminar.Enabled = false;
                cboRelacionLabInst1.Enabled = true;
                cboTipoPlanilla1.Enabled = true;
            }

        }

        private void dtgPeriodos_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void cboRelacionLabInst1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRelacionLabInst1.Text != "")
            {
                cboTipoPlanilla1.ListarTipoPlanillaRelacionLab(Convert.ToInt32(cboRelacionLabInst1.SelectedValue));
                cboTipoPlanilla1.SelectedIndex = -1;
            }
            else
                cboTipoPlanilla1.ListarTipoPlanillaRelacionLab(0);
            CambioTipoPlanilla();
        }

        private void cboTipoPlanilla1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CambioTipoPlanilla();
        }
        private void CambioTipoPlanilla() {
            if (cboTipoPlanilla1.Text.Trim() != "")
            {
                btnNuevo.Enabled = true;
                BuscarPeriodos();
            }
            else
            {
                if (dtgPeriodos.Rows.Count > 0)
                    dtPeriodos.Rows.Clear();
                Limpiar();
                this.btnNuevo.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnEliminar.Enabled = false;
            }        
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtpFecInicio.Value.Date <= clsVarGlobal.dFecSystem.Date)
            {
                MessageBox.Show("No se puede eliminar los periodos que se encuentren Vigentes o ya culminaron", "Mantenimiento de Periodos de Planilla", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            string cDenominacion = Convert.ToString(txtDenominacion.Text);
            DateTime dFechaInicio = Convert.ToDateTime(dtpFecInicio.Text);
            DateTime dFechaFin = Convert.ToDateTime(dtpFecFin.Text);
            int idEstadoPeriodo = Convert.ToInt32(cboEstadoPeriodo1.SelectedValue);
            
            int filaseleccionada = Convert.ToInt32(this.dtgPeriodos.CurrentRow.Index);
            int idPeriodo = Convert.ToInt32(dtgPeriodos.Rows[filaseleccionada].Cells["idPeriodoPlanilla"].Value);

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar el Periodo?", "Mantenimiento de Periodos de Planilla", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                clsCNPeriodoPlanilla GuardaPeriodos = new clsCNPeriodoPlanilla();
                GuardaPeriodos.CNActualizarPeriodoPlanila(idPeriodo, cDenominacion, dFechaInicio, dFechaFin,
                                                         idEstadoPeriodo, 0);
                MessageBox.Show("El periodo fue eliminado ", "Mantenimiento de Periodos de Planilla", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BuscarPeriodos();
            }
            else
                return;
         }       
    }
}