using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ADM.AccesoDatos;
namespace ADM.CapaNegocio
{
    public class clsCNPlazosXModulo
    {
        clsADPlazosXModulo ListaPlazos = new clsADPlazosXModulo();
        public DataTable ListarPlazos(int idModulo)
        {
            return ListaPlazos.ListarPlazos(idModulo);
        }

        public void ActualizarPlazos(string XMLPlazos, int idMod, int idUsuario)
        {
            ListaPlazos.ActualizarPlazos(XMLPlazos, idMod, idUsuario);
        }
        public DataTable UsoPlazos(int idMonto)
        {
            return ListaPlazos.UsoPlazos(idMonto);
        }
    }
}
