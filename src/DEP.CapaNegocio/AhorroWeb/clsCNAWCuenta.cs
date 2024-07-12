using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.Funciones;
using EntityLayer;
using DEP.AccesoDatos.AhorroWeb;
using System.Data;

namespace DEP.CapaNegocio.AhorroWeb
{    
    public class clsCNAWCuenta
    {
        #region Variables Privadas
        private clsADAWCuenta objADAWCuenta;
        private clsCNAWGeneral objCNAWGeneral;
        private clsCNDeposito objCNDeposito;

        private clsAWDeposito objAWDeposito = new clsAWDeposito();        
        private List<clsAWInterviniente> lstAWInterviniente = new List<clsAWInterviniente>();

        private int idAgencia;
        private int idUsuario;
        private DateTime dFechaSistema;
        private int idTipoPago;
        private int idCanal;
        #endregion

        #region Variables Públicas
        public clsAWLog objAWLog;
        public clsAWTramite objAWTramite;
        public clsAWRegistrarCliente objAWRegistrarCliente;
        public clsAWRegistrarSolicitud objAWRegistrarSolicitud;
        #endregion        
        
        #region Constructores
        public clsCNAWCuenta(bool lConexion, clsAWTramite objAWTramite)
        {
            this.objADAWCuenta = new clsADAWCuenta(true);
            this.objCNAWGeneral = new clsCNAWGeneral(true, objAWTramite);
            this.objCNDeposito = new clsCNDeposito(true);

            this.idAgencia = objAWTramite.idAgencia;
            this.idUsuario = objAWTramite.idUsuario;
            this.dFechaSistema = objAWTramite.dFechaSistema;
            this.idTipoPago = objAWTramite.idTipoPago;
            this.idCanal = objAWTramite.idCanal;
        }
        #endregion

        #region Métodos Públicos
        public clsAWRegistrarSolicitud registrarSolicitud()
        {
            clsAWRegistrarSolicitud objAWRegistrarSolicitud = new clsAWRegistrarSolicitud();

            this.construirDeposito();
            List<clsAWDeposito> lstAWDeposito = new List<clsAWDeposito>();
            lstAWDeposito.Add(this.objAWDeposito);
            string xmlAWDeposito = lstAWDeposito.ListObjectToXml<clsAWDeposito>("Table1", "dsDeposito");

            this.construirIntervinientes();
            string xmlAWInterviniente = this.lstAWInterviniente.ListObjectToXml<clsAWInterviniente>("Table1", "dsDeposito");

            List<clsAWDatosTipoPago> lstAWDatosTipoPago = new List<clsAWDatosTipoPago>();
            lstAWDatosTipoPago.Add(this.construirDatosTipoPagoSolicitud());
            string xmlAWDatosTipoPago = lstAWDatosTipoPago.ListObjectToXml<clsAWDatosTipoPago>("Table1", "dsDeposito");

            List<clsAWEmpleador> lstAWEmpleador = new List<clsAWEmpleador>();
            lstAWEmpleador.Add(new clsAWEmpleador());
            string xmlAWEmpleador = lstAWEmpleador.ListObjectToXml<clsAWEmpleador>("Table1", "dsDeposito");

            List<clsAWAhorroProgramado> lstAWAhorroProgramado = new List<clsAWAhorroProgramado>();
            lstAWAhorroProgramado.Add(new clsAWAhorroProgramado());
            string xmlAWAhorroProgramado = lstAWAhorroProgramado.ListObjectToXml<clsAWAhorroProgramado>("Table1", "dsDeposito");

            List<clsAWCuentaCancelada> lstAWCuentaCancelada = new List<clsAWCuentaCancelada>();
            lstAWCuentaCancelada.Add(new clsAWCuentaCancelada());
            string xmlAWCuentaCancelada = lstAWCuentaCancelada.ListObjectToXml<clsAWCuentaCancelada>("Table1", "dsDeposito");

            int idUsuario = this.idUsuario;
            DateTime dFecOpe = this.dFechaSistema;
            int nCuotas = 0;
            Decimal nMonIntang = 0;
            bool lisAhoPrg = false;
            bool lIsRequeCert = false;
            bool lIsCtaCTS = false;
            int idTipPago = 1;
            int idCuentaTrans = 0;
            DateTime dFecAhoPrg = this.dFechaSistema;
            bool lisReqEmp = false;
            string cNroDocPag = "";
            int idEntFin = 77;
            int idCuentaRel = 0;
            Decimal nMonCapital = 30;

            clsCNAperturaCta objCNAperturaCta = new clsCNAperturaCta(true);
            DataTable dt = objCNAperturaCta.RegistraAperturaCta(
                xmlAWDeposito,
                xmlAWInterviniente,
                xmlAWDatosTipoPago,
                xmlAWEmpleador,
                xmlAWAhorroProgramado,
                idUsuario,
                dFecOpe,
                nCuotas,
                nMonIntang, 
                lisAhoPrg,
                lIsRequeCert,
                lIsCtaCTS,
                idTipPago,
                idCuentaTrans,
                dFecAhoPrg,
                lisReqEmp,
                cNroDocPag,
                idEntFin,
                idCuentaRel,
                nMonCapital,
                xmlAWCuentaCancelada
            );
            objAWRegistrarSolicitud.idCuentaAho = Int32.Parse(dt.Rows[0]["idCuentaAho"].ToString());
            objAWRegistrarSolicitud.idNroCta = dt.Rows[0]["idNroCta"].ToString();
            this.objAWRegistrarSolicitud = objAWRegistrarSolicitud;
            return objAWRegistrarSolicitud;
        }

