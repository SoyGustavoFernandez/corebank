using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using CLI.CapaNegocio;
using SER.CapaNegocio;
using EntityLayer;
using GEN.Funciones;

namespace SER.Presentacion
{
    public partial class frmCambioClaveEnvioGiro : frmBase
    {
        #region Variables Globales

        clsCNControlServ cncontrolserv = new clsCNControlServ();
        String cTituloMensajes = "Cambio de clave envío de giro";
        public string pcClave = String.Empty;
        int idServGiro = 0;
        int idCliRem = 0;
        int idSolAproba = 0;

        #endregion        

        public frmCambioClaveEnvioGiro()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmCambioClaveEnvioGiro_Load(object sender, EventArgs e)
        {
            cboMot.CargarMotivos(1);
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }
            //------ Preparar para uno nuevo ------------->
            LimpiarControles();
            this.cboMot.Enabled = false;
            this.btnBusGiro.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = true;
            this.txtClave.Enabled = false;
            this.txtReClave.Enabled = false;
            this.txtMotivo.Enabled = false;
            this.btnNuevo.Enabled = false;
            this.btnBusGiro.Focus();
            //------------------------------------------>
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

                if (tbGiros.Rows[0]["idEstado"].ToString().Equals("1"))
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
                    this.idCliRem                   = Convert.ToInt32(tbGiros.Rows[0]["idCliRem"].ToString());
                    this.txtNomCliRem.Text          = tbGiros.Rows[0]["cNombreRem"].ToString();
                    this.txtDniRem.Text             = tbGiros.Rows[0]["cNroDniRem"].ToString();
                    this.cboEstablecimientoRem.SelectedValue = Convert.ToInt32(tbGiros.Rows[0]["idAgeRem"].ToString());
                    this.txtDirRem.Text             = tbGiros.Rows[0]["cDirCliRem"].ToString();
                    this.txtTelefCelRem.Text = tbGiros.Rows[0]["cNumTelfRem"].ToString();
                    //Datos Beneficiario
                    this.txtNomCliBen.Text          = tbGiros.Rows[0]["cNombreDes"].ToString();
                    this.txtDniBen.Text             = tbGiros.Rows[0]["cNroDniDes"].ToString();
                    this.cboEstablecimientoGiroDes.SelectedValue= Convert.ToInt32(tbGiros.Rows[0]["idAgeDes"].ToString());
                    this.txtDirDes.Text             = tbGiros.Rows[0]["cDirCliDes"].ToString();
                    this.txtTelefCelDes.Text = tbGiros.Rows[0]["cNumTelfDes"].ToString();
                    if (string.IsNullOrEmpty(tbGiros.Rows[0]["cDirCliDes"].ToString()))
                    {
                        txtDirDes.Enabled = true;
                        txtDirDes.Focus();
                    }
                    else
                    {
                        txtDirDes.Enabled = false;
                    }

                    this.cboMoneda.SelectedValue= Convert.ToInt32(tbGiros.Rows[0]["idMoneda"].ToString());
                    this.txtMonGiro.Text        = tbGiros.Rows[0]["nMontoGiro"].ToString();
                    pcClave                     = tbGiros.Rows[0]["bClaveGiro"].ToString();                                   

