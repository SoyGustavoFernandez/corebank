using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOG.AccesoDatos;
using EntityLayer;
using System.Data;

namespace LOG.CapaNegocio
{
    public class clsCNNotaEntrada
    {
        private clsADNotaEntrada objADNotaEntrada = new clsADNotaEntrada();

        public List<clsNotaEntrada> ListaNotasEntradaAlmacen(int idAmacen, DateTime dFecIni, DateTime dFecFin)
        {
            return objADNotaEntrada.ListaNotasEntradaAlmacen(idAmacen, dFecIni, dFecFin);
        }

        public List<clsNotaEntrada> ListaNotasEntradaAgencia(int idAgencia, DateTime dFecIni, DateTime dFecFin)
        {
            return objADNotaEntrada.ListaNotasEntradaAgencia(idAgencia, dFecIni, dFecFin);
        }

        public List<clsNotaEntrada> ListaNotasEntradaxOrdenCompra(int idOrden)
        {
            return objADNotaEntrada.ListaNotasEntradaxOrdenCompra(idOrden);
        }

        public List<clsNotaEntrada> ListaNotasEntradaxMovimiento(int idMovimiento, int idTipIngNotaEntrada)
        {
            return objADNotaEntrada.ListaNotasEntradaxMovimiento(idMovimiento, idTipIngNotaEntrada);
        }

        public List<clsDetalleNotaEntrada> ListDetalleNotaEntrada(int idNotaEntrada)
        {
            return objADNotaEntrada.ListDetalleNotaEntrada(idNotaEntrada);
        }

        public DataTable ListarTipoIngresoNotaEntrada()
        {
            return objADNotaEntrada.ListarTipoIngresoNotaEntrada();
        }

        public clsDBResp InsertarActualizarNotaEntrada(clsNotaEntrada objNotaEntrada)
        {
            return objADNotaEntrada.InsertarActualizarNotaEntrada(objNotaEntrada);
        }

        public clsDBResp ExtornarNotaEntrada(int idNotaEntrada, DateTime dFecExtorno, int idUsuExtorno)
        {
            return objADNotaEntrada.ExtornarNotaEntrada(idNotaEntrada, dFecExtorno, idUsuExtorno);
        }
    }
}
