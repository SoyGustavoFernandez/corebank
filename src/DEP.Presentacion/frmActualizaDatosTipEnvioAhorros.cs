using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using DEP.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using EntityLayer;
using GEN.Funciones;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using System.Text.RegularExpressions;
using SPL.Presentacion;


namespace DEP.Presentacion
{
    public partial class frmActualizaDatosTipEnvioAhorros : frmBase
    {

        #region Variables Globales
        
        string cTitulo = "Actualizar Datos de Tipo de Envío de EE.CC. de Ahorros";
        int idCuenta = 0;
        string cTipoCuenta = "";
        string cProducto = "";
        clsCNDeposito clsDeposito = new clsCNDeposito();
        int nEditar = 0;
        
        #endregion

        #region Eventos

        public frmActualizaDatosTipEnvioAhorros()
        {
            InitializeComponent();
            DeshabilitarCampos();
            this.btnGrabar1.Enabled = false;

        }

        private void conBusCtaAho1_ClicBusCta(object sender, EventArgs e)
        {
            ObtenerCuenta();
        }

        private void frmActualizaDatosTipEnvioAhorros_Load(object sender, EventArgs e)
        {
            conBusCtaAho1.nTipOpe = 0;  //--Operación 0 muestra solo la lista de las cuentas
            conBusCtaAho1.pnIdMon = 0;  //--Para Retiro No es Necesario la MOneda, debe Listar Todas las Cuentas.
            conBusCtaAho1.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            conBusCtaAho1.txtCodAge.Focus();
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {

            this.registrarRastreo(Convert.ToInt32(this.conBusCtaAho1.txtCodCli.Text.ToString()), Convert.ToInt32(idCuenta), "Inicio - Edición de Tipo de envío de EECC", btnEditar1);

            nEditar = 1;
            HabilitarCamposEditables();
            this.btnGrabar1.Enabled = true;

            if (Convert.ToInt16(cboEnvioEstCta.SelectedValue) == 1)
            {
                this.txtDireccionEnvioEstCta.Enabled = true;
            }
            else if (Convert.ToInt16(cboEnvioEstCta.SelectedValue) == 2)
            {
                this.btnMiniEditar1.Visible = true;
            }
            
          
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            GrabarCambios();
        }
                
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            nEditar = 0;

            LimpiarCampos();
            DeshabilitarCampos();
            this.conBusCtaAho1.LimpiarControles();
        }
        
        private void cboEnvioEstCta_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Convert.ToInt16(cboEnvioEstCta.SelectedValue) == 2) //Envio por Correo
            {
                txtDireccionEnvioEstCta.KeyPress += txtDireccionEnvioEstCta_KeyPress;
                txtDireccionEnvioEstCta.Enabled = false;
                this.btnMiniEditar1.Enabled = true;

                if (nEditar == 1)
                {
                    this.btnMiniEditar1.Visible = true;
                    txtDireccionEnvioEstCta.Text = "";
                }
            
            }
            else
            {
                txtDireccionEnvioEstCta.KeyPress -= txtDireccionEnvioEstCta_KeyPress;
                txtDireccionEnvioEstCta.Text = "";
            }

