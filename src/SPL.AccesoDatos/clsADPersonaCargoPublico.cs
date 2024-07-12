using EntityLayer;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPL.AccesoDatos
{
    public class clsADPersonaCargoPublico
    {
        public clsPersonaCargoPublico BuscarPersonaCP(int nNumDoc)
        {
            clsPersonaCargoPublico pers = new clsPersonaCargoPublico();

            clsGENEjeSP objEjeSp = new clsGENEjeSP();
            DataTable ds = new DataTable();
            ds = objEjeSp.EjecSP("GEN_BuscarPersonaPublicaSPL", nNumDoc);

            try
            {
                pers.cApePaterno = Convert.ToString(ds.Rows[0]["cApePaterno"]);
                pers.cApeMaterno = Convert.ToString(ds.Rows[0]["cApeMaterno"]);
                pers.cNombres = Convert.ToString(ds.Rows[0]["cNombres"]);
                pers.cInstitucion = Convert.ToString(ds.Rows[0]["cInstitucion"]);
                pers.cCargo = Convert.ToString(ds.Rows[0]["cCargo"]);
                pers.nNumDoc = Convert.ToInt32(ds.Rows[0]["nNumDoc"]);
                return pers;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
                
            
            
            
        }
    }
}
