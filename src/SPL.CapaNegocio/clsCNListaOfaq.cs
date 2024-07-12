using SPL.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPL.CapaNegocio
{
    public class clsCNListaOfaq
    {
        clsADListaOfaq listaofaq = new clsADListaOfaq();

        public DataTable InsertarListaOfaq(string xmListaOfaq, int idUsuReg)
        {
            return listaofaq.InsertarListaOfaq(xmListaOfaq, idUsuReg);
        }

        public DataTable InsertarDireccionListaOfaq(string xmDirListaOfaq, int idUsuReg)
        {
            return listaofaq.InsertarDireccionListaOfaq(xmDirListaOfaq, idUsuReg);
        }

        public DataTable ValidarListaOfaqClientes()
        {
            return listaofaq.ValidarListaOfaqClientes();
        }
    }
}
