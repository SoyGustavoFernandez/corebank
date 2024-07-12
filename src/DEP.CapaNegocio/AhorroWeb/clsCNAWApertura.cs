using DEP.AccesoDatos.AhorroWeb;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.Funciones;

namespace DEP.CapaNegocio.AhorroWeb
{
    public class clsCNAWApertura
    {
        #region Variables Privadas
        private clsADAWApertura objADAWApertura;
        private clsADAWGeneral objADAWGeneral;
        private clsCNAWGeneral objCNAWGeneral;
        private clsCNAWCuenta objCNAWCuenta;
        #endregion

        #region Variables Públicas
        public clsAWLog objAWLog;
        public clsAWTramite objAWTramite;

        public clsAWRegistrarCliente objAWRegistrarCliente;
        public clsAWRegistrarSolicitud objAWRegistrarSolicitud;
        public clsAWRegistrarApertura objAWRegistrarApertura;
        #endregion

        #region Constructores
        public clsCNAWApertura(bool lConexion, clsAWTramite objAWTramite)
        {
            this.objAWTramite = objAWTramite;            

            this.objCNAWCuenta = new clsCNAWCuenta(true, objAWTramite);
            this.objADAWApertura = new clsADAWApertura(true);
            this.objCNAWGeneral = new clsCNAWGeneral(true, objAWTramite);
            this.objADAWGeneral = new clsADAWGeneral(true);

            this.objAWLog = this.objCNAWGeneral.obtenerLog(objAWTramite.cDocumentoID);
        }
        #endregion

        #region Métodos Públicos
        public void registrarFallo(string cEstado)
        {
            this.objAWLog.cEstado = "FALLO APERTURA => " + cEstado;
            this.objCNAWGeneral.registrarLog("update", this.objAWLog);
        }

        public clsAWRegistrarCliente registrarClienteReniec()
        {
            clsADAWApertura objADAWApertura = new clsADAWApertura(true);

            clsAWCliente objAWCliente = null;
            clsAWClienteNatural objAWClienteNatural = null;
            clsAWDireccion objAWDireccion = null;            

            DataTable dtClienteReniec = objADAWApertura.obtenerClienteReniec(this.objAWTramite.cDocumentoID);
            objAWCliente = dtClienteReniec.Rows[0].ToObject<clsAWCliente>();
            objAWClienteNatural = dtClienteReniec.Rows[0].ToObject<clsAWClienteNatural>();            
            objAWDireccion = objCNAWGeneral.obtenerDireccionReniec(this.objAWTramite.cDocumentoID);
            List<clsAWDireccion> lstAWDireccion = new List<clsAWDireccion>();
            lstAWDireccion.Add(objAWDireccion);

            clsCNAWCliente objCNAWCliente = new clsCNAWCliente(true, this.objAWTramite);            
            objCNAWCliente.objAWCliente = objAWCliente;
            objCNAWCliente.objAWClienteNatural = objAWClienteNatural;
            objCNAWCliente.lstAWDireccion = lstAWDireccion;
            objCNAWCliente.objAWLog = this.objAWLog;
            objCNAWCliente.objAWTramite = this.objAWTramite;
            clsAWRegistrarCliente objAWRegistrarCliente = objCNAWCliente.registrarCliente();

            return objAWRegistrarCliente;
        }

        public clsAWRegistrarSolicitud registrarSolicitud()
        {
            clsAWRegistrarSolicitud objAWRegistrarSolicitud = null;
            this.objCNAWCuenta.objAWTramite = this.objAWTramite;
            this.objCNAWCuenta.objAWLog = this.objAWLog;
            objAWRegistrarSolicitud = this.objCNAWCuenta.registrarSolicitud();
            return objAWRegistrarSolicitud;
        }

        public clsAWRegistrarApertura registrarApertura()
        {
            clsAWRegistrarApertura objAWRegistrarApertura = null;
            this.objCNAWCuenta.objAWTramite = this.objAWTramite;
            this.objCNAWCuenta.objAWLog = this.objAWLog;
            objAWRegistrarApertura = this.objCNAWCuenta.registrarApertura();
            return objAWRegistrarApertura;
        }

        public clsAWRespuesta validarCodigoValidacion()
        {
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();
            try
            {
                if (!String.Equals(this.objAWTramite.cCodigoValidacion, this.objAWLog.cCodigoValidacion))
                {
                    objAWRespuesta.respuestaFallida("codigovalidacion");
                    this.registrarFallo("Código de Verificación");
                }
            }
            catch (Exception e)
            {
                this.registrarFallo("Excepción Contratar Cuenta (Codigo Verificación): " + e.ToString());
            }            
            return objAWRespuesta;
        }

        public clsAWDatosCorreo construirDatosCorreo()
        {
            clsAWDatosCorreo objAWDatosCorreo = new clsAWDatosCorreo();
            objAWDatosCorreo.cCorreoDestino = this.objAWTramite.cCorreoElectronico2;
            objAWDatosCorreo.cPrimerNombre = this.objAWRegistrarCliente.cPrimerNombre;
            objAWDatosCorreo.cNombreCompleto = this.objAWRegistrarCliente.cNombre;
            objAWDatosCorreo.cCuenta = this.objAWRegistrarSolicitud.idNroCta;
            objAWDatosCorreo.cProducto = this.objAWTramite.cProducto;
            objAWDatosCorreo.cMoneda = this.objAWTramite.cMoneda;
            objAWDatosCorreo.cArchivoTermCond = "terminos_condiciones_contrato.pdf";
            objAWDatosCorreo.nVigenciaCuenta = 30;
            return objAWDatosCorreo;
        }

