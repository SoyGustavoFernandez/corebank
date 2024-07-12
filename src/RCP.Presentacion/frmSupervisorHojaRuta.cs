using EntityLayer;
using GEN.ControlesBase;
using RCP.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCP.Presentacion
{
    public partial class frmSupervisorHojaRuta : frmBase
    {
        clsCNHojaRuta cnHojaRuta = new clsCNHojaRuta();
        DataTable dtHojaRuta = new DataTable();
        DataTable dtGestiones = new DataTable();
        int idHojaRuta = 0;
        int idFilaSeleccionado = 0;

        public frmSupervisorHojaRuta()
        {
            InitializeComponent();
        }

        private void cboUsuRecuperadores1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUsuRecuperadores1.SelectedIndex >= 0)
            {
                dtHojaRuta = cnHojaRuta.obtenerPrimeraHojaRutaPendiente(Convert.ToInt32(cboUsuRecuperadores1.SelectedValue));
                if (dtHojaRuta.Rows.Count > 0)
                {
                    idHojaRuta = Convert.ToInt32(dtHojaRuta.Rows[0]["idHojaRuta"]);
                    dtpFechaInicio.Value = dtHojaRuta.Rows[0]["dFechaInicio"];
                    dtpFechaFin.Value = dtHojaRuta.Rows[0]["dFechaFin"];
                    txtEstadoHojaRuta.Text = dtHojaRuta.Rows[0]["cEstadoHojaRuta"].ToString();
                    txtKilometrajeInicio.Text = dtHojaRuta.Rows[0]["nTacometroInicio"].ToString();
                    txtKilometrajeFin.Text = dtHojaRuta.Rows[0]["nTacometroFin"].ToString();
                    txtPendientes.Text = dtHojaRuta.Rows[0]["nPendientes"].ToString();
                    dtGestiones = cnHojaRuta.obtenerCreditosHojaRuta(idHojaRuta);
                    txtTotalCreditos.Text = dtGestiones.Rows.Count.ToString();                    
                    dtgGestiones.DataSource = dtGestiones;
                    formatoGridGestiones();
                    btnMapa1.Enabled = true;
                }
                else
                {
                    limpiarControles();
                    btnMapa1.Enabled = false;
                    MessageBox.Show("El usuario no tiene hoja de rutas pendientes o en ejecución", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void frmSupervisorHojaRuta_Load(object sender, EventArgs e)
        {
            cboUsuRecuperadores1.cargarUsuarioSupervisados(clsVarGlobal.User.idUsuario);
            cboUsuRecuperadores1.SelectedIndex = -1;
            btnMapa1.Enabled = false;
        }

        private void formatoGridGestiones()
        {
            foreach (DataGridViewColumn columna in dtgGestiones.Columns)
            {
                //columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                columna.Visible = false;
            }
            dtgGestiones.Columns["lFinGestion"].ValueType = typeof(CheckBox);

            dtgGestiones.Columns["idCuenta"].Visible = true;
            dtgGestiones.Columns["cTipoIntervencion"].Visible = true;
            dtgGestiones.Columns["cNombre"].Visible = true;
            dtgGestiones.Columns["cTipoDir"].Visible = true;
            dtgGestiones.Columns["cUbigeo"].Visible = true;
            dtgGestiones.Columns["nAtraso"].Visible = true;
            dtgGestiones.Columns["lFinGestion"].Visible = true;

            dtgGestiones.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgGestiones.Columns["cTipoIntervencion"].HeaderText = "Tipo Inter.";
            dtgGestiones.Columns["cNombre"].HeaderText = "Nombre";
            dtgGestiones.Columns["cTipoDir"].HeaderText = "Tipo Dirección";
            dtgGestiones.Columns["cUbigeo"].HeaderText = "Ubigeo";
            dtgGestiones.Columns["nAtraso"].HeaderText = "Atraso";
            dtgGestiones.Columns["lFinGestion"].HeaderText = "Finalizado";


            dtgGestiones.Columns["idCuenta"].Width = 65;
            dtgGestiones.Columns["cTipoIntervencion"].Width = 100;
            dtgGestiones.Columns["cNombre"].Width = 120;
            dtgGestiones.Columns["cTipoDir"].Width = 100;
            dtgGestiones.Columns["cUbigeo"].Width = 120;
            dtgGestiones.Columns["nAtraso"].Width = 50;
            dtgGestiones.Columns["lFinGestion"].Width = 50;

            dtgGestiones.Columns["lFinGestion"].DisplayIndex = 0;
            dtgGestiones.Columns["idCuenta"].DisplayIndex = 1;
            dtgGestiones.Columns["nAtraso"].DisplayIndex = 2;
            dtgGestiones.Columns["cTipoIntervencion"].DisplayIndex = 3;
            dtgGestiones.Columns["cNombre"].DisplayIndex = 4;
            dtgGestiones.Columns["cTipoDir"].DisplayIndex = 5;
            dtgGestiones.Columns["cUbigeo"].DisplayIndex = 6;            

            
        }
        
        public void limpiarControles() 
        {
            idHojaRuta = 0;
            dtpFechaInicio.Value = clsVarGlobal.dFecSystem;
            dtpFechaFin.Value = clsVarGlobal.dFecSystem;
            txtTotalCreditos.Text = "";
            txtPendientes.Text = "";
            txtEstadoHojaRuta.Text = "";
            txtKilometrajeInicio.Text = "";
            txtKilometrajeFin.Text = "";            
            dtgGestiones.DataSource = null; 
            txtCodigoCliente.Text = "";
            txtNombreCliente.Text = "";
            txtDiasAtraso.Text = "";
            txtSaldoCapital.Text = "";
            txtMoneda.Text = "";
            txtIntervencion.Text = "";
            txtUbigeo.Text = "";
            txtTipoDireccion.Text = "";
            chbDirPrincipal.Checked = false;
            txtDireccion.Text = "";
            txtCuenta.Text = "";
            txtTotalPagar.Text = "";
            lblObservacion.Text = "";
            txtAccion.Text = "";
            txtNotificacion.Text = "";
            cboTipoCliente1.SelectedIndex = -1;
            cboMotivoMora1.SelectedIndex = -1;
            cboTipoResultado1.SelectedIndex = -1;
            chbRecuperable.Checked = false;
            txtObservacion.Text = "";
            txtObservacionPromesa.Text = "";
            txtObservacionVisita.Text = "";
            txtMontoPromesa.Text = "";
            txtFechaPromesa.Text = "";
            txtFechaVisita.Text = "";
        }

        private void dtgGestiones_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idFilaSeleccionado = e.RowIndex;
                txtCodigoCliente.Text = dtgGestiones.CurrentRow.Cells["idCli"].Value.ToString();
                txtNombreCliente.Text = dtgGestiones.CurrentRow.Cells["cNombre"].Value.ToString();
                txtDiasAtraso.Text = dtgGestiones.CurrentRow.Cells["nAtraso"].Value.ToString();
                txtSaldoCapital.Text = dtgGestiones.CurrentRow.Cells["nSaldoCapital"].Value.ToString();
                txtMoneda.Text = dtgGestiones.CurrentRow.Cells["cSimbolo"].Value.ToString();
                txtIntervencion.Text = dtgGestiones.CurrentRow.Cells["cTipoIntervencion"].Value.ToString();
                txtUbigeo.Text = dtgGestiones.CurrentRow.Cells["cUbigeo"].Value.ToString();
                txtTipoDireccion.Text = dtgGestiones.CurrentRow.Cells["cTipoDir"].Value.ToString();
                chbDirPrincipal.Checked = (bool)dtgGestiones.CurrentRow.Cells["lDirPrincipal"].Value;
                txtDireccion.Text = dtgGestiones.CurrentRow.Cells["cDireccion"].Value.ToString();
                txtCuenta.Text = dtgGestiones.CurrentRow.Cells["idCuenta"].Value.ToString();
                txtTotalPagar.Text = dtgGestiones.CurrentRow.Cells["nTotalPagar"].Value.ToString();
                lblObservacion.Text = dtgGestiones.CurrentRow.Cells["cObservacion"].Value.ToString();
                txtAccion.Text = dtgGestiones.CurrentRow.Cells["cTipoAccion"].Value.ToString();
                txtNotificacion.Text = dtgGestiones.CurrentRow.Cells["cTipoNotificacion"].Value.ToString();
                chbEntregoNotificacion.Checked = (bool)dtgGestiones.CurrentRow.Cells["lEntregoNotificacion"].Value;
                chcDomVerificado.Checked = (bool)dtgGestiones.CurrentRow.Cells["lDomVerificado"].Value;                      
          
                if (Convert.ToInt32(dtgGestiones.CurrentRow.Cells["idResultado"].Value.ToString()) == 0)
                {
                    cboTipoCliente1.SelectedIndex = -1;
                    cboMotivoMora1.SelectedIndex = -1;
                    cboTipoResultado1.SelectedIndex = -1;
                    chbRecuperable.Checked = false;
                    txtObservacion.Text = "";
                    txtObservacionPromesa.Text = "";
                    txtObservacionVisita.Text = "";
                    txtMontoPromesa.Text = "0.00";
                    txtFechaPromesa.Text = "";
                    txtFechaVisita.Text = "";
                    txtFechaGestion.Text = "";
                    chcDomVerificado.Checked = false;
                }
                else
                {
                    cboTipoCliente1.SelectedValue = dtgGestiones.CurrentRow.Cells["idTipoCliente"].Value;
                    cboMotivoMora1.SelectedValue = dtgGestiones.CurrentRow.Cells["idMotivoMora"].Value;
                    cboTipoResultado1.SelectedValue = dtgGestiones.CurrentRow.Cells["idResultado"].Value;
                    chbRecuperable.Checked = (bool)dtgGestiones.CurrentRow.Cells["lRecuperable"].Value;
                    chcDomVerificado.Checked = Convert.ToBoolean(dtgGestiones.CurrentRow.Cells["lDomVerificado"].Value);
                    txtObservacion.Text = dtgGestiones.CurrentRow.Cells["cObservacionResutaldo"].Value.ToString();
                    txtFechaGestion.Text = dtgGestiones.CurrentRow.Cells["dFechaRegisCliente"].Value.ToString();//((DateTime)dtgGestiones.CurrentRow.Cells["dFechaRegisCliente"].Value).ToString("D", new CultureInfo("es-ES"));
                    if (Convert.ToInt32(dtgGestiones.CurrentRow.Cells["lProximaVisita"].Value) == 1)
                    {
                        chbVolverVisitar.Checked = true;
                        txtFechaVisita.Text = ((DateTime)dtgGestiones.CurrentRow.Cells["dFechaVisita"].Value).ToString("D", new CultureInfo("es-ES"));
                        txtObservacionVisita.Text = dtgGestiones.CurrentRow.Cells["cObservacionVisita"].Value.ToString();                        
                    }
                    else
                    {
                        chbVolverVisitar.Checked = false;
                        txtFechaVisita.Text = "";
                        txtObservacionVisita.Text = "";
                    }
                    if (Convert.ToInt32(dtgGestiones.CurrentRow.Cells["idResultado"].Value.ToString()) == 1)
                    {
                        txtFechaPromesa.Text = ((DateTime)dtgGestiones.CurrentRow.Cells["dFechaPromesa"].Value).ToString("D", new CultureInfo("es-ES"));
                        txtObservacionPromesa.Text = dtgGestiones.CurrentRow.Cells["cObservacionPromesa"].Value.ToString();
                        txtMontoPromesa.Text = dtgGestiones.CurrentRow.Cells["nMontoPromesa"].Value.ToString();
                    }
                    else
                    {
                        txtFechaPromesa.Text = "";
                        txtObservacionPromesa.Text = "";
                        txtMontoPromesa.Text = "";                    
                    }
                }
            }

        }

        private void btnMapa1_Click(object sender, EventArgs e)
        {
            frmMapaHojaRuta frmMapaHojaRuta = new frmMapaHojaRuta();
            frmMapaHojaRuta.idHojaRuta = this.idHojaRuta;
            frmMapaHojaRuta.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmSeleccionarHojaRuta frmSeleccion = new frmSeleccionarHojaRuta(0);
            frmSeleccion.ShowDialog();
            if (frmSeleccion.idHojaRutaSeleccinada > 0)
            {
                dtHojaRuta = cnHojaRuta.obtenerHojaRuta(frmSeleccion.idHojaRutaSeleccinada);
                if (dtHojaRuta.Rows.Count > 0)
                {
                    cboUsuRecuperadores1.SelectedIndexChanged -= cboUsuRecuperadores1_SelectedIndexChanged;

                    cboUsuRecuperadores1.SelectedValue = Convert.ToInt32(dtHojaRuta.Rows[0]["idUsuario"]);

                    cboUsuRecuperadores1.SelectedIndexChanged -= cboUsuRecuperadores1_SelectedIndexChanged;

                    idHojaRuta = Convert.ToInt32(dtHojaRuta.Rows[0]["idHojaRuta"]);
                    dtpFechaInicio.Value = dtHojaRuta.Rows[0]["dFechaInicio"];
                    dtpFechaFin.Value = dtHojaRuta.Rows[0]["dFechaFin"];
                    txtEstadoHojaRuta.Text = dtHojaRuta.Rows[0]["cEstadoHojaRuta"].ToString();
                    txtKilometrajeInicio.Text = dtHojaRuta.Rows[0]["nTacometroInicio"].ToString();
                    txtKilometrajeFin.Text = dtHojaRuta.Rows[0]["nTacometroFin"].ToString();
                    txtPendientes.Text = dtHojaRuta.Rows[0]["nPendientes"].ToString();
                    dtGestiones = cnHojaRuta.obtenerCreditosHojaRuta(idHojaRuta);
                    txtTotalCreditos.Text = dtGestiones.Rows.Count.ToString();
                    dtgGestiones.DataSource = dtGestiones;
                    formatoGridGestiones();
                    btnMapa1.Enabled = true;
                }
                else
                {
                    limpiarControles();
                    btnMapa1.Enabled = false;
                    MessageBox.Show("Hoja de ruta no encontrada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("No se seleccionó una hoja de ruta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
