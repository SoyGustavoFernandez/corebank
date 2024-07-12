using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GEN.Funciones;
using Microsoft.Reporting.WinForms;
using GEN.Servicio;
using EntityLayer.SentinelData;
using System.Globalization;

namespace CRE.Presentacion
{
    public partial class frmDecisionComiteCred : frmBase
    {
        #region Variables
        private clsCNExcepcionesCreditos objCNExcepciones = new clsCNExcepcionesCreditos();
        private clsComiteCred objComite = new clsComiteCred();
        private clsEvalCredComite objEvalCred = new clsEvalCredComite();
        private clsCNComiteCreditos objCNComiteCred = new clsCNComiteCreditos();
        private clsCNAprobacionCredito objCNAprobacionCredito = new clsCNAprobacionCredito();
        private clsCNGestionObservaciones objCNGestionObservaciones = new clsCNGestionObservaciones();
        private clsCreditoProp objCreditoProp;
        private int nExcepciones;
        private const string cTituloMsjes = "Comité de créditos.";
        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();
        private clsCNExpedienteLinea clsExpedienteNegocio = new clsCNExpedienteLinea();
        private clsComiteCreditoSesion objComiteCreditoSesion;
        private System.Timers.Timer objTimer;
        private int idFormulario = 0;


        string cTipoPersona = string.Empty;
        DataTable dtClasificacionCliente = new DataTable();
        ClsCNClienteExclusivo objCE = new ClsCNClienteExclusivo();
        clsCNIntervCre cninterviniente = new clsCNIntervCre();
        Response objRespuesta;
        List<TitularConyuge> objLisTituConyuge;
        clsApiCentralRsgExterno objCentraRsgExterno = new clsApiCentralRsgExterno();
        GEN.CapaNegocio.clsCNValidaReglasDinamicas ValidaReglasDinamicas = new GEN.CapaNegocio.clsCNValidaReglasDinamicas();

        Response objRespuestaTitular;
        Response objRespuestaConyuge;

        private string cTipoSolicitud = "individual";
        DataTable dtBasicoSunatTitular;
        DataColumn columnBasicoSunatTitular;
        DataRow rowBasicoSunatTitular;

        DataTable dtBasicoSunatConyuge;
        DataColumn columnBasicoSunatConyuge;
        DataRow rowBasicoSunatConyuge;
        DataSet dsContenedorConsolidada;

        DataTable dtBSunatDireccionTitular;
        DataColumn columnBSunatDireccionTitular;
        DataRow rowBSunatDireccionTitular;

        DataTable dtBSunatDireccionConyuge;
        DataColumn columnBSunatDireccionConyuge;
        DataRow rowBSunatDireccionConyuge;

        DataTable dtRlegalTitular;
        DataColumn columnRlegalTitular;
        DataRow rowRlegalTitular;

        DataTable dtRlegalConyuge;
        DataColumn columnRlegalConyuge;
        DataRow rowRlegalConyuge;

        DataTable dtlCredNoUtilizadaT;
        DataColumn columnlCredNoUtilizadaT;
        DataRow rowlCredNoUtilizadaT;

        DataTable dtlCredNoUtilizadaC;
        DataColumn columnlCredNoUtilizadaC;
        DataRow rowlCredNoUtilizadaC;

        DataTable dtDeudaTitular;
        DataColumn columnDeudaTitular;
        DataRow rowDeudaTitular;

        DataTable dtDeudaConyuge;
        DataColumn columnDeudaConyuge;
        DataRow rowDeudaConyuge;

        DataTable dtAvalistaTitular;
        DataColumn columnAvalistaTitular;
        DataRow rowAvalistaTitular;

        DataTable dtAvalistaConyuge;
        DataColumn columnAvalistaConyuge;
        DataRow rowAvalistaConyuge;

        DataTable dtAvalado;
        DataColumn columnAvaladoTitular;
        DataRow rowAvaladoTitular;

        DataTable dtAvaladoConyuge;
        DataColumn columnAvaladoConyuge;
        DataRow rowAvaladoConyuge;
        DataTable dtDeudaSentinelDirectaTitular;
        DataTable dtDeudaSentinelDirectaConyuge;

        DataTable dtMicrTitular;
        DataColumn columnMicrTitular;
        DataRow rowMicrTitular;

        DataTable dtMicrConyuge;
        DataColumn columnMicrConyuge;
        DataRow rowMicrConyuge;

        DataTable dtHistorialSentinelTitular;
        DataRow rowHistorialSentinelTitular;
        DataColumn columnHistorialSentinelTitular;

        DataTable dtHistorialSentinelConyuge;
        DataRow rowHistorialSentinelConyuge;
        DataColumn columnHistorialSentinelConyuge;

        DataTable dtClasTitularConyuge;
        DataColumn columnClasTitularConyuge;
        DataRow rowClasTitularConyuge;
        string cSemaforoTitular = string.Empty;
        string cSemaforoConyuge = string.Empty;
        string cidTipoDocumento = string.Empty;
        int nidTipoPersona;
        
        #endregion

        #region Métodos
        public frmDecisionComiteCred()
        {
            InitializeComponent();

            this.btnSalir.lEventoDesactivado = true;

            conCreditoTasa.Enabled = false;

            cboMotRechazo.Visible = false;
            lblComentario.Visible = false;

            btnEditarCondCredito.Enabled = true;
            btnGrabarCondCredito.Enabled = false;


            grbObservaciones.Visible = false;
            //grbComentario.Visible = false;

            objEvalCred = new clsEvalCredComite();
            nExcepciones = 0;
        }

