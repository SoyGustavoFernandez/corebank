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
using RCP.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using RCP.Presentacion;


namespace RCP.Presentacion
{
    public partial class frmListPosCredParaCastigo : frmBase
    {
        #region Variables
        clsCNCreditoCastigo cnCreditoCastigo = new clsCNCreditoCastigo();
        DataTable dtLisPropCreCastigo = new DataTable("dtLisPropCreCastigo");
        string prefijoCodigo = "CPC";
        DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
        DateTime dFechaSis;
        Nullable<DateTime> dFechaCas;

        Transaccion nTran;

        static Color cColorCumple = Color.Aqua;
        static Color cColorNoCumple = Color.Gray;

        int idUsuaReg;
        int idUsuaMod;
        
        int idLista;
        int idEstado;

        string cTituloMsg = "Lista de Propuesta Crétidos Castigados";
        #endregion
        #region Metodos
        public frmListPosCredParaCastigo()
        {
            InitializeComponent();
            actualizarBotonesPorEstado(0);
            dtpCorto1.Value = clsVarGlobal.dFecSystem;

            lblCumple.BackColor = cColorCumple;
            lblNoCumple.BackColor = cColorNoCumple;
            nTran = Transaccion.Elimina;
            ControlBotones();
        }

        private void frmListPosCredParaCastigo_Load(object sender, EventArgs e)
        {
            cboCalificacion.SelectedValue = 4;
            txtSinPagos.Text = clsVarApl.dicVarGen["cDiasImpagosListPropCast"].ToString();
        }

