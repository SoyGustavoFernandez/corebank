using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace CRE.AccesoDatos
{
     public class clsADMotivoExtorno
    {

         clsGENEjeSP objEjeSp = new clsGENEjeSP();
         public DataTable ListaMotivoExtorno(int idTipoMotivo)
         {
             return objEjeSp.EjecSP("CRE_LisMotivoExtorno_SP",idTipoMotivo);
         }
         public DataTable GrabarMotivoExoneraITF(int idMotivoExoITF, string cMotivoExoITF, string cDetMotExoneraITF,bool lVigente)
         {
             return objEjeSp.EjecSP("DEP_GrabarMotExoITF_SP", idMotivoExoITF, cMotivoExoITF, cDetMotExoneraITF, lVigente);
         }
         
        public DataTable ADListaMotivoExtornoOperacion(int idTipoMotivo, int idTipoOperacion)
        {
            return objEjeSp.EjecSP("CRE_LisMotivoExtornoOperacion_SP", idTipoMotivo, idTipoOperacion);
        }
    }
}
