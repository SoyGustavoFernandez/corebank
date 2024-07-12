using CRE.CapaNegocio;
using EntityLayer;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class ConEstadosFinancierosPymeEst : UserControl
    {
        #region Variables

        // -- Eventos
        public event EventHandler DeudasClick;

        // -- Variables Generales
        private clsEvalCred objEvalCred;
        private clsCreditoProp objSolicitud;
        private clsMEstResPymeEst objMEstRes;
        private List<clsIndicadorEval> listIndiFinanc;
        private List<clsDEstResPymeEst> listDEstRes;
        private List<clsDEstResPymeEst> listDEstResUlt;
        private decimal nCuotaAprox = 0.00M;

        private List<clsEstResEval> listEstResEval;
        private DataTable dtMeses;
        private decimal nIncrementoMin;
        private decimal nIncrementoMax;
        private int nMaxMesesEERR;
        private bool lformatoSimple;
        private int nPlazo;

        // -- Alertas Variables
        private clsCNAlertaVariable objCNAlertaVariable;
        private DataTable dtReemplazos;
        private int idEvalCred;
        private int idCliente;
        private int idDestino;
        private decimal nCapitalPropuesto;
        private decimal nCuotaAproximada;

        // -- Estado de Perdidas y Ganancias
        private List<clsIncremento> listIncrementoVert = new List<clsIncremento>();
        private DataTable dtIncrementoHori = new DataTable();
        private DataTable dtEstPerGan = new DataTable();
        private BindingSource bsIncrementoHori = new BindingSource();
        private BindingSource bsEstPerGan = new BindingSource();
        private decimal nVentaMensualMarginal;

        // -- Referencia Última Evaluación
        DateTime dFechaDesembolso_ult;

        enum TipoFormato
        {
            Simple = 1,
            Completo = 2
        }

        #endregion

        #region Métodos Públicos

        public ConEstadosFinancierosPymeEst()
        {
            InitializeComponent();
        }

        public void asignarDatos(clsEvalCred objEvalCred, clsCreditoProp objSolicitud, DataTable dtEstResEvalM, DataTable dtEstResEvalD, DataTable dtEstResEvalUlt, List<clsIndicadorEval> listIndiFinanc)
        {
            // -- Eventos
            this.dtgIncrementos.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIncrementos_CellValueChanged);
            this.dtgIncrementos.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgIncrementos_EditingControlShowing);
            this.dtgEstResEval.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgEstResEval_DataBindingComplete);
            this.dtgEstResEval.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEstResEval_CellValueChanged);
            this.dtgEstResEval.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgEstResEval_EditingControlShowing);

            // -- Evaluación
            this.idEvalCred = objEvalCred.idEvalCred;
            this.objEvalCred = objEvalCred;
            this.nCapitalPropuesto = objEvalCred.nCapitalPropuesto;
            this.nCuotaAproximada = objEvalCred.nCuotaAprox;

            // -- Solicitud
            this.objSolicitud = objSolicitud;
            this.idCliente = objSolicitud.idCli;
            this.idDestino = objSolicitud.idDestino;

            // -- EERR
            this.objMEstRes = (DataTableToList.ConvertTo<clsMEstResPymeEst>(dtEstResEvalM) as List<clsMEstResPymeEst>).First();
            this.listDEstRes = DataTableToList.ConvertTo<clsDEstResPymeEst>(dtEstResEvalD) as List<clsDEstResPymeEst>;
            this.listDEstResUlt = DataTableToList.ConvertTo<clsDEstResPymeEst>(dtEstResEvalUlt) as List<clsDEstResPymeEst>;

            // -- Referencia última evalacuación
            if (dtEstResEvalUlt.Rows.Count > 0)
            {
                int idEvalCred_ult = dtEstResEvalUlt.Rows[0].Field<int>("idEvalCred");
                this.dFechaDesembolso_ult = dtEstResEvalUlt.Rows[0].Field<DateTime>("dFechaDesembolso");
                decimal nCapitalDesembolso_ult = dtEstResEvalUlt.Rows[0].Field<decimal>("nCapitalDesembolso");
                decimal nCuotaAprox_ult = dtEstResEvalUlt.Rows[0].Field<decimal>("nCuotaAprox");

                txtUltEvalRef.Text = "ÚLTIMA EVALUACIÓN(" + this.dFechaDesembolso_ult.ToString("yyyy/MM/dd") + ") N°: " + idEvalCred_ult + " \r\nMonto: " + nCapitalDesembolso_ult.ToString("N2") + "    Cuota Ref: " + nCuotaAprox_ult.ToString("N2");
            }
            else { 
                txtUltEvalRef.Text = "ÚLTIMA EVALUACIÓN: ---";
            }

            // -- Deudas Financieras
            var dtDeudasFinancieras = new clsCNEvalPymeEstacional().obtenerGastosFinancieros(this.idEvalCred);
            var listSaldosRCC = DataTableToList.ConvertTo<clsDeudasEval>(dtDeudasFinancieras) as List<clsDeudasEval>;
            decimal nGastosFinancieros = listSaldosRCC.Sum(x => x.nMontoCuota);

            if (!this.lformatoSimple)
            {
                var filterListDEstRes = this.listDEstRes.Where(x => x.idEEFF == EEFF.GastosFinancieros).ToList();
                filterListDEstRes.ForEach(x => x.nValorBase = nGastosFinancieros);
            }

            // -- Indicadores financieros
            this.listIndiFinanc = listIndiFinanc;

            // -- Parámetros del formulario
            this.dtMeses = new clsCNEvalPymeEstacional().obtenerMeses();
            this.nIncrementoMin = clsVarApl.dicVarGen["nIncrementoMin"];
            this.nIncrementoMax = clsVarApl.dicVarGen["nIncrementoMax"];
            this.nMaxMesesEERR = clsVarApl.dicVarGen["nMaxMesesEERR"];
            this.lformatoSimple = this.objMEstRes.idMConf == (int)TipoFormato.Simple ? true : false;
            this.nPlazo = this.objMEstRes.nPlazo;

            formatearDataGridView();
            generaIncrementos();
            generarConceptos();
            calcularValores();
            formatearColumnasDtgIncrementos();
            formatearColumnasDtgEstResEval();

            actualizarIndicadores(true);

            // -- Condiciones del Credito
            this.conCreditoTasa.AsignarDatos(new clsCreditoProp()
            {
                idSolicitud = this.objEvalCred.idSolicitud,
                idMoneda = this.objEvalCred.idMoneda,
                nMonto = this.objEvalCred.nCapitalPropuesto,
                nCuotas = this.objEvalCred.nCuotas,
                idTipoPeriodo = this.objEvalCred.idTipoPeriodo,
                nPlazoCuota = this.objEvalCred.nPlazoCuota,
                nDiasGracia = this.objEvalCred.nDiasGracia,
                dFechaDesembolso = this.objEvalCred.dFechaDesembolso,
                idProducto = this.objEvalCred.idProducto,
                cTipoCredito = this.objEvalCred.cTipoProducto,
                cSubProducto = this.objEvalCred.cSubProducto,
                idTasa = this.objEvalCred.idTasa,
                nTasaCompensatoria = this.objEvalCred.nTEA,
                idCli = this.objEvalCred.idCli,
                nCuotasGracia = this.objEvalCred.nCuotasGracia,
                idOperacion = this.objSolicitud.idOperacion,
                idAgencia = this.objSolicitud.idAgencia,
                idClasificacionInterna = this.objEvalCred.idClasificacionInterna
            });

            // -- Eventos
            this.dtgIncrementos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIncrementos_CellValueChanged);
            this.dtgIncrementos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgIncrementos_EditingControlShowing);
            this.dtgEstResEval.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgEstResEval_DataBindingComplete);
            this.dtgEstResEval.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEstResEval_CellValueChanged);
            this.dtgEstResEval.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgEstResEval_EditingControlShowing);

            this.objEvalCred.nCuotaAprox = this.conCreditoTasa.CuotaAprox();
            this.conCreditoTasa.SubTipoPeriodoEnable = false;

            dtgEstResEval_DataBindingComplete(null, null);
        }

        public void actualizarGastosFinancieros(decimal nGastosFinancieros)
        {
            if (this.lformatoSimple)
                return;

            var filterListDEstRes = this.listDEstRes.Where(x => x.idEEFF == EEFF.GastosFinancieros).ToList();
            filterListDEstRes.ForEach(x => x.nValorBase = nGastosFinancieros);

            var row = this.dtEstPerGan.Select("idEEFF = " + EEFF.GastosFinancieros)[0];
            row["nValorBase"] = nGastosFinancieros;

            calcularValores();
            actualizarIndicadores();
            this.dtgEstResEval.Refresh();
        }

        public DataSet ObtenerDatos()
        {
            DataSet dataSet = new DataSet();

            var listMEstRes = new List<clsMEstResPymeEst> { this.objMEstRes };
            DataTable dtEstResEvalM = DataTableToList.CreateDataTable(listMEstRes);
            dataSet.Tables.Add(dtEstResEvalM);

            var listMeses = new List<int>();
            listMeses = this.listDEstRes.Select(x => x.nMes).Distinct().ToList();

            foreach (DataRow row in this.dtEstPerGan.Rows)
            {
                foreach (var item in listMeses)
                {
                    var nombreColumna = "nValorMes" + item;
                    var objDEstRes = this.listDEstRes.Find(x => x.idEEFF == row.Field<int>("idEEFF") && x.nMes == item);
                    objDEstRes.nValorBase = row.Field<decimal>("nValorBase");
                    objDEstRes.nValorMes = row.Field<decimal>(nombreColumna);
                    objDEstRes.nIncremento = this.dtIncrementoHori.Rows[0].Field<decimal>(nombreColumna);
                }
            }

            DataTable dtEstResEvalD = DataTableToList.CreateDataTable(this.listDEstRes);
            dataSet.Tables.Add(dtEstResEvalD);

            return dataSet;
        }

        public List<clsEvalCredAlertaVariable> listarAlertaVariable(int idSolicitud, int idSectorEcon)
        {
            this.generarReemplazos();
            this.objCNAlertaVariable = new clsCNAlertaVariable();
            List<clsEvalCredAlertaVariable> lstEvalCredAlerta = new List<clsEvalCredAlertaVariable>();

            List<clsAlertaVariable> lstAlertaVariable = this.objCNAlertaVariable.listarAlertaVariable(idSolicitud, idSectorEcon);
            Dictionary<string, decimal> dcValorEEFF = new Dictionary<string, decimal>();
            DataTable dtEvaluador = new DataTable();

            foreach (clsAlertaVariable objAlerta in lstAlertaVariable)
            {
                string cCondicion = objAlerta.cCondicion;

                int idEEFF = 0;
                string[] vFragmentos = cCondicion.Split('[', ']');
                string cCondReemplazado = string.Empty;

                for (int i = 0; i < vFragmentos.Length; i++)
                {
                    string cCadena = vFragmentos[i].Trim();

                    if (int.TryParse(cCadena, out idEEFF))
                    {
                        decimal nValor = this.buscarValorEEFF(objAlerta.idClaseAnalisis, objAlerta.idTipoAnalisis, idEEFF, objAlerta.idFuncionDinamica);
                        vFragmentos[i] = nValor.ToString("##0.0000");
                    }
                    cCondReemplazado = string.Concat(cCondReemplazado, vFragmentos[i]);
                }

                bool lEvaluacion = false;

                try
                {
                    lEvaluacion = Convert.ToBoolean(dtEvaluador.Compute(cCondReemplazado, ""));
                }
                catch
                {
                    lEvaluacion = false;
                }

                if (lEvaluacion)
                {
                    clsEvalCredAlertaVariable objEvalCredAlerta = new clsEvalCredAlertaVariable();

                    objEvalCredAlerta.idClaseAnalisis = objAlerta.idClaseAnalisis;
                    objEvalCredAlerta.cClaseAnalisis = objAlerta.cClaseAnalisis;
                    objEvalCredAlerta.idTipoAnalisis = objAlerta.idTipoAnalisis;
                    objEvalCredAlerta.cTipoAnalisis = objAlerta.cTipoAnalisis;
                    objEvalCredAlerta.idFuncionDinamica = objAlerta.idFuncionDinamica;
                    objEvalCredAlerta.cIdsSectorEcon = objAlerta.cIdsSectorEcon;
                    objEvalCredAlerta.cAlertaVariable = objAlerta.cAlertaVariable;
                    objEvalCredAlerta.lReqVistoBueno = objAlerta.lReqVistoBueno;

                    objEvalCredAlerta.idAlertaVariable = objAlerta.idAlertaVariable;
                    objEvalCredAlerta.cValor = cCondReemplazado;
                    objEvalCredAlerta.idEvalCred = this.idEvalCred;
                    objEvalCredAlerta.idSolicitud = idSolicitud;

                    lstEvalCredAlerta.Add(objEvalCredAlerta);
                }
            }

            return lstEvalCredAlerta;
        }

        public void generarReemplazos()
        {
            this.dtReemplazos = new DataTable();
            this.dtReemplazos.Columns.Add("cNombre", typeof(string));
            this.dtReemplazos.Columns.Add("cValor", typeof(string));

            DataRow drFila = this.dtReemplazos.NewRow();
            drFila["cNombre"] = "idCliente";
            drFila["cValor"] = this.idCliente.ToString();
            dtReemplazos.Rows.Add(drFila);

            drFila = this.dtReemplazos.NewRow();
            drFila["cNombre"] = "nMonto";
            drFila["cValor"] = this.nCapitalPropuesto.ToString();
            dtReemplazos.Rows.Add(drFila);
        }

        public decimal buscarValorEEFF(int idClaseAnalisis, int idTipoAnalisis, int idEEFF, int idFuncionDinamica)
        {
            if (idEEFF == 9999) return this.nCuotaAproximada;
            else if (idEEFF == 8888)
            {
                clsRespuestaServidor objRespuestaServidor = this.objCNAlertaVariable.ejecutarFuncionDinamica(idFuncionDinamica, this.dtReemplazos);
                if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
                {
                    return Convert.ToDecimal(objRespuestaServidor.objDatos);
                }
                else
                {
                    return decimal.Zero;
                }

            }
            else if (idEEFF == 7777) return this.nCapitalPropuesto;
            else if (idEEFF == 6666) return this.idDestino;

            decimal nValor = decimal.Zero;

            if (idClaseAnalisis == 1)
            {
                clsEstResEval objEstResEval = new clsEstResEval(); //this.listEstResEval.Find(x => x.idEEFF == idEEFF);
                if (objEstResEval != null)
                {
                    switch (idTipoAnalisis)
                    {
                        case 1:
                            nValor = objEstResEval.nTotalMA;
                            break;
                        case 2:
                            nValor = (objEstResEval.nTotalUltEvMA != decimal.Zero) ?
                                (objEstResEval.nTotalMA - objEstResEval.nTotalUltEvMA) / objEstResEval.nTotalUltEvMA :
                                decimal.Zero;
                            break;
                        case 3:
                            nValor = objEstResEval.nTotalMA;
                            break;
                    }
                }
            }

            return nValor;
        }

        public clsEvalCred condicionesCreditoYDestino()
        {
            clsCreditoProp credProp = this.conCreditoTasa.ObtenerCreditoPropuesto();

            this.objEvalCred.nCapitalPropuesto = credProp.nMonto;
            this.objEvalCred.nCuotas = credProp.nCuotas;
            this.objEvalCred.idTipoPeriodo = credProp.idTipoPeriodo;
            this.objEvalCred.nPlazoCuota = credProp.nPlazoCuota;
            this.objEvalCred.dFechaDesembolso = credProp.dFechaDesembolso;
            this.objEvalCred.nDiasGracia = credProp.nDiasGracia;
            this.objEvalCred.idTasa = credProp.idTasa;
            this.objEvalCred.nTEA = credProp.nTea;
            this.objEvalCred.nTEM = credProp.nTem;
            this.objEvalCred.nCuotasGracia = credProp.nCuotasGracia;
            this.objEvalCred.nPlazo = credProp.nPlazo;
            this.objEvalCred.nCuotaAprox = credProp.nCuotaAprox;
            this.objEvalCred.nCuotaGraciaAprox = credProp.nCuotaGraciaAprox;
            this.objEvalCred.dtCalendarioPagos = credProp.dtCalendarioPagos;
            this.objEvalCred.cCalendarioPagos = credProp.cCalendarioPagos;
            this.objEvalCred.nTotalMontoPagar = credProp.nTotalMontoPagar;

            return objEvalCred;
        }

        public clsCreditoProp condicionesCreditoPropuesto()
        {
            return this.conCreditoTasa.ObtenerCreditoPropuesto();
        }

        public int PlazoTotal()
        {
            return conCreditoTasa.nPlazoTotal;
        }

        public decimal obtenerMonto()
        {
            return this.conCreditoTasa.Monto();
        }

        public DataTable obtenerEstPerGan()
        {
            return this.dtEstPerGan;
        }

        #endregion

        #region Métodos Privados

        private void generaIncrementos()
        {
            // VERTICAL
            this.listIncrementoVert = new List<clsIncremento>();
            int idMesesInicial = this.listDEstRes.Find(x => x.nMes == 1).idMeses;
            for (int i = 0; i < this.nPlazo; i++)
            {
                var filtrados = this.listDEstRes.FindAll(x => x.nMes == (i + 1));

                int nMesEnAnio = (idMesesInicial + i) % 12 == 0 ? 12 : (idMesesInicial + i) % 12;

                this.listIncrementoVert.Add(new clsIncremento
                {
                    nMes = 1 + i,
                    idMeses = nMesEnAnio,
                    cMes = this.dtMeses.Select("idMeses = " + (nMesEnAnio))[0]["cMes"].ToString(),
                    nIncremento = filtrados.Count > 0 ? filtrados[0].nIncremento : this.nIncrementoMin
                });
            }

            // HORIZONTAL
            var dtIncrementoHori = new DataTable();
            foreach (var item in this.listIncrementoVert)
            {
                var nombreColumna = "nValorMes" + item.nMes;
                dtIncrementoHori.Columns.Add(nombreColumna, typeof(decimal));
            }

            DataRow fila = dtIncrementoHori.NewRow();
            foreach (var item in this.listIncrementoVert)
            {
                var nombreColumna = "nValorMes" + item.nMes;
                fila[nombreColumna] = item.nIncremento == decimal.Zero ? this.nIncrementoMin : item.nIncremento;
            }
            dtIncrementoHori.Rows.Add(fila);

            this.dtIncrementoHori = dtIncrementoHori;
            this.bsIncrementoHori.DataSource = this.dtIncrementoHori;
            this.dtgIncrementos.DataSource = this.bsIncrementoHori;
        }

        private void generarConceptos()
        {
            var dtEstPerGan = new DataTable();

            dtEstPerGan.Columns.Add("idEEFF", typeof(int));
            dtEstPerGan.Columns.Add("lEditable", typeof(bool));
            dtEstPerGan.Columns.Add("cDescripcion", typeof(string));
            dtEstPerGan.Columns.Add("nValorUlt", typeof(decimal));
            dtEstPerGan.Columns.Add("nValorBase", typeof(decimal));
            dtEstPerGan.Columns.Add("nPorcentaje", typeof(decimal));

            foreach (var item in this.listDEstRes.Select(x => x.nMes).Distinct())
            {
                var nombreColumna = "nValorMes" + item;
                dtEstPerGan.Columns.Add(nombreColumna, typeof(decimal));
            }

            dtEstPerGan.Columns.Add("nMarginal", typeof(decimal));

            var listConceptosUnicos = this.listDEstRes.Select(x => new { x.idEEFF, x.lEditable, x.cDescripcion, x.nValorBase }).Distinct();
            bool lEstResulNuevo = this.listDEstRes.All(x => x.dFechaMod == null);

            foreach (var item in listConceptosUnicos)
            {
                DataRow fila = dtEstPerGan.NewRow();
                fila["idEEFF"] = item.idEEFF;
                fila["lEditable"] = item.lEditable;
                fila["cDescripcion"] = item.cDescripcion;

                decimal nValorBase = item.nValorBase;
                decimal nValorUlt = 0.00M;

                clsDEstResPymeEst itemUlt = listDEstResUlt.Find(x => x.idEEFF == item.idEEFF);
                if (itemUlt != null)
                {
                    nValorUlt = itemUlt.nValorBase;
                    if (lEstResulNuevo && itemUlt.lVigente)
                    {
                        nValorBase = itemUlt.nValorBase;
                    }
                }

                fila["nValorUlt"] = nValorUlt;
                fila["nValorBase"] = nValorBase;

                dtEstPerGan.Rows.Add(fila);
            }

            foreach (DataRow row in dtEstPerGan.Rows)
            {
                decimal nMarginal = decimal.Zero;
                foreach (var item in this.listDEstRes.Select(x => x.nMes).Distinct())
                {
                    var nombreColumna = "nValorMes" + item;
                    row[nombreColumna] = this.listDEstRes.Find(x => x.idEEFF == (int)row["idEEFF"] && x.nMes == item).nValorMes;
                    nMarginal = nMarginal + row.Field<decimal>(nombreColumna);
                }
                row["nMarginal"] = nMarginal;
            }


            this.dtEstPerGan = dtEstPerGan;
            this.bsEstPerGan.DataSource = this.dtEstPerGan;
            this.dtgEstResEval.DataSource = this.bsEstPerGan;
        }

        private void calcularValores()
        {
            foreach (DataRow row in this.dtEstPerGan.Rows)
            {
                if (row.Field<int>("idEEFF") == EEFF.UtilidadBruta)
                {
                    var VentasNetas = this.dtEstPerGan.Select("idEEFF = " + EEFF.VentasNetas);
                    var CostoVentas = this.dtEstPerGan.Select("idEEFF = " + EEFF.CostoVentas);
                    row["nValorBase"] = VentasNetas[0].Field<decimal>("nValorBase") - CostoVentas[0].Field<decimal>("nValorBase");
                }

                if (!this.lformatoSimple)
                {
                    if (row.Field<int>("idEEFF") == EEFF.GastosNegocio)
                    {
                        int[] aIdEEFF = { EEFF.GastosDelPersonal , EEFF.LuzAguaTelefono   ,
                                          EEFF.AlquilerLocal     , EEFF.Transporte        ,
                                          EEFF.Impuestos         , EEFF.GastosFinancieros ,
                                          EEFF.OtrosGastos };

                        row["nValorBase"] = this.dtEstPerGan.AsEnumerable()
                                            .Where(x => aIdEEFF.Contains(x.Field<int>("idEEFF")))
                                            .Sum(x => x.Field<decimal>("nValorBase"));
                    }

                    if (row.Field<int>("idEEFF") == EEFF.UtilidadNeta)
                    {
                        var UtilidadBruta = this.dtEstPerGan.Select("idEEFF = " + EEFF.UtilidadBruta);
                        var GastosNegocio = this.dtEstPerGan.Select("idEEFF = " + EEFF.GastosNegocio);
                        row["nValorBase"] = UtilidadBruta[0].Field<decimal>("nValorBase") - GastosNegocio[0].Field<decimal>("nValorBase");
                    }

                    if (row.Field<int>("idEEFF") == EEFF.ExcedenteMensualFamiliar)
                    {
                        DataRow UtilidadNeta = this.dtEstPerGan.Select("idEEFF = " + EEFF.UtilidadNeta)[0];
                        DataRow OtrosIngresos = this.dtEstPerGan.Select("idEEFF = " + EEFF.OtrosIngresos)[0];
                        DataRow GastosFamiliares = this.dtEstPerGan.Select("idEEFF = " + EEFF.GastosFamiliares)[0];

                        row["nValorBase"] = UtilidadNeta.Field<decimal>("nValorBase") + OtrosIngresos.Field<decimal>("nValorBase") - GastosFamiliares.Field<decimal>("nValorBase");
                    }
                }

                row["nPorcentaje"] = row.Field<decimal>("nValorUlt") == 0 ? 0 : (row.Field<decimal>("nValorBase") / row.Field<decimal>("nValorUlt")) - 1;

            }

            foreach (DataRow row in this.dtEstPerGan.Rows)
            {
                decimal nMarginal = decimal.Zero;
                foreach (var item in this.listDEstRes.Select(x => x.nMes).Distinct())
                {
                    var nombreColumna = "nValorMes" + item;
                    decimal nIncremento = this.dtIncrementoHori.Rows[0].Field<decimal>(nombreColumna);
                    row[nombreColumna] = row.Field<decimal>("nValorBase") * (nIncremento / 100) - row.Field<decimal>("nValorBase");
                    nMarginal = nMarginal + row.Field<decimal>(nombreColumna);
                }
                row["nMarginal"] = nMarginal;
            }

            this.nVentaMensualMarginal = this.dtEstPerGan.Select("idEEFF = " + EEFF.VentasNetas)[0].Field<decimal>("nMarginal");
        }

        private void formatearDataGridView()
        {
            // Incrementos
            this.dtgIncrementos.MultiSelect = false;
            this.dtgIncrementos.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgIncrementos.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgIncrementos.SelectionMode = DataGridViewSelectionMode.CellSelect;

            // Conceptos
            this.dtgEstResEval.MultiSelect = false;
            this.dtgEstResEval.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgEstResEval.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgEstResEval.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        private void formatearColumnasDtgIncrementos()
        {
            this.dtgEstResEval.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgEstResEval_DataBindingComplete);
            this.dtgIncrementos.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIncrementos_CellValueChanged);

            this.dtgIncrementos.ReadOnly = false;

            foreach (DataGridViewColumn column in this.dtgIncrementos.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                column.Width = 70;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.DefaultCellStyle.Format = "P";
                column.DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
                column.ReadOnly = false;

            }

            foreach (var item in this.listDEstRes.Select(x => x.nMes).Distinct())
            {
                var nombreColumna = "nValorMes" + item;
                this.dtgIncrementos.Columns[nombreColumna].HeaderText = this.listIncrementoVert.Find(x => x.nMes == item).cMes;
            }

            this.dtgIncrementos.CellFormatting += dtgIncrementos_CellFormatting;
            this.dtgIncrementos.ClearSelection();
            this.dtgIncrementos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgIncrementos_CellValueChanged);
            this.dtgEstResEval.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgEstResEval_DataBindingComplete);
        }

        private void dtgIncrementos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dtgIncrementos.Columns.Count >= 1 && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                decimal valor = Convert.ToDecimal(this.dtgIncrementos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                string valorFormateado = string.Format("{0:n2} %", valor);
                e.Value = valorFormateado;
                e.FormattingApplied = true;
            }
        }

        private void formatearColumnasDtgEstResEval()
        {
            this.dtgEstResEval.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEstResEval_CellValueChanged);

            this.dtgEstResEval.ColumnHeadersVisible = false;

            this.dtgEstResEval.Columns["idEEFF"].Visible = false;
            this.dtgEstResEval.Columns["lEditable"].Visible = false;

            this.dtgEstResEval.ReadOnly = false;

            foreach (DataGridViewColumn column in this.dtgEstResEval.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                column.ReadOnly = true;
            }
            this.dtgEstResEval.Columns["nValorBase"].ReadOnly = false;

            this.dtgEstResEval.Columns["cDescripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            this.dtgEstResEval.Columns["nPorcentaje"].DefaultCellStyle.Format = "P"; // "P" para porcentaje
            foreach (var item in this.listDEstRes.Select(x => x.nMes).Distinct())
            {
                var nombreColumna = "nValorMes" + item;
                this.dtgEstResEval.Columns[nombreColumna].Width = 70;
                this.dtgEstResEval.Columns[nombreColumna].DefaultCellStyle.Format = "n2";
            }
            this.dtgEstResEval.Columns["nMarginal"].DefaultCellStyle.Format = "n2";

            this.dtgEstResEval.Columns["cDescripcion"].Width = 150;
            this.dtgEstResEval.Columns["nValorUlt"].Width = 70;
            this.dtgEstResEval.Columns["nPorcentaje"].Width = 70;
            this.dtgEstResEval.Columns["nValorBase"].Width = 70;
            this.dtgEstResEval.Columns["nMarginal"].Width = 70;

            int nDtgIncrementosWidth = 0;
            foreach (DataGridViewColumn column in this.dtgIncrementos.Columns)
            {
                if (column.Visible)
                {
                    nDtgIncrementosWidth += column.Width;
                }
            }

            this.tableLayoutCabecera.ColumnStyles[1].Width = nDtgIncrementosWidth;

            this.dtgEstResEval.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEstResEval_CellValueChanged);
        }

        private void formatearStyleCellDtgEstResEval()
        {
            foreach (DataGridViewRow row in this.dtgEstResEval.Rows)
            {
                bool lEditable = Convert.ToBoolean(row.Cells["lEditable"].Value);

                if (lEditable)
                {
                    row.Cells["nValorBase"].ReadOnly = false;
                    row.Cells["nValorBase"].Style.BackColor = GridViewStyle.GridViewBackColorEditable;
                }
                else
                {
                    row.Cells["nValorBase"].ReadOnly = true;
                }
            }

            foreach (DataGridViewRow row in this.dtgEstResEval.Rows)
            {
                int idEEFF = Convert.ToInt32(row.Cells["idEEFF"].Value);
                if (idEEFF == EEFF.UtilidadBruta || idEEFF == EEFF.GastosOperativos ||
                    idEEFF == EEFF.UtilidadNeta || idEEFF == EEFF.ExcedenteMensualFamiliar)
                    row.DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorTotal;
            }
        }

        private void modificarPlazo(int nPlazo)
        {
            if (nPlazo < this.nPlazo)
            {
                this.listDEstRes.RemoveAll(fila => fila.nMes > nPlazo);
            }
            else
            {
                int cantidad = nPlazo - this.nPlazo;
                var listTemp = new List<clsDEstResPymeEst>();
                int maxNumeroMes = listDEstRes.Max(x => x.nMes);
                listTemp = listDEstRes.FindAll(x => x.nMes == maxNumeroMes);

                for (int i = 1; i <= cantidad; i++)
                {
                    foreach (var item in listTemp)
                    {
                        int nMesEnAnio = (item.idMeses + i) % 12 == 0 ? 12 : (item.idMeses + i) % 12;

                        this.listDEstRes.Add(new clsDEstResPymeEst()
                        {
                            idDEstRes = 0,
                            idMEstRes = this.objMEstRes.idMEstRes,
                            idItemEstRes = item.idItemEstRes,
                            idEEFF = item.idEEFF,
                            nValorBase = item.nValorBase,
                            idMeses = nMesEnAnio,
                            cMes = this.dtMeses.Select("idMeses = " + (nMesEnAnio))[0]["cMes"].ToString(),
                            nMes = this.nPlazo + i,
                            nIncremento = item.nIncremento,
                            nValorMes = 0,
                            nOrden = item.nOrden,
                            lEditable = item.lEditable,
                            cDescripcion = item.cDescripcion
                        });
                    }
                }
            }

            this.objMEstRes.nPlazo = nPlazo;
            this.nPlazo = this.objMEstRes.nPlazo;

            this.dtgEstResEval.Columns.Clear();
            generaIncrementos();
            generarConceptos();
            calcularValores();
            formatearColumnasDtgIncrementos();
            formatearColumnasDtgEstResEval();
            actualizarIndicadores();
            this.dtgIncrementos.Refresh();
            this.dtgEstResEval.Refresh();
        }

        private void actualizarIndicadores(bool lPrimeraCarga = false)
        {
            this.listEstResEval = new List<clsEstResEval>();
            foreach (DataRow row in this.dtEstPerGan.Rows)
            {
                this.listEstResEval.Add(
                    new clsEstResEval()
                    {
                        idEEFF = row.Field<int>("idEEFF"),
                        nTotalMA = row.Field<decimal>("nValorBase"),
                        nTotalME = 0,
                        nTotalMN = 0,
                        nTotalUltEv = 0,
                        nTotalUltEvMA = 0,
                    });
            }

            CalcularCuotaAprox();
            if (lPrimeraCarga)
            {
                this.txtCuotaAprox.Text = this.nCuotaAprox.ToString("N2");

                this.conIndicadores.asignaDatosCredPymeEstacional(
                    this.listIndiFinanc,
                    this.listEstResEval,
                    this.objEvalCred.idTipEvalCred,
                    this.objEvalCred.nCapitalPropuesto,
                    this.nCuotaAprox,
                    this.nVentaMensualMarginal);
            }
            else
            {
                this.conIndicadores.actualizaCredPymeEstacional(
                    this.listEstResEval,
                    this.objEvalCred.idTipEvalCred,
                    this.objEvalCred.nCapitalPropuesto,
                    this.nCuotaAprox,
                    this.nVentaMensualMarginal);
            }

        }

        #endregion

        #region Eventos

        private void dtgIncrementos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell celda = this.dtgIncrementos.Rows[0].Cells[e.ColumnIndex];

            decimal nIncremento = Convert.ToDecimal(celda.Value.ToString());
            if (nIncremento < this.nIncrementoMin)
            {
                nIncremento = this.nIncrementoMin;
                celda.Value = nIncremento;
            }

            if (nIncremento > this.nIncrementoMax)
            {
                nIncremento = this.nIncrementoMax;
                celda.Value = nIncremento;
            }

            calcularValores();
            actualizarIndicadores();
            this.dtgEstResEval.Refresh();
        }

        private void dtgEstResEval_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = this.dtgEstResEval.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    this.dtgEstResEval.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEstResEval_CellValueChanged);
                    cell.Value = 0.00M;
                    this.dtgEstResEval.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEstResEval_CellValueChanged);
                    return;
                }
            }

            calcularValores();
            actualizarIndicadores();
            this.dtgEstResEval.Refresh();
        }

        private void dtgIncrementos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);
            e.Control.KeyPress -= new KeyPressEventHandler(column_KeyPressDecimal);

            TextBox tb = e.Control as TextBox;
            if (tb != null)
            {
                tb.KeyPress += new KeyPressEventHandler(column_KeyPressDecimal);
            }
        }

        private void dtgEstResEval_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dtg = ((DataGridView)sender);

            e.Control.KeyPress -= new KeyPressEventHandler(column_KeyPressDecimal);

            TextBox tb = e.Control as TextBox;
            if (tb != null)
            {
                tb.KeyPress += new KeyPressEventHandler(column_KeyPressDecimal);
            }
        }

        private void column_KeyPressDecimal(object sender, KeyPressEventArgs e)
        {
            // allowed numeric and one dot  ex. 10.23
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void dtgEstResEval_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            formatearStyleCellDtgEstResEval();
        }

        private void dtgEstResEval_Leave(object sender, EventArgs e)
        {
            this.dtgEstResEval.ClearSelection();
        }

        private void dtgIncrementos_Leave(object sender, EventArgs e)
        {
            this.dtgIncrementos.ClearSelection();
        }

        private void conCreditoTasa_ValueChangedDia(object sender, EventArgs e)
        {
            int nDias = this.conCreditoTasa.conCreditoPeriodo.nDias;
            int nMaxDias = this.nMaxMesesEERR * 30;

            if (nDias <= nMaxDias)
            {
                int nMesesEERR = (int)Math.Round(nDias / 30.00);
                if (nMesesEERR != this.nPlazo)
                    modificarPlazo(nMesesEERR);
            }
            else
            {
                MessageBox.Show("Se superó el maximo de dias del plazo para la Evaluación Pyme Estacional.", "Evaluación Pyme Estacional", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                var dFechaDesembolso = this.conCreditoTasa.FechaDesembolso();

                this.conCreditoTasa.ActualizarFechaPriCuota(dFechaDesembolso.AddDays(nMaxDias));
                this.conCreditoTasa.conCreditoPeriodo.actualizarDia(nMaxDias);
            }
        }

        private void ConCreditoTasa_ChangeMonto(object sender, EventArgs e)
        {
            this.objEvalCred.nCapitalPropuesto = this.conCreditoTasa.Monto();
            this.objMEstRes.nMonto = this.conCreditoTasa.Monto();
            actualizarIndicadores();
        }

        private void ConCreditoTasa_ChangeCuotaAprox(object sender, EventArgs e)
        {
            CalcularCuotaAprox();
            this.txtCuotaAprox.Text = this.nCuotaAprox.ToString("N2");
            actualizarIndicadores();
        }

        private void CalcularCuotaAprox()
        {
            // Tasa Frecuencia
            double nTasaFrecuencia = ((double)nPlazo * 30.00) / 360.00; // Exponente
            nTasaFrecuencia = Math.Pow(((double)conCreditoTasa.TEA() / 100.00 + 1.00), nTasaFrecuencia); // Potencia
            nTasaFrecuencia = nTasaFrecuencia - 1;

            // Cuota
            double nMonto = (double)this.conCreditoTasa.MontoPropuesto;
            double nNumPeriodos = 1;

            if (nTasaFrecuencia == 0)
            {
                this.nCuotaAprox = (decimal)(nMonto / nNumPeriodos);
            }
            else
            {
                this.nCuotaAprox = (decimal)((nMonto * nTasaFrecuencia) / (1 - Math.Pow(1 + nTasaFrecuencia, -nNumPeriodos)));
            }
        }

        private void btnDeudas_Click(object sender, EventArgs e)
        {
            if (DeudasClick != null)
                DeudasClick(sender, e);
        }

        private void tableLayoutCabecera_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (this.dtgEstResEval.Columns.Count <= 0)
                return;

            int cDescripcionWidth = this.dtgEstResEval.Columns["cDescripcion"].HeaderCell.Size.Width;
            int nValorUltWidth = this.dtgEstResEval.Columns["nValorUlt"].HeaderCell.Size.Width;
            int nValorBaseWidth = this.dtgEstResEval.Columns["nValorBase"].HeaderCell.Size.Width;
            int nPorcentajeWidth = this.dtgEstResEval.Columns["nPorcentaje"].HeaderCell.Size.Width;

            int nDtgIncrementosWidth = 0;
            foreach (DataGridViewColumn column in this.dtgIncrementos.Columns)
            {
                if (column.Visible)
                {
                    nDtgIncrementosWidth += column.Width;
                }
            }

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            int cellX = cDescripcionWidth;
            int cellY = this.tableLayoutCabecera.Height / 2;
            int cellWidth = this.dtgEstResEval.Columns["nValorBase"].HeaderCell.Size.Width;
            int cellHeight = this.tableLayoutCabecera.Height / 2;

            string cFecUltEval = "";
            DateTime defaultDateTime = new DateTime();
            if (this.dFechaDesembolso_ult != null && this.dFechaDesembolso_ult != defaultDateTime)
            {
                cFecUltEval = this.dFechaDesembolso_ult.ToString("yyyy/MM/dd");
            }
            else { 
                cFecUltEval = "---";
            }

            g.DrawRectangle(Pens.Gray, cellX, 0, cellWidth, cellHeight);
            g.DrawString(cFecUltEval, this.dtgIncrementos.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(System.Drawing.Color.Black),
                new RectangleF(cellX, 0, cellWidth, cellHeight), stringFormat);

            g.DrawRectangle(Pens.Gray, cellX, cellY, cellWidth, cellHeight);
            g.DrawString("Ult. Eval.", this.dtgIncrementos.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(System.Drawing.Color.Black),
                new RectangleF(cellX, cellY, cellWidth, cellHeight), stringFormat);

            cellX = cDescripcionWidth + nValorUltWidth;
            g.DrawRectangle(Pens.Gray, cellX, cellY, cellWidth, cellHeight);
            g.DrawString("Eval. Actual", this.dtgIncrementos.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(System.Drawing.Color.Black),
                new RectangleF(cellX, cellY, cellWidth, cellHeight), stringFormat);

            cellX = cDescripcionWidth + nValorUltWidth + nValorBaseWidth;
            cellWidth = this.dtgEstResEval.Columns["nPorcentaje"].HeaderCell.Size.Width;
            g.DrawRectangle(Pens.Gray, cellX, cellY, cellWidth, cellHeight);
            g.DrawString("Variación %", this.dtgIncrementos.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(System.Drawing.Color.Black),
                new RectangleF(cellX, cellY, cellWidth, cellHeight), stringFormat);

            cellX = cDescripcionWidth + nValorUltWidth + nValorBaseWidth + nPorcentajeWidth + nDtgIncrementosWidth;
            cellWidth = this.dtgEstResEval.Columns["nMarginal"].HeaderCell.Size.Width;
            g.DrawRectangle(Pens.Gray, cellX, cellY, cellWidth, cellHeight);
            g.DrawString("Acum.Total", this.dtgIncrementos.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(System.Drawing.Color.Black),
                new RectangleF(cellX, cellY, cellWidth, cellHeight), stringFormat);

        }

        #endregion

        #region Clases internas

        public class clsIncremento
        {
            public int nMes { get; set; }
            public int idMeses { get; set; }
            public string cMes { get; set; }
            public decimal nIncremento { get; set; }
        }

        #endregion
    }
}