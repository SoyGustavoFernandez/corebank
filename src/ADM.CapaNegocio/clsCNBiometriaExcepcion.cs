using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADM.AccesoDatos;
using GEN.Funciones;
using EntityLayer;
using System.Data;

namespace ADM.CapaNegocio
{
    public class clsCNBiometriaExcepcion
    {
        private clsADBiometriaExcepcion objADBiometriaExcepcion { get; set; }

        public clsCNBiometriaExcepcion()
        {
            objADBiometriaExcepcion = new clsADBiometriaExcepcion();
        }

        public List<clsBiometriaExcep> CNObtenerRPTSolicitudBiometrica(int idZona, int idAgencia, int idEstablecimientp, DateTime dFechaDesde, DateTime dFechaHasta, int idEstado)
        {
            DataSet dsResultado = objADBiometriaExcepcion.ADObtenerRPTSolicitudBiometrica(idZona, idAgencia, idEstablecimientp, dFechaDesde, dFechaHasta, idEstado);
            List<clsBiometriaExcep> lstBiometriaExcepcion = new List<clsBiometriaExcep>();
            lstBiometriaExcepcion = (dsResultado.Tables[0].Rows.Count > 0) ? dsResultado.Tables[0].SoftToList<clsBiometriaExcep>() as List<clsBiometriaExcep> : new List<clsBiometriaExcep>();

            lstBiometriaExcepcion = lstBiometriaExcepcion.Select(item => { item.lstAprobaSolici = (dsResultado.Tables[0].AsEnumerable().Any(item2 => Convert.ToInt32(item2["idSolAproba"]) == item.idSolAproba )) ? dsResultado.Tables[1].AsEnumerable().Where(item2 => Convert.ToInt32(item2["idSolAproba"]) == item.idSolAproba).CopyToDataTable().SoftToList<clsAprobaSolici>() as List<clsAprobaSolici> : new List<clsAprobaSolici>() ; return item; }).ToList();
            return lstBiometriaExcepcion;
        }
        public DataTable CNObtenerRPTSolicitudBiometricaCompleto(int idZona, int idAgencia, int idEstablecimientp, DateTime dFechaDesde, DateTime dFechaHasta, int idEstado)
        {
            return objADBiometriaExcepcion.ADObtenerRPTSolicitudBiometricaCompleto(idZona, idAgencia, idEstablecimientp, dFechaDesde, dFechaHasta, idEstado);
        }

        public DataTable CNObtenerDetalleArchivoExcepBiometrica(int idBiometriaExcep)
        {
            return objADBiometriaExcepcion.ADObtenerDetalleArchivoExcepBiometrica(idBiometriaExcep);
        }
    }
}
