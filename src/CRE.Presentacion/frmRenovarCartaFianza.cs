using CRE.CapaNegocio;
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
    public partial class frmRenovarCartaFianza : frmBase
    {
        clsCNCartaFianza cnCartaFianza = new clsCNCartaFianza();
        int idSeleccionado = 0;
        DataTable dtCartasFianza;
        public frmRenovarCartaFianza()
        {
            InitializeComponent();
        }

        private void frmRenovarCartaFianza_Load(object sender, EventArgs e)
        {
            conBusCli1.ClicBuscar += conBusCli1_ClicBuscar;
            limpiarControles();
        }

        void conBusCli1_ClicBuscar(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {
            idSeleccionado = 0;
            dtCartasFianza = cnCartaFianza.obtenerCartaFianzaXCliente(conBusCli1.idCli, 1);
            if (dtCartasFianza.Rows.Count > 0)
            {
                if (dtCartasFianza.Rows.Count > 1)
                {
                    frmSeleccionarCartaFianza frmSeleccionarCartaFianza = new frmSeleccionarCartaFianza(dtCartasFianza);
                    frmSeleccionarCartaFianza.ShowDialog();
                    if (!frmSeleccionarCartaFianza.lAceptar)
                    {
                        limpiarControles();
                        return;
                    }
                    idSeleccionado = frmSeleccionarCartaFianza.idSeleccionado;
                }
                txtCartaFianza.Text = dtCartasFianza.Rows[0]["codCartaFianza"].ToString();                
                cboMoneda1.SelectedValue = dtCartasFianza.Rows[idSeleccionado]["idMoneda"];
                cboMoneda2.SelectedValue = dtCartasFianza.Rows[idSeleccionado]["idMoneda"];
                txtMontoAprobado.Text = dtCartasFianza.Rows[idSeleccionado]["nMonto"].ToString();
                txtMontoRenovacion.Text = dtCartasFianza.Rows[idSeleccionado]["nMonto"].ToString();
                txtPlazoAprobado.Text = dtCartasFianza.Rows[idSeleccionado]["nPlazo"].ToString();
                txtPlazoRenovacion.Text = dtCartasFianza.Rows[idSeleccionado]["nPlazo"].ToString();
                txtFechaInicioAprobado.Text = dtCartasFianza.Rows[idSeleccionado]["dFechaVigencia"].ToString();
                DateTime fechaInicioAprobado = Convert.ToDateTime(dtCartasFianza.Rows[idSeleccionado]["dFechaVigencia"]);
                txtFechaInicioRenovacion.Text = fechaInicioAprobado.AddDays(Convert.ToInt32(dtCartasFianza.Rows[idSeleccionado]["nPlazo"].ToString())).ToString();
                txtTasaAprobada.Text = dtCartasFianza.Rows[idSeleccionado]["nTasaComision"].ToString() + " %";
                txtTasaRenovacion.Text = dtCartasFianza.Rows[idSeleccionado]["nTasaComision"].ToString() + " %";
                txtPlazoRenovacion.Enabled = true;
                btnAceptar1.Enabled = true;
                btnCancelar1.Enabled = true;
            }
            else
            {
                MessageBox.Show(@"El cliente no tiene cartas fianzas a renovar.", "Renovación carta fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarControles();
        }

        private void limpiarControles()
        {
            txtCartaFianza.Text = "";
            cboMoneda1.SelectedIndex = -1;
            cboMoneda2.SelectedIndex = -1;
            txtMontoAprobado.Text = "";
            txtMontoRenovacion.Text = "";
            txtPlazoAprobado.Text = "";
            txtPlazoRenovacion.Text = "";
            txtFechaInicioAprobado.Text = "";            
            txtFechaInicioRenovacion.Text = "";
            txtTasaAprobada.Text = "";
            txtTasaRenovacion.Text = "";
            btnAceptar1.Enabled = false;
            btnCancelar1.Enabled = false;
            txtPlazoRenovacion.Enabled = false;
            conBusCli1.limpiarControles();
            conBusCli1.txtCodCli.Focus();
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var Msg = MessageBox.Show("¿Esta Seguro de Renovar la carta fianza?", "Renovación carta fianza", MessageBoxButtons.YesNo, MessageBoxIcon.Question);            
                if (Msg == DialogResult.No)
                {
                    return;
                }
                DataTable dtResultado = cnCartaFianza.renovarCartaFianza(Convert.ToInt32(dtCartasFianza.Rows[idSeleccionado]["idCartaFianza"]), Convert.ToInt32(txtPlazoRenovacion.Text));
                if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0][0]) != 0)
                {
                    MessageBox.Show("Renovación realizada con Exito, Solicitud numero: " + dtResultado.Rows[0]["idResultado"], "Renovación carta fianza", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarControles();
                }
                else
                {
                    MessageBox.Show("Error al renovar la carta fianza: " + dtResultado.Rows[0]["cMensaje"], "Renovación carta fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private bool validar()
        {
            if (txtPlazoRenovacion.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Debe ingresar el plazo nuevo de la carta fianza a renovar", "Validación Renovación carta fianza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPlazoRenovacion.Focus();
                return false;
            }
            return true;
        }
    }
}
