using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LOG.AccesoDatos;
using EntityLayer;

namespace LOG.CapaNegocio
{
    public class clsCNNotaSalida
    {
        private clsADNotaSalida clsNotaSalida = new clsADNotaSalida();

        public clsNotaSalida CNNotaSalida(int idNotaSalida)
        {
            return clsNotaSalida.ADNotaSalida(idNotaSalida);
        }

        public clsNotaSalida CNBuscarNotaSalidaById(int idNotaSalida)
        {
            DateTime dFechaIni = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
            DateTime dFechaFin = System.Data.SqlTypes.SqlDateTime.MaxValue.Value;
            int idAgencia = 0;
            string cEstado = string.Format("{0},{1},{2},{3}",Convert.ToInt16(EstLog.SOLICITADO),Convert.ToInt16(EstLog.APROBADO),
                                                            Convert.ToInt16(EstLog.ATENDIDO),Convert.ToInt16(EstLog.DENEGADO));

            List<clsNotaSalida> lstNotaSalida = clsNotaSalida.ADListNotaSalida(idNotaSalida, dFechaIni, dFechaFin, idAgencia, cEstado, clsVarGlobal.User.idUsuario);
            if(lstNotaSalida.Count==0)
                return null;

            return lstNotaSalida.First();
        }

        public List<clsNotaSalida> CNListarNotaSalida(DateTime dFechaIni, DateTime dFechaFin,
                                                    int idAgencia, string cEstado, int idUsuario)
        {
            return clsNotaSalida.ADListNotaSalida(-1, dFechaIni, dFechaFin, idAgencia, cEstado, idUsuario);
        }

        public clsDBResp CNAprobDenegNotaSalida(clsNotaSalida objNotaSalida)
        {
            return clsNotaSalida.ADAprobDenegNotaSalida(objNotaSalida);
        }

        public clsDBResp CNAtenderNotaSalida(clsNotaSalida objNotaSalida)
        {
            //List<clsActivo> lstActivos = new List<clsActivo>();
            //foreach (clsDetNotaSalida item in objNotaSalida.LstDetNotSalida)
            //{
            //    if (item.objCatalogo.lIndActivo)
            //    {
            //        lstActivos.Add((clsActivo)item.objCatalogo);
            //    }
            //}

            return clsNotaSalida.ADAtenderNotaSalida(objNotaSalida/*,lstActivos*/);
        }

        //public clsDBResp CNExtornoNotaSalida(clsNotaSalida objNotaSalida, int idMotExtorno, string cObsExtorno)
        //{
        //    return clsNotaSalida.ADExtornoNotaSalida(objNotaSalida, idMotExtorno, cObsExtorno);
        //}

        public clsDBResp CNExtornoNotaSalida(int idKardex, DateTime dFecExtorno, int idUsuExtorno)
        {
            return clsNotaSalida.ADExtornoNotaSalida(idKardex, dFecExtorno, idUsuExtorno);
        }

        public clsDBResp CNGuardarNotaSalida(clsNotaSalida objNotaSalida)
        {
            return clsNotaSalida.ADGuardarNotaSalida(objNotaSalida);
        }

        public clsDBResp CNActualizarNotaSalida(clsNotaSalida objNotaSalida)
        {
            return clsNotaSalida.ADActualizarNotaSalida(objNotaSalida);
        }

        public DataTable CNCargaNotaSalida(int idNotaSalida)
        {
            return clsNotaSalida.ADCargaNotaSalida(idNotaSalida);
        }

    }
}
