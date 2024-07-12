using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using GEN.Funciones;


namespace GEN.ControlesBase
{
    public partial class frmSustentoVinculacionArchivo : frmBase
    {

        #region Variables
        private int idSustentoVinculacionArchivo { get; set; }
        private int idTipoArchivo { get; set; }
        private int idSolicitud { get; set; }
        private int idArchivo { get; set; }
        private int idAccionVinculacionArchivo { get; set; }
        private int idEstadoSolicitud { get; set; }

        private int idSolicitudGrupoSolidario { get; set; }
        private bool lSuperaMontoExposicion { get; set; }
        private int idPagareCredito { get; set; }



        private List<clsMotivoVinculacionArchivo> lstMotivoVinculacionArchivo { get; set; }
        private BindingSource bsMotivoVinculacionArchivo { get; set; }
        private CRE.CapaNegocio.clsCNAdministracionFiles objCNAdministracionFiles { get; set; }
        private CRE.CapaNegocio.clsCNCargaArchivo objCNCargaArchivo { get; set; }
        public clsSustentoArchivoPagare objSustentoVinculacionArchivo { get; set; }
        #endregion

        #region Constructores
        public frmSustentoVinculacionArchivo()
        {
            InitializeComponent();
            cargarComponentes();
        }

        public frmSustentoVinculacionArchivo(int _idSolicitud, bool _lSuperaMontoExposicion, int _idEstadoSolicitud, int _idTipoArchivo, int _idArchivo, int _idAccionVinculacion, int _idPagareCredito, int _idSolicitudGrupoSolidario = 0)
        {
            InitializeComponent();
            cargarComponentes(_idSolicitud, _lSuperaMontoExposicion, _idEstadoSolicitud, _idTipoArchivo, _idArchivo, _idAccionVinculacion, _idPagareCredito, _idSolicitudGrupoSolidario);
        }

        #endregion

        #region Eventos
        #endregion

        #region Metodos

        private void cargarComponentes()
        {
            idSustentoVinculacionArchivo    = 0;
            idTipoArchivo                   = 0;
            idSolicitud                     = 0;
            idArchivo                       = 0;
            idAccionVinculacionArchivo      = 0;
            objCNAdministracionFiles        = new CRE.CapaNegocio.clsCNAdministracionFiles();
            objCNCargaArchivo               = new CRE.CapaNegocio.clsCNCargaArchivo();
            lstMotivoVinculacionArchivo     = new List<clsMotivoVinculacionArchivo>();
            lstMotivoVinculacionArchivo     = objCNCargaArchivo.CNObtenerMotivoVinculacionArchivo();
            bsMotivoVinculacionArchivo      = new BindingSource();
            bsMotivoVinculacionArchivo.DataSource = lstMotivoVinculacionArchivo;
            objSustentoVinculacionArchivo   = new clsSustentoArchivoPagare();
            

            cboMotivoVinculacionArchivo.DataSource         = bsMotivoVinculacionArchivo;
            cboMotivoVinculacionArchivo.ValueMember        = "idMotivoVinculacionArchivo";
            cboMotivoVinculacionArchivo.DisplayMember      = "cMotivoVinculacionArchivo";
        }

        private void cargarComponentes(int _idSolicitud, bool _lSuperaMontoExposicion, int _idEstadoSolicitud, int _idTipoArchivo, int _idArchivo, int _idAccionVinculacion, int _idPagareCredito, int _idSolicitudGrupoSolidario)
        {
            idSustentoVinculacionArchivo            = 0;
            idTipoArchivo                           = _idTipoArchivo;
            idSolicitud                             = _idSolicitud;
            lSuperaMontoExposicion                  = _lSuperaMontoExposicion;
            idEstadoSolicitud                       = _idEstadoSolicitud;
            idArchivo                               = _idArchivo;
            idAccionVinculacionArchivo              = _idAccionVinculacion;
            idPagareCredito                         = _idPagareCredito;
            idSolicitudGrupoSolidario               = _idSolicitudGrupoSolidario;
            objCNAdministracionFiles                = new CRE.CapaNegocio.clsCNAdministracionFiles();
            objCNCargaArchivo                       = new CRE.CapaNegocio.clsCNCargaArchivo();
            lstMotivoVinculacionArchivo             = new List<clsMotivoVinculacionArchivo>();
            lstMotivoVinculacionArchivo             = objCNCargaArchivo.CNObtenerMotivoVinculacionArchivo();
            bsMotivoVinculacionArchivo              = new BindingSource();
            bsMotivoVinculacionArchivo.DataSource   = lstMotivoVinculacionArchivo;
            objSustentoVinculacionArchivo           = new clsSustentoArchivoPagare();
            

            cboMotivoVinculacionArchivo.DataSource     = bsMotivoVinculacionArchivo;
            cboMotivoVinculacionArchivo.ValueMember    = "idMotivoVinculacionArchivo";
            cboMotivoVinculacionArchivo.DisplayMember  = "cMotivoVinculacionArchivo";

        }

        
        public clsSustentoArchivoPagare obtenerSustentoVinculacionArchivo()
        {
            clsSustentoArchivoPagare objSustentoVinculacion = new clsSustentoArchivoPagare();

            objSustentoVinculacion.idSustentoArchivoPagare          = this.idSustentoVinculacionArchivo;
            objSustentoVinculacion.idSolicitud                      = this.idSolicitud;
            objSustentoVinculacion.idSolicitudGrupoSolidario        = this.idSolicitudGrupoSolidario;
            objSustentoVinculacion.lSuperaMontoExposicion           = this.lSuperaMontoExposicion;
            objSustentoVinculacion.idArchivo                        = this.idArchivo;
            objSustentoVinculacion.idTipoArchivo                    = this.idTipoArchivo;
            objSustentoVinculacion.idPagareCredito                  = this.idPagareCredito;
            objSustentoVinculacion.idMotivoVinculacionArchivo       = Convert.ToInt32(cboMotivoVinculacionArchivo.SelectedValue);
            objSustentoVinculacion.cComentario                      = txtDescripcionVinculacionArchivo.Text;
            objSustentoVinculacion.idAccionVinculacionArchivo       = this.idAccionVinculacionArchivo;
            objSustentoVinculacion.idEstadoSolicitud                = this.idEstadoSolicitud;
            objSustentoVinculacion.idEstado                         = 1;
            objSustentoVinculacion.dFechaRegistro                   = clsVarGlobal.dFecSystem;
            objSustentoVinculacion.lVigente                         = true;
            return objSustentoVinculacion;
        }
        #endregion

        private void frmSustentoVinculacionArchivo_Load(object sender, EventArgs e)
        { 

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            objSustentoVinculacionArchivo = obtenerSustentoVinculacionArchivo();
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            objSustentoVinculacionArchivo = new clsSustentoArchivoPagare();
            this.Dispose();
        }
    }
}
