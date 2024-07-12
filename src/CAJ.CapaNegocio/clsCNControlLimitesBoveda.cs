using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAJ.AccesoDatos;
using System.Data;
using EntityLayer;

namespace CAJ.CapaNegocio
{
    public enum eEstadoSolicitud 
    { 
        SinSolicitar = 0,
        Solicitado = 1,
        Aprobado = 2,
        Autoaprobado = 3
    }

    public class clsEstSolCirrBov 
    {
        public eEstadoSolicitud nEstado { get; set; }
        public Int32 idMotivoExt { get; set; }
        public String cSustento { get; set; }
        public Int32 idSolicitud { get; set; }
    }

    public class clsCNControlLimitesBoveda
    {
        #region Variables
        clsADControlLimitesBoveda oAD = new clsADControlLimitesBoveda();
        clsADControlOpe oADControlOpe = new clsADControlOpe();
        clsCNControlOpe oCNControlOpe = new clsCNControlOpe();
        public Decimal nSaldoSoles { get; set; }
        public Decimal nSaldoDolares { get; set; }

        public Decimal nMontoLim { get; set; }
        public Decimal nXlimMenor { get; set; }
        public Decimal nXlimMedio { get; set; }
        public Decimal nXlimMayor { get; set; }
        public Decimal nMontoLimDol { get; set; }
        public Decimal nXlimMenorDol { get; set; }
        public Decimal nXlimMedioDol { get; set; }
        public Decimal nXlimMayorDol { get; set; }
        
        public Int32 idUsuario { get; set; }
        public Int32 idAgencia { get; set; }
        public DateTime dFechaOpe { get; set; }
        public Int32 idEstablecimiento { get; set; }
        public Boolean lActualizarParams { get; set; } /** Actualizar parametros **/
        
        public Int16 idEsResponsable { get; set; } /** 0 => indefinido, 1 => false, 2 => true **/
        #endregion Variables

        #region Constructor
        public clsCNControlLimitesBoveda(){
            this.lActualizarParams = true;
        }
        public clsCNControlLimitesBoveda(
            Int32 idUsuario,
            Int32 idAgencia,
            DateTime dFechaOpe,
            Int32 idEstablecimiento)
        {
            this.idUsuario = idUsuario;
            this.idAgencia = idAgencia;
            this.dFechaOpe = dFechaOpe;
            this.idEstablecimiento = idEstablecimiento;
            this.lActualizarParams = false;
        }
        #endregion Constructor

        #region Metodos
        /**
         * 
         * Resumen de Numero de cierres con exceso, memos, de una agencia
         * 
         * 
         */
        public DataTable resumenCtrlLimBov(Int32 idAgencia)
        {
            return this.oAD.resumenCtrlLimBov(idAgencia);
        }
        /**
         * 
         * Actualiza los parametros de las variables globales 
         * 
         * **/
        public void actualizarParametros()
        {
            if (this.lActualizarParams)
            {
                this.idUsuario = clsVarGlobal.PerfilUsu.idUsuario;
                this.idAgencia = clsVarGlobal.nIdAgencia;
                this.dFechaOpe = clsVarGlobal.dFecSystem;
                this.idEstablecimiento = clsVarGlobal.User.idEstablecimiento;
            }
        }
        /** 
         * 
         * Actualiza los datos de saldos y limites de boveda
         * 
         */
        public void actualizarDatos()
        {
            this.actualizarParametros();
            this.establecerLimites();
            this.calcularSaldo();
        }
        /**
         * 
         * retorna el id de moneda que supero los limites de boveda
         * 
         **/
        public Int32 idMonedaPasoLimite()
        {
            if (this.pasoLimiteCobertura(1))
                return 1;
            else if (this.pasoLimiteCobertura(2))
                return 2;
            else
                return -1;
        }
        /**
         * 
         * Retorna true o false, si es o no un responsable de boveda
         * 
         **/
        public Boolean esResponsableBoveda()
        {
            if (this.idEsResponsable == 0)
            {
                this.actualizarParametros();
                var dtResult = this.oCNControlOpe.RetRespBoveda(
                this.idUsuario,
                this.idAgencia,
                3,
                this.dFechaOpe
                );

                if (dtResult.Rows.Count > 0)
                    this.idEsResponsable = 2;
                else
                    this.idEsResponsable = 1;
            }
            return this.idEsResponsable == 2 ? true : false;
        }
        /**
         * 
         * Retoran datatable de motivos de cierre de boveda con exceso
         * 
         **/
        public DataTable listaMotivosCierreBoveda()
        {
            return this.oAD.listaMotivosCierreBoveda();
        }
        public Decimal saldoMoneda(Int32 idMoneda)
        {
            return (idMoneda == 2 ? this.nSaldoDolares : this.nSaldoSoles);
        }
        /**
         * 
         * Retorna la cantidad equivalente al porcentaje limite de una moneda
         * 
         **/
        public Decimal porcentajeLimite(Decimal nPorcetateLimite, Int32 idMoneda)
        {
            return idMoneda == 1 ? (this.nMontoLim * nPorcetateLimite / 100) :
                (this.nMontoLimDol * nPorcetateLimite / 100);
        }
        /**
         * 
         * Guarda incidente de sobrepaso limite de boveda
         * 
         **/
        public void GuardarIncidente(String cMensaje = "", Int32 idSolicitudAprob = 0)
        {
            this.oAD.registrarControlLimiteBoveda(
                cMensaje,
                this.dFechaOpe,
                this.idUsuario,
                this.idAgencia,
                this.nSaldoSoles,
                this.nMontoLim,
                this.nSaldoDolares,
                this.nMontoLimDol,
                idSolicitudAprob,
                this.idEstablecimiento
                );
        }
        /**
         * 
         * retorna true o false, si paso o no el limite de la moneda en boveda
         * 
         **/
        public Boolean pasoLimiteCobertura(Int32 idMoneda = 1)
        {
            if (idMoneda == 1)
            {
                return this.nMontoLim < this.nSaldoSoles;
            }
            else if (idMoneda == 2)
            {
                return this.nMontoLimDol < this.nSaldoDolares;
            }
            else
            {
                return false;
            }
        }
        /**
         * 
         * diferencia entre el saldo y el limite de saldo
         * 
         */
        public Decimal montoDiferenciaLimite(Int32 idMoneda)
        {
            if (idMoneda == 1)
                return this.nSaldoSoles - this.nMontoLim;
            else if (idMoneda == 2)
                return this.nSaldoDolares - this.nMontoLimDol;
            else
                return 0;
        }
        /**
         * 
         * Guarda los limites de boveda
         * 
         **/
        void establecerLimites()
        { 
            var dtLimites = this.oADControlOpe.listarLimitesCobertura(
                3,
                this.idAgencia,
                1
                );

            if (dtLimites.Rows.Count > 0)
            {
                this.nMontoLim = Convert.ToDecimal(dtLimites.Rows[0]["nMontoLim"]);
                this.nMontoLimDol = Convert.ToDecimal(dtLimites.Rows[0]["nMontoLimDol"]);
            }
        }
        /**
         * 
         * Guarda el saldo de boveda
         * 
         **/
        void calcularSaldo()
        {
            /** SALDO en Linea **/
            this.nSaldoSoles = 0;
            this.nSaldoDolares = 0;
            var dtSaldoIncial = (new clsCNControlOpe()).RetornaSaldoOperadorAge(this.dFechaOpe, this.idUsuario, this.idAgencia, 3);
            if (dtSaldoIncial.Rows.Count > 0)
            {
                this.nSaldoSoles = Convert.ToDecimal(dtSaldoIncial.Rows[0]["nSalSoles"]);
                this.nSaldoDolares = Convert.ToDecimal(dtSaldoIncial.Rows[0]["nSalDolar"]);
            }
        }

