using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNKardex
    {
        public clsADKardex adkardex = new clsADKardex();

        public DataTable DetalleDesembolso(Int32 idCuenta)
        {
            return adkardex.ListaExtornoDesembolso(idCuenta);
        }

        public DataTable DetalleValida(Int32 idCuenta)
        {
            return adkardex.DatosValida(idCuenta);
        }

        public DataTable ExtDesembolso(String tCuentaCRE, String tCuentaAHO, Int32 idUsuario, DateTime dFecSystem, Int32 nIdAgencia, Int32 idCanal)
        {
            return adkardex.ExtornaDesembolso(tCuentaCRE, tCuentaAHO, idUsuario, dFecSystem, nIdAgencia, idCanal);
        }

        public DataTable DetalleDesembAHO(Int32 idCuenta)
        {
            return adkardex.ListaExtornoDesemCtaAHO(idCuenta);
        }

        public DataTable RetornaOperacionesVinculadas(int idKardexPrincipal)
        {
            return adkardex.RetornaOperacionesVinculadas(idKardexPrincipal);
        }

        public DataTable RetornaOperacionCanalRegistro(int idCuenta, String tipoOpe)
        {
            return adkardex.RetornaOperacionCanalRegistro(idCuenta, tipoOpe);
        }

        public DataTable RetornaOperacionInicioSolicitud(int idCuenta)
        {
            return adkardex.RetornaOperacionInicioSolicitud(idCuenta);
        }

    }
}
