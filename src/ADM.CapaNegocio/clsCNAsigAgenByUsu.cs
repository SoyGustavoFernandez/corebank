using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADM.AccesoDatos;
using EntityLayer;

namespace ADM.CapaNegocio
{
    public class clsCNAsigAgenByUsu
    {
        public List<clsAgenByUsu> CNGetAgenByUsu(int idAgenByUsu)
        {
            return new clsADAsigAgenByUsu().ADGetAgenByUsu(idAgenByUsu);
        }

        public clsDBResp CNGuardarAgenByUsu(clsAgenByUsu objAgenByUsu)
        {
            return new clsADAsigAgenByUsu().ADGuardarAgenByUsu(objAgenByUsu);
        }
    }
}
