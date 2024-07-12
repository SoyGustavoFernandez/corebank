using System;
using System.Collections.Generic;
using System.Data;
using EntityLayer;
using SolIntEls.GEN.Helper;

namespace ADM.AccesoDatos
{
    public class clsADMantAssemblies
    {
        public clsDBResp GuardarInfoAssemblies(string xmlAssemblies)
        {
            DataTable dtResult = new clsGENEjeSP().EjecSP("ADM_GuardarAssemblies_Sp", xmlAssemblies);
            return new clsDBResp(dtResult);
        }

        public List<clsAssembly> GetAssembliesInfoDB()
        {
            DataTable dtResult = new clsGENEjeSP().EjecSP("ADM_GetAssembliesInfo_Sp");
            return MapeaTablaEntidad(dtResult);
        }

        private List<clsAssembly> MapeaTablaEntidad(DataTable dtResult)
        {
            List<clsAssembly> lstAssemblies = new List<clsAssembly>();
            foreach (DataRow row in dtResult.Rows)
            {
                clsAssembly assembly = new clsAssembly();
                assembly.cNomAssembly = Convert.ToString(row["cNomAssembly"]);
                assembly.cVersion = Convert.ToString(row["cVersion"]);

                lstAssemblies.Add(assembly);
            }
            return lstAssemblies;
        }
    }
}
