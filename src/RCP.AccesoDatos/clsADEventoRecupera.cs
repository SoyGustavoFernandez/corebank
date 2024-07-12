using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.AccesoDatos
{
    public class clsADEventoRecupera
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarEventoRecupera()
        {
            
            return objEjeSp.EjecSP("RCP_ListarEventoRecupera_SP");
        }
         
        public DataTable InsertarEventoRecupera(int idProcesoRecupera, int idTipoEventoRecupera, int idTipoEfecto, DateTime dFechaReg,
                                                int idUsuReg, int idContactoRecupera, int idMotivoRecupera, string cTelefono, DateTime dProxAccion,
                                                string cObservaciones, int idCli, int idCuenta, string tHoraProxAccion, bool lProxContacto, decimal nMontoMovilidad,
                                                string cOrigen, string cDestino, int idTipoRespuesta)
        {
            return objEjeSp.EjecSP("RCP_InsertarEventoRecupera_SP", idProcesoRecupera, idTipoEventoRecupera, idTipoEfecto, dFechaReg,
                                                 idUsuReg, idContactoRecupera, idMotivoRecupera, cTelefono, dProxAccion, cObservaciones, 
                                                 idCli, idCuenta, tHoraProxAccion, lProxContacto, nMontoMovilidad, cOrigen, cDestino, idTipoRespuesta);
        }

        public DataTable ActualizarEventoRecupera(int idProcesoRecupera, int idTipoEventoRecupera, int idTipoEfecto, DateTime dFechaReg,
                                                int idUsuReg, int idContactoRecupera, int idMotivoRecupera, string cTelefono, DateTime dProxAccion, string cObservaciones, int idEventoRecupera)
        {
            return objEjeSp.EjecSP("RCP_ActualizarEventoRecupera_SP",idProcesoRecupera,  idTipoEventoRecupera,  idTipoEfecto,  dFechaReg,
                                                 idUsuReg,  idContactoRecupera,  idMotivoRecupera,  cTelefono,  dProxAccion,  cObservaciones,idEventoRecupera);
        }

        public DataTable ListarEventoRecuperaCliente(int idCli)
        {
            return objEjeSp.EjecSP("RCP_ListarEventoRecuperaCliente_SP", idCli);
        }

        public DataTable rptAlertaVisitaCli(int nDias, int idRecuperador)
        {
            return objEjeSp.EjecSP("RCP_AlertaVisitaCli_sp", nDias, idRecuperador);
        }


        public DataTable ListarEventoRecuperaPorCuenta( int idCuenta)
        {
            return objEjeSp.EjecSP("RCP_ListarHistorialRecuperaciones_SP", idCuenta);
        }
    }
}
