using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;
using System.Data;
namespace GEN.AccesoDatos
{
    
    public class clsADListaFormatoImp
    {
        clsGENEjeSP ObjEjeSP = new clsGENEjeSP();
        public DataTable ADListaFormato()
        {
            return ObjEjeSP.EjecSP("GEN_ListarFormatosImp_sp");
            
        }

        public DataTable ADListaFormatosReimpresion(int idOpcion, int idCuenta)
        {
            return ObjEjeSP.EjecSP("GEN_ListarFormatosReimpresion_sp", idOpcion, idCuenta);

        }

        public DataTable ADRegistraReimpresionDocs(int idCuenta, int idMotivo, string cMotivo, int idSolicitud, int idUsuario, int idAgencia, string XMLDocs)
        {
            return ObjEjeSP.EjecSP("DEP_RegSolicitudReimpresion_SP", idCuenta, idMotivo, cMotivo, idSolicitud, idUsuario, idAgencia, XMLDocs);

        }

        public DataTable ADSolicitudReimpresionApr()
        {
            return ObjEjeSP.EjecSP("DEP_SolicitudesImpresionApr_Sp");

        }
    }
}
