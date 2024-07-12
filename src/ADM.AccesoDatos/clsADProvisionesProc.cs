using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;
namespace ADM.AccesoDatos
{
    public class clsADProvisionesProc
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListarPeriodosProv()
        {
            return objEjeSp.EjecSP("ADM_ListarPeriodosProvPro_sp");
        }
        public DataTable ListarTasasProv()
        {
            return objEjeSp.EjecSP("ADM_ListarTasasProvPro_sp");
        }
        public DataTable ActualizarProvisiones(string xmlPeriodo, string xmlTasa, DateTime dFecha,int idUsuario,
                                                 decimal nMontoTasaMen, int idPeriodo, int idTasaTipoCredito, int idMes)
        {
            return objEjeSp.EjecSP("ADM_ActProvisionesPro_sp", xmlPeriodo, xmlTasa, dFecha, idUsuario,
                                                                 nMontoTasaMen, idPeriodo, idTasaTipoCredito, idMes);
        }
        public DataTable CargarTasaMensual(int idPeriodo, int idTasaTipoCredito, int idMes)
        {
            return objEjeSp.EjecSP("ADM_TasaMensualProvPro_sp", idPeriodo, idTasaTipoCredito, idMes);
        }
    }
}
