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
using DEP.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using SER.CapaNegocio;

namespace DEP.Presentacion
{
    public partial class frmExtornoCompraVenta : frmBase
    {
        int pidCuenta = 0, pidTipPago = 0;
        DataTable dtListOperCompVent = new DataTable();

        public frmExtornoCompraVenta()
        {
            InitializeComponent();
        }

        private void frmExtornoCompraVenta_Load(object sender, EventArgs e)
        {
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }
        }

        private void LimpiarControles()
        {
            txtDocIdePerson.Clear();
            txtNombrePerson.Clear();
            txtFechaOpe.Clear();
            this.txtModulo.Clear();
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

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            pidCuenta = 0;
            pidTipPago = 0;
            btnExtorno.Enabled = false;
            frmBuscarSolExt frmExtPen = new frmBuscarSolExt();
            frmExtPen.pidMod = 9;
            frmExtPen.pidTipOpe = "20,21";
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
                                                                clsVarGlobal.User.idUsuario, 9, "20,21");
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
                btnExtorno.Enabled = true;

                clsCNControlServ CompraVenta = new clsCNControlServ();
                dtListOperCompVent = CompraVenta.CNListaOperCompraVenta(Convert.ToInt32(nudNroKardex.Value));

            }
            else
            {
                MessageBox.Show("No Existen Datos de la Operación: VERIFICAR", "Validar Datos del Extorno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            nudNroKardex.Value = 0;
            txtEstadoOpe.Text = "";
            LimpiarControles();
        }

        private void btnExtorno_Click(object sender, EventArgs e)
        {
            if (!ValiDatos())
            {
                return;
            }

            var Msg = MessageBox.Show("Esta Seguro de Extornar la Operación?...", "Extornar  Compra/Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Msg == DialogResult.No)
            {
                return;
            }

            //-======================================================
            //--Registrar Extorno de Operación
            //-======================================================
            int idKar = Convert.ToInt32(this.nudNroKardex.Text.ToString());
            int idTipOpe = Convert.ToInt32(this.cboTipoOperacion.SelectedValue.ToString());
            int idMon = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
            Decimal nMontoOpe = Convert.ToDecimal(this.txtMonOpe.Text);
            //--==========================================================================================
            //-- valida los  saldos
            //--==========================================================================================           
            for (int i = 0; i < dtListOperCompVent.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtListOperCompVent.Rows[i]["idTipoPago"]) == 1)
                {
                    if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt32(dtListOperCompVent.Rows[i]["idMoneda"]), Convert.ToInt32(dtListOperCompVent.Rows[i]["idTipoIngresoEgreso"]) == 1 ? 2 : 1, Convert.ToDecimal(dtListOperCompVent.Rows[i]["nMontoOperacion"])))
                    {
                        return;
                    }
                }
            }

            //--Fin Monitoreo

            clsCNCompraVenta dtExt = new clsCNCompraVenta();

            bool lModificaSaldoLinea = false;

            DataTable tbExt = dtExt.RegistraExtornoOpeCV(idKar, pidCuenta, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem,
                                                        nMontoOpe, idTipOpe, pidTipPago, Convert.ToInt32(nudNroKardex.Value), lModificaSaldoLinea);

            if (Convert.ToInt32(tbExt.Rows[0]["idRpta"].ToString()) == 0)
            {
                //// RQ-412 Integracion de Saldos en Linea
                new Semaforo().ValidarSaldoSemaforo();

                MessageBox.Show(tbExt.Rows[0]["cMensage"].ToString(), "Extorno de Compra/Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.nudNroKardex.Enabled = false;
                this.btnExtorno.Enabled = false;
                this.btnCancelar.Enabled = true;
                //--------------------------------------IMPRIMIR VOUCHER --------------------------------------->                    
                int idKardex = Convert.ToInt32(tbExt.Rows[0]["nNroOperacion"]);
                ImpresionVoucher(idKardex, 9, idTipOpe, 1, Convert.ToDecimal(this.txtMonOpe.Text), 0, 0, 1);
                //---------------------------------------------------------------------------------------------->
            }
            else
            {
                MessageBox.Show(tbExt.Rows[0]["cMensage"].ToString(), "Extorno de Compra/Venta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
