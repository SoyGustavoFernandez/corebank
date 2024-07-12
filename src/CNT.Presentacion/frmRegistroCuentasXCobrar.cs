using CNT.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNT.Presentacion
{
    public partial class frmRegistroCuentasXCobrar : frmBase
    {
        private int idCuentaXcobrar=0;
        public int idEstadoCxC;
        private decimal nTotalPago;
        clsCNCuentasXCobrar cnCxc = new clsCNCuentasXCobrar();

        public frmRegistroCuentasXCobrar()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (ValidarInicioOpe() != "A")
            {
                Dispose();
                return;
            }
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            if (idCuentaXcobrar == 0)
            {
                MessageBox.Show("El cliente no tiene registrado acciones", "Mensaje registro accionista", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            conBusCli.Enabled = false;
            EnableBoton(false);
            chcVigente.Enabled = true;
            EnableControl(true);
        }
        private void EnableBoton(bool lActivo)
        {
            btnEditar1.Enabled = lActivo;
            btnNuevo1.Enabled = lActivo;
            btnGrabar1.Enabled = !lActivo;
            btnCancelar1.Enabled = !lActivo;
        }
        private void EnableControl(bool lActivo)
        {
            //conBusCli.Enabled = lActivo;
            cboTipoCuentasCobrar1.Enabled = lActivo;
            txtObservacion.Enabled = lActivo;
            txtMonto.Enabled = lActivo;
            dtpFechControl.Enabled = lActivo;
        }
        private void limpiarGrupo()
        {
            chcVigente.Checked = false;
            cboTipoCuentasCobrar1.SelectedIndex = -1;
            txtMonto.Text = "0.00";
            txtObservacion.Clear();
            dtpFechControl.Value = clsVarGlobal.dFecSystem;
            chcVigente.Checked = false;
        }
        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            if (conBusCli.idCli == 0)
            {
                return;
            }
            limpiarGrupo();
            EnableBoton(false);
            chcVigente.Checked = true;
            chcVigente.Enabled = false;
            EnableControl(true);
            conBusCli.Enabled = false;

   
            idCuentaXcobrar = 0;
            //conBusCli.Enabled = lActivo
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            btnEditar1.Enabled = true;
            btnNuevo1.Enabled = true;
            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = false;
            conBusCli.Enabled = true;
            chcVigente.Enabled = false;
            EnableControl(false);

            conBusCli.limpiarControles();
            conBusCli.txtCodCli.Enabled = true;
            limpiarGrupo();

        }
        private bool validar()
        { 
            
            if (cboTipoCuentasCobrar1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe elegir tipo de cuenta por cobrar", "Registro cuentas por cobrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (txtMonto.Text=="")
            {
                MessageBox.Show("Debe ingresar el monto de la cuenta por cobrar", "Registro cuentas por cobrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (Convert.ToDecimal(txtMonto.Text) <=0)
            {
                MessageBox.Show("El monto de la cuenta por cobrar debe ser mayor a cero", "Registro cuentas por cobrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (txtObservacion.Text.Trim().Length <5)
            {
                MessageBox.Show("Debe ingresar un comentario u observacion", "Registro cuentas por cobrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (dtpFechControl.Value>clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha de inicio de operación debe ser ser menor a la fecha del sistema", "Registro cuentas por cobrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (nTotalPago > 0)
            {
                MessageBox.Show("No puede editar, ya se realizaron pagos", "Registro cuentas por cobrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;

            }
            return false;
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                return;
            }
            EnableBoton(true);
            DataTable dtResultado;
            dtResultado = cnCxc.CNRegistraCuentasXcobrar(idCuentaXcobrar, conBusCli.idCli, (int)(cboTipoCuentasCobrar1.SelectedValue),
                Convert.ToDecimal(txtMonto.Text), txtObservacion.Text, dtpFechControl.Value, 
                clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem, chcVigente.Checked,clsVarGlobal.nIdAgencia,Convert.ToInt32(cboMoneda1.SelectedValue));
            if (dtResultado.Rows.Count > 0)
            {
                if (dtResultado.Rows[0][0].ToString() == "1")
                {

                    MessageBox.Show(dtResultado.Rows[0][1].ToString(), "Graba cuentas por cobrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    EnableControl(false);
                    btnCancelar1.Enabled = true;
                }
                else
                {
                    EnableBoton(false);
                    MessageBox.Show(dtResultado.Rows[0][1].ToString(), "Graba cuentas por cobrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            DataTable dtCxC = cnCxc.CNListaCuentasxCobrar(conBusCli.idCli);
            if (dtCxC.Rows.Count <= 0)
            {
                return;
            }
            else if (dtCxC.Rows.Count == 1)
            {
                DataRow dtRows = dtCxC.Rows[0];
                idCuentaXcobrar = (int)dtRows["idCuentasxCobrar"];
                cboTipoCuentasCobrar1.SelectedValue = (int)dtRows["idTipoCuentaxCobrar"];
                txtMonto.Text = dtRows["nMonto"].ToString();
                txtObservacion.Text = dtRows["cObservacion"].ToString();
                dtpFechControl.Value = Convert.ToDateTime(dtRows["dFechaIniOpera"]);
                chcVigente.Checked = Convert.ToBoolean(dtRows["lVigente"]);
                btnCancelar1.Enabled = true;
                idEstadoCxC = Convert.ToInt32(dtRows["idEstadoCxC"]);
                nTotalPago = Convert.ToDecimal(dtRows["nTotalPago"]);
                btnEditar1.Enabled = idEstadoCxC == 2 ? false : true;
            }
            else
            {
                frmBuscarCuentasXCobrar frCxC = new frmBuscarCuentasXCobrar(dtCxC);
                frCxC.ShowDialog();
                if (frCxC.dtRows != null)
                {
                    idCuentaXcobrar = (int)frCxC.dtRows["idCuentasxCobrar"];
                    cboTipoCuentasCobrar1.SelectedValue = (int)frCxC.dtRows["idTipoCuentaxCobrar"];
                    txtMonto.Text = frCxC.dtRows["nMonto"].ToString();
                    nTotalPago = Convert.ToDecimal(frCxC.dtRows["nTotalPago"]);
                    txtObservacion.Text = frCxC.dtRows["cObservacion"].ToString();
                    dtpFechControl.Text = frCxC.dtRows["dFechaIniOpera"].ToString();
                    chcVigente.Checked = Convert.ToBoolean(frCxC.dtRows["lVigente"]);
                    btnCancelar1.Enabled = true;
                    idEstadoCxC = Convert.ToInt32(frCxC.dtRows["idEstadoCxC"]);
                    btnEditar1.Enabled = idEstadoCxC == 2 ? false : true;
                }

            }

        }

        private void frmRegistroCuentasXCobrar_Load(object sender, EventArgs e)
        {
            EnableBoton(true);
            EnableControl(false);
            limpiarGrupo();
            cboMoneda1.SelectedValue = 1;
        }
    }
}
