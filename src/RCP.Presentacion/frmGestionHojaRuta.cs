using EntityLayer;
using GEN.ControlesBase;
using RCP.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCP.Presentacion
{
    public partial class frmGestionHojaRuta : frmBase
    {
        clsCNHojaRuta cnHojaRuta = new clsCNHojaRuta();
        clsCNDireccionRecupera cnDireccionRecupera = new clsCNDireccionRecupera();
        DataTable dtHojaRuta = new DataTable();
        DataTable dtCreditosHojaRuta = new DataTable();
        int idDetalleHojaRutaSeleccionado = 0;
        bool lPuedeEditar = false;
        int idHojaRuta = 0;
        int idEstadoHojaRuta = 0;
        int idFilaSeleccionado = 0;
        int idCliente = 0;

        public frmGestionHojaRuta()
        {
            InitializeComponent();
        }

        private void frmGestionHojaRuta_Load(object sender, EventArgs e)
        {
            btnFinalizar1.Enabled = false;
            habilitarControles(false);  
            frmSeleccionarHojaRuta frmSeleccionarHojaRuta = new frmSeleccionarHojaRuta(clsVarGlobal.User.idUsuario);
            frmSeleccionarHojaRuta.ShowDialog();
            if (!frmSeleccionarHojaRuta.lAceptar)
            {
                this.Dispose();
            }
            idHojaRuta = frmSeleccionarHojaRuta.idHojaRutaSeleccinada;
            cboTipoCliente1.ListaPorModulo(13);
            dtpFechaPromesa.Value = clsVarGlobal.dFecSystem;
            dtpFechaVisita.Value = clsVarGlobal.dFecSystem;
            dtpFechaVisita.Enabled = false;
            txtObservacionVisita.Enabled = false;
            txtMontoPromesa.Text = "0.00";
            cargarHojaRuta();

            dtpFechaPromesa.MinDate = clsVarGlobal.dFecSystem;
            dtpFechaVisita.MinDate = clsVarGlobal.dFecSystem;
            

        }

        private void cargarHojaRuta()
        {
            dtHojaRuta = cnHojaRuta.obtenerHojaRuta(idHojaRuta);
            if (dtHojaRuta.Rows.Count > 0)
            {
                
                dtpFechaInicio.Value = dtHojaRuta.Rows[0]["dFechaInicio"];
                dtpFechaFin.Value = dtHojaRuta.Rows[0]["dFechaFin"];
                dtpFechaGestion.MinDate = Convert.ToDateTime(dtHojaRuta.Rows[0]["dFechaInicio"]);
                dtpFechaGestion.MaxDate = Convert.ToDateTime(dtHojaRuta.Rows[0]["dFechaFin"]);
                txtKilometrajeInicio.Text = dtHojaRuta.Rows[0]["nTacometroInicio"].ToString();
                txtEstadoHojaRuta.Text = dtHojaRuta.Rows[0]["cEstadoHojaRuta"].ToString();
                idEstadoHojaRuta = Convert.ToInt32(dtHojaRuta.Rows[0]["idEstado"]);
                dtCreditosHojaRuta = cnHojaRuta.obtenerCreditosHojaRuta(idHojaRuta);
                dtgHojaRuta.DataSource = dtCreditosHojaRuta;
                txtTotalCreditos.Text = dtCreditosHojaRuta.Rows.Count + " Crédito(s)";
                if (idEstadoHojaRuta == 3)
                {
                    grbGestion.Enabled = false;
                    btnAgregar2.Enabled = false;
                    btnFinalizar1.Enabled = false;
                    btnNuevoTelefono.Enabled = false;
                    btnDirRecupera.Enabled = false;
                }
                else if(verificarFinalizacion())
                {
                    btnFinalizar1.Enabled = true;
                }
            }                        
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (lPuedeEditar)
            {
                habilitarControles(true);
                chbNotificacionEntregada.Enabled = !(txtNotificacion.Text.Equals(" - "));
                cboTipoResultado1.Focus();
            }
            else
            {
                MessageBox.Show("Usted no puede editar una gestión registrada", "Gestión de Hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool verificarFinalizacion()
        {
            foreach (DataRow row in dtCreditosHojaRuta.Rows)
            {
                if (Convert.ToInt32(row["idResultado"]) == 0)
                    return false;
            }
            return true;
        }

        public void habilitarControles(bool habilitar)
        {
            btnGrabar1.Enabled = habilitar;
            btnAgregar2.Enabled = !habilitar;
            dtgHojaRuta.Enabled = !habilitar;
            btnEditar1.Enabled = !habilitar;
            btnCancelar1.Enabled = habilitar;
            grbResultado.Enabled = habilitar;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            habilitarControles(false);
            cboTipoCliente1.SelectedIndex = -1;
            cboMotivoMora1.SelectedIndex = -1;
            cboTipoResultado1.SelectedIndex = -1;
            chbRecuperable.Checked = false;
            txtObservacion.Text = "";
            txtMontoPromesa.Text = "0.00";
            dtpFechaPromesa.Value = clsVarGlobal.dFecSystem;            
        }
             
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                DataTable dtResultado = cnHojaRuta.registrarGestionHojaRuta(idDetalleHojaRutaSeleccionado, Convert.ToInt32(cboTipoResultado1.SelectedValue), Convert.ToInt32(cboMotivoMora1.SelectedValue), 
                                                                        Convert.ToInt32(cboTipoCliente1.SelectedValue), chbRecuperable.Checked, txtObservacion.Text, (DateTime)dtpFechaPromesa.Value, 
                                                                        Convert.ToDecimal(txtMontoPromesa.Text), txtObservacionPromesa.Text, chbVolverVisitar.Checked, (DateTime)dtpFechaVisita.Value, 
                                                                        txtObservacionVisita.Text, Convert.ToDateTime(dtpFechaGestion.Value), chcDomVerificado.Checked, chbNotificacionEntregada.Checked);
                if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                {
                    MessageBox.Show("Gestión registrada correctamente", "Gestión Hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                    cargarHojaRuta();
                    dtgHojaRuta.Focus();
                    dtgHojaRuta.Rows[idFilaSeleccionado].Selected = true;                    
                    habilitarControles(false);
                }
                else
                {
                    MessageBox.Show("Error al registrar Gestión: " + dtResultado.Rows[0][1], "Gestión Hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool validar()
        {
            if (cboTipoResultado1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar resultado", "Validar Registro de gestión de hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoResultado1.Focus();
                return false;
            }
            if (cboMotivoMora1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar la razón de mora", "Validar Registro de gestión de hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMotivoMora1.Focus();
                return false;
            }
            if (cboTipoCliente1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar tipo de cliente", "Validar Registro de gestión de hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoCliente1.Focus();
                return false;
            }            
            if (txtObservacion.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe ingresar observación de gestión", "Validar Registro de gestión de hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtObservacion.Focus();
                return false;
            }
            if (grbPromesa.Enabled)
            {
                if ((DateTime)dtpFechaPromesa.Value < clsVarGlobal.dFecSystem) 
                {
                    MessageBox.Show("La fecha de la promesa de pago no puede ser menor a la fecha del sistema", "Validar Registro de gestión de hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpFechaPromesa.Focus();
                    return false;
                }
                if (txtMontoPromesa.Text.Trim().Length <= 0)
                {
                    MessageBox.Show("Debe ingresar monto de la promesa de pago", "Validar Registro de gestión de hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtObservacion.Focus();
                    return false;
                }
                if (Convert.ToDecimal(txtMontoPromesa.Text) <= 0.00M )
                {
                    MessageBox.Show("El monto de la promesa debe ser mayor a 0.00", "Validar Registro de gestión de hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMontoPromesa.Focus();
                    return false;
                }
                if (Convert.ToDecimal(txtMontoPromesa.Text) > Convert.ToDecimal(txtTotalPagar.Text))
                {
                    MessageBox.Show("El monto a pagar no puede ser mayor al total a pagar", "Validar Registro de gestión de hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMontoPromesa.Focus();
                    return false;
                }
            }
            if (chbVolverVisitar.Checked)
            {
                if ((DateTime)dtpFechaVisita.Value < clsVarGlobal.dFecSystem)
                {
                    MessageBox.Show("La fecha de la proxima visita no puede ser menor a la fecha del sistema", "Validar Registro de gestión de hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpFechaVisita.Focus();
                    return false;
                }
            }
            
            return true;
        }

        private void btnAgregar2_Click(object sender, EventArgs e)
        {
            frmAgregarCreditoHojaRuta frmAgregarCreditoHojaRuta = new frmAgregarCreditoHojaRuta();
            frmAgregarCreditoHojaRuta.dtHojaRuta = dtCreditosHojaRuta.Copy();
            frmAgregarCreditoHojaRuta.ShowDialog();
            if (frmAgregarCreditoHojaRuta.lAceptar)
            {
                DataTable dtResultado = cnHojaRuta.agregarCreditoHojaRuta(idHojaRuta, frmAgregarCreditoHojaRuta.idCuentaSeleccionada, frmAgregarCreditoHojaRuta.idIntervCreSelecionado, frmAgregarCreditoHojaRuta.idDireccionSeleccionada, frmAgregarCreditoHojaRuta.idAccionSeleccionada, frmAgregarCreditoHojaRuta.idNotificacionSeleccionada, clsVarGlobal.dFecSystem, frmAgregarCreditoHojaRuta.lDireccionRecupera);
                if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                {
                    MessageBox.Show("Se agregó el crédito con código: " + frmAgregarCreditoHojaRuta.idCuentaSeleccionada + "", "Gestión hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarHojaRuta();
                }
                else
                {
                    MessageBox.Show("Error al agregar crédito en hoja de ruta: " + dtResultado.Rows[0][1], "Gestión hoja de ruta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtgHojaRuta_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idFilaSeleccionado = e.RowIndex;
                idDetalleHojaRutaSeleccionado = Convert.ToInt32(dtgHojaRuta.CurrentRow.Cells["idDetalleHojaRuta"].Value);
                idCliente = Convert.ToInt32(dtgHojaRuta.CurrentRow.Cells["idCli"].Value);
                txtCodigoCliente.Text = dtgHojaRuta.CurrentRow.Cells["idCli"].Value.ToString();
                txtNombreCliente.Text = dtgHojaRuta.CurrentRow.Cells["cNombre"].Value.ToString();
                txtDiasAtraso.Text = dtgHojaRuta.CurrentRow.Cells["nAtraso"].Value.ToString();
                txtSaldoCapital.Text = dtgHojaRuta.CurrentRow.Cells["nSaldoCapital"].Value.ToString();
                txtMoneda.Text = dtgHojaRuta.CurrentRow.Cells["cSimbolo"].Value.ToString();
                txtIntervencion.Text = dtgHojaRuta.CurrentRow.Cells["cTipoIntervencion"].Value.ToString();
                txtUbigeo.Text = dtgHojaRuta.CurrentRow.Cells["cUbigeo"].Value.ToString();
                txtTipoDireccion.Text = dtgHojaRuta.CurrentRow.Cells["cTipoDir"].Value.ToString();
                chbDirPrincipal.Checked = (bool)dtgHojaRuta.CurrentRow.Cells["lDirPrincipal"].Value;
                txtDireccion.Text = dtgHojaRuta.CurrentRow.Cells["cDireccion"].Value.ToString();
                txtCuenta.Text = dtgHojaRuta.CurrentRow.Cells["idCuenta"].Value.ToString();
                txtTotalPagar.Text = dtgHojaRuta.CurrentRow.Cells["nTotalPagar"].Value.ToString();
                lblObservacion.Text = dtgHojaRuta.CurrentRow.Cells["cObservacion"].Value.ToString();
                txtAccion.Text = dtgHojaRuta.CurrentRow.Cells["cTipoAccion"].Value.ToString();
                txtNotificacion.Text = dtgHojaRuta.CurrentRow.Cells["cTipoNotificacion"].Value.ToString();
                chbNotificacionEntregada.Checked = (bool)dtgHojaRuta.CurrentRow.Cells["lEntregoNotificacion"].Value;
                chcDomVerificado.Checked = (bool)dtgHojaRuta.CurrentRow.Cells["lDomVerificado"].Value;                      
          
                DataTable dtDirecciones = cnDireccionRecupera.ListarDireccionClienteCompleto(idCliente);
                dtgDirecciones.DataSource = dtDirecciones;
                formatearGrillDirecciones();

                if (Convert.ToInt32(dtgHojaRuta.CurrentRow.Cells["idResultado"].Value.ToString()) == 0)
                {
                    cboTipoCliente1.SelectedIndex = -1;
                    cboMotivoMora1.SelectedIndex = -1;
                    cboTipoResultado1.SelectedIndex = -1;
                    chbRecuperable.Checked = false;
                    txtObservacion.Text = "";
                    txtObservacionPromesa.Text = "";
                    txtObservacionVisita.Text = "";
                    txtMontoPromesa.Text = "0.00";
                    lPuedeEditar = true;
                    dtpFechaPromesa.Value = clsVarGlobal.dFecSystem;
                    dtpFechaVisita.Value = clsVarGlobal.dFecSystem;
                    dtpFechaGestion.Value = dtpFechaGestion.MinDate;
                    chcDomVerificado.Checked = false;
                }
                else
                {
                    cboTipoCliente1.SelectedValue = dtgHojaRuta.CurrentRow.Cells["idTipoCliente"].Value;
                    cboMotivoMora1.SelectedValue = dtgHojaRuta.CurrentRow.Cells["idMotivoMora"].Value;
                    cboTipoResultado1.SelectedValue = dtgHojaRuta.CurrentRow.Cells["idResultado"].Value;
                    chbRecuperable.Checked = (bool)dtgHojaRuta.CurrentRow.Cells["lRecuperable"].Value;
                    chcDomVerificado.Checked = Convert.ToBoolean(dtgHojaRuta.CurrentRow.Cells["lDomVerificado"].Value);
                    txtObservacion.Text = dtgHojaRuta.CurrentRow.Cells["cObservacionResutaldo"].Value.ToString();
                    dtpFechaGestion.Value = Convert.ToDateTime(dtgHojaRuta.CurrentRow.Cells["dFechaRegisCliente"].Value);
                    if (Convert.ToInt32(dtgHojaRuta.CurrentRow.Cells["lProximaVisita"].Value) == 1)
                    {
                        chbVolverVisitar.Checked = true;
                        dtpFechaVisita.Value = (DateTime)dtgHojaRuta.CurrentRow.Cells["dFechaVisita"].Value;
                        txtObservacionVisita.Text = dtgHojaRuta.CurrentRow.Cells["cObservacionVisita"].Value.ToString();
                    }
                    else
                    {
                        chbVolverVisitar.Checked = false;
                        dtpFechaVisita.Value = clsVarGlobal.dFecSystem;
                        txtObservacionVisita.Text = "";
                    }
                    if (Convert.ToInt32(dtgHojaRuta.CurrentRow.Cells["idResultado"].Value.ToString()) == 1)
                    {
                        dtpFechaPromesa.Value = (DateTime)dtgHojaRuta.CurrentRow.Cells["dFechaPromesa"].Value;
                        txtObservacionPromesa.Text = dtgHojaRuta.CurrentRow.Cells["cObservacionPromesa"].Value.ToString();
                        txtMontoPromesa.Text = dtgHojaRuta.CurrentRow.Cells["nMontoPromesa"].Value.ToString();
                    }
                    else
                    {
                        dtpFechaPromesa.Value = clsVarGlobal.dFecSystem;
                        txtObservacionPromesa.Text = "";
                        txtMontoPromesa.Text = "";
                    }
                    lPuedeEditar = false;
                }
            }
        }

        private void formatearGrillDirecciones()
        {
            foreach (DataGridViewColumn columna in dtgDirecciones.Columns)
            {
                columna.Visible = false;
            }

            dtgDirecciones.Columns["cFuente"].Visible = true;
            dtgDirecciones.Columns["dFechaReg"].Visible = true;
            dtgDirecciones.Columns["cUbigeo"].Visible = true;
            dtgDirecciones.Columns["cDirecion"].Visible = true;

            dtgDirecciones.Columns["cFuente"].HeaderText = "";
            dtgDirecciones.Columns["dFechaReg"].HeaderText = "Fecha de Reg.";
            dtgDirecciones.Columns["cUbigeo"].HeaderText = "Ubigeo";
            dtgDirecciones.Columns["cDirecion"].HeaderText = "Dirección";

            dtgDirecciones.Columns["cFuente"].Width = 100;
            dtgDirecciones.Columns["dFechaReg"].Width = 100;
            dtgDirecciones.Columns["cUbigeo"].Width = 200;
            dtgDirecciones.Columns["cDirecion"].Width = 200;
        }

        private void cboTipoResultado1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoResultado1.SelectedIndex >= 0 && Convert.ToInt32(cboTipoResultado1.SelectedValue) == 1)
            {
                grbPromesa.Enabled = true;
                chbVolverVisitar.Enabled = false;
                chbVolverVisitar.Checked = false;
                txtObservacionVisita.Text = "";
                txtObservacionVisita.Enabled = false;
                dtpFechaVisita.Enabled = false;
            }
            else
            {
                grbPromesa.Enabled = false;
                chbVolverVisitar.Enabled = true;
                chbVolverVisitar.Checked = false;
                txtObservacionPromesa.Text = "";
                txtMontoPromesa.Text = "0.00";
                dtpFechaPromesa.Value = clsVarGlobal.dFecSystem;
            }
        }

        private void chbVolverVisitar_CheckedChanged(object sender, EventArgs e)
        {
            if (chbVolverVisitar.Checked)
            {
                dtpFechaVisita.Enabled = true;
                txtObservacionVisita.Enabled = true;
            }
            else
            {
                dtpFechaVisita.Enabled = false;
                txtObservacionVisita.Enabled = false;
                txtObservacionVisita.Text = "";
                dtpFechaVisita.Value = clsVarGlobal.dFecSystem;
            }
        }

        private void btnFinalizar1_Click(object sender, EventArgs e)
        {
            frmFinalizarRegResultadosHojaRuta frmFinalizarRegResultadosHojaRuta = new frmFinalizarRegResultadosHojaRuta();
            frmFinalizarRegResultadosHojaRuta.idHojaRuta = idHojaRuta;
            frmFinalizarRegResultadosHojaRuta.nKilometroInicial = Convert.ToDecimal(txtKilometrajeInicio.Text);
            frmFinalizarRegResultadosHojaRuta.ShowDialog();
            if (frmFinalizarRegResultadosHojaRuta.lFinalizado)
            {
                cargarHojaRuta();
            }
        }

        private void btnDirRecupera_Click(object sender, EventArgs e)
        {
            frmDireccionRecupera frmdireccion = new frmDireccionRecupera(idCliente);
            frmdireccion.ShowDialog();

            DataTable dtDirecciones = cnDireccionRecupera.ListarDireccionClienteCompleto(idCliente);
            dtgDirecciones.DataSource = dtDirecciones;
            formatearGrillDirecciones();
        }

        private void dtpFechaPromesa_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaVisita.Value = dtpFechaPromesa.Value;
        }

        private void btnNuevoTelefono_Click(object sender, EventArgs e)
        {
            frmRegistrarTelefonoRecupera frmRegistrarTelefonoRecupera = new frmRegistrarTelefonoRecupera();
            frmRegistrarTelefonoRecupera.idCli = idCliente;
            frmRegistrarTelefonoRecupera.ShowDialog();
        }    

    }
}
