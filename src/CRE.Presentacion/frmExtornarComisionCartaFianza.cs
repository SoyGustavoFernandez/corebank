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
    public partial class frmExtornarComisionCartaFianza : frmBase
    {
        clsCNCartaFianza cnCartaFianza = new clsCNCartaFianza();
        int idKardex = 0;
        int idMoneda = 0;
        int idSolicitoAproba = 0;
        public frmExtornarComisionCartaFianza()
        {
            InitializeComponent();
        }

        private void btnListaAprob1_Click(object sender, EventArgs e)
        {
            frmListarExtComisionCartaFianza frmListarExtComisionCartaFianza = new frmListarExtComisionCartaFianza();
            frmListarExtComisionCartaFianza.ShowDialog();
            if (frmListarExtComisionCartaFianza.idKardexSelec > 0)
            {
                idKardex = frmListarExtComisionCartaFianza.idKardexSelec;
                idSolicitoAproba = frmListarExtComisionCartaFianza.idSolicitoAproba;
                cargarDatos();
            }
        }

        private void cargarDatos()
        {
            DataTable dtComision = cnCartaFianza.obtenerOperacionAExtornar(idKardex);
            if (dtComision.Rows.Count > 0)
            {
                txtKardex.Text = idKardex.ToString("000000");
                txtTipoDocumento.Text = dtComision.Rows[0]["cTipoDocumento"].ToString();
                txtNumeroDocumento.Text = dtComision.Rows[0]["cNumeroDocumento"].ToString();
                txtMoneda.Text = dtComision.Rows[0]["cMoneda"].ToString();
                txtMonto.Text = dtComision.Rows[0]["nMonto"].ToString();
                txtFecha.Text = dtComision.Rows[0]["cFechaHora"].ToString();
                idMoneda = Convert.ToInt32(dtComision.Rows[0]["idMoneda"].ToString());
                btnExtorno1.Enabled = true;  
            }
        }

        private void btnExtorno1_Click(object sender, EventArgs e)
        {
            var Msg = MessageBox.Show("¿Esta Seguro de Extornar la Operación?", "Extornar Operaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            bool lModificaSaldoLinea = true;
            int idTipoTransac = 2; //EGRESO
            int nIdAgencia = clsVarGlobal.nIdAgencia;
            decimal nMontoOpe = Convert.ToDecimal(txtMonto.Text);
            int idUsuario = clsVarGlobal.PerfilUsu.idUsuario;

            if (Msg == DialogResult.No)
            {
                return;
            }
            if (ValidaSaldoLinea(clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.nIdAgencia, idMoneda, 2, Convert.ToDecimal(txtMonto.Text)))
            {
                return;
            }
            DataTable dtResultado = cnCartaFianza.extornarComision(idKardex, clsVarGlobal.dFecSystem, idSolicitoAproba, lModificaSaldoLinea, idTipoTransac, nIdAgencia, idMoneda, nMontoOpe, idUsuario);
            if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0][0]) != 0)
            {
                // RQ-412 Integracion de Saldos en Linea
                new Semaforo().ValidarSaldoSemaforo();
                
                MessageBox.Show("Se realizó el extorno de pago de la comisión de carta fianza", "Carta Fianza", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //impresion del voucher

                decimal nMontoRecibido = 0;
                decimal nMontoVuelto = 0;
                ImpresionVoucher(idKardex, 1, 0, 1, nMontoRecibido, nMontoVuelto, 0, 1);
                limpiarCampos();
                btnExtorno1.Enabled = false;
            }
            else
            {
                //ActualizarSaldo(clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.nIdAgencia, idMoneda, 1, Convert.ToDecimal /*era ToDouble*/(txtMonto.Text));
                MessageBox.Show("Error al extonar la operacion: " + dtResultado.Rows[0][0], "Extornar Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void limpiarCampos()
        {
            txtKardex.Text = "";
            txtTipoDocumento.Text = "";
            txtNumeroDocumento.Text = "";
            txtMoneda.Text = "";
            txtMonto.Text = "";
            txtFecha.Text = "";
            idMoneda = 0;
            idKardex = 0;
        }

        private void frmExtornarComisionCartaFianza_Load(object sender, EventArgs e)
        {
            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }
            btnExtorno1.Enabled = false;
        }
    }
}
