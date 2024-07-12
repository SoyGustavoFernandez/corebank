using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using ADM.CapaNegocio;
using System.Data;
using GEN.Funciones;

namespace GEN.ControlesBase
{
    public class clsGestionaNivelAprobacion
    {      
        private clsCNNivelesAprobacion oNivelAprobacion = new clsCNNivelesAprobacion();
        List<clsNivelAprobaBase> listNivelAprobaciones = new List<clsNivelAprobaBase>();
        List<clsDetSolicitudAproba> listDetSolAproba = new List<clsDetSolicitudAproba>();
        int idSolicitudAproba = 0;
        int idModulo = 0;
        int idTipoOperacion = 0;

        int idNivelAprobacion = 0;

        #region Constructores

        public clsGestionaNivelAprobacion()
        {
            this.idSolicitudAproba = 0;
            this.idModulo = 0;
            this.idTipoOperacion = 0;
        }
        /// <summary>
        /// Constructor inicializa las caracteristicas de niveles de aprobacion asi como tambien el detalle de la 
        /// solicitud de aprobación
        /// </summary>
        /// <param name="_idSolicitudAproba">identificador de la solicitud de aprobación</param>
        /// <param name="_idModulo">Modulo en el cual se esta realizando la aprobación</param>
        /// <param name="_idTipoOperacion">Tipo de operacion</param>
        public clsGestionaNivelAprobacion(int _idSolicitudAproba, int _idModulo, int _idTipoOperacion) 
        {
            this.idSolicitudAproba = _idSolicitudAproba;
            this.idModulo = _idModulo;
            this.idTipoOperacion = _idTipoOperacion;

            this.ObtenerCaracteristicasNivelesAprobacion(this.idModulo, this.idTipoOperacion);
            this.ObtenerDetalleSolicitudAprobacion(this.idSolicitudAproba);   
        }

        #endregion

        #region Public

        public void init(int _idSolicitudAproba, int _idModulo, int _idTipoOperacion)
        {
            this.idSolicitudAproba = _idSolicitudAproba;
            this.idModulo = _idModulo;
            this.idTipoOperacion = _idTipoOperacion;
        }

        public string guardarVoBoNivelAprobacion(string cComentario, int idUsuario, int idPerfil, DateTime dFecha, int idEstadoAprobacion)
        {
            DataTable dRes = oNivelAprobacion.CNRegistroVoBoNivelesAprobacion(cComentario, idUsuario, idPerfil, dFecha, idEstadoAprobacion, this.idSolicitudAproba);
            return dRes.Rows[0]["cMensaje"].ToString();
        }
        public string guardarParaAprobacion(int idEstadoAprobacion)
        {
            DataTable dRes = oNivelAprobacion.CNRegistroParaAprobacion(idEstadoAprobacion, this.idSolicitudAproba);
            return dRes.Rows[0]["cMensaje"].ToString();
        }

        public string obtenerNivelAprobacionSolicitud(int idEstadoAproba = 2)
        {
            int idNivelPorMonto = 0;
            preparaCaracDetalleNivelAprobacion();

            this.idNivelAprobacion = obtenerNivelDeAprobacion();
            /*
             * Valida si sumple con parametro maximo de monto a condonar y si no manda al nivel superior
             */
            idNivelPorMonto = obtenerNivelDeAprobacion(2);
            if (this.idNivelAprobacion < idNivelPorMonto)// validar monto condonación
            {
                this.idNivelAprobacion = idNivelPorMonto;
            }

            if (this.idNivelAprobacion == 0)
            {
                return "La Solicitud no tiene un nivel pre configurado. Coordinar la negociación con el Área de Recuperaciones";
            }

            return generarNivelesAprobacionBaseDatos(idNivelAprobacion, idEstadoAproba);
        }

        public int getIdNivelAprobacion() 
        {
            return this.idNivelAprobacion;
        }

