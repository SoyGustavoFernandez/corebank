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
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.Funciones;

namespace DEP.Presentacion
{
    public partial class frmControlCertificadosxCta : frmBase
    {
        private int p_idCta = 0, idTipOpe;

        clsCNDeposito clsDeposito = new clsCNDeposito();
        clsCNImpresion clsImpresion = new clsCNImpresion();
        clsCNValorados objValorados = new clsCNValorados();

        public frmControlCertificadosxCta()
        {
            InitializeComponent();
        }

        private void frmControlCertificadosxCta_Load(object sender, EventArgs e)
        {
            idTipOpe = 16;
            conBusCtaAho.nTipOpe = idTipOpe;
            conBusCtaAho.pnIdMon = 0;  //Para Cancelación no es necesario la moneda, debe listar todas las Cuentas.
            conBusCtaAho.txtCodIns.Text = clsVarApl.dicVarGen["cCodInstFin"];
            conBusCtaAho.idcuenta = 0;
            conBusCtaAho.Focus();
            conBusCtaAho.txtCodAge.Focus();
        }

        private void conBusCtaAho_ClicBusCta(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(conBusCtaAho.txtNroCta.Text) && conBusCtaAho.idcuenta > 0)
            {

                p_idCta = Convert.ToInt32(conBusCtaAho.idcuenta);
                if (Convert.ToInt32(p_idCta) > 0)
                {
                    this.DatosCuenta();

                }
            }
            else
            {
                this.conBusCtaAho.txtCodAge.Focus();
            }
        }

