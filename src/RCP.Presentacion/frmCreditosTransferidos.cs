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
using RCP.CapaNegocio;
using Microsoft.Reporting.WinForms;
using EntityLayer;

namespace RCP.Presentacion
{
    public partial class frmCreditosTransferidos : frmBase
    {
        clsCNTranferencias cnTranferencias = new clsCNTranferencias();
        int idAsignacion = -1;
        int idCuentaSeleccionada = 0;

        public frmCreditosTransferidos()
        {
            InitializeComponent();
        }

        private void frmCreditosTransferidos_Load(object sender, EventArgs e)
        {
            limpiar();
            CargarCreditos();
            habilitarControles(false);
            LimpiarDatCred();
            btnNuevo1.Enabled = dtgCreditosTransferidos.RowCount > 0;
        }

        private void dtgCreditosTransferidos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idAsignacion = Convert.ToInt32(dtgCreditosTransferidos.Rows[e.RowIndex].Cells["idAsigCartRecuperaciones"].Value.ToString());
                idCuentaSeleccionada = Convert.ToInt32(dtgCreditosTransferidos.Rows[e.RowIndex].Cells["idCuenta"].Value.ToString());
                txtCuenta.Text = dtgCreditosTransferidos.Rows[e.RowIndex].Cells["idCuenta"].Value.ToString();
                txtCodCliente.Text = dtgCreditosTransferidos.Rows[e.RowIndex].Cells["idCli"].Value.ToString();
                txtNombreCliente.Text = dtgCreditosTransferidos.Rows[e.RowIndex].Cells["cNombre"].Value.ToString();
                txtSaldoCapital.Text = dtgCreditosTransferidos.Rows[e.RowIndex].Cells["cMoneda"].Value.ToString() + " " + dtgCreditosTransferidos.Rows[e.RowIndex].Cells["nSaldoCapital"].Value.ToString();
                txtTotalPagar.Text = dtgCreditosTransferidos.Rows[e.RowIndex].Cells["cMoneda"].Value.ToString() + " " + dtgCreditosTransferidos.Rows[e.RowIndex].Cells["nTotalPagar"].Value.ToString();
                txtAtraso.Text = dtgCreditosTransferidos.Rows[e.RowIndex].Cells["nAtraso"].Value.ToString();
                txtUbigeo.Text = dtgCreditosTransferidos.Rows[e.RowIndex].Cells["nUbigeo"].Value.ToString();
            }
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                DataTable dtResultado = cnTranferencias.ActualizarGlosa(idCuentaSeleccionada, idAsignacion, txtOpinionTransferencia.Text.Trim(), Convert.ToInt32(cboMotivoMora1.SelectedValue), txtObservaciones.Text.Trim(), clsVarGlobal.dFecSystem, true,clsVarGlobal.User.idUsuario);
                if (dtResultado.Rows.Count > 0 && Convert.ToInt32(dtResultado.Rows[0][0]) == 0)
                {
                    int idInfPaseRecuperaciones = Convert.ToInt32(dtResultado.Rows[0]["idInfPaseRecuperaciones"]);
                    DataTable dtCreditoTransferido = cnTranferencias.ObtenerCreditoTransferido(idInfPaseRecuperaciones);
                    DataTable dtIntervinientes = cnTranferencias.ListarIntervinientes(Convert.ToInt32(dtCreditoTransferido.Rows[0]["idSolicitud"]));
                    DataTable dtGestiones = cnTranferencias.listarGestiones(Convert.ToInt32(txtCuenta.Text));
                    DataTable dtPromesas = cnTranferencias.listarPromesas(Convert.ToInt32(txtCuenta.Text));

                    List<ReportDataSource> dtslist = new List<ReportDataSource>();
                    List<ReportParameter> paramlist = new List<ReportParameter>();
                    paramlist.Clear();
                    paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                    paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
                    paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));

                    dtslist.Clear();
                    dtslist.Add(new ReportDataSource("dsGestiones", dtGestiones));
                    dtslist.Add(new ReportDataSource("dsPromesas", dtPromesas));
                    dtslist.Add(new ReportDataSource("dsCredito", dtCreditoTransferido));
                    dtslist.Add(new ReportDataSource("dsInterviniente", dtIntervinientes));

                    string reportpath = "rptInformeTransferencia.rdlc";
                    new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                    //imprimir formato
                    dtgCreditosTransferidos.Enabled = true;
                    limpiar();
                    CargarCreditos();
                    LimpiarDatCred();
                    dtgCreditosTransferidos.Focus();
                    habilitarControles(false);
                    btnNuevo1.Enabled = dtgCreditosTransferidos.RowCount > 0;
                }
            }
        }

        public bool validar()
        {
            if (txtOpinionTransferencia.Text.Trim().Length <= 0)
            {
                MessageBox.Show("De de ingresar Opinión de transferencia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtOpinionTransferencia.Focus();
                return false;
            }
            if (cboMotivoMora1.SelectedIndex < 0)
            {
                MessageBox.Show("De de ingresar Factor de mora", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboMotivoMora1.Focus();
                return false;
            }
            if (txtObservaciones.Text.Trim().Length <= 0)
            {
                MessageBox.Show("De de ingresar Observación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtObservaciones.Focus();
                return false;
            }

            return true;
        }

        public void limpiar()
        {
            txtOpinionTransferencia.Text = String.Empty;
            txtObservaciones.Text = String.Empty;
            cboMotivoMora1.SelectedIndex = -1;
        }

        private void CargarCreditos()
        {
            dtgCreditosTransferidos.DataSource = cnTranferencias.ListaCredTransfUsuario(clsVarGlobal.User.idUsuario);
        }

        public void habilitarControles(bool habilitar)
        {
            txtOpinionTransferencia.Enabled = habilitar;
            txtObservaciones.Enabled = habilitar;
            cboMotivoMora1.Enabled = habilitar;
            btnNuevo1.Enabled = !habilitar;
            btnCancelar1.Enabled = habilitar;
            btnGrabar1.Enabled = habilitar;

            if (dtgCreditosTransferidos.Rows.Count <= 0)
            {
                btnNuevo1.Enabled = false;
            }
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            habilitarControles(true);
            dtgCreditosTransferidos.Enabled = false;
        }

        private void LimpiarDatCred()
        {
            txtCuenta.Text = String.Empty;
            txtCodCliente.Text = String.Empty;
            txtNombreCliente.Text = String.Empty;
            txtSaldoCapital.Text = String.Empty;
            txtTotalPagar.Text = String.Empty;
            txtAtraso.Text = String.Empty;
            txtUbigeo.Text = String.Empty;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            habilitarControles(false);
            dtgCreditosTransferidos.Enabled = true;
            limpiar();
            LimpiarDatCred();
            dtgCreditosTransferidos.Focus();
            btnNuevo1.Enabled = dtgCreditosTransferidos.RowCount > 0;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            new frmGenInformeAsesor().ShowDialog();
        }
    }
}
