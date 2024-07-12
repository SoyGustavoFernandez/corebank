using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;

namespace GEN.AccesoDatos
{
    public class clsADKardex
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable ListaExtornoDesembolso(Int32 idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ListaExtornoDesembolso_sp", idCuenta);
        }
        public DataTable DatosValida(Int32 idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ListaDatosValidaExtorno_sp", idCuenta);
        }
        public DataTable ExtornaDesembolso(String tDatosCRE, String tDatosAHO, Int32 idUsuario, DateTime dFecSystem, Int32 nIdAgencia, Int32 idCanal)
        {
            return objEjeSp.EjecSP("CRE_ExtornaDesembolso_sp", tDatosCRE, tDatosAHO, idUsuario,  dFecSystem, nIdAgencia, idCanal);
        }
        public DataTable ListaExtornoDesemCtaAHO(Int32 idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ListaExtornoDesemCtaAho_sp", idCuenta);
        }

        public DataTable RetornaOperacionesVinculadas(int idKardexPrincipal)
        {
            return objEjeSp.EjecSP("GEN_RetornaOperacionesVinculadas_SP", idKardexPrincipal);
        }
        public DataTable RetornaOperacionCanalRegistro(int idCuenta, String tipoOpe)
        {
            return objEjeSp.EjecSP("GEN_RetornaOperacionesCanalRegistro_SP", idCuenta, tipoOpe);
        }
        public DataTable RetornaOperacionInicioSolicitud(int idCuenta)
        {
            return objEjeSp.EjecSP("GEN_BuscarOpeSolicIniKardex_SP", idCuenta);
        } 
    }
}
