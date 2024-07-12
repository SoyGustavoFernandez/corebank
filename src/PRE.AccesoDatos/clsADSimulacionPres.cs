using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PRE.AccesoDatos
{
    public class clsADSimulacionPres
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListarPresuSimulados(int idPeriodo)
        {
            return objEjeSp.EjecSP("PRE_ListarPresuSimulado_SP", idPeriodo);
        }
        public DataTable ListarValoresSimulados(int idPeriodo, int idSimulacion)
        {
            return objEjeSp.EjecSP("PRE_ListarValoresSimulados_SP", idPeriodo, idSimulacion);
        }
        public DataTable InsertarValoresSimulados(string descripcion, int idPeriodo, int idUsuReg, DateTime dFechaReg, bool lVigente, string xmlValoresSimulados)
        {
            return objEjeSp.EjecSP("PRE_InsertarSimulacion_SP", descripcion, idPeriodo, idUsuReg, dFechaReg, lVigente, xmlValoresSimulados);
        }
        public DataTable ActualizarValoresSimulados(int idSimulacion, string descripcion, int idPeriodo, int idUsuMod, DateTime dFechaMod, bool lVigente, string xmlValoresSimulados)
        {
            return objEjeSp.EjecSP("PRE_ActualizarSimulacion_SP", idSimulacion, descripcion, idPeriodo, idUsuMod, dFechaMod, lVigente, xmlValoresSimulados);
        }
        public DataTable EliminarValoresSimulados(int idSimulacion, int idUsuMod, DateTime dFechaMod)
        {
            return objEjeSp.EjecSP("PRE_EliminarSimulacion_SP", idSimulacion, idUsuMod, dFechaMod);
        }
    }
}