        private void DatosCuenta()
        {
            txtCodCertificado.Text = "";
            txtNroFolio.Text = "";
            //--===================================================================================
            //--Cargar Datos de la Cuenta
            //--===================================================================================
            DataTable dtbNumCuentas = clsDeposito.CNRetornaDatosCuenta(p_idCta, "1", idTipOpe);
            if (dtbNumCuentas.Rows.Count > 0)
            {
                //--==================================================================================
                //--Se debe Definir si se va Imprimir la Constancia o No
                //--==================================================================================
                bool lIsRequeCert = Convert.ToBoolean(dtbNumCuentas.Rows[0]["lIsRequeCert"]);
                if (!lIsRequeCert)
                {
                    MessageBox.Show("El producto no Requiere Certificado de Plazo Fijo...Verificar", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarControles();
                    conBusCtaAho.LimpiarControles();
                    this.conBusCtaAho.txtCodAge.Focus();
                    return;
                }

                //--==================================================================================
                //--Datos generales de la Cuenta
                //--==================================================================================
                this.txtProducto.Text = dtbNumCuentas.Rows[0]["cProducto"].ToString();
                this.cboMoneda.SelectedValue = dtbNumCuentas.Rows[0]["idMoneda"].ToString();
                this.cboTipoCuenta.SelectedValue = dtbNumCuentas.Rows[0]["idTipoCuenta"].ToString();
                this.dtpFecApe.Value = Convert.ToDateTime(dtbNumCuentas.Rows[0]["dFechaApertura"]);                
                
                int lVal = 0;
                //--==================================================================================
                //--Validar si ya Tiene Certificado
                //--==================================================================================
                if (Convert.ToInt32(dtbNumCuentas.Rows[0]["nNumeCertificado"]) > 0)
                {
                    txtCodCertificado.Text = dtbNumCuentas.Rows[0]["nNumeCertificado"].ToString();
                    if (Convert.ToInt32(dtbNumCuentas.Rows[0]["nNroFolio"]) > 0)
                    {
                        lVal = 1;
                        txtNroFolio.Text = dtbNumCuentas.Rows[0]["nNroFolio"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("El Folio no Existe, Inconsistencia de datos...Por Favor Revisar", "Validación de impresión de formatos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        LimpiarControles();
                        conBusCtaAho.LimpiarControles();
                        this.conBusCtaAho.btnBusCliente.Enabled = true;
                        this.conBusCtaAho.txtCodAge.Focus();
                        return;
                    }
                }

                DataTable dtNumImpresion = clsImpresion.CNRetornaNumImpresion(p_idCta, clsVarGlobal.idModulo);
                if (string.IsNullOrEmpty(dtNumImpresion.Rows[0]["nNumImpresion"].ToString()))
                {
                    this.txtNroImpresiones.Text = "0";
                }
                else
                {
                    this.txtNroImpresiones.Text = dtNumImpresion.Rows[0]["nNumImpresion"].ToString();
                }
                
            }
            else
            {
                MessageBox.Show("Número de Cuenta no Válido para Reimpresión de Formatos", "Validación de impresión de formatos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarControles();
                conBusCtaAho.LimpiarControles();
                this.conBusCtaAho.btnBusCliente.Enabled = true;
                this.conBusCtaAho.txtCodAge.Focus();
                return;
            }
            conBusCtaAho.HabDeshabilitarCtrl(false);
            conBusCtaAho.btnBusCliente.Enabled = false;
            btnEditar.Enabled = true;
        }

        private void LimpiarControles()
        {
            p_idCta = 0;
            this.conBusCtaAho.LimpiarControles();
            this.txtProducto.Clear();
            cboMoneda.SelectedValue = 1;
            cboTipoCuenta.SelectedValue = 1;
            dtpFecApe.Value = clsVarGlobal.dFecSystem;
            txtNroImpresiones.Text = "0";
            txtCodCertificado.Text = "";
            txtNroFolio.Text = "";
            txtMotCambio.Clear();
            txtCodCertNue.Clear();
            txtFolioNuevo.Clear();
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(txtCodCertificado.Text))
            {
                MessageBox.Show("El codigo del certificado no puede estar vacio...verificar", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (Convert.ToInt32(txtCodCertificado.Text) <= 0)
            {
                MessageBox.Show("El codigo del certificado no puede ser Cero o estar en Negativo...verificar", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(txtNroFolio.Text))
            {
                MessageBox.Show("El Número de Folio, no puede estar vacio...verificar", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (Convert.ToInt32(txtNroFolio.Text) <= 0)
            {
                MessageBox.Show("El Número de Folio, no puede ser Cero o estar en Negativo...verificar", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtFolioNuevo.Text))
            {
                MessageBox.Show("Debe Ingresar el Número de Folio del Nuevo Certificado a Vincular", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFolioNuevo.Focus();
                return false;
            }
            if (Convert.ToInt32(txtFolioNuevo.Text) <= 0)
            {
                MessageBox.Show("El Número de Folio Ingresasado no es Válido", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFolioNuevo.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtMotCambio.Text))
            {
                MessageBox.Show("Debe Ingresar el Motivo del Cambio de Certificado", "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFolioNuevo.Focus();
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
            conBusCtaAho.idcuenta = 0;
            this.conBusCtaAho.HabDeshabilitarCtrl(true);
            this.conBusCtaAho.btnBusCliente.Enabled = true;
            this.conBusCtaAho.txtCodAge.Focus();
        }

        private void btnVincular_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }

            var Msg = MessageBox.Show("Esta Seguro de Vincular con el Nuevo Certificado?...", "Validar Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Msg == DialogResult.No)
            {
                return;
            }

            int nNroFolio = Convert.ToInt32(txtFolioNuevo.Text),
                nFolioAnt = Convert.ToInt32(txtNroFolio.Text);

            string cMotivo = txtMotCambio.Text;

            DataTable dtEnviOP = objValorados.CNVinculaCtaCertificado(nNroFolio, p_idCta, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, cMotivo, nFolioAnt);
            if (Convert.ToInt32(dtEnviOP.Rows[0]["idRpta"].ToString()) == 0)
            {
                txtCodCertNue.Text = dtEnviOP.Rows[0]["nNroCertificado"].ToString();
                txtNroFolio.Enabled = false;
                btnVincular.Enabled = false;
                MessageBox.Show(dtEnviOP.Rows[0]["cMensage"].ToString(), "Vinculación de Certificado con la Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HabilitarCtrls(false);
            }
            else
            {
                MessageBox.Show(dtEnviOP.Rows[0]["cMensage"].ToString(), "Vinculación de Certificado con la Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFolioNuevo.Focus();
                txtFolioNuevo.SelectAll();
                return;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            btnVincular.Enabled = true;
            HabilitarCtrls(true);
            txtFolioNuevo.Focus();
        }

        private void HabilitarCtrls(bool val)
        {
            txtFolioNuevo.Enabled = val;
            txtMotCambio.Enabled = val;
        }


    }
}
