using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRE.AccesoDatos;
using System.Data;

namespace CRE.CapaNegocio
{
     public class clsCNMotivoExtorno
    {
         public clsADMotivoExtorno objMotivoExtorno = new clsADMotivoExtorno();
          public DataTable ListaMotivioExtrono(int idTipoMotivo)
          {
              return objMotivoExtorno.ListaMotivoExtorno(idTipoMotivo);
          }
          public DataTable GrabarMotivoExoITF(int idMotivoExoITF, string cMotivoExoITF, string cDetMotExoneraITF, bool lVigente)
          {
              return objMotivoExtorno.GrabarMotivoExoneraITF(idMotivoExoITF, cMotivoExoITF, cDetMotExoneraITF, lVigente);
          }

        public DataTable CNListaMotivoExtornoOperacion(int idTipoMotivo, int idTipoOperacion)
        {
            return objMotivoExtorno.ADListaMotivoExtornoOperacion(idTipoMotivo, idTipoOperacion);
        }
    }
}