        public clsFinVoBoNivelesAproba validarVoBoNivelAproba(int _idSolicitudAproba)
        {
            this.idSolicitudAproba = _idSolicitudAproba;
            DataTable dtRes = oNivelAprobacion.CNValidaVoBoNivelAprobacion(this.idSolicitudAproba);
            if (dtRes.Rows.Count == 0)
            {
                return null;
            }
            else 
            {
                clsFinVoBoNivelesAproba obj = new clsFinVoBoNivelesAproba();
                obj.idVoBoNivelesAproba = Convert.ToInt32(dtRes.Rows[0]["idVoBoNivelesAproba"]);
                obj.cComentario         = dtRes.Rows[0]["cComentario"].ToString();
		        obj.idUsuarioReg		= Convert.ToInt32(dtRes.Rows[0]["idUsuarioReg"]);
		        obj.idPerfil			= Convert.ToInt32(dtRes.Rows[0]["idPerfil"]);
                obj.dFechaVoBo          = Convert.ToDateTime(dtRes.Rows[0]["dFechaVoBo"]);
		        obj.idEstadoAproba		= Convert.ToInt32(dtRes.Rows[0]["idEstadoAproba"]);
		        obj.idSolicitudAproba	= Convert.ToInt32(dtRes.Rows[0]["idSolicitudAproba"]);
		        obj.lVigente			= Convert.ToBoolean(dtRes.Rows[0]["lVigente"]);
                return obj;
            }

        }

        public List<clsSolicitudAprobacion> obtenerSolicitudesParaAprobar(int idPerfil, int idAgencia)
        {
            DataTable dtRes = oNivelAprobacion.CNListarSolicitudesParaAprobar(idPerfil, idAgencia);
            return DataTableToList.ConvertTo<clsSolicitudAprobacion>(dtRes) as List<clsSolicitudAprobacion>;
        }

        public DataTable registrarDesicion(int idNivelAprobaSol, int idSolicitudAproba, DateTime dFechaSis, int idEstadoAproba, int idUsu, string cComentario, int idCuenta = 0)
        {
            return oNivelAprobacion.CNGuardarDesicionSolicitud(idNivelAprobaSol, idSolicitudAproba, dFechaSis, idEstadoAproba, idUsu, cComentario, Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil), idCuenta);
        }

        public DataTable dtsPropuestaNegociacion(int idSolAproba)
        {
            return oNivelAprobacion.dtsPropuestaNegociacion(idSolAproba);
        }

        public DataTable listarGruposAfectacion()
        {
            return oNivelAprobacion.listarGruposAfectacion();
        }

        public DataTable listarCobsGrupo(int idGrupo)
        {
            return oNivelAprobacion.listarCobsGrupo(idGrupo);
        }

        public DataTable registrarDecicionAfectacion(int idGrupo, int idEstado, int idUsuario, DateTime dFecha, string cComentario)
        {
            return oNivelAprobacion.registrarDecicionAfectacion(idGrupo, idEstado, idUsuario, dFecha, cComentario);
        }
        #endregion
        
