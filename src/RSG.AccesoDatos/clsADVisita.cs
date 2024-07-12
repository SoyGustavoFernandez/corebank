using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace RSG.AccesoDatos
{
    public class clsADVisita
    {
        clsGENEjeSP objEje;
        public clsADVisita() 
        {
            objEje = new clsGENEjeSP();
        }

        public DataTable ADListaTipoOperacion()
        { 
            return objEje.EjecSP("RSG_ListaTipoOperacion_SP");
        }
        public DataTable ADResultadoVisitas()
        {
            return objEje.EjecSP("RSG_ListaResultadoVisita_SP");
        }
        public DataTable ADCreditosIdCliente(int idCli)
        {
            return objEje.EjecSP("RSG_CreditosIdCliente_SP", idCli);
        }
        public DataTable ADRegistrarVisita(int idVisita, DateTime dFechaInicio, DateTime dFechaFin, int idAgencia, int idZona, DateTime dFechaSis, int idUsuario, string cVisitascliente)
        {
            return objEje.EjecSP("RSG_RegistraVisitaRiesgos_SP", idVisita, dFechaInicio, dFechaFin, idAgencia, idZona, dFechaSis, idUsuario, cVisitascliente);
        }
        public DataTable ADBuscarVisita(DateTime dFechaIni, DateTime dFechaFin)
        {
            return objEje.EjecSP("RSG_VisitasPorPeriodoVisita_SP", dFechaIni, dFechaFin);
        }

        public DataTable ADListarVisitaClientesPodIdVisita(int idVisita)
        {
            return objEje.EjecSP("RSG_ListarVisitaClientesPodIdVisita_SP", idVisita);
        }
        public DataTable ADClienteAgencia(int idCli)
        {
            return objEje.EjecSP("RSG_ObtenerAgenciaCliente_SP", idCli);
        }
        public DataTable ADBuscarResumenVisita(int idVisita)
        {
            return objEje.EjecSP("RSG_BuscarResumenVisita_SP", idVisita);
        }
        public DataTable ADClienteCreditosVigentes(int idCli)
        {
            return objEje.EjecSP("RSG_ClienteCreditosVigentes_SP", idCli);
        }
        #region DETALLES VISITA
        public DataTable ADListaUbicaVisita(Boolean lTodos)
        {
            return objEje.EjecSP("RSG_ListaUbicaVisita_SP", lTodos);
        }

        public DataTable ADListaTipoVerificacionAsesor(Boolean lTodos)
        {
            return objEje.EjecSP("RSG_ListaTipoVerificacionAsesor_SP", lTodos);
        }

        public DataTable ADListaTipoVerificaAutonomia(Boolean lTodos)
        {
            return objEje.EjecSP("RSG_ListaTipoVerificaAutonomia_SP", lTodos);
        }

        public DataTable ADListaTipoRiesgoOperacional(Boolean lTodos)
        {
            return objEje.EjecSP("RSG_ListaTipoRiesgoOperacional_SP", lTodos);
        }
        public DataTable ADListaMotivoMoraRiesgos(Boolean lTodos)
        {
            return objEje.EjecSP("RSG_ListaMotivoMoraRiesgos_SP", lTodos);
        }
        public DataTable ADListaVisitaEscala(Boolean lTodos)
        {
            return objEje.EjecSP("RSG_ListaVisitaEscala_SP", lTodos);
        }
        public DataTable ADEliminarVisitaRiesgos(int idVisita)
        {
            return objEje.EjecSP("RSG_EliminarVisitaRiesgos_SP", idVisita);
        }
        #endregion
    }
}
