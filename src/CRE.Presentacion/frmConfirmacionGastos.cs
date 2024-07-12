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

namespace CRE.Presentacion
{
    public partial class frmConfirmacionGastos : frmBase
    {

        #region Variables Globales

        private decimal nTipCambio = 0M;
        private string cTituloMsjes = "Confirmación de gastos.";
        private DataTable dtPlanPagos = null;
        private DataTable dtGastos = null;
        private DataTable dtConfirmacion = null;

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            nTipCambio = Convert.ToDecimal(clsVarApl.dicVarGen["nTipoCambio"]);

            LimpiarDatosCredito();
            dtgGastosCuenta.DataSource = string.Empty;
            dtgPlanPagos.DataSource = string.Empty;
            LimpiarControles();

            btnNuevo.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;

            conBusCuentaCli.Focus();
            conBusCuentaCli.txtNroBusqueda.Select();
        }

        private void conBusCuentaCli_MyClic(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void conBusCuentaCli_MyKey(object sender, KeyPressEventArgs e)
        {
            cargarDatos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            CrearTablaConfirmacion();

            cboMonSentencia.SelectedValue = 1;

            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;

            HabilitarControles(true);
            if (dtGastos.Rows.Count > 0 && dtGastos.AsEnumerable().Where(x => x["idConfirmGastos"] != DBNull.Value).Count() == 0)
            {
                FormatoGridEditable();
                FormatoPlanPagosEditable();
            }

            cboJuzgado.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            LlenarTablaConfirmacionData();

            DataSet dsGastos = new DataSet("dsGastos");

            //var watch = System.Diagnostics.Stopwatch.StartNew();
            //DataTable dtCuotasGastos = DistribuirCuotasConceptos(dtPlanPagos, dtGastos);
            //dtCuotasGastos.TableName = "dtCuotasGastos";
            //watch.Stop();
            //var elapsedMs = watch.Elapsed;

            //MessageBox.Show(elapsedMs.ToString(), cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //return;

            DataTable dtCuotasGastos = DistribuirCuotasConceptos(dtPlanPagos, dtGastos);
            dtCuotasGastos.TableName = "dtCuotasGastos";

            dtGastos.TableName = "dtDetGastos";

            dsGastos.Tables.Add(dtCuotasGastos);
            dsGastos.Tables.Add(dtGastos);
            dsGastos.Tables.Add(dtConfirmacion);

            string xmlCuotasGastos = dsGastos.GetXml();

            dsGastos.Tables.Clear();

            clsDBResp objDbResp = new clsCNGastosCuenta().CNConfirmarGastos(xmlCuotasGastos);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);

                dtgGastosCuenta.DataSource = string.Empty;
                dtgGastosCuenta.DataSource = string.Empty;
                LimpiarControles();  
 
                dtGastos = new clsCNGastosCuenta().CNLstGastosCuenta(conBusCuentaCli.nValBusqueda);
                dtGastos.Columns["lAceptado"].ReadOnly = true;
                dtgGastosCuenta.DataSource = dtGastos;
                FormatoGrid();

                CargarPlanPagos(conBusCuentaCli.nValBusqueda);
                CalcSumatorias();

                HabilitarControles(false);

                btnCancelar.Enabled = true;  
                btnNuevo.Enabled = false;
                btnGrabar.Enabled = false;

                dtgGastosCuenta.Focus();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            conBusCuentaCli.LiberarCuenta();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            conBusCuentaCli.LiberarCuenta();
            conBusCuentaCli.limpiarControles();
            LimpiarDatosCredito();
            dtgGastosCuenta.DataSource = string.Empty;
            dtgPlanPagos.DataSource = string.Empty;
            LimpiarControles();

            dtConfirmacion = null;
            dtGastos = null;
            dtPlanPagos = null;

            HabilitarControles(false);

            btnNuevo.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;

            conBusCuentaCli.txtNroBusqueda.Enabled = true;
            conBusCuentaCli.btnBusCliente1.Enabled = true;

            conBusCuentaCli.Focus();
            conBusCuentaCli.txtNroBusqueda.Select(); 
        }

