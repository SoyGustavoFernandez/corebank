using LOG.Rendiciones.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.Funciones;
using WCFLogistica.EntityLayer;
using System.Data;
using GEN.CapaNegocio;

namespace LOG.Rendiciones.CapaNegocio
{
    public class clsCNEntregasRendir
    {
        #region propiedades privadas
        private clsADEntregasRendir adEntregasRendir;
        #endregion

        #region constructores
        public clsCNEntregasRendir()
        {
            this.adEntregasRendir = new clsADEntregasRendir();
        }
        #endregion

        #region métodos públicos        
        public clsWCFRespuesta cambiarEstadoEntrega(int idEntrega, int idEtapa, int idEstado, int idUsuario, string cComentario)
        {
            DataTable dtEstadoEntrega = this.adEntregasRendir.cambiarEstadoEntrega(idEntrega, idEtapa, idEstado, idUsuario, cComentario);
            return dtEstadoEntrega.Rows[0].ToObject<clsWCFRespuesta>();
        }

        public IList<clsEntregaRendir> obtenerResumenEntregas(int idUsuario, int idTipoEntrega)
        {
            DataTable dtResumenEntregas = this.adEntregasRendir.obtenerResumenEntregas(idUsuario, idTipoEntrega);
            return dtResumenEntregas.SoftToList<clsEntregaRendir>();
        }

        #region etapa - registro
        public IList<clsEntregaRendir> obtenerEntregasRendir(int idUsuario, int idTipo, int idEstado, int idEntrega)            
        {
            DataTable dtEntregasRendir = this.adEntregasRendir.obtenerEntregasRendir(idUsuario, idTipo, idEstado, idEntrega);
            return dtEntregasRendir.SoftToList<clsEntregaRendir>();
        }

        public clsEntregaRendir registrarEntregaRendir(clsEntregaRendir objEntregaRendir)
        {
            DataTable dtEntregaRendir = this.adEntregasRendir.registrarEntregaRendir(
                objEntregaRendir.idEntrega,
		        objEntregaRendir.idTipoEntrega,
		        objEntregaRendir.idUsuario,
		        objEntregaRendir.idPerfil,
                objEntregaRendir.idAgencia,
		        objEntregaRendir.idArea,		        
		        objEntregaRendir.idMoneda,
		        objEntregaRendir.nMonto,
		        objEntregaRendir.cMotivo,
		        objEntregaRendir.lVigente
            );
            return dtEntregaRendir.Rows[0].ToObject<clsEntregaRendir>();
        }

        public clsWCFRespuesta solicitarEntregaRendir(int idEntrega, int idUsuario)
        {
            clsWCFRespuesta clsWCFRespuesta = new clsWCFRespuesta();
            try
            {
                DataTable dtEntregaRendir = this.adEntregasRendir.solicitarEntregaRendir(idEntrega, idUsuario);
                return dtEntregaRendir.Rows[0].ToObject<clsWCFRespuesta>();
            }
            catch (Exception e)
            {
                clsWCFRespuesta.cError = e.ToString();
            }
            return clsWCFRespuesta;
        }

        public clsArchivoEntrega obtenerArchivoEntrega(int idArchivo)
        {
            DataTable dtArchivoEntrega = this.adEntregasRendir.obtenerArchivoEntrega(idArchivo);
            if (dtArchivoEntrega.Rows.Count == 1)
                return dtArchivoEntrega.Rows[0].ToObject<clsArchivoEntrega>();
            return null;
        }

        public IList<clsArchivoEntrega> obtenerDatosArchivosEntrega(int idEntrega)
        {
            DataTable dtDatosArchivosEntrega = this.adEntregasRendir.obtenerDatosArchivosEntrega(idEntrega);
            return dtDatosArchivosEntrega.SoftToList<clsArchivoEntrega>();
        }

        public clsWCFRespuesta registrarArchivoEntrega(clsArchivoEntrega objArchivoEntrega)
        {
            clsWCFRespuesta clsWCFRespuesta = new clsWCFRespuesta();
            try
            {
                DataTable dtArchivoEntrega = this.adEntregasRendir.registrarArchivoEntrega(
                    objArchivoEntrega.idArchivo,
                    objArchivoEntrega.idEntrega,
                    objArchivoEntrega.cNombreArchivo,
                    objArchivoEntrega.cArchivoBase64,
                    objArchivoEntrega.cTipo,
                    objArchivoEntrega.cExtension,
                    objArchivoEntrega.lVigente
                );
                clsWCFRespuesta = dtArchivoEntrega.Rows[0].ToObject<clsWCFRespuesta>();
            }
            catch (Exception e)
            {
                clsWCFRespuesta.cRespuesta = e.ToString();
            }
            return clsWCFRespuesta;
        }

