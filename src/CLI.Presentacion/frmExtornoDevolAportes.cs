using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLI.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;

namespace CLI.Presentacion
{
    public partial class frmExtornoDevolAportes : frmBase
    {
        int pidAporte = 0, pidTipPago = 0;

        public frmExtornoDevolAportes()
        {
            InitializeComponent();
        }

        private void frmExtornoAporte_Load(object sender, EventArgs e)
        {
            if (this.ValidarInicioOpe() != "A")
            {
                this.Dispose();
                return;
            }
        }

        private void LimpiarControles()
        {
            txtDocIdePerson.Clear();
            txtNombrePerson.Clear();
            txtFechaOpe.Clear();
            this.txtModulo.Clear();
            this.cboTipoOperacion.SelectedValue = 1;
            this.cboMoneda.SelectedValue = 1;
            this.txtMonOpe.Text = "0.00";
        }

        private bool ValiDatos()
        {
            if (string.IsNullOrEmpty(this.nudNroKardex.Value.ToString()))
            {
                MessageBox.Show("El Numero de Kardex, esta Vacio, por Favor VErificar ", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (this.nudNroKardex.Value <= 0)
            {
                MessageBox.Show("El Numero de Kardex no es Válido, VERIFICAR ", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(this.txtModulo.Text.Trim()))
            {
                MessageBox.Show("La Operación no Pertenece a Ningun Módulo, No Puede Realizar el Extorno", "Validar Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            nudNroKardex.Value  = 0;
            txtEstadoOpe.Text   = "";
            LimpiarControles();
            nudNroKardex.Enabled = true;
            nudNroKardex.Focus();
        }

        private void btnExtorno_Click(object sender, EventArgs e)
        {
            if (!ValiDatos())
            {
                return;
            }

            var Msg = MessageBox.Show("Esta Seguro de Extornar la Operación?...", "Extornar Compra/Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Msg == DialogResult.No)
            {
                return;
            }

            //-======================================================
            //--Registrar Extorno de Operación
            //-======================================================
            int idKar       = Convert.ToInt32(this.nudNroKardex.Text.ToString());
            int idTipOpe    = Convert.ToInt32(this.cboTipoOperacion.SelectedValue.ToString());
            int idMon       = Convert.ToInt32(this.cboMoneda.SelectedValue.ToString());
            Decimal nMontoOpe = Convert.ToDecimal (this.txtMonOpe.Text);

            bool lModificaSaldoLinea = false;
            int idTipoTransac = 0;

            clsCNAporte ObjAporte = new clsCNAporte();

            DataTable tbExt = ObjAporte.RegistraExtornoDevolucAportes(idKar, pidAporte, clsVarGlobal.User.idUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.dFecSystem, nMontoOpe, idTipOpe, pidTipPago, lModificaSaldoLinea, idTipoTransac, idMon);

            if (Convert.ToInt32(tbExt.Rows[0]["idRpta"].ToString()) != 0)
            {
                MessageBox.Show(tbExt.Rows[0]["msg"].ToString(), "Extorno de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.nudNroKardex.Enabled   = false;
                this.btnExtorno.Enabled     = false;
                this.btnCancelar.Enabled    = true;
            }
            else
            {
                MessageBox.Show(tbExt.Rows[0]["msg"].ToString(), "Extorno de Aportes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            if (nudNroKardex.Value<=0)
            {
                MessageBox.Show("Debe Ingresar un Número de Kardex Válido", "Validar Datos del Extorno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudNroKardex.Focus();
                nudNroKardex.Select();
                return;
            }

            clsCNAprobacion objApr = new clsCNAprobacion();
            DataTable dtDatExt = objApr.RetornaDatosOperacionExt(Convert.ToInt32(nudNroKardex.Value), clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia,
                                                                clsVarGlobal.User.idUsuario, 9, "58");
            if (dtDatExt.Rows.Count > 0)
            {
                //if (Convert.ToInt32(dtDatExt.Rows[0]["idRpta"].ToString()) == 0)
                //{
                    this.txtDocIdePerson.Text = dtDatExt.Rows[0]["cNroDNI"].ToString();
                    this.txtNombrePerson.Text = dtDatExt.Rows[0]["cNomCliente"].ToString();
                    this.txtFechaOpe.Text = dtDatExt.Rows[0]["dFecHoraOpe"].ToString();
                    this.txtModulo.Text = dtDatExt.Rows[0]["cModulo"].ToString();
                    this.cboTipoOperacion.SelectedValue = dtDatExt.Rows[0]["idTipoOperacion"].ToString();
                    this.cboMoneda.SelectedValue = dtDatExt.Rows[0]["idMoneda"].ToString();
                    this.txtMonOpe.Text = dtDatExt.Rows[0]["nMontoOperacion"].ToString();
                    //--Asignando Valores
                    pidAporte = Convert.ToInt32(dtDatExt.Rows[0]["idCuenta"].ToString());
                    pidTipPago = Convert.ToInt32(dtDatExt.Rows[0]["idTipoPago"].ToString());

                    btnExtorno.Enabled = true;
                /*}
                else
                {
                    MessageBox.Show(dtDatExt.Rows[0]["cMensaje"].ToString(), "Buscar Transacción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.nudNroKardex.Focus();
                    this.nudNroKardex.Select();
                }*/                
            }
            else
            {
                MessageBox.Show("No Existen Datos de la Operación: VERIFICAR", "Validar Datos del Extorno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }  
        }

        private void nudNroKardex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnBusqueda.PerformClick();
            }
        }
    }
}
