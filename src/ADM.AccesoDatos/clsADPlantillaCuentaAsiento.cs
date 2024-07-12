using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace ADM.AccesoDatos
{
    public class clsADPlantillaCuentaAsiento
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarPlantillaCuentaAsiento(int idModulo, int idProducto, int idCondicionContable,
                                                        int idTipoPersona, int idTipoOperacion, int idCanal,
                                                        int idTipoPago, int idConcepto, int idTipoAsiento,
                                                        int idCalifica, int idCentroCosto,int idMotivoOpe)
        {
            return objEjeSp.EjecSP("ADM_ListarPlantillaCuentaAsiento_SP", idModulo, idProducto, idCondicionContable,
                                                                          idTipoPersona, idTipoOperacion, idCanal,
                                                                          idTipoPago, idConcepto, idTipoAsiento,
                                                                          idCalifica, idCentroCosto, idMotivoOpe);
        }

        public DataTable ADActualizaPlantillaCuentaAsiento(int idModulo, int idProducto, int idCondicionContable,
                                                           int idTipoPersona, int idTipoOperacion, int idCanal,
                                                           int idTipoPago, int idConcepto, int idTipoAsiento,
                                                           string xPlantillaCtaCtb, int idCalifica, int idCentroCosto,int idMontivoOperacion)
        {
            return objEjeSp.EjecSP("ADM_ActualizaPlantillaCuentaAsiento_SP", idModulo, idProducto, idCondicionContable,
                                                                             idTipoPersona, idTipoOperacion, idCanal,
                                                                             idTipoPago, idConcepto, idTipoAsiento,
                                                                             xPlantillaCtaCtb, idCalifica, idCentroCosto, idMontivoOperacion);
        }

        public DataTable ADListarPlantillaCtaCtbPorModulo(int idModulo)
        {
            return objEjeSp.EjecSP("ADM_ListarPlantillaCtaCtbPorModulo_SP", idModulo);
        }
    }
}
