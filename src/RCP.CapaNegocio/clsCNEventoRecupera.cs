using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.CapaNegocio
{
    public  class clsCNEventoRecupera
    {
        clsADEventoRecupera eventorecupera = new clsADEventoRecupera();

        public DataTable ListarEventoRecupera()
        {
            return eventorecupera.ListarEventoRecupera();
        } 

        public DataTable InsertarEventoRecupera( int idProcesoRecupera, int idTipoEventoRecupera, int idTipoEfecto, DateTime dFechaReg,
                                                int idUsuReg, int idContactoRecupera, int idMotivoRecupera, string cTelefono, DateTime dProxAccion, string cObservaciones,
                                                int idCli, int idCuenta, string tHoraProxAccion, bool lProxContacto, decimal nMontoMovilidad,
                                                string cOrigen,string cDestino, int idTipoRespuesta)
        {
            return eventorecupera.InsertarEventoRecupera(  idProcesoRecupera, idTipoEventoRecupera, idTipoEfecto, dFechaReg,
                                                 idUsuReg, idContactoRecupera, idMotivoRecupera, cTelefono, dProxAccion, cObservaciones, 
                                                 idCli, idCuenta, tHoraProxAccion, lProxContacto, nMontoMovilidad, cOrigen, cDestino, idTipoRespuesta);
        }

        public DataTable ActualizarEventoRecupera(int idProcesoRecupera, int idTipoEventoRecupera, int idTipoEfecto, DateTime dFechaReg,
                                                int idUsuReg, int idContactoRecupera, int idMotivoRecupera, string cTelefono, DateTime dProxAccion, string cObservaciones, int idEventoRecupera)
        {
            return eventorecupera.ActualizarEventoRecupera(idProcesoRecupera, idTipoEventoRecupera, idTipoEfecto, dFechaReg,
                                                 idUsuReg, idContactoRecupera, idMotivoRecupera, cTelefono, dProxAccion, cObservaciones, idEventoRecupera);
        }

        public DataTable ListarEventoRecuperaCliente(int idCli)
        {
            return eventorecupera.ListarEventoRecuperaCliente(idCli);
        }

        public DataTable rptAlertaVisitaCli(int nDias, int idRecuperador)
        {
            return eventorecupera.rptAlertaVisitaCli(nDias, idRecuperador);
        }

        public DataTable ListarEventoRecuperaPorCuenta(int idCuenta)
        {
            return eventorecupera.ListarEventoRecuperaPorCuenta(idCuenta);
        }
    }
}
