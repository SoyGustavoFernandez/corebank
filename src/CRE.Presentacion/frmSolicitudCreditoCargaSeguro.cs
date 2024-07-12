#region Referencias
using System;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
#endregion

namespace CRE.Presentacion
{
    public partial class frmSolicitudCreditoCargaSeguro : frmBase
    {
        #region Variables
        public bool lValidoSeguros = true;
        public bool lCerrar = false;
        public clsSolicitudCreditoCargaSeguro objSolicitudCreditoCargaSeguro = new clsSolicitudCreditoCargaSeguro();
        #endregion

        public frmSolicitudCreditoCargaSeguro()
        {
            InitializeComponent();
        }

        public frmSolicitudCreditoCargaSeguro(clsSolicitudCreditoCargaSeguro _objSolicitudCreditoCargaSeguro)
        {
            InitializeComponent();
            this.conSolicitudCargaSeguros1.InicializaControl1(_objSolicitudCreditoCargaSeguro, Convert.ToInt32(clsVarApl.dicVarGen["nIdSeguroVida"]), Convert.ToInt32(clsVarApl.dicVarGen["nIdSeguroOncologico"]));
        }

        public frmSolicitudCreditoCargaSeguro(clsSolicitudCreditoCargaSeguro _objSolicitudCreditoCargaSeguro, int nParam)
        {
            InitializeComponent();
            this.conSolicitudCargaSeguros1.InicializaControl2(_objSolicitudCreditoCargaSeguro, nParam, true, Convert.ToInt32(clsVarApl.dicVarGen["nIdSeguroVida"]), Convert.ToInt32(clsVarApl.dicVarGen["nIdSeguroOncologico"]));
        }

        public frmSolicitudCreditoCargaSeguro(clsSolicitudCreditoCargaSeguro _objSolicitudCreditoCargaSeguro, bool _linvocadoDesdeSimulador, bool _desgravamenSimulador)
        {
            InitializeComponent();
            this.conSolicitudCargaSeguros1.InicializaControl3(_objSolicitudCreditoCargaSeguro, true, Convert.ToInt32(clsVarApl.dicVarGen["nIdSeguroVida"]), Convert.ToInt32(clsVarApl.dicVarGen["nIdSeguroOncologico"]), _linvocadoDesdeSimulador, _desgravamenSimulador);
        }

        #region Eventos
        private void frmSolicitudCreditoCargaSeguro_Load(object sender, EventArgs e)
        {
            #region PlanesDeSeguro
            conSolicitudCargaSeguros1.PintarPlanesDeSeguro();
            #endregion
            #region SegurosOncologicos
            conSolicitudCargaSeguros1.SalirClicked += cerrarFormularioActual;
            conSolicitudCargaSeguros1.AceptarClicked += cerrarFormularioActual;
            conSolicitudCargaSeguros1.ValidarSegurosQueNoSePuedenMarcar();
            conSolicitudCargaSeguros1.ValidarSeguroActivo();
            #endregion
        }

        private void frmSolicitudCreditoCargaSeguro_FormClosing(object sender, FormClosingEventArgs e)
        {
            objSolicitudCreditoCargaSeguro = conSolicitudCargaSeguros1.objSolicitudCreditoCargaSeguro;
            lValidoSeguros = conSolicitudCargaSeguros1.lValidoSeguros;
            if (!this.lCerrar)
            {
                e.Cancel = true;
                return;
            }
        }
        #endregion

        #region Metodos
        private void cerrarFormularioActual(object sender, EventArgs e)
        {
            this.lCerrar = true;
            this.Dispose();
        }

        public void ActualizarParametroAprobado()
        {
            conSolicitudCargaSeguros1.ActualizarParametroAprobado();
        }

        public void EnvioDatos()
        {
            conSolicitudCargaSeguros1.EnvioDatos();
        }
        #endregion
    }
}