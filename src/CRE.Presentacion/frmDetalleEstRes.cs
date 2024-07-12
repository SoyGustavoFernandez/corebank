using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
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
    public partial class frmDetalleEstRes : frmBase
    {
        private int idEvalCred;
        private clsEvalCred objEvalCred;

        private List<clsVentasCostos> listVentasCostos;
        private List<clsDetEstResEval> listGFamiliares;
        private List<clsDetEstResEval> listGPersonales;
        private List<clsDetEstResEval> listGOperativos;
        private List<clsDetEstResEval> listOtrosEgresos;
        private List<clsDetEstResEval> listOtrosIngresos;
        private List<clsVarFlujoCajaEval> listCicloVentas;
        private List<clsVarFlujoCajaEval> listReinversiones;
        private List<clsVarFlujoCajaEval> listVarGastosFam;

        private List<clsDescripcionEval> listDescVentasCostos;
        private List<clsDescripcionEval> listDescGastos;

        private List<clsInventarioPecuario> listInvPecuario;

        private string cTipEvaluacion;
        private int idTipEvalCred;

        private int idMonedaMA;
        private decimal nTipoCambio;
        private string cMonedaSimbolo;

        public bool lGuardado = false;

        public frmDetalleEstRes()
        {
            InitializeComponent();
        }

        public frmDetalleEstRes(List<clsDescripcionEval> _listDescripcionEval,
            int _idEvalCred, decimal _nTipoCambio, int _idMonedaMA, string _cMonedaSimbolo, string _cTipEvaluacion, int _idTipEvalCred, clsEvalCred _objEvalCred)
        {
            InitializeComponent();

            this.listGFamiliares = new List<clsDetEstResEval>();
            this.listGPersonales = new List<clsDetEstResEval>();
            this.listGOperativos = new List<clsDetEstResEval>();
            this.listVentasCostos = new List<clsVentasCostos>();
            this.listCicloVentas = new List<clsVarFlujoCajaEval>();
            this.listOtrosIngresos = new List<clsDetEstResEval>();
            //this.listFlujoCaja = new List<clsFlujoCaja>();

            this.idEvalCred = _idEvalCred;

            this.nTipoCambio = _nTipoCambio;
            this.idMonedaMA = _idMonedaMA;
            this.cMonedaSimbolo = _cMonedaSimbolo;
            this.idTipEvalCred = _idTipEvalCred;

            this.btnGrabar.Enabled = false;
            this.btnEditar.Enabled = true;

            this.conVentasCostos.Enabled = false;
            this.conDetalleEERR.Enabled = false;
            this.conDetalleInvPecuario.Enabled = false;
            this.btnCancelar.Enabled = false;

            this.listDescVentasCostos = (from p in _listDescripcionEval
                                         where p.idTipoDescripcion == TipoDescripcion.IngresoVentas ||
                                                 p.idTipoDescripcion == TipoDescripcion.IngresoProduccion ||
                                                 p.idTipoDescripcion == TipoDescripcion.IngresoServicios ||
                                                 p.idTipoDescripcion == TipoDescripcion.CosteoProduccion ||
                                                 p.idTipoDescripcion == TipoDescripcion.CosteoServicios
                                         select p).ToList();

            this.listDescGastos = (from p in _listDescripcionEval
                                   where p.idTipoDescripcion == TipoDescripcion.GastosPersonal ||
                                           p.idTipoDescripcion == TipoDescripcion.GastosOperativos ||
                                           p.idTipoDescripcion == TipoDescripcion.OtrosIngresos ||
                                           p.idTipoDescripcion == TipoDescripcion.OtrosEgresos ||
                                           p.idTipoDescripcion == TipoDescripcion.GastosFamiliares
                                   select p).ToList();

            this.conDetalleEERR.GastosPersonalVisible = true;

            this.cTipEvaluacion = _cTipEvaluacion;
            this.objEvalCred = _objEvalCred;

        }

        #region Métodos Públicos
        public List<clsVentasCostos> VentasCostos()
        {
            return this.listVentasCostos;
        }

        public List<clsDetEstResEval> GFamiliares()
        {
            return this.listGFamiliares;
        }

        public List<clsDetEstResEval> GPersonales()
        {
            return this.listGPersonales;
        }

        public List<clsDetEstResEval> GOperativos()
        {
            return this.listGOperativos;
        }

        public List<clsDetEstResEval> OtrosEgresos()
        {
            return this.listOtrosEgresos;
        }

        public List<clsDetEstResEval> OtrosIngresos()
        {
            return this.listOtrosIngresos;
        }

        public List<clsInventarioPecuario> InventarioPecuario()
        {
            return this.listInvPecuario;
        }
        #endregion

        #region Métodos Privados
        private bool EsPyme(int idTipEvalCred)
        {
            bool lResultado = false;
            string cEvalPyme, cEvalAgro;
            string[] cEvalArrayPyme, cEvalArrayAgro;
            int[] nEvalArrayPyme, nEvalArrayAgro;

            cEvalPyme = clsVarApl.dicVarGen["cIDsTipEvalCredPyme"];
            cEvalAgro = clsVarApl.dicVarGen["cIDsTipEvalCredAgro"];

            cEvalArrayPyme = cEvalPyme.Split(',');
            cEvalArrayAgro = cEvalAgro.Split(',');

            nEvalArrayPyme = Array.ConvertAll<string, int>(cEvalArrayPyme, int.Parse);
            nEvalArrayAgro = Array.ConvertAll<string, int>(cEvalArrayAgro, int.Parse);

            if (idTipEvalCred.In(nEvalArrayPyme)) lResultado = true;

            return lResultado;
        }

        private bool EsAgro(int idTipEvalCred)
        {
            bool lResultado = false;
            string cEvalPyme, cEvalAgro;
            string[] cEvalArrayPyme, cEvalArrayAgro;
            int[] nEvalArrayPyme, nEvalArrayAgro;

            cEvalPyme = clsVarApl.dicVarGen["cIDsTipEvalCredPyme"];
            cEvalAgro = clsVarApl.dicVarGen["cIDsTipEvalCredAgro"];

            cEvalArrayPyme = cEvalPyme.Split(',');
            cEvalArrayAgro = cEvalAgro.Split(',');

            nEvalArrayPyme = Array.ConvertAll<string, int>(cEvalArrayPyme, int.Parse);
            nEvalArrayAgro = Array.ConvertAll<string, int>(cEvalArrayAgro, int.Parse);

            if (idTipEvalCred.In(nEvalArrayAgro)) lResultado = true;
            return lResultado;
        }

        private void RecuperarDetalleEstResultados()
        {
            DataSet ds = (new clsCNEvalPyme()).RecuperarDetalleEstResultadosEval(this.idEvalCred);

            DataSet dsPec = (new clsCNEvalPyme()).RecuperarDetalleEstResultadosEvalPecuario(this.idEvalCred);
            this.listInvPecuario = DataTableToList.ConvertTo<clsInventarioPecuario>(dsPec.Tables[0]) as List<clsInventarioPecuario>;

            var listDetEstResEval = DataTableToList.ConvertTo<clsDetEstResEval>(ds.Tables[0]) as List<clsDetEstResEval>;
            var listVentasCostos = DataTableToList.ConvertTo<clsVentasCostos>(ds.Tables[1]) as List<clsVentasCostos>;
            var listCosteoEval = DataTableToList.ConvertTo<clsCosteo>(ds.Tables[2]) as List<clsCosteo>;
            var listVarFlujoCaja = DataTableToList.ConvertTo<clsVarFlujoCajaEval>(ds.Tables[3]) as List<clsVarFlujoCajaEval>;

            // -- Organizar listas
            #region Detalle de los Estado Resultados
            this.listGFamiliares = (from p in listDetEstResEval
                                    where p.idEEFF == EEFF.GastosFamiliares
                                    select p).ToList();

            this.listGPersonales = (from p in listDetEstResEval
                                    where p.idEEFF == EEFF.GastosPersonales
                                    select p).ToList();

            this.listGOperativos = (from p in listDetEstResEval
                                    where p.idEEFF == EEFF.GastosOperativos
                                    select p).ToList();

            this.listOtrosIngresos = (from p in listDetEstResEval
                                      where p.idEEFF == EEFF.OtrosIngresos
                                      select p).ToList();

            this.listOtrosEgresos = (from p in listDetEstResEval
                                     where p.idEEFF == EEFF.OtrosEgresos
                                     select p).ToList();
            #endregion

            #region Detalle de las ventas y costos
            foreach (clsVentasCostos oVnCostos in listVentasCostos)
            {
                oVnCostos.listCosteo = (from p in listCosteoEval
                                        where p.idVentasCostos == oVnCostos.idVentasCostos
                                        select p).ToList();
            }

            this.listVentasCostos = listVentasCostos;
            #endregion

            #region Detalle de las ventas y costos
            this.listCicloVentas = (from p in listVarFlujoCaja
                                    where p.idEEFF == EEFF.CicloVentas
                                    select p).ToList();

            this.listVarGastosFam = (from p in listVarFlujoCaja
                                     where p.idEEFF == EEFF.VariacionGFamiliares
                                     select p).ToList();

            this.listReinversiones = (from p in listVarFlujoCaja
                                      where p.idEEFF == EEFF.Reinversiones
                                      select p).ToList();
            #endregion


            this.conVentasCostos.AsignarDataTables(Evaluacion.DataTableMoneda, this.listDescVentasCostos);
            this.conVentasCostos.AsignarDatos(this.listVentasCostos, this.nTipoCambio, this.idMonedaMA, this.cMonedaSimbolo);

            
            if (Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalCredPyme"]).Equals(this.cTipEvaluacion))
            {
                this.tabControl1.TabPages.Remove(this.tabPage3);   
            }
            else if (Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalCredAgro"]).Equals(this.cTipEvaluacion) ||
                     Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalCredRural"]).Equals(this.cTipEvaluacion))
            {
                if (this.listVentasCostos.Count == 0)
                {
                    this.tabControl1.TabPages.Remove(this.tabPage2);

                    this.conDetalleInvPecuario.AsignarDataTables(dsPec.Tables[1], dsPec.Tables[2], dsPec.Tables[3], dsPec.Tables[4], dsPec.Tables[5], dsPec.Tables[6], dsPec.Tables[7], Evaluacion.DataTableMoneda, dsPec.Tables[8]);
                    this.conDetalleInvPecuario.AsignarDatos(this.listInvPecuario, this.idEvalCred, this.objEvalCred.obtenerNumeroMeses(), this.objEvalCred.dFecActualEval);
                }
                else
                {
                    this.tabControl1.TabPages.Remove(this.tabPage3);   
                }

                this.conDetalleEERR.FrecuenciaMesVentaEnabled = true;
                this.conDetalleEERR.GastosPersonalVisible = false;
            }

            this.conDetalleEERR.AsignarDataTables(Evaluacion.DataTableMoneda, this.listDescGastos);
            this.conDetalleEERR.AsignarDatos(this.listGFamiliares, this.listGPersonales, this.listGOperativos, this.listOtrosIngresos, this.listOtrosEgresos,
                this.listCicloVentas, this.listVarGastosFam, this.listReinversiones,
                this.nTipoCambio, this.idMonedaMA, this.cMonedaSimbolo, this.idEvalCred);

            this.conDetalleEERR.LimpiarSelecciones();
        }

        private string DetalleEstResEnXML(List<clsDetEstResEval> listDetalleEstRes)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idDetEstResEval", typeof(int));
            //dt.Columns.Add("idEvalCred", typeof(int));
            dt.Columns.Add("idEEFF", typeof(int));
            dt.Columns.Add("cDescripcion", typeof(string));
            dt.Columns.Add("idDescripcion", typeof(int));
            dt.Columns.Add("idMoneda", typeof(int));
            dt.Columns.Add("idUnidMedida", typeof(int));
            dt.Columns.Add("nCantidad", typeof(int));
            dt.Columns.Add("nPUnitario", typeof(decimal));
            dt.Columns.Add("nTotal", typeof(decimal));
            dt.Columns.Add("idMonedaMA", typeof(int));
            dt.Columns.Add("nTotalMA", typeof(decimal));

            dt.Columns.Add("nFrecuencia", typeof(int));
            dt.Columns.Add("dMesVenta", typeof(DateTime));
            dt.Columns.Add("nMesVenta", typeof(int));

            foreach (var detEstRes in listDetalleEstRes)
            {
                DataRow row = dt.NewRow();

                row["idDetEstResEval"] = detEstRes.idDetEstResEval;
                //row["idEvalCred"] = detBalGen.idEvalCred;
                row["idEEFF"] = detEstRes.idEEFF;
                row["cDescripcion"] = detEstRes.cDescripcion;
                row["idDescripcion"] = detEstRes.idDescripcion;
                row["idMoneda"] = detEstRes.idMoneda;
                row["idUnidMedida"] = detEstRes.idUnidMedida;
                row["nCantidad"] = detEstRes.nCantidad;
                row["nPUnitario"] = detEstRes.nPUnitario;
                row["nTotal"] = detEstRes.nTotal;
                row["idMonedaMA"] = detEstRes.idMonedaMA;
                row["nTotalMA"] = detEstRes.nTotalMA;

                row["nFrecuencia"] = detEstRes.nFrecuencia;
                row["dMesVenta"] = detEstRes.dMesVenta;
                row["nMesVenta"] = detEstRes.nMesVenta;

                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "DetEstResEval", "Item");
        }

        private string DetalleVentasCostosEnXML(List<clsVentasCostos> listVentasCostos)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("idVentasCostos", typeof(int));
            //dt.Columns.Add("idEvalCred", typeof(int));
            dt.Columns.Add("idTipoActividad", typeof(int));
            dt.Columns.Add("cDescripcion", typeof(string));
            dt.Columns.Add("idDescripcion", typeof(int));
            dt.Columns.Add("idMoneda", typeof(int));
            dt.Columns.Add("idUnidMedida", typeof(int));
            dt.Columns.Add("cUnidMedida", typeof(string));
            dt.Columns.Add("nCantidad", typeof(decimal));
            dt.Columns.Add("nPUnitVenta", typeof(decimal));
            dt.Columns.Add("nPUnitCosto", typeof(decimal));
            dt.Columns.Add("nTotalVentas", typeof(decimal));
            dt.Columns.Add("nTotalCostos", typeof(decimal));
            dt.Columns.Add("idMonedaMA", typeof(int));
            dt.Columns.Add("nTotalVentasMA", typeof(decimal));
            dt.Columns.Add("nTotalCostosMA", typeof(decimal));
            //dt.Columns.Add("nUtilidadBruta", typeof(decimal));
            //dt.Columns.Add("nMargenVentas", typeof(decimal));
            dt.Columns.Add("nFrecuencia", typeof(int));
            dt.Columns.Add("dMesVenta", typeof(DateTime));
            dt.Columns.Add("nMesVenta", typeof(int));

            foreach (var detVeCo in listVentasCostos)
            {
                DataRow row = dt.NewRow();

                row["idVentasCostos"] = detVeCo.idVentasCostos;
                //row["idEvalCred"] = detVeCo.idEvalCred;
                row["idTipoActividad"] = detVeCo.idTipoActividad;
                row["cDescripcion"] = detVeCo.cDescripcion;
                row["idDescripcion"] = detVeCo.idDescripcion;
                row["idMoneda"] = detVeCo.idMoneda;
                row["idUnidMedida"] = detVeCo.idUnidMedida;
                row["cUnidMedida"] = detVeCo.cUnidMedida;
                row["nCantidad"] = detVeCo.nCantidad;
                row["nPUnitVenta"] = detVeCo.nPUnitVenta;
                row["nPUnitCosto"] = detVeCo.nPUnitCosto;
                row["nTotalVentas"] = detVeCo.nTotalVentas;
                row["nTotalCostos"] = detVeCo.nTotalCostos;
                row["idMonedaMA"] = detVeCo.idMonedaMA;
                row["nTotalVentasMA"] = detVeCo.nTotalVentasMA;
                row["nTotalCostosMA"] = detVeCo.nTotalCostosMA;
                //row["nUtilidadBruta"] = detVeCo.nUtilidadBruta;
                //row["nMargenVentas"] = detVeCo.nMargenVentas;
                row["nFrecuencia"] = detVeCo.nFrecuencia;
                row["dMesVenta"] = detVeCo.dMesVenta;
                row["nMesVenta"] = detVeCo.nMesVenta;

                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "VentasCostos", "Item");
        }

        private string DetalleCosteoEnXML(List<clsCosteo> listCosteo)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idCosteo", typeof(int));
            dt.Columns.Add("idEvalCred", typeof(int));
            dt.Columns.Add("idVentasCostos", typeof(int));
            dt.Columns.Add("idTipoCosteo", typeof(int));
            dt.Columns.Add("cDescripcion", typeof(string));
            dt.Columns.Add("idDescripcion", typeof(int));
            dt.Columns.Add("idMoneda", typeof(int));
            dt.Columns.Add("idUnidMedida", typeof(int));
            dt.Columns.Add("cUnidMedida", typeof(string));
            dt.Columns.Add("nCantidad", typeof(decimal));
            dt.Columns.Add("nPUnitario", typeof(decimal));
            dt.Columns.Add("nTotal", typeof(decimal));
            dt.Columns.Add("idMonedaMA", typeof(int));
            dt.Columns.Add("nTotalMA", typeof(decimal));
            dt.Columns.Add("nFrecuencia", typeof(int));
            dt.Columns.Add("dMesVenta", typeof(DateTime));
            dt.Columns.Add("nMesVenta", typeof(int));

            foreach (var detCosteo in listCosteo)
            {
                DataRow row = dt.NewRow();

                row["idCosteo"] = detCosteo.idCosteo;
                row["idEvalCred"] = detCosteo.idEvalCred;
                row["idVentasCostos"] = detCosteo.idVentasCostos;
                row["idTipoCosteo"] = detCosteo.idTipoCosteo;
                row["cDescripcion"] = detCosteo.cDescripcion;
                row["idDescripcion"] = detCosteo.idDescripcion;
                row["idMoneda"] = detCosteo.idMoneda;
                row["idUnidMedida"] = detCosteo.idUnidMedida;
                row["cUnidMedida"] = detCosteo.cUnidMedida;
                row["nCantidad"] = detCosteo.nCantidad;
                row["nPUnitario"] = detCosteo.nPUnitario;
                row["nTotal"] = detCosteo.nTotal;
                row["idMonedaMA"] = detCosteo.idMonedaMA;
                row["nTotalMA"] = detCosteo.nTotalMA;
                row["nFrecuencia"] = detCosteo.nFrecuencia;
                row["dMesVenta"] = detCosteo.dMesVenta;
                row["nMesVenta"] = detCosteo.nMesVenta;

                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "Costeo", "Item");
        }

        private string DetalleVarFCajaEnXML(List<clsVarFlujoCajaEval> listDetalleVarFCaja)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idVarFlujoCajaEval", typeof(int));
            //dt.Columns.Add("idEvalCred", typeof(int));
            dt.Columns.Add("idEEFF", typeof(int));
            dt.Columns.Add("dFecha", typeof(DateTime));
            dt.Columns.Add("nMes", typeof(int));
            dt.Columns.Add("nMonto", typeof(decimal));

            foreach (var detVarFC in listDetalleVarFCaja)
            {
                DataRow row = dt.NewRow();

                row["idVarFlujoCajaEval"] = detVarFC.idVarFlujoCajaEval;
                //row["idEvalCred"] = detVarFC.idEvalCred;
                row["idEEFF"] = detVarFC.idEEFF;
                row["dFecha"] = detVarFC.dFecha;
                row["nMes"] = detVarFC.nMes;
                row["nMonto"] = detVarFC.nMonto;

                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "VarFlujoCajaEval", "Item");
        }
        #endregion

        #region Eventos
        private void FormDetalleEstRes_Load(object sender, EventArgs e)
        {
            this.conDetalleInvPecuario.inicializarControl();
            RecuperarDetalleEstResultados();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.conDetalleEERR.LimpiarSelecciones();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            List<clsDetEstResEval> listDetalleEstRes = new List<clsDetEstResEval>();
            List<clsVentasCostos> listDetalleVenCos = new List<clsVentasCostos>();
            List<clsCosteo> listDetalleCosteo = new List<clsCosteo>();
            List<clsVarFlujoCajaEval> listDetalleVarFCaja = new List<clsVarFlujoCajaEval>();

            #region Detalle de los Estados Resultados
            foreach (clsDetEstResEval detBG in this.listGFamiliares)
                listDetalleEstRes.Add(detBG);

            foreach (clsDetEstResEval detBG in this.listGPersonales)
                listDetalleEstRes.Add(detBG);

            foreach (clsDetEstResEval detBG in this.listGOperativos)
                listDetalleEstRes.Add(detBG);

            foreach (clsDetEstResEval detBG in this.listOtrosIngresos)
                listDetalleEstRes.Add(detBG);

            foreach (clsDetEstResEval detBG in this.listOtrosEgresos)
                listDetalleEstRes.Add(detBG);
            #endregion

            #region Detalle de las Ventas y Costos
            foreach (clsVentasCostos detVC in this.listVentasCostos)
            {
                listDetalleVenCos.Add(detVC);

                foreach (clsCosteo detCo in detVC.listCosteo)
                    listDetalleCosteo.Add(detCo);
            }
            #endregion

            #region Ciclo de Ventas
            foreach (clsVarFlujoCajaEval detVFC in this.listCicloVentas)
            {
                detVFC.nMonto = (detVFC.nPorcentaje >= 0) ? detVFC.nPorcentaje / 100 : 1;
                listDetalleVarFCaja.Add(detVFC);
            }

            foreach (clsVarFlujoCajaEval detVFC in this.listVarGastosFam)
            {
                listDetalleVarFCaja.Add(detVFC);
            }

            foreach (clsVarFlujoCajaEval detVFC in this.listReinversiones)
            {
                listDetalleVarFCaja.Add(detVFC);
            }
            #endregion

            // -- Preparación de datos
            string xmlDetalleEstRes = DetalleEstResEnXML(listDetalleEstRes);
            string xmlDetalleVenCos = DetalleVentasCostosEnXML(listDetalleVenCos);
            string xmlDetalleCosteo = DetalleCosteoEnXML(listDetalleCosteo);
            string xmlDetalleVarFCaja = DetalleVarFCajaEnXML(listDetalleVarFCaja);

            (new clsCNEvalPyme()).ActDetalleEstadosResultadoslEval(this.idEvalCred, xmlDetalleEstRes, xmlDetalleVenCos, xmlDetalleCosteo, xmlDetalleVarFCaja);

            this.conVentasCostos.Enabled = false;
            this.conDetalleEERR.Enabled = false;
            this.conDetalleInvPecuario.Enabled = false;

            this.btnEditar.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;

            this.lGuardado = true;

            RecuperarDetalleEstResultados();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.conVentasCostos.Enabled = true;
            this.conDetalleEERR.Enabled = true;
            this.conDetalleInvPecuario.Enabled = true;

            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.conVentasCostos.Enabled = false;
            this.conVentasCostos.LimpiarFormulario();
            this.conDetalleEERR.Enabled = false;
            this.conDetalleInvPecuario.Enabled = false;

            this.btnEditar.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;

            RecuperarDetalleEstResultados();
        }
        #endregion
    }
}
