using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRE.AccesoDatos;
using EntityLayer;
using GEN.Funciones;

namespace CRE.CapaNegocio
{
    public class clsCNCargaArchivo
    {
        clsADCargaArchivo objGrupo = new clsADCargaArchivo();//Falta implementar

        public DataTable CNListarConfiguracionArchivo(int idOperacion, int idTipEvalCred, int idDescTipoDoc)
        {
            return objGrupo.ADListarConfiguracionArchivo(idOperacion, idTipEvalCred, idDescTipoDoc);
        }

        public DataTable CNGuardarConfiguracion(int idOperacion, int idTipEvalCred, int idDescTipoDoc, string cConfiguracionXml)
        {
            return objGrupo.ADGuardarConfiguracion(idOperacion, idTipEvalCred, idDescTipoDoc, cConfiguracionXml);
        }

        public DataTable CNObtenerArchivosObligatoriosCargados(int idSolicitud){
            return objGrupo.ADObtenerArchivosObligatoriosCargados(idSolicitud);
        }

        public DataTable CNGuardarNuevoArchivo(int idDescTipoDoc, string dtArchivosXml)
        {
            return objGrupo.ADGuardarNuevoArchivo(idDescTipoDoc, dtArchivosXml);
        }

        public DataTable controlDpsCargados(int idSolicitud)
        {
            return this.objGrupo.ADControlDpsCargados(idSolicitud);
        }

        public DataTable CNObtenerParametros()
        {
            return this.objGrupo.ADObtenerParametros();
        }

        public DataTable CNGuardarParametros(decimal nMontoExposicion, decimal nMontoExposicionJuridica, int idUsuario, DateTime dFechaSistema)
        {
            return this.objGrupo.ADGuardarParametros(nMontoExposicion, nMontoExposicionJuridica, idUsuario, dFechaSistema);
        }

        public List<clsMotivoVinculacionArchivo> CNObtenerMotivoVinculacionArchivo()
        {
            DataTable dtMotivoVinculacion = this.objGrupo.ADObtenerMotivoVinculacionArchivo();
            List<clsMotivoVinculacionArchivo> lstMotivoVinculacionArchivo = (dtMotivoVinculacion.Rows.Count > 0) ? dtMotivoVinculacion.ToList<clsMotivoVinculacionArchivo>() as List<clsMotivoVinculacionArchivo> : new List<clsMotivoVinculacionArchivo>();
            return lstMotivoVinculacionArchivo;
        }

        public DataTable CNRegistrarSustentoVinculacionArchivo(string xmlSustentoVinculacionArchivo, int idUsuario, DateTime dFechaSistema)
        {
            return this.objGrupo.ADRegistrarSustentoVinculacionArchivo(xmlSustentoVinculacionArchivo, idUsuario, dFechaSistema);
        }

        public DataTable CNVerificarCargaArchivoSolicitud(int idSolicitud, int idTipoArchivo, int idDescTipoDoc)
        {
            return this.objGrupo.ADVerificarCargaArchivoSolicitud(idSolicitud, idTipoArchivo, idDescTipoDoc);
        }

