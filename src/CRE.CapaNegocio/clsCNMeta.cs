using CRE.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace CRE.CapaNegocio
{
    public class clsCNMeta
    {
        clsADMeta admeta = new clsADMeta();

        public DataTable CNConsultaMeta(int idAgencia, int nAnio, int nMes, int idTipoMeta, int idGrupoAsesor)
        {
            return admeta.ADConsultaMeta(idAgencia, nAnio, nMes, idTipoMeta, idGrupoAsesor);
        }
        public DataTable CNInsActMeta(int idAgencia, int nAnio, int nMes, int idTipoMeta, string xmlMeta)
        {
            return admeta.ADInsActMeta(idAgencia, nAnio, nMes, idTipoMeta, xmlMeta);
        }
        public DataTable RptMetasAsesores(DateTime dFecha,int idAgencia)
        {
            return admeta.RptMetasAsesores(dFecha, idAgencia);
        }

        public DataTable CNListaAsesorGrupoMeta(int idAgencia, int nAnio, int nMes)
        {
            return admeta.ADListaAsesorGrupoMeta(idAgencia, nAnio, nMes);
        }

        public DataTable CNInsActGrupoAsesor(string xmlGrupoAsesor, int idUsuario)
        {
            return admeta.ADInsActGrupoAsesor(xmlGrupoAsesor, idUsuario);
        }

        public DataTable CNProcesaAsignacionMetas(int nAnio, int nMes)
        {
            return admeta.ADProcesaAsignacionMetas(nAnio, nMes);
        }

        public DataTable CNListarCategoriaAsesor()
        {
            return admeta.ADListarCategoriaAsesor();
        }

        public DataTable CNActualizarCategoriaAsesor(int idCategoriaAsesor, decimal nValorMin, decimal nValorMax
                            , int nTopeTransNroCliMax, decimal nTopeTransSaldoMax, int nMinNroClientesGestion
                            , int nMaxNroClientesGestion, decimal nMontoMetaColocacion, int nNroCreditosMetaColocacion
                            , int idCategoriaPersonal
                            , Boolean lVigente)
        {
            return admeta.ADActualizarCategoriaAsesor(idCategoriaAsesor, nValorMin, nValorMax, nTopeTransNroCliMax
                , nTopeTransSaldoMax, nMinNroClientesGestion
                , nMaxNroClientesGestion, nMontoMetaColocacion, nNroCreditosMetaColocacion, idCategoriaPersonal, lVigente);
        }
        public DataTable CNListaGrupoAsesor(Boolean lTodos)
        {
            return admeta.ADListaGrupoAsesor(lTodos);
        }

        public DataTable CNListaTipoInsentivo(Boolean lTodos)
        {
            return admeta.ADListaTipoInsentivo(lTodos);
        }

        public DataTable CNGrupoMetas(int idCategoriaAsesor, int idGrupoAsesor, int idTipoMeta)
        {
            return admeta.ADGrupoMetas(idCategoriaAsesor, idGrupoAsesor, idTipoMeta);
        }

        public DataTable CNInsertarGrupoMeta(int idCategoriaAsesor, int idGrupoAsesor, int idTipoMeta, decimal nValor, Boolean lVigente)
        {
            return admeta.ADInsertarGrupoMeta(idCategoriaAsesor, idGrupoAsesor, idTipoMeta, nValor, lVigente);
        }

        public List<clsMetaCreditoCarga> CNConsultaDatosMetaActual(int idAgencia, int nMes, int nAnio, bool lSoloAsesoresNuevos = false, bool lSoloAsesoresCesados = false)
        {
            DataTable dtDatosMeta = admeta.ADConsultaDatosMetaActual(idAgencia, nMes, nAnio, lSoloAsesoresNuevos, lSoloAsesoresCesados);

            List<clsMetaCreditoCarga> lstMetaCreditoCarga = (dtDatosMeta.Rows.Count == 0) ? new List<clsMetaCreditoCarga>() : (from DataRow drMetaCreditoCarga in dtDatosMeta.Rows
                                                                                                                               select new clsMetaCreditoCarga()
                                                                                                                               {
                cDesZona                    = Convert.ToString(drMetaCreditoCarga["cDesZona"]),
                idAgencia                   = Convert.ToInt32(drMetaCreditoCarga["idAgencia"]),
                cAgenciaCarga               = Convert.ToString(drMetaCreditoCarga["cAgenciaCarga"]),
                cEstablecimientoEOBCarga    = Convert.ToString(drMetaCreditoCarga["cEstablecimientoEOBCarga"]),
                idUsuario                   = Convert.ToInt32(drMetaCreditoCarga["idUsuario"]),
                cAsesorCarga                = Convert.ToString(drMetaCreditoCarga["cAsesorCarga"]),
                cCargo                      = Convert.ToString(drMetaCreditoCarga["cCargo"]),
                idTipoMetaSaldo             = Convert.ToInt32(drMetaCreditoCarga["idTipoMetaSaldo"]),
                nMetaSaldo                  = Convert.ToDecimal(drMetaCreditoCarga["nMetaSaldo"]),
                idTipoMetaCrecimiento       = Convert.ToInt32(drMetaCreditoCarga["idTipoMetaCrecimiento"]),
                nCrecimientoClientes        = Convert.ToInt32(drMetaCreditoCarga["nCrecimientoClientes"]),
                idTipoMetaClientesNuevos    = Convert.ToInt32(drMetaCreditoCarga["idTipoMetaClientesNuevos"]),
                nClientesNuevos             = Convert.ToInt32(drMetaCreditoCarga["nClientesNuevos"]),
                idEstadoAsesor              = Convert.ToInt32(drMetaCreditoCarga["idEstadoAsesor"])
               
            }).ToList();

            return lstMetaCreditoCarga;
        }

        public DataTable CNConsultaDatosMetaActualReporte(int idAgencia, int nMes, int nAnio, bool lSoloAsesoresNuevos = false, bool lSoloAsesoresCesados = false)
        {
            return admeta.ADConsultaDatosMetaActual(idAgencia, nMes, nAnio, lSoloAsesoresNuevos, lSoloAsesoresCesados);
        }

        public DataTable CNActualizarMetasCreditosModificados(string xmlMetasCreditosModificados, int idAgencia, int nMes, int nAnio)
        {
            return admeta.ADActualizarMetasCreditosModificados(xmlMetasCreditosModificados, idAgencia, nMes, nAnio, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario);
        }
    }
}
