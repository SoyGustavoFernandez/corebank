using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNClienteVinculado
    {
        clsClienteVinculado objClienteVinculado = new clsClienteVinculado();

        public DataTable generarIntervinienteNuevo(int idCli, int idTipoInterv, bool lIncluirCony)
        {
            return objClienteVinculado.generarIntervinienteNuevo(idCli, idTipoInterv, lIncluirCony);
        }
        public DataTable ListaClienteVinculado(Int32 nIdCliente)
        {
            return objClienteVinculado.ListaClienteVinculado(nIdCliente);
        }
        public DataTable DesactivarReglaFiado(Int32 idSolicitud, string cNombreFormulario)
        {
            return objClienteVinculado.DesactivarReglaFiador(idSolicitud, cNombreFormulario);
        }
        public DataTable CNBuscarRegistroConyuge(int idSolicitud, int idCliVin)
        {
            return objClienteVinculado.ADBuscarRegistrConyuge(idSolicitud, idCliVin);
        }
    }
}
