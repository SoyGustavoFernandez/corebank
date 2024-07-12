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
using CRE.CapaNegocio;
using System.Diagnostics;

namespace GEN.ControlesBase
{
    public partial class ConCreditoPrimeraCuota : UserControl
    {
        public event EventHandler ValueChangedFecha;
        public int idTipoPeriodo { get; set; }
        public int idPeriodo { get; set; }
        public int nPeriodoDia { get; set; }
        public int nDiasGracia { get; set; }
        public DateTime dFechaDesembolso { get; set; }

        public DateTime dFechaSelec { get; set; }
        public DateTime dFechaEsperada { get; set; }
        public DateTime dFecha
        {
            get;
            private set;
        }
        public int nDia { get; private set; }
        public bool lDiaAjustado { get; private set; }

        public bool lFechaSelec { get; set; }
        public bool lFechaEnabled
        {
            get
            {
                return this.dtpFecha.Enabled;
            }
            set
            {
                this.dtpFecha.Enabled = value;
            }
        }
        public string cFormatoFecha
        {
            get
            {
                return this.dtpFecha.CustomFormat;
            }
            set
            {
                this.dtpFecha.Format = DateTimePickerFormat.Custom;
                this.dtpFecha.CustomFormat = value;
            }
        }

        public ConCreditoPrimeraCuota()
        {
            InitializeComponent();

            DateTime dFechaSistem = clsVarGlobal.dFecSystem;

            if (clsVarGlobal.dFecSystem.Day > 21) 
            {
                dFechaSistem = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1).AddMonths(1);
            }

            this.dtpFecha.MinDate = dFechaSistem;
            this.lFechaSelec = false;
        }
        public void SetFechaPriCuota(DateTime dFechaPriCuota)
        {
            this.dtpFecha.ValueChanged -= this.dtpFecha_ValueChanged;
            var a  = dtpFecha.MinDate;
            dtpFecha.Value = dFechaPriCuota;

            this.dtpFecha.ValueChanged += this.dtpFecha_ValueChanged;
        }

        public DateTime fechaMinima()
        {
            return dtpFecha.MinDate;
        }

        public DateTime dFechaPriCuota()
        {
            return this.dtpFecha.Value;
        }
        
