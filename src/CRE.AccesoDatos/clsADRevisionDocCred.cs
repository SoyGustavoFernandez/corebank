using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using GEN.Funciones;
using SolIntEls.GEN.Helper;

namespace CRE.AccesoDatos
{
    public class clsADRevisionDocCred
    {
        public clsRevisionDocCred ADGetRevisionDocCred(int idSolicitud)
        {
            DataTable dtData = new clsGENEjeSP().EjecSP("CRE_BusRevisionDocCre_Sp", idSolicitud);
            IList<clsRevisionDocCred> LstRevision = DataTableToList.ConvertTo<clsRevisionDocCred>(dtData);
            return LstRevision.FirstOrDefault();
        }

        public List<clsDetRevisionDocCre> ADGetDetRevisionDocCred(int idRevisionDocCred)
        {
            DataTable dtData = new clsGENEjeSP().EjecSP("CRE_BusDetRevisionDocCre_Sp", idRevisionDocCred);
            IList<clsDetRevisionDocCre> LstDetRevision = DataTableToList.ConvertTo<clsDetRevisionDocCre>(dtData);
            return LstDetRevision as List<clsDetRevisionDocCre>;
        }

        public clsDBResp ADGuardarRevision(string xmlRevision)
        {
            DataTable dtResult = new clsGENEjeSP().EjecSP("CRE_GuardarRevisionDocCre_Sp", xmlRevision);
            return new clsDBResp(dtResult);
        }
    }
}
