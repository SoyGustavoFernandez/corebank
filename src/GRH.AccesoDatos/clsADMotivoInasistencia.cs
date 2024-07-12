using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADMotivoInasistencia
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarMotivosPermisoUsuario()
        {
            return objEjeSp.EjecSP("GRH_ListarMotivosPermisoUsuario_SP");
        }

        public DataTable ADListarMotivosPermisoRRHH()
        {
            return objEjeSp.EjecSP("GRH_ListarMotivosPermisoRRHH_SP");
        }

        public DataTable ADListarMotivosJustificacion()
        {
            return objEjeSp.EjecSP("GRH_ListarMotivosJustificacion_SP");
        }
        public DataTable ListarMotivos()
        {
            return objEjeSp.EjecSP("GRH_ListarMotivos_SP");
        }
        public DataTable ActualizarMotivos(int TipOpe, int idMotivoAux, string cNombreMot, int lLaborable, int lFalta,
                                            int lDescuento, int lPermiso, int lJustificacion, int lPermRRHH)
        {
            return objEjeSp.EjecSP("GRH_ActualizarMotivos_SP", TipOpe, idMotivoAux, cNombreMot, lLaborable, lFalta, lDescuento, lPermiso,
                                                  lJustificacion, lPermRRHH);
        }
        public DataTable GuardarMotivos(string cNombreMot, int lLaborable, int lFalta,
                                            int lDescuento, int lPermiso, int lJustificacion, int lPermRRHH)
        {
            return objEjeSp.EjecSP("GRH_GuardarMotivos_SP", cNombreMot, lLaborable, lFalta, lDescuento, lPermiso,
                                                  lJustificacion, lPermRRHH);
        }
        public DataTable EliminarMotivo(int idMotivo)
        {
            return objEjeSp.EjecSP("GRH_EliminarMotivos_SP", idMotivo);
        }
    }
}
