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
using EntityLayer;

namespace SolIntEls
{
    public partial class frmTipoCambioMensual : frmBase
    {
        public frmTipoCambioMensual()
        {
            InitializeComponent();
        }

        private void frmTipoCambioMensual_Load(object sender, EventArgs e)
        {
            dtpFecIni.Value = clsVarGlobal.dFecSystem;
            dtpFecFin.Value = clsVarGlobal.dFecSystem;
            FechaIniTipCambio();
            UltimoTipCambio();
            txtTipCamFij.Focus();
            txtTipCamFij.Select();
        }

        private void FechaIniTipCambio()
        {
            DateTime dFecIni;
            clsCNGenAdmOpe dtFecIni = new clsCNGenAdmOpe();
            DataTable tbFecIni = dtFecIni.RetornaFechaTipCambio(clsVarGlobal.dFecSystem);
            dFecIni=Convert.ToDateTime(tbFecIni.Rows[0]["dFecIni"].ToString());
            dtpFecIni.Value= Convert.ToDateTime(dFecIni.ToShortDateString());
            dtpFecFin.Value = Convert.ToDateTime(dFecIni.ToShortDateString());
        }

        private void UltimoTipCambio()
        {
            clsCNGenAdmOpe dtTipCam = new clsCNGenAdmOpe();
            DataTable tbTipCam = dtTipCam.RetornaUltimoTipCambio(clsVarGlobal.dFecSystem);
            txtTipCamFij.Text = tbTipCam.Rows[0]["nTipCamFij"].ToString();
            txtTipCamCom.Text = tbTipCam.Rows[0]["nTipCamCom"].ToString();
            txtTipCamVen.Text = tbTipCam.Rows[0]["nTipCamVen"].ToString();
            txtTipCamProCom.Text = tbTipCam.Rows[0]["nTipCamProCom"].ToString();
            txtTipCamProVen.Text = tbTipCam.Rows[0]["nTipCamProVen"].ToString();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (this.dtpFecIni.Value>this.dtpFecFin.Value)
            {
                MessageBox.Show("La Fecha Inicial no Puede ser Mayor que la Fecha Final", "Rigistrar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.dtpFecIni.Focus();
                return;   
            }

            if (string.IsNullOrEmpty(this.txtTipCamFij.Text))
            {
                MessageBox.Show("Debe Ingresar el Tipo de Cambio Fijo", "Rigistrar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTipCamFij.Focus();
                this.txtTipCamFij.Select();
                return;
            }

            if (Convert.ToDecimal (this.txtTipCamFij.Text)<=0)
            {
                MessageBox.Show("Debe Ingresar el Tipo de Cambio Fijo Válido", "Rigistrar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTipCamFij.Focus();
                this.txtTipCamFij.Select();
                return;
            }

            if (string.IsNullOrEmpty(this.txtTipCamCom.Text))
            {
                MessageBox.Show("Debe Ingresar el Tipo de Cambio Compra", "Rigistrar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTipCamCom.Focus();
                this.txtTipCamCom.Select();
                return;
            }

            if (Convert.ToDecimal(this.txtTipCamCom.Text) <= 0)
            {
                MessageBox.Show("Debe Ingresar el Tipo de Cambio Compra Válido", "Rigistrar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTipCamCom.Focus();
                this.txtTipCamCom.Select();
                return;
            }

            if (string.IsNullOrEmpty(this.txtTipCamVen.Text))
            {
                MessageBox.Show("Debe Ingresar el Tipo de Cambio Venta", "Rigistrar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTipCamVen.Focus();
                this.txtTipCamVen.Select();
                return;
            }

            if (Convert.ToDecimal(this.txtTipCamVen.Text) <= 0)
            {
                MessageBox.Show("Debe Ingresar el Tipo de Cambio Venta Válido", "Rigistrar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTipCamVen.Focus();
                this.txtTipCamVen.Select();
                return;
            }

            if (string.IsNullOrEmpty(this.txtTipCamProCom.Text))
            {
                MessageBox.Show("Debe Ingresar el Tipo de Cambio Promedio Compra", "Rigistrar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTipCamProCom.Focus();
                this.txtTipCamProCom.Select();
                return;
            }

            if (Convert.ToDecimal(this.txtTipCamProCom.Text) <= 0)
            {
                MessageBox.Show("Debe Ingresar el Tipo de Cambio Promedio Compra Válido", "Rigistrar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTipCamProCom.Focus();
                this.txtTipCamProCom.Select();
                return;
            }

            if (string.IsNullOrEmpty(this.txtTipCamProVen.Text))
            {
                MessageBox.Show("Debe Ingresar el Tipo de Cambio Promedio Venta", "Rigistrar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTipCamProVen.Focus();
                this.txtTipCamProVen.Select();
                return;
            }

            if (Convert.ToDecimal (this.txtTipCamProVen.Text) <= 0)
            {
                MessageBox.Show("Debe Ingresar el Tipo de Cambio Promedio Venta Válido", "Rigistrar Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtTipCamProVen.Focus();
                this.txtTipCamProVen.Select();
                return;
            }

            //======================================================================
            //--------Datos para Guardar Tipos de Cambio
            //======================================================================
            Decimal nTipCamFij = Convert.ToDecimal(this.txtTipCamFij.Text);
            Decimal nTipCamCom = Convert.ToDecimal(this.txtTipCamCom.Text);
            Decimal nTipCamVen = Convert.ToDecimal(this.txtTipCamVen.Text);
            Decimal nTipCamProCom = Convert.ToDecimal(this.txtTipCamProCom.Text);
            Decimal nTipCamPromVen = Convert.ToDecimal(this.txtTipCamProVen.Text);
            DateTime dFecIni = dtpFecIni.Value;
            DateTime dFecFin = dtpFecFin.Value;

            var Msg = MessageBox.Show("Esta Seguro de Registrar los Tipos de Cambio?...", "Registrar Tipos de Cambio", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Msg == DialogResult.No)
            {
                return;
            }

            //======================================================================
            //--------Guardar Tipos de Cambio
            //======================================================================
            clsCNGenAdmOpe dtTipCam = new clsCNGenAdmOpe();
            DataTable tbTipCam = dtTipCam.RegistrarTiposCambio(dFecIni, dFecFin, nTipCamFij, nTipCamCom, nTipCamVen, nTipCamProCom, nTipCamPromVen, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            if (Convert.ToInt32(tbTipCam.Rows[0]["idRpta"].ToString()) == 0)
            {
                MessageBox.Show(tbTipCam.Rows[0]["cMensage"].ToString(), "Registro de Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTipCamFij.Enabled = false;
                txtTipCamCom.Enabled = false;
                txtTipCamVen.Enabled = false;
                txtTipCamProCom.Enabled = false;
                txtTipCamProVen.Enabled = false;
                dtpFecFin.Enabled = false;
                btnProcesar.Enabled = false;
            }
            else
            {
                MessageBox.Show(tbTipCam.Rows[0]["cMensage"].ToString(), "Registro de Tipos de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTipCamFij.Focus();
            }
        }
    }
}