                    //buscar si ya se envió una solicitud de aprobación para cambio de clave
                    DataTable SolicDuplicada = cncontrolserv.BuscarSolicitudAprobacCmbioClave(Convert.ToInt32(txtNroGiro.Text), Convert.ToDecimal(txtMonGiro.Text));
                    if (SolicDuplicada.Rows.Count > 0)
                    {
                        idSolAproba = Convert.ToInt32(SolicDuplicada.Rows[0]["idSolAproba"]);

                        cboMot.SelectedValue= Convert.ToInt32(SolicDuplicada.Rows[0]["idMotivo"]);
                        cboMot.Enabled      = false;
                        txtMotivo.Text      = SolicDuplicada.Rows[0]["cSustento"].ToString();

                        txtMotivo.Enabled   = false;
                        txtClave.Enabled    = false;
                        txtReClave.Enabled  = false;

                        lblEstSolicitud.Visible = true;
                        lblEstSolicitud.Text = "Estado de la solicitud: " + SolicDuplicada.Rows[0]["cEstadoSol"];

                        if (Convert.ToInt32(SolicDuplicada.Rows[0]["idEstadoSol"])==1)//Solicitado
                        {
                            MessageBox.Show("La solicitud de Cambio de clave ya fue Enviada por:\n \n \tUsuario:   " + SolicDuplicada.Rows[0]["cNombre"] +
                            "\n \tAgencia:   " + SolicDuplicada.Rows[0]["cNombreAge"] + "\n \tFecha:   " + Convert.ToDateTime(SolicDuplicada.Rows[0]["dFecSolici"]).ToShortDateString(), "Buscar Solicitud cambio de clave Envío de Giro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else//APROBADO
                        {
                            MessageBox.Show("La solicitud está APROBADA.", "Buscar Solicitud cambio de clave Envío de Giro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.btnNuevo.Enabled = true;                            
                        }
                        btnBusGiro.Enabled = false;
                    }
                    else
                    {
                        
                        btnBusGiro.Enabled = true;
                        habilitarControles(true);                                                
                        this.btnBusGiro.Enabled = false;
                        this.txtMotivo.Focus();
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
            if (ValidarDatos() == "ERROR") return;
            //===================================================================
            //--Encriptar la Clave
            //===================================================================
            clsCNSeguridad bEncryp = new clsCNSeguridad();
            string cClave = bEncryp.GeneratePasswordHash(this.txtClave.Text);

            int nNumGiro = Convert.ToInt32(txtNroGiro.Text);

            DataTable tbRetGiro = cncontrolserv.SolicitarCambioClaveEnvioGiro(idSolAproba, clsVarGlobal.nIdAgencia, this.idCliRem, 1, Convert.ToInt32(this.cboMoneda.SelectedValue), 0,
                                                                            Convert.ToDecimal(txtMonGiro.Text), nNumGiro, clsVarGlobal.dFecSystem,
                                                                            Convert.ToInt32(cboMot.SelectedValue), txtMotivo.Text, 1, Convert.ToDateTime("01/01/1900"),
                                                                            Convert.ToInt32(clsVarGlobal.User.idUsuario), cClave);
            if (Convert.ToInt32(tbRetGiro.Rows[0]["idSolAproba"].ToString()) != 0)
            {
                MessageBox.Show(tbRetGiro.Rows[0]["cMensaje"].ToString() + ". Nro Solicitud: " + tbRetGiro.Rows[0]["idSolAproba"].ToString(), "Cambio de clave Envío de Giro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(tbRetGiro.Rows[0]["cMensaje"].ToString(), "Cambio de clave Envío de Giro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }     
            habilitarControles(false);
            this.btnBusGiro.Enabled = false;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            idSolAproba = 0;
            LimpiarControles();        
            habilitarControles(false);
            this.btnBusGiro.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            habilitarControles(false);
            this.btnCancelar.Enabled = true;
            this.btnNuevo.Enabled = false;            
        }
        private void frmCambioClaveEnvioGiro_FormClosing(object sender, FormClosingEventArgs e)
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
            if (!String.IsNullOrEmpty(this.txtNroGiro.Text.ToString()))
            {
                cncontrolserv.DesbloquearGiro(Convert.ToInt32(this.txtNroGiro.Text), clsVarGlobal.User.idUsuario); //desbloquear el giro   
            }
            this.idServGiro = 0;
            this.txtNroGiro.Clear();
            this.txtNomCliRem.Clear();
            this.txtDniRem.Clear();
            this.cboEstablecimientoRem.SelectedValue = 0;
            this.txtDirRem.Clear();
            this.txtNomCliBen.Clear();
            this.txtDniBen.Clear();
            this.cboEstablecimientoGiroDes.SelectedValue = 0;
            this.txtDirDes.Clear();
            this.cboMoneda.SelectedValue = 1;
            this.txtMonGiro.Text = "0.00";
            this.txtClave.Clear();
            this.txtReClave.Clear();
            this.txtTelefCelRem.Clear();
            this.txtTelefCelDes.Clear();

            this.txtMotivo.Clear();
            this.lblEstSolicitud.Text = String.Empty;
            this.lblEstSolicitud.Visible = false;

            this.cboMot.SelectedIndex = -1;           
        }        

        private string ValidarDatos()
        {
            if (this.cboMot.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el motivo", "Cambio de clave Envío de Giro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cboMot.Focus();
                return "ERROR";
            }
            //=======================================================================
            //--Validar Datos del Remitente
            //=======================================================================            
            if (string.IsNullOrEmpty(this.txtNomCliRem.Text.Trim()))
            {
                MessageBox.Show("No existen datos del Cliente Remitente", "Cambio de clave Envío de Giro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return "ERROR";
            }

            //=======================================================================
            //--Validar Datos del Destinatario
            //=======================================================================
            if (string.IsNullOrEmpty(this.txtNomCliBen.Text.Trim()))
            {
                MessageBox.Show("No existen Datos del cliente Beneficiario", "Cambio de clave Envío de Giro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return "ERROR";
            }

            //=======================================================================
            //--Validar Datos del Giro
            //=======================================================================
            if (string.IsNullOrEmpty(this.txtMonGiro.Text.Trim()))
            {
                MessageBox.Show("No existe Monto del Giro", "Cambio de clave Envío de Giro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return "ERROR";
            }

            if (string.IsNullOrEmpty(txtMotivo.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar el motivo del solicitud.", "Cambio de clave Envío de Giro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return "ERROR";
            }
            if (txtMotivo.Text.Trim().Length < 6)
            {
                MessageBox.Show("El motivo debe tener más de 6 caracteres", "Cambio de clave Envío de Giro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return "ERROR";
            }

            if (string.IsNullOrEmpty(this.txtClave.Text))
            {
                MessageBox.Show("Debe ingresar la nueva clave", "Cambio de clave Envío de Giro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return "ERROR";
            }

            if (this.txtClave.Text.Length!=4)
            {
                MessageBox.Show("La clave debe ser de 4 dígitos", "Cambio de clave Envío de Giro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return "ERROR";
            }

            if (this.txtClave.Text.Trim() != this.txtReClave.Text.Trim())
            {
                MessageBox.Show("Las Claves Ingresadas no son Iguales, Por Favor vuelva a Ingresar", "Cambio de clave Envío de Giro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtClave.Clear();
                this.txtReClave.Clear();
                this.txtClave.Select();
                this.txtClave.Focus();
                return "ERROR";
            }
            
            return "OK";
        }
        
        private void habilitarControles(Boolean val)
        {
            this.txtMotivo.Enabled = val;
            this.txtClave.Enabled = val;
            this.txtReClave.Enabled = val;
            this.cboMot.Enabled = val;

            this.btnGrabar.Enabled = val;
            this.btnCancelar.Enabled = val;
            this.btnNuevo.Enabled = !val;
            this.btnBusGiro.Enabled = !val;
        }
        #endregion
    }   
}
