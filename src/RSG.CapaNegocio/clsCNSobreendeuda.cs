using RSG.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSG.CapaNegocio
{
    public class clsCNSobreendeuda
    {
        clsADSobreendeuda adSobreendeuda = new clsADSobreendeuda();
        public DataSet obtieneResultadosEvaluacion(int idCli, DateTime dFecha)
        {
            return adSobreendeuda.obtieneResultadosEvaluacion(idCli, dFecha);
        }
        public DataTable guardaSaldosSobredeuda(int idCliente, int idUsuario, DateTime dFecha, String xmlSaldos, String xmlResultados)
        {
            return adSobreendeuda.guardaSaldosSobredeuda( idCliente, idUsuario, dFecha, xmlSaldos, xmlResultados);
        }
        public DataTable listaSoliciCreSobredeuda(int idCliente, int idAgencia, DateTime dFechaIni, DateTime dFechaFin)
        {
            return adSobreendeuda.listaSoliciCreSobredeuda(idCliente, idAgencia, dFechaIni, dFechaFin);
        }
        public DataTable listaResultSoliciSobredeuda(int idCliente, int idSolicitud)
        {
            return adSobreendeuda.listaResultSoliciSobredeuda(idCliente, idSolicitud);
        }

        public DataTable listaCliSobredeuda(int idAgencia, int idTipoPersona, String dFechaCorte, DateTime dFechaSistema)
        {
            return adSobreendeuda.listaCliSobredeuda(idAgencia, idTipoPersona, dFechaCorte, dFechaSistema);
        }
        /*==========================================================================================================*/
        /*- mantenimiento de tablas     -*/
        /*==========================================================================================================*/
        public DataTable listaParamSobredeudaSolCre(int idParametro)
        {
            return adSobreendeuda.listaParamSobredeudaSolCre(idParametro);
        }
        public DataTable guardaParamSobredeudaSolCre(int idParametro, String cParametro, String cDescripcion, String cSigno, Decimal nConstanteBase,
                                                        String cSimbolo, Boolean lVigente, int idUsu, DateTime dFecha)
        {
            return adSobreendeuda.guardaParamSobredeudaSolCre(idParametro, cParametro, cDescripcion, cSigno, nConstanteBase,
                                                                                cSimbolo, lVigente, idUsu, dFecha);
        }
        public DataTable listaParamSobredeudaCliente(int idParametro)
        {
            return adSobreendeuda.listaParamSobredeudaCliente( idParametro);
        }
        public DataTable listaRangosParamSobredeudaCliente(int idParametro)
        {
            return adSobreendeuda.listaRangosParamSobredeudaCliente( idParametro);
        }
        public DataTable guardaParamSobredeudaCliente(int idParametro, String cParametro, String cParamAbrv, Boolean lVigente, int idUsu, DateTime dFecha, String xmlRangos)
        {
            return adSobreendeuda.guardaParamSobredeudaCliente(idParametro, cParametro, cParamAbrv, lVigente, idUsu, dFecha, xmlRangos);
        }
        public DataTable guardaCalificativoSobredeuda(int idCalificacion, String cCalificacion, Boolean lAlerta, Boolean lVigente, int idUsu, DateTime dFecha)
        {
            return adSobreendeuda.guardaCalificativoSobredeuda(idCalificacion, cCalificacion, lAlerta, lVigente, idUsu, dFecha);
        } 

        public DataTable listaCalificSobredeudaCli(int idCalificativo)
        {
            return adSobreendeuda.listaCalificSobredeudaCli(idCalificativo);
        }
    }
}