        public List<int> CNObtenerListaSustentoTipoArchivo()
        {
            DataTable dtResultado = this.objGrupo.ADObtenerListaSustentoTipoArchivo();
            List<int> lstTipoArchivo = (dtResultado.Rows.Count > 0) ? dtResultado.AsEnumerable().Select(item => Convert.ToInt32(item["Items"])).ToList() :  new List<int>();

            return lstTipoArchivo;
        }
        public DataTable CNVerificarSustentoVinculacionArchivo(int idSolicitud, int idTipoArchivo)
        {
            return this.objGrupo.ADVerificarSustentoVinculacionArchivo(idSolicitud, idTipoArchivo);
        }
        public DataTable CNVerificarCargaPagareCredito(int idSolicitud)
        {
            return this.objGrupo.ADVerificarCargaPagareCredito(idSolicitud);
        }
        public DataTable CNVerificarVinculacionPagare(int idSolicitud)
        {
            return this.objGrupo.ADVerificarVinculacionPagare(idSolicitud);
        }
        public List<DataTable> CNParametrosConfiguracionCargaArchivo()
        {
            DataSet dsRespuesta = this.objGrupo.ADParametrosConfiguracionCargaArchivo();

            DataTable dtPregunta = dsRespuesta.Tables[0];
            DataTable dtPregunta2 = dsRespuesta.Tables[1];
            DataTable dtPregunta3 = dsRespuesta.Tables[2];
            DataTable dtPregunta4 = dsRespuesta.Tables[3];
            DataTable dtPregunta5 = dsRespuesta.Tables[4];
            List<DataTable> lista = new List<DataTable>();
            lista.Add(dtPregunta);
            lista.Add(dtPregunta2);
            lista.Add(dtPregunta3);
            lista.Add(dtPregunta4);
            lista.Add(dtPregunta5);
            return lista;
        }
        public clsDBResp GrabarNuevaTipoDocumento(clsTipoArchivoEscaneado tipoDocumento)
        {
            return objGrupo.GrabarNuevaTipoDocumento(tipoDocumento);
        }
        public clsDBResp CNEliminarTipoDocumento(clsTipoArchivoEscaneado tipoDocumento)
        {
            return objGrupo.ADEliminarTipoArchivo(tipoDocumento);
        }

        public clsDBResp EliminarTipoArchivo(clsTipoArchivoEscaneado tipoDocumento)
        {
            return objGrupo.GrabarNuevaTipoDocumento(tipoDocumento);
        }
        public clsDBResp ActualizarConfiguracionTipoArchivo(clsListaTipoArchivoEscaneado listaTipoDocumento)
        {
            return objGrupo.GrabarOrdenTipoDocumento(listaTipoDocumento);
        }
        public DataTable CNListarConfiguracionArchivoxIdTipoArchivo(int idTipoArchivo)
        {
            return objGrupo.ADListarConfiguracionArchivo(idTipoArchivo);
        }
        public clsDBResp CNGuardarConfiguracion2(string cConfiguracionXml, int idUsuReg, DateTime dFecReg, int? idUsuAct, DateTime? dFecAct)
        {
            return objGrupo.ADGuardarConfiguracion(cConfiguracionXml, idUsuReg, dFecReg, idUsuAct,  dFecAct);
        }

        public clsDBResp CNGuardarConfigMonto(clsConfigDocxMonto datasel, int idUsuReg, DateTime dFecReg, int? idUsuAct, DateTime? dFecAct)
        {
            return objGrupo.ADGuardarConfigMonto(datasel.GetXml(), idUsuReg, dFecReg, idUsuAct, dFecAct);
        }
         
