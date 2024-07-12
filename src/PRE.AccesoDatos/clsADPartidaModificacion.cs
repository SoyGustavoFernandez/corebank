using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRE.AccesoDatos
{
    public class clsADPartidaModificacion
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        // -- TODAS LAS PARTIDAS DE MODIFICACION: idTipoModificacion = 1 -> Reasignacion, 2 -> ampliacion
        public DataTable ListarTodosPartidasModificacion(int idPeriodo, int idTipoModificacion)
        {
            return objEjeSp.EjecSP("PRE_ListarPartidasModificacion_SP", idPeriodo, 0, idTipoModificacion);
        }
        public DataTable InsertarPartida(int idPartida, String cJustificacion, int idPeriodo, int idTipoModific, int idUsuSolicitante,
                                        int idUsu, DateTime dFecha, int idPartidaOrigen, int idPartidaDestino, String xmlModifPres, Decimal nMovimiento, int idAgencia)
        {
            return objEjeSp.EjecSP("PRE_InsertarPartidaModificacion_SP", idPartida, cJustificacion, idPeriodo, idTipoModific, idUsuSolicitante,
                                                                        idUsu, dFecha, idPartidaOrigen, idPartidaDestino, nMovimiento, idAgencia, xmlModifPres);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////
        // LISTA UNA PARTIDA CON PRESUPUESTO MODIFICADO         
        public DataTable ListaPresupuestoPartidaModificada(int idPeriodo, int idPartidaModificacion, int idPartidaActora)
        {
            return objEjeSp.EjecSP("PRE_ListaPresupuestoPartidaModificada_SP", idPeriodo, idPartidaModificacion, idPartidaActora);
        }
        //////////////////////////////////////////////////////////////////////////////////////////
        // -- EJECUTAR MODIFICACION DE PRESUPUESTO
        public DataTable ProcesarModificacionPresupuesto(int idSolicitud, int idPeriodo, int idPartidaModificacion, int idUsuario, DateTime dFecha)
        {
            return objEjeSp.EjecSP("PRE_EjecutarModificacionPresupuestal_SP", idSolicitud, idPeriodo, idPartidaModificacion, idUsuario, dFecha);
        }        
    }
}