        private void formatoGridVin(DataGridView dtgCreditos, bool lSelVisible = true)
        {
            dtgCreditos.ReadOnly = false;

            foreach (DataGridViewColumn item in dtgCreditos.Columns)
            {
                //item.SortMode = DataGridViewColumnSortMode.NotSortable;
                item.Visible = false;
                item.ReadOnly = true;
            }

            dtgCreditos.Columns["lSel"].ReadOnly = false;

            dtgCreditos.Columns["cContable"].Visible = true;
            dtgCreditos.Columns["nMontoTotalCastigo"].Visible = true;
            dtgCreditos.Columns["nMontoTotalCastigoMO"].Visible = true;

            dtgCreditos.Columns["lSel"].Visible = lSelVisible;
            dtgCreditos.Columns["nAtraso"].Visible = true;
            dtgCreditos.Columns["cNroCuentaCredito"].Visible = true;
            
            dtgCreditos.Columns["nSaldoCapParaCastigar"].Visible = true;
            dtgCreditos.Columns["nIntCompen"].Visible = true;
            dtgCreditos.Columns["nIntMora"].Visible = true;
            dtgCreditos.Columns["nOtros"].Visible = true;

            dtgCreditos.Columns["nSaldoCapParaCastigarMO"].Visible = true;
            dtgCreditos.Columns["nIntCompenMO"].Visible = true;
            dtgCreditos.Columns["nIntMoraMO"].Visible = true;
            dtgCreditos.Columns["nOtrosMO"].Visible = true;
            
            dtgCreditos.Columns["cNombreCliente"].Visible = true;
            dtgCreditos.Columns["cNombreAge"].Visible = true;
            dtgCreditos.Columns["dFechaDesembolso"].Visible = true;
            dtgCreditos.Columns["cProducto"].Visible = true;
            dtgCreditos.Columns["nPorProv"].Visible = true;            
            dtgCreditos.Columns["cMoneda"].Visible = true;
            dtgCreditos.Columns["nInt"].Visible = true;
            dtgCreditos.Columns["nIntMO"].Visible = true;
            //dtgCreditos.Columns["cNroCuentaAhorros"].Visible = true;
            //dtgCreditos.Columns["nMontoDeposito"].Visible = true;

            dtgCreditos.Columns["cContable"].HeaderText = "Cond. Contable";
            dtgCreditos.Columns["nAtraso"].HeaderText = "Días Atraso";
            dtgCreditos.Columns["cNroCuentaCredito"].HeaderText = "Nro Cuenta Crédito";
            dtgCreditos.Columns["nSaldoCapParaCastigarMO"].HeaderText = "Saldo Castigar MO";
            dtgCreditos.Columns["nIntCompenMO"].HeaderText = "Int. Comp. MO";
            dtgCreditos.Columns["nIntMoraMO"].HeaderText = "Int. Morat. MO";
            dtgCreditos.Columns["nOtrosMO"].HeaderText = "Otros MO";
            dtgCreditos.Columns["nSaldoCapParaCastigar"].HeaderText = "Saldo Castigar";
            dtgCreditos.Columns["nIntCompen"].HeaderText = "Int. Comp.";
            dtgCreditos.Columns["nIntMora"].HeaderText = "Int. Morat.";
            dtgCreditos.Columns["nOtros"].HeaderText = "Otros";
            dtgCreditos.Columns["cNombreCliente"].HeaderText = "Cliente";
            dtgCreditos.Columns["cNombreAge"].HeaderText = "Agencia";
            dtgCreditos.Columns["dFechaDesembolso"].HeaderText = "Fecha Desembolso";
            dtgCreditos.Columns["cProducto"].HeaderText = "Producto";
            dtgCreditos.Columns["nPorProv"].HeaderText = "Provision";
            dtgCreditos.Columns["lSel"].HeaderText = "Sel.";
            dtgCreditos.Columns["cMoneda"].HeaderText = "Moneda";
            dtgCreditos.Columns["nInt"].HeaderText = "Int.";
            dtgCreditos.Columns["nIntMO"].HeaderText = "Int. MO";
            dtgCreditos.Columns["nMontoTotalCastigo"].HeaderText = "Monto Total";
            dtgCreditos.Columns["nMontoTotalCastigoMO"].HeaderText = "Monto Total MO";
            // dtgCreditos.Columns["cNroCuentaAhorros"].HeaderText = "Nro Cta. Ahorros";
            // dtgCreditos.Columns["nMontoDeposito"].HeaderText = "Monto Deposito";

            dtgCreditos.Columns["nAtraso"].Width = 30;
            dtgCreditos.Columns["cNroCuentaCredito"].Width = 150;
            dtgCreditos.Columns["nSaldoCapParaCastigar"].Width = 80;
            dtgCreditos.Columns["nIntCompen"].Width = 40;
            dtgCreditos.Columns["nIntMora"].Width = 40;
            dtgCreditos.Columns["nOtros"].Width = 40;
            dtgCreditos.Columns["cNombreCliente"].Width = 200;
            dtgCreditos.Columns["cNombreAge"].Width = 150;
            dtgCreditos.Columns["dFechaDesembolso"].Width = 90;
            dtgCreditos.Columns["cProducto"].Width = 150;
            dtgCreditos.Columns["nPorProv"].Width = 50;

            dtgCreditos.Columns["nSaldoCapParaCastigarMO"].DefaultCellStyle.Format = "N2";
            dtgCreditos.Columns["nIntCompenMO"].DefaultCellStyle.Format = "N2";
            dtgCreditos.Columns["nIntMoraMO"].DefaultCellStyle.Format = "N2";
            dtgCreditos.Columns["nOtrosMO"].DefaultCellStyle.Format = "N2";
            dtgCreditos.Columns["nSaldoCapParaCastigar"].DefaultCellStyle.Format = "N2";
            dtgCreditos.Columns["nIntCompen"].DefaultCellStyle.Format = "N2";
            dtgCreditos.Columns["nIntMora"].DefaultCellStyle.Format = "N2";
            dtgCreditos.Columns["nOtros"].DefaultCellStyle.Format = "N2";
            dtgCreditos.Columns["nInt"].DefaultCellStyle.Format = "N2";
            dtgCreditos.Columns["nIntMO"].DefaultCellStyle.Format = "N2";
            dtgCreditos.Columns["nPorProv"].DefaultCellStyle.Format = "P0";
            dtgCreditos.Columns["nMontoTotalCastigo"].DefaultCellStyle.Format = "N2";
            dtgCreditos.Columns["nMontoTotalCastigoMO"].DefaultCellStyle.Format = "N2";

            pintarSiCumpleConfiltros(dtgListaPosiblesCreCast);
            pintarSiCumpleConfiltros(dtgListaCredProp);
        }

        private void cargarDtgListaPosiblesCreCast(DataTable dtCreditosCastigados)
        {
            dtCreditosCastigados.Columns["lSel"].ReadOnly = false;
            dtgListaPosiblesCreCast.DataSource = dtCreditosCastigados;
            formatoGridVin(dtgListaPosiblesCreCast);
        }

