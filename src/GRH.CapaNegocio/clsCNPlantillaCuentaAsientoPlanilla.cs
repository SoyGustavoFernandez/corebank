using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNPlantillaCuentaAsientoPlanilla
    {
        clsADPlantillaCuentaAsientoPlanilla objPlantillaCuentaAsiento = new clsADPlantillaCuentaAsientoPlanilla();

        public DataTable CNListarPlantillaCuentaAsientoPlanilla(int idTipoPlanilla, int idConcepto)
        {
            return objPlantillaCuentaAsiento.ADListarPlantillaCuentaAsientoPlanilla(idTipoPlanilla, idConcepto);
        }

        public DataTable CNActualizarPlantillaCuentaAsientoPlanilla(int idTipoPlanilla, int idConcepto, string xmlPlantillaCtaCtb)
        {
            return objPlantillaCuentaAsiento.ADActualizarPlantillaCuentaAsientoPlanilla(idTipoPlanilla, idConcepto, xmlPlantillaCtaCtb);
        }
    }
}