        public void construirDeposito()
        {
            this.objAWDeposito.idAgencia = this.idAgencia;
            this.objAWDeposito.idUsuario = this.idUsuario;
            this.objAWDeposito.idUsuAtiende = this.idUsuario;
            this.objAWDeposito.idUsuAsig = this.idUsuario;
            this.objAWDeposito.idProducto = this.objAWTramite.idProducto;
            this.objAWDeposito.idMoneda = this.objAWTramite.idMoneda;
            this.objAWDeposito.idEstado = 4; // pre solicitado
            this.objAWDeposito.idTipoCuenta = 1; // individual
            this.objAWDeposito.idTipoTasa = 1; // Normal
            this.objAWDeposito.nNumeroFirmas = 1; // Una sola firma - Individual
            this.objAWDeposito.idTipoPersona = 1; // Persona Natural
            this.objAWDeposito.idTipoEnvioEstCta = String.IsNullOrEmpty(this.objAWTramite.cCorreoElectronico2) ? 3 : 2; // Recojo en oficina / Correo Electrónico
            this.objAWDeposito.cDireccionEnvioEstCta = this.objAWTramite.cCorreoElectronico2;
            clsAWParametrosProducto objAWParametrosProducto = this.obtenerParametroProducto(this.objAWDeposito.idProducto, this.objAWDeposito.idMoneda, 2);
            this.objAWDeposito.lIsAfectoITF = objAWParametrosProducto.lIsAfectoITF;
            this.objAWDeposito.lInactiva = objAWParametrosProducto.lIsInactiva;
            this.objAWDeposito.lIsCtaOrdPago = objAWParametrosProducto.lIsCtaOrdPago;
            this.objAWDeposito.nSaldoMinimo = objAWParametrosProducto.nMonMinSalDis;
            this.objAWDeposito.idObjetoAho = this.objAWTramite.idObjetoAho;

            clsAWTasa clsAWTasa = this.obtenerTasa(this.objAWDeposito);
            this.objAWDeposito.idTasa = clsAWTasa.idTasa;
            this.objAWDeposito.nMonTasa = clsAWTasa.nTasaCompensatoria;
        }

        public void construirIntervinientes()
        {
            clsAWInterviniente objAWInterviniente = new clsAWInterviniente();//titular
            objAWInterviniente.codigo = this.objAWRegistrarCliente.idCli;
            objAWInterviniente.idTipoInterv = 6; //titular
            objAWInterviniente.dFecIniInterv = this.dFechaSistema;            
            objAWInterviniente.lEsAfeItf = true;
            this.lstAWInterviniente.Add(objAWInterviniente);
        }

        public clsAWDatosTipoPago construirDatosTipoPagoSolicitud()
        {
            clsAWDatosTipoPago objAWDatosTipoPago = new clsAWDatosTipoPago();
            objAWDatosTipoPago.idTipoValorado = this.idTipoPago;
            objAWDatosTipoPago.cNroDocumento= "000";
            objAWDatosTipoPago.cSerieDocumento = "0";
            objAWDatosTipoPago.idEntidad = 77; //CRACLASA
            objAWDatosTipoPago.dFechaReg = this.dFechaSistema;
            objAWDatosTipoPago.dFechaEmiDoc = this.dFechaSistema;
            return objAWDatosTipoPago;
        }

