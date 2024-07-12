using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntityLayer;

namespace RCP.AccesoDatos
{
    public class clsADRecuperacionComision
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarRecuperacionComisionTipo()
        {
            return objEjeSp.EjecSP("GEN_ListarRecuperacionComisionTipo_SP");
        }

        public DataTable listarRecuperacionComision( int idRecuperacionComisionTipo, DateTime dFecha)
        {
            string cProcedimientoAlmacenado = string.Empty;

            switch(idRecuperacionComisionTipo)
            {
                case (int)RecuperacionComisionTipo.GestorRecuperacion:
                    cProcedimientoAlmacenado = "RCP_CalcularGestorRecuperacionComision_SP";
                    break;
                case(int)RecuperacionComisionTipo.SupervisorRecuperacion:
                    cProcedimientoAlmacenado = "RCP_CalcularSupervisorRecuperacionComision_SP";
                    break;
                case (int)RecuperacionComisionTipo.SupervisorJudicial:
                    cProcedimientoAlmacenado = "RCP_CalcularSupervisorJudicialRecupComision_SP";
                    break;
                case (int)RecuperacionComisionTipo.CarteraCastigada:
                    cProcedimientoAlmacenado = "RCP_CalcularCarteraCastigadaRecupComision_SP";
                    break;
                case (int)RecuperacionComisionTipo.JefeRecuperacion:
                    cProcedimientoAlmacenado = "RCP_CalcularJefeRecuperacionComision_SP";
                    break;
                case (int)RecuperacionComisionTipo.CallCenter:
                    cProcedimientoAlmacenado = "RCP_CalcularCallCenterRecupComision_SP";
                    break;
            }
            return objEjeSp.EjecSP(cProcedimientoAlmacenado, idRecuperacionComisionTipo, dFecha);
        }
        public DataTable grabarRecuperacionComision(int idRecuperacionComisionTipo, int idUsuario, DateTime dFecha, string xmlRecuperacionComision)
        {
            return objEjeSp.EjecSP("RCP_GrabarRecuperacionComision_SP", idRecuperacionComisionTipo, idUsuario, dFecha, xmlRecuperacionComision);
        }

        public DataTable listarMetaReduccionSaldoVencido(int nAnio, int nMes)
        {
            return objEjeSp.EjecSP("RCP_ListarMetaReduccionSaldoVencido_SP", nAnio, nMes);
        }

        public DataTable grabarMetaReduccionSaldoVencido(int idUsuario, string xmlMetaReducSaldoVencido)
        {
            return objEjeSp.EjecSP("RCP_GrabarMetaReduccionSaldoVencido_SP", idUsuario, xmlMetaReducSaldoVencido);
        }

        public DataTable listarRecuperacionCondonacionLimite(int nAnio, int nMes)
        {
            return objEjeSp.EjecSP("RCP_ListarRecuperacionCondonacionLimite_SP", nAnio, nMes);
        }

        public DataTable grabarRecuperacionCondonacionLimite(int idUsuario, string xmlMetaReducSaldoVencido)
        {
            return objEjeSp.EjecSP("RCP_GrabarRecuperacionCondonacionLimite_SP", idUsuario, xmlMetaReducSaldoVencido);
        }
        public DataTable revisarGrabadoRecuperacionComision(DateTime dFecha)
        {
            return objEjeSp.EjecSP("RCP_RevisarGrabadoRecuperacionComision_SP", dFecha);
        }
        public DataTable grabarAproSolicitudRecComision(DateTime dFecha, DateTime dFechaComision, decimal nMontoComision, int idUsuario)
        {
            return objEjeSp.EjecSP("RCP_GrabarAproSolicitudRecComision_SP", dFecha, dFechaComision, nMontoComision, idUsuario);
        }
        public DataTable listarAproSolicitudRecComision(int idPerfil)
        {
            return objEjeSp.EjecSP("RCP_ListarAproSolicitudRecComision_SP", idPerfil);
        }
        public DataTable gestionarAprobacionRecuperacionComision(int idNivelAprobacion, int idPerfil)
        {
            return objEjeSp.EjecSP("RCP_GestionarAprobacionRecuperacionComision_SP", idNivelAprobacion, idPerfil);
        }
        public DataTable grabarResolucionAproSolRecComision(int idAproSolicitudRecComision, int idEstado,int idNivelAprobacion, int idNivelAprobacionSig , int idUsuario,
            decimal nMontoComision, DateTime dFechaComision, string cComentario)
        {
            return objEjeSp.EjecSP("RCP_GrabarResolucionAproSolRecComision_SP", idAproSolicitudRecComision, idEstado, idNivelAprobacion, idNivelAprobacionSig, idUsuario,
                nMontoComision, dFechaComision, cComentario);
        }
        public DataTable calcularRecuperacionComisionMora(DateTime dFecha, int idAgencia = 0, int idUsuario = 0, int idZona = 0)
        {
            return objEjeSp.EjecSP("RCP_CalcularRecuperacionComisionMora_SP", dFecha, idAgencia, idUsuario, idZona);
        }
        public DataSet recuperacionComisionHistorico(DateTime dFecha, int idEstablecimiento = 0, int idZona = 0)
        {
            return objEjeSp.DSEjecSP("RCP_RecuperacionComisionHistorico_SP", dFecha, idEstablecimiento, idZona);
        }
         
    }
}
