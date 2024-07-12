using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper.Interface;
using SolIntEls.GEN.Helper;
using EntityLayer;
using System.Data;
using GEN.Funciones;

namespace GEN.AccesoDatos
{
    public class clsADScoreCreditos
    {
        IntConexion objCone;

        public clsADScoreCreditos(bool lWebService)
        {
            objCone = new clsWCFEjeSP();
        }

        public clsADScoreCreditos()
        {
            objCone = new clsGENEjeSP();
        }

        public List<clsScoreVarCond> ADObtenerScoreVarCond(int idTipoScore)
        {
            DataTable dtRes = objCone.EjecSP("CRE_CargaVarCondScore_SP", idTipoScore);
            return (List < clsScoreVarCond > ) DataTableToList.ConvertTo<clsScoreVarCond>(dtRes);
        }

        public List<clsScoreVariable> ADIniciarScore(clsParamScore objParam)
        {
            DataTable dtRes = objCone.EjecSP("CRE_IniciarScore_SP", objParam.cNumDocuId, objParam.cNumDocuIdConyuge, objParam.cUbigeo, objParam.idAgencia, objParam.idSolicitud, objParam.idTipoScore, objParam.idUsuario, objParam.idDestino);
            return (List < clsScoreVariable > ) DataTableToList.ConvertTo<clsScoreVariable>(dtRes);
        }

        public DataSet ADGuardaScoreResultado(List<clsScoreVarCond> obj)
        {
            return objCone.DSEjecSP("CRE_GuardaScoreResultado_SP", GenericListExtensionMethods.GetXml(obj));
        }

        public DataTable ADObtenerConyugeCliente(string cDocumentoTitular)
        {
            return objCone.EjecSP("CLI_ObtenerConyugeCliente_SP", cDocumentoTitular);
        }

        public DataSet ADValidaSiExisteScore(int idSolicitud)
        {
            return objCone.DSEjecSP("CRE_ValidaSiExisteScore_SP", idSolicitud);
        }

        public DataTable ADValidarCondicionesBasicasScore(string cDocumentoID)
        {
            return objCone.EjecSP("CRE_ValidarCondicionesBasicasScore_sp", cDocumentoID);
        }
    }
}
