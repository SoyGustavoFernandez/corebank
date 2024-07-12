using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNPersonalCreditos
    {
        public clsADPersonalCreditos objdocide = new clsADPersonalCreditos();
        public DataTable ListarPersonalCre(Int32 idAgencia, int idEstadoPersonal = 0)
        {
            return objdocide.ListaPersonalCre(idAgencia, idEstadoPersonal);
        }
        public DataTable CNListaPromotorCred(int idAgencia)
        {
            return objdocide.ADListaPromotorCre(idAgencia);
        }

        public DataTable ListarAsesorNegGrupoSol(int idAgencia = 0)
        {
            return objdocide.ListarAsesorNegGrupoSol(idAgencia);
        }
        
        public DataTable ListarPersonalCompletoCre(Int32 idAgencia)
        {
            return objdocide.ListaPersonalCompletoCre(idAgencia);
        }

        public DataTable ListarPersonalCompletoZonaCre(Int32 idZona)
        {
            return objdocide.ListaPersonalCompletoZonaCre(idZona);
        }

        public DataTable ListarUsuariosConCartera(DateTime dFechaIni, DateTime dFechaFin, int idZona, int idAgencia)
        {
            return objdocide.ListarUsuariosConCartera(dFechaIni, dFechaFin, idZona, idAgencia);
        }

        public DataTable ListarPersonalAsesorPrincipal(int idAgencias)
        {
            return objdocide.ListarPersonalAsesorPrincipal(idAgencias);
        }
    }
}
