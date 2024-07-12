using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using EntityLayer;
using GEN.PrintHelper;
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using GEN.BotonesBase;
using ADM.CapaNegocio;
using GEN.Funciones;
using CLI.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class FrmPosicionCli : frmBase
    {

        #region Variables

        clsCNCredito Credito = new clsCNCredito();
        clsRPTCNCredito rptCred = new clsRPTCNCredito();
        clsCNCliente cliente = new clsCNCliente();
        DataTable dtLisCredxCli = new DataTable();
        DataTable dtHisCreCli = new DataTable();
        DataTable dtDatosInterv = null;//new DataTable();

        #endregion

        #region Eventos

        private void FrmPosicionCli_Load(object sender, EventArgs e)
        {
            this.activarControlObjetos(this,EventoFormulario.INICIO);

            lblClasifInt.Text = string.Empty;
            lblSegmento.Text = string.Empty;
            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
            checkboxColumn.Width = 30;
            checkboxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgCreditos.Columns.Insert(0, checkboxColumn);


            Rectangle rect = dtgCreditos.GetCellDisplayRectangle(0, -1, true);
            rect.X = rect.Location.X + (rect.Width / 4);

            CheckBox checkboxHeader = new CheckBox();
            checkboxHeader.Name = "checkboxHeader";
            checkboxHeader.Size = new Size(18, 18);
            checkboxHeader.Location = rect.Location;
            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);
            dtgCreditos.Controls.Add(checkboxHeader);

            conBusCli.txtCodCli.Focus();
            cargarEstados();
        }

        private void conBusCli_ClicBuscar(object sender, EventArgs e)
        {
            cargardatos();
        }

        private void btnImpKardexPagos_Click(object sender, EventArgs e)
        {
            if (this.dtgCreditos.Rows.Count > 0)
            {
                Int32 fila = Convert.ToInt32(this.dtgCreditos.SelectedCells[0].RowIndex);
                int nNumCredito = Convert.ToInt32(dtLisCredxCli.Rows[fila]["idCuenta"]);
                DateTime dFecSis = clsVarGlobal.dFecSystem;
                string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> listParam = new List<ReportParameter>();

                listParam.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                listParam.Add(new ReportParameter("x_dFechaSis", dFecSis.ToString("dd/MM/yyyy"), false));

                dtslist.Add(new ReportDataSource("dtsKardexPagoCre", new clsRPTCNPlanPagos().CNKardexPagos(nNumCredito)));
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

                string reportpath = "rptKardexPagoCre.rdlc";
                new frmReporteLocal(dtslist, reportpath,listParam).ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay Información que Imprimir", "Kardex de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void btnImpPlanPagos_Click(object sender, EventArgs e)
        {
            if (this.dtgCreditos.Rows.Count > 0)
            {
                Int32 fila = Convert.ToInt32(this.dtgCreditos.SelectedCells[0].RowIndex);
                int nNumCredito = Convert.ToInt32(dtLisCredxCli.Rows[fila]["idCuenta"]);

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> listParam = new List<ReportParameter>();

                DateTime dFecSis = clsVarGlobal.dFecSystem;
                string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

                dtslist.Add(new ReportDataSource("dtsPPG", new clsRPTCNPlanPagos().CNCronogramaPagos(nNumCredito)));
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));
                listParam.Add(new ReportParameter("nNumCredito", Convert.ToString(nNumCredito), false));
                listParam.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                listParam.Add(new ReportParameter("x_dFechaSis", dFecSis.ToString("dd/MM/yyyy"), false));


                string reportpath = "rptPlanPagoPosInt.rdlc";
                new frmReporteLocal(dtslist, reportpath, listParam).ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay Información que Imprimir.", "Plan de pagos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void btnImpResumenCred_Click(object sender, EventArgs e)
        {
            if (this.dtgCreditos.Rows.Count > 0)
            {
                Int32 fila = Convert.ToInt32(this.dtgCreditos.SelectedCells[0].RowIndex);
                int idCliente = Convert.ToInt32(this.conBusCli.txtCodCli.Text);
                List<ReportParameter> listPar = new List<ReportParameter>();
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtHisCreCli = rptCred.CNHistCredCliente(idCliente);
                dtHisCreCli.Columns["lEstado"].ReadOnly = false;

                for (int i = 0; i < dtgCreditos.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)dtgCreditos.Rows[i].Cells[0];
                    int idCuenta = (int)dtgCreditos.Rows[i].Cells["idcuenta"].Value;
                    for (int j = 0; j < dtHisCreCli.Rows.Count; j++)
                    {
                        if (idCuenta == (int)dtHisCreCli.Rows[j]["idcuenta"])
                        {
                            dtHisCreCli.Rows[j]["lEstado"] = Convert.ToBoolean(ch1.Value);
                        }
                    }
                }

                DateTime dFecSis = clsVarGlobal.dFecSystem;
                string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

                dtslist.Add(new ReportDataSource("dtsHisCreCli", dtHisCreCli));
                dtslist.Add(new ReportDataSource("dtsCalificaCrexCli", new clsRPTCNCredito().CNCalificCredClient(idCliente)));
                dtslist.Add(new ReportDataSource("dtsNumCreCli", new GEN.CapaNegocio.clsCNCredito().NumeroCreditos(idCliente)));
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

                string reportpath = "rptHistCredClientes.rdlc";
                listPar.Add(new ReportParameter("nIdAgencia", clsVarGlobal.nIdAgencia.ToString(), false));
                listPar.Add(new ReportParameter("idUsuario", clsVarGlobal.User.idUsuario.ToString(), false));
                listPar.Add(new ReportParameter("idCliente", idCliente.ToString(), false));
                listPar.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                listPar.Add(new ReportParameter("x_dFechaSis", dFecSis.ToString("dd/MM/yyyy"), false));

                new frmReporteLocal(dtslist, reportpath, listPar).ShowDialog();

            }
            else
            {
                MessageBox.Show("No hay Información que Imprimir.", "Historial del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void btnImpUltCred_Click(object sender, EventArgs e)
        {
            if (this.conBusCli.txtCodCli.Text != string.Empty)
            {
                int nContNumCred = 1;
                int nNumCredImpPosCli = 0;
                nNumCredImpPosCli = Convert.ToInt16(clsVarApl.dicVarGen["nNumCredImpPosCli"]);

                int nIdCliente = Convert.ToInt32(this.conBusCli.txtCodCli.Text);

                DataTable dtTodosCreditos = Credito.CNdtLisCrexCli(nIdCliente);

                if (dtTodosCreditos.Rows.Count > 0)
                {
                    int idCliente = Convert.ToInt32(this.conBusCli.txtCodCli.Text);
                    List<ReportParameter> listPar = new List<ReportParameter>();
                    List<ReportDataSource> dtslist = new List<ReportDataSource>();
                    dtHisCreCli = rptCred.CNHistCredCliente(idCliente);
                    dtHisCreCli.Columns["lEstado"].ReadOnly = false;

                    foreach (DataRow row in dtTodosCreditos.Rows)
                    {
                        if (nContNumCred > nNumCredImpPosCli) break;
                        nContNumCred++;
                        int idCuenta = Convert.ToInt32(row["idcuenta"]);
                        foreach (DataRow rowInt in dtHisCreCli.Rows)
                        {
                            if (idCuenta == Convert.ToInt32(rowInt["idCuenta"]))
                            {
                                rowInt["lEstado"] = true;
                            }
                        }
                    }

                    DateTime dFecSis = clsVarGlobal.dFecSystem;
                    string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

                    dtslist.Add(new ReportDataSource("dtsHisCreCli", dtHisCreCli));
                    dtslist.Add(new ReportDataSource("dtsCalificaCrexCli", new clsRPTCNCredito().CNCalificCredClient(idCliente)));
                    dtslist.Add(new ReportDataSource("dtsNumCreCli", new GEN.CapaNegocio.clsCNCredito().NumeroCreditos(idCliente)));
                    dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

                    string reportpath = "rptHistCredClientes.rdlc";
                    listPar.Add(new ReportParameter("nIdAgencia", clsVarGlobal.nIdAgencia.ToString(), false));
                    listPar.Add(new ReportParameter("idUsuario", clsVarGlobal.User.idUsuario.ToString(), false));
                    listPar.Add(new ReportParameter("idCliente", idCliente.ToString(), false));
                    listPar.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                    listPar.Add(new ReportParameter("x_dFechaSis", dFecSis.ToString("dd/MM/yyyy"), false));

                    new frmReporteLocal(dtslist, reportpath, listPar).ShowDialog();

                }
                else
                {
                    MessageBox.Show("No se encontro información para el reporte.", "Historial del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                MessageBox.Show("No se encontro información para el reporte.", "Historial del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void btnImprAfectKard_Click(object sender, EventArgs e)
        {
            if (dtgCreditos.Rows.Count > 0)
            {
                Int32 fila = Convert.ToInt32(this.dtgCreditos.SelectedCells[0].RowIndex);
                int nNumCredito = Convert.ToInt32(dtLisCredxCli.Rows[fila]["idCuenta"]);

                List<ReportParameter> paramlist = new List<ReportParameter>();
                DateTime dFecSis = clsVarGlobal.dFecSystem;
                string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

                paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", dFecSis.ToString("dd/MM/yyyy"), false));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();

                dtslist.Add(new ReportDataSource("dsData", new clsRPTCNPlanPagos().CNRptAfectKardexCuotasCred(nNumCredito)));
                dtslist.Add(new ReportDataSource("dtsRutaLogo", new clsRPTCNAgencia().CNRutaLogo()));

                string reportpath = "rptAfectKardexCuotasCred.rdlc";
                new frmReporteLocal(dtslist,reportpath,paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay información que imprimir", "Kardex de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarControles();
            this.btnCancelar.Enabled = false;
        }

        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dtgCreditos.RowCount; i++)
            {
                dtgCreditos[0, i].Value = ((CheckBox)dtgCreditos.Controls.Find("checkboxHeader", true)[0]).Checked;
            }
            dtgCreditos.EndEdit();
        }

        private void cboEstadoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEstadoCredito.SelectedIndex > -1)
            {
                if (cboEstadoCredito.SelectedValue is DataRowView) return;

                if (conBusCli.idCli > 0)
                {
                    cargardatos();
                }
            }
        }

        private void dtgCreditos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Int32 fila = e.RowIndex;

            // cargar el kardex
            int nNumCredito = Convert.ToInt32(dtLisCredxCli.Rows[fila]["idCuenta"]);
            clsCNCredito Credito = new clsCNCredito();
            DataTable Listkardex = Credito.CNdtLisKardexCre(nNumCredito);
            dtgPagoKardex.DataSource = Listkardex;
            this.FormatoKardexpago();

            //Cargar los Intervinientes
            int nNumsolicitud = Convert.ToInt32(dtLisCredxCli.Rows[fila]["idSolicitud"]);
            clsCNIntervCre IntervCre = new clsCNIntervCre();
            DataTable ListIntervCre = IntervCre.obtenerIntervinienteSolicitud(nNumsolicitud, clsVarGlobal.idModulo, false, false);
            DataTable ListIntervSoli = IntervCre.CNdtIntervSoli(nNumsolicitud, clsVarGlobal.idModulo, false);
            dtDatosInterv = ListIntervSoli;
            //dtgBase2.DataSource = ListIntervCre.DefaultView;
            dtgIntervinientes.DataSource = ListIntervCre;
            this.FormatoGridIntervinientes();

            // Cargar el Plan de Pagos
            clsCNPlanPago PlanPago = new clsCNPlanPago();
            DataTable ListPlanPago = PlanPago.CNdtPlanPagPosi(nNumCredito);
            dtgPlanPagos.DataSource = ListPlanPago;
            this.FormatoPlanPagos();

            // Cargar gastos judiciales pendientes
            clsCNGastosJudiciales CNGastosJudiciales = new clsCNGastosJudiciales();
            DataTable dtGastosJudiciales = CNGastosJudiciales.ListarPendientes(nNumCredito);
            if (dtGastosJudiciales.Rows.Count > 0)
            {
                dtgGastosPendientes.DataSource = dtGastosJudiciales;
                formteardtgGastosPendientes();
            }
            else
            {
                dtgGastosPendientes.DataSource = null;
            }

            // Cargar datos del Crédito
            this.txtAsesor.Text = dtLisCredxCli.Rows[fila]["cAsesorAct"].ToString();
            this.txtGestorRecuperaciones.Text = dtLisCredxCli.Rows[fila]["cRecuperador"].ToString();
            this.txtExpediente.Text = dtLisCredxCli.Rows[fila]["cCodigoExped"].ToString();
            this.txtMontoDesembolsado.Text = String.Format("{0:#,0.00}",Convert.ToDecimal(dtLisCredxCli.Rows[fila]["nCapitalDesembolso"]));
            this.txtFechaDesembolso.Text = Convert.ToDateTime(dtLisCredxCli.Rows[fila]["dFechaDesembolso"]).ToString("dd/MM/yyyy");
            this.txtEstado.Text = dtLisCredxCli.Rows[fila]["cEstado"].ToString();
            this.txtCuenta.Text = dtLisCredxCli.Rows[fila]["idCuenta"].ToString();
            this.txtTipo.Text = dtLisCredxCli.Rows[fila]["cTipo"].ToString();
            this.txtMoneda.Text = dtLisCredxCli.Rows[fila]["cMoneda"].ToString();
            this.lblSaldoEAI.Text = dtLisCredxCli.Rows[fila]["nSaldoOfertaEAI"].ToString();

            // Cargar Nombre de Grupo Solidario y Nro

            this.conDatosReprogramacion.cargarComponentes(Convert.ToInt32(dtLisCredxCli.Rows[fila]["idCuenta"]), false, false);

            DataTable DatosGrupo = Credito.CNDatosGrupoSol(Convert.ToInt32(dtLisCredxCli.Rows[fila]["idCuenta"]));
            this.txtBase1.Text = Convert.ToString(DatosGrupo.Rows[0]["idGrupoSolidario"].ToString());
            this.txtBase2.Text = Convert.ToString(DatosGrupo.Rows[0]["cNombre"].ToString());

            // Suscribirse al evento CellFormatting para pintar la columna "comisiones" de color verde pastel
            dtgPlanPagos.CellFormatting += dtgPlanPagos_CellFormatting;
        }

        private void dtgPlanPagos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dtgPlanPagos.Columns["nOtros"].Index)
                e.CellStyle.BackColor = Color.PaleGreen;
        }

        private void formteardtgGastosPendientes()
        {
            foreach (DataGridViewColumn column in dtgGastosPendientes.Columns)
            {
                column.Visible = false;
            }

            dtgGastosPendientes.Columns["dFechaRegistra"].Visible = true;
            dtgGastosPendientes.Columns["cConcepto"].Visible = true;
            dtgGastosPendientes.Columns["nMonto"].Visible = true;
            dtgGastosPendientes.Columns["cObservacion"].Visible = true;
            dtgGastosPendientes.Columns["cNombre"].Visible = true;
            dtgGastosPendientes.Columns["cMoneda"].Visible = true;

            dtgGastosPendientes.Columns["dFechaRegistra"].HeaderText = "Fecha Reg.";
            dtgGastosPendientes.Columns["cConcepto"].HeaderText = "Concepto";
            dtgGastosPendientes.Columns["nMonto"].HeaderText = "Monto";
            dtgGastosPendientes.Columns["cObservacion"].HeaderText = "Observación";
            dtgGastosPendientes.Columns["cNombre"].HeaderText = "Usuario Reg.";
            dtgGastosPendientes.Columns["cMoneda"].HeaderText = "Mon.";

            //dtgGastosPendientes.Columns["dFechaRegistra"].Width = 70;
            //dtgGastosPendientes.Columns["cConcepto"].Width = 100;
            //dtgGastosPendientes.Columns["nMonto"].Width = 70;
            //dtgGastosPendientes.Columns["cObservacion"].Width = 100;
            //dtgGastosPendientes.Columns["cNombre"].Width = 100;
            //dtgGastosPendientes.Columns["cMoneda"].Width = 25;

        }

        private void dtgCreditos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgCreditos.CurrentRow == null)
            {
                return;
            }
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)dtgCreditos.Rows[dtgCreditos.CurrentRow.Index].Cells[0];
            Int32 fila = e.RowIndex;

            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;

                    break;
                case "False":
                    {
                        ch1.Value = true;
                    }
                    break;
            }
        }

        #endregion

        #region Metodos

        #region Constructores

        public FrmPosicionCli()
        {
            InitializeComponent();
            this.lblBase12.Visible = true;
            this.lblBase13.Visible = true;
            this.txtBase1.Visible = true;
            this.txtBase2.Visible = true;
        }

        public FrmPosicionCli(int idCli)
        {
            InitializeComponent();
            conBusCli.idCli = idCli;
            conBusCli.CargardatosCli(conBusCli.idCli);
            cargardatos();
            this.lblBase12.Visible = true;
            this.lblBase13.Visible = true;
            this.txtBase1.Visible = true;
            this.txtBase2.Visible = true;
  
        }
        
        public FrmPosicionCli(int idCli,string cNroGrupo, string cNombreGrupo)
        {
            InitializeComponent();
            conBusCli.idCli = idCli;
            conBusCli.CargardatosCli(conBusCli.idCli);
            cargardatos();
            this.lblBase12.Visible = true;
            this.lblBase13.Visible = true;
            this.txtBase1.Visible = true;
            this.txtBase2.Visible = true;
            this.txtBase1.Text = cNroGrupo;
            this.txtBase2.Text = cNombreGrupo;
        }

        #endregion

        private void cargarEstados()
        {
            var dtEstados = cboEstadoCredito.retornarTodosEstado();
            var dtEstadoFiltro = dtEstados.Clone();

            (from item in dtEstados.AsEnumerable()
             where Convert.ToInt32(item["IdEstado"]).In(5, 6)
             select item).CopyToDataTable(dtEstadoFiltro, LoadOption.OverwriteChanges);

            var drTotdos = dtEstadoFiltro.NewRow();
            drTotdos["IdEstado"] = 0;
            drTotdos["cEstado"] = "*** TODOS ***";
            dtEstadoFiltro.Rows.Add(drTotdos);

            cboEstadoCredito.DataSource = dtEstadoFiltro;
            cboEstadoCredito.ValueMember = dtEstadoFiltro.Columns[0].ToString();
            cboEstadoCredito.DisplayMember = dtEstadoFiltro.Columns[1].ToString();
        }

        private void FormatoGridCreditos()
        {
            foreach (DataGridViewColumn item in dtgCreditos.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgCreditos.Columns["nProvisionSoles"].Visible = false;
            dtgCreditos.Columns["idEstado"].Visible = false;
            dtgCreditos.Columns["idCondContableNormal"].Visible = false;
            dtgCreditos.Columns["idCondContableVenc"].Visible = false;
            dtgCreditos.Columns["cTipoCliente"].Visible = false;

            dtgCreditos.Columns["cOperacion"].HeaderText = "Operación";
            dtgCreditos.Columns["cModalidadCredito"].HeaderText = "Modalidad de crédito";
            dtgCreditos.Columns["nNumOrdCre"].HeaderText = "Nro.";
            dtgCreditos.Columns["dFechaDesembolso"].HeaderText = "Fecha desembolso";
            dtgCreditos.Columns["dFechaCancelacion"].HeaderText = "Fecha cancelación";
            dtgCreditos.Columns["idCuenta"].HeaderText = "N° cuenta";
            dtgCreditos.Columns["cNombreAge"].HeaderText = "Agencia";
            dtgCreditos.Columns["cProducto"].HeaderText = "Producto";
            dtgCreditos.Columns["cEstado"].HeaderText = "Estado";
            dtgCreditos.Columns["nAtraso"].HeaderText = "Dias atraso";
            dtgCreditos.Columns["nCuotas"].HeaderText = "N° cuotas";
            dtgCreditos.Columns["nPlazoCuota"].HeaderText = "Plazo cuota";
            dtgCreditos.Columns["cAsesorAct"].HeaderText = "Asesor actual";
            dtgCreditos.Columns["cAsesorIni"].HeaderText = "Asesor inicial";
            dtgCreditos.Columns["cTipoCliente"].HeaderText = "Tipo cliente";
            dtgCreditos.Columns["nTasaCompensatoria"].HeaderText = "Tasa comp.(%)";
            dtgCreditos.Columns["nTasaMoratoria"].HeaderText = "Tasa morat.(%)";
            dtgCreditos.Columns["nTasaCostoEfectivo"].HeaderText = "Tasa cost. efec.(%)";
            dtgCreditos.Columns["nCapitalDesembolso"].HeaderText = "Cap. desemb.";
            dtgCreditos.Columns["nCapitalPagado"].HeaderText = "Cap. pagado";
            dtgCreditos.Columns["nSalCap"].HeaderText = "Saldo cap.";
            dtgCreditos.Columns["nCapitalPagado"].HeaderText = "Cap. pag.";
            dtgCreditos.Columns["nInteresPactado"].HeaderText = "Int. pac.";
            dtgCreditos.Columns["nInteresPagado"].HeaderText = "Int. pag.";
            dtgCreditos.Columns["nSaliNT"].HeaderText = "Saldo int.";
            dtgCreditos.Columns["nInteresComp"].HeaderText = "Int. comp.";
            dtgCreditos.Columns["nInteresCompPago"].HeaderText = "Int. comp. pag.";
            dtgCreditos.Columns["nIntCompSal"].HeaderText = "Saldo int. comp.";
            dtgCreditos.Columns["nMoraGenerado"].HeaderText = "Mora gen.";
            dtgCreditos.Columns["nMoraPagada"].HeaderText = "Mora pag.";
            dtgCreditos.Columns["nSalMor"].HeaderText = "Saldo mora";
            dtgCreditos.Columns["nOtrosGenerado"].HeaderText = "Otros gen.";
            dtgCreditos.Columns["nOtrosPagado"].HeaderText = "Otros pag.";
            dtgCreditos.Columns["nSalOtr"].HeaderText = "Saldo otr.";
            dtgCreditos.Columns["nSalTot"].HeaderText = "Saldo tot.";
            dtgCreditos.Columns["cCodigoExped"].HeaderText = "Expediente";
            dtgCreditos.Columns["cDestino"].HeaderText = "Destino";
            dtgCreditos.Columns["idSolicitud"].HeaderText = "N° sol.";
            dtgCreditos.Columns["cCuenta"].HeaderText = "Cuenta";
            dtgCreditos.Columns["cMoneda"].HeaderText = "Moneda";
            dtgCreditos.Columns["nTotSalVen"].HeaderText = "Saldo Vencido";
            dtgCreditos.Columns["nTotCuoVen"].HeaderText = "Cuotas Vencidas";
            dtgCreditos.Columns["cCondContNormal"].HeaderText = "Cond. Contable Normal";
            dtgCreditos.Columns["cCondContVenc"].HeaderText = "Cond. Contable Vencido";



            dtgCreditos.Columns["nTasaCompensatoria"].DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nTasaMoratoria"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nTasaCostoEfectivo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nCapitalDesembolso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nCapitalPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nSalCap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nCapitalPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nInteresPactado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nInteresPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nSaliNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nInteresComp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nInteresCompPago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nIntCompSal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nMoraGenerado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nMoraPagada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nSalMor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nOtrosGenerado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nOtrosPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nSalOtr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nSalTot"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgCreditos.Columns["nTotSalVen"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgCreditos.Columns["nTasaCompensatoria"].DefaultCellStyle.Format = "#,0.0000";
            dtgCreditos.Columns["nTasaMoratoria"].DefaultCellStyle.Format = "#,0.0000";
            dtgCreditos.Columns["nTasaCostoEfectivo"].DefaultCellStyle.Format = "#,0.0000";
            dtgCreditos.Columns["nCapitalDesembolso"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nCapitalPagado"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nSalCap"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nCapitalPagado"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nInteresPactado"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nInteresPagado"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nSaliNT"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nInteresComp"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nInteresCompPago"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nIntCompSal"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nMoraGenerado"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nMoraPagada"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nSalMor"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nOtrosGenerado"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nOtrosPagado"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nSalOtr"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nSalTot"].DefaultCellStyle.Format = "#,0.00";
            dtgCreditos.Columns["nTotSalVen"].DefaultCellStyle.Format = "#,0.00";
        }

        private void FormatoGridIntervinientes()
        {
            foreach (DataGridViewColumn item in dtgIntervinientes.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
            }

            this.dtgIntervinientes.Enabled = true;
            this.dtgIntervinientes.ReadOnly = true;
            this.dtgIntervinientes.Columns["cNombre"].Visible = true;
            this.dtgIntervinientes.Columns["cTipoIntervencion"].Visible = true;

            this.dtgIntervinientes.Columns["cNombre"].HeaderText = "Cliente";
            this.dtgIntervinientes.Columns["cTipoIntervencion"].HeaderText = "Vínculo";
            this.dtgIntervinientes.Columns["cNombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dtgIntervinientes.Columns["cTipoIntervencion"].Width = 200;
        }

        private void FormatoPlanPagos()
        {
            void ConfigurarColumna(string nombreColumna, string encabezado, int indice, DataGridViewContentAlignment alineacion = DataGridViewContentAlignment.MiddleLeft, string formato = null)
            {
                var columna = dtgPlanPagos.Columns[nombreColumna];
                if (columna != null)
                {
                    columna.Visible = true;
                    columna.HeaderText = encabezado;
                    columna.DisplayIndex = indice;
                    columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                    columna.DefaultCellStyle.Alignment = alineacion;
                    if (!string.IsNullOrEmpty(formato))
                    {
                        columna.DefaultCellStyle.Format = formato;
                    }
                }
            }

            // Hacer invisible todas las columnas por defecto
            foreach (DataGridViewColumn columna in dtgPlanPagos.Columns)
            {
                columna.Visible = false;
            }

            // Configurar columnas visibles
            ConfigurarColumna("idCuota", "Nro", 0);
            ConfigurarColumna("dFechaProg", "Fecha prog.", 1);
            ConfigurarColumna("dFechaPago", "Fecha pag.", 2);
            ConfigurarColumna("dFechaValor", "Fecha val.", 3);
            ConfigurarColumna("nAtrasoCuota", "Dias atr. cuo.", 4);
            ConfigurarColumna("nNumDiaCuota", "Dias cuota", 5);
            ConfigurarColumna("nMonCuoIni", "Monto cuota", 6, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("EstadoCuota", "Estado", 7);
            ConfigurarColumna("nCapital", "Capital", 8, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nCapitalPagado", "Cap. pag.", 9, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nSalCap", "Saldo cap.", 10, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nInteres", "Int.", 11, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nInteresPagado", "Int. pag.", 13, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nSalInt", "Saldo int.", 14, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nInteresComp", "Int. comp.", 15, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nInteresCompPago", "Int. comp. pag.", 16, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nSalIntComp", "Saldo int. comp.", 17, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nMoraGenerado", "Mora. gen.", 18, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nMoraPagada", "Mora. pag.", 19, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nSalMor", "Saldo mora", 20, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nOtros", "Otros", 21, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nOtrosPagado", "Otros pag.", 22, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nSalOtr", "Saldo otros", 23, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nSalTot", "Saldo total", 24, DataGridViewContentAlignment.MiddleRight, "#,0.00");
        }

        private void FormatoKardexpago()
        {
            // Método auxiliar para configurar cada columna
            void ConfigurarColumna(string nombreColumna, string encabezado, int indice, DataGridViewContentAlignment alineacion = DataGridViewContentAlignment.MiddleLeft, string formato = null)
            {
                var columna = dtgPagoKardex.Columns[nombreColumna];
                if (columna != null)
                {
                    columna.Visible = true;
                    columna.HeaderText = encabezado;
                    columna.DisplayIndex = indice;
                    columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                    columna.DefaultCellStyle.Alignment = alineacion;
                    if (!string.IsNullOrEmpty(formato))
                    {
                        columna.DefaultCellStyle.Format = formato;
                    }
                }
            }

            // Hacer invisible todas las columnas por defecto
            foreach (DataGridViewColumn columna in dtgPagoKardex.Columns)
            {
                columna.Visible = false;
            }

            // Configurar columnas visibles
            ConfigurarColumna("NumOrdPag", "Nro", 0);
            ConfigurarColumna("idKardex", "Nro. ope.", 1);
            ConfigurarColumna("cTipoOperacion", "Operación", 2);
            ConfigurarColumna("cMotivoOperacion", "Mod. operación", 3);
            ConfigurarColumna("dFechaOpe", "Fech. ope.", 4);
            ConfigurarColumna("dFechaValor", "Fech. val.", 5);
            ConfigurarColumna("nAtrasoPago", "Dias atraso", 6);
            ConfigurarColumna("nMontoOperacion", "Monto ope.", 7, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nMontoCapital", "Monto cap.", 8, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nMontoInteres", "Monto int.", 9, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nMontoIntComp", "Monto int. comp.", 10, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nMontoMora", "Monto mora", 11, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nMontoOtros", "Monto otros", 12, DataGridViewContentAlignment.MiddleRight, "#,0.00");
            ConfigurarColumna("nSaldoCap", "Saldo capital", 13);
            ConfigurarColumna("cNomPersOpe", "Persona operación", 14);
            ConfigurarColumna("cWinUser", "Usuario", 15);
            ConfigurarColumna("cNombreAge", "Agencia", 16);
            ConfigurarColumna("cDesTipoPago", "Tipo pago", 17);
        }


        private void cargardatos()
        {
            if (this.conBusCli.txtCodCli.Text != string.Empty)
            {
                int nIdCliente = Convert.ToInt32(this.conBusCli.txtCodCli.Text);
                lblClasifInt.Text = (conBusCli.nIdClasifInterna == 0) ? string.Empty : conBusCli.cClasifInterna;

                var dtTodosCreditos = Credito.CNdtLisCrexCli(nIdCliente);
                dtLisCredxCli = dtTodosCreditos.Clone();
                var idEstado = Convert.ToInt32(cboEstadoCredito.SelectedValue);

                if (idEstado == 0)
                {
                    dtLisCredxCli = dtTodosCreditos;
                }
                else
                {
                    (from item in dtTodosCreditos.AsEnumerable()
                     where Convert.ToInt32(item["idEstado"]) == idEstado
                     select item).CopyToDataTable(dtLisCredxCli, LoadOption.OverwriteChanges);

                    dtLisCredxCli.Columns["nNumOrdCre"].ReadOnly = false;

                    for (int i = 0; i < dtLisCredxCli.Rows.Count; i++)
                    {
                        dtLisCredxCli.Rows[i]["nNumOrdCre"] = i + 1;
                    }
                }

                dtgCreditos.DataSource = dtLisCredxCli;
                this.FormatoGridCreditos();
                this.btnCancelar.Enabled = true;

                //Segmento del Cliente
                ObtenerSegmentoCliente(nIdCliente);
            }
            else
            {
                this.btnCancelar.Enabled = false;
                this.conBusCli.txtCodCli.Focus();
                this.LimpiarControles();

            }
            this.dtgCreditos.Focus();
        }

        private void LimpiarControles()
        {
            dtgCreditos.DataSource = "";
            dtgIntervinientes.DataSource = "";
            dtgPagoKardex.DataSource = "";
            dtgPlanPagos.DataSource = "";
            dtDatosInterv = null;
            this.txtAsesor.Text = "";
            this.txtGestorRecuperaciones.Text = "";
            this.txtExpediente.Text = "";
            this.txtMontoDesembolsado.Text = "";
            this.txtFechaDesembolso.Text = "";
            this.txtEstado.Text = "";
            this.txtCuenta.Text = "";
            this.txtTipo.Text = "";
            this.txtMoneda.Text = "";
            this.lblClasifInt.Text = string.Empty;
            this.lblSegmento.Text = string.Empty;

            this.conBusCli.txtCodCli.Text = "";
            this.conBusCli.txtNombre.Text = "";
            this.conBusCli.txtNroDoc.Text = "";
            this.conBusCli.txtCodAge.Text = "";
            this.conBusCli.txtCodInst.Text = "";
            this.conBusCli.txtDireccion.Text = "";
            this.conBusCli.txtCodCli.Enabled = true;
            this.conBusCli.txtCodCli.Focus();
            tbcDatosCredito.SelectedIndex = 0;

            this.txtBase1.Text = null;
            this.txtBase2.Text = null;

            conDatosReprogramacion.limpiarDatos();

        }

        private void btnBlanco1_Click(object sender, EventArgs e)
        {
            if (dtDatosInterv == null)
            {
                MessageBox.Show("No existen Intervinientes para el crédito seleccionado.","Intervinientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmPosicionInterv VerDatos = new frmPosicionInterv(dtDatosInterv);
            VerDatos.Show();
        }

        private void dtgPlanPagos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            try
            {
                List<clsConceptos> lstConceptos = DataTableToList.ConvertTo<clsConceptos>(new clsCNMantConceptos().ListarConceptos()) as List<clsConceptos>;

                if (e.ColumnIndex >= 0 && dtgPlanPagos.Columns[e.ColumnIndex].Name == "nOtros")
                {
                    DataGridViewRow selectedRow = dtgPlanPagos.Rows[e.RowIndex];
                    string nCuenta = selectedRow.Cells[0].Value.ToString();

                    List<clsOtrosGastos> listaGastos = DataTableToList.ConvertTo<clsOtrosGastos>(new clsCNCargaGastosCred().listarGastosPorCuenta(Convert.ToInt32(nCuenta))) as List<clsOtrosGastos>;
                    frmDetalleOtrosGastos detalleForm = new frmDetalleOtrosGastos();
                    DataGridView dataGridViewDetalleGastos = detalleForm.dtgDetalleGastos;

                    var query = from gasto in listaGastos
                                join concepto in lstConceptos on gasto.idTipoGasto equals concepto.idConcepto
                                select new
                                {
                                    gasto.idCuota,
                                    concepto.cNombreCorto,
                                    gasto.nGasto
                                };

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Cuota", typeof(string));

                    foreach (var item in query)
                    {
                        if (!dataTable.Columns.Contains(item.cNombreCorto))
                            dataTable.Columns.Add(item.cNombreCorto, typeof(decimal));

                        DataRow existingRow = null;
                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (Convert.ToInt32(row["Cuota"]) == item.idCuota)
                            {
                                existingRow = row;
                                break;
                            }
                        }

                        if (existingRow == null)
                        {
                            existingRow = dataTable.NewRow();
                            existingRow["Cuota"] = item.idCuota;
                            dataTable.Rows.Add(existingRow);
                        }
                        existingRow[item.cNombreCorto] = item.nGasto;
                    }

                    dataTable.Columns.Add("Total", typeof(decimal));

                    DataRow totalRow = dataTable.NewRow();

                    int totalFilas = dataTable.Rows.Count;
                    int totalColumnas = dataTable.Columns.Count;

                    decimal[] sumatorias = new decimal[totalColumnas];

                    for (int fila = 0; fila < totalFilas; fila++)
                    {
                        for (int columna = 0; columna < totalColumnas; columna++)
                        {
                            object cellValue = dataTable.Rows[fila][columna];
                            if (cellValue != null)
                            {
                                decimal valorCelda;
                                if (decimal.TryParse(cellValue.ToString(), out valorCelda))
                                {
                                    sumatorias[columna] += valorCelda;
                                }
                            }
                        }
                    }
                    DataRow sumRow = dataTable.NewRow();

                    for (int columna = 1; columna < totalColumnas; columna++)
                        sumRow[columna] = sumatorias[columna];

                    dataTable.Rows.Add(sumRow);

                    int ultimaFilaIndex = dataTable.Rows.Count - 1;
                    dataTable.Rows[ultimaFilaIndex][0] = "Total";

                    dataGridViewDetalleGastos.DataSource = dataTable;

                    foreach (DataGridViewRow dgvRow in dataGridViewDetalleGastos.Rows)
                    {
                        foreach (DataGridViewCell cell in dgvRow.Cells)
                        {
                            if (cell.ColumnIndex > 0 && (cell.Value == null || cell.Value is DBNull))
                            {
                                cell.Value = 0m;
                            }
                        }
                    }
                    dataGridViewDetalleGastos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    foreach (DataGridViewRow dgvRow in dataGridViewDetalleGastos.Rows)
                    {
                        decimal total = 0;
                        for (int i = 1; i < dgvRow.Cells.Count; i++)
                        {
                            decimal valor;
                            if (dgvRow.Cells[i].Value != null && decimal.TryParse(dgvRow.Cells[i].Value.ToString(), out valor))
                                total += valor;
                        }
                        dgvRow.Cells["TOTAL"].Value = total;
                    }

                    foreach (DataGridViewColumn columna in dataGridViewDetalleGastos.Columns)
                    {
                        if (columna.Name == "Cuota")
                            columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        else
                            columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    dataGridViewDetalleGastos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                    dataGridViewDetalleGastos.Columns["Cuota"].Width = 50;
                    dataGridViewDetalleGastos.Columns["Total"].Width = 70;

                    foreach (DataGridViewColumn columna in dataGridViewDetalleGastos.Columns)
                        if (columna.Name != "Cuota" && columna.Name != "Total")
                            columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; 

                    detalleForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error interno: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerSegmentoCliente(int idCliente)
        {
            string cSegmento = cliente.CNObtenerSegmentoCliente(idCliente);
            lblSegmento.ForeColor = Color.Navy;
            lblSegmento.Font = new Font(lblSegmento.Font, FontStyle.Regular);
            lblSegmento.Text = cSegmento;

            //Valida si existe la variable
            bool lExiste = clsVarApl.dicVarGen.ContainsKey("cSegmentoColorVerde");
            if (lExiste)
            {
                //Obtiene el segmento con letra verde
                string cSegmentoColorVerde = clsVarApl.dicVarGen["cSegmentoColorVerde"];
                if (cSegmentoColorVerde.ToUpper() == cSegmento.ToUpper())
                {
                    lblSegmento.ForeColor = Color.Green;
                    lblSegmento.Font = new Font(lblSegmento.Font, FontStyle.Bold);
                }
            }
        }

        #endregion

        
    }
}
