using RCP.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.CapaNegocio
{
    public class clsCNConfigMetas
    {
        clsADConfigMetas adConfigMetas = new clsADConfigMetas();

        public DataTable Listar(int idUsuario, bool lTodasAgencias, string cListaAgencias, int idTramo, int idVariable, string cPeriodo, int idPerfil)
        {
            return adConfigMetas.Listar(idUsuario, lTodasAgencias, cListaAgencias, idTramo, idVariable, cPeriodo, idPerfil);
        }

        public DataTable agregarModificar(int idUsuario, string cListaAgencias, int idTramo, string cListaPeriodos, int idVariableRecuperacion,
                                        decimal nMeta, decimal nMinMetaComision, decimal nComision, decimal nMetaBono, decimal nBono, int idPerfil,
                                        int idUsuRegMod, DateTime dFecSis)
        {
            return adConfigMetas.agregarModificar(idUsuario, cListaAgencias, idTramo, cListaPeriodos, idVariableRecuperacion,
                                                    nMeta, nMinMetaComision, nComision, nMetaBono, nBono, idPerfil,
                                                    idUsuRegMod, dFecSis);
        }
    }
}
