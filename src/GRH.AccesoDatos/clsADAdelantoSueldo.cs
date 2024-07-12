using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADAdelantoSueldo
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarAdelantoSueldoPorUsuario(int idUsuario)
        {
            return objEjeSp.EjecSP("GRH_ListarAdelantoSueldoPorUsuario_SP", idUsuario);
        }

        public DataTable ADListarDescuentosAdelantoSueldo(int idAdelantoSueldo)
        {
            return objEjeSp.EjecSP("GRH_ListarDescuentosAdelantoSueldo_SP", idAdelantoSueldo);
        }

        public DataTable ADRegistrarAdelantoSueldo(int idTipoPlanilla, int idPeriodoPlanilla, int idUsuario, int idRelacionLab, DateTime dFechaSolicitud, decimal nMontoAdelanto, string cMotivoAdelanto, string xmlDescuentoAdelantoSueldo, DateTime dFechaReg, int idUsuarioReg)
        {
            return objEjeSp.EjecSP("GRH_RegistrarAdelantoSueldo_SP", idTipoPlanilla, idPeriodoPlanilla, idUsuario, idRelacionLab, dFechaSolicitud, nMontoAdelanto, cMotivoAdelanto, xmlDescuentoAdelantoSueldo, dFechaReg, idUsuarioReg);
        }

        public DataTable ADActualizarAdelantoSueldo(int idAdelantoSueldo, int idPeriodoPlanilla, decimal nMontoAdelanto, string cMotivoAdelanto, string xmlDescuentoAdelantoSueldo, DateTime dFechaMod, int idUsuarioMod)
        {
            return objEjeSp.EjecSP("GRH_ActualizarAdelantoSueldo_SP", idAdelantoSueldo, idPeriodoPlanilla, nMontoAdelanto, cMotivoAdelanto, xmlDescuentoAdelantoSueldo, dFechaMod, idUsuarioMod);
        }

        public DataTable ADEliminarAdelantoSueldo(int idAdelantoSueldo, DateTime dFechaMod, int idUsuarioMod)
        {
            return objEjeSp.EjecSP("GRH_EliminarAdelantoSueldo_SP", idAdelantoSueldo, dFechaMod, idUsuarioMod);
        }
    }
}
