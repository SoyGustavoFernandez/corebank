using CLI.Servicio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.Funciones;
using SER.CapaNegocio;
using SER.Funciones;
using System;
using System.Data;
using System.Windows.Forms;

namespace SER.Presentacion
{
    public partial class frmPagoGiroNuevo : frmBase
    {


        #region Variables
        private clsCNControlServ objCNControlServ = new clsCNControlServ();
        private DataTable dtGiros;
        private int idTipoOperacion = 14;
        private int idProducto = 126;
        private clsPagoGiro objPagoGiroSelec = new clsPagoGiro();
        private clsFunUtiles objFunTruncar = new clsFunUtiles();
        private const int idTipoOpeRegimenReforzado = 178;
        private clsBiometrico oBiometrico = new clsBiometrico();
        private clsCNSeguridad bEncryp = new clsCNSeguridad();
        #endregion


        #region Constructor
        public frmPagoGiroNuevo()
        {
            InitializeComponent();
            conBusPersonaDestinatario.lConsiderarRUC = false;
        }
        #endregion


        #region Eventos
        private void frmPagoGiroNuevo_Load(object sender, EventArgs e)
        {
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }
            this.cboMotivoOperacion.ListarMotivoOperacion(this.idTipoOperacion, clsVarGlobal.PerfilUsu.idPerfil);            
            Habilitar(false);
            chcItf.Visible = false;
        }
        private void conBusPersonaDestinatario_ehEncontrado(object sender, EventArgs e)
        {
            if (conBusPersonaDestinatario.lEncontrado)
            {
                chcItf.Enabled = true;
                conBusPersonaDestinatario.Enabled = false;
                Cargar();                
            }
            else
            {
                btnGrabar.Enabled = false;
            }

        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar(true);
            conBusPersonaDestinatario.Focus();
            conBusPersonaDestinatario.FocusNumeroDocumento();
            btnGrabar.Enabled=false;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            conBusPersonaDestinatario.Enabled = true;
            Habilitar(false);
        }
        private void dtgGiros_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                objPagoGiroSelec.idServicioGiro = Convert.ToInt32(dtGiros.Rows[e.RowIndex]["idServGiro"]);
                objPagoGiroSelec.idEstablecimientoDestinatario = Convert.ToInt32(dtGiros.Rows[e.RowIndex]["idEstablecimientoDestinatario"]);
                objPagoGiroSelec.idMoneda = Convert.ToInt32(dtGiros.Rows[e.RowIndex]["idMoneda"]);
                objPagoGiroSelec.nMontoGiro = Convert.ToDecimal(dtGiros.Rows[e.RowIndex]["nMontoGiro"]);
                objPagoGiroSelec.nMontoITF = chcItf.Checked ? new clsCalculoComision().CalcularItf(objPagoGiroSelec.nMontoGiro) : 0;
                objPagoGiroSelec.cClave = dtGiros.Rows[e.RowIndex]["bClaveGiro"].ToString();
                objPagoGiroSelec.idEstado = Convert.ToInt32(dtGiros.Rows[e.RowIndex]["idEstado"]);
                cboMoneda.SelectedValue = objPagoGiroSelec.idMoneda;
                txtMontoGiro.Text = objPagoGiroSelec.nMontoGiro.ToString("N2");

                Decimal nMonFavClie = 0.00m;
                Decimal nMontoE = 0.00m;
                nMontoE = objFunTruncar.redondearBCR(objPagoGiroSelec.nMontoGiro + objPagoGiroSelec.nMontoITF, ref nMonFavClie, objPagoGiroSelec.idMoneda, true, false);
                objPagoGiroSelec.nMontoRedondeo = nMonFavClie;
                txtMontoITF.Text = objPagoGiroSelec.nMontoITF.ToString("N2");
                txtMontoRedondeo.Text = objPagoGiroSelec.nMontoRedondeo.ToString("N2");
                objPagoGiroSelec.nMontoEntregar = objPagoGiroSelec.nMontoGiro - objPagoGiroSelec.nMontoITF + objPagoGiroSelec.nMontoRedondeo;
                txtMontoEntregar.Text = objPagoGiroSelec.nMontoEntregar.ToString("N2");
                

