#region Referencias
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAJ.CapaNegocio;
using GEN.ControlesBase;
using EntityLayer;
using GEN.CapaNegocio;
using eEstadoSolicitud = CAJ.CapaNegocio.eEstadoSolicitud;
#endregion Referencias

namespace GEN.ControlesBase
{
    public partial class frmControlLimitesBoveda : frmBase
    {
        struct MensajesForm
        {
            public static string MSJ_LIM_1 = "Se encuentra próximo a superar el límite de efectivo en bóveda {0}, se recomienda coordinar los desembolsos y retiros, cancelaciones, o, proceder con remesar exceso";
            public static string MSJ_LIM_2 = "Usted ha superado el límite de efectivo en bóveda {0}, proceda con remesar exceso";
            public static string MSJ_LIM_3 = "Requiere gestionar efectivo {0}";
            public static string TIT_MSJ = "Control Límites Bóveda";
            public static string TIT_MEM = "MEMORANDUM RECOMENDACIÓN";
            public static string MSJ_NO_AUTAPR = "No te puedes aprobar a ti mismo, requieres solicitar de nuevo";
            public static string MSJ_APR = "Aprobado, puedes continuar";
            public static string MSJ_PS_90 = "Se pasó del 90% del límite establecido";
            public static string MSJ_SOL1 = "La solicitud {0} se realizó con éxito, espere la aprobación del Jefe de Oficina";
            public static string MSJ_SOL2 = "La solicitud {0} se realizó con éxito, espere la aprobación del Supervisor de Operaciones y Servicios";
            public static string MJS_ERR_1 = "Ocurrió un error en base de datos al intentar realizar la solicitud, ";
            public static string MSJ_ERR_2 = "Ocurrió un error al intentar realizar la solicitud";
            public static string MSJ_SOL_1 = "Limite Sobrepasado, se envió solicitud para proceder con cierre";
            public static string MSJ_SOLIC_AV = "Aun no puede realizar el Cierre, Solicitud Nº {0} pendiente de aprobación";
            public static string MSJ_AUT_AUT1 = "Número de veces que se sobrepasó el límite en bóveda esta semana {0}, numero de memorándum recomendación {1}";
        }

        #region Variables
        public clsCNControlLimitesBoveda oBD = new clsCNControlLimitesBoveda();
        Boolean _lContinuar { get; set; }
        public Boolean lContinuar
        {
            get { return this._lContinuar; }
            set { 
                this._lContinuar = value;
                this.btnAceptar1.Enabled = value;
            }
        }
        public Boolean lActivado { get; set; }
        #endregion Variables

        #region Constructor
        public frmControlLimitesBoveda()
        {
            InitializeComponent();
            this.cboLimCierreBov.DataSource = this.oBD.listaMotivosCierreBoveda();
            this.cboLimCierreBov.DisplayMember = "cMotivo";
            this.cboLimCierreBov.ValueMember = "IdMotivoExt";
            this.lblSaldos.Text = "S/" + this.oBD.nSaldoSoles + " $" + this.oBD.nSaldoDolares;

            
            /** Comprueba si esta activo el control **/
            try
            {
                String cVal = Convert.ToString(clsVarApl.dicVarGen["lCajaCtrlLimCierreBov"]);
                this.lActivado = cVal == "1" ? true : false;
            }
            catch (Exception) 
            {
                this.lActivado = false;
            }
            if (!this.oBD.esResponsableBoveda())
            {
                this.lActivado = false;
            }
        }
        #endregion Constructor