            if (Convert.ToInt16(cboEnvioEstCta.SelectedValue) == 3) //Recojo en Oficina de Crac Lasa
            {
                txtDireccionEnvioEstCta.Enabled = false;
                this.btnMiniEditar1.Enabled = false;
                this.btnMiniEditar1.Visible = false;

            }
            else if (Convert.ToInt16(cboEnvioEstCta.SelectedValue) == 1)
            {
                txtDireccionEnvioEstCta.Enabled = true;
                txtDireccionEnvioEstCta.Focus();
                this.btnMiniEditar1.Enabled = false;
                this.btnMiniEditar1.Visible = false;

            }

        }
        
        private void txtDireccionEnvioEstCta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt16(cboEnvioEstCta.SelectedValue) == 2)
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }
                else if (e.KeyChar >= 48 && e.KeyChar <= 57)
                {
                    e.Handled = false;
                }
                else if (e.KeyChar >= 64 && e.KeyChar <= 90)
                {
                    e.Handled = false;
                }
                else if (e.KeyChar >= 97 && e.KeyChar <= 122)
                {
                    e.Handled = false;
                }

                else if (e.KeyChar == 45 || e.KeyChar == 95)//guion y subguion
                {
                    e.Handled = false;
                    return;
                }
                else if (e.KeyChar == 64)//arroba
                {
                    int CantArrobas = 0;

                    for (int i = 0; i < this.txtDireccionEnvioEstCta.TextLength; i++)
                    {
                        if (this.txtDireccionEnvioEstCta.Text.Substring(i, 1) == "@")
                        {
                            CantArrobas = 1;
                        }
                    }
                    if (CantArrobas == 1)
                        e.Handled = true;
                    else
                        e.Handled = false;
                }
                else if (e.KeyChar == 46)//punto
                {
                    int CantLetras = this.txtDireccionEnvioEstCta.TextLength;
                    if (CantLetras >= 1)
                    {
                        if (this.txtDireccionEnvioEstCta.Text.Substring((CantLetras - 1), 1) == ".")
                        {
                            e.Handled = true;
                        }
                        else
                            e.Handled = false;
                    }
                }

                else
                {
                    e.Handled = true;
                }
            }
        }
        
        private void btnMiniEditar1_Click(object sender, EventArgs e)
        {
            recuperarDatosCorreo();
        }

        #endregion

        #region Métodos
        private void GrabarCambios()
        {

            int idCli = Convert.ToInt32(conBusCtaAho1.txtCodCli.Text.ToString()); ;
            int idCuenta = Convert.ToInt32(conBusCtaAho1.idcuenta.ToString()); ;
            string cSustento = this.txtObservacion.Text.ToString();
            int idTipoEnvioEstCta = Convert.ToInt32(this.cboEnvioEstCta.SelectedValue.ToString());
            string cDireccionEnvioEstCta = this.txtDireccionEnvioEstCta.Text.ToString();

            int idRegistro = 0;


            if (Convert.ToInt32(cboEnvioEstCta.SelectedValue.ToString()) == 2 && (String.IsNullOrEmpty(Convert.ToString(this.txtDireccionEnvioEstCta.Text)) || String.IsNullOrWhiteSpace(Convert.ToString(this.txtDireccionEnvioEstCta.Text))))
            {
                MessageBox.Show("No puede continuar por no contar con algún correo electrónico", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToInt32(cboEnvioEstCta.SelectedValue.ToString()) == 1 && (String.IsNullOrEmpty(Convert.ToString(this.txtDireccionEnvioEstCta.Text)) || String.IsNullOrWhiteSpace(Convert.ToString(this.txtDireccionEnvioEstCta.Text))))
            {
                MessageBox.Show("No puede continuar por no escribir una dirección", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (String.IsNullOrEmpty(Convert.ToString(this.txtObservacion.Text)) || String.IsNullOrWhiteSpace(Convert.ToString(this.txtObservacion.Text)))
            {
                MessageBox.Show("No puede continuar por no escribir un sustento.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtObservacion.Focus();
                return;
            }

            if (Convert.ToInt32(cSustento.Length) < 20)
            {
                MessageBox.Show("No puede continuar por no escribir un sustento mayor a 20 caracteres.", cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtObservacion.Focus();
                return;
            }

            this.registrarRastreo(Convert.ToInt32(this.conBusCtaAho1.txtCodCli.Text.ToString()), Convert.ToInt32(idCuenta), "Proceso - Grabar cambios en Tipo de envío de EECC", btnGrabar1);

            nEditar = 0;
            DeshabilitarCampos();

            DataTable dtRegistroCambio = clsDeposito.CNRegistroCambio(idCli, idCuenta, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), cSustento, idTipoEnvioEstCta, cDireccionEnvioEstCta);

            if (Convert.ToInt32(dtRegistroCambio.Rows[0]["nIdMsj"].ToString()) == 1)
            {
                MessageBox.Show(dtRegistroCambio.Rows[0]["cMsj"].ToString(), cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                idRegistro = Convert.ToInt32(dtRegistroCambio.Rows[0]["nRegistro"].ToString());

            }
            else
            {
                MessageBox.Show(dtRegistroCambio.Rows[0]["cMsj"].ToString(), cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Imprimir(idRegistro);
            this.btnGrabar1.Enabled = false;

        }

        private void Imprimir(int idRegistro)
        {
            if (idRegistro == 0)
            {
                return;
            }
            else
            {
                MessageBox.Show("Se imprimirá el voucher de cambio de datos con el número de registro: " + idRegistro, cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

                ImprimiVoucher(idRegistro);

                while (MessageBox.Show("¿Desea reimprimir el voucher?", cTitulo,
                                                                     MessageBoxButtons.YesNo,
                                                                     MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ImprimiVoucher(idRegistro);
                }

                nEditar = 0;
                this.registrarRastreo(Convert.ToInt32(this.conBusCtaAho1.txtCodCli.Text.ToString()), Convert.ToInt32(idCuenta), "FIN - Grabar cambios en Tipo de envío de EECC", btnGrabar1);

                LimpiarCampos();
                DeshabilitarCampos();
                this.conBusCtaAho1.LimpiarControles();


            }

        }

        private void ObtenerCuenta()
        {
            idCuenta = Convert.ToInt32(conBusCtaAho1.idcuenta.ToString());

            if (idCuenta != 0)
            {
                
                DataTable dtBuscarDatos = clsDeposito.CNBuscaDatosCuenta(idCuenta);

                this.txtBase1.Text = dtBuscarDatos.Rows[0]["idCuenta"].ToString();
                this.txtBase2.Text = dtBuscarDatos.Rows[0]["cTipoCuenta"].ToString();
                this.txtBase3.Text = dtBuscarDatos.Rows[0]["cProducto"].ToString();
                this.cboEnvioEstCta.SelectedValue = Convert.ToInt32(dtBuscarDatos.Rows[0]["idTipoEnvioEstCta"].ToString());
                this.txtDireccionEnvioEstCta.Text = dtBuscarDatos.Rows[0]["cDireccionEnvioEstCta"].ToString();

            }
        
        }

        private void DeshabilitarCampos()
        {
            this.txtBase1.Enabled = false;
            this.txtBase2.Enabled = false;
            this.txtBase3.Enabled = false;
            this.cboEnvioEstCta.Enabled = false;
            this.txtDireccionEnvioEstCta.Enabled = false;
            this.btnMiniEditar1.Enabled = false;
            this.btnMiniEditar1.Visible = false;
            this.txtObservacion.Enabled = false;


        }

        private void HabilitarCamposEditables()
        {
            this.cboEnvioEstCta.Enabled = true;
            this.btnMiniEditar1.Enabled = true;
            this.txtObservacion.Enabled = true;
        }

        private void LimpiarCampos()
        {
            this.txtBase1.Text = "";
            this.txtBase2.Text = "";
            this.txtBase3.Text = "";
            this.cboEnvioEstCta.SelectedIndex = 0;
            this.txtDireccionEnvioEstCta.Text = "";
            this.txtObservacion.Text = "";
        }

        private void recuperarDatosCorreo()
        {
            DataTable dtDatosInterv = clsDeposito.CNDatosInterv(idCuenta);
            
            frmBuscarEmailAhorros frmBuscar = new frmBuscarEmailAhorros(dtDatosInterv);
            frmBuscar.ShowDialog();
            string cCorreo = frmBuscar.cCorreoAsignadoPrincipal();
            MessageBox.Show("Se ha recuperado el siguiente correo: " + cCorreo + ".", "Solicitud de Apertura de Cuentas de Ahorro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtDireccionEnvioEstCta.Text = cCorreo;
            
        }

        private string ArmarVoucherEmpresa(int idPlant, int idReg)
        {
            DataTable dtDatosVoucher = clsDeposito.CNExtraeDatosVoucher(idReg,Convert.ToString(clsVarGlobal.cNomAge.Trim()),Convert.ToString(clsVarGlobal.User.cWinUser.Trim()));

            string cPlantillaEmpresa = "";
                        
            /*========================================================================================
            * NORMAL
            ========================================================================================*/
            if (idPlant == 1)
            {
                cPlantillaEmpresa = dtDatosVoucher.Rows[0]["cPlantillaEmpresa"].ToString();
                return cPlantillaEmpresa;

            }
           
           /*========================================================================================
           * MATRICIAL
           ========================================================================================*/

            cPlantillaEmpresa = dtDatosVoucher.Rows[0]["cPlantillaEmpresaMatricial"].ToString();
            
            return cPlantillaEmpresa;


        }

        private string ArmarVoucherCliente(int idPlant, int idReg)
        {
//            DataTable dtDatosVoucher = clsDeposito.CNExtraeDatosVoucher(idReg);
            DataTable dtDatosVoucher = clsDeposito.CNExtraeDatosVoucher(idReg, Convert.ToString(clsVarGlobal.cNomAge.Trim()), Convert.ToString(clsVarGlobal.User.cWinUser.Trim()));
          
            string cPlantillaCliente = "";
            
            /*========================================================================================
            * NORMAL
            ========================================================================================*/
            if (idPlant == 1)
            {
                cPlantillaCliente = dtDatosVoucher.Rows[0]["cPlantillaCliente"].ToString();
                
                return cPlantillaCliente;

            }
            

            return cPlantillaCliente;


        }

        private void ImprimiVoucher(int idRegistro)
        {
            string cPlantillaCliente = "";
            string cPlantillaEmpresa = "";
            string cNombreEmpresa = clsVarApl.dicVarGen["cNomCortoEmp"];
            string cRUC = clsVarApl.dicVarGen["cRUC"];

            string cTipoImpresion = "   ";//idTipoImpresion == 1 ? "   " : "COPIA";

            int idTipoPlantImpresion = clsVarGlobal.idTipoPlantillaImpresion;

            cPlantillaEmpresa = ArmarVoucherEmpresa(idTipoPlantImpresion,idRegistro);

            if (idTipoPlantImpresion == 2)
            {
                cPlantillaCliente = cPlantillaEmpresa;
            }
            else
            {
                cPlantillaCliente = ArmarVoucherCliente(idTipoPlantImpresion,idRegistro);
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Add(new ReportParameter("cTextoEmpresa", cPlantillaEmpresa, false));
            paramlist.Add(new ReportParameter("cTextoCliente", cPlantillaCliente, false));
            paramlist.Add(new ReportParameter("cNombreEmpresa", cNombreEmpresa, false));
            paramlist.Add(new ReportParameter("cRUC", cRUC, false));
            paramlist.Add(new ReportParameter("cTipoImpresion", cTipoImpresion, false));
            paramlist.Add(new ReportParameter("nIdKardex", idRegistro.ToString(), false));
            string reportpath = "rptVoucher.rdlc";

            if (idTipoPlantImpresion == 2)
            {
                reportpath = "rptVoucherTicketMatricial.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
            }
            else
            {
                new frmReporteLocal(dtslist, reportpath, paramlist, false).ShowDialog();
            }


        }


        #endregion

    }
}
