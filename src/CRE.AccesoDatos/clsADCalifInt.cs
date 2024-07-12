using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using EntityLayer;

namespace CRE.AccesoDatos
{
    public class clsADCalifInt
    {

        private clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADGetClasifInt()
        {
            return objEjeSp.EjecSP("CRE_LstCalifInt_Sp");
        }

        public DataTable ADGetClasifIntCli(int idCli)
        {
            return objEjeSp.EjecSP("CRE_GetClasifIntCli_Sp", idCli);
        }

        public clsDBResp ADGuardarClasifIntCli(int idCli, int idClasif, string cObservacion,
                                                    DateTime dFecRegistro, int idUsuario)
        {
            DataTable dtResult = objEjeSp.EjecSP("CRE_GuardaClasifIntCli_Sp", idCli, idClasif,cObservacion,dFecRegistro,idUsuario);
            return new clsDBResp(dtResult);
        }
}
}
