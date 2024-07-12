using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using SolIntEls.GEN.Helper;
using System.Data;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace RCP.AccesoDatos
{
    public class clsADCartaRecupera
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListarFirmaRecupera()
        {
            return objEjeSp.EjecSP("RCP_ListarFirmaRecupera_SP");
        }

        public DataTable InsertarFirmaRecupera(string cFirmaRecupera, Image imgFirma, bool lVigente)
        {
            MemoryStream ms = new MemoryStream();
            imgFirma.Save(ms, ImageFormat.Jpeg);
            var dt = objEjeSp.EjecSP("RCP_InsertarFirmaRecupera_SP", cFirmaRecupera, ms.ToArray(), lVigente);
            ms.Flush();
            ms.Close();

            return dt;

        }

        public DataTable ActualizarFirmaRecupera(string cFirmaRecupera, Image imgFirma, bool lVigente, int idFirmaRecupera)
        {
            MemoryStream ms = new MemoryStream();
            imgFirma.Save(ms, ImageFormat.Jpeg);
            var dt = objEjeSp.EjecSP("RCP_ActualizarFirmaRecupera_SP", cFirmaRecupera, ms.ToArray(), lVigente, idFirmaRecupera);
            ms.Flush();
            ms.Close();
            return dt;
        }

        public DataTable EliminarFirmaRecupera(int idFirmaRecupera)
        {
            return objEjeSp.EjecSP("RCP_EliminarFirmaRecupera_SP",idFirmaRecupera);
        }

        public DataTable DatosCliCreCarta(string cCuentas)
        {
            return objEjeSp.EjecSP("RCP_DatosCliCreCarta_SP", cCuentas);
        }

        public DataTable CartasGeneradas(int idCuenta)
        {
            return objEjeSp.EjecSP("RCP_CartasGeneradas_SP", idCuenta);
        }

        public DataTable InsertarCreditoCarta(int idcuenta,int idTipoCarta,DateTime dFechaReg,int idUsuReg,bool lVigente)
        {
            return objEjeSp.EjecSP("RCP_InsertarCreditoCarta_SP", idcuenta, idTipoCarta, dFechaReg, idUsuReg, lVigente);
        }

        public DataTable ListarTiposCarta(int idRangoAtraso)
        {
            return objEjeSp.EjecSP("RCP_ListarTiposCarta_SP", idRangoAtraso);
        }

        public DataTable ListaCartasRecuperador(int idUsuRecupera, string xmlTiposCarta, int idUbigeo)
        {
            return objEjeSp.EjecSP("RCP_ListaCartasRecuperador_sp", idUsuRecupera, xmlTiposCarta, idUbigeo);
        }

        public DataTable NotificacionesGeneradas(int idCuenta)
        {
            return objEjeSp.EjecSP("RCP_NotificacionesGeneradas_SP", idCuenta);
        }
    }
}
