using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADPlanilla
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ADListarPlanillasProceso()
        {
            return objEjeSp.EjecSP("GRH_ListarPlanillasProceso_SP");
        }

        public DataTable ADVisualizarPlanillaProceso(int idTipoPlanilla)
        {
            return objEjeSp.EjecSP("GRH_VisualizarPlanillaProceso_SP", idTipoPlanilla);
        }

        public DataTable ADListarPersonalCalculoPlanilla(int idTipoRelLab, int idTipoPlanilla, int idModalidad,int idPeriodoPlanilla)
        {
            return objEjeSp.EjecSP("GRH_ListarPersonalCalculoPlanilla_SP", idTipoRelLab, idTipoPlanilla, idModalidad, idPeriodoPlanilla);
        }

        public DataTable ADProcesarPlanilla(int idTipoRelLab, int idTipoPlanilla, int idModalidad, int idPeriodoPlanilla,
                                            int idPeriodoDeclaracion, string xmlPersonSelec)
        {
            return objEjeSp.EjecSP("GRH_ProcesarPlanilla_SP", idTipoRelLab, idTipoPlanilla, idModalidad, idPeriodoPlanilla,
                                                              idPeriodoDeclaracion, xmlPersonSelec);
        }

        public DataTable ADListarConceptoUsuarioPlanillaTmp(int idTipoPlanilla, int idUsuario)
        {
            return objEjeSp.EjecSP("GRH_ListarConceptoUsuarioPlanillaTmp_SP", idTipoPlanilla, idUsuario);
        }

        public DataTable ADActualizarConceptosUsuarioPlanillaTmp(int idTipoPlanilla, int idUsuario, string xmlConceptosPlanilla)
        {
            return objEjeSp.EjecSP("GRH_ActualizarConceptosUsuarioPlanillaTmp_SP", idTipoPlanilla, idUsuario, xmlConceptosPlanilla);
        }

        public DataTable ADEliminarUsuarioPlanillaTmp(int idTipoPlanilla, int idUsuario)
        {
            return objEjeSp.EjecSP("GRH_EliminarUsuarioPlanillaTmp_SP", idTipoPlanilla, idUsuario);
        }

        public DataTable ADCerrarPlanilla(int idTipoPlanilla, DateTime dFechaPlanilla, DateTime dFechaReg, int idUsuarioReg)
        {
            return objEjeSp.EjecSP("GRH_CerrarPlanilla_SP", idTipoPlanilla, dFechaPlanilla, dFechaReg, idUsuarioReg);
        }

        public DataTable ADAnularPlanilla(int idPlanilla, DateTime dFechaMod, int idUsuarioMod)
        {
            return objEjeSp.EjecSP("GRH_AnularPlanilla_SP", idPlanilla, dFechaMod, idUsuarioMod);
        }

        public DataTable ADDetalleConceptosPorPlanilla(int idPlanilla)
        {
            return objEjeSp.EjecSP("GRH_DetalleConceptosPorPlanilla_SP", idPlanilla);
        }

        public DataTable ADListaDatoGralTelecred(int idPlanilla)
        {
            return objEjeSp.EjecSP("GRH_ListaDatosCuentaCargoTelecred_SP", idPlanilla);
        }
        public DataTable ADListaPlanillaTelecredito(int idPlanilla, bool lValidaDocTrab)
        {
            return objEjeSp.EjecSP("GRH_ListaPlanillaRemuneraTelecred_SP", idPlanilla, lValidaDocTrab);
        }
        public DataTable ADListaPlanillaCTSTelecredito(int idPlanilla, int idPeriodo)
        {
            return objEjeSp.EjecSP("GRH_ListaPlanillaCTSTelecred_SP", idPlanilla, idPeriodo);
        }

        public DataTable ADProvisionPlanillas(int idTipoPlanilla, DateTime dFechaProvision)
        {
            return objEjeSp.EjecSP("GRH_ProvisionPlanillasAgencia_SP", idTipoPlanilla, dFechaProvision);
        }
    }
}
