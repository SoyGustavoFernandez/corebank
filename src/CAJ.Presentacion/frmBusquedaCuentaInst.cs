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

namespace CAJ.Presentacion
{
    public partial class frmBusquedaCuentaInst : frmBase
    {
        clsCNMovimientoBanco objBuscarCuenta = new clsCNMovimientoBanco();
        string idTipoEntidad="%", idEntidad="%", idTipoCuenta = "%";
        string cNumeroCuenta = "";
        public int pidCuentaInstitucion,pidTipoEntidad,pidEntidad,pidAgencia, pidTipoCuenta,pidMoneda,pidEstado,pnFactorInteres ;
		public string pcEntidad,pcNumeroCuenta,pcDescripcionCuenta,pcCuentaContable;
		public DateTime  pdFechaApertura = DateTime.Today, pdFechaCancelacion=DateTime.Today;
        public string pcTEA, pcSaldoDisponible, pcSaldoContable, pcPlazo;

        public frmBusquedaCuentaInst()
        {
            InitializeComponent();
            //this.cboAgencia.Enabled = true;
            this.cboTipoEntidad.Focus();
        }

        private void frmBusquedaCuentaInst_Load(object sender, EventArgs e)
        {
            this.cboEntidad.Enabled = false;
            this.txtNumeroCuenta.Enabled = false;
            if (pidAgencia!=0)
            {
                this.cboAgencia.SelectedValue = pidAgencia;
            }
            else
            {
                this.cboAgencia.SelectedValue = Convert.ToInt32(clsVarGlobal.nIdAgencia);
            }
            
            dtgCuentasInst.DataSource = objBuscarCuenta.listarCuentas(this.cboAgencia.SelectedValue.ToString(), idTipoEntidad, idEntidad,
                                                            idTipoCuenta, cNumeroCuenta);
            formatoGrid();
            dtgCuentasInst.Focus();
        }

        private void cboTipoEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboEntidad.Enabled = true;
            idTipoEntidad = this.cboTipoEntidad.SelectedValue.ToString();
            this.cboEntidad.CargarEntidades(Convert.ToInt32(idTipoEntidad));
            dtgCuentasInst.DataSource = objBuscarCuenta.listarCuentas(this.cboAgencia.SelectedValue.ToString(), idTipoEntidad, idEntidad,
                                                            idTipoCuenta, cNumeroCuenta);
            formatoGrid();
            dtgCuentasInst.Focus();
        }        

