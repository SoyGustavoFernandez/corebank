using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADM.AccesoDatos;

namespace ADM.CapaNegocio
{
    public class clsCNPlantillaCuentaAsiento
    {
        public clsADPlantillaCuentaAsiento objdocide = new clsADPlantillaCuentaAsiento();

        public DataTable CNListarPlantillaCuentaAsiento(int idModulo, int idProducto, int idCondicionContable,
                                                        int idTipoPersona, int idTipoOperacion, int idCanal,
                                                        int idTipoPago, int idConcepto, int idTipoAsiento,
                                                        int idCalifica, int idCentroCosto, int idMotivoOpe)
        {
            return objdocide.ADListarPlantillaCuentaAsiento(idModulo, idProducto, idCondicionContable,
                                                            idTipoPersona, idTipoOperacion, idCanal,
                                                            idTipoPago, idConcepto, idTipoAsiento,
                                                            idCalifica, idCentroCosto, idMotivoOpe);
        }

        public DataTable CNActualizaPlantillaCuentaAsiento(int idModulo, int idProducto, int idCondicionContable,
                                                           int idTipoPersona, int idTipoOperacion, int idCanal,
                                                           int idTipoPago, int idConcepto, int idTipoAsiento,
                                                           string xPlantillaCtaCtb, int idCalifica, int idCentroCosto,
                                                           int idMontivoOperacion)
        {
            return objdocide.ADActualizaPlantillaCuentaAsiento(idModulo, idProducto, idCondicionContable,
                                                               idTipoPersona, idTipoOperacion, idCanal,
                                                               idTipoPago, idConcepto, idTipoAsiento,
                                                               xPlantillaCtaCtb, idCalifica, idCentroCosto, idMontivoOperacion);
        }

        public DataTable CNListarPlantillaCtaCtbPorModulo(int idModulo)
        {
            return objdocide.ADListarPlantillaCtaCtbPorModulo(idModulo);
        }
    }
}
