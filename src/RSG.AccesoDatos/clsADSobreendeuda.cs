using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSG.AccesoDatos
{
    public class clsADSobreendeuda
    {
        public DataSet obtieneResultadosEvaluacion(int idCli, DateTime dFecha)
        {
            return new clsGENEjeSP().DSEjecSP("RSG_EvaluaSobreendeudamiento_SP", idCli, dFecha);
        }
        public DataTable guardaSaldosSobredeuda(int idCliente, int idUsuario, DateTime dFecha, String xmlSaldos, String xmlResultados)
        {
            return new clsGENEjeSP().EjecSP("RSG_registraSobreendeudamiento_SP", idCliente, idUsuario, dFecha, xmlSaldos, xmlResultados);
        }
        public DataTable listaSoliciCreSobredeuda(int idCliente, int idAgencia, DateTime dFechaIni, DateTime dFechaFin)
        {
            return new clsGENEjeSP().EjecSP("RSG_listaSoliCreSobredeuda_SP", idCliente, idAgencia, dFechaIni, dFechaFin);
        }
        public DataTable listaResultSoliciSobredeuda(int idCliente, int idSolicitud)
        {
            return new clsGENEjeSP().EjecSP("RSG_ListaResultEvalSoliCreSobreDeuda_SP", idCliente, idSolicitud);
        }

        public DataTable listaCliSobredeuda(int idAgencia, int idTipoPersona, String dFechaCorte, DateTime dFechaSistema)
        {
            return new clsGENEjeSP().EjecSP("RSG_obtieneCliExpuestosSobreDeuda_SP", idAgencia, idTipoPersona, dFechaCorte, dFechaSistema);
        }
        /*==========================================================================================================*/
        /*- mantenimiento de tablas     -*/
        /*==========================================================================================================*/
        public DataTable listaParamSobredeudaSolCre(int idParametro)
        {
            return new clsGENEjeSP().EjecSP("RSG_ListaParamSobredeudaSolCre_SP", idParametro);
        }
        public DataTable guardaParamSobredeudaSolCre(int idParametro, String cParametro, String cDescripcion, String cSigno, Decimal nConstanteBase, 
                                                        String cSimbolo, Boolean lVigente, int idUsu, DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("RSG_GuardaParamSobredeudaSolCre_SP", idParametro, cParametro, cDescripcion, cSigno, nConstanteBase, 
                                                                                cSimbolo, lVigente, idUsu, dFecha);
        }
        public DataTable listaParamSobredeudaCliente(int idParametro)
        {
            return new clsGENEjeSP().EjecSP("RSG_ListaParamSobreduedaClientes_SP", idParametro);
        }
        public DataTable listaRangosParamSobredeudaCliente(int idParametro)
        {
            return new clsGENEjeSP().EjecSP("RSG_ListaRangosParamSobredeuda_SP", idParametro);
        }
        public DataTable guardaParamSobredeudaCliente(int idParametro, String cParametro, String cParamAbrv, Boolean lVigente, int idUsu, DateTime dFecha, String xmlRangos)
        {
            return new clsGENEjeSP().EjecSP("RSG_GuardaParamSobredeudaCliente_SP", idParametro, cParametro, cParamAbrv, lVigente, idUsu, dFecha, xmlRangos);
        }
        public DataTable guardaCalificativoSobredeuda(int idCalificacion, String cCalificacion, Boolean lAlerta, Boolean lVigente, int idUsu, DateTime dFecha)
        {
            return new clsGENEjeSP().EjecSP("RSG_GuardaCalificativoSobredeuda_SP", idCalificacion, cCalificacion, lAlerta, lVigente, idUsu, dFecha);
        }        

        public DataTable listaCalificSobredeudaCli(int idCalificativo)
        {
            return new clsGENEjeSP().EjecSP("RSG_ListaCalificSobredeuda_SP", idCalificativo);
        }
        
    }
}


