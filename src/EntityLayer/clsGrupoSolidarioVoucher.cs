using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsGrupoSolidarioVoucher
    {
        public int idGrupoSolidarioVoucher { get; set; }
        public int idTipoOperacion { get; set; }
        public int idMotivoOperacion { get; set; }
        public int idGrupoSolidario { get; set; }
        public int idSolicitudCredGrupoSol { get; set; }
        public int nIntegrantes { get; set; }
        public decimal nMonto { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public DateTime dFechaHoraRegistro { get; set; }
        public int idUsuarioRegistra { get; set; }

        public clsGrupoSolidarioVoucher()
        {
            this.idGrupoSolidarioVoucher = 0;
            this.idTipoOperacion = 0;
            this.idMotivoOperacion = 0;
            this.idGrupoSolidario = 0;
            this.idSolicitudCredGrupoSol = 0;
            this.nIntegrantes = 0;
            this.nMonto = decimal.Zero;
            this.dFechaRegistro = clsVarGlobal.dFecSystem;
            this.dFechaHoraRegistro = clsVarGlobal.dFecSystem;
            this.idUsuarioRegistra = 0;
        }
    }
}
