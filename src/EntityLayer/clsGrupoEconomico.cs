using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace EntityLayer
{
    public class clsGrupoEconomico
    {
        public int idGrupoEconomico { get; set; }
        public string cGrupoEconomico { get; set; }
        public int idTipoGrupoEco { get; set; }
        public int idEstado { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public clsLisCliente listaClientes { get; set; }

        public override string ToString()
        {
            return cGrupoEconomico;
        }
    }

    public class clslisGrupoEconomico:List<clsGrupoEconomico>{}


    public class clsTipoGrupoEconomico
    {
        public int idTipoGrupoEco { get; set; }
        public string cTipoGrupoEco { get; set; }
        public int idEstado { get; set; }
    }

    public class clslisTipoGrupoEconomico : List<clsTipoGrupoEconomico> { }


}