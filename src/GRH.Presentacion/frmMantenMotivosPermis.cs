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
    public partial class frmMantenMotivosPermis : frmBase
    {
        DataTable dtMotivos;
        public string pcTipOpe = "N"; //Puede ser N --> Nuevo, A--> Actualizar
        clsCNMotivoInasistencia MantMotivos = new clsCNMotivoInasistencia();

        public frmMantenMotivosPermis()
        {
            InitializeComponent();
        }

        private void frmMantenMotivosPermis_Load(object sender, EventArgs e)
        {            
            Limpiar();
            HabilitarControles(false);
            BuscarMotivos();
            
        }
        private void BuscarMotivos()
        {
            dtMotivos = MantMotivos.ListarMotivos();

            if (dtgMotivos.ColumnCount > 0)
            {
                dtgMotivos.Columns.Remove("idMotivo");
                dtgMotivos.Columns.Remove("cMotivo");
                dtgMotivos.Columns.Remove("lContaLaborable");
                dtgMotivos.Columns.Remove("lContaFalta");
                dtgMotivos.Columns.Remove("lContaDescuento");
                dtgMotivos.Columns.Remove("lPermisoUsuario");
                dtgMotivos.Columns.Remove("lJustificacion");
                dtgMotivos.Columns.Remove("lPermisoRRHH");

            }
            dtgMotivos.DataSource = dtMotivos.DefaultView;

            dtgMotivos.Columns["idMotivo"].Width = 15;
            dtgMotivos.Columns["idMotivo"].HeaderText = "Cod";
            dtgMotivos.Columns["idMotivo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgMotivos.Columns["cMotivo"].Width = 65;
            dtgMotivos.Columns["cMotivo"].HeaderText = "Nombre del Motivo";
            dtgMotivos.Columns["cMotivo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dtgMotivos.Columns["lContaLaborable"].Visible = false;
            dtgMotivos.Columns["lContaFalta"].Visible = false;
            dtgMotivos.Columns["lContaDescuento"].Visible = false;
            dtgMotivos.Columns["lPermisoUsuario"].Visible = false;
            dtgMotivos.Columns["lJustificacion"].Visible = false;
            dtgMotivos.Columns["lPermisoRRHH"].Visible = false;
           
        }
        private void Limpiar()
        {
            this.txtNomMotivo.Clear();
            this.CBLaborable.Checked = false;
            this.CBFalta.Checked = false;
            this.CBDescuento.Checked = false;
            this.CBPermiso.Checked = false;
            this.CBJustificacion.Checked = false;
            this.CBPermisoRRHH.Checked = false;

        }
        private void HabilitarControles(Boolean Val)
        {
            this.txtNomMotivo.Enabled = Val;
            this.CBLaborable.Enabled = Val;
            this.CBFalta.Enabled = Val;
            this.CBDescuento.Enabled = Val;
            this.CBPermiso.Enabled = Val;
            this.CBJustificacion.Enabled = Val;
            this.CBPermisoRRHH.Enabled = Val;

        }

        private void btnNuevo1_Click(object sender, System.EventArgs e)
        {
            pcTipOpe = "N";
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnEliminar.Enabled = false;
            this.btnCancelar1.Enabled = true;
            Limpiar();
            HabilitarControles(true);
             
        }

        private void btnEditar1_Click(object sender, System.EventArgs e)
        {
            pcTipOpe = "A";
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnEliminar.Enabled = false;
            this.btnCancelar1.Enabled = true;
            HabilitarControles(true);     
        }
     
        private string ValidarDatos()
        {
            if (txtNomMotivo.Text.Trim() == "") {
                MessageBox.Show("Ingrese el nombre del Motivo", "Mantenimiento de Motivos de Justificación y permisos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNomMotivo.Focus();
                return "ERROR";
            }

            
            if (pcTipOpe == "N")
            {
                for (int i = 0; i < dtgMotivos.Rows.Count; i++)
                {
                    if (Convert.ToString(dtgMotivos.Rows[i].Cells["cMotivo"].Value) == txtNomMotivo.Text.Trim())
                    {
                        MessageBox.Show("Ya existe un Motivo con ese nombre", "Mantenimiento de Motivos de Justificación y permisos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNomMotivo.Focus();
                        return "ERROR";
                    }
                    
                }
            }

            if (pcTipOpe == "A")
            {
                int filaseleccionada = Convert.ToInt32(this.dtgMotivos.CurrentRow.Index);
                
                for (int i = 0; i < dtgMotivos.Rows.Count;i++ )
                {
                    if (filaseleccionada != i)
                    {
                        if (Convert.ToString(dtgMotivos.Rows[i].Cells["cMotivo"].Value) == txtNomMotivo.Text.Trim())
                        {
                            MessageBox.Show("Ya existe un Motivo con ese nombre", "Mantenimiento de Motivos de Justificación y permisos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNomMotivo.Focus();
                            return "ERROR";
                        }
                    }
                }
            }
            
            return "OK";
        }

        private void MostrarDatos()
        {

            if (dtgMotivos.SelectedRows.Count > 0)
            {
                int filaseleccionada = Convert.ToInt32(this.dtgMotivos.CurrentRow.Index);

                this.txtNomMotivo.Text = Convert.ToString(this.dtgMotivos.Rows[filaseleccionada].Cells["cMotivo"].Value);
                this.CBLaborable.Checked = Convert.ToBoolean(this.dtgMotivos.Rows[filaseleccionada].Cells["lContaLaborable"].Value);
                this.CBFalta.Checked = Convert.ToBoolean(this.dtgMotivos.Rows[filaseleccionada].Cells["lContaFalta"].Value.ToString());
                this.CBDescuento.Checked = Convert.ToBoolean(this.dtgMotivos.Rows[filaseleccionada].Cells["lContaDescuento"].Value);
                this.CBPermiso.Checked = Convert.ToBoolean(this.dtgMotivos.Rows[filaseleccionada].Cells["lPermisoUsuario"].Value);
                this.CBJustificacion.Checked = Convert.ToBoolean(this.dtgMotivos.Rows[filaseleccionada].Cells["lJustificacion"].Value);
                this.CBPermisoRRHH.Checked = Convert.ToBoolean(this.dtgMotivos.Rows[filaseleccionada].Cells["lPermisoRRHH"].Value);
                               
                HabilitarControles(false);
                pcTipOpe = "A";                
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = true;                  
                this.btnEliminar.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnCancelar1.Enabled = false;
            }

        }

        private void btnGrabar_Click_1(object sender, EventArgs e)
        {
            if (ValidarDatos() == "ERROR")
            {
                return;
            }

            string cNombreMot = txtNomMotivo.Text.Trim();
            int lLaborable = Convert.ToInt32(CBLaborable.Checked);
            int lFalta = Convert.ToInt32(CBFalta.Checked);
            int lIngreso = Convert.ToInt32(CBDescuento.Checked);
            int lPermiso = Convert.ToInt32(CBPermiso.Checked);
            int lJustificacion = Convert.ToInt32(CBJustificacion.Checked);
            int lPermRRHH = Convert.ToInt32(CBPermisoRRHH.Checked);


            if (pcTipOpe == "A")
            {
                int filaseleccionada = Convert.ToInt32(this.dtgMotivos.CurrentRow.Index);
                int idMotivoAux = Convert.ToInt32(dtgMotivos.Rows[filaseleccionada].Cells["idMotivo"].Value);

                //TipOpercion 1=Modificar, 0=eliminar
                MantMotivos.ActualizarMotivos(1,idMotivoAux, cNombreMot, lLaborable, lFalta, lIngreso, lPermiso,
                                                  lJustificacion, lPermRRHH);
                MessageBox.Show("Se han actualizado correctamente los Datos ", "Mantenimiento de Horarios", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //cargar de nuevo y seleccionar la primera de todos los registros que fueroon modificados

                BuscarMotivos();
                int n = 0;
                foreach (DataGridViewRow fila in dtgMotivos.Rows)
                {
                    n += 1;
                    if (Convert.ToInt32(fila.Cells["idMotivo"].Value) == idMotivoAux)
                    {
                        dtgMotivos.CurrentCell = dtgMotivos.Rows[n - 1].Cells[0];
                        MostrarDatos();
                    }
                }

            }

            else if (pcTipOpe == "N")
            {

                int NuevoId = MantMotivos.GuardarMotivos(cNombreMot, lLaborable, lFalta, lIngreso, lPermiso,
                                                                 lJustificacion, lPermRRHH);
                MessageBox.Show("Se han Registrado los Datos Correctamente", "Mantenimiento de Tarifario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //cargar de nuevo y seleccionar el registros con la tasa recien añadida

                BuscarMotivos();
                int n = 0;
                foreach (DataGridViewRow fila in dtgMotivos.Rows)
                {
                    n += 1;
                    if (Convert.ToInt32(fila.Cells["idMotivo"].Value) == NuevoId)
                    {
                        dtgMotivos.CurrentCell = dtgMotivos.Rows[n - 1].Cells[0];
                        MostrarDatos();
                    }
                }


                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnEliminar.Enabled = true;
                this.btnCancelar1.Enabled = false;

            }
        }
                
        private void dtgMotivos_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            if (dtgMotivos.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar el Motivo?", "Mantenimiento de Motivos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {

                    int filaseleccionada = Convert.ToInt32(this.dtgMotivos.CurrentRow.Index);
                    int idMotivoAux = Convert.ToInt32(dtgMotivos.Rows[filaseleccionada].Cells["idMotivo"].Value);


                    //TipOpercion 1=Modificar, 0=eliminar
                    MantMotivos.ActualizarMotivos(0, idMotivoAux, Convert.ToString(dtgMotivos.Rows[filaseleccionada].Cells["cMotivo"].Value),
                                                    Convert.ToInt32(dtgMotivos.Rows[filaseleccionada].Cells["lContaLaborable"].Value),
                                                    Convert.ToInt32(dtgMotivos.Rows[filaseleccionada].Cells["lContaFalta"].Value),
                                                    Convert.ToInt32(dtgMotivos.Rows[filaseleccionada].Cells["lContaDescuento"].Value),
                                                    Convert.ToInt32(dtgMotivos.Rows[filaseleccionada].Cells["lPermisoUsuario"].Value),
                                                    Convert.ToInt32(dtgMotivos.Rows[filaseleccionada].Cells["lJustificacion"].Value),
                                                    Convert.ToInt32(dtgMotivos.Rows[filaseleccionada].Cells["lPermisoRRHH"].Value));
                    MessageBox.Show("Se ha eliminado correctamente el Motivo ", "Mantenimiento de Motivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BuscarMotivos();
                }
                else
                    return;
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            HabilitarControles(false);
            MostrarDatos();
        }
    }
}
