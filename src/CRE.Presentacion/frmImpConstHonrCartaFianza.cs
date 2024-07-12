using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRE.Presentacion
{
    public partial class frmImpConstHonrCartaFianza : frmBase
    {
        clsCNCartaFianza cnCartaFianza = new clsCNCartaFianza();
        int idCartaFianza = 0;
        bool lCuentasConKardex = false;
        DataTable dtGarantias = new DataTable();
        double nTotal;
        DataTable dtCartaFianza;
        
        public frmImpConstHonrCartaFianza()
        {
            InitializeComponent();
        }

        #region eventos
        private void frmImpConstHonrCartaFianza_Load(object sender, EventArgs e)
        {
            this.conBusCuentaCli1.cTipoBusqueda = "F";
            this.conBusCuentaCli1.cEstado = "[8]";
            this.conBusCuentaCli1.MyClic += conBusCuentaCli1_MyClic;
            this.conBusCuentaCli1.MyKey += conBusCuentaCli1_MyClic;
            this.conBusCuentaCli1.lblNroBuscar.Text = "Nro de carta fianza";
            habilitarControles(false);
            
            
        }

        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.conBusCuentaCli1.txtNroBusqueda.Text))
            {
                idCartaFianza = Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text);
                cargar();

            }
            else
            {
                limpiar();
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            habilitarControles(false);
            limpiar();
        }

        private void btnMiniBusq1_Click(object sender, EventArgs e)
        {
            frmListarMovimientosCuenta frmListarMovimientosCuenta = new frmListarMovimientosCuenta();
            int idSeleccionado = dtgCuentasGarantias.SelectedRows[0].Index;
            frmListarMovimientosCuenta.cNroCuenta = dtgCuentasGarantias.Rows[idSeleccionado].Cells["cNroCuenta"].Value.ToString();
            frmListarMovimientosCuenta.ShowDialog();
            if (frmListarMovimientosCuenta.lAceptar)
            {
                int idKardex = frmListarMovimientosCuenta.idKardex;
                double nMonto = frmListarMovimientosCuenta.nMonto;
                DateTime dFechaAfectacion = frmListarMovimientosCuenta.dFechaAfectacion;
                dtgCuentasGarantias.Rows[idSeleccionado].Cells["idKardex"].Value = idKardex;
                dtgCuentasGarantias.Rows[idSeleccionado].Cells["nMontoPagado"].Value = nMonto.ToString("0.00");
                dtgCuentasGarantias.Rows[idSeleccionado].Cells["dFechaAfectacion"].Value = dFechaAfectacion.ToString("dd/MM/yyyy");
                calcularTotal();
            }
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();
                
                GEN.Funciones.clsNumLetras numLetras = new GEN.Funciones.clsNumLetras();

                double nMonto = Convert.ToDouble(dtCartaFianza.Rows[0]["nMontoCartaFianza"].ToString());
                paramlist.Clear();
                paramlist.Add(new ReportParameter("cMontoEnLetras", numLetras.ToCustomCardinal(nMonto).ToUpper(), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                dtslist.Clear();
                dtslist.Add(new ReportDataSource("dsDatosCartaFianza", dtCartaFianza));
                dtslist.Add(new ReportDataSource("dsGarantias", dtGarantias));                

                string reportpath = "rptConstanciaCancCartFianza.rdlc";               

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();                
            }
        }

        private void dtgCuentasGarantias_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnMiniBusq1.Enabled = (dtgCuentasGarantias.Rows[e.RowIndex].Cells["cNroCuenta"].Value.ToString() != "-");
                //btnMiniBusq1.Enabled = (dtgCuentasGarantias.CurrentRow.Cells["cNroCuenta"].Value.ToString() != "-");
            }
        }
        #endregion

        #region metodos
        private bool validar()
        {
            if (!lCuentasConKardex)
            {
                MessageBox.Show("No todas la cuentas tiene un kardex relacionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (nTotal > Convert.ToDouble(txtMontoAprobado.Text))
            {
                MessageBox.Show("El monto total debe ser menor o igual al monto de la carta fianza", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void calcularTotal()
        {
            nTotal = 0.00;
            lCuentasConKardex = true;
            foreach (DataRow row in dtGarantias.Rows)
            {
                nTotal += Convert.ToDouble(row["nMontoPagado"]);
                if (Convert.ToInt32(row["idKardex"]) == 0 && row["cNroCuenta"].ToString() != "-")
                {
                    lCuentasConKardex = false;
                }
            }
            txtTotalSumado.Text = nTotal.ToString("0.00");
        }

        private void habilitarControles(bool lHabilitar)
        {
            this.conBusCuentaCli1.Enabled = !lHabilitar;
            this.conBusCuentaCli1.btnBusCliente1.Enabled = !lHabilitar;
            this.conBusCuentaCli1.txtNroBusqueda.Enabled = !lHabilitar;
            btnCancelar1.Enabled = lHabilitar;
            btnImprimir1.Enabled = lHabilitar;
            btnMiniBusq1.Enabled = lHabilitar;
        }

        private void limpiar()
        {
            this.conBusCuentaCli1.limpiarControles();
            this.conBusCuentaCli1.txtNroBusqueda.Focus();
            txtCartaFianza.Clear();
            txtMontoAprobado.Clear();
            txtFechaCancelacion.Clear();
            txtMoneda.Clear();
            dtgCuentasGarantias.DataSource = null;            
        }
        
        private void cargar()
        {
            dtCartaFianza = cnCartaFianza.obtenerCartaFianzaCancelada(idCartaFianza);
            if (dtCartaFianza.Rows.Count > 0)
            {
                txtCartaFianza.Text = dtCartaFianza.Rows[0]["nroCartaFianza"].ToString();
                txtMontoAprobado.Text = dtCartaFianza.Rows[0]["nMontoCartaFianza"].ToString();
                txtFechaCancelacion.Text = dtCartaFianza.Rows[0]["dFechaCancelacion"].ToString();
                txtMoneda.Text = dtCartaFianza.Rows[0]["cMoneda"].ToString();

                dtGarantias = cnCartaFianza.obtenerGarantiasDetalle(idCartaFianza, true);
                if (dtGarantias.Rows.Count > 0)
                {
                    dtGarantias.Columns["idKardex"].ReadOnly = false;
                    dtGarantias.Columns["nMontoPagado"].ReadOnly = false;
                    dtGarantias.Columns["dFechaAfectacion"].ReadOnly = false;
                    habilitarControles(true);
                    dtgCuentasGarantias.DataSource = dtGarantias;
                    formtearDtgCuentaGarantias();                    
                    calcularTotal();            
                    
                }
                //habilitarControles(false);
            }
            else
            {
                habilitarControles(false);
                limpiar();
            }
        }

        private void formtearDtgCuentaGarantias()
        {
            foreach (DataGridViewColumn column in dtgCuentasGarantias.Columns)
            {
                column.Visible = false;
            }

            dtgCuentasGarantias.Columns["cNroCuenta"].Visible = true;
            dtgCuentasGarantias.Columns["cTitular"].Visible = true;
            dtgCuentasGarantias.Columns["nMontoGrabado"].Visible = true;
            dtgCuentasGarantias.Columns["idKardex"].Visible = true;
            dtgCuentasGarantias.Columns["nMontoPagado"].Visible = true;
            dtgCuentasGarantias.Columns["dFechaAfectacion"].Visible = true;

            dtgCuentasGarantias.Columns["cNroCuenta"].HeaderText = "Nro. Cuenta";
            dtgCuentasGarantias.Columns["cTitular"].HeaderText = "Titular";
            dtgCuentasGarantias.Columns["nMontoGrabado"].HeaderText = "Monto";
            dtgCuentasGarantias.Columns["idKardex"].HeaderText = "Kardex";
            dtgCuentasGarantias.Columns["nMontoPagado"].HeaderText = "Monto Retirado";
            dtgCuentasGarantias.Columns["dFechaAfectacion"].HeaderText = "Fecha Afectado";

            dtgCuentasGarantias.Columns["cNroCuenta"].Width = 120;
            dtgCuentasGarantias.Columns["cTitular"].Width = 100;
            dtgCuentasGarantias.Columns["nMontoGrabado"].Width = 70;
            dtgCuentasGarantias.Columns["idKardex"].Width = 40;
            dtgCuentasGarantias.Columns["nMontoPagado"].Width = 50;
            dtgCuentasGarantias.Columns["dFechaAfectacion"].Width = 70;

            dtgCuentasGarantias.ReadOnly = false;
            dtgCuentasGarantias.Columns["cNroCuenta"].ReadOnly = true;
            dtgCuentasGarantias.Columns["cTitular"].ReadOnly = true;
            dtgCuentasGarantias.Columns["nMontoGrabado"].ReadOnly = true;
            dtgCuentasGarantias.Columns["idKardex"].ReadOnly = true;
            dtgCuentasGarantias.Columns["nMontoPagado"].ReadOnly = true;
            dtgCuentasGarantias.Columns["dFechaAfectacion"].ReadOnly = true;
        }

        #endregion


    }
}