        #region Metodos
        public static void mostrarNotificacionAprobador(Int32 idAgencia)
        {

            DataTable dtResult = (new clsCNControlLimitesBoveda()).resumenCtrlLimBov(idAgencia);
            String cNSolicitudes = dtResult.Rows.Count > 0 ? dtResult.Rows[0]["nCantidad"].ToString() : "0";
            String cNMemos = dtResult.Rows.Count > 0 ? dtResult.Rows[0]["nMemos"].ToString() : "0";
            MessageBox.Show(
                    String.Format(MensajesForm.MSJ_AUT_AUT1, cNSolicitudes, cNMemos),
                    MensajesForm.TIT_MSJ,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }
        public static Int32 obtenerIdTipoOperacionSolicitud()
        {
            try { return Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeCirrBovExc"]); }
            catch (Exception) { return -1; }
        }
        private void validarEstadoSolicitudCierreConExceso()
        {
            var nResEstSolBov = this.oBD.validarSolicitudAprobacionCierreBov();
            this.lContinuar = false;
            if ((new int[] { 1, 2, 3 }).Contains<Int32>(Convert.ToInt16(nResEstSolBov.nEstado)))
            {
                this.cboLimCierreBov.SelectedValue = nResEstSolBov.idMotivoExt;
                this.txtBase1.Text = nResEstSolBov.cSustento;
            }

            if ((new int[] { 1, 2 }).Contains<Int32>(Convert.ToInt16(nResEstSolBov.nEstado)))
            {
                this.grbBase1.Enabled = false;
                this.btnSolicitar1.Enabled = false;
            }

            if (nResEstSolBov.nEstado == eEstadoSolicitud.Solicitado)
            {
                MessageBox.Show(
                    String.Format(MensajesForm.MSJ_SOLIC_AV, nResEstSolBov.idSolicitud),
                    MensajesForm.TIT_MSJ,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            if (nResEstSolBov.nEstado == eEstadoSolicitud.Autoaprobado)
            {
                MessageBox.Show(
                    MensajesForm.MSJ_NO_AUTAPR,
                    MensajesForm.TIT_MSJ,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            if (nResEstSolBov.nEstado == eEstadoSolicitud.Aprobado)
            {
                MessageBox.Show(MensajesForm.MSJ_APR,
                    MensajesForm.TIT_MSJ,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.lContinuar = true;
            }
        }
        public void comprobarLimiteBovedaEnMoneda(Int32 idMoneda)
        {
            String cMoneda = idMoneda == 2 ? "en dolares" : "en soles";
            if (this.oBD.saldoMoneda(idMoneda) > this.oBD.porcentajeLimite(100, idMoneda))
            {
                MessageBox.Show(
                    String.Format(MensajesForm.MSJ_LIM_2, cMoneda),
                    MensajesForm.TIT_MSJ,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (this.oBD.saldoMoneda(idMoneda) > this.oBD.porcentajeLimite(90, idMoneda))
            {
                MessageBox.Show(
                    MensajesForm.TIT_MEM + " - " + String.Format(MensajesForm.MSJ_LIM_1, cMoneda),
                    MensajesForm.TIT_MSJ,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.oBD.GuardarIncidente(MensajesForm.MSJ_PS_90);
            }
            else if (this.oBD.saldoMoneda(idMoneda) > this.oBD.porcentajeLimite(80, idMoneda))
            {
                MessageBox.Show(
                        String.Format(MensajesForm.MSJ_LIM_1, cMoneda),
                        MensajesForm.TIT_MSJ,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
            else if (this.oBD.saldoMoneda(idMoneda) < this.oBD.porcentajeLimite(20, idMoneda))
            {
                MessageBox.Show(
                        String.Format(MensajesForm.MSJ_LIM_3, cMoneda),
                        MensajesForm.TIT_MSJ,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
        }
        public void comprobarLimiteBoveda()
        {
            if (!this.oBD.esResponsableBoveda() || !this.lActivado)
            {
                /** no es responsable de boveda **/
                return;
            }

            this.oBD.actualizarDatos();
            this.comprobarLimiteBovedaEnMoneda(1); // SOLES
            this.comprobarLimiteBovedaEnMoneda(2); // DOLARES
        }
        #endregion Metodos

        #region Eventos
        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            this.lContinuar = false;
            this.Close();
        }
        private void frmControlLimitesBoveda_Shown(object sender, EventArgs e)
        {
            if (this.lActivado)
                this.validarEstadoSolicitudCierreConExceso();
            else
            {
                this.lContinuar = true;
                this.Close();
            }
        }
        private void btnSolicitar1_Click(object sender, EventArgs e)
        {
            this.lContinuar = false;
            try
            {
                clsCNAprobacion oCNApr = new clsCNAprobacion();
                var dtResult = oCNApr.GuardarSolicitudAprobac(
                    clsVarGlobal.nIdAgencia,
                    clsVarGlobal.User.idCli,
                    Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeCirrBovExc"]),
                    1,
                    this.oBD.idMonedaPasoLimite(),
                    0,
                    this.oBD.montoDiferenciaLimite(this.oBD.idMonedaPasoLimite()),
                    0,
                    clsVarGlobal.dFecSystem,
                    Convert.ToInt32(this.cboLimCierreBov.SelectedValue),
                    this.txtBase1.Text,
                    1,
                    DateTime.Now,
                    clsVarGlobal.PerfilUsu.idUsuario,
                    0,
                    clsVarGlobal.User.idEstablecimiento, 
                    Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil)
                    );

                if (dtResult.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtResult.Rows[0]["idEstadoSol"]) == 1)
                    {
                        Int32 idSolicitud = Convert.ToInt32(dtResult.Rows[0]["idSolAproba"]);
                        this.oBD.GuardarIncidente(MensajesForm.MSJ_SOL_1, Convert.ToInt32(dtResult.Rows[0]["idSolAproba"]));
                        if (clsVarGlobal.PerfilUsu.idPerfil == 85) // JEFE DE OFICINA 
                        {
                            MessageBox.Show(
                                String.Format(MensajesForm.MSJ_SOL2, idSolicitud),
                                MensajesForm.TIT_MSJ,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                                );
                        }
                        else
                        {
                            MessageBox.Show(
                                String.Format(MensajesForm.MSJ_SOL1, idSolicitud),
                                MensajesForm.TIT_MSJ,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                                );
                        }
                        this.btnSolicitar1.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show(MensajesForm.MJS_ERR_1 + Convert.ToString(dtResult.Rows[0]["cMensaje"]));
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(MensajesForm.MSJ_ERR_2);
            }
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion Eventos
    }
}
