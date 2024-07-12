using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRE.AccesoDatos;
using System.Data;

namespace PRE.CapaNegocio
{
    public class clsCNPartidasPres
    {
        clsADPartidasPres clsadpartidaspres = new clsADPartidasPres();
        public DataTable listarTodasPartidas(int idPeriodo)
        {
            return clsadpartidaspres.ListarTodosPartidas(idPeriodo);
        }
        public DataTable listarUnaPartida(int idPeriodo, int idPartida)
        {
            return clsadpartidaspres.ListarUnaPartida(idPeriodo, idPartida);
        }

        public DataTable ListarPartidasXEstructura(int idPeriodo, String cEstructura)
        {
            return clsadpartidaspres.ListarPartidasXEstructura(idPeriodo, cEstructura);
        }

        public DataTable InsertarPartidaPres(int idPartida, int idPadre, int idPlantilla, String cNombre, int idPeriodo,
                                        Decimal nPresupuesto, Boolean lAfectacion, int idNivelAprob,
                                        Decimal nPorcentaje, int idUsu, DateTime dFecha, String xmlCuentasContables, int idLimAplicacion, int nSigno)
        {
            return clsadpartidaspres.InsertarPartida(idPartida, idPadre, idPlantilla, cNombre, idPeriodo, nPresupuesto, lAfectacion, idNivelAprob, nPorcentaje, idUsu, dFecha, xmlCuentasContables, idLimAplicacion, nSigno);
        }
        public DataTable EliminarPartidaPres(int idPartida, int idUsu, DateTime dFecha)
        {
            return clsadpartidaspres.EliminarPartida(idPartida, idUsu, dFecha);
        }
        public DataTable EliminarPartidasPeriodo(int idPeriodo, int idUsu, DateTime dFecha)
        {
            return clsadpartidaspres.EliminarPartidasPeriodo(idPeriodo, idUsu, dFecha);
        }
        //=====================================================
        // lista las cuentas contables de la partida y todos sus hijos
        public DataTable listarTodasCuentasContables(int idPartida)
        {
            return clsadpartidaspres.ListarTodasCuentasContables(idPartida);
        }
        //=====================================================
        // lista las cuentas contables de unicamente una partida
        public DataTable listarCuentasContables(int idPartida)
        {
            return clsadpartidaspres.ListarCuentasContables(idPartida);
        }
        public DataTable ListarValoresDePartidas(int idPeriodo)
        {
            return clsadpartidaspres.ListarValoresDePartidas(idPeriodo);
        }
        //==========================================================
        // EXPORTA LAS PARTIDAS DE UN PERIODO ANTERIOR, HACIA EL PERIODO PLANIFICACION
        //public DataTable ExportarPartidasAPlanif(int idPeriodoOrigen, int idPeriodoDestino, int idUsu, DateTime dFecha)
        //{
        //    return clsadpartidaspres.ExportarPartidasAPlanif(idPeriodoOrigen, idPeriodoDestino, idUsu, dFecha);
        //}

        public DataTable ListarValoresDeUnaPartida(int idPeriodo, int idPartida)
        {
            return clsadpartidaspres.ListarValoresDeUnaPartida(idPeriodo, idPartida);
        }
        public DataTable InsertarValoresPartidas(int idPeriodo, int idUsuMod, DateTime dFechaMod, string xmlValoresPartidas)
        {
            return clsadpartidaspres.InsertarValoresPartidas(idPeriodo, idUsuMod, dFechaMod, xmlValoresPartidas);
        }
    }
}
