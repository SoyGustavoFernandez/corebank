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
    public partial class frmCancelarCartaFianza : frmBase
    {
        clsCNCartaFianza cnCartaFianza = new clsCNCartaFianza();
        int idCartaFianza=0;

        public frmCancelarCartaFianza()
        {
            InitializeComponent();
        }

        private void frmCancelarCartaFianza_Load(object sender, EventArgs e)
        {
            this.conBusCuentaCli1.cTipoBusqueda = "F";
            this.conBusCuentaCli1.cEstado = "[6,7]";
            this.conBusCuentaCli1.MyClic += conBusCuentaCli1_MyClic;
            this.conBusCuentaCli1.MyKey += conBusCuentaCli1_MyClic;
            this.conBusCuentaCli1.lblNroBuscar.Text = "Nro de carta fianza";
            cboMotivoCancelacion1.cboMotivoCancelacionPorModulo(15);
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

        private void limpiar()
        {
            this.conBusCuentaCli1.limpiarControles();            
            this.conBusCuentaCli1.txtNroBusqueda.Focus();
            txtCartaFianza.Clear();
            txtMontoAprobado.Clear();
            txtTasaAprobada.Clear();
            txtFechaInicioAprobado.Clear();
            txtPlazoAprobado.Clear();
            cboMoneda1.SelectedIndex = -1;
            txtEstado.Clear();
            txtDocumentoReferencia.Clear();
            txtMotivoSustento.Clear();
            cboMotivoCancelacion1.SelectedIndex = -1;
        }

        public void cargar()
        {
            DataTable dtCartaFianza = cnCartaFianza.obtenerCartaFianza(idCartaFianza);
            if (dtCartaFianza.Rows.Count > 0)
            {
                txtCartaFianza.Text = dtCartaFianza.Rows[0]["codCartaFianza"].ToString();
                txtMontoAprobado.Text = dtCartaFianza.Rows[0]["nMonto"].ToString();
                txtTasaAprobada.Text = dtCartaFianza.Rows[0]["nTasaComision"].ToString();
                txtFechaInicioAprobado.Text = dtCartaFianza.Rows[0]["dFechaVigencia"].ToString();
                txtPlazoAprobado.Text = dtCartaFianza.Rows[0]["nPlazo"].ToString();
                cboMoneda1.SelectedValue = Convert.ToInt32(dtCartaFianza.Rows[0]["idMoneda"]);
                txtEstado.Text = dtCartaFianza.Rows[0]["cEstado"].ToString();
                habilitarControles(true);
            }
            else
            {
                habilitarControles(false);
                limpiar();
            }
        }

        private void habilitarControles(bool lHabilitar)
        {
            this.conBusCuentaCli1.Enabled = !lHabilitar;
            this.conBusCuentaCli1.btnBusCliente1.Enabled = !lHabilitar;
            this.conBusCuentaCli1.txtNroBusqueda.Enabled = !lHabilitar;
            gboDatosCancelacion.Enabled = lHabilitar;

            btnGrabar1.Enabled = lHabilitar;
            btnCancelar1.Enabled = lHabilitar;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            habilitarControles(false);
            limpiar();
            
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            DataTable dtResultado = cnCartaFianza.cancelarCartaFianza(idCartaFianza, Convert.ToInt32(cboMotivoCancelacion1.SelectedValue),txtDocumentoReferencia.Text, txtMotivoSustento.Text, clsVarGlobal.dFecSystem, clsVarGlobal.PerfilUsu.idUsuario);
            if (Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
            {
                MessageBox.Show("Se canceló correctamente la carta fianza", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                habilitarControles(false);
                limpiar();
            }
            else
            {
                MessageBox.Show("Error al cancelar carta fianza", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

       
    }
}
