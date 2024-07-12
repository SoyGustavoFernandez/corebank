using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLI.AccesoDatos;
using EntityLayer;
using System.Data;

namespace CLI.CapaNegocio
{
    public class clsCNAporte
    {
        clsADAporte adaporte = new clsADAporte();

        public clsAporte retornardatosaporte(int idAporte)
        {
            return adaporte.retornardatosaporte(idAporte);
        }

        public clslisDetalleAporte listardetalleaporte(int idAporte)
        {
            return adaporte.listardetalleaporte(idAporte);
        }

        public DataTable RegistraExtornoDevolucAportes(int idKar, int pidCuenta, int idUsuario, int nIdAgencia, DateTime dFecSystem, Decimal nMontoOpe, int idTipOpe, int pidTipPago, bool lModificaSaldoLinea, int idTipoTransac, int idMon)
        {
            return adaporte.RegistraExtornoDevolucAportes(idKar, pidCuenta, idUsuario, nIdAgencia, dFecSystem, nMontoOpe, idTipOpe, pidTipPago, lModificaSaldoLinea, idTipoTransac, idMon);
        }

        public DataTable RegistraExtornoPagoAportes(int idKar, int pidPago, int idUsuario, int nIdAgencia, DateTime dFecSystem, Decimal nMontoOpe, int idTipOpe, int pidTipPago, bool lModificaSaldoLinea, int idTipoTransac, int idMon)
        {
            return adaporte.RegistraExtornoPagoAportes(idKar, pidPago, idUsuario, nIdAgencia, dFecSystem, nMontoOpe, idTipOpe, pidTipPago, lModificaSaldoLinea, idTipoTransac, idMon);
        }

        public DataTable retornarDatosOpeApoFon(int idKardex)
        {
            return adaporte.retornarDatosOpeApoFon(idKardex);
        }
    }
}
