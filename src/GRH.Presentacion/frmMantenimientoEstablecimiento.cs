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
using CLI.CapaNegocio;
using EntityLayer;

namespace GRH.Presentacion
{
    public partial class frmMantenimientoEstablecimiento : frmBase
    {
        DataTable dtEstablecimiento;
        public string pcTipOpe = "N"; //Puede ser N --> Nuevo, A--> Actualizar
        clsCNMantEstablec MantEstablec = new clsCNMantEstablec();

        public frmMantenimientoEstablecimiento()
        {
            InitializeComponent();
        }

        private void frmMantenimientoEstablecimiento_Load(object sender, EventArgs e)
        {
            this.cboTipoEstablecimiento.CargarDatos();
            this.conUbigeoDir.cargar();

            Limpiar();
            HabilitarControles(false);
            BuscarEstablecimientos();
        }
        private void BuscarEstablecimientos()
        {
            dtEstablecimiento = MantEstablec.ListarEstablecimientos();
            if (dtgEstablecimiento.ColumnCount > 0)
            {               
                dtgEstablecimiento.Columns.Remove("cNombreEstab");
                dtgEstablecimiento.Columns.Remove("idEstablecimiento");              
                dtgEstablecimiento.Columns.Remove("cDireccion");
                dtgEstablecimiento.Columns.Remove("idUbigeo");
                dtgEstablecimiento.Columns.Remove("cRefDirec");
                dtgEstablecimiento.Columns.Remove("cTeleFono");
                dtgEstablecimiento.Columns.Remove("cCodSUNAT");                
                dtgEstablecimiento.Columns.Remove("lCentroRiesgo");
                dtgEstablecimiento.Columns.Remove("lVigente");
                dtgEstablecimiento.Columns.Remove("idTipoEstablec");
                dtgEstablecimiento.Columns.Remove("cTipoEstablec");
                dtgEstablecimiento.Columns.Remove("lAutBiometricaAgencia");
                dtgEstablecimiento.Columns.Remove("lAutBiometricaComite");
                dtgEstablecimiento.Columns.Remove("lVerificacionSMS");
            }
            dtgEstablecimiento.DataSource = dtEstablecimiento.DefaultView;
            
            dtgEstablecimiento.Columns["cNombreEstab"].Width = 60;           
            dtgEstablecimiento.Columns["cNombreEstab"].HeaderText = "Nombre del Establecimiento";
            dtgEstablecimiento.Columns["cNombreEstab"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgEstablecimiento.Columns["idEstablecimiento"].Visible = false;
            dtgEstablecimiento.Columns["cDireccion"].Width = 60;
            dtgEstablecimiento.Columns["cDireccion"].HeaderText = "Dirección";
            dtgEstablecimiento.Columns["cDireccion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgEstablecimiento.Columns["idUbigeo"].Visible = false;
            dtgEstablecimiento.Columns["cRefDirec"].Visible = false;
            dtgEstablecimiento.Columns["cTeleFono"].Visible = false;
            dtgEstablecimiento.Columns["cCodSUNAT"].Visible = false;
            dtgEstablecimiento.Columns["lCentroRiesgo"].Visible = false;
            dtgEstablecimiento.Columns["lVigente"].FillWeight = 25;
            dtgEstablecimiento.Columns["lVigente"].HeaderText = "Vig.";
            dtgEstablecimiento.Columns["lVigente"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgEstablecimiento.Columns["idTipoEstablec"].Visible = false;
            dtgEstablecimiento.Columns["cTipoEstablec"].Visible = false;
            dtgEstablecimiento.Columns["lAutBiometricaAgencia"].HeaderText = "A. Biom.";
            dtgEstablecimiento.Columns["lAutBiometricaAgencia"].Visible = true;
            dtgEstablecimiento.Columns["lAutBiometricaComite"].HeaderText = "A. Bio. Comite";
            dtgEstablecimiento.Columns["lAutBiometricaComite"].Visible = true;
            dtgEstablecimiento.Columns["lVerificacionSMS"].HeaderText = "Ver. SMS";
            dtgEstablecimiento.Columns["lVerificacionSMS"].Visible = true;

            if (dtgEstablecimiento.Rows.Count == 0) {
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;            
            }
        }
        private void Limpiar()
        {
            this.txtNomEstablecimiento.Clear();
            this.txtDireccion.Clear();
            this.txtReferencia.Clear();
            this.cboTipoEstablecimiento.SelectedValue = -1;
            this.conUbigeoDir.cboPais.SelectedValue = -1;
            this.conUbigeoDir.cboDepartamento.SelectedValue = -1;
            this.conUbigeoDir.cboProvincia.SelectedValue = -1;
            this.conUbigeoDir.cboDistrito.SelectedValue = -1;
            this.txtTelefono.Clear();
            this.txtCodSUNAT.Clear();
            this.CBCentroRiesgo.Checked = false;
            this.CBVigente.Checked = false;
            this.chcAutBio.Checked = false;
            this.chcAutBioComite.Checked = false;
            this.chcVerificacionSMS.Checked = false;
        }
        private void HabilitarControles(Boolean Val)
        {
            this.txtNomEstablecimiento.Enabled = Val;
            this.txtDireccion.Enabled = Val;
            this.txtReferencia.Enabled = Val;
            this.cboTipoEstablecimiento.Enabled = Val;
            this.conUbigeoDir.cboPais.Enabled = Val;
            this.conUbigeoDir.cboDepartamento.Enabled = Val;
            this.conUbigeoDir.cboProvincia.Enabled = Val;
            this.conUbigeoDir.cboDistrito.Enabled = Val;
            this.txtTelefono.Enabled = Val;
            this.txtCodSUNAT.Enabled = Val;
            this.CBCentroRiesgo.Enabled = Val;
            this.CBVigente.Enabled = Val;
            this.chcAutBio.Enabled = Val;
            this.chcAutBioComite.Enabled = Val;
            this.chcVerificacionSMS.Enabled = Val;
        }
        private string ValidarDatos()
        {
            if (txtNomEstablecimiento.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre del Establecimiento", "Mantenimiento de Establecimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNomEstablecimiento.Focus();
                return "ERROR";
            }
            if (txtDireccion.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la dirección del Establecimiento", "Mantenimiento de Establecimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDireccion.Focus();
                return "ERROR";
            }

            if(cboTipoEstablecimiento.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de Establecimiento", "Mantenimiento de Establecimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoEstablecimiento.Focus();
                return "ERROR";
            }

            if (txtReferencia.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la referencia de la Dirección", "Mantenimiento de Establecimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtReferencia.Focus();
                return "ERROR";
            }
            if (conUbigeoDir.cboDistrito.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Distrito donde se ubica el Establecimiento", "Mantenimiento de Establecimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNomEstablecimiento.Focus();
                return "ERROR";
            }
            if (txtTelefono.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el teléfono del Establecimiento", "Mantenimiento de Establecimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTelefono.Focus();
                return "ERROR";
            }
            if (txtCodSUNAT.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Código de SUNAT del Establecimiento", "Mantenimiento de Establecimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodSUNAT.Focus();
                return "ERROR";
            }


            if (pcTipOpe == "N")
            {
                for (int i = 0; i < dtgEstablecimiento.Rows.Count; i++)
                {
                    if (Convert.ToString(dtgEstablecimiento.Rows[i].Cells["cNombreEstab"].Value) == txtNomEstablecimiento.Text.Trim())
                    {
                        MessageBox.Show("Ya existe un Área con ese nombre. Verifique", "Mantenimiento de Áreas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNomEstablecimiento.Focus();
                        return "ERROR";
                    }
                }
            }

            if (pcTipOpe == "A")
            {
                int filaseleccionada = Convert.ToInt32(this.dtgEstablecimiento.CurrentRow.Index);

                for (int i = 0; i < dtgEstablecimiento.Rows.Count; i++)
                {
                    if (filaseleccionada != i)
                    {
                        if (Convert.ToString(dtgEstablecimiento.Rows[i].Cells["cNombreEstab"].Value) == txtNomEstablecimiento.Text.Trim())
                        {
                            MessageBox.Show("Ya existe un Área con ese nombre. Verifique", "Mantenimiento de Áreas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtNomEstablecimiento.Focus();
                            return "ERROR";
                        }
                    }
                }
            }

            return "OK";
        }
        private void MostrarDatos()
        {
            if (dtgEstablecimiento.SelectedRows.Count > 0)
            {
                int filaseleccionada = Convert.ToInt32(dtgEstablecimiento.SelectedCells[1].RowIndex);

                this.txtNomEstablecimiento.Text = Convert.ToString(this.dtgEstablecimiento.Rows[filaseleccionada].Cells["cNombreEstab"].Value);
                this.txtDireccion.Text = Convert.ToString(this.dtgEstablecimiento.Rows[filaseleccionada].Cells["cDireccion"].Value);
                this.txtReferencia.Text = Convert.ToString(this.dtgEstablecimiento.Rows[filaseleccionada].Cells["cRefDirec"].Value);
                this.txtTelefono.Text = Convert.ToString(this.dtgEstablecimiento.Rows[filaseleccionada].Cells["cTeleFono"].Value);
                this.txtCodSUNAT.Text = Convert.ToString(this.dtgEstablecimiento.Rows[filaseleccionada].Cells["cCodSUNAT"].Value);
                this.CBCentroRiesgo.Checked = Convert.ToBoolean(this.dtgEstablecimiento.Rows[filaseleccionada].Cells["lCentroRiesgo"].Value);
                this.CBVigente.Checked = Convert.ToBoolean(this.dtgEstablecimiento.Rows[filaseleccionada].Cells["lVigente"].Value);
                this.cboTipoEstablecimiento.SelectedValue = Convert.ToInt32(this.dtgEstablecimiento.Rows[filaseleccionada].Cells["idTipoEstablec"].Value);
                this.chcAutBio.Checked = Convert.ToBoolean(this.dtgEstablecimiento.Rows[filaseleccionada].Cells["lAutBiometricaAgencia"].Value);
                this.chcAutBioComite.Checked = Convert.ToBoolean(this.dtgEstablecimiento.Rows[filaseleccionada].Cells["lAutBiometricaComite"].Value);
                this.chcVerificacionSMS.Checked = Convert.ToBoolean(this.dtgEstablecimiento.Rows[filaseleccionada].Cells["lVerificacionSMS"].Value);

                Int32 idUbigeo = Convert.ToInt32(dtgEstablecimiento.Rows[filaseleccionada].Cells["idubigeo"].Value);
                clsCNRetDatosCliente objLista = new clsCNRetDatosCliente();
                DataTable tbDatUbi = objLista.RetUbiCli(idUbigeo);
                conUbigeoDir.cboPais.SelectedValue = Convert.ToInt32(tbDatUbi.Rows[3]["idUbigeo"]);
                conUbigeoDir.cboDepartamento.SelectedValue = Convert.ToInt32(tbDatUbi.Rows[2]["idUbigeo"]);
                conUbigeoDir.cboProvincia.SelectedValue = Convert.ToInt32(tbDatUbi.Rows[1]["idUbigeo"]);
                conUbigeoDir.cboDistrito.SelectedValue = Convert.ToInt32(tbDatUbi.Rows[0]["idUbigeo"]);


                HabilitarControles(false);
                pcTipOpe = "A";
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
            else
            {
                Limpiar();
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = false;
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
            conUbigeoDir.cboPais.SelectedValue = 173;
            txtNomEstablecimiento.Focus();

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
            txtNomEstablecimiento.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos() == "ERROR")
            {
                return;
            }
            string cNomEstablec = txtNomEstablecimiento.Text.Trim();
            string cDireccion = txtDireccion.Text.Trim();
            string cReferencia = txtReferencia.Text.Trim();
            int idUbigeo= Convert.ToInt32(conUbigeoDir.cboDistrito.SelectedValue);
            string cTelefono = txtTelefono.Text.Trim();
            string cCodSUNAT = txtCodSUNAT.Text.Trim();
            int lCenRiesgo = Convert.ToInt32(CBCentroRiesgo.Checked);
            int lVigente = Convert.ToInt32(CBVigente.Checked);
            int idTipoEstablecimiento = Convert.ToInt32(cboTipoEstablecimiento.SelectedValue);
            bool lAutBiometricaAgencia = chcAutBio.Checked;
            bool lAutBiometricaComite = chcAutBioComite.Checked;
            bool lVerificacionSMS = chcVerificacionSMS.Checked;

            if (pcTipOpe == "A")
            {
                int filaseleccionada = Convert.ToInt32(this.dtgEstablecimiento.CurrentRow.Index);
                int idEst = Convert.ToInt32(dtgEstablecimiento.Rows[filaseleccionada].Cells["idEstablecimiento"].Value);

                MantEstablec.ActualizarEstablecimiento(idEst, cNomEstablec, cDireccion, idUbigeo, cReferencia, cTelefono, cCodSUNAT, lVigente, lCenRiesgo, idTipoEstablecimiento, lAutBiometricaAgencia, lAutBiometricaComite, lVerificacionSMS);
                MessageBox.Show("Se han actualizado correctamente los Datos ", "Mantenimiento de Áreas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //cargar de nuevo y seleccionar la primera de todos los registros que fueroon modificados
                BuscarEstablecimientos();
                int n = 0;
                foreach (DataGridViewRow fila in dtgEstablecimiento.Rows)
                {
                    n += 1;
                    if (Convert.ToInt32(fila.Cells["idEstablecimiento"].Value) == idEst)
                    {
                        dtgEstablecimiento.CurrentCell = dtgEstablecimiento.Rows[n - 1].Cells[0];
                        MostrarDatos();
                    }
                }
            }

            else if (pcTipOpe == "N")
            {
                int NuevoId = MantEstablec.GuardarEstablecimiento(cNomEstablec, cDireccion, idUbigeo, cReferencia, cTelefono, cCodSUNAT, lVigente, lCenRiesgo, idTipoEstablecimiento, lAutBiometricaAgencia, lAutBiometricaComite, lVerificacionSMS);
                MessageBox.Show("Se han Registrado los Datos Correctamente", "Mantenimiento de Áreas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //cargar de nuevo y seleccionar el registros con la tasa recien añadida

                BuscarEstablecimientos();
                int n = 0;
                foreach (DataGridViewRow fila in dtgEstablecimiento.Rows)
                {
                    n += 1;
                    if (Convert.ToInt32(fila.Cells["idEstablecimiento"].Value) == NuevoId)
                    {
                        dtgEstablecimiento.CurrentCell = dtgEstablecimiento.Rows[n - 1].Cells[0];
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

        private void dtgEstablecimiento_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatos();
        }
    }
} 