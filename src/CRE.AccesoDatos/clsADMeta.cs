using SolIntEls.GEN.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRE.AccesoDatos
{
    public class clsADMeta
    {
        clsGENEjeSP objEjeSp = new clsGENEjeSP();
        public DataTable ADConsultaMeta(int idAgencia, int nAnio, int nMes, int idTipoMeta, int idGrupoAsesor)
        {
            return objEjeSp.EjecSP("CRE_ConsultaMeta_sp", idAgencia, nAnio, nMes, idTipoMeta, idGrupoAsesor);            
        }

        public DataTable ADInsActMeta(int idAgencia, int nAnio, int nMes, int idTipoMeta, string xmlMeta)
        {
            return objEjeSp.EjecSP("CRE_InsUpdMeta_sp", idAgencia, nAnio, nMes, idTipoMeta, xmlMeta);
        }

        public DataTable RptMetasAsesores(DateTime dFecha, int idAgencia)
        {
            return objEjeSp.EjecSP("CRE_RptMetasAsesores_SP", dFecha, idAgencia);           
        }

        public DataTable ADListaAsesorGrupoMeta(int idAgencia, int nAnio, int nMes)
        {
            return objEjeSp.EjecSP("CRE_ListaAsesorGrupoMeta_sp", idAgencia, nAnio, nMes);
        }

        public DataTable ADInsActGrupoAsesor(string xmlGrupoAsesor, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_InsActGrupoAsesor_sp", xmlGrupoAsesor, idUsuario);
        }

        public DataTable ADProcesaAsignacionMetas(int nAnio, int nMes)
        {
            return objEjeSp.EjecSP("CRE_ProcesaAsignacionMetas_SP", nAnio, nMes);
        }

        public DataTable ADListarCategoriaAsesor()
        {
            return objEjeSp.EjecSP("CRE_ListarCategoriaAsesor_SP");
        }

        public DataTable ADActualizarCategoriaAsesor(int idCategoriaAsesor, decimal nValorMin, decimal nValorMax
                                , int nTopeTransNroCliMax, decimal nTopeTransSaldoMax, int nMinNroClientesGestion
                                , int nMaxNroClientesGestion, decimal nMontoMetaColocacion, int nNroCreditosMetaColocacion, int idCategoriaPersonal, Boolean lVigente)
        {
            return objEjeSp.EjecSP("CRE_ActualizarCategoriaAsesor_SP", idCategoriaAsesor, nValorMin, nValorMax, nTopeTransNroCliMax
                    , nTopeTransSaldoMax, nMinNroClientesGestion
                    , nMaxNroClientesGestion, nMontoMetaColocacion, nNroCreditosMetaColocacion, idCategoriaPersonal, lVigente);
        }

        public DataTable ADListaGrupoAsesor(Boolean lTodos)
        {
            return objEjeSp.EjecSP("CRE_ListaGrupoAsesor_SP", lTodos);
        }

        public DataTable ADListaTipoInsentivo(Boolean lTodos)
        {
            return objEjeSp.EjecSP("CRE_ListarTipoIncentivo_SP", lTodos);
        }

        public DataTable ADGrupoMetas(int idCategoriaAsesor, int idGrupoAsesor, int idTipoMeta)
        {
            return objEjeSp.EjecSP("CRE_GrupoMeta_SP", idCategoriaAsesor, idGrupoAsesor, idTipoMeta);
        }

        public DataTable ADInsertarGrupoMeta(int idCategoriaAsesor, int idGrupoAsesor, int idTipoMeta, decimal nValor, Boolean lVigente)
        {
            return objEjeSp.EjecSP("CRE_InsertarGrupoMeta_SP", idCategoriaAsesor, idGrupoAsesor, idTipoMeta, nValor, lVigente);
        }

        public DataTable ADConsultaDatosMetaActual(int idAgencia, int nMes, int nAnio, bool lSoloAsesoresNuevos = false, bool lSoloAsesoresCesados = false)
        {
            return objEjeSp.EjecSP("CRE_ConsultarDatosMetaActual_SP", idAgencia, nMes, nAnio, lSoloAsesoresNuevos, lSoloAsesoresCesados);
        }

        public DataTable ADActualizarMetasCreditosModificados(string xmlMetasCreditosModificados, int idAgencia, int nMes, int nAnio, DateTime dFechaSistema, int idUsuario)
        {
            return objEjeSp.EjecSP("CRE_ActualizarMetasCreditosModificados_SP", xmlMetasCreditosModificados, idAgencia, nMes, nAnio, dFechaSistema, idUsuario);
        }
    }
}
