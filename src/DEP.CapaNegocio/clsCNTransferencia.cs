using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEP.AccesoDatos;
using System.Data;
using EntityLayer;
namespace DEP.CapaNegocio
{
    
    public class clsCNTransferencia
    {
        clsADTransferencia ObjTransfer = new clsADTransferencia();
        //Lista los tipos de transferencias
        public DataTable CNListaTipoTransferencia()
        {
            return ObjTransfer.ADListaTipoTransferencia();
        }
        //Lista Monto pendiente de cuentas de ahorro y crédito 
        public DataTable CNRetornaDatCuenta(int idcuenta, int idTipoTransfer, int idAgencia)
        {
            return ObjTransfer.ADRetornaDatCuenta(idcuenta, idTipoTransfer, idAgencia);
        }
        //Guardar Transferencia
        //Guarda Transferencia
        public DataTable CNGuardaTransferencia(int idTipoOpe, string XMLRetiro, string xmlTipPagoRet, string XMLOpeTransfer, string xmlIntervRet,
                                                string xmlIntervOpe, string xmlComisionOpe, string xmlComisionRet, string tXmlPlanPagoCobrado,
                                                int idCuenta, int idUsu, int idAge, DateTime dFechaOpe, int idCanal, int idProdRet,
                                                string cDniCliOpe, string cNomCliOpe, string cDirCliOpe, int idCliItfRet, int idCliItfOpe,
                                                int idMoneda, decimal nMoraPagada, clslisDetalleAporte xDetalleAporte, clslisDetalleFondo xDetalleFondo,
                                                bool lPagarInscripcion, int idInscripcion)
        {
            return ObjTransfer.ADGuardaTransferencia( idTipoOpe, XMLRetiro, xmlTipPagoRet, XMLOpeTransfer, xmlIntervRet,
                                                 xmlIntervOpe, xmlComisionOpe, xmlComisionRet, tXmlPlanPagoCobrado,
                                                 idCuenta, idUsu, idAge, dFechaOpe, idCanal, idProdRet,
                                                 cDniCliOpe, cNomCliOpe, cDirCliOpe, idCliItfRet, idCliItfOpe,
                                                 idMoneda, nMoraPagada, xDetalleAporte, xDetalleFondo,
                                                 lPagarInscripcion, idInscripcion);
        }
    }
}
