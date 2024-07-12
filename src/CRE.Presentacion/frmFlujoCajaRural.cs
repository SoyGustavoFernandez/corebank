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
    public partial class frmFlujoCajaRural : frmBase
    {
        #region Variables

        private int idEvalCred;
        private int idTipoPeriodo;
        private int idPeriodo;
        private int nCuotas;
        private int nPlazoCredMeses;
        private decimal nMontoPropuesto;
        private decimal nMontoCaja;
        private decimal nTEM;
        private decimal nTEA;
        private DateTime dFechaDesembolso;
        private DateTime dFechaPrimeraCuota;
        private DateTime dFechaMinima;
        private DataTable dtCalendarioPlanPago;
        private clsEvalCred objEvalCredito;
        private List<clsFlujoCajaRural> listFlujoCaja;
        private List<clsDisenioCredito> listDisenioCredito;
        private List<clsOtrosIngresosEvalRuralM> listOtrosIngresosMaestro;
        private List<clsOtrosIngresosEvalRuralD> listOtrosIngresosDetalle;
        private List<clsOtrosEgresosEvalRuralM> listOtrosEgresosMaestro;
        private List<clsOtrosEgresosEvalRuralD> listOtrosEgresosDetalle;
        public bool lGuardado = false;

        enum eTipoPeriodoCred 
        { 
            FechaFija = 1, 
            PeriodoFijo = 2, 
            CuotasLibres = 3 
        }
        enum ePeriodoCred
        {
            Diario = 1,
            Quinquenal = 2,
            Mensual = 3,
            Bimensual = 4,
            Trimestral = 5,
            Cuatrimestral = 6,
            Quinquemestral = 7,
            Semestral = 8,
            Anual = 9,
            Unicuota = 10
        }

        #endregion


        #region Métodos Públicos

        public frmFlujoCajaRural(int idEvalCred, int idTipoPeriodo, int idPeriodo, int nCuotas, decimal nMontoPropuesto, decimal nMontoCaja,
            decimal nTEM, decimal nTEA, DateTime dFechaDesembolso, DateTime dFechaPrimeraCuota, DataTable CalendarioPlanPago, DateTime fechaMinima)
        {
            this.idEvalCred = idEvalCred;
            this.idTipoPeriodo = idTipoPeriodo;
            this.idPeriodo = idPeriodo;
            this.nCuotas = nCuotas;
            this.nMontoPropuesto = nMontoPropuesto;
            this.nMontoCaja = nMontoCaja;
            this.nTEM = nTEM;
            this.nTEA = nTEA;
            this.dFechaDesembolso = dFechaDesembolso;
            this.dFechaPrimeraCuota = dFechaPrimeraCuota;
            this.dFechaMinima = fechaMinima;
            this.dtCalendarioPlanPago = CalendarioPlanPago;
            
            DataTable dtConfDisCred = new clsCNEvalCrediRural().ObtenerConfiguracionDiseCredRural(this.idEvalCred);

            if (dtConfDisCred.Rows.Count > 0 && this.idTipoPeriodo == (int)eTipoPeriodoCred.CuotasLibres)
                this.nPlazoCredMeses = Convert.ToInt32(dtConfDisCred.Rows[0]["nPlazoMeses"]);
            else
            {
                if (this.idTipoPeriodo == (int)eTipoPeriodoCred.CuotasLibres)
                    this.nPlazoCredMeses = 12;
                else if (this.idTipoPeriodo == (int)eTipoPeriodoCred.PeriodoFijo && this.idPeriodo == (int)ePeriodoCred.Mensual)
                    this.nPlazoCredMeses = this.nCuotas;
                else if (this.idTipoPeriodo == (int)eTipoPeriodoCred.PeriodoFijo && this.idPeriodo == (int)ePeriodoCred.Unicuota)
                    this.nPlazoCredMeses = Math.Abs((this.dFechaPrimeraCuota.Month - this.dFechaDesembolso.Month) + 12 * (this.dFechaPrimeraCuota.Year - this.dFechaDesembolso.Year));
            }

            InitializeComponent();

            conFlujoCajaRural.Enabled = false;
            conOtrosIngEgr.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        public decimal getMontoPropuesto()
        {
            return this.conFlujoCajaRural.getMontoPropuesto();
        }

        public DateTime getFechaPriCuota()
        {
            return this.conFlujoCajaRural.getFechaPriCuota();
        }

        #endregion


        #region Métodos Privados

        private void RecuperarDetalleFlujoCaja()
        {
            DataSet dsFlujoCaja = new clsCNEvalCrediRural().GeneraFlujoCajaRural
                (this.idEvalCred, 
                this.nPlazoCredMeses, 
                this.idTipoPeriodo, 
                this.idPeriodo, 
                this.dFechaDesembolso,
                this.nMontoCaja);

            this.listFlujoCaja = DataTableToList.ConvertTo<clsFlujoCajaRural>(dsFlujoCaja.Tables[0]) as List<clsFlujoCajaRural>;
            this.listDisenioCredito = DataTableToList.ConvertTo<clsDisenioCredito>(dsFlujoCaja.Tables[1]) as List<clsDisenioCredito>;
            this.objEvalCredito = (DataTableToList.ConvertTo<clsEvalCred>(dsFlujoCaja.Tables[2]) as List<clsEvalCred>).FirstOrDefault();

            DataSet dsOtrosIngresos = new clsCNEvalCrediRural().GeneraOtrosIngresosRural(this.idEvalCred);
            this.listOtrosIngresosMaestro = DataTableToList.ConvertTo<clsOtrosIngresosEvalRuralM>(dsOtrosIngresos.Tables[0]) as List<clsOtrosIngresosEvalRuralM>;
            this.listOtrosIngresosDetalle = DataTableToList.ConvertTo<clsOtrosIngresosEvalRuralD>(dsOtrosIngresos.Tables[1]) as List<clsOtrosIngresosEvalRuralD>;
            this.listOtrosEgresosMaestro = DataTableToList.ConvertTo<clsOtrosEgresosEvalRuralM>(dsOtrosIngresos.Tables[2]) as List<clsOtrosEgresosEvalRuralM>;
            this.listOtrosEgresosDetalle = DataTableToList.ConvertTo<clsOtrosEgresosEvalRuralD>(dsOtrosIngresos.Tables[3]) as List<clsOtrosEgresosEvalRuralD>;

            foreach (var item in this.listOtrosIngresosMaestro)
            {
                item.listaDetalle = this.listOtrosIngresosDetalle.FindAll(x => x.idOtrIngM == item.idOtrIngM);
            }

            this.conFlujoCajaRural.AsignarDatos(this.listFlujoCaja, 
                                                this.listDisenioCredito, 
                                                this.objEvalCredito,
                                                this.idTipoPeriodo,
                                                this.idPeriodo,
                                                this.nPlazoCredMeses,
                                                this.nMontoPropuesto,
                                                this.nMontoCaja,
                                                this.nTEM,
                                                this.dFechaDesembolso,
                                                this.dtCalendarioPlanPago,
                                                this.dFechaMinima);

            this.conOtrosIngEgr.AsignarDatos(this.listOtrosIngresosMaestro,
                                             this.listOtrosEgresosMaestro,
                                             this.listOtrosEgresosDetalle,
                                             this.dFechaDesembolso, 
                                             this.objEvalCredito);

            conFlujoCajaRural_nudCuotas_ValueChange(null,null);
        }

        private string DisenioCreditoEnXML(List<clsDisenioCredito> lstDisenioCredito)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("dFecha", typeof(DateTime));
            dt.Columns.Add("cMesCuota", typeof(string));
            dt.Columns.Add("nDiaDesembolso", typeof(int));
            dt.Columns.Add("nMontoCuota", typeof(decimal));
            dt.Columns.Add("nCapIntSeg", typeof(decimal));
            dt.Columns.Add("nExedenteFinal", typeof(decimal));


            foreach (var item in lstDisenioCredito)
            {
                DataRow row = dt.NewRow();
                row["dFecha"] = item.dFecha;
                row["cMesCuota"] = item.cMesCuota;
                row["nDiaDesembolso"] = item.nDiaDesembolso;
                row["nMontoCuota"] = item.nMontoCuota;
                row["nCapIntSeg"] = item.nCapIntSeg;
                row["nExedenteFinal"] = item.nExedenteFinal;
                dt.Rows.Add(row);
            }

            return clsUtils.ConvertToXML(dt.Copy(), "DisenioCredito", "Item");
        }

        #endregion


        #region Eventos

        private void FormFlujoCaja_Load(object sender, EventArgs e)
        {
            this.conFlujoCajaRural.inicializarControl();
            this.conOtrosIngEgr.inicializarControl(this.nPlazoCredMeses, this.dFechaDesembolso);
            RecuperarDetalleFlujoCaja();
        }

        private void conFlujoCajaRural_nudCuotas_ValueChange(object sender, EventArgs e) 
        {
            conFlujoCajaRural.ActualizaDatosDisenioCrediticio();
            this.nPlazoCredMeses = conFlujoCajaRural.getPlazoCuotasLibres();
            conOtrosIngEgr.ActualizaDatosOtrosIngEgr();
        }

        private void conOtrosIngEgr_btnGrabarOtrIng_click(object sender, EventArgs e)
        {
            conOtrosIngEgr.GrabarOtrosIngresosEgresos();
            conFlujoCajaRural_nudCuotas_ValueChange(sender, e); 
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            this.listDisenioCredito = this.conFlujoCajaRural.RecuperaDisenioCredito();
            
            List<clsDisenioCredito> lstDisenioCredito = new List<clsDisenioCredito>();
            

            foreach (clsDisenioCredito item in this.listDisenioCredito)
            {
                lstDisenioCredito.Add(item);
            }

            //Remplazando fechas con dia asignado
            foreach (var item in lstDisenioCredito)
            {
                item.dFecha = new DateTime(item.dFecha.Value.Year, item.dFecha.Value.Month, item.nDiaDesembolso);
            }

            string xmlDisenioCredito = DisenioCreditoEnXML(lstDisenioCredito);
            
            (new clsCNEvalCrediRural()).GuardarDisenioCredito(this.idEvalCred, xmlDisenioCredito);

            this.nMontoPropuesto = getMontoPropuesto();
            DateTime dFechaPriCuota = getFechaPriCuota();
            int cuotas = this.listDisenioCredito.FindAll(x => x.nMontoCuota > 0).Count();
            this.nPlazoCredMeses = conFlujoCajaRural.getPlazoCuotasLibres();
            int nAlerta = conFlujoCajaRural.getNumeroAlerta();

            new clsCNEvalCrediRural().GuardarConfiguracionDiseCredRural(
                this.idEvalCred,
                this.nMontoPropuesto,
                this.idTipoPeriodo,
                this.idPeriodo,
                this.nPlazoCredMeses,
                cuotas,
                this.nTEA,
                this.dFechaDesembolso,
                dFechaPriCuota,
                nAlerta);

            RecuperarDetalleFlujoCaja();

            this.lGuardado = true;
            conFlujoCajaRural.Enabled = false;
            conOtrosIngEgr.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEditar.Enabled = true;
        }

        private void btnEditar_click(object sender, EventArgs e)
        {
            conFlujoCajaRural.Enabled = true;
            conOtrosIngEgr.Enabled = true;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEditar.Enabled = false;
        }

        private void btnCancelar_click(object sender, EventArgs e)
        {
            RecuperarDetalleFlujoCaja();
            conFlujoCajaRural.Enabled = false;
            conOtrosIngEgr.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEditar.Enabled = true;
        }

        #endregion
    }
}
