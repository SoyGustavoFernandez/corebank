using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CLI.CapaNegocio;
using CAJ.CapaNegocio;
using EntityLayer;

namespace CAJ.Presentacion
{
    public partial class frmIniCajaChica : frmBase
    {
        clsCNCajaChica Lista = new clsCNCajaChica();
        DataTable dtDatosCajChica;
        public frmIniCajaChica()
        {
            InitializeComponent();
        }

        private void frmIniCajaChica_Load(object sender, EventArgs e)
        {
            this.cboAgencias.SelectedValue = clsVarGlobal.nIdAgencia;
            this.dtpFecInicio.Value = clsVarGlobal.dFecSystem;
            this.txtNroRec.Focus();
            if (ValidarRespCajChica())
            {
                MessageBox.Show("Usted no es responsable de Caja Chica", "Inicio de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
                return;
            }
            if (ValidarCajaChicaActivo())
            {
                MessageBox.Show("Fondo Fijo Está Activo..", "Inicio de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
                return;
            }
            if (ValidarHabilitacionCajChica())
            {
                MessageBox.Show("Falta realizar la Habilitacion de Fondo Fijo", "Inicio de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
                return;
            }
        }
        private bool ValidarRespCajChica()
        {
            bool valRespCajChi = false;
            dtDatosCajChica = Lista.BuscarCajChicResp(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);
            if (dtDatosCajChica.Rows.Count <=0)
            {
                valRespCajChi = true;
            }
            return valRespCajChi;
        }
        private bool ValidarCajaChicaActivo()
        {
            bool valRespCajChi = false;
            dtDatosCajChica = Lista.BuscarCajChicActivo(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);
            if (dtDatosCajChica.Rows.Count > 0)
            {
                valRespCajChi = true;
            }
            return valRespCajChi;
        }
        private bool ValidarHabilitacionCajChica()
        {
            bool valRespCajChi = false;
            dtDatosCajChica = Lista.BuscarHabCajChic(clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia);
            if (dtDatosCajChica.Rows.Count <= 0)
            {
                valRespCajChi = true;

            }
            return valRespCajChi;
        }
      
        private void DatosHabCajChica(int idRec)
        {
            LimpiarControles();
            

            DataTable tb = Lista.RetDatosCajaChica(idRec);
            if (tb.Rows.Count > 0)
            {
                //--Datos Recibo
                this.cboMonRec.SelectedValue = tb.Rows[0]["idMonRec"];
                this.txtMonRec.Text = tb.Rows[0]["nMontoTot"].ToString();
                this.dtpFecEmiRec.Value = Convert.ToDateTime(tb.Rows[0]["dFechaReg"].ToString());
                this.txtSustento.Text = tb.Rows[0]["cSustento"].ToString();
                //--Datos Caja Chica
                this.cboAgencias.SelectedValue = tb.Rows[0]["idAgencia"];
                this.txtIdCaj.Text = tb.Rows[0]["idCajChica"].ToString();
                this.txtNomCaj.Text = tb.Rows[0]["cNomCajChi"].ToString();
                this.txtNomResCaj.Text = tb.Rows[0]["cNombre"].ToString();
                this.txtIDResCaj.Text = tb.Rows[0]["idResCajChi"].ToString();
                this.cboMoneda.SelectedText = tb.Rows[0]["idMoneda"].ToString();
                this.txtMonFij.Text = tb.Rows[0]["nMonMaxCaj"].ToString();
                this.txtNroFonFij.Text = tb.Rows[0]["nNroCajChi"].ToString();
                this.txtTotHab.Text = tb.Rows[0]["nMontoHab"].ToString();
                this.btnGrabar.Enabled = true;
                this.txtNroRec.Enabled = false;
                this.btnAceptar.Enabled = false;
                this.btnGrabar.Focus();
            }
            else
            {
                this.btnGrabar.Enabled = false;
                MessageBox.Show("El Número de Recibo Ingresado No es Válido", "Iniciar Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNroRec.Text = "";
                this.txtNroRec.Focus();
            }
        }

        private void LimpiarControles()
        {
            //--Datos Recibo
            this.cboMonRec.SelectedValue = 1;
            this.txtMonRec.Text = "0.00";
            this.dtpFecEmiRec.Value = clsVarGlobal.dFecSystem;
            this.txtSustento.Clear();
            //--Datos Caja Chica;
            this.txtIdCaj.Clear();
            this.txtNomCaj.Clear();
            this.txtNomResCaj.Clear();
            this.txtIDResCaj.Clear();
            this.cboMoneda.SelectedValue = 1;
            this.txtMonFij.Text = "0.00";
            this.txtNroFonFij.Clear();
            this.txtTotHab.Text = "0.00";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //=======================================================================
            //--Validar Datos
            //=======================================================================
            if (string.IsNullOrEmpty(this.txtNroRec.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar Primero el Número e Recibo de Habilitación", "Iniciar Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                
                this.txtNroRec.Focus();
                this.txtNroRec.Select();
                return;
            }
            int idRec = Convert.ToInt32(this.txtNroRec.Text);
            if (idRec==0)
            {
                MessageBox.Show("Ingresar un Número de Recibo Válido", "Iniciar Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNroRec.Focus();
                this.txtNroRec.Select();
                return;
            }
            DatosHabCajChica(idRec);
            btnCancelar.Enabled = true;
        }

        private void txtNroRec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnAceptar.PerformClick();
            }
        }

        private void txtNroGiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57)
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 13)
            {
                this.btnAceptar.PerformClick();
            }
        }

        private void txtNroRec_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNroRec_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar) < 48 && e.KeyChar != 8) || e.KeyChar > 57)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                this.btnAceptar.PerformClick();
            }
        }

        private void txtNroRec_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //=======================================================================
            //--Validar Datos
            //=======================================================================
            if (string.IsNullOrEmpty(this.txtNroRec.Text.Trim()))
            {
                MessageBox.Show("Debe Ingresar Primero el Número del Recibo de Habilitación", "Iniciar Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtNroRec.Focus();
                this.txtNroRec.Select();
                return;
            }

            if (string.IsNullOrEmpty(this.txtIdCaj.Text.Trim()))
            {
                MessageBox.Show("El Codigo de la Caja Chica no Existe...REVISAR", "Iniciar Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(this.txtNroFonFij.Text.Trim()))
            {
                MessageBox.Show("El Número de la Caja Chica no Existe...REVISAR", "Iniciar Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToInt32(this.txtIDResCaj.Text.Trim()) != clsVarGlobal.User.idUsuario)
            {
                MessageBox.Show("Usted no es Responsable de esta Caja Chica...REVISAR", "Iniciar Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            //===============================================================================
            //--Asignar Datos a las Variables
            //===============================================================================
            int idCajChi = Convert.ToInt32(this.txtIdCaj.Text.Trim());
            int nNroCaj = Convert.ToInt32(this.txtNroFonFij.Text.Trim());
            DateTime dFecReg = this.dtpFecInicio.Value;
            int idUsu = Convert.ToInt32(this.txtIDResCaj.Text);            

            //===============================================================================
            //--Registro de Habilitación de Caja Chica
            //===============================================================================
            clsCNCajaChica dtCajChi = new clsCNCajaChica();
            DataTable tbdtCajChi = dtCajChi.RegistraInicioCajaChica(idCajChi, nNroCaj, dFecReg, idUsu);
            if (Convert.ToInt32(tbdtCajChi.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(tbdtCajChi.Rows[0]["cMensage"].ToString(), "Registro de INICIO de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnGrabar.Enabled = false;
            }
            else
            {
                MessageBox.Show(tbdtCajChi.Rows[0]["cMensage"].ToString(), "Registro de INICIO de Caja Chica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            txtNroRec.Clear();
            txtNroRec.Enabled = true;
            btnAceptar.Enabled = true;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
        }

    }
}
