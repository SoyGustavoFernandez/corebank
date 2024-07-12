using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using GEN.Funciones;
using CAJ.CapaNegocio;
using EntityLayer;
using DEP.CapaNegocio;
using Microsoft.Reporting.WinForms;
using SPL.Presentacion;

namespace DEP.Presentacion
{
    public partial class frmCompraVenta : frmBase
    {
        int idEstSol = 1;
        int idOperacion = -1;
        int idSolAproba = -1;


        int idCli = 0;
        clsFunUtiles funciones = new clsFunUtiles();
        clsCNBuscarCli BusPerson = new clsCNBuscarCli();
        DataTable dtPerson;

        public frmCompraVenta()
        {
            InitializeComponent();
        }

        private void frmCompraVenta_Load(object sender, EventArgs e)
        {
            //===========================================================================================
            //--Validar Inicio de Operaciones
            //===========================================================================================
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }
            if (!TiposDeCambio())
            {
                return;
            }
            conBusCli.txtCodCli.Enabled = false;
            conBusCli.txtNroDoc.MaxLength = 8;
            rbtVentaDolar.Checked = true;

        }

        private bool TiposDeCambio()
        {
            clsCNGenAdmOpe dtTipCam = new clsCNGenAdmOpe();
            DataTable tbTipCam = dtTipCam.RetornaTiposCambio(clsVarGlobal.dFecSystem);
            if (tbTipCam.Rows.Count > 0)
            {
                txtTipCamFij.Text = Convert.ToDecimal(tbTipCam.Rows[0]["nTipCamFij"]).ToString("0.000");
                txtTipCamCom.Text = Convert.ToDecimal(tbTipCam.Rows[0]["nTipCamCom"]).ToString("0.000");
                txtTipCamVen.Text = Convert.ToDecimal(tbTipCam.Rows[0]["nTipCamVen"]).ToString("0.000");
            }
            else
            {
                MessageBox.Show("No Existe Tipos de Cambio", "Validar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
                return false;
            }
            return true;
        }

        private string ValidarDatos()
        {

            if (String.IsNullOrEmpty(txtMonDolares.Text.ToString()) || Convert.ToDecimal (txtMonDolares.Text) <= 0)
            {
                MessageBox.Show("Debe Ingresar un Monto Válido", "Registrar Compra Venta Dólares", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtMonDolares.Focus();
                this.txtMonDolares.Select();
                return "ERROR";
            }

            if (chcCliente.Checked)
            {
                if (cboTipDocumento.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe elegir el tipo de documento", "Registrar Compra Venta Dólares", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (string.IsNullOrEmpty(txtCBNroDocumentos.Text.Trim()))
                {
                    MessageBox.Show("Debe ingresar el Nro de documento del cliente", "Registrar Compra Venta Dólares", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCBNroDocumentos.Focus();
                    txtCBNroDocumentos.SelectAll();
                    return "ERROR";
                }

                if (Convert.ToInt32(cboTipDocumento.SelectedValue) == 1 || Convert.ToInt32(cboTipDocumento.SelectedValue) == 11)
                    if (txtCBNroDocumentos.TextLength != 8)
                    {
                        MessageBox.Show("El número de DNI debe tener 8 digitos", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCBNroDocumentos.SelectAll();
                        txtCBNroDocumentos.Focus();
                        return "ERROR";
                    }


                if (Convert.ToInt32(cboTipDocumento.SelectedValue) == 4)
                {
                    if (txtCBNroDocumentos.TextLength != 11)
                    {
                        MessageBox.Show("El número de RUC debe tener 11 digitos", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCBNroDocumentos.SelectAll();
                        txtCBNroDocumentos.Focus();
                        return "ERROR";
                    }
                    else
                    {
                        if (!funciones.validarNumeroRUC(txtCBNroDocumentos.Text.Trim()))
                        {
                            MessageBox.Show("Por Favor ingresar un RUC Válido", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtCBNroDocumentos.SelectAll();
                            txtCBNroDocumentos.Focus();
                            return "ERROR";
                        }
                    }
                }
                if (Convert.ToInt32(cboTipDocumento.SelectedValue) == 3)
                    if (txtCBNroDocumentos.TextLength < 9)
                    {
                        MessageBox.Show("El número de PASAPORTE debe tener por lo menos 9 dígitos", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCBNroDocumentos.Focus();
                        txtCBNroDocumentos.SelectAll();
                        return "ERROR";
                    }           

                if (string.IsNullOrEmpty(txtNombrePerson.Text.Trim()))
                {
                    MessageBox.Show("Debe Ingresar el Nombre del Cliente", "Registrar Compra Venta Dólares", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombrePerson.Focus();
                    txtNombrePerson.Select();
                    return "ERROR";
                }

                if (string.IsNullOrEmpty(txtDireccPerson.Text.Trim()))
                {
                    MessageBox.Show("Debe Ingresar la Dirección del Cliente", "Registrar Compra Venta Dólares", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDireccPerson.Focus();
                    txtDireccPerson.Select();
                    return "ERROR";
                }
            }
            else
            {
                if (conBusCli.nidTipoPersona>1)
	            {
                    MessageBox.Show("El cliente no puede ser una persona Jurídica...Verificar", "Registrar Compra Venta Dólares", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conBusCli.txtNroDoc.Focus();
                    conBusCli.txtNroDoc.Select();
                    return "ERROR";
	            }

                if (string.IsNullOrEmpty(conBusCli.txtNroDoc.Text.Trim()))
                {
                    MessageBox.Show("Debe Ingresar el DNI del Cliente", "Registrar Compra Venta Dólares", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conBusCli.txtNroDoc.Focus();
                    conBusCli.txtNroDoc.Select();
                    return "ERROR";
                }

                if (Convert.ToInt16(conBusCli.nidTipoDocumento)==1 && Convert.ToInt16(conBusCli.nidTipoDocumento)==11)
                {
                    if (conBusCli.txtNroDoc.Text.Trim().Length != 8)
                    {
                        MessageBox.Show("El Número de DNI, Debe ser de 08 DÍGITOS, VERIFICAR", "Registrar Compra Venta Dólares", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        conBusCli.txtNroDoc.Focus();
                        conBusCli.txtNroDoc.Select();
                        return "ERROR";
                    }
                }

                if (Convert.ToInt16(conBusCli.nidTipoDocumento)==3)
                {
                    if (txtCBNroDocumentos.TextLength < 9)
                    {
                        MessageBox.Show("El número de PASAPORTE debe tener por lo menos 9 dígitos", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        conBusCli.txtNroDoc.Focus();
                        conBusCli.txtNroDoc.Select();
                        return "ERROR";
                    }   
                }

                if (string.IsNullOrEmpty(conBusCli.txtNombre.Text.Trim()))
                {
                    MessageBox.Show("Debe Ingresar el Nombre del Cliente", "Registrar Compra Venta Dólares", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conBusCli.txtNombre.Focus();
                    conBusCli.txtNombre.Select();
                    return "ERROR";
                }

                if (string.IsNullOrEmpty(conBusCli.txtDireccion.Text.Trim()))
                {
                    MessageBox.Show("Debe Ingresar la Dirección del Cliente", "Registrar Compra Venta Dólares", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conBusCli.txtDireccion.Focus();
                    conBusCli.txtDireccion.Select();
                    return "ERROR";
                }
            }


            return "OK";
        }

        private void rbtCompraDolar_CheckedChanged(object sender, EventArgs e)
        {
            txtMonDolares.Text = "0.00";
            txtMonEquiSol.Text = "0.00";
            txtMonRed.Text = "0.00";
            txtMonNeto.Text = "0.00";
            btnGrabar.Enabled = false;

            if (rbtVentaDolar.Checked)
            {
                //lblDescripcion.Text = "EL CLIENTE REALIZA LA COMPRA DE DOLARES A LA FINANCIERA";
                lblDescripcion.Text = "LA FINANCIERA VENDE DOLARES AL CLIENTE";
                lblMonto.Text = "MONTO A RECIBIR:";
                txtMonDolares.Enabled = true;
                txtMonDolares.Focus();
                txtMonDolares.Select();
                if (chcTipCamEsp.Checked)
                {
                    chcTipCamEsp_CheckedChanged(sender, e);
                }
            }

        }

        private void rbtVentaDolar_CheckedChanged(object sender, EventArgs e)
        {
            txtMonDolares.Text = "0.00";
            txtMonEquiSol.Text = "0.00";
            txtMonRed.Text = "0.00";
            txtMonNeto.Text = "0.00";
            btnGrabar.Enabled = false;
            if (rbtCompraDolar.Checked)
            {
                //lblDescripcion.Text = "EL CLIENTE VENDE DOLARES A LA FINANCIERA";
                lblDescripcion.Text = "LA FINANCIERA REALIZA LA COMPRA DE DOLARES AL CLIENTE";
                lblMonto.Text = "MONTO A ENTREGAR:";
                txtMonDolares.Enabled = true;
                txtMonDolares.Focus();
                txtMonDolares.Select();
                if (chcTipCamEsp.Checked)
                {
                    chcTipCamEsp_CheckedChanged(sender, e);
                }
            }
        }

        private void txtMonDolares_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (this.txtMonDolares.nvalor <= 0)
                {
                    MessageBox.Show("Debe Ingresar un Monto Válido", "Rigistrar Compra/Venta Dólares", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.txtMonDolares.Focus();
                    this.txtMonDolares.Select();
                    btnGrabar.Enabled = false;
                    return;
                }
                CalcularMontoConvertido();
                btnGrabar.Enabled = true;

            }
        }

        private void CalcularMontoConvertido()
        {
            Decimal nMonFavCli, nMonOpe, nMonNeto;
            nMonOpe = 0.00m;
            nMonFavCli = 0.00m;
            clsFunUtiles nRetVal = new clsFunUtiles();

            if (rbtVentaDolar.Checked) //para ambos casos siempre es a favor del cliente
            {
                lblDescripcion.Text = "LA FINANCIERA VENDE DOLARES AL CLIENTE";
                lblMonto.Text = "MONTO A RECIBIR:";
                nMonOpe = Math.Round(Convert.ToDecimal (txtMonDolares.Text) * Convert.ToDecimal (txtTipCamVen.Text), 2);
                nMonNeto = nRetVal.redondearBCR(nMonOpe, ref nMonFavCli, 1, true, true);
                txtMonEquiSol.Text = string.Format("{0:#,#0.00}", nMonOpe);
                txtMonRed.Text = string.Format("{0:#,#0.00}", nMonFavCli);
                txtMonNeto.Text = string.Format("{0:#,#0.00}", (nMonOpe - nMonFavCli));
            }
            else
            {
                lblDescripcion.Text = "LA FINANCIERA REALIZA LA COMPRA DE DOLARES AL CLIENTE";
                lblMonto.Text = "MONTO A ENTREGAR:";
                nMonOpe = Math.Round(Convert.ToDecimal (txtMonDolares.Text) * Convert.ToDecimal (txtTipCamCom.Text), 2);
                nMonNeto = nRetVal.redondearBCR(nMonOpe, ref nMonFavCli, 1, true, true);
                txtMonEquiSol.Text = string.Format("{0:#,#0.00}", nMonOpe);
                txtMonRed.Text = string.Format("{0:#,#0.00}", nMonFavCli);
                txtMonNeto.Text = string.Format("{0:#,#0.00}", (nMonOpe - nMonFavCli));
            }
        }

        private void txtMonDolares_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            idEstSol = 1;
            btnBusSolicitud.Enabled = false;
            conBusCli.Enabled = true;
            chcTipCamEsp.Enabled = true;

            chcTipCamEsp.Checked = false;
            rbtVentaDolar.Checked = true;
            rbtCompraDolar.Checked = false;
            rbtVentaDolar.Enabled = true;
            rbtCompraDolar.Enabled = true;
            txtMonDolares.Text = "0.00";
            txtMonEquiSol.Text = "0.00";
            txtMonRed.Text = "0.00";
            txtMonNeto.Text = "0.00";
            chcCliente.Checked = false;
            chcCliente.Enabled = true;
            LimpiarDatosCli();
            grbCli.Visible = false;
            conBusCli.Visible = true;
            conBusCli.btnBusCliente.Enabled = true;
            btnBusSolicitud.Enabled = true;
            btnNuevo.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = false;
            txtMonDolares.Enabled = true;
            txtMonDolares.Focus();
            txtMonDolares.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnBusSolicitud.Enabled = true;
            chcTipCamEsp.Checked = false;
            chcTipCamEsp.Enabled = false;
            rbtVentaDolar.Checked = true;
            rbtCompraDolar.Checked = false;
            txtMonDolares.Text = "0.00";
            txtMonEquiSol.Text = "0.00";
            txtMonRed.Text = "0.00";
            txtMonNeto.Text = "0.00";
            chcCliente.Checked = false;
            chcCliente.Enabled = false;
            LimpiarDatosCli();
            conBusCli.btnBusCliente.Enabled = false;
            grbCli.Visible = false;
            conBusCli.Visible = true;
            rbtVentaDolar.Enabled = false;
            rbtCompraDolar.Enabled = false;
            btnBusSolicitud.Enabled = false;
            btnNuevo.Enabled = true;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
            txtMonDolares.Enabled = false;
        }
        private bool ValidarReglasAprob(string nMonto, string nMoneda)
        {
            /*========================================================================================
            * Validar Reglas para Operaciones de EOb´s con Aprobacion
            ========================================================================================*/

            String cCumpleReglas2 = "";
            int x_idCliente = 0;
            int idProd = 0;//Convert.ToInt16(dtCredito.Rows[0]["idProducto"]);
            //x_idCliente = clsVarGlobal.User.idCli;

            if (!chcCliente.Checked)
            {
                x_idCliente = Convert.ToInt32(conBusCli.txtCodCli.Text);
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

            string cNroDni = "0";
            if (!chcCliente.Checked)
            {
                cNroDni = Convert.ToString(conBusCli.txtNroDoc.Text);
            }
            else
            {
                cNroDni = Convert.ToString(this.txtCBNroDocumentos.Text);
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
            drfila[0] = "idCli";
            drfila[1] = conBusCli.idCli.ToString();
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
            drfila[1] = "'"+cNroDni+"'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoOpe";//soles
            drfila[1] = Convert.ToString(Convert.ToDecimal(txtMonNeto.Text));
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nMontoOpeDol";
            drfila[1] = Convert.ToString(Convert.ToDecimal(txtMonDolares.Text));
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "txtTipCamCom";
            drfila[1] = Convert.ToString(Convert.ToDecimal(txtTipCamCom.Text));
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "txtTipCamVen";
            drfila[1] = Convert.ToString(Convert.ToDecimal(txtTipCamVen.Text));
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idNoCliRem";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idNoCliDes";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cNroDniRem";
            drfila[1] = "0";
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //======================================================================
            //--------Validar Datos de Entrada
            //======================================================================
            if (ValidarDatos() == "ERROR")
            {
                return;
            }
            
            /*========================================================================================
            * Validar Regla Eob con autorizacion
            ========================================================================================*/
            if (!ValidarReglasAprob(Convert.ToString(txtMonDolares.Text), Convert.ToString(2))) //Moneda validar
            {
               // MessageBox.Show("Error, Businnes Rules aren´t aprobated");
                return;
            }
            /*========================================================================================
            * FIN -  Validar Regla Eob con autorizacion
            ========================================================================================*/


            //======================================================================
            //--------Datos para Guardar Operación
            //======================================================================
            int nComVen = 0;
            Decimal nTipcam = 0.00m;
            //--Tipo de Cambio de la Operación
            if (rbtVentaDolar.Checked)
            {
                nComVen = 2;
                nTipcam = Convert.ToDecimal (txtTipCamVen.Text);
            }
            else
            {
                nComVen = 1;
                nTipcam = Convert.ToDecimal (txtTipCamCom.Text);
            }

            Decimal nMonOpe = Convert.ToDecimal (txtMonDolares.Text);
            Decimal nMonEqui = Convert.ToDecimal(txtMonEquiSol.Text);
            Decimal nMonRed = Convert.ToDecimal (txtMonRed.Text);
            Decimal nMonNeto = Convert.ToDecimal(txtMonNeto.Text);

            string cNroDoc = "";
            string cNomCli = "";
            string cDirCli = "";
            bool bTipCamEsp = chcTipCamEsp.Checked;
            int pidcli = 0;
            int idNacionalidad=0;
            int idTipDocumento=0;
            if (chcCliente.Checked)
            {
                cNroDoc = txtCBNroDocumentos.Text;
                cNomCli = txtNombrePerson.Text;
                cDirCli = txtDireccPerson.Text;
                pidcli = idCli;
                idNacionalidad = rbtCompraDolar.Checked == true ? 1 : 2;
                idTipDocumento = Convert.ToInt32(cboTipDocumento.SelectedValue);
            }
            else
            {
                cNroDoc = conBusCli.txtNroDoc.Text.Trim();
                cNomCli = conBusCli.txtNombre.Text.Trim();
                cDirCli = conBusCli.txtDireccion.Text.Trim();
                pidcli = Convert.ToInt32(conBusCli.txtCodCli.Text);
                idTipDocumento = Convert.ToInt32(conBusCli.nidTipoDocumento);
            }

            //-------------------------------------------------------------
            //VALIDA CLIENTE PEP
            //-------------------------------------------------------------
            if (!chcCliente.Checked)
            {            
                string mensaje = "",
                        x_cNroDni = "";
                int x_idEstApr = 0;               

                if (!conSplaf1.ValidaAprobacionClientePep(conBusCli.idCli, ref mensaje, ref x_cNroDni, ref x_idEstApr))
                {
                    MessageBox.Show(mensaje, "Validar cliente PEP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (x_idEstApr == 1) //--Solicitado
                    {
                        frmPep frmPepx = new frmPep(idTipDocumento,x_cNroDni);
                        frmPepx.ShowDialog();
                    }
                    return;
                }
            }

            //--==========================================================================================
            //-- validar monitoreo
            //--==========================================================================================
            if (rbtVentaDolar.Checked) // COMPRA DE DOLARES POR CLIENTE = VENTA DE DOLARES POR LA ENTIDAD
            {
                //--CUANDO SALE (EGRESA) DOLARES DE LA VENTANILLA
                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, 2, 2, nMonOpe))
                {
                    return;
                }
                //--CUANDO INGRESA SOLES DE LA VENTANILLA
                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, 1, 1, nMonNeto))
                {
                    return;
                }
            }
            else  // VENTA DE DOLARES POR CLIENTE = COMPRA DE DOLARES POR LA ENTIDAD
            {
                //--CUANDO INGRESA DOLARES DE LA VENTANILLA
                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, 2, 1, nMonOpe))
                {
                    return;
                }
                //--CUANDO SALE(EGRESA) SOLES DE LA VENTANILLA
                if (ValidaSaldoLinea(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, 1, 2, nMonNeto))
                {
                    return;
                }
            }
            //--Fin Monitoreo

            #region Validacion Umbrales Dolares
            
            decimal nMontoTotPago = nMonOpe  ;
            int idMonedaUm = 2;
            int idMotivoOpe = 0;
            int idSubProducto = 125;
            int idTipoOperacion = (rbtVentaDolar.Checked) ? 21 : 20;
            int idTipoPago = 1;

            GEN.ControlesBase.frmSustentoArchivoSplaft frmUmbDol = new GEN.ControlesBase.frmSustentoArchivoSplaft(nMontoTotPago, idMonedaUm, idTipoOperacion, idMotivoOpe, idSubProducto, idTipoPago);
            if (!frmUmbDol.obtenerContinuaOperacion())
                return;
            
            #endregion

            //======================================================================
            //--------Guardar COMPRA Y VENTA
            //======================================================================
            int idkardex = 0,
                idKardexRel = 0;
            clsCNCompraVenta dtComVen = new clsCNCompraVenta();

            bool lModificaSaldoLinea = true;

            DataTable tbComVen = dtComVen.CNRegCompraVenta(clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, nComVen, nMonOpe, nTipcam, nMonEqui, nMonRed, nMonNeto, cNroDoc, cNomCli, cDirCli, bTipCamEsp, idEstSol, idOperacion, idSolAproba, pidcli, idNacionalidad, idTipDocumento, lModificaSaldoLinea);

            if (Convert.ToInt32(tbComVen.Rows[0]["idRpta"].ToString()) == 2)
            {
                MessageBox.Show(tbComVen.Rows[0]["cMensage"].ToString(), "Registrar Operación de Compra Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rbtVentaDolar.Enabled = false;
                rbtCompraDolar.Enabled = false;
                txtMonDolares.Enabled = false;
                chcCliente.Enabled = false;
                DesHabCtrlCli();
                btnNuevo.Enabled = true;
                btnCancelar.Enabled = false;
                btnGrabar.Enabled = false;
                chcTipCamEsp.Enabled = false;
                txtTipCamVen.Enabled = false;
                txtTipCamCom.Enabled = false;
                return;
            }   

            if (Convert.ToInt32(tbComVen.Rows[0]["idRpta"].ToString()) == 0)
            {
                // RQ-412 Integracion de Saldos en Linea
                new Semaforo().ValidarSaldoSemaforo();
                
                //--Fin Monitoreo

                MessageBox.Show(tbComVen.Rows[0]["cMensage"].ToString(), "Registrar operación de compra venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                idkardex        = Convert.ToInt32(tbComVen.Rows[0]["nNumOperacion"].ToString());
                idKardexRel     = Convert.ToInt32(tbComVen.Rows[0]["idKardexOp"].ToString());
                //-----------------------------------------------------------------------------------------------------
                //--    REALIZA VALIDACION DE REGISTRO DE OPERACIONES ÚNICAS - SPLAFT
                //-----------------------------------------------------------------------------------------------------
                frmRegOpeSplaft regope = new frmRegOpeSplaft(idKardexRel, clsVarGlobal.idModulo);

                //-----------------------------------------------------------------------------------------------------
                //--  REALIZA VALIDACION DE REGISTRO DE OPERACIONES MULTIPLES - SPLAFT
                //-----------------------------------------------------------------------------------------------------
                frmRegOperacionesMultiples regOpeMult = new frmRegOperacionesMultiples(idKardexRel);

                //---Imprimir Voucher
                ImpresionVoucher(idKardexRel, 9, 0, 1, Convert.ToDecimal(nMonOpe), Convert.ToDecimal(0.0), 0, 1);
            }
            else
            {
                MessageBox.Show(tbComVen.Rows[0]["cMensage"].ToString(), "Registrar operación de compra venta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMonDolares.Focus();
                return;
            }

            rbtCompraDolar.Enabled = false;
            rbtVentaDolar.Enabled = false;
            txtMonDolares.Enabled = false;
            chcCliente.Enabled = false;
            chcTipCamEsp.Enabled = false;
            DesHabCtrlCli();
            btnNuevo.Enabled = true;
            btnBusSolicitud.Enabled = false;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
            grbBase6.Enabled = false;
            grbxDatosNoCliente.Enabled = false;
        }

        private void DesHabCtrlCli()
        {
            conBusCli.txtCodCli.Enabled = false;
            conBusCli.txtNroDoc.Enabled = false;
            conBusCli.txtNombre.Enabled = false;
            conBusCli.btnBusCliente.Enabled = false;
            conBusCli.btnBusCliente.Enabled = false;

            txtCBNroDocumentos.Enabled = false;
            txtNombrePerson.Enabled = false;
            txtDireccPerson.Enabled = false;
        }

        private void LimpiarDatosCli()
        {
            conBusCli.txtCodInst.Text = "";
            conBusCli.txtCodAge.Text = "";
            conBusCli.txtCodCli.Text = "";
            conBusCli.txtNroDoc.Text = "";
            conBusCli.txtNombre.Text = "";
            conBusCli.txtDireccion.Text = "";

            txtCBNroDocumentos.Text = "";
            txtNombrePerson.Text = "";
            txtDireccPerson.Text = "";
        }
        //private void EmitirVoucher(int idKardex, DataTable dtOperacion)
        //{
        //    List<ReportParameter> paramlist = new List<ReportParameter>();
        //    paramlist.Clear();
        //    paramlist.Add(new ReportParameter("idKardex", idKardex.ToString(), false));

        //    List<ReportDataSource> dtslist = new List<ReportDataSource>();
        //    dtslist.Clear();
        //    dtslist.Add(new ReportDataSource("dtsOper", dtOperacion));

        //    //  List<ReportParameter> paramlist = new List<ReportParameter>();
        //    string reportpath = "rptVoucherOpeDol.rdlc";
        //    new frmReporteLocal(dtslist, reportpath, paramlist, true).ShowDialog();
        //}
        private void chcCliente_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarDatosCli();
            txtCBNroDocumentos.Enabled = false;
            conBusCli.btnBusCliente.Enabled = false;
            
            if (chcCliente.Checked)
            {
                conBusCli.Visible = false;
                grbCli.Visible = true;
                txtCBNroDocumentos.Enabled = true;
                //txtCBNroDocumentos.Focus();
                rbtNacionPer.Checked = true;
                grbxDatosNoCliente.Enabled = true;
                grbBase6.Enabled = true;

            }
            else
            {
                conBusCli.Visible = true;
                grbCli.Visible = false;
                conBusCli.btnBusCliente.Enabled = true;
                conBusCli.btnBusCliente.Focus();
            }
        }

        private void txtMonDolares_Leave(object sender, EventArgs e)
        {
            if (this.txtMonDolares.nvalor <= 0)
            {
                btnGrabar.Enabled = false;
                return;
            }
            CalcularMontoConvertido();
            btnGrabar.Enabled = true;
        }

        private void chcTipCamEsp_CheckedChanged(object sender, EventArgs e)
        {
            if (chcTipCamEsp.Checked)
            {
                if (rbtVentaDolar.Checked)
                {
                    txtTipCamVen.Enabled = true;
                    txtTipCamCom.Enabled = false;
                    TiposDeCambio();
                    txtMonDolares_Leave(sender, e);
                }
                if (rbtCompraDolar.Checked)
                {
                    txtTipCamCom.Enabled = true;
                    txtTipCamVen.Enabled = false;
                    TiposDeCambio();
                    txtMonDolares_Leave(sender, e);
                }
            }
            else
            {
                txtTipCamCom.Enabled = false;
                txtTipCamVen.Enabled = false;
                TiposDeCambio();
                txtMonDolares_Leave(sender, e);
            }
        }

        private void txtTipCamCom_Leave(object sender, EventArgs e)
        {
            txtMonDolares_Leave(sender, e);
        }

        private void txtTipCamVen_Leave(object sender, EventArgs e)
        {
            txtMonDolares_Leave(sender, e);
        }

        private void btnBusSolicitud_Click(object sender, EventArgs e)
        {
            frmBuscaSolCompraVenta frmBusSolComVen = new frmBuscaSolCompraVenta();
            frmBusSolComVen.ShowDialog();

            if (frmBusSolComVen.pnComVen == -1)
            {
                return;
            }
            else
            {
                idEstSol = frmBusSolComVen.pidEstadoSol;
                idOperacion = frmBusSolComVen.pidOperacion;
                idSolAproba = frmBusSolComVen.pidSolAproba;

                txtMonDolares.Text = frmBusSolComVen.pnMonOpe.ToString();

                txtMonDolares.Enabled = false;
                chcTipCamEsp.Enabled = false;
                conBusCli.Enabled = false;
                chcCliente.Enabled = false;
                btnNuevo.Enabled = false;
                btnCancelar.Enabled = true;
                btnGrabar.Enabled = true;

                rbtVentaDolar.CheckedChanged -= new EventHandler(rbtCompraDolar_CheckedChanged);
                rbtCompraDolar.CheckedChanged -= new EventHandler(rbtVentaDolar_CheckedChanged);
                if (frmBusSolComVen.pnComVen == 1)
                {
                    rbtVentaDolar.Checked = false;
                    rbtCompraDolar.Checked = true;
                    rbtCompraDolar.Enabled = false;
                    lblDescripcion.Text = "LA FINANCIERA REALIZA LA COMPRA DE DOLARES AL CLIENTE";
                    txtTipCamCom.Text = frmBusSolComVen.pnTipcam.ToString();
                }
                else
                {

                    rbtVentaDolar.Checked = true;
                    rbtVentaDolar.Enabled = false;
                    rbtCompraDolar.Checked = false;
                    lblDescripcion.Text = "LA FINANCIERA VENDE DOLARES AL CLIENTE";                    
                    txtTipCamVen.Text = frmBusSolComVen.pnTipcam.ToString();
                }
                rbtVentaDolar.CheckedChanged += new EventHandler(rbtCompraDolar_CheckedChanged);
                rbtCompraDolar.CheckedChanged += new EventHandler(rbtVentaDolar_CheckedChanged);
                chcTipCamEsp.CheckedChanged -= new EventHandler(chcTipCamEsp_CheckedChanged);
                chcTipCamEsp.Checked = frmBusSolComVen.pbTipCamEsp;
                chcTipCamEsp.CheckedChanged += new EventHandler(chcTipCamEsp_CheckedChanged);

                txtMonRed.Text = frmBusSolComVen.pnMonRed.ToString();
                txtMonNeto.Text = frmBusSolComVen.pnMonNeto.ToString();
                txtMonEquiSol.Text = frmBusSolComVen.pnMonEqui.ToString();

                if (!frmBusSolComVen.pcIdCli.Equals("0"))
                {
                    chcCliente.Checked = false;
                    conBusCli.txtCodInst.Text = frmBusSolComVen.pcIdCli.ToString().Substring(0, 3);
                    conBusCli.txtCodAge.Text = frmBusSolComVen.pcIdCli.ToString().Substring(3, 3);
                    conBusCli.txtCodCli.Text = frmBusSolComVen.pcIdCli.ToString().Substring(6);

                    conBusCli.txtNroDoc.Text = frmBusSolComVen.pcNroDoc;
                    conBusCli.txtNombre.Text = frmBusSolComVen.pcNomCli;
                    conBusCli.txtDireccion.Text = frmBusSolComVen.pcDirCli;
                    
                }
                else
                {
                    chcCliente.Checked = true;
                    grbCli.Enabled = false;
                    rbtNacionPer.Checked = frmBusSolComVen.pidNacionalidad == 1 ? true : false ;
                    rbtNacionExt.Checked = frmBusSolComVen.pidNacionalidad == 2? true : false ;
                    cboTipDocumento.SelectedValue = frmBusSolComVen.pidTipDocumento;
                    txtCBNroDocumentos.Text=frmBusSolComVen.pcNroDoc;
                    txtNombrePerson.Text=frmBusSolComVen.pcNomCli;
                    txtDireccPerson.Text = frmBusSolComVen.pcDirCli;

                }
               
            }
        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            if (conBusCli.nidTipoPersona >= 2)
            {
                MessageBox.Show("Compra/Venta, NO puede realizar una Persona Jurídica", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conBusCli.txtCodInst.Text = "";
                conBusCli.txtCodAge.Text = "";
                conBusCli.txtCodCli.Text = "";
                conBusCli.txtNroDoc.Text = "";
                conBusCli.txtNombre.Text = "";
                conBusCli.txtDireccion.Text = "";
                return;
            }
        }

        private void RdBtnNacionPer_CheckedChanged(object sender, EventArgs e)
        {

            this.cboTipDocumento.CargarDocumentos("N");
            cboTipDocumento.SelectedIndex = -1;
            txtCBNroDocumentos.Clear();
            txtNombrePerson.Clear();
            txtDireccPerson.Clear();

        }

        private void RdBtnNacionExt_CheckedChanged(object sender, EventArgs e)
        {
            this.cboTipDocumento.CargarDocumentos("E");
            cboTipDocumento.SelectedIndex = -1;
            txtCBNroDocumentos.Clear();
            txtNombrePerson.Clear();
            txtDireccPerson.Clear();
        }

        private void cboTipDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCBNroDocumentos.ValidarTipoDoc(Convert.ToString(this.cboTipDocumento.SelectedValue));
        }

        public void BusPerByDocIde()
        {
            var cDocumento = this.txtCBNroDocumentos.Text.Trim();

            if (cDocumento.Length >= 8)
            {
                dtPerson = BusPerson.ListarClientes("1", txtCBNroDocumentos.Text);

                if (dtPerson.Rows.Count > 0)
                {
                    txtNombrePerson.Text = Convert.ToString(dtPerson.Rows[0]["cNombre"]);
                    txtDireccPerson.Text = Convert.ToString(dtPerson.Rows[0]["cDireccion"]);
                    idCli = Convert.ToInt32(dtPerson.Rows[0]["idCli"]);
                    txtNombrePerson.Enabled = false;
                    txtDireccPerson.Enabled = false;
                }
                else
                {
                    idCli = 0;
                    txtNombrePerson.Enabled = true;
                    txtDireccPerson.Enabled = true;
                    txtNombrePerson.Clear();
                    txtDireccPerson.Clear();
                }
            }
        }

        private void txtCBNroDocumentos_Validating(object sender, CancelEventArgs e)
        {
        }

        private void txtCBNroDocumentos_TextChanged(object sender, EventArgs e)
        {
            if (txtCBNroDocumentos.Text != "")
            {
                if (Convert.ToInt32(cboTipDocumento.SelectedValue) == 1 || Convert.ToInt32(cboTipDocumento.SelectedValue) == 11)
                    if (txtCBNroDocumentos.TextLength == 8)
                    {
                        BusPerByDocIde();
                        return;
                    }
                    else
                    {
                        idCli = 0;
                        txtNombrePerson.Enabled = false;
                        txtDireccPerson.Enabled = false;
                        txtNombrePerson.Clear();
                        txtDireccPerson.Clear();
                    }

                if (Convert.ToInt32(cboTipDocumento.SelectedValue) == 4)
                {
                    if (txtCBNroDocumentos.TextLength == 11)
                    {
                        if (!funciones.validarNumeroRUC(txtCBNroDocumentos.Text.Trim()))
                        {
                            MessageBox.Show("Por Favor ingresar un RUC Válido", "Registro de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtCBNroDocumentos.SelectAll();
                            txtCBNroDocumentos.Focus();
                            return;
                        }
                        BusPerByDocIde();
                    }
                    else
                    {
                        idCli = 0;
                        txtNombrePerson.Enabled = false;
                        txtDireccPerson.Enabled = false;
                        txtNombrePerson.Clear();
                        txtDireccPerson.Clear();
                    }

                }
                if (Convert.ToInt32(cboTipDocumento.SelectedValue) == 3 || Convert.ToInt32(cboTipDocumento.SelectedValue) == 2 || Convert.ToInt32(cboTipDocumento.SelectedValue) == 14)
                    if (txtCBNroDocumentos.TextLength >= 9)
                    {
                        BusPerByDocIde();
                        return;
                    }
                    else
                    {
                        idCli = 0;
                        txtNombrePerson.Enabled = false;
                        txtDireccPerson.Enabled = false;
                        txtNombrePerson.Clear();
                        txtDireccPerson.Clear();
                    }
            }
            else
            {
                idCli = 0;
                txtNombrePerson.Enabled = false;
                txtDireccPerson.Enabled = false;
                txtNombrePerson.Clear();
                txtDireccPerson.Clear();
            }
        }

        private void conBusCli_ChangeDocumentoID(object sender, EventArgs e)
        {
            if (this.conBusCli.txtNroDoc.Text.Length < 6)
            {
                return;
            }

            int idRes = Convert.ToInt32(clsVarApl.dicVarGen["lAlertaOfertaCredito"]);
            bool lAlerta = Convert.ToBoolean(idRes);
            if (lAlerta)
            {
                frmAlertaOfertaCredito objAlertaOferta = new frmAlertaOfertaCredito(this.conBusCli.txtNroDoc.Text);
            }
        }
    }
}
