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

namespace DEP.Presentacion
{
    public partial class frmExtornoOpeAho : frmBase
    {
        int pidCuenta = 0, pidTipPago = 0, p_idCta = 0, p_idTipoPago = 0, idTipoIngresoEgreso=0;
        clsCNDeposito clsDeposito = new clsCNDeposito();

        public frmExtornoOpeAho()
        {
            InitializeComponent();
        }

        private void frmExtornoOpeAho_Load(object sender, EventArgs e)
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
            if (this.nudNroKardex.Value<=0)
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
            p_idTipoPago = 0;
            p_idCta = 0;
            if (Convert.ToInt32(nudNroKardex.Value) > 0)
            {
                clsDeposito.CNUpdNoUsoCuenta(Convert.ToInt32(nudNroKardex.Value));
            }
            
            LimpiarControles();
            pidCuenta = 0;
            pidTipPago=0;
            btnExtorno.Enabled = false;
            frmBuscarSolExt frmExtPen = new frmBuscarSolExt();
            frmExtPen.pidMod = 2;
            frmExtPen.pidTipOpe = "9,10,11,12";
            frmExtPen.ShowDialog();
            int nidKar = frmExtPen.pidKardex;
            if (nidKar>0)
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
                                                                clsVarGlobal.User.idUsuario, 2, "9,10,11,12");
            if (dtDatExt.Rows.Count>0)
            {
                if (string.IsNullOrEmpty(dtDatExt.Rows[0]["cProducto"].ToString()))
                {
                    MessageBox.Show("No Tiene Datos del Producto: VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                pidCuenta = Convert.ToInt32(dtDatExt.Rows[0]["idCuenta"].ToString());
                //--===============================================================================
                //--Validar Si Cuenta esta Siendo Usada
                //--===============================================================================
                p_idCta = pidCuenta;
                DataTable dtbDatCuentas = clsDeposito.CNRetornaDatosCuenta(p_idCta, "1", 11);
                if (dtbDatCuentas.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dtbDatCuentas.Rows[0]["idUsuarioqBlo"].ToString()))
                    {
                        int idusuBlo = Convert.ToInt32(dtbDatCuentas.Rows[0]["idUsuarioqBlo"].ToString());
                        clsCNRetornaNumCuenta RetUsuario = new clsCNRetornaNumCuenta();
                        DataTable dtUsu = RetUsuario.BusUsuBlo(idusuBlo);
                        string cUserBloqueo = dtUsu.Rows[0][0].ToString();
                        MessageBox.Show("La Cuenta esta Siendo Consultada por Otro Usuario: " + cUserBloqueo, "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                this.txtDocIdePerson.Text = dtDatExt.Rows[0]["cNroDNI"].ToString();
                this.txtNombrePerson.Text = dtDatExt.Rows[0]["cNomCliente"].ToString();
                this.txtFechaOpe.Text = dtDatExt.Rows[0]["dFecHoraOpe"].ToString();
                this.txtProducto.Text = dtDatExt.Rows[0]["cProducto"].ToString();
                this.txtModulo.Text = dtDatExt.Rows[0]["cModulo"].ToString();
                this.cboTipoOperacion.SelectedValue = dtDatExt.Rows[0]["idTipoOperacion"].ToString();
                this.cboMoneda.SelectedValue = dtDatExt.Rows[0]["idMoneda"].ToString();
                this.txtMonOpe.Text = dtDatExt.Rows[0]["nMontoOperacion"].ToString();
                p_idTipoPago = Convert.ToInt32(dtDatExt.Rows[0]["idTipoPago"].ToString());
                //--Asignando Valores                
                pidTipPago = Convert.ToInt32(dtDatExt.Rows[0]["idTipoPago"].ToString());

                idTipoIngresoEgreso = Convert.ToInt32(dtDatExt.Rows[0]["idTipoIngresoEgreso"].ToString());

                //=========================================================================
                //--Validar Si Existe Saldo para Realizar Extorno de DEPOSITO
                //=========================================================================
                if (Convert.ToInt32(this.cboTipoOperacion.SelectedValue)==10)
                {
                    DataTable dtbNumCuentas = clsDeposito.CNRetornaDatosCuenta(pidCuenta, "1", 10);
                    if (dtbNumCuentas.Rows.Count > 0)
                    {
                        if ( Convert.ToDecimal (dtbNumCuentas.Rows[0]["nSaldoDis"].ToString())< Convert.ToDecimal (dtDatExt.Rows[0]["nMontoOperacion"].ToString()))
                        {
                            MessageBox.Show("No se Puede Extornar la Operación, porque no cuenta con Saldo Disponible...VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            LimpiarControles();
                            nudNroKardex.Value = 0;
                            txtEstadoOpe.Text = "";
                            return;
                        }
                    }
                }

                //=========================================================================
                //--Validar Si no realizó Ninguna Operacion en caso de extorno de APERTURA
                //=========================================================================
                if (Convert.ToInt32(this.cboTipoOperacion.SelectedValue) == 9)
                {
                    clsCNOperacionDep clsExtApe = new clsCNOperacionDep();
                    DataTable dtbNumOpe = clsExtApe.RetornaNroOpePostExt(Convert.ToInt32(nudNroKardex.Value),pidCuenta);
                    if (dtbNumOpe.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtbNumOpe.Rows[0]["nNumOperaciones"].ToString())>0)
                        {
                            MessageBox.Show("No se Puede Extornar la Apertura, Tiene Operaciones Posteriores...VERIFICAR", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            LimpiarControles();
                            nudNroKardex.Value = 0;
                            txtEstadoOpe.Text = "";
                            return;
                        }
                    }
                }
                clsDeposito.CNUpdUsoCuenta(p_idCta, clsVarGlobal.User.idUsuario);
                conSolesDolar.iMagenMoneda(Convert.ToInt16(cboMoneda.SelectedValue));
                btnExtorno.Enabled = true;
            }
            else
            {
                MessageBox.Show("No Existen Datos de la Operación: VERIFICAR", "Validar Datos del Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            nudNroKardex.Value = 0;
            txtEstadoOpe.Text = "";
            LimpiarControles();
            clsDeposito.CNUpdNoUsoCuenta(p_idCta);
        }

        private void btnExtorno_Click(object sender, EventArgs e)
        {
            /*========================================================================================
             * REGISTRO DE RASTREO
            ========================================================================================*/

            this.registrarRastreo(Convert.ToInt32(nudNroKardex.Value), Convert.ToInt32(nudNroKardex.Value), "Inicio-Extorno operacion", btnExtorno);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/
            
            if (!ValiDatos())
            {
                return;
            }

            var Msg = MessageBox.Show("Esta Seguro de Extornar la Operación?...", "Extornar Operaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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

            bool lModificaSaldoLinea = false;
            int idTipoTransac = idTipoIngresoEgreso == 1 ? 2 : 1;

            if (p_idTipoPago == 1)
                lModificaSaldoLinea = true;

            Decimal nMontoOpe = Convert.ToDecimal(this.txtMonOpe.Text);
            if (p_idTipoPago == 1)
            {
                int idTipoIngresoEgresoExt = idTipoIngresoEgreso == 1 ? 2 : 1;
                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia,Convert.ToInt16(cboMoneda.SelectedValue), idTipoIngresoEgresoExt, nMontoOpe))
                {
                    return;
                }
            }
            clsCNOperacionDep dtExt = new clsCNOperacionDep();
            DataTable tbExt = dtExt.RegistraExtornoOpe(idKar, pidCuenta, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem,
                                                        nMontoOpe, idTipOpe, pidTipPago, lModificaSaldoLinea, idTipoTransac, idMon);

            if (Convert.ToInt32(tbExt.Rows[0]["idRpta"].ToString()) == 0)
            {
                // RQ-412 Integracion de Saldos en Linea
                new Semaforo().ValidarSaldoSemaforo();
                
                MessageBox.Show(tbExt.Rows[0]["cMensage"].ToString(), "Extorno de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.nudNroKardex.Enabled = false;
                this.btnExtorno.Enabled = false;
                this.btnCancelar.Enabled = true;
             
                clsDeposito.CNUpdNoUsoCuenta(p_idCta);
                ////Impresion del Voucher
                this.ImpresionVoucher(Convert.ToInt32(tbExt.Rows[0]["IdKarExt"]), 2, idTipOpe, 2, 0, 0, 0,1);
            }
            else
            {
                MessageBox.Show(tbExt.Rows[0]["cMensage"].ToString(), "Extorno de Operaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            conSolesDolar.iMagenMoneda(0);

            //this.objFrmSemaforo.ValidarSaldoSemaforo();
            /*========================================================================================
             * REGISTRO DE RASTREO
            ========================================================================================*/

            this.registrarRastreo(Convert.ToInt32(nudNroKardex.Value), Convert.ToInt32(nudNroKardex.Value), "Fin-Extorno operacion", btnExtorno);
            /*========================================================================================
             * FIN DEL REGISTRO DE RASTREO
             ========================================================================================*/

        }

        private void frmExtornoOpeAho_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsDeposito.CNUpdNoUsoCuenta(p_idCta);
        }
    }
}
