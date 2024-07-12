using CLI.Presentacion;
using DEP.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using SER.CapaNegocio;
using SER.Funciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SER.Presentacion
{
    public partial class frmEnvioGiroNuevo : frmBase
    {

        #region Variables
        private clsCNControlServ objCNControlServ = new clsCNControlServ();
        private string _cNroCuenta = String.Empty;
        private int _idCuentaDeposito = 0;
        private decimal _nMontoDisponible = 0;
        private List<clsTarifarioGiros> lstTarifario = new List<clsTarifarioGiros>();
        private const int idTipoOpeRegimenReforzado = 177;
        #endregion


        #region Constructor
        public frmEnvioGiroNuevo()
        {
            InitializeComponent();
            conBusPersonaDestinatario.lConsiderarRUC = false;
        }
        #endregion


        #region Eventos
        private void btnMiniVerInterv_Click(object sender, EventArgs e)
        {
            frmVisualizarVinculado objfrmVisualizarVinculado = new frmVisualizarVinculado();
            objfrmVisualizarVinculado.idCli = conBusPersonaRemitente.idCliente;
            objfrmVisualizarVinculado.ShowDialog();
        }
        private void frmEnvioGiroNuevo_Load(object sender, EventArgs e)
        {
            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }

            HabilitarFormuario(false);
            Limpiar();
            btnNuevo.Focus();
            ObtenerTarifario();
            cboMotivoOpe.ListarMotivoOperacionCNT(13);
            conBusPersonaDestinatario.lModoEdicion = true;
            conBusPersonaRemitente.lModoEdicion = true;
        }
        private void conBusPersonaRemitente_ehCancelar(object sender, EventArgs e)
        {
            cboModalidadesPagoGiro.SelectedValue = 1;
            btnMiniVerInterv.Visible = false;
        }
        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void txtReClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
                e.Handled = false;
            else if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMoneda.SelectedIndex >= 0)
            {
                if (Convert.ToInt32(cboMoneda.SelectedValue) == 2)//moneda dolares
                {
                    this.BackColor = Color.FromArgb(209, 234, 213);
                }
                else
                {
                    this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                }
                if (txtMontoGiro.Enabled)
                    CalcularComisionTotal();
                else
                    CalcularComisionGiro();
            }
        }
        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtReClave.Focus();
            }
        }
        private void txtReClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGrabar.Focus();
            }
        }
        private void cboEstablecimientoGiro_Leave(object sender, EventArgs e)
        {
            cboEstablecimiento.SelectionLength = 0;
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            /*========================================================================================
            * VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/
            clsValidacionPreviaOpe validaciones = new clsValidacionPreviaOpe(conBusPersonaRemitente.idCliente, conBusPersonaRemitente.cNumeroDocumento.Trim(), clsVarGlobal.nIdAgencia, 13, 0);
            if (validaciones.verificPararOperacion())
            {
                return;
            }
            /*========================================================================================
            * FIN - VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/


            if (ValidarFormulario())
            {
                if (!conBusPersonaRemitente.ActualizarNoCliente()) return;
                if (!conBusPersonaDestinatario.ActualizarNoCliente()) return;
                var datosGiro = ObtenerDatos();

                this.registrarRastreo(this.conBusPersonaRemitente.idCliente, this.conBusPersonaDestinatario.idCliente, "Inicio - Registro de envio de giro", btnGrabar);
                /*========================================================================================
                * Validar Regla Eob con autorizacion
                ========================================================================================*/
                //if (!ValidarReglasAprob(Convert.ToString(Convert.ToDecimal(txtMontoGiro.Text)), Convert.ToString(Convert.ToInt32(cboMoneda.SelectedValue))))
                //{
                //    return;
                //}
                /*========================================================================================
                * FIN -  Validar Regla Eob con autorizacion
                ========================================================================================*/

                /*========================================================================================
                * VALIDACIONES PARA REGIMEN DEL CLIENTE
                ========================================================================================*/
                //clsValidacionPreviaOpe validaRegimen = new clsValidacionPreviaOpe(conBusPersonaRemitente.idCliente,
                //                                                                    datosGiro.idMoneda,
                //                                                                    0,
                //                                                                    conBusPersonaDestinatario.idCliente,
                //                                                                    datosGiro.nMontoGiro);
                //if (!validaRegimen.ValidarRegimenCli(idTipoOpeRegimenReforzado))
                //{
                //    return;
                //}


                if (datosGiro.idTipoPago == 1)//efectivo
                {
                    //valida saldos
                    if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, datosGiro.idMoneda, 1, datosGiro.nMontoTotal))
                    {
                        HabilitarFormuario(false);
                        this.btnNuevo.Enabled = true;
                        this.btnGrabar.Enabled = false;
                        this.btnCancelar.Enabled = false;
                        return;
                    }
                    #region Validacion Umbrales Dolares
                    //ERROR
                    int idSubProducto = 126;
                    int idTipoOperacion = 13;
                    frmSustentoArchivoSplaft frmUmbDol = new frmSustentoArchivoSplaft(
                        datosGiro.nMontoTotal,
                        datosGiro.idMoneda,
                        idTipoOperacion,
                        datosGiro.idMotivoOperacion,
                        idSubProducto,
                        datosGiro.idTipoPago);
                    if (!frmUmbDol.obtenerContinuaOperacion())
                        return;

                    #endregion

                    DataTable dtResultado = objCNControlServ.CNRegistrarEnvioGiro(datosGiro);
                    if (Convert.ToInt32(dtResultado.Rows[0]["idRpta"].ToString()) == 0)
                    {
                        // RQ-412 Integracion de Saldos en Linea
                        new Semaforo().ValidarSaldoSemaforo();

                        MessageBox.Show(dtResultado.Rows[0]["cMensage"].ToString() + ", NRO DE GIRO: " + dtResultado.Rows[0]["idServGiro"].ToString() + ", NRO DE OPERACIÓN: " + dtResultado.Rows[0]["nNroOperacion"].ToString(), "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //--------------------------------------IMPRIMIR VOUCHER --------------------------------------->
                        int idKardex = Convert.ToInt32(dtResultado.Rows[0]["nNroOperacion"]);

                        //-----------------------------------------------------------------------------------------------------
                        //--    REALIZA VALIDACION DE REGISTRO DE OPERACIONES ÚNICAS - SPLAFT
                        //-----------------------------------------------------------------------------------------------------
                        frmRegOpeSplaft regope = new frmRegOpeSplaft(idKardex, clsVarGlobal.idModulo);

                        //-----------------------------------------------------------------------------------------------------
                        //--  REALIZA VALIDACION DE REGISTRO DE OPERACIONES MULTIPLES - SPLAFT
                        //-----------------------------------------------------------------------------------------------------
                        frmRegOperacionesMultiples regOpeMult = new frmRegOperacionesMultiples(idKardex);

                        ImpresionVoucher(idKardex, 9, 13, 1, datosGiro.nMontoTotal, 0, 0, 1);
                        //---------------------------------------------------------------------------------------------->
                    }
                    else
                    {
                        MessageBox.Show(dtResultado.Rows[0]["cMensage"].ToString(), "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                if (datosGiro.idTipoPago == 2)
                {
                    DataTable dtResultado = objCNControlServ.CNRegistrarEnvioGiro(datosGiro);
                    if (Convert.ToInt32(dtResultado.Rows[0]["idRpta"].ToString()) == 0)
                    {
                        MessageBox.Show(dtResultado.Rows[0]["cMensage"].ToString() + ", NRO DE GIRO: " + dtResultado.Rows[0]["idServGiro"].ToString() + ", NRO DE OPERACIÓN: " + dtResultado.Rows[0]["nNroOperacion"].ToString(), "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //--------------------------------------IMPRIMIR VOUCHER --------------------------------------->
                        int idKardex = Convert.ToInt32(dtResultado.Rows[0]["nNroOperacion"]);

                        //-----------------------------------------------------------------------------------------------------
                        //--    REALIZA VALIDACION DE REGISTRO DE OPERACIONES ÚNICAS - SPLAFT
                        //-----------------------------------------------------------------------------------------------------
                        frmRegOpeSplaft regope = new frmRegOpeSplaft(idKardex, clsVarGlobal.idModulo);

                        //-----------------------------------------------------------------------------------------------------
                        //--  REALIZA VALIDACION DE REGISTRO DE OPERACIONES MULTIPLES - SPLAFT
                        //-----------------------------------------------------------------------------------------------------
                        frmRegOperacionesMultiples regOpeMult = new frmRegOperacionesMultiples(idKardex);

                        ImpresionVoucher(idKardex, 9, 13, 1, datosGiro.nMontoTotal, 0, 0, 1);
                        //---------------------------------------------------------------------------------------------->
                    }
                    else
                    {
                        MessageBox.Show(dtResultado.Rows[0]["cMensage"].ToString(), "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                HabilitarFormuario(false);
                this.registrarRastreo(this.conBusPersonaRemitente.idCliente, this.conBusPersonaDestinatario.idCliente, "Fin - Registro de envio de giro", btnGrabar);
            }
        }        
        private void chcIncluirComisionTotal_CheckedChanged(object sender, EventArgs e)
        {
            txtMontoTotal.Text = "0.00";
            txtMontoGiro.Text = "0.00";
            txtMontoComision.Text = "0.00";
            txtMontoRedondeo.Text = "0.00";
            txtITF.Text = "0.00";

            if (chcIncluirComisionTotal.Checked)
            {
                txtMontoGiro.Enabled = false;
                txtMontoGiro.Focus();
                txtMontoTotal.Enabled = true;
            }
            else
            {
                txtMontoGiro.Enabled = true;
                txtMontoGiro.Focus();
                txtMontoTotal.Enabled = false;
            }

        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            HabilitarFormuario(true);
            Limpiar();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarFormuario(false);
            Limpiar();
            btnNuevo.Focus();
        }
        private void btnBuscaCtaAho_Click(object sender, EventArgs e)
        {
            int idCliRemitente = Convert.ToInt32(conBusPersonaRemitente.idRegistro); ;
            frmBusCtaAho frmCtaAho = new frmBusCtaAho();
            frmCtaAho.idCli = idCliRemitente;
            frmCtaAho.pTipBus = 1;
            frmCtaAho.idMon = Convert.ToInt32(cboMoneda.SelectedValue);
            frmCtaAho.nTipOpe = 11;  //--Cuentas para Operación de Retiro

            clsCNDeposito objDeposito = new clsCNDeposito();
            DataTable dtbNumCuentas = objDeposito.CNRetornaCuentasAhorros(
                    idCliRemitente,
                    1,
                    Convert.ToInt32(cboMoneda.SelectedValue),
                    frmCtaAho.nTipOpe
                );

            if (dtbNumCuentas.Rows.Count > 0)
            {
                frmCtaAho.ShowDialog();
                _cNroCuenta = frmCtaAho.pnCta;
                if (frmCtaAho.idMon != Convert.ToInt32(cboMoneda.SelectedValue)) //TIPO DE MONEDA DE LA CUENTA DEBE SER LA MISMA QUE EL GIRO
                {
                    MessageBox.Show("La cuenta debe ser en la misma moneda del giro", "Valida Envio de Giro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _cNroCuenta = String.Empty;
                    _idCuentaDeposito = 0;
                    txtNumeroCuenta.Clear();
                    return;
                }
                if (!String.IsNullOrEmpty(frmCtaAho.pcNroCta))
                {
                    String cFormato =
                    frmCtaAho.pcNroCta.Substring(0, 3) + "-" +
                    frmCtaAho.pcNroCta.Substring(3, 3) + "-" +
                    frmCtaAho.pcNroCta.Substring(6, 3) + "-" +
                    frmCtaAho.pcNroCta.Substring(9, 1) + "-" +
                    frmCtaAho.pcNroCta.Substring(10);
                    txtNumeroCuenta.Text = cFormato;
                }
                _nMontoDisponible = string.IsNullOrEmpty(frmCtaAho.pnMonDisp) ? 0.00M : Convert.ToDecimal(frmCtaAho.pnMonDisp);
                _idCuentaDeposito = Convert.ToInt32(frmCtaAho.pnCta);
                txtClave.Focus();
            }
            else
            {
                MessageBox.Show("NO EXISTE CUENTA DE AHORRO PARA VINCULAR" + "\n" + "Debe Aperturar una cuenta de ahorro nueva para el Envio de Giro", "Valida Envio de Giro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this._cNroCuenta = String.Empty;
                txtNumeroCuenta.Clear();
                return;
            }
        }
        private void btnGestionContacto_Click(object sender, EventArgs e)
        {
            frmGestionContacto objFrmGestionContacto = new frmGestionContacto();
            objFrmGestionContacto.ShowDialog();
        }
        private void txtMontoGiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                CalcularComisionTotal();
            }
        }
        private void txtMontoTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                CalcularComisionGiro();
            }
        }
        
        private void conBusPersonaRemitente_ehEncontrado(object sender, EventArgs e)
        {
            cboModalidadesPagoGiro.Enabled = conBusPersonaRemitente.lCliente;
            btnMiniVerInterv.Visible = conBusPersonaRemitente.lCliente && conBusPersonaRemitente.idTipoPersonaBusqueda == 2;
        }
        private void cboModalidadesPagoGiro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModalidadesPagoGiro.SelectedIndex >= 0)
            {
                if (txtMontoTotal.Enabled)
                    CalcularComisionGiro();
                else
                    CalcularComisionTotal();

                cboMotivoOpe.SelectedIndex = cboModalidadesPagoGiro.SelectedIndex;
                if (Convert.ToInt32(cboModalidadesPagoGiro.SelectedValue) == 1)
                {
                    btnBuscaCtaAho.Enabled = false;
                    txtNumeroCuenta.Enabled = false;
                    txtNumeroCuenta.Clear();
                    txtClave.Focus();
                    _nMontoDisponible = 0;
                    _cNroCuenta = "";
                    _idCuentaDeposito = 0;
                }
                else
                {
                    btnBuscaCtaAho.Enabled = true;
                    txtNumeroCuenta.Enabled = true;
                    btnBuscaCtaAho.Focus();
                }
            }
        }
        private void txtMontoGiro_Leave(object sender, EventArgs e)
        {
            CalcularComisionTotal();
        }
        private void txtMontoTotal_Leave(object sender, EventArgs e)
        {
            CalcularComisionGiro();
        }
        private void conBusPersonaDestinatario_ehEncontrado(object sender, EventArgs e)
        {
            if (txtMontoGiro.Enabled)
                CalcularComisionTotal();
            else
                CalcularComisionGiro();
        }
        private void cboEstablecimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEstablecimiento.SelectedIndex >= 0)
            {
                if(cboEstablecimiento.cAgenciaPadre.Length > 0 )
                    lblNombreAgencia.Text = "Pertence a: " + cboEstablecimiento.cAgenciaPadre;
                else
                    lblNombreAgencia.Text = "";
            }
            else
                lblNombreAgencia.Text = "";
            
        }
        #endregion


        #region Métodos
        private clsEnvioGiro ObtenerDatos()
        {
            var objRemitente = new clsGiroParticipante
            {
                idAgencia = clsVarGlobal.nIdAgencia,
                idEstablecimiento = clsVarGlobal.User.idEstablecimiento,
                lCliente = conBusPersonaRemitente.lCliente,
                idRegistro = conBusPersonaRemitente.idRegistro,
                idTipoDocumento = conBusPersonaRemitente.idTipoDocumento,
                cNumeroDocumento = conBusPersonaRemitente.cNumeroDocumento,
                cNombreCompleto = conBusPersonaRemitente.cNombre,
                cPaterno = String.Empty,
                cMaterno = String.Empty,
                cNombres = String.Empty,
                cDireccion = conBusPersonaRemitente.cDireccion,
                cCelular = conBusPersonaRemitente.cCelular
            };

            var objDestinatario = new clsGiroParticipante
            {
                idAgencia = cboEstablecimiento.idAgencia,
                idEstablecimiento = cboEstablecimiento.idEstablecimiento,
                lCliente = conBusPersonaDestinatario.lCliente,
                idRegistro = conBusPersonaDestinatario.idRegistro,
                idTipoDocumento = conBusPersonaDestinatario.idTipoDocumento,
                cNumeroDocumento = conBusPersonaDestinatario.cNumeroDocumento,
                cNombreCompleto = conBusPersonaDestinatario.cNombre,
                cPaterno = String.Empty,
                cMaterno = String.Empty,
                cNombres = String.Empty,
                cDireccion = conBusPersonaDestinatario.cDireccion,
                cCelular = conBusPersonaDestinatario.cCelular
            };

            return new clsEnvioGiro
            {
                dFechaGiro = clsVarGlobal.dFecSystem,
                idUsuarioRegistra = clsVarGlobal.User.idUsuario,
                idCuentaDeposito = _idCuentaDeposito,
                idMoneda = Convert.ToInt32(cboMoneda.SelectedValue),
                nMontoGiro = Convert.ToDecimal(txtMontoGiro.Text),
                nMontoComisionGiro = Convert.ToDecimal(txtMontoComision.Text),
                nMontoITF = Convert.ToDecimal(txtITF.Text),
                nMontoRedondeo = Convert.ToDecimal(txtMontoRedondeo.Text),
                cClaveGiro = txtClave.Text,
                idProducto = 126,
                idCanal = clsVarGlobal.idCanal,
                idTipoOperacion = 13,
                idMotivoOperacion = Convert.ToInt32(cboMotivoOpe.SelectedValue),
                idTipoPago = Convert.ToInt32(cboModalidadesPagoGiro.SelectedValue),
                lModificaSaldoLinea = true,
                idTipoTransac = 1,//ingreso
                nMontoTotal = Convert.ToDecimal(txtMontoTotal.Text),
                objRemitente = objRemitente,
                objDestinatario = objDestinatario
            };
        }
        private void CalcularComisionTotal()
        {
            try
            {
                if (Convert.ToDecimal(txtMontoGiro.Text) > 0)
                {
                    var obj = new clsCalculoComision().CalcularMontoTotal(
                        Convert.ToDecimal(txtMontoGiro.Text),
                        Convert.ToInt32(cboMoneda.SelectedValue),
                        conBusPersonaRemitente.idTipoPersonaBusqueda,
                        lstTarifario,
                        Convert.ToInt32(cboModalidadesPagoGiro.SelectedValue) == 1
                        );
                    txtMontoComision.Text = obj.nComision.ToString("N2");
                    txtMontoGiro.Text = obj.nMontoGiro.ToString("N2");
                    txtITF.Text = obj.nITF.ToString("N2");
                    txtMontoRedondeo.Text = obj.nRedondeo.ToString("N2");
                    txtMontoTotal.Text = obj.nMontoTotal.ToString("N2");
                    cboModalidadesPagoGiro.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMontoComision.Text = "0.00";
                txtMontoGiro.Text = "0.00";
                txtITF.Text = "0.00";
                txtMontoRedondeo.Text = "0.00";
                txtMontoTotal.Text = "0.00";
            }
        }
        private void CalcularComisionGiro()
        {
            try
            {
                if (Convert.ToDecimal(txtMontoTotal.Text) > 0)
                {
                    var obj = new clsCalculoComision().CalcularMontoGiro(
                        Convert.ToDecimal(txtMontoTotal.Text),
                        Convert.ToInt32(cboMoneda.SelectedValue),
                        conBusPersonaRemitente.idTipoPersonaBusqueda,
                        lstTarifario,
                        Convert.ToInt32(cboModalidadesPagoGiro.SelectedValue) == 1
                    );
                    if ((obj.nMontoGiro + obj.nComision + obj.nITF - obj.nRedondeo) != obj.nMontoTotal)
                    {
                        MessageBox.Show("No es posible calcular el monto de giro, ingreselo manualmente a través del monto de giro.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMontoTotal.Text = "0.00";
                        chcIncluirComisionTotal.Checked = false;
                        txtMontoGiro.Focus();
                    }
                    else
                    {
                        txtMontoComision.Text = obj.nComision.ToString("0.00");
                        txtMontoGiro.Text = obj.nMontoGiro.ToString("0.00");
                        txtITF.Text = obj.nITF.ToString("0.00");
                        txtMontoRedondeo.Text = obj.nRedondeo.ToString("0.00");
                        txtMontoTotal.Text = obj.nMontoTotal.ToString("0.00");
                        cboModalidadesPagoGiro.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMontoComision.Text = "0.00";
                txtMontoGiro.Text = "0.00";
                txtITF.Text = "0.00";
                txtMontoRedondeo.Text = "0.00";
                txtMontoTotal.Text = "0.00";
            }
        }
        private void ObtenerTarifario()
        {
            DataTable dt = objCNControlServ.CNObtenerTarifarioFiltro((int)GiroTarifarioTipo.ComisionEnvioGiro);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    var objTarifa = new clsTarifarioGiros();
                    objTarifa.idGiroTarifario = Convert.ToInt32(item["idGiroTarifario"]);
                    objTarifa.idMoneda = Convert.ToInt32(item["idMoneda"]);
                    objTarifa.idTipoPersona = Convert.ToInt32(item["idTipoPersona"]);
                    objTarifa.idTipComGiro = Convert.ToInt32(item["idTipComGiro"]);
                    objTarifa.nMontoMinimo = Convert.ToDecimal(item["nMontoMinimo"]);
                    objTarifa.nMontoMaximo = Convert.ToDecimal(item["nMontoMaximo"]);
                    objTarifa.nMontoComision = Convert.ToDecimal(item["nMontoComision"]);
                    lstTarifario.Add(objTarifa);
                }
            }
        }
        private void HabilitarFormuario(bool lHabilitar)
        {
            btnBuscaCtaAho.Enabled = !lHabilitar;
            txtNumeroCuenta.Enabled = !lHabilitar;
            cboModalidadesPagoGiro.Enabled = !lHabilitar;
            btnBuscaCtaAho.Enabled = !lHabilitar;
            txtNumeroCuenta.Enabled = !lHabilitar;
            grbDatosRemitente.Enabled = lHabilitar;
            grbDatosGiro.Enabled = lHabilitar;
            grbDatosDestinatario.Enabled = lHabilitar;
            cboMotivoOpe.Enabled = false;
            grbDatosComplementarios.Enabled = lHabilitar;
            btnNuevo.Enabled = !lHabilitar;
            btnCancelar.Enabled = lHabilitar;
            btnGrabar.Enabled = lHabilitar;
            btnGestionContacto.Enabled = lHabilitar;
        }
        private void Limpiar()
        {
            lblNombreAgencia.Text = "";
            conBusPersonaDestinatario.Reiniciar();
            conBusPersonaRemitente.Reiniciar();
            chcIncluirComisionTotal.Checked = false;
            cboEstablecimiento.SelectedIndex = -1;
            cboMoneda.SelectedIndex = 0;
            cboModalidadesPagoGiro.SelectedIndex = 0;
            txtMontoGiro.Text = "0.00";
            txtMontoTotal.Text = "0.00";
            txtMontoComision.Text = "0.00";
            txtMontoRedondeo.Text = "0.00";
            txtITF.Text = "0.00";
            txtNumeroCuenta.Text = "";
            txtClave.Text = "";
            txtReClave.Text = "";
            conBusPersonaRemitente.Focus();
        }
        private bool ValidarFormulario()
        {
            //------------------------------------------------------------------
            // Calculo de comisión
            //------------------------------------------------------------------
            if (Convert.ToDecimal(txtMontoComision.Text) <= 0)
            {
                MessageBox.Show("No se calculo la comisión", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cboEstablecimiento.SelectedIndex < 0 || Convert.ToInt32(cboEstablecimiento.SelectedValue) <= 0)
            {
                MessageBox.Show("Debe seleccionar el destino del giro", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboEstablecimiento.Focus();
                return false;
            }
            //------------------------------------------------------------------
            // Datos remitente
            //------------------------------------------------------------------
            if (!conBusPersonaRemitente.lEncontrado)
            {
                MessageBox.Show("Debe realizar la búsqueda de la persona remitente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusPersonaRemitente.Focus();
                conBusPersonaRemitente.FocusNumeroDocumento();
                return false;
            }
            if (conBusPersonaRemitente.cNombre.Length <= 8)
            {
                MessageBox.Show("Debe ingresar el nombre del remitente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusPersonaRemitente.Focus();
                conBusPersonaRemitente.FocusNombre();
                return false;
            }
            if (conBusPersonaRemitente.cDireccion.Length <= 8)
            {
                MessageBox.Show("Debe ingresar la dirección del remitente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusPersonaRemitente.Focus();
                conBusPersonaRemitente.FocusDireccion();
                return false;
            }
            if (conBusPersonaRemitente.cCelular.Length <= 8)
            {
                MessageBox.Show("Debe ingresar el celular del remitente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusPersonaRemitente.Focus();
                conBusPersonaRemitente.FocusCelular();
                return false;
            }
            if (conBusPersonaRemitente.cCelular[0] != '9')
            {
                MessageBox.Show("El número de celular del remitente debe iniciar con 9", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusPersonaRemitente.Focus();
                conBusPersonaRemitente.FocusCelular();
                return false;
            }
            //------------------------------------------------------------------
            // Datos destinatario
            //------------------------------------------------------------------
            if (!conBusPersonaDestinatario.lEncontrado)
            {
                MessageBox.Show("Debe realizar la búsqueda de la persona destinatario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusPersonaDestinatario.Focus();
                conBusPersonaDestinatario.FocusNumeroDocumento();
                return false;
            }
            if (conBusPersonaDestinatario.cNombre.Length <= 8)
            {
                MessageBox.Show("Debe ingresar el nombre del destinatario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusPersonaDestinatario.Focus();
                conBusPersonaDestinatario.FocusNombre();
                return false;
            }
            if (conBusPersonaDestinatario.cDireccion.Length <= 8)
            {
                MessageBox.Show("Debe ingresar la dirección del destinatario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusPersonaDestinatario.Focus();
                conBusPersonaDestinatario.FocusDireccion();
                return false;
            }
            if (conBusPersonaDestinatario.cCelular.Length <= 8)
            {
                MessageBox.Show("Debe ingresar el celular del destinatario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusPersonaDestinatario.Focus();
                conBusPersonaDestinatario.FocusCelular();
                return false;
            }
            if (conBusPersonaDestinatario.cCelular[0] != '9')
            {
                MessageBox.Show("El número de celular del destinatario debe iniciar con 9", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conBusPersonaDestinatario.Focus();
                conBusPersonaDestinatario.FocusCelular();
                return false;
            }
            //------------------------------------------------------------------
            // Validar Clave
            //------------------------------------------------------------------
            if (txtClave.Text.Length != 4)
            {
                MessageBox.Show("Debe ingresar una clave de 4 caracteres", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtClave.Focus();
                return false;
            }
            if (txtClave.Text.Length != 4)
            {
                MessageBox.Show("Debe re ingresar una clave de 4 caracteres", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtReClave.Focus();
                return false;
            }
            if (txtClave.Text.ToString() != txtReClave.Text.ToString())
            {
                MessageBox.Show("Las claves no coinciden", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtClave.Text = String.Empty;
                txtReClave.Text = String.Empty;
                txtClave.Focus();
                return false;
            }
            //------------------------------------------------------------------
            // Validación de saldo en la cuenta
            //------------------------------------------------------------------
            if (Convert.ToInt32(cboModalidadesPagoGiro.SelectedValue) == 2)// en caso de 
            {
                if (_idCuentaDeposito == 0)
                {
                    MessageBox.Show("Debe seleccionar una cuenta a la cual se afectará el monto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnBuscaCtaAho.Focus();
                    return false;
                }
                if (_nMontoDisponible < Convert.ToDecimal(txtMontoTotal.Text))
                {
                    MessageBox.Show("Usted no tiene saldo suficiente para realizar este giro", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboModalidadesPagoGiro.Focus();
                    return false;
                }
            }
            return true;
        }
        private bool ValidarReglasAprob(string nMonto, string nMoneda)
        {
            /*========================================================================================
            * Validar Reglas para Operaciones de EOb´s con Aprobacion
            ========================================================================================*/

            String cCumpleReglas2 = "";
            int x_idCliente = 0;
            int idProd = 0;//Convert.ToInt16(dtCredito.Rows[0]["idProducto"]);

            if (conBusPersonaRemitente.lCliente)
            {
                x_idCliente = conBusPersonaRemitente.idCliente;
            }

            GEN.CapaNegocio.clsCNValidaReglasDinamicas ValidaReglasDinamicas2 = new GEN.CapaNegocio.clsCNValidaReglasDinamicas();
            int nNivAuto = 0;//parámetro que se usa sólo en los Niveles de Autorización
            cCumpleReglas2 = ValidaReglasDinamicas2.ValidarReglas(ArmarTablaParametros(), //dtTablaParametros
                                                                    this.Name,            //cNombreFormulario
                                                                    clsVarGlobal.nIdAgencia,//idAgencia
                                                                    x_idCliente,            //idCliente
                                                                    1,                      //idEstadoOperac
                                                                    Convert.ToInt32(nMoneda),//idMoneda
                                                                    idProd,                 //idProducto
                                                                    Decimal.Parse(nMonto),  //nValAproba
                                                                    0,                      //idDocument
                                                                    clsVarGlobal.dFecSystem,//FechaSolici
                                                                    2,                      //idMotivo
                                                                    1,                      //idEstadoSOl
                                                                    clsVarGlobal.User.idUsuario,//idUsuRegist
                                                                    ref nNivAuto);          //idSolAprob
            if (cCumpleReglas2.Equals("NoCumple"))
            {
                return false;
            }
            return true;
        }
        private DataTable ArmarTablaParametros()//Armar los parametros para validar que el usuario del Sistema no sea el mismo que pague sus cuotas
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");
            string cNroDni = this.conBusPersonaRemitente.cNumeroDocumento;
            if (cNroDni == "")
            {
                cNroDni = "0";
            }


            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUsuSistem";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUsuario";
            drfila[1] = clsVarGlobal.User.idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idAgencia";
            drfila[1] = clsVarGlobal.nIdAgencia.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEstab";
            drfila[1] = clsVarGlobal.User.idEstablecimiento.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipEstab";
            drfila[1] = clsVarGlobal.User.idTipoEstablec.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = this.conBusPersonaRemitente.idCliente;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cNroDni";
            drfila[1] = cNroDni;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoOpe";
            drfila[1] = Convert.ToString(Convert.ToDecimal(txtMontoGiro.Text));
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idNoCliRem";
            drfila[1] = Convert.ToString(Convert.ToInt32(!conBusPersonaRemitente.lCliente));
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idNoCliDes";
            drfila[1] = Convert.ToString(Convert.ToInt32(!conBusPersonaDestinatario.lCliente));
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cNroDniRem";
            drfila[1] = conBusPersonaRemitente.cNumeroDocumento;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cNroDniDes";
            drfila[1] = conBusPersonaDestinatario.cNumeroDocumento;
            dtTablaParametros.Rows.Add(drfila);


            return dtTablaParametros;
        }
        #endregion


        #region Enums
        public enum GiroTarifarioTipo
        {
            ComisionEnvioGiro = 1,
            CambioDestino = 2
        }


        #endregion

        
    }
}
