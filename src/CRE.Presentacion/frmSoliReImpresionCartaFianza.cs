 using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmSoliReImpresionCartaFianza : frmBase
    {
        clsCNCartaFianza cnCartaFianza = new clsCNCartaFianza();
        clsCNAprobacion cnAprobacion = new clsCNAprobacion();
        int idSeleccionado = 0;
        DataTable dtCartasFianza;
        public frmSoliReImpresionCartaFianza()
        {
            InitializeComponent();
        }

        private void frmReImpresionCartaFianza_Load(object sender, EventArgs e)
        {
            conBusCli1.ClicBuscar += conBusCli1_ClicBuscar;
            btnSolicitar1.Enabled = false;
            txtMotivo.Enabled = false;
        }
        void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            if(conBusCli1.txtCodCli.ToString()!="")
            {
                cargarDatos();
            }
        }
        private void cargarDatos()
        {
            idSeleccionado = 0;
            dtCartasFianza = cnCartaFianza.obtenerCartaFianzaXCliente(conBusCli1.idCli, -1);
            if (dtCartasFianza.Rows.Count > 0)
            {
                if (dtCartasFianza.Rows.Count > 1)
                {
                    frmSeleccionarCartaFianza frmSeleccionarCartaFianza = new frmSeleccionarCartaFianza(dtCartasFianza);
                    frmSeleccionarCartaFianza.ShowDialog();
                    if (!frmSeleccionarCartaFianza.lAceptar)
                    {
                        limpiar();
                        return;
                    }
                    idSeleccionado = frmSeleccionarCartaFianza.idSeleccionado;
                }
                txtCartaFianza.Text = dtCartasFianza.Rows[0]["codCartaFianza"].ToString();
                cboMoneda1.SelectedValue = dtCartasFianza.Rows[idSeleccionado]["idMoneda"];
                txtMontoAprobado.Text = dtCartasFianza.Rows[idSeleccionado]["nMonto"].ToString();
                txtPlazoAprobado.Text = dtCartasFianza.Rows[idSeleccionado]["nPlazo"].ToString();
                txtFechaInicioAprobado.Text = dtCartasFianza.Rows[idSeleccionado]["dFechaVigencia"].ToString();
                txtTasaAprobada.Text = dtCartasFianza.Rows[idSeleccionado]["nTasaComision"].ToString() + " %";
                btnSolicitar1.Enabled = true;
                txtMotivo.Enabled = true;

                DataTable dtSolicitudesPendientes = cnAprobacion.ObtenerSoliciAprobaPendiente(121, Convert.ToInt32(dtCartasFianza.Rows[idSeleccionado]["idCartaFianza"]));
                if (dtSolicitudesPendientes.Rows.Count > 0)
                {
                    MessageBox.Show("La carta fianza tiene una solicitud pendiente de: " + dtSolicitudesPendientes.Rows[0]["cNombreUsuario"].ToString(), "Re impresión carta fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpiar();
                    txtMotivo.Enabled = false;
                    btnSolicitar1.Enabled = false;

                }
            }
            else
            {
                MessageBox.Show("El cliente no tiene cartas fianzas vigentes.", "Re impresión carta fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiar();
                txtMotivo.Enabled = false;
                btnSolicitar1.Enabled = false;
            }
        }

        private void limpiar()
        {
            txtCartaFianza.Text = "";
            cboMoneda1.SelectedIndex = -1;
            conBusCli1.limpiarControles();
            conBusCli1.txtCodCli.Enabled = true;
            conBusCli1.txtCodCli.Focus();
            txtMontoAprobado.Text               = "";
            txtPlazoAprobado.Text               = "";
            txtFechaInicioAprobado.Text         = "";
            txtTasaAprobada.Text = "";
        }

        private void btnSolicitar1_Click(object sender, EventArgs e)
        {

            if (txtMotivo.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Se debe registrar el movito de la solicitud de reimpresión", "Re impresión carta fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMotivo.Focus();
                return;
            }
            int idTipoOperacion = 121;//reimpresion de carta fianza
            DataTable dtResultado = cnAprobacion.GuardarSolicitudAprobac(clsVarGlobal.nIdAgencia, this.conBusCli1.idCli, idTipoOperacion, 1, Convert.ToInt32(cboMoneda1.SelectedValue), Convert.ToInt32(dtCartasFianza.Rows[idSeleccionado]["idProducto"]), Convert.ToDecimal(txtMontoAprobado.Text), Convert.ToInt32(dtCartasFianza.Rows[idSeleccionado]["idCartaFianza"]), clsVarGlobal.dFecSystem, 11, txtMotivo.Text, 1, clsVarGlobal.dFecSystem, clsVarGlobal.PerfilUsu.idUsuario, 0, clsVarGlobal.User.idEstablecimiento, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));
            if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0][0]) > 0)
            {
                MessageBox.Show("Se realizó la solicitud para la la reimpresión de la carta fianza, Código solicitud: " + dtResultado.Rows[0][0].ToString(), "Re impresión carta fianza", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSolicitar1.Enabled = false;
                txtMotivo.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error al realizar la solicitud de reimpresión de carta fianza: " + dtResultado.Rows[0]["cMensaje"].ToString(), "Re impresión carta fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



    }
}
