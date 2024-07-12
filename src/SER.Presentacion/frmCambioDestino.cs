using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using SER.CapaNegocio;
using EntityLayer;
using static SER.Presentacion.frmEnvioGiroNuevo;

namespace SER.Presentacion
{
    public partial class frmCambioDestino : frmBase
    {
        #region Variables Globales

        clsCNControlServ cncontrolserv = new clsCNControlServ();
        String cTituloMensajes = "Cambio de destino";
        int idServGiro = 0;
        int idCliRem = 0;
        int idProducto = 126;
        int idTipoOperacion = 13;
        private const int idTipoOpeRegimenReforzado = 179;
        private List<clsTarifarioGiros> lstTarifario = new List<clsTarifarioGiros>();
        #endregion

        public frmCambioDestino()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmCambioDestino_Load(object sender, EventArgs e)
        {
            this.btnNuevo.PerformClick();
            //habilita combo de motivos==========================================
            this.cboMotivoOperacion1.ListarMotivoOperacion(this.idTipoOperacion, clsVarGlobal.PerfilUsu.idPerfil);
            this.cboMotivoOperacion1.SelectedIndex = this.cboMotivoOperacion1.Items.Count - 1;
            clsCNGenVariables cnGenVar = new clsCNGenVariables();
            this.idTipoOperacion = Convert.ToInt32(cnGenVar.RetornaVariable("idTipoOpeCambioDestinoGiro", 0));
            ObtenerTarifario();
        }
        private void btnBusGiro_Click(object sender, EventArgs e)
        {
            //==================================================
            //--Llamar al Formulario
            //==================================================
            frmBusGiro frmbuscarGiro = new frmBusGiro();
            frmbuscarGiro.cOpcForm = 4;
            frmbuscarGiro.ShowDialog();

            if (frmbuscarGiro.pnGiro > 0)
            {
                clsCNControlServ ListarGiros = new clsCNControlServ();
                DataTable tbGiros = ListarGiros.ListadodeGiros(frmbuscarGiro.pnGiro, "", "", clsVarGlobal.nIdAgencia, 6);
                if (tbGiros.Rows[0]["idAgeRem"].ToString() != clsVarGlobal.nIdAgencia.ToString())
                {
                    MessageBox.Show("EL GIRO DEBE SER MODIFICADO SU DESTINO EN LA AGENCIA: " + tbGiros.Rows[0]["cNomAgeRem"].ToString(), "Buscar de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.btnBusGiro.Focus();
                    return;
                }

                if (tbGiros.Rows[0]["idEstado"].ToString() == "1")
                {
                    LimpiarControles();
                    DataTable dtBloquear = cncontrolserv.BloquearGiro(frmbuscarGiro.pnGiro, clsVarGlobal.User.idUsuario); //bloquear el giro
                    if (Convert.ToInt32(dtBloquear.Rows[0]["idResultado"].ToString()) < 1)
                    {
                        MessageBox.Show(dtBloquear.Rows[0]["cMensaje"].ToString(), this.cTituloMensajes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.btnBusGiro.Focus();
                        return;
                    }
                    this.txtNroGiro.Text = frmbuscarGiro.pnGiro.ToString();
                    this.idServGiro = frmbuscarGiro.pnGiro;
                    //Datos Remitente
                    idCliRem = Convert.ToInt32(tbGiros.Rows[0]["idCliRem"]);
                    this.txtNomCliRem.Text = tbGiros.Rows[0]["cNombreRem"].ToString();
                    this.txtDniRem.Text = tbGiros.Rows[0]["cNroDniRem"].ToString();
                    this.cboAgenciaRem.SelectedValue = Convert.ToInt32(tbGiros.Rows[0]["idAgeRem"].ToString());
                    this.txtDirRem.Text = tbGiros.Rows[0]["cDirCliRem"].ToString();
                    this.txtTelefCelRem.Text = tbGiros.Rows[0]["cNumTelfRem"].ToString();
                    //Datos Beneficiario
                    this.txtNomCliBen.Text = tbGiros.Rows[0]["cNombreDes"].ToString();
                    this.txtDniBen.Text = tbGiros.Rows[0]["cNroDniDes"].ToString();
                    this.cboAgenciaDes.SelectedValue = Convert.ToInt32(tbGiros.Rows[0]["idAgeDes"].ToString());
                    this.txtDirDes.Text = tbGiros.Rows[0]["cDirCliDes"].ToString();
                    this.txtTelefCelDes.Text = tbGiros.Rows[0]["cNumTelfDes"].ToString();
                    //Datos de Giro
                    this.cboMoneda.SelectedValue = Convert.ToInt32(tbGiros.Rows[0]["idMoneda"].ToString());
                    this.txtMonGirAnt.Text = tbGiros.Rows[0]["nMontoGiro"].ToString();
                    this.txtMonComAnt.Text = tbGiros.Rows[0]["nMonComGiro"].ToString();
                    this.cboAgeNueva.Enabled = true;
                    this.btnGrabar.Enabled = true;
                    this.btnBusGiro.Enabled = false;

                    var objTarifa = ObtenerTarifa(Convert.ToDecimal(tbGiros.Rows[0]["nMontoGiro"].ToString()),
                        Convert.ToInt32(tbGiros.Rows[0]["idMoneda"].ToString()));
                    if(objTarifa != null )
                    {
                        txtMonComGiro.Text = objTarifa.nMontoComision.ToString();
                    }
                    else
                    {
                        MessageBox.Show("No se encuentra un tarifario configurado.", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnGrabar.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("EL GIRO SE ENCUENTRA EN ESTADO " + tbGiros.Rows[0]["cNomEstado"].ToString() + ": " + tbGiros.Rows[0]["cMotivoEstado"].ToString(), "Buscar de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.btnBusGiro.Focus();
                    return;
                }

            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNroGiro.Text.Trim()))
            {
                MessageBox.Show("El Número de Giro No Existe, por Favor Verificar", "Modificar Destino de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.btnBusGiro.Focus();
                return;
            }
            if (cboAgeNueva.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el destino del giro", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgeNueva.Focus();
                return;
            }
            if (Convert.ToInt32(cboAgeNueva.SelectedValue) == Convert.ToInt32(cboAgenciaDes.SelectedValue))
            {
                MessageBox.Show("Debe seleccionar el destino del giro", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAgeNueva.Focus();
                return;
            }

            /*========================================================================================
            * VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/
            clsValidacionPreviaOpe validaciones = new clsValidacionPreviaOpe(0, this.txtDniRem.Text.Trim(), clsVarGlobal.nIdAgencia, this.idTipoOperacion, 0);
            if (validaciones.verificPararOperacion())
            {
                return;
            }
            /*========================================================================================
            * FIN - VALIDACIONES ANTES DE CONTINUAR CON LA OPERACIÓN
            ========================================================================================*/

            if (this.cboAgeNueva.SelectedIndex < 0)
            {
                MessageBox.Show("Debe Seleccionar La Agencia del Destino del Giro", "Modificar Destino de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgeNueva.Focus();
                return;
            }

            string index = this.cboAgenciaDes.SelectedValue.ToString().Trim();
            if (this.cboAgeNueva.SelectedValue.ToString() == index)
            {
                MessageBox.Show("La Agencia Nueva, Debe Ser Distinto al Actual", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboAgeNueva.SelectedValue = 0;
                this.cboAgeNueva.Focus();
                return;
            }

            //===================================================================
            //--Guardar Pago del Giro
            //===================================================================
            int idGiro = Convert.ToInt32(this.txtNroGiro.Text.ToString());
            int idAgeNue = Convert.ToInt32(this.cboAgeNueva.SelectedValue.ToString());            
            Decimal nComGiro = Convert.ToDecimal(this.txtMonComGiro.Text.ToString());

            /*========================================================================================
            * VALIDACIONES PARA REGIMEN DEL CLIENTE
            ========================================================================================*/
            clsValidacionPreviaOpe validaRegimen = new clsValidacionPreviaOpe(idCliRem,
                                                                               Convert.ToInt32(cboMoneda.SelectedValue.ToString()),
                                                                               0,
                                                                               idGiro,
                                                                              Convert.ToDecimal(txtMonComGiro.Text));
            if (!validaRegimen.ValidarRegimenCli(idTipoOpeRegimenReforzado))
            {
                return;
            }

            clsCNControlServ dtRegGiro = new clsCNControlServ();
            DataTable tbRegGiro = dtRegGiro.RegCambioDesGiro(idGiro, Convert.ToDateTime(clsVarGlobal.dFecSystem), clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, idAgeNue, Convert.ToDecimal(txtMonComGiro.Text), nComGiro, this.idProducto, clsVarGlobal.idCanal, this.idTipoOperacion, Convert.ToInt32(this.cboMotivoOperacion1.SelectedValue));

            if (Convert.ToInt32(tbRegGiro.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(tbRegGiro.Rows[0]["cMensage"].ToString() + ", NRO DE GIRO: " + tbRegGiro.Rows[0]["idServGiro"].ToString() + ", NRO DE OPERACIÓN: " + tbRegGiro.Rows[0]["nNroOperacion"].ToString(), "Modificar Destino de Giros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                desbloquearGiro();
                //--------------------------------------IMPRIMIR VOUCHER --------------------------------------->
                int idKardex = Convert.ToInt32(tbRegGiro.Rows[0]["nNroOperacion"]);
                ImpresionVoucher(idKardex, 9, 13, 1, Convert.ToDecimal(txtMonComGiro.Text), 0, 0, 1);
            }
            else
            {
                MessageBox.Show(tbRegGiro.Rows[0]["cMensage"].ToString(), "Modificar Destino de Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.btnBusGiro.Enabled = false;
            this.btnNuevo.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.cboAgeNueva.Enabled = false;
            this.btnNuevo.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            this.btnBusGiro.Enabled = true;
            this.btnNuevo.Enabled = false;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = true;
            this.cboAgeNueva.Enabled = true;
            this.btnBusGiro.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            this.btnBusGiro.Enabled = false;
            this.btnNuevo.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.cboAgeNueva.Enabled = false;
            this.btnNuevo.Focus();
        }

        private void cboAgeNueva_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAgenciaDes.SelectedValue == null || Convert.ToInt32(cboAgeNueva.SelectedValue) == 0)
            {
                return;
            }
            string index = this.cboAgenciaDes.SelectedValue.ToString().Trim();
            if (Convert.ToInt32(this.cboAgenciaDes.SelectedValue.ToString()) != 0)
            {
                if (this.cboAgeNueva.SelectedValue.ToString() == index)
                {
                    MessageBox.Show("La Agencia Nueva, Debe Ser Distinto al Actual", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.cboAgeNueva.SelectedValue = -1;
                    this.cboAgeNueva.Focus();
                    return;
                }

                if (this.cboAgeNueva.SelectedValue.ToString() == clsVarGlobal.nIdAgencia.ToString())
                {
                    MessageBox.Show("La Agencia Nueva, No Puede ser la Misma Agencia ORIGEN", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.cboAgeNueva.SelectedValue = -1;
                    this.cboAgeNueva.Focus();
                    return;
                }
            }

            int nRpta = 0;
            if (this.cboAgeNueva.SelectedIndex >= 0)
            {
                if (Convert.ToDecimal(this.txtMonGirAnt.Text) <= 0)
                {
                    MessageBox.Show("El Monto del Giro, no Puede ser Cero", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.cboAgeNueva.SelectedIndex = -1;
                    this.cboAgeNueva.Focus();
                    return;
                }

                clsCNControlServ clsSer = new clsCNControlServ();
                DataTable tbCom = clsSer.RetMonComGiro(clsVarGlobal.nIdAgencia, Convert.ToInt32(this.cboAgeNueva.SelectedValue.ToString()), Convert.ToInt32(this.cboMoneda.SelectedValue.ToString()), Convert.ToDecimal(this.txtMonGirAnt.Text), ref nRpta);
                if (nRpta == 1)
                {
                    Decimal nMonTotal = Math.Round(Convert.ToDecimal(this.txtMonGirAnt.Text), 2) + Math.Round(Convert.ToDecimal(this.txtMonComAnt.Text), 2);
                    if (tbCom.Rows[0]["idTipComGiro"].ToString() == "1")
                    {
                        this.txtMonComGiro.Text = tbCom.Rows[0]["nMontoCom"].ToString();                       
                    }
                    else
                    {
                        this.txtMonComGiro.Text=Convert.ToString(Math.Round((nMonTotal*(Convert.ToDecimal(tbCom.Rows[0]["nMontoCom"].ToString()))/100),2));                        
                        //this.txtMonGir.Text = Convert.ToString(Math.Round(nMonTotal / ((Convert.ToDecimal(tbCom.Rows[0]["nMontoCom"].ToString()) / 100) + 1), 2));
                        //this.txtMonComGiro.Text = Convert.ToString(Math.Round(nMonTotal, 2) - Math.Round(Convert.ToDecimal(this.txtMonGir.Text), 2));
                    }
                }
                else
                {
                    MessageBox.Show("No Existe Comisión Para la Agencia Seleccionada", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.cboAgeNueva.SelectedIndex = -1;
                    this.txtMonComGiro.Text = "0.00";                    
                    this.cboAgeNueva.Focus();
                }
            }
        }

        private void frmCambioDestino_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.idServGiro != 0)
            {
                cncontrolserv.DesbloquearGiro(this.idServGiro, clsVarGlobal.User.idUsuario); //desbloquear el giro
            }
        }
        #endregion

        #region Metodos

        private void LimpiarControles()
        {
            desbloquearGiro();
            this.idServGiro = 0;
            this.txtNroGiro.Clear();
            this.txtNomCliRem.Clear();
            this.txtDniRem.Clear();
            this.txtDirRem.Clear();
            this.cboAgenciaRem.SelectedValue = 0;
            this.txtNomCliBen.Clear();
            this.txtDniBen.Clear();
            this.txtDirDes.Clear();
            this.cboAgenciaDes.SelectedValue = 0;
            this.cboMoneda.SelectedValue = 1;
            this.txtMonGirAnt.Text = "0.00";
            this.txtMonComAnt.Text = "0.00";            
            this.txtMonComGiro.Text = "0.00";
            this.cboAgeNueva.SelectedValue = 0;
            this.txtTelefCelRem.Clear();
            this.txtTelefCelDes.Clear();
        }
        private void desbloquearGiro()
        {
            if (!String.IsNullOrEmpty(this.txtNroGiro.Text.ToString()))
            {
                cncontrolserv.DesbloquearGiro(Convert.ToInt32(this.txtNroGiro.Text), clsVarGlobal.User.idUsuario); //desbloquear el giro
            }
        }
        private void ObtenerTarifario()
        {
            DataTable dt = cncontrolserv.CNObtenerTarifarioFiltro((int)GiroTarifarioTipo.CambioDestino);
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
        private clsTarifarioGiros ObtenerTarifa(decimal nMonto, int idMoneda)
        {
            var result = (from item in lstTarifario
                          where idMoneda == item.idMoneda &&                          
                          nMonto >= item.nMontoMinimo &&
                          nMonto <= item.nMontoMaximo
                          select item).ToList<clsTarifarioGiros>();
            if (result.Count > 0)
                return result[0];
            else
                return null;
                
        }
        #endregion


    }
}