        public void inicializarFecha(DateTime dFechaDesembolso, int idTipoPeriodo = (int)TipoPeriodo.FechaFija)
        {
            int nDiasAdd = 31;
            if (idTipoPeriodo == (int)TipoPeriodo.FechaFija)
            {
                this.dtpFecha.MinDate = dFechaDesembolso.AddDays(20);
            }
            else
            {
                this.dtpFecha.MinDate = dFechaDesembolso.AddDays(30);                
            }

            this.dtpFecha.ValueChanged -= this.dtpFecha_ValueChanged;
            this.dtpFecha.Value = dFechaDesembolso.AddDays(nDiasAdd);
            this.dFecha = this.dtpFecha.Value;
            this.dtpFecha.ValueChanged += this.dtpFecha_ValueChanged;
        }
        public void actualizarDiasGracia(int nDiasGracia)
        {
            this.nDiasGracia = nDiasGracia;
            this.calcularFecha(this.idTipoPeriodo, this.nPeriodoDia, this.nDiasGracia, this.dFechaDesembolso);
        }
        public void actualizarFechaDesembolso(DateTime dFechaDesembolso)
        {
            this.dFechaDesembolso = dFechaDesembolso;
            this.calcularFecha(this.idTipoPeriodo, this.nPeriodoDia, this.nDiasGracia, this.dFechaDesembolso);
        }
        public void calcularFecha(int idTipoPeriodo, int nPeriodoDia, int nDiasGracia, DateTime dFechaDesembolso)
        {
            this.idTipoPeriodo = idTipoPeriodo;
            this.nPeriodoDia = nPeriodoDia;
            this.nDiasGracia = nDiasGracia;
            this.dFechaDesembolso = dFechaDesembolso;
            this.lDiaAjustado = false;

            this.habilitarFecha();

            if (this.idTipoPeriodo == (int)TipoPeriodo.PeriodoFijo)
            {
                this.dFecha = this.dFechaDesembolso.AddDays(this.nDiasGracia);
                this.dFecha = this.dFecha.AddDays(this.nPeriodoDia);
                this.nDia = this.nPeriodoDia;
            }
            else if (this.idTipoPeriodo == (int)TipoPeriodo.FechaFija)
            {
                int nDia = (this.nPeriodoDia > 28) ? 28 : this.nPeriodoDia;
                int nMes = this.dFechaDesembolso.Month + 1;
                int nAnio = this.dFechaDesembolso.Year;

                if (nMes > 12)
                {
                    nAnio++;
                    nMes = 1;
                }

                while (nDia > 0)
                {
                    string cFechaPrimera = string.Concat(nAnio, "-", nMes, "-", nDia);
                    DateTime dFechaPrimera;
                    if (DateTime.TryParse(cFechaPrimera, out dFechaPrimera))
                    {
                        this.dFecha = dFechaPrimera.AddDays(this.nDiasGracia);                        
                        break;
                    }
                    nDia--;
                }              

                if ((this.dFecha - dFechaDesembolso).TotalDays < 30)
                {
                    DateTime dFechaAjuste;
                    if (DateTime.TryParse(
                        string.Concat(this.dFecha.Year, "-", (this.dFecha.Month + 1), "-", this.dFecha.Day),
                        out dFechaAjuste))
                    {
                        this.dFecha = dFechaAjuste;
                    }
                    else
                    {
                        this.dFecha.AddMonths(1);
                    }
                    this.dtpFecha.MaxDate = this.dFecha;
                }

                this.nDia = this.dFecha.Day;
                if (this.dFecha.Day != nPeriodoDia)
                    this.lDiaAjustado = true;

                if (this.dFecha < this.dtpFecha.MinDate.Date)
                {
                    this.dFecha = this.dtpFecha.MinDate.Date;
                }
                else if (this.dFecha > this.dtpFecha.MaxDate.Date)
                {
                    this.dFecha = this.dtpFecha.MaxDate.Date;
                }
            }
            else
            {
                this.dFecha = this.dFechaDesembolso.AddMonths(1);
                this.nDia = this.dFecha.Day;
            }
            this.dtpFecha.ValueChanged -= dtpFecha_ValueChanged;
            this.dtpFecha.Value = this.dFecha;            
            this.dtpFecha.ValueChanged += dtpFecha_ValueChanged;            
        }
        private void habilitarFecha()
        {
            dtpFecha.ValueChanged -= dtpFecha_ValueChanged;
            if (this.idTipoPeriodo == (int)TipoPeriodo.FechaFija)
            {
                DateTime dFechaDesembolsoTmp = this.dFechaDesembolso;
                this.dtpFecha.MinDate = dFechaDesembolsoTmp.AddDays(30);
                dFechaDesembolsoTmp = this.dFechaDesembolso;
                this.dtpFecha.MaxDate = dFechaDesembolsoTmp.AddDays(90);                
            }
            else
            {
                DateTime dFechaDesembolsoTmp = this.dFechaDesembolso;
                this.dtpFecha.MinDate = dFechaDesembolsoTmp.AddDays(1);
                dFechaDesembolsoTmp = this.dFechaDesembolso;
                this.dtpFecha.MaxDate = dFechaDesembolsoTmp.AddDays(1440);
            }
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
        }
        public void asignarPrimeraCuotaReprog(int idTipoPeriodo, int nPeriodoDia, int nDiasGracia, DateTime dFechaDesembolso,
            int nCuotas, int idOperacion, DateTime dFechaProxVenc = default(DateTime), bool lUnicuota = false)
        {
            this.habilitarFecha(idTipoPeriodo, (lUnicuota ? 10 : 0), idOperacion);
            this.lFechaSelec = true;

            if (lUnicuota)
            {
                this.idPeriodo = 10; //Unicuota
            }
            else
            {
                this.idPeriodo = 0;
            }

            this.calcPrimCuotaEsperada(idTipoPeriodo, nPeriodoDia, dFechaDesembolso, this.idPeriodo);
            if (idOperacion == (int)OperacionCredito.ReprogramacionCambioFecha && dFechaProxVenc > default(DateTime))
            {
                this.dFechaSelec = dFechaProxVenc;
            }
            else
            {
                this.dFechaSelec = this.dFechaEsperada.AddDays(nDiasGracia);
            }

            if (this.dFechaSelec.Day != nPeriodoDia && idTipoPeriodo == (int)TipoPeriodo.FechaFija)
            {
                this.lDiaAjustado = true;
                this.nPeriodoDia = this.dFechaSelec.Day;
            }
            else
            {
                this.lDiaAjustado = false;
                this.nPeriodoDia = nPeriodoDia;
            }

            int nDiffDias = (int)(this.dFechaSelec - this.dFechaEsperada).TotalDays;
            if (nDiffDias > 0 && this.lFechaSelec &&
                (this.idTipoPeriodo == (int)TipoPeriodo.FechaFija ||
                idOperacion == (int)OperacionCredito.ReprogramacionCambioFecha ||
                (this.idTipoPeriodo == (int)TipoPeriodo.PeriodoFijo && this.idPeriodo != 10))) //Unicuota = 10
            {
                this.nDiasGracia = nDiffDias;
            }
            else
            {
                this.nDiasGracia = 0;
            }

            this.dtpFecha.ValueChanged -= dtpFecha_ValueChanged;
            this.asignarLimiteFecha(idTipoPeriodo, nPeriodoDia, dFechaDesembolso, this.dFechaSelec);

            this.dtpFecha.Value = this.dFechaSelec;
            this.dFecha = this.dFechaSelec;
            this.dtpFecha.ValueChanged += dtpFecha_ValueChanged;

            this.lFechaSelec = false;

        }
        private DateTime crearFecha(int nAnio, int nMes, int nDia)
        {
            if (nMes > 12)
            {
                nAnio++;
                nMes = 1;
            }
            DateTime dFechaCreada = default(DateTime);
            while (nDia > 0)
            {
                string cFechaPrimera = string.Concat(nAnio, "-", nMes, "-", nDia);

                if (DateTime.TryParse(cFechaPrimera, out dFechaCreada))
                {
                    break;
                }
                nDia--;
            }
            return dFechaCreada;
        }
        public DateTime reconstuirFechaSelec(DateTime dFechaDesembolso, int idTipoPeriodo, int nPeriodoDia, int nDiasGracia, DateTime dFechaEsperada)
        {
            if (idTipoPeriodo == (int)TipoPeriodo.FechaFija)
            {

                DateTime dFechaSuperior = this.crearFecha(dFechaDesembolso.Year, dFechaDesembolso.Month + 1, nPeriodoDia);
                DateTime dFechaInferior = this.crearFecha(dFechaDesembolso.Year, dFechaDesembolso.Month, nPeriodoDia);
                if (dFechaSuperior <= dFechaEsperada)
                {
                    dFechaInferior = dFechaSuperior;
                    dFechaSuperior = this.crearFecha(dFechaSuperior.Year, dFechaSuperior.Month + 1, nPeriodoDia);
                }
                
                if (nDiasGracia == 0 && dFechaInferior <= dFechaEsperada)
                {
                    if ((dFechaInferior - dFechaDesembolso).TotalDays < 20)
                    {
                        return dFechaDesembolso.AddDays(20);
                    }
                    else
                    {
                        return dFechaInferior;
                    }
                }
                else if ((dFechaSuperior - dFechaEsperada).TotalDays == nDiasGracia)
                {
                    return dFechaSuperior;
                }
                else
                {
                    return dFechaEsperada.AddDays(nDiasGracia);
                }
            }
            else if(idTipoPeriodo == (int)TipoPeriodo.CuotasLibres)
            {
                return dFechaEsperada;
            }
            else
            {
                return dFechaDesembolso.AddDays(nPeriodoDia + nDiasGracia);
            }
        }
        public void asignarPrimeraCuota(int idTipoPeriodo, int nPeriodoDia, int nDiasGracia, DateTime dFechaDesembolso,
            int nCuotas, int idOperacion, DateTime dFechaProxVenc = default(DateTime), int idPeriodo = 0, int idsolicitud = 0)
        {
            this.lFechaSelec = true;
            if (idTipoPeriodo == (int)TipoPeriodo.PeriodoFijo && nCuotas == 1 && idPeriodo == 0)
            {
                this.idPeriodo = 10; //Unicuota
            }
            else
            {
                this.idPeriodo = idPeriodo;
            }
            this.habilitarFecha(idTipoPeriodo, this.idPeriodo, idOperacion);

            this.calcPrimCuotaEsperada(idTipoPeriodo, nPeriodoDia, dFechaDesembolso, this.idPeriodo, idsolicitud);
            if (idOperacion == (int)OperacionCredito.ReprogramacionCambioFecha && dFechaProxVenc > default(DateTime))
            {
                this.dFechaSelec = dFechaProxVenc;
            }
            else
            {
                this.dFechaSelec = this.reconstuirFechaSelec(dFechaDesembolso, idTipoPeriodo, nPeriodoDia, nDiasGracia, this.dFechaEsperada);
            }

            if (this.dFechaSelec.Day != nPeriodoDia && idTipoPeriodo == (int)TipoPeriodo.FechaFija)
            {
                this.lDiaAjustado = true;
                this.nPeriodoDia = this.dFechaSelec.Day;
            }
            else
            {
                this.lDiaAjustado = false;
                this.nPeriodoDia = nPeriodoDia;
            }

            int nDiffDias = (int)(this.dFechaSelec - this.dFechaEsperada).TotalDays;
            if (nDiffDias > 0 && this.lFechaSelec &&
                (this.idTipoPeriodo == (int)TipoPeriodo.FechaFija ||
                idOperacion == (int)OperacionCredito.ReprogramacionCambioFecha ||
                (this.idTipoPeriodo == (int)TipoPeriodo.PeriodoFijo && this.idPeriodo != 10))) //Unicuota = 10
            {
                this.nDiasGracia = nDiffDias;
            }
            else
            {
                this.nDiasGracia = 0;
            }

            this.dtpFecha.ValueChanged -= dtpFecha_ValueChanged;
            this.asignarLimiteFecha(idTipoPeriodo, nPeriodoDia, dFechaDesembolso, this.dFechaSelec);

            this.dtpFecha.Value = this.dFechaSelec;
            this.dFecha =  this.dFechaSelec;
            this.dtpFecha.ValueChanged += dtpFecha_ValueChanged;

            this.lFechaSelec = false;

        }