        public clsAWParametrosProducto obtenerParametroProducto(int idProducto, int idMoneda, int nOpcion)
        {
            clsAWParametrosProducto objAWParametrosProducto = null;
            DataTable dt = this.objADAWCuenta.obtenerParametroProducto(idProducto, idMoneda, nOpcion);
            if (dt.Rows.Count != 1)
                return null;
            objAWParametrosProducto = dt.Rows[0].ToObject<clsAWParametrosProducto>();
            return objAWParametrosProducto;
        }

        public clsAWTasa obtenerTasa(clsAWDeposito objAWDeposito)
        {
            clsAWTasa objAWTasa = null;
            DataTable dt = this.objADAWCuenta.obtenerTasa(
                objAWDeposito.nPlazoCta,
                objAWDeposito.idProducto,
                objAWDeposito.nMontoDeposito,
                objAWDeposito.idMoneda,
                objAWDeposito.idAgencia,
                objAWDeposito.idTipoPersona
            );
            if (dt.Rows.Count != 1)
                return null;
            objAWTasa = dt.Rows[0].ToObject<clsAWTasa>();
            return objAWTasa;
        }

        public clsAWRegistrarApertura registrarApertura()
        {
            clsAWRegistrarApertura objAWRegistrarApertura = new clsAWRegistrarApertura();            

            int idTipoOperacion = 9; //APERTURA
            int idCuenta = this.objAWRegistrarSolicitud.idCuentaAho;

            clsCNOperacionDep objCNOperacionDep = new clsCNOperacionDep(true);
            string cEstadoCuenta = "";
            if (!objCNOperacionDep.ValidarBloqueoCta(idCuenta, idTipoOperacion, ref cEstadoCuenta))
            {
                this.objCNDeposito.CNUpdNoUsoCuenta(idCuenta);
                return null;
            }

            List<clsAWObtenerCuenta> lstAWObtenerCuenta = this.obtenerCuentas();
            clsAWObtenerCuenta objAWObtenerCuenta = lstAWObtenerCuenta[0];

            List<clsAWInterviniente> lstAWInterviniente = this.obtenerIntervinientes();
            string xmlAWInterviniente = lstAWInterviniente.ListObjectToXml<clsAWInterviniente>();

            List<clsAWDatosTipoPago> lstAWDatosTipoPago = new List<clsAWDatosTipoPago>();
            lstAWDatosTipoPago.Add(this.construirDatosTipoPagoApertura());
            string xmlAWDatosTipoPago = lstAWDatosTipoPago.ListObjectToXml<clsAWDatosTipoPago>();

            List<clsAWComision> lstAWComision = this.obtenerComisiones(objAWObtenerCuenta);
            string xmlAWComision = lstAWComision.ListObjectToXml<clsAWComision>();

            int nCuota = 0;
            bool lEsAhoProg = false;
            bool lIsRequCerti = false;
            bool lIsCtaCTS = false;
            string cNroDoc = "";//ninguno            
            int idEntFin = 0;//No se tiene - Codigo de la entidad Financiera
            int idCtaTrans = 0;//No se tiene - cCta de Transferencia Interna @cCtaTransf
            int idTipPago = this.idTipoPago;//Sera 1: en efectivo - Indica el Tipo de pago, Efectivo, Cheque, etc
            decimal nMonITFDep = 0;	//No existe ITF por ser monto 0 - ECIMAL(12,2), -- Monto ITF del Deposito
            decimal nMonITFInt = 0;	//No existe ITF por ser monto 0 - Monto del ITF del pago Interes Adelantado
            decimal nMonComis = 0;//No se sabe - DECIMAL(12,2),
            decimal nMonRedondeo = 0;//DECIMAL(12,2),
            int idCanal = this.idCanal; //		INT,
            decimal nMonRedIntAde = 0; // DECIMAL(12,2),
            bool lIsDepMenEdad = false; // BIT,
            int idMotivoOpe = 1; // INT, Se puede crear otro motivo de operacion efectivo por web
            decimal nMonto = 0;
            decimal nMonIntPagAde = Convert.ToDecimal(objAWObtenerCuenta.nIntPagAde);
            int idUsuario = this.idUsuario;
            DateTime dFechaOperacion = this.dFechaSistema;
            decimal nMonCapital = 0;
            int idTasa = this.objAWDeposito.idTasa;
            decimal nMonTasa = this.objAWDeposito.nMonTasa;
            decimal nMonIntTot = this.objAWDeposito.nMonIntTot;

            //Aplica solo para modificacion de saldos en Linea
            bool lModificaSaldoLinea1 = false;
            bool lModificaSaldoLinea2 = false;
            int idMoneda = 0;
            int nIdAgencia = 0;

            DataTable dt = new clsCNAperturaCta(true).RegistraConfirmApeCta(
                idCuenta,
                xmlAWComision,
                xmlAWDatosTipoPago,
                xmlAWInterviniente,
                nMonto,
                nMonIntPagAde,
                idUsuario,
                dFechaOperacion,
                nCuota,
                lEsAhoProg,
                lIsRequCerti,
                lIsCtaCTS,
                cNroDoc,
                idEntFin,
                idCtaTrans,
                idTipoPago,
                nMonITFDep,
                nMonITFInt,
                nMonComis,
                nMonRedondeo,
                nMonCapital,
                idCanal,
                nMonRedIntAde,
                lIsDepMenEdad,
                idMotivoOpe,
                idTasa,
                nMonTasa,
                nMonIntTot,
                lModificaSaldoLinea1,
                lModificaSaldoLinea2,
                idMoneda,
                nIdAgencia
            );

            return objAWRegistrarApertura;
        }

