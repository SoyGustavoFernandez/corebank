using System.Collections.Generic;
using System.Data;
using ADM.AccesoDatos;
using EntityLayer;

namespace ADM.CapaNegocio
{
    public class clsCNMantAssemblies
    {
        public clsDBResp GuardarInfoAssemblies(string xmlAssemblies)
        {
            return new clsADMantAssemblies().GuardarInfoAssemblies(xmlAssemblies);
        }

        public List<clsAssembly> GetAssembliesInfoDB()
        {
            return new clsADMantAssemblies().GetAssembliesInfoDB();
        }
    }
}