                conBusPersonaDestinatario.setDireccion(dtgGiros.Rows[e.RowIndex].Cells["cDireccion"].Value.ToString());
                conBusPersonaDestinatario.setCelular(dtgGiros.Rows[e.RowIndex].Cells["cCelular"].Value.ToString());
            }
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!Validar())
            {
                return;
            }
            /*========================================================================================
            * VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/
            clsValidacionPreviaOpe validaciones = new clsValidacionPreviaOpe(0, conBusPersonaDestinatario.cNumeroDocumento, clsVarGlobal.nIdAgencia, this.idTipoOperacion, 0);
            if (validaciones.verificPararOperacion())
            {
                return;
            }
            /*========================================================================================
            * FIN - VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/

            /*========================================================================================
            * Validar Regla Eob con autorizacion
            ========================================================================================*/
            if (!ValidarReglasAprob(Convert.ToString(objPagoGiroSelec.nMontoGiro), Convert.ToString(Convert.ToInt32(cboMoneda.SelectedValue.ToString()))))
            {
                //MessageBox.Show("Error, Businnes Rules aren´t aprobated");
                return;
            }
            /*========================================================================================
            * FIN -  Validar Regla Eob con autorizacion
            ========================================================================================*/


            /*========================================================================================
            * VALIDACIONES PARA REGIMEN DEL CLIENTE
            ========================================================================================*/
            clsValidacionPreviaOpe validaRegimen = new clsValidacionPreviaOpe(conBusPersonaDestinatario.idCliente,
                                                                               Convert.ToInt32(cboMoneda.SelectedValue.ToString()),
                                                                               0,
                                                                               objPagoGiroSelec.idServicioGiro,
                                                                               objPagoGiroSelec.nMontoGiro);
            if (!validaRegimen.ValidarRegimenCli(idTipoOpeRegimenReforzado))
            {
                return;
            }

            /*========================================================================================
            * VALIDACIONES BIOMETRICO
            ========================================================================================*/
            bool lValidadoBiometrico = false;
            bool lValidadoClave = false;
            #region Huellas y validación de clave
            if (clsVarGlobal.User.lAutBiometricaAgencia && conBusPersonaDestinatario.idTipoDocumento == 1)
            {
                if (!(oBiometrico.validarHuellaPagoGiro(conBusPersonaDestinatario.cNumeroDocumento, conBusPersonaDestinatario.cNombre).idRespuesta == 1))
                {
                    MessageBox.Show("No se pudo validar la huella, ingrese la clave por favor", "Validación de clave", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //===================================================================
                    //--Encriptar la Clave y Validar
                    //===================================================================

                    while (!lValidadoClave)
                    {
                        frmGiroIngresoClave objFrmGiroIngresoClave = new frmGiroIngresoClave();
                        objFrmGiroIngresoClave.ShowDialog();
                        if (objFrmGiroIngresoClave.lAceptar)
                        {
                            string cClave = bEncryp.GeneratePasswordHash(objFrmGiroIngresoClave.cClave);

                            if (objPagoGiroSelec.cClave.Trim() != cClave.Trim())
                            {
                                MessageBox.Show("La clave del giro no es correcto, por favor vuelva a ingresar", "Pago de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                DataTable dtRegistroIntento = new clsCNControlServ().RegIntenFallClave(objPagoGiroSelec.idServicioGiro, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario);

                                if (Convert.ToInt32(dtRegistroIntento.Rows[0]["nIntentos"].ToString()) >= 3)
                                {
                                    MessageBox.Show(dtRegistroIntento.Rows[0]["cMensage"].ToString(), "Registro de Pago de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    this.btnNuevo.Enabled = true;
                                    this.btnGrabar.Enabled = false;
                                    this.btnCancelar.Enabled = false;
                                    this.txtClave.Enabled = false;
                                    Cargar();
                                    return;
                                }
                            }
                            else
                            {
                                lValidadoClave = true;
                                txtClave.Text = objFrmGiroIngresoClave.cClave;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    lValidadoBiometrico = true;
                }
            }
            else
            {
                MessageBox.Show("Ingrese la clave por favor", "Validación biométrica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //===================================================================
                //--Encriptar la Clave y Validar
                //===================================================================

                while (!lValidadoClave)
                {
                    frmGiroIngresoClave objFrmGiroIngresoClave = new frmGiroIngresoClave();
                    objFrmGiroIngresoClave.ShowDialog();
                    if (objFrmGiroIngresoClave.lAceptar)
                    {
                        string cClave = bEncryp.GeneratePasswordHash(objFrmGiroIngresoClave.cClave);

                        if (objPagoGiroSelec.cClave.Trim() != cClave.Trim())
                        {
                            MessageBox.Show("La clave del giro no es correcto, por favor vuelva a ingresar", "Pago de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            DataTable dtRegistroIntento = new clsCNControlServ().RegIntenFallClave(objPagoGiroSelec.idServicioGiro, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario);

                            if (Convert.ToInt32(dtRegistroIntento.Rows[0]["nIntentos"].ToString()) >= 3)
                            {
                                MessageBox.Show(dtRegistroIntento.Rows[0]["cMensage"].ToString(), "Registro de Pago de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                Cargar();
                                return;
                            }
                        }
                        else
                        {
                            lValidadoClave = true;
                            txtClave.Text = objFrmGiroIngresoClave.cClave;
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }
            #endregion
            if (lValidadoBiometrico || lValidadoClave)
            {
                PagarGiro(lValidadoBiometrico, lValidadoClave);
            }
        }
        private void dtgGiros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (objPagoGiroSelec.idEstado == 3)
                {
                    DataTable dtSolicitudDesbl = new DataTable();
                    dtSolicitudDesbl = objCNControlServ.CNObtenerDetalleSolicitudDesbloGiro(objPagoGiroSelec.idServicioGiro);

                    if (dtSolicitudDesbl.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtSolicitudDesbl.Rows[0]["idEstadoSol"]) == 1)
                        {
                            MessageBox.Show("Este Giro tiene actualmente una solicitud de desbloqueo Pendiente.", "Bloqueo de Giro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            frmSolDesbloqGiro frmDesbloqueoGiro = new frmSolDesbloqGiro();
                            frmDesbloqueoGiro.CargarDatosGiro(objPagoGiroSelec);
                            frmDesbloqueoGiro.idEstadoSol = Convert.ToInt32(dtSolicitudDesbl.Rows[0]["idEstadoSol"]);
                            frmDesbloqueoGiro.idSolAproba = Convert.ToInt32(dtSolicitudDesbl.Rows[0]["idSolAproba"]);
                            frmDesbloqueoGiro.cMotivo = Convert.ToString(dtSolicitudDesbl.Rows[0]["cSustento"]);
                            frmDesbloqueoGiro.idProducto = idProducto;
                            frmDesbloqueoGiro.ShowDialog();
                        }
                        else if (Convert.ToInt32(dtSolicitudDesbl.Rows[0]["idEstadoSol"]) == 2)
                        {
                            DialogResult drResultado = MessageBox.Show("La Solicitud de desbloqueo de giro ha sido " + dtSolicitudDesbl.Rows[0]["cEstadoSol"].ToString() + "\n\n¿Desea Ejecutar la Solicitud de Desbloqueo de Clave?", "Bloqueo de Giro", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                            if (drResultado == DialogResult.Yes)
                            {
                                DataTable dtResultado = objCNControlServ.CNEjecutarSolDesbloqueoGiro(objPagoGiroSelec.idServicioGiro, Convert.ToInt32(dtSolicitudDesbl.Rows[0]["idSolAproba"]), clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
                                if (dtResultado.Rows.Count > 0)
                                {
                                    if (Convert.ToInt32(dtResultado.Rows[0]["nResultado"]) == 1)
                                    {
                                        MessageBox.Show("La solicitud fue ejecutada.", "Bloqueo de Giro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Cargar();
                                    }
                                    else
                                    {
                                        MessageBox.Show("El desbloqueo no se completo, Intentar Nuevamente.", "Bloqueo de Giro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                        else if (Convert.ToInt32(dtSolicitudDesbl.Rows[0]["idEstadoSol"]) == 4)
                        {
                            DialogResult drResultado = MessageBox.Show("La Solicitud de desbloqueo de giro ha sido "
                                + Convert.ToString(dtSolicitudDesbl.Rows[0]["cEstadoSol"])
                                + " debido a la Siguiente Razon: \n\n"
                                + Convert.ToString(dtSolicitudDesbl.Rows[0]["cCometario"])
                                + "\n\n ¿Desea volver a solicitar el desbloqueo?", "Bloqueo de Giro", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (drResultado == DialogResult.Yes)
                            {
                                frmSolDesbloqGiro frmDesbloqueoGiro = new frmSolDesbloqGiro();
                                frmDesbloqueoGiro.CargarDatosGiro(objPagoGiroSelec);
                                frmDesbloqueoGiro.idEstadoSol = 1;
                                frmDesbloqueoGiro.idSolAproba = 0;
                                frmDesbloqueoGiro.cMotivo = String.Empty;
                                frmDesbloqueoGiro.idProducto = idProducto;
                                frmDesbloqueoGiro.ShowDialog();
                            }
                        }
                    }
                    else
                    {

                        DialogResult drResultado = MessageBox.Show("Esta Giro esta BLOQUEADO. ¿Desea Solicitar el Desbloqueo?", "Bloqueo de Giro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (drResultado == DialogResult.Yes)
                        {
                            frmSolDesbloqGiro frmDesbloqueoGiro = new frmSolDesbloqGiro();
                            frmDesbloqueoGiro.CargarDatosGiro(objPagoGiroSelec);
                            frmDesbloqueoGiro.idEstadoSol = 1;
                            frmDesbloqueoGiro.idSolAproba = 0;

                            frmDesbloqueoGiro.ShowDialog();
                        }
                    }
                }
            }
        }
        private void chcItf_CheckedChanged(object sender, EventArgs e)
        {
            if (chcItf.Checked)
            {
                objPagoGiroSelec.nMontoITF = new clsCalculoComision().CalcularItf(objPagoGiroSelec.nMontoGiro);
                Decimal nMonFavClie = 0.00m;
                Decimal nMontoE = 0.00m;
                nMontoE = objFunTruncar.redondearBCR(objPagoGiroSelec.nMontoGiro + objPagoGiroSelec.nMontoITF, ref nMonFavClie, objPagoGiroSelec.idMoneda, true, false);
                objPagoGiroSelec.nMontoRedondeo = nMonFavClie;
                txtMontoITF.Text = objPagoGiroSelec.nMontoITF.ToString("N2");
                txtMontoRedondeo.Text = objPagoGiroSelec.nMontoRedondeo.ToString("N2");
                objPagoGiroSelec.nMontoEntregar = objPagoGiroSelec.nMontoGiro - objPagoGiroSelec.nMontoITF + objPagoGiroSelec.nMontoRedondeo;
                txtMontoEntregar.Text = objPagoGiroSelec.nMontoEntregar.ToString("N2");

            }
            else
            {
                objPagoGiroSelec.nMontoITF = 0;
                Decimal nMonFavClie = 0.00m;
                Decimal nMontoE = 0.00m;
                nMontoE = objFunTruncar.redondearBCR(objPagoGiroSelec.nMontoGiro + objPagoGiroSelec.nMontoITF, ref nMonFavClie, objPagoGiroSelec.idMoneda, true, false);
                objPagoGiroSelec.nMontoRedondeo = nMonFavClie;
                txtMontoITF.Text = objPagoGiroSelec.nMontoITF.ToString("N2");
                txtMontoRedondeo.Text = objPagoGiroSelec.nMontoRedondeo.ToString("N2");
                objPagoGiroSelec.nMontoEntregar = objPagoGiroSelec.nMontoGiro - objPagoGiroSelec.nMontoITF + objPagoGiroSelec.nMontoRedondeo;
                txtMontoEntregar.Text = objPagoGiroSelec.nMontoEntregar.ToString("N2");
            }
        }
        #endregion


        #region Metodos privados
        private void PagarGiro(bool lValidadoBiometrico, bool lValidadoClave)
        {
            //===================================================================
            //--Guardar Pago del Giro
            //===================================================================            
            if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, objPagoGiroSelec.idMoneda, 2, objPagoGiroSelec.nMontoEntregar))
            {
                this.btnNuevo.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.txtClave.Enabled = false;
                return;
            }

            #region Validacion Umbrales Dolares

            int idMotivoOpe = Convert.ToInt32(this.cboMotivoOperacion.SelectedValue);
            int idSubProducto = 126;
            int idTipoPago = 1;

            frmSustentoArchivoSplaft frmUmbDol = new frmSustentoArchivoSplaft(
                objPagoGiroSelec.nMontoEntregar,
                objPagoGiroSelec.idMoneda,
                idTipoOperacion,
                idMotivoOpe,
                idSubProducto,
                idTipoPago);
            if (!frmUmbDol.obtenerContinuaOperacion())
                return;

            #endregion

            //===================================================================
            //--Montos para el Pago del Giro
            //===================================================================            
            bool lModificaSaldoLinea = true;
            int idTipoTransac = 2; //EGRESO

            clsCNControlServ dtRegGiro = new clsCNControlServ();
            DataTable tbRegGiro = dtRegGiro.RegistrarPagoGiro(
                objPagoGiroSelec.idServicioGiro, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario,
                objPagoGiroSelec.idMoneda, clsVarGlobal.nIdAgencia, objPagoGiroSelec.nMontoGiro,
                conBusPersonaDestinatario.cNumeroDocumento, conBusPersonaDestinatario.cNombre, conBusPersonaDestinatario.cDireccion,
                this.idProducto, clsVarGlobal.idCanal, this.idTipoOperacion,
                Convert.ToInt32(this.cboMotivoOperacion.SelectedValue),
                objPagoGiroSelec.nMontoITF, objPagoGiroSelec.nMontoRedondeo, objPagoGiroSelec.nMontoEntregar,
                lModificaSaldoLinea, idTipoTransac, lValidadoBiometrico, lValidadoClave);

            if (Convert.ToInt32(tbRegGiro.Rows[0]["idRpta"].ToString()) == 0)
            {
                // RQ-412 Integracion de Saldos en Linea
                new Semaforo().ValidarSaldoSemaforo();

                MessageBox.Show(tbRegGiro.Rows[0]["cMensage"].ToString() + ", NRO DE GIRO: " + tbRegGiro.Rows[0]["idServGiro"].ToString() + ", NRO DE OPERACIÓN: " + tbRegGiro.Rows[0]["nNroOperacion"].ToString(), "Registro de Pago de Giros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //--------------------------------------IMPRIMIR VOUCHER --------------------------------------->              
                int idKardex = Convert.ToInt32(tbRegGiro.Rows[0]["nNroOperacion"]);

                //-----------------------------------------------------------------------------------------------------
                //--    REALIZA VALIDACION DE REGISTRO DE OPERACIONES ÚNICAS - SPLAFT
                //-----------------------------------------------------------------------------------------------------
                frmRegOpeSplaft regope = new frmRegOpeSplaft(idKardex, clsVarGlobal.idModulo);

                //-----------------------------------------------------------------------------------------------------
                //--  REALIZA VALIDACION DE REGISTRO DE OPERACIONES MULTIPLES - SPLAFT
                //-----------------------------------------------------------------------------------------------------
                frmRegOperacionesMultiples regOpeMult = new frmRegOperacionesMultiples(idKardex);

                ImpresionVoucher(idKardex, 9, this.idTipoOperacion, 1, objPagoGiroSelec.nMontoEntregar, 0, 0, 1);
                Limpiar();
                Habilitar(true);
                conBusPersonaDestinatario.Focus();
                conBusPersonaDestinatario.FocusNumeroDocumento();
            }
            else
            {
                MessageBox.Show(tbRegGiro.Rows[0]["cMensage"].ToString(), "Pago de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Habilitar(false);
            this.btnNuevo.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.txtClave.Enabled = false;
            chcItf.Enabled = false;
            this.btnNuevo.Focus();

            this.objFrmSemaforo.ValidarSaldoSemaforo();
        }
        private void Cargar()
        {
            dtGiros = objCNControlServ.CNListarGirosPendientes(conBusPersonaDestinatario.idTipoDocumento, conBusPersonaDestinatario.cNumeroDocumento);

            if (dtGiros.Rows.Count > 0)
            {
                dtgGiros.DataSource = dtGiros;
                FormatearDtgGiros();
                dtgGiros.Focus();
                btnGrabar.Enabled = true;
            }
            else
            {
                MessageBox.Show("La persona no tiene ningún giro pendiente a pagar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGrabar.Enabled = false;
                conBusPersonaDestinatario.Enabled = true;
                conBusPersonaDestinatario.Reiniciar();
                conBusPersonaDestinatario.Focus();
                conBusPersonaDestinatario.FocusNumeroDocumento();

            }
        }
        private void FormatearDtgGiros()
        {

            foreach (DataGridViewColumn column in dtgGiros.Columns)
            {
                column.Visible = false;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgGiros.Columns["nOrden"].Visible = true;
            dtgGiros.Columns["idServGiro"].Visible = true;
            dtgGiros.Columns["dFechaGiro"].Visible = true;
            dtgGiros.Columns["cAgenciaRemite"].Visible = true;
            dtgGiros.Columns["cRemitente"].Visible = true;
            dtgGiros.Columns["cAgenciaDestino"].Visible = true;
            dtgGiros.Columns["cMoneda"].Visible = true;
            dtgGiros.Columns["nMontoGiro"].Visible = true;
            dtgGiros.Columns["cEstado"].Visible = true;

            dtgGiros.Columns["nOrden"].HeaderText = "N°";
            dtgGiros.Columns["idServGiro"].HeaderText = "Numero de giro";
            dtgGiros.Columns["dFechaGiro"].HeaderText = "Fecha de giro";
            dtgGiros.Columns["cAgenciaRemite"].HeaderText = "Agencia remitente";
            dtgGiros.Columns["cRemitente"].HeaderText = "Remitente";
            dtgGiros.Columns["cAgenciaDestino"].HeaderText = "Agencia destino";
            dtgGiros.Columns["cMoneda"].HeaderText = "Moneda";
            dtgGiros.Columns["nMontoGiro"].HeaderText = "Monto";
            dtgGiros.Columns["cEstado"].HeaderText = "Estado";

            int nOrden = 0;
            dtgGiros.Columns["nOrden"].DisplayIndex = nOrden++;
            dtgGiros.Columns["idServGiro"].DisplayIndex = nOrden++;
            dtgGiros.Columns["dFechaGiro"].DisplayIndex = nOrden++;
            dtgGiros.Columns["cAgenciaRemite"].DisplayIndex = nOrden++;
            dtgGiros.Columns["cRemitente"].DisplayIndex = nOrden++;
            dtgGiros.Columns["cAgenciaDestino"].DisplayIndex = nOrden++;
            dtgGiros.Columns["cMoneda"].DisplayIndex = nOrden++;
            dtgGiros.Columns["nMontoGiro"].DisplayIndex = nOrden++;
            dtgGiros.Columns["cEstado"].DisplayIndex = nOrden++;

        }
        private void Habilitar(bool lHabilitar)
        {
            conBusPersonaDestinatario.Enabled = lHabilitar;
            grbDatosDestinatario.Enabled = lHabilitar;
            dtgGiros.Enabled = lHabilitar;
            grbDatosGiro.Enabled = lHabilitar;
            btnNuevo.Enabled = !lHabilitar;
            btnCancelar.Enabled = lHabilitar;
            btnGrabar.Enabled = lHabilitar;
            grbClave.Visible = false;
        }
        private void Limpiar()
        {
            dtgGiros.DataSource = new DataTable();
            conBusPersonaDestinatario.Reiniciar();
            cboMoneda.SelectedIndex = 0;
            cboMotivoOperacion.SelectedIndex = 0;
            txtMontoGiro.Text = "0.00";
            txtMontoITF.Text = "0.00";
            txtMontoRedondeo.Text = "0.00";
            txtMontoEntregar.Text = "0.00";
            txtClave.Text = "0.00";
            chcItf.Checked = false;
        }
        private bool Validar()
        {
            if (objPagoGiroSelec.idEstado == 3)
            {
                MessageBox.Show("El giro esta bloqueado no es posible realizar el pago.", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (objPagoGiroSelec.idEstablecimientoDestinatario != clsVarGlobal.User.idEstablecimiento)
            {
                MessageBox.Show("El establecimiento de destino es diferente al este establecimiento", "Registro de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
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

            x_idCliente = 0; ;


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
                                                                    objPagoGiroSelec.idServicioGiro, //idDocument
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
        private DataTable ArmarTablaParametros()
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

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
            drfila[0] = "cNroDni";
            drfila[1] = conBusPersonaDestinatario.cNumeroDocumento;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoOpe";
            drfila[1] = Convert.ToString(Convert.ToDecimal(txtMontoGiro.Text));
            dtTablaParametros.Rows.Add(drfila);


            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idNoCliRem";
            drfila[1] = Convert.ToString(1);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idNoCliDes";
            drfila[1] = Convert.ToString(0);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cNroDniRem";
            drfila[1] = conBusPersonaDestinatario.cNumeroDocumento;
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        #endregion


    }
}
