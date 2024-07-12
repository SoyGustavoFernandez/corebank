using EntityLayer;
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
using CRE.CapaNegocio;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class frmDetalleBalGen : frmBase
    {
        private int idEvalCred;
        private DateTime dFecActualEval;
        private int nCuotas;

        private List<clsDetBalGenEval> listMaqEquipos;
        private List<clsDetBalGenEval> listInventario;
        private List<clsDetBalGenEval> listInmuebles;
        private List<clsDescripcionEval> listDescripcionEval;
        private List<clsIngresoVentaActivoRural> listIngVtaAtvRural;
        private List<clsFechasIngresoVentaInv> listFechas;
        private List<clsUnidadMedida> listUnidadesMedida;

        private string cTipEvaluacion;

        private int idMonedaMA;
        private decimal nTipoCambio;
        private string cMonedaSimbolo;
        private decimal nCajaInicial;

        public bool lGuardado = false;

        public frmDetalleBalGen()
        {
            InitializeComponent();
        }

        public frmDetalleBalGen(List<clsDescripcionEval> _listDescripcionEval,
            int _idEvalCred, decimal _nTipoCambio, int _idMonedaMA, string _cMonedaSimbolo, string _cTipEvaluacion, DateTime? dFecActualEval = null, int nCuotas = 0)
        {
            InitializeComponent();

            if (dFecActualEval != null)
                this.dFecActualEval = dFecActualEval.Value;

            if (nCuotas != 0)
                this.nCuotas = nCuotas;

            if (_cTipEvaluacion != Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalCredRural"]))
                this.tabControl1.TabPages.Remove(tabPage2);

            this.listMaqEquipos = new List<clsDetBalGenEval>();
            this.listInventario = new List<clsDetBalGenEval>();
            this.listInmuebles = new List<clsDetBalGenEval>();

            this.idEvalCred = _idEvalCred;

            this.nTipoCambio = _nTipoCambio;
            this.idMonedaMA = _idMonedaMA;
            this.cMonedaSimbolo = _cMonedaSimbolo;

            this.btnGrabar.Enabled = false;
            this.btnEditar.Enabled = true;
            this.btnCancelar.Enabled = false;

            this.conDetalleBBGG.Enabled = false;

            if (_cTipEvaluacion == Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalCredRural"]))
                this.conIngresoVentaActivoRural.Enabled = false;
                

            this.listDescripcionEval = _listDescripcionEval;
            this.cTipEvaluacion = _cTipEvaluacion;
        }

        #region Métodos Públicos
        public decimal TotalMaqEquipos()
        {
            return this.listMaqEquipos.Sum(x => x.nTotalMA);
        }

        public decimal TotalHerramOtros()
        {
            return (from p in this.listInventario
                    where p.nCodigoInv == TipoInventario.PlantelFijo
                    select p).Sum(x => x.nTotalMA);
        }

        public decimal TotalInventario()
        {
            return (from p in this.listInventario
                    where p.nCodigoInv != TipoInventario.PlantelFijo
                    select p).Sum(x => x.nTotalMA);
        }

        public decimal TotalInmuebles()
        {
            return this.listInmuebles.Sum(x => x.nTotalMA);
        }

        public decimal CajaInicial()
        {
            return this.nCajaInicial;
        }

        public List<clsDetBalGenEval> ListaInventario()
        {
            return this.listInventario;
        }
        #endregion

        #region Métodos Privados
        private string DetalleBalGenEnXML(List<clsDetBalGenEval> listDetalleBalGen)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idDetBalGenEval", typeof(int));
            //dt.Columns.Add("idEvalCred", typeof(int));
            dt.Columns.Add("idEEFF", typeof(int));
            dt.Columns.Add("cDescripcion", typeof(string));
            dt.Columns.Add("idDescripcion", typeof(int));
            dt.Columns.Add("idMoneda", typeof(int));
            dt.Columns.Add("idUnidMedida", typeof(int));
            dt.Columns.Add("cUnidMedida", typeof(string));
            dt.Columns.Add("nCantidad", typeof(int));
            dt.Columns.Add("nPUnitario", typeof(decimal));
            dt.Columns.Add("nTotal", typeof(decimal));
            dt.Columns.Add("idMonedaMA", typeof(int));
            dt.Columns.Add("nTotalMA", typeof(decimal));
            dt.Columns.Add("nCodigoInv", typeof(int));

            foreach (var detBalGen in listDetalleBalGen)
            {
                DataRow row = dt.NewRow();

                row["idDetBalGenEval"] = detBalGen.idDetBalGenEval;
                //row["idEvalCred"] = detBalGen.idEvalCred;
                row["idEEFF"] = detBalGen.idEEFF;
                row["cDescripcion"] = detBalGen.cDescripcion;
                row["idDescripcion"] = detBalGen.idDescripcion;
                row["idMoneda"] = detBalGen.idMoneda;
                row["idUnidMedida"] = detBalGen.idUnidMedida;
                row["cUnidMedida"] = detBalGen.cUnidMedida;
                row["nCantidad"] = detBalGen.nCantidad;
                row["nPUnitario"] = detBalGen.nPUnitario;
                row["nTotal"] = detBalGen.nTotal;
                row["idMonedaMA"] = detBalGen.idMonedaMA;
                row["nTotalMA"] = detBalGen.nTotalMA;
                row["nCodigoInv"] = detBalGen.nCodigoInv;

                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "DetBalGenEval", "Item");
        }

        private string IngresoVentaActivosEnXML(List<clsIngresoVentaActivoRural> listIngVtaAtvRural)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("cProducto", typeof(string));
            dt.Columns.Add("idUnidadMedida", typeof(int));
            dt.Columns.Add("nCantidad", typeof(decimal));
            dt.Columns.Add("nKgxGanado", typeof(decimal));
            dt.Columns.Add("nPrecio", typeof(decimal));
            dt.Columns.Add("nTotal", typeof(decimal));
            dt.Columns.Add("dFechaVenta", typeof(int));

            foreach (var item in listIngVtaAtvRural)
            {
                DataRow row = dt.NewRow();
                row["cProducto"] = item.cProducto;
                row["idUnidadMedida"] = item.idUnidadMedida;
                row["nCantidad"] = item.nCantidad;
                row["nKgxGanado"] = item.nKgxGanado;
                row["nPrecio"] = item.nPrecio;
                row["nTotal"] = item.nTotal;
                row["dFechaVenta"] = item.dFechaVenta;
                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "DetIngVtaAtvRural", "Item");
        }

        private void RecuperarDetalleBalGeneral()
        {
            DataSet ds = (new clsCNEvalPyme()).RecuperarDetalleBalGeneralEval(this.idEvalCred);

            var listDetBalGenEval = DataTableToList.ConvertTo<clsDetBalGenEval>(ds.Tables[0]) as List<clsDetBalGenEval>;


            if (this.cTipEvaluacion == Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalCredRural"]))
            {
                var listUnidadesMedida = DataTableToList.ConvertTo<clsUnidadMedida>(ds.Tables[3]) as List<clsUnidadMedida>;
                this.listUnidadesMedida = listUnidadesMedida;

                DataTable dtIngVtaAtvRural = new clsCNEvalCrediRural().GenerarIngresosVentaInventario(this.idEvalCred);
                var listIngVtaAtvRural = DataTableToList.ConvertTo<clsIngresoVentaActivoRural>(dtIngVtaAtvRural) as List<clsIngresoVentaActivoRural>;
                this.listIngVtaAtvRural = listIngVtaAtvRural;

                DateTime dFecActualEval = this.dFecActualEval;

                List<clsFechasIngresoVentaInv> listFechas = new List<clsFechasIngresoVentaInv>();
                for (int i = 0; i < Convert.ToInt32(clsVarApl.dicVarGen["nPlazoMaxEvalRural"]); i++)
                {
                    clsFechasIngresoVentaInv fechas = new clsFechasIngresoVentaInv();
                    fechas.dFechaVenta = Convert.ToInt32(dFecActualEval.ToString("yyyyMM"));
                    fechas.cFecha = dFecActualEval.ToString("MMMM yyyy");

                    listFechas.Add(fechas);
                    dFecActualEval = dFecActualEval.AddMonths(1);
                }
                this.listFechas = listFechas;
            }


            // -- Organizar listas
            this.listMaqEquipos = (from p in listDetBalGenEval
                                   where p.idEEFF == EEFF.MaqEquipos
                                   select p).ToList();

            this.listInmuebles = (from p in listDetBalGenEval
                                  where p.idEEFF == EEFF.Inmuebles
                                  select p).ToList();

            this.listInventario = (from p in listDetBalGenEval
                                   where p.idEEFF == EEFF.Inventario
                                   select p).ToList().Where(x => x.nCodigoInv == 4 || x.nCodigoInv == 5 || x.nCodigoInv == 6 || x.nCodigoInv == 7 || x.nCodigoInv == 9).ToList();

            DataTable dtEvalCred = ds.Tables[1];

            this.nCajaInicial = Convert.ToInt32(dtEvalCred.Rows[0][0]);

            DataTable dtTipoInventario = ds.Tables[2];
            if (this.cTipEvaluacion == "3, 6")
            {
                dtTipoInventario = dtTipoInventario.AsEnumerable()
                                        .Where(item =>
                                            // item.Field<int>("nCodigo") == 10 || 
                                            item.Field<int>("nCodigo") == 4 ||
                                            item.Field<int>("nCodigo") == 5 ||
                                            item.Field<int>("nCodigo") == 6 ||
                                            item.Field<int>("nCodigo") == 7 ||
                                            item.Field<int>("nCodigo") == 9
                                        // item.Field<int>("nCodigo") == 11
                                        ).CopyToDataTable();
            }

            // --
            if (Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalCredPyme"]).Equals(this.cTipEvaluacion)) { }
            else if (Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalCredAgro"]).Equals(this.cTipEvaluacion))
                this.conDetalleBBGG.InventarioAgroEnabled = true;

            // -- 
            this.conDetalleBBGG.AsignarDataTables(dtTipoInventario, this.listDescripcionEval);
            this.conDetalleBBGG.AsignarDatos(this.listMaqEquipos, this.listInventario, this.listInmuebles, this.nTipoCambio, this.idMonedaMA, this.cMonedaSimbolo, this.nCajaInicial, this.cTipEvaluacion);

            if (this.cTipEvaluacion == Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalCredRural"]))
                this.conIngresoVentaActivoRural.AsignarDatos(this.idEvalCred, this.listIngVtaAtvRural, this.listUnidadesMedida, this.listFechas);
        }
        #endregion

        #region Eventos
        private void FormDetalleBalGen_Load(object sender, EventArgs e)
        {
            RecuperarDetalleBalGeneral();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            this.nCajaInicial = this.conDetalleBBGG.CajaInicial();

            List<clsDetBalGenEval> listDetalleBalGen = new List<clsDetBalGenEval>();
            foreach (clsDetBalGenEval detBG in this.listMaqEquipos)
            {
                listDetalleBalGen.Add(detBG);
            }

            foreach (clsDetBalGenEval detBG in this.listInventario)
            {
                listDetalleBalGen.Add(detBG);
            }

            foreach (clsDetBalGenEval detBG in this.listInmuebles)
            {
                listDetalleBalGen.Add(detBG);
            }


            string xmlIngresoVentaActivos = string.Empty;
            List<clsIngresoVentaActivoRural> listIngVtaAtvRural = new List<clsIngresoVentaActivoRural>();

            if (this.cTipEvaluacion == Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalCredRural"]))
            {
                foreach (clsIngresoVentaActivoRural detIVA in this.listIngVtaAtvRural)
                {
                    listIngVtaAtvRural.Add(detIVA);
                }
                xmlIngresoVentaActivos = IngresoVentaActivosEnXML(listIngVtaAtvRural);
            }

            string xmlDetalleBalGen = DetalleBalGenEnXML(listDetalleBalGen);

            if (xmlIngresoVentaActivos != string.Empty)
                (new clsCNEvalCrediRural()).GuardaDetalleBalGenEvalRural(this.idEvalCred, this.nCajaInicial, xmlDetalleBalGen, xmlIngresoVentaActivos);
            else
                (new clsCNEvalPyme()).ActDetalleBalanceGeneralEval(this.idEvalCred, this.nCajaInicial, xmlDetalleBalGen);

            if (this.cTipEvaluacion == Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalCredRural"]))
                this.conIngresoVentaActivoRural.Enabled = false;

            this.conDetalleBBGG.Enabled = false;

            this.btnEditar.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;

            this.lGuardado = true;

            RecuperarDetalleBalGeneral();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.conDetalleBBGG.Enabled = true;

            if (this.cTipEvaluacion == Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalCredRural"]))
                this.conIngresoVentaActivoRural.Enabled = true;

            this.btnEditar.Enabled = false;
            this.btnGrabar.Enabled = true;
            this.btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.conDetalleBBGG.Enabled = false;

            if (this.cTipEvaluacion == Convert.ToString(clsVarApl.dicVarGen["cIDsTipEvalCredRural"]))
                this.conIngresoVentaActivoRural.Enabled = false;

            this.btnEditar.Enabled = true;
            this.btnGrabar.Enabled = false;
            this.btnCancelar.Enabled = false;

            RecuperarDetalleBalGeneral();
        }
        #endregion
    }
}
