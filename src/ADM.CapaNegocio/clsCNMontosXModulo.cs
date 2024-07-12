using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ADM.AccesoDatos;

namespace ADM.CapaNegocio
{
    public class clsCNMontosXModulo
    {
        clsADMontosXModulo ListaMontos = new clsADMontosXModulo();
        public DataTable ListarMontos(int idModulo)
        {
            return ListaMontos.ListarMontos(idModulo);
        }

        public void ActualizarMontos(string XMLMontos, int idMod,  int idUsuario)
        {
            ListaMontos.ActualizarMontos(XMLMontos, idMod,   idUsuario);
        }
        public DataTable UsoMontos(int idMonto)
        {
            return ListaMontos.UsoMontos(idMonto);
        }
    }
}
