using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADPLAME
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarPLAME()
        {
            return objEjeSp.EjecSP("GRH_listarPLAME_SP");
        }
        public DataTable ProcesPlanillas(string cNomSp, int idPeriodo)
        {
            return objEjeSp.EjecSP(cNomSp, idPeriodo);
        }
        public DataTable ListarTREGISTRO()
        {
            return objEjeSp.EjecSP("GRH_listarTREGISTROS_SP");
        }
        public DataTable ProcesRegistros(string cNomSp, int idPeriodo)
        {
            return objEjeSp.EjecSP(cNomSp, idPeriodo);
        }
    }
}
