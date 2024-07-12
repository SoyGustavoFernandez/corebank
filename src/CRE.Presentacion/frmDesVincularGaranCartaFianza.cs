using CRE.CapaNegocio;
using EntityLayer;
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
    public partial class frmDesVincularGaranCartaFianza : frmBase
    {
        clsCNCartaFianza cnCartaFianza = new clsCNCartaFianza();
        int idCartaFianza = 0;
        public frmDesVincularGaranCartaFianza()
        {
            InitializeComponent();
        }

        private void frmDesVincularGaranCartaFianza_Load(object sender, EventArgs e)
        {
            this.conBusCuentaCli1.cTipoBusqueda = "F";
            this.conBusCuentaCli1.cEstado = "[8]";
            this.conBusCuentaCli1.MyClic += conBusCuentaCli1_MyClic;
            this.conBusCuentaCli1.MyKey += conBusCuentaCli1_MyClic;
            this.conBusCuentaCli1.lblNroBuscar.Text = "Nro de carta fianza";
            habilitarControles(false);
            limpiar(); 
        }

        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.conBusCuentaCli1.txtNroBusqueda.Text))
            {
                idCartaFianza = Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text);
                cargar();
            }
            else
            {
                limpiar();
            }
        }
        
        private void cargar()
        {
            DataTable dtCartaFianza = cnCartaFianza.obtenerCartaFianzaCancelada(idCartaFianza);
            if (dtCartaFianza.Rows.Count > 0)
            {
                int idMotivoCancelacion = Convert.ToInt32(dtCartaFianza.Rows[0]["idMotivoCancelacion"]);
                if (idMotivoCancelacion == 7 || idMotivoCancelacion == 9)
                {
                    txtCartaFianza.Text = dtCartaFianza.Rows[0]["nroCartaFianza"].ToString();
                    txtMontoAprobado.Text = dtCartaFianza.Rows[0]["nMontoCartaFianza"].ToString();
                    txtFechaCancelacion.Text = dtCartaFianza.Rows[0]["dFechaCancelacion"].ToString();
                    txtMoneda.Text = dtCartaFianza.Rows[0]["cMoneda"].ToString();
                    DataTable dtGarantias = cnCartaFianza.obtenerGarantiasDetalle(idCartaFianza, true);
                    if (dtGarantias.Rows.Count > 0)
                    {
                        dtgGarantias.DataSource = dtGarantias;
                        formtearDtgGarantias();
                        habilitarControles(true);
                    }
                    else
                    {
                        MessageBox.Show("La carta fianza no tiene garantias a liberar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                        habilitarControles(false);
                    }
                }
                else
                {
                    MessageBox.Show("El motivo de cancelación de carta fianza no corresponde para la liberación de las garantías", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                    habilitarControles(false);
                }
            }
            else
            {
                limpiar();
            }
        }

        private void formtearDtgGarantias()
        {
            foreach (DataGridViewColumn column in dtgGarantias.Columns)
            {
                column.Visible = false;
            }

            dtgGarantias.Columns["cNombreGarantia"].Visible = true;
            dtgGarantias.Columns["cNroCuenta"].Visible = true;
            dtgGarantias.Columns["cTitular"].Visible = true;
            dtgGarantias.Columns["nMontoGrabado"].Visible = true;

            dtgGarantias.Columns["cNombreGarantia"].HeaderText = "Garantia";
            dtgGarantias.Columns["cNroCuenta"].HeaderText = "Nro. Cuenta";
            dtgGarantias.Columns["cTitular"].HeaderText = "Titular";
            dtgGarantias.Columns["nMontoGrabado"].HeaderText = "Monto";
            
            dtgGarantias.Columns["cNombreGarantia"].Width = 80;
            dtgGarantias.Columns["cNroCuenta"].Width = 50;
            dtgGarantias.Columns["cTitular"].Width = 100;
            dtgGarantias.Columns["nMontoGrabado"].Width = 70;
        }

        private void habilitarControles(bool lHabilitar)
        {
            this.conBusCuentaCli1.Enabled = !lHabilitar;
            this.conBusCuentaCli1.btnBusCliente1.Enabled = !lHabilitar;
            this.conBusCuentaCli1.txtNroBusqueda.Enabled = !lHabilitar;
            btnCancelar1.Enabled = lHabilitar;
            btnLiberar1.Enabled = lHabilitar;
        }

        private void limpiar()
        {
            this.conBusCuentaCli1.limpiarControles();
            this.conBusCuentaCli1.txtNroBusqueda.Focus();
            txtCartaFianza.Clear();
            txtMontoAprobado.Clear();
            txtFechaCancelacion.Clear();
            txtMoneda.Clear();
            dtgGarantias.DataSource = null;
        }

        private void btnLiberar1_Click(object sender, EventArgs e)
        {
            DataTable dtResultado = cnCartaFianza.DesvinculaGarantiasYDesbloqueaDep(idCartaFianza, clsVarGlobal.dFecSystem, clsVarGlobal.PerfilUsu.idUsuario);
            if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
            {
                MessageBox.Show("Se desvinculo correctamente las garantias y se desbloquearon las cuentas de depositos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                habilitarControles(false);
                limpiar();
            }
            else
            {
                MessageBox.Show("Error al cancelar carta fianza", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        
        private void btnCancelar1_Click_1(object sender, EventArgs e)
        {
            limpiar();
            habilitarControles(false);
        }


    }
}
