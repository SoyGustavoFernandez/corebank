using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS;
using System.IO.Ports;
using SER.CapaNegocio;
using GEN.Funciones;
using System.Data;

namespace GEN.ControlesBase
{
    public class clsEnvioMensajeTexto
    {
        #region Atributos

        SerialPort sPort; 
        Method oMethod;
        clsConexion oConexion;

        private string cPuerto;
        private int nTransmision;
        private int nBitDatos;
        private int nBitParada;
        private int nTiempoEscritura;
        private int nTiempoLectura;

        private string[] aPorts;
        private int nIndicePort;
        private int nContador;
        private int nIntentos;
        clsCNMensajeTexto cnMensaje;

        #endregion

        #region Constructor
        public void setIntentos(int _nIntentos)
        {
            this.nIntentos = _nIntentos;
        }

        public clsEnvioMensajeTexto(string _cPuerto, int _nTransmision, int _nBitDatos, int _nBitParada, int _nTiempoEscritura, int _nTiempoLectura)
        {
            this.sPort = new SerialPort();
            this.oMethod = new Method();

            this.cPuerto = _cPuerto;
            this.nTransmision = _nTransmision;
            this.nBitDatos = _nBitDatos;
            this.nBitParada = _nBitParada;
            this.nTiempoEscritura = _nTiempoEscritura;
            this.nTiempoLectura = _nTiempoLectura;
            this.oConexion = new clsConexion();
            this.cnMensaje = new clsCNMensajeTexto();

            this.nContador = 0;
            this.nIntentos = 6;
            
        }

        public void iniciarCuenta()
        {
            this.nContador = 0;
            this.nIntentos = 6;
        }

        public clsEnvioMensajeTexto(string _cPuerto)
        {
            //this.sPort = new SerialPort();
            this.oMethod = new Method();

            this.nTransmision = 9600;
            this.nBitDatos = 8;
            this.nBitParada = 1;
            this.nTiempoEscritura = 300;
            this.nTiempoLectura = 300;
            this.oConexion = new clsConexion();
            this.cPuerto = _cPuerto;
            this.cnMensaje = new clsCNMensajeTexto();
        }

        #endregion

        #region Métodos Publicos

        public clsMensajeTexto EnviarMensaje(clsMensajeTexto oMensaje)
        {
            
            Dictionary<String, dynamic> Rpta = new Dictionary<string, dynamic>();

            //Rpta = oMethod.Dic_SendMSG(sPort, oMensaje.cNroCelular, oMensaje.cMensaje);
            try
            {
                oMethod.sendMsg(sPort, oMensaje.cNroCelular, oMensaje.cMensaje);
            }
            catch (Exception ex)
            {

                oMensaje.cMsgResultado = ex.Message;
                if (oMensaje.idEstadoEnvio != EstadoEnvioSMS.ENVIADO)
                {
                    oMensaje.cResultado = "fail";
                }
                else
                {
                    oMensaje.cResultado = "success";
                }
            }
            
            this.nContador++;
            //System.Threading.Thread.Sleep(1000);
                        
            //oMensaje.cMsgResultado = Rpta["msg"];
            //oMensaje.cResultado = Rpta["result"];

            if (oMensaje.idEstadoEnvio != EstadoEnvioSMS.ENVIADO)
            {
                if (this.nContador < this.nIntentos)
                {
                    this.EnviarMensaje(oMensaje);
                }
            }

            return oMensaje;
        }

        public clsConexion Conectar()
        {
            if (String.IsNullOrEmpty(cPuerto))
            {
                oConexion.idEstado = 0;
                oConexion.cMensaje = "No hay un puerto definido";
                return oConexion;
            }

            try
            {
                if (this.sPort == null)
                {
                    this.sPort = oMethod.OpenPort(cPuerto, this.nTransmision, this.nBitDatos, this.nBitParada, this.nTiempoEscritura);

                    if (this.sPort != null)
                    {
                        oConexion.idEstado = 1;
                        oConexion.cMensaje = "Conexión se realizó correctamente";
                    }

                    else
                    {
                        oConexion.idEstado = 0;
                        oConexion.cMensaje = "Error en conexión o correxión invalida";
                    }
                }
                else
                {
                    oConexion.idEstado = 1;
                    oConexion.cMensaje = "Conexión esta abierta";
                }
            }
            catch (Exception ex)
            {
                oConexion.idEstado = 0;
                oConexion.cMensaje = ex.Message;
            }

            return oConexion;
        }

        public clsConexion Desconectar()
        {
            try
            {
                oMethod.ClosePort(this.sPort);
                oConexion.idEstado = 1;
                oConexion.cMensaje = "Conexión Cerrada";

            }
            catch (Exception ex)
            {
                oConexion.idEstado = 0;
                oConexion.cMensaje = "Error al cerrar Conexión "+ex.Message;
            }

            return oConexion;
        }

        #endregion

        #region Métodos Privados
        #endregion
    }

    public class clsMensajeTexto
    {
        public int idMensaje { get; set; }
        public string cNombres { get; set; }
        public Double nNroCelular { get; set; }
        public string cNroCelular { 
            get { return this.nNroCelular.ToString(); } 
        }
        public int idCli { get; set; }
        public int idCuenta { get; set; }
        public string cMensaje { get; set; }
        public int idUsuarioRegistra { get; set; }
        public DateTime dFechaRegistro { get; set; }
        public int idUsuarioEnvio { get; set; }
        public DateTime dFechaEnvio   { get; set; }
        public int idEstadoEnvio { get {
            int nIndice = -1;
            nIndice = (this.cMsgResultado == null) ? -1 : this.cMsgResultado.IndexOf("Respuesta recibida");
            if (nIndice >= 0)
            {
                return EstadoEnvioSMS.ENVIADO;
            }
            else
            {
                return EstadoEnvioSMS.NO_ENVIADO;
            }
        } }
        public bool lVigente { get; set; }
        public string nRpta { get; set; }
        public string cResultado { get; set; }
        public string cLogError { get; set; }
        public string cMsgResultado { get; set; }
        public int idTipoMensaje { get; set; }
        public string cMensajeRespuesta { get {
            return this.cResultado + this.cMsgResultado;
        } }
        public bool lEnvio { get; set; }
        public string cDetalleError { get; set; }
    }

    public class clsConexion
    {
        public int idEstado { get; set; }
        public string cMensaje { get; set; } 
    }

    #region TipoEnvioSMS

    public class TipoEnvioSMS
    {
        public static int ENVIOMASIVO = 1;
    }

    public class EstadoEnvioSMS
    {
        public static int ENVIADO = 1;
        public static int PROGRAMADO = 2;
        public static int NO_ENVIADO = 3;
        public static int NO_RECIBIDO = 4;
    }

    #endregion
}
