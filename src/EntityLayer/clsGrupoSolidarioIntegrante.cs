using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsGrupoSolidarioIntegrante
    {
        public int idGrupoSolidarioIntegrante { get; set; }
        public int idGrupoSolidario { get; set; }
        public int idCli { get; set; }
        public int idGrupoSolidarioCargo { get; set; }
        public int idGrupoSolidarioCiclo { get; set; }
        public DateTime dFechaIntegracion { get; set; }
        public bool lDomicilioGrupo { get; set; }

        public string cGrupoSolidario { get; set; }
        public string cNumDocumento { get; set; }
        public string cNombreCliente { get; set; }
        public string cCargo { get; set; }
        public string cCiclo { get; set; }

        public clsGrupoSolidarioIntegrante()
        {
            this.idGrupoSolidarioIntegrante = 0;
            this.idGrupoSolidario = 0;
            this.idCli = 0;
            this.idGrupoSolidarioCargo = 0;
            this.idGrupoSolidarioCiclo = 0;
            this.dFechaIntegracion = clsVarGlobal.dFecSystem;
            this.lDomicilioGrupo = false;

            this.cGrupoSolidario = string.Empty;
            this.cNumDocumento = string.Empty;
            this.cNombreCliente = string.Empty;
            this.cCargo = string.Empty;
            this.cCiclo = string.Empty;
        }
    }

    

    public enum FormButtonAction
    {
        Editar = 1,
        Grabar = 2,
        Enviar = 3,
        Buscar = 4,
        Nuevo = 5,
        Cancelar = 7
    }
}
