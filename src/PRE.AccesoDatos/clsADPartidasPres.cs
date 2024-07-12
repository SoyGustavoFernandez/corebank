using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRE.AccesoDatos
{
    public class clsADPartidasPres
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarTodosPartidas(int idPeriodo)
        {
            return objEjeSp.EjecSP("PRE_ListarPartidasPres_SP", idPeriodo, 0, "");
        }        
        public DataTable ListarUnaPartida(int idPeriodo, int idPartida)
        {
            return objEjeSp.EjecSP("PRE_ListarPartidasPres_SP", idPeriodo, idPartida, "");
        }

        public DataTable ListarPartidasXEstructura(int idPeriodo, String cEstructura)
        {
            return objEjeSp.EjecSP("PRE_ListarPartidasPres_SP", idPeriodo, 0, cEstructura);
        }

        public DataTable InsertarPartida(int idPartida, int idPadre, int idPlantilla, String cNombre, int idPeriodo,
                                        Decimal nPresupuesto, Boolean lAfectacion, int idNivelAprob,
                                        Decimal nPorcentaje, int idUsu, DateTime dFecha, String xmlCuentasContables, int idLimAplicacion, int nSigno)
        {
            return objEjeSp.EjecSP("PRE_InsertarPartidaPres_SP", idPartida, idPadre, idPlantilla, cNombre, idPeriodo, nPresupuesto, lAfectacion, idNivelAprob, nPorcentaje, idUsu, dFecha, idLimAplicacion, xmlCuentasContables, nSigno);
        }
        public DataTable EliminarPartida(int idPartida, int idUsu, DateTime dFecha)
        {
            return objEjeSp.EjecSP("PRE_EliminarPartidaPresupuesto_SP", idPartida, idUsu, dFecha);
        }
        public DataTable EliminarPartidasPeriodo(int idPeriodo, int idUsu, DateTime dFecha)
        {
            return objEjeSp.EjecSP("PRE_LimpiaPartidasXCargaExcel_SP", idPeriodo, idUsu, dFecha);
        }
        //=====================================================
        // lista las cuentas contables de la partida y todos sus hijos
        public DataTable ListarTodasCuentasContables(int idPartida)
        {
            return objEjeSp.EjecSP("PRE_ListarCuentasContXPartida_SP", idPartida);
        }
        //=====================================================
        // lista las cuentas contables de unicamente una partida
        public DataTable ListarCuentasContables(int idPartida)
        {
            return objEjeSp.EjecSP("PRE_ListarCuentasContables_SP", idPartida);
        }
        public DataTable ListarValoresDePartidas(int idPeriodo)
        {
            return objEjeSp.EjecSP("PRE_ListarValoresDePartidas_SP", idPeriodo, 0);
        }
        //==========================================================
        // EXPORTA LAS PARTIDAS DE UN PERIODO ANTERIOR, HACIA EL PERIODO PLANIFICACION
        //public DataTable ExportarPartidasAPlanif(int idPeriodoOrigen, int idPeriodoDestino, int idUsu, DateTime dFecha)
        //{
        //    return objEjeSp.EjecSP("PRE_ExportarPartidasAPeriodoPlanific_SP", idPeriodoOrigen, idPeriodoDestino, idUsu, dFecha);
        //}


        public DataTable ListarValoresDeUnaPartida(int idPeriodo, int idPartida)
        {
            return objEjeSp.EjecSP("PRE_ListaPresupuestoPartida_SP", idPeriodo, idPartida);
        }

        public DataTable InsertarValoresPartidas(int idPeriodo, int idUsuMod, DateTime dFechaMod, string xmlValoresPartidas)
        {
            return objEjeSp.EjecSP("PRE_InsertarValoresPartidas_SP", idPeriodo, idUsuMod, dFechaMod, xmlValoresPartidas);
        }
    }
}
