using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using System.IO;
using System.Net;
using GEN.Funciones;
using System.Text.RegularExpressions;

namespace CRE.Presentacion
{
    public partial class frmTasaNegociable : frmBase
    {

        #region Variables Globales

        DataTable Sol = new DataTable("dtSolicitud");
        int nCodPro = 1, nCodEst = 0, idCliente = 0, idAgencia = clsVarGlobal.nIdAgencia, idZonaUsuario = 0;
        int idTasa = 0;
        bool lEstado = true, lValGarantia = false, lGrabado = false, lEdicion = false, lSalir = false, lformclosing = false;
        public bool lTasafrm = false, lTasaNegociada = true;
        decimal nMontoSolicitado = 0;
        char Transaccion = Convert.ToChar("I");
        public int idEstadoSol = 0, idSolicitud_frm = 0;
        clsCNValidaReglasDinamicas ValidaReglasDinamicas = new clsCNValidaReglasDinamicas();
        clsCNSolicitud cnsolicitud = new clsCNSolicitud();
        int idClasificacionInterna;
        DateTime dFechaDesembolso;
        private string cGlobal_NombreCli = "", cGlobal_cDocumento = "", c_txtJustificacion = "", c_txtOtros = "", c_txtComentarios = "", c_txtTasaSolicitada = "0", c_txtTasaExt = "0", c_txtImporteExt = "0";
        private int cGlobal_idsolicitud = 0, cGlobal_idEstadoTasa = 999, cGlobal_idTasaNegociada = 0, cGlobal_nEstadoCredito = 0;
        private decimal  cGlobal_TasaMax = 0;
        private string cEstado_TNegociable = "[]";
        DataTable dtParamEnvioEmail = new DataTable();
        DataTable dtParamEnvioSMS = new DataTable();
        string cNombreUsuario = clsVarGlobal.User.cNomUsu;
        string cNombreagencia = clsVarGlobal.cNomAge;
        string cPerfilUsuario = clsVarGlobal.PerfilUsu.cPerfil;
        #endregion

        public frmTasaNegociable()
        {
            InitializeComponent();

            DataTable dtESolTasa = cnsolicitud.CNObtenerEstadoSolicitudTasaNegociable();
            if (dtESolTasa.Rows.Count > 0) 
            {
                cEstado_TNegociable = Convert.ToString(dtESolTasa.Rows[0]["cValVar"]);
            }

            this.conBusCuentaCli1.cTipoBusqueda = "S";
            this.conBusCuentaCli1.cEstado = cEstado_TNegociable;
            this.conBusCuentaCli1.lTasaBusqueda = true;
            cboTipoCredito.CargarProducto(nCodPro);

            cboPersonalCreditos.SelectedValue = 0;
            cboDestinoCredito.SelectedValue = 0;
            cboOperacionCre1.SelectedValue = 0;

            btnAnular1.Enabled = false;

            txtJustificacionSolicitud.TextChanged += txtJustificacionSolicitud_TextChanged;
            txtOtros.TextChanged += txtOtros_TextChanged;
            txtComentariosEntFinanciera.TextChanged += txtCBLetra1_TextChanged;

            txtTasaCompensatoria.TextChanged += txtTasaCompensatoria_TextChanged;
            txtTasaEntExt.TextChanged += txtTasaEntExt_TextChanged;
            txtImporteEntExt.TextChanged += txtImporteEntExt_TextChanged;

        }

        public frmTasaNegociable(int idCli, int idSolicitud)
        {
            InitializeComponent();

            DataTable dtESolTasa = cnsolicitud.CNObtenerEstadoSolicitudTasaNegociable();
            if (dtESolTasa.Rows.Count > 0)
            {
                cEstado_TNegociable = Convert.ToString(dtESolTasa.Rows[0]["cValVar"]);
            }

            this.conBusCuentaCli1.cTipoBusqueda = "S";
            this.conBusCuentaCli1.cEstado = cEstado_TNegociable;
            cboTipoCredito.CargarProducto(nCodPro);

            cboPersonalCreditos.SelectedValue = 0;
            cboDestinoCredito.SelectedValue = 0;
            cboOperacionCre1.SelectedValue = 0;

            this.conBusCuentaCli1.buscarCuentasPorCliente(idCli);
            buscarCuenta(idSolicitud);            
        }

        private void frmTasaNegociable_Load(object sender, EventArgs e)
        {
            if (lTasafrm == true) 
            {
                pnlExpandCollapse5.Visible = false;
                flowLayoutPanel4.Size = new System.Drawing.Size(699, 370);
            }
        }

