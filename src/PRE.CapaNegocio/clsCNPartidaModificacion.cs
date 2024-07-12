using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRE.AccesoDatos;

namespace PRE.CapaNegocio
{
    public class clsCNPartidaModificacion
    {
        clsADPartidaModificacion clsADpartidaReasig = new clsADPartidaModificacion();
        // -- TODAS LAS PARTIDAS DE MODIFICACION: idTipoModificacion = 1 -> Reasignacion, 2 -> ampliacion
        public DataTable ListarTodosPartidasModificacion(int idPeriodo, int idTipoModificacion)
        {
            return clsADpartidaReasig.ListarTodosPartidasModificacion(idPeriodo, idTipoModificacion);
        }
        public DataTable InsertarPartida(int idPartida, String cJustific, int idPeriodo, int idTipoModific, int idUsuSolicitante,
                                        int idUsu, DateTime dFecha, int idPartidaOrigen, int idPartidaDestino, String xmlModifPres, Decimal nMovimiento, int idAgencia)
        {
            return clsADpartidaReasig.InsertarPartida(idPartida, cJustific, idPeriodo, idTipoModific, idUsuSolicitante,
                                                      idUsu, dFecha, idPartidaOrigen, idPartidaDestino, xmlModifPres, nMovimiento, idAgencia);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////
        // LISTA UNA PARTIDA CON PRESUPUESTO MODIFICADO                                             
        public DataTable ListaPresupuestoPartidaModificada(int idPeriodo, int idPartidaModificacion, int idPartidaActora)
        {
            return clsADpartidaReasig.ListaPresupuestoPartidaModificada(idPeriodo, idPartidaModificacion, idPartidaActora);
        }
        //////////////////////////////////////////////////////////////////////////////////////////
        // -- EJECUTAR MODIFICACION DE PRESUPUESTO
        public DataTable ProcesarModificacionPresupuesto(int idSolicitud, int idPeriodo, int idPartidaModificacion, int idUsuario, DateTime dFecha)
        {
            return clsADpartidaReasig.ProcesarModificacionPresupuesto(idSolicitud, idPeriodo, idPartidaModificacion, idUsuario, dFecha);
        }      
    }
}