        public clsWCFRespuesta registrarArchivosEntrega(List<clsArchivoEntrega> lstArchivoEntrega)
        {
            clsWCFRespuesta clsWCFRespuesta = new clsWCFRespuesta();
            try
            {
                DataTable dtArchivoEntrega;
                foreach (clsArchivoEntrega objArchivoEntrega in lstArchivoEntrega)
                {
                    dtArchivoEntrega = this.adEntregasRendir.registrarArchivoEntrega(
                    objArchivoEntrega.idArchivo,
                    objArchivoEntrega.idEntrega,
                    objArchivoEntrega.cNombreArchivo,
                    objArchivoEntrega.cArchivoBase64,
                    objArchivoEntrega.cTipo,
                    objArchivoEntrega.cExtension,
                    objArchivoEntrega.lVigente
                    );
                    clsWCFRespuesta = dtArchivoEntrega.Rows[0].ToObject<clsWCFRespuesta>();
                }                
            }
            catch (Exception e)
            {
                clsWCFRespuesta.cRespuesta = e.ToString();
            }
            return clsWCFRespuesta;
        }
        #endregion

        #region etapa - aprobación de entrega
        public IList<clsAprobacionEntrega> obtenerEntregaAprobaciones(int idEntrega)
        {
            DataTable dtEntregaAprobaciones = this.adEntregasRendir.obtenerEntregaAprobaciones(idEntrega);
            return dtEntregaAprobaciones.SoftToList<clsAprobacionEntrega>();
        }
        #endregion

        #region etapa - desembolso
        public clsDesembolsoEntrega obtenerDesembolsoEntrega(int idEntrega)
        {
            DataTable dtDesembolsoEntrega = this.adEntregasRendir.obtenerDesembolsoEntrega(idEntrega);
            return dtDesembolsoEntrega.Rows[0].ToObject<clsDesembolsoEntrega>();
        }        
        #endregion

        #region etapa - rendición
        public clsRendicionEntrega obtenerRendicionEntrega(int idEntrega)
        {
            DataTable dtRendicionEntrega = this.adEntregasRendir.obtenerRendicionEntrega(idEntrega);
            return dtRendicionEntrega.Rows[0].ToObject<clsRendicionEntrega>();
        }

        public IList<clsComprobantePago> obtenerComprobantesPago(int idEntrega, int idComprobantePago)
        {
            DataTable dtComprobantesPago = this.adEntregasRendir.obtenerComprobantesPago(idEntrega, idComprobantePago);
            return dtComprobantesPago.SoftToList<clsComprobantePago>();
        }

        public IList<clsDetalleComprobante> obtenerDetallesComprobante(int idEntrega, int idComprobantePago)
        {
            DataTable dtDetallesComprobante = this.adEntregasRendir.obtenerDetallesComprobante(idEntrega, idComprobantePago);
            return dtDetallesComprobante.SoftToList<clsDetalleComprobante>();
        }

        public clsComprobantePago registrarComprobantePago(int idEntrega, clsComprobantePago objComprobantePago, List<clsDetalleComprobante> lstDetalleComprobante)
        {
            try
            {
                /*Lista a DataTable */
                List<clsComprobantePago> lstComprobantePago = new List<clsComprobantePago>();
                lstComprobantePago.Add(objComprobantePago);

                DataTable dtComprobantePago = DataTableToList.CreateDataTable<clsComprobantePago>(lstComprobantePago);
                DataTable dtDetalleComprobante = DataTableToList.CreateDataTable<clsDetalleComprobante>(lstDetalleComprobante);

                /*Convertir a XML*/
                DataSet dsComprobantePago = new DataSet("dsComprPago");
                DataSet dsDetalleComprobante = new DataSet("dsDetComprPago");

                dtComprobantePago.TableName = "dtComprPago";
                dtDetalleComprobante.TableName = "dtDetComprPago";

                dsComprobantePago.Tables.Add(dtComprobantePago);
                dsDetalleComprobante.Tables.Add(dtDetalleComprobante);

                string xmlComprobantePago = clsCNFormatoXML.EncodingXML(dsComprobantePago.GetXml());
                string xmlDetalleComprobante = clsCNFormatoXML.EncodingXML(dsDetalleComprobante.GetXml());

                dsComprobantePago.Tables.Clear();
                dsDetalleComprobante.Tables.Clear();

                DataTable dtResComprobantePago = this.adEntregasRendir.registrarComprobantePago(xmlComprobantePago, xmlDetalleComprobante, idEntrega);
                return dtResComprobantePago.Rows[0].ToObject<clsComprobantePago>();
            }
            catch (Exception e)
            {
                clsComprobantePago objResComprobantePago = new clsComprobantePago();
                objResComprobantePago.idMsje = 1;
                objResComprobantePago.cMsje = e.Message;
                return objResComprobantePago;
            }            
        }

