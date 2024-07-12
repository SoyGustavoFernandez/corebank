using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;

namespace CAJ.Presentacion
{
    public partial class frmManRespBoveda : frmBase
    {
        #region variables
        DataTable tbColAge;
        int pidResBoveda = 0;
        clsCNControlOpe cnResBovAge = new clsCNControlOpe();
        DataTable tbResBovAge;
        int nOpcion = 0;
        #endregion
        #region eventos

        public frmManRespBoveda()
        {
            InitializeComponent();
        }
        private void frmManRespBoveda_Load(object sender, EventArgs e)
        {
            valorInicial();
            this.dtpFecFin.Value = clsVarGlobal.dFecSystem;
            this.cboColaborador.Enabled = false;
            this.cboTipResponsableCaja1.Enabled = false;
            this.chclVigente.Enabled = false;
            this.dtpFechaInicio.Enabled = false;
            this.dtpFecFin.Enabled = false;
            this.grbTiempo.Enabled = false;
            cboAgencias.SelectedIndex = -1;


        }

        private void cboAgencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgencias.SelectedIndex != -1)
            {
                int idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
                ListarColAgencia(idAgencia);
                cboTipResponsableCaja1.cargarTipoResponsableCajaAdm(idAgencia);
                DataRow row = ((DataTable)cboAgencias.DataSource).Rows[cboAgencias.SelectedIndex];
                string IdTipEsq = row["idTipEsquemaCaja"].ToString();
                if (IdTipEsq.Equals(""))
                {
                    btnNuevo1.Enabled = false;
                    btnEditar.Enabled = false;
                    MessageBox.Show("La agencia no tiene asignado el esquema de trabajo", "Mantenimiento de Responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (Convert.ToInt32(IdTipEsq) <= 0)
                {
                    btnNuevo1.Enabled = false;
                    btnEditar.Enabled = false;
                    MessageBox.Show("La agencia no tiene asignado el esquema de trabajo", "Mantenimiento de Responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                }
                else
                {
                    btnNuevo1.Enabled = true;
                    btnEditar.Enabled = true;

                }
            }
        }

        private void cboColaborador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbColAge.Rows.Count > 0 && cboColaborador.SelectedIndex != -1)
            {
                int i = this.cboColaborador.SelectedIndex;
                this.txtCargo.Text = tbColAge.Rows[i]["cCargo"].ToString();
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            #region validacion
            //==================================================================
            //--Validar Datos
            //==================================================================
            if (this.cboAgencias.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar la Agencia", "Mantenimiento de Responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgencias.Focus();
                this.cboAgencias.Select();
                return;
            }
            if (this.cboTipResponsableCaja1.SelectedIndex < 0 && chclVigente.Checked != true)
            {
                MessageBox.Show("Debe seleccionar el tipo de responsable.", "Mantenimiento de Responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboTipResponsableCaja1.Focus();
                this.cboTipResponsableCaja1.Select();
                return;
            }
            if (this.cboColaborador.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar al colaborador", "Mantenimiento de Responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboColaborador.Focus();
                this.cboColaborador.Select();
                return;
            }
            if (string.IsNullOrEmpty(this.txtCargo.ToString().Trim()))
            {
                MessageBox.Show("El colaborador debe tener un cargo", "Mantenimiento de Responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboColaborador.Focus();
                this.cboColaborador.Select();
                return;
            }

            if (rbtDeterminado.Checked == false && rbtIndeterminado.Checked == false)
            {
                MessageBox.Show("Debe elegir el tiempo como responsable de " + cboTipResponsableCaja1.Text.Substring(8), "Mantenimiento de Responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (rbtDeterminado.Checked == true && dtpFecFin.Value.Date < dtpFechaInicio.Value.Date && nOpcion == 1 && chclVigente.Checked != true)
            {
                MessageBox.Show("La fecha final debe ser mayor a la fecha de inicio.", "Mantenimiento de Responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dtpFechaInicio.Value < clsVarGlobal.dFecSystem && chclVigente.Checked != true && nOpcion == 1)
            {
                MessageBox.Show("La fecha inicio debe ser mayor o igual a la fecha del sistema.", "Mantenimiento de Responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dtpFechaInicio.Value.Date > dtpFecFin.Value.Date && chclVigente.Checked != true && nOpcion == 2 & rbtDeterminado.Checked)
            {
                MessageBox.Show("La fecha final debe ser mayor o igual a la fecha de inicio.", "Mantenimiento de Responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            #endregion
            //==================================================================
            //--Guardar Datos opcion nuevo
            //==================================================================
            if (nOpcion == 1)
            {
                ////Valida regitro unico
                if (lExisteResponsable())
                {
                    return;
                }
                int idUsu = Convert.ToInt32(this.cboColaborador.SelectedValue.ToString());
                int idAge = Convert.ToInt32(this.cboAgencias.SelectedValue.ToString());
                DateTime dFechIni = dtpFechaInicio.Value;
                int idTipoResponsable = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);

                bool lTiempoIndeter = rbtIndeterminado.Checked == true ? true : false;
                DateTime? dfecFin = null;

                if (lTiempoIndeter == false)
                {
                    dfecFin = dtpFecFin.Value;
                }

                string msge = cnResBovAge.GuardarResBovAge(idUsu, idAge, clsVarGlobal.nIdAgencia, clsVarGlobal.User.idUsuario, dFechIni, idTipoResponsable, lTiempoIndeter, dfecFin);
                if (msge.Equals("OK"))
                {
                    MessageBox.Show("Los datos se guardaron Correctamente", "Mantenimiento de responsables de bóveda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarColAgencia(idAge);
                    this.cboAgencias.Enabled = true;
                    this.cboColaborador.Enabled = false;
                    this.dtgResBov.Enabled = true;
                    ActivarBotones(true);
                    nOpcion = 0;
                }
                else
                {
                    MessageBox.Show(msge, "Error al registrar el responsable de bóveda", MessageBoxButtons.OK, MessageBoxIcon.Warning);                   
                    this.dtgResBov.DataSource = null;
                    tbResBovAge = cnResBovAge.ListarResBovAge(Convert.ToInt32(this.cboAgencias.SelectedValue.ToString()), clsVarGlobal.dFecSystem);
                    dtgResBov.DataSource = tbResBovAge;
                    FormatoGridCli();
                    btnCancelar_Click(sender,e);      
                }
            }
            //==================================================================
            //--Editar Datos opción nuevo
            //==================================================================
            if (nOpcion == 2)
            {
                if (chclVigente.Checked )
                {
                    int idUsuario, idTipResCaj, idAgencia, iFila;
                    iFila = dtgResBov.SelectedCells[0].RowIndex;
                    idUsuario = Convert.ToInt32(tbResBovAge.Rows[iFila]["idUsuario"].ToString());
                    idTipResCaj =  Convert.ToInt32(tbResBovAge.Rows[iFila]["idTipResCaj"].ToString());
                    idAgencia = Convert.ToInt32(cboAgencias.SelectedValue);
            
                    string cEstCie = cnResBovAge.ValidaIniOpeCaja(clsVarGlobal.dFecSystem, idUsuario, idAgencia, idTipResCaj);
                    if (cEstCie.Equals("A"))
                    {
                        MessageBox.Show("El usuario ya inició sus operaciones, \n debe cerrar para poder dar de baja", "Validar Inicio de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                bool lVigente = chclVigente.Checked == true ? false : true;
                
                bool lTiempoIndeter = rbtIndeterminado.Checked == true ? true : false;
                DateTime? dfecFin = null;
                if (lTiempoIndeter == false)
                {
                    dfecFin = dtpFecFin.Value;
                }
                if (lVigente == false)
                {
                    dfecFin = clsVarGlobal.dFecSystem;
                }
                string msge = cnResBovAge.EditarResBovAge(pidResBoveda, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, dfecFin, clsVarGlobal.nIdAgencia, lTiempoIndeter, lVigente);
                if (msge.Equals("OK"))
                {
                    MessageBox.Show("Los datos se actualizaron correctamente.", "Mantenimiento de responsables de bóveda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarColAgencia(Convert.ToInt32(this.cboAgencias.SelectedValue.ToString()));
                    this.cboAgencias.Enabled = true;
                    this.cboColaborador.Enabled = false;
                    this.dtgResBov.Enabled = true;
                    ActivarBotones(true);
                    nOpcion = 0;
                }
                else
                {
                    MessageBox.Show(msge, "Error al actualizar el responsable de bóveda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            if (cboAgencias.SelectedIndex <= -1)
            {
                MessageBox.Show("Debe seleccionar la agencia", "Mantenimiento de Responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            nOpcion = 1;
            this.cboAgencias.Enabled = false;
            this.cboColaborador.Enabled = true;
            this.cboTipResponsableCaja1.Enabled = true;
            this.chclVigente.Enabled = false;
            this.dtpFechaInicio.Enabled = true;
            this.dtpFecFin.Enabled = true;
            this.grbTiempo.Enabled = true;
            this.dtgResBov.Enabled = false;
            this.lblfecfin.Visible = false;
            this.dtpFecFin.Visible = false;
            rbtIndeterminado.Checked = false;
            rbtDeterminado.Checked = false;
            ActivarBotones(false);
            valorInicial();
            this.cboTipResponsableCaja1.Focus();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgResBov.RowCount > 0)
            {
                nOpcion = 2;
                this.chclVigente.Enabled = true;
                this.cboAgencias.Enabled = false;
                this.dtgResBov.Enabled = false;
                this.grbTiempo.Enabled = true;
                if (rbtDeterminado.Checked)
                {
                    dtpFecFin.Enabled = true;
                }
                ActivarBotones(false);
            }
            else
            {
                MessageBox.Show("No existe responsable para editar", "Mantenimiento de responsables de bóveda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
        }
        private void cancelar()
        {
            nOpcion = 0;
            this.cboAgencias.Enabled = true;
            this.cboTipResponsableCaja1.Enabled = false;
            this.cboColaborador.Enabled = false;
            this.chclVigente.Checked = false;
            this.chclVigente.Enabled = false;
            this.dtpFechaInicio.Enabled = false;
            this.dtgResBov.Enabled = true;
            this.grbTiempo.Enabled = false;
            this.dtpFecFin.Enabled = false;
            ActivarBotones(true);
            valorInicial();
            if (dtgResBov.SelectedRows.Count > 0)
            {
                int FilaIndice;
                FilaIndice = dtgResBov.SelectedCells[1].RowIndex;
                asignarDatos(FilaIndice);
            }
        }
        private void rbtIndeterminado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtIndeterminado.Checked)
            {
                dtpFecFin.Enabled = false;
                dtpFecFin.Visible = false;
                dtpFecFin.Value = dtpFechaInicio.Value;
                lblfecfin.Visible = false;
            }
        }

        private void rbtDeterminado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtDeterminado.Checked)
            {
                if (nOpcion == 2)
                {
                    dtpFecFin.Enabled = true;
                }
                else
                {
                    if (nOpcion == 1)
                    {
                        dtpFecFin.Enabled = true;
                    }
                    else
                    {
                        dtpFecFin.Enabled = false;
                    }
                }


                dtpFecFin.Visible = true;
                lblfecfin.Visible = true;
            }
        }

        private void dtgResBov_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int Fila = e.RowIndex;
            asignarDatos(Fila);
        }

        private void dtgResBov_RowErrorTextChanged(object sender, DataGridViewRowEventArgs e)
        {

        }
        #endregion
        #region metodos
        private void ListarColAgencia(int idAge)
        {
            clsCNControlOpe LisColAge = new clsCNControlOpe();
            tbColAge = LisColAge.ListarColPorAgencias(idAge);

            this.cboColaborador.DataSource = tbColAge;
            this.cboColaborador.ValueMember = tbColAge.Columns["idUsuario"].ToString();
            this.cboColaborador.DisplayMember = tbColAge.Columns["cNombre"].ToString();

            valorInicial();
            this.dtgResBov.DataSource = null;
            tbResBovAge = cnResBovAge.ListarResBovAge(idAge, clsVarGlobal.dFecSystem);
            dtgResBov.DataSource = tbResBovAge;

            cboColaborador.Enabled = false;
            cboTipResponsableCaja1.Enabled = false;
            chclVigente.Enabled = false;
            dtpFechaInicio.Enabled = false;
            dtpFecFin.Enabled = false;
            grbTiempo.Enabled = false;
            ActivarBotones(true);
            FormatoGridCli();
        }
        private void ActivarBotones(bool lActiva)
        {
            this.btnEditar.Enabled = lActiva;
            this.btnCancelar.Enabled = !lActiva;
            this.btnGrabar.Enabled = !lActiva;
            this.btnNuevo1.Enabled = lActiva;
        }
        private void FormatoGridCli()
        {
            this.dtgResBov.Columns["idTipResCaj"].Visible = false;
            this.dtgResBov.Columns["dfecInicio"].Visible = false;
            this.dtgResBov.Columns["lIndeterninado"].Visible = false;
            this.dtgResBov.Columns["dfecFinal"].Visible = false;
            this.dtgResBov.Columns["idResBoveda"].Visible = false;
            this.dtgResBov.Columns["idUsuario"].Width = 50;
            this.dtgResBov.Columns["idUsuario"].HeaderText = "Id";
            this.dtgResBov.Columns["cNombre"].Width = 190;
            this.dtgResBov.Columns["cNombre"].HeaderText = "Nombre";
            this.dtgResBov.Columns["cCargo"].Width = 150;
            this.dtgResBov.Columns["cCargo"].HeaderText = "Cargo";
            this.dtgResBov.Columns["cTipoResponsable"].Width = 120;
            this.dtgResBov.Columns["cTipoResponsable"].HeaderText = "Tipo responsable";
            this.dtgResBov.Columns["cEstado"].HeaderText = "Estado";
        }
        private void valorInicial()
        {
            dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
            cboTipResponsableCaja1.SelectedIndex = -1;
            cboColaborador.SelectedIndex = -1;
            txtCargo.Clear();
            chclVigente.Checked = false;
            rbtDeterminado.Checked = false;
            rbtIndeterminado.Checked = false;
        }
        private bool lExisteResponsable()
        {
            bool lValor = false;
            foreach (DataRow rows in tbResBovAge.Rows)
            {
                int idTipoResCaja = Convert.ToInt32(cboTipResponsableCaja1.SelectedValue);
                if (Convert.ToInt32(rows["idTipResCaj"].ToString()) == idTipoResCaja && idTipoResCaja != 1)
                {
                    MessageBox.Show("Ya existe el " + rows["cTipoResponsable"].ToString() + " para la agencia.", "Mantenimiento de Responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lValor = true;
                    this.dtgResBov.DataSource = null;
                    tbResBovAge = cnResBovAge.ListarResBovAge(Convert.ToInt32(this.cboAgencias.SelectedValue.ToString()), clsVarGlobal.dFecSystem);
                    dtgResBov.DataSource = tbResBovAge;
                    FormatoGridCli();
                    cancelar();
                    break;
                }
                //                if(Convert.ToInt32(rows["idUsuario"])==Convert.ToInt32(cboColaborador.SelectedValue) &&
                //Convert.ToInt32(rows["idTipResCaj"])>1 && Convert.ToInt32(cboTipResponsableCaja1.SelectedValue)==1)
                //                {
                //                    MessageBox.Show("El responsable de caja pulmón y/o  bóveda no puede ser responsable de ventanilla", "Mantenimiento de Responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //                    lValor = true;
                //                    break;
                //                }
                //                if (Convert.ToInt32(rows["idUsuario"]) == Convert.ToInt32(cboColaborador.SelectedValue) &&
                //Convert.ToInt32(rows["idTipResCaj"]) == 1  && Convert.ToInt32(cboTipResponsableCaja1.SelectedValue) == 2)
                //                {
                //                    MessageBox.Show("El responsable de caja pulmón y/o  bóveda no puede ser responsable de ventanilla", "Mantenimiento de Responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //                    lValor = true;
                //                    break;
                //                }
                //                if (Convert.ToInt32(rows["idUsuario"]) == Convert.ToInt32(cboColaborador.SelectedValue) &&
                //Convert.ToInt32(rows["idTipResCaj"]) == 1 && Convert.ToInt32(cboTipResponsableCaja1.SelectedValue) == 3)
                //                {
                //                    MessageBox.Show("El responsable de caja pulmón y/o  bóveda no puede ser responsable de ventanilla", "Mantenimiento de Responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //                    lValor = true;
                //                    break;
                //                }
                if (Convert.ToInt32(rows["idUsuario"]) == Convert.ToInt32(cboColaborador.SelectedValue) &&
Convert.ToInt32(rows["idTipResCaj"]) == Convert.ToInt32(cboTipResponsableCaja1.SelectedValue))
                {
                    MessageBox.Show("El responsable ya está registrado como " + cboTipResponsableCaja1.Text, "Mantenimiento de Responsables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lValor = true;
                    this.dtgResBov.DataSource = null;
                    tbResBovAge = cnResBovAge.ListarResBovAge(Convert.ToInt32(this.cboAgencias.SelectedValue.ToString()), clsVarGlobal.dFecSystem);
                    dtgResBov.DataSource = tbResBovAge;
                    FormatoGridCli();
                    cancelar();
                    break;
                }

            }
            return lValor;
        }
        private void asignarDatos(int iFila)
        {
            pidResBoveda = Convert.ToInt32(tbResBovAge.Rows[iFila]["idResBoveda"].ToString());
            cboColaborador.SelectedValue = Convert.ToInt32(tbResBovAge.Rows[iFila]["idUsuario"].ToString());
            cboTipResponsableCaja1.SelectedValue = Convert.ToInt32(tbResBovAge.Rows[iFila]["idTipResCaj"].ToString());
            dtpFechaInicio.Value = Convert.ToDateTime(tbResBovAge.Rows[iFila]["dfecInicio"].ToString());

            bool ltiempo = Convert.ToBoolean(tbResBovAge.Rows[iFila]["lIndeterninado"].ToString());
            if (ltiempo)
            {
                rbtIndeterminado.Checked = true;
            }
            else
            {
                rbtDeterminado.Checked = true;
                dtpFecFin.Value = Convert.ToDateTime(tbResBovAge.Rows[iFila]["dfecFinal"].ToString());
            }
        }
        #endregion
    }
}

