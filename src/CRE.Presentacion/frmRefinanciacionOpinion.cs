using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using CRE.CapaNegocio;
using GEN.CapaNegocio;
using Microsoft.Reporting.WinForms;
using GEN.Servicio;
using DEP.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmRefinanciacionOpinion : frmBase
    {
        #region Variable Globales

        clsCNSolicitudAmortiza cnsolicitudamortiza = new clsCNSolicitudAmortiza();
        clsCNRetornsCuentaSolCliente cncuentasolcli = new clsCNRetornsCuentaSolCliente();
        CRE.CapaNegocio.clsCNCredito cncredito = new CapaNegocio.clsCNCredito();
        clsCNDirecCli cndireccion = new clsCNDirecCli();
        int idSolicitud=0;
        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();
        private string tmpTextoBuscar = "";
        private int rowIndex = -1;
        #endregion

        public frmRefinanciacionOpinion()
        {
            InitializeComponent();
        }

        #region Eventos

        private void frmBase_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this, EventoFormulario.INICIO);
            cargarSolicitudes();
            cargarDatosSolicitud();
        }

        private void dtgSolicitudRefinanciacion_SelectionChanged(object sender, EventArgs e)
        {
            cargarDatosSolicitud();
        }

        private void dtgCreditosVinculados_SelectionChanged(object sender, EventArgs e)
        {
            //cargarIntervinientes();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (!rbtSI.Checked && !rbtNO.Checked)
            {
                MessageBox.Show("Se debe seleccionar la Decisión a la solicitud", "Registro de opinión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtConclusion.Text == "")
            {
                MessageBox.Show("Se registrar una Opinión de la Decisión a la solicitud", "Registro de opinión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult drResultado = MessageBox.Show("Esta seguro de continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResultado == DialogResult.Yes && validar())
            {
                idSolicitud = (int)dtgSolicitudRefinanciacion.SelectedRows[0].Cells["idSolicitud"].Value;
                DataTable dtRes = cnsolicitudamortiza.CNInsertarOpinionRefinanciacion(idSolicitud, rbtSI.Checked, txtConclusion.Text.Trim());

                if (Convert.ToInt32(dtRes.Rows[0]["idError"]) == 0)
                {
                    MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Registro de opinión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(dtRes.Rows[0]["cMensaje"].ToString(), "Registro de opinión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                /*  Guardar Expedientes - Grupo Opinion de recuperaciones  */
                clsProcesoExp.guardarCopiaExpediente("Opinion de Recuperaciones", idSolicitud, this);

                imprimir();
                limpiar();
                cargarSolicitudes();
                cargarDatosSolicitud();

                grbOpinion.Enabled = false;
                dtgSolicitudRefinanciacion.Enabled = true;
                
            }
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            limpiar();
            btnNuevo1.Enabled = false;
            btnCancelar1.Enabled = true;
            btnGrabar1.Enabled = true;
            grbOpinion.Enabled = true;
            dtgSolicitudRefinanciacion.Enabled = false;
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            btnNuevo1.Enabled = true;
            btnCancelar1.Enabled = false;
            btnGrabar1.Enabled = false;
            grbOpinion.Enabled = false;
            dtgSolicitudRefinanciacion.Enabled = true;
            limpiar();
        }

        private void imprimir()
        {
            string reportpath = "rptOpinionRefinanciacion.rdlc";

            List<ReportDataSource> lisData = new List<ReportDataSource>();
            List<ReportParameter> lisParametros = new List<ReportParameter>();

            lisParametros.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            lisParametros.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            lisParametros.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));

            lisData.Add(new ReportDataSource("dsOpinion", cnsolicitudamortiza.CNrptOpinionRefinanciacion(idSolicitud)));
            new frmReporteLocal(lisData, reportpath, lisParametros).ShowDialog();

            btnNuevo1.Enabled = true;
        }

        private void buscarTexto()
        {
            bool lEncontrado = false;
            if (tmpTextoBuscar != txtBuscar.Text)
            {
                rowIndex = 0;
                tmpTextoBuscar = txtBuscar.Text;
            }

            for (int i = 0; i < dtgSolicitudRefinanciacion.Rows.Count; i++)
            {
                if (dtgSolicitudRefinanciacion.Rows[rowIndex].Cells["idSolicitud"].Value.ToString().ToUpper().Contains(txtBuscar.Text.ToUpper())
                    || dtgSolicitudRefinanciacion.Rows[rowIndex].Cells["idCli"].Value.ToString().ToUpper().Contains(txtBuscar.Text.ToUpper())
                    || dtgSolicitudRefinanciacion.Rows[rowIndex].Cells["cNombre"].Value.ToString().ToUpper().Contains(txtBuscar.Text.ToUpper())
                    )
                {
                    dtgSolicitudRefinanciacion.Rows[rowIndex].Selected = true;
                    dtgSolicitudRefinanciacion.FirstDisplayedScrollingRowIndex = rowIndex;
                    lEncontrado = true;
                }

                rowIndex++;
                if (dtgSolicitudRefinanciacion.Rows.Count == rowIndex)
                {
                    rowIndex = 0;
                }

                if (lEncontrado)
                {
                    break;
                }
            }

            if (!lEncontrado)
            {
                MessageBox.Show("No se ha encontrado coincidencias en la búsqueda","Buscar texto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rowIndex = 0;
            }
        }
        #endregion

        #region Métodos

        private void cargarSolicitudes()
        {
            btnGrabar1.Enabled = false;
            btnCancelar1.Enabled = false;

            dtgSolicitudRefinanciacion.DataSource = null;
            dtgCreditosVinculados.DataSource = null;
            dtgIntervinientes.DataSource = null;

            var dtSolicitudes = cnsolicitudamortiza.CNLisSolOpinionRecupera();
            if (dtSolicitudes.Rows.Count > 0)
            {
                dtgSolicitudRefinanciacion.DataSource = dtSolicitudes;
                formatoGridSolicitudes();
                btnNuevo1.Enabled = true;
            }
            else
            {
                btnNuevo1.Enabled = false;
            }
        }

        private void cargarDatosSolicitud()
        {
            if (dtgSolicitudRefinanciacion.SelectedRows.Count > 0)
            {
                var idCli = Convert.ToInt32(dtgSolicitudRefinanciacion.SelectedRows[0].Cells["idCli"].Value);
                int idOperacion = Convert.ToInt32(dtgSolicitudRefinanciacion.SelectedRows[0].Cells["idOperacion"].Value);
                int idSolicitud = Convert.ToInt32(dtgSolicitudRefinanciacion.SelectedRows[0].Cells["idSolicitud"].Value);
                var idTipoPersona = Convert.ToInt32(dtgSolicitudRefinanciacion.SelectedRows[0].Cells["IdTipoPersona"].Value);

                DataTable dtDatosCli = new clsCNBuscarCli().ListarclixIdCli(idCli);
                if (dtDatosCli.Rows.Count > 0)
                {
                    txtCodCli.Text = dtDatosCli.Rows[0]["idCli"].ToString();
                    txtDocumento.Text = dtDatosCli.Rows[0]["cDocumentoID"].ToString();
                    txtNombre.Text = dtDatosCli.Rows[0]["cNombre"].ToString();
                    txtDireccion.Text = dtDatosCli.Rows[0]["cDireccion"].ToString();
                }

                DataTable dtDepositos = new clsCNDeposito().CNConsultaDeposito(idCli, "[1]");
                txtNroDepositos.Text = dtDepositos.Rows.Count.ToString();

                var dtCuentasCredito = cncuentasolcli.CNRetDetCuentasVinculadasxSoli(idSolicitud);
                if (dtCuentasCredito.Rows.Count > 0)
                {
                    dtgCreditosVinculados.DataSource = dtCuentasCredito;
                    formatoGridCreditos();
                }
                else
                {
                    dtgCreditosVinculados.DataSource = null;
                }

                cargarIntervinientes(idSolicitud);

            }
        }

        private void cargarIntervinientes(int idSolicitud)
        {
            if (dtgCreditosVinculados.SelectedRows.Count > 0)
            {
                var dtInterviniente = cncredito.DetalleImpPagare(idSolicitud);
                if (dtInterviniente.Rows.Count > 0)
                {
                    dtgIntervinientes.DataSource = dtInterviniente;
                    formatoGridInterviniente();
                }
            }
        }

        private bool validar()
        {
            bool lValida = false;

            if (dtgSolicitudRefinanciacion.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una solicitud", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValida;
            }

            if (!rbtSI.Checked && !rbtNO.Checked)
            {
                MessageBox.Show("Seleccione si cliente tiene voluntad de pago", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValida;
            }

            if (string.IsNullOrEmpty(this.txtConclusion.Text))
            {
                MessageBox.Show("Debe de registrar las conclusiones", "Validación de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConclusion.Focus();
                return lValida;
            }

            lValida = true;
            return lValida;
        }

        private void formatoGridSolicitudes()
        {
            foreach (DataGridViewColumn item in dtgSolicitudRefinanciacion.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgSolicitudRefinanciacion.Columns["idTipoPeriodo"].Visible = false;
            dtgSolicitudRefinanciacion.Columns["idMoneda"].Visible = false;
            dtgSolicitudRefinanciacion.Columns["IdTipoPersona"].Visible = false;
            dtgSolicitudRefinanciacion.Columns["idOperacion"].Visible = false;

            dtgSolicitudRefinanciacion.Columns["idSolicitud"].HeaderText = "Cod.Sol.";
            dtgSolicitudRefinanciacion.Columns["idCli"].HeaderText = "Cod.Cli.";
            dtgSolicitudRefinanciacion.Columns["cNombre"].HeaderText = "Nombres/Razón Social";
            dtgSolicitudRefinanciacion.Columns["cProducto"].HeaderText = "Producto";
            dtgSolicitudRefinanciacion.Columns["nCapitalSolicitado"].HeaderText = "Monto";
            dtgSolicitudRefinanciacion.Columns["nCuotas"].HeaderText = "Cuotas";
            dtgSolicitudRefinanciacion.Columns["nPlazoCuota"].HeaderText = "Plazo";
            dtgSolicitudRefinanciacion.Columns["nTasaCompensatoria"].HeaderText = "Tasa";
            dtgSolicitudRefinanciacion.Columns["cDescripTipoPeriodo"].HeaderText = "Tipo";
            dtgSolicitudRefinanciacion.Columns["cMoneda"].HeaderText = "Moneda";

            asignarColorSeleccion();

        }

        private void asignarColorSeleccion()
        {
            foreach (DataGridViewRow row in dtgSolicitudRefinanciacion.Rows)
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

        private void formatoGridCreditos()
        {
            foreach (DataGridViewColumn item in dtgCreditosVinculados.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgCreditosVinculados.Columns["cWinUser"].Visible = false;
            dtgCreditosVinculados.Columns["IdMoneda"].Visible = false;
            dtgCreditosVinculados.Columns["idProducto"].Visible = false;
            dtgCreditosVinculados.Columns["idSolCre"].Visible = false;

            dtgCreditosVinculados.Columns["idCuenta"].HeaderText = "Cod.Cta";
            dtgCreditosVinculados.Columns["idCli"].HeaderText = "Cod.Cli.";
            dtgCreditosVinculados.Columns["idSolicitud"].HeaderText = "Cod.solicitud";
            dtgCreditosVinculados.Columns["dFecDesembolso"].HeaderText = "Fec.Desembolso";
            dtgCreditosVinculados.Columns["nCapitalDesembolso"].HeaderText = "Capital";
            dtgCreditosVinculados.Columns["nCuotas"].HeaderText = "Cuotas";
            dtgCreditosVinculados.Columns["cProducto"].HeaderText = "Producto";
            dtgCreditosVinculados.Columns["cMoneda"].HeaderText = "Moneda";
            dtgCreditosVinculados.Columns["nAtraso"].HeaderText = "Atraso";
            dtgCreditosVinculados.Columns["nSaldoCapital"].HeaderText = "Sal.Capital";
            dtgCreditosVinculados.Columns["nSaldoTotal"].HeaderText = "Saldo Total";
        }

        private void formatoGridInterviniente()
        {
            foreach (DataGridViewColumn item in dtgIntervinientes.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }

            dtgIntervinientes.Columns["idCli"].Visible = true;
            dtgIntervinientes.Columns["cNombre"].Visible = true;
            dtgIntervinientes.Columns["cDocumentoID"].Visible = true;
            dtgIntervinientes.Columns["cTipoIntervencion"].Visible = true;

            dtgIntervinientes.Columns["idCli"].HeaderText = "Cod.Cli.";
            dtgIntervinientes.Columns["cNombre"].HeaderText = "Nombres";
            dtgIntervinientes.Columns["cDocumentoID"].HeaderText = "Documento";
            dtgIntervinientes.Columns["cTipoIntervencion"].HeaderText = "Interviene";

            dtgIntervinientes.Columns["idCli"].Width = 70;
            dtgIntervinientes.Columns["cDocumentoID"].Width = 100;
            dtgIntervinientes.Columns["cTipoIntervencion"].Width = 100;
            dtgIntervinientes.Columns["cTipoIntervencion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void limpiar()
        {
            idSolicitud = 0;
            rbtNO.Checked = false;
            rbtSI.Checked = false;
            txtDireccion.Clear();
            txtConclusion.Clear();
            txtCodCli.Clear();
            txtDocumento.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtNroDepositos.Clear();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buscarTexto();
            }
        }

        private void btnSig_Click(object sender, EventArgs e)
        {
            buscarTexto();
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            if (dtgSolicitudRefinanciacion.SelectedRows.Count > 0)
            {
                int idSolicitud = (int)dtgSolicitudRefinanciacion.SelectedRows[0].Cells["idSolicitud"].Value;
                int idCli = (int)dtgSolicitudRefinanciacion.SelectedRows[0].Cells["idCli"].Value;
                frmExpedienteLinea frmExpdte = new frmExpedienteLinea(idSolicitud, idCli, "individual");
                frmExpdte.ShowDialog();
            }
        }
        #endregion
    }
}
