using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using GEN.AccesoDatos;

namespace GEN.CapaNegocio
{
    public class clsCNRelacLaboral
    {
        clsADRelacLaboral objrelaclaboral = new clsADRelacLaboral();

        public clslisRelacLaboral listarRelacionLaboralActivos()
        {
            var query=from item in objrelaclaboral.listarRelacionLaboral()
                          where item.lVigente==true
                          select item;

            clslisRelacLaboral lista = new clslisRelacLaboral();
            lista.AddRange(query);
            return lista;
        }

        public clslisRelacLaboral listarRelacionLaboralTodos()
        {
            return objrelaclaboral.listarRelacionLaboral();
        }
    }
}