        public List<clsAWObtenerCuenta> obtenerCuentas()
        {
            List<clsAWObtenerCuenta> lstAWObtenerCuenta = new List<clsAWObtenerCuenta>();
            int idCuenta = this.objAWRegistrarSolicitud.idCuentaAho;
            int idTipoOperacion = 9; //APERTURA
            DataTable dt = this.objCNDeposito.CNRetornaDatosCuenta(idCuenta, "4", idTipoOperacion);
            if(dt.Rows.Count > 0)
                lstAWObtenerCuenta = dt.SoftToList<clsAWObtenerCuenta>().ToList<clsAWObtenerCuenta>();
            return lstAWObtenerCuenta;
        }

        public List<clsAWInterviniente> obtenerIntervinientes()
        {
            List<clsAWInterviniente> lstAWInterviniente = new List<clsAWInterviniente>();
            int idCuenta = this.objAWRegistrarSolicitud.idCuentaAho;
            DataTable dt = this.objCNDeposito.CNRetornaIntervinientesCuenta(idCuenta);
            if (dt.Rows.Count > 0)
                lstAWInterviniente = dt.SoftToList<clsAWInterviniente>().ToList<clsAWInterviniente>();
            return lstAWInterviniente;
        }

        public clsAWDatosTipoPago construirDatosTipoPagoApertura()
        {
            clsAWDatosTipoPago objAWDatosTipoPago = new clsAWDatosTipoPago();
            objAWDatosTipoPago.idTipoValorado = this.idTipoPago;
            objAWDatosTipoPago.cNroDocumento = "000";
            objAWDatosTipoPago.cSerieDocumento = "0";
            objAWDatosTipoPago.idEntidad = 77; //CRACLASA
            objAWDatosTipoPago.dFechaReg = this.dFechaSistema;
            objAWDatosTipoPago.dFechaEmiDoc = this.dFechaSistema;
            return objAWDatosTipoPago;
        }

        public List<clsAWComision> obtenerComisiones(clsAWObtenerCuenta objAWObtenerCuenta)
        {
            List<clsAWComision> lstAWComision = new List<clsAWComision>();
            int idCuenta = this.objAWRegistrarSolicitud.idCuentaAho;
            int idTipoPago = this.idTipoPago;
            decimal nMonto = 0;
            decimal nMonIntPagAde = Convert.ToDecimal(objAWObtenerCuenta.nIntPagAde);
            int idProd = objAWObtenerCuenta.idProducto;
            int idTipoOperacion = 9; //APERTURA;
            int idTipoPersona = objAWObtenerCuenta.idTipoPersona;
            int idMoneda = this.objAWDeposito.idMoneda;
            int idAgencia = this.idAgencia;            
            int nPlanCta = 0;            
            DataTable dt = new clsCNOperacionDep(true).RetornaComisionesCtaOpe(idProd, idTipoOperacion, idTipoPersona, idMoneda, idCuenta, this.idCanal, this.idAgencia, nMonto, nPlanCta, idTipoPago);            
            if (dt.Rows.Count > 0)
                lstAWComision = dt.SoftToList<clsAWComision>().ToList<clsAWComision>();
            return lstAWComision;
        }
        #endregion
    }
}