        #region Privada
        /// <summary>
        /// Valida Expresion enviada por parametro sintaxis Visual Basic
        /// </summary>
        /// <param name="cCadenaValidar">cadena a evaluar</param>
        /// <returns></returns>
        private bool ValidarExpresion(string cCadenaValidar)
        {
            DataTable dtComputable = new DataTable();
            if (Convert.ToBoolean(dtComputable.Compute(cCadenaValidar.Trim(), "")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ObtenerCaracteristicasNivelesAprobacion(int idModulo, int idTipoOperacion)
        {
            DataTable dtCarNivelAproba = oNivelAprobacion.CNCargandoCaracteristicasNivelesAprobacion(0, idModulo, idTipoOperacion);
            listNivelAprobaciones = DataTableToList.ConvertTo<clsNivelAprobaBase>(dtCarNivelAproba) as List<clsNivelAprobaBase>;
        }

        private void ObtenerDetalleSolicitudAprobacion(int idSolicitudAproba)
        {
            DataTable dtDetSoliciAproba = oNivelAprobacion.CNListaCondSolicitudAprobacion(idSolicitudAproba);
            listDetSolAproba = DataTableToList.ConvertTo<clsDetSolicitudAproba>(dtDetSoliciAproba) as List<clsDetSolicitudAproba>;
        }

        private string ReemplazarValores(string cCadenaBase, string cTextoInicial, string cTextoReemplazo)
        {
            return cCadenaBase.Replace(cTextoInicial, cTextoReemplazo);
        }

        private void preparaCaracDetalleNivelAprobacion()
        {
            foreach (clsNivelAprobaBase item in listNivelAprobaciones)
            {
                foreach (clsDetSolicitudAproba item2 in listDetSolAproba)
                {
                    // Reemplazando las caracteristicas
                    item.cCaracteristicaNAReemp = ReemplazarValores((item.cCaracteristicaNAReemp == null) ? item.cCaracteristicaNA : item.cCaracteristicaNAReemp, item2.cVarNivelAproBase, item2.cValor);

                    // Reemplazando las reglas   
                    item.cReglaReemp = ReemplazarValores((item.cReglaReemp == null) ? item.cRegla : item.cReglaReemp, item2.cVarNivelAproBase, item2.cValor);
                }
                
            }
        }

        private int obtenerNivelDeAprobacion(int idTipoVar= 1)
        {
            int idNivelAprobacionBase = 0;
            List<clsNivelAprobaBase> list = obtenerCaracteristicaXNivelAproba(idTipoVar);

            foreach (clsNivelAprobaBase item in list)
            {
                if (ValidarExpresion(item.cCaracteristicaNAReemp))
                {
                    if (buscarNivelAprobaPorCaracteristicaYNivelBase(item.idCaracteristicaNA, item.idNivelAprobaBase, idTipoVar))
                    {
                        idNivelAprobacionBase = item.idNivelAprobaBase;
                        break;
                    }
                }
            }

            return idNivelAprobacionBase;
        }

        private List<clsNivelAprobaBase> obtenerCaracteristicaXNivelAproba(int idTipoVar =1)
        { 
            List<clsNivelAprobaBase> oCaracNivelApro = new List<clsNivelAprobaBase>();
            foreach (clsNivelAprobaBase item in listNivelAprobaciones)
	        {
                if (idTipoVar == item.idTipoVar)
                {
                    if (oCaracNivelApro.Count == 0)
                    {
                        oCaracNivelApro.Add(item);
                    }
                    else
                    {
                        bool lExiste = false;
                        foreach (clsNivelAprobaBase item2 in oCaracNivelApro)
                        {
                            if (item2.idNivelAprobaBase == item.idNivelAprobaBase && item2.idCaracteristicaNA == item.idCaracteristicaNA)
                            {
                                lExiste = true;
                            }
                        }

                        if (!lExiste)
                        {
                            oCaracNivelApro.Add(item);
                        }
                    }
                }
	        }

            return oCaracNivelApro;
            
        }

        private bool buscarNivelAprobaPorCaracteristicaYNivelBase(int idCaracteristica, int idNivelAproBase, int idTipoVar = 1)
        {
            int nCaracteristicas = 0;
            int nCaracteristicasOk = 0;
            
            foreach (clsNivelAprobaBase item in listNivelAprobaciones)
            {
                if (item.idTipoVar == idTipoVar)
                {
                    if (idCaracteristica == item.idCaracteristicaNA && idNivelAproBase == item.idNivelAprobaBase)
                    {
                        nCaracteristicas++;

                        if (ValidarExpresion(item.cReglaReemp))
                        {
                            nCaracteristicasOk++;
                        }

                    }
                }
            }
            
            return (nCaracteristicas == nCaracteristicasOk)? true: false ;
        }

        private string generarNivelesAprobacionBaseDatos(int idNivelAprobacion, int idEstadoAproba)
        {
            DataTable dtRes = oNivelAprobacion.CNGuardarNivelAprobacion(this.idSolicitudAproba, idNivelAprobacion, idEstadoAproba);
            return dtRes.Rows[0]["cMensaje"].ToString();
        }


        public DataTable revisarVistoBuenoNivelAprobacion(int idSolicitudAproba)
        {
             DataTable dtRes = oNivelAprobacion.CNrevisarVistoBuenoNivelAprobacion(idSolicitudAproba);
             return dtRes;
        }
        #endregion
    }
}
