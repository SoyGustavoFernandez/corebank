using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using RCP.AccesoDatos;
using System.Data;
using System.Drawing;

namespace RCP.CapaNegocio
{
    public class clsCNCartaRecupera
    {
        clsADCartaRecupera cartarecupera = new clsADCartaRecupera();

        public DataTable ListarFirmaRecupera()
        {
            return cartarecupera.ListarFirmaRecupera();
        }

        public DataTable InsertarFirmaRecupera(string cFirmaRecupera, Image imgFirma, bool lVigente)
        {
            return cartarecupera.InsertarFirmaRecupera(cFirmaRecupera,  imgFirma,  lVigente);
        }

        public DataTable ActualizarFirmaRecupera(string cFirmaRecupera, Image imgFirma, bool lVigente, int idFirmaRecupera)
        {
            return cartarecupera.ActualizarFirmaRecupera(cFirmaRecupera, imgFirma, lVigente, idFirmaRecupera);
        }

        public DataTable EliminarFirmaRecupera(int idFirmaRecupera)
        {
            return cartarecupera.EliminarFirmaRecupera(idFirmaRecupera);
        }

        public DataTable DatosCliCreCarta(string cCuentas)
        {
            return cartarecupera.DatosCliCreCarta(cCuentas);
        }

        public DataTable CartasGeneradas(int idCuenta)
        {
            return cartarecupera.CartasGeneradas(idCuenta);
        }

        public DataTable InsertarCreditoCarta(int idcuenta, int idTipoCarta, DateTime dFechaReg, int idUsuReg, bool lVigente)
        {
            return cartarecupera.InsertarCreditoCarta(idcuenta, idTipoCarta, dFechaReg, idUsuReg, lVigente);
        }

        public DataTable ListarTiposCarta(int idRangoAtraso)
        {
            return cartarecupera.ListarTiposCarta(idRangoAtraso);
        }

        public DataTable ListaCartasRecuperador(int idUsuRecupera, string xmlTiposCarta, int idUbigeo)
        {
            return cartarecupera.ListaCartasRecuperador(idUsuRecupera, xmlTiposCarta, idUbigeo);
        }

        public DataTable NotificacionesGeneradas(int idCuenta)
        {
            return cartarecupera.NotificacionesGeneradas(idCuenta);
        }
    }
}
