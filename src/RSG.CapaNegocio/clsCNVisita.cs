using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSG.AccesoDatos;
using System.Data;

namespace RSG.CapaNegocio
{
    public class clsCNVisita
    {
        clsADVisita adVisita;
        public clsCNVisita()
        {
            adVisita = new clsADVisita();
        }
        public DataTable CNListaTipoOperacion()
        {
            return adVisita.ADListaTipoOperacion();
        }
        
        public DataTable CNResultadoVisitas()
        {
            return adVisita.ADResultadoVisitas();
        }
        public DataTable CNCreditosIdCliente(int idCli)
        {
            return adVisita.ADCreditosIdCliente(idCli);
        }
        public DataTable CNRegistrarVisita(int idVisita, DateTime dFechaInicio, DateTime dFechaFin, int idAgencia, int idZona, DateTime dFechaSis, int idUsuario, string cVisitascliente)
        {
            return adVisita.ADRegistrarVisita(idVisita,  dFechaInicio,  dFechaFin,  idAgencia,  idZona,  dFechaSis, idUsuario, cVisitascliente);
        }
        public DataTable CNBuscarVisita(DateTime dFechaIni, DateTime dFechaFin)
        { 
            return adVisita.ADBuscarVisita(dFechaIni, dFechaFin);
        }
        public DataTable CNListarVisitaClientesPodIdVisita(int idVisita)
        {
            return adVisita.ADListarVisitaClientesPodIdVisita(idVisita);
        }
        public DataTable CNClienteAgencia(int idCli)
        {
            return adVisita.ADClienteAgencia(idCli);
        }
        public DataTable CNBuscarResumenVisita(int idVisita)
        {
            return adVisita.ADBuscarResumenVisita(idVisita);
        }
        public DataTable CNClienteCreditosVigentes(int idCli)
        {
            return adVisita.ADClienteCreditosVigentes(idCli);
        }
        #region DETALLES VISITA
        public DataTable CNListaUbicaVisita(Boolean lTodos)
        {
            return adVisita.ADListaUbicaVisita(lTodos);
        }
        public DataTable CNListaTipoVerificacionAsesor(Boolean lTodos)
        {
            return adVisita.ADListaTipoVerificacionAsesor(lTodos);
        }

        public DataTable CNListaTipoVerificaAutonomia(Boolean lTodos)
        {
            return adVisita.ADListaTipoVerificaAutonomia( lTodos);
        }

        public DataTable CNListaTipoRiesgoOperacional(Boolean lTodos)
        {
            return adVisita.ADListaTipoRiesgoOperacional(lTodos);
        }
        public DataTable CNListaMotivoMoraRiesgos(Boolean lTodos)
        {
            return adVisita.ADListaMotivoMoraRiesgos(lTodos);
        }
        public DataTable CNListaVisitaEscala(Boolean lTodos)
        {
            return adVisita.ADListaVisitaEscala(lTodos);
        }
        public DataTable CNEliminarVisitaRiesgos(int idVisita)
        {
            return adVisita.ADEliminarVisitaRiesgos(idVisita);
        }
        #endregion
    }
}