        public clsListaConfiguracionTipoArchivoEscaneado CNListarConfiguracionArchivo(int idTipoArchivo)
        {
            clsListaConfiguracionTipoArchivoEscaneado listaConfiguracionDocumento = new clsListaConfiguracionTipoArchivoEscaneado();
            var dt = objGrupo.ADListarConfiguracionArchivo(idTipoArchivo);
            var lista = (from DataRow dr in dt.Rows
                         select new clsConfiguracionTipoArchivoEscaneado()
                         {
                             idTipoOperacion = Convert.ToInt32(dr["idTipoOperacion"]),
                             cTipoOperacion = dr["cTipoOperacion"].ToString(), 
                             idTipoCredito = Convert.ToInt32(dr["idTipoCredito"]),
                             cTipoCredito = dr["cTipoCredito"].ToString(),
                             idSubProducto = Convert.ToInt32(dr["idSubProducto"]),
                             cSubProducto = dr["cSubProducto"].ToString(), 
                             idDestinoCredito = Convert.ToInt32(dr["idDestinoCredito"]),
                             cDestinoCredito = dr["cDestinoCredito"].ToString(),
                             idRangoMonto = Convert.ToInt32(dr["idRangoMonto"]),
                             cRangoMonto = dr["cRangoMonto"].ToString(),
                             idTipoPersona = Convert.ToInt32(dr["idTipoPersona"]),
                             cTipoPersona = dr["cTipoPersona"].ToString(),
                             idTipoArchivo = Convert.ToInt32(dr["idTipoArchivoEsc"]),
                             cTipoArchivo = dr["cTipoArchivo"].ToString(),
                             lVisible = Convert.ToBoolean(dr["lVisible"]),
                             lObligatorio = Convert.ToBoolean(dr["lObligatorio"])
                         }).ToList();
            foreach (var item in lista)
            {
                listaConfiguracionDocumento.Add(item);

            }
            return listaConfiguracionDocumento; 
        }
        public clsListaTipoArchivoEscaneado CNListarTipoArchivo(int idOperacion, int idTipEvalCred, int idDescTipoDoc)
        {
            clsListaTipoArchivoEscaneado listaDocumento = new clsListaTipoArchivoEscaneado();

             var dt = objGrupo.ADListarTipoArchivoConfigurado(idOperacion, idTipEvalCred, idDescTipoDoc);
             var lista = (from DataRow dr in dt.Rows
                          select new clsTipoArchivoEscaneado()
                          {

                              idTipoArchivo = Convert.ToInt32(dr["idTipoArchivo"]),
                              cTipoArchivo = dr["cTipoArchivo"].ToString(),
                              nOrden = Convert.ToInt32(dr["nOrden"].ToString()), 
                              idGrupoArchivo = Convert.ToInt32(dr["idGrupoArchivo"].ToString()),
                              dFechaVigencia =Convert.ToBoolean(dr["lConFechaVigencia"]) ? (DateTime?)dr["dFechaVigencia"] : null,
                              lConFechaVigencia = Convert.ToBoolean(dr["lConFechaVigencia"]),
                              lIndefinido = Convert.ToBoolean(dr["lIndefinido"]),
                              idTipArcOrigen = Convert.ToInt32(dr["idTipArcOrigen"]),
                              cTipArcOrigen = dr["cTipArcOrigen"].ToString(),
                              idUsuReg = Convert.ToInt32(dr["idUsuReg"]),
                              dFecRegistro =  Convert.ToDateTime(dr["dFecRegistro"])

                          }).ToList();
             foreach (var item in lista)
             {
                 listaDocumento.Add(item);

             }
            return listaDocumento;
        }
        public clsListaTipoArchivoEscaneado CNListarTipoArchivoGeneral()
        {
            clsListaTipoArchivoEscaneado listaDocumento = new clsListaTipoArchivoEscaneado();

            var dt = objGrupo.ADListarTipoArchivoConfiguradoGeneral();
            var lista = (from DataRow dr in dt.Rows
                         select new clsTipoArchivoEscaneado()
                         {

                             idTipoArchivo = Convert.ToInt32(dr["idTipoArchivo"]),
                             cTipoArchivo = dr["cTipoArchivo"].ToString(),
                             nOrden = Convert.ToInt32(dr["nOrden"].ToString()),
                             idGrupoArchivo = Convert.ToInt32(dr["idGrupoArchivo"].ToString()),
                             dFechaVigencia = Convert.ToBoolean(dr["lConFechaVigencia"]) ? (DateTime?)dr["dFechaVigencia"] : null,
                             lConFechaVigencia = Convert.ToBoolean(dr["lConFechaVigencia"]),
                             lIndefinido = Convert.ToBoolean(dr["lIndefinido"]),
                             idTipArcOrigen = Convert.ToInt32(dr["idTipArcOrigen"]),
                             cTipArcOrigen = dr["cTipArcOrigen"].ToString(),
                             idUsuReg = Convert.ToInt32(dr["idUsuReg"]),
                             dFecRegistro = Convert.ToDateTime(dr["dFecRegistro"])

                         }).ToList();
            foreach (var item in lista)
            {
                listaDocumento.Add(item);

            }
            return listaDocumento;
        }
    }
}