        private void pintarSiCumpleConfiltros(DataGridView dtgCre)
        {
            foreach (DataGridViewRow item in dtgCre.Rows)
            {
                if (Convert.ToInt32(item.Cells["nCumpleFiltros"].Value) == 1)
                {
                    item.DefaultCellStyle.BackColor = cColorCumple;
                }
                else
                {
                    item.DefaultCellStyle.BackColor = cColorNoCumple;
                }
            }
        }

        private DataTable cargarMotivoCastigo()
        {
            return cnCreditoCastigo.CNMotivosCastigo();
        }
        
        private Boolean validarPropuestaCreditos()
        {
            Boolean state = true;
            dtLisPropCreCastigo = (DataTable)dtgListaCredProp.DataSource;
            dtLisPropCreCastigo.TableName = "dtLisPropCreCastigo";
            // int i = 0;
            // foreach (DataGridViewRow item in dtgListaCredProp.Rows)
            // {
            //     var idMotivo = item.Cells["nMotivoCast"].Value;
            //     if (idMotivo == null)
            //     {
            //         state = false;
            //         dtLisPropCreCastigo.Rows[i]["idMotivo"] = -1;
            //     }
            //     else
            //     {
            //         dtLisPropCreCastigo.Rows[i]["idMotivo"] = (int)idMotivo;
            //     }
            //     i++;
            // }
            return state;
            
        }
       
        // private void actualizaridMotivoCombo()
        // {
        //     int i = 0;
        //     foreach (DataRow item in ((DataTable)dtgListaCredProp.DataSource).Rows)
        //     {
        //         if (Convert.ToInt32(item["idMotivo"]) > 0)
        //         {
        //             DataGridViewComboBoxCell cellCombo = new DataGridViewComboBoxCell();
        //             cellCombo.DataSource = cmb.DataSource;
        //             cellCombo.Value = (cmb.Items[Convert.ToInt32(item["idMotivo"]) - 1] as DataRowView).Row[0];
        //             dtgListaCredProp.Rows[i].Cells["nMotivoCast"].Value = cellCombo.Value;
        //         }
        //         i++;
        //     }
        // }
        private void refrescarDtg()
        {
            dtgListaPosiblesCreCast.Update();
            dtgListaPosiblesCreCast.Refresh();
            dtgListaCredProp.Update();
            dtgListaCredProp.Refresh();
        }
        private void actualizarBotonesPorEstado(int idEstado)
        {
            switch (idEstado) { 
                case 0:
                    btnGrabar1.Enabled = true;
                    btnCancelar1.Enabled = false;
                    btnNuevo1.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnAnexo7.Enabled = false;
                    break;
                case 1: // creado 
                    btnGrabar1.Enabled = false;
                    btnCancelar1.Enabled = false;
                    btnNuevo1.Enabled = true;
                    btnEditar1.Enabled = true;
                    btnAnexo7.Enabled = true;
                    break;
                case 2: // enviado al jefe de recuperaciones
                    btnGrabar1.Enabled = false;
                    btnCancelar1.Enabled = false;
                    btnNuevo1.Enabled = true;
                    btnEditar1.Enabled = true;
                    btnAnexo7.Enabled = true;
                    break;
                case 3: // propuesto para castigar asignar codigo
                    btnGrabar1.Enabled = false;
                    btnCancelar1.Enabled = false;
                    btnNuevo1.Enabled = true;
                    btnEditar1.Enabled = true;
                    btnAnexo7.Enabled = true;
                    break;
                case 4: // ENVIADO GERENCIA DE OPERACIONES PARA DESBLOQUEAR CTAS. DE GARANTIA
                    btnCancelar1.Enabled = false;
                    btnNuevo1.Enabled = true;
                    btnEditar1.Enabled = true;
                    btnGrabar1.Enabled = false;
                    btnAnexo7.Enabled = true;
                    break;
                case 5: //GENERACION DE REPORTE ACTUALIZADO DE CREDITOS CÁSTIGADOS
                    btnGrabar1.Enabled = false;
                    btnCancelar1.Enabled = false;
                    btnNuevo1.Enabled = true;
                    btnEditar1.Enabled = true;
                    btnAnexo7.Enabled = false;
                    break;
                case 6: //ENVIADO GERENCIA DE RIESGOS DIRECTORIO
                    btnGrabar1.Enabled = false;
                    btnCancelar1.Enabled = false;
                    btnNuevo1.Enabled = true;
                    btnEditar1.Enabled = true;
                    btnAnexo7.Enabled = false;
                    break;
                case 7: //CASTIGADO
                    btnGrabar1.Enabled = false;
                    btnCancelar1.Enabled = false;
                    btnNuevo1.Enabled = true;
                    btnEditar1.Enabled = true;
                    btnAnexo7.Enabled = true;
                    break;
                default:
                    btnGrabar1.Enabled = false;
                    btnAnexo7.Enabled = false;
                    break;

            }
        }

