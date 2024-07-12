using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.CapaNegocio
{
    public class clsCNAPICallCenter
    {
        clsADAPICallCenter objADAPICallCenter = new clsADAPICallCenter();

        public clsCNAPICallCenter()
        {
            objADAPICallCenter = new clsADAPICallCenter();
        }

        public clsCNAPICallCenter(bool cConex)
        {
            objADAPICallCenter = new clsADAPICallCenter(cConex);
        }

        public DataTable CNListarMotivos(int idModalidad, string xmlReqLisTrabCC)
        {
            return objADAPICallCenter.ADListarMotivos(idModalidad, xmlReqLisTrabCC);
        }

        public DataTable CNListarTiposContacto(int idModalidad, string xmlReqLisTrabCC)
        {
            return objADAPICallCenter.ADListarTiposContacto(idModalidad, xmlReqLisTrabCC);
        }

        public DataTable CNGrabarContactoCli(int idModalidad, string xmlReqRegCliContac)
        {
            return objADAPICallCenter.ADGrabarContactoCli(idModalidad, xmlReqRegCliContac);
        }
         
        public DataTable CNListarDatosCreditoCallCenter(int idModalidad, string xmlReqLisDatosCreCC)
        {
            return objADAPICallCenter.ADListarDatosCreditoCallCenter(idModalidad, xmlReqLisDatosCreCC);
        }

        public DataTable CNListarPlanTrabajoCallCenter(int idModalidad, string xmlReqLisTrabCC)
        {
            return objADAPICallCenter.ADListarPlanTrabajoCallCenter(idModalidad, xmlReqLisTrabCC);
        }
    }
}
