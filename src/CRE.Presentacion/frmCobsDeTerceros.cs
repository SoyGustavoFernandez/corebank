using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using EntityLayer;

namespace CRE.Presentacion
{
    public partial class frmCobsDeTerceros : frmBase
    {
        private string cTituloMsg;
        clsCNCondonacion SolicCondonacion;
        DataRow drTmp;
        public DataRow drRes;
        public int idMoneda;
        int idMonedaTmp;
        public frmCobsDeTerceros(int idMoneda_ = 1)
        {
            InitializeComponent();
            this.cTituloMsg = "Vincular Cobs de Terceros";
            this.idMoneda = idMoneda_;
            SolicCondonacion = new clsCNCondonacion();
        }

        private void btn_Vincular1_Click(object sender, EventArgs e)
        {
            if (!validar(false))
            {
                return;
            }

            frmMsgAdvertencia frmMensaje = new frmMsgAdvertencia("Advertencia de vinculación de COB's de Terceros"
                    , "Se esta intentando vincular la COB de terceros con codigo de operación Nro.: " + txtKardex.Text
                        + ", cualquier responsabilidad será asumida por su usuario: " + clsVarGlobal.User.cWinUser);

            frmMensaje.ShowDialog();

            DialogResult dResult = frmMensaje.dRes;
            
            if (dResult == DialogResult.OK)
            {
                drRes = drTmp;
                this.Dispose();
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            limpiarForm();
            txtKardex.Enabled = true;
            drRes = null;
            drTmp = null;
        }

        private bool validar(bool lOnlyKardex = false)
        {
            if (lOnlyKardex)
            {
                if (string.IsNullOrEmpty(txtKardex.Text))
                {
                    MessageBox.Show("Ingrese el número de operación de la COB", this.cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                return true;
            }

            if (string.IsNullOrEmpty(txtKardex.Text))
            {
                MessageBox.Show("Ingrese el número de operación de la COB", this.cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtNroRecibo.Text))
            {
                MessageBox.Show("Ingrese el número de recibo", this.cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (idMoneda != idMonedaTmp)
            {
                MessageBox.Show("No se puede vincular una Operacion con distinto tipo de Moneda a la del Crédito", this.cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;

        }

        private void btnMiniBusq1_Click(object sender, EventArgs e)
        {
            if (!this.validar(true))
            {
                return;
            }

            this.buscarCobXKardex(Convert.ToInt32(txtKardex.Text));
        }

        private void buscarCobXKardex(int idKardex)
        {
            DataTable dtRes = SolicCondonacion.CNBuscaCobsXNroOperacion(idKardex);
            
            if (dtRes.Rows.Count > 0)
            {
                drTmp = dtRes.Rows[0];
                txtNroRecibo.Text = dtRes.Rows[0]["idRecibo"].ToString();
                txtMoneda.Text = dtRes.Rows[0]["cMoneda"].ToString();
                txtMonto.Text = dtRes.Rows[0]["nMontoTot"].ToString();
                txtIdCLi.Text = dtRes.Rows[0]["idCli"].ToString();
                txtCliente.Text = dtRes.Rows[0]["cNombre"].ToString();
                txtFechaOpe.Text = dtRes.Rows[0]["dFechaOpe"].ToString();
                txtSustento.Text = dtRes.Rows[0]["cSustento"].ToString();
                idMonedaTmp = Convert.ToInt32(dtRes.Rows[0]["idMoneda"]);
                txtKardex.Enabled = false;
            }
            else
            {
                MessageBox.Show("No se ha encontrado una COB con el Nro de Operación : "+ txtKardex.Text+", que este libre para vincular.", this.cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void limpiarForm()
        {
            txtNroRecibo.Clear();
            txtMoneda.Clear();
            txtMonto.Clear();
            txtIdCLi.Clear();
            txtCliente.Clear();
            txtFechaOpe.Clear();
            txtSustento.Clear();
            txtKardex.Clear();
            drTmp = null;
        }

        private void txtKardex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.buscarCobXKardex(Convert.ToInt32(txtKardex.Text));
            }
        }
    }
}
