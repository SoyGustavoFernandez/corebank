using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAJ.CapaNegocio;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.BotonesBase;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmCobroCreditosDctoPlanilla : frmBase
    {

        #region Variables

        public const int idTipoOperacion = 2;
        clsCNCredito objCredito = new clsCNCredito();

        private DataTable dtDsctoPlanilla = new DataTable();
        private DataTable dtLisCrexAna = new DataTable();
        private int nIdAse = -1;

        #endregion

        #region Eventos

        private void frmCobroCreditosDctoPlanilla_Load(object sender, EventArgs e)
        {
            // Agregar Columnas a tabla dtDsctoPlanilla
            dtDsctoPlanilla.Columns.Add("cCodEmpleado", typeof(string));
            dtDsctoPlanilla.Columns.Add("nMontoDscto", typeof(Decimal));

            // Validar Inicio de Operaciones
            ////////if (this.ValidarInicioOpe() != "A")
            ////////{
            ////////    this.Dispose();
            ////////    return;
            ////////}
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            btnImportar.Enabled = false;

            string cNomArchivo;
            int nLineas = 0;
            string cRegistro;
            dtDsctoPlanilla.Clear();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                cNomArchivo = System.IO.Path.GetFullPath(openFileDialog.FileName).Trim();
            }
            else
            {
                return;
            }

            StreamReader objArchivo = new StreamReader(@cNomArchivo);
            while ((cRegistro = objArchivo.ReadLine()) != null)
            {
                string[] campos = cRegistro.Split('|');

                if (campos.Length == 3)
                {
                    dtDsctoPlanilla.Rows.Add(campos[0].Replace(@"""", ""), Convert.ToDecimal(campos[2].Replace(@"""", "")) / 100);

                    nLineas++;
                }
            }

            objArchivo.Close();

            DataSet dsDsctoPlanilla = new DataSet("dsDsctoPlanilla");
            dsDsctoPlanilla.Tables.Add(dtDsctoPlanilla);
            string xmlDsctoPlanilla = dsDsctoPlanilla.GetXml();

            int idConvenio = Convert.ToInt32(cboConvenio.SelectedValue);

            dtLisCrexAna = objCredito.CNListarPagoDctoPlanilla(dtpFecVen.Value.Date, xmlDsctoPlanilla, clsVarGlobal.User.idUsuario, idConvenio);
            if (dtLisCrexAna.Rows.Count <= 0)
            {
                MessageBox.Show("No existen créditos activos", "Cobros Masivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dtLisCrexAna.Columns["nMonPagCuota"].ReadOnly = false;
            dtLisCrexAna.Columns["lSeleCta"].ReadOnly = false;

            foreach (DataRow item in dtLisCrexAna.Rows)
            {
                item["lSeleCta"] = true;
            }

            nIdAse = 0;

            dtgPagoCreditosConvenio.DataSource = dtLisCrexAna;
            this.dtgPagoCreditosConvenio.Enabled = true;
            this.dtgPagoCreditosConvenio.ReadOnly = false;
            this.FormatoGrid();
            this.HabilitarGrid(true);
            //this.cboMoneda1.Enabled = false;
            if (dtLisCrexAna.Rows.Count > 0)
            {
                this.btnGrabar.Enabled = true;
            }
            this.btnCancelar.Enabled = true;
            //Restringir la cantidad de dígitos a 10
            ((DataGridViewTextBoxColumn)dtgPagoCreditosConvenio.Columns["nMonPagCuota"]).MaxInputLength = 9;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.dtgPagoCreditosConvenio.Enabled = false;
            this.dtgPagoCreditosConvenio.ReadOnly = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;
            btnImprimir.Enabled = false;
            btnImportar.Enabled = true;
            conPagoBcos.Enabled = true;
            cboConvenio.Enabled = true;
            dtpFecVen.Enabled = true;

            conPagoBcos.CargaEntidad(4);
            conPagoBcos.LimpiarControles();

            this.dtgPagoCreditosConvenio.DataSource = "";
            this.txtTotalPago.Text = "";
            this.txtTotalCreditos.Text = "";

            this.txtTotalPago.Visible = true;
            this.txtTotalCreditos.Visible = true;
            LiberarCuenta();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            clsCNPlanPago PlanPago = new clsCNPlanPago();
            DataTable dtPlanPago = new DataTable("dtPlanPago");
            DataTable dtPlanPagado = new DataTable("dtPlanPagado");
            Decimal nPagaDeuda = 0.00m;
            int nNumCredito = 0;

            if (!validapago())
            {
                return;
            }

            btnGrabar.Enabled = false;
            conPagoBcos.Enabled = false;
            cboConvenio.Enabled = false;
            cboTipoPago.Enabled = false;
            cboMotivoOperacion.Enabled = false;
            dtpFecVen.Enabled = false;
            for (int i = 0; i < dtLisCrexAna.Rows.Count; i++)
            {
                bool lSeleCta = Convert.ToBoolean(dtLisCrexAna.Rows[i]["lSeleCta"]);
                if (!lSeleCta)
                {
                    continue;
                }
                nPagaDeuda = Convert.ToDecimal (dtLisCrexAna.Rows[i]["nMonPagCuota"]);
                if ((nPagaDeuda) <= 0)
                {
                    continue;
                }
                nNumCredito = Convert.ToInt32(dtLisCrexAna.Rows[i]["idCuenta"]);
                dtPlanPago = PlanPago.CNdtPlanPago(nNumCredito);
                if (nPagaDeuda > 0)
                {
                    dtPlanPagado = PlanPago.dtCNPagoDistribuido(dtPlanPago, nPagaDeuda, true);
                    var nCapitalPag = Convert.ToDecimal (dtPlanPagado.Rows[0]["nCapitalPag"].ToString());
                    var nInteresPag = Convert.ToDecimal (dtPlanPagado.Rows[0]["nInteresPag"].ToString());
                    var nMoraPag = Convert.ToDecimal (dtPlanPagado.Rows[0]["nMoraPag"].ToString());
                    var nOtrosPag = Convert.ToDecimal (dtPlanPagado.Rows[0]["nOtrosPag"].ToString());

                    DataSet ds = new DataSet("dsPlanPagos");
                    dtPlanPago.TableName = "dtPlanPagos";
                    ds.Tables.Add(dtPlanPago);
                    string xmlPpg = ds.GetXml();
                    Decimal nMonRedondeo = 0.00m;
                    Decimal nImpuesto = 0.00m;
                    decimal nITFNormal = 0.00m;
                    int idTipoPago = Convert.ToInt16(cboTipoPago.SelectedValue), idCtaEntidad = 0, idEntidad = 0;
                    string cNroTrx = "";

                    if (Convert.ToInt16(cboConvenio.SelectedValue) == 1)
                    {
                        idCtaEntidad = clsVarGlobal.dFecSystem.Year;
                        idEntidad = clsVarGlobal.dFecSystem.Month;
                        cNroTrx = clsVarGlobal.dFecSystem.Year.ToString() + "/" + clsVarGlobal.dFecSystem.Month.ToString();
                    }
                    else
                    {
                        idCtaEntidad = conPagoBcos.idCuenta;
                        idEntidad = conPagoBcos.idEntidad;
                        cNroTrx = conPagoBcos.cNroTrx;
                    }

                    DataTable TablaUpPpg = PlanPago.UpCobroPpg(PpgXml: xmlPpg, 
                                                                dFecSis: clsVarGlobal.dFecSystem,
                                                                nUsuSis: clsVarGlobal.User.idUsuario,
                                                                nIdAgencia: clsVarGlobal.nIdAgencia, 
                                                                nMoraPagada: nMoraPag, 
                                                                idCuenta: nNumCredito, 
                                                                idCanal: clsVarGlobal.idCanal, 
                                                                nMonRedondeo: nMonRedondeo, 
                                                                nImpuesto: nImpuesto, 
                                                                nITFNormal: nITFNormal, 
                                                                idTipoPago: idTipoPago, 
                                                                idEntidad: idEntidad, 
                                                                idCtaEntidad: idCtaEntidad, 
                                                                cNroTrx: cNroTrx,
                                                                idMotivoOperacion: Convert.ToInt32(cboMotivoOperacion.SelectedValue),
                                                                cXmlCobs: " ",
                                                                lModificaSaldoLinea: false,
                                                                idTipoTransac: 0,
                                                                idMoneda: 1,
                                                                nMontoOpe: 0);
                    ds.Dispose();
                }
            }
            MessageBox.Show("Cobro en Lote Realizado Satisfactoriamente", "Cobro en Lote", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LiberarCuenta();
            btnImprimir.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            LiberarCuenta();
        }

        private void frmCobroCreditosDctoPlanilla_FormClosed(object sender, FormClosedEventArgs e)
        {
            LiberarCuenta();
        }

        private void dtgPagoCreditosConvenio_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Int32 fila = Convert.ToInt32(this.dtgPagoCreditosConvenio.SelectedCells[0].RowIndex);
            dtgPagoCreditosConvenio.CurrentCell = dtgPagoCreditosConvenio.Rows[fila].Cells["nMonPagCuota"];
            Decimal nTotDeuda = Convert.ToDecimal (dtLisCrexAna.Rows[fila]["nSaldoTot"]);
            Decimal nPagaDeuda = Convert.ToDecimal (dtLisCrexAna.Rows[fila]["nMonPagCuota"]);
            if (nPagaDeuda > nTotDeuda)
            {
                dtgPagoCreditosConvenio.CurrentCell = dtgPagoCreditosConvenio.Rows[fila].Cells["nMonPagCuota"];
                MessageBox.Show("Monto a pagar no puede superar a la deuda de la cuota", "Cobros Masivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SumaPagos();
        }

        private void dtgPagoCreditosConvenio_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }

        private void cboConvenio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(cboConvenio.SelectedValue) == 1)
            {
                grbPagoIns.Visible = true;
                conPagoBcos.Visible = false;
                txtEntidad.Text = clsVarApl.dicVarGen["cNomEmpresa"];
                txtCuenta.Text = clsVarGlobal.dFecSystem.Year.ToString();
                txtNroOpeIns.Text = clsVarGlobal.dFecSystem.Year.ToString() + "/" + clsVarGlobal.dFecSystem.Month.ToString();
                cboTipoPago.Enabled = false;
                cboTipoPago.SelectedValue = 4;//interbancario
            }
            else
            {
                cboTipoPago.Enabled = true;
                cboTipoPago.SelectedIndex = 0;
                grbPagoIns.Visible = false;
                conPagoBcos.Visible = true;
                conPagoBcos.CargaEntidad(Convert.ToInt32(cboTipoPago.SelectedValue));
            }
            cboMotivoOperacion.Enabled = true;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            int idEntidad = 0, idCuenta = 0;
            string cNroTrx = "", cEmpresa = "", cCuenta = "";

            if (Convert.ToInt16(cboConvenio.SelectedValue) == 1)
            {
                idEntidad = clsVarGlobal.dFecSystem.Month;
                idCuenta = Convert.ToInt32(txtCuenta.Text);
                cNroTrx = txtNroOpeIns.Text;
                cEmpresa = txtEntidad.Text;
                cCuenta = txtCuenta.Text;
            }
            else
            {
                idEntidad = conPagoBcos.idEntidad;
                idCuenta = conPagoBcos.idCuenta;
                cNroTrx = conPagoBcos.cNroTrx;
                cEmpresa = conPagoBcos.cEmpresa;
                cCuenta = conPagoBcos.cCuenta;
            }

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            List<ReportParameter> paramlist = new List<ReportParameter>();
            string reportpath = "RptDetallePagoConvenio.rdlc";
            dtslist.Add(new ReportDataSource("dtsPagoDsctoPlanilla", new clsRPTCNCredito().CNDetallePagDsctoPlanilla(idEntidad, idCuenta, cNroTrx)));

            paramlist.Add(new ReportParameter("x_cNroTrx", cNroTrx, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cEmpresa", cEmpresa, false));
            paramlist.Add(new ReportParameter("cCuenta", cCuenta, false));

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void cboTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoPago.SelectedIndex >= 0)
            {
                conPagoBcos.LimpiarControles();
                conPagoBcos.CargaEntidad(Convert.ToInt32(cboTipoPago.SelectedValue));
            }
        }

        private void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            else
            {
                var fff = (from L in this.Text.ToString()
                           where L.ToString() == "."
                           select L).Count();

                if (fff <= 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        #endregion

        #region Métodos

        public frmCobroCreditosDctoPlanilla()
        {
            InitializeComponent();
            GEN.CapaNegocio.clsCNTipoPago TipoPago = new GEN.CapaNegocio.clsCNTipoPago();
            DataTable dtTipoPago = TipoPago.CNListarTipPagCredito();

            cboTipoPago.DataSource = dtTipoPago;
            cboTipoPago.ValueMember = dtTipoPago.Columns["idTipoPago"].ToString();
            cboTipoPago.DisplayMember = dtTipoPago.Columns["cDesTipoPago"].ToString();
            cboTipoPago.Enabled = false;
            cboMotivoOperacion.Enabled = false;
            cboTipoPago.SelectedValue = 4;

            conPagoBcos.CargaEntidad(Convert.ToInt32(cboTipoPago.SelectedValue));

            cboConvenio.SelectedValue = 0;

            cboMotivoOperacion.ListarMotivoOperacion(idTipoOperacion, clsVarGlobal.PerfilUsu.idPerfil);
            cboMotivoOperacion.SelectedIndex = -1;

        }

        private string ValidarCorteFracc()
        {
            string cRpta = "OK";
            string msge = "";
            clsCNControlOpe ValCorFra = new clsCNControlOpe();
            string cCorFra = ValCorFra.ValidaCorteFracc(clsVarGlobal.dFecSystem, Convert.ToInt32(clsVarGlobal.User.idUsuario.ToString()), clsVarGlobal.nIdAgencia, ref msge);
            if (msge == "OK")
            {
                if (cCorFra == "0")
                {
                    MessageBox.Show("Primero debe Realizar su Corte Fraccionario... por Favor..", "Validar Corte Fraccionario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cRpta = "ERROR";
                }
            }
            else
            {
                MessageBox.Show(msge, "Error al Validar Corte Fraccionario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cRpta = "ERROR";
            }
            return cRpta;
        }

        public void FormatoGrid()
        {
            dtgPagoCreditosConvenio.Columns["nCuotasVen"].Visible = false;
            this.dtgPagoCreditosConvenio.Columns["idCli"].Visible = false;
            this.dtgPagoCreditosConvenio.Columns["idUsuario"].Visible = false;
            this.dtgPagoCreditosConvenio.Columns["idAgencia"].Visible = false;


            dtgPagoCreditosConvenio.Columns["lSeleCta"].Width = 20;
            dtgPagoCreditosConvenio.Columns["idCuenta"].Width = 40;
            dtgPagoCreditosConvenio.Columns["cNombre"].Width = 150;
            dtgPagoCreditosConvenio.Columns["nAtraso"].Width = 30;
            dtgPagoCreditosConvenio.Columns["nCuoPen"].Width = 30;
            dtgPagoCreditosConvenio.Columns["nAtrCuoPen"].Width = 30;
            dtgPagoCreditosConvenio.Columns["nFechProg"].Width = 50;
            dtgPagoCreditosConvenio.Columns["nSaldoTot"].Width = 50;
            dtgPagoCreditosConvenio.Columns["nSalAPagar"].Width = 50;
            dtgPagoCreditosConvenio.Columns["nMonPagCuota"].Width = 50;
            dtgPagoCreditosConvenio.Columns["nNumeroTelefono"].Width = 150;

            dtgPagoCreditosConvenio.Columns["lSeleCta"].HeaderText = "Sel.";
            dtgPagoCreditosConvenio.Columns["idCuenta"].HeaderText = "Cuenta";
            dtgPagoCreditosConvenio.Columns["cNombre"].HeaderText = "Cliente";
            dtgPagoCreditosConvenio.Columns["nMonCuoIni"].HeaderText = "Cuota Ini.";
            dtgPagoCreditosConvenio.Columns["nAtraso"].HeaderText = "Atr.Cre";
            dtgPagoCreditosConvenio.Columns["nCuoPen"].HeaderText = "Cuo.Pend";
            dtgPagoCreditosConvenio.Columns["nAtrCuoPen"].HeaderText = "Atr.Cuo";
            dtgPagoCreditosConvenio.Columns["nFechProg"].HeaderText = "Fec.Prog";
            dtgPagoCreditosConvenio.Columns["nSaldoTot"].HeaderText = "Sal.Tot.Cre";
            dtgPagoCreditosConvenio.Columns["nSalAPagar"].HeaderText = "Sal.Cuo";
            dtgPagoCreditosConvenio.Columns["nMonPagCuota"].HeaderText = "Pago Cuota";
            dtgPagoCreditosConvenio.Columns["nNumeroTelefono"].HeaderText = "Teléfono";
            dtgPagoCreditosConvenio.Columns["nMonPagCuota"].DefaultCellStyle.BackColor = Color.DarkBlue;
            dtgPagoCreditosConvenio.Columns["nMonPagCuota"].DefaultCellStyle.ForeColor = Color.White;

            DataGridViewCellStyle boldStyle = new DataGridViewCellStyle();
            boldStyle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            boldStyle.BackColor = Color.DarkBlue;
            boldStyle.ForeColor = Color.White;

            dtgPagoCreditosConvenio.Columns["nMonPagCuota"].DefaultCellStyle.Format = "N2";
            dtgPagoCreditosConvenio.Columns["nMonPagCuota"].DefaultCellStyle = boldStyle;
            dtgPagoCreditosConvenio.Columns["nMonPagCuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public void HabilitarGrid(Boolean bVal)
        {
            this.dtgPagoCreditosConvenio.ReadOnly = !bVal;

            this.dtgPagoCreditosConvenio.Columns["lSeleCta"].ReadOnly = !bVal;

            this.dtgPagoCreditosConvenio.Columns["idCuenta"].ReadOnly = bVal;
            this.dtgPagoCreditosConvenio.Columns["cNombre"].ReadOnly = bVal;
            this.dtgPagoCreditosConvenio.Columns["nAtraso"].ReadOnly = bVal;
            this.dtgPagoCreditosConvenio.Columns["nCuoPen"].ReadOnly = bVal;
            this.dtgPagoCreditosConvenio.Columns["nAtrCuoPen"].ReadOnly = bVal;
            this.dtgPagoCreditosConvenio.Columns["nFechProg"].ReadOnly = bVal;
            this.dtgPagoCreditosConvenio.Columns["nSaldoTot"].ReadOnly = bVal;
            this.dtgPagoCreditosConvenio.Columns["nSalAPagar"].ReadOnly = bVal;
            this.dtgPagoCreditosConvenio.Columns["nMonPagCuota"].ReadOnly = !bVal;
        }

        private void SumaPagos()
        {
            Decimal nTotPagadoCuo = 0;
            int nNumCrePagados = 0;
            for (int i = 0; i < dtLisCrexAna.Rows.Count; i++)
            {
                bool lSeleCta = Convert.ToBoolean(dtLisCrexAna.Rows[i]["lSeleCta"]);
                if (lSeleCta)
                {
                    nTotPagadoCuo += Convert.ToDecimal (dtLisCrexAna.Rows[i]["nMonPagCuota"]);
                    if (Convert.ToDecimal (dtLisCrexAna.Rows[i]["nMonPagCuota"]) > 0.00m)
                    {
                        nNumCrePagados++;
                    }
                }
            }
            this.txtTotalPago.Text = nTotPagadoCuo.ToString();
            this.txtTotalCreditos.Text = nNumCrePagados.ToString();
        }

        private bool validapago()
        {
            bool lvalida = true;
            Decimal nTotDeuda = 0.00m;
            Decimal nPagaDeuda = 0.00m;
            if (Convert.ToInt16(cboConvenio.SelectedValue) != 1)
            {
                conPagoBcos.CargaResultado();

                if (!conPagoBcos.lResulta)
                {
                    MessageBox.Show(conPagoBcos.cResultado, "Cobros Masivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            if (String.IsNullOrEmpty(this.txtTotalPago.Text.Trim()) || Convert.ToDecimal (this.txtTotalPago.Text) <= 0)
            {
                MessageBox.Show("No hay montos a ser pagados", "Cobros Masivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lvalida = false;
                return lvalida;
            }
            for (int i = 0; i < dtLisCrexAna.Rows.Count; i++)
            {
                bool lSeleCta = Convert.ToBoolean(dtLisCrexAna.Rows[i]["lSeleCta"]);
                if (!lSeleCta)
                {
                    continue;
                }
                nTotDeuda = Convert.ToDecimal (dtLisCrexAna.Rows[i]["nSaldoTot"]);
                nPagaDeuda = Convert.ToDecimal (dtLisCrexAna.Rows[i]["nMonPagCuota"]);
                if (nPagaDeuda > nTotDeuda)
                {
                    MessageBox.Show("Monto a pagar no puede superar a la deuda de la cuota", "Cobros Masivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtgPagoCreditosConvenio.CurrentCell = dtgPagoCreditosConvenio.Rows[i].Cells["nMonPagCuota"];
                    lvalida = false;
                    break;
                }
            }

            if (cboMotivoOperacion.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el motivo de operación.", "Cobros Masivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lvalida = false;
                return lvalida;
            }

            return lvalida;
        }

        public void LiberarCuenta()
        {
            if (nIdAse != -1)
            {
                objCredito.DesbMasByAse(nIdAse, clsVarGlobal.User.idUsuario);
            }
        }

        #endregion

    }
}
