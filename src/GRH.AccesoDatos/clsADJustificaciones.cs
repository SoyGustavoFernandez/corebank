using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntEls.GEN.Helper;

namespace GRH.AccesoDatos
{
    public class clsADJustificaciones
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

       
        public DataTable Inasistencias(int idUsuario, int idPeriodo)
        {
            return objEjeSp.EjecSP("GRH_ListarInasistencias_SP", idUsuario, idPeriodo);
        }
        public DataTable EnviarSolicitud(int idAgencia, int idCliente, int idTipoOper, int EstadoOpe, int idMoneda, int idProducto,
                                        decimal Valor, int NroCuenta, DateTime FechaSolic, int idMotivo, string sustento, int EstSolic, DateTime FechaAprob,
                                        int idUsuario, bool x_lExcepcion, int idEstablecimiento = 0, int idPerfil = 0, int idTipoOpeExp = 0, string cLimiteExcep = "")
        {
            return objEjeSp.EjecSP("GEN_InsSoliciAproba_SP", idAgencia, idCliente, idTipoOper, EstadoOpe, idMoneda, idProducto,
                                         Valor, NroCuenta, FechaSolic, idMotivo, sustento, EstSolic, FechaAprob,
                                         idUsuario, x_lExcepcion, idEstablecimiento, idPerfil, idTipoOpeExp, cLimiteExcep);
        }
        public DataTable GuardarSolicitud(int idUsuario,string cSustento, string XMLInasistencias)
        {
            return objEjeSp.EjecSP("GRH_SolicJustifInasis_SP", idUsuario,cSustento, XMLInasistencias);
        }
        public DataTable DatosSolicitud(int idUsuario, int idPeriodo)
        {
            return objEjeSp.EjecSP("GRH_DatosSolicJustif_SP", idUsuario, idPeriodo);
        }
        public void AnularSolicRechazada(int idSolicitud)
        {
            objEjeSp.EjecSP("GRH_AnularSolic_SP", idSolicitud);
        }
    }
}
