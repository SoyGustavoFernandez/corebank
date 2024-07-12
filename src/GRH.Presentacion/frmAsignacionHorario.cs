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
    public partial class frmAsignacionHorario : frmBase
    {
       
        public DataTable dtAsigHorario;
        public string TipoOper = "N";
        public frmAsignacionHorario()
        {
            InitializeComponent();
        }

        private void frmAsignacionHorario_Load(object sender, EventArgs e)
        {
            this.CleanData();
            HabilitarControles(false);            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
                CleanData();
                if (dtgAsignaciones.Rows.Count > 0)
                    dtAsigHorario.Rows.Clear();
                this.conBusCol1.txtCod.Clear();
                this.conBusCol1.txtNom.Clear();
                this.conBusCol1.txtCargo.Clear();
                
                this.HabilitarControles(false);
                this.conBusCol1.txtCod.Enabled = true;
                this.conBusCol1.txtCod.Focus();
                this.conBusCol1.btnConsultar.Enabled = true;

                
                this.btnEliminar1.Enabled = false;
                this.btnNuevo1.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnGrabar.Enabled = false;
            

        }
       
        private void conBusCol1_BuscarUsuario(object sender, EventArgs e)
        {            
            if (conBusCol1.txtCod.Text.Trim() == "")
            {   
                this.CleanData();
                MessageBox.Show("No se encontró registro", "Asignacion de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusCol1.txtCod.Focus();
                return;
            }
           
            Int32 nidCliente = Convert.ToInt32(this.conBusCol1.txtCod.Text);
            this.BuscaPersonal(nidCliente);
            conBusCol1.btnConsultar.Enabled = true;
            conBusCol1.txtCod.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //encontrar el la mayor fecha de inicio- Solo se puede editar la ultima asignación
            DateTime FechaInicioMayor = Convert.ToDateTime(dtgAsignaciones.Rows[0].Cells["dFechaInicio"].Value).Date;
            foreach (DataGridViewRow fila in dtgAsignaciones.Rows)
            {                
                if (Convert.ToDateTime(fila.Cells["dFechaInicio"].Value).Date > FechaInicioMayor)
                {
                    FechaInicioMayor=Convert.ToDateTime(fila.Cells["dFechaInicio"].Value).Date;
                }
            }
            Int32 nFila = Convert.ToInt32(dtgAsignaciones.SelectedCells[1].RowIndex);
            if(Convert.ToDateTime(dtgAsignaciones.Rows[nFila].Cells["dFechaInicio"].Value).Date!=FechaInicioMayor)   {
                MessageBox.Show("Sólo se puede editar la ultima asignación, si desea editar ésta, primero debe eliminar las asignaciones posteriores", "Asignacion de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;            
            }

            if (CBIndicarFecha.Checked == true)
            {
                if (Convert.ToDateTime(dtgAsignaciones.Rows[nFila].Cells["dFechaFin"].Value).Date < clsVarGlobal.dFecSystem.Date)
                {
                    MessageBox.Show("No se puede modificar la Asignación de Horario, ya que su periodo a caducado", "Asignacion de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            TipoOper = "A";
            this.HabilitarControles(true);
            if (Convert.ToDateTime(dtgAsignaciones.Rows[nFila].Cells["dFechaInicio"].Value).Date <= clsVarGlobal.dFecSystem.Date)
            {
                this.dtpFecInicio.Enabled = false;
                this.cboTipoHorario1.Enabled = false;
            }
            
            if (CBIndicarFecha.Checked == false)
                this.dtpFecFin.Enabled = false;
            
            this.btnEliminar1.Enabled = false;
            this.btnNuevo1.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
                       
        }
        public void HabilitarControles(Boolean bVal)
        {
            this.cboTipoHorario1.Enabled = bVal;
            this.dtpFecInicio.Enabled = bVal;
            this.dtpFecFin.Enabled = bVal;
            this.CBIndicarFecha.Enabled = bVal;
           
        }

        public void BuscaPersonal(Int32 nIdCliente)
        {
            clsCNAsignacionHorario Horario = new clsCNAsignacionHorario();
            dtAsigHorario = Horario.DatosAsigHorario(nIdCliente);


            if (dtgAsignaciones.ColumnCount > 0)
            {                
                dtgAsignaciones.Columns.Remove("idHorario");
                dtgAsignaciones.Columns.Remove("cHorario");
                dtgAsignaciones.Columns.Remove("dFechaInicio");
                dtgAsignaciones.Columns.Remove("dFechaFin");
                dtgAsignaciones.Columns.Remove("idHorarioUsuario");
            }
         
            dtgAsignaciones.DataSource = dtAsigHorario.DefaultView;
            
            dtgAsignaciones.Columns["idHorario"].Visible = false;
            dtgAsignaciones.Columns["cHorario"].HeaderText = "Nombre del Horario";
            dtgAsignaciones.Columns["cHorario"].Width = 60;
            dtgAsignaciones.Columns["cHorario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgAsignaciones.Columns["dFechaInicio"].HeaderText = "F. Inicio";
            dtgAsignaciones.Columns["dFechaInicio"].Width = 25;
            dtgAsignaciones.Columns["dFechaInicio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgAsignaciones.Columns["dFechaFin"].HeaderText = "F. Final";
            dtgAsignaciones.Columns["dFechaFin"].Width = 25;
            dtgAsignaciones.Columns["dFechaFin"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgAsignaciones.Columns["idHorarioUsuario"].Visible = false;

            //========================================================================
            //--Asignando Valores
            //========================================================================
            if (dtAsigHorario.Rows.Count == 0)
            {
                MessageBox.Show("Dicho personal no tiene asignado ningún un horario", "Asignacion de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.CleanData();

                this.HabilitarControles(false);
                this.btnEliminar1.Enabled = false;
                this.btnNuevo1.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = true;
                return;
            }
            MostrarDatos();
            
        }
        private void MostrarDatos() {
            if (dtgAsignaciones.SelectedRows.Count > 0)
            {
                Int32 nFila = Convert.ToInt32(dtgAsignaciones.SelectedCells[1].RowIndex);
                
                this.cboTipoHorario1.SelectedValue = dtgAsignaciones.Rows[nFila].Cells["idHorario"].Value.ToString();
                this.dtpFecInicio.Value = Convert.ToDateTime(dtgAsignaciones.Rows[nFila].Cells["dFechaInicio"].Value.ToString());
                if (string.IsNullOrEmpty(dtgAsignaciones.Rows[nFila].Cells["dFechaFin"].Value.ToString()))
                {
                    this.dtpFecFin.Value = Convert.ToDateTime("01/01/1900");
                    this.CBIndicarFecha.Checked = false;
                }
                else
                {
                    this.dtpFecFin.Value = Convert.ToDateTime(dtgAsignaciones.Rows[nFila].Cells["dFechaFin"].Value.ToString());
                    this.CBIndicarFecha.Checked = true;
                } 
                this.HabilitarControles(false);
                this.btnEliminar1.Enabled = true;
                this.btnNuevo1.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = true;

            }
                
        }

        private bool ValidarData()
        {           
            
            if (cboTipoHorario1.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar el Tipo de Horario", "Asignacion de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoHorario1.Focus();                
                return false;
            }
            if (CBIndicarFecha.Checked == true)
            {
                if (dtpFecInicio.Value.Date == dtpFecFin.Value.Date)
                {
                    MessageBox.Show("La Fecha de Inicio y la Fecha Final no pueden ser iguales", "Asignacion de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboTipoHorario1.Focus();
                    return false;
                }
                if (dtpFecInicio.Value.Date > dtpFecFin.Value.Date)
                {
                    MessageBox.Show("La Fecha de Inicio no puede ser mayor que la Fecha Final", "Asignacion de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboTipoHorario1.Focus();
                    return false;
                }
            }

           
            
            return true;
        }

        private void CleanData()
        {
            this.cboTipoHorario1.SelectedIndex=-1;
            this.dtpFecInicio.Value = clsVarGlobal.dFecSystem;
            this.dtpFecFin.Value = clsVarGlobal.dFecSystem;
            this.CBIndicarFecha.Checked = false;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarData())
                return;

            if (TipoOper == "A")
            {
                    Int32 nFila = Convert.ToInt32(dtgAsignaciones.SelectedCells[1].RowIndex);
                    //SI LA FECHA INICIAL ERA POSTERIOR A LA DE HOY , NO SE PUEDE ACTUAIZAR A UNA ANTERIOR O IGUAL A ESTA
                    if (Convert.ToDateTime(dtgAsignaciones.Rows[nFila].Cells["dFechaInicio"].Value) > clsVarGlobal.dFecSystem.Date)
                    {
                        if (dtpFecInicio.Value.Date <= clsVarGlobal.dFecSystem.Date)
                        {
                            MessageBox.Show("La fecha Inicial no puede ser anterior a la de Hoy, ya que a la fecha esta Asignación de horario no ha producido ningún registro", "Asignación de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }


                    // LA FECHA FINAL NO PUEDE SER ANTERIOR A LA DEL SISTEMA, PQ YA SE HA GENERADO SU KARDEX DE ASISTENCIA
                    if (CBIndicarFecha.Checked == true)
                    {
                        if (Convert.ToDateTime(dtpFecFin.Value).Date < clsVarGlobal.dFecSystem.Date)
                        {
                            MessageBox.Show("La fecha final no puede ser anterior a la de Hoy, ya que hasta la fecha ha generado registros de asistencia ", "Asignación de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }


                    int idAsig = Convert.ToInt32(dtgAsignaciones.Rows[nFila].Cells["idHorarioUsuario"].Value.ToString());

                    int idHorario = (int)cboTipoHorario1.SelectedValue;
                    DateTime tdFechInicio = dtpFecInicio.Value.Date;
                    DateTime tdFechaFin = dtpFecFin.Value.Date;

                    //===================================================================
                    //Actualizar Datos del Personal
                    //===================================================================
                    clsCNAsignacionHorario GuardaPersonal = new clsCNAsignacionHorario();
                    GuardaPersonal.ActualizarAsigHorario(idAsig, idHorario, tdFechInicio, tdFechaFin, 1);
                    MessageBox.Show("Los Datos se Actualizaron Correctamente", "Asignacion de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    this.BuscaPersonal(Convert.ToInt32(conBusCol1.txtCod.Text.Trim()));

                    int n = 0;
                    foreach (DataGridViewRow fila in dtgAsignaciones.Rows)
                    {
                        n += 1;
                        if (Convert.ToInt32(fila.Cells["idHorarioUsuario"].Value) == idAsig)
                        {
                            dtgAsignaciones.CurrentCell = dtgAsignaciones.Rows[n - 1].Cells["dFechaInicio"];
                            MostrarDatos();
                        }
                    }
            }
            if (TipoOper == "N")
            {
                if (dtpFecInicio.Value.Date <= clsVarGlobal.dFecSystem.Date)
                {
                    MessageBox.Show("La fecha Inicial no puede ser anterior o igual a la Fecha de Hoy", "Asignación de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //ENCONTRAR LA MAYOR FECHA DE INICIO- LA F. DE INICIO TIENE QUE SER POSTERIOR A LA ULTIMA ASIGNACION
                if (dtgAsignaciones.Rows.Count > 0)
                {
                    DateTime FechaInicioMayor = Convert.ToDateTime(dtgAsignaciones.Rows[0].Cells["dFechaInicio"].Value).Date;
                    DateTime FechaFinalMayor = Convert.ToDateTime(dtgAsignaciones.Rows[0].Cells["dFechaFin"].Value).Date;
                    foreach (DataGridViewRow fila in dtgAsignaciones.Rows)
                    {
                        if (Convert.ToDateTime(fila.Cells["dFechaInicio"].Value).Date > FechaInicioMayor)
                        {
                            FechaInicioMayor = Convert.ToDateTime(fila.Cells["dFechaInicio"].Value).Date;
                            FechaFinalMayor = Convert.ToDateTime(fila.Cells["dFechaFin"].Value).Date;
                        }
                    }
                    if (dtpFecInicio.Value.Date <= FechaInicioMayor)
                    {
                        MessageBox.Show("No se puede establecer asignaciones con fechas anteriores o iguales a la asignación más reciente", "Asignacion de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (dtpFecInicio.Value.Date <= FechaFinalMayor)
                    {
                        MessageBox.Show("La fecha Inicial no puede ser anterior o igual a la Fecha final de la última asignación", "Asignacion de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                int idPersonal = Convert.ToInt32(conBusCol1.txtCod.Text.Trim());
                int idHorario = (int)cboTipoHorario1.SelectedValue;
                DateTime tdFechInicio = dtpFecInicio.Value.Date;
                DateTime tdFechaFin = dtpFecFin.Value.Date;

                //===================================================================
                //Guardar Datos de la Asignacion 
                //===================================================================
                clsCNAsignacionHorario GuardaPersonal = new clsCNAsignacionHorario();
                int idAsig = GuardaPersonal.GuardaAsigHorario(idPersonal, idHorario, tdFechInicio, tdFechaFin);

                //volver a cargar y seleccionar la fila 
                BuscaPersonal(Convert.ToInt32(conBusCol1.txtCod.Text.Trim()));
                int m = 0;
                foreach (DataGridViewRow fila in dtgAsignaciones.Rows)
                {
                    m += 1;
                    if (Convert.ToInt32(fila.Cells["idHorarioUsuario"].Value) == idAsig)
                    {
                        dtgAsignaciones.CurrentCell = dtgAsignaciones.Rows[m - 1].Cells["dFechaInicio"];
                        MostrarDatos();
                    }
                }
                MessageBox.Show("Se asignó correctamente el Horario", "Asignacion de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }


        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow fila in dtgAsignaciones.Rows)
            {
                if (string.IsNullOrEmpty(fila.Cells["dFechaFin"].Value.ToString()))                
                {
                    MessageBox.Show("Existe una asignación con fecha Final no definida, primero definala para poder agregar otra", "Asignacion de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            TipoOper = "N";
            HabilitarControles(true);
            CleanData();
            CBIndicarFecha.Checked = true;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;

            this.btnEliminar1.Enabled = false;
            this.btnNuevo1.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
        }

        private void dtgAsignaciones_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }
         

        private void chcBase1_CheckedChanged(object sender, EventArgs e)
        {
            if (CBIndicarFecha.Enabled == true)
            {
                dtpFecFin.Enabled = CBIndicarFecha.Checked;
                if (CBIndicarFecha.Checked == false)
                    dtpFecFin.Value = Convert.ToDateTime("01/01/1900");
            }
        }

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            if (dtgAsignaciones.SelectedRows.Count > 0)
            {
                Int32 nFila = Convert.ToInt32(dtgAsignaciones.SelectedCells[1].RowIndex);
                if (Convert.ToDateTime(dtgAsignaciones.Rows[nFila].Cells["dFechaInicio"].Value).Date <= clsVarGlobal.dFecSystem.Date)
                {
                    MessageBox.Show("No se puede eliminar las asignaciones cuyo proceso está en curso o ya culminó", "Asignacion de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                int idAsig = Convert.ToInt32(dtgAsignaciones.Rows[nFila].Cells["idHorarioUsuario"].Value);

                int idHorario = (int)cboTipoHorario1.SelectedValue;
                DateTime tdFechInicio = dtpFecInicio.Value.Date;
                DateTime tdFechaFin = dtpFecFin.Value.Date;

                //===================================================================
                //Actualizar Datos del Personal
                //===================================================================

                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminarlo?", "Asignacion de Horarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    clsCNAsignacionHorario GuardaPersonal = new clsCNAsignacionHorario();
                    GuardaPersonal.ActualizarAsigHorario(idAsig, idHorario, tdFechInicio, tdFechaFin, 0);
                    this.BuscaPersonal(Convert.ToInt32(conBusCol1.txtCod.Text.Trim()));
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
        }

        
       
    }
}
