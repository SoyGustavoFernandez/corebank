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

namespace ADM.Presentacion
{
    public partial class frmSolReimpresionVoucher : frmBase
    {
        int p_idProd = 0, p_idCli = 0,p_idTipOpe=0;
        clsCNImpresion Imprimir = new clsCNImpresion();

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
            DataTable dtDatKardex = Imprimir.CNBuscaKardex(idKardex, clsVarGlobal.nIdAgencia);
            if (dtDatKardex.Rows.Count > 0)
            {
                this.txtEstadoOpe.Text = dtDatKardex.Rows[0]["cEstadoKardex"].ToString();
                this.txtFechaOpe.Text = dtDatKardex.Rows[0]["dFechaOpe"].ToString();
                this.txtModulo.Text = dtDatKardex.Rows[0]["cModulo"].ToString();
                this.txtTipoOperacion.Text = dtDatKardex.Rows[0]["cTipoOperacion"].ToString();
                this.cboMoneda.SelectedValue = dtDatKardex.Rows[0]["idMoneda"];
                this.txtMonOpe.Text = dtDatKardex.Rows[0]["nMontoOperacion"].ToString();
                this.lblNroImpresion.Text = dtDatKardex.Rows[0]["nNumImpresion"].ToString();
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
            nudNroOperacion.Enabled = true;
            nudNroOperacion.Focus();
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
            return true;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatosIngresados())
            {
                return;
            }

            clsCNAprobacion dtSolApr = new clsCNAprobacion();
            DataTable tbSolApr = dtSolApr.GuardarSolicitudAprobac(clsVarGlobal.nIdAgencia, p_idCli, 116, 1,
                                                                Convert.ToInt16(cboMoneda.SelectedValue), p_idProd, Convert.ToDecimal (txtMonOpe.Text),
                                                                Convert.ToInt32(nudNroOperacion.Value), clsVarGlobal.dFecSystem, Convert.ToInt16(cboMotivos.SelectedValue),
                                                                txtMotivo.Text, 1, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, 0, clsVarGlobal.User.idEstablecimiento, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil));

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

    }
}
