using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SolIntEls.GEN.Helper.Interface
{
    public interface IntConexion
    {
        List<clsGENParams> CargaParametroSP(string NombreSP, SqlConnection con);

        DataTable EjecSP(string NombreSP, params object[] parametros);

        DataTable EjecSPTMO(string NombreSP, int nTimeOut, params object[] parametros);

        DataSet DSEjecSP(string NombreSP, params object[] parametros);

        void EjecSPAlm(string NombreSP, params object[] parametros);
    }
}
