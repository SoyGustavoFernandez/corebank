using SPL.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPL.CapaNegocio
{
    public class clsCNUmbralSPL
    {
        clsADUmbralSPLAFT objumbral = new clsADUmbralSPLAFT();
        public DataTable ListarUmbral(int tipo, int idTipoOperacion)
        {           
            return objumbral.listarUmbral(tipo, idTipoOperacion);
        }

        public void insertarUmbral(int idUmbral, int idAgencia, int nTipoUmbral, decimal nValor, DateTime dFechaInicio, DateTime dFechaFin, string cTipoOperaciones)
        {
            objumbral.insertarUmbral(idUmbral, idAgencia, nTipoUmbral, nValor, dFechaInicio, dFechaFin, cTipoOperaciones);
        }
        public DataTable ListarTipoOperaciones()
        {
            return objumbral.ListarTipoOperaciones();
        }
        public DataTable ListarUmbralIdAgencia(int nTipoUmbral, int idAgencia, int idTipoOperacion)
        {
            return objumbral.ListarUmbralIdAgencia(nTipoUmbral, idAgencia, idTipoOperacion);
        }
        public DataTable retornoUmbralPorId(int idUmbral)
        {
            return objumbral.retornoUmbralPorId(idUmbral);
        }
        public DataTable ListarTipoOperacionesPorIdUmbral(int idUmbral)
        { 
            return objumbral.ListarTipoOperacionesPorIdUmbral(idUmbral);
        }
        public DataTable CNValidandoUmbralExistente(int idUmbral, int nTipoUmbral, int idAgencia, DateTime dFechaInicio, DateTime dFechaFin, string cTipoOpe)
        {
            return objumbral.ADValidandoUmbralExistente(idUmbral, nTipoUmbral, idAgencia, dFechaInicio, dFechaFin, cTipoOpe);
        }
        public DataTable CNListarUmbralKardex(int idTipoUmbral, int idKardex)
        {
            return objumbral.ADListarUmbralKardex(idTipoUmbral, idKardex);
        }
        public DataTable ListarTipoOperacionesUlt()
        {
            return objumbral.ListarTipoOperacionesUlt();
        }
        public DataTable ListarTipoOperacionesPorIdUmbralUlt(int idUmbral)
        {
            return objumbral.ListarTipoOperacionesPorIdUmbralUlt(idUmbral);
        }
    }
}