        /**
         * 
         * valida el estado de solicitud de aprobacion de cierre de boveda con exceso de saldo
         * 
         * posibles estados de nEstado
         * 
         * 0 => sin solicitar
         * 1 => solicitado
         * 2 => aprobado
         * 3 => autoaprobado
         * 
         */
        public clsEstSolCirrBov validarSolicitudAprobacionCierreBov()
        {
            var oResult = new clsEstSolCirrBov();
            var dtResult = this.oAD.comprobarAprobacionCierreBov(
                this.idUsuario,
                this.idAgencia,
                this.dFechaOpe);

            if (dtResult.Rows.Count > 0)
            {
                oResult.idMotivoExt = Convert.ToInt32(dtResult.Rows[0]["idMotivo"]);
                oResult.cSustento = Convert.ToString(dtResult.Rows[0]["cSustento"]);
                oResult.idSolicitud = Convert.ToInt32(dtResult.Rows[0]["idSolAproba"]);
            }

            if (dtResult.Rows.Count == 0)
                oResult.nEstado = eEstadoSolicitud.SinSolicitar;
            else if (dtResult.Rows[0]["idUsuarioEmiOpi"] == DBNull.Value)
                oResult.nEstado = eEstadoSolicitud.Solicitado;
            else if (Convert.ToInt32(dtResult.Rows[0]["idUsuarioEmiOpi"]) == Convert.ToInt32(dtResult.Rows[0]["idUsuRegist"]))
                oResult.nEstado = eEstadoSolicitud.Autoaprobado;
            else
                oResult.nEstado = eEstadoSolicitud.Aprobado;

            return oResult;
        }

        public DataTable reporteEstadoLimiteBoveda(
            Int32 idAgencia
            , Int32 idEstablecimiento
            , Int32 idZona
            , DateTime dFechaInicio
            , DateTime dFechaFin
            )
        {
            return this.oAD.reporteEstadoLimiteBoveda(idAgencia, idEstablecimiento, idZona, dFechaInicio, dFechaFin);
        }

        public DataSet listaAgenciasEOBs(Int32 idUsuario = -1)
        {
            return this.oAD.listaAgenciasEOBs(idUsuario);
        }

        public DataTable reporteResumenExcepciones(Int32 idAgencia, Int32 idEOB, Int32 idZona, DateTime dFechaIni, DateTime dFechaFin)
        {
            return this.oAD.reporteResumenExcepciones(idAgencia, idEOB, idZona, dFechaIni, dFechaFin);
        }
        #endregion Metodos
    }
}
