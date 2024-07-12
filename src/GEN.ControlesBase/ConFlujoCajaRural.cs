using CRE.CapaNegocio;
using EntityLayer;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class ConFlujoCajaRural : UserControl
    {
        #region Variables

        private List<clsFlujoCajaRural> listFlujoCaja;
        private List<clsDisenioCredito> listDisenioCredito;
        private BindingSource bsFlujoCajaPrincipal;
        private BindingSource bsDisenioCredito;
        private int idEvalCred;
        private int idSolicitud;
        private int idOperacion;
        private int idTipoPeriodo;
        private int idPeriodo;
        private int nPlazoCredMeses;
        private decimal nMontoPropuesto;
        private decimal nMontoCajaIncial;
        private decimal nTEM;
        private DateTime dFechaDesembolso;
        private DateTime dFechaMinima;
        private DataTable dtCalendarioPlanPago;
        public event EventHandler nudCuotasValueChange;
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


        #region Metodos Publicos

        public ConFlujoCajaRural()
        {
            InitializeComponent();
        }

        public void inicializarControl()
        {
            this.listFlujoCaja = new List<clsFlujoCajaRural>();
            this.listDisenioCredito = new List<clsDisenioCredito>();

            inicializarTablaFlujoCajaPrincipal();
            inicializarTablaDisenioCredito();
            FormatearDataGridView();
        }

        public void AsignarDatos(
        List<clsFlujoCajaRural> listFlujoCaja, List<clsDisenioCredito> listDisenioCredito, clsEvalCred objEvalCred, int idTipoPeriodo, int idPeriodo,
        int plazoCredMeses, decimal montoPropuesto, decimal nMontoCajaIncial, decimal nTEM, DateTime dFechaDesembolso, DataTable CalendarioPlanPago, DateTime fechaMinima)
        {
            this.dtgDisenioCrediticio.DataBindingComplete -= new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgDisenioCrediticio_DataBindingComplete);
            this.nudCuotas.ValueChanged -= new System.EventHandler(this.nudCuotas_ValueChange);

            this.idEvalCred = objEvalCred.idEvalCred;
            this.idSolicitud = objEvalCred.idSolicitud;

            var idOperacion = new clsCNEvalCrediRural().RetornaOperacionxIdSolicitud(this.idSolicitud).Rows[0]["idOperacion"];
            this.idOperacion = Convert.ToInt32(idOperacion);

            this.idTipoPeriodo = idTipoPeriodo;
            this.idPeriodo = idPeriodo;
            this.nPlazoCredMeses = plazoCredMeses;
            this.nMontoPropuesto = montoPropuesto;
            this.nMontoCajaIncial = nMontoCajaIncial;
            this.nTEM = nTEM;
            this.dFechaDesembolso = dFechaDesembolso;
            this.dFechaMinima = fechaMinima;
            this.dtCalendarioPlanPago = CalendarioPlanPago;

            this.listFlujoCaja.Clear();
            this.listDisenioCredito.Clear();

            decimal totalIngresos = 0m;
            decimal totalEgresos = 0m;
            decimal saldoAcumulado = 0m;
            decimal NecesidadCredito = 0m;

            foreach (var item in listFlujoCaja)
            {
                this.listFlujoCaja.Add(item);
                totalIngresos = totalIngresos + item.nOtrosIngresos + item.nIngresoCultivos + item.nProductosAlmacenados;
                totalEgresos = totalEgresos + item.nEgresosCultivos + item.nDeudaFinanciera + item.nExedPyme;
            }

            NecesidadCredito = listFlujoCaja.Min(x => x.nNecesidadCredito);

            foreach (var item in listDisenioCredito)
            {
                this.listDisenioCredito.Add(item);
            }

            saldoAcumulado = totalIngresos + totalEgresos;

            this.txtIngresos.Text = totalIngresos.ToString();
            this.txtEgresos.Text = totalEgresos.ToString();
            this.txtSaldoAcumulado.Text = saldoAcumulado.ToString();
            this.txtNecesidadCredito.Text = (NecesidadCredito <= 0m) ? NecesidadCredito.ToString() : "0";
            this.nudCuotas.Text = this.nPlazoCredMeses.ToString();
            this.txtMonto.Text = this.nMontoPropuesto.ToString();

            this.bsFlujoCajaPrincipal.ResetBindings(false);
            this.bsDisenioCredito.ResetBindings(false);

            this.dtgDisenioCrediticio.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgDisenioCrediticio_DataBindingComplete);
            this.nudCuotas.ValueChanged += new System.EventHandler(this.nudCuotas_ValueChange);

            dtgDisenioCrediticio_DataBindingComplete(null, null);

            if (this.idOperacion == 2)
            {
                this.txtNecesidadCredito.Text = "0";
                this.txtMonto.Enabled = false;
            }
        }

        public int getPlazoCuotasLibres()
        {
            return this.nPlazoCredMeses;
        }

        public List<clsDisenioCredito> RecuperaDisenioCredito()
        {
            return this.listDisenioCredito;
        }

        public decimal getMontoPropuesto()
        {
            return this.nMontoPropuesto;
        }

        public int getNumeroAlerta()
        {
            return Convert.ToInt32(this.txtConAlertas.Text);
        }

        public DateTime getFechaPriCuota()
        {
            if(this.idTipoPeriodo == (int)eTipoPeriodoCred.PeriodoFijo && this.idPeriodo == (int)ePeriodoCred.Unicuota)
                return (DateTime)this.listDisenioCredito.Last().dFecha;
            else if(this.idTipoPeriodo == (int)eTipoPeriodoCred.PeriodoFijo && this.idPeriodo == (int)ePeriodoCred.Mensual)
                return (DateTime)this.listDisenioCredito.Find(x => x.nCuota == 1).dFecha;
            else
                return (this.listDisenioCredito.FindAll(x => x.nMontoCuota > 0).Count > 0) ? (DateTime)this.listDisenioCredito.First(x => x.nMontoCuota > 0).dFecha : (DateTime)this.listDisenioCredito.Find(x => x.nCuota == 1).dFecha;
        }

        public void ActualizaDatosDisenioCrediticio()
        {
            this.nPlazoCredMeses = Convert.ToInt32(this.nudCuotas.Value);
            this.listFlujoCaja.Clear();
            DataSet dtFlujoCaja = new clsCNEvalCrediRural().GeneraFlujoCajaRural(this.idEvalCred, Convert.ToInt32(this.nudCuotas.Value), this.idTipoPeriodo, this.idPeriodo, this.dFechaDesembolso, this.nMontoCajaIncial);
            this.listFlujoCaja = DataTableToList.ConvertTo<clsFlujoCajaRural>(dtFlujoCaja.Tables[0]) as List<clsFlujoCajaRural>;
            var listDisenioCredito = DataTableToList.ConvertTo<clsDisenioCredito>(dtFlujoCaja.Tables[1]) as List<clsDisenioCredito>;

            if (Convert.ToInt32(this.nudCuotas.Value) >= listDisenioCredito.Count)
            {
                for (int x = listDisenioCredito.Count; x <= Convert.ToInt32(this.nudCuotas.Value); x++)
                {
                    clsDisenioCredito row = new clsDisenioCredito();

                    int nMonths = 0;

                    if (listDisenioCredito.Count == 0)
                        nMonths = 1;
                    else if ((this.dFechaDesembolso - Convert.ToDateTime(listDisenioCredito.First().dFecha)) < TimeSpan.Zero)
                        nMonths = -1;
                    else if ((this.dFechaDesembolso - Convert.ToDateTime(listDisenioCredito.First().dFecha)) >= TimeSpan.Zero)
                        nMonths = 1;

                    if (listDisenioCredito.Count < 1)
                    {
                        row.nCuota = 0;
                        row.dFecha = this.dFechaDesembolso;
                    }
                    else
                    {
                        row.nCuota = listDisenioCredito.Last().nCuota + 1;
                        if (nMonths == -1)
                            row.dFecha = Convert.ToDateTime(listDisenioCredito.First().dFecha).AddMonths(nMonths);
                        else
                            row.dFecha = Convert.ToDateTime(listDisenioCredito.Last().dFecha).AddMonths(nMonths);
                    }

                    row.cMesCuota = Convert.ToDateTime(row.dFecha).ToString("MMM - yy");
                    row.nMontoCuota = 0;
                    row.nCapIntSeg = 0;
                    row.nDiaDesembolso = 0;
                    row.nExedenteFinal = 0;

                    if (nMonths == -1)
                        listDisenioCredito.Insert(0, row);
                    else
                        listDisenioCredito.Add(row);
                }
                this.listDisenioCredito = listDisenioCredito;
            }
            else
            {
                this.listDisenioCredito = listDisenioCredito;
            }

            decimal totalIngresos = 0;
            decimal totalEgresos = 0;
            decimal saldoAcumulado = 0;
            decimal NecesidadCredito = 0;

            foreach (var item in listFlujoCaja)
            {
                totalIngresos = totalIngresos + item.nOtrosIngresos + item.nIngresoCultivos + item.nProductosAlmacenados;
                totalEgresos = totalEgresos + item.nEgresosCultivos + item.nDeudaFinanciera + item.nExedPyme;
            }

            NecesidadCredito = listFlujoCaja.Min(x => x.nNecesidadCredito);

            saldoAcumulado = totalIngresos + totalEgresos;

            this.txtIngresos.Text = totalIngresos.ToString();
            this.txtEgresos.Text = totalEgresos.ToString();
            this.txtSaldoAcumulado.Text = saldoAcumulado.ToString();

            if(this.idOperacion == 2)
                this.txtNecesidadCredito.Text = "0";
            else
                this.txtNecesidadCredito.Text = (NecesidadCredito <= 0m) ? NecesidadCredito.ToString() : "0";

            inicializarTablaFlujoCajaPrincipal();
            inicializarTablaDisenioCredito();

            if (this.idTipoPeriodo == 3)
            {
                dtgDisenioCrediticio.Columns["nMontoCuota"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
                dtgDisenioCrediticio.Columns["nMontoCuota"].ReadOnly = false;
                dtgDisenioCrediticio.Columns["nDiaDesembolso"].DefaultCellStyle.BackColor = GridViewStyle.GridViewBackColorEditable;
                dtgDisenioCrediticio.Columns["nDiaDesembolso"].ReadOnly = false;
                nudCuotas.Enabled = true;
                nudCuotas.ReadOnly = false;
                dtgDisenioCrediticio.Rows[0].Cells["nMontoCuota"].ReadOnly = true;
                dtgDisenioCrediticio.Rows[0].Cells["nMontoCuota"].Value = 0m;
                dtgDisenioCrediticio.Rows[0].Cells["nMontoCuota"].Style.BackColor = Color.White;
                dtgDisenioCrediticio.Rows[0].Cells["nDiaDesembolso"].ReadOnly = true;
                dtgDisenioCrediticio.Rows[0].Cells["nDiaDesembolso"].Style.BackColor = Color.White;
            }
            else
            {
                dtgDisenioCrediticio.Columns["nMontoCuota"].DefaultCellStyle.BackColor = SystemColors.Window;
                dtgDisenioCrediticio.Columns["nMontoCuota"].ReadOnly = true;
                dtgDisenioCrediticio.Columns["nDiaDesembolso"].DefaultCellStyle.BackColor = SystemColors.Window;
                dtgDisenioCrediticio.Columns["nDiaDesembolso"].ReadOnly = true;
                nudCuotas.Enabled = false;
                txtMonto.Enabled = false;
            }

            ValidaDiseñoCrediticio();
        }

        #endregion


        #region Metodos Privados

        private void inicializarTablaFlujoCajaPrincipal()
        {
            this.bsFlujoCajaPrincipal = new BindingSource();
            this.bsFlujoCajaPrincipal.DataSource = this.listFlujoCaja;
            this.dtgFlujoPrincipal.DataSource = this.bsFlujoCajaPrincipal;

            this.bsFlujoCajaPrincipal.ResetBindings(false);
            this.dtgFlujoPrincipal.Refresh();

            foreach (DataGridViewColumn column in this.dtgFlujoPrincipal.Columns)
            {
                column.Visible = true;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgFlujoPrincipal.Columns["nFecha"].Visible = false;
            dtgFlujoPrincipal.Columns["nCuota"].Visible = false;

            dtgFlujoPrincipal.Columns["nOtrosIngresos"].DefaultCellStyle.Format = "n2";
            dtgFlujoPrincipal.Columns["nIngresoCultivos"].DefaultCellStyle.Format = "n2";
            dtgFlujoPrincipal.Columns["nProductosAlmacenados"].DefaultCellStyle.Format = "n2";
            dtgFlujoPrincipal.Columns["nEgresosCultivos"].DefaultCellStyle.Format = "n2";
            dtgFlujoPrincipal.Columns["nDeudaFinanciera"].DefaultCellStyle.Format = "n2";
            dtgFlujoPrincipal.Columns["nExedPyme"].DefaultCellStyle.Format = "n2";
            dtgFlujoPrincipal.Columns["nExedMensual"].DefaultCellStyle.Format = "n2";
            dtgFlujoPrincipal.Columns["nNecesidadCredito"].DefaultCellStyle.Format = "n2";

            dtgFlujoPrincipal.Columns["cMesCuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgFlujoPrincipal.Columns["nOtrosIngresos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgFlujoPrincipal.Columns["nIngresoCultivos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgFlujoPrincipal.Columns["nProductosAlmacenados"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgFlujoPrincipal.Columns["nEgresosCultivos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgFlujoPrincipal.Columns["nDeudaFinanciera"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgFlujoPrincipal.Columns["nExedPyme"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgFlujoPrincipal.Columns["nExedMensual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgFlujoPrincipal.Columns["nNecesidadCredito"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgFlujoPrincipal.Columns["cMesCuota"].HeaderText = "Mes de Cuota";
            dtgFlujoPrincipal.Columns["nOtrosIngresos"].HeaderText = "Otros Ingresos y Egresos";
            dtgFlujoPrincipal.Columns["nIngresoCultivos"].HeaderText = "Ingreso de Cultivos";
            dtgFlujoPrincipal.Columns["nProductosAlmacenados"].HeaderText = "Productos Almacenados";
            dtgFlujoPrincipal.Columns["nEgresosCultivos"].HeaderText = "Egresos de Cultivos";
            dtgFlujoPrincipal.Columns["nDeudaFinanciera"].HeaderText = "Deuda Financiera";
            dtgFlujoPrincipal.Columns["nExedPyme"].HeaderText = "Exedente Pyme";
            dtgFlujoPrincipal.Columns["nExedMensual"].HeaderText = "Exedente Mensual";
            dtgFlujoPrincipal.Columns["nNecesidadCredito"].HeaderText = "Necesidad de Credito";

            dtgFlujoPrincipal.Columns["nExedMensual"].DefaultCellStyle.BackColor = Color.LightGray;
        }

        private void inicializarTablaDisenioCredito()
        {
            this.bsDisenioCredito = new BindingSource();
            this.bsDisenioCredito.DataSource = this.listDisenioCredito;
            this.dtgDisenioCrediticio.DataSource = this.bsDisenioCredito;

            this.bsDisenioCredito.ResetBindings(false);
            this.dtgDisenioCrediticio.Refresh();

            dtgDisenioCrediticio.ReadOnly = false;

            foreach (DataGridViewColumn column in this.dtgDisenioCrediticio.Columns)
            {
                column.Visible = true;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.ReadOnly = true;
            }

            dtgDisenioCrediticio.Columns["dFecha"].Visible = false;
            dtgDisenioCrediticio.Columns["nCuota"].Visible = false;
            dtgDisenioCrediticio.Columns["idDisCred"].Visible = false;

            dtgDisenioCrediticio.Columns["nMontoCuota"].DefaultCellStyle.Format = "n2";
            dtgDisenioCrediticio.Columns["nCapIntSeg"].DefaultCellStyle.Format = "n2";
            dtgDisenioCrediticio.Columns["nExedenteFinal"].DefaultCellStyle.Format = "n2";

            dtgDisenioCrediticio.Columns["cMesCuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDisenioCrediticio.Columns["nDiaDesembolso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDisenioCrediticio.Columns["nMontoCuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDisenioCrediticio.Columns["nCapIntSeg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDisenioCrediticio.Columns["nExedenteFinal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgDisenioCrediticio.Columns["cMesCuota"].HeaderText = "Mes de Cuota";
            dtgDisenioCrediticio.Columns["nDiaDesembolso"].HeaderText = "Día de Desembolso o Pago";
            dtgDisenioCrediticio.Columns["nMontoCuota"].HeaderText = "Monto de Cuota";
            dtgDisenioCrediticio.Columns["nCapIntSeg"].HeaderText = "Capital + Interes";
            dtgDisenioCrediticio.Columns["nExedenteFinal"].HeaderText = "Exedente Final";

        }

        private void FormatearDataGridView()
        {
            this.dtgFlujoPrincipal.Margin = new System.Windows.Forms.Padding(0);
            this.dtgFlujoPrincipal.MultiSelect = false;
            this.dtgFlujoPrincipal.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgFlujoPrincipal.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgFlujoPrincipal.RowHeadersVisible = false;
            this.dtgFlujoPrincipal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgFlujoPrincipal.ReadOnly = true;

            this.dtgDisenioCrediticio.Margin = new System.Windows.Forms.Padding(0);
            this.dtgDisenioCrediticio.MultiSelect = false;
            this.dtgDisenioCrediticio.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgDisenioCrediticio.ColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgDisenioCrediticio.RowHeadersVisible = false;
            this.dtgDisenioCrediticio.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        private void RealizarCalculos()
        {
            bool ldegrav = true;
            decimal seguro = 0;
            decimal capitalProp = this.txtMonto.Text == string.Empty ? 0 : this.nMontoPropuesto;

            if (ldegrav)
                seguro = capitalProp * 0;//0.001183m;
            else
                seguro = capitalProp * 0;//0.000914m;

            int nCuota = 0;

            List<clsCalculoDisenioCred> lstFechas = new List<clsCalculoDisenioCred>();

            foreach (var item in this.listFlujoCaja)
            {
                item.nCuota = nCuota;
                nCuota += 1;
            }

            nCuota = 0;

            foreach (var item in this.listDisenioCredito)
            {
                item.nCuota = nCuota;
                DateTime oPrimerDiaDelMes = new DateTime(item.dFecha.Value.Year, item.dFecha.Value.Month, 1);

                if (item.nDiaDesembolso <= 0)
                    item.nDiaDesembolso = 1;
                else if (item.nDiaDesembolso > oPrimerDiaDelMes.AddMonths(1).AddDays(-1).Day)
                    item.nDiaDesembolso = oPrimerDiaDelMes.AddMonths(1).AddDays(-1).Day;

                if (nCuota == 0)
                    item.nDiaDesembolso = this.dFechaDesembolso.Day;
                else if (nCuota == 1 && this.dFechaMinima > new DateTime(item.dFecha.Value.Year, item.dFecha.Value.Month, item.nDiaDesembolso) && this.idTipoPeriodo == (int)eTipoPeriodoCred.CuotasLibres)
                    item.nDiaDesembolso = this.dFechaMinima.Day;
                else
                    item.nDiaDesembolso = item.nDiaDesembolso;


                if (item.nMontoCuota < 0)
                    item.nMontoCuota = 0;
                else
                    item.nMontoCuota = item.nMontoCuota;

                item.dFecha = new DateTime(item.dFecha.Value.Year, item.dFecha.Value.Month, item.nDiaDesembolso);

                clsCalculoDisenioCred row = new clsCalculoDisenioCred();
                row.nCuota = nCuota;
                row.dFecha = item.dFecha;
                row.nMontoCuota = -(item.nMontoCuota);
                row.nExedenteMensual = this.listFlujoCaja.Find(x => x.nFecha == Convert.ToInt32(String.Format("{0:yyyyMM}", item.dFecha))).nExedMensual;
                row.nExedenteFinal = item.nExedenteFinal;

                lstFechas.Add(row);

                nCuota += 1;
            }

            foreach (var item in lstFechas)
            {
                if (item.nCuota == 0)
                {
                    item.ntotalSeguroDegrav = 0.00m;
                    item.nAbonoInteres = 0.00m;
                    item.nInteresLapso = 0.00m;
                    item.nInteresVigente = 0.00m;
                    item.nAbonoCapital = 0.00m;
                    item.nCapital = capitalProp;
                    item.nTotal = capitalProp;
                    item.nExedenteFinal = this.nMontoCajaIncial + capitalProp + item.nExedenteMensual;
                }
                else
                {
                    decimal nSeguroDegravAnt = lstFechas.Find(x => x.nCuota == (item.nCuota - 1)).ntotalSeguroDegrav;
                    decimal nCapitalAnt = lstFechas.Find(x => x.nCuota == (item.nCuota - 1)).nCapital;
                    decimal nInteresLapsoAnt = lstFechas.Find(x => x.nCuota == (item.nCuota - 1)).nInteresLapso;
                    decimal nAbonoInteresAnt = lstFechas.Find(x => x.nCuota == (item.nCuota - 1)).nAbonoInteres;
                    decimal nInteresVigenteAnt = lstFechas.Find(x => x.nCuota == (item.nCuota - 1)).nInteresVigente;
                    decimal nExedenteFinalAnt = lstFechas.Find(x => x.nCuota == (item.nCuota - 1)).nExedenteFinal;
                    bool lMismoMes = false;
                    if (String.Format("{0:yyyyMM}", lstFechas.Find(x => x.nCuota == (item.nCuota - 1)).dFecha) == String.Format("{0:yyyyMM}", item.dFecha))
                    {
                        lMismoMes = true;
                    }

                    DateTime dFechaAnt = (DateTime)lstFechas.Find(x => x.nCuota == (item.nCuota - 1)).dFecha;
                    TimeSpan difFechas = (TimeSpan)(item.dFecha - dFechaAnt);

                    //decimal TEA = 0.26m;
                    //decimal TEM =  Convert.ToDecimal((Math.Pow(Convert.ToDouble(TEA + 1), 1.0/12.0)) - 1.0);
                    decimal TEM = this.nTEM / 100;


                    item.nInteresLapso = (nCapitalAnt * TEM / 360 * 12) * (difFechas.Days);
                    item.nInteresVigente = item.nInteresLapso + nInteresVigenteAnt - nAbonoInteresAnt;

                    if (-(item.nMontoCuota) >= item.nInteresVigente)
                        item.nAbonoCapital = -(item.nMontoCuota) - item.nInteresVigente;
                    else
                        item.nAbonoCapital = 0;

                    if (-(item.nMontoCuota) <= item.nInteresVigente)
                        item.nAbonoInteres = -(item.nMontoCuota);
                    else
                        item.nAbonoInteres = item.nInteresVigente;

                    item.nCapital = nCapitalAnt - item.nAbonoCapital + item.nInteresLapso - item.nAbonoInteres;

                    item.ntotalSeguroDegrav = seguro + nSeguroDegravAnt;

                    item.nExedenteFinal = nExedenteFinalAnt + (lMismoMes ? 0 : item.nExedenteMensual) + item.nMontoCuota;

                    item.nTotal = item.ntotalSeguroDegrav + item.nCapital;

                }
            }

            foreach (var item in this.listDisenioCredito)
            {
                item.nCapIntSeg = lstFechas.Find(x => x.nCuota == item.nCuota).nTotal;
                item.nExedenteFinal = lstFechas.Find(x => x.nCuota == item.nCuota).nExedenteFinal;
            }

            if (this.idTipoPeriodo == (int)eTipoPeriodoCred.PeriodoFijo && this.idPeriodo == (int)ePeriodoCred.Mensual)
            {
                foreach (var item in this.listDisenioCredito)
                {
                    if (item.nCuota > 0)
                    {
                        var Row = this.dtCalendarioPlanPago.Select("cuota = " + item.nCuota);
                        item.nMontoCuota = Convert.ToDecimal(Row[0]["imp_cuota"]);
                        item.dFecha = Convert.ToDateTime(Row[0]["fecha"]);
                        item.nDiaDesembolso = Convert.ToDateTime(Row[0]["fecha"]).Day;
                        item.cMesCuota = Convert.ToDateTime(item.dFecha).ToString("MMM - yy");
                    }
                }

                this.listDisenioCredito.Last().nCapIntSeg = decimal.Zero;

            }
            else if (this.idTipoPeriodo == (int)eTipoPeriodoCred.PeriodoFijo && this.idPeriodo == (int)ePeriodoCred.Unicuota)
            {
                var Row = this.dtCalendarioPlanPago.Rows[0];
                this.listDisenioCredito.Last().nMontoCuota = Convert.ToDecimal(Row["imp_cuota"]);
                this.listDisenioCredito.Last().dFecha = Convert.ToDateTime(Row["fecha"]);
                this.listDisenioCredito.Last().nDiaDesembolso = Convert.ToDateTime(Row["fecha"]).Day;
                this.listDisenioCredito.Last().nCapIntSeg = decimal.Zero;
            }

            this.dtgDisenioCrediticio.Refresh();

            ValidaDiseñoCrediticio();
        }

        private string ValidaDiseñoCrediticio()
        {
            List<clsAlertasDisCredEvalRural> lstAlertas = new List<clsAlertasDisCredEvalRural>();
            lstAlertas.Clear();

            decimal nNecCre = (txtNecesidadCredito.Text != "") ? Convert.ToDecimal(txtNecesidadCredito.Text) : 0m;
            decimal nMonPro = (txtMonto.Text != "") ? Convert.ToDecimal(txtMonto.Text) : 0m;

            if (this.listFlujoCaja.Count <= 0 || this.listDisenioCredito.Count <= 0)
                return "";

            var lstFluCaj = this.listFlujoCaja.FindAll(x => x.nCuota != 0);
            var lstDisCre = this.listDisenioCredito.FindAll(x => x.nCuota != 0);

            //Validacion 1: Necesidad mayor al monto propuesto

            if (nMonPro < (nNecCre * -1) && this.idOperacion == 1)
            {
                var objAlerta = new clsAlertasDisCredEvalRural();
                objAlerta.nAlerta = 1;
                objAlerta.cMensaje = "REVISAR: Necesidad mayor al monto propuesto.";
                lstAlertas.Add(objAlerta);
            }

            //Validacion 2: Monto propuesto supera en más del 10% a la necesidad del crédito

            if (nMonPro > ((nNecCre * -1) * 1.10m) && this.idOperacion == 1)
            {
                var objAlerta = new clsAlertasDisCredEvalRural();
                objAlerta.nAlerta = 2;
                objAlerta.cMensaje = "REVISAR: Monto propuesto supera en más del 10% a la necesidad del crédito.";
                lstAlertas.Add(objAlerta);
            }

            //Validacion 3: Propuesta no muestra necesidad de financiamiento

            if(nNecCre == 0 && this.idOperacion == 1)
            {
                var objAlerta = new clsAlertasDisCredEvalRural();
                objAlerta.nAlerta = 3;
                objAlerta.cMensaje = "REVISAR: Propuesta no muestra necesidad de financiamiento.";
                lstAlertas.Add(objAlerta);
            }

            //Validacion 4: Existe cuotas altas en relación al excedente

            var resultado = from p in lstDisCre
                            join q in lstFluCaj on p.nCuota equals q.nCuota
                            select new { q.nExedMensual, p.nMontoCuota };

            if (resultado.ToList().Exists(x => x.nExedMensual < x.nMontoCuota && x.nMontoCuota != 0))
            {
                var objAlerta = new clsAlertasDisCredEvalRural();
                objAlerta.nAlerta = 4;
                objAlerta.cMensaje = "REVISAR: Existe cuotas altas en relación al excedente.";
                lstAlertas.Add(objAlerta);
            }

            //Validacion 5: Los intereses no han sido cubiertos en su totalidad

            if (lstDisCre.Last().nCapIntSeg > 1.0m)
            {
                var objAlerta = new clsAlertasDisCredEvalRural();
                objAlerta.nAlerta = 5;
                objAlerta.cMensaje = "REVISAR: Los intereses no han sido cubiertos en su totalidad.";
                lstAlertas.Add(objAlerta);
            }

            string msgAlertas = string.Empty;

            foreach (var item in lstAlertas)
            {
                msgAlertas += "\n"+ item.cMensaje;
            }

            this.txtConAlertas.Text = lstAlertas.Count.ToString();

            if(lstAlertas.Count > 0)
                errorProvider.SetError(this.txtConAlertas, "Existen alertas por revisar.");
            else
                errorProvider.Clear();

            return msgAlertas;
        }

        #endregion


        #region Eventos

        private void dtgDisenioCrediticio_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            RealizarCalculos();
        }

        private void nudCuotas_ValueChange(object sender, EventArgs e)
        {
            if (nudCuotasValueChange != null)
                nudCuotasValueChange(sender, e);
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            this.nMontoPropuesto = this.txtMonto.Text == string.Empty ? 0 : Convert.ToDecimal(this.txtMonto.Text);
            RealizarCalculos();
        }

        private void btnValidar_click(object sender, EventArgs e)
        {
            string msgAlertas = ValidaDiseñoCrediticio();

            if (msgAlertas != string.Empty)
                MessageBox.Show("Debera correguir las siguientes alertas: " + msgAlertas, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("No se tiene ninguna Alerta por revisar. ", "CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dtgFlujoPrincipal_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            HashSet<string> set = new HashSet<string>();
            foreach (DataGridViewRow row in this.dtgFlujoPrincipal.Rows)
            {
                string key = row.Cells["nFecha"].Value.ToString();
                if (!set.Add(key))
                {
                    row.DefaultCellStyle.BackColor = Color.Orange;
                }
            }

        }
        #endregion
    }
}