        public void calcPrimeraCuota(int idTipoPeriodo, int nPeriodoDia, DateTime dFechaDesembolso, int idPeriodo, int idsolicitud = 0)
        {
            this.calcPrimCuotaEsperada(idTipoPeriodo, nPeriodoDia, dFechaDesembolso, idPeriodo, idsolicitud);

            if (this.idTipoPeriodo == (int)TipoPeriodo.PeriodoFijo && this.idPeriodo == 10)
                this.dtpFecha.MinDate = dFechaDesembolso.AddDays(30);
            else
                this.asignarLimiteFecha(idTipoPeriodo, nPeriodoDia, dFechaDesembolso, this.dFechaEsperada);

            int nDiffDias = (int)(this.dFechaSelec - this.dFechaEsperada).TotalDays;
            if (nDiffDias > 0 && this.lFechaSelec && 
                (this.idTipoPeriodo == (int)TipoPeriodo.FechaFija ||
                (this.idTipoPeriodo == (int)TipoPeriodo.PeriodoFijo && this.idPeriodo != 10))) //Unicuota = 10
            {
                this.nDiasGracia = nDiffDias;                
            }
            else
            {
                this.nDiasGracia = 0;
            }

            this.dtpFecha.ValueChanged -= this.dtpFecha_ValueChanged;
            if (this.idTipoPeriodo == (int)TipoPeriodo.CuotasLibres)
            {
                if (this.dFechaSelec < this.dtpFecha.MinDate)
                {
                    this.dFechaSelec = this.dtpFecha.MinDate;
                }
                this.dtpFecha.Value = this.dFechaEsperada;
                this.nPeriodoDia = this.dFechaSelec.Day;
                this.nDia = this.dFechaSelec.Day;
            }
            else if (this.idTipoPeriodo == (int)TipoPeriodo.FechaFija)
            {

                if (this.lFechaSelec)
                {
                    if (this.dFechaSelec < this.dtpFecha.MinDate)
                    {
                        this.dFechaSelec = this.dtpFecha.MinDate;
                    }

                    this.dtpFecha.Value = this.dFechaSelec;
                    this.nPeriodoDia = this.dFechaSelec.Day;
                    this.nDia = this.dFechaSelec.Day;
                }
                else
                {
                    this.dtpFecha.Value = this.dFechaEsperada;
                    this.nPeriodoDia = this.dFechaSelec.Day;
                    this.nDia = this.dFechaEsperada.Day;
                }
            }
            else
            {
                if (this.idPeriodo == 10)//Unicuota
                {
                    if (this.dFechaSelec < this.dtpFecha.MinDate)
                    {
                        this.dFechaSelec = this.dtpFecha.MinDate;
                    }

                    this.dtpFecha.Value = this.dFechaSelec;
                    this.nPeriodoDia = (int)(this.dFechaSelec - this.dFechaDesembolso).TotalDays;
                    this.nDiasGracia = 0;
                    this.nDia = this.nPeriodoDia;
                }
                else if (this.lFechaSelec)
                {
                    if (this.dFechaSelec < this.dtpFecha.MinDate)
                    {
                        this.dFechaSelec = this.dtpFecha.MinDate;
                    }

                    this.dtpFecha.Value = this.dFechaSelec;
                    this.nPeriodoDia = (int)(this.dFechaSelec - this.dFechaDesembolso).TotalDays;
                    this.nPeriodoDia = (this.nPeriodoDia / 30) * 30;
                    this.nDia = 0;
                }
                else
                {
                    this.dtpFecha.Value = this.dFechaEsperada;
                    this.nPeriodoDia = (int)(this.dFechaEsperada - this.dFechaDesembolso).TotalDays;
                    this.nDia = 0;
                }
            }
            this.dFecha = this.dtpFecha.Value;
            this.dtpFecha.ValueChanged += this.dtpFecha_ValueChanged;
        }
        public DateTime calcPrimCuotaEsperada(int idTipoPeriodo, int nPeriodoDia, DateTime dFechaDesembolso, int idPeriodo, int idsolicitud = 0)
        {
            this.dFechaEsperada = dFechaDesembolso;
            this.dFechaDesembolso = dFechaDesembolso;
            this.idTipoPeriodo = idTipoPeriodo;
            this.idPeriodo = idPeriodo;

            if (idTipoPeriodo == (int)TipoPeriodo.PeriodoFijo)
            {
                if (idPeriodo == 10 && this.dFechaSelec > clsVarGlobal.dFecSystem) //Unicuota
                {
                    this.dFechaEsperada = this.dFechaSelec;
                    this.nPeriodoDia = (int)(this.dFechaSelec - dFechaDesembolso).TotalDays;
                    this.lFechaSelec = true;
                }
                else
                {
                    this.dFechaEsperada = dFechaDesembolso;
                    this.dFechaEsperada = dFechaEsperada.AddDays(nPeriodoDia);
                }
            }
            else if (idTipoPeriodo == (int)TipoPeriodo.FechaFija)
            {
                if(this.lFechaSelec)
                    nPeriodoDia = dFechaDesembolso.Day;
                this.dFechaEsperada = this.crearFecha(dFechaDesembolso.Year, dFechaDesembolso.Month + 1, nPeriodoDia);

                if ((dFechaEsperada - dFechaDesembolso).TotalDays < 20)
                {
                    this.dFechaEsperada = this.crearFecha(dFechaEsperada.Year, dFechaEsperada.Month + 1, dFechaEsperada.Day);
                }
            }
            else if (idTipoPeriodo == (int)TipoPeriodo.CuotasLibres)
            {
                DataTable dtDisenioCrediticio = new clsCNEvalCrediRural().ObtenerConfiguracionDiseCredRuralxSolicitud(idsolicitud);

                if (dtDisenioCrediticio.Rows.Count == 0)
                    this.dFechaEsperada = dFechaDesembolso.AddMonths(1);
                else
                    this.dFechaEsperada = (DateTime)dtDisenioCrediticio.Rows[0]["dFechaPrimeraCuota"];
            }
            else
            {
                this.dFechaEsperada = dFechaDesembolso.AddMonths(1);
            }

            return this.dFechaEsperada;
        }
        public void resetearFechaSelec(DateTime dFechaDesembolso, int idTipoPeriodo, ref int nPerDiaReset)
        {
            this.dtpFecha.ValueChanged -= this.dtpFecha_ValueChanged;
            if (idTipoPeriodo == (int)TipoPeriodo.CuotasLibres)
            {
                nPerDiaReset = 0;
                this.dFechaSelec = dFechaDesembolso.AddDays(nPerDiaReset);
            }
            else if (idTipoPeriodo == (int)TipoPeriodo.FechaFija)
            {
                this.dFechaSelec = this.crearFecha(dFechaDesembolso.Year, dFechaDesembolso.Month + 1, dFechaDesembolso.Day);
                nPerDiaReset = this.dFechaSelec.Day;
            }
            else
            {
                this.dFechaSelec = dFechaDesembolso.AddDays(30);
                nPerDiaReset = 30;
            }
            this.asignarLimiteFecha(this.idTipoPeriodo, this.nPeriodoDia, dFechaDesembolso, this.dFechaSelec);
            this.dtpFecha.Value = this.dFechaSelec;
            this.dtpFecha.ValueChanged += this.dtpFecha_ValueChanged;
        }
        public void asignarLimiteFecha(int idTipoPeriodo, int nPeriodoDia, DateTime dFechaDesembolso, DateTime dFechaSelec)
        {
            DateTime dFechaMin = dFechaDesembolso;
            if (idTipoPeriodo == (int)TipoPeriodo.PeriodoFijo)
            {
                if (this.idPeriodo == 10)
                    dFechaMin = dFechaMin.AddDays(30);
                else
                    dFechaMin = dFechaMin.AddDays(nPeriodoDia);
            }
            else
            {
                dFechaMin = dFechaMin.AddDays(20);
            }

            if (dFechaMin > dFechaSelec)
            {
                this.dtpFecha.MinDate = dFechaSelec;
            }
            else
            {
                this.dtpFecha.MinDate = dFechaMin;
            }
        }
        public void habilitarFecha(int idTipoPeriodo, int idPeriodo, int idOperacion = 0)
        {
            if (idTipoPeriodo == (int)TipoPeriodo.FechaFija || idPeriodo == 10 ||
                idOperacion == (int)OperacionCredito.ReprogramacionCambioFecha) //Unicuota
                this.dtpFecha.Enabled = true;
            else
                this.dtpFecha.Enabled = false;
        }
        public void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            DateTime dFechaSis = clsVarGlobal.dFecSystem;
            this.lFechaSelec = true;
            this.dFechaSelec = this.dtpFecha.Value;
            if (this.dFechaSelec < dFechaSis.AddDays(1))
            {
                this.dtpFecha.ValueChanged -= dtpFecha_ValueChanged;
                this.dtpFecha.Value = dFechaSis.AddDays(1);
                this.dFechaSelec = this.dtpFecha.Value;
                this.dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            }
            if (this.dFechaSelec < this.dtpFecha.MinDate)
            {
                this.dFechaSelec = this.dtpFecha.MinDate.Date;
            }            

            this.nPeriodoDia = this.dFechaSelec.Day;
            this.nDia = this.dFechaSelec.Day;
            this.dtpFecha.ValueChanged -= dtpFecha_ValueChanged;
            this.dtpFecha.Value = this.dFechaSelec;
            this.dtpFecha.ValueChanged += dtpFecha_ValueChanged;

            if (ValueChangedFecha != null)
                ValueChangedFecha(sender, e);

        }
        private void ConCreditoPrimeraCuota_Load(object sender, EventArgs e)
        {
            this.dtpFecha.ValueChanged -= dtpFecha_ValueChanged;
            this.dtpFecha.MinDate = clsVarGlobal.dFecSystem;
            this.dtpFecha.ValueChanged += dtpFecha_ValueChanged;
        }
    }
}
