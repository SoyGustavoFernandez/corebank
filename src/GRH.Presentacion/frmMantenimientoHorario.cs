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
    public partial class frmMantenimientoHorario : frmBase
    {
        DataTable dtHorarios;
        public string pcTipOpe = "N"; //Puede ser N --> Nuevo, A--> Actualizar
        public frmMantenimientoHorario()
        {
            InitializeComponent();
        }

        private void frmMantenimientoHorario_Load(object sender, EventArgs e)
        {
            cboTipoHorario1.SelectedIndex = -1;
            Limpiar();
            HabilitarControles(false);
        }

        private void cboTipoHorario1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoHorario1.Text != "")
            {                
                BuscarHorarios();
                this.txtNombHorario.Text = cboTipoHorario1.Text;
                this.txtNombHorario.Enabled = false;
                this.CBHorNocturno.Enabled = false;
                btnMiniNuevo.Enabled = true;
                btnMiniEliminar.Enabled = true;
                btnMiniGrabar.Enabled = false;
            }
            else
            {
                if (dtgHorario.Rows.Count > 0)
                    dtHorarios.Rows.Clear();

                this.txtNombHorario.Clear();
                this.txtNombHorario.Enabled = false;
                this.CBHorNocturno.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
                HabilitarControles(false);    

                btnMiniNuevo.Enabled = true;
                btnMiniEliminar.Enabled = false;
                btnMiniGrabar.Enabled = false;
            }
        }
        private void BuscarHorarios(){
            int idHorario=Convert.ToInt32(cboTipoHorario1.SelectedValue);
            clsCNMantenimientoHorario LitaHorarios = new clsCNMantenimientoHorario();
            dtHorarios = LitaHorarios.ListarDetalleHorarios(idHorario);

            int lHorNocturno = LitaHorarios.DatoHorarioNoc(idHorario);
            this.CBHorNocturno.Checked = Convert.ToBoolean(lHorNocturno);

            if (dtgHorario.ColumnCount > 0)
            {
                dtgHorario.Columns.Remove("idDetalleHorario");
                dtgHorario.Columns.Remove("idDiaIngreso");
                dtgHorario.Columns.Remove("DiaIngreso");
                dtgHorario.Columns.Remove("tHoraIngreso");
                dtgHorario.Columns.Remove("lMarcaIngreso");
                dtgHorario.Columns.Remove("nMinAntesIngreso");
                dtgHorario.Columns.Remove("nMinToleraIngreso");
                dtgHorario.Columns.Remove("idDiaSalida");
                dtgHorario.Columns.Remove("DiaSalida");
                dtgHorario.Columns.Remove("tHoraSalida");
                dtgHorario.Columns.Remove("lMarcaSalida");
                dtgHorario.Columns.Remove("nMinAntesSalida");
                dtgHorario.Columns.Remove("nMinToleraSalida");              
                dtgHorario.Columns.Remove("lVigente");            

            }
            dtgHorario.DataSource = dtHorarios.DefaultView;

            dtgHorario.Columns["idDetalleHorario"].Width = 20;
            dtgHorario.Columns["idDetalleHorario"].HeaderText = "Cod";
            dtgHorario.Columns["idDetalleHorario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgHorario.Columns["idDiaIngreso"].Visible = false;
            dtgHorario.Columns["DiaIngreso"].Width = 55;
            dtgHorario.Columns["DiaIngreso"].HeaderText = "Día Ingreso";
            dtgHorario.Columns["DiaIngreso"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgHorario.Columns["tHoraIngreso"].Width = 55;
            dtgHorario.Columns["tHoraIngreso"].HeaderText = "Hora Ingreso";
            dtgHorario.Columns["tHoraIngreso"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgHorario.Columns["lMarcaIngreso"].Visible = false;   
            dtgHorario.Columns["nMinAntesIngreso"].Visible = false;
            dtgHorario.Columns["nMinToleraIngreso"].Visible = false;   
            dtgHorario.Columns["idDiaSalida"].Visible = false;

            dtgHorario.Columns["DiaSalida"].Width = 55;
            dtgHorario.Columns["DiaSalida"].HeaderText = "Día Salida";
            dtgHorario.Columns["DiaSalida"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgHorario.Columns["tHoraSalida"].Width = 55;
            dtgHorario.Columns["tHoraSalida"].HeaderText = "Hora Salida";
            dtgHorario.Columns["tHoraSalida"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgHorario.Columns["lMarcaSalida"].Visible = false;
            dtgHorario.Columns["nMinAntesSalida"].Visible = false;
            dtgHorario.Columns["nMinToleraSalida"].Visible = false;          

            dtgHorario.Columns["lVigente"].Width = 35;
            dtgHorario.Columns["lVigente"].HeaderText = "Vig.";

            MostrarDatos();
        
        }
        private void Limpiar() {
            this.cboDiasSemIngreso.SelectedIndex = -1;
            this.dtHoraIngreso.Value = Convert.ToDateTime("00:00 AM");
            this.txtAntesIngreso.Clear();
            this.txtToleranciaIngreso.Clear();
            this.CBMarcaIngreso.Checked = false;

            this.cboDiasSemSalida.SelectedIndex = -1;
            this.dtHoraSalida.Value = Convert.ToDateTime("00:00 AM");
            this.txtAntesSalida.Clear();
            this.txtToleranciaSalida.Clear();
            this.CBMarcaSalida.Checked = false;
            this.CBVigente.Checked = false;
        
        }
        private void HabilitarControles(Boolean Val) {
            this.cboDiasSemIngreso.Enabled = Val;
            this.dtHoraIngreso.Enabled = Val;
            this.txtAntesIngreso.Enabled = Val;
            this.txtToleranciaIngreso.Enabled = Val;
            this.CBMarcaIngreso.Enabled = Val;

            this.cboDiasSemSalida.Enabled = Val;
            this.dtHoraSalida.Enabled = Val;
            this.txtAntesSalida.Enabled = Val;
            this.txtToleranciaSalida.Enabled = Val;
            this.CBMarcaSalida.Enabled = Val;
            this.CBVigente.Enabled = Val;
        
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            pcTipOpe = "A";
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
            HabilitarControles(true);     
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
            this.CBVigente.Checked = true;
            this.CBVigente.Enabled = false;         
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dtgHorario.Rows.Count > 0)
                dtHorarios.Rows.Clear();
            Limpiar();
            cboTipoHorario1.SelectedValue = -1;                        

            this.btnMiniGrabar.Enabled = false;
            this.btnMiniNuevo.Enabled = true;
            this.btnMiniEliminar.Enabled = false;
            this.txtNombHorario.Enabled = false;
            this.txtNombHorario.Clear();
            this.CBHorNocturno.Enabled = false;
            this.CBHorNocturno.Checked = false;
      
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos() == "ERROR")
            {
                return;
            }

            int idDiaIngreso = Convert.ToInt32(cboDiasSemIngreso.SelectedValue);
            DateTime HoraIngreso = Convert.ToDateTime(dtHoraIngreso.Value);
            int MinAntesIngreso = Convert.ToInt32(txtAntesIngreso.Text);
            int MinToleranciaIngreso = Convert.ToInt32(txtToleranciaIngreso.Text);
            int MarcaIngreso=Convert.ToInt32(CBMarcaIngreso.Checked);

            int idDiaSalida = Convert.ToInt32(cboDiasSemSalida.SelectedValue);
            DateTime HoraSalida = Convert.ToDateTime(dtHoraSalida.Value);
            int MinAntesSalida = Convert.ToInt32(txtAntesSalida.Text);
            int MinToleranciaSalida = Convert.ToInt32(txtToleranciaSalida.Text);
            int MarcaSalida = Convert.ToInt32(CBMarcaSalida.Checked);

            int Vigente = Convert.ToInt32(CBVigente.Checked);

            clsCNMantenimientoHorario GuardaHorarios = new clsCNMantenimientoHorario();

            if (pcTipOpe == "A")
            {              
                int filaseleccionada = Convert.ToInt32(this.dtgHorario.CurrentRow.Index);
                int idDetalleHorario = Convert.ToInt32(dtgHorario.Rows[filaseleccionada].Cells["idDetalleHorario"].Value);
                    

                DataTable tbHorarioDup = GuardaHorarios.ControlDuplicidad(Convert.ToInt32(cboTipoHorario1.SelectedValue), idDiaIngreso, HoraIngreso,
                                                                        idDiaSalida, HoraSalida);
                //Si existe duplicado        
                if (tbHorarioDup.Rows.Count > 0 && Convert.ToInt32(tbHorarioDup.Rows[0]["idDetalleHorario"]) != idDetalleHorario)
                {
                    int Duplicado = Convert.ToInt32(tbHorarioDup.Rows[0]["idDetalleHorario"]);
                    MessageBox.Show("No se puede guardar los cambios \n El intervalo entre las Horas de Ingreso y Salida del Horario N° " + Duplicado + " incluye valores del Intervalo del Horario modificado, Si desea Modifíquelo", "Mantenimiento de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //cargar de nuevo y seleccionar el registros que contien las mismas caracteristicas (duplicado)            

                    BuscarHorarios();

                    int n = 0;
                    foreach (DataGridViewRow fila in dtgHorario.Rows)
                    {
                        n += 1;
                        if (Convert.ToInt32(fila.Cells["idDetalleHorario"].Value) == Duplicado)
                        {
                            dtgHorario.CurrentCell = dtgHorario.Rows[n - 1].Cells[0];
                            MostrarDatos();
                        }
                    }

                }
                else
                {
                    
                    GuardaHorarios.ActualizarHorario(idDetalleHorario, idDiaIngreso, HoraIngreso, MinAntesIngreso,
                                                  MinToleranciaIngreso, MarcaIngreso, idDiaSalida, HoraSalida, MinAntesSalida, MinToleranciaSalida, MarcaSalida, Vigente);
                    MessageBox.Show("Se han actualizado correctamente los Datos ", "Mantenimiento de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    //cargar de nuevo y seleccionar la primera de todos los registros que fueroon modificados

                    BuscarHorarios();
                    int n = 0;
                    foreach (DataGridViewRow fila in dtgHorario.Rows)
                    {
                        n += 1;
                        if (Convert.ToInt32(fila.Cells["idDetalleHorario"].Value) == idDetalleHorario)
                        {
                            dtgHorario.CurrentCell = dtgHorario.Rows[n - 1].Cells[0];
                            MostrarDatos();
                        }
                    }
                }
            }

            else if (pcTipOpe == "N")
            {

                DataTable tbProdDup = GuardaHorarios.ControlDuplicidad(Convert.ToInt32(cboTipoHorario1.SelectedValue), idDiaIngreso, HoraIngreso,
                                                                        idDiaSalida, HoraSalida);
                //Si existe duplicado        
                if (tbProdDup.Rows.Count > 0)
                {
                    int Duplicado = Convert.ToInt32(tbProdDup.Rows[0]["idDetalleHorario"]);
                    MessageBox.Show("No se puede guardar el nuevo horario \n El intervalo de las Horas de Ingreso y Salida del Horario N° " + Duplicado + " incluye valores del Intervalo del Horario ingresado, Si desea Modifíquelo", "Mantenimiento de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //cargar de nuevo y seleccionar el registros que contien las mismas caracteristicas (duplicado)            

                    BuscarHorarios();

                    int n = 0;
                    foreach (DataGridViewRow fila in dtgHorario.Rows)
                    {
                        n += 1;
                        if (Convert.ToInt32(fila.Cells["idDetalleHorario"].Value) == Duplicado)
                        {
                            dtgHorario.CurrentCell = dtgHorario.Rows[n - 1].Cells[0];
                            MostrarDatos();
                        }
                    }

                }
                // si no existe duplicado
                else if (tbProdDup.Rows.Count == 0)
                {
                    int NuevoId = GuardaHorarios.GuardarHorario(Convert.ToInt32(cboTipoHorario1.SelectedValue), idDiaIngreso, HoraIngreso, MinAntesIngreso,
                                                  MinToleranciaIngreso, MarcaIngreso, idDiaSalida, HoraSalida, MinAntesSalida, MinToleranciaSalida, MarcaSalida, Vigente);
                    MessageBox.Show("Se han Registrado los Datos Correctamente", "Mantenimiento de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //cargar de nuevo y seleccionar el registros con la tasa recien añadida

                    BuscarHorarios();
                    int n = 0;
                    foreach (DataGridViewRow fila in dtgHorario.Rows)
                    {
                        n += 1;
                        if (Convert.ToInt32(fila.Cells["idDetalleHorario"].Value) == NuevoId)
                        {
                            dtgHorario.CurrentCell = dtgHorario.Rows[n - 1].Cells[0];
                            MostrarDatos();
                        }
                    }                    
                                
                }
            }
        }

        private string ValidarDatos()
        {
            if (cboDiasSemIngreso.Text.Trim() == "")
            {
                MessageBox.Show("Debe Indicar el Día de Ingreso", "Ingresar datos del Horario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboDiasSemIngreso.Focus();
                return "ERROR";
            }
            if (txtAntesIngreso.Text.Trim() == "")
            {
                MessageBox.Show("Debe Indicar la cantidad de Minutos permitidos antes de la Hora de Ingreso", "Ingresar datos del Horario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAntesIngreso.Focus();
                return "ERROR";
            }
            if (txtToleranciaIngreso.Text.Trim() == "")
            {
                MessageBox.Show("Debe Indicar la cantidad de Minutos de Tolerancia a la Hora de Ingreso", "Ingresar datos del Horario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtToleranciaIngreso.Focus();
                return "ERROR";
            }

            if (cboDiasSemSalida.Text.Trim() == "")
            {
                MessageBox.Show("Debe Indicar el Día de Salida", "Ingresar datos del Horario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboDiasSemSalida.Focus();
                return "ERROR";
            }
            if (((Convert.ToInt32(cboDiasSemSalida.SelectedValue) - Convert.ToInt32(cboDiasSemIngreso.SelectedValue)) < 0 && (Convert.ToInt32(cboDiasSemSalida.SelectedValue) - Convert.ToInt32(cboDiasSemIngreso.SelectedValue)) != (-6)) || (Convert.ToInt32(cboDiasSemSalida.SelectedValue) - Convert.ToInt32(cboDiasSemIngreso.SelectedValue) >= 2))
            {
                MessageBox.Show("El día de Salida NO puede ser anterior o posterior en 2 días o más al día de Ingreso", "Ingresar datos del Horario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboDiasSemSalida.Focus();
                return "ERROR";
            }
          
            if (txtAntesSalida.Text.Trim() == "")
            {
                MessageBox.Show("Debe Indicar la cantidad de Minutos permitidos antes de la Hora de Salida", "Ingresar datos del Horario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAntesSalida.Focus();
                return "ERROR";
            }
            if (txtToleranciaSalida.Text.Trim() == "")
            {
                MessageBox.Show("Debe Indicar la cantidad de Minutos de Tolerancia a la Hora de Salida", "Ingresar datos del Horario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtToleranciaSalida.Focus();
                return "ERROR";
            }
            
            return "OK";        
        }

        private void MostrarDatos()
        {
            if (Convert.ToInt32(this.dtgHorario.SelectedRows.Count) >= 1)
            {
                int filaseleccionada = Convert.ToInt32(this.dtgHorario.CurrentRow.Index);

                this.cboDiasSemIngreso.SelectedValue = Convert.ToInt32(this.dtgHorario.Rows[filaseleccionada].Cells["idDiaIngreso"].Value);

                this.dtHoraIngreso.Value = Convert.ToDateTime(this.dtgHorario.Rows[filaseleccionada].Cells["tHoraIngreso"].Value.ToString());
                this.txtAntesIngreso.Text = Convert.ToString(this.dtgHorario.Rows[filaseleccionada].Cells["nMinAntesIngreso"].Value);
                this.txtToleranciaIngreso.Text = Convert.ToString(this.dtgHorario.Rows[filaseleccionada].Cells["nMinToleraIngreso"].Value);
                this.CBMarcaIngreso.Checked = Convert.ToBoolean(this.dtgHorario.Rows[filaseleccionada].Cells["lMarcaIngreso"].Value);

                this.cboDiasSemSalida.SelectedValue = Convert.ToInt32(this.dtgHorario.Rows[filaseleccionada].Cells["idDiaSalida"].Value);
                this.dtHoraSalida.Value = Convert.ToDateTime(this.dtgHorario.Rows[filaseleccionada].Cells["tHoraSalida"].Value.ToString());
                this.txtAntesSalida.Text = Convert.ToString(this.dtgHorario.Rows[filaseleccionada].Cells["nMinAntesSalida"].Value);
                this.txtToleranciaSalida.Text = Convert.ToString(this.dtgHorario.Rows[filaseleccionada].Cells["nMinToleraSalida"].Value);
                this.CBMarcaSalida.Checked = Convert.ToBoolean(this.dtgHorario.Rows[filaseleccionada].Cells["lMarcaSalida"].Value);

                this.CBVigente.Checked = Convert.ToBoolean(this.dtgHorario.Rows[filaseleccionada].Cells["lVigente"].Value);
                
                HabilitarControles(false);
                pcTipOpe = "A";
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnGrabar.Enabled = false;
            }
            else
            {
                Limpiar();
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.btnGrabar.Enabled = false;
            }

        }

        private void dtgHorario_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }
            
        private void btnMiniNuevo_Click(object sender, EventArgs e)
        {
            this.txtNombHorario.Enabled = true;
            this.txtNombHorario.Clear();
            this.CBHorNocturno.Enabled = true;
            this.CBHorNocturno.Checked = false;
            btnMiniGrabar.Enabled = true;
            btnMiniEliminar.Enabled = false;
            btnMiniNuevo.Enabled = false;
        }

        private void btnMiniGrabar_Click(object sender, EventArgs e)
        {
            if (txtNombHorario.Text.Trim() == "") {
                MessageBox.Show("Ingrese el Nombre del Horario a crear", "Mantenimiento de Horario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombHorario.Focus();
                return;            
            }
            clsCNMantenimientoHorario GuardaHorarios = new clsCNMantenimientoHorario();
            int idTipoHorario = GuardaHorarios.CNCrearNuevoHorario(txtNombHorario.Text.Trim(), Convert.ToInt32(CBHorNocturno.Checked));

            if (idTipoHorario != 0)
            {
                MessageBox.Show("El Tipo de Horario fue creado correctamente", "Mantenimiento de Horario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTipoHorario1.RecargarCboTipoHorario();
                cboTipoHorario1.SelectedValue = idTipoHorario;
            }
            else
            {
                MessageBox.Show("Ya existe un Tipo de Horario con el mismo nombre. Verifique.", "Mantenimiento de Horario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnMiniEliminar_Click(object sender, EventArgs e)
        {
            clsCNMantenimientoHorario GuardaHorarios = new clsCNMantenimientoHorario();
            int CantAsignaciones=GuardaHorarios.CNEliminarHorario(Convert.ToInt32(cboTipoHorario1.SelectedValue));

            if (CantAsignaciones == 0) {
                MessageBox.Show("El Horario fue eliminado", "Mantenimiento de Horario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTipoHorario1.RecargarCboTipoHorario();
                cboTipoHorario1.SelectedValue = -1;
                CBHorNocturno.Checked = false;
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se puede eliminar dicho Horario, ya que existen " + CantAsignaciones +" asignaciones de este Horario a distintos colaboradores (Asignaciones actuales o futuras).", "Mantenimiento de Horario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }
              
    }
}
