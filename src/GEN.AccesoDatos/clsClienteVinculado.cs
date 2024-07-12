using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsClienteVinculado
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable generarIntervinienteNuevo(int idCli, int idTipoInterv, bool lIncluirCony)
        {
            return objEjeSp.EjecSP("GEN_GenerarIntervinienteNuevo_SP", idCli, idTipoInterv, lIncluirCony);
        }
        public DataTable ListaClienteVinculado( Int32 nIdCliente)
        {
            return objEjeSp.EjecSP("Gen_ListaClienteVinculo_Sp", nIdCliente);
        }
        public DataTable DesactivarReglaFiador(Int32 idSolicitud, string cNombreFormulario)
        {
            return objEjeSp.EjecSP("Gen_DesactivarReglaFiador_Sp", idSolicitud, cNombreFormulario);
        }
        public DataTable ADBuscarRegistrConyuge(int idSolicitud, int idCliVin)
        {
            return objEjeSp.EjecSP("CRE_BuscarRegistroIntervCon_SP", idSolicitud, idCliVin);
        }
    }
}