        private void cboEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            idEntidad = this.cboEntidad.SelectedValue.ToString();
            dtgCuentasInst.DataSource = objBuscarCuenta.listarCuentas(this.cboAgencia.SelectedValue.ToString(), idTipoEntidad, idEntidad,
                                                            idTipoCuenta, cNumeroCuenta);       
            formatoGrid();
            dtgCuentasInst.Focus();
        }

        private void cboTipoCuentaBco_SelectedIndexChanged(object sender, EventArgs e)
        {
            idTipoCuenta = this.cboTipoCuentaBco.SelectedValue.ToString();
            dtgCuentasInst.DataSource = objBuscarCuenta.listarCuentas(this.cboAgencia.SelectedValue.ToString(), idTipoEntidad, idEntidad,
                                                            idTipoCuenta, cNumeroCuenta);
            formatoGrid();
            dtgCuentasInst.Focus();
        }

        private void dtgCuentasInst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                aceptar();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            aceptar();
        }

        private void aceptar()
        {
            if (dtgCuentasInst.RowCount > 0)
            {
                pidCuentaInstitucion= Convert.ToInt32(dtgCuentasInst.Rows[dtgCuentasInst.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
				pcNumeroCuenta = dtgCuentasInst.Rows[dtgCuentasInst.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
                pidTipoEntidad = Convert.ToInt32(dtgCuentasInst.Rows[dtgCuentasInst.SelectedCells[0].RowIndex].Cells[2].Value.ToString());
				pidEntidad =Convert.ToInt32(dtgCuentasInst.Rows[dtgCuentasInst.SelectedCells[0].RowIndex].Cells[3].Value.ToString());
				pidTipoCuenta = Convert.ToInt32(dtgCuentasInst.Rows[dtgCuentasInst.SelectedCells[0].RowIndex].Cells[4].Value.ToString());
				pcDescripcionCuenta = dtgCuentasInst.Rows[dtgCuentasInst.SelectedCells[0].RowIndex].Cells[5].Value.ToString();
				pidMoneda = Convert.ToInt32(dtgCuentasInst.Rows[dtgCuentasInst.SelectedCells[0].RowIndex].Cells[6].Value.ToString());
				pdFechaApertura = Convert.ToDateTime(dtgCuentasInst.Rows[dtgCuentasInst.SelectedCells[0].RowIndex].Cells[7].Value);			
				pcTEA = dtgCuentasInst.Rows[dtgCuentasInst.SelectedCells[0].RowIndex].Cells[9].Value.ToString();
				pnFactorInteres= Convert.ToInt32(dtgCuentasInst.Rows[dtgCuentasInst.SelectedCells[0].RowIndex].Cells[10].Value.ToString());
				pcPlazo = dtgCuentasInst.Rows[dtgCuentasInst.SelectedCells[0].RowIndex].Cells[11].Value.ToString();
				pcSaldoDisponible = dtgCuentasInst.Rows[dtgCuentasInst.SelectedCells[0].RowIndex].Cells[12].Value.ToString();
				pcSaldoContable = dtgCuentasInst.Rows[dtgCuentasInst.SelectedCells[0].RowIndex].Cells[13].Value.ToString();
				pcCuentaContable = dtgCuentasInst.Rows[dtgCuentasInst.SelectedCells[0].RowIndex].Cells[14].Value.ToString();
                pidEstado = Convert.ToInt32(dtgCuentasInst.Rows[dtgCuentasInst.SelectedCells[0].RowIndex].Cells[15].Value.ToString());
                pidAgencia = Convert.ToInt32(cboAgencia.SelectedValue.ToString());
                pdFechaCancelacion = Convert.ToDateTime(dtgCuentasInst.Rows[dtgCuentasInst.SelectedCells[0].RowIndex].Cells[8].Value);			
            }
            else
            {  
                MessageBox.Show("Seleccione una Cuenta", "Busqueda Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;       
            }

            this.Dispose();
        }

        private void formatoGrid()
        {
            dtgCuentasInst.Columns["idCuentaInstitucion"].Visible = false;
            dtgCuentasInst.Columns["cNumeroCuenta"].Visible = true;
            dtgCuentasInst.Columns["idTipoEntidad"].Visible = false;
            dtgCuentasInst.Columns["idEntidad"].Visible = false;
            dtgCuentasInst.Columns["idTipoCuenta"].Visible = false;
            dtgCuentasInst.Columns["cDescripcionCuenta"].Visible = false;
            dtgCuentasInst.Columns["idMoneda"].Visible = false;
            dtgCuentasInst.Columns["dFechaApertura"].Visible = false;
            dtgCuentasInst.Columns["dFechaCancelacion"].Visible = false;
            dtgCuentasInst.Columns["nTea"].Visible = false;
            dtgCuentasInst.Columns["nFactorInteres"].Visible = false;
            dtgCuentasInst.Columns["nPlazo"].Visible = false;
            dtgCuentasInst.Columns["nSaldoDisponible"].Visible = false;
            dtgCuentasInst.Columns["nSaldoContable"].Visible = false;
            dtgCuentasInst.Columns["cCuentaContable"].Visible = false;
            dtgCuentasInst.Columns["idEstado"].Visible = false;
            dtgCuentasInst.Columns["cTipoCuenta"].Visible = false;
            dtgCuentasInst.Columns["cEntidad"].Visible = true;
            dtgCuentasInst.Columns["cMoneda"].Visible = true;

            dtgCuentasInst.Columns["cNumeroCuenta"].HeaderText = "Nro.Cuenta";
            dtgCuentasInst.Columns["cTipoCuenta"].HeaderText = "Tipo Cuenta";
            dtgCuentasInst.Columns["cEntidad"].HeaderText = "Entidad";
            dtgCuentasInst.Columns["cMoneda"].HeaderText = "Moneda";

            ColorFilasGrid();
        }

        private void ColorFilasGrid()
        {
            foreach (DataGridViewRow row in dtgCuentasInst.Rows)
            {
                int idMon = Convert.ToInt16(row.Cells["idMoneda"].Value);

                if (idMon == 1)
                {
                    row.DefaultCellStyle.ForeColor = Color.Blue;
                    row.DefaultCellStyle.SelectionBackColor = Color.Blue;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Green;
                    row.DefaultCellStyle.SelectionBackColor = Color.Green;
                }
            }
        }

        private void chcBuscarCuenta_CheckedChanged(object sender, EventArgs e)
        {
            if (chcBuscarCuenta.Checked)
            {
                this.txtNumeroCuenta.Enabled = true;
                this.cboTipoEntidad.Enabled = false;
                this.cboEntidad.Enabled = false;
                this.cboTipoCuentaBco.Enabled = false;
                idTipoEntidad = "%";
                idEntidad = "%";
                idTipoCuenta = "%";
            }
            else
            {
                this.txtNumeroCuenta.Enabled = false;
                this.cboTipoEntidad.Enabled = true;
                this.cboEntidad.Enabled = true;
                this.cboTipoCuentaBco.Enabled = true;
                this.txtNumeroCuenta.Text = "";
                cNumeroCuenta = "";
            }
        }

        private void txtNumeroCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cNumeroCuenta = txtNumeroCuenta.Text;
                dtgCuentasInst.DataSource = objBuscarCuenta.listarCuentas(this.cboAgencia.SelectedValue.ToString(), idTipoEntidad, idEntidad,
                                                            idTipoCuenta, cNumeroCuenta);
                formatoGrid();
                dtgCuentasInst.Focus();
            }
        }

    }

    
}
