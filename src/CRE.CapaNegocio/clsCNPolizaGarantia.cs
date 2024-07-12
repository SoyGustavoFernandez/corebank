using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;
using EntityLayer;
using System.Data;

namespace CRE.CapaNegocio
{
    /// <summary>
    /// 
    /// </summary>
    public class clsCNPolizaGarantia
    {
        private clsADPolizaGarantia poliza = new clsADPolizaGarantia();

        /// <summary>
        /// inserta o actualiza el registro de poliza de una garantia
        /// </summary>
        /// <param name="objpoliza"></param>
        public void insertaactPoliza(clsPolizaGarantia objpoliza)
        {
            poliza.insertaactPoliza(objpoliza);
        }

        /// <summary>
        /// retorna los datos de la poliza de una garantia
        /// </summary>
        /// <param name="idGarantia">id de la garantia</param>
        /// <returns>objeto poliza</returns>
        public clsPolizaGarantia retornadatPoliza(int idGarantia)
        {
            return poliza.retornadatPoliza(idGarantia);
        }

        public DataTable RptPolizasGarantia(DateTime dFecIni, DateTime dFecFin)
        {
            return poliza.RptPolizasGarantia(dFecIni, dFecFin);
        }
    }
}
