using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CAJ.CapaNegocio;
using EntityLayer;
using CNT.CapaNegocio;

namespace CAJ.Presentacion
{
    public partial class frmRegistroCuenta : frmBase
    {
        private int nIdCuentaOtraInst = -1;
        private int nIdEstadoCuenta = 1;
        clsCtaContable objctactb;

        public frmRegistroCuenta()
        {
            InitializeComponent();
            LlenarCboFactorInteres();
            LimpiarControles();          
        }

        private void frmRegistroCuenta_Load(object sender, EventArgs e)
        {
            this.cboAgencia.SelectedValue = clsVarGlobal.nIdAgencia;
            this.lblPlazo.Visible = false;
            this.txtPlazo.Visible = false;
            this.lblEstado.Visible = false;
            this.lblFecCancel.Visible = false;
            this.dtpFechaCancelacion.Visible = false;
            
            DateTime dfecCan = new DateTime();
            dfecCan=dfecCan.AddYears(1899);
            this.dtpFechaCancelacion.Value = dfecCan;
            this.cboEstadoCuentaBco.Visible = false;
            Habilitar(false);
            this.btnNuevaCuenta.Focus();
        }

        private void cboTipoEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboEntidad.CargarEntidades(Convert.ToInt32(cboTipoEntidad.SelectedValue));
        }

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            frmBusquedaCuentaInst frmbusCuentaInst = new frmBusquedaCuentaInst();
            frmbusCuentaInst.ShowDialog();
            if ( frmbusCuentaInst.pcNumeroCuenta == null) return;

            nIdCuentaOtraInst = frmbusCuentaInst.pidCuentaInstitucion;
            txtNumeroCuenta.Text = frmbusCuentaInst.pcNumeroCuenta;
            cboTipoCuentaBco.SelectedValue = frmbusCuentaInst.pidTipoCuenta;
            cboTipoEntidad.SelectedValue = frmbusCuentaInst.pidTipoEntidad;
            cboEntidad.SelectedValue = frmbusCuentaInst.pidEntidad;
            txtDescripcionCuenta.Text = frmbusCuentaInst.pcDescripcionCuenta;
            cboMoneda.SelectedValue = frmbusCuentaInst.pidMoneda;
            dtpFechaApertura.Value = frmbusCuentaInst.pdFechaApertura;
            txtTEA.Text = frmbusCuentaInst.pcTEA;
            cboFactorInteres.SelectedValue = frmbusCuentaInst.pnFactorInteres;
            txtPlazo.Text = frmbusCuentaInst.pcPlazo;
            txtSaldoDisponible.Text = frmbusCuentaInst.pcSaldoDisponible;
            txtSaldoContable.Text = frmbusCuentaInst.pcSaldoContable;
            txtCuentaContable.Text = frmbusCuentaInst.pcCuentaContable;
            cboEstadoCuentaBco.SelectedValue = frmbusCuentaInst.pidEstado;
            dtpFechaCancelacion.Value = frmbusCuentaInst.pdFechaCancelacion;