        public frmDecisionComiteCred(clsComiteCred _objComite, clsEvalCredComite _objEvalCredComite, clsComiteCreditoSesion objComiteCreditoSesion)
        {
            InitializeComponent();
            formatGridView();

            this.objComite = _objComite;
            this.objEvalCred = _objEvalCredComite;
            this.objComiteCreditoSesion = objComiteCreditoSesion;
            this.btnGestObs.Enabled = true;
            this.conCreditoTasa.Enabled = false;
            this.cboMotRechazo.Visible = false;
            this.lblComentario.Visible = false;
            this.btnEditarCondCredito.Enabled = this.condicionesEditable(this.objEvalCred.idProducto);
            this.btnGrabarCondCredito.Enabled = false;
            this.grbObservaciones.Visible = false;

            //------------------------
            txtNroDoc.Text = this.objEvalCred.cDocumentoID.ToString();
            txtNombre.Text = this.objEvalCred.cNombre.ToString();
            txtAsesor.Text = this.objEvalCred.cAsesor.ToString();
            txtIdSolicitud.Text = this.objEvalCred.idSolicitud.ToString(); 
            txtIdEvalCred.Text = this.objEvalCred.idEval.ToString();
            txtOperacion.Text = this.objEvalCred.cOperacion.ToString();
            txtModCredito.Text = this.objEvalCred.cModalidadCredito.ToString();

            cboResultComite.SelectedValue = this.objEvalCred.idResultado;
            cboMotRechazo.SelectedValue = this.objEvalCred.idMotRechazo;
            txtObservResultado.Text = this.objEvalCred.cComentario;
            txtComentRev.Text = this.objEvalCred.cComentRev;
            lblBase4.Text = "Comentario del Revisor " + this.objEvalCred.cNombreResponsable + " :";

            this.obtenerParticipantes(this.objComite.idComiteCred, this.objEvalCred.idEval);

            bindingObservaciones.DataSource = objEvalCred.lstObsAprobador;
            dtgObservaciones.DataSource = bindingObservaciones;
            formatGridViewObservaciones();

            clsCreditoProp objCreditoProp = objCNAprobacionCredito.ObtenerCondicionesCredito(objEvalCred.idEval);
            conCreditoTasa.AsignarDatos(objCreditoProp);

            this.objCreditoProp = objCreditoProp;

            txtIdSolicitud.Text = this.objEvalCred.idSolicitud.ToString();
            txtIdSolicitud.Text = this.objEvalCred.idSolicitud.ToString();
            nExcepciones = 0;
            nroExcepciones(this.objEvalCred.idSolicitud);

            if (!((objEvalCred.idEstadoEvalCred == 2 || this.objEvalCred.idEstadoEvalCred == 10) && this.objEvalCred.idEtapaEvalCred == 4))
            {
                this.HabilitarPanelDecision(false, 1);
                MessageBox.Show("Esta evaluación se encuentra en estado " + this.objEvalCred.cEstado + " en etapa de " + this.objEvalCred.cEtapa + "\n\n" +
                    "* No se permite emitir resolución en dicha condición." +
                    "** Si el comité tiene otras evaluaciones, intente resolverlas y luego finalice el comité."
                , "CONDICIONES INCORRECTAS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            MostrarGarantias(this.objEvalCred.idSolicitud);

            DataTable dtControlDPS = new clsCNCargaArchivo().controlDpsCargados(this.objEvalCred.idSolicitud);
            if (Convert.ToInt32(dtControlDPS.Rows[0]["idEstado"]) == 0)
            {
                MessageBox.Show(dtControlDPS.Rows[0]["cEstado"].ToString(), "Alerta de Control de DPS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool condicionesEditable(int idProducto)
        {
            string cProductos = new clsCNGenVariables().RetornaVariable("cProductoCondicion", 0);
            List<int> lstRural = new List<int>();
            if (!string.IsNullOrWhiteSpace(cProductos))
            {
                string[] aProducto = cProductos.Split(',');
                foreach (string cProducto in aProducto)
                {
                    int nEntero = 0;
                    if (int.TryParse(cProducto, out nEntero))
                    {
                        lstRural.Add(nEntero);
                    }
                }
            }
            if (lstRural.Contains(idProducto))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void MostrarGarantias(int idSolicitud)
        {
            DataSet dsGarantias = objCNComiteCred.CNLstGarantiasSolCre(idSolicitud);
            DataTable dtFiadorSolidario = dsGarantias.Tables[0];
            DataTable dtGarantias = dsGarantias.Tables[1];

            dtgFiadorSolidario.DataSource = dtFiadorSolidario;
            dtgGarantias.DataSource = InvertirCamporGarantias(dtGarantias);
            formatoDTGGarantias();
        }

        private DataTable InvertirCamporGarantias(DataTable dtGarantias)
        {
            DataTable dtInvertidoGaranti = new DataTable();
            dtInvertidoGaranti.Columns.Add("Campo", typeof(String));
            if (dtGarantias.Rows.Count == 0)
            {
                DataRow drFila = dtInvertidoGaranti.NewRow();
                drFila["Campo"] = "Sin garantias";
                dtInvertidoGaranti.Rows.Add(drFila);
                return dtInvertidoGaranti;
            }
            for (int k = 1; k <= dtGarantias.Rows.Count; k++)
            {
                dtInvertidoGaranti.Columns.Add("Garantía_" + k, typeof(String));
            }
            for (int i = 0; i < dtGarantias.Columns.Count; i++)
            {
                if (dtGarantias.Columns[i].ColumnName == "idGarantia")
                {
                    break;
                }
                DataRow drFila = dtInvertidoGaranti.NewRow();
                if (String.Compare(dtGarantias.Columns[i].ColumnName, "cTipoGarantia") == 0)
                    drFila["Campo"] = "Tipo de Garantía";
                else if (String.Compare(dtGarantias.Columns[i].ColumnName, "cNombre") == 0)
                    drFila["Campo"] = "Propietario";
                else if (String.Compare(dtGarantias.Columns[i].ColumnName, "cGarantia") == 0)
                    drFila["Campo"] = "Descripción";
                else if (String.Compare(dtGarantias.Columns[i].ColumnName, "cUbigeo") == 0)
                    drFila["Campo"] = "Ubigeo";
                else if (String.Compare(dtGarantias.Columns[i].ColumnName, "nValorRealiza") == 0)
                    drFila["Campo"] = "Valor de realización";
                else if (String.Compare(dtGarantias.Columns[i].ColumnName, "dFecUltVal") == 0)
                    drFila["Campo"] = "Fecha de tasación";
                else
                    drFila["Campo"] = dtGarantias.Columns[i].ColumnName;
                for (int j = 0; j < dtGarantias.Rows.Count; j++)
                {
                    drFila["Garantía_" + (j + 1)] = dtGarantias.Rows[j][i].ToString();
                }
                dtInvertidoGaranti.Rows.Add(drFila);
            }

            return dtInvertidoGaranti;
        }

        private void formatoDTGGarantias()
        {
            foreach (DataGridViewColumn item in this.dtgGarantias.Columns)
            {
                item.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", (float)(7.5));
            }
        }

        private void actualizaEstadoRevisionEval()
        {
            clsCNComiteCreditos objCNComites = new clsCNComiteCreditos();
            DataTable dtGrabarEstEvalCred = objCNComites.grabarEstadoEvalCred(this.objEvalCred.idEval, this.objEvalCred.idSolicitud, this.objComite.idComiteCred, false, true);
        }

        private void nroExcepciones(int idSolicitud)
        {

            DataTable dtNroExcepciones = objCNAprobacionCredito.NroExcepcionesCredito(idSolicitud);
            nExcepciones = Convert.ToInt32(dtNroExcepciones.Rows[0][0].ToString());
        }
        private void formatGridView()
        {
            this.dtgParticipantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgParticipantes.Margin = new System.Windows.Forms.Padding(0);
            this.dtgParticipantes.MultiSelect = false;
            this.dtgParticipantes.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgParticipantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgParticipantes.RowHeadersVisible = false;
            this.dtgParticipantes.ReadOnly = true;

            this.dtgObservaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgObservaciones.Margin = new System.Windows.Forms.Padding(0);
            this.dtgObservaciones.MultiSelect = false;
            this.dtgObservaciones.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgObservaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgObservaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgObservaciones.RowHeadersVisible = false;
            this.dtgObservaciones.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dtgObservaciones.ReadOnly = true;
        }

        private void formatGridViewParticipantes()
        {
            foreach (DataGridViewColumn column in this.dtgParticipantes.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgParticipantes.Columns["lResponsable"].DisplayIndex = 0;
            dtgParticipantes.Columns["cNombre"].DisplayIndex = 1;
            dtgParticipantes.Columns["cDecision"].DisplayIndex = 2;
            dtgParticipantes.Columns["cTipoParticip"].DisplayIndex = 3;

            dtgParticipantes.Columns["lResponsable"].Visible = true;
            dtgParticipantes.Columns["cNombre"].Visible = true;
            dtgParticipantes.Columns["cDecision"].Visible = true;
            dtgParticipantes.Columns["cTipoParticip"].Visible = true;

            dtgParticipantes.Columns["lResponsable"].HeaderText = "Resp.?";
            dtgParticipantes.Columns["cNombre"].HeaderText = "Nombres";
            dtgParticipantes.Columns["cDecision"].HeaderText = "Opinión";
            dtgParticipantes.Columns["cTipoParticip"].HeaderText = "Tip. Particip.";

            dtgParticipantes.Columns["lResponsable"].FillWeight = 15;
            dtgParticipantes.Columns["cNombre"].FillWeight = 70;
            dtgParticipantes.Columns["cDecision"].FillWeight = 30;
            dtgParticipantes.Columns["cTipoParticip"].FillWeight = 30;
        }

        private void formatGridViewObservaciones()
        {
            foreach (DataGridViewColumn column in this.dtgObservaciones.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgObservaciones.Columns["cTipObservacion"].DisplayIndex = 0;
            dtgObservaciones.Columns["cObservacion"].DisplayIndex = 1;
            dtgObservaciones.Columns["lSubsanado"].DisplayIndex = 2;

            dtgObservaciones.Columns["cTipObservacion"].Visible = true;
            dtgObservaciones.Columns["cObservacion"].Visible = true;
            dtgObservaciones.Columns["lSubsanado"].Visible = true;

            dtgObservaciones.Columns["cTipObservacion"].HeaderText = "Tipo ";
            dtgObservaciones.Columns["cObservacion"].HeaderText = "Observación";
            dtgObservaciones.Columns["lSubsanado"].HeaderText = "?";

            dtgObservaciones.Columns["cTipObservacion"].FillWeight = 50;
            dtgObservaciones.Columns["cObservacion"].FillWeight = 100;
            dtgObservaciones.Columns["lSubsanado"].FillWeight = 10;
        }

        private bool ValidarReglas()
        {
            string cCumpleReglas = String.Empty;
            int nNivAuto = 0;
            DataTable dtParametros = ArmarTablaParametros();

            cCumpleReglas = new clsCNValidaReglasDinamicas().ValidarReglas(dtTablaParametros: dtParametros,
                                                                            cNombreFormulario: "frmRegComiteCred",
                                                                            idAgencia: clsVarGlobal.nIdAgencia,
                                                                            idCliente: 0,
                                                                            idEstadoOperac: 1,
                                                                            idMoneda: 1,
                                                                            idProducto: 1,
                                                                            nValAproba: 0,
                                                                            idDocument: 0,
                                                                            dFecSolici: clsVarGlobal.dFecSystem,
                                                                            idMotivo: 0,
                                                                            idEstadoSol: 1,
                                                                            idUsuRegist: clsVarGlobal.User.idUsuario,
                                                                            idSolApr: ref nNivAuto);

            if (cCumpleReglas.Equals("Cumple"))
            {
                return true;
            }
            return false;
        }

        private DataTable ArmarTablaParametros()
        {
            /*clsEvalCredComite objEvalCredComite = dtgEvaluaciones.SelectedRows[0].DataBoundItem as clsEvalCredComite;
            clsCreditoProp objCreditoProp = conCreditoTasa.ObtenerCreditoPropuesto();
            int idCli = objEvalCredComite.idCli;
            int idSolCred = objEvalCredComite.idSolicitud;*/
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            //Obtenemos los datos generales del cliente

            /*DataTable dtDatCli = new clsCNBuscarCli().GetDatosGenCli(idCli);

            foreach (DataColumn column in dtDatCli.Columns)
            {
                if (column.DataType == typeof(DateTime))
                {
                    dtTablaParametros.Rows.Add(column.ColumnName,
                        ((DateTime)dtDatCli.Rows[0][column.ColumnName]).ToString("yyyy-MM-dd"));
                }
                else
                {
                    dtTablaParametros.Rows.Add(column.ColumnName,
                        dtDatCli.Rows[0][column.ColumnName].ToString());
                }
            }

            DataTable dtDatSolCre = new clsCNSolicitud().CNGetDatGenCreSolCre(idSolCred);

            foreach (DataColumn column in dtDatSolCre.Columns)
            {
                if (column.DataType == typeof(DateTime))
                {
                    dtTablaParametros.Rows.Add(column.ColumnName,
                        ((DateTime)dtDatSolCre.Rows[0][column.ColumnName]).ToString("yyyy-MM-dd"));
                }
                else
                {
                    dtTablaParametros.Rows.Add(column.ColumnName,
                        dtDatSolCre.Rows[0][column.ColumnName].ToString());
                }
            }*/
            clsCreditoProp objCredProp = conCreditoTasa.ObtenerCreditoPropuesto();
            DataRow drfila = dtTablaParametros.NewRow();

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idResultado";
            drfila[1] = Convert.ToInt32(cboResultComite.SelectedValue);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSolCre";
            drfila[1] = objEvalCred.idSolicitud;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idOperacionSol";
            drfila[1] = objCreditoProp.idOperacion;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipCred";
            drfila[1] = objEvalCred.idTipEval;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEvalCred";
            drfila[1] = objEvalCred.idEval;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTipCamFij";
            drfila[1] = Convert.ToDecimal(clsVarApl.dicVarGen["nTipCamFij"]);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nValAproba";
            drfila[1] = this.objCreditoProp.nMonto;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "lVerificacionForm";
            drfila[1] = chcVerificacion.Checked;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTasaCompForm";
            drfila[1] = objCreditoProp.nTasaCompensatoria;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMonedaForm";
            drfila[1] = objCreditoProp.idMoneda;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipProd";
            drfila[1] = objCreditoProp.idProducto;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idOperacionForm";
            drfila[1] = objCreditoProp.idOperacion;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idProductoForm";
            drfila[1] = objCreditoProp.idProducto;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idNivelAprRanOpeForm";
            drfila[1] = objCreditoProp.idNivelAprRanOpe;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nCuotasForm";
            drfila[1] = objCreditoProp.nCuotas;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTEAForm";
            drfila[1] = objCreditoProp.nTea;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "lVerificacionForm";
            drfila[1] = chcVerificacion.Checked;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoOpe";
            drfila[1] = 55;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUser";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUserPersonal";
            drfila[1] = clsVarGlobal.User.idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = objEvalCred.idCli;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCanal";
            drfila[1] = clsVarGlobal.idCanal.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nIdAgencia";
            drfila[1] = clsVarGlobal.nIdAgencia.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nITF";
            drfila[1] = clsVarGlobal.nITF.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idPerfil";
            drfila[1] = clsVarGlobal.PerfilUsu.idPerfil.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaCese";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaIngreso";
            drfila[1] = clsVarGlobal.User.dFechaIngreso.Year.ToString("yyyy-MM-dd");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCargo";
            drfila[1] = clsVarGlobal.User.idCargo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimOpePacSol";
            drfila[1] = clsVarApl.dicVarGen["nLimOpePacSol"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimOpePacDol";
            drfila[1] = clsVarApl.dicVarGen["nLimOpePacDol"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimIndividual";
            drfila[1] = clsVarApl.dicVarGen["nLimIndividual"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimGlobal";
            drfila[1] = clsVarApl.dicVarGen["nLimGlobal"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idModulo";
            drfila[1] = clsVarGlobal.idModulo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoPeriodo";
            drfila[1] = objCredProp.idTipoPeriodo;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "frecuencia";
            drfila[1] = objCredProp.nPlazoCuota.ToString();
            dtTablaParametros.Rows.Add(drfila);
            
            return dtTablaParametros;
        }
        #region Sesion de Comite de Credito
        private void iniciarTemporizador()
        {
            this.objTimer = new System.Timers.Timer();
            this.objTimer.Interval = 60000;
            this.objTimer.Elapsed += Timer_Elapsed;
            this.objTimer.Start();
        }
        private void finalizarComiteCreditoSesion()
        {
            if (this.objTimer != null)
            {
                this.objTimer.Close();
            }
            this.actualizarTiemposSesion();
        }

        private void iniciarComiteCreditoSesion()
        {
            this.actualizarTiemposSesion();
            this.iniciarTemporizador();
        }
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!IsHandleCreated) return;
            Invoke(new MethodInvoker(delegate()
            {
                this.objComiteCreditoSesion.nTiempoRestante--;
                if (this.objComiteCreditoSesion.nTiempoRestante <= 0)
                {
                    this.finalizarComiteCreditoSesion();
                    frmComiteCredSesionMensaje objFrmMensaje = new frmComiteCredSesionMensaje("El tiempo de sesión del comité ha finalizado.\n\n" +
                       "*Todos los créditos que no tengan una decisión serán devueltos a la etapa de evaluación.",
                        "TIEMPO AGOTADO", 5, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    objFrmMensaje.ShowDialog();

                    this.Close();
                }
                else if (
                    !this.objComiteCreditoSesion.lTiempoAmpliado &&
                    this.objComiteCreditoSesion.lValidoParaAmpliacion &&
                    this.objComiteCreditoSesion.nTiempoAlerta >= 0 &&
                    this.objComiteCreditoSesion.nTiempoRestante == this.objComiteCreditoSesion.nTiempoAlerta)
                {
                    frmComiteCredSesionMensaje objFrmMensaje = new frmComiteCredSesionMensaje("El comité de créditos se cerrará en " +
                        this.objComiteCreditoSesion.nTiempoAlerta + " minutos.\n\n" +
                        "¿Desea solicitar tiempo adicional?", "SESION DE COMITE", 10, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    objFrmMensaje.ShowDialog();

                    if (objFrmMensaje.idResultado == System.Windows.Forms.DialogResult.Yes)
                    {
                        frmComiteCreditoTiempoAdicional objFrmComiteCredTiempoAdd = new frmComiteCreditoTiempoAdicional(this.objComiteCreditoSesion.idComiteCred, false);
                        objFrmComiteCredTiempoAdd.Show();
                    }

                }
                this.lblTiempoRestante.Text = (new TimeSpan(0, this.objComiteCreditoSesion.nTiempoRestante, 0)).ToString(@"hh\:mm");
            }));
        }
        private void actualizarTiemposSesion()
        {
            this.lblEstado.Text = this.objComiteCreditoSesion.cEstado;
            this.lblHoraIniProg.Text = this.objComiteCreditoSesion.tHoraIniProg.ToString(@"hh\:mm");
            this.lblTiempoAmpliado.Text = this.objComiteCreditoSesion.tTiempoAmpliado.ToString(@"hh\:mm");
            this.lblHoraFinProg.Text = this.objComiteCreditoSesion.tHoraFinProg.ToString(@"hh\:mm");
            this.lblTiempoRestante.Text = (new TimeSpan(0, this.objComiteCreditoSesion.nTiempoRestante, 0)).ToString(@"hh\:mm");
        }
        #endregion

        #endregion

        #region Eventos

        #region Generales
        private void frmDecisionComiteCred_Load(object sender, EventArgs e)
        {
            CreaTablaClasificacionCliente();
            CreaTablaBasicoSunatTitular();
            CreaTablaBasicoSunatConyuge();
            CreaTablaBSunatDireccionTitular();
            CreaTablaBSunatDireccionConyuge();
            CreaTablaRLegalTitular();
            CreaTablaRLegalConyuge();
            CreaTablalCredNoUtilTitular();
            CreaTablalCredNoUtilConyuge();
            CreaTablaDeudaTitular();
            CreaTablaDeudaConyuge();
            CreaTablaAvalistaTitular();
            CreaTablaAvalistaConyuge();
            CreaTablaAvaladoTitular();
            CreaTablaAvaladoConyuge();
            CreaTablaMicrofinanzasTitular();
            CreaTablaMicrofinanzasConyuge();
            CreaTablaHistorialSentinelTitular();
            CreaTablaHistorialSentinelConyuge();
            /*txtNroDoc.Text = this.objEvalCred.cDocumentoID.ToString();
            txtNombre.Text = this.objEvalCred.cNombre.ToString();
            txtAsesor.Text = this.objEvalCred.cAsesor.ToString();
            txtIdSolicitud.Text = this.objEvalCred.idSolicitud.ToString();
            txtIdEvalCred.Text = this.objEvalCred.idEval.ToString();
            txtOperacion.Text = this.objEvalCred.cOperacion.ToString();
            txtModCredito.Text = this.objEvalCred.cModalidadCredito.ToString();*/

            cboResultComite.SelectedValue = (this.objEvalCred.idResultado == 6 || this.objEvalCred.idResultado==null) ? 5 : this.objEvalCred.idResultado;
            cboMotRechazo.SelectedValue = (this.objEvalCred.idMotRechazo==null)? 0 : this.objEvalCred.idMotRechazo;

            conLimitesOperativos.InitControl();
            conLimitesOperativos.IdUsuario = objEvalCred.idAsesor;
            conLimitesOperativos.IdAgencia = objComite.idAgencia;

            /*txtObservResultado.Text = this.objEvalCred.cComentario;
            txtComentRev.Text = this.objEvalCred.cComentRev;

            bindingParticipantes.DataSource = objEvalCred.lstDecisComite;
            dtgParticipantes.DataSource = bindingParticipantes;
            formatGridViewParticipantes();

            bindingObservaciones.DataSource = objEvalCred.lstObsAprobador;
            dtgObservaciones.DataSource = bindingObservaciones;
            formatGridViewObservaciones();

            clsCreditoProp objCreditoProp = objCNAprobacionCredito.ObtenerCondicionesCredito(objEvalCred.idEval);
            conCreditoTasa.AsignarDatos(objCreditoProp);

            this.objCreditoProp = objCreditoProp;

            txtIdSolicitud.Text = this.objEvalCred.idSolicitud.ToString();
            txtIdSolicitud.Text = this.objEvalCred.idSolicitud.ToString();
            lblnroExcepciones.Text = "No tiene Excepciones.";
            nExcepciones = 0;
            nroExcepciones(this.objEvalCred.idSolicitud);

            if (!((objEvalCred.idEstadoEvalCred == 2 || this.objEvalCred.idEstadoEvalCred == 10) && this.objEvalCred.idEtapaEvalCred == 4))
            {
                this.HabilitarPanelDecision(false, 1);
                MessageBox.Show("Ya fue dada una decision para esta evalución,\nno se puede realizar ningun cambio", "Solo Vizualización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            MostrarGarantias(this.objEvalCred.idSolicitud);*/

            cboResultComite_SelectedIndexChanged(this.cboResultComite, new EventArgs());
        }
        #endregion
        public void CreaTablaBasicoSunatTitular()
        {

            dtBasicoSunatTitular = new DataTable("dtBasicoSunatTitular");
            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "TDoc";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "NDoc";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "RelTDoc";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "RelNDOC";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "RazSoc";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "NomCom";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "TipCon";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "IniAct";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "ActEco";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "FchInsRRPP";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "AgeRet";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "ApePat";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "ApeMat";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "Nom";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "Sex";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "EstCon";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "EstDom";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "EstDomic";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

            columnBasicoSunatTitular = new DataColumn();
            columnBasicoSunatTitular.DataType = System.Type.GetType("System.String");
            columnBasicoSunatTitular.ColumnName = "CondDomic";
            dtBasicoSunatTitular.Columns.Add(columnBasicoSunatTitular);

        }
        public void CreaTablaBasicoSunatConyuge()
        {

            dtBasicoSunatConyuge = new DataTable("dtBasicoSunatConyuge");
            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "TDoc";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "NDoc";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "RelTDoc";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "RelNDOC";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "RazSoc";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "NomCom";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "TipCon";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "IniAct";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "ActEco";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "FchInsRRPP";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "AgeRet";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "ApePat";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "ApeMat";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "Nom";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "Sex";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "EstCon";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "EstDom";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "EstDomic";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

            columnBasicoSunatConyuge = new DataColumn();
            columnBasicoSunatConyuge.DataType = System.Type.GetType("System.String");
            columnBasicoSunatConyuge.ColumnName = "CondDomic";
            dtBasicoSunatConyuge.Columns.Add(columnBasicoSunatConyuge);

        }
        public void CreaTablaBSunatDireccionTitular()
        {

            dtBSunatDireccionTitular = new DataTable("dtBSunatDireccionTitular");
            columnBSunatDireccionTitular = new DataColumn();
            columnBSunatDireccionTitular.DataType = System.Type.GetType("System.String");
            columnBSunatDireccionTitular.ColumnName = "Direccion";
            dtBSunatDireccionTitular.Columns.Add(columnBSunatDireccionTitular);

            columnBSunatDireccionTitular = new DataColumn();
            columnBSunatDireccionTitular.DataType = System.Type.GetType("System.String");
            columnBSunatDireccionTitular.ColumnName = "Fuente";
            dtBSunatDireccionTitular.Columns.Add(columnBSunatDireccionTitular);

        }
        public void CreaTablaBSunatDireccionConyuge()
        {

            dtBSunatDireccionConyuge = new DataTable("dtBSunatDireccionConyuge");
            columnBSunatDireccionConyuge = new DataColumn();
            columnBSunatDireccionConyuge.DataType = System.Type.GetType("System.String");
            columnBSunatDireccionConyuge.ColumnName = "Direccion";
            dtBSunatDireccionConyuge.Columns.Add(columnBSunatDireccionConyuge);

            columnBSunatDireccionConyuge = new DataColumn();
            columnBSunatDireccionConyuge.DataType = System.Type.GetType("System.String");
            columnBSunatDireccionConyuge.ColumnName = "Fuente";
            dtBSunatDireccionConyuge.Columns.Add(columnBSunatDireccionConyuge);

        }
        public void CreaTablaRLegalTitular()
        {
            dtRlegalTitular = new DataTable("dtRlegalTitular");
            columnRlegalTitular = new DataColumn();
            columnRlegalTitular.DataType = System.Type.GetType("System.String");
            columnRlegalTitular.ColumnName = "TDOC";
            dtRlegalTitular.Columns.Add(columnRlegalTitular);

            columnRlegalTitular = new DataColumn();
            columnRlegalTitular.DataType = System.Type.GetType("System.String");
            columnRlegalTitular.ColumnName = "NDOC";
            dtRlegalTitular.Columns.Add(columnRlegalTitular);

            columnRlegalTitular = new DataColumn();
            columnRlegalTitular.DataType = System.Type.GetType("System.String");
            columnRlegalTitular.ColumnName = "Nombre";
            dtRlegalTitular.Columns.Add(columnRlegalTitular);

            columnRlegalTitular = new DataColumn();
            columnRlegalTitular.DataType = System.Type.GetType("System.String");
            columnRlegalTitular.ColumnName = "FecIniCar";
            dtRlegalTitular.Columns.Add(columnRlegalTitular);

            columnRlegalTitular = new DataColumn();
            columnRlegalTitular.DataType = System.Type.GetType("System.String");
            columnRlegalTitular.ColumnName = "Cargo";
            dtRlegalTitular.Columns.Add(columnRlegalTitular);
        }
        public void CreaTablaRLegalConyuge()
        {
            dtRlegalConyuge = new DataTable("dtRlegalConyuge");
            columnRlegalConyuge = new DataColumn();
            columnRlegalConyuge.DataType = System.Type.GetType("System.String");
            columnRlegalConyuge.ColumnName = "TDOC";
            dtRlegalConyuge.Columns.Add(columnRlegalConyuge);

            columnRlegalConyuge = new DataColumn();
            columnRlegalConyuge.DataType = System.Type.GetType("System.String");
            columnRlegalConyuge.ColumnName = "NDOC";
            dtRlegalConyuge.Columns.Add(columnRlegalConyuge);

            columnRlegalConyuge = new DataColumn();
            columnRlegalConyuge.DataType = System.Type.GetType("System.String");
            columnRlegalConyuge.ColumnName = "Nombre";
            dtRlegalConyuge.Columns.Add(columnRlegalConyuge);

            columnRlegalConyuge = new DataColumn();
            columnRlegalConyuge.DataType = System.Type.GetType("System.String");
            columnRlegalConyuge.ColumnName = "FecIniCar";
            dtRlegalConyuge.Columns.Add(columnRlegalConyuge);

            columnRlegalConyuge = new DataColumn();
            columnRlegalConyuge.DataType = System.Type.GetType("System.String");
            columnRlegalConyuge.ColumnName = "Cargo";
            dtRlegalConyuge.Columns.Add(columnRlegalConyuge);
        }
        public void CreaTablalCredNoUtilTitular()
        {

            dtlCredNoUtilizadaT = new DataTable("dtlCredNoUtilizadaT");
            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "Condicion";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);

            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "Inst";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);

            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "LinApr";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);

            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "LinNoUti";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);

            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "LinUti";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);

            columnlCredNoUtilizadaT = new DataColumn();
            columnlCredNoUtilizadaT.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaT.ColumnName = "TipCred";
            dtlCredNoUtilizadaT.Columns.Add(columnlCredNoUtilizadaT);
        }
        public void CreaTablalCredNoUtilConyuge()
        {

            dtlCredNoUtilizadaC = new DataTable("dtlCredNoUtilizadaC");
            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "Condicion";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);

            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "Inst";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);

            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "LinApr";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);

            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "LinNoUti";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);

            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "LinUti";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);

            columnlCredNoUtilizadaC = new DataColumn();
            columnlCredNoUtilizadaC.DataType = System.Type.GetType("System.String");
            columnlCredNoUtilizadaC.ColumnName = "TipCred";
            dtlCredNoUtilizadaC.Columns.Add(columnlCredNoUtilizadaC);
        }
        public void CreaTablaDeudaTitular()
        {
            dtDeudaTitular = new DataTable("dtDeudaTitular");

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "Condicion";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.Int32");
            columnDeudaTitular.ColumnName = "idFue";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "MaxDiaVen";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "NomFue";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "VenTot";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "NomEnt";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "MontDeu";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);


            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "DiaVen";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

            columnDeudaTitular = new DataColumn();
            columnDeudaTitular.DataType = System.Type.GetType("System.String");
            columnDeudaTitular.ColumnName = "NumDoc";
            dtDeudaTitular.Columns.Add(columnDeudaTitular);

        }
        public void CreaTablaDeudaConyuge()
        {
            dtDeudaConyuge = new DataTable("dtDeudaConyuge");

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "Condicion";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.Int32");
            columnDeudaConyuge.ColumnName = "idFue";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "MaxDiaVen";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "NomFue";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "VenTot";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "NomEnt";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "MontDeu";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);


            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "DiaVen";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);

