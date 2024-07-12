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
    public partial class frmMantPeriodoDeclar : frmBase
    {
        DataTable dtPeriodos;
        string pcTipOpe = "N";

        public frmMantPeriodoDeclar()
        {
            InitializeComponent();
        }

        private void frmMantPeriodoDeclar_Load(object sender, EventArgs e)
        {
            Limpiar();
            HabilitarControles(false);                        
            BuscarPeriodos();
        }
        private void BuscarPeriodos()
        {
            clsCNPeriodoDeclaracion ListaPeriodosDeclarativos = new clsCNPeriodoDeclaracion();
            dtPeriodos = ListaPeriodosDeclarativos.CNListarPeriodosDeclaracion();

            if (dtgPeriodos.ColumnCount > 0)
            {
                dtgPeriodos.Columns.Remove("cMes");
                dtgPeriodos.Columns.Remove("idPeriodoDeclaracion");
                dtgPeriodos.Columns.Remove("cPeriodoDeclaracion");
                dtgPeriodos.Columns.Remove("nMesDeclaracion");                
                dtgPeriodos.Columns.Remove("dFechaInicio");
                dtgPeriodos.Columns.Remove("dFechaFin");
                dtgPeriodos.Columns.Remove("cEstado");
                dtgPeriodos.Columns.Remove("idEstado");
            }
            dtgPeriodos.DataSource = dtPeriodos.DefaultView;

            dtgPeriodos.Columns["cMes"].Width = 30;
            dtgPeriodos.Columns["cMes"].HeaderText = "Mes";
            dtgPeriodos.Columns["cMes"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgPeriodos.Columns["idPeriodoDeclaracion"].Visible = false;
            dtgPeriodos.Columns["cPeriodoDeclaracion"].Visible = false;
            dtgPeriodos.Columns["nMesDeclaracion"].Visible = false;
                      
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
            this.cboEstadoPeriodo1.SelectedIndex = -1;
        }
        private void HabilitarControles(Boolean Val)
        {
            this.txtDenominacion.Enabled = Val;
            this.dtpFecInicio.Enabled = Val;
            this.dtpFecFin.Enabled = Val;
            this.cboEstadoPeriodo1.Enabled = Val;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            pcTipOpe = "A";
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.btnEliminar.Enabled = false;

            HabilitarControles(true);            
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
            
            Limpiar();
            HabilitarControles(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarControles(false);
            Limpiar();
            MostrarDatos();

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos() == "ERROR")
            {
                return;
            }
                        
            string cDenominacion = Convert.ToString(txtDenominacion.Text);
            DateTime dFechaInicio = Convert.ToDateTime(dtpFecInicio.Value).Date;
            DateTime dFechaFin = Convert.ToDateTime(dtpFecFin.Value).Date;
            int idEstadoPeriodo = Convert.ToInt32(cboEstadoPeriodo1.SelectedValue);
            int idMes=Convert.ToDateTime(dtpFecInicio.Value).Month;

            clsCNPeriodoDeclaracion GuardaPeriodos = new clsCNPeriodoDeclaracion();

            if (pcTipOpe == "A")
            {
                int filaseleccionada = Convert.ToInt32(this.dtgPeriodos.CurrentRow.Index);
                int idPeriodo = Convert.ToInt32(dtgPeriodos.Rows[filaseleccionada].Cells["idPeriodoDeclaracion"].Value);

                GuardaPeriodos.CNActualizarPeriodoDeclaracion(idPeriodo, cDenominacion, dFechaInicio, dFechaFin,
                                                        idEstadoPeriodo, idMes, 1);
                MessageBox.Show("Se han actualizado correctamente los Datos ", "Mantenimiento de Periodos de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //cargar de nuevo y seleccionar la primera de todos los registros que fueroon modificados

                BuscarPeriodos();
                int n = 0;
                foreach (DataGridViewRow fila in dtgPeriodos.Rows)
                {
                    n += 1;
                    if (Convert.ToInt32(fila.Cells["idPeriodoDeclaracion"].Value) == idPeriodo)
                    {
                        dtgPeriodos.CurrentCell = dtgPeriodos.Rows[n - 1].Cells[0];
                        MostrarDatos();
                    }
                }
            }

            else if (pcTipOpe == "N")
            {
                int NuevoId = GuardaPeriodos.CNGuardarPeriodoDeclaracion(cDenominacion, dFechaInicio, dFechaFin,
                                                                    idEstadoPeriodo, idMes);
                MessageBox.Show("Se han Registrado los Datos Correctamente", "Mantenimiento de Periodos de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //cargar de nuevo y seleccionar el registros con la tasa recien añadida

                BuscarPeriodos();
                int n = 0;
                foreach (DataGridViewRow fila in dtgPeriodos.Rows)
                {
                    n += 1;
                    if (Convert.ToInt32(fila.Cells["idPeriodoDeclaracion"].Value) == NuevoId)
                    {
                        dtgPeriodos.CurrentCell = dtgPeriodos.Rows[n - 1].Cells[0];
                        MostrarDatos();
                    }
                }

            }
        }
        private string ValidarDatos()
        {            
            if (txtDenominacion.Text.Trim() == "")
            {
                MessageBox.Show("Indique la denominación del Periodo", "Mantenimiento de Periodos de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDenominacion.Focus();
                return "ERROR";
            }
            if (dtpFecInicio.Value.Date == dtpFecFin.Value.Date)
            {
                MessageBox.Show("La fecha de Inicio y la fecha Final no deben ser iguales", "Mantenimiento de Periodos de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFecInicio.Focus();
                return "ERROR";
            }
            if (dtpFecInicio.Value.Date > dtpFecFin.Value.Date)
            {
                MessageBox.Show("La fecha de Inicio no puede ser mayor que la fecha Final ", "Mantenimiento de Periodos de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFecInicio.Focus();
                return "ERROR";
            }
            if (dtpFecInicio.Value.Month != dtpFecFin.Value.Month)
            {
                MessageBox.Show("La fecha de Inicio y la fecha Final deben pertenecer al mismo Mes ", "Mantenimiento de Periodos de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpFecInicio.Focus();
                return "ERROR";
            }

            if (cboEstadoPeriodo1.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar el estado del periodo", "Mantenimiento de Periodos de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboEstadoPeriodo1.Focus();
                return "ERROR";
            }
            if (pcTipOpe == "N")
            {
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
                        MessageBox.Show("No se puede establecer periodos anteriores o iguales al periodo más reciente", "Mantenimiento de Periodos de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return "ERROR";
                    }
                    if (dtpFecInicio.Value.Date <= FechaFinalMayor)
                    {
                        MessageBox.Show("La fecha Inicial no puede ser anterior o igual a la Fecha final del último periodo", "Mantenimiento de Periodos de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return "ERROR";
                    }
                }
            }

            if (pcTipOpe == "A")
            {
                DateTime dInicio = dtpFecInicio.Value.Date;
                DateTime dFin = dtpFecFin.Value.Date;

                for (int i = 0; i <= dtgPeriodos.Rows.Count - 1; i++)
                {
                    DateTime dFecInicioAnterior = Convert.ToDateTime(dtgPeriodos.Rows[i].Cells["dFechaInicio"].Value).Date;
                    DateTime dFecFinAnterior = Convert.ToDateTime(dtgPeriodos.Rows[i].Cells["dFechaFin"].Value).Date;

                    int filaseleccionada = Convert.ToInt32(this.dtgPeriodos.CurrentRow.Index);

                    if (filaseleccionada != i)
                    {
                        if (dInicio == dFecInicioAnterior && dFin == dFecFinAnterior)
                        {
                            MessageBox.Show("El periodo de " + Convert.ToString(dtgPeriodos.Rows[i].Cells["cMes"].Value) + " cuenta con el mismo intervalo de Fechas. Verifique", "Mantenimiento de Periodos de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return "ERROR";
                        }

                        if ((dInicio <= dFecInicioAnterior && dFin >= dFecInicioAnterior) || (dInicio <= dFecFinAnterior && dFin >= dFecFinAnterior) || (dInicio > dFecInicioAnterior && dFin < dFecFinAnterior))
                        {
                            MessageBox.Show("El Intervalo del Periodo o parte de éste, se encuentra contenido en el Periodo de " + Convert.ToString(dtgPeriodos.Rows[i].Cells["cMes"].Value) + ". Verifique", "Mantenimiento de Periodos de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                this.txtDenominacion.Text = Convert.ToString(this.dtgPeriodos.Rows[filaseleccionada].Cells["cPeriodoDeclaracion"].Value);
                this.dtpFecInicio.Value = Convert.ToDateTime(this.dtgPeriodos.Rows[filaseleccionada].Cells["dFechaInicio"].Value.ToString());
                this.dtpFecFin.Value = Convert.ToDateTime(this.dtgPeriodos.Rows[filaseleccionada].Cells["dFechaFin"].Value.ToString());
                this.cboEstadoPeriodo1.SelectedValue = Convert.ToString(this.dtgPeriodos.Rows[filaseleccionada].Cells["idEstado"].Value);

                HabilitarControles(false);
                pcTipOpe = "A";
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnEliminar.Enabled = true;
            }
            else
            {
                Limpiar();
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnEliminar.Enabled = false;
            }
        }

        private void dtgPeriodos_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
             if (dtpFecInicio.Value.Date <= clsVarGlobal.dFecSystem.Date)
            {
                MessageBox.Show("No se puede eliminar los periodos que se encuentren Vigentes o ya culminaron", "Mantenimiento de Periodos de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            string cDenominacion = Convert.ToString(txtDenominacion.Text);
            DateTime dFechaInicio = Convert.ToDateTime(dtpFecInicio.Text);
            DateTime dFechaFin = Convert.ToDateTime(dtpFecFin.Text);
            int idEstadoPeriodo = Convert.ToInt32(cboEstadoPeriodo1.SelectedValue);
            int idMes=Convert.ToDateTime(dtpFecInicio.Value).Month;
            
            int filaseleccionada = Convert.ToInt32(this.dtgPeriodos.CurrentRow.Index);
            int idPeriodo = Convert.ToInt32(dtgPeriodos.Rows[filaseleccionada].Cells["idPeriodoDeclaracion"].Value);

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar el Periodo?", "Mantenimiento de Periodos de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                clsCNPeriodoDeclaracion GuardaPeriodos = new clsCNPeriodoDeclaracion();
                GuardaPeriodos.CNActualizarPeriodoDeclaracion(idPeriodo, cDenominacion, dFechaInicio, dFechaFin,
                                                         idEstadoPeriodo,idMes, 0);
                MessageBox.Show("El periodo fue eliminado ", "Mantenimiento de Periodos de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BuscarPeriodos();
            }
            else
                return;
         }
    }
}
