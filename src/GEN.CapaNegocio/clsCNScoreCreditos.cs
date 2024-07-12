using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.AccesoDatos;
using EntityLayer;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNScoreCreditos
    {
        private clsADScoreCreditos objBaseDatos;

        public clsCNScoreCreditos(bool lWebService)
        {
            objBaseDatos = new clsADScoreCreditos(lWebService);
        }

        public clsCNScoreCreditos()
        {
            objBaseDatos = new clsADScoreCreditos();   
        }

        public List<clsScoreVarCond> CNObtenerScoreVarCond(int idTipoScore)
        {
            return objBaseDatos.ADObtenerScoreVarCond(idTipoScore);
        }

        public List<clsScoreVariable> CNIniciarScore(clsParamScore objParam)
        {
            return objBaseDatos.ADIniciarScore(objParam);
        }

        public DataSet CNGuardaScoreResultado(List<clsScoreVarCond> obj)
        {
            return objBaseDatos.ADGuardaScoreResultado(obj);
        }

        public DataTable CNObtenerConyugeCliente(string cDocumentoTitular)
        {
            return objBaseDatos.ADObtenerConyugeCliente(cDocumentoTitular);
        }

        public DataSet CNValidaSiExisteScore(int idSolicitud)
        {
            return objBaseDatos.ADValidaSiExisteScore(idSolicitud);
        }

        public DataTable CNValidarCondicionesBasicasScore(string cDocumentoID) 
        {
            return objBaseDatos.ADValidarCondicionesBasicasScore(cDocumentoID);
        }
    }
}