        public clsAWRespuesta enviarCorreo()
        {
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();
            try
            {
                clsAWDatosCorreo objAWDatosCorreo = this.construirDatosCorreo();
                List<object> parametros = clsUtils.ObjectToParams(objAWDatosCorreo);
                DataTable dt = this.objADAWApertura.enviarCorreo(parametros.ToArray());
                if (Int32.Parse(dt.Rows[0]["idRespuesta"].ToString()) == 0)
                {
                    objAWRespuesta.respuestaFallida("enviarcorreo");
                    this.registrarFallo("Enviar Correo: " + dt.Rows[0]["idRespuesta"].ToString());
                }
            }
            catch (Exception e)
            {
                objAWRespuesta.respuestaFallida("enviarcorreo");
                this.registrarFallo("Excepción Contratar Cuenta (Enviar Correo): " + e.ToString());
            }                      
            return objAWRespuesta;
        }

        public clsAWRespuesta registrarCanal()
        {
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();
            try
            {
                int idCuenta = this.objAWRegistrarSolicitud.idCuentaAho;
                int idCanal = 3; //Ahorro Web
                DataTable dt = this.objADAWApertura.registrarCanal(idCuenta, idCanal);           
            }
            catch (Exception e)
            {
                this.registrarFallo("Excepción Contratar Cuenta (Registrar Canal): " + e.ToString());
            }                        
            return objAWRespuesta;
        }

        public clsAWRespuesta registrarLog()
        {
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();
            try
            {
                this.construirLog();
                this.objCNAWGeneral.registrarLog("update", this.objAWLog);
            }
            catch (Exception e)
            {
                this.registrarFallo("Excepción Contratar Cuenta (Registrar Log): " + e.ToString());
            }            
            return objAWRespuesta;
        }

        public void construirLog()
        {
            this.objAWLog.idCli = this.objAWRegistrarCliente.idCli;
            this.objAWLog.idTipoCliente = this.objAWRegistrarCliente.idTipoCliente;
            this.objAWLog.idCuenta = this.objAWRegistrarSolicitud.idCuentaAho;
            this.objAWLog.cEstado = "CUENTA APERTURADA => La cuenta fué aperturada correctamente";
        }

        public clsAWRespuesta registrarTramite()
        {
            clsAWRespuesta objAWRespuesta = new clsAWRespuesta();
            try
            {
                this.construirTramite();
                List<object> parametros = clsUtils.ObjectToParams(this.objAWTramite);
                DataTable dtRes = this.objADAWApertura.registrarTramite(parametros.ToArray());
            }
            catch (Exception e)
            {
                this.registrarFallo("Excepción Contratar Cuenta (Registrar Tramite): " + e.ToString());
            }                        
            return objAWRespuesta;
        }

        public void construirTramite()
        {
            this.objAWTramite.idLogAhorroWeb = this.objAWLog.idLogAhorroWeb;
            this.objAWTramite.idCuenta = this.objAWRegistrarSolicitud.idCuentaAho;
            this.objAWTramite.lIdentidadConfirmada = false;
            this.objAWTramite.lDatosRegularizados = false;
            this.objAWTramite.lDocumentosRegularizados = false;
        }

        public clsAWRegistrarOperacion registrarOperacion()
        {
            clsAWRegistrarOperacion objAWRegistrarOperacion = new clsAWRegistrarOperacion();            
                        
            try
            {
                this.objAWRegistrarCliente = this.registrarClienteReniec();
                if (this.objAWRegistrarCliente.idRespuesta == 0)
                {
                    objAWRegistrarOperacion.respuestaFallida("registrooperacion");
                    this.registrarFallo("Registro Cliente");
                    return objAWRegistrarOperacion;
                }

                this.objCNAWCuenta.objAWRegistrarCliente = this.objAWRegistrarCliente;
                this.objAWRegistrarSolicitud = this.registrarSolicitud();
                if (this.objAWRegistrarSolicitud.idRespuesta == 0)
                {
                    objAWRegistrarOperacion.respuestaFallida("registrooperacion");
                    this.registrarFallo("Registro Solicitud");
                    return objAWRegistrarOperacion;
                }

                this.objAWRegistrarApertura = this.registrarApertura();
                if (this.objAWRegistrarApertura.idRespuesta == 0)
                {
                    objAWRegistrarOperacion.respuestaFallida("registrooperacion");
                    this.registrarFallo("Registro Apertura");
                    return objAWRegistrarOperacion;
                }
            }
            catch (Exception e)
            {
                this.registrarFallo("Excepción Contratar Cuenta (Registrar Operación): " + e.ToString());
                objAWRegistrarOperacion.respuestaFallida("registrooperacion");
            }  

            objAWRegistrarOperacion.cCuenta = this.objAWRegistrarSolicitud.idNroCta;
            objAWRegistrarOperacion.cFechaHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            objAWRegistrarOperacion.cPrimerNombre = this.objAWRegistrarCliente.cPrimerNombre;

            return objAWRegistrarOperacion;
        }
        #endregion
    }
}
