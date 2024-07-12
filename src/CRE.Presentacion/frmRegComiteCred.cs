using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using Microsoft.Reporting.WinForms;
using System.Data;
using System.Text;
using RPT.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmRegComiteCred : frmBase
    {
        #region Variables Globales
        private clsCNGestionObservaciones objCNGestionObservaciones = new clsCNGestionObservaciones();
        private clsComiteCred objComiteCredito = null;
        private clsCNComiteCreditos objCNComites = new clsCNComiteCreditos();
        private List<clsComiteCred> lstComiteCred;
        private BindingSource bsComiteCred;

        private const string cTituloMsjes = "Registro de comités.";
        private DateTime dFecMinValue = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
        private DateTime dFecMaxValue = System.Data.SqlTypes.SqlDateTime.MaxValue.Value;

        private clsComiteCreditoConfig objComiteCreditoConfig;
        private clsComiteCreditoSesion objComiteCreditoSesion;

        private clsAprobacionSolicitud objAprobacionSolicitud;

        private System.Timers.Timer objTimer;

        private int nIdcFilaComite, idSolic, idEtapaEvalCred;
        #endregion

        #region Metodos
        public frmRegComiteCred()
        {
            InitializeComponent();
            this.inicializarDatos();
        }
        private void inicializarDatos()
        {
            this.lstComiteCred = new List<clsComiteCred>();
            this.bsComiteCred = new BindingSource();
            this.bsComiteCred.DataSource = this.lstComiteCred;
            this.dtgComites.DataSource = this.bsComiteCred;

            this.nIdcFilaComite = -1;

            cboTipoComiteCred.CargarDatos();

            FormatearDataGridView();

            dtpFecIni.Value = clsVarGlobal.dFecSystem.Date;
            dtpFecFin.Value = clsVarGlobal.dFecSystem.Date;
            chcTodos.Checked = false;

            this.objComiteCreditoConfig = new clsComiteCreditoConfig();
            this.objComiteCreditoSesion = new clsComiteCreditoSesion();

            this.objAprobacionSolicitud = new clsAprobacionSolicitud();

            dtgParticipantes.DataSource = new List<clsUsuComite>();
            dtgEvaluaciones.DataSource = new List<clsEvalCredComite>();

            FormatColumnasEvaluaciones();
            FormatColumnasParticipantes();
        }
        private void habilitarControles(int idAccion)
        {
            switch (idAccion)
            {
                case clsAcciones.DEFECTO:
                    this.tsmQuiComiteCredito.Enabled = false;
                    this.btnNuevo.Enabled = true;
                    this.btnIniciar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnFinalizar.Enabled = false;
                    this.btnActaAprob.Enabled = false;
                    this.tsmAbrirEval.Enabled = false;
                    break;
                case clsAcciones.CONTINUAR:
                    this.limpiarTiemposSesion();
                    this.tsmQuiComiteCredito.Enabled = (this.objComiteCredito.idEstado == 1); //Creado
                    this.btnIniciar.Enabled = (this.objComiteCredito.idEstado == 1);
                    this.btnEditar.Enabled = (this.objComiteCredito.idEstado == 1);
                    this.btnFinalizar.Enabled = (this.objComiteCredito.idEstado == 2);        //Iniciado
                    this.btnNuevo.Enabled = (this.objComiteCredito.idEstado.In(3));//Finalizado
                    this.btnActaAprob.Enabled = (this.objComiteCredito.idEstado == 3);  // Finalizado
                    this.tsmAbrirEval.Enabled = (this.objComiteCredito.idEstado == 2);  // Iniciado
                    this.tsmActualizar.Enabled = true;
                    break;
                case clsAcciones.GRABAR:
                    this.tsmQuiComiteCredito.Enabled = true;
                    this.btnIniciar.Enabled = true;
                    this.btnEditar.Enabled = true;
                    this.btnFinalizar.Enabled = false;
                    this.btnActaAprob.Enabled = false;
                    this.tsmAbrirEval.Enabled = false;
                    break;
                case clsAcciones.INICIAR:
                    this.tsmQuiComiteCredito.Enabled = false;
                    this.btnIniciar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnFinalizar.Enabled = true;
                    this.btnActaAprob.Enabled = false;
                    this.tsmAbrirEval.Enabled = true;
                    break;
                case clsAcciones.FINALIZAR:
                    this.tsmQuiComiteCredito.Enabled = false;
                    this.btnIniciar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnFinalizar.Enabled = false;
                    this.btnActaAprob.Enabled = true;
                    this.tsmAbrirEval.Enabled = false;
                    break;
                case clsAcciones.NUEVO:
                    this.tsmQuiComiteCredito.Enabled = false;
                    this.btnIniciar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnFinalizar.Enabled = false;
                    this.btnActaAprob.Enabled = false;
                    this.tsmAbrirEval.Enabled = false;
                    break;
                case clsAcciones.CANCELAR:
                    this.tsmQuiComiteCredito.Enabled = false;
                    this.btnIniciar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnFinalizar.Enabled = false;
                    this.btnActaAprob.Enabled = false;
                    this.tsmAbrirEval.Enabled = false;
                    break;
                case clsAcciones.VISTA:
                    this.tsmQuiComiteCredito.Enabled = false;
                    this.btnIniciar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnFinalizar.Enabled = false;
                    this.btnActaAprob.Enabled = false;
                    this.tsmAbrirEval.Enabled = false;
                    break;
            }
        }

        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                MessageBox.Show("Ingrese el nombre del comité.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarControles()
        {
            txtNombre.Text = String.Empty;
            cboTipoComiteCred.SelectedValue = 1;
        }

        private void HabilitarBotonesSegunModo(int nModo)
        {
            if (nModo == clsAcciones.NUEVO)
            {
                this.btnActualizar.Enabled = false;
                this.btnIniciar.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnGrabar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnEliLista.Enabled = false;

                this.dtgComites.Enabled = false;
                this.dtpFecIni.Enabled = false;
                this.dtpFecFin.Enabled = false;
                this.chcTodos.Enabled = false;
                this.btnBusqComite.Enabled = false;

                this.txtNombre.Enabled = true;
                this.cboTipoComiteCred.Enabled = true;
                this.tsmAsignarPresidente.Enabled = false;
                this.tsmAgrParticipantes.Enabled = true;
                this.tsmQuiParticipantes.Enabled = true;
                this.tsmAgrEvaluaciones.Enabled = true;
                this.tsmQuiEvaluaciones.Enabled = true;
                this.tsmActualizar.Enabled = false;


                this.btnActaAprob.Enabled = false;
            }
            else if (nModo == clsAcciones.EDITAR)
            {
                this.btnActualizar.Enabled = false;
                this.btnIniciar.Enabled = false;
                this.btnNuevo.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnGrabar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnEliLista.Enabled = false;

                this.dtgComites.Enabled = false;
                this.dtpFecIni.Enabled = false;
                this.dtpFecFin.Enabled = false;
                this.chcTodos.Enabled = false;
                this.btnBusqComite.Enabled = false;

                this.txtNombre.Enabled = true;
                this.cboTipoComiteCred.Enabled = true;
                this.tsmAsignarPresidente.Enabled = false;
                this.tsmAgrParticipantes.Enabled = true;
                this.tsmQuiParticipantes.Enabled = true;
                this.tsmAgrEvaluaciones.Enabled = true;
                this.tsmQuiEvaluaciones.Enabled = true;
                this.tsmActualizar.Enabled = true;

                this.btnActaAprob.Enabled = false;
            }
            else if (nModo == clsAcciones.GRABAR)
            {
                this.btnActualizar.Enabled = true;
                this.btnIniciar.Enabled = true;
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnEliLista.Enabled = true;

                this.dtgComites.Enabled = true;
                this.dtpFecIni.Enabled = true;
                this.dtpFecFin.Enabled = true;
                this.chcTodos.Enabled = true;
                this.btnBusqComite.Enabled = true;

                this.txtNombre.Enabled = false;
                this.cboTipoComiteCred.Enabled = false;
                this.tsmAsignarPresidente.Enabled = false;
                this.tsmAgrParticipantes.Enabled = false;
                this.tsmQuiParticipantes.Enabled = false;
                this.tsmAgrEvaluaciones.Enabled = false;
                this.tsmQuiEvaluaciones.Enabled = false;
                this.tsmActualizar.Enabled = true;


                this.btnActaAprob.Enabled = false;
            }
            else if (nModo == clsAcciones.CANCELAR)
            {
                this.btnActualizar.Enabled = true;
                this.btnIniciar.Enabled = false;
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnEliLista.Enabled = true;

                this.dtgComites.Enabled = true;
                this.dtpFecIni.Enabled = true;
                this.dtpFecFin.Enabled = true;
                this.chcTodos.Enabled = true;
                this.btnBusqComite.Enabled = true;

                this.txtNombre.Enabled = false;
                this.cboTipoComiteCred.Enabled = false;
                this.tsmAsignarPresidente.Enabled = false;
                this.tsmAgrParticipantes.Enabled = false;
                this.tsmQuiParticipantes.Enabled = false;
                this.tsmAgrEvaluaciones.Enabled = false;
                this.tsmQuiEvaluaciones.Enabled = false;
                this.tsmActualizar.Enabled = false;


                this.btnActaAprob.Enabled = false;
            }
            else if(nModo == clsAcciones.FINALIZAR)
            {
                this.btnActualizar.Enabled = true;
                this.btnIniciar.Enabled = false;
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnGrabar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnEliLista.Enabled = true;

                this.dtgComites.Enabled = true;
                this.dtpFecIni.Enabled = true;
                this.dtpFecFin.Enabled = true;
                this.chcTodos.Enabled = true;
                this.btnBusqComite.Enabled = true;

                this.txtNombre.Enabled = false;
                this.cboTipoComiteCred.Enabled = false;
                this.tsmAsignarPresidente.Enabled = false;
                this.tsmAgrParticipantes.Enabled = false;
                this.tsmQuiParticipantes.Enabled = false;
                this.tsmAgrEvaluaciones.Enabled = false;
                this.tsmQuiEvaluaciones.Enabled = false;
                this.tsmActualizar.Enabled = false;

                this.btnActaAprob.Enabled = true;
            }

            this.btnFinalizar.Enabled = false;
            this.tsmAbrirEval.Enabled = false;
        }

        private bool ValidaInicio()
        {
            int nMinParticipComite = 0;
            nMinParticipComite = Convert.ToInt32(clsVarApl.dicVarGen["nMinParticipComite"]);
            string nCargosAsesoresCreditos = clsVarApl.dicVarGen["nCargosAsesoresCreditos"];

            if (dtgEvaluaciones.RowCount <= 0)
            {
                MessageBox.Show("Agregue por lo menos una evaluación al comité.", cTituloMsjes,
                                                                                    MessageBoxButtons.OK,
                                                                                    MessageBoxIcon.Warning);
                return false;
            }

            string[] cCargosAsesores = nCargosAsesoresCreditos.Split(',');
            int[] nCargosAsesores = Array.ConvertAll(cCargosAsesores, int.Parse);

            int nNumAsesores = this.objComiteCredito.lstParticipantes.Count(x => x.idCargo.In(nCargosAsesores));

            if (nNumAsesores < nMinParticipComite)
            {
                MessageBox.Show("El comité tiene que tener como mínimo " + nMinParticipComite
                                + " asesores para iniciar.", cTituloMsjes,
                                                                MessageBoxButtons.OK,
                                                                MessageBoxIcon.Warning);
                return false;
            }


            var lstAsesoresNoParticipantes = this.objComiteCredito.lstEvalCred
                                                        .Where(x => x.idAsesor != 0)
                                                        .Select(x => x.idAsesor)
                                                        .Except(this.objComiteCredito.lstParticipantes.Select(x => x.idUsuario))
                                                        .Select(x => new { idAsesor = x }).ToList();

            if (lstAsesoresNoParticipantes.Any())
            {
                StringBuilder cAsesores = new StringBuilder();
                var enumAsesores = this.objComiteCredito.lstEvalCred.Join(lstAsesoresNoParticipantes,
                                                    x => x.idAsesor, y => y.idAsesor,
                                    (x, y) => new { x.idAsesor, x.cAsesor }).Distinct();
                foreach (var asesor in enumAsesores)
                {
                    cAsesores.Append(String.Format("{0}\n", asesor.cAsesor));
                }

                MessageBox.Show("Debe agregar a los siguientes asesores:\n" + cAsesores, cTituloMsjes,
                                                                                            MessageBoxButtons.OK,
                                                                                            MessageBoxIcon.Warning);
                return false;
                //return true;
            }

            if (!this.objComiteCredito.lstParticipantes.Any(x => x.idUsuario == clsVarGlobal.User.idUsuario))
            {
                MessageBox.Show("El usuario no pertenece al comité.", cTituloMsjes,
                                                                      MessageBoxButtons.OK,
                                                                      MessageBoxIcon.Warning);
                return false;
            }

            if (this.objComiteCredito.lstParticipantes.Any(x => x.lInvitacion == true))
            {
                MessageBox.Show("Debe actualizar el estado de los participantes del comité.", cTituloMsjes,
                                                                                                 MessageBoxButtons.OK,
                                                                                                 MessageBoxIcon.Warning);
                return false;
            }

            if (this.objComiteCredito.lstParticipantes.Any(x => x.lConfirmAsis == false))
            {
                MessageBox.Show("Hay participantes virtuales que no aceptaron la invitación, debe retirarlos del comité.", cTituloMsjes,
                                                                                                                           MessageBoxButtons.OK,
                                                                                                                           MessageBoxIcon.Warning);
                return false;
            }

            if (this.objComiteCredito.idUsuPreside == null)
            {
                MessageBox.Show("Debe elegir al usuario que presidirá el comite antes de iniciar.", cTituloMsjes,
                                                                                                    MessageBoxButtons.OK,
                                                                                                    MessageBoxIcon.Warning);
                return false;
            }

            /*if (this.objComiteCredito.lstParticipantes.Count(x => !(x.lConfirmAsis) && x.idTipoParticip == 1) > 0)
            {
                MessageBox.Show("Todos los participantes deben de confirmar su asistencia para iniciar el comite.", cTituloMsjes,
                                                                                                                    MessageBoxButtons.OK,
                                                                                                                    MessageBoxIcon.Warning);
                return false;
            }*/

            if (this.objComiteCredito.idEstado == 1 && this.objComiteCredito.idUsuPreside != clsVarGlobal.User.idUsuario)
            {
                MessageBox.Show("No puede iniciar comité. El usuario seleccionado no puede ser el presidente del comité"
                                    , cTituloMsjes,
                                                                            MessageBoxButtons.OK,
                                                                            MessageBoxIcon.Warning);
                return false;
            }

            if (!this.objComiteCredito.idEstado.In(1, 2))
            {
                MessageBox.Show("Estado de comité inválido. No se puede iniciar el comité.", cTituloMsjes,
                                                                                            MessageBoxButtons.OK,
                                                                                            MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public bool validaFin(bool lSesionExpirada)
        {
            //var objComiteCredito = dtgComites.SelectedRows[0].DataBoundItem as clsComiteCred;
            if (lSesionExpirada && this.gestionarTiempoSesionAdicional(false))
            {
                return false;
            }

            if (!lSesionExpirada && objComiteCredito.lstEvalCred.Any(x => (x.idEtapaEvalCred == 4 && (x.idEstadoEvalCred == 2 || x.idEstadoEvalCred == 10)) && x.idResultado == 1))
            {
                MessageBox.Show("Existen créditos sin decisión. No se puede finalizar el comité.", cTituloMsjes,
                                                                                            MessageBoxButtons.OK,
                                                                                            MessageBoxIcon.Warning);
                return false;
            }
            if (!lSesionExpirada && objComiteCredito.lstEvalCred.Any((x => x.idResultado == 3)))
            {
                DialogResult result = MessageBox.Show("Existen créditos en ajuste. ¿Está seguro de finalizar el comité?.", cTituloMsjes,
                                                                                                                        MessageBoxButtons.YesNo,
                                                                                                                        MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return false;
            }
            else if (!lSesionExpirada)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de finalizar el comité?.", cTituloMsjes,
                                                                                            MessageBoxButtons.YesNo,
                                                                                            MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return false;
            }

            return true;
        }

        private void BuscarComites()
        {
            this.lstComiteCred.Clear();
            this.lstComiteCred.AddRange(objCNComites.CNGetComitesCred(0, (chcTodos.Checked ? 0 : clsVarGlobal.nIdAgencia), dtpFecIni.Value.Date, dtpFecFin.Value.Date));

            this.dtgComites.SelectionChanged -= dtgComites_SelectionChanged;
            this.bsComiteCred.ResetBindings(false);
            this.dtgComites.Refresh();
            this.dtgComites.ClearSelection();
            this.nIdcFilaComite = -1;
            this.dtgComites.SelectionChanged += dtgComites_SelectionChanged;

            HabilitarBotonesSegunModo(clsAcciones.CANCELAR);
        }

        private void desplegarComiteCred()
        {
            if (this.objComiteCredito.idUsuarioReg != clsVarGlobal.User.idUsuario)
            {
                MessageBox.Show("El comite " + this.objComiteCredito.cNomComite + " solo puede ser visualizado por el usuario que lo registró.\nPase a otro comite por favor", "APERTURA DENEGADA", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                this.objComiteCredito = new clsComiteCred();
                this.objComiteCredito.lstParticipantes = new List<clsUsuComite>();
                this.objComiteCredito.lstEvalCred = new List<clsEvalCredComite>();

                dtgParticipantes.DataSource = this.objComiteCredito.lstParticipantes.ToList();
                dtgEvaluaciones.DataSource = this.objComiteCredito.lstEvalCred.ToList();
                return;
            }

            if (!this.objComiteCredito.lSesionIniciada && this.objComiteCredito.idEstado == 2)
            {
                DialogResult idResultadoMsg = MessageBox.Show("Este comité se encuentra en estado INICIADO, " +
                "si ingresa a revisarlo no se le permitirá salir hasta que lo finalice.\n\n" +
                "¿Desea ingresar a revisarlo?","CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (idResultadoMsg != DialogResult.Yes)
                {
                    return;
                }
            }

            this.txtNombre.Text = this.objComiteCredito.cNomComite;
            this.cboTipoComiteCred.SelectedValue = this.objComiteCredito.idTipoComiteCred;
            this.objComiteCredito.lstParticipantes = objCNComites.CNGetUsuComiteCred(this.objComiteCredito);    // Se obtiene de DB
            this.objComiteCredito.lstEvalCred = objCNComites.CNGetEvalComiteCred(this.objComiteCredito);        // Se obtiene de DB

            this.dtgParticipantes.DataSource = this.objComiteCredito.lstParticipantes.ToList();
            this.dtgEvaluaciones.DataSource = this.objComiteCredito.lstEvalCred.ToList();

            this.habilitarControles(clsAcciones.CONTINUAR);

            this.actualizarComiteVirtual();

            if (this.objComiteCredito.idEstado == 2)
            {
                this.recuperarComiteCreditoSesion();
            }
        }

        private void ValidarPerfil()
        {
            string[] cPerfilesJudicial = ((string)clsVarApl.dicVarGen["cPerfilComiteCredito"]).Split(',');

            if (!cPerfilesJudicial.Contains(clsVarGlobal.PerfilUsu.idPerfil.ToString()))
            {
                MessageBox.Show("Perfil no autorizado para efectuar Comité de Créditos", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
        }
        private void iniciarComiteCred()
        {
            if (!ValidaInicio())
                return;

            if (this.objComiteCredito.idEstado == 1)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de iniciar el comité?", cTituloMsjes,
                                                                                            MessageBoxButtons.YesNo,
                                                                                            MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return;
                }

                this.objComiteCredito.idEstado = 2;
                this.objComiteCredito.dFecIni = clsVarGlobal.dFecSystem.Date;
                this.objComiteCredito.dFecha = clsVarGlobal.dFecSystem.Date;
                this.objComiteCredito.idUsuario = clsVarGlobal.User.idUsuario;
                this.objComiteCredito.idUsuPreside = clsVarGlobal.User.idUsuario;
                this.objComiteCredito.idPerfilPreside = clsVarGlobal.PerfilUsu.idPerfil;

                clsRespuestaServidor objRespuestaServidor = objCNComites.CNIniciarComite(this.objComiteCredito);

                if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
                {
                    this.objComiteCreditoSesion = (clsComiteCreditoSesion)objRespuestaServidor.objDatos;
                    if (!(this.objComiteCreditoSesion != null) || this.objComiteCreditoSesion.idComiteCreditoSesion <= 0)
                    {
                        MessageBox.Show("No ha sido posible identificar los datos de sesión de este comité.", "SESION NO IDENTIFICADA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    this.objComiteCreditoSesion.objComiteCreditoConfig = (clsComiteCreditoConfig)this.objComiteCreditoConfig.Clone();
                    this.objComiteCreditoSesion.lValidoParaAmpliacion = (this.objComiteCreditoConfig.nMontoMinReqAmpTiempo <= this.objComiteCredito.lstEvalCred.Max(x=>x.nMontoProp));

                    frmComiteCredSesionMensaje objFrmMensaje = new frmComiteCredSesionMensaje(objRespuestaServidor.cMensaje +
                        "\nEl tiempo restante de sesión para este comité es: " + (new TimeSpan(0, this.objComiteCreditoSesion.nTiempoRestante, 0)).ToString("T") + ". " +
                        "\n\n Ahora puede continuar, seleccione una evaluación y haga click en DECISIÓN", "INFORMACION DE SESION", 20,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    objFrmMensaje.ShowDialog();

                    this.finalizarComiteCreditoSesion();
                    this.iniciarComiteCreditoSesion();
                    this.habilitarControles(clsAcciones.INICIAR);

                    this.dtgComites.SelectionChanged -= dtgComites_SelectionChanged;
                    this.objComiteCredito.idEstado = 2; //INICIADO
                    this.bsComiteCred.ResetBindings(false);
                    this.dtgComites.Refresh();
                    this.dtgComites.Rows[this.nIdcFilaComite].Selected = true;
                    this.dtgComites.SelectionChanged += dtgComites_SelectionChanged;
                    /*dtgComites.Refresh();
                    dtgComites_SelectionChanged(dtgComites, new EventArgs());*/
                }
                else
                {
                    this.objComiteCredito.idEstado = 1;
                    MessageBox.Show(objRespuestaServidor.cMensaje, cTituloMsjes,
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error);
                }
            }
        }
        private void finalizarComiteCred()
        {
            objComiteCredito.idEstado = 3;
            objComiteCredito.dFecha = clsVarGlobal.dFecSystem.Date;
            objComiteCredito.idUsuario = clsVarGlobal.User.idUsuario;

            clsDBResp objDbResp = objCNComites.CNFinalizaComite(objComiteCredito);

            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //dtgComites.Refresh();
                this.finalizarComiteCreditoSesion();
                HabilitarBotonesSegunModo(clsAcciones.FINALIZAR);
                this.habilitarControles(clsAcciones.FINALIZAR);

                this.dtgComites.SelectionChanged -= dtgComites_SelectionChanged;
                this.objComiteCredito.idEstado = 3; //FINALIZADO
                this.bsComiteCred.ResetBindings(false);
                this.dtgComites.Refresh();
                this.dtgComites.Rows[this.nIdcFilaComite].Selected = true;
                this.dtgComites.SelectionChanged += dtgComites_SelectionChanged;
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void actualizarComiteVirtual() 
        {
            this.objComiteCredito.lstParticipantes = objCNComites.CNGetUsuComiteCred(this.objComiteCredito);

            this.dtgParticipantes.DataSource = this.objComiteCredito.lstParticipantes.ToList();

            foreach (DataGridViewRow row in this.dtgParticipantes.Rows)
            {
                if ((bool)row.Cells["lInvitacion"].Value == false && (Int32)row.Cells["idTipoParticip"].Value == 3)
                {
                    if ((bool)row.Cells["lConfirmAsis"].Value == false)
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                    }
                }
            }
        }

        private void asignarPresidenteComite()
        {
            GEN.CapaNegocio.clsCNUsuComite objCNUsuComite = new GEN.CapaNegocio.clsCNUsuComite();

            DataTable dtRes = objCNUsuComite.CNBuscarUsuarioExoneradoLoginComiteCred(Convert.ToString(clsVarGlobal.User.cWinUser));
            bool lUsuAutBiometrico = false;
            if (dtRes.Rows.Count == 0) //cliente no exonerado
            {
                frmCredenciales frmCred = new frmCredenciales(false, clsVarGlobal.User.lAutBiometricaComite);
                frmCred.cWinUser = Convert.ToString(clsVarGlobal.User.cWinUser);
                frmCred.ShowDialog();

                if (!frmCred.lValido)
                {
                    MessageBox.Show("No se ha ingresado las credenciales del participante, no se puede crear un nuevo comité de créditos.", "Nuevo Comité", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    this.finalizarComiteCreditoSesion();
                    LimpiarControles();
                    HabilitarBotonesSegunModo(clsAcciones.CANCELAR);
                    this.dtgComites.Focus();

                    return;
                }
                lUsuAutBiometrico = frmCred.lUsuAutBiometrico;
            }

            DataTable dtPer = objCNUsuComite.CNBusPersonalComite("3", Convert.ToString(clsVarGlobal.User.idUsuario));
            clsUsuComite objUsuComite = new clsUsuComite();
            if (dtPer.Rows.Count > 0)
            {
                objUsuComite.idUsuario = Convert.ToInt32(dtPer.Rows[0]["idUsuario"]);
                objUsuComite.cNombre = Convert.ToString(dtPer.Rows[0]["cNombre"]);
                objUsuComite.idCargo = Convert.ToInt32(dtPer.Rows[0]["idCargo"]);
                objUsuComite.idTipoParticip = 1;
                objUsuComite.cTipoParticip = "PRESENCIAL";
                objUsuComite.lConfirmAsis = true;
                objUsuComite.lAutenticacionBiometrica = lUsuAutBiometrico;
                objUsuComite.lPresideComite = true;

                this.objComiteCredito.idPerfilPreside = clsVarGlobal.PerfilUsu.idPerfil;

                this.objComiteCredito.idUsuPreside = clsVarGlobal.User.idUsuario;
                this.objComiteCredito.idUsuarioReg = clsVarGlobal.User.idUsuario;

                this.objComiteCredito.lstParticipantes.Add(objUsuComite);
                this.dtgParticipantes.DataSource = this.objComiteCredito.lstParticipantes.ToList();

            }
            else
            {
                objUsuComite = null;
            }
        }
        #region Formatear Columnas 
        private void FormatColumnasComiteCredito()
        {
            foreach (DataGridViewColumn column in this.dtgComites.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgComites.Columns["idComiteCred"].DisplayIndex = 0;
            dtgComites.Columns["cNomComite"].DisplayIndex = 1;
            dtgComites.Columns["cEstComiteCred"].DisplayIndex = 2;
            dtgComites.Columns["dFecha"].DisplayIndex = 3;
            dtgComites.Columns["nNumEval"].DisplayIndex = 4;
            dtgComites.Columns["cDuracion"].DisplayIndex = 5;

            dtgComites.Columns["idComiteCred"].Visible = true;
            dtgComites.Columns["cNomComite"].Visible = true;
            dtgComites.Columns["cEstComiteCred"].Visible = true;
            dtgComites.Columns["dFecha"].Visible = true;
            dtgComites.Columns["nNumEval"].Visible = true;
            dtgComites.Columns["cDuracion"].Visible = true;

            dtgComites.Columns["idComiteCred"].HeaderText = "Cod";
            dtgComites.Columns["cNomComite"].HeaderText = "Nombre";
            dtgComites.Columns["cEstComiteCred"].HeaderText = "Estado";
            dtgComites.Columns["dFecha"].HeaderText = "Fecha Registro";
            dtgComites.Columns["nNumEval"].HeaderText = "Nro Eval";
            dtgComites.Columns["cDuracion"].HeaderText = "Duración";

            dtgComites.Columns["idComiteCred"].FillWeight = 30;
            dtgComites.Columns["cNomComite"].FillWeight = 70;
            dtgComites.Columns["cEstComiteCred"].FillWeight = 40;
            dtgComites.Columns["dFecha"].FillWeight = 45;
            dtgComites.Columns["nNumEval"].FillWeight = 20;
            dtgComites.Columns["cDuracion"].FillWeight = 35;

            dtgComites.Columns["idComiteCred"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgComites.Columns["dFecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgComites.Columns["nNumEval"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgComites.Columns["cDuracion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void FormatColumnasEvaluaciones()
        {
            foreach (DataGridViewColumn column in this.dtgEvaluaciones.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            this.dtgEvaluaciones.Columns["idEval"].DisplayIndex = 0;
            this.dtgEvaluaciones.Columns["cNombre"].DisplayIndex = 1;
            this.dtgEvaluaciones.Columns["cProducto"].DisplayIndex = 2;
            this.dtgEvaluaciones.Columns["nMontoProp"].DisplayIndex = 3;
            this.dtgEvaluaciones.Columns["cEstado"].DisplayIndex = 4;
            this.dtgEvaluaciones.Columns["cResultado"].DisplayIndex = 5;

            this.dtgEvaluaciones.Columns["idEval"].Visible = true;
            this.dtgEvaluaciones.Columns["cNombre"].Visible = true;
            this.dtgEvaluaciones.Columns["cProducto"].Visible = true;
            this.dtgEvaluaciones.Columns["nMontoProp"].Visible = true;
            this.dtgEvaluaciones.Columns["cEstado"].Visible = true;
            this.dtgEvaluaciones.Columns["cResultado"].Visible = true;

            this.dtgEvaluaciones.Columns["idEval"].HeaderText = "N°";
            this.dtgEvaluaciones.Columns["cNombre"].HeaderText = "Cliente";
            this.dtgEvaluaciones.Columns["cProducto"].HeaderText = "Producto";
            this.dtgEvaluaciones.Columns["nMontoProp"].HeaderText = "Monto Sol.";
            this.dtgEvaluaciones.Columns["cEstado"].HeaderText = "Estado";
            this.dtgEvaluaciones.Columns["cResultado"].HeaderText = "Resultado";

            this.dtgEvaluaciones.Columns["idEval"].FillWeight = 25;
            this.dtgEvaluaciones.Columns["cNombre"].FillWeight = 90;
            this.dtgEvaluaciones.Columns["cProducto"].FillWeight = 45;
            this.dtgEvaluaciones.Columns["nMontoProp"].FillWeight = 27;
            this.dtgEvaluaciones.Columns["cEstado"].FillWeight = 30;
            this.dtgEvaluaciones.Columns["cResultado"].FillWeight = 30;

            this.dtgEvaluaciones.Columns["idEval"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgEvaluaciones.Columns["nMontoProp"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dtgEvaluaciones.Columns["nMontoProp"].DefaultCellStyle.Format = "N0";
        }

        private void FormatColumnasParticipantes()
        {
            foreach (DataGridViewColumn column in this.dtgParticipantes.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            this.dtgParticipantes.Columns["idUsuario"].DisplayIndex = 0;
            this.dtgParticipantes.Columns["cNombre"].DisplayIndex = 1;
            this.dtgParticipantes.Columns["cTipoParticip"].DisplayIndex = 2;
            this.dtgParticipantes.Columns["lPresideComite"].DisplayIndex = 3;
            //this.dtgParticipantes.Columns["lConfirmAsis"].DisplayIndex = 4;

            this.dtgParticipantes.Columns["idUsuario"].Visible = true;
            this.dtgParticipantes.Columns["cNombre"].Visible = true;
            this.dtgParticipantes.Columns["cTipoParticip"].Visible = true;
            this.dtgParticipantes.Columns["lPresideComite"].Visible = true;
            //this.dtgParticipantes.Columns["lConfirmAsis"].Visible = true;

            this.dtgParticipantes.Columns["idUsuario"].HeaderText = "Cod.";
            this.dtgParticipantes.Columns["cNombre"].HeaderText = "Nombre";
            this.dtgParticipantes.Columns["cTipoParticip"].HeaderText = "Tip. Particip.";
            this.dtgParticipantes.Columns["lPresideComite"].HeaderText = "Preside?";
            //this.dtgParticipantes.Columns["lConfirmAsis"].HeaderText = "Confirmado?";

            this.dtgParticipantes.Columns["idUsuario"].FillWeight = 30;
            this.dtgParticipantes.Columns["cNombre"].FillWeight = 200;
            this.dtgParticipantes.Columns["cTipoParticip"].FillWeight = 75;
            this.dtgParticipantes.Columns["lPresideComite"].FillWeight = 35;

            this.dtgParticipantes.Columns["idUsuario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void FormatearDataGridView()
        {
            this.dtgComites.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgComites.Margin = new System.Windows.Forms.Padding(0);
            this.dtgComites.MultiSelect = false;
            this.dtgComites.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgComites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgComites.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgComites.RowHeadersVisible = false;
            this.dtgComites.ReadOnly = true;

            this.dtgEvaluaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgEvaluaciones.Margin = new System.Windows.Forms.Padding(0);
            this.dtgEvaluaciones.MultiSelect = false;
            this.dtgEvaluaciones.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgEvaluaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEvaluaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgEvaluaciones.RowHeadersVisible = false;
            this.dtgEvaluaciones.ReadOnly = true;

            this.dtgParticipantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgParticipantes.Margin = new System.Windows.Forms.Padding(0);
            this.dtgParticipantes.MultiSelect = false;
            this.dtgParticipantes.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgParticipantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgParticipantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgParticipantes.RowHeadersVisible = false;
            this.dtgParticipantes.ReadOnly = true;
        }
        private void resolverEvaluacionCredito()
        {
            if (this.dtgEvaluaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a tomar decisión.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.objComiteCredito.idEstado == 2)
            {
                clsEvalCredComite objEvalCredComite = (clsEvalCredComite)dtgEvaluaciones.SelectedRows[0].DataBoundItem;
                this.idEtapaEvalCred = objEvalCredComite.idEtapaEvalCred;
                this.idSolic = objEvalCredComite.idSolicitud;
                
                DataTable dtGrabarEstEvalCred = objCNComites.grabarEstadoEvalCred(objEvalCredComite.idEval, objEvalCredComite.idSolicitud, objComiteCredito.idComiteCred, true, true);

                this.finalizarComiteCreditoSesion();

                frmDecisionComiteCred frmDecisionComiteCred = new frmDecisionComiteCred(this.objComiteCredito, objEvalCredComite, this.objComiteCreditoSesion);
                frmDecisionComiteCred.ShowDialog();

                this.objComiteCredito.lstParticipantes = objCNComites.CNGetUsuComiteCred(this.objComiteCredito);    // Se obtiene de DB
                this.objComiteCredito.lstEvalCred = objCNComites.CNGetEvalComiteCred(this.objComiteCredito);        // Se obtiene de DB

                this.dtgParticipantes.DataSource = this.objComiteCredito.lstParticipantes.ToList();
                this.dtgEvaluaciones.DataSource = this.objComiteCredito.lstEvalCred.ToList();

                if (this.objComiteCreditoSesion.nTiempoRestante > 0)
                {
                    this.iniciarComiteCreditoSesion();
                }
                else
                {
                    if(this.validaFin(true))
                    this.finalizarComiteCred();
                }
                this.actualizarTiemposSesion();
            }
            else
            {
                MessageBox.Show("Para acceder al formulario de decisión el comité de crédito debe estar en estado INICIADO.",
                    "ACCION NO PERMITIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Sesion de Comite de Credito
        private void obtenerComiteCreditoConfig()
        {
            this.objComiteCreditoConfig = this.objCNComites.obtenerComiteCreditoConfig();
            if (this.objComiteCreditoConfig.idComiteCreditoConfig <= 0)
            {
                MessageBox.Show("¡La configuración de sesión de comités de crédito no fue encontrada!" +
                "\n\n* Este formulario será cerrado.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                this.desplegarHorarios();
            }
        }
        private void desplegarHorarios()
        {
            string cHorarios = string.Empty;
            int nTurno = 1;
            foreach (clsComiteCreditoHorario objHorario in this.objComiteCreditoConfig.lstComiteCreditoHorario)
            {
                TimeSpan tHora = objHorario.tHoraInicio;
                cHorarios += string.Concat("Comité ", nTurno, ":\t", tHora.Add(new TimeSpan(0, -this.objComiteCreditoConfig.nTiempoToleranciaPrev, 0)).ToString(@"hh\:mm"), " - ");

                tHora = objHorario.tHoraInicio;
                cHorarios += string.Concat(tHora.Add(new TimeSpan(0, this.objComiteCreditoConfig.nTiempoToleranciaPost, 0)).ToString(@"hh\:mm"), "\r\n");

                nTurno++;
            }
            this.txtHorariosApertura.Text = cHorarios;
        }
        private void recuperarComiteCreditoSesion()
        {
            this.objComiteCreditoSesion = this.objCNComites.recuperarComiteCreditoSesion(this.objComiteCredito.idComiteCred);
            if (this.objComiteCreditoSesion.idComiteCreditoSesion == 0)
            {
                MessageBox.Show("No se pudo recuperar la sesión del comité crédito " +
                this.objComiteCredito.cNomComite, "SESION DE COMITE INEXISTENTE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.habilitarControles(clsAcciones.DEFECTO);
            }
            else
            {
                this.objComiteCreditoSesion.objComiteCreditoConfig = (clsComiteCreditoConfig)this.objComiteCreditoConfig.Clone();
                this.objComiteCreditoSesion.lValidoParaAmpliacion = (this.objComiteCreditoConfig.nMontoMinReqAmpTiempo <= this.objComiteCredito.lstEvalCred.Max(x => x.nMontoProp));

                if (this.objComiteCreditoSesion.nTiempoRestante <= 0)
                {
                    MessageBox.Show("¡El tiempo de sesión del comité " +
                    this.objComiteCredito.cNomComite +
                    " ha EXPIRADO!" +
                    "\n\n*Se finalizará el comité, todos los créditos que no tengan una decisión serán devueltos a la etapa de evaluación.",
                    "SESION EXPIRADA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if(this.validaFin(true))
                    this.finalizarComiteCred();
                }
                else
                {
                    frmComiteCredSesionMensaje objFrmMensaje = new frmComiteCredSesionMensaje("Se ha recuperado la sesión del comité," +
                        " el tiempo restante de sesión para este comité es: " + (new TimeSpan(0, this.objComiteCreditoSesion.nTiempoRestante, 0)).ToString("T") + ". " +
                        "\n\n Ahora puede continuar, seleccione una evaluación y haga click en DECISIÓN", "INFORMACION DE SESION", 20,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    objFrmMensaje.ShowDialog();

                    this.finalizarComiteCreditoSesion();
                    this.iniciarComiteCreditoSesion();
                }
            }
        }
        private void iniciarTemporizador()
        {
            this.objTimer = new System.Timers.Timer();
            this.objTimer.Interval = 60000;
            this.objTimer.Elapsed += Timer_Elapsed;
            this.objTimer.Start();
        }
        private void finalizarComiteCreditoSesion()
        {
            if (this.objTimer != null)
            {
                this.objTimer.Close();
            }

            if(this.objComiteCreditoSesion.nTiempoRestante<0)
                this.objComiteCreditoSesion.nTiempoRestante = 0;

            this.actualizarTiemposSesion();

            if(this.objComiteCredito != null)
                this.objComiteCredito.lSesionIniciada = false;
        }

        private void iniciarComiteCreditoSesion()
        {
            this.actualizarTiemposSesion();
            this.iniciarTemporizador();
            this.objComiteCredito.lSesionIniciada = true;
        }
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!IsHandleCreated) return;
            Invoke(new MethodInvoker(delegate()
            {
                this.objComiteCreditoSesion.nTiempoRestante--;
                if (this.objComiteCreditoSesion.nTiempoRestante <= 0)
                {
                    this.finalizarComiteCreditoSesion();

                    if (this.validaFin(true))
                    {
                        MessageBox.Show("El tiempo de sesión del comité ha finalizado.\n\n" +
                        "*Se finalizará el comité, todos los créditos que no tengan una decisión serán devueltos a la etapa de evaluación.",
                        "TIEMPO AGOTADO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        this.finalizarComiteCred();
                    }
                }
                else if (
                    !this.objComiteCreditoSesion.lTiempoAmpliado &&
                    this.objComiteCreditoSesion.lValidoParaAmpliacion &&
                    this.objComiteCreditoSesion.nTiempoAlerta >= 0 &&
                    this.objComiteCreditoSesion.nTiempoRestante == this.objComiteCreditoSesion.nTiempoAlerta)
                {
                    frmComiteCredSesionMensaje objFrmMensaje = new frmComiteCredSesionMensaje("El comité de créditos se cerrará en " +
                        this.objComiteCreditoSesion.nTiempoAlerta + " minutos.\n\n" +
                        "¿Desea solicitar tiempo adicional?", "SESION DE COMITE", 20, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    objFrmMensaje.ShowDialog();
                    if (objFrmMensaje.idResultado == System.Windows.Forms.DialogResult.Yes)
                    {
                        frmComiteCreditoTiempoAdicional objFrmComiteCredTiempoAdd = new frmComiteCreditoTiempoAdicional(this.objComiteCreditoSesion.idComiteCred, false);
                        objFrmComiteCredTiempoAdd.Show();
                    }

                }
                this.lblTiempoRestante.Text = (new TimeSpan(0, this.objComiteCreditoSesion.nTiempoRestante, 0)).ToString(@"hh\:mm");
            }));
        }
        private void actualizarTiemposSesion()
        {
            this.lblEstado.Text = this.objComiteCreditoSesion.cEstado;
            this.lblHoraIniProg.Text = this.objComiteCreditoSesion.tHoraIniProg.ToString(@"hh\:mm");
            this.lblTiempoAmpliado.Text = this.objComiteCreditoSesion.tTiempoAmpliado.ToString(@"hh\:mm");
            this.lblHoraFinProg.Text = this.objComiteCreditoSesion.tHoraFinProg.ToString(@"hh\:mm");
            this.lblTiempoRestante.Text = (new TimeSpan(0, this.objComiteCreditoSesion.nTiempoRestante, 0)).ToString(@"hh\:mm");
        }
        private void limpiarTiemposSesion()
        {
            this.lblEstado.Text = "NINGUNO";
            this.lblHoraIniProg.Text = "00:00";
            this.lblTiempoAmpliado.Text = "00:00";
            this.lblHoraFinProg.Text = "00:00";
            this.lblTiempoRestante.Text = "00:00";
        }
        private void obtenerAprobacionSolicitud()
        {
            this.objAprobacionSolicitud = (new ADM.CapaNegocio.clsCNAprobacion()).obtenerAprobacionSolicitud((int)AprobacionSolicitudTipo.TiempoComiteCredito, this.objComiteCredito.idComiteCred);
        }
        private bool ejecutarAprobacionSolicitud()
        {
            clsRespuestaServidor objRespuestaServidor = (new ADM.CapaNegocio.clsCNAprobacion()).ejecutarAprobacionSolicitud((int)AprobacionSolicitudTipo.TiempoComiteCredito, this.objComiteCredito.idComiteCred);
            if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
            {
                MessageBox.Show(objRespuestaServidor.cMensaje, objRespuestaServidor.cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show(objRespuestaServidor.cMensaje,objRespuestaServidor.cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool expirarAprobacionSolicitud()
        {
            clsRespuestaServidor objRespuestaServidor = (new ADM.CapaNegocio.clsCNAprobacion()).expirarAprobacionSolicitud((int)AprobacionSolicitudTipo.TiempoComiteCredito, this.objComiteCredito.idComiteCred);
            if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
            {
                MessageBox.Show(objRespuestaServidor.cMensaje, objRespuestaServidor.cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show(objRespuestaServidor.cMensaje, objRespuestaServidor.cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool tiempoEsperaAmpliacionExpirado(bool lFinalizarComiteCred)
        {
            if (this.objComiteCreditoConfig.nTiempoEsperaAmpliacion < this.objAprobacionSolicitud.tAntiguedad.TotalMinutes)
            {
                frmComiteCredSesionMensaje objSesionMsg = new frmComiteCredSesionMensaje("Han transcurrido " +
                this.objAprobacionSolicitud.tAntiguedad.TotalMinutes.ToString("0") + " minutos desde que se solicitó la ampliación de tiempo, " +
                "Se ejecutaran las siguientes acciones:\n\n" +
                " 1.- La solicitud de ampliación de tiempo será marcada como EXPIRADA." +
                "\n 2.- El comité de crédito " + this.objComiteCredito.cNomComite + " será finalizado."
                , "TIEMPO DE ESPERA AGOTADO",20, MessageBoxButtons.OK, MessageBoxIcon.Error);

                objSesionMsg.ShowDialog();

                this.expirarAprobacionSolicitud();
                if(lFinalizarComiteCred)
                    this.finalizarComiteCred();
                return true;
            }

            return false;
        }
        private bool gestionarTiempoSesionAdicional(bool lFinalizarComiteCred)
        {
            this.obtenerAprobacionSolicitud();
            frmComiteCredSesionMensaje objSesionMsg;

            if (this.objAprobacionSolicitud.idAprobacionSolicitud > 0)
            {
                switch (this.objAprobacionSolicitud.idEstado)
                {
                    case (int)Estado.APROBADO:
                        if (this.tiempoEsperaAmpliacionExpirado(lFinalizarComiteCred))
                        {
                            return false;
                        }

                        objSesionMsg  = new frmComiteCredSesionMensaje("El comité " + this.objComiteCredito.cNomComite +
                            " tiene un tiempo de " + this.objAprobacionSolicitud.cValor + "(min) adicionales aprobado." +
                            "\n\n¿Desea utilizar dicho tiempo adicional para continuar con la sesión de comité?" +
                            "\n\n *Luego de iniciar el uso del tiempo adicional, se recomienda no cerrar este formulario, porque al cerrar este formulario no podrá volver a continuar con la sesión de este comité.",
                            "TIEMPO ADICIONAL APROBADO",20, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        objSesionMsg.ShowDialog();

                        if (objSesionMsg.idResultado == DialogResult.Yes)
                        {
                            if (this.ejecutarAprobacionSolicitud())
                            {
                                this.finalizarComiteCreditoSesion();

                                int nTiempoAmpliado = Convert.ToInt32(this.objAprobacionSolicitud.cValor);

                                this.objComiteCreditoSesion.nTiempoRestante += nTiempoAmpliado;
                                this.objComiteCreditoSesion.tTiempoAmpliado = new TimeSpan(0, nTiempoAmpliado, 0);
                                this.objComiteCreditoSesion.lTiempoAmpliado = true;

                                this.iniciarComiteCreditoSesion();
                                this.habilitarControles(clsAcciones.INICIAR);

                                this.objComiteCredito.idEstado = 2;
                                this.dtgComites.SelectionChanged -= dtgComites_SelectionChanged;
                                this.bsComiteCred.ResetBindings(false);
                                this.dtgComites.Refresh();
                                this.dtgComites.Rows[this.nIdcFilaComite].Selected = true;
                                this.dtgComites.SelectionChanged += dtgComites_SelectionChanged;

                                return true;
                            }
                        }
                        break;
                    case (int)Estado.DENEGADO:
                        objSesionMsg = new frmComiteCredSesionMensaje("La solicitud de " + this.objAprobacionSolicitud.cValor +
                            " (min) adicionales ha sido denegada.", "TIEMPO ADICIONAL DENEGADO",5, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        objSesionMsg.ShowDialog();
                        break;
                    case (int)Estado.REGISTRADO:
                        if (this.tiempoEsperaAmpliacionExpirado(lFinalizarComiteCred))
                        {
                            return false;
                        }


                        objSesionMsg = new frmComiteCredSesionMensaje("La solicitud de " + this.objAprobacionSolicitud.cValor +
                            " (min) adicionales aún se encuentra en estado SOLICITADO, requiere ser APROBADO para poder usar dicho tiempo." +
                            "\n\n ¿Desea esperar a que se apruebe su solicitud de ampliación de tiempo?" +
                            "\n\n *El comité " + this.objComiteCredito.cNomComite + " será BLOQUEADO.",
                            "SIN RESOLVER",20, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        objSesionMsg.ShowDialog();

                        if (objSesionMsg.idResultado == DialogResult.Yes)
                        {
                            this.finalizarComiteCreditoSesion();
                            clsRespuestaServidor objRespuestaServidor = this.objCNComites.bloquearComiteCred(this.objComiteCredito.idComiteCred);
                            if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
                            {
                                MessageBox.Show(objRespuestaServidor.cMensaje, objRespuestaServidor.cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.habilitarControles(clsAcciones.VISTA);
                                this.objComiteCredito.idEstado = 4;
                                this.dtgComites.SelectionChanged -= dtgComites_SelectionChanged;
                                this.bsComiteCred.ResetBindings(false);
                                this.dtgComites.Refresh();
                                this.dtgComites.Rows[this.nIdcFilaComite].Selected = true;
                                this.dtgComites.SelectionChanged += dtgComites_SelectionChanged;
                                return true;
                            }
                            else
                            {
                                MessageBox.Show(objRespuestaServidor.cMensaje, objRespuestaServidor.cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            clsRespuestaServidor objRespuestaServidor = (new ADM.CapaNegocio.clsCNAprobacion()).anularAprobacionSolicitud((int)AprobacionSolicitudTipo.TiempoComiteCredito, this.objComiteCredito.idComiteCred);
                            if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
                            {
                                objSesionMsg = new frmComiteCredSesionMensaje("La solicitud de " + this.objAprobacionSolicitud.cValor +
                                   " (min) adicionales ha sido ANULADA, el comité finalizará sin agregar ningún tiempo adicional.",
                                   objRespuestaServidor.cTitulo, 15, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                objSesionMsg.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show(objRespuestaServidor.cMensaje, objRespuestaServidor.cTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        break;
                    default:
                        objSesionMsg = new frmComiteCredSesionMensaje("La solicitud de " + this.objAprobacionSolicitud.cValor +
                            " (min) adicionales se encuentra en estado " + this.objAprobacionSolicitud.cEstado +
                            ", en dicho estado no es posible continuar la sesión de comité.",
                            "RESOLUCION",15, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        objSesionMsg.ShowDialog();
                        break;

                }
            }
            else
            {
                objSesionMsg = new frmComiteCredSesionMensaje("¡No se ha encontrado ninguna solicitud de ampliación de tiempo vigente!",
                    "NO EXISTE SOLICITUD",5, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                objSesionMsg.ShowDialog();
            }
            return false;

        }
        #endregion

        #endregion

        #region Eventos
        private void Form_Load(object sender, EventArgs e)
        {
            this.obtenerComiteCreditoConfig();
            BuscarComites();
            FormatColumnasComiteCredito();
        }

        #region DataGridView
        private void dtgComites_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgComites.SelectedRows.Count > 0)
            {
                this.nIdcFilaComite = this.dtgComites.SelectedRows[0].Index;
                if (this.objComiteCredito != null && this.objComiteCredito.lSesionIniciada && this.objComiteCredito.idEstado == 2)
                {
                    frmComiteCredSesionMensaje objFrmMensaje =
                        new frmComiteCredSesionMensaje("Se ha iniciado la sesión del comité " +
                            this.objComiteCredito.cNomComite +
                            ". No se le permitirá cambiar de comité hasta que finalice la sesión.",
                            "SESION INICIADA", 20, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    objFrmMensaje.ShowDialog();

                    this.nIdcFilaComite = lstComiteCred.FindIndex(x=>x.idComiteCred == this.objComiteCredito.idComiteCred);
                    if (this.nIdcFilaComite < 0 || this.nIdcFilaComite >= lstComiteCred.Count) return;
                    this.dtgComites.SelectionChanged -= dtgComites_SelectionChanged;
                    this.dtgComites.Rows[this.nIdcFilaComite].Selected = true;
                    this.dtgComites.SelectionChanged += dtgComites_SelectionChanged;
                    return;
                }

                this.objComiteCredito = this.lstComiteCred[this.nIdcFilaComite];

                this.objComiteCredito.lstParticipantes = new List<clsUsuComite>();
                this.objComiteCredito.lstEvalCred = new List<clsEvalCredComite>();

                dtgParticipantes.DataSource = this.objComiteCredito.lstParticipantes.ToList();
                dtgEvaluaciones.DataSource = this.objComiteCredito.lstEvalCred.ToList();
                //this.desplegarComiteCred();
                habilitarControles(clsAcciones.DEFECTO);
            }
        }

        private void dtgEvaluaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgEvaluaciones.SelectedRows.Count > 0)
            {
                //clsComiteCred objComiteCredito = (clsComiteCred)dtgComites.SelectedRows[0].DataBoundItem;
                clsEvalCredComite oEvalCredComite = (clsEvalCredComite)dtgEvaluaciones.SelectedRows[0].DataBoundItem;

                this.tsmActaAprob.Enabled = ((this.objComiteCredito.idEstado == 2 || this.objComiteCredito.idEstado == 3) && oEvalCredComite.idResultado == 5);
            }
        }

        private void dtgEvaluaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.resolverEvaluacionCredito();
        }
        #endregion

        #region Buttons
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.finalizarComiteCreditoSesion();
            LimpiarControles();
            HabilitarBotonesSegunModo(clsAcciones.NUEVO);
            this.txtNombre.Focus();

            this.objComiteCredito = new clsComiteCred();
            this.objComiteCredito.lstParticipantes = new List<clsUsuComite>();
            this.objComiteCredito.lstEvalCred = new List<clsEvalCredComite>();

            dtgParticipantes.DataSource = this.objComiteCredito.lstParticipantes.ToList();
            dtgEvaluaciones.DataSource = this.objComiteCredito.lstEvalCred.ToList();

            this.dtgComites.SelectionChanged -= dtgComites_SelectionChanged;
            this.dtgComites.ClearSelection();
            this.nIdcFilaComite = -1;
            this.dtgComites.SelectionChanged += dtgComites_SelectionChanged;

            asignarPresidenteComite(); 
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.dtgComites.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el comité a editar.", cTituloMsjes,
                                                                MessageBoxButtons.OK,
                                                                MessageBoxIcon.Warning);
                return;
            }

            this.objComiteCredito.idUsuario = clsVarGlobal.User.idUsuario;
            this.objComiteCredito.dFecha = clsVarGlobal.dFecSystem.Date;

            HabilitarBotonesSegunModo(clsAcciones.EDITAR);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            ValidarPerfil();

            if (!Validar())
                return;

            //this.objComiteCredito = (clsComiteCred)dtgComites.SelectedRows[0].DataBoundItem;
            this.objComiteCredito.cNomComite = txtNombre.Text.Trim();
            this.objComiteCredito.cDescComite = "";
            this.objComiteCredito.idTipoComiteCred = Convert.ToInt32(this.cboTipoComiteCred.SelectedValue);
            this.objComiteCredito.lAutBiometricaComite = clsVarGlobal.User.lAutBiometricaComite;

            clsRespuestaServidor objRespuestaServidor = new clsCNComiteCreditos().CNGuardarComite(this.objComiteCredito, clsVarGlobal.PerfilUsu.idPerfil);
            if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
            {
                MessageBox.Show(objRespuestaServidor.cMensaje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.txtNombre.Text = "";
                BuscarComites();

                int nIndiceComite = 0;
                nIndiceComite = this.lstComiteCred.FindIndex(x=>x.idComiteCred == objRespuestaServidor.idRegistro);
                if (nIndiceComite >= 0)
                {
                    dtgComites.Rows[nIndiceComite].Selected = true;
                    this.desplegarComiteCred();
                }

                HabilitarBotonesSegunModo(clsAcciones.GRABAR);
                this.habilitarControles(clsAcciones.GRABAR);
                this.actualizarComiteVirtual();
            }
            else
            {
                MessageBox.Show(objRespuestaServidor.cMensaje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.finalizarComiteCreditoSesion();
            LimpiarControles();
            HabilitarBotonesSegunModo(clsAcciones.CANCELAR);
            this.dtgComites.Focus();
        }

        private void btnEliLista_Click(object sender, EventArgs e)
        {
            frmBusEvalCli frmBusEvalCli = new frmBusEvalCli(frmBusEvalCli.DEVOLVER_EVAL);
            frmBusEvalCli.MultiSeleccion = true;
            frmBusEvalCli.ShowDialog();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if(this.validaFin(false))
            this.finalizarComiteCred();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            this.iniciarComiteCred();
        }

        private void btnActaAprob_Click(object sender, EventArgs e)
        {
            if (dtgComites.SelectedRows.Count > 0)
            {
                //var objComite = dtgComites.SelectedRows[0].DataBoundItem as clsComiteCred;
                //if (objComite == null) return;

                string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

                DataTable dtData = new clsRPTCNCredito().CNGenActaComiteCred(objComiteCredito.idComiteCred);

                if (dtData.Rows.Count == 0)
                {
                    MessageBox.Show("No existen datos para el reporte", "Reporte Conc. C. Oficina, Asesor y Distrito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();

                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString(), false));
                paramlist.Add(new ReportParameter("cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString()));

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dsData", dtData));

                string reportpath = "rptActaComiteCred.rdlc";

                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            BuscarComites();
        }

        private void btnBusqComite_Click(object sender, EventArgs e)
        {
            BuscarComites();
        }
        #endregion

        #region ToolStripMenu
        private void tsmAgrParticipantes_Click(object sender, EventArgs e)
        {
            FrmBusUsuComite frmBusCol = new FrmBusUsuComite();
            frmBusCol.ShowDialog();

            if (frmBusCol.objUsuComite == null) return;

            //var objComiteCredito = dtgComites.SelectedRows[0].DataBoundItem as clsComiteCred;
            clsUsuComite objUser = frmBusCol.objUsuComite;

            if (this.objComiteCredito.lstParticipantes.Count(x => x.idUsuario == objUser.idUsuario) > 0)
            {
                MessageBox.Show("El colaborador ya se encuentra registrado como participante.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            objUser.lConfirmAsis = true;
            this.objComiteCredito.lstParticipantes.Add(objUser);

            this.dtgParticipantes.DataSource = this.objComiteCredito.lstParticipantes.ToList();
        }

        private void tsmQuiParticipantes_Click(object sender, EventArgs e)
        {
            if (this.dtgParticipantes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a quitar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsUsuComite participante = this.dtgParticipantes.SelectedRows[0].DataBoundItem as clsUsuComite;
            if (participante.lPresideComite == true)
            {
                MessageBox.Show("No se puede retirar al Presidente del Comité.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //var objComiteCredito = dtgComites.SelectedRows[0].DataBoundItem as clsComiteCred;
            this.objComiteCredito.lstParticipantes.Remove((clsUsuComite)dtgParticipantes.SelectedRows[0].DataBoundItem);

            this.dtgParticipantes.DataSource = this.objComiteCredito.lstParticipantes.ToList();
        }

        private void tsmAgrEvaluaciones_Click(object sender, EventArgs e)
        {
            frmBusEvalCli frmBusEvalCli = new frmBusEvalCli(frmBusEvalCli.AGREGAR_EVAL);
            frmBusEvalCli.MultiSeleccion = true;
            frmBusEvalCli.ShowDialog();

            if (frmBusEvalCli.LstEvalCredComites == null || !frmBusEvalCli.LstEvalCredComites.Any()) return;

            //var objComiteCredito = dtgComites.SelectedRows[0].DataBoundItem as clsComiteCred;

            var lstRepetidos = this.objComiteCredito.lstEvalCred.Select(x => x.idEval)
                                                    .Intersect(frmBusEvalCli.LstEvalCredComites.Select(y => y.idEval)).ToList();

            if (lstRepetidos.Any())
            {
                MessageBox.Show("Existen evaluaciones que ya se encuentra agregadas al comité.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var objEval in frmBusEvalCli.LstEvalCredComites)
            {
                this.objComiteCredito.lstEvalCred.Add(objEval);
            }

            dtgEvaluaciones.DataSource = this.objComiteCredito.lstEvalCred.ToList();
        }

        private void tsmQuiEvaluaciones_Click(object sender, EventArgs e)
        {
            if (this.dtgEvaluaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a quitar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //var objComiteCredito = dtgComites.SelectedRows[0].DataBoundItem as clsComiteCred;
            this.objComiteCredito.lstEvalCred.Remove((clsEvalCredComite)dtgEvaluaciones.SelectedRows[0].DataBoundItem);

            this.dtgEvaluaciones.DataSource = this.objComiteCredito.lstEvalCred.ToList();
        }

        private void tsmAsignarPresidente_Click(object sender, EventArgs e)
        {
            if (this.objComiteCredito == null)
            {
                MessageBox.Show("No se a seleccionado ningun comité de créditos.", cTituloMsjes,
                                                                                MessageBoxButtons.OK,
                                                                                MessageBoxIcon.Warning);
                return;
            }

            if (this.dtgParticipantes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el participante que será presidente del comité.", cTituloMsjes,
                                                                                            MessageBoxButtons.OK,
                                                                                            MessageBoxIcon.Warning);
                return;
            }

            //clsComiteCred objComiteCredito = (clsComiteCred)dtgComites.SelectedRows[0].DataBoundItem;

            clsUsuComite objUsuComite = (clsUsuComite)dtgParticipantes.SelectedRows[0].DataBoundItem;
            if (this.objComiteCredito.idUsuPreside != null)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de cambiar de presidente de comité?", cTituloMsjes,
                                                                                                        MessageBoxButtons.YesNo,
                                                                                                        MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                    return;
            }

            int? idUsuPresideAnt = this.objComiteCredito.idUsuPreside;

            this.objComiteCredito.idUsuPreside = objUsuComite.idUsuario;
            this.objComiteCredito.idPerfilPreside = 0;
            //this.objComiteCredito.idUsuPreside = clsVarGlobal.User.idUsuario;
            this.objComiteCredito.dFecha = clsVarGlobal.dFecSystem;
            this.objComiteCredito.idUsuario = clsVarGlobal.User.idUsuario;

            clsUsuComite objUsuPreside = this.objComiteCredito.lstParticipantes.FirstOrDefault(x => x.idUsuario == this.objComiteCredito.idUsuPreside);
            if (objUsuPreside != null)
            {
                this.objComiteCredito.lstParticipantes.ForEach(x => { x.lPresideComite = false; });
                objUsuPreside.lPresideComite = true;
            }

            this.dtgParticipantes.Refresh();
        }

        private void tsmQuiComiteCredito_Click(object sender, EventArgs e)
        {
            if (this.dtgComites.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el comité a eliminar", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (this.objComiteCredito != null)
            {
                DialogResult result = MessageBox.Show("¿Está seguro de eliminar el registro?", cTituloMsjes, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                dtgComites.Enabled = false;
                this.objComiteCredito.idUsuario = clsVarGlobal.User.idUsuario;
                this.objComiteCredito.dFecha = clsVarGlobal.dFecSystem.Date;
                this.objComiteCredito.lVigente = false;

                clsRespuestaServidor objRespuestaServidor = new clsCNComiteCreditos().CNGuardarComite(this.objComiteCredito, clsVarGlobal.PerfilUsu.idPerfil);
                if (objRespuestaServidor.idResultado == ResultadoServidor.Correcto)
                {
                    MessageBox.Show(objRespuestaServidor.cMensaje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    BuscarComites();
                }
                else
                {
                    MessageBox.Show(objRespuestaServidor.cMensaje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtgComites.Enabled = true;
                }
            }
        }

        private void tsmAbrirEval_Click(object sender, EventArgs e)
        {
            this.resolverEvaluacionCredito();
        }

        private void tsmActaAprob_Click(object sender, EventArgs e)
        {
            if (dtgEvaluaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro para mostrar el reporte.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsEvalCredComite objEvalCred = dtgEvaluaciones.SelectedRows[0].DataBoundItem as clsEvalCredComite;

            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            this.idSolic = objEvalCred.idSolicitud;
            DataSet dsData = new clsRPTCNCredito().CNGenActaAprobDenegCred(this.idSolic);

            if (dsData.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para el reporte.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();

            paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.Date.ToString(), false));
            paramlist.Add(new ReportParameter("cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString()));

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();

            dtslist.Add(new ReportDataSource("dsDatosGenerales", dsData.Tables["dtDatosGenerales"]));
            dtslist.Add(new ReportDataSource("dsDestCredSol", dsData.Tables["dtDestCredSol"]));
            dtslist.Add(new ReportDataSource("dsComite", dsData.Tables["dtComite"]));
            dtslist.Add(new ReportDataSource("dsNivAproba", dsData.Tables["dtNivAproba"]));
            dtslist.Add(new ReportDataSource("dsIntervSolCre", dsData.Tables["dtIntervSolCre"]));
            dtslist.Add(new ReportDataSource("dsExcepciones", dsData.Tables["dtExcepciones"]));
            dtslist.Add(new ReportDataSource("dsParticipantes", dsData.Tables["dtParticipantes"]));
            dtslist.Add(new ReportDataSource("dsHistObs", dsData.Tables["dtHistObs"]));
            
            string reportpath = "rptActaAprobacionCredito.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }
        #endregion

        private void frmRegComiteCred_Shown(object sender, EventArgs e)
        {
            ValidarPerfil();
        }

        #endregion

        private void btnBuscarActa_Click(object sender, EventArgs e)
        {
            frmActaAprobCred frmActAproCred = new frmActaAprobCred();
            frmActAproCred.ShowDialog();
        }

        private void AlertaCreditos50000(int idSolicitud, decimal ?nMonto)
        {
            clsCNCredito objCre = new clsCNCredito();
            DataTable dt = objCre.CNAlertaCreditos50000(idSolicitud);

            if (dt.Rows.Count == 0)
            {
                return;
            }

            int idTipoCliente = Convert.ToInt32(dt.Rows[0]["idTipoCli"].ToString());
            decimal nMontoLimite = Convert.ToDecimal(dt.Rows[0]["nMontoLimite"].ToString());
            

            if (nMonto >= nMontoLimite)
            {
                MessageBox.Show("Para montos mayores o iguales a S/ " + nMontoLimite.ToString("###,###,##0.00") +
                    ", requiere la Aprobación y Conformidad del Directorio",
                    "Información Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmRegComiteCred_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.finalizarComiteCreditoSesion();
        }

        private void btnRevisar_Click(object sender, EventArgs e)
        {
            if (this.nIdcFilaComite < 0)
            {
                MessageBox.Show("¡Seleccione algún comité de crédito para revisar!", "COMITE NO SELECCIONADO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.desplegarComiteCred();
        }

        private void btnTiempo_Click(object sender, EventArgs e)
        {
            this.gestionarTiempoSesionAdicional(true);
        }

        private void tsmActualizar_Click(object sender, EventArgs e)
        {
            this.actualizarComiteVirtual();
        }
    }
}
