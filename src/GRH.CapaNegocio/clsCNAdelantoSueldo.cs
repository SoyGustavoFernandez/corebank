using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNAdelantoSueldo
    {
        clsADAdelantoSueldo objAdelantoSueldo = new clsADAdelantoSueldo();

        public DataTable CNListarAdelantoSueldoPorUsuario(int idUsuario)
        {
            return objAdelantoSueldo.ADListarAdelantoSueldoPorUsuario(idUsuario);
        }

        public DataTable CNListarDescuentosAdelantoSueldo(int idAdelantoSueldo)
        {
            return objAdelantoSueldo.ADListarDescuentosAdelantoSueldo(idAdelantoSueldo);
        }

        public DataTable CNRegistrarAdelantoSueldo(int idTipoPlanilla, int idPeriodoPlanilla, int idUsuario, int idRelacionLab, DateTime dFechaSolicitud, decimal nMontoAdelanto, string cMotivoAdelanto, string xmlDescuentoAdelantoSueldo, DateTime dFechaReg, int idUsuarioReg)
        {
            return objAdelantoSueldo.ADRegistrarAdelantoSueldo(idTipoPlanilla, idPeriodoPlanilla, idUsuario, idRelacionLab, dFechaSolicitud, nMontoAdelanto, cMotivoAdelanto, xmlDescuentoAdelantoSueldo, dFechaReg, idUsuarioReg);
        }

        public DataTable CNActualizarAdelantoSueldo(int idAdelantoSueldo, int idPeriodoPlanilla, decimal nMontoAdelanto, string cMotivoAdelanto, string xmlDescuentoAdelantoSueldo, DateTime dFechaMod, int idUsuarioMod)
        {
            return objAdelantoSueldo.ADActualizarAdelantoSueldo(idAdelantoSueldo, idPeriodoPlanilla, nMontoAdelanto, cMotivoAdelanto, xmlDescuentoAdelantoSueldo, dFechaMod, idUsuarioMod);
        }

        public DataTable CNEliminarAdelantoSueldo(int idAdelantoSueldo, DateTime dFechaMod, int idUsuarioMod)
        {
            return objAdelantoSueldo.ADEliminarAdelantoSueldo(idAdelantoSueldo, dFechaMod, idUsuarioMod);
        }
    }
}
