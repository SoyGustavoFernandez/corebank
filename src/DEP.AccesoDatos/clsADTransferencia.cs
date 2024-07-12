using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using SolIntEls.GEN.Helper;
using System.Data;

namespace DEP.AccesoDatos
{
    
    public class clsADTransferencia
    {
        clsGENEjeSP objEjeSP = new clsGENEjeSP();
        //Lista los tipos de transferencia
        public DataTable ADListaTipoTransferencia()
        {
            return objEjeSP.EjecSP("GEN_ListarTipoTransferencia_sp");
        }
        //Lista Monto pendiente de cuentas de ahorro y crédito 
        public DataTable ADRetornaDatCuenta(int idcuenta, int idTipoTransfer, int idAgencia)
        {
            return objEjeSP.EjecSP("DEP_RetornaDatCuenta_sp",idcuenta,idTipoTransfer,idAgencia);
        }

        //Guarda Transferencia
        public DataTable ADGuardaTransferencia(int idTipoOpe, string XMLRetiro, string xmlTipPagoRet, string XMLOpeTransfer, string xmlIntervRet,
	                                            string xmlIntervOpe, string	xmlComisionOpe, string xmlComisionRet, string tXmlPlanPagoCobrado,
	                                            int idCuenta,int idUsu,int idAge,DateTime dFechaOpe,int idCanal,int idProdRet	,
	                                            string cDniCliOpe,string cNomCliOpe,string cDirCliOpe,int idCliItfRet	,int idCliItfOpe	,
                                                int idMoneda, decimal nMoraPagada, clslisDetalleAporte xDetalleAporte, clslisDetalleFondo xDetalleFondo,
	                                            bool lPagarInscripcion ,int idInscripcion  )
        {
            return objEjeSP.EjecSP("DEP_GuardarTransferencia_sp", idTipoOpe, XMLRetiro, xmlTipPagoRet, XMLOpeTransfer, xmlIntervRet,
	                                             xmlIntervOpe, 	xmlComisionOpe,  xmlComisionRet,  tXmlPlanPagoCobrado,
	                                             idCuenta, idUsu, idAge, dFechaOpe, idCanal, idProdRet	,
	                                             cDniCliOpe, cNomCliOpe, cDirCliOpe, idCliItfRet	, idCliItfOpe	,
	                                             idMoneda, nMoraPagada  , xDetalleAporte , xDetalleFondo  ,
	                                             lPagarInscripcion , idInscripcion);
        }


    }
}
