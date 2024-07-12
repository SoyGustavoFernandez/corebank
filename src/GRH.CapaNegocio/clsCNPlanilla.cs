using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNPlanilla
    {
        clsADPlanilla objPlanilla = new clsADPlanilla();

        public DataTable CNListarPlanillasProceso()
        {
            return objPlanilla.ADListarPlanillasProceso();
        }

        public DataTable CNVisualizarPlanillaProceso(int idTipoPlanilla)
        {
            return objPlanilla.ADVisualizarPlanillaProceso(idTipoPlanilla);
        }

        public DataTable CNListarPersonalCalculoPlanilla(int idTipoRelLab, int idTipoPlanilla, int idModalidad, int idPeriodoPlanilla)
        {
            return objPlanilla.ADListarPersonalCalculoPlanilla(idTipoRelLab, idTipoPlanilla, idModalidad, idPeriodoPlanilla);
        }

        public DataTable CNProcesarPlanilla(int idTipoRelLab, int idTipoPlanilla, int idModalidad, int idPeriodoPlanilla,
                                            int idPeriodoDeclaracion, string xmlPersonSelec)
        {
            return objPlanilla.ADProcesarPlanilla(idTipoRelLab, idTipoPlanilla, idModalidad, idPeriodoPlanilla,
                                                  idPeriodoDeclaracion, xmlPersonSelec);
        }

        public DataTable CNListarConceptoUsuarioPlanillaTmp(int idTipoPlanilla, int idUsuario)
        {
            return objPlanilla.ADListarConceptoUsuarioPlanillaTmp(idTipoPlanilla, idUsuario);
        }

        public DataTable CNActualizarConceptosUsuarioPlanillaTmp(int idTipoPlanilla, int idUsuario, string xmlConceptosPlanilla)
        {
            return objPlanilla.ADActualizarConceptosUsuarioPlanillaTmp(idTipoPlanilla, idUsuario, xmlConceptosPlanilla);
        }

        public DataTable CNEliminarUsuarioPlanillaTmp(int idTipoPlanilla, int idUsuario)
        {
            return objPlanilla.ADEliminarUsuarioPlanillaTmp(idTipoPlanilla, idUsuario);
        }

        public DataTable CNCerrarPlanilla(int idTipoPlanilla, DateTime dFechaPlanilla, DateTime dFechaReg, int idUsuarioReg)
        {
            return objPlanilla.ADCerrarPlanilla(idTipoPlanilla, dFechaPlanilla, dFechaReg, idUsuarioReg);
        }

        public DataTable CNAnularPlanilla(int idPlanilla, DateTime dFechaMod, int idUsuarioMod)
        {
            return objPlanilla.ADAnularPlanilla(idPlanilla, dFechaMod, idUsuarioMod);
        }

        public DataTable CNDetalleConceptosPorPlanilla(int idPlanilla)
        {
            return objPlanilla.ADDetalleConceptosPorPlanilla(idPlanilla);
        }

        //reporte de telecredito
        public DataTable CNListaDatoGralTelecred(int idPlanilla)
        {
            return objPlanilla.ADListaDatoGralTelecred(idPlanilla);
        }
        public DataTable CNListaPlanillaTelecredit(int idPlanilla, bool lValidaDocTrab)
        {
            return objPlanilla.ADListaPlanillaTelecredito(idPlanilla, lValidaDocTrab);
        }
        public DataTable CNListaPlanillaCTSTelecredit(int idPlanilla, int idPeriodo)
        {
            return objPlanilla.ADListaPlanillaCTSTelecredito(idPlanilla, idPeriodo);
        }

        public DataTable CNProvisionPlanillas(int idTipoPlanilla, DateTime dFechaProvision)
        {
            return objPlanilla.ADProvisionPlanillas(idTipoPlanilla, dFechaProvision);
        }
    }
}