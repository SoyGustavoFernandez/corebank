using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAJ.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;

namespace CAJ.Presentacion
{
    public partial class frmRegistroPagoComprobante : frmPagoComprobantes
    {
        #region Variables
        private int idComprobante;
        public bool lComprobantePagado = false;
        #endregion
        public frmRegistroPagoComprobante()
        {
            InitializeComponent();
        }

        public frmRegistroPagoComprobante(int idComprobante_)
        {
            idComprobante = idComprobante_;
            InitializeComponent();
        }

        private void frmRegistroPagoComprobante_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EntityLayer.EventoFormulario.INICIO);
            this.btnCancelar.Visible = false;
            this.btnExtorno.Visible = false;
            this.btnEditar.Visible = false;
            this.btnGrabar.Visible = false;
            this.btnPagar1.Visible = true;

            this.BuscarComprobante(idComprobante);
            this.getDatosComprobante();

            if (this.getEstadoComprobante() == 1)
            {
                btnPagar1.Visible = true;
            }
            else
            {
                btnPagar1.Visible = false;
            }
        }

        private void btnPagar1_Click(object sender, EventArgs e)
        {
            if (this.validar())
            {
                return;
            }

            decimal nImportePagado = datCpg.nImportePagado;
            //-----------------------------------------------------------------------------
            //--valida Saldos de Caja
            //-----------------------------------------------------------------------------
            if (datCpg.idTipoPago == 1)
            {
                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, datCpg.idMoneda, 2, nImportePagado))
                {
                    return;
                }
            }

            this.btnPagar1.Enabled = false;

            DataTable dtResult = this.guardarComprobantePago();

            if (dtResult.Rows[0]["idMsje"].ToString() == "1")
            {
                lComprobantePagado = true;
               
                // RQ-412 Integracion de Saldos en Linea
                new Semaforo().ValidarSaldoSemaforo();

                MessageBox.Show(dtResult.Rows[0]["cMsje"].ToString(), "Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.btnPagar1.Enabled = true;
                MessageBox.Show(dtResult.Rows[0]["cMsje"].ToString(), "Pago de Comprobantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
