using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNModalidadPlanilla
    {
        clsADModalidadPlanilla objModalidadPlanilla = new clsADModalidadPlanilla();

        public DataTable CNListarModalidadPlanilla()
        {
            //return objModalidadPlanilla.ADListarModalidadPlanilla();

            var dt = objModalidadPlanilla.ADListarModalidadPlanillaXML();
            DataTable dtModPlanilla = dt.Clone();
            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtModPlanilla, LoadOption.OverwriteChanges);
            return dtModPlanilla;
        }

        public DataTable CNListarModalidadTipoPlanilla(int idTipoPlanilla)
        {
            return objModalidadPlanilla.ADListarModalidadTipoPlanilla(idTipoPlanilla);
        }

        public DataTable CNListarModalidadDctoAdelantoTipoPlanilla(int idTipoPlanilla)
        {
            return objModalidadPlanilla.ADListarModalidadDctoAdelantoTipoPlanilla(idTipoPlanilla);
        }
    }
}