            this.btnNuevaCuenta.Enabled = true;
            this.btnEditarCuenta.Enabled = true;
            this.btnCancelar.Enabled = true;
        }

        private void btnGrabarCuenta_Click(object sender, EventArgs e)
        {
            string cMensaje = Validar();
            if (cMensaje == "")
            {
                if (Convert.ToInt32(cboEstadoCuentaBco.SelectedValue.ToString()) != 1)
                {
                    if (MessageBox.Show("¿ESTA SEGURO DE CAMBIAR EL ESTADO DE ESTA CUENTA A \"" + cboEstadoCuentaBco.Text + "\"?", "Registrar Cuenta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }

                DateTime dFecCancelacion = dtpFechaCancelacion.Value;

                clsCNMovimientoBanco cuenta = new clsCNMovimientoBanco();
                DataTable  dtGrabarCuenta = cuenta.grabarCuentaInstitucion(nIdCuentaOtraInst,
                                                    Convert.ToInt32(cboEntidad.SelectedValue.ToString()),
                                                    Convert.ToInt32(cboAgencia.SelectedValue.ToString()),
                                                    Convert.ToInt32(cboTipoCuentaBco.SelectedValue.ToString()),
                                                    txtNumeroCuenta.Text.Trim(),
                                                    txtDescripcionCuenta.Text.Trim(),
                                                    Convert.ToInt32(cboMoneda.SelectedValue.ToString()),
                                                    Convert.ToDateTime(dtpFechaApertura.Value.ToShortDateString()),
                                                    Convert.ToDecimal(txtTEA.Text.Trim()),
                                                    Convert.ToInt32(cboFactorInteres.SelectedValue.ToString()),
                                                    Convert.ToInt32(txtPlazo.Text.Trim()),
                                                    txtCuentaContable.Text.Trim(),
                                                    nIdEstadoCuenta, dFecCancelacion);
                if (dtGrabarCuenta.Rows[0]["idMsje"].ToString() == "0")
                {
                    MessageBox.Show(dtGrabarCuenta.Rows[0]["cMsje"].ToString(), "Registrar Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Habilitar(false);
                    this.btnNuevaCuenta.Enabled = false;
                    this.btnCancelar.Enabled = true;
                }
                else
                {
                    MessageBox.Show(dtGrabarCuenta.Rows[0]["cMsje"].ToString(), "Registrar Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show(cMensaje, "Registrar Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);   
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            Habilitar(false);
        }

        private void btnNuevaCuenta_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            nIdCuentaOtraInst = -1;
            nIdEstadoCuenta = 1;
            Habilitar(true);
            this.btnEditarCuenta.Enabled = false;
            this.cboEstadoCuentaBco.SelectedValue = 1;
        }

        private void btnEditarCuenta_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNumeroCuenta.Text))
            {
                Habilitar(false);
                this.txtNumeroCuenta.Enabled = true;
                this.btnEditarCuenta.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.btnGrabarCuenta.Enabled = true;
                this.txtPlazo.Enabled = true;
                this.cboEstadoCuentaBco.Enabled = true;
                this.lblEstado.Visible = true;
                this.cboEstadoCuentaBco.Visible = true;
                this.dtpFechaApertura.Enabled = true;
                this.dtpFechaCancelacion.Enabled = true;
            }
            else
            {
                MessageBox.Show("Seleccione una cuenta.", "Registro Cuenta Institucion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Habilitar(false);
                this.btnBuscarCuenta.Enabled = true;
            }
        }

        private void cboEstadoCuentaBco_SelectedIndexChanged(object sender, EventArgs e)
        {
            nIdEstadoCuenta = Convert.ToInt32(this.cboEstadoCuentaBco.SelectedValue.ToString());
        }

        private void cboTipoCuentaBco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoCuentaBco.SelectedValue != null)
            {
                if (Convert.ToInt32(cboTipoCuentaBco.SelectedValue.ToString()) == 2)
                {
                    lblPlazo.Visible = true;
                    txtPlazo.Visible = true;
                    lblFecCancel.Visible = true;
                    dtpFechaCancelacion.Visible = true;
                    this.dtpFechaCancelacion.Value = clsVarGlobal.dFecSystem;
                }
                else
                {
                    lblPlazo.Visible = false;
                    txtPlazo.Visible = false;
                    lblFecCancel.Visible = false;
                    dtpFechaCancelacion.Visible = false;

                    DateTime dfecCan = new DateTime();
                    dfecCan = dfecCan.AddYears(1899);
                    this.dtpFechaCancelacion.Value = dfecCan;
                }
            }
        }

        public string Validar()
        {
            string cMensaje="";
            if(string.IsNullOrEmpty(txtNumeroCuenta.Text))
            {
                cMensaje += "Ingrese el numero de cuenta.";
            }
            if (string.IsNullOrEmpty(cboTipoCuentaBco.Text))
            {
                cMensaje += "\nSeleccione un tipo de cuenta.";
            }
            if (string.IsNullOrEmpty(cboTipoEntidad.Text))
            {
                cMensaje += "\nSeleccione un tipo de entidad.";
            }
            if (string.IsNullOrEmpty(cboEntidad.Text))
            {
                cMensaje += "\nSeleccione de que entidad es la cuenta.";
            }
            if (string.IsNullOrEmpty(txtDescripcionCuenta.Text))
            {
                cMensaje += "\nComplete la descripcion de la cuenta.";
            }
            if (string.IsNullOrEmpty(cboMoneda.Text))
            {
                cMensaje += "\nSeleccione el tipo de moneda de la cuenta";
            }
            if (string.IsNullOrEmpty(txtTEA.Text))
            {
                cMensaje += "\nIngrese el campo TEA de la cuenta.";
            }
            else
            {
                if (Convert.ToDecimal(txtTEA.Text) > new decimal(100.00) || Convert.ToDecimal(txtTEA.Text) < new decimal(0.00))
                {
                    cMensaje += "\n El valor de la TEA tiene que ser entre 0 a 100.";
                }
            }
            if (string.IsNullOrEmpty(cboFactorInteres.Text))
            {
                cMensaje += "\nSeleccione el factor de interes de la cuenta.";
            }
            if (string.IsNullOrEmpty(txtCuentaContable.Text))
            {
                cMensaje += "\nIngrese la cuenta contable de la cuenta.";
            }
            if (txtPlazo.Visible == true)
            {
                if (string.IsNullOrEmpty(txtPlazo.Text))
                {
                    cMensaje += "\nIngrese el plazo de la cuenta.";
                }
                if (Convert.ToInt32(txtPlazo.Text) <=0)
                {
                    cMensaje += "\nIngrese el plazo correctamente.";
                }
            }

            return cMensaje;
        }

        private void Habilitar(bool lval)
        {
            this.btnBuscarCuenta.Enabled = !lval;
            this.btnCancelar.Enabled = lval;
            this.btnGrabarCuenta.Enabled = lval;
            this.btnNuevaCuenta.Enabled = !lval;
            this.btnEditarCuenta.Enabled = lval;
            this.txtNumeroCuenta.Enabled = lval;
            this.cboTipoCuentaBco.Enabled = lval;
            this.cboTipoEntidad.Enabled = lval;
            this.cboEntidad.Enabled = lval;
            this.txtDescripcionCuenta.Enabled = lval;
            this.cboMoneda.Enabled = lval;
            this.dtpFechaApertura.Enabled = lval;
            this.txtTEA.Enabled = lval;
            this.cboFactorInteres.Enabled = lval;
            this.txtCuentaContable.Enabled = lval;
            this.txtPlazo.Enabled = lval;
            this.cboEstadoCuentaBco.Enabled = lval;
            this.dtpFechaCancelacion.Enabled = lval;
            btnMiniBusq1.Enabled = lval;
        }

        private void LimpiarControles()
        {
            this.txtNumeroCuenta.Text = "";
            this.cboTipoCuentaBco.SelectedIndex = -1;           
            this.cboTipoEntidad.SelectedIndex = -1;
            this.cboEntidad.DataSource = null;
            this.txtDescripcionCuenta.Text = "";
            this.cboMoneda.SelectedIndex = -1;
            this.dtpFechaApertura.Value = clsVarGlobal.dFecSystem;
            this.txtTEA.Text = "";
            this.cboFactorInteres.SelectedIndex = 0;
            this.txtPlazo.Text = "0";
            this.txtSaldoDisponible.Text = "0.00";
            this.txtSaldoContable.Text = "0.00";
            this.txtCuentaContable.Text = "";
            this.lblPlazo.Visible = false;
            this.txtPlazo.Visible = false;
            this.lblFecCancel.Visible = false;
            this.dtpFechaCancelacion.Visible = false;
            this.lblEstado.Visible = false;
            this.cboEstadoCuentaBco.Visible = false;

            DateTime dfecCan = new DateTime();
            dfecCan = dfecCan.AddYears(1899);
            this.dtpFechaCancelacion.Value = dfecCan;
        }

        private void LlenarCboFactorInteres()
        {
            //==============================================
            //CREA DATATABLE PARA LLENAR CBOFACTORINTERES
            //==============================================
            DataTable dtFactorInteres = new DataTable();
            DataRow dr = null;
            dtFactorInteres.Columns.Clear();
            dtFactorInteres.Rows.Clear();
            dtFactorInteres.Columns.Add(new DataColumn("nValor", typeof(Int32)));
            dtFactorInteres.Columns.Add(new DataColumn("nFactor", typeof(Int32)));
            dr = dtFactorInteres.NewRow();
            dr["nValor"] = 360;
            dr["nFactor"] = 360;
            dtFactorInteres.Rows.Add(dr);
            dr = dtFactorInteres.NewRow();
            dr["nValor"] = 365;
            dr["nFactor"] = 365;
            dtFactorInteres.Rows.Add(dr);
            cboFactorInteres.DataSource = dtFactorInteres;
            cboFactorInteres.ValueMember = "nValor";
            cboFactorInteres.DisplayMember = "nFactor";
        }

        private void btnMiniBusq1_Click(object sender, EventArgs e)
        {
            frmBuscaCtaCtb frmBscCtaCtb = new frmBuscaCtaCtb();
            frmBscCtaCtb.ShowDialog();
            if (string.IsNullOrEmpty(frmBscCtaCtb.pcCtaCtb)) return;

            if (ValidarCtaCtb(frmBscCtaCtb.pcCtaCtb))
            {
                return;
            }
            txtCuentaContable.Text = frmBscCtaCtb.pcCtaCtb;
        }

        private Boolean ValidarCtaCtb(string pcCodCtb)
        {
            objctactb = new clsCNCtaContable().detallectactb(pcCodCtb);
            if (objctactb.nHijos > 0)
            {
                MessageBox.Show("Cuenta debe ser del ultimo nivel", "Graba Cuenta Contable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            if (string.IsNullOrEmpty(objctactb.cDescripcion))
            {
                return true;
            }
            return false;
        }

    }
}