            columnDeudaConyuge = new DataColumn();
            columnDeudaConyuge.DataType = System.Type.GetType("System.String");
            columnDeudaConyuge.ColumnName = "NumDoc";
            dtDeudaConyuge.Columns.Add(columnDeudaConyuge);
        }
        public void CreaTablaAvalistaTitular()
        {
            dtAvalistaTitular = new DataTable("dtAvalistaTitular");

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "Condicion";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "NDoc";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "RazSoc";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "Sem12Mes";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "SemAct";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "SemPre";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "NDocAcre";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "RazSocAcre";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "Cal";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "SalDeu";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "TipEnt";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

            columnAvalistaTitular = new DataColumn();
            columnAvalistaTitular.DataType = System.Type.GetType("System.String");
            columnAvalistaTitular.ColumnName = "FecRep";
            dtAvalistaTitular.Columns.Add(columnAvalistaTitular);

        }
        public void CreaTablaAvalistaConyuge()
        {
            dtAvalistaConyuge = new DataTable("dtAvalistaConyuge");

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "Condicion";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "NDoc";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "RazSoc";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "Sem12Mes";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "SemAct";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "SemPre";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "NDocAcre";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "RazSocAcre";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "Cal";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "SalDeu";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "TipEnt";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);

            columnAvalistaConyuge = new DataColumn();
            columnAvalistaConyuge.DataType = System.Type.GetType("System.String");
            columnAvalistaConyuge.ColumnName = "FecRep";
            dtAvalistaConyuge.Columns.Add(columnAvalistaConyuge);


        }
        public void CreaTablaAvaladoTitular()
        {
            ///Crea Tabla Avalado Titular
            dtAvalado = new DataTable("dtAvalado");

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "Condicion";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "ndoc";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "tDoc";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "razSoc";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "semAct";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "Sem12Mes";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "tDocAcre";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "nDocAcre";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "razSocAcre";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "cal";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "tipEnt";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "salDeu";
            dtAvalado.Columns.Add(columnAvaladoTitular);

            columnAvaladoTitular = new DataColumn();
            columnAvaladoTitular.DataType = System.Type.GetType("System.String");
            columnAvaladoTitular.ColumnName = "fecRep";
            dtAvalado.Columns.Add(columnAvaladoTitular);


        }
        public void CreaTablaAvaladoConyuge()
        {
            dtAvaladoConyuge = new DataTable("dtAvaladoConyuge");

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "Condicion";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "ndoc";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "tDoc";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "razSoc";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "semAct";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "Sem12Mes";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "tDocAcre";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "nDocAcre";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "razSocAcre";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "cal";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "tipEnt";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "salDeu";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

            columnAvaladoConyuge = new DataColumn();
            columnAvaladoConyuge.DataType = System.Type.GetType("System.String");
            columnAvaladoConyuge.ColumnName = "fecRep";
            dtAvaladoConyuge.Columns.Add(columnAvaladoConyuge);

        }
        public void CreaTablaMicrofinanzasTitular()
        {
            dtMicrTitular = new DataTable("dtMicrTitular");

            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "Condicion";
            dtMicrTitular.Columns.Add(columnMicrTitular);

            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "NomEnt";
            dtMicrTitular.Columns.Add(columnMicrTitular);

            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "Cal";
            dtMicrTitular.Columns.Add(columnMicrTitular);


            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "SalDeu";
            dtMicrTitular.Columns.Add(columnMicrTitular);


            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.Int32");
            columnMicrTitular.ColumnName = "DiaVen";
            dtMicrTitular.Columns.Add(columnMicrTitular);


            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "FchPro";
            dtMicrTitular.Columns.Add(columnMicrTitular);

            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "FchRep";
            dtMicrTitular.Columns.Add(columnMicrTitular);

            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "FchProNumero";
            dtMicrTitular.Columns.Add(columnMicrTitular);

            columnMicrTitular = new DataColumn();
            columnMicrTitular.DataType = System.Type.GetType("System.String");
            columnMicrTitular.ColumnName = "DeudaTotal";
            dtMicrTitular.Columns.Add(columnMicrTitular);
        }
        public void CreaTablaMicrofinanzasConyuge()
        {
            dtMicrConyuge = new DataTable("dtMicrConyuge");

            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "Condicion";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);

            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "NomEnt";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);


            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "Cal";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);


            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "SalDeu";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);


            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.Int32");
            columnMicrConyuge.ColumnName = "DiaVen";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);


            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "FchPro";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);

            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "FchRep";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);

            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "FchProNumero";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);

            columnMicrConyuge = new DataColumn();
            columnMicrConyuge.DataType = System.Type.GetType("System.String");
            columnMicrConyuge.ColumnName = "DeudaTotal";
            dtMicrConyuge.Columns.Add(columnMicrConyuge);
        }
        public void CreaTablaHistorialSentinelTitular()
        {
            dtHistorialSentinelTitular = new DataTable("dtHistorialSentinelTitular");

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "FechPro";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "SemaActual";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.Int32");
            columnHistorialSentinelTitular.ColumnName = "NroEntidad";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);


            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "DeudaTotal";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);


            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "Calificacion";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajeNOR";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajeCPP";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajeDEF";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajeDUD";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajePER";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "PorcentajeSCAL";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);

            columnHistorialSentinelTitular = new DataColumn();
            columnHistorialSentinelTitular.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelTitular.ColumnName = "FchProNumero";
            dtHistorialSentinelTitular.Columns.Add(columnHistorialSentinelTitular);
            

        }
        public void CreaTablaHistorialSentinelConyuge()
        {
            dtHistorialSentinelConyuge = new DataTable("dtHistorialSentinelConyuge");

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "FechPro";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "SemaActual";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.Int32");
            columnHistorialSentinelConyuge.ColumnName = "NroEntidad";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "DeudaTotal";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "Calificacion";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajeNOR";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajeCPP";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajeDEF";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajeDUD";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajePER";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "PorcentajeSCAL";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);

            columnHistorialSentinelConyuge = new DataColumn();
            columnHistorialSentinelConyuge.DataType = System.Type.GetType("System.String");
            columnHistorialSentinelConyuge.ColumnName = "FchProNumero";
            dtHistorialSentinelConyuge.Columns.Add(columnHistorialSentinelConyuge);
            
        }
        public void CreaTablaClasificacionCliente()
        {

            dtClasTitularConyuge = new DataTable("dtClasTitularConyuge");
            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cCondicion";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.Int32");
            columnClasTitularConyuge.ColumnName = "idTipoDocumento";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "ctipoDocumento";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cnombre";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cNumDocumento";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.Int32");
            columnClasTitularConyuge.ColumnName = "idCli";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cCalificacion";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cEstadoCivil";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cEdad";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cRelNDoc";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

            columnClasTitularConyuge = new DataColumn();
            columnClasTitularConyuge.DataType = System.Type.GetType("System.String");
            columnClasTitularConyuge.ColumnName = "cTipoCliente";
            dtClasTitularConyuge.Columns.Add(columnClasTitularConyuge);

        }
        #region Comite de Créditos
        private void cboResultComite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboResultComite.SelectedValue != null)
            {
                DataRowView dv = cboResultComite.SelectedItem as DataRowView;
                if (dv != null)
                {
                    int idResultado = Convert.ToInt32(dv.Row["idResultado"]);

                    lblComentario.Visible = (idResultado == 5 || idResultado == 7);
                    txtObservResultado.Visible = (idResultado == 5 || idResultado == 7);
                    cboMotRechazo.Visible = (idResultado == 7);
                    lblMotRechazo.Visible = (idResultado == 7);
                    //grbObservaciones.Visible = (idResultado == 8 || idResultado == 9);
                    //grbObservaciones.Visible = true;
                }
            }
        }

        private void btnDecidir_Click(object sender, EventArgs e)
        {
            string cRespEmision = new frmGestionObservaciones().GenEmitirObs(false, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
            if (cRespEmision != "")
            {
                MessageBox.Show(cRespEmision, "Gestión de observaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            int nValidaOpinionAntes = 0;
            int nValidaOpinionDespues = 0;
            
            foreach (DataGridViewRow dtRow in dtgParticipantes.Rows)
            {
                if (Convert.ToString(dtRow.Cells["cDecision"].Value) == "Desfavorable")
                {
                    nValidaOpinionAntes++;
                }
            }

            objEvalCred.lstDecisComite = objCNComiteCred.listarParticipComiteCred(this.objComite.idComiteCred, this.objEvalCred.idEval);
            nValidaOpinionDespues = objEvalCred.lstDecisComite.FindAll(x => x.lDecision == false).Count();

            if (nValidaOpinionAntes != nValidaOpinionDespues)
            {
                MessageBox.Show("Actualice las opiniones de los participantes virtuales.",
                "OPINIÓN DE PARTICIPANTES VIRTUALES", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bindingParticipantes.DataSource = objEvalCred.lstDecisComite;
            bindingParticipantes.ResetBindings(false);

            frmEvalCredAlertaVariable objEvalCredAlertaVariable = new frmEvalCredAlertaVariable(this.objEvalCred.idSolicitud, this.objEvalCred.idEval);
            objEvalCredAlertaVariable.validarCheck();

            if (objEvalCredAlertaVariable.lConformeCheck == true && Convert.ToInt32(cboResultComite.SelectedValue).In(5))
            {
                MessageBox.Show("Aún están pendientes de VB alguna(s) alertas de evaluación.",
                "ALERTA DE EVALUACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (objEvalCredAlertaVariable.lDenegadoSolEvalCred && objEvalCredAlertaVariable.lComforme)
            {
                this.HabilitarPanelDecision(false, 1);
                clsProcesoExp.guardarCopiaExpediente("Aprobacion de Credito", this.objEvalCred.idSolicitud, this);
                this.Close();
                return;
            }

            if (!objEvalCredAlertaVariable.lComforme && Convert.ToInt32(cboResultComite.SelectedValue) == 5) // 5 = APROBAR
            {
                MessageBox.Show("¡usted no ha aceptado las alertas de evaluación!\n\n" +
                "*No se le permitirá continuar con la aprobación.\n\n" +
                "**Intente realizar la aprobación nuevamente y acepte las alertas de evaluación.",
                "ALERTA DE EVALUACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!this.GrabarObservacionesAprobador()) return;
            else
            {
                if (!this.ValidarRestriccionesAprobacion()) return;

                if (Convert.ToInt32(cboResultComite.SelectedValue).In(5))
                {
                    clsRespuestaServidor objRespuesta = this.objCNExcepciones.validarAprobExcepcioneReglaNeg(this.objCreditoProp.idSolicitud);
                    if (objRespuesta.idResultado == ResultadoServidor.Error)
                    {
                        MessageBox.Show(objRespuesta.cMensaje, "ALERTA DE EXCEPCIÓN DE REGLA CREDITICIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!this.ValidarReglas()) return;
                }

                this.GestionarAprobacion();
            }
        }

        private void GestionarAprobacion()
        {
            this.objCreditoProp = conCreditoTasa.ObtenerCreditoPropuesto();
            int idResultado = Convert.ToInt32(cboResultComite.SelectedValue);

            if (idResultado == 5)
            {
                if (!ValidarIndicadorObser("lEmision"))
                {
                    MessageBox.Show("La solicitud debe estar en 'Emisión Completa' para pasar a la siguiente etapa.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (!ValidarIndicadorObser("lAbsolCom"))
                {
                    MessageBox.Show("Para continuar, Ud. debe Absolver las observaciones registradas.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                DialogResult resMensaje = MessageBox.Show(
                      "Acepto las condiciones anteriormente descritas,\n"
                    + "declaro  y  aseguro   que   esta  propuesta  de\n"
                    + "crédito   cumple  con   todos  los  requisitos,\n"
                    + "documentación,  verificación  y  evaluación que\n"
                    + "corresponde  según  las normativas  internas de\n"
                    + "créditos  de  la  empresa.   Asimismo,  declaro\n"
                    + "conocer  que  toda  vulneración  a  los  puntos\n"
                    + "anteriores, constituye en una infracción sujeta\n"
                    + "a sanción  disciplinaria  según  el  reglamento\n"
                    + "interno    de   la   empresa   e  inclusive  de\n"
                    + "comprobarse la falsedad en lo declarado, conoce\n"
                    + "que  corresponde a  la  empresa promover acción\n"
                    + "civil (laboral) y/o penal por  el delito contra\n"
                    + "la  Fe  Pública  previsto  en el vigente Código\n"
                    + "Penal.", "APROBACIÓN DE CRÉDITO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resMensaje == DialogResult.No)
                {
                    return;
                }

                DataTable dtGes = objCNAprobacionCredito.GestionarAprobacion(this.objEvalCred.idSolicitud, this.objEvalCred.idEval, clsVarGlobal.nIdAgencia, this.objCreditoProp.nMonto, false);
                List<clsAprobacionCredito> objAproCred = new List<clsAprobacionCredito>();
                objAproCred = DataTableToList.ConvertTo<clsAprobacionCredito>(dtGes) as List<clsAprobacionCredito>;

                if (objAproCred[0].idError == 0)
                {
                    DialogResult dlres = MessageBox.Show("" + objAproCred[0].cMensaje, "Aprobacion en proceso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlres == DialogResult.Yes)
                    {
                        int idEtapaEvalCred = 5;
                        if (objAproCred[0].idEstadoEvalCred == 5)
                            idEtapaEvalCred = objEvalCred.idEtapaEvalCred;

                        this.GuardarDecision(objAproCred[0].idEstadoEvalCred, idEtapaEvalCred, objAproCred[0].idNivelAprobacion, objAproCred[0].lEnviaSolInfRiesgos, objAproCred[0].lRevision);
                    }
                }
                else if (objAproCred[0].idError == 1)
                {
                    MessageBox.Show("" + objAproCred[0].cMensaje, "Error al intentar consultar aprobacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (idResultado == 8)
            {
                this.GuardarDecision(idResultado, 3, 1, false, false);
            }
            else if (idResultado == 9)
            {
                this.GuardarDecision(idResultado, 3, objEvalCred.idNivelAprobacion, false, false);
            }
            else
            {
                this.GuardarDecision(idResultado, 4, objEvalCred.idNivelAprobacion, false, false);
            }
        }

        public void GuardarDecision(int idEstadoEvalCred, int idEtapaEvalCred, int idNivelAprobacion, bool lEnviaSolInfRiesgos, bool lRevision)
        {

            string cComentario = txtObservResultado.Text.Trim();
            string cComentRev = txtComentRev.Text.Trim();
            bool lVerificacion = chcVerificacion.Checked;
            int idMotRechazo = idEstadoEvalCred == 7 ? Convert.ToInt32(cboMotRechazo.SelectedValue) : 0;

            DataTable dtRes = objCNAprobacionCredito.GuardarDecisionComite(
                this.objEvalCred.idEvalComiteCred, this.objEvalCred.idSolicitud, this.objEvalCred.idEval, this.objComite.idUsuarioReg,
                idEstadoEvalCred, idEtapaEvalCred, idNivelAprobacion, lEnviaSolInfRiesgos, lRevision,
                cComentario, cComentRev, lVerificacion, idMotRechazo);

            if (Convert.ToInt32(dtRes.Rows[0]["idError"]) == 0)
            {
                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], "Decision aprobador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (idEstadoEvalCred == 7 || idEstadoEvalCred == 5)
                {
                    //Recupera informacion para Posicion consilidada antes de congelar
                    DataTable didDescTipoDoc = clsExpedienteNegocio.obtenerIdentificaridDescTipoDoc();
                    DataSet dExpedientes = clsExpedienteNegocio.getGrupoExpedienteLinea("Posicion consolidada de Cliente", this.objEvalCred.idSolicitud, "individual");
                    DataTable dtLeerTablaExpediente = dExpedientes.Tables[0];

                    /*  Guardar Expedientes - Grupo Aprobacion  */
                    clsProcesoExp.guardarCopiaExpediente("Aprobacion de Credito", this.objEvalCred.idSolicitud, this);

                    bool lPosConsolidadaExterno = false;
                    if (clsVarGlobal.lisVars.Any(item => item.cVariable.Contains("lPosConsolidadaExterno")))
                    {
                        clsVarGen objVarPosConsolidada = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("lPosConsolidadaExterno"));
                        lPosConsolidadaExterno = Convert.ToBoolean(objVarPosConsolidada.cValVar);
                    }
                    if (lPosConsolidadaExterno)
                    {
                        clsCNIntervCre IntervCre = new clsCNIntervCre();
                        DataTable dtLisIntervSol = IntervCre.obtenerIntervinienteSolicitud(this.objEvalCred.idSolicitud, clsVarGlobal.idModulo, true, true);

                        foreach (DataRow row in dtLisIntervSol.Rows)
                        {
                            int idCliSel = Convert.ToInt32(row["idCli"]);
                            string cDocumentoSel = Convert.ToString(row["cDocumentoID"]);
                            /*  Guardar Expedientes - Posicion Consolidada - Congelamiento */
                            dExpedientes.Tables[0].Rows[0]["idSecundario"] = idCliSel;
                            SentinelPosicionConsolidada(idCliSel, cDocumentoSel);
                            clsProcesoExp.guardarCopiaExpedientePosicionConsolidada(Convert.ToInt32(didDescTipoDoc.Rows[0]["idDescTipoDoc"]), cTipoSolicitud, idCliSel, "Posicion consolidada de Cliente", this.objEvalCred.idSolicitud, this, dsContenedorConsolidada, dExpedientes);
                        }
                    }

                }
                this.HabilitarPanelDecision(false, 1);
            }
            else
            {
                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarRestriccionesAprobacion()
        {
            if (cboResultComite.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una decisión","No seleccionado",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }

            int idResultado = Convert.ToInt32(cboResultComite.SelectedValue);

            if (idResultado == 7 && cboMotRechazo.SelectedIndex<0)
            {
                MessageBox.Show("Seleccione un motivo de rechazo","No seleccionado",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            else if (idResultado == 5 || idResultado == 7)
            {
                
                if (!objEvalCred.lstDecisComite.Exists(x => x.lResponsable == true))
                {
                    MessageBox.Show("Asigne al revisor del expediente","Revisor no asignado",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (this.txtObservResultado.Text.Equals(string.Empty))
                {
                    MessageBox.Show("El presidente debe ingresar su comentario", "Comentario pendiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if(this.txtComentRev.Text.Equals(string.Empty))
                {
                    MessageBox.Show("El revisor del crédito debe ingresar su comentario", "Comentario pendiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            int nObsSinSubsanar = objEvalCred.lstObsAprobador.Count(x => x.lSubsanado == false);

            if (idResultado == 5)
            {
                if (nObsSinSubsanar > 0)
                {
                    MessageBox.Show("Quedan ( " + nObsSinSubsanar + " ) observaciones por subsanar, no se podrá APROBAR sin antes subsanar todas.", "Observaciones pendientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                clsDecisComite objDecis=this.objEvalCred.lstDecisComite.Find(x => x.lDecision==false);
                if(objDecis!=null && objDecis.idUsuComite==this.objComite.idUsuPreside)
                {
                    MessageBox.Show("La opinión del presidente de comite es desfavorable, por lo tanto, el credito no puede ser aprobado","",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                    return false;
                }
                else
                {
                    clsCNExcepcionesCreditos objCNExcepCred = new clsCNExcepcionesCreditos();
                    DataTable dtRes=objCNExcepCred.ContExcepcionesPorEstado(this.objEvalCred.idSolicitud);

                    DataTable obtenerRegla = new DataTable();
                    obtenerRegla = objCNExcepCred.obtenerReglas(this.objEvalCred.idSolicitud);
                    if (Convert.ToInt32(obtenerRegla.Rows[0]["nResultado"]) == 0)
                    {
                        MessageBox.Show("Está pendiente de aprobación la siguiente Excepción no Contemplada: \n <<" + Convert.ToString(obtenerRegla.Rows[0]["nDesRegla"]) + ">>. \n No podrá aprobar el crédito hasta la aprobación de la excepción.", "Excepciones No Contempladas", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                    else if (Convert.ToInt32(obtenerRegla.Rows[0]["nResultado"]) == 1)
                    {
                        MessageBox.Show("Tiene una Excepción no Contemplada aprobada: \n <<" + Convert.ToString(obtenerRegla.Rows[0]["nDesRegla"]) + ">>. \n El reporte de aprobación debe adjuntarse al expediente.", "Excepciones No Contempladas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //  return false;
                    }

                    if(dtRes.Rows.Count==0)
                    {
                    }
                    else if (Convert.ToInt32(dtRes.Rows[0]["nDesestimados"]) > 0)
                    {
                        MessageBox.Show("La solicitud tiene ( "+dtRes.Rows[0]["nDesestimados"]+" ) excepciones desestimadas por lo que no podra ser aprobado","Excepciones desestimadas",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return false;
                    }
                    else if (Convert.ToInt32(dtRes.Rows[0]["nSolicitados"]) > 0)
                    {
                        MessageBox.Show("La solicitud tiene ( " + dtRes.Rows[0]["nSolicitados"] + " ) excepciones solicitadas que deben ser aceptadas", "Excepciones solicitadas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            else if (!ValidarIndicadorObser("lObserv") && (idResultado == 8 || idResultado == 9))
            {
                MessageBox.Show("No se podrá DEVOLVER o enviar a AJUSTE sin antes registrar observaciones.", "Registre observación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private bool GrabarObservacionesAprobador()
        {
            clsCNObservacionAprobador objCNObsApro = new clsCNObservacionAprobador();
            DataTable dtRes = objCNObsApro.GrabarObservacionAprobador(this.objEvalCred.idEval, this.objEvalCred.idSolicitud,this.objEvalCred.idNivelAprobacion, this.objEvalCred.lstObsAprobador.GetXml());

            if (Convert.ToInt32(dtRes.Rows[0]["idError"]) == 0)
            {
                clsCNObservacionAprobador objCNObsApro2 = new clsCNObservacionAprobador();
                objEvalCred.lstObsAprobador = objCNObsApro2.ListarObsAprobador(this.objEvalCred.idEval);
                if (dtgObservaciones.Rows.Count != objEvalCred.lstObsAprobador.Count)
                {
                    MessageBox.Show("Actualice las observaciones, aún están pendientes de los participantes virtuales.", "Observación desactualizada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                bindingObservaciones.DataSource = objEvalCred.lstObsAprobador;
                bindingObservaciones.ResetBindings(false);
                return true;
            }
            else
            {
                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], "Error inesperado en observaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void obtenerParticipantes(int idComiteCred, int idEval)
        {
            clsDecisComite objRevisorVirtual = new clsDecisComite();

            objEvalCred.lstDecisComite = objCNComiteCred.listarParticipComiteCred(idComiteCred, idEval);
            bindingParticipantes.DataSource = objEvalCred.lstDecisComite;
            dtgParticipantes.DataSource = bindingParticipantes;
            formatGridViewParticipantes();

            objRevisorVirtual = objEvalCred.lstDecisComite.FirstOrDefault(x => x.lResponsable == true);
            
            if(objRevisorVirtual != null)
            {
                if (objRevisorVirtual.lResponsable == true && objRevisorVirtual.idTipoParticip == 3)
                {
                    this.txtComentRev.Text = "";
                    this.txtComentRev.Enabled = false;
                    DataTable dtResultComentObs = objCNComiteCred.obtenerComentObsComiteVirtual(idComiteCred, this.objEvalCred.idEval, 0);
                    this.txtComentRev.Text = dtResultComentObs.Rows[0]["cComentRev"].ToString();
                }
                else 
                {
                    this.txtComentRev.Text = "";
                    this.txtComentRev.Enabled = true;
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (this.objEvalCred == null)
            {
                MessageBox.Show("No se ha seleccionado la evaluación", "Comité de créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (this.objEvalCred.idSolicitud == 0)
            {
                MessageBox.Show("No se ha ingresado la solicitud", "Comité de créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (this.objEvalCred.idCli == 0)
            {
                MessageBox.Show("No se ha ingresado el cliente", "Comité de créditos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            frmExpedienteLinea frmExpLinea = new frmExpedienteLinea(this.objEvalCred.idSolicitud, this.objEvalCred.idCli, "individual");
            frmExpLinea.ShowDialog();
        }

        private void btnPosIntInterv_Click(object sender, EventArgs e)
        {
            new frmPosicionInterv().MostrarReporte(objEvalCred.cDocumentoID, objEvalCred.cNombre, objEvalCred.idCli);
        }

        private void btnHistEEFF_Click(object sender, EventArgs e)
        {
            DataSet dsHist = (new clsCNComiteCreditos()).HistoricoEEFF(this.objEvalCred.idEval);

            List<ReportParameter> paramList = new List<ReportParameter>();
            List<ReportDataSource> dtsList = new List<ReportDataSource>();

            dtsList.Add(new ReportDataSource("dsInfEvalCred", dsHist.Tables[0]));
            dtsList.Add(new ReportDataSource("dsDetalleGuardadosEval", dsHist.Tables[1]));
            dtsList.Add(new ReportDataSource("dsHistBalGenEval", dsHist.Tables[2]));
            dtsList.Add(new ReportDataSource("dsHistEstResEval", dsHist.Tables[3]));
            dtsList.Add(new ReportDataSource("dsHistIndFinEval", dsHist.Tables[4]));

            paramList.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge.ToString(), false));
            paramList.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
            paramList.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));
            paramList.Add(new ReportParameter("idEvalCred", this.objEvalCred.idEval.ToString()));

            string reportPath = "rptHistEEFFEval.rdlc";

            frmReporteLocal frmReporteProp = new frmReporteLocal(dtsList, reportPath, paramList);
            frmReporteProp.Show();
        }

        private void tsmOpinion_Click(object sender, EventArgs e)
        {
            if (dtgParticipantes.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione el usuario del que desea actualizar la opinión.", cTituloMsjes,
                                                                                            MessageBoxButtons.OK,
                                                                                            MessageBoxIcon.Warning);
                return;
            }

            clsDecisComite objDecision = (clsDecisComite)dtgParticipantes.SelectedRows[0].DataBoundItem;

            if (objDecision.idTipoParticip == 3)
            {
                MessageBox.Show("No es posible cambiar la opinión de una participación virtual.", "PARTICIPANTE VIRTUAL",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("¿Está seguro de cambiar su decisión?", cTituloMsjes,
                                                                                            MessageBoxButtons.YesNo,
                                                                                            MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }

            DataTable dtRes = objCNComiteCred.CambiarOpinionUsuComiteCred(objComite.idComiteCred, objEvalCred.idEval, objDecision.idUsuComite, !(objDecision.lDecision == true), clsVarGlobal.dFecSystem);
            if (Convert.ToInt32(dtRes.Rows[0]["idError"]) == 0)
            {
                objEvalCred.lstDecisComite.Where(x => x.idUsuComite == objDecision.idUsuComite).First().lDecision = !(objDecision.lDecision == true);
                this.bindingParticipantes.ResetBindings(false);

                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], cTituloMsjes,
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], cTituloMsjes,
                                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsmResponsable_Click(object sender, EventArgs e)
        {

            if (dtgParticipantes.SelectedRows.Count <= 0)
            {
                MessageBox.Show("No se seleccionó ningun usuario responsable de la revisión.", cTituloMsjes,
                                                                                                MessageBoxButtons.OK,
                                                                                                MessageBoxIcon.Warning);
                return;
            }

            clsDecisComite objUsuResponsable = (clsDecisComite)dtgParticipantes.SelectedRows[0].DataBoundItem;

            if (objUsuResponsable.idCargo != 59)
            {
                MessageBox.Show("El usuario tiene un cargo que no le permite ser revisor de créditos.", cTituloMsjes,
                                                                                                        MessageBoxButtons.OK,
                                                                                                        MessageBoxIcon.Warning);
                return;
            }

            if (objEvalCred.idAsesor == objUsuResponsable.idUsuComite)
            {
                MessageBox.Show("El asesor del crédito no puede ser el responsable de la revisión.", cTituloMsjes,
                                                                                                MessageBoxButtons.OK,
                                                                                                MessageBoxIcon.Warning);
                return;
            }

            if (objEvalCred.idUsuResponsable == objUsuResponsable.idUsuComite)
            {
                MessageBox.Show("El usuario ya es responsable de la revisión de la evaluación.", cTituloMsjes,
                                                                                                MessageBoxButtons.OK,
                                                                                                MessageBoxIcon.Warning);
                return;
            }

            if (objEvalCred.idUsuResponsable != null)
            {
                DialogResult result = MessageBox.Show("¿Confirma la asignación de " + objUsuResponsable.cNombre + " como responsable de la revisión de la evaluación?", cTituloMsjes,
                                                                                                                        MessageBoxButtons.YesNo,
                                                                                                                        MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return;
                }
            }

            DataTable dtRes = objCNComiteCred.AsigResponsableRevisionCred(objComite.idComiteCred, objEvalCred.idEval, objUsuResponsable.idUsuComite);
            if (Convert.ToInt32(dtRes.Rows[0]["idError"]) == 0)
            {
                 this.obtenerParticipantes(this.objComite.idComiteCred, this.objEvalCred.idEval);

                objEvalCred.idUsuResponsable = objUsuResponsable.idUsuComite;

                lblBase4.Text = "Comentario del Revisor " + objUsuResponsable.cNombre + " :";

                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], cTituloMsjes,
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], cTituloMsjes,
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Condiciones del Crédito
        private void btnEditarCondCredito_Click(object sender, EventArgs e)
        {
            habilitarConCreditoTasa(true);
        }

        private void btnGrabarCondCredito_Click(object sender, EventArgs e)
        {
            clsMsjError objError = conCreditoTasa.Validar();

            if (objError.HasErrors)
            {
                MessageBox.Show("La propuesta contiene errores.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsCreditoProp objCredProp = conCreditoTasa.ObtenerCreditoPropuesto();

            if (objCredProp.nMonto > this.objEvalCred.nMontoSoli)
            {
                MessageBox.Show("El monto propuesto no puede ser mayor a lo solicitado por el cliente.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsCNAprobacionCredito objCNAproCred = new clsCNAprobacionCredito();
            DataTable dtRes = objCNAproCred.ActualizarCondicionesCredito(objCredProp.idEvalCred, objCredProp.idSolicitud, objCredProp.nMonto, objCredProp.nCuotas, objCredProp.idTipoPeriodo,
                objCredProp.nPlazoCuota, objCredProp.nPlazo, objCredProp.nCuotasGracia, objCredProp.nDiasGracia, objCredProp.dFechaDesembolso, objCredProp.idProducto, objCredProp.idTasa, objCredProp.nTasaCompensatoria);

            if (Convert.ToInt32(dtRes.Rows[0]["idError"]) == 0)
            {
                this.objCreditoProp = conCreditoTasa.ObtenerCreditoPropuesto();
                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], "ACTUALIZACIÓN CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], "ERROR INESPERADO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            habilitarConCreditoTasa(false);
        }

        private void btnCancelarCondCredito_Click(object sender, EventArgs e)
        {
            habilitarConCreditoTasa(false);

            clsCNAprobacionCredito objCNAproCred = new clsCNAprobacionCredito();
            this.objCreditoProp = objCNAproCred.ObtenerCondicionesCredito(this.objEvalCred.idEval);

            this.conCreditoTasa.AsignarDatos(this.objCreditoProp);
        }

        private void habilitarConCreditoTasa(bool lHabilitado)
        {
            conCreditoTasa.Enabled = lHabilitado;

            grbObservaciones.Enabled = !lHabilitado;
            grbMiembros.Enabled = !lHabilitado;
            grbDecision.Enabled = !lHabilitado;
            btnImprimir.Enabled = !lHabilitado;
            btnPosIntInterv.Enabled = !lHabilitado;
            chcVerificacion.Enabled = !lHabilitado;
            txtComentRev.Enabled = !lHabilitado;

            btnGrabarCondCredito.Enabled = lHabilitado;
            btnEditarCondCredito.Enabled = !lHabilitado;
            btnCancelarCondCredito.Enabled = lHabilitado;
        }

        public void HabilitarPanelDecision(bool lAccion, int nPanel)
        {

            switch (nPanel)
            {
                case 1: this.tbpDecision.Enabled = lAccion;
                        this.btnAlertaEvaluacion.Enabled = lAccion;
                    break;
            }
        }

        #endregion

        #region Observaciones
        private void btnAddObs_Click(object sender, EventArgs e)
        {
            frmObsAprobacion frmEditObs = new frmObsAprobacion();
            frmEditObs.idOrigenObs = 1;

            if (objEvalCred.idUsuResponsable == null)
            {
                MessageBox.Show("Seleccione el responsable de la revisión de la evaluación.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsObservacionAprobador objObservacion = new clsObservacionAprobador();

            objObservacion.idObsAprobador = 0;
            //objObservacion.idSolicitud= objEvalCred.idSolicitud;
            objObservacion.idTipObservacion = 0;
            objObservacion.cTipObservacion = string.Empty;
            objObservacion.cObservacion = string.Empty;
            objObservacion.lSubsanado = false;
            objObservacion.idUsuReg = clsVarGlobal.User.idUsuario;

            frmEditObs.objObservacion = objObservacion;
            frmEditObs.ShowDialog();

            if (!frmEditObs.lAceptado) return;

            objEvalCred.lstObsAprobador.Add(objObservacion);
            bindingObservaciones.ResetBindings(false);
        }

        private void btnQuitObs_Click(object sender, EventArgs e)
        {
            if (dtgObservaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a eliminar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsObservacionAprobador objObservacion = (clsObservacionAprobador)dtgObservaciones.SelectedRows[0].DataBoundItem;

            if (objObservacion.idObsAprobador > 0)
            {
                MessageBox.Show("No se pueden eliminar las observaciones.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            objEvalCred.lstObsAprobador.Remove(objObservacion);
            //bindingObservaciones.DataSource = objEvalCred.lstObservaciones;
            bindingObservaciones.ResetBindings(false);
        }

        private void btnEditObs_Click(object sender, EventArgs e)
        {
            if (dtgObservaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a editar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //dtgObservaciones.SelectedCells.co

            clsObservacionAprobador objObservacion = dtgObservaciones.SelectedRows[0].DataBoundItem as clsObservacionAprobador;

            if (objObservacion.idObsAprobador != 0)
            {
                MessageBox.Show("Solo se pueden editar las observaciones nuevas.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmObsAprobacion frmEditObs = new frmObsAprobacion();

            //frmEditObs.idOrigenObs = objObservacion.idOrigenObs;
            frmEditObs.objObservacion = objObservacion;
            frmEditObs.ShowDialog();

            bindingObservaciones.DataSource = objEvalCred.lstObsAprobador;
            bindingObservaciones.ResetBindings(false);
        }

        private void btnSubsanar_Click(object sender, EventArgs e)
        {
            if (dtgObservaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione la observación a subsanar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            clsObservacionAprobador objObservacion = dtgObservaciones.SelectedRows[0].DataBoundItem as clsObservacionAprobador;

            if (objObservacion == null) return;

            if (objObservacion.idObsAprobador == 0)
            {
                MessageBox.Show("No se puede subsanar una observacion recien creada.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            objObservacion.lSubsanado = true;
            this.bindingObservaciones.ResetBindings(false);
            /*objObservacion.dFecha = clsVarGlobal.dFecSystem.Date;
            objObservacion.idUsuario = clsVarGlobal.User.idUsuario;*/

            /*string xmlObservaciones = objEvalCred.lstObsAprobador.GetXml<clsObservacion>();
            clsDBResp objDbResp = new clsCNObservaciones().CNGuardarObservaciones(xmlObservaciones);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                objEvalCred.lstObsAprobador = new clsCNObservaciones().CNGetObservaciones(objEvalCred.idSolicitud, 55);
                dtgObservaciones.DataSource = objEvalCred.lstObsAprobador.ToList();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }
        #endregion

     
        private void frmDecisionComiteCred_Shown(object sender, EventArgs e)
        {
            this.iniciarComiteCreditoSesion();
        }

        private void frmDecisionComiteCred_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.finalizarComiteCreditoSesion();
            this.actualizaEstadoRevisionEval();
            if (!ValidarIndicadorObser("lEmision"))
            {
                MessageBox.Show("La solicitud debe estar en 'Emisión Completa' para pasar a la siguiente etapa, no puede cerrar el formulario.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }
        }

        private void btnExcepciones_Click(object sender, EventArgs e)
        {
            if (txtIdSolicitud.Text != "")
            {
                frmGestionReglasNegExcepcion objGestionExcepcion = new frmGestionReglasNegExcepcion(this.objCreditoProp.idSolicitud, clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil);
                objGestionExcepcion.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay una solicitud de crédito vinculada", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        private void btnAlertaEvaluacion_Click(object sender, EventArgs e)
        {
            this.idFormulario = 1569;
            frmEvalCredAlertaVariable objFrmEvalCredAlertaVariable = new frmEvalCredAlertaVariable(this.objEvalCred.idSolicitud, this.objEvalCred.idEval, this.idFormulario);
            objFrmEvalCredAlertaVariable.ShowDialog();
        }

        private void tsmActualizar_Click(object sender, EventArgs e)
        {
            this.obtenerParticipantes(this.objComite.idComiteCred, this.objEvalCred.idEval);

            clsCNObservacionAprobador objCNObsApro = new clsCNObservacionAprobador();
            objEvalCred.lstObsAprobador = objCNObsApro.ListarObsAprobador(this.objEvalCred.idEval);
            bindingObservaciones.DataSource = objEvalCred.lstObsAprobador;
            dtgObservaciones.DataSource = bindingObservaciones;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.actualizaEstadoRevisionEval();
            if (!ValidarIndicadorObser("lEmision"))
            {
                MessageBox.Show("La solicitud debe estar en 'Emisión Completa' para pasar a la siguiente etapa, no puede cerrar el formulario.", "Validación de Solicitud de crédito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                this.btnSalir.lEventoDesactivado = false;
            }
            this.Dispose();
        }
        public void SentinelPosicionConsolidada(int idCliSeleccion, string cDocumentoIDSel)
        {
            dsContenedorConsolidada = new DataSet();


            if (idCliSeleccion.ToString() != string.Empty)
            {
                
                GEN.CapaNegocio.clsCNBuscarCli listarCli = new GEN.CapaNegocio.clsCNBuscarCli();
                DataTable tablaCli = listarCli.ListarclixIdCli(Convert.ToInt32(idCliSeleccion));

                cidTipoDocumento = tablaCli.Rows[0]["idTipoDocumento"].ToString();

                nidTipoPersona = Convert.ToInt32(tablaCli.Rows[0]["IdTipoPersona"]);

                if (nidTipoPersona == 1)
                {
                    cTipoPersona = "N";
                }
                if (nidTipoPersona == 2 || nidTipoPersona == 3)
                {
                    cTipoPersona = "J";
                }

                DataTable dResultadoReglaConciones = ValidaReglasDinamicas.ValidarReglasCondiciones(ArmarTablaParametrosPosicionConsolidada(idCliSeleccion, cDocumentoIDSel, cidTipoDocumento), "frmPosConCliente", cTipoPersona);

                DataTable dResumenCondiciones = new DataTable();
                dResumenCondiciones = GeneraResumenCondiciones(dResultadoReglaConciones);
                dsContenedorConsolidada.Tables.Add(dResumenCondiciones.Copy());

                DataTable dRastreo = new DataTable();

                dRastreo = cninterviniente.CNdtLstRastreoPosicionConsolidada(cDocumentoIDSel);
                dRastreo.TableName = "dtRastreo";

                dsContenedorConsolidada.Tables.Add(dRastreo.Copy());

                objLisTituConyuge = new List<TitularConyuge>();
                //Clasificacion Cliente

                dtClasificacionCliente = objCE.CNObtenerClasificacionTitularConyuge(cDocumentoIDSel, Convert.ToInt32(cidTipoDocumento));
                for (int i = 0; i < dtClasificacionCliente.Rows.Count; i++)
                {
                    TitularConyuge modelTituConyuge = new TitularConyuge();
                    modelTituConyuge.cCondicion = dtClasificacionCliente.Rows[i]["cCondicion"].ToString();
                    modelTituConyuge.ctipoDocumento = dtClasificacionCliente.Rows[i]["ctipoDocumento"].ToString();
                    modelTituConyuge.cnombre = dtClasificacionCliente.Rows[i]["cnombre"].ToString();
                    modelTituConyuge.cNumDocumento = dtClasificacionCliente.Rows[i]["cNumDocumento"].ToString();
                    modelTituConyuge.idCli = Convert.ToInt32(dtClasificacionCliente.Rows[i]["idCli"].ToString());
                    modelTituConyuge.cCalificacion = dtClasificacionCliente.Rows[i]["cCalificacion"].ToString();
                    modelTituConyuge.cEstadoCivil = dtClasificacionCliente.Rows[i]["cEstadoCivil"].ToString();
                    modelTituConyuge.cEdad = dtClasificacionCliente.Rows[i]["cEdad"].ToString();
                    modelTituConyuge.cTipoCliente = dtClasificacionCliente.Rows[i]["cTipoCliente"].ToString();
                    modelTituConyuge.idTipoDocumento = Convert.ToInt32(dtClasificacionCliente.Rows[i]["idTipoDocumento"].ToString());


                    if (cTipoPersona == "N")
                    {
                        objRespuesta = objCentraRsgExterno.ConsultaClienteExterno(clsVarGlobal.User.idUsuario, dtClasificacionCliente.Rows[i]["cNumDocumento"].ToString(), "D");
                        if (objRespuesta.Data.Count > 0)
                        {
                            DatosBasicoSunat(objRespuesta.Data[0].InfBas, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            modelTituConyuge.cRelNDoc = (objRespuesta.Data[0].InfBas == null) ? String.Empty : objRespuesta.Data[0].InfBas.RelNDoc;
                            DatosBasicoSunatDireccion(objRespuesta.Data[0].InfGen.Direcc, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosBasicoSunatRLegal(objRespuesta.Data[0].InfGen.EsRepLegDe, objRespuesta.Data[0].InfGen.RepLeg, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosBasicoLineaCredito(objRespuesta.Data[0].ConRap.UtiLinCre, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosDeudaProtesto(objRespuesta.Data[0].ConRap.DetVen, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosAvalista(objRespuesta.Data[0].AvalCod.AvalDe, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosAvalado(objRespuesta.Data[0].AvalCod.QuiAval, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosDeudaDirecta(objRespuesta.Data[0].ConRap.DetSBSMicr, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                        }

                        if (dtClasificacionCliente.Rows[i]["cCondicion"].ToString() == "Titular")
                        {
                            objRespuestaTitular = objRespuesta;
                        }
                        else
                        {
                            objRespuestaConyuge = objRespuesta;
                        }
                    }

                    if (cTipoPersona == "J")
                    {
                        objRespuesta = objCentraRsgExterno.ConsultaClienteExterno(clsVarGlobal.User.idUsuario, dtClasificacionCliente.Rows[i]["cNumDocumento"].ToString(), "R");
                        if (objRespuesta.Data.Count > 0)
                        {
                            DatosBasicoSunat(objRespuesta.Data[0].InfBas, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosBasicoSunatDireccion(objRespuesta.Data[0].InfGen.Direcc, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosBasicoSunatRLegal(objRespuesta.Data[0].InfGen.EsRepLegDe, objRespuesta.Data[0].InfGen.RepLeg, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosBasicoLineaCredito(objRespuesta.Data[0].ConRap.UtiLinCre, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosDeudaProtesto(objRespuesta.Data[0].ConRap.DetVen, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosAvalista(objRespuesta.Data[0].AvalCod.AvalDe, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosAvalado(objRespuesta.Data[0].AvalCod.QuiAval, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                            DatosDeudaDirecta(objRespuesta.Data[0].ConRap.DetSBSMicr, dtClasificacionCliente.Rows[i]["cCondicion"].ToString());
                        }

                        if (dtClasificacionCliente.Rows[i]["cCondicion"].ToString() == "Titular")
                        {
                            objRespuestaTitular = objRespuesta;
                        }
                    }
                    if (objRespuesta.Data.Count == 0)
                    {
                        MessageBox.Show("Existe caida del Servicio Sentinel, Comunicarse con el departamento de sistemas", "Sentinel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        modelTituConyuge.PuntajeScore = "";
                        modelTituConyuge.nRiesgo = "";
                        modelTituConyuge.CapacidadPago = "";
                        modelTituConyuge.cRelNDoc = "";
                        objLisTituConyuge.Add(modelTituConyuge);

                        dtClasTitularConyuge.Clear();
                        for (int j = 0; j < objLisTituConyuge.Count; j++)
                        {
                            DataRow rowClasTitularConyuge = dtClasTitularConyuge.NewRow();

                            rowClasTitularConyuge["cCondicion"] = objLisTituConyuge[j].cCondicion;
                            rowClasTitularConyuge["idTipoDocumento"] = Convert.ToInt32(objLisTituConyuge[j].idTipoDocumento);
                            rowClasTitularConyuge["ctipoDocumento"] = objLisTituConyuge[j].ctipoDocumento;
                            rowClasTitularConyuge["cnombre"] = objLisTituConyuge[j].cnombre;
                            rowClasTitularConyuge["cNumDocumento"] = objLisTituConyuge[j].cNumDocumento;
                            rowClasTitularConyuge["idCli"] = Convert.ToInt32(objLisTituConyuge[j].idCli);
                            rowClasTitularConyuge["cCalificacion"] = objLisTituConyuge[j].cCalificacion;
                            rowClasTitularConyuge["cEstadoCivil"] = objLisTituConyuge[j].cEstadoCivil;
                            rowClasTitularConyuge["cEdad"] = objLisTituConyuge[j].cEdad;
                            rowClasTitularConyuge["cRelNDoc"] = objLisTituConyuge[j].cRelNDoc;
                            rowClasTitularConyuge["cTipoCliente"] = objLisTituConyuge[j].cTipoCliente;

                            dtClasTitularConyuge.Rows.Add(rowClasTitularConyuge);
                        }

                        dsContenedorConsolidada.Tables.Add(dtBasicoSunatTitular.Copy());
                        dsContenedorConsolidada.Tables.Add(dtBasicoSunatConyuge.Copy());
                        dsContenedorConsolidada.Tables.Add(dtBSunatDireccionTitular.Copy());
                        dsContenedorConsolidada.Tables.Add(dtBSunatDireccionConyuge.Copy());
                        dsContenedorConsolidada.Tables.Add(dtRlegalTitular.Copy());
                        dsContenedorConsolidada.Tables.Add(dtRlegalConyuge.Copy());
                        dsContenedorConsolidada.Tables.Add(dtClasTitularConyuge.Copy());
                        dsContenedorConsolidada.Tables.Add(dtMicrTitular.Copy());
                        dsContenedorConsolidada.Tables.Add(dtMicrConyuge.Copy());
                        DataTable dtCombinedDeudaSentinelVacio = new DataTable("dtDeudaSentinelDirectaTitular");
                        if (dtDeudaSentinelDirectaTitular != null)
                        {
                            dtCombinedDeudaSentinelVacio = dtDeudaSentinelDirectaTitular.Copy();
                        }

                        if (dtDeudaSentinelDirectaConyuge != null)
                        {
                            dtCombinedDeudaSentinelVacio.Merge(dtDeudaSentinelDirectaConyuge);
                        }

                        dsContenedorConsolidada.Tables.Add(dtCombinedDeudaSentinelVacio.Copy());

                        DataTable dtCombinedLineaCreditoSentinelVacio = new DataTable("dtlCredNoUtilizadaT");
                        if (dtlCredNoUtilizadaT != null)
                        {
                            dtCombinedLineaCreditoSentinelVacio = dtlCredNoUtilizadaT.Copy();
                        }
                        if (dtlCredNoUtilizadaC != null)
                        {
                            dtCombinedLineaCreditoSentinelVacio.Merge(dtlCredNoUtilizadaC);
                        }

                        dsContenedorConsolidada.Tables.Add(dtCombinedLineaCreditoSentinelVacio.Copy());

                        DataTable dtCombinedVencidoSentinelVacio = new DataTable("dtDeudaTitular");
                        if (dtDeudaTitular != null)
                        {
                            dtCombinedVencidoSentinelVacio = dtDeudaTitular.Copy();
                        }
                        if (dtDeudaConyuge != null)
                        {
                            dtCombinedVencidoSentinelVacio.Merge(dtDeudaConyuge);
                        }
                        dsContenedorConsolidada.Tables.Add(dtCombinedVencidoSentinelVacio.Copy());

                        DataTable dtCombinedAvalistaSentinelVacio = new DataTable("dtAvalistaTitular");
                        if (dtAvalistaTitular != null)
                        {
                            dtCombinedAvalistaSentinelVacio = dtAvalistaTitular.Copy();
                        }
                        if (dtAvalistaConyuge != null)
                        {
                            dtCombinedAvalistaSentinelVacio.Merge(dtAvalistaConyuge);
                        }
                        dsContenedorConsolidada.Tables.Add(dtCombinedAvalistaSentinelVacio.Copy());

                        DataTable dtCombinedAvaladoSentinelVacio = new DataTable("dtAvalado");
                        if (dtAvalado != null)
                        {
                            dtCombinedAvaladoSentinelVacio = dtAvalado.Copy();
                        }
                        if (dtAvaladoConyuge != null)
                        {
                            dtCombinedAvaladoSentinelVacio.Merge(dtAvaladoConyuge);
                        }
                        dsContenedorConsolidada.Tables.Add(dtCombinedAvaladoSentinelVacio.Copy());
                        dsContenedorConsolidada.Tables.Add(dtHistorialSentinelTitular.Copy());
                        dsContenedorConsolidada.Tables.Add(dtHistorialSentinelConyuge.Copy());
                        return;
                    }
                    objLisTituConyuge.Add(modelTituConyuge);
                }
                dtClasTitularConyuge.Clear();
                for (int i = 0; i < objLisTituConyuge.Count; i++)
                {
                    DataRow rowClasTitularConyuge = dtClasTitularConyuge.NewRow();

                    rowClasTitularConyuge["cCondicion"] = objLisTituConyuge[i].cCondicion;
                    rowClasTitularConyuge["idTipoDocumento"] = Convert.ToInt32(objLisTituConyuge[i].idTipoDocumento);
                    rowClasTitularConyuge["ctipoDocumento"] = objLisTituConyuge[i].ctipoDocumento;
                    rowClasTitularConyuge["cnombre"] = objLisTituConyuge[i].cnombre;
                    rowClasTitularConyuge["cNumDocumento"] = objLisTituConyuge[i].cNumDocumento;
                    rowClasTitularConyuge["idCli"] = Convert.ToInt32(objLisTituConyuge[i].idCli);
                    rowClasTitularConyuge["cCalificacion"] = objLisTituConyuge[i].cCalificacion;
                    rowClasTitularConyuge["cEstadoCivil"] = objLisTituConyuge[i].cEstadoCivil;
                    rowClasTitularConyuge["cEdad"] = objLisTituConyuge[i].cEdad;
                    rowClasTitularConyuge["cRelNDoc"] = objLisTituConyuge[i].cRelNDoc;
                    rowClasTitularConyuge["cTipoCliente"] = objLisTituConyuge[i].cTipoCliente;


                    dtClasTitularConyuge.Rows.Add(rowClasTitularConyuge);
                }
                dsContenedorConsolidada.Tables.Add(dtBasicoSunatTitular.Copy());
                dsContenedorConsolidada.Tables.Add(dtBasicoSunatConyuge.Copy());
                dsContenedorConsolidada.Tables.Add(dtBSunatDireccionTitular.Copy());
                dsContenedorConsolidada.Tables.Add(dtBSunatDireccionConyuge.Copy());
                dsContenedorConsolidada.Tables.Add(dtRlegalTitular.Copy());
                dsContenedorConsolidada.Tables.Add(dtRlegalConyuge.Copy());
                dsContenedorConsolidada.Tables.Add(dtClasTitularConyuge.Copy());

                DataTable dtCombinedDeudaSentinel = new DataTable("dtDeudaSentinelDirectaTitular");
                if (dtDeudaSentinelDirectaTitular != null)
                {
                    dtCombinedDeudaSentinel = dtDeudaSentinelDirectaTitular.Copy();
                }

                if (dtDeudaSentinelDirectaConyuge != null)
                {
                    dtCombinedDeudaSentinel.Merge(dtDeudaSentinelDirectaConyuge);
                }

                dsContenedorConsolidada.Tables.Add(dtCombinedDeudaSentinel.Copy());

                DataTable dtCombinedLineaCreditoSentinel = new DataTable("dtlCredNoUtilizadaT");
                if (dtlCredNoUtilizadaT != null)
                {
                    dtCombinedLineaCreditoSentinel = dtlCredNoUtilizadaT.Copy();
                }
                if (dtlCredNoUtilizadaC != null)
                {
                    dtCombinedLineaCreditoSentinel.Merge(dtlCredNoUtilizadaC);
                }

                dsContenedorConsolidada.Tables.Add(dtCombinedLineaCreditoSentinel.Copy());

                DataTable dtCombinedVencidoSentinel = new DataTable("dtDeudaTitular");
                if (dtDeudaTitular != null)
                {
                    dtCombinedVencidoSentinel = dtDeudaTitular.Copy();
                }
                if (dtDeudaConyuge != null)
                {
                    dtCombinedVencidoSentinel.Merge(dtDeudaConyuge);
                }
                dsContenedorConsolidada.Tables.Add(dtCombinedVencidoSentinel.Copy());

                DataTable dtCombinedAvalistaSentinel = new DataTable("dtAvalistaTitular");
                if (dtAvalistaTitular != null)
                {
                    dtCombinedAvalistaSentinel = dtAvalistaTitular.Copy();
                }
                if (dtAvalistaConyuge != null)
                {
                    dtCombinedAvalistaSentinel.Merge(dtAvalistaConyuge);
                }
                dsContenedorConsolidada.Tables.Add(dtCombinedAvalistaSentinel.Copy());

                DataTable dtCombinedAvaladoSentinel = new DataTable("dtAvalado");
                if (dtAvalado != null)
                {
                    dtCombinedAvaladoSentinel = dtAvalado.Copy();
                }
                if (dtAvaladoConyuge != null)
                {
                    dtCombinedAvaladoSentinel.Merge(dtAvaladoConyuge);
                }
                dsContenedorConsolidada.Tables.Add(dtCombinedAvaladoSentinel.Copy());

                HistoricoSentinel_Titular();
                HistoricoSentinel_Conyuge();

                dsContenedorConsolidada.Tables.Add(dtHistorialSentinelTitular.Copy());
                dsContenedorConsolidada.Tables.Add(dtHistorialSentinelConyuge.Copy());

                if (objRespuestaTitular.Data != null)
                {
                    foreach (DataSenConBasSBSMicr objDeuda in objRespuestaTitular.Data[0].ConRap.DetSBSMicr)
                    {
                        DateTime dtFechaProc = new DateTime(objDeuda.ano, objDeuda.mes, 1);
                        rowMicrTitular = dtMicrTitular.NewRow();
                        rowMicrTitular["Condicion"] = "Titular";
                        rowMicrTitular["NomEnt"] = "DEUDA TOTAL";
                        rowMicrTitular["Cal"] = "SCAL";
                        rowMicrTitular["SalDeu"] = objDeuda.Detalle.Sum(x => Convert.ToDecimal(x.SalDeu));
                        rowMicrTitular["DiaVen"] = (objDeuda.Detalle.Count > 0) ? objDeuda.Detalle.Max(x => Convert.ToInt32(x.DiaVen)) : 0;
                        rowMicrTitular["FchPro"] = fechaformateada(objDeuda.ano + "-" + objDeuda.mes);
                        rowMicrTitular["FchRep"] = objDeuda.Detalle.Max(x => Convert.ToString(x.FchRep)); ;
                        rowMicrTitular["FchProNumero"] = dtFechaProc.ToString("yyyy-MM");
                        rowMicrTitular["DeudaTotal"] = objDeuda.Detalle.Sum(x => Convert.ToDecimal(x.SalDeu));
                        dtMicrTitular.Rows.Add(rowMicrTitular);
                    }
                }

                if (objRespuestaConyuge != null)
                {
                    foreach (DataSenConBasSBSMicr objDeuda in objRespuestaConyuge.Data[0].ConRap.DetSBSMicr)
                    {
                        DateTime dtFechaProc = new DateTime(objDeuda.ano, objDeuda.mes, 1);
                        rowMicrConyuge = dtMicrConyuge.NewRow();
                        rowMicrConyuge["Condicion"] = "Conyuge";
                        rowMicrConyuge["NomEnt"] = "DEUDA TOTAL";
                        rowMicrConyuge["Cal"] = "SCAL";
                        rowMicrConyuge["SalDeu"] = objDeuda.Detalle.Sum(x => Convert.ToDecimal(x.SalDeu));
                        rowMicrConyuge["DiaVen"] = (objDeuda.Detalle.Count > 0) ? objDeuda.Detalle.Max(x => Convert.ToInt32(x.DiaVen)) : 0;
                        rowMicrConyuge["FchPro"] = fechaformateada(objDeuda.ano + "-" + objDeuda.mes);
                        rowMicrConyuge["FchRep"] = objDeuda.Detalle.Max(x => Convert.ToString(x.FchRep)); ;
                        rowMicrConyuge["FchProNumero"] = dtFechaProc.ToString("yyyy-MM");
                        rowMicrConyuge["DeudaTotal"] = objDeuda.Detalle.Sum(x => Convert.ToDecimal(x.SalDeu));
                        dtMicrConyuge.Rows.Add(rowMicrConyuge);
                    }
                }

                dsContenedorConsolidada.Tables.Add(dtMicrTitular.Copy());
                dsContenedorConsolidada.Tables.Add(dtMicrConyuge.Copy());
            }

        }

        public void DatosBasicoSunat(DataSenInfBasica dataBasicoSunat, string CondicionTitularConyuge)
        {
            List<DataSenInfBasica> ListaSunatInfoSentinelTitular = new List<DataSenInfBasica>();
            if (dataBasicoSunat != null)
            {
                if (Convert.ToInt32(cidTipoDocumento) == 1) //PERSONA NATURAL
                {
                    switch (CondicionTitularConyuge)
                    {
                        case "Titular":
                            dtBasicoSunatTitular.Clear();
                            DataRow rowBasicoSunatTitular = dtBasicoSunatTitular.NewRow();

                            rowBasicoSunatTitular["TDoc"] = dataBasicoSunat.TDoc;
                            rowBasicoSunatTitular["NDoc"] = dataBasicoSunat.NDoc;
                            rowBasicoSunatTitular["RelTDOC"] = dataBasicoSunat.RelTDoc;
                            rowBasicoSunatTitular["RelNDoc"] = dataBasicoSunat.RelNDoc;
                            rowBasicoSunatTitular["RazSoc"] = dataBasicoSunat.RazSoc;
                            rowBasicoSunatTitular["NomCom"] = dataBasicoSunat.NomCom;
                            rowBasicoSunatTitular["TipCon"] = dataBasicoSunat.TipCon;
                            rowBasicoSunatTitular["IniAct"] = dataBasicoSunat.IniAct;
                            rowBasicoSunatTitular["ActEco"] = dataBasicoSunat.ActEco;
                            rowBasicoSunatTitular["FchInsRRPP"] = dataBasicoSunat.FchInsRRPP;
                            rowBasicoSunatTitular["AgeRet"] = dataBasicoSunat.AgeRet;
                            rowBasicoSunatTitular["ApePat"] = dataBasicoSunat.ApePat;
                            rowBasicoSunatTitular["ApeMat"] = dataBasicoSunat.ApeMat;
                            rowBasicoSunatTitular["Nom"] = dataBasicoSunat.Nom;
                            rowBasicoSunatTitular["Sex"] = dataBasicoSunat.Sex;
                            rowBasicoSunatTitular["EstCon"] = dataBasicoSunat.EstCon;
                            rowBasicoSunatTitular["EstDom"] = dataBasicoSunat.EstCon;
                            rowBasicoSunatTitular["EstDomic"] = dataBasicoSunat.EstCon;
                            rowBasicoSunatTitular["CondDomic"] = dataBasicoSunat.EstCon;
                            dtBasicoSunatTitular.Rows.Add(rowBasicoSunatTitular);
                            break;
                        case "Conyuge":
                            dtBasicoSunatConyuge.Clear();
                            DataRow rowBasicoSunatConyuge = dtBasicoSunatConyuge.NewRow();

                            rowBasicoSunatConyuge["TDoc"] = dataBasicoSunat.TDoc;
                            rowBasicoSunatConyuge["NDoc"] = dataBasicoSunat.NDoc;
                            rowBasicoSunatConyuge["RelTDOC"] = dataBasicoSunat.RelTDoc;
                            rowBasicoSunatConyuge["RelNDoc"] = dataBasicoSunat.RelNDoc;
                            rowBasicoSunatConyuge["RazSoc"] = dataBasicoSunat.RazSoc;
                            rowBasicoSunatConyuge["NomCom"] = dataBasicoSunat.NomCom;
                            rowBasicoSunatConyuge["TipCon"] = dataBasicoSunat.TipCon;
                            rowBasicoSunatConyuge["IniAct"] = dataBasicoSunat.IniAct;
                            rowBasicoSunatConyuge["ActEco"] = dataBasicoSunat.ActEco;
                            rowBasicoSunatConyuge["FchInsRRPP"] = dataBasicoSunat.FchInsRRPP;
                            rowBasicoSunatConyuge["AgeRet"] = dataBasicoSunat.AgeRet;
                            rowBasicoSunatConyuge["ApePat"] = dataBasicoSunat.ApePat;
                            rowBasicoSunatConyuge["ApeMat"] = dataBasicoSunat.ApeMat;
                            rowBasicoSunatConyuge["Nom"] = dataBasicoSunat.Nom;
                            rowBasicoSunatConyuge["Sex"] = dataBasicoSunat.Sex;
                            rowBasicoSunatConyuge["EstCon"] = dataBasicoSunat.EstCon;
                            rowBasicoSunatConyuge["EstDom"] = dataBasicoSunat.EstCon;
                            rowBasicoSunatConyuge["EstDomic"] = dataBasicoSunat.EstCon;
                            rowBasicoSunatConyuge["CondDomic"] = dataBasicoSunat.EstCon;
                            dtBasicoSunatConyuge.Rows.Add(rowBasicoSunatConyuge);
                            break;

                    }
                }
                if (Convert.ToInt32(cidTipoDocumento) == 4)//PERSONA JURIDICA
                {
                    dtBasicoSunatTitular.Clear();
                    DataRow rowBasicoSunatTitular = dtBasicoSunatTitular.NewRow();

                    rowBasicoSunatTitular["TDoc"] = dataBasicoSunat.TDoc;
                    rowBasicoSunatTitular["NDoc"] = dataBasicoSunat.NDoc;
                    rowBasicoSunatTitular["RelTDOC"] = dataBasicoSunat.RelTDoc;
                    rowBasicoSunatTitular["RelNDoc"] = dataBasicoSunat.RelNDoc;
                    rowBasicoSunatTitular["RazSoc"] = dataBasicoSunat.RazSoc;
                    rowBasicoSunatTitular["NomCom"] = dataBasicoSunat.NomCom;
                    rowBasicoSunatTitular["TipCon"] = dataBasicoSunat.TipCon;
                    rowBasicoSunatTitular["IniAct"] = dataBasicoSunat.IniAct;
                    rowBasicoSunatTitular["ActEco"] = dataBasicoSunat.ActEco;
                    rowBasicoSunatTitular["FchInsRRPP"] = dataBasicoSunat.FchInsRRPP;
                    rowBasicoSunatTitular["AgeRet"] = dataBasicoSunat.AgeRet;
                    rowBasicoSunatTitular["ApePat"] = dataBasicoSunat.ApePat;
                    rowBasicoSunatTitular["ApeMat"] = dataBasicoSunat.ApeMat;
                    rowBasicoSunatTitular["Nom"] = dataBasicoSunat.Nom;
                    rowBasicoSunatTitular["Sex"] = dataBasicoSunat.Sex;
                    rowBasicoSunatTitular["EstCon"] = dataBasicoSunat.EstCon;
                    rowBasicoSunatTitular["EstDom"] = dataBasicoSunat.EstCon;
                    rowBasicoSunatTitular["EstDomic"] = dataBasicoSunat.EstCon;
                    rowBasicoSunatTitular["CondDomic"] = dataBasicoSunat.EstCon;
                    dtBasicoSunatTitular.Rows.Add(rowBasicoSunatTitular);

                }

            }
        }
        public void DatosBasicoSunatDireccion(List<DataSenInfGenDirecc> dataBasicaDireccion, string CondicionTitularConyuge)
        {
            if (dataBasicaDireccion.Count > 0)
            {
                if (Convert.ToInt32(cidTipoDocumento) == 1) //PERSONA NATURAL
                {
                    switch (CondicionTitularConyuge)
                    {
                        case "Titular":
                            dtBSunatDireccionTitular.Clear();
                            for (int iDireccSunatT = 0; iDireccSunatT < dataBasicaDireccion.Count; iDireccSunatT++)
                            {
                                DataRow rowBSunatDireccionTitular = dtBSunatDireccionTitular.NewRow();
                                rowBSunatDireccionTitular["Direccion"] = dataBasicaDireccion[iDireccSunatT].Direccion;
                                rowBSunatDireccionTitular["Fuente"] = dataBasicaDireccion[iDireccSunatT].Fuente;
                                dtBSunatDireccionTitular.Rows.Add(rowBSunatDireccionTitular);
                            }


                            break;
                        case "Conyuge":
                            dtBSunatDireccionConyuge.Clear();
                            for (int iDireccSunatC = 0; iDireccSunatC < dataBasicaDireccion.Count; iDireccSunatC++)
                            {
                                DataRow rowBSunatDireccionConyuge = dtBSunatDireccionConyuge.NewRow();
                                rowBSunatDireccionConyuge["Direccion"] = dataBasicaDireccion[iDireccSunatC].Direccion;
                                rowBSunatDireccionConyuge["Fuente"] = dataBasicaDireccion[iDireccSunatC].Fuente;
                                dtBSunatDireccionConyuge.Rows.Add(rowBSunatDireccionConyuge);
                            }

                            break;
                    }
                }
                if (Convert.ToInt32(cidTipoDocumento) == 4)//PERSONA JURIDICA
                {
                    dtBSunatDireccionTitular.Clear();
                    for (int iDireccSunatT = 0; iDireccSunatT < dataBasicaDireccion.Count; iDireccSunatT++)
                    {
                        DataRow rowBSunatDireccionTitular = dtBSunatDireccionTitular.NewRow();
                        rowBSunatDireccionTitular["Direccion"] = dataBasicaDireccion[iDireccSunatT].Direccion;
                        rowBSunatDireccionTitular["Fuente"] = dataBasicaDireccion[iDireccSunatT].Fuente;
                        dtBSunatDireccionTitular.Rows.Add(rowBSunatDireccionTitular);
                    }

                }


            }
        }
        public void DatosBasicoSunatRLegal(List<DataSenInfGenEsRepLeg> EsRepLegDe, List<DataSenInfGenRepLeg> ListRepLeg, string CondicionTitularConyuge)
        {
            if (EsRepLegDe.Count > 0)
            {
                if (Convert.ToInt32(cidTipoDocumento) == 1) //PERSONA NATURAL
                {
                    switch (CondicionTitularConyuge)
                    {
                        case "Titular":
                            dtRlegalTitular.Clear();
                            for (int iRlegalTitular = 0; iRlegalTitular < EsRepLegDe.Count; iRlegalTitular++)
                            {
                                DataRow rowRlegalTitular = dtRlegalTitular.NewRow();

                                rowRlegalTitular["TDOC"] = EsRepLegDe[iRlegalTitular].TDOC;
                                rowRlegalTitular["NDOC"] = EsRepLegDe[iRlegalTitular].NDOC.ToString();
                                rowRlegalTitular["Nombre"] = EsRepLegDe[iRlegalTitular].RazSoc.ToString();
                                rowRlegalTitular["FecIniCar"] = EsRepLegDe[iRlegalTitular].FecIniCar.ToString();
                                rowRlegalTitular["Cargo"] = EsRepLegDe[iRlegalTitular].Cargo.ToString();
                                dtRlegalTitular.Rows.Add(rowRlegalTitular);
                            }

                            break;
                        case "Conyuge":
                            dtRlegalConyuge.Clear();
                            for (int iRlegalConyuge = 0; iRlegalConyuge < EsRepLegDe.Count; iRlegalConyuge++)
                            {
                                DataRow rowRlegalConyuge = dtRlegalConyuge.NewRow();

                                rowRlegalConyuge["TDOC"] = EsRepLegDe[iRlegalConyuge].TDOC;
                                rowRlegalConyuge["NDOC"] = EsRepLegDe[iRlegalConyuge].NDOC.ToString();
                                rowRlegalConyuge["Nombre"] = EsRepLegDe[iRlegalConyuge].RazSoc.ToString();
                                rowRlegalConyuge["FecIniCar"] = EsRepLegDe[iRlegalConyuge].FecIniCar.ToString();
                                rowRlegalConyuge["Cargo"] = EsRepLegDe[iRlegalConyuge].Cargo.ToString();
                                dtRlegalConyuge.Rows.Add(rowRlegalConyuge);
                            }
                            break;
                    }
                }
            }
            if (ListRepLeg.Count > 0)
            {
                if (Convert.ToInt32(cidTipoDocumento) == 4)//PERSONA JURIDICA
                {
                    dtRlegalTitular.Clear();
                    for (int iRlegalTitular = 0; iRlegalTitular < ListRepLeg.Count; iRlegalTitular++)
                    {
                        DataRow rowRlegalTitular = dtRlegalTitular.NewRow();

                        rowRlegalTitular["TDOC"] = ListRepLeg[iRlegalTitular].TDOC;
                        rowRlegalTitular["NDOC"] = ListRepLeg[iRlegalTitular].NDOC.ToString();
                        rowRlegalTitular["Nombre"] = ListRepLeg[iRlegalTitular].Nombre.ToString();
                        rowRlegalTitular["FecIniCar"] = ListRepLeg[iRlegalTitular].FecIniCar.ToString();
                        rowRlegalTitular["Cargo"] = ListRepLeg[iRlegalTitular].Cargo.ToString();
                        dtRlegalTitular.Rows.Add(rowRlegalTitular);
                    }


                }
            }


        }
        public void DatosBasicoLineaCredito(List<DataSenConBasUtiLinCre> UtiLinCre, string CondicionTitularConyuge)
        {
            if (UtiLinCre.Count > 0)
            {

                switch (CondicionTitularConyuge)
                {
                    case "Titular":
                        dtlCredNoUtilizadaT.Clear();
                        for (int iLCredNoUtili = 0; iLCredNoUtili < UtiLinCre.Count; iLCredNoUtili++)
                        {
                            DataRow rowlCredNoUtilizadaT = dtlCredNoUtilizadaT.NewRow();
                            rowlCredNoUtilizadaT["Condicion"] = "Titular";
                            rowlCredNoUtilizadaT["Inst"] = UtiLinCre[iLCredNoUtili].Inst;
                            rowlCredNoUtilizadaT["LinApr"] = UtiLinCre[iLCredNoUtili].LinApr.ToString();
                            rowlCredNoUtilizadaT["LinNoUti"] = UtiLinCre[iLCredNoUtili].LinNoUti.ToString();
                            rowlCredNoUtilizadaT["LinUti"] = UtiLinCre[iLCredNoUtili].LinUti.ToString();
                            rowlCredNoUtilizadaT["TipCred"] = UtiLinCre[iLCredNoUtili].TipCred.ToString();
                            dtlCredNoUtilizadaT.Rows.Add(rowlCredNoUtilizadaT);
                        }

                        break;
                    case "Conyuge":
                        dtlCredNoUtilizadaC.Clear();
                        for (int iLCredNoUtiliConyuge = 0; iLCredNoUtiliConyuge < UtiLinCre.Count; iLCredNoUtiliConyuge++)
                        {
                            DataRow rowlCredNoUtilizadaC = dtlCredNoUtilizadaC.NewRow();
                            rowlCredNoUtilizadaC["Condicion"] = "Cónyuge";
                            rowlCredNoUtilizadaC["Inst"] = UtiLinCre[iLCredNoUtiliConyuge].Inst;
                            rowlCredNoUtilizadaC["LinApr"] = UtiLinCre[iLCredNoUtiliConyuge].LinApr.ToString();
                            rowlCredNoUtilizadaC["LinNoUti"] = UtiLinCre[iLCredNoUtiliConyuge].LinNoUti.ToString();
                            rowlCredNoUtilizadaC["LinUti"] = UtiLinCre[iLCredNoUtiliConyuge].LinUti.ToString();
                            rowlCredNoUtilizadaC["TipCred"] = UtiLinCre[iLCredNoUtiliConyuge].TipCred.ToString();
                            dtlCredNoUtilizadaC.Rows.Add(rowlCredNoUtilizadaC);
                        }

                        break;
                }
            }

        }
        public void DatosDeudaProtesto(List<DataSenConBasVen> ListProtestoDeuLaboralSentinel, string CondicionTitularConyuge)
        {
            if (ListProtestoDeuLaboralSentinel != null)
            {
                if (ListProtestoDeuLaboralSentinel.Count > 0)
                {
                    switch (CondicionTitularConyuge)
                    {
                        case "Titular":
                            dtDeudaTitular.Clear();

                            for (int iDeudaTitular = 0; iDeudaTitular < ListProtestoDeuLaboralSentinel.Count; iDeudaTitular++)
                            {
                                for (int iVenciDeudaTitular = 0; iVenciDeudaTitular < ListProtestoDeuLaboralSentinel[iDeudaTitular].DetalleVencidos.Count; iVenciDeudaTitular++)
                                {
                                    DataRow rowDeudaTitular = dtDeudaTitular.NewRow();
                                    rowDeudaTitular["Condicion"] = "Titular";
                                    rowDeudaTitular["idFue"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].IdFue;
                                    rowDeudaTitular["MaxDiaVen"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].MaxDiaVen.ToString();
                                    rowDeudaTitular["NomFue"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].NomFue.ToString();
                                    rowDeudaTitular["VenTot"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].VenTot.ToString();
                                    rowDeudaTitular["NomEnt"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].DetalleVencidos[iVenciDeudaTitular].NomEnt.ToString();
                                    rowDeudaTitular["MontDeu"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].DetalleVencidos[iVenciDeudaTitular].MontDeu.ToString();
                                    rowDeudaTitular["DiaVen"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].DetalleVencidos[iVenciDeudaTitular].DiaVen.ToString();
                                    rowDeudaTitular["NumDoc"] = ListProtestoDeuLaboralSentinel[iDeudaTitular].DetalleVencidos[iVenciDeudaTitular].NumDoc.ToString();

                                    dtDeudaTitular.Rows.Add(rowDeudaTitular);
                                }
                            }

                            break;
                        case "Conyuge":
                            dtDeudaConyuge.Clear();

                            for (int iDeudaConyuge = 0; iDeudaConyuge < ListProtestoDeuLaboralSentinel.Count; iDeudaConyuge++)
                            {
                                for (int iVenciDeudaConyuge = 0; iVenciDeudaConyuge < ListProtestoDeuLaboralSentinel[iDeudaConyuge].DetalleVencidos.Count; iVenciDeudaConyuge++)
                                {
                                    DataRow rowDeudaConyuge = dtDeudaConyuge.NewRow();
                                    rowDeudaConyuge["Condicion"] = "Cónyuge";
                                    rowDeudaConyuge["idFue"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].IdFue;
                                    rowDeudaConyuge["MaxDiaVen"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].MaxDiaVen.ToString();
                                    rowDeudaConyuge["NomFue"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].NomFue.ToString();
                                    rowDeudaConyuge["VenTot"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].VenTot.ToString();

                                    rowDeudaConyuge["NomEnt"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].DetalleVencidos[iVenciDeudaConyuge].NomEnt.ToString();
                                    rowDeudaConyuge["MontDeu"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].DetalleVencidos[iVenciDeudaConyuge].MontDeu.ToString();
                                    rowDeudaConyuge["DiaVen"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].DetalleVencidos[iVenciDeudaConyuge].DiaVen.ToString();
                                    rowDeudaConyuge["NumDoc"] = ListProtestoDeuLaboralSentinel[iDeudaConyuge].DetalleVencidos[iVenciDeudaConyuge].NumDoc.ToString();
                                    dtDeudaConyuge.Rows.Add(rowDeudaConyuge);

                                }

                            }


                            break;
                    }
                }
            }
        }
        public void DatosAvalista(List<DataSenAvalDe> LisAvalista, string CondicionTitularConyuge)
        {
            if (LisAvalista != null)
            {
                if (LisAvalista.Count > 0)
                {
                    switch (CondicionTitularConyuge)
                    {

                        case "Titular":
                            dtAvalistaTitular.Clear();

                            for (int iAvalista = 0; iAvalista < LisAvalista.Count; iAvalista++)
                            {
                                for (int iAcredorAvalista = 0; iAcredorAvalista < LisAvalista[iAvalista].Acreedor.Count; iAcredorAvalista++)
                                {
                                    DataRow rowAvalistaTitular = dtAvalistaTitular.NewRow();
                                    rowAvalistaTitular["Condicion"] = "Titular";
                                    rowAvalistaTitular["NDoc"] = LisAvalista[iAvalista].NDoc.ToString();
                                    rowAvalistaTitular["RazSoc"] = LisAvalista[iAvalista].RazSoc.ToString();
                                    rowAvalistaTitular["Sem12Mes"] = LisAvalista[iAvalista].Sem12Mes.ToString();
                                    rowAvalistaTitular["SemAct"] = LisAvalista[iAvalista].SemAct.ToString();
                                    rowAvalistaTitular["SemPre"] = LisAvalista[iAvalista].SemPre.ToString();
                                    rowAvalistaTitular["NDocAcre"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].NDoc.ToString();
                                    rowAvalistaTitular["RazSocAcre"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].RazSoc.ToString();
                                    rowAvalistaTitular["Cal"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].Cal.ToString();
                                    rowAvalistaTitular["SalDeu"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].SalDeu.ToString();
                                    rowAvalistaTitular["TipEnt"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].TipEnt.ToString();
                                    rowAvalistaTitular["FecRep"] = LisAvalista[iAvalista].Acreedor[iAcredorAvalista].FecRep.ToString();

                                    dtAvalistaTitular.Rows.Add(rowAvalistaTitular);

                                }
                            }


                            break;
                        case "Conyuge":
                            dtAvalistaConyuge.Clear();

                            for (int iAvalistaConyuge = 0; iAvalistaConyuge < LisAvalista.Count; iAvalistaConyuge++)
                            {
                                for (int iAcredorAvalistaConyuge = 0; iAcredorAvalistaConyuge < LisAvalista[iAvalistaConyuge].Acreedor.Count; iAcredorAvalistaConyuge++)
                                {
                                    DataRow rowAvalistaConyuge = dtAvalistaConyuge.NewRow();
                                    rowAvalistaConyuge["Condicion"] = "Cónyuge";
                                    rowAvalistaConyuge["NDoc"] = LisAvalista[iAvalistaConyuge].NDoc.ToString();
                                    rowAvalistaConyuge["RazSoc"] = LisAvalista[iAvalistaConyuge].RazSoc.ToString();
                                    rowAvalistaConyuge["Sem12Mes"] = LisAvalista[iAvalistaConyuge].Sem12Mes.ToString();
                                    rowAvalistaConyuge["SemAct"] = LisAvalista[iAvalistaConyuge].SemAct.ToString();
                                    rowAvalistaConyuge["SemPre"] = LisAvalista[iAvalistaConyuge].SemPre.ToString();

                                    rowAvalistaConyuge["NDocAcre"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].NDoc.ToString();
                                    rowAvalistaConyuge["RazSocAcre"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].RazSoc.ToString();
                                    rowAvalistaConyuge["Cal"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].Cal.ToString();
                                    rowAvalistaConyuge["SalDeu"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].SalDeu.ToString();
                                    rowAvalistaConyuge["TipEnt"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].TipEnt.ToString();
                                    rowAvalistaConyuge["FecRep"] = LisAvalista[iAvalistaConyuge].Acreedor[iAcredorAvalistaConyuge].FecRep.ToString();
                                    dtAvalistaConyuge.Rows.Add(rowAvalistaConyuge);

                                }

                            }

                            break;
                    }
                }
            }
        }
        public void DatosAvalado(List<DataSenAvalPor> Listavalado, string CondicionTitularConyuge)
        {
            if (Listavalado != null)
            {
                if (Listavalado.Count > 0)
                {
                    switch (CondicionTitularConyuge)
                    {
                        case "Titular":

                            dtAvalado.Clear();

                            for (int iAvalado = 0; iAvalado < Listavalado.Count; iAvalado++)
                            {
                                for (int iAcreedorTitular = 0; iAcreedorTitular < Listavalado[iAvalado].Acreedor.Count; iAcreedorTitular++)
                                {
                                    rowAvaladoTitular = dtAvalado.NewRow();
                                    rowAvaladoTitular["Condicion"] = "Titular";
                                    rowAvaladoTitular["ndoc"] = Listavalado[iAvalado].NDoc.ToString();
                                    rowAvaladoTitular["tDoc"] = Listavalado[iAvalado].TDoc.ToString();
                                    rowAvaladoTitular["razSoc"] = Listavalado[iAvalado].RazSoc.ToString();
                                    rowAvaladoTitular["semAct"] = Listavalado[iAvalado].SemAct.ToString();
                                    rowAvaladoTitular["Sem12Mes"] = Listavalado[iAvalado].Sem12Mes.ToString();
                                    rowAvaladoTitular["tDocAcre"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].TDoc.ToString();
                                    rowAvaladoTitular["nDocAcre"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].NDoc.ToString();
                                    rowAvaladoTitular["razSocAcre"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].RazSoc.ToString();
                                    rowAvaladoTitular["cal"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].Cal.ToString();
                                    rowAvaladoTitular["tipEnt"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].TipEnt.ToString();
                                    rowAvaladoTitular["salDeu"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].SalDeu.ToString();
                                    rowAvaladoTitular["fecRep"] = Listavalado[iAvalado].Acreedor[iAcreedorTitular].FecRep.ToString();

                                    dtAvalado.Rows.Add(rowAvaladoTitular);
                                }

                            }

                            break;
                        case "Conyuge":

                            dtAvaladoConyuge.Clear();

                            for (int iAvaladoConyuge = 0; iAvaladoConyuge < Listavalado.Count; iAvaladoConyuge++)
                            {

                                for (int iAcreedorConyuge = 0; iAcreedorConyuge < Listavalado[iAvaladoConyuge].Acreedor.Count; iAcreedorConyuge++)
                                {
                                    rowAvaladoConyuge = dtAvaladoConyuge.NewRow();
                                    rowAvaladoConyuge["Condicion"] = "Cónyuge";
                                    rowAvaladoConyuge["ndoc"] = Listavalado[iAvaladoConyuge].NDoc.ToString();
                                    rowAvaladoConyuge["tDoc"] = Listavalado[iAvaladoConyuge].TDoc.ToString();
                                    rowAvaladoConyuge["razSoc"] = Listavalado[iAvaladoConyuge].RazSoc.ToString();
                                    rowAvaladoConyuge["semAct"] = Listavalado[iAvaladoConyuge].SemAct.ToString();
                                    rowAvaladoConyuge["Sem12Mes"] = Listavalado[iAvaladoConyuge].Sem12Mes.ToString();

                                    rowAvaladoConyuge["tDocAcre"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].TDoc.ToString();
                                    rowAvaladoConyuge["nDocAcre"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].NDoc.ToString();
                                    rowAvaladoConyuge["razSocAcre"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].RazSoc.ToString();
                                    rowAvaladoConyuge["cal"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].Cal.ToString();
                                    rowAvaladoConyuge["tipEnt"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].TipEnt.ToString();
                                    rowAvaladoConyuge["salDeu"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].SalDeu.ToString();
                                    rowAvaladoConyuge["fecRep"] = Listavalado[iAvaladoConyuge].Acreedor[iAcreedorConyuge].FecRep.ToString();
                                    dtAvaladoConyuge.Rows.Add(rowAvaladoConyuge);


                                }

                            }

                            break;
                    }
                }
            }
        }
        public void DatosDeudaDirecta(List<DataSenConBasSBSMicr> DetSBSMicr, string CondicionTitularConyuge)
        {
            if (objRespuesta.Data[0].ConRap.DetSBSMicr.Count > 0)
            {
                DetSBSMicr = objRespuesta.Data[0].ConRap.DetSBSMicr;
                switch (CondicionTitularConyuge)
                {
                    case "Titular":
                        dtMicrTitular.Clear();
                        dtDeudaSentinelDirectaTitular = new DataTable("dtDeudaSentinelDirectaTitular");
                        for (int iSBSMicro = 0; iSBSMicro < DetSBSMicr.Count; iSBSMicro++)
                        {
                            DateTime dtFechaProc = new DateTime(objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].ano, objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].mes, 1);
                            for (int iDetalle = 0; iDetalle < DetSBSMicr[iSBSMicro].Detalle.Count; iDetalle++)
                            {
                                rowMicrTitular = dtMicrTitular.NewRow();

                                rowMicrTitular["Condicion"] = "Titular";
                                rowMicrTitular["NomEnt"] = DetSBSMicr[iSBSMicro].Detalle[iDetalle].NomEnt;
                                rowMicrTitular["Cal"] = DetSBSMicr[iSBSMicro].Detalle[iDetalle].Cal;
                                rowMicrTitular["SalDeu"] = DetSBSMicr[iSBSMicro].Detalle[iDetalle].SalDeu;
                                rowMicrTitular["DiaVen"] = DetSBSMicr[iSBSMicro].Detalle[iDetalle].DiaVen;
                                rowMicrTitular["FchPro"] = fechaformateada(DetSBSMicr[iSBSMicro].Detalle[iDetalle].FchPro);
                                rowMicrTitular["FchRep"] = DetSBSMicr[iSBSMicro].Detalle[iDetalle].FchRep;
                                rowMicrTitular["FchProNumero"] = dtFechaProc.ToString("yyyy-MM");
                                rowMicrTitular["DeudaTotal"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle.Sum(x => Convert.ToDecimal(x.SalDeu)); 
 
                                dtMicrTitular.Rows.Add(rowMicrTitular);
                            }
                            if (DetSBSMicr[iSBSMicro].Detalle.Count == 0)
                            {
                                rowMicrTitular = dtMicrTitular.NewRow();
                                rowMicrTitular["Condicion"] = "Titular";
                                rowMicrTitular["NomEnt"] = "";
                                rowMicrTitular["Cal"] = "SCAL";
                                rowMicrTitular["SalDeu"] = 0;
                                rowMicrTitular["DiaVen"] = 0;
                                rowMicrTitular["FchPro"] = fechaformateada(objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].ano + "-" + objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].mes);
                                rowMicrTitular["FchRep"] = "";
                                rowMicrTitular["FchProNumero"] = dtFechaProc.ToString("yyyy-MM");
                                rowMicrTitular["DeudaTotal"] = 0; 

                                dtMicrTitular.Rows.Add(rowMicrTitular);
                            }

                        }
                        cSemaforoTitular = objRespuesta.Data[0].ConRap.Resumen_ConRap.Semaforos;
                        var dtExisteDataMesAnioSBSMicr = dtMicrTitular.AsEnumerable().Where(r => r.Field<string>("FchPro") == Convert.ToString(fechaformateada(clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd")))).Any();

                        if (dtExisteDataMesAnioSBSMicr)
                        {
                            dtDeudaSentinelDirectaTitular = dtMicrTitular.AsEnumerable().Where(r => r.Field<string>("FchPro") == Convert.ToString(fechaformateada(clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd")))).CopyToDataTable();
                            dtDeudaSentinelDirectaTitular.TableName = "dtDeudaSentinelDirectaTitular";
                        }

                        break;
                    case "Conyuge":
                        dtMicrConyuge.Clear();
                        dtDeudaSentinelDirectaConyuge = new DataTable("dtDeudaSentinelDirectaConyuge");
                        for (int iSBSMicro = 0; iSBSMicro < objRespuesta.Data[0].ConRap.DetSBSMicr.Count; iSBSMicro++)
                        {
                            DateTime dtFechaProc = new DateTime(objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].ano, objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].mes, 1);
                            for (int iDetalle = 0; iDetalle < objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle.Count; iDetalle++)
                            {
                                rowMicrConyuge = dtMicrConyuge.NewRow();
                                rowMicrConyuge["Condicion"] = "Cónyuge";
                                rowMicrConyuge["NomEnt"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].NomEnt;
                                rowMicrConyuge["Cal"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].Cal;
                                rowMicrConyuge["SalDeu"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].SalDeu;
                                rowMicrConyuge["DiaVen"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].DiaVen;
                                rowMicrConyuge["FchPro"] = fechaformateada(objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].FchPro);
                                rowMicrConyuge["FchRep"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle[iDetalle].FchRep;
                                rowMicrConyuge["FchProNumero"] = dtFechaProc.ToString("yyyy-MM");
                                rowMicrConyuge["DeudaTotal"] = objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle.Sum(x => Convert.ToDecimal(x.SalDeu)); 

                                dtMicrConyuge.Rows.Add(rowMicrConyuge);
                            }

                            if (objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].Detalle.Count == 0)
                            {
                                rowMicrConyuge = dtMicrConyuge.NewRow();
                                rowMicrConyuge["Condicion"] = "Cónyuge";
                                rowMicrConyuge["NomEnt"] = "";
                                rowMicrConyuge["Cal"] = "SCAL";
                                rowMicrConyuge["SalDeu"] = 0;
                                rowMicrConyuge["DiaVen"] = 0;
                                rowMicrConyuge["FchPro"] = fechaformateada(objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].ano + "-" + objRespuesta.Data[0].ConRap.DetSBSMicr[iSBSMicro].mes);
                                rowMicrConyuge["FchRep"] = "";
                                rowMicrConyuge["FchProNumero"] = dtFechaProc.ToString("yyyy-MM");
                                rowMicrConyuge["DeudaTotal"] = 0; 

                                dtMicrConyuge.Rows.Add(rowMicrConyuge);
                            }

                        }
                        cSemaforoConyuge = objRespuesta.Data[0].ConRap.Resumen_ConRap.Semaforos;
                        var dtExisteDataMesAnioSBSMicrConyuge = dtMicrConyuge.AsEnumerable().Where(r => r.Field<string>("FchPro") == Convert.ToString(fechaformateada(clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd")))).Any();
                        if (dtExisteDataMesAnioSBSMicrConyuge)
                        {
                            dtDeudaSentinelDirectaConyuge = dtMicrConyuge.AsEnumerable().Where(r => r.Field<string>("FchPro") == Convert.ToString(fechaformateada(clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd")))).CopyToDataTable();
                            dtDeudaSentinelDirectaConyuge.TableName = "dtDeudaSentinelDirectaConyuge";
            
                        }

                        break;
                }
            }
        }
        public void HistoricoSentinel_Titular()
        {
            if (dtMicrTitular.Rows.Count > 0)
            {
                dtHistorialSentinelTitular.Clear();
                var dataTitular = dtMicrTitular.AsEnumerable().GroupBy(X => X["FchPro"]).Select(X => X.CopyToDataTable());
                var SemaforoActual = InvertirCadena(cSemaforoTitular);

                decimal DeutaTotal;
                int nNumeroEntidad;
                string cCalificacion;
                string cfechaPRo;
                List<ListOrdenSemaforo> DataSemaforoTitular = LLenaListaSemaforo(SemaforoActual);

                for (int iDataTitular = 0; iDataTitular < dataTitular.Count(); iDataTitular++)
                {
                    var DataTitularAgrupada = dataTitular.ElementAt(iDataTitular);
                    DeutaTotal = 0;
                    nNumeroEntidad = 0;
                    cCalificacion = String.Empty;
                    cfechaPRo = string.Empty;
                    decimal nValorDeudaNOR = Decimal.Zero;
                    decimal nValorDeudaCPP = Decimal.Zero;
                    decimal nValorDeudaDEF = Decimal.Zero;
                    decimal nValorDeudaDUD = Decimal.Zero;
                    decimal nValorDeudaPER = Decimal.Zero;
                    decimal nValorDeudaSCAL = Decimal.Zero;
                    string cFechProNumero = String.Empty;

                    for (int y = 0; y < DataTitularAgrupada.Rows.Count; y++)
                    {
                        DeutaTotal += Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]);
                        nNumeroEntidad += 1;
                        cCalificacion = DataTitularAgrupada.Rows[y]["Cal"].ToString();
                        cfechaPRo = DataTitularAgrupada.Rows[y]["FchPro"].ToString();

                        nValorDeudaNOR += (cCalificacion == "NOR") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaCPP += (cCalificacion == "CPP") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaDEF += (cCalificacion == "DEF") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaDUD += (cCalificacion == "DUD") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaPER += (cCalificacion == "PER") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaSCAL += (cCalificacion == "SCAL") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;

                        cFechProNumero = Convert.ToString(DataTitularAgrupada.Rows[y]["FchProNumero"]);
                    }

                    rowHistorialSentinelTitular = dtHistorialSentinelTitular.NewRow();

                    rowHistorialSentinelTitular["FechPro"] = cfechaPRo;
                    rowHistorialSentinelTitular["SemaActual"] = DataSemaforoTitular.Where(S => S.codigo == iDataTitular).Select(S => S.Semaforo).ToList()[0];
                    rowHistorialSentinelTitular["NroEntidad"] = nNumeroEntidad;
                    rowHistorialSentinelTitular["DeudaTotal"] = DeutaTotal;
                    rowHistorialSentinelTitular["Calificacion"] = cCalificacion;

                    rowHistorialSentinelTitular["PorcentajeNOR"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaNOR * 100 / DeutaTotal), 0);
                    rowHistorialSentinelTitular["PorcentajeCPP"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaCPP * 100 / DeutaTotal), 0);
                    rowHistorialSentinelTitular["PorcentajeDEF"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaDEF * 100 / DeutaTotal), 0);
                    rowHistorialSentinelTitular["PorcentajeDUD"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaDUD * 100 / DeutaTotal), 0);
                    rowHistorialSentinelTitular["PorcentajePER"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaPER * 100 / DeutaTotal), 0);
                    rowHistorialSentinelTitular["PorcentajeSCAL"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaSCAL * 100 / DeutaTotal), 0);

                    rowHistorialSentinelTitular["FchProNumero"] = cFechProNumero;

                    dtHistorialSentinelTitular.Rows.Add(rowHistorialSentinelTitular);
                }
            }

        }
        public void HistoricoSentinel_Conyuge()
        {
            if (dtMicrConyuge.Rows.Count > 0)
            {
                dtHistorialSentinelConyuge.Clear();
                var dataConyuge = dtMicrConyuge.AsEnumerable().GroupBy(X => X["FchPro"]).Select(X => X.CopyToDataTable());
                var SemaforoActual = InvertirCadena(cSemaforoConyuge);

                decimal DeutaTotal;
                int nNumeroEntidad;
                string cCalificacion;
                string cfechaPRo;
                List<ListOrdenSemaforo> DataSemaforoTitular = LLenaListaSemaforo(SemaforoActual);

                for (int iDataConyuge = 0; iDataConyuge < dataConyuge.Count(); iDataConyuge++)
                {
                    var DataTitularAgrupada = dataConyuge.ElementAt(iDataConyuge);
                    DeutaTotal = 0;
                    nNumeroEntidad = 0;
                    cCalificacion = String.Empty;
                    cfechaPRo = string.Empty;
                    decimal nValorDeudaNOR = Decimal.Zero;
                    decimal nValorDeudaCPP = Decimal.Zero;
                    decimal nValorDeudaDEF = Decimal.Zero;
                    decimal nValorDeudaDUD = Decimal.Zero;
                    decimal nValorDeudaPER = Decimal.Zero;
                    decimal nValorDeudaSCAL = Decimal.Zero;
                    string cFechProNumero = String.Empty;

                    for (int y = 0; y < DataTitularAgrupada.Rows.Count; y++)
                    {
                        DeutaTotal += Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]);
                        nNumeroEntidad += 1;
                        cCalificacion = DataTitularAgrupada.Rows[y]["Cal"].ToString();
                        cfechaPRo = DataTitularAgrupada.Rows[y]["FchPro"].ToString();

                        nValorDeudaNOR += (cCalificacion == "NOR") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaCPP += (cCalificacion == "CPP") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaDEF += (cCalificacion == "DEF") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaDUD += (cCalificacion == "DUD") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaPER += (cCalificacion == "PER") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        nValorDeudaSCAL += (cCalificacion == "SCAL") ? Convert.ToDecimal(DataTitularAgrupada.Rows[y]["SalDeu"]) : Decimal.Zero;
                        cFechProNumero = Convert.ToString(DataTitularAgrupada.Rows[y]["FchProNumero"]);
                    }

                    rowHistorialSentinelConyuge = dtHistorialSentinelConyuge.NewRow();

                    rowHistorialSentinelConyuge["FechPro"] = cfechaPRo;
                    rowHistorialSentinelConyuge["SemaActual"] = DataSemaforoTitular.Where(S => S.codigo == iDataConyuge).Select(S => S.Semaforo).ToList()[0];
                    rowHistorialSentinelConyuge["NroEntidad"] = nNumeroEntidad;
                    rowHistorialSentinelConyuge["DeudaTotal"] = DeutaTotal;
                    rowHistorialSentinelConyuge["Calificacion"] = cCalificacion;

                    rowHistorialSentinelConyuge["PorcentajeNOR"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaNOR * 100 / DeutaTotal), 0);
                    rowHistorialSentinelConyuge["PorcentajeCPP"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaCPP * 100 / DeutaTotal), 0);
                    rowHistorialSentinelConyuge["PorcentajeDEF"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaDEF * 100 / DeutaTotal), 0);
                    rowHistorialSentinelConyuge["PorcentajeDUD"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaDUD * 100 / DeutaTotal), 0);
                    rowHistorialSentinelConyuge["PorcentajePER"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaPER * 100 / DeutaTotal), 0);
                    rowHistorialSentinelConyuge["PorcentajeSCAL"] = (DeutaTotal == Decimal.Zero) ? Decimal.Zero : Math.Round((nValorDeudaSCAL * 100 / DeutaTotal), 0);

                    rowHistorialSentinelConyuge["FchProNumero"] = cFechProNumero;

                    dtHistorialSentinelConyuge.Rows.Add(rowHistorialSentinelConyuge);
                }
            }

        }
        public static string InvertirCadena(string cadena)
        {
            // Convertir a arreglo
            char[] cadenaComoCaracteres = cadena.ToCharArray();
            // Invertir el arreglo usando métodos incorporados
            Array.Reverse(cadenaComoCaracteres);
            // Convertir de nuevo el arreglo a cadena
            return new string(cadenaComoCaracteres);
        }
        public List<ListOrdenSemaforo> LLenaListaSemaforo(string cadena)
        {

            List<ListOrdenSemaforo> lista = new List<ListOrdenSemaforo>();
            for (int i = 0; i < cadena.Length; i++)
            {
                ListOrdenSemaforo objmodel = new ListOrdenSemaforo();
                objmodel.codigo = i;
                objmodel.Semaforo = cadena[i].ToString();
                //char c = dato[i];
                lista.Add(objmodel);

            }

            return lista;
        }

        private DataTable ArmarTablaParametrosPosicionConsolidada(int idCliSeleccion, string cDocumentoIDS, string idTipoDocumento)
        {
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            DataRow drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";

            drfila[1] = idCliSeleccion.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nidTipoPersona";

            drfila[1] = nidTipoPersona.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "cDocumentoID";
            drfila[1] = "'" + cDocumentoIDS + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoDocumento";
            drfila[1] = "'" + idTipoDocumento + "'";
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }
        public DataTable GeneraResumenCondiciones(DataTable dt)
        {
            DataTable dtRespuesta = new DataTable("DtValidacionCondiciones");
            dtRespuesta.Columns.Add("Mensaje", typeof(string));
            dtRespuesta.Columns.Add("Resultado", typeof(string));

            DataTable dtRespuestaDetCumple = dtRespuesta.Clone();
            DataTable dtRespuestaDetNoCumple = dtRespuesta.Clone();

            DataTable dtGeneral = dtRespuesta.Clone();
            dtGeneral = dt.AsEnumerable()
                                .Where(b => Convert.ToString(b.Field<string>("cTipoCondicion")) == "GENERAL")
                                .GroupBy(x => x.Field<string>("Mensaje"))
                                .Select(y => dtRespuesta.Rows.Add(Convert.ToString(y.First().Field<string>("Mensaje")), Convert.ToString(y.First().Field<string>("Resultado")))).CopyToDataTable();

            DataTable dtProducto = dtRespuesta.Clone();
            dtProducto = dt.AsEnumerable().Where(x => Convert.ToString(x.Field<string>("cTipoCondicion")) == "PRODUCTO").CopyToDataTable();

            IEnumerable<IGrouping<string, string>> lstCumple = dtProducto.AsEnumerable().Where(b => Convert.ToString(b.Field<string>("Resultado")) == "CUMPLE").GroupBy(grp => grp.Field<string>("Mensaje"), grp => grp.Field<string>("Oculto"));
            IEnumerable<IGrouping<string, string>> lstNoCumple = dtProducto.AsEnumerable().Where(b => Convert.ToString(b.Field<string>("Resultado")) == "NO CUMPLE").GroupBy(grp => grp.Field<string>("Mensaje"), grp => grp.Field<string>("Oculto"));

            foreach (IGrouping<string, string> oNoCumple in lstNoCumple)
            {
                string cNoCumpleDet = (dtProducto.AsEnumerable().Any(x => Convert.ToString(x.Field<string>("Resultado")) == "NO CUMPLE" && Convert.ToString(x.Field<string>("Mensaje")) == oNoCumple.Key)) ? "NO CUMPLE:" : "";
                cNoCumpleDet = cNoCumpleDet + " " + String.Join(", ", oNoCumple);
                dtRespuestaDetNoCumple.Rows.Add(oNoCumple.Key, cNoCumpleDet);
            }

            foreach (IGrouping<string, string> oCumple in lstCumple)
            {
                string cCumpleDet = (dtProducto.AsEnumerable().Any(x => Convert.ToString(x.Field<string>("Resultado")) == "CUMPLE" && Convert.ToString(x.Field<string>("Mensaje")) == oCumple.Key)) ? "CUMPLE" : "";
                dtRespuestaDetCumple.Rows.Add(oCumple.Key, cCumpleDet);
            }

            dtRespuestaDetCumple.Merge(dtRespuestaDetNoCumple, true, MissingSchemaAction.AddWithKey);

            dtRespuestaDetCumple.AsEnumerable()
                .GroupBy(grp => grp.Field<string>("Mensaje"))
                .Select(x => new { Mensaje = x.Key, Resultado = String.Join(" - ", x.Select(i => i.Field<string>("Resultado"))) }).ToList()
                .ForEach(x => { dtRespuesta.Rows.Add(x.Mensaje, x.Resultado); });

            return dtRespuesta;
        }
        public string fechaformateada(string fecha)
        {
            string[] valores = fecha.Split('-');
            string Mes = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(valores[1]));
            string Anio = valores[0];
            string Resultado = Mes.Replace(".", "").Replace("Set", "Sep") + " " + Anio;
            return Resultado;
        }

        private void txtNroDoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGestObs_Click(object sender, EventArgs e)
        {
            frmGestionObservaciones frmGestObs = new frmGestionObservaciones();
            frmGestObs.idEtapaEvalCred = 4;
            frmGestObs.nModoFunc = 1;
            frmGestObs.idSolicitud = this.objEvalCred.idSolicitud;
            frmGestObs.ConfigSelecFiltros(true, true, true, true);
            frmGestObs.ConfigHabilitarFiltros(false, true, true, true);
            frmGestObs.ShowDialog();

            if (ValidarIndicadorObser("lObserv"))
            {
                this.cboResultComite.SelectedValue = 9;
            }
        }

        private bool ValidarIndicadorObser(string cFiltro)
        {
            DataTable dtIndicadoresObs = objCNGestionObservaciones.ObtenerIndicadoresObs(this.objEvalCred.idSolicitud, 4);
            return (dtIndicadoresObs.AsEnumerable().FirstOrDefault().Field<bool>(cFiltro));
        }
    }
}
