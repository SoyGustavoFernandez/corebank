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
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmExtornoRecibos : frmBase
    {
        int pidCuenta = 0, pidTipPago = 0;
        private int pidTipoIngresoEgreso;
        public frmExtornoRecibos()
        {
            InitializeComponent();
        }

        private void frmExtornoRecibos_Load(object sender, EventArgs e)
        {
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }
            conSolesDolar.iMagenMoneda(1);
        }

        private void LimpiarControles()
        {
            txtDocIdePerson.Clear();
            txtNombrePerson.Clear();
            txtFechaOpe.Clear();
            this.txtModulo.Clear();
            txtProducto.Clear();
            this.cboTipoOperacion.SelectedValue = 1;
            this.cboMoneda.SelectedValue = 1;
            this.txtMonOpe.Text = "0.00";
        }

        private bool ValiDatos()
        {
            if (string.IsNullOrEmpty(this.nudNroKardex.Value.ToString()))
            {
                MessageBox.Show("El Numero de Kardex, esta Vacio, por Favor VErificar ", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (this.nudNroKardex.Value <= 0)
            {
                MessageBox.Show("El Numero de Kardex no es Válido, VERIFICAR ", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(this.txtModulo.Text.Trim()))
            {
                MessageBox.Show("La Operación no Pertenece a Ningun Módulo, No Puede Realizar el Extorno", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            nudNroKardex.Value = 0;
            txtEstadoOpe.Text = "";
            LimpiarControles();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            pidCuenta = 0;
            pidTipPago = 0;
            btnExtorno.Enabled = false;
            frmBuscarSolExt frmExtPen = new frmBuscarSolExt();
            frmExtPen.pidMod = 3;
            frmExtPen.pidTipOpe = "5,62";
            frmExtPen.ShowDialog();
            int nidKar = frmExtPen.pidKardex;
            if (nidKar > 0)
            {
                nudNroKardex.Value = nidKar;
                this.txtEstadoOpe.Text = frmExtPen.pcEstKardex;
            }
            else
            {
                nudNroKardex.Value = 0;
                this.txtEstadoOpe.Text = "";
                return;
            }

            clsCNAprobacion objApr = new clsCNAprobacion();
            DataTable dtDatExt = objApr.RetornaDatosOperacionExt(Convert.ToInt32(nudNroKardex.Value), clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia,
                                                                clsVarGlobal.User.idUsuario, 3, "5,62");
            if (dtDatExt.Rows.Count > 0)
            {
                this.txtDocIdePerson.Text = dtDatExt.Rows[0]["cNroDNI"].ToString();
                this.txtNombrePerson.Text = dtDatExt.Rows[0]["cNomCliente"].ToString();
                this.txtFechaOpe.Text = dtDatExt.Rows[0]["dFecHoraOpe"].ToString();
                this.txtModulo.Text = dtDatExt.Rows[0]["cModulo"].ToString();
                this.cboTipoOperacion.SelectedValue = dtDatExt.Rows[0]["idTipoOperacion"].ToString();
                this.cboMoneda.SelectedValue = dtDatExt.Rows[0]["idMoneda"].ToString();
                this.txtMonOpe.Text = dtDatExt.Rows[0]["nMontoOperacion"].ToString();
                //--Asignando Valores
                pidCuenta = Convert.ToInt32(dtDatExt.Rows[0]["idCuenta"].ToString());
                pidTipPago = Convert.ToInt32(dtDatExt.Rows[0]["idTipoPago"].ToString());
                pidTipoIngresoEgreso = Convert.ToInt32(dtDatExt.Rows[0]["idTipoIngresoEgreso"].ToString());
                if (pidTipoIngresoEgreso==1)
                {
                    pidTipoIngresoEgreso = 2;
                }
                else if (pidTipoIngresoEgreso==2)
                {
                    pidTipoIngresoEgreso = 1;
                }
                btnExtorno.Enabled = true;
            }
            else
            {
                MessageBox.Show("No Existen Datos de la Operación: VERIFICAR", "Validar Datos del Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnExtorno_Click(object sender, EventArgs e)
        {
            if (!ValiDatos())
            {
                return;
            }

            var Msg = MessageBox.Show("Esta Seguro de Extornar la Operación?...", "Extornar  Recibos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Msg == DialogResult.No)
            {
                return;
            }

            //-======================================================
            //--Registrar Extorno de Operación
            //-======================================================
            int idKar = Convert.ToInt32(this.nudNroKardex.Text.ToString());
            int idKarExt = 0;
            int idTipOpe = Convert.ToInt32(this.cboTipoOperacion.SelectedValue.ToString());
            int idMon = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
            Decimal nMontoOpe = Convert.ToDecimal(this.txtMonOpe.Text);
            bool lModificaSaldoLinea = true;

            if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, idMon, pidTipoIngresoEgreso, nMontoOpe))
            {
                return;
            }

            clsCNControlOpe dtExt = new clsCNControlOpe();
            DataTable tbExt = dtExt.CNRegistraExtornoRecibos(idKar, pidCuenta, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem,
                                                          nMontoOpe, idTipOpe, pidTipPago, lModificaSaldoLinea, pidTipoIngresoEgreso, idMon);

            if (Convert.ToInt32(tbExt.Rows[0]["idRpta"].ToString()) == 0)
            {
                // RQ-412 Integracion de Saldos en Linea
                new Semaforo().ValidarSaldoSemaforo();

                MessageBox.Show(tbExt.Rows[0]["cMensage"].ToString(), "Extorno de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                idKarExt = Convert.ToInt32(tbExt.Rows[0]["idKardexExt"].ToString());
                this.nudNroKardex.Enabled = false;
                this.btnExtorno.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                MessageBox.Show(tbExt.Rows[0]["cMensage"].ToString(), "Extorno de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //--------------------------------------------------------------------
            //Impresion del voucher
            //--------------------------------------------------------------------
            if (idKarExt > 0)
            {
                ImpresionVoucher(idKarExt, clsVarGlobal.idModulo, idTipOpe, 2, 0, 0, 0, 1);
            }
        }
    }
}
