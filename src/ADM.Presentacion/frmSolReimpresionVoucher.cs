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
using GEN.CapaNegocio;
using EntityLayer;
using CAJ.CapaNegocio;
using RPT.CapaNegocio;
using System.Xml.Serialization;
using GEN.Funciones;
using DEP.Presentacion;
using CAJ.Presentacion;
namespace ADM.Presentacion
{
    public partial class frmSolReimpresionVoucher : frmBase
    {
        int p_idProd = 0, p_idCli = 0,p_idTipOpe=0;
        clsCNImpresion Imprimir = new clsCNImpresion();
        private clsCreditoProp objCreditoProp;
        private clsCNAprobacion objAprobacion = new clsCNAprobacion();
        private clsCNControlOpe objValidaOpe = new clsCNControlOpe();
        bool lFlujoNormal = true;
        bool lEnviado = false;
        bool lUsuarioCesado = false;
        int idAgeOpera = clsVarGlobal.nIdAgencia;
  
        public frmSolReimpresionVoucher()
        {
            InitializeComponent();
        }

        private void frmSolReimpresionVoucher_Load(object sender, EventArgs e)
        {
            cboMotivos.CargarMotivos(7);
            nudNroOperacion.Focus();
            nudNroOperacion.Select(0, 2);
        }

        private void nudNroOperacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (string.IsNullOrEmpty(this.nudNroOperacion.Value.ToString().Trim()))
                {
                    MessageBox.Show("Ingrese el Número de Operación a Buscar", "Reimpresión de Voucher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.nudNroOperacion.Focus();
                    this.nudNroOperacion.Select(0,12);
                    return;
                }
                else
                {
                    if (Convert.ToInt32(nudNroOperacion.Value)<=0)
                    {
                        MessageBox.Show("Ingrese un Número de Operación Válido...", "Reimpresión de Voucher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.nudNroOperacion.Focus();
                        this.nudNroOperacion.Select(0,12);
                        return;
                    }
                    int idkardex = Convert.ToInt32(this.nudNroOperacion.Value.ToString().Trim());
                    this.BuscarKardex(idkardex);
                }
            }
        }

