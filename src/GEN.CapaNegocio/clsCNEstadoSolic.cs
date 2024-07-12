using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNEstadoSolic
    {
        clsADEstadoSolic objEstPersonal = new clsADEstadoSolic();        

        public DataTable listarEstadoSolic()
        {
            //return objEstPersonal.listarEstadoSolic();

            var dt = objEstPersonal.listarEstadoSolicXml();

            DataTable dtEstadoSolic = dt.Clone();

            (from item in dt.AsEnumerable()
             where (bool)item["lVigente"] == true
             select item).CopyToDataTable(dtEstadoSolic, LoadOption.OverwriteChanges);

            return dtEstadoSolic;
             
        }
        public DataTable CNlistarEstSolic(int idEstadoSol)
        {
            return objEstPersonal.ADlistarEstSolic(idEstadoSol);
        }

        public DataTable CNlistaEstSolicitudPermiso()
        {
            return objEstPersonal.ADlistaEstSolicitudPermiso();
        }
    }
}
