using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNRetornsCuentaSolCliente
    {
        public clsRetornaCuentaSolCliente objRetornaCuentaSol;

        public clsCNRetornsCuentaSolCliente()
        {
            objRetornaCuentaSol = new clsRetornaCuentaSolCliente();
        }

        public clsCNRetornsCuentaSolCliente(bool lWS)
        {
            objRetornaCuentaSol = new clsRetornaCuentaSolCliente(lWS);
        }

        public DataTable RetornaCuentaSolCliente(int nIdCliente, string cTipoBusqueda, string cEstado)
        {
            return objRetornaCuentaSol.RetornaCuentaSolCliente(nIdCliente, cTipoBusqueda, cEstado);
        }

        public DataTable CNRetDetCuentasVinculadas(int idCliente, int idOperacion)
        {
            return objRetornaCuentaSol.ADRetDetCuentasVinculadas(idCliente, idOperacion);
        }

        public DataTable CNRetDetCuentasVinculadasxSoli(int idSolicitud)
        {
            return objRetornaCuentaSol.ADRetDetCuentasVinculadasxSoli(idSolicitud);
        }
        public DataTable RetornaCuentaXSolicitud(int idSolicitud)
        {
            return objRetornaCuentaSol.RetornaCuentaXSolicitud(idSolicitud);
        }
        public DataTable CNRetornaPoliticaPrivacidadCliente(int idCli)
        {
            return objRetornaCuentaSol.ADRetornaPoliticaPrivacidadCliente(idCli);
        }
        public DataTable CNRecuperaPdfSentinel(int idSolicitud)
        {
            return objRetornaCuentaSol.ADRecuperaPdfSentinel(idSolicitud);
        }
        public DataTable CNRecuperaPdfSolTasa(int idSolicitud)
        {
            return objRetornaCuentaSol.ADRecuperaPdfsolTasa(idSolicitud);
        }
        public DataTable CNRecuperaPdfTasaNegociable(int idSolicitud)
        {
            return objRetornaCuentaSol.ADRecuperaPdfTasaNegociable(idSolicitud);
        }
        public DataTable CNObtenerSubProducto(int idSubProducto)
        {
            return objRetornaCuentaSol.ADObtenerSubProducto(idSubProducto);
        }
    }
}
