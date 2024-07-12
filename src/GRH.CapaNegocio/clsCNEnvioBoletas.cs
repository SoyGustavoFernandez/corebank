using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GRH.AccesoDatos;

namespace GRH.CapaNegocio
{
    public class clsCNEnvioBoletas
    {
        clsADEnvioBoletas objAdelantoSueldo = new clsADEnvioBoletas();

        public DataTable CNInsertarDatos(string cDni, string cNombres, string cApellidos, string cPeriodo, string cAgencia, string cCorreoColabString, string cSexo, string cNomArchivo, string cEstado, string cError)
        {
            return objAdelantoSueldo.ADInsertarDatos(cDni, cNombres, cApellidos, cPeriodo, cAgencia, cCorreoColabString, cSexo, cNomArchivo, cEstado, cError);
        }

        public DataTable CNVerDatos(int nDato)
        {
            return objAdelantoSueldo.ADVerDatos(nDato);
        }




    }
}
