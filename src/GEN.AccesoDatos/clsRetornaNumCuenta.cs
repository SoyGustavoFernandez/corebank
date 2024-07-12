using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolIntEls.GEN.Helper;
using System.Data;
using SolIntEls.GEN.Helper.Interface;

namespace GEN.AccesoDatos
{
    public class clsRetornaNumCuenta
    {
        public IntConexion objEjeSp;

        public clsRetornaNumCuenta()
        { 
            this.objEjeSp = new clsGENEjeSP();
        }

        public clsRetornaNumCuenta(bool lWCF)
        {
            this.objEjeSp = new clsWCFEjeSP();
        }

        public DataTable RetornaNumCuenta(int nValBusqueda, string cTipoBusqueda,string cEstado )
        {
            return objEjeSp.EjecSP("Cre_RetornaNumCuenta_sp", nValBusqueda, cTipoBusqueda, cEstado);
        }

        public DataTable VerifEstCuenta(int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_VerifEstCuenta_sp", idCuenta);
        }
        //jcasas
        public DataTable RetornaAsesorCuenta(int idCuenta)
        {
            return objEjeSp.EjecSP("Cre_RetornaAsesorCuenta_sp", idCuenta);
        }
        //jcasas
        public DataTable ProyecCuenta(string dFechaCalculo,int idCuenta)
        {
            return objEjeSp.EjecSP("CRE_ProyeccionCredito_sp", dFechaCalculo,idCuenta);
        }

        public DataTable BusUsuBlo(int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_BusUsuBlo_sp", idUsuario);
        }

        public DataTable UpdEstCuenta(int idCuenta, Nullable<int> idUsuario)
        {
            return objEjeSp.EjecSP("CRE_UpdEstCuenta_sp", idCuenta, idUsuario);
        }
        //Verifica el estado de todas las cuentas (Ahorro y Creditos)
        public DataTable ADVerifEstCuentaGen(int idCuenta, int idModulo)
        {
            return objEjeSp.EjecSP("GEN_VerifEstCuenta_sp", idCuenta, idModulo);
        }
        //Desbloquea Cuentas
        public DataTable ADDesbloqueaCuenta(int idCuenta, int idModulo)
        {
            return objEjeSp.EjecSP("GEN_Desbloqueacuentas_sp", idCuenta, idModulo);
        }
    }
}