        private void txtMontoAceptado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DistribuirGastos();
            }
        }

        private void cboMonSentencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMonSentencia.SelectedIndex >= 0 && cboMonSentencia.SelectedValue != null
                 && !(cboMonSentencia.SelectedValue is DataRowView))
            {
                DistribuirGastos();
            }
        }

        private void dtgGastosCuenta_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgGastosCuenta.SelectedRows.Count > 0)
            {
                MapeaTablaControles(dtgGastosCuenta.SelectedRows[0]);

                StringBuilder sbDetalle = new StringBuilder();

                DateTime dFechaReg = Convert.ToDateTime(dtgGastosCuenta.SelectedRows[0].Cells["dFechaReg"].Value);
                string cWinUser = Convert.ToString(dtgGastosCuenta.SelectedRows[0].Cells["cWinUser"].Value);
                string cNombreAge = Convert.ToString(dtgGastosCuenta.SelectedRows[0].Cells["cNombreAge"].Value);
                string cConcepto = Convert.ToString(dtgGastosCuenta.SelectedRows[0].Cells["cConcepto"].Value);
                string cDetGasto = Convert.ToString(dtgGastosCuenta.SelectedRows[0].Cells["cDetGasto"].Value);
                decimal nMontoSoles = Convert.ToDecimal(dtgGastosCuenta.SelectedRows[0].Cells["nMontoSoles"].Value);

                sbDetalle.Append(string.Format("Fecha de registro: {0:dd/MM/yyyy}\n", dFechaReg));
                sbDetalle.Append(string.Format("Fecha de registro: {0}\n", cWinUser));
                sbDetalle.Append(string.Format("Fecha de registro: {0}\n", cNombreAge));
                sbDetalle.Append(string.Format("Fecha de registro: {0}\n", cConcepto));
                sbDetalle.Append(string.Format("Fecha de registro: {0}\n", cDetGasto));
                sbDetalle.Append(string.Format("Fecha de registro: {0:#,0.00}\n", nMontoSoles));

                ttpDetalle.SetToolTip(dtgGastosCuenta, sbDetalle.ToString());
            }
        }

        private void dtgGastosCuenta_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dtgGastosCuenta.Columns[e.ColumnIndex].Name.Equals("lAceptado"))
            {
                DataGridViewRow row = dtgGastosCuenta.Rows[e.RowIndex];
                bool bChecked = Convert.ToBoolean(row.Cells["lAceptado"].Value);
                if (bChecked)
                {
                    row.Cells["nMontoAceptado"].Value = row.Cells["nMontoMonCred"].Value;
                }
                else
                {
                    row.Cells["nMontoAceptado"].Value = 0M;
                }
                SumarGastosAceptado();
                //DistribuirCuotas();
            }

            if(dtgGastosCuenta.Columns[e.ColumnIndex].Name.Equals("nMontoAceptado"))
            {
                DataGridViewRow row = dtgGastosCuenta.Rows[e.RowIndex];
                bool bChecked = Convert.ToBoolean(row.Cells["lAceptado"].Value);
                if (bChecked)
                {
                    if (row.Cells["nMontoAceptado"].Value == DBNull.Value)
                    {
                        row.Cells["nMontoAceptado"].Value = 0;
                    }
                    if (Convert.ToDecimal(row.Cells["nMontoAceptado"].Value) > Convert.ToDecimal(row.Cells["nMontoMonCred"].Value))
                    {
                        MessageBox.Show("El monto aceptado no puede ser mayor al monto gastado.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        row.Cells["nMontoAceptado"].Value = 0M;
                    }                    
                }
                else
                {
                    row.Cells["nMontoAceptado"].Value = 0M;  
                }
                SumarGastosAceptado();
                //DistribuirCuotas();   
            }
        }

        private void dtgGastosCuenta_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dtgGastosCuenta.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void chcTodosGastos_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dtgGastosCuenta.Rows)
            {
                row.Cells["lAceptado"].Value = chcTodosGastos.Checked;
            }
        }

        private void dtgPlanPagos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dtgPlanPagos.Columns[e.ColumnIndex].Name.Equals("lAplicar"))
            {
                DistribuirCuotas();
            }
        }

        private void dtgPlanPagos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dtgPlanPagos.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void chcTodasCuotas_CheckedChanged(object sender, EventArgs e)
        {
            //dtgPlanPagos.CellValueChanged -= dtgPlanPagos_CellValueChanged;

            foreach (DataGridViewRow row in dtgPlanPagos.Rows)
            {
                row.Cells["lAplicar"].Value = chcTodasCuotas.Checked;
            }

            //decimal nMontoDistribuir = !string.IsNullOrEmpty(txtMontoConvert.Text) ? Convert.ToDecimal(txtMontoConvert.Text) : 0;
            //int nNumCuotCheck = dtgPlanPagos.Rows.Cast<DataGridViewRow>()
            //                                    .Where(x => Convert.ToBoolean(x.Cells["lAplicar"].Value) == true).Count();
            //decimal nGastoCuota = nNumCuotCheck > 0 ? decimal.Round(nMontoDistribuir / nNumCuotCheck, 1) : 0M;

            //foreach (DataGridViewRow row in dtgPlanPagos.Rows)
            //{
            //    if (!Convert.ToBoolean(row.Cells["lAplicar"].Value))
            //    {
            //        row.Cells["nOtros"].Value = 0;
            //        continue;
            //    }

            //    if (nNumCuotCheck==1)
            //    {
            //        row.Cells["nOtros"].Value = nMontoDistribuir;
            //        nMontoDistribuir -= nMontoDistribuir;
            //    }

            //    else
            //    {
            //        row.Cells["nOtros"].Value = nGastoCuota;
            //        nMontoDistribuir -= nGastoCuota;
            //    }
            //    nNumCuotCheck--;
            //}

            //dtgPlanPagos.CellValueChanged += dtgPlanPagos_CellValueChanged;
            
        }

        private void dtgGastosCuenta_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txtbox = e.Control as TextBox;
            if (txtbox != null)
            {
                txtbox.KeyPress += new KeyPressEventHandler(txtbox_KeyPress);
            }
        }

        private void txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtMontoAceptado_Enter(object sender, EventArgs e)
        {
            txtMontoAceptado.Select();
        }

        #endregion

        #region Metodos

        public frmConfirmacionGastos()
        {
            InitializeComponent();
            conBusCuentaCli.cTipoBusqueda = "C";
        }

        private bool Validar()
        {

            if (cboJuzgado.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el juzgado.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboJuez.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el juez.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboMonSentencia.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione la moneda.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtMontoAceptado.Text.Trim()))
            {
                MessageBox.Show("Ingrese el monto aceptado en la sentencia.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!dtgGastosCuenta.Rows.Cast<DataGridViewRow>().Any(x => Convert.ToBoolean(x.Cells["lAceptado"].Value)))
            {
                MessageBox.Show("Seleccione por lo menos un gasto a aceptar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!dtgPlanPagos.Rows.Cast<DataGridViewRow>().Any(x => Convert.ToBoolean(x.Cells["lAplicar"].Value)))
            {
                MessageBox.Show("seleccione por lo menos una cuota a la cual aplicar los gastos.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            decimal nMontoGastos = dtgGastosCuenta.Rows.Cast<DataGridViewRow>()
                                                            .Sum(x => Convert.ToDecimal(x.Cells["nMontoMonCred"].Value));

            decimal nMontoAceptado = dtgGastosCuenta.Rows.Cast<DataGridViewRow>()
                                                             .Sum(x => Convert.ToDecimal(x.Cells["nMontoAceptado"].Value));


            if (nMontoAceptado > nMontoGastos)
            {
                MessageBox.Show("El monto aceptado no puede ser mayor a los gastos del crédito.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Convert.ToInt32(cboMoneda.SelectedValue) == Convert.ToInt32(cboMonSentencia.SelectedValue))
            {
                if (nMontoAceptado != Convert.ToDecimal(txtMontoAceptado.Text))
                {
                    MessageBox.Show("El monto aceptado es distinto del monto en la caja de texto.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                if (nMontoAceptado != Convert.ToDecimal(txtMontoConvert.Text))
                {
                    MessageBox.Show("El monto aceptado es distinto del monto en la caja de texto.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void cargarDatos()
        {
            LimpiarDatosCredito();
            dtgGastosCuenta.DataSource = string.Empty;
            dtgPlanPagos.DataSource = string.Empty;
            LimpiarControles();
            if (conBusCuentaCli.nValBusqueda == 0)
            {
                conBusCuentaCli.limpiarControles();
                btnCancelar.Enabled = false;
                btnNuevo.Enabled = false;
                return;
            }
            else
            {
                cargarCredito(conBusCuentaCli.nValBusqueda);
                
                dtGastos = new clsCNGastosCuenta().CNLstGastosCuenta(conBusCuentaCli.nValBusqueda);
                dtGastos.Columns["lAceptado"].ReadOnly = false;
                dtgGastosCuenta.DataSource = dtGastos;
                FormatoGrid();

                CargarPlanPagos(conBusCuentaCli.nValBusqueda);
                CalcSumatorias();

                btnCancelar.Enabled = true;
                btnNuevo.Enabled = false;
                if (dtGastos.Rows.Count > 0 && dtGastos.AsEnumerable().Where(x => x["idConfirmGastos"] != DBNull.Value).Count() == 0)
                {
                    btnNuevo.Enabled = true;
                }
            }
            btnGrabar.Enabled = false;
            HabilitarControles(false);
        }

        private void cargarCredito(int idCuenta)
        {
            DataTable dtCredito = new clsCNCredito().CNdtDataCreditoCobro(idCuenta);
            decimal nDeuda = 0M;

            if (dtCredito.Rows.Count > 0)
            {
                foreach (DataRow row in dtCredito.Rows)
                {
                    DataTable dtPpg = new clsCNPlanPago().CNdtPlanPago(idCuenta);


                    nDeuda = (Convert.ToDecimal(row["nCapitalDesembolso"]) - Convert.ToDecimal(row["nCapitalPagado"]) +
                                Convert.ToDecimal(row["nInteresPactado"]) - Convert.ToDecimal(row["nInteresPagado"]) +
                                Convert.ToDecimal(row["nMoraGenerado"]) - Convert.ToDecimal(row["nMoraPagada"]) +
                                Convert.ToDecimal(row["nOtrosGenerado"]) - Convert.ToDecimal(row["nOtrosPagado"]));

                    txtTipoCredito.Text = Convert.ToString(row["cProducto"]);
                    cboMoneda.SelectedValue = Convert.ToInt16(row["IdMoneda"]);
                    txtSaldoCred.Text = string.Format("{0:#,0.00}", nDeuda);
                    txtCuotas.Text = Convert.ToString(row["nCuotas"]);
                    txtAtraso.Text = Convert.ToString(row["nAtraso"]);
                    txtCuoPend.Text = Convert.ToString(new clsCNPlanPago().nNumCuotasPen(dtPpg));
                }
            }
        }

        private void MapeaTablaControles(DataGridViewRow dtgRow)
        {
            if (dtgRow.Cells["idConfirmGastos"].Value != DBNull.Value)
            {
                dtpFecSentencia.Value = Convert.ToDateTime(dtgRow.Cells["dFecSentencia"].Value);
                cboJuzgado.SelectedValue = Convert.ToInt32(dtgRow.Cells["idJuzgado"].Value);
                cboJuez.SelectedValue = Convert.ToString(dtgRow.Cells["idJuez"].Value);
                cboMonSentencia.SelectedValue = Convert.ToInt32(dtgRow.Cells["idMonSentencia"].Value);
                txtMontoAceptado.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(dtgRow.Cells["nTotAcept"].Value));
                txtMontoConvert.Text = string.Format("{0:#,0.00}", Convert.ToDecimal(dtgRow.Cells["nMontoConvertido"].Value));
            }
        }

        private void CrearTablaConfirmacion()
        {
            dtConfirmacion = new DataTable("dtConfirmacion");

            dtConfirmacion.Columns.Add("dFecSentencia", typeof(DateTime));
            dtConfirmacion.Columns.Add("idJuzgado", typeof(int));
            dtConfirmacion.Columns.Add("idJuez", typeof(int));
            dtConfirmacion.Columns.Add("idMoneda", typeof(int));
            dtConfirmacion.Columns.Add("nMontoAceptado", typeof(decimal));
            dtConfirmacion.Columns.Add("nMontoConvertido", typeof(decimal));
            dtConfirmacion.Columns.Add("nTipCamFijo", typeof(decimal));
            dtConfirmacion.Columns.Add("idAgencia", typeof(int));
            dtConfirmacion.Columns.Add("dFechaReg", typeof(DateTime));
            dtConfirmacion.Columns.Add("idUsuario", typeof(int));

            dtConfirmacion.Rows.Add(dtConfirmacion.NewRow());
        }

        private void LlenarTablaConfirmacionData()
        {
            DataRow drGasto = dtConfirmacion.Rows[0];

            drGasto["dFecSentencia"] = dtpFecSentencia.Value.Date;
            drGasto["idJuzgado"] = Convert.ToInt32(cboJuzgado.SelectedValue);
            drGasto["idJuez"]= Convert.ToInt32(cboJuzgado.SelectedValue);
            drGasto["idMoneda"]= Convert.ToInt32(cboMonSentencia.SelectedValue);
            drGasto["nMontoAceptado"]= Convert.ToDecimal(txtMontoAceptado.Text);
            drGasto["nMontoConvertido"]= Convert.ToDecimal(txtMontoConvert.Text);
            drGasto["nTipCamFijo"] = nTipCambio;
            drGasto["idAgencia"]= clsVarGlobal.nIdAgencia;
            drGasto["dFechaReg"]= clsVarGlobal.dFecSystem.Date;
            drGasto["idUsuario"]= clsVarGlobal.User.idUsuario;
        }

        private void HabilitarControles(bool lHabil)
        {
            chcTodasCuotas.Enabled = lHabil;
            chcTodosGastos.Enabled = lHabil;
            dtpFecSentencia.Enabled = lHabil;
            cboJuzgado.Enabled = lHabil;
            cboJuez.Enabled = lHabil;
            cboMonSentencia.Enabled = lHabil;
            txtMontoAceptado.Enabled = lHabil;
        }

        private void SumarGastosAceptado()
        {
            decimal nMontoAceptado = dtgGastosCuenta.Rows.Cast<DataGridViewRow>()
                                                            .Sum(x => Convert.ToDecimal(x.Cells["nMontoAceptado"].Value));
            decimal nMontoConvertido = nMontoAceptado;

            if (Convert.ToInt16(cboMoneda.SelectedValue) != Convert.ToInt16(cboMonSentencia.SelectedValue))
            {
                if (Convert.ToInt16(cboMonSentencia.SelectedValue) == 1)
                {
                    nMontoConvertido = (nTipCambio > 0) ? (nMontoAceptado / nTipCambio) : 0;
                }
                else
                {
                    nMontoConvertido = (nTipCambio > 0) ? (nMontoAceptado * nTipCambio) : 0;
                }
            }

            txtMontoAceptado.Text = string.Format("{0:#,0.00}", nMontoAceptado);
            txtMontoConvert.Text = string.Format("{0:#,0.00}", nMontoConvertido);
            CalcSumatorias();
        }

        private void DistribuirGastos()
        {
            decimal nMontoDistribuir = 0M;
            decimal nSaldoMonto = 0M;
            decimal nMonAcepConvert = 0M;
            if (!string.IsNullOrEmpty(txtMontoAceptado.Text))
            {              
                decimal.TryParse(txtMontoAceptado.Text, out nMontoDistribuir);
                if (nMontoDistribuir > 0)
                {
                    DialogResult result = MessageBox.Show("Los gastos asignados se borraran. ¿Desea distribuir los gastos?", cTituloMsjes, 
                                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        dtgGastosCuenta.CellValueChanged -= dtgGastosCuenta_CellValueChanged;

                        foreach (DataGridViewRow row in dtgGastosCuenta.Rows)
                        {
                            row.Cells["lAceptado"].Value = false;
                            row.Cells["nMontoAceptado"].Value = 0M;
                        }

                        nMonAcepConvert = nMontoDistribuir;

                        if (Convert.ToInt16(cboMoneda.SelectedValue) != Convert.ToInt16(cboMonSentencia.SelectedValue))
                        {
                            if (Convert.ToInt16(cboMonSentencia.SelectedValue) == 1)
                            {
                                nMonAcepConvert = (nTipCambio > 0) ? (nMontoDistribuir / nTipCambio) : 0;
                            }
                            else
                            {
                                nMonAcepConvert = (nTipCambio > 0) ? (nMontoDistribuir * nTipCambio) : 0;
                            }
                        }

                        decimal nSumGastos = dtgGastosCuenta.Rows.Cast<DataGridViewRow>()
                                                            .Sum(x => Convert.ToDecimal(x.Cells["nMontoMonCred"].Value));

                        if (nMonAcepConvert > nSumGastos)
                        {
                            MessageBox.Show("El monto aceptado no puede ser mayor a la sumatoria de los gastos.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            nMontoDistribuir = 0;
                            nMonAcepConvert = 0;
                        }
                        else
                        {
                            nSaldoMonto = nMonAcepConvert;
                            foreach (DataGridViewRow row in dtgGastosCuenta.Rows)
                            {
                                if (nSaldoMonto == 0) break;
                                decimal nMonto = Convert.ToDecimal(row.Cells["nMontoMonCred"].Value);
                                row.Cells["lAceptado"].Value = true;
                                if (nSaldoMonto >= nMonto)
                                {
                                    row.Cells["nMontoAceptado"].Value = nMonto;
                                    nSaldoMonto -= nMonto;
                                }
                                else
                                {
                                    row.Cells["nMontoAceptado"].Value = nSaldoMonto;
                                    nSaldoMonto -= nSaldoMonto;
                                }
                            }
                        }
                        dtgGastosCuenta.CellValueChanged += dtgGastosCuenta_CellValueChanged;
                    }
                }
            }

            txtMontoAceptado.Text = string.Format("{0:#,0.00}", nMontoDistribuir);
            txtMontoConvert.Text = string.Format("{0:#,0.00}", nMonAcepConvert);
            CalcSumatorias();
        }

        private void CalcSumatorias()
        {
            decimal nMontoAceptado = dtgGastosCuenta.Rows.Cast<DataGridViewRow>()
                                                            .Sum(x => Convert.ToDecimal(x.Cells["nMontoAceptado"].Value));
            decimal nMontoGastos = dtgGastosCuenta.Rows.Cast<DataGridViewRow>()
                                                            .Sum(x => Convert.ToDecimal(x.Cells["nMontoMonCred"].Value));

            txtSumGastos.Text = string.Format("{0:#,0.00}", nMontoGastos);
            txtSumAceptado.Text = string.Format("{0:#,0.00}", nMontoAceptado);
        }

        public void CargarPlanPagos(int nNumCredito)
        {
            dtPlanPagos = new clsCNPlanPago().CNdtPlanPago(nNumCredito);

            DataColumn dcAplicar = new DataColumn("lAplicar", typeof(bool));
            dcAplicar.DefaultValue = false;
            dtPlanPagos.Columns.Add(dcAplicar);

            if (dtGastos.AsEnumerable().Where(x => x["idConfirmGastos"] != DBNull.Value).Count() > 0)
            {
                foreach (DataRow row in dtPlanPagos.Rows)
                {
                    if(Convert.ToDecimal(row["nOtros"])>0){
                        row["lAplicar"] = true;
                    }
                }
            }

            dtgPlanPagos.DataSource = dtPlanPagos;
            FormatoPlanPagos();
        }

        private void DistribuirCuotas()
        {
            dtgPlanPagos.CellValueChanged -= dtgPlanPagos_CellValueChanged;

            decimal nMontoDistribuir = !string.IsNullOrEmpty(txtMontoConvert.Text) ? Convert.ToDecimal(txtMontoConvert.Text) : 0;
            int nNumCuotCheck = dtgPlanPagos.Rows.Cast<DataGridViewRow>()
                                                .Where(x => Convert.ToBoolean(x.Cells["lAplicar"].Value) == true).Count();
            decimal nGastoCuota = nNumCuotCheck > 0 ? decimal.Round(nMontoDistribuir / nNumCuotCheck, 1) : 0M;

            foreach (DataGridViewRow row in dtgPlanPagos.Rows)
            {
                if (!Convert.ToBoolean(row.Cells["lAplicar"].Value))
                {
                    row.Cells["nOtros"].Value = 0;
                    continue;
                }

                if (nNumCuotCheck == 1)
                {
                    row.Cells["nOtros"].Value = nMontoDistribuir;
                    nMontoDistribuir -= nMontoDistribuir;
                }
                else
                {
                    row.Cells["nOtros"].Value = nGastoCuota;
                    nMontoDistribuir -= nGastoCuota;
                }
                nNumCuotCheck--;

            }

            dtgPlanPagos.CellValueChanged += dtgPlanPagos_CellValueChanged;

        }

        private DataTable DistribuirCuotasConceptos(DataTable dtPpg, DataTable dtGastos)
        {
            //Realiza la union y distribucion de los gastos en cada cuota
            DataTable dtCuotasConceptos = new DataTable();
            dtCuotasConceptos.Columns.Add("idCuenta", typeof(int));
            dtCuotasConceptos.Columns.Add("idPlanPagos", typeof(int));
            dtCuotasConceptos.Columns.Add("idCuota", typeof(int));
            dtCuotasConceptos.Columns.Add("idContable", typeof(int));
            dtCuotasConceptos.Columns.Add("nOtros", typeof(decimal));
            dtCuotasConceptos.Columns.Add("idGastoCuenta", typeof(int));
            dtCuotasConceptos.Columns.Add("nMontoMonCred", typeof(decimal));
            dtCuotasConceptos.Columns.Add("nMontoAceptado", typeof(decimal));
            dtCuotasConceptos.Columns.Add("nMontoCuoConcep", typeof(decimal));

            int nNumCuoCheck = dtPpg.Rows.Cast<DataRow>()
                                                .Where(x => Convert.ToBoolean(x["lAplicar"]) == true).Count();

            foreach (DataRow rowCuota in dtPpg.Rows)
            {
                if (!Convert.ToBoolean(rowCuota["lAplicar"])) continue;

                foreach (DataRow rowGasto in dtGastos.Rows)
                {
                    if (!Convert.ToBoolean(rowGasto["lAceptado"])) continue;

                    decimal nMontoAceptado = Convert.ToDecimal(rowGasto["nMontoAceptado"]);

                    DataRow drCuotaGasto = dtCuotasConceptos.NewRow();
                    drCuotaGasto["idCuenta"] = Convert.ToInt32(rowCuota["idCuenta"]);
                    drCuotaGasto["idPlanPagos"] = Convert.ToInt32(rowCuota["idPlanPagos"]);
                    drCuotaGasto["idCuota"] = Convert.ToInt32(rowCuota["idCuota"]);
                    drCuotaGasto["idContable"] = Convert.ToInt32(rowCuota["idContable"]);
                    drCuotaGasto["nOtros"] = Convert.ToDecimal(rowCuota["nOtros"]);
                    drCuotaGasto["idGastoCuenta"] = Convert.ToInt32(rowGasto["idGastoCuenta"]);
                    drCuotaGasto["nMontoMonCred"] = Convert.ToDecimal(rowGasto["nMontoMonCred"]);
                    drCuotaGasto["nMontoAceptado"] = Convert.ToDecimal(rowGasto["nMontoAceptado"]);
                    drCuotaGasto["nMontoCuoConcep"] = decimal.Round(nMontoAceptado / nNumCuoCheck, 2);
                    dtCuotasConceptos.Rows.Add(drCuotaGasto);
                }
            }

            //Ajuste de los montos.
            DataTable dtGastosAceptado = dtGastos.AsEnumerable().Where(x => Convert.ToBoolean(x["lAceptado"])).CopyToDataTable();

            foreach (DataRow rowGasto in dtGastosAceptado.Rows)
            {
                decimal nMontoAceptado = Convert.ToDecimal(rowGasto["nMontoAceptado"]);
                int idGastoCuenta = Convert.ToInt32(rowGasto["idGastoCuenta"]);
                DataRow lastRow = dtCuotasConceptos.AsEnumerable().Where(x => Convert.ToInt32(x["idGastoCuenta"]) == idGastoCuenta)
                                                                    .OrderBy(x => x["idCuota"]).Last();
                decimal nMontoAcumulado = 0M;

                DataTable dtResult = dtCuotasConceptos.AsEnumerable().Where(x => Convert.ToInt32(x["idGastoCuenta"]) == idGastoCuenta)
                                                                .CopyToDataTable();

                foreach (DataRow row in dtCuotasConceptos.AsEnumerable()
                                        .Where(x => Convert.ToInt32(x["idGastoCuenta"]) == idGastoCuenta))
                {
                    if (row == lastRow)
                    {
                        row["nMontoCuoConcep"] = nMontoAceptado - nMontoAcumulado;
                    }
                    nMontoAcumulado += Convert.ToDecimal(row["nMontoCuoConcep"]);
                }
            }

            return dtCuotasConceptos;
        }

        private void LimpiarControles()
        {
            dtpFecSentencia.Value = clsVarGlobal.dFecSystem.Date;
            cboJuzgado.SelectedIndex = -1;
            cboJuez.SelectedIndex = -1;
            cboMonSentencia.SelectedIndex = -1;
            txtMontoAceptado.Text = "0.00";
            txtMontoConvert.Text = "0.00";
        }

        private void LimpiarDatosCredito()
        {
            txtTipoCredito.Text = string.Empty;
            txtSaldoCred.Text = string.Empty;
            txtAtraso.Text = string.Empty;
            cboMoneda.SelectedIndex = -1;
            txtCuotas.Text = string.Empty;
            txtCuoPend.Text = string.Empty;
        }

        private void FormatoGrid()
        {
            dtgGastosCuenta.ReadOnly = true;
            foreach (DataGridViewColumn column in dtgGastosCuenta.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgGastosCuenta.Columns["cConcepto"].Visible = true;
            dtgGastosCuenta.Columns["nMontoMonCred"].Visible = true;
            dtgGastosCuenta.Columns["dFechaReg"].Visible = true;
            dtgGastosCuenta.Columns["cWinUser"].Visible = true;
            dtgGastosCuenta.Columns["cDetGasto"].Visible = true;
            dtgGastosCuenta.Columns["lAceptado"].Visible = true;
            dtgGastosCuenta.Columns["nMontoAceptado"].Visible = true;

            dtgGastosCuenta.Columns["cConcepto"].HeaderText = "Gasto";
            dtgGastosCuenta.Columns["nMontoMonCred"].HeaderText = "Monto Gasto";
            dtgGastosCuenta.Columns["dFechaReg"].HeaderText = "F. Registro";
            dtgGastosCuenta.Columns["cWinUser"].HeaderText = "Usuario";
            dtgGastosCuenta.Columns["cDetGasto"].HeaderText = "Detalle";
            dtgGastosCuenta.Columns["lAceptado"].HeaderText = string.Empty;
            dtgGastosCuenta.Columns["nMontoAceptado"].HeaderText = "M. Aceptado";

            dtgGastosCuenta.Columns["lAceptado"].FillWeight = 5;
            dtgGastosCuenta.Columns["dFechaReg"].FillWeight = 12;
            dtgGastosCuenta.Columns["cWinUser"].FillWeight = 13;
            dtgGastosCuenta.Columns["cConcepto"].FillWeight = 20;
            dtgGastosCuenta.Columns["cDetGasto"].FillWeight = 30;
            dtgGastosCuenta.Columns["nMontoMonCred"].FillWeight = 10;
            dtgGastosCuenta.Columns["nMontoAceptado"].FillWeight = 10;

            dtgGastosCuenta.Columns["lAceptado"].DisplayIndex = 0;
            dtgGastosCuenta.Columns["dFechaReg"].DisplayIndex = 1;
            dtgGastosCuenta.Columns["cWinUser"].DisplayIndex = 2;
            dtgGastosCuenta.Columns["cConcepto"].DisplayIndex = 3;
            dtgGastosCuenta.Columns["cDetGasto"].DisplayIndex = 4;
            dtgGastosCuenta.Columns["nMontoMonCred"].DisplayIndex = 5;
            dtgGastosCuenta.Columns["nMontoAceptado"].DisplayIndex = 6;

            dtgGastosCuenta.Columns["nMontoMonCred"].DefaultCellStyle.Format = "#,0.00";
            dtgGastosCuenta.Columns["nMontoMonCred"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgGastosCuenta.Columns["nMontoAceptado"].DefaultCellStyle.Format = "#,0.00";
            dtgGastosCuenta.Columns["nMontoAceptado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgGastosCuenta.Columns["nMontoAceptado"].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Bold);
            dtgGastosCuenta.Columns["nMontoAceptado"].DefaultCellStyle.BackColor = Color.SkyBlue;
        }

        private void FormatoGridEditable()
        {
            dtgGastosCuenta.ReadOnly = false;
            foreach (DataGridViewColumn column in dtgGastosCuenta.Columns)
            {
                column.ReadOnly = true;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgGastosCuenta.Columns["lAceptado"].ReadOnly = false;
            dtgGastosCuenta.Columns["nMontoAceptado"].ReadOnly = false;
        }

        private void FormatoPlanPagos()
        {
            dtgPlanPagos.ReadOnly = true;
            foreach (DataGridViewColumn column in dtgPlanPagos.Columns)
            {
                column.Visible = false;
            }

            dtgPlanPagos.Columns["idCuota"].Visible = true;
            dtgPlanPagos.Columns["nCapital"].Visible = true;
            dtgPlanPagos.Columns["nInteres"].Visible = true;
            dtgPlanPagos.Columns["nSaldoCapital"].Visible = true;
            dtgPlanPagos.Columns["nOtros"].Visible = true;
            dtgPlanPagos.Columns["dFechaProg"].Visible = true;
            dtgPlanPagos.Columns["lAplicar"].Visible = true;

            dtgPlanPagos.Columns["idCuota"].HeaderText = "Cuota";
            dtgPlanPagos.Columns["nCapital"].HeaderText = "Capital";
            dtgPlanPagos.Columns["nInteres"].HeaderText = "Interés";
            dtgPlanPagos.Columns["nSaldoCapital"].HeaderText = "Saldo Capital";
            dtgPlanPagos.Columns["nOtros"].HeaderText = "Gastos Cargados";
            dtgPlanPagos.Columns["dFechaProg"].HeaderText = "Fec.Prog";
            dtgPlanPagos.Columns["lAplicar"].HeaderText = "Aplicar";

            dtgPlanPagos.Columns["idCuota"].Width = 40;
            dtgPlanPagos.Columns["nCapital"].Width = 60;
            dtgPlanPagos.Columns["nInteres"].Width = 90;
            dtgPlanPagos.Columns["nSaldoCapital"].Width = 92;
            dtgPlanPagos.Columns["nOtros"].Width = 50;
            dtgPlanPagos.Columns["dFechaProg"].Width = 70;
            dtgPlanPagos.Columns["lAplicar"].Width = 40;

            dtgPlanPagos.Columns["nCapital"].DefaultCellStyle.Format = "#,0.00";
            dtgPlanPagos.Columns["nInteres"].DefaultCellStyle.Format = "#,0.00";
            dtgPlanPagos.Columns["nSaldoCapital"].DefaultCellStyle.Format = "#,0.00";
            dtgPlanPagos.Columns["nOtros"].DefaultCellStyle.Format = "#,0.00";
        }

        private void FormatoPlanPagosEditable()
        {
            dtgPlanPagos.ReadOnly = false;
            foreach (DataGridViewColumn column in dtgPlanPagos.Columns)
            {
                column.ReadOnly = true;
            }

            dtgPlanPagos.Columns["lAplicar"].ReadOnly = false;
        }

        #endregion

    }
}
