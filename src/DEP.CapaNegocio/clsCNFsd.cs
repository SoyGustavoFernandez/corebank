using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEP.AccesoDatos;
using EntityLayer;
using GEN.Funciones;

namespace DEP.CapaNegocio
{
    public class clsCNFsd
    {
        public clsADFsd objFSD = new clsADFsd();

        public DataTable ADListarLimiteCoberFSD()
        {
            return objFSD.ADListarLimiteCoberFSD();
        }

        public DataTable CNListarMotivoExclusionFSD()
        {
            return objFSD.ADListarMotivoExclusionFSD();
        }

        public clsRespuestaServidor CNRegistrarClienteExcluidoFSD(int idCliExcl, int idCli, int idExclusionFSD, DateTime dFechaInicio, DateTime dFechaHasta, bool lVigente)
        {
            DataTable dtRespuesta = this.objFSD.ADRegistrarClienteExcluidoFSD(idCliExcl, idCli, idExclusionFSD, dFechaInicio, dFechaHasta, lVigente);
            return (dtRespuesta.Rows.Count > 0) ? dtRespuesta.Rows[0].ToObject<clsRespuestaServidor>() :
                new clsRespuestaServidor();
        }

        public List<clsClienteExcluidoFSD> CNListarClienteExcluidoFSD()
        {
            DataTable dtExcluido = this.objFSD.ADListarClienteExcluidoFSD();
            return (dtExcluido.Rows.Count > 0) ?
                dtExcluido.ToList<clsClienteExcluidoFSD>() as List<clsClienteExcluidoFSD> :
                new List<clsClienteExcluidoFSD>();
        }
    }
}
