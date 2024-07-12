using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.AccesoDatos
{
    public class clsADDireccionRecupera
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarDireccionRecupera(int idCli)
        {
            return objEjeSp.EjecSP("RCP_ListarDireccionRecupera_SP", idCli);
        }

        public DataTable InsertarDireccionRecupera(string XmlDirCli)
        {
            return objEjeSp.EjecSP("RCP_InsertarDireccionRecupera_SP", XmlDirCli);
        }

        public DataTable ActualizarDireccionRecupera(int idDireccionRecupera,int idCli, int idUbigeo, string cDireccion, string cReferenciaDireccion, bool lVigente,
                                                    int idTipoDireccion, int idTipoZona, string cDesZona, int idTipoVia, string cDesVia,
                                                    string cInterior, string cManzana, string cLote, string cKilometro, string cBlock,
                                                    string cEtapa, string cNumero, int idTipoVivienda, string cdescOtros)
        {
            return objEjeSp.EjecSP("RCP_ActualizarDireccionRecupera_SP", idDireccionRecupera,idCli, idUbigeo, cDireccion, cReferenciaDireccion, lVigente,
                                                                         idTipoDireccion, idTipoZona, cDesZona, idTipoVia, cDesVia,
                                                                         cInterior, cManzana, cLote, cKilometro, cBlock,
                                                                         cEtapa, cNumero, idTipoVivienda, cdescOtros);
        }

        public DataTable EliminarDireccionRecupera(int idDireccionRecupera)
        {
            return objEjeSp.EjecSP("RCP_EliminarDireccionRecupera_SP", idDireccionRecupera);
        }

        public DataTable ListarDireccionClienteCompleto(int idCliente)
        {
            return objEjeSp.EjecSP("RCP_ListarDireccionesClienteCompleto_SP", idCliente);
        }
    }
}
