using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.Funciones;
using CRE.CapaNegocio;

namespace CRE.ControlBase
{
    public partial class ConIndicadores : UserControl
    {
        private List<clsBalGenEval> listBalGenEval;
        private List<clsEstResEval> listEstResEval;
        private List<clsIndicadorEval> listIndiFinanc;
        private List<clsDetBalGenEval> listInventario;
        private List<clsFlujoCajaRural> listFlujoCaja;
        private List<clsDisenioCredito> listDisenioCredito;

        private decimal nMontoProp;
        private decimal nCuotaAprox;
        private decimal nDestinoCapitalTrabajo;
        private decimal nPtjeEvalCualitativa;
        private decimal nTotalPasivoAC;                 // Total Pasivo de amplicación y compra de deuda
        private decimal nCapitalParaComercio;
        private int nCodigoSectorEconomico;

        private bool lValidacionEnabled;
        private bool lDescripcionReglaEnabled;

        private int idTipEvalCred;
        private decimal nVentaMensualMarginal;
        private decimal nTotalPlantelFijo;
        private decimal nTotalSaca;
        private int idEvalCred;
        private clsCNEvalAgrop objCapaNegocio;

        private int idProducto = 0;
        private int nCuotasMnesuales;
        private int idTipoPeriodo;
        private int idPeriodo;
        private int plazoCuotaLibre;
        private DateTime dFechaDesembolso;
        private decimal nTea;

        enum eTipoPeriodoCred { FechaFija = 1, PeriodoFijo = 2, CuotasLibres = 3 }
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

        public ConIndicadores()
        {
            InitializeComponent();
            FormatearDataGridView();

            this.nMontoProp = 0;
            this.nCuotaAprox = 0;
            this.nDestinoCapitalTrabajo = 0;
            this.nPtjeEvalCualitativa = 0;
            this.nTotalPasivoAC = 0;                    // Total Pasivo de amplicación y compra de deuda
            this.nCapitalParaComercio = 0;
            this.nCodigoSectorEconomico = 0;

            this.listInventario = new List<clsDetBalGenEval>();
            this.objCapaNegocio = new clsCNEvalAgrop();

            this.lValidacionEnabled = true;
            this.lDescripcionReglaEnabled = true;
        }

        #region "Properties"
        public bool ValidacionEnabled
        {
            get { return this.lValidacionEnabled; }
            set { this.lValidacionEnabled = value; }
        }

        public bool DescripcionReglaEnabled
        {
            get { return this.lDescripcionReglaEnabled; }
            set { this.lDescripcionReglaEnabled = value; }
        }
        #endregion

        #region Métodos Públicos
        public void AsignarDatos(List<clsIndicadorEval> _listIndiFinanc, List<clsBalGenEval> _listBalGenEval, List<clsEstResEval> _listEstResEval, List<clsDetBalGenEval> _listInventario,
            decimal _nMontoProp, decimal _nCuotaAprox, decimal _nDestinoCapitalTrabajo, decimal _nTotalPasivoAC, decimal _nCapitalParacomercio, int _nCodigoSectorEconomico, int _idTipEvalCred,
            decimal _nTotalPlantelFijo, decimal _nTotalSaca, int _idEvalCred, int _idProducto = 0)
        {
            idProducto = _idProducto;
            this.dtgIndiFinanc.CellFormatting -= new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgIndiFinanc_CellFormatting);
            this.dtgIndiFinanc.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgIndiFinanc_DataBindingComplete);

            this.nMontoProp = _nMontoProp;
            this.nCuotaAprox = _nCuotaAprox;
            this.nDestinoCapitalTrabajo = _nDestinoCapitalTrabajo;
            this.nTotalPasivoAC = _nTotalPasivoAC;
            this.nCapitalParaComercio = _nCapitalParacomercio;
            this.nCodigoSectorEconomico = _nCodigoSectorEconomico;
            this.idTipEvalCred = _idTipEvalCred;
            this.nTotalPlantelFijo = _nTotalPlantelFijo;
            this.nTotalSaca = _nTotalSaca;
            this.idEvalCred = _idEvalCred;

            this.listIndiFinanc = _listIndiFinanc;
            this.listBalGenEval = _listBalGenEval;
            this.listEstResEval = _listEstResEval;
            this.listInventario = _listInventario;

            this.bindingIndiFinanc.DataSource = this.listIndiFinanc;
            this.dtgIndiFinanc.DataSource = this.bindingIndiFinanc;
            this.AgregarComboBoxColumnsDataGridView();
            this.FormatearColumnasDataGridView();