        private void BuscarKardex( int idKardex)
        {

            DataTable dtDatKardex = Imprimir.CNBuscaKardex(idKardex, 0);
            if (dtDatKardex.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dtDatKardex.Rows[0]["lExisteRegistro"]) == true)
                {
                    MessageBox.Show("Nro. de Operacion " + Convert.ToString(nudNroOperacion.Value) + ", tiene una solicitud Pendiente de APROBACIÓN: [" + Convert.ToString(dtDatKardex.Rows[0]["idSolAproba"]) + "]", "Reimpresión de Voucher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (Convert.ToBoolean(dtDatKardex.Rows[0]["lExisteImpPendi"]) == true)
                {
                    MessageBox.Show("Nro. de Operacion " + Convert.ToString(nudNroOperacion.Value) + ", tiene una solicitud Pendiente de IMPRESIÓN: [" + Convert.ToString(dtDatKardex.Rows[0]["idSolAproba_imp"]) + "]", "Reimpresión de Voucher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                if (Convert.ToInt32(dtDatKardex.Rows[0]["idAgeOpera"]) != clsVarGlobal.nIdAgencia) 
                {
                    DialogResult respMsg = MessageBox.Show("El número de operación buscado se creó en la agencia: " + Convert.ToString(dtDatKardex.Rows[0]["cNombreEstab"]) + "\n\n Desea continuar con la operación?", "Reimpresión de Voucher", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respMsg == DialogResult.No)
                    {
                        return;
                    }
                }

                this.lUsuarioCesado = Convert.ToBoolean(dtDatKardex.Rows[0]["lUsuarioCesado"]);
                this.txtEstadoOpe.Text = dtDatKardex.Rows[0]["cEstadoKardex"].ToString();
                this.txtFechaOpe.Text = Convert.ToDateTime(dtDatKardex.Rows[0]["dFechaOpe"]).ToString("dd/MM/yyyy") + " " + dtDatKardex.Rows[0]["cHoraOpe"].ToString();
                this.txtModulo.Text = dtDatKardex.Rows[0]["cModulo"].ToString();
                this.txtTipoOperacion.Text = dtDatKardex.Rows[0]["cTipoOperacion"].ToString();
                this.cboMoneda.SelectedValue = dtDatKardex.Rows[0]["idMoneda"];
                this.txtMonOpe.Text = dtDatKardex.Rows[0]["nMontoOperacion"].ToString();
                this.lblNroImpresion.Text = dtDatKardex.Rows[0]["nNumImpresion"].ToString();
                this.txtCanal.Text = dtDatKardex.Rows[0]["cCanal"].ToString();
                //idModulo = Convert.ToInt32(dtDatKardex.Rows[0]["idModulo"].ToString());
                this.nudNroOperacion.Enabled = false;
                this.cboMotivos.Enabled = true;
                this.txtMotivo.Enabled = true;
                this.cboMotivos.Focus();
                this.btnEnviar.Enabled = true;
                this.btnCancelar.Enabled = true;
                //idCuenta = Convert.ToInt32(dtDatKardex.Rows[0]["idCuenta"].ToString());
                p_idTipOpe=Convert.ToInt32(dtDatKardex.Rows[0]["idTipoOperacion"].ToString());
                if (p_idTipOpe.In(10, 11, 51, 52))
                {
                    chcSaldo.Enabled = true;
                }
                
                p_idProd = Convert.ToInt32(dtDatKardex.Rows[0]["idProducto"].ToString());
                p_idCli = Convert.ToInt32(dtDatKardex.Rows[0]["idCliAfeITF"].ToString());
                if (dtDatKardex.Rows[0]["idEstadoKardex"].ToString().Equals("2"))
                {
                    grbBase4.Enabled = false;
                    btnEnviar.Enabled = false;
                    MessageBox.Show("La operación ya fue extornada","Reimpresion de Voucher",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("No se encontro Datos del Kardex ingresado", "Reimpresión de Voucher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.nudNroOperacion.Focus();
                this.nudNroOperacion.Select(0, 12);
                return;
            }
        }

        private void grbBase4_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            cboMotivos.Enabled = false;
            txtMotivo.Enabled = false;
            btnEnviar.Enabled = false;
            grbBase4.Enabled = true;
            btnEnviar.Enabled = true;
            nudNroOperacion.Enabled = true;
            nudNroOperacion.Focus();
            nudNumeroRecibo.Enabled = false;
            btnEmitirRecibo1.Enabled = false;
            nudNroOperacion.Select(0, 2);
        }

        private void LimpiarControles()
        {
            this.nudNroOperacion.Value=0;
            this.txtEstadoOpe.Clear();
            this.txtFechaOpe.Clear();
            this.txtModulo.Clear();
            this.txtTipoOperacion.Clear();
            this.cboMoneda.SelectedValue = 1;
            this.txtMonOpe.Clear();
            this.txtMotivo.Clear();
            cboMotivos.SelectedValue = 1;
            p_idProd = 0;
            p_idCli = 0;
            p_idTipOpe = 0;
            nudNumeroRecibo.Value = 0;
        }

        private bool ValidarDatosIngresados()
        {     
            if (Convert.ToInt32(cboMotivos.SelectedIndex) == -1)
            {
                MessageBox.Show("Debe seleccionar el Motivo de reimpresión...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboMotivos.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMotivo.Text))
            {
                MessageBox.Show("Debe registrar el motivo de reimpresión del voucher...", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtMotivo.Focus();
                return false;
            }

            //EVITA QUE SE CREE SOLICITUD DE REIMPRESION A LOS TIPO DE OPERACIONES 6,7,16,44,56,63,71
            string[] cTipoOperacionNoOperacion = ((string)clsVarApl.dicVarGen["cTipoOperacionNoReimpresion"]).Split(',');

            for (int i = 0; i < cTipoOperacionNoOperacion.Length; i++)
            {
                if (p_idTipOpe == Convert.ToInt32(cTipoOperacionNoOperacion[i]))
                {
                    MessageBox.Show("No se permite crear Solicitud de Reimpresión para el Tipo de Operación: " + txtTipoOperacion.Text, "Registro de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return false;
                }
            }

            //Seleccionar solo para perfiles permitidos
            if (Convert.ToInt32(cboMotivos.SelectedValue) == Convert.ToInt32(clsVarApl.dicVarGen["cRequerimientoCliente"]))
            {
                string[] cPerfilPermitido = (clsVarApl.dicVarGen["cPerfilPagoReimpresion"]).Split(',');
                bool permitido = false;
                for (int i = 0; i < cPerfilPermitido.Length; i++)
                {
                    if (Convert.ToInt32(cPerfilPermitido[i]) == clsVarGlobal.PerfilUsu.idPerfil)
                    {
                        permitido = true;
                        break;
                    }
                }

                if (!permitido)
                {
                    MessageBox.Show("Motivo no permitido para este perfil.", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            return true;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

            if (!ValidarDatosIngresados())
            {
                return;
            }

            AprobacionAutomaticaGeneraSolicitud();

            if (lFlujoNormal)
            {
                clsCNAprobacion dtSolApr = new clsCNAprobacion();
                DataTable tbSolApr = dtSolApr.GuardarSolicitudAprobac(idAgeOpera, p_idCli, 116, 1,
                                                                    Convert.ToInt16(cboMoneda.SelectedValue), p_idProd, Convert.ToDecimal(txtMonOpe.Text),
                                                                    Convert.ToInt32(nudNroOperacion.Value), clsVarGlobal.dFecSystem, Convert.ToInt16(cboMotivos.SelectedValue),
                                                                    txtMotivo.Text, 1, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, 0, clsVarGlobal.User.idEstablecimiento, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));

                if (Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"].ToString()) != 0)
                {
                    MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString() + ", Nro. Solicitud: " + tbSolApr.Rows[0]["idSolAproba"].ToString(), "Registro de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DataTable tbSolUpd = dtSolApr.ActualizaPerfilEstablecimientoSolicitudAprobac(Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"]), clsVarGlobal.User.idEstablecimiento, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));
                }
                else
                {
                    MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                cboMotivos.Enabled = false;
                txtMotivo.Enabled = false;
                btnEnviar.Enabled = false;
        
            }
            lEnviado = true;  
        }
        private bool ValidarReciboIngresado()
        {
            if (nudNumeroRecibo.Value == 0)
            {
                MessageBox.Show("Ingrese Nro.Recibo en la sección Datos del Recibo", "Solicitud Reimpresión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nudNumeroRecibo.Focus();
                return false;
            }

            return true;
        }

        public void AprobacionAutomaticaGeneraSolicitud()
        {
            clsCNAprobacion dtSolApr = new clsCNAprobacion();
            DataTable dtConceptoPago = dtSolApr.RecuperaConceptoPago();

            int idMotivoReqCliente = Convert.ToInt32(dtConceptoPago.Rows[0]["idMotivoReqCliente"]);
            int idPagosWeb = Convert.ToInt32(dtConceptoPago.Rows[0]["idPagosWeb"]);

            //POR REQUERIMIENTO CLIENTE --O PAGO CANAL DIGITAL--
            if (cboMotivos.SelectedValue.ToString() == idMotivoReqCliente.ToString()) 
            {
                lFlujoNormal = false;
                int nidkardex = Convert.ToInt32(this.nudNroOperacion.Value.ToString().Trim());
                DataTable dtDatKardex = Imprimir.CNDevuelveOperadorKardex(nidkardex);
                int IdUsuario = Convert.ToInt32(dtDatKardex.Rows[0]["IdUsuario"]);
                string cWinUser = dtDatKardex.Rows[0]["cWinUser"].ToString();
                string dFechaOpe = dtDatKardex.Rows[0]["dFechaOpe"].ToString();

                int nNumImpresion = Convert.ToInt32(dtDatKardex.Rows[0]["nNumImpresion"]);
                string IdKardex = dtDatKardex.Rows[0]["IdKardex"].ToString();
                int idCanalKardex = Convert.ToInt32(dtDatKardex.Rows[0]["idCanal"]);

                //VERIFICA SI LA OPERACION ES DEL MISMO DIA
                if (Convert.ToDateTime(dFechaOpe) == clsVarGlobal.dFecSystem)
                {
                    //VERIFICA SI ES EL MISMO OPERADOR
                    if (IdUsuario == clsVarGlobal.User.idUsuario)
                    {
                        //VERIFICA SI ES LA PRIMERA REIMPRESION
                        if (nNumImpresion < 1)
                        {
                            //GENERA SOLICITUD Y APROBACION AUTOMATICA
                            string cFecha = clsVarGlobal.dFecSystem.ToShortDateString();
                            string cHora = DateTime.Now.ToString("hh:mm tt");
                            string cFechayhora = cFecha + " " + cHora;

                            DateTime dresultFechyHora;
                            DateTime.TryParse(cFechayhora, out dresultFechyHora);

                          
                            DataTable tbSolApr = dtSolApr.GuardarSolicitudAprobacAutomatica(clsVarGlobal.nIdAgencia, p_idCli, 116, 1,
                                                                                Convert.ToInt16(cboMoneda.SelectedValue), p_idProd, Convert.ToDecimal(txtMonOpe.Text),
                                                                                Convert.ToInt32(nudNroOperacion.Value), dresultFechyHora, Convert.ToInt32(cboMotivos.SelectedValue),
                                                                                txtMotivo.Text, 1, dresultFechyHora, clsVarGlobal.User.idUsuario, 0, clsVarGlobal.User.idEstablecimiento, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));

                            if (Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"].ToString()) != 0)
                            {
                                MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString() + ", Nro. Solicitud: " + tbSolApr.Rows[0]["idSolAproba"].ToString(), "Registro de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }

                            cboMotivos.Enabled = false;
                            txtMotivo.Enabled = false;
                            btnEnviar.Enabled = false;
                        }
                        else
                        {
                            //SI ES LA SEGUNDA REIMPRESIÓN

                            PediryValidarRecibo();
                        }
                    }
                    else
                    {
                        //SI ES OTRO OPERADOR
                        PediryValidarRecibo();
                    }
                }
                else
                {
                    string cCanalDigital = ((string)clsVarApl.dicVarGen["cCanalDigital"]);

                    // si es Canal Digital
                    if (idCanalKardex == idPagosWeb)
                    {
                        //VERIFICA SI ES LA PRIMERA REIMPRESION
                        if (nNumImpresion < 1)
                        {
                            string cFecha = clsVarGlobal.dFecSystem.ToShortDateString();
                            string cHora = DateTime.Now.ToString("hh:mm tt");
                            string cFechayhora = cFecha + " " + cHora;

                            DateTime dresultFechyHora;
                            DateTime.TryParse(cFechayhora, out dresultFechyHora);
                            //GENERA SOLICITUD Y APROBACION AUTOMATICA
                          
                            DataTable tbSolApr = dtSolApr.GuardarSolicitudAprobacAutomatica(clsVarGlobal.nIdAgencia, p_idCli, 116, 1,
                                                                                Convert.ToInt16(cboMoneda.SelectedValue), p_idProd, Convert.ToDecimal(txtMonOpe.Text),
                                                                                Convert.ToInt32(nudNroOperacion.Value), dresultFechyHora, Convert.ToInt16(cboMotivos.SelectedValue),
                                                                                txtMotivo.Text, 1, dresultFechyHora, clsVarGlobal.User.idUsuario, 0, clsVarGlobal.User.idEstablecimiento, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));

                            if (Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"].ToString()) != 0)
                            {
                                MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString() + ", Nro. Solicitud: " + tbSolApr.Rows[0]["idSolAproba"].ToString(), "Registro de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }

                            cboMotivos.Enabled = false;
                            txtMotivo.Enabled = false;
                            btnEnviar.Enabled = false;
                        }
                        else
                        {
                            //APARTIR DE LA SEGUNDA REIMPRESION COBRO 
                            PediryValidarRecibo();
                        }
                    }
                    else
                    {
                        //SI DE OTRO DIA
                        PediryValidarRecibo();
                    }
                   
                }


            }
           
        }
        public void PediryValidarRecibo()
        {
            DataTable dtMontoDuplicadoRecibo = objValidaOpe.CNDevuelveDuplicadoVoucher();
            decimal nMontoCon = Convert.ToDecimal(dtMontoDuplicadoRecibo.Rows[0]["nMontoCon"]);
            // SI TIENE MONTO A COBRAR
            if (nMontoCon > 0)
            {
                nudNumeroRecibo.Enabled = true;
                btnEmitirRecibo1.Enabled = true;
                //VERIFICA RECIBO
                if (!ValidarReciboIngresado())
                {
                    return;
                }

                ValidaReciboYNoReutilizacion_GeneraSoli(Convert.ToInt32(nudNumeroRecibo.Value));

                nudNumeroRecibo.Enabled = false;
                btnEmitirRecibo1.Enabled = false;
            }
            else
            {
                // SI NO TIENE MONTO A COBRAR
                generasolicitud();
            }
        }
        public void generasolicitud()
        {
            string cFecha = clsVarGlobal.dFecSystem.ToShortDateString();
            string cHora = DateTime.Now.ToString("hh:mm tt");
            string cFechayhora = cFecha + " " + cHora;

            DateTime dresultFechyHora;
            DateTime.TryParse(cFechayhora, out dresultFechyHora);

            clsCNAprobacion dtSolApr = new clsCNAprobacion();
            DataTable tbSolApr = dtSolApr.GuardarSolicitudAprobac(idAgeOpera, p_idCli, 116, 1,
                                                                Convert.ToInt16(cboMoneda.SelectedValue), p_idProd, Convert.ToDecimal(txtMonOpe.Text),
                                                                Convert.ToInt32(nudNroOperacion.Value), dresultFechyHora, Convert.ToInt16(cboMotivos.SelectedValue),
                                                                txtMotivo.Text, 1, dresultFechyHora, clsVarGlobal.User.idUsuario, 0, clsVarGlobal.User.idEstablecimiento, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));

            if (Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"].ToString()) != 0)
            {
                DataTable tbReciboRegistro = dtSolApr.GuardarSolicitudReciboUtilizado(Convert.ToInt32(nudNumeroRecibo.Value), Convert.ToInt32(nudNroOperacion.Value), clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"].ToString()), p_idCli, dresultFechyHora);

                MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString() + ", Nro. Solicitud: " + tbSolApr.Rows[0]["idSolAproba"].ToString(), "Registro de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataTable tbSolUpd = dtSolApr.ActualizaPerfilEstablecimientoSolicitudAprobac(Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"]), clsVarGlobal.User.idEstablecimiento, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));
            }
            else
            {
                MessageBox.Show(tbSolApr.Rows[0]["cMensaje"].ToString(), "Registrar Solicitud de Extorno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (lUsuarioCesado == true) 
            {
                MessageBox.Show("Usuario que emitió documento tiene condicion de [CESADO]. \n\n Debe ser aprobado por perfil - JEFE DE OPERACIONES.", "Solicitud Reimpresión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataTable dtDatKardex = Imprimir.CNActualizaPerfilAprUsuarioCesado(Convert.ToInt32(tbSolApr.Rows[0]["idSolAproba"].ToString()));            
            }
            cboMotivos.Enabled = false;
            txtMotivo.Enabled = false;
            btnEnviar.Enabled = false;
            nudNumeroRecibo.Enabled = false;
        
        }

        public void ValidaReciboYNoReutilizacion_GeneraSoli(int idRecibo)
        {
            DataTable dtDatRecibo = objValidaOpe.CNDevuelveExistenciayUtilRecibo(idRecibo);
            int nExisteRecibo = Convert.ToInt32(dtDatRecibo.Rows[0]["nExisteRecibo"]);
            int nUtlizadoRecibo = Convert.ToInt32(dtDatRecibo.Rows[0]["nUtlizadoRecibo"]);
            int nIdRecido = Convert.ToInt32(dtDatRecibo.Rows[0]["nIdRecibo"]);
            string cFecha = dtDatRecibo.Rows[0]["cFecha"].ToString();
            //VALIDA EXISTENCIA DEL RECIBO Y VERIFICA QUE NO PERMITA REUTILIZARSE EL RECIBO
            if (nExisteRecibo == 1 && nUtlizadoRecibo == 0)
            {
                //GENERA SOLICITUD
                generasolicitud();
               
            }
            else
            {
                MessageBox.Show("El Nro. de Recibo: " + nudNumeroRecibo.Value.ToString() + " No Existe Ó ya fue utilizado.", "Solicitud Reimpresión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnReimpresionVoucher1_Click(object sender, EventArgs e)
        {
          frmReimpresionVoucher frmobjReimpresion = new frmReimpresionVoucher();
          frmobjReimpresion.ShowDialog();

            
        }

        private void btnEmitirRecibo1_Click(object sender, EventArgs e)
        {
            DataTable dtMontoDuplicadoRecibo = objValidaOpe.CNDevuelveDuplicadoVoucher();
            int idConcepto = Convert.ToInt32(dtMontoDuplicadoRecibo.Rows[0]["idConcepto"]);

            frmEmisionRecibos frmObjEmiRecibo = new frmEmisionRecibos(idConcepto, p_idCli);
            frmObjEmiRecibo.cNroRecibo += new frmEmisionRecibos.PasarDato(ejecutardelegado);
            frmObjEmiRecibo.ShowDialog();
        }
        public void ejecutardelegado(string cNroRecibo)
        {
            nudNumeroRecibo.Value = Convert.ToInt32(cNroRecibo);
            btnEmitirRecibo1.Enabled = false;
            nudNumeroRecibo.Enabled = false;
        }

        private void cboMotivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lEnviado) 
            {
                lFlujoNormal = true;
            }
        }
   
    }
}
