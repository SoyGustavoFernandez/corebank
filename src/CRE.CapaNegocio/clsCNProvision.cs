using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;

namespace CRE.CapaNegocio
{
    public class clsCNProvision
    {
        public clsADProvision ObjProvision = new clsADProvision();
        public DataTable CNTasProAct()
        {
            return ObjProvision.ADTasProAct();
        }
        public DataTable CNTasaProEspecifica()
        {
            return ObjProvision.ADTasaProEspecifica();
        }

        public DataTable ActualizarProvisiones( string xmlEspecifico, int idTasaActiva,
                                               DateTime dFecSystem, int idUsuario, decimal TasaGenerica,
                                               decimal TasaMesGenerica, string Anio, int Mes, int idProducto)
        {
            return ObjProvision.ActualizarProvisiones( xmlEspecifico, idTasaActiva,
                                                      dFecSystem,  idUsuario, TasaGenerica, 
                                                      TasaMesGenerica, Anio, Mes, idProducto);
        }
        public decimal BuscarTasaMensual( string AnioBusq, int idMes, int idProducto)
        {
            DataTable dt= ObjProvision.BuscarTasaMensual(AnioBusq,  idMes,  idProducto);
            decimal TasaMensual=Convert.ToDecimal(0.00);
           
            if (dt.Rows.Count > 0)
                TasaMensual= Convert.ToDecimal(dt.Rows[0][0]);

            return TasaMensual;            
        }


        /// <summary>
        /// Calcular Provicion segun Fecha
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public DataTable CalcularProvicionFecha(DateTime fecha)
        {
            return ObjProvision.ProcesarProvisiones(fecha);
        }

        /// <summary>
        /// Reportar el registro de los clientes y su riesgo
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public DataTable ReportarRiesgoProvisiones(DateTime fecha)
        {
            return ObjProvision.VerReporteProvisiones(fecha);
        }
        
    }
}