            this.dtgIndiFinanc.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgIndiFinanc_CellFormatting);
            this.dtgIndiFinanc.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgIndiFinanc_DataBindingComplete);

            //this.CalcularIndicadores();
            //this.bindingIndiFinanc.ResetBindings(false);
        }

        public void PuntajeEvalCualitativa(decimal nPuntajeEvalCualitativa)
        {
            this.nPtjeEvalCualitativa = nPuntajeEvalCualitativa;
        }

        public void Actualizar()
        {
            this.CalcularIndicadores();
            this.bindingIndiFinanc.ResetBindings(false);
        }

        public void ActualizarPorIndicadores(List<clsIndicadorEval> _listIndiFinanc)
        {
            this.listIndiFinanc = _listIndiFinanc;

            this.CalcularIndicadores();
            this.bindingIndiFinanc.ResetBindings(false);
        }

        public void ActualizarPorEstadosFinancieros(List<clsBalGenEval> _listBalGenEval, List<clsEstResEval> _listEstResEval, List<clsDetBalGenEval> _listInventario,
            decimal _nTotalPasivoAC, decimal _nCapitalParaComercio)
        {
            this.listBalGenEval = _listBalGenEval;
            this.listEstResEval = _listEstResEval;
            this.listInventario = _listInventario;

            this.nTotalPasivoAC = _nTotalPasivoAC;
            this.nCapitalParaComercio = _nCapitalParaComercio;

            this.CalcularIndicadores();
            this.bindingIndiFinanc.ResetBindings(false);
        }

        public void ActualizarPorSectorEconomico(int _nCodigoSectorEconomico)
        {
            this.nCodigoSectorEconomico = _nCodigoSectorEconomico;

            this.CalcularIndicadores();
            this.bindingIndiFinanc.ResetBindings(false);
        }

        public void ActualizarPorMontoCuota(decimal _nMontoProp, decimal _nCuotaAprox)
        {
            this.nMontoProp = _nMontoProp;
            this.nCuotaAprox = _nCuotaAprox;

            this.CalcularIndicadores();
            this.bindingIndiFinanc.ResetBindings(false);
        }

        public void ActualizarPorIndPorMPropPorMAprox(List<clsIndicadorEval> _listIndiFinanc, decimal _nMontoProp, decimal _nCuotaAprox)
        {
            this.listIndiFinanc = _listIndiFinanc;

            this.nMontoProp = _nMontoProp;
            this.nCuotaAprox = _nCuotaAprox;

            this.CalcularIndicadores();
            this.bindingIndiFinanc.ResetBindings(false);
        }

        public void ActualizarPorDestinoCapitalTrabajo(decimal _nDestinoCapitalTrabajo)
        {
            this.nDestinoCapitalTrabajo = _nDestinoCapitalTrabajo;

            this.CalcularIndicadores();
            this.bindingIndiFinanc.ResetBindings(false);
        }

        public void ActualizarPuntajeEvalCualitativa(decimal _nPtjeEvalCualitativa)
        {
            this.nPtjeEvalCualitativa = _nPtjeEvalCualitativa;

            this.CalcularIndicadores();
            this.bindingIndiFinanc.ResetBindings(false);
        }

        public void asignaDatosCredPymeEstacional(
            List<clsIndicadorEval> _listIndiFinanc,
            List<clsEstResEval> _listEstResEval,
            int _idTipEvalCred,
            decimal _nMontoProp,
            decimal _nCuotaAprox,
            decimal _nVentaMensualMarginal
            )
        {
            this.dtgIndiFinanc.CellFormatting -= new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgIndiFinanc_CellFormatting);
            this.dtgIndiFinanc.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgIndiFinanc_DataBindingComplete);

            this.listIndiFinanc = _listIndiFinanc;
            this.listEstResEval = _listEstResEval;
            this.idTipEvalCred = _idTipEvalCred;
            this.nMontoProp = _nMontoProp;
            this.nCuotaAprox = _nCuotaAprox;
            this.nVentaMensualMarginal = _nVentaMensualMarginal;

            this.listBalGenEval = new List<clsBalGenEval>();

            Actualizar();

            this.bindingIndiFinanc.DataSource = this.listIndiFinanc;
            this.dtgIndiFinanc.DataSource = this.bindingIndiFinanc;
            this.AgregarComboBoxColumnsDataGridView();
            this.FormatearColumnasDataGridView();

            this.dtgIndiFinanc.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgIndiFinanc_CellFormatting);
            this.dtgIndiFinanc.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgIndiFinanc_DataBindingComplete);
        }

        public void actualizaCredPymeEstacional(List<clsEstResEval> _listEstResEval, int _idTipEvalCred, 
                                                decimal _nMontoProp, decimal _nCuotaAprox,decimal _nVentaMensualMarginal)
        {
            this.listEstResEval = _listEstResEval;
            this.idTipEvalCred = _idTipEvalCred;
            this.nMontoProp = _nMontoProp;
            this.nCuotaAprox = _nCuotaAprox;
            this.nVentaMensualMarginal = _nVentaMensualMarginal;

            this.CalcularIndicadores();
            this.bindingIndiFinanc.ResetBindings(false);
        }

        #endregion

        #region Métodos Privados
        private void FormatearDataGridView()
        {
            this.dtgIndiFinanc.Margin = new System.Windows.Forms.Padding(0);
            this.dtgIndiFinanc.MultiSelect = false;
            this.dtgIndiFinanc.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgIndiFinanc.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgIndiFinanc.RowHeadersVisible = false;
            this.dtgIndiFinanc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgIndiFinanc.ReadOnly = true;
        }

        private void FormatearColumnasDataGridView()
        {
            foreach (DataGridViewColumn column in this.dtgIndiFinanc.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgIndiFinanc.Columns["cDescripcion"].DisplayIndex = 0;
            dtgIndiFinanc.Columns["nRatio"].DisplayIndex = 1;
            dtgIndiFinanc.Columns["imgValidacion"].DisplayIndex = 2;
            dtgIndiFinanc.Columns["cDescRegla"].DisplayIndex = 3;

            dtgIndiFinanc.Columns["cDescripcion"].Visible = true;
            dtgIndiFinanc.Columns["nRatio"].Visible = true;
            dtgIndiFinanc.Columns["imgValidacion"].Visible = true;
            dtgIndiFinanc.Columns["cDescRegla"].Visible = true;

            dtgIndiFinanc.Columns["cDescripcion"].FillWeight = 90;
            dtgIndiFinanc.Columns["nRatio"].FillWeight = 35;
            dtgIndiFinanc.Columns["imgValidacion"].FillWeight = 10;
            dtgIndiFinanc.Columns["cDescRegla"].FillWeight = 25;

            dtgIndiFinanc.Columns["cDescripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void AgregarComboBoxColumnsDataGridView()
        {
            DataGridViewImageColumn imgValidacion = new DataGridViewImageColumn();
            imgValidacion.Name = "imgValidacion";
            imgValidacion.DataPropertyName = "imgValidacion";
            this.dtgIndiFinanc.Columns.Add(imgValidacion);
        }

        private void StyleCellDataGridView()
        {
            int nCodigo = 0, nTipoVariable = 0;
            foreach (DataGridViewRow row in this.dtgIndiFinanc.Rows)
            {
                nCodigo = Convert.ToInt32(row.Cells["nCodigo"].Value);
                nTipoVariable = Convert.ToInt32(row.Cells["nTipoVariable"].Value);

                if (nTipoVariable == 1) row.DefaultCellStyle.Format = "N0";
                else if (nTipoVariable == 2) row.DefaultCellStyle.Format = "P2";
            }
        }

        public void setCuotasMensuales(int nCuotasMensuales)
        {
            this.nCuotasMnesuales = nCuotasMensuales;
        }

        public void setIdTipoPeriodo(int idTipoPeriodo)
        {
            this.idTipoPeriodo = idTipoPeriodo;
        }

        public void setIdPeriodo(int idPeriodo)
        {
            this.idPeriodo = idPeriodo;
        }

        private void CalcularIndicadores()
        {
            //decimal nMontoProp = 50000.00m;
            //decimal nCuota = 51275.06m;
            //decimal nDestCredCapTrabajo = 0;

            decimal nPtjeEvalCualitativa = this.nPtjeEvalCualitativa,
                    nCapitalTrabajo = 0,
                    nEndeudamientoTotal = 0,
                    nRentabilidadInver = 0,
                    nRotacionInventarios = 0,
                    nCapacidadPago = 0,
                    nIncrementoCapital = 0,
                    nEndHatoGanadero = 0;

            decimal nActivos = 0m,
                    nAcCorriente = 0m,
                    nAcNoCorriente = 0m,
                    nPasivos = 0m,
                    nPaCorriente = 0m,
                    nPaNoCorriente = 0m,
                    nPatrimonio = 0m,
                    nInventario = 0m,
                    nInmuebles = decimal.Zero,
                    nMontoCaja = 0m;

            decimal nVentasNetas = 0m,
                    nCostoVentas = 0m,
                    nUBruta = 0m,
                    nGastoNegocio = 0m,
                    nUOperativa = 0m,
                    nGastosFinancieros = 0m,
                    nUNeta = 0m,
                    nOtrosIngresos = 0m,
                    nOtrosEgresos = 0m,
                    nGastosFamiliares = 0m,
                    nUDisponible = 0m,
                    nEndeudamientoSinInmueble = decimal.Zero;
            decimal nVentasNetasExtra = 0m;
            decimal nEndeudamientoPatrimonial = 0m,
                    nCuotaExcedente = 0m,
                    nCoberturaDeGarantia = 0m;

            //--Evaluación Pyme Estacional
            decimal nFinanciamientoCapital = 0m, 
                    nCoberturaPrestamo = 0m;

            //---------------- Balance General
            nAcCorriente = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalAcCorriente).Sum(x => x.nTotalMA);
            nAcNoCorriente = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalAcNoCorriente).Sum(x => x.nTotalMA);
            nActivos = nAcCorriente + nAcNoCorriente;

            nPaCorriente = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalPaCorriente).Sum(x => x.nTotalMA);
            nPaNoCorriente = listBalGenEval.Where(x => x.idEEFFPadre == EEFF.TotalPaNoCorriente).Sum(x => x.nTotalMA);
            nPasivos = nPaCorriente + nPaNoCorriente;

            nPatrimonio = nActivos - nPasivos;
            nInventario = listBalGenEval.Where(x => x.idEEFF == EEFF.Inventario).Sum(x => x.nTotalMA);
            nInmuebles = listBalGenEval.Where(x => x.idEEFF == EEFF.Inmuebles).Sum(x => x.nTotalMA);

            nMontoCaja = this.listBalGenEval.Where(x => x.idEEFF == EEFF.Caja).Sum(x => x.nTotalMA);

            //---------------- Estado de Resultados
            nVentasNetas = listEstResEval.Where(x => x.idEEFF == EEFF.VentasNetas).Sum(x => x.nTotalMA);
            nCostoVentas = listEstResEval.Where(x => x.idEEFF == EEFF.CostoVentas).Sum(x => x.nTotalMA);
            nVentasNetasExtra = listEstResEval.Where(x => x.idEEFF == EEFF.IngresoJrnlTitular).Sum(x => x.nTotalMA);
            nVentasNetasExtra = nVentasNetasExtra + listEstResEval.Where(x => x.idEEFF == EEFF.IngresoJrnlCónyuge).Sum(x => x.nTotalMA);
            nUBruta = nVentasNetas + nVentasNetasExtra - nCostoVentas;

            nGastoNegocio = listEstResEval.Where(x => x.idEEFF == EEFF.GastosNegocio).Sum(x => x.nTotalMA);
            nUOperativa = nUBruta - nGastoNegocio;

            nGastosFinancieros = listEstResEval.Where(x => x.idEEFF == EEFF.GastosFinancieros).Sum(x => x.nTotalMA);
            nUNeta = nUOperativa - nGastosFinancieros;

            nOtrosIngresos = listEstResEval.Where(x => x.idEEFF == EEFF.OtrosIngresos).Sum(x => x.nTotalMA);
            nOtrosEgresos = listEstResEval.Where(x => x.idEEFF == EEFF.OtrosEgresos).Sum(x => x.nTotalMA);
            nGastosFamiliares = listEstResEval.Where(x => x.idEEFF == EEFF.GastosFamiliares).Sum(x => x.nTotalMA);
            nUDisponible = nUNeta + nOtrosIngresos - nOtrosEgresos - nGastosFamiliares;

            //---------------- IFinancieros
            nCapitalTrabajo = nAcCorriente - nPaCorriente;
            //nEndeudamientoTotal = clsNumerico.Dividir((nPasivos + this.nMontoProp - this.nTotalPasivoAC), (nPatrimonio + this.nTotalPasivoAC));
            nEndeudamientoTotal = nPatrimonio != 0 ? clsNumerico.Dividir((nPasivos + this.nMontoProp - this.nTotalPasivoAC), (nPatrimonio)) : 0;
            nRentabilidadInver = nActivos != 0 ? clsNumerico.Dividir(nUNeta, nActivos) : 0;
            nRotacionInventarios = nCostoVentas != 0 ? (clsNumerico.Dividir(nInventario, nCostoVentas)) * 30 : 0;

            if (idTipEvalCred == 22)
            {
                if (VerificarSubProductoCrediChamba()) 
                {
                    decimal nIngresosFamiliares = listEstResEval.Where(x => x.idEEFF == EEFF.UtilidadBruta).Sum(x => x.nTotalMA);
                    nCapacidadPago = clsNumerico.Dividir((this.nCuotaAprox + nGastosFinancieros), (nIngresosFamiliares - nGastosFamiliares));
                }
                else
                {
                nCapacidadPago = clsNumerico.Dividir((this.nCuotaAprox), (nUDisponible));
            }
            }
            else if (idTipEvalCred == 23)
            {
                nCapacidadPago = clsNumerico.Dividir((this.nCuotaAprox + nGastosFinancieros), (nUOperativa + nOtrosIngresos - nOtrosEgresos - nGastosFamiliares));
            }
            else if (idTipEvalCred == 25)
            {
                DataTable dtConfDisCred = new clsCNEvalCrediRural().ObtenerConfiguracionDiseCredRural(this.idEvalCred);

                if (dtConfDisCred.Rows.Count > 0)
                {
                    this.plazoCuotaLibre = Convert.ToInt32(dtConfDisCred.Rows[0]["nPlazoMeses"]);
                    this.idTipoPeriodo = Convert.ToInt32(dtConfDisCred.Rows[0]["idTipoPeriodo"]);
                    this.idPeriodo = Convert.ToInt32(dtConfDisCred.Rows[0]["idPeriodo"]);
                    this.dFechaDesembolso = Convert.ToDateTime(dtConfDisCred.Rows[0]["dFechaDesembolso"]);
                    this.nTea = Convert.ToDecimal(dtConfDisCred.Rows[0]["nTEA"]);
                    //this.nMontoProp = Convert.ToDecimal(dtConfDisCred.Rows[0]["nMontoPropuesto"]);

                    DataSet dsFlujoCaja = new clsCNEvalCrediRural().GeneraFlujoCajaRural(this.idEvalCred, this.plazoCuotaLibre, this.idTipoPeriodo, this.idPeriodo, this.dFechaDesembolso, nMontoCaja);
                    this.listFlujoCaja = new List<clsFlujoCajaRural>();
                    this.listDisenioCredito = new List<clsDisenioCredito>();
                    this.listFlujoCaja = DataTableToList.ConvertTo<clsFlujoCajaRural>(dsFlujoCaja.Tables[0]) as List<clsFlujoCajaRural>;
                    this.listDisenioCredito = DataTableToList.ConvertTo<clsDisenioCredito>(new clsCNEvalCrediRural().SelectDisenioCrediticio(this.idEvalCred)) as List<clsDisenioCredito>;

                    decimal nTotIngresos = 0m;
                    decimal nTotEgresos = 0m;
                    decimal nSumaCuotas = 0m;
                    decimal nPromedioCuotas_sinCt0 = 0m; 
                    decimal nPromedioExdMensu_sinCt0 = 0m;

                    if (this.listFlujoCaja.Count > 0)
                    {
                        nTotIngresos = this.listFlujoCaja.Sum(x => x.nOtrosIngresos) +
                                          this.listFlujoCaja.Sum(x => x.nIngresoCultivos) +
                                          this.listFlujoCaja.Sum(x => x.nProductosAlmacenados);

                        nTotEgresos = this.listFlujoCaja.Sum(x => x.nEgresosCultivos) +
                                              this.listFlujoCaja.Sum(x => x.nDeudaFinanciera) +
                                              this.listFlujoCaja.Sum(x => x.nExedPyme);
                    }

                    if (this.listDisenioCredito.Count > 0)
                    {
                        nSumaCuotas = this.listDisenioCredito.Sum(x => x.nMontoCuota);
                        List<decimal> montoCuotas = new List<decimal>();

                        foreach (var item in listDisenioCredito)
	                    {
		                    if(item.nMontoCuota > 0)
                                montoCuotas.Add(item.nMontoCuota);
	                    }

                        if (montoCuotas.Count < 1)
                                nPromedioCuotas_sinCt0 = 0m;
                            else
                                nPromedioCuotas_sinCt0 = montoCuotas.Average();
                    }

                    if (this.listFlujoCaja.Count > 0 && this.listDisenioCredito.Count > 0)
                    {
                        List<int> indice = new List<int>();

                        foreach (var item in this.listDisenioCredito)
                        {
                            if (item.nMontoCuota > 0)
                            {
                                indice.Add(this.listDisenioCredito.IndexOf(item));
                            }
                        }

                        List<decimal> exdMensual = new List<decimal>();

                        foreach (var item in this.listFlujoCaja)
                        {
                            if (indice.Contains(this.listFlujoCaja.IndexOf(item)))
                            {
                                exdMensual.Add(item.nExedMensual);
                            }
                        }

                        if (exdMensual.Count > 0)
                        {
                            //nPromedioExdMensu = exdMensual.Average();
                            //exdMensual.Remove(0);
                            if (exdMensual.Count < 1)
                                nPromedioExdMensu_sinCt0 = 0m;
                            else
                                nPromedioExdMensu_sinCt0 = exdMensual.Average();
                        }

                    }

                    nCapacidadPago = clsNumerico.Dividir(((nTotIngresos + nTotEgresos) + this.nMontoProp), nSumaCuotas);

                    nEndeudamientoPatrimonial = clsNumerico.Dividir((nPasivos + this.nMontoProp), nPatrimonio);

                    if (this.idTipoPeriodo == (int)eTipoPeriodoCred.CuotasLibres ||
                        this.idTipoPeriodo == (int)eTipoPeriodoCred.PeriodoFijo && this.idPeriodo == (int)ePeriodoCred.Mensual ||
                        this.idTipoPeriodo == (int)eTipoPeriodoCred.PeriodoFijo && this.idPeriodo == (int)ePeriodoCred.Unicuota)
                    //    nCuotaExcedente = clsNumerico.Dividir(nPromedioCuotas, nPromedioExdMensu);
                    //else if (this.idTipoPeriodo == 4)
                        nCuotaExcedente = clsNumerico.Dividir(nPromedioCuotas_sinCt0, nPromedioExdMensu_sinCt0);
                    else
                        nCuotaExcedente = 0;
                }
                else
                {
                    nCapacidadPago = 0m;
                    nEndeudamientoPatrimonial = 0m;
                    nCuotaExcedente = 0m;
                    //nCoberturaDeGarantia = 0m;
                }

                DataTable dtGarantia = new clsCNGarantiaRural().ListarGarantiaRuralid(this.idEvalCred);

                if (dtGarantia.Rows.Count > 0)
                {
                    nCoberturaDeGarantia = clsNumerico.Dividir(this.nMontoProp, Convert.ToDecimal(dtGarantia.Rows[0]["nValor"]));
                }
                else
                {
                    if (nInmuebles > 0)
                        nCoberturaDeGarantia = clsNumerico.Dividir(this.nMontoProp, nInmuebles);
                    else
                        nCoberturaDeGarantia = 0m;
                }

            }
            else if (idTipEvalCred == 26)
            {
                nFinanciamientoCapital = nCostoVentas != 0 ? Math.Round(clsNumerico.Dividir(this.nMontoProp, nCostoVentas),2) : 0;
                nCoberturaPrestamo = this.nVentaMensualMarginal != 0 ? Math.Round(clsNumerico.Dividir(this.nCuotaAprox, this.nVentaMensualMarginal),2) : 0;
            }
            else
            {
                nCapacidadPago = clsNumerico.Dividir((this.nCuotaAprox + nGastosFinancieros), (nUDisponible + nGastosFinancieros));
            }

            nIncrementoCapital = clsNumerico.Dividir(this.nDestinoCapitalTrabajo, nCapitalTrabajo);
            nEndHatoGanadero = EndeudamientoSegunHatoGanadero(this.listInventario, this.nCapitalParaComercio, this.nCodigoSectorEconomico, this.nMontoProp);
            nEndeudamientoSinInmueble = clsNumerico.Dividir((nPasivos + this.nMontoProp - this.nTotalPasivoAC), (nPatrimonio - nInmuebles));

            //---------------- Actualizar
            foreach (clsIndicadorEval item in listIndiFinanc)
            {
                if (item.nCodigo == IFN.PtjeEvalCualitativa)
                {
                    item.nRatio = nPtjeEvalCualitativa;
                }
                else if (item.nCodigo == IFN.CapitalTrabajo)
                {
                    item.nRatio = nCapitalTrabajo;
                }
                else if (item.nCodigo == IFN.EndeudamientoTotal)
                {
                    item.nRatio = nEndeudamientoTotal;
                }
                else if (item.nCodigo == IFN.RentabilidadInver)
                {
                    item.nRatio = nRentabilidadInver;
                }
                else if (item.nCodigo == IFN.RotacionInventarios)
                {
                    item.nRatio = nRotacionInventarios;
                }
                else if (item.nCodigo == IFN.CapacidadPago)
                {
                    item.nRatio = nCapacidadPago;
                }
                else if (item.nCodigo == IFN.IncrementoCapital)
                {
                    item.nRatio = nIncrementoCapital;
                }
                else if (item.nCodigo == IFN.EndSegunHato)
                {
                    item.nRatio = nEndHatoGanadero;
                }
                else if (item.nCodigo == IFN.EndeudamientoSinInmueble)
                {
                    item.nRatio = nEndeudamientoSinInmueble;
                }
                else if (item.nCodigo == IFN.EndeudamientoPatrimonial)
                {
                    item.nRatio = nEndeudamientoPatrimonial;
                }
                else if (item.nCodigo == IFN.CuotaExcedente)
                {
                    item.nRatio = nCuotaExcedente;
                }
                else if (item.nCodigo == IFN.CoberturaDeGarantia)
                {
                    item.nRatio = nCoberturaDeGarantia;
                }
                else if (item.nCodigo == IFN.FinanciamientoCapital)
                {
                    item.nRatio = nFinanciamientoCapital;
                }
                else if (item.nCodigo == IFN.CoberturaPrestamo)
                {
                    item.nRatio = nCoberturaPrestamo;
                }
            }
        }

        private decimal EndeudamientoSegunHatoGanadero(List<clsDetBalGenEval> listInventario, decimal nCapitalParacomercio, int nCodigoSectorEconomico, decimal nMontoPropuesto)
        {
            decimal nRatio = 0,
                    nIndHatoGanRecria = 0,
                    nIndHatoGanEngorde = 0,
                    nIndHatoGanComercio = 0,
                    nIndHatoGanComercioRecria1 = 0,
                    nIndHatoGanComercioRecria2 = 0,
                    nIndHatoGanComercioEngorde1 = 0,
                    nIndHatoGanComercioEngorde2 = 0;

            decimal nInvPlantelFijo = 0,
                    nGanadoEngorde = 0,
                    nGanadoComercio = 0;

            nIndHatoGanRecria = Convert.ToDecimal(clsVarApl.dicVarGen["nIndHatoGanRecria"]);
            nIndHatoGanEngorde = Convert.ToDecimal(clsVarApl.dicVarGen["nIndHatoGanEngorde"]);
            nIndHatoGanComercio = Convert.ToDecimal(clsVarApl.dicVarGen["nIndHatoGanComercio"]);
            nIndHatoGanComercioRecria1 = Convert.ToDecimal(clsVarApl.dicVarGen["nIndHatoGanComercioRecria1"]);
            nIndHatoGanComercioRecria2 = Convert.ToDecimal(clsVarApl.dicVarGen["nIndHatoGanComercioRecria2"]);
            nIndHatoGanComercioEngorde1 = Convert.ToDecimal(clsVarApl.dicVarGen["nIndHatoGanComercioEngorde1"]);
            nIndHatoGanComercioEngorde2 = Convert.ToDecimal(clsVarApl.dicVarGen["nIndHatoGanComercioEngorde2"]);

            nInvPlantelFijo = listInventario.Where(x => x.nCodigoInv == TipoInventario.PlantelFijo).Sum(x => x.nTotalMA);
            nGanadoEngorde = listInventario.Where(x => x.nCodigoInv == TipoInventario.SemovientesEngorde).Sum(x => x.nTotalMA);
            nGanadoComercio = listInventario.Where(x => x.nCodigoInv == TipoInventario.SemovientesComercio).Sum(x => x.nTotalMA);

            decimal nTotalPlantelSaca = this.nTotalPlantelFijo + this.nTotalSaca;

            if (this.idTipEvalCred == 3 || this.idTipEvalCred == 6)
            {
                DataSet dsResult = this.objCapaNegocio.BuscarEvalCredito(this.idEvalCred);
                // this.nTotalPlantelFijo = dsResult.Tables[13].AsEnumerable().Where(x => x.Field<int>("idTipoInventario") == 10).Sum(x => x.Field<decimal>("nValorActual"));
                decimal nTotalComercio = dsResult.Tables[13].AsEnumerable().Where(x => 
                    (x.Field<int>("idTipoInventario") == 11 || x.Field<int>("idTipoInventario") == 10) && x.Field<int>("idTipoCrianza") == 3).Sum(x => x.Field<decimal>("nValorActual")
                );
                decimal nTotalEngorde = dsResult.Tables[13].AsEnumerable().Where(x => 
                    (x.Field<int>("idTipoInventario") == 11 || x.Field<int>("idTipoInventario") == 10) && x.Field<int>("idTipoCrianza") == 2).Sum(x => x.Field<decimal>("nValorActual")
                );
                decimal nTotalRecria = dsResult.Tables[13].AsEnumerable().Where(x => 
                    (x.Field<int>("idTipoInventario") == 11 || x.Field<int>("idTipoInventario") == 10) && x.Field<int>("idTipoCrianza") == 1).Sum(x => x.Field<decimal>("nValorActual")
                );

                decimal nIndComercio = Decimal.Zero;
                decimal nIndEngorde = Decimal.Zero;
                decimal nIndRecria = Decimal.Zero;

                if (nCodigoSectorEconomico == 4)
                {
                    nIndRecria = nTotalRecria * 0.3m;
                }
                else if (nCodigoSectorEconomico == 5)
                {
                    nIndEngorde = nTotalEngorde * 0.5m;
                }
                else if (nCodigoSectorEconomico == 6)
                {
                    nIndComercio = nTotalComercio * 0.8m;
                }
                else if (nCodigoSectorEconomico == 7)
                {
                    nIndComercio = nTotalComercio * 0.8m;
                    nIndRecria = nTotalRecria * 0.3m;
                }
                else if (nCodigoSectorEconomico == 8)
                {
                    nIndComercio = nTotalComercio * 0.8m;
                    nIndEngorde = nTotalEngorde * 0.5m;
                }
                else if (nCodigoSectorEconomico == 10)
                {
                    nIndEngorde = nTotalEngorde * 0.5m;
                    nIndRecria = nTotalRecria * 0.3m;
                }
                else if (nCodigoSectorEconomico == 11)
                {
                    nIndComercio = nTotalComercio * 0.8m;
                    nIndEngorde = nTotalEngorde * 0.5m;
                    nIndRecria = nTotalRecria * 0.3m;
                }

                decimal nDenomidador = (nIndComercio) + (nIndEngorde) + (nIndRecria) + (nCapitalParacomercio * 0.8m);

                if (nDenomidador == 0)
                {
                    nRatio = 0;
                }
                else
                {
                    nRatio = (nMontoPropuesto) / (nDenomidador);
                }
            }
            else
            {
                if (nCodigoSectorEconomico == TipoIngresoPorActividad.Recria)
                {
                    nRatio = clsNumerico.Dividir(nMontoPropuesto,
                        nInvPlantelFijo * nIndHatoGanRecria);
                }
                else if (nCodigoSectorEconomico == TipoIngresoPorActividad.Engorde)
                {
                    nRatio = clsNumerico.Dividir(nMontoPropuesto,
                        nGanadoEngorde * nIndHatoGanEngorde);
                }
                else if (nCodigoSectorEconomico == TipoIngresoPorActividad.ComercioAgro)
                {
                    nRatio = clsNumerico.Dividir(nMontoPropuesto,
                        (nGanadoComercio + nCapitalParacomercio) * nIndHatoGanComercio);
                }
                else if (nCodigoSectorEconomico == TipoIngresoPorActividad.MixtoRecriaComercio)
                {
                    nRatio = clsNumerico.Dividir(nMontoPropuesto,
                        ((nGanadoComercio + nCapitalParacomercio) * nIndHatoGanComercioRecria1) + (nInvPlantelFijo * nIndHatoGanComercioRecria2));
                }
                else if (nCodigoSectorEconomico == TipoIngresoPorActividad.MixtoComercioRecria)
                {
                    nRatio = clsNumerico.Dividir(nMontoPropuesto,
                        ((nGanadoComercio + nCapitalParacomercio) * nIndHatoGanComercioEngorde1) + (nGanadoEngorde * nIndHatoGanComercioEngorde2));
                }
            }

            return nRatio;
        }

        private bool VerificarSubProductoCrediChamba()
        {
            bool lProducto = false;
            DataTable dtProducto = new clsCNEvalCrediJornal().SubProductoCrediChamba();

            foreach (DataRow item in dtProducto.Rows)
            {
                if (Convert.ToInt32(item["idProducto"]) == idProducto)
                {
                    lProducto = true;
                    break;
                }
            }
            return lProducto;
        }

        #endregion

        #region Eventos
        private void dtgIndiFinanc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = this.dtgIndiFinanc.Rows[e.RowIndex].Cells["cDescripcion"];
            if (idTipEvalCred != 22)
            {
            cell.ToolTipText = this.dtgIndiFinanc.Rows[e.RowIndex].Cells["cDescFormula"].Value.ToString();
            }

            if (this.dtgIndiFinanc.Columns[e.ColumnIndex].Name.Equals("imgValidacion"))
            {

                decimal nValorMinimo = this.listIndiFinanc[e.RowIndex].nValorMinimo;
                decimal nValorMaximo = this.listIndiFinanc[e.RowIndex].nValorMaximo;
                decimal nRatio = this.listIndiFinanc[e.RowIndex].nRatio;

                nRatio = (this.listIndiFinanc[e.RowIndex].nTipoVariable == 2) ? nRatio * 100 : nRatio;
                nRatio = Math.Round(nRatio, 2);

                if (this.lValidacionEnabled)
                {
                    if (nRatio >= nValorMinimo && nRatio <= nValorMaximo)
                    {
                        // Valido
                        e.Value = imageList.Images[1];
                    }
                    else
                    {
                        // No válido
                        e.Value = imageList.Images[0];
                    }
                }
                else
                {
                    e.Value = imageList.Images[2];
                    e.CellStyle.SelectionBackColor = Color.White;
                }
            }

            if (this.dtgIndiFinanc.Columns[e.ColumnIndex].Name.Equals("cDescRegla"))
            {
                if (!this.lDescripcionReglaEnabled)
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.White;
                }
                
            }
        }

        private void dtgIndiFinanc_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.StyleCellDataGridView();
            this.dtgIndiFinanc.ClearSelection();
        }

        #endregion
    }
}