        private void buscarCuenta(int idSolicitud)
        {
            if (idSolicitud == 0)
            {
                limpiar();
                MessageBox.Show("No se encontró número de solicitud.", "Valida solicitud de cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string cEstado = "";
            clsCNSolicitud cnsolicitud = new clsCNSolicitud();
            DataTable dtESolTasa = cnsolicitud.CNObtenerEstadoSolicitudTasaNegociable();
            if (dtESolTasa.Rows.Count > 0)
            {
                cEstado = Convert.ToString(dtESolTasa.Rows[0]["cValVar"]);
            }

            if (cEstado.Contains(Convert.ToString(cGlobal_nEstadoCredito).Trim()))
            {
                BuscarSolicitud(idSolicitud);
            }
            else 
            {
                var cEstadosTasa = "";
                clsCNSolicitud cnMsgsolicitud = new clsCNSolicitud();
                DataTable dtEstadosTasa = cnMsgsolicitud.CNObtenerEstadoTasaNegociable();
                foreach (DataRow fila in dtEstadosTasa.Rows)
                {
                    cEstadosTasa = cEstadosTasa + fila["cEstado"].ToString() + ",";
                }
                MessageBox.Show("La solicitud de crédito del cliente no se encuentra dentro de los estados permitidos[" + cEstadosTasa + "].", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
               
        }
        private void limpiar()
        {

            txtMonto.Text = "";
            cboMoneda.SelectedValue = 0;
            nudCuotas.Value = 0;
            nudPlazo.Value = 0;
            nudDiasGracia.Value = 0;
            dtFechaDesembolso.Value = DateTime.Today;
            cboOperacionCre1.SelectedValue = 1;
            cboEstadoCredito.SelectedValue = 0;
            cboPersonalCreditos.SelectedValue = 0;
            cboTipoCredito.SelectedValue = 0;
            cboSubTipoCredito.SelectedValue = 0;
            cboProducto.SelectedValue = 0;
            cboSubProducto.SelectedValue = 0;
            cboDestinoCredito.SelectedValue = 0;
            txtTasaCom.Text = "";
            txtTasaMora.Text = "";
            txtClasifInterna.Text = "";
            txtTpp.Text = "";

            cboEstadoCredito.CargaEstadoActual(999);
            conBusCuentaCli1.txtEstado.Text = "";
            conBusCuentaCli1.txtNombreCli.Text = "";
            conBusCuentaCli1.txtNroBusqueda.Text = "";
            conBusCuentaCli1.txtCodCli.Text = "";
            conBusCuentaCli1.txtNroDoc.Text = "";

            btnGrabar1.Enabled = false;
            btnCargaArhivos.Enabled = false;

            conBusCuentaCli1.btnBusCliente1.Enabled = true;
            conBusCuentaCli1.txtNroBusqueda.Enabled = true;


            conBusCuentaCli1.txtNroBusqueda.Focus();

            txtJustificacionSolicitud.Clear();
            cboTipoTasaCredito.DataSource = null;
            txtTasCompensatoriaMin.Clear();
            txtTasCompensatoriaMax.Clear();
            txtTasaMoraSec.Clear();
            txtTasaCompensatoria.Clear();
            lblTipoTasaCredito.Text = "";
            lblClasifInterna.Text = string.Empty;

            limpiarTasasNegociadas();
            limpiarHistoricoTEACliente();
            limpiarPerformanceADN();
            pnlMotivo.Enabled = true;
            gboxEntExterna.Enabled = true;
            cboMotivotipo.SelectedValue = 0;
            txtOtros.Clear();

            cboEntidadFina.SelectedValue = 0;
            txtTasaEntExt.Clear();
            txtImporteEntExt.Clear();
            txtComentariosEntFinanciera.Clear();
            cboTipoTasaCredito.DataSource = null;

        }
        private void limpiarTasasNegociadas()
        {
            int c = dtgSolicitudes.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                dtgSolicitudes.Rows.RemoveAt(0);
            }
        }
        private void limpiarHistoricoTEACliente()
        {
            int c = dtgHistoricoTEA.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                dtgHistoricoTEA.Rows.RemoveAt(0);
            }
        }
        private void limpiarPerformanceADN()
        {
            int c = dtgPerformanceADN.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                dtgPerformanceADN.Rows.RemoveAt(0);
            }
        }
        private void formatearSolicitudTasaNegociable()
        {
            foreach(DataGridViewColumn dgColumna in dtgSolicitudes.Columns)
            {
                dgColumna.Visible = false;
            }

            dtgSolicitudes.Columns["idSolicitud"].Visible           = true;
            dtgSolicitudes.Columns["dFechaReg"].Visible             = true;
            dtgSolicitudes.Columns["cUsuAprueba"].Visible           = true;
            dtgSolicitudes.Columns["nTasaSolicitada"].Visible       = true;
            dtgSolicitudes.Columns["nTasaPreAprobada"].Visible      = true;
            dtgSolicitudes.Columns["nTasaAprobada"].Visible         = true;
            dtgSolicitudes.Columns["nTasaMoratoriaSol"].Visible     = true;
            dtgSolicitudes.Columns["cDescEstado"].Visible           = true;
            dtgSolicitudes.Columns["cProducto"].Visible             = true;
            dtgSolicitudes.Columns["cMoneda"].Visible               = true;
            dtgSolicitudes.Columns["nCapitalSolicitado"].Visible    = true;
            dtgSolicitudes.Columns["nCuotas"].Visible               = true;
            dtgSolicitudes.Columns["cDescripTipoPeriodo"].Visible   = true;
            dtgSolicitudes.Columns["nPlazoCuota"].Visible           = true;
            dtgSolicitudes.Columns["nDiasGracia"].Visible           = true;
            dtgSolicitudes.Columns["FechaDesembolso"].Visible       = true;

            dtgSolicitudes.Refresh();
        }
        private void formatearHistoricoTEACliente()
        {
            dtgHistoricoTEA.Columns["nNumOrdCre"].HeaderText = "Nro.";
            dtgHistoricoTEA.Columns["cEstado"].HeaderText = "Estado de Crédito";
            dtgHistoricoTEA.Columns["dFechaDesembolso"].HeaderText = "Fecha Desembolso";
            dtgHistoricoTEA.Columns["nCapitalDesembolso"].HeaderText = "Monto";
            dtgHistoricoTEA.Columns["nTasaEfectivaAnual"].HeaderText = "TEA";
            dtgHistoricoTEA.Columns["nAtrasoMaximo"].HeaderText = "Mora Máxima";
            dtgHistoricoTEA.Columns["nAtrasoProm"].HeaderText = "Mora Promedio";
            dtgHistoricoTEA.Columns["cSituacionPago"].HeaderText = "Situación de Pago";
            dtgHistoricoTEA.Columns["idCuenta"].HeaderText = "Número de cuenta";
            dtgHistoricoTEA.Columns["idCli"].Visible = false;
            dtgHistoricoTEA.Columns["nTppPonderado"].Visible = false;

            dtgHistoricoTEA.Columns["nCapitalDesembolso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgHistoricoTEA.Columns["nTasaEfectivaAnual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgHistoricoTEA.Columns["nAtrasoMaximo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgHistoricoTEA.Columns["nAtrasoProm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgHistoricoTEA.Refresh();
        }
        private void formatearTPromedioPonderado()
        {
            dtgPerformanceADN.Columns["us"].HeaderText = "";
            dtgPerformanceADN.Columns["c_inicial"].HeaderText = "Inicial";
            dtgPerformanceADN.Columns["c_actual"].HeaderText = "Actual";
            dtgPerformanceADN.Columns["c_variacion"].HeaderText = "Variación";
            dtgPerformanceADN.Columns["d_inicial"].HeaderText = "Inicial";
            dtgPerformanceADN.Columns["d_actual"].HeaderText = "Actual";
            dtgPerformanceADN.Columns["d_variacion"].HeaderText = "Variación";

            dtgPerformanceADN.Columns["c_inicial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPerformanceADN.Columns["c_actual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPerformanceADN.Columns["c_variacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPerformanceADN.Columns["d_inicial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPerformanceADN.Columns["d_actual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPerformanceADN.Columns["d_variacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgPerformanceADN.Refresh();
        }
        public void BuscarSolicitud(int CodigoSol)
        {
            cGlobal_idsolicitud = CodigoSol;
            Sol = cnsolicitud.ExtraeDatosSolicitudTNegociable(CodigoSol, clsVarGlobal.User.idUsuario);

            if (Sol.Rows.Count > 0)
            {
                //--Validar si Cli esta en la Base Negativa
                clsCNBuscarCli ValidaCliBN = new clsCNBuscarCli();
                if (!string.IsNullOrEmpty(Convert.ToString(Sol.Rows[0]["cDocumentoID"])))
                {
                    if (ValidaCliBN.ValidaCliBaseNegativa(Convert.ToString(Sol.Rows[0]["cDocumentoID"]), clsVarGlobal.idModulo, true))
                    {                   
                        return;
                    }
                }

                bool lNegociableRefinanciado = false;
                lNegociableRefinanciado = Convert.ToBoolean(Convert.ToInt32(clsVarApl.dicVarGen["lTasaNegociableRefinanciado"]));

                int idOperacion = (Sol.Rows[0]["idOperacion"] == DBNull.Value) ?
                    0 : Convert.ToInt32(Sol.Rows[0]["idOperacion"]);

                if (idOperacion.In(2,6) && !lNegociableRefinanciado)
                {
                    MessageBox.Show("¡No se permite negociar la tasa para operaciones de REFINANCIAMIENTO en ninguna de sus modalidades!", "OPERACION NO ADMITIDA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    limpiar();
                    btnGrabar1.Enabled = false;
                    btnAnular1.Enabled = false;
                    txtJustificacionSolicitud.Clear();
                    return;
                }

                dtpFechaSol.Value = (Sol.Rows[0]["dFechaRegistro"] == DBNull.Value) ? clsVarGlobal.dFecSystem : (DateTime)Sol.Rows[0]["dFechaRegistro"];
                txtMonto.Text = (Sol.Rows[0]["nCapitalSolicitado"] == DBNull.Value) ? "" : Sol.Rows[0]["nCapitalSolicitado"].ToString();
                nMontoSolicitado = (Sol.Rows[0]["nCapitalSolicitado"] == DBNull.Value) ? 0.00m : (Decimal)Sol.Rows[0]["nCapitalSolicitado"];
                cboMoneda.SelectedValue = (Sol.Rows[0]["IdMoneda"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["IdMoneda"]);
                nudCuotas.Value = (Sol.Rows[0]["nCuotas"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nCuotas"]);
                nudPlazo.Value = (Sol.Rows[0]["nPlazoCuota"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nPlazoCuota"]);
                nudDiasGracia.Value = (Sol.Rows[0]["ndiasgracia"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["ndiasgracia"]);
                dtFechaDesembolso.Value = (Sol.Rows[0]["dFechaDesembolsoSugerido"] == DBNull.Value) ? clsVarGlobal.dFecSystem : Convert.ToDateTime(Sol.Rows[0]["dFechaDesembolsoSugerido"]);
                dFechaDesembolso = (Sol.Rows[0]["dFechaDesembolsoSugerido"] == DBNull.Value) ? clsVarGlobal.dFecSystem : Convert.ToDateTime(Sol.Rows[0]["dFechaDesembolsoSugerido"]);
                cboEstadoCredito.SelectedValue = (Sol.Rows[0]["idEstado"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idEstado"]);
                cGlobal_nEstadoCredito = (Sol.Rows[0]["idEstado"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idEstado"]);
                cboPersonalCreditos.ListarPersonal(Convert.ToInt32(Sol.Rows[0]["idAgencia"]));
                cboPersonalCreditos.SelectedValue = (Sol.Rows[0]["idUsuario"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idUsuario"]);
                cboTipoCredito.SelectedValue = (Sol.Rows[0]["nTipCre"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nTipCre"]);
                cboSubTipoCredito.SelectedValue = (Sol.Rows[0]["nSubTip"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nSubTip"]);
                cboProducto.SelectedValue = (Sol.Rows[0]["nProdu"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nProdu"]);
                cboSubProducto.SelectedValue = (Sol.Rows[0]["nSubPro"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["nSubPro"]);
                cboDestinoCredito.SelectedValue = (Sol.Rows[0]["idDestino"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idDestino"]);
                idClasificacionInterna = (Sol.Rows[0]["idClasificacionInterna"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idClasificacionInterna"]);

                txtTasaCom.Text = (Sol.Rows[0]["nTasaCompensatoria"] == DBNull.Value) ? "" : Convert.ToString(Sol.Rows[0]["nTasaCompensatoria"]);
                txtTasaMora.Text = (Sol.Rows[0]["nTasaMoratoria"] == DBNull.Value) ? "" : Convert.ToString(Sol.Rows[0]["nTasaMoratoria"]);
                lblClasifInterna.Text = (Sol.Rows[0]["cClasificacionInterna"] == DBNull.Value) ? "" : Convert.ToString(Sol.Rows[0]["cClasificacionInterna"]);
                txtClasifInterna.Text = (Sol.Rows[0]["cClasificacionInterna"] == DBNull.Value) ? "" : Convert.ToString(Sol.Rows[0]["cClasificacionInterna"]);

                nCodEst = (Sol.Rows[0]["idEstado"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idEstado"]);

                cboEstadoCredito.CargaEstadoActual(nCodEst);

                cboTipoPeriodo.SelectedValue = (Sol.Rows[0]["idTipoPeriodo"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idTipoPeriodo"]);
                cboOperacionCre1.SelectedValue = (Sol.Rows[0]["idOperacion"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idOperacion"]);
                idCliente = (Sol.Rows[0]["idCli"] == DBNull.Value) ? 0 : Convert.ToInt32(Sol.Rows[0]["idCli"]);
                cGlobal_NombreCli = (Sol.Rows[0]["cNombre"] == DBNull.Value) ? "" : Convert.ToString(Sol.Rows[0]["cNombre"]);

                var nEvaluacion = Convert.ToInt32(Sol.Rows[0]["nEvaluacion"]);

                if (Convert.ToInt32(Sol.Rows[0]["idTipoPeriodo"]) == 1)
                {
                    this.lblBase19.Text = "Día de Pago:";
                    this.lblBase3.Text = "";
                }
                else
                {
                    this.lblBase19.Text = "Frecuencia:";
                    this.lblBase3.Text = "en días";
                }
                Transaccion = Convert.ToChar("U");
                conBusCuentaCli1.btnBusCliente1.Enabled = false;
                conBusCuentaCli1.txtNroBusqueda.Enabled = false;

                txtJustificacionSolicitud.Enabled = true;
                var drGarantia = cnsolicitud.ValidaGarantiasSolicitud(CodigoSol).Rows[0];
                int nTotalDias = obtenerTotalDias(Convert.ToDateTime(dFechaDesembolso), Convert.ToInt32(nudCuotas.Value), Convert.ToInt32(nudDiasGracia.Value.ToString()), Convert.ToInt32(cboTipoPeriodo.SelectedValue), Convert.ToInt32(nudPlazo.Value));
                int idProducto = Convert.ToInt32(Sol.Rows[0]["nSubPro"]);
                decimal nMonto = Convert.ToDecimal(string.IsNullOrEmpty(txtMonto.Text) ? "0.00" : txtMonto.Text);
                int idMoneda = Convert.ToInt32(Sol.Rows[0]["IdMoneda"]);

                lTasaNegociada = true;
                asignarTasaNegociable(nTotalDias, idProducto, nMonto, idMoneda);                
                if (lTasaNegociada == false)
                {
                    if (lTasafrm == true)
                    {
                        return;
                    }
                    pnlMotivo.Enabled = false;
                    gboxEntExterna.Enabled = false;
                    return;
                }
                else 
                {
                    pnlMotivo.Enabled = true;
                    gboxEntExterna.Enabled = true;
                }
                seguimientoTasaNegociable(CodigoSol, clsVarGlobal.User.idUsuario);

                //Historico TEA Cliente
                int nTipodocumento = Convert.ToInt32(Sol.Rows[0]["idTipoDocumento"]);
                string cDocumento = Convert.ToString(Sol.Rows[0]["cDocumentoID"]);
                cGlobal_cDocumento = Convert.ToString(Sol.Rows[0]["cDocumentoID"]);

                historicoTEACliente(nTipodocumento, cDocumento);

                //TPP
                
                int idUsuario = Convert.ToInt32(clsVarGlobal.User.idUsuario);
                DataTable dtZonaUsuario = cnsolicitud.CNObtenerZonaUsuario(idUsuario);
                if (dtZonaUsuario.Rows.Count > 0)
                {
                    idZonaUsuario = Convert.ToInt32(dtZonaUsuario.Rows[0]["idZona"]);
                }      
          
               obtenerTasapromedioPonderada(clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia, idZonaUsuario, idUsuario);

               DataTable dtSolTasa = cnsolicitud.CNMostrarEstadoTasaNegociable(CodigoSol, 1);
               if (dtSolTasa.Rows.Count > 0)
               {                   
                    cGlobal_idEstadoTasa = Convert.ToInt32(dtSolTasa.Rows[0]["idEstado"]);
                    int nUsuarioRegistra = Convert.ToInt32(dtSolTasa.Rows[0]["idUsuReg"]);

                    int nUsuarioconsulta = 0;
                    if (clsVarGlobal.User.idUsuario != nUsuarioRegistra)
                    {
                        nUsuarioconsulta = nUsuarioRegistra;
                    }
                    else 
                    {
                        nUsuarioconsulta = clsVarGlobal.User.idUsuario;
                    }

                   DataTable dtSolTasaN = cnsolicitud.CNObtenerSolicitudTasaNegociable(nUsuarioconsulta, CodigoSol, 1);
                   if (dtSolTasaN.Rows.Count > 0)
                   {
                       cGlobal_idTasaNegociada = Convert.ToInt32(dtSolTasaN.Rows[0]["idTasaNegociada"]);

                       cboTipoTasaCredito.SelectedValue = Convert.ToInt32(dtSolTasaN.Rows[0]["idTasa"]);

                       txtTasaCompensatoria.Text = Convert.ToString(dtSolTasaN.Rows[0]["nTasaSolicitada"]);
                       txtJustificacionSolicitud.Text = Convert.ToString(dtSolTasaN.Rows[0]["cJustificacion"]);

                       listarEntidadFinanciera(Convert.ToInt32(dtSolTasaN.Rows[0]["idEntidadFinanciera"]));
                       txtTasaEntExt.Text = Convert.ToString(dtSolTasaN.Rows[0]["nTasaEntidad"]);
                       txtImporteEntExt.Text = Convert.ToDecimal(dtSolTasaN.Rows[0]["nMontoEntidad"]).ToString("N2");
                       txtComentariosEntFinanciera.Text = Convert.ToString(dtSolTasaN.Rows[0]["cComentarioEntidad"]);
                     
                       listarMotivosTasa(Convert.ToInt32(dtSolTasaN.Rows[0]["IdMotivoTasa"]));
                       txtOtros.Text = Convert.ToString(dtSolTasaN.Rows[0]["cComenMotivoTasa"]);
                       txtMonto.Text = Convert.ToString(dtSolTasaN.Rows[0]["nCapitalSolicitado"]);
                        btnAnular1.Enabled = true;
                        if (lTasafrm == true)
                        {
                            btnCancelar1.Enabled = false;
                        }
                    }
                   if (Convert.ToInt32(dtSolTasa.Rows[0]["idEstado"]) == 1 || Convert.ToInt32(dtSolTasa.Rows[0]["idEstado"]) == 8)
                   { 
                        btnEditar1.Enabled = true;

                   }
                   if (Convert.ToInt32(dtSolTasa.Rows[0]["idEstado"]) == 7)
                   {
                        MessageBox.Show("El cliente tiene una solicitud de tasa pendiente de aprobación.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnGrabar1.Enabled = false;
                        btnCargaArhivos.Enabled = false;
                        btnEditar1.Enabled = false;
                        btnEnviar1.Enabled = false;
                    }
                   if (Convert.ToInt32(dtSolTasa.Rows[0]["idEstado"]) == 2)
                   {
                        MessageBox.Show("Esta solicitud de crédito ya cuenta con una solicitud de Tasa aprobada.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnGrabar1.Enabled = false;
                        btnCargaArhivos.Enabled = false;
                        btnAnular1.Enabled = true;
                        btnEditar1.Enabled = false;
                        btnEnviar1.Enabled = false;
                    }
                   if (Convert.ToInt32(dtSolTasa.Rows[0]["idEstado"]) == 4)
                    {
                        MessageBox.Show("La solicitud de crédito anteriormente tuvo una solicitud de tasa DENEGADA.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (Convert.ToInt32(dtSolTasa.Rows[0]["idEstado"]) == 8)
                    {
                        cboTipoTasaCredito.Enabled = false;
                    }
                    pnlMotivo.Enabled = false;
                    gboxEntExterna.Enabled = false;

                    if (cGlobal_idEstadoTasa == 1 || cGlobal_idEstadoTasa == 8)
                    {
                        if (clsVarGlobal.User.idUsuario != nUsuarioRegistra)
                        {
                            MessageBox.Show("La solicitud de crédito esta siendo atendido por otro usuario.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pnlMotivo.Enabled = false;
                            gboxEntExterna.Enabled = false;
                            btnGrabar1.Enabled = false;
                            btnCargaArhivos.Enabled = false;
                            btnEditar1.Enabled = false;
                            btnEnviar1.Enabled = false;
                            btnAnular1.Enabled = false;
                        }
                    }
                }
               else 
               {
                   btnGrabar1.Enabled = true;
                   btnCargaArhivos.Enabled = true;
                   pnlMotivo.Enabled = true;
                   gboxEntExterna.Enabled = true;
                   listarEntidadFinanciera(-1);
                   listarMotivosTasa(-1);                   
               }
            }
            else
            {
                limpiar();
                Transaccion = Convert.ToChar("I");
                cboTipoPeriodo.Enabled = false;
                nudPlazo.Enabled = false;
                btnGrabar1.Enabled = false;
                btnCargaArhivos.Enabled = false;
            }
        }
        private void seguimientoTasaNegociable(int idSolicitud, int idusuario)
        {
            DataTable TasasNegociadas = cnsolicitud.SeguimientoTasaNegociable(idSolicitud, idusuario);
            limpiarTasasNegociadas();
            if (TasasNegociadas.Rows.Count > 0)
            {
                dtgSolicitudes.DataSource = TasasNegociadas;
                formatearSolicitudTasaNegociable();
            }

            if (tbcBase1.SelectedIndex == 1)
            {
                if (dtgSolicitudes.Rows.Count > 0)
                {
                    btnAnular1.Enabled = true;
                }
            }
        }
        private void historicoTEACliente(int nTipodocumento, string cDocumento)
        {
            DataTable dtHistTEA = cnsolicitud.CNMostrarHistoricoTEACliente(nTipodocumento, cDocumento);

            if (dtHistTEA.Rows.Count > 0)
            {
                dtgHistoricoTEA.DataSource = dtHistTEA;
                formatearHistoricoTEACliente();
                txtTpp.Text = Convert.ToString(dtHistTEA.Rows[0]["nTppPonderado"]) + " %";
            }
        }
        private void obtenerTasapromedioPonderada(DateTime dFecha, int id_Agencia, int id_Zona, int id_Usuario) 
        {
            DataTable dtTPP = cnsolicitud.CNMostrarTasaPromedioPonderada(dFecha, id_Agencia, id_Zona, id_Usuario);

            if (dtTPP.Rows.Count > 0)
            {
                dtgPerformanceADN.DataSource = dtTPP;
                formatearTPromedioPonderado();
            }
        }
        private int obtenerTotalDias(DateTime dFecDesemb, int nNumCuoCta, int nDiaGraCta, int nTipPerPag, int nDiaFecPag)
        {
            return cnsolicitud.ObtieneTotalDias(dFecDesemb, nNumCuoCta, nDiaGraCta, nTipPerPag, nDiaFecPag);
        }
        private void asignarTasaNegociable(int nTotalDias, int idProducto, decimal nMonto, int idMoneda)
        {

            cboTipoTasaCredito.DataSource = null;

            clsCNSolicitud TasaCredito = new clsCNSolicitud();
            DataTable dtTasa;
            dtTasa = TasaCredito.CNListaTasaCreditoNegociable(nTotalDias, idProducto, nMonto, idMoneda, idAgencia, Convert.ToInt32(cboOperacionCre1.SelectedValue), idClasificacionInterna);

            if (dtTasa.Rows.Count > 0)
            {

                cboTipoTasaCredito.DataSource = dtTasa;
                cboTipoTasaCredito.DisplayMember = "cDescripcion";
                cboTipoTasaCredito.ValueMember = "idTasa";
                var idTipoTasaCredito = Convert.ToInt32(dtTasa.Rows[0]["idTipoTasaCredito"]);

                if (dtTasa.Rows[0]["nTasaCompensatoria"].ToString() != "" && Transaccion == 'U')
                {
                    txtTasCompensatoriaMin.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoria"]);
                    txtTasCompensatoriaMax.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoriaMax"]);
                    cGlobal_TasaMax = Convert.ToDecimal(dtTasa.Rows[0]["nTasaCompensatoriaMax"]);

                    txtTasaMoraSec.Text = Convert.ToString(dtTasa.Rows[0]["nTasaMoratoria"]);
                    idTasa = Convert.ToInt32(dtTasa.Rows[0]["idTasa"]);

                    lblTipoTasaCredito.Text = Convert.ToString(dtTasa.Rows[0]["cDescripcion"]);
                    txtTasaCompensatoria.Enabled = true;
                    txtTasaCompensatoria.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoriaMax"]);
                }
                else
                {
                    txtTasaCompensatoria.Text = Convert.ToString(dtTasa.Rows[0]["nTasaCompensatoria"]);
                    txtTasaMoraSec.Text = Convert.ToString(dtTasa.Rows[0]["nTasaMoratoria"]);
                }

                txtTasaCompensatoria.Enabled = true;
            }
            else
            {
                txtTasCompensatoriaMin.Text = "";
                txtTasCompensatoriaMax.Text = "";
                txtTasaCompensatoria.Text = "";
                txtTasaMoraSec.Text = "";
                txtTasaCompensatoria.Enabled = false;
                btnGrabar1.Enabled = false;
                lTasaNegociada = false;
                MessageBox.Show("El producto no cuenta con Tasas Negociables.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private bool validar()
        {
            bool flag = true;
            if (cboMotivotipo.Text == "") 
            {
                MessageBox.Show("Debe seleccionar MOTIVO/TIPO.", "Solicitud de Cartera Negociable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;          
            }
            if (cboMotivotipo.Text == "OTROS")
            {
                if (txtOtros.Text.Trim() == "") 
                { 
                    MessageBox.Show("Debe detallar el motivo OTROS.", "Solicitud de Cartera Negociable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;               
                }
            }
            if (txtJustificacionSolicitud.Text == "")
            {
                MessageBox.Show("Debe hacer el ingreso de su justificación.", "Solicitud de Cartera Negociable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (Convert.ToDecimal(txtTasCompensatoriaMin.Text) > Convert.ToDecimal(txtTasaCompensatoria.Text))
            {
                MessageBox.Show("Debe ingresar una nueva tasa de interés válida.", "Solicitud de Cartera Negociable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (Convert.ToDecimal(txtTasaCompensatoria.Text) > Convert.ToDecimal(txtTasCompensatoriaMax.Text))
            {
                MessageBox.Show("Debe ingresar una nueva tasa de interés válida.", "Solicitud de Cartera Negociable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
           
            return flag;

        }
        private void grabar() 
        {
            int idEntidadfinanciera;
            if (cboEntidadFina.Text == "")
            {
                idEntidadfinanciera = 0;
            }
            else
            {
                idEntidadfinanciera = Convert.ToInt32(cboEntidadFina.SelectedValue.ToString());
            }

            DataTable dtResultado;
            dtResultado = cnsolicitud.CNRegistraSolicitudTasaNegociable(
                                                Convert.ToInt32(Sol.Rows[0]["idSolicitud"].ToString()),
                                                Convert.ToInt32(cboTipoTasaCredito.SelectedValue),
                                                Convert.ToDecimal(txtTasaCompensatoria.Text),
                                                Convert.ToDecimal(txtTasaMoraSec.Text),
                                                txtJustificacionSolicitud.Text,
                                                clsVarGlobal.User.idUsuario,
                                                Convert.ToInt32(Sol.Rows[0]["idTasa"].ToString()),
                                                Convert.ToDecimal(Sol.Rows[0]["nTasaCompensatoria"].ToString()),
                                                clsVarGlobal.nIdAgencia,
                                                clsVarGlobal.dFecSystem.Date,
                                                Convert.ToInt32(Sol.Rows[0]["nTipCre"].ToString()),
                                                Convert.ToInt32(Sol.Rows[0]["nSubTip"].ToString()),
                                                Convert.ToInt32(Sol.Rows[0]["nProdu"].ToString()),
                                                Convert.ToInt32(Sol.Rows[0]["nSubPro"].ToString()),
                                                Convert.ToInt32(Sol.Rows[0]["IdMoneda"].ToString()),
                                                Convert.ToDecimal(Sol.Rows[0]["nCapitalSolicitado"].ToString()),
                                                Convert.ToInt32(Sol.Rows[0]["nCuotas"].ToString()),
                                                Convert.ToInt32(Sol.Rows[0]["idTipoPeriodo"].ToString()),
                                                Convert.ToInt32(Sol.Rows[0]["nPlazoCuota"].ToString()),
                                                Convert.ToInt32(Sol.Rows[0]["ndiasgracia"].ToString()),
                                                Convert.ToDateTime(Sol.Rows[0]["dFechaDesembolsoSugerido"].ToString()),
                                                Convert.ToString(cboEntidadFina.Text),
                                                Convert.ToDecimal(txtTasaEntExt.Text),
                                                Convert.ToString(txtComentariosEntFinanciera.Text),
                                                Convert.ToDecimal(txtImporteEntExt.Text),
                                                Convert.ToInt32(cboMotivotipo.SelectedValue.ToString()),
                                                Convert.ToString(txtOtros.Text),
                                                Convert.ToInt32(idEntidadfinanciera),
                                                cGlobal_idTasaNegociada,
                                                1,
                                                Convert.ToInt32(cboOperacionCre1.SelectedValue),
                                                clsVarGlobal.User.idEstablecimiento,
                                                clsVarGlobal.PerfilUsu.idPerfil);


            if (dtResultado.Rows.Count > 0)
            {
                MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                seguimientoTasaNegociable(Convert.ToInt32(Sol.Rows[0]["idSolicitud"].ToString()), clsVarGlobal.User.idUsuario);
                if (dtResultado.Rows[0]["idError"].ToString() == "0") 
                {
                    cGlobal_idTasaNegociada = Convert.ToInt32(dtResultado.Rows[0]["idTasaN"].ToString());
                }
                string cJustificaInsert = txtJustificacionSolicitud.Text.Trim();
                string cComentariosEnti = txtComentariosEntFinanciera.Text.Trim();
                txtJustificacionSolicitud.Text = string.Empty;
                txtComentariosEntFinanciera.Text = string.Empty;
                txtJustificacionSolicitud.Text = cJustificaInsert;
                txtComentariosEntFinanciera.Text = cComentariosEnti;

                lGrabado = true;                
                pnlMotivo.Enabled = false;
                gboxEntExterna.Enabled = false;
                btnEnviar1.Enabled = true;
                btnEditar1.Enabled = true;                
                guardarDocumento();
                btnEnviar1.Focus();

            }
            else
            {
                MessageBox.Show("No se pudo realizar el registro de la solicitud.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnGrabar1.Enabled = true;
                pnlMotivo.Enabled = true;
                gboxEntExterna.Enabled = true;
            }
        }
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            string cEstado = "";
            clsCNSolicitud cnsolicitud = new clsCNSolicitud();
            DataTable dtESolTasa = cnsolicitud.CNObtenerEstadoSolicitudTasaNegociable();
            if (dtESolTasa.Rows.Count > 0)
            {
                cEstado = Convert.ToString(dtESolTasa.Rows[0]["cValVar"]);
            }

            if (cEstado.Contains(Convert.ToString(cGlobal_nEstadoCredito).Trim())) 
            {
                int x_nCodigoSol = 0;
                if (lTasafrm == true)
                {
                    if (idSolicitud_frm == 0)
                    {
                        MessageBox.Show("No se ha ingresado la solicitud.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        x_nCodigoSol = idSolicitud_frm;
                    }
                }
                else
                {
                    if (conBusCuentaCli1.txtNroBusqueda.Text == "")
                    {
                        MessageBox.Show("No se ha ingresado la solicitud.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        x_nCodigoSol = Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text);
                    }
                }

                DataTable dtSolTasa = cnsolicitud.CNMostrarEstadoTasaNegociable(x_nCodigoSol, 1);
                if (dtSolTasa.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtSolTasa.Rows[0]["idEstado"]) == 2)
                    {
                        MessageBox.Show("El cliente tiene una solicitud Tasa Aprobada.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;      
                    }
                }

                int nCaracteres = 12;
                if (cboEntidadFina.Text != "" )
                {
                    if (cboEntidadFina.Text != "--NINGUNO--") 
                    { 
                        if (txtTasaEntExt.Text == "" || txtTasaEntExt.Text == "0") 
                        {
                            MessageBox.Show("La Tasa de la entidad externa proponente debe ser mayor a 0.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTasaEntExt.Focus();
                            return; 
                        }

                        if (txtImporteEntExt.Text == "" || txtImporteEntExt.Text == "0" || Convert.ToDecimal(txtImporteEntExt.Text) <= 0)
                        {
                            MessageBox.Show("El importe de la entidad externa proponente debe ser mayor a 0.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTasaEntExt.Focus();
                            return;
                        }

                        if (txtComentariosEntFinanciera.Text.Trim().Length < nCaracteres) 
                        {
                            MessageBox.Show("El comentario de la entidad externa proponente debe tener como mínimo " + nCaracteres.ToString() + " carácteres.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtComentariosEntFinanciera.Focus();
                            return;               
                        }                   
                    }                   

                }
                else 
                {
                    if (Convert.ToDecimal(txtTasaEntExt.Text) > 0) 
                    {
                        DialogResult result = MessageBox.Show("Ha ingresado tasa de la entidad externa." + Environment.NewLine + "Desea continuar la edición? " + Environment.NewLine + Environment.NewLine + " -[SI] Continuar con la edición. " + Environment.NewLine + " -[NO] Omitir y guardar.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            return;
                        }
                        else 
                        {
                            txtTasaEntExt.Text = "0";
                        }
                    }
                    if (Convert.ToDecimal(txtImporteEntExt.Text) > 0)
                    {
                        DialogResult result = MessageBox.Show("Ha ingresado importe de la entidad externa." + Environment.NewLine + "Desea continuar la edición? " + Environment.NewLine + Environment.NewLine + " -[SI] Continuar con la edición. " + Environment.NewLine + " -[NO] Omitir y guardar.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            return;
                        }
                        else
                        {
                            txtImporteEntExt.Text = "0";
                        }
                    }
                    if (txtComentariosEntFinanciera.Text.Trim() != "")
                    {
                        DialogResult result = MessageBox.Show("Ha ingresado comentario de la entidad externa." + Environment.NewLine + "Desea continuar la edición? " + Environment.NewLine + Environment.NewLine + " -[SI] Continuar con la edición. " + Environment.NewLine + " -[NO] Omitir y guardar.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            return;
                        }
                        else
                        {
                            txtComentariosEntFinanciera.Text = "";
                        } 
                    }               
                }

                if (txtJustificacionSolicitud.Text.Trim().Length < nCaracteres)
                {
                    MessageBox.Show("La justificación para la negociación de tasa debe tener como mínimo " + nCaracteres.ToString() + " carácteres.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtJustificacionSolicitud.Focus();
                    return;
                }

                //-Valida cambio de Monto
                clsCNSolicitud objCNSolicitud = new clsCNSolicitud();
                DataTable dtSolicitud = objCNSolicitud.ExtraeDatosSolicitudTNegociable(Convert.ToInt32(cGlobal_idsolicitud), clsVarGlobal.User.idUsuario);

                if (Convert.ToDecimal(txtMonto.Text) != Convert.ToDecimal(dtSolicitud.Rows[0]["nCapitalsolicitado"]))
                {
                    MessageBox.Show("El monto del crédito ha cambiado, se debe denegar o anular la solicitud de tasa para ingresar una nueva solicitud.", "Aprobacion de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                btnGrabar1.Enabled = false;
                btnCargaArhivos.Enabled = false;
                lEdicion = false;
                if (validar())
                {
                    guardarDocumento();
                    grabar();
                }
                else
                {
                    btnGrabar1.Enabled = true;
                    pnlMotivo.Enabled = true;
                    gboxEntExterna.Enabled = true;
                }
            }
            else 
            {
                var cEstadosTasa = "";
                clsCNSolicitud cnMsgsolicitud = new clsCNSolicitud();
                DataTable dtEstadosTasa = cnMsgsolicitud.CNObtenerEstadoTasaNegociable();
                foreach (DataRow fila in dtEstadosTasa.Rows)
                {
                    cEstadosTasa = cEstadosTasa + fila["cEstado"].ToString() + ",";
                }
                MessageBox.Show("La solicitud de crédito del cliente no se encuentra dentro de los estados permitidos[" + cEstadosTasa + "].", "Buscar Cuenta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void conBusCuentaCli1_MyClic(object sender, EventArgs e)
        {
            Int32 nIdSol = Convert.ToInt32(conBusCuentaCli1.nValBusqueda);
            if (nIdSol > 0) 
            { 
                buscarCuenta(nIdSol);            
            }
        }
        private void conBusCuentaCli1_MyKey(object sender, KeyPressEventArgs e)
        {
            Int32 CodSol = Convert.ToInt32(conBusCuentaCli1.nValBusqueda);
            if (CodSol > 0) 
            {
                BuscarSolicitud(CodSol);           
            }
        }
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            if (lTasafrm == true)
            {
                txtJustificacionSolicitud.Clear();
                cboMotivotipo.SelectedValue = 0;
                txtOtros.Clear();

                cboEntidadFina.SelectedValue = 0;
                txtTasaEntExt.Clear();
                txtImporteEntExt.Clear();
                txtComentariosEntFinanciera.Clear();
                cboTipoTasaCredito.Enabled = false;
            }
            else 
            {
                if (lEdicion == true)
                {
                    DataTable dtSolTasaN = cnsolicitud.CNObtenerSolicitudTasaNegociable(clsVarGlobal.User.idUsuario, cGlobal_idsolicitud, 1);
                    if (dtSolTasaN.Rows.Count > 0)
                    {
                        cGlobal_idTasaNegociada = Convert.ToInt32(dtSolTasaN.Rows[0]["idTasaNegociada"]);

                        txtTasaCompensatoria.Text = Convert.ToString(dtSolTasaN.Rows[0]["nTasaSolicitada"]);

                        txtJustificacionSolicitud.Text = Convert.ToString(dtSolTasaN.Rows[0]["cJustificacion"]);

                        listarEntidadFinanciera(Convert.ToInt32(dtSolTasaN.Rows[0]["idEntidadFinanciera"]));
                        txtTasaEntExt.Text = Convert.ToString(dtSolTasaN.Rows[0]["nTasaEntidad"]);
                        txtImporteEntExt.Text = Convert.ToString(dtSolTasaN.Rows[0]["nMontoEntidad"]);
                        txtComentariosEntFinanciera.Text = Convert.ToString(dtSolTasaN.Rows[0]["cComentarioEntidad"]);

                        listarMotivosTasa(Convert.ToInt32(dtSolTasaN.Rows[0]["IdMotivoTasa"]));
                        txtOtros.Text = Convert.ToString(dtSolTasaN.Rows[0]["cComenMotivoTasa"]);
                    }
                    btnGrabar1.Enabled = false;
                    btnCargaArhivos.Enabled = false;
                    pnlMotivo.Enabled = false;
                    gboxEntExterna.Enabled = false;
                    btnEnviar1.Enabled = true;
                    lGrabado = true;
                }
                else 
                { 
                    limpiar();
                    btnGrabar1.Enabled = false;
                    btnCargaArhivos.Enabled = false;
                    btnAnular1.Enabled = false;
                    txtJustificacionSolicitud.Clear();
                    btnEnviar1.Enabled = false;
                    btnEditar1.Enabled = false;
                    conBusCuentaCli1.nValBusqueda = 0;
                    cboTipoTasaCredito.Enabled = true;
                }
                lEdicion = false;
            }
        }
        private void cboTipoTasaCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoTasaCredito.SelectedIndex > -1)
            {
                var drTasa = (DataRowView)cboTipoTasaCredito.SelectedItem;
                txtTasCompensatoriaMin.Text = Convert.ToString(drTasa["nTasaCompensatoria"]);
                txtTasCompensatoriaMax.Text = Convert.ToString(drTasa["nTasaCompensatoriaMax"]);
                txtTasaMoraSec.Text = Convert.ToString(drTasa["nTasaMoratoria"]);
                txtTasaCompensatoria.Text = Convert.ToString(drTasa["nTasaCompensatoriaMax"]);
                if (txtTasCompensatoriaMin.Text == txtTasCompensatoriaMax.Text)
                {
                    txtTasaCompensatoria.Enabled = false;
                    txtTasaCompensatoria.Text = txtTasCompensatoriaMax.Text;
                }
                else
                {
                    txtTasaCompensatoria.Focus();
                    txtTasaCompensatoria.SelectAll();
                    txtTasaCompensatoria.Enabled = true;
                }
            }
        }
        private void btnSalir2_Click(object sender, EventArgs e)
        {
            string cEstado = "";
            clsCNSolicitud cnsolicitud = new clsCNSolicitud();
            DataTable dtESolTasa = cnsolicitud.CNObtenerEstadoSolicitudTasaNegociable();
            if (dtESolTasa.Rows.Count > 0)
            {
                cEstado = Convert.ToString(dtESolTasa.Rows[0]["cValVar"]);
            }

            if (cEstado.Contains(Convert.ToString(cGlobal_nEstadoCredito).Trim()))
            {
                if (lSalir == true) 
                {
                    if (lformclosing == false)
                    {
                        this.Close();
                    }
                    return;
                }

                if (cGlobal_idsolicitud == 0)
                {
                    if (lformclosing == false)
                    {
                        this.Close();
                    }
                    return;
                }

                if (lGrabado == false)
                {
                    DataTable dtSolTasa = cnsolicitud.CNMostrarEstadoTasaNegociable(cGlobal_idsolicitud, 1);
                    if (dtSolTasa.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtSolTasa.Rows[0]["idEstado"]) != 1)
                        {
                            if (lformclosing == false)
                            {
                                this.Close();
                            }
                            return;
                        }
                    }

                    string cD_txtTasaCompensatoria = "0", cD_txtImporteEntExt = "0", cD_txtTasaEntExt = "0", 
                                 cD_txtJustificacionSolicitud = "" ,cD_txtComentariosEntFinanciera = "" , cD_txtOtros = "";
                    int nD_idTipo = 0, nD_idEntidad = 0;
                    bool lCambiosRegistro = false;

                    DataTable dtSolTasaN = cnsolicitud.CNObtenerSolicitudTasaNegociable(clsVarGlobal.User.idUsuario, cGlobal_idsolicitud, 1);
                    if (dtSolTasaN.Rows.Count > 0)
                    {
                        cD_txtTasaCompensatoria = Convert.ToString(dtSolTasaN.Rows[0]["nTasaSolicitada"]);
                        cD_txtJustificacionSolicitud = Convert.ToString(dtSolTasaN.Rows[0]["cJustificacion"]);
                        cD_txtTasaEntExt = Convert.ToString(dtSolTasaN.Rows[0]["nTasaEntidad"]);
                        cD_txtImporteEntExt = Convert.ToString(dtSolTasaN.Rows[0]["nMontoEntidad"]);
                        cD_txtComentariosEntFinanciera = Convert.ToString(dtSolTasaN.Rows[0]["cComentarioEntidad"]);
                        cD_txtOtros = Convert.ToString(dtSolTasaN.Rows[0]["cComenMotivoTasa"]);
                        nD_idTipo = Convert.ToInt32(dtSolTasaN.Rows[0]["IdMotivoTasa"]);
                        nD_idEntidad = Convert.ToInt32(dtSolTasaN.Rows[0]["idEntidadFinanciera"]);
                    }

                    int nIdEntidad_x;
                    if (cboEntidadFina.SelectedValue == null)
                    {
                        nIdEntidad_x = 0;
                    }
                    else
                    {
                        nIdEntidad_x = Convert.ToInt32(cboEntidadFina.SelectedValue.ToString());
                    }

                    int nIdTipo_x;
                    if (cboMotivotipo.SelectedValue == null)
                    {
                        nIdTipo_x = 0;
                    }
                    else
                    {
                        nIdTipo_x = Convert.ToInt32(cboMotivotipo.SelectedValue.ToString());
                    }

                    decimal nTasaEnt;
                    if (c_txtTasaExt == "")
                    {
                        nTasaEnt = 0;
                    }
                    else
                    {
                        nTasaEnt = Convert.ToDecimal(c_txtTasaExt);
                    }

                    decimal nImporteEnt;
                    if (c_txtImporteExt == "")
                    {
                        nImporteEnt = 0;
                    }
                    else
                    {
                        nImporteEnt = Convert.ToDecimal(c_txtImporteExt);
                    }

                    if (c_txtTasaSolicitada == "") { c_txtTasaSolicitada = "0"; }
                    if (c_txtImporteExt == "") { c_txtImporteExt = "0"; }
                    if (c_txtTasaExt == "") { c_txtTasaExt = "0"; }

                    if (cGlobal_TasaMax != Convert.ToDecimal(c_txtTasaSolicitada)) 
                    {
                        if (Convert.ToDecimal(c_txtTasaSolicitada) != Convert.ToDecimal(cD_txtTasaCompensatoria)) { lCambiosRegistro = true; }                
                    }
                    if (Convert.ToDecimal(c_txtTasaExt) != Convert.ToDecimal(cD_txtTasaEntExt)) { lCambiosRegistro = true; }
                    if (Convert.ToDecimal(c_txtImporteExt) != Convert.ToDecimal(cD_txtImporteEntExt)) { lCambiosRegistro = true; }

                    if (c_txtJustificacion.Trim() != cD_txtJustificacionSolicitud.Trim()) { lCambiosRegistro = true; }
                    if (c_txtComentarios.Trim() != cD_txtComentariosEntFinanciera.Trim()) { lCambiosRegistro = true; }
                    if (c_txtOtros.Trim() != c_txtOtros.Trim()) { lCambiosRegistro = true; }

                    if (nIdEntidad_x != nD_idEntidad) { lCambiosRegistro = true; }
                    if (nIdTipo_x != nD_idTipo) { lCambiosRegistro = true; }

                    if (lCambiosRegistro == true) 
                    {
                        DialogResult drResultado = MessageBox.Show("¿Está seguro de que desea salir? Por favor, elige (SÍ) para salir y guardar o (NO) para omitir los cambios.", "Solicitud de Tasa Negociable", MessageBoxButtons.YesNo, MessageBoxIcon.Question);                               
                        if (drResultado == DialogResult.Yes)
                        {

                            DataTable dtResultado = cnsolicitud.CNRegistraSolicitudTasaNegociable(
                                                                    Convert.ToInt32(Sol.Rows[0]["idSolicitud"].ToString()),
                                                                    Convert.ToInt32(cboTipoTasaCredito.SelectedValue),
                                                                    Convert.ToDecimal(c_txtTasaSolicitada),
                                                                    Convert.ToDecimal(0),
                                                                    c_txtJustificacion,
                                                                    clsVarGlobal.User.idUsuario,
                                                                    Convert.ToInt32(Sol.Rows[0]["idTasa"].ToString()),
                                                                    Convert.ToDecimal(0),
                                                                    clsVarGlobal.nIdAgencia,
                                                                    clsVarGlobal.dFecSystem.Date,
                                                                    Convert.ToInt32(Sol.Rows[0]["nTipCre"].ToString()),
                                                                    Convert.ToInt32(Sol.Rows[0]["nSubTip"].ToString()),
                                                                    Convert.ToInt32(Sol.Rows[0]["nProdu"].ToString()),
                                                                    Convert.ToInt32(Sol.Rows[0]["nSubPro"].ToString()),
                                                                    Convert.ToInt32(Sol.Rows[0]["IdMoneda"].ToString()),
                                                                    Convert.ToDecimal(Sol.Rows[0]["nCapitalSolicitado"].ToString()),
                                                                    Convert.ToInt32(Sol.Rows[0]["nCuotas"].ToString()),
                                                                    Convert.ToInt32(Sol.Rows[0]["idTipoPeriodo"].ToString()),
                                                                    Convert.ToInt32(Sol.Rows[0]["nPlazoCuota"].ToString()),
                                                                    Convert.ToInt32(Sol.Rows[0]["ndiasgracia"].ToString()),
                                                                    Convert.ToDateTime(Sol.Rows[0]["dFechaDesembolsoSugerido"].ToString()),
                                                                    Convert.ToString(cboEntidadFina.Text),
                                                                    Convert.ToDecimal(nTasaEnt),
                                                                    Convert.ToString(c_txtComentarios),
                                                                    Convert.ToDecimal(nImporteEnt),
                                                                    Convert.ToInt32(nIdTipo_x),
                                                                    Convert.ToString(c_txtOtros),
                                                                    Convert.ToInt32(nIdEntidad_x),
                                                                    cGlobal_idTasaNegociada,
                                                                    1,
                                                                    Convert.ToInt32(cboOperacionCre1.SelectedValue),
                                                                    clsVarGlobal.User.idEstablecimiento,
                                                                    clsVarGlobal.PerfilUsu.idPerfil);

                            if (dtResultado.Rows.Count > 0)
                                {
                                    MessageBox.Show(dtResultado.Rows[0]["cMensaje"].ToString(), "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lSalir = true;
                                }
                                if (lformclosing == false)
                                {
                                    this.Close();
                                }
                        }
                        else
                        {
                            lSalir = true;
                            if (lformclosing == false)
                            {
                                this.Close();
                            }
                            return;
                        }                
                    }
                }
                else
                {
                    if (lformclosing == false) 
                    { 
                        this.Close();               
                    }
                    return;
                }
            }
        }
        private void cboTipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoCredito.SelectedIndex > 0)
            {
                nCodPro = Convert.ToInt32(cboTipoCredito.SelectedValue);
                cboSubTipoCredito.CargarProducto(nCodPro);
            }
            else
            {
                cboTipoCredito.SelectedIndex = 0;
            }
        }
        private void dtgSolicitudes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            mostrarDetalleSeguimientoTasaNegociable();
        }
        private void btnMiniDetalle_Click(object sender, EventArgs e)
        {
            mostrarDetalleSeguimientoTasaNegociable();
        }
        public void mostrarDetalleSeguimientoTasaNegociable()
        {
            if(dtgSolicitudes.SelectedRows.Count > 0)
            {
                int nIndex = (dtgSolicitudes.SelectedRows.Count > 0) ? dtgSolicitudes.SelectedRows[0].Index : -1;
                DataRow drSolicitud = ((DataRowView)dtgSolicitudes.SelectedRows[0].DataBoundItem).Row;
                int idSolicitudN = Convert.ToInt32(drSolicitud["nSolicitud"]);
                int idTasaNegociadaN = Convert.ToInt32(drSolicitud["idTasaNegociada"]);

                if (nIndex != -1)
                {
                    frmDetalleTasaNegociable frmDetalleNegociable = new frmDetalleTasaNegociable();
                    frmDetalleNegociable.cTipoMotivo = "P";
                    frmDetalleNegociable.cargarDetalleTasaNegociable(idSolicitudN, idTasaNegociadaN, clsVarGlobal.User.idUsuario);
                    frmDetalleNegociable.ShowDialog();
                }
            }
        }
        private void cboSubTipoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubTipoCredito.SelectedIndex > 0)
            {
                nCodPro = Convert.ToInt32(cboSubTipoCredito.SelectedValue);
                cboProducto.CargarProducto(nCodPro);
            }
            else
            {
                cboSubTipoCredito.SelectedIndex = 0;
            }
        }
        private void cboProducto_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex > 0)
            {
                nCodPro = Convert.ToInt32(cboProducto.SelectedValue);
                cboSubProducto.CargarProducto(nCodPro);
            }
            else
            {
                cboProducto.SelectedIndex = 0;
            }
        }
        private void btnAnular1_Click(object sender, EventArgs e)
        {            
            if (cGlobal_idEstadoTasa != 999)
            {
                if (cGlobal_idEstadoTasa != 5)
                {
                    if (cGlobal_idEstadoTasa == 2)
                    {
                        DialogResult cRpta = MessageBox.Show("¿La solicitud de tasa se encuentra con estado APROBADO, desea Anular solicitud?", "Solicitud de Tasa Negociable", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (cRpta == DialogResult.No)
                        {
                            return;
                        }
                        if (cRpta == DialogResult.Yes)
                        {
                            frmAnulaTasaNegociable frmAnulaTasaNegociable = new frmAnulaTasaNegociable();
                            frmAnulaTasaNegociable.idTasaNegociada = cGlobal_idTasaNegociada;
                            frmAnulaTasaNegociable.idEstado = cGlobal_idEstadoTasa;
                            if (frmAnulaTasaNegociable.ShowDialog() == DialogResult.OK)
                            {
                                seguimientoTasaNegociable(cGlobal_idsolicitud, clsVarGlobal.User.idUsuario);
                                tbcBase1.SelectedIndex = 0;
                                btnEditar1.Enabled = false;
                                btnEnviar1.Enabled = false;
                                btnCancelar1.Enabled = false;
                                btnAnular1.Enabled = false;
                                lSalir = true;
                                if (lTasafrm == false)
                                {
                                    btnCancelar1_Click(sender, e);
                                    btnCancelar1.Enabled = true;
                                }
                            }
                        }
                    }
                    else 
                    {
                        frmAnulaTasaNegociable frmAnulaTasaNegociable = new frmAnulaTasaNegociable();
                        frmAnulaTasaNegociable.idTasaNegociada = cGlobal_idTasaNegociada;
                        frmAnulaTasaNegociable.idEstado = cGlobal_idEstadoTasa;
                        if (frmAnulaTasaNegociable.ShowDialog() == DialogResult.OK)
                        {
                            seguimientoTasaNegociable(cGlobal_idsolicitud, clsVarGlobal.User.idUsuario);
                            tbcBase1.SelectedIndex = 0;
                            btnEditar1.Enabled = false;
                            btnEnviar1.Enabled = false;
                            btnCancelar1.Enabled = false;
                            btnAnular1.Enabled = false;
                            lSalir = true;
                            if (lTasafrm == false)
                            {
                                btnCancelar1_Click(sender, e);
                                btnCancelar1.Enabled = true;
                            }
                        }
                    }
                }
            }
        }
        private void listarEntidadFinanciera(int nItemvalue)
        {
            clsCNSolicitud cnsolicitudEF = new clsCNSolicitud();
            DataTable dtResultado = cnsolicitudEF.CNListaEntidadFinanciera();
            cboEntidadFina.DataSource = dtResultado;
            cboEntidadFina.ValueMember = dtResultado.Columns[0].ToString();
            cboEntidadFina.DisplayMember = dtResultado.Columns[1].ToString();
            cboEntidadFina.SelectedValue = nItemvalue;
        }
        private void txtTasaEntExt_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && (textBox.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if ((char.IsDigit(e.KeyChar)) && (textBox.Text.Length == 2))
            {
                textBox.Text += "." + e.KeyChar.ToString(); 
                textBox.SelectionStart = textBox.Text.Length;
                e.Handled = true;
            }
        }
        private void txtTasaEntExt_Click(object sender, EventArgs e)
        {
            if (txtTasaEntExt.Text == "0")
            {
                txtTasaEntExt.Text = "";
            }
        }
        private void txtTasaEntExt_Leave(object sender, EventArgs e)
        {
            if (esNumerico(txtTasaEntExt.Text.Trim()))
            {
                if (txtTasaEntExt.Text == "")
                {
                    txtTasaEntExt.Text = "0";
                }
                else
                {
                    decimal nTasaentidad = Convert.ToDecimal(txtTasaEntExt.Text);
                    txtTasaEntExt.Text = string.Empty;
                    txtTasaEntExt.Text = nTasaentidad.ToString("N4");
                }
            }
            else
            {
                MessageBox.Show("Valor ingresado incorrecto.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaEntExt.Text = "0";
            }
        }
        private void txtImporteEntExt_Click(object sender, EventArgs e)
        {
            if (txtImporteEntExt.Text == "0")
            {
                txtImporteEntExt.Text = "";
            }
        }
        private void txtImporteEntExt_Leave(object sender, EventArgs e)
        {
            if (esNumerico(txtImporteEntExt.Text.Trim()))
            {
                if (txtImporteEntExt.Text == "")
                {
                    txtImporteEntExt.Text = "0";
                }
                else
                {
                    decimal nImporteentidad = Convert.ToDecimal(txtImporteEntExt.Text);
                    txtImporteEntExt.Text = string.Empty;
                    txtImporteEntExt.Text = nImporteentidad.ToString("N2");
                }
            }
            else
            {
                MessageBox.Show("Valor ingresado incorrecto.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtImporteEntExt.Text = "0";
            }
        }
        private void cboEntidadFina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEntidadFina.Text == "--NINGUNO--") 
            {
                cboEntidadFina.SelectedIndex = -1;
                txtTasaEntExt.Text = "0";
                txtImporteEntExt.Text = "0";
                txtComentariosEntFinanciera.Text = "";
            }
        }
        private void txtTasaCompensatoria_Click(object sender, EventArgs e)
        {
            if (txtTasaCompensatoria.Text == txtTasCompensatoriaMax.Text)
            {
                txtTasaCompensatoria.Text = "";
            }
        }
        private void txtTasaCompensatoria_Leave(object sender, EventArgs e)
        {
            if (esNumerico(txtTasaCompensatoria.Text.Trim()))
            {
                if (txtTasaCompensatoria.Text == "")
                {
                    txtTasaCompensatoria.Text = txtTasCompensatoriaMax.Text;
                }
                else
                {
                    decimal nTasa = Convert.ToDecimal(txtTasaCompensatoria.Text);
                    txtTasaCompensatoria.Text = string.Empty;
                    txtTasaCompensatoria.Text = nTasa.ToString("N4");
                }
            }
            else 
            {
                MessageBox.Show("Valor ingresado incorrecto.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTasaCompensatoria.Text = txtTasCompensatoriaMax.Text;
            }
        }
        static bool esNumerico(string texto)
        {
            Regex regex = new Regex(@"^[0-9]+(\.[0-9]+)?$");
            return regex.IsMatch(texto);
        }
        private void txtTasaCompensatoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && (textBox.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if ((char.IsDigit(e.KeyChar)) && (textBox.Text.Length == 2))
            {
                textBox.Text += "." + e.KeyChar.ToString();
                textBox.SelectionStart = textBox.Text.Length;
                e.Handled = true;
            }
        }
        private void frmTasaNegociable_FormClosing(object sender, FormClosingEventArgs e)
        {
            string cEstado = "";
            clsCNSolicitud cnsolicitud = new clsCNSolicitud();
            DataTable dtESolTasa = cnsolicitud.CNObtenerEstadoSolicitudTasaNegociable();
            if (dtESolTasa.Rows.Count > 0)
            {
                cEstado = Convert.ToString(dtESolTasa.Rows[0]["cValVar"]);
            }

            if (cEstado.Contains(Convert.ToString(cGlobal_nEstadoCredito).Trim()))
            {
                if (lSalir == false)
                {
                    lformclosing = true;
                    btnSalir2_Click(sender, e);
                }
            }
        }
        private void listarMotivosTasa(int nItemvalue)
        {
            clsCNSolicitud cnsolicitudMT = new clsCNSolicitud();
            DataTable dtResultado = cnsolicitudMT.CNListaMotivosolicitudTasa("P");
            cboMotivotipo.DataSource = dtResultado;
            cboMotivotipo.ValueMember = dtResultado.Columns[0].ToString();
            cboMotivotipo.DisplayMember = dtResultado.Columns[1].ToString();
            cboMotivotipo.SelectedValue = nItemvalue;
        }
        private void btnCargaArhivos_Click(object sender, EventArgs e)
        {
            if (cboMotivotipo.Text == "")
            {
                MessageBox.Show("Debe seleccionar MOTIVO/TIPO de la Solicitud de Tasa.", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtJustificacionSolicitud.Text == "")
            {
                MessageBox.Show("Debe registrar Justificación para la Negociación de Tasa.", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            mostrarCargaArchivo();
        }
        private void mostrarCargaArchivo()
        {
            int x_idsolicitud = 0;
            if (lTasafrm == true)
            {
                if (idSolicitud_frm == 0)
                {
                    MessageBox.Show("No se ha ingresado la solicitud.", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                x_idsolicitud = idSolicitud_frm;
            }
            else
            {
                if (conBusCuentaCli1.txtNroBusqueda.Text == "")
                {
                    MessageBox.Show("No se ha ingresado la solicitud.", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                x_idsolicitud = Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text); 
            }

            frmCargaArchivo frmCargaArchivo = new frmCargaArchivo(x_idsolicitud, false);
            frmCargaArchivo.lTasa = true;
            frmCargaArchivo.ShowDialog();
        }
        private void cboBase2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMotivotipo.Text == "OTROS")
            {
                lblOtros.Visible = true;
                txtOtros.Visible = true;
            }
            else 
            {
                lblOtros.Visible = false;
                txtOtros.Visible = false;
            }
            txtOtros.Text = string.Empty;
        }
        private void btnEditar1_Click(object sender, EventArgs e)
        {
            int x_nCodigoSol = 0;
            if (lTasafrm == true)
            {
                if (idSolicitud_frm == 0)
                {
                    MessageBox.Show("No se ha ingresado la solicitud.", "Editar Solicitud Tasa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else 
                {
                    x_nCodigoSol = idSolicitud_frm;
                }
            }
            else
            {
                if (conBusCuentaCli1.txtNroBusqueda.Text == "")
                {
                    MessageBox.Show("No se ha ingresado la solicitud.", "Editar Solicitud Tasa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else 
                {
                    x_nCodigoSol = Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text);
                }
            }

            DataTable dtSolTasa = cnsolicitud.CNMostrarEstadoTasaNegociable(x_nCodigoSol, 1);
            if (dtSolTasa.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtSolTasa.Rows[0]["idEstado"]) == 1 || Convert.ToInt32(dtSolTasa.Rows[0]["idEstado"]) == 8)
                {
                    btnGrabar1.Enabled = true;
                    btnCargaArhivos.Enabled = true;
                    pnlMotivo.Enabled = true;
                    gboxEntExterna.Enabled = true;
                    btnEnviar1.Enabled = false;
                    btnEditar1.Enabled = false;
                    lGrabado = false;
                    lEdicion = true;

                    if (Convert.ToInt32(dtSolTasa.Rows[0]["idEstado"]) == 8) 
                    {
                        cboTipoTasaCredito.Enabled = false;
                    }
                    else 
                    {
                        cboTipoTasaCredito.Enabled = true;
                    }
                }
                else 
                {
                    MessageBox.Show("No se permite edición de solicitud Tasa en estado [ENVIADO].", "Editar Solicitud Tasa", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                    return;
                }
            }

        }
        private void txtJustificacionSolicitud_TextChanged(object sender, EventArgs e)
        {
            c_txtJustificacion = txtJustificacionSolicitud.Text;
        }
        private void txtOtros_TextChanged(object sender, EventArgs e)
        {
            c_txtOtros = txtOtros.Text;
        }
        private void txtCBLetra1_TextChanged(object sender, EventArgs e)
        {
            c_txtComentarios = txtComentariosEntFinanciera.Text;
        }
        private void txtTasaCompensatoria_TextChanged(object sender, EventArgs e)
        {
            c_txtTasaSolicitada = txtTasaCompensatoria.Text;
        }
        private void txtTasaEntExt_TextChanged(object sender, EventArgs e)
        {
            c_txtTasaExt = txtTasaEntExt.Text;
            if (!string.IsNullOrEmpty(txtTasaEntExt.Text))
            {
                if (!esNumerico(txtTasaEntExt.Text.Trim())) 
                {
                    return;
                }
                decimal nNumero = decimal.Parse(txtTasaEntExt.Text);
                decimal nMinimo = 1;
                decimal nMaximo = 100;
                if (nNumero < nMinimo || nNumero > nMaximo)
                {
                    txtTasaEntExt.Text = c_txtTasaExt;
                    return;
                }
            }
        }
        private void txtImporteEntExt_TextChanged(object sender, EventArgs e)
        {
            c_txtImporteExt = txtImporteEntExt.Text;
        }
        private void btnEnviar1_Click(object sender, EventArgs e)
        {                      
            int x_idsolicitud = 0;
            if (lTasafrm == true)
            {
                if (idSolicitud_frm == 0)
                {
                    MessageBox.Show("No se ha ingresado la solicitud.", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                x_idsolicitud = idSolicitud_frm;
            }
            else
            {
                if (conBusCuentaCli1.txtNroBusqueda.Text == "")
                {
                    MessageBox.Show("No se ha ingresado la solicitud.", "Carga de Archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                x_idsolicitud = Convert.ToInt32(conBusCuentaCli1.txtNroBusqueda.Text);
            }

            int nCaracteres = 12;
            if (cboEntidadFina.Text != "")
            {
                if (txtTasaEntExt.Text == "" || txtTasaEntExt.Text == "0")
                {
                    MessageBox.Show("La Tasa de la Entidad Externa proponente debe ser mayor a 0.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTasaEntExt.Focus();
                    return;
                }

                if (txtImporteEntExt.Text == "" || txtImporteEntExt.Text == "0")
                {
                    MessageBox.Show("El Importe de la Entidad Externa proponente debe ser mayor a 0.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTasaEntExt.Focus();
                    return;
                }

                if (txtComentariosEntFinanciera.Text.Trim().Length < nCaracteres)
                {
                    MessageBox.Show("El Comentario de la Entidad Externa proponente debe tener como mínimo " + nCaracteres.ToString() + " carácteres.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtComentariosEntFinanciera.Focus();
                    return;
                }
            }

            if (txtJustificacionSolicitud.Text.Trim().Length < nCaracteres)
            {
                MessageBox.Show("La justificación para la negociación de tasa debe tener como mínimo " + nCaracteres.ToString() + " carácteres.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtJustificacionSolicitud.Focus();
                return;
            }

            //-Valida cambio de Monto
            clsCNSolicitud cnsolicitud = new clsCNSolicitud();
            DataTable dtSolicitud = cnsolicitud.ExtraeDatosSolicitudTNegociable(Convert.ToInt32(cGlobal_idsolicitud), clsVarGlobal.User.idUsuario);

            if (Convert.ToDecimal(txtMonto.Text) != Convert.ToDecimal(dtSolicitud.Rows[0]["nCapitalsolicitado"]))
            {
                MessageBox.Show("El monto del crédito ha cambiado, se debe denegar o anular la solicitud de tasa para ingresar una nueva solicitud.", "Aprobacion de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (validar())
            { 
                DataTable dtSolTasa = cnsolicitud.CNMostrarEstadoTasaNegociable(x_idsolicitud, 1);
                if (dtSolTasa.Rows.Count > 0)
                {
                    string cNombreCli = Convert.ToString(dtSolTasa.Rows[0]["cNombre"]);
                    if (Convert.ToInt32(dtSolTasa.Rows[0]["idEstado"]) == 1 || Convert.ToInt32(dtSolTasa.Rows[0]["idEstado"]) == 8)
                    {
                        DataTable Resultado = cnsolicitud.CNEnviarSolicitudTasaNegociable(Convert.ToInt32(dtSolTasa.Rows[0]["idTasaNegociada"]), Convert.ToInt32(dtSolTasa.Rows[0]["idEstado"]), clsVarGlobal.dFecSystem.Date);
                        if (Resultado.Rows.Count > 0)
                        {
                            MessageBox.Show(Resultado.Rows[0]["cMensaje"].ToString(), "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (Resultado.Rows[0]["idError"].ToString() == "0")
                            {
                                lGrabado = true;
                                btnEnviar1.Enabled = false;
                                btnAnular1.Enabled = true;
                                btnEditar1.Enabled = false;
                            }
                        }

                        string cPerfilTasa = "JO";
                        if (cboTipoTasaCredito.Text == "NEG. GERENCIA NEGOCIOS") 
                        {
                            cPerfilTasa = "GN";
                        }
                        if (cboTipoTasaCredito.Text == "NEG. GERENCIA REGIONAL")
                        {
                            cPerfilTasa = "GR";
                        }

                        clsCNSolicitud objclsCNSolicitudEMAIL = new clsCNSolicitud();
                        dtParamEnvioEmail = objclsCNSolicitudEMAIL.CNVerificarParametrosEnvioMail();
                        if (Convert.ToBoolean(dtParamEnvioEmail.Rows[0]["lVigente"].ToString()) == true)
                        {
                            envioCorreoAprobador(cPerfilTasa, cNombreCli);
                        }

                        clsCNSolicitud objclsCNSolicitudSMS = new clsCNSolicitud();
                        dtParamEnvioSMS = objclsCNSolicitudSMS.CNVerificarParametrosEnvioSMS();
                        if (Convert.ToBoolean(dtParamEnvioSMS.Rows[0]["lVigente"].ToString()) == true && dtParamEnvioSMS.Rows[0]["cValVar"].ToString() == "SI")
                        {
                            envioSMSAprobador(cPerfilTasa, cNombreCli);
                        }
                    }
                    else
                    {
                       MessageBox.Show("el estado de solicitud distinto a [SOLICITADO] o [Devuelto].", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       btnEnviar1.Enabled = false;
                    }
               }           
            }

        }
        private void envioCorreoAprobador(string cPerfilTasa, string cNombreCli)
        {
            string cPerfil = string.Empty;
            string cCuerpo = string.Empty;
            string cAsunto = string.Empty;

            string c_xNombreUsuario = cNombreUsuario.Trim();
            string c_xNombreagencia = cNombreagencia.Trim();
            string c_xNombreCli = cNombreCli;
            string c_xTasaCompensatoria = txtTasaCompensatoria.Text.Trim();
            string c_xMonto = txtMonto.Text.Trim();
            string c_xTasaPizarra = txtTasaCom.Text.Trim();

            DataTable dtAprobadorCorreo = new DataTable();
            clsCNSolicitud objCNprobacion = new clsCNSolicitud();
            DataTable dtCuerpoMensaje = objCNprobacion.CNObtenerCuerpoMensaje(c_xNombreUsuario, c_xNombreagencia, c_xNombreCli, c_xTasaCompensatoria, c_xMonto, clsVarGlobal.PerfilUsu.cPerfil, c_xTasaPizarra);

            if (dtCuerpoMensaje.Rows.Count == 0) 
            {
                MessageBox.Show("Ocurrió un error al recuperar texto de correo electrónico.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            cPerfil = dtParamEnvioEmail.Rows[0]["cValVar"].ToString();
            cCuerpo = Convert.ToString(dtCuerpoMensaje.Rows[0]["TextoMensaje"].ToString());

            cAsunto = "Solicitud de TEA Negociable " + c_xNombreCli + " " + cNombreagencia.Trim();
 
            dtAprobadorCorreo = objCNprobacion.CNListarCorreoAprobaSol(cPerfilTasa, idZonaUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil);

            var cFinalizaEnvioMAIL = "Se notificó por CORREO a los siguientes usuarios:" + Environment.NewLine + Environment.NewLine;
            if (dtAprobadorCorreo.Rows.Count > 0) 
            { 
                foreach (DataRow fila in dtAprobadorCorreo.Rows)
                {
                    string cCorreo = Convert.ToString(fila["cEmailInst"]);
                    string cWinuser = Convert.ToString(fila["cWinUser"]);
                    string cPerfilUs = Convert.ToString(fila["cPerfil"]);
                    if (!string.IsNullOrEmpty(cCorreo))
                    {
                        DataTable dtenviocorreo = objCNprobacion.CNEnviarCorreoAprobadorTN(cPerfil, cCorreo, cCuerpo, cAsunto);
                        cFinalizaEnvioMAIL = cFinalizaEnvioMAIL + " - [" + fila["cWinUser"].ToString() + "] " + fila["cPerfil"].ToString() + " [" + Convert.ToString(dtenviocorreo.Rows[0]["cMensaje"]) + "]." + Environment.NewLine;

                    }
                }
                MessageBox.Show(cFinalizaEnvioMAIL, "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);            
            }
        }
        private void envioSMSAprobador(string cPerfilTasa, string cNombreCli)
        {
            DataTable dtAprobadorSMS = new DataTable();
            clsCNSolicitud objCNprobacion = new clsCNSolicitud();
            dtAprobadorSMS = objCNprobacion.CNListarCelularAprobaSol(cPerfilTasa, idZonaUsuario, clsVarGlobal.nIdAgencia, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil);

            string cMensaje = string.Empty;
            string c_xNombreUsuario = cNombreUsuario.Trim();
            string c_xNombreagencia = cNombreagencia.Trim();
            string c_xNombreCli = cNombreCli;
            string c_xTasaCompensatoria = txtTasaCompensatoria.Text.Trim();
            string c_xMonto = txtMonto.Text.Trim();
            string c_xTasaPizarra = txtTasaCom.Text.Trim();

            DataTable dtCuerpoSMS = objCNprobacion.CNObtenerCuerpoMensajeSMS(c_xNombreUsuario, c_xNombreagencia, c_xNombreCli, c_xTasaCompensatoria, c_xMonto, clsVarGlobal.PerfilUsu.cPerfil);

            if (dtCuerpoSMS.Rows.Count == 0)
            {
                MessageBox.Show("Ha ocurrido un error al recuperar texto de SMS.", "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cMensaje = Convert.ToString(dtCuerpoSMS.Rows[0]["TextoMensaje"].ToString());

            var cFinalizaEnvioSMS = "Se notificó por SMS a los siguientes usuarios:" + Environment.NewLine + Environment.NewLine;
            if (dtAprobadorSMS.Rows.Count > 0) 
            { 
                foreach (DataRow fila in dtAprobadorSMS.Rows)
                {
                    string cCelular = Convert.ToString(fila["cCelular"]);
                    string cWinuser = Convert.ToString(fila["cWinUser"]);
                    string cPerfilUs = Convert.ToString(fila["cPerfil"]);
                    if (!string.IsNullOrEmpty(cCelular))
                    {
                        Dictionary<string, dynamic> cRespuesta = new Dictionary<string, dynamic>();
                        cRespuesta = enviarSMS(Convert.ToDouble(cCelular), cMensaje);
                        var cRespuestaMensaje = cRespuesta.First();
                        string cResp = $"{cRespuestaMensaje.Value}";
                        cFinalizaEnvioSMS = cFinalizaEnvioSMS + " - [" + fila["cWinUser"].ToString() + "] " + fila["cPerfil"].ToString() + " [" + cResp + "]." + Environment.NewLine;
                    }
                }
                MessageBox.Show(cFinalizaEnvioSMS, "Solicitud de Tasa Negociable", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public Dictionary<string, dynamic> enviarSMS(double numero, string mensaje)
        {
            Dictionary<string, dynamic> res = new Dictionary<string, dynamic>();
            ADM.CapaNegocio.clsCNMantenimiento obtenerPerfil = new ADM.CapaNegocio.clsCNMantenimiento();
            DataTable dtPerfil = obtenerPerfil.CNRetornaValorVariableGen("cServicioSMSInfobip");
            if (dtPerfil.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró ruta de servicio mensajeria SMS", "Envio de SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                res.Add("cEstado", "No se encontró ruta de Servicio");
                return res;
            }

            try
            {
                string cServicio = Convert.ToString(dtPerfil.Rows[0]["cValVar"]);
                string dicto = "{\"phone\":" + numero + ",\"content\":\"" + mensaje + "\"}";
                byte[] bBytes = Encoding.ASCII.GetBytes(dicto);
                byte[] response;

                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;

                string serviceURL = string.Format(cServicio);
                response = webClient.UploadData(serviceURL, "POST", bBytes);
                res.Add("cEstado", "Envío Correcto");
            }
            catch (Exception e)
            {
                res.Add("cEstado", "Falló envio");
                res.Add("cFail", e.ToString());
            }

            return res;
        }
        private void guardarDocumento()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string rutaDescarga = string.Empty;
            string nNombreArchivo = "TasaNegociable"+ Convert.ToString(cGlobal_idsolicitud) + ".pdf";
            string userFolder = Environment.UserName;
            rutaDescarga = @"C:\Users\" + userFolder + @"\Downloads\" + nNombreArchivo ;

            byte[] bytesPdf = new byte[0];

            DataTable dtResultado = cnsolicitud.CNGuardaPdfTasaNegociable(Convert.ToInt32(cGlobal_idsolicitud), nNombreArchivo.Trim(), (byte[])Compresion.CompressedByte(bytesPdf), clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario,false,"",0);

            if (File.Exists(rutaDescarga)) // si existe el archivo
            {
               File.Delete(rutaDescarga); //borras el archivo
            }
        }
    }
}



