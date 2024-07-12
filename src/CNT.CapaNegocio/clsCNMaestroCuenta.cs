using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNT.AccesoDatos;
using System.Data;

namespace CNT.CapaNegocio
{
    public class clsCNMaestroCuenta
    {
        public clsADMaestroCuentas ObjMestroCta = new clsADMaestroCuentas();

        public DataTable CNListaCuentas(int idCuentaPadre)
        {
            return ObjMestroCta.ADListaCuentas(idCuentaPadre);
        }
        public DataTable CNListaEstrucCuenta(string cCodigoCuenta)
        {
            return ObjMestroCta.ADListaEstrucCuenta(cCodigoCuenta);
        }
        public DataTable CNListaTipoAsiento()
        {
            return ObjMestroCta.ADListaTipoAsiento();
        }

        public DataTable CNListaMotivoOpeCnt(int idTipoOperacion)
        {
            return ObjMestroCta.ADListaMotivoOpeCnt( idTipoOperacion);
        }

    }
}
