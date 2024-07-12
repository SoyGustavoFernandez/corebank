using SolIntEls.GEN.Helper;
using SolIntEls.GEN.Helper.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.AccesoDatos
{
    public class clsADAPICallCenter
    {        
        private IntConexion objEjeSp;

        public clsADAPICallCenter()
        {
            objEjeSp = new clsGENEjeSP();
        }

        public clsADAPICallCenter(bool lconexion)
        {
            objEjeSp = new clsWCFEjeSP();
        }

        public DataTable ADListarMotivos(int idModalidad, string xmlReqLisTrabCC)
        {
            return this.objEjeSp.EjecSP("RCP_APITransaccionalCallCenter_SP", idModalidad, xmlReqLisTrabCC);
        }

        public DataTable ADListarTiposContacto(int idModalidad, string xmlReqLisTrabCC)
        {
            return this.objEjeSp.EjecSP("RCP_APITransaccionalCallCenter_SP", idModalidad, xmlReqLisTrabCC);
        }

        public DataTable ADGrabarContactoCli(int idModalidad, string xmlReqRegCliContac)
        {
            return this.objEjeSp.EjecSP("RCP_APITransaccionalCallCenter_SP", idModalidad, xmlReqRegCliContac);
        }

        public DataTable ADListarDatosCreditoCallCenter(int idModalidad, string xmlReqLisDatosCreCC)
        {
            return this.objEjeSp.EjecSP("RCP_APITransaccionalCallCenter_SP", idModalidad, xmlReqLisDatosCreCC);
        }

        public DataTable ADListarPlanTrabajoCallCenter(int idModalidad, string xmlReqLisTrabCC)
        {
            return this.objEjeSp.EjecSP("RCP_APITransaccionalCallCenter_SP", idModalidad, xmlReqLisTrabCC);
        }
    }
}
