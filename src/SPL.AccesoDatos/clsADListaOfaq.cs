using EntityLayer;
using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPL.AccesoDatos
{
    public class clsADListaOfaq
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();

        public DataTable InsertarListaOfaq(string xmListaOfaq, int idUsuReg)
        {
            return objEjeSp.EjecSP("SPL_InsertarListaOfaq_SP", xmListaOfaq, idUsuReg);
        }

        public DataTable InsertarDireccionListaOfaq(string xmDirListaOfaq, int idUsuReg)
        {
            return objEjeSp.EjecSP("SPL_InsertarDireccionOfaq_SP", xmDirListaOfaq, idUsuReg);
        }

        public DataTable ValidarListaOfaqClientes()
        {
            return objEjeSp.EjecSP("SPL_ValidarListaOfaqClientes_SP");
        }
    }
}