        public clsArchivoComprobante obtenerArchivoComprobante(int idComprobantePago)
        {
            DataTable dtArchivoComprobante = this.adEntregasRendir.obtenerArchivoComprobante(idComprobantePago);
            if (dtArchivoComprobante.Rows.Count == 0)
                return null;
            return dtArchivoComprobante.Rows[0].ToObject<clsArchivoComprobante>();
        }

        public  clsWCFRespuesta registrarArchivoComprobante(clsArchivoComprobante objArchivoComprobante)
        {
            DataTable dtArchivoComprobante = this.adEntregasRendir.registrarArchivoComprobante(
                objArchivoComprobante.idComprobantePago,
                objArchivoComprobante.cNombreArchivo,                                
                objArchivoComprobante.cArchivoBase64,
                objArchivoComprobante.cTipo,
                objArchivoComprobante.cExtension,
                objArchivoComprobante.lVigente
            );
            return dtArchivoComprobante.Rows[0].ToObject<clsWCFRespuesta>();
        }

        public clsRendicionEntrega enviarRendicionEntrega(clsRendicionEntrega objRendicionEntrega)
        {
            DataTable dtRendicionEntrega = this.adEntregasRendir.enviarRendicionEntrega(
                objRendicionEntrega.idEntrega,
                objRendicionEntrega.nMontoRendido,
                objRendicionEntrega.nMontoFavor,
                objRendicionEntrega.nMontoSobrante,
                objRendicionEntrega.idUsuario,
                false
            );
            return dtRendicionEntrega.Rows[0].ToObject<clsRendicionEntrega>();
        }

        public clsRendicionEntrega actualizarRendicionEntrega(clsRendicionEntrega objRendicionEntrega)
        {
            DataTable dtRendicionEntrega = this.adEntregasRendir.actualizarRendicionEntrega(
                objRendicionEntrega.idEntrega,
                objRendicionEntrega.nMontoRendido,
                objRendicionEntrega.nMontoFavor,
                objRendicionEntrega.nMontoSobrante,
                objRendicionEntrega.idUsuario,
                true
            );
            return dtRendicionEntrega.Rows[0].ToObject<clsRendicionEntrega>();
        }

        public IList<clsRecibo> obtenerRecibos(int idEntrega, int idReciboRendicion)
        {
            DataTable dtRecibos = this.adEntregasRendir.obtenerRecibos(idEntrega, idReciboRendicion);
            return dtRecibos.SoftToList<clsRecibo>();
        }

        public clsWCFRespuesta registrarRecibo(clsRecibo objRecibo)
        {
            DataTable dtRecibo = this.adEntregasRendir.registrarRecibo(
                objRecibo.idReciboRendicion,
                objRecibo.idEntrega,
                objRecibo.idTipRecibo,
                objRecibo.idConcepto,
                objRecibo.idMoneda,
                objRecibo.nMonto,
                objRecibo.cSustento,
                objRecibo.idUsuario,
                objRecibo.lVigente                
            );
            return dtRecibo.Rows[0].ToObject<clsWCFRespuesta>();
        }

        public clsProveedor registrarProveedor(clsProveedor objProveedor)
        {
            DataTable dtProveedor = this.adEntregasRendir.registrarProveedor(
                objProveedor.idTipoPersona,
                objProveedor.cNombre,
                objProveedor.cApellidoPaterno,
                objProveedor.cApellidoMaterno,
                objProveedor.cRuc,
                objProveedor.cDni,
                objProveedor.cDireccion,
                objProveedor.idActivEco,
                objProveedor.idUsuario,
                objProveedor.idAgenciaReg
            );
            return dtProveedor.Rows[0].ToObject<clsProveedor>();
        }
        #endregion

        #region etapa - aprobación de rendición
        public IList<clsAprobacionRendicion> obtenerRendicionAprobaciones(int idEntrega)
        {
            DataTable dtAprobacionRendicion = this.adEntregasRendir.obtenerRendicionAprobaciones(idEntrega);
            return dtAprobacionRendicion.SoftToList<clsAprobacionRendicion>();
        }
        #endregion        

        #region etapa - rendido
        public clsRendidoEntrega obtenerRendidoEntrega(int idEntrega)
        {
            DataTable dtRendidoEntrega = this.adEntregasRendir.obtenerRendidoEntrega(idEntrega);
            if (dtRendidoEntrega.Rows.Count == 1)
                return dtRendidoEntrega.Rows[0].ToObject<clsRendidoEntrega>();
            return null;
        }
        #endregion
        #endregion
    }
}
