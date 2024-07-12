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
    public partial class frmAmortizarCuentasXCobrar : frmBase
    {
        private int idCuentaXcobrar=0;
        clsCNCuentasXCobrar cnCxc = new clsCNCuentasXCobrar();
        public int idEstadoCxC;
        public frmAmortizarCuentasXCobrar()
        {
            InitializeComponent();
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
            btnExtorno1.Enabled = lActivo;
            btnNuevo1.Enabled = lActivo;
            btnGrabar1.Enabled = !lActivo;
            btnCancelar1.Enabled = !lActivo;
        }
        private void EnableControl(bool lActivo)
        {
            //conBusCli.Enabled = lActivo;
            dtpFechPago.Enabled = lActivo;
            txtMontoPago.Enabled = lActivo;
           
        }
        private void limpiarGrupo()
        {
            chcVigente.Checked = false;
            cboTipoCuentasCobrar1.SelectedIndex = -1;
            txtMonto.Text = "0.00";
            txtMontoPago.Text = "0.00";
            txtSaldoAnterior.Text = "0.00";
            txtObservacion.Clear();
            txtNuevoSando.Text = "0.00";
            limpiarGrupoPago();
        }
        private void limpiarGrupoPago()
        {          
            txtNuevoSando.Text = "0.00";
            cboTipoPago1.SelectedIndex = -1;
            dtpFechPago.Value = clsVarGlobal.dFecSystem;
            
        }
        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            if (conBusCli.idCli == 0)
            {
                return;
            }
            limpiarGrupoPago();
            EnableBoton(false);
            chcVigente.Checked = true;
            chcVigente.Enabled = false;
            EnableControl(true);
            conBusCli.Enabled = false;
            cboTipoPago1.SelectedValue = 1;
   
            //conBusCli.Enabled = lActivo
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            btnNuevo1.Enabled = true;
            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = false;
            conBusCli.Enabled = true;
            chcVigente.Enabled = false;
            EnableControl(false);
            btnNuevo1.Enabled = false;
            btnExtorno1.Enabled = false;
            conBusCli.limpiarControles();
            conBusCli.txtCodCli.Enabled = true;
            btnCancelar1.Enabled = false;
            limpiarGrupo();
            dtgPagoCxC.DataSource = null;
            limpiarGrupoPago();
        }
        private bool validar()
        { 
            if (txtMontoPago.Text == "")
            {
                MessageBox.Show("Debe ingresar el monto a pagar", "Pago de cuentas por cobrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (Convert.ToDecimal(txtMontoPago.Text) <=0)
            {
                MessageBox.Show("El monto a pagar debe ser mayor a cero", "Pago de cuentas por cobrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (Convert.ToDecimal(txtMontoPago.Text) > Convert.ToDecimal(txtSaldoAnterior.Text))
            {
                MessageBox.Show("El monto a pagar debe ser menor o igual a saldo", "Pago de cuentas por cobrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (dtpFechPago.Value>clsVarGlobal.dFecSystem)
            {
                MessageBox.Show("La fecha de pago debe ser menor a la fecha del sistema", "Pago de cuentas por cobrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (dtpFechPago.Value < dtpFechControl.Value)
            {
                MessageBox.Show("La fecha de pago debe ser mayor a la fecha de inicio de operación", "Pago de cuentas por cobrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            dtResultado = cnCxc.CNPagoCuentasxCobrar(idCuentaXcobrar,dtpFechPago.Value,Convert.ToDecimal(txtMontoPago.Text),
                (int)cboTipoPago1.SelectedValue, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario,clsVarGlobal.nIdAgencia);
            if (dtResultado.Rows.Count > 0)
            {
                if (dtResultado.Rows[0][0].ToString() == "1")
                {

                    MessageBox.Show(dtResultado.Rows[0][1].ToString(), "Pago de cuentas por cobrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buscarDetallePago(idCuentaXcobrar);
                    txtTotalPago.Text = (Convert.ToDecimal(txtTotalPago.Text) + Convert.ToDecimal(txtMontoPago.Text)).ToString();
                    txtSaldoAnterior.Text = (Convert.ToDecimal(txtMonto.Text) - Convert.ToDecimal(txtTotalPago.Text)).ToString();
                    EnableControl(false);
                    btnCancelar1.Enabled = true;
                }
                else
                {
                    EnableBoton(false);
                    MessageBox.Show(dtResultado.Rows[0][1].ToString(), "Pago de cuentas por cobrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                txtSaldoAnterior.Text = dtRows["nSaldo"].ToString();
                txtTotalPago.Text = dtRows["nTotalPago"].ToString();
               EnableBoton(true);
                buscarDetallePago(idCuentaXcobrar);
               
                btnCancelar1.Enabled = true;
                idEstadoCxC = Convert.ToInt32(dtRows["idEstadoCxC"]); 
                btnNuevo1.Enabled = idEstadoCxC==2? false : true ;
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
                    txtObservacion.Text = frCxC.dtRows["cObservacion"].ToString();
                    dtpFechControl.Text = frCxC.dtRows["dFechaIniOpera"].ToString();
                    chcVigente.Checked = Convert.ToBoolean(frCxC.dtRows["lVigente"]);
                    txtSaldoAnterior.Text = frCxC.dtRows["nSaldo"].ToString();
                    txtTotalPago.Text = frCxC.dtRows["nTotalPago"].ToString();
                    EnableBoton(true);
                    buscarDetallePago(idCuentaXcobrar);                
                    btnCancelar1.Enabled = true;
                    idEstadoCxC = Convert.ToInt32(frCxC.dtRows["idEstadoCxC"]);
                    btnNuevo1.Enabled = idEstadoCxC == 2 ? false : true;
                }

            }

        }
        private void buscarDetallePago(int idCuentasXCobrar)
        {
            DataTable dtPagoCxC = cnCxc.CNListaPagoCuentasxCobrar(idCuentasXCobrar);
            dtgPagoCxC.DataSource = dtPagoCxC;

            btnExtorno1.Enabled = (dtPagoCxC.Rows.Count==0) ? false:true;        
            dtgPagoCxC.Columns["idPagoCuentasxCobrar"].Visible = false;
            dtgPagoCxC.Columns["idCuentasxCobrar"].Visible = false;
            
            dtgPagoCxC.Columns["dFechaPago"].HeaderText = "Fecha pago";
            dtgPagoCxC.Columns["dFechaPago"].Width = 130;
            dtgPagoCxC.Columns["nMontoPago"].HeaderText = "Monto pago";
            dtgPagoCxC.Columns["nMontoPago"].Width = 130;
            dtgPagoCxC.Columns["idTipoPago"].Visible = false;
            dtgPagoCxC.Columns["cDesTipoPago"].HeaderText = "Tipo pago";

        }
        private void frmRegistroCuentasXCobrar_Load(object sender, EventArgs e)
        {
            EnableBoton(true);
            btnNuevo1.Enabled = false;
            btnExtorno1.Enabled = false;
            EnableControl(false);
            limpiarGrupo();
        }

        private void dtgPagoCxC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MostrarDatosPagos();
        }
        private void MostrarDatosPagos()
        {
            //if (dtgPagoCxC.DataSource==null)
            //{
            //    return;
            //}
           
            //if (idEstadoCxC==1)
            //{
            //     DataRow dtRowsPag = ((DataRowView)dtgPagoCxC.CurrentRow.DataBoundItem).Row;
            //txtMontoPago.Text = dtRowsPag["nMontoPago"].ToString();
               
            //    dtpFechPago.Value = Convert.ToDateTime(dtRowsPag["dFechaPago"]);
            //    cboTipoPago1.SelectedValue = Convert.ToInt32(dtRowsPag["idTipoPago"]);
            //}   
           
        }
        private void btnExtorno1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de extornar el pago?","Extorno pago de cuentas por cobrar",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==System.Windows.Forms.DialogResult.Yes)
            {
                DataRow dtRowsPag = ((DataRowView)dtgPagoCxC.CurrentRow.DataBoundItem).Row;
                DataTable dtResultado;
                dtResultado = cnCxc.CNExtornaPagoCuentasxCobrar(Convert.ToInt32(dtRowsPag["idPagoCuentasxCobrar"]), 
                                    Convert.ToInt32(dtRowsPag["idCuentasXCobrar"]), Convert.ToDecimal(dtRowsPag["nMontoPago"]),
                                    clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario);
                if (dtResultado.Rows.Count > 0)
                {
                    if (dtResultado.Rows[0][0].ToString() == "1")
                    {

                        MessageBox.Show(dtResultado.Rows[0][1].ToString(), "Extorno de pago de cuentas por cobrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      
                        txtTotalPago.Text = (Convert.ToDecimal(txtTotalPago.Text) - Convert.ToDecimal(dtRowsPag["nMontoPago"])).ToString();
                        txtSaldoAnterior.Text = (Convert.ToDecimal(txtMonto.Text) + Convert.ToDecimal(dtRowsPag["nMontoPago"])).ToString();
                        buscarDetallePago(idCuentaXcobrar);
                        EnableControl(false);
                        idEstadoCxC = 1;
                    }
                    else
                    {
                        EnableBoton(false);
                        MessageBox.Show(dtResultado.Rows[0][1].ToString(), "Extorno de pago de cuentas por cobrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void dtgPagoCxC_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dtgPagoCxC_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgPagoCxC_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //MostrarDatosPagos();
        }

        private void dtgPagoCxC_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDatosPagos();
        }

        private void conBusCli_Load(object sender, EventArgs e)
        {

        }

        private void txtMontoPago_TextChanged(object sender, EventArgs e)
        {
            if (txtMontoPago.Text.Trim()=="")
            {
                return;
            }
            txtNuevoSando.Text=(Convert.ToDecimal(txtSaldoAnterior.Text)-Convert.ToDecimal(txtMontoPago.Text)).ToString();
        }
    }
}
