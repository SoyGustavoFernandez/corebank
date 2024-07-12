using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CRE.AccesoDatos;
using EntityLayer;
using GEN.Funciones;

namespace CRE.CapaNegocio
{
    public class clsCNRevisionDocCred
    {
        public clsRevisionDocCred CNGetRevisionDocCred(int idSolicitud)
        {
            return new clsADRevisionDocCred().ADGetRevisionDocCred(idSolicitud);
        }

        public List<clsDetRevisionDocCre> CNGetDetRevisionDocCred(int idRevisionDocCred)
        {
            return new clsADRevisionDocCred().ADGetDetRevisionDocCred(idRevisionDocCred);
        }

        public clsDBResp CNGuardarRevison(string xmlRevision)
        {
            return new clsADRevisionDocCred().ADGuardarRevision(xmlRevision);
        }
    }
}