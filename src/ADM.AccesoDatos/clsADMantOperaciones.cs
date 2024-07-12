using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;

namespace ADM.AccesoDatos
{
    public class clsADMantOperaciones
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable Listaroperaciones(int idModulo)
        {
            return objEjeSp.EjecSP("ADM_ListarOperaciones_sp", idModulo);
        }

        public DataTable ActualizarOperaciones(int idTipoOperacion, String Tipo, int idModulo, string NombOper,
                                                   int Modalidad, int Moneda, int Producto,
                                                   int Extractocta, string CodigoSBS, int idTipoAsiento, int lVigente, int CantImpres,
                                                    bool lisSplaft, bool lImprimir, int nNumDiasVcto)
        {
            return objEjeSp.EjecSP("ADM_ActualizarOperaciones_sp", idTipoOperacion, Tipo, idModulo, NombOper,
                                                    Modalidad,Moneda, Producto,
                                                    Extractocta, CodigoSBS, idTipoAsiento, lVigente, CantImpres, lisSplaft,
                                                    lImprimir, nNumDiasVcto);
        }

        public DataTable ListarTipoOperaciones()
        {
            return objEjeSp.EjecSP("ADM_ListarTipoOperaciones_sp");
        }
    }
}
