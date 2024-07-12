using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEN.AccesoDatos;
using System.Data;

namespace GEN.CapaNegocio
{
    public class clsCNRetornaNumCuenta
    {
        clsRetornaNumCuenta objRetNumCuenta;

        public clsCNRetornaNumCuenta()
        {
            this.objRetNumCuenta = new clsRetornaNumCuenta();
        }

        public clsCNRetornaNumCuenta(bool cConex)
        {
            this.objRetNumCuenta = new clsRetornaNumCuenta(cConex);
        }

        public DataTable RetornaNumCuenta(int nValBusqueda, string cTipoBusqueda,string cEstado )
        {
            return objRetNumCuenta.RetornaNumCuenta(nValBusqueda, cTipoBusqueda, cEstado);
        }
        public DataTable VerifEstCuenta(int idCuenta)
        {
            return objRetNumCuenta.VerifEstCuenta(idCuenta);
        }
        //jcasas
        public DataTable RetornaAsesorCuenta(int idCuenta)
        {
            return objRetNumCuenta.RetornaAsesorCuenta(idCuenta);
        }
        //jcasas
        public DataTable ProyecCuenta(string dFechaCalculo, int idCuenta)
        {
            return objRetNumCuenta.ProyecCuenta(dFechaCalculo, idCuenta);
        }
    
        public DataTable BusUsuBlo(int idUsuario)
        {
            return objRetNumCuenta.BusUsuBlo(idUsuario);
        }

        public DataTable UpdEstCuenta(int idCuenta, Nullable<int> idUsuario)
        {
            return objRetNumCuenta.UpdEstCuenta(idCuenta, idUsuario);
        }
        //Desbloquea Cuentas
        public DataTable CNDesbloqueaCuenta(int idCuenta, int idModulo)
        {
            return objRetNumCuenta.ADDesbloqueaCuenta(idCuenta, idModulo);
        }
        public DataTable CNVerifEstCuentaGen(int idCuenta, int idModulo)
        {
            return objRetNumCuenta.ADVerifEstCuentaGen(idCuenta, idModulo);
        }
    }
}