        public void prepParamListaCreditosCastigados(int idEstado)
        {
            dFechaCas = null;
            switch (idEstado)
            {   
                case 0:
                    dFechaSis = clsVarGlobal.dFecSystem;
                    idUsuaReg = clsVarGlobal.User.idUsuario;
                    idUsuaMod = 0;
                    
                    idEstado  = 1;
                    break;
                case 1:
                    idUsuaMod = clsVarGlobal.User.idUsuario;
                    break;
                case 2:
                    idUsuaMod = clsVarGlobal.User.idUsuario;
                    break;
                case 3: //asignar codigo
                    idUsuaMod = clsVarGlobal.User.idUsuario;
                    break;
                case 4:
                    idUsuaMod = clsVarGlobal.User.idUsuario;
                    break;
                case 5:
                    idUsuaMod = clsVarGlobal.User.idUsuario;
                    break;
                case 6: // Verifica Parametros de Registro de Castigo
                    idUsuaMod = clsVarGlobal.User.idUsuario;
                    break;

                default:
                    break;
            }
        }

        private void grabarListaCreditos(int idEstado)
        {
            if (dtgListaCredProp.Rows.Count == 0)
            {
                MessageBox.Show("La lista de créditos no tiene ningún elemento", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!validarPropuestaCreditos())
            {
                MessageBox.Show("Seleccione el motivo de castigo de todos los créditos", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataSet dsLisPropCreCastigo = new DataSet("dsLisPropCreCastigo");
            string cLisPropCreCastigo = "";

            if (dtLisPropCreCastigo.DataSet != null)
            {
                dtLisPropCreCastigo.DataSet.Clear();
            }

            dsLisPropCreCastigo.Tables.Add(dtLisPropCreCastigo.Copy());

            cLisPropCreCastigo = dsLisPropCreCastigo.GetXml();

            prepParamListaCreditosCastigados(idEstado);
            DataTable dtResult = cnCreditoCastigo.CNGuargarListaCreditosParaCastigo(cLisPropCreCastigo, dFechaCas, idUsuaReg, idUsuaMod, dFechaSis, idEstado, idLista);
            if (Convert.ToInt32(dtResult.Rows[0]["nResultado"]) == 1)
            {
                idLista = Convert.ToInt32(dtResult.Rows[0]["idLista"]);
                actualizarBotonesPorEstado(idEstado);
                txtBase1.Text = dtResult.Rows[0]["cCodigoCastigo"].ToString();
                txtUsuReg.Text = dtResult.Rows[0]["cWinUserReg"].ToString();
                txtEstado.Text = dtResult.Rows[0]["cEstado"].ToString();
                nTran = Transaccion.Selecciona;
                ControlBotones();  

                MessageBox.Show(dtResult.Rows[0]["cMensaje"].ToString(), cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                idEstado = idEstado - 1;
                MessageBox.Show(dtResult.Rows[0]["cMensaje"].ToString(), cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void LimpiarFormulario()
        {
            txtBase1.Clear();
            txtUsuReg.Clear();
            txtEstado.Clear();
            idLista = 0;
            dtgListaCredProp.DataSource = null;
            dtgListaPosiblesCreCast.DataSource = null;

        }
        
        private void obtenerListaDeCreditosCstigados()
        {
            DataTable creditosCast = cnCreditoCastigo.CNListarCredParaCastigo(idLista);

            if (creditosCast.Rows.Count == 0)
            {
                MessageBox.Show("No hay Resultado para ese código", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dtgListaCredProp.DataSource != null)
                {
                    ((DataTable)dtgListaCredProp.DataSource).Clear();
                }
                return;
            }

            txtBase1.Text = creditosCast.Rows[0]["cCodigo"].ToString();
            txtUsuReg.Text = creditosCast.Rows[0]["cWinUserReg"].ToString();
            dtpCorto1.Value = (DateTime)((creditosCast.Rows[0]["dFechaRegistro"] == DBNull.Value)?null :creditosCast.Rows[0]["dFechaRegistro"]);
            txtEstado.Text = creditosCast.Rows[0]["cEstado"].ToString();

            idEstado = (int)creditosCast.Rows[0]["idEstado"];
            idUsuaReg = (int)creditosCast.Rows[0]["idWinUserReg"];
            dFechaSis = (DateTime)((creditosCast.Rows[0]["dFechaRegistro"] == DBNull.Value)? null : creditosCast.Rows[0]["dFechaRegistro"]);
            actualizarBotonesPorEstado(idEstado);
            //traendo los creditos de la lista

            DataTable dtCreditoCast = cnCreditoCastigo.CNListaCreditosCastGuardados(idLista, dFechaSis);
            if (dtCreditoCast.Rows.Count == 0)
            {
                MessageBox.Show("No hay elementos en la Lista puede agregar algunos", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dtgListaCredProp.DataSource != null)
                {
                    ((DataTable)dtgListaCredProp.DataSource).Clear();
                }
                return;
            }
            dtgListaCredProp.DataSource = dtCreditoCast;
            dtCreditoCast.Columns["lSel"].ReadOnly = false;
            formatoGridVin(dtgListaCredProp);
            dtgListaCredProp.Columns["lSel"].Visible = false;
        }

        private void agregarAPropuesta()
        {
            if (dtgListaPosiblesCreCast.Rows.Count == 0)
            {
                MessageBox.Show("No hay elementos para agregar", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtSeleccionados = ((DataTable)dtgListaPosiblesCreCast.DataSource).Clone();

            foreach (DataRow item in ((DataTable)dtgListaPosiblesCreCast.DataSource).Rows)
            {
                if (item != null)
                {
                    if (Convert.ToBoolean(item["lSel"]))
                    {
                        dtSeleccionados.ImportRow(item);
                        item.Delete();
                    }
                }
            }

            if ((DataTable)dtgListaCredProp.DataSource != null)
            {
                foreach (DataRow item in ((DataTable)dtgListaCredProp.DataSource).Rows)
                {
                    if (item != null)
                    {
                        dtSeleccionados.ImportRow(item);
                    }
                }
            }

            ((DataTable)dtgListaPosiblesCreCast.DataSource).AcceptChanges();
            dtgListaCredProp.DataSource = dtSeleccionados;

            formatoGridVin(dtgListaCredProp);
            dtgListaCredProp.Columns["lSel"].Visible = false;
            refrescarDtg();
        }

        private void quitarDePropuesta()
        {
            if (dtgListaCredProp.Rows.Count == 0)
            {
                MessageBox.Show("No hay elementos que eliminar", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtgListaPosiblesCreCast.Columns.Count > 0)
            {
                int nFila = dtgListaCredProp.SelectedRows[0].Index,
                    idCli = Convert.ToInt32(dtgListaCredProp.Rows[nFila].Cells["idCli"].Value);

                for (int i = 0; i < ((DataTable)dtgListaCredProp.DataSource).Rows.Count; i++)
                {
                    if (Convert.ToInt32(((DataTable)dtgListaCredProp.DataSource).Rows[i]["idCli"]) == idCli)
                    {
                        quitarDePropuestaPoridCli(i);
                    }
                }

            }
            else
            {
                int nFila = dtgListaCredProp.SelectedRows[0].Index,
                                    idCli = Convert.ToInt32(dtgListaCredProp.Rows[nFila].Cells["idCli"].Value);

                for (int i = 0; i < ((DataTable)dtgListaCredProp.DataSource).Rows.Count; i++)
                {
                    if (Convert.ToInt32(((DataTable)dtgListaCredProp.DataSource).Rows[i]["idCli"]) == idCli)
                    {
                        quitarDePropuestaPoridCli(i, true);
                    }
                }
            }

            ((DataTable)dtgListaCredProp.DataSource).AcceptChanges();
            formatoGridVin(dtgListaCredProp, false);
        }

        private void quitarDePropuestaPoridCli(int nFilaIndice, bool lEliminarSinPasar = false)
        {
            DataTable dtTempCred = (DataTable)dtgListaPosiblesCreCast.DataSource;
            ((DataTable)dtgListaCredProp.DataSource).Rows[nFilaIndice]["lSel"] = false;

            if (!lEliminarSinPasar)
            {
                dtTempCred.ImportRow(((DataRow)((DataTable)dtgListaCredProp.DataSource).Rows[nFilaIndice]));
                dtgListaPosiblesCreCast.DataSource = dtTempCred;
                formatoGridVin(dtgListaPosiblesCreCast);
            }
            
            ((DataTable)dtgListaCredProp.DataSource).Rows[nFilaIndice].Delete();
        }

        private void SeleccionaCredMismoCliente(int nIndiceFila)
        {
            int idCli = Convert.ToInt32(dtgListaPosiblesCreCast.Rows[nIndiceFila].Cells["idCLi"].Value);
            Boolean lSel = Convert.ToBoolean(dtgListaPosiblesCreCast.Rows[nIndiceFila].Cells["lSel"].Value);
            foreach (DataGridViewRow item in dtgListaPosiblesCreCast.Rows)
            {
                if (Convert.ToInt32(item.Cells["idCli"].Value) == idCli)
                {
                    item.Cells["lSel"].Value = lSel;
                }
            }
        }
        
        /// <summary>
        /// Prepara parametros y envía consulta para la obtención o 
        /// </summary>
        /// <param name="nObtencion">Tipo de obtención: 1: consulta créditos; 2: consulta créditos con garantias para reporte</param>
        private void PrepararParametrosConsulta(int nObtencion) 
        {
            Cursor.Current = Cursors.WaitCursor;
            int nDiasAtra,
               idClasifi,
               idCalificacion,
               nDiasImpagos;
            decimal nProvi;
            DateTime dFecha;
            string cXmlAgencias = "";

            nDiasAtra = Convert.ToInt32(txtDiasAtraso.Value);
            idClasifi = Convert.ToInt32(cboCalificacion.SelectedValue);
            nProvi = nudProvision.Value;
            dFecha = clsVarGlobal.dFecSystem;
            idCalificacion = Convert.ToInt32(cboCalificacion.SelectedValue);
            nDiasImpagos = Convert.ToInt32(txtSinPagos.Text);
            DataTable dtRes = conListAgencias1.obtenerAgenciasSeleccionados();
            DataSet dsRes = new DataSet("dsAgencia");

            dsRes.Tables.Add(dtRes);
            cXmlAgencias = dsRes.GetXml();

            switch (nObtencion)
            { 
                case 1:
                    DataTable ListaSugerencia = cnCreditoCastigo.CNBuscarPosiblesCredParaCastigo(cXmlAgencias, nDiasAtra, idClasifi, nProvi, dFecha, nDiasImpagos);
                        if (ListaSugerencia.Rows.Count == 0)
                        {
                            dtgListaPosiblesCreCast.DataSource = null;
                            MessageBox.Show("No Existe Ninguna Sugerencia con esos Filtros", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Cursor.Current = Cursors.Default;
                            return;
                        }
                        cargarDtgListaPosiblesCreCast(ListaSugerencia);
                    break;
                case 2:
                    DataTable CredConGarantias = cnCreditoCastigo.CNRptGarantiasDeCredVencidos(cXmlAgencias, nDiasAtra, idClasifi, nProvi, dFecha, nDiasImpagos);
                        if (CredConGarantias.Rows.Count == 0)
                        {
                            MessageBox.Show("No Existen creditos con garantías ejecutable", cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Cursor.Current = Cursors.Default;
                            return;
                        }
                        List<ReportParameter> paramlist = new List<ReportParameter>();

                        paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge.ToString(), false));
                        //paramlist.Add(new ReportParameter("cUsuWin",  clsVarGlobal.User.cWinUser.ToString(), false));
                        paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                        paramlist.Add(new ReportParameter("cRutaLogo", EntityLayer.clsVarApl.dicVarGen["CRUTALOGO"], false));

                        List<ReportDataSource> dtslist = new List<ReportDataSource>();

                        dtslist.Add(new ReportDataSource("dsRpt", CredConGarantias));
                        string reportpath = "rptCreditosConGarantiaEjecutable.rdlc";
                        new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                    break;
            }
            Cursor.Current = Cursors.Default;
            
        }
        #endregion

        #region Eventos

        private void btnBusqueda1_Click(object sender, EventArgs e)
        {
            PrepararParametrosConsulta(1);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var dtCreditosCastigados = (DataTable)dtgListaPosiblesCreCast.DataSource;
            dtCreditosCastigados.AsEnumerable().ToList().ForEach(x => x["lSel"] = checkBox1.Checked);

        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            grabarListaCreditos(idEstado);
        }
        
        private void btnMiniBusq1_Click(object sender, EventArgs e)
        {
            frmBuscarPropuestaCredCastigados frmPropuesta = new frmBuscarPropuestaCredCastigados();
            frmPropuesta.ShowDialog();
            if (frmPropuesta.idPlan > 0)
            {
                idLista = frmPropuesta.idPlan;
                obtenerListaDeCreditosCstigados();
                idEstado = 2; //Editando
                nTran = Transaccion.Selecciona;
                ControlBotones();  
            }
        }

        private void btnNuevo1_Click(object sender, EventArgs e)
        {
            //actualizarBotonesPorEstado(idEstado);
            nTran = Transaccion.Nuevo;
            ControlBotones();
            LimpiarFormulario();
        }
        
        private void boton1_Click(object sender, EventArgs e)
        {
            idEstado = 2;

            grabarListaCreditos(idEstado); // generando propuesta
        }

        private void btnEnvJefeRec_Click(object sender, EventArgs e)
        {
            
            grabarListaCreditos(idEstado); // generando propuesta
        }

        private void btnAnexo7_Click(object sender, EventArgs e)
        {
            int nFiltro = 0;
            string cNomEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cNomAgen = clsVarGlobal.cNomAge;
            string cUsuWin = clsVarGlobal.User.cWinUser;

            DataTable dtListaCredCast = cnCreditoCastigo.CNListarCredParaCastigo(idLista);
            DataTable dtAnexo7 = cnCreditoCastigo.CNAnexo7(idLista, clsVarGlobal.dFecSystem, nFiltro);
            if (dtListaCredCast.Rows.Count > 0)
            {
                if (dtAnexo7.Rows.Count > 0)
                {
                    List<ReportParameter> paramlist = new List<ReportParameter>();

                    paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                    paramlist.Add(new ReportParameter("cUsuWin", cUsuWin, false));
                    paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                    paramlist.Add(new ReportParameter("cRutaLogo", EntityLayer.clsVarApl.dicVarGen["CRUTALOGO"], false));

                    List<ReportDataSource> dtslist = new List<ReportDataSource>();

                    dtslist.Add(new ReportDataSource("dsResuListaCreCast", dtListaCredCast));
                    dtslist.Add(new ReportDataSource("dsListaCreCast", dtAnexo7));
                    string reportpath = "rptAnexo7Recuperaciones.rdlc";
                    new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                }
                else
                {
                    MessageBox.Show("No Hay créditos para esa lista", "Anexo 7 - Recuperaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                
            }
            else
            {
                MessageBox.Show("No Hay elementos para esa Lista", "Anexo 7 - Recuperaciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        
        }

        private void boton8_Click(object sender, EventArgs e)
        {
            //agregar codigo
            int nTamCodigo = 8;
            string cCeros = "";
            int nTamActual = Convert.ToString(idLista).Length;
            if ( nTamActual < nTamCodigo)
            {
                for (int i = 0; i < nTamCodigo-nTamActual; i++)
                {
                    cCeros += "0";
                }
            }
            idEstado = 3;
            DataTable dtCodigo = cnCreditoCastigo.CNAsignarCodigo(idLista, prefijoCodigo+cCeros+idLista, idEstado, "",clsVarGlobal.dFecSystem);
            if (dtCodigo.Rows.Count > 0)
            {
                MessageBox.Show(dtCodigo.Rows[0]["cMensaje"].ToString(), cTituloMsg, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Convert.ToInt32(dtCodigo.Rows[0]["nResultado"]) == 1)
                {
                    txtBase1.Text = prefijoCodigo + cCeros + idLista;
                    actualizarBotonesPorEstado(idEstado);
                }
            }

        }

        private void ControlBotones()
        {
            switch (nTran)
            {
                case Transaccion.Elimina: // Estado iniciado
                    conListAgencias1.Enabled = false;
                    txtDiasAtraso.Enabled = false;
                    nudProvision.Enabled = false;
                    btnBusqueda1.Enabled = false;
                    btnImprimir1.Enabled = false;
                    grbBase4.Enabled = false;
                    btnMiniBusq1.Enabled = true;
                    btnQuitar1.Enabled = false;
                    //Botones
                    btnNuevo1.Enabled = true;
                    btnCancelar1.Enabled = false;
                    btnEditar1.Enabled = false;
                    btnGrabar1.Enabled = false;
                    btnAnexo7.Enabled = false;
                    break;
                case Transaccion.Selecciona:
                    conListAgencias1.Enabled = false;
                    txtDiasAtraso.Enabled = false;
                    nudProvision.Enabled = false;
                    btnBusqueda1.Enabled = false;
                    btnImprimir1.Enabled = false;
                    grbBase4.Enabled = false;
                    btnMiniBusq1.Enabled = true;
                    btnQuitar1.Enabled = false;
                    //Botones
                    btnNuevo1.Enabled = false;
                    btnCancelar1.Enabled = true;
                    btnEditar1.Enabled = true;
                    btnGrabar1.Enabled = false;
                    btnAnexo7.Enabled = true;
                    break;
                case Transaccion.Nuevo:
                    conListAgencias1.Enabled = true;
                    txtDiasAtraso.Enabled = true;
                    btnBusqueda1.Enabled = true;
                    btnImprimir1.Enabled = true;
                    grbBase4.Enabled = true;
                    btnMiniBusq1.Enabled = false;
                    btnQuitar1.Enabled = true;
                    
                    //Botones
                    btnNuevo1.Enabled = false;
                    btnCancelar1.Enabled = true;
                    btnEditar1.Enabled = false;
                    btnGrabar1.Enabled = true;
                    btnAnexo7.Enabled = false;
                    break;
                case Transaccion.Edita:
                    conListAgencias1.Enabled = true;
                    txtDiasAtraso.Enabled = true;
                    btnBusqueda1.Enabled = true;
                    btnImprimir1.Enabled = true;
                    grbBase4.Enabled = true;
                    btnMiniBusq1.Enabled = false;
                    btnQuitar1.Enabled = true;
                    //Botones
                    btnNuevo1.Enabled = false;
                    btnCancelar1.Enabled = true;
                    btnEditar1.Enabled = false;
                    btnGrabar1.Enabled = true;
                    btnAnexo7.Enabled = false;
                    break;
            }
        }
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            nTran = Transaccion.Edita;
            ControlBotones();           
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        { 
            int idLista2 = idLista;
            obtenerListaDeCreditosCstigados();
            LimpiarFormulario();
            nTran = Transaccion.Elimina;
            ControlBotones();           
        }

        private void btnAgregar1_Click_1(object sender, EventArgs e)
        {
            agregarAPropuesta();
        }

        private void btnQuitar1_Click_1(object sender, EventArgs e)
        {
            quitarDePropuesta();
        }
        
        private void dtgListaPosiblesCreCast_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (dtgListaPosiblesCreCast.RowCount == 0)
            //    return;
            //if (dtgListaPosiblesCreCast.Columns[e.ColumnIndex].Name == "lSel" && e.RowIndex >= 0)
            //{
            //    SeleccionaCredMismoCliente(e.RowIndex);
            //}
        }

        

        private void dtgListaPosiblesCreCast_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtgListaPosiblesCreCast.IsCurrentCellDirty)
            {
                dtgListaPosiblesCreCast.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            PrepararParametrosConsulta(2);
        }

        private void dtgListaPosiblesCreCast_Sorted(object sender, EventArgs e)
        {
            pintarSiCumpleConfiltros(dtgListaPosiblesCreCast);
            pintarSiCumpleConfiltros(dtgListaCredProp);
        }

        private void dtgListaCredProp_Sorted(object sender, EventArgs e)
        {
            pintarSiCumpleConfiltros(dtgListaPosiblesCreCast);
            pintarSiCumpleConfiltros(dtgListaCredProp);
        }

        #endregion
    }
}
