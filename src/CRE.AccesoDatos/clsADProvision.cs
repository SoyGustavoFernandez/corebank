using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace CRE.AccesoDatos
{
    public class clsADProvision
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADTasProAct()
        {
            return objEjeSp.EjecSP("CRE_RetornaTasaProAct_sp");
        }
        public DataTable ADTasaProEspecifica()
        {
            return objEjeSp.EjecSP("CRE_RetornaTasaProEspecif_sp");
        }
        public DataTable ActualizarProvisiones( string xmlEspecifico, int idTasaActiva,
                                               DateTime dFecSystem, int idUsuario, decimal TasaGenerica,
                                               decimal TasaMesGenerica, string Anio, int Mes, int idProducto)
        {
           return objEjeSp.EjecSP("ADM_ActProvisiones_sp", xmlEspecifico, idTasaActiva,
                                                      dFecSystem, idUsuario, TasaGenerica,
                                                      TasaMesGenerica, Anio, Mes, idProducto);
        }
        public DataTable BuscarTasaMensual(string AnioBusq, int idMes, int idProducto)
        {
            return objEjeSp.EjecSP("ADM_RetornaTasaMenProv_sp", AnioBusq, idMes, idProducto);
        }

        /// <summary>
        /// Metodo para procesar las provosines
        /// </summary>
        /// <param name="Fecha"></param>
        /// <returns></returns>
        public DataTable ProcesarProvisiones(DateTime fecha)
        {
            return objEjeSp.EjecSP("CRE_CalculoProvisionFecha_sp", fecha);
        }

        /// <summary>
        /// Metodo para procesar las provosines
        /// </summary>
        /// <param name="Fecha"></param>
        /// <returns></returns>
        public DataTable VerReporteProvisiones(DateTime fecha)
        {
            return objEjeSp.EjecSP("CRE_ReporteRiesgoProvision_SP", fecha);
        }
    }
}
