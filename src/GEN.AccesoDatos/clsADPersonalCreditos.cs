using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADPersonalCreditos
    {
        public clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ListaPersonalCre(Int32 idAgencia, int idEstadoPersonal)
        {
            return objEjeSp.EjecSP("CRE_ListaAsesorCredito_sp", idAgencia, idEstadoPersonal);
        }
        public DataTable ADListaPromotorCre(Int32 idAgencia)
        {
            return objEjeSp.EjecSP("CRE_ListaPromotorCredito_sp", idAgencia);
        }

        public DataTable ListarAsesorNegGrupoSol(int idAgencia)
        {
            return objEjeSp.EjecSP("CRE_ListarAsesorNegGrupoSol_SP", idAgencia);
        }

        public DataTable ListaPersonalCompletoCre(Int32 idAgencia)
        {
            return objEjeSp.EjecSP("CRE_ListaAsesorCreditoCompleto_sp", idAgencia);
        }

        public DataTable ListaPersonalCompletoZonaCre(Int32 idZona)
        {
            return objEjeSp.EjecSP("CRE_ListaAsesorCreditoCompletoZona_SP", idZona);
        }

        public DataTable ListarUsuariosConCartera(DateTime dFechaIni, DateTime dFechaFin, int idZona, int idAgencia)
        {
            return objEjeSp.EjecSP("CRE_ListarUsuariosConCartera_SP", dFechaIni, dFechaFin, idZona, idAgencia);
        }
        public DataTable ListarPersonalAsesorPrincipal(int idAgencias)
        {
            return objEjeSp.EjecSP("CRE_ListarPersonalAsesorPrincipal_SP", idAgencias);
        }
    }
}