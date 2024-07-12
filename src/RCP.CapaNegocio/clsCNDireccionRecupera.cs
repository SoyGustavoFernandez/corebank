using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.CapaNegocio
{
    public class clsCNDireccionRecupera
    {
        clsADDireccionRecupera direccionrecupera = new clsADDireccionRecupera();

        public DataTable ListarDireccionRecupera(int idCli)
        {
            return direccionrecupera.ListarDireccionRecupera(idCli);
        }

        public DataTable InsertarDireccionRecupera(string XmlDirCli)
        {
            return direccionrecupera.InsertarDireccionRecupera(XmlDirCli);
        }

        public DataTable ActualizarDireccionRecupera(int idDireccionRecupera, int idCli, int idUbigeo, string cDireccion, string cReferenciaDireccion, bool lVigente,
                                                    int idTipoDireccion, int idTipoZona, string cDesZona, int idTipoVia, string cDesVia,
                                                    string cInterior, string cManzana, string cLote, string cKilometro, string cBlock,
                                                    string cEtapa, string cNumero, int idTipoVivienda, string cdescOtros)
        {
            return direccionrecupera.ActualizarDireccionRecupera( idDireccionRecupera, idCli, idUbigeo, cDireccion, cReferenciaDireccion, lVigente,
                                                                         idTipoDireccion, idTipoZona, cDesZona, idTipoVia, cDesVia,
                                                                         cInterior, cManzana, cLote, cKilometro, cBlock,
                                                                         cEtapa, cNumero, idTipoVivienda, cdescOtros);
        }

        public DataTable EliminarDireccionRecupera(int idDireccionRecupera)
        {
            return direccionrecupera.EliminarDireccionRecupera( idDireccionRecupera);
        }

        public DataTable ListarDireccionClienteCompleto(int idCliente)
        {
            return direccionrecupera.ListarDireccionClienteCompleto(idCliente);
        }
    }
}
