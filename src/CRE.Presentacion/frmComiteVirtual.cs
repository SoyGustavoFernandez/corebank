using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class frmComiteVirtual : frmBase
    {
        private List<clsUsuComite> lstParticipantes = new List<clsUsuComite>();
        private List<clsEvalCredComite> lstEvalCred = new List<clsEvalCredComite>();
        private clsCNComiteCreditos objCNComites = new clsCNComiteCreditos();
        private clsCNAprobacionCredito objCNAprobacionCredito = new clsCNAprobacionCredito();
        private clsComiteCreditoSesion objComiteCreditoSesion = new clsComiteCreditoSesion();

        private clsEvalCredComite objEvalCred = new clsEvalCredComite();
        private clsCreditoProp objCreditoProp;

        private const string cTituloMsjes = "COMITÉ VIRTUAL";
        private const string cTipoRevisor = "REVISOR";
        private const string cTipoParticipante = "PARTICIPANTE";

        private System.Timers.Timer objTimer;

        private int idComiteCred = 0;
        private int idEvalCred = 0;
        private bool lActualizarTiempo = true;

        public frmComiteVirtual()
        {
            InitializeComponent();
            this.habilitarControles(clsAcciones.DEFECTO);
        }

        private void habilitarControles(int idAccion)
        {
            switch(idAccion)
            {
                case clsAcciones.DEFECTO:
                    this.grbBase.Enabled = false;
                    this.txtDatosComite.Enabled = false;
                    this.txtAsesor.Enabled = false;
                    this.txtComentario.Enabled = false;
                    this.grbObservaciones.Enabled = false;
                    this.btnOpinion.Enabled = false;
                    this.btnRevisar.Enabled = false;
                    this.btnExpediente.Enabled = false;
                    this.btnActualizar.Enabled = false;
                    this.cboDecision.Enabled = false;
                    this.txtTipoParticipacion.Enabled = false;
                    break;
                case clsAcciones.NUEVO:
                    this.grbBase.Enabled = false;
                    this.txtDatosComite.Enabled = false;
                    this.txtAsesor.Enabled = false;
                    this.txtComentario.Enabled = false;
                    this.grbObservaciones.Enabled = false;
                    this.btnOpinion.Enabled = false;
                    this.btnRevisar.Enabled = true;
                    this.btnExpediente.Enabled = true;
                    this.btnActualizar.Enabled = true;
                    this.cboDecision.Enabled = false;
                    this.txtTipoParticipacion.Enabled = false;
                    break;
                case clsAcciones.INICIAR:
                    this.grbBase.Enabled = false;
                    this.txtComentario.Enabled = true;
                    this.grbObservaciones.Enabled = true;
                    this.btnOpinion.Enabled = true;
                    this.btnExpediente.Enabled = true;
                    this.btnActualizar.Enabled = true;
                    this.cboDecision.Enabled = true;
                    this.conCreditoTasa.Enabled = false;
                    break;
                case clsAcciones.VISTA:
                    this.grbBase.Enabled = false;
                    this.txtComentario.Enabled = false;
                    this.grbObservaciones.Enabled = true;
                    this.btnOpinion.Enabled = true;
                    this.btnExpediente.Enabled = true;
                    this.btnActualizar.Enabled = true;
                    this.cboDecision.Enabled = true;
                    this.conCreditoTasa.Enabled = false;
                    break;
            }
        }

        private void finalizarComiteCreditoSesion()
        {
            if (this.objTimer != null)
            {
                this.objTimer.Close();
            }

            if (this.objComiteCreditoSesion.nTiempoRestante < 0)
                this.objComiteCreditoSesion.nTiempoRestante = 0;
            
            this.lActualizarTiempo = false;
            this.actualizarTiemposSesion();
        }

        private void iniciarComiteCreditoSesion()
        {
            this.lActualizarTiempo = true;
            this.actualizarTiemposSesion();
            this.iniciarTemporizador();
        }

        private void iniciarTemporizador()
        {
            this.objTimer = new System.Timers.Timer();
            this.objTimer.Interval = 60000;
            this.objTimer.Elapsed += Timer_Elapsed;
            this.objTimer.Start();
        }

        private void actualizarTiemposSesion()
        {
            this.lblEstado.Text = this.objComiteCreditoSesion.cEstado;
            this.lblHoraIniProg.Text = this.objComiteCreditoSesion.tHoraIniProg.ToString(@"hh\:mm");
            this.lblTiempoAmpliado.Text = this.objComiteCreditoSesion.tTiempoAmpliado.ToString(@"hh\:mm");
            this.lblHoraFinProg.Text = this.objComiteCreditoSesion.tHoraFinProg.ToString(@"hh\:mm");
            this.lblTiempoRestante.Text = (new TimeSpan(0, this.objComiteCreditoSesion.nTiempoRestante, 0)).ToString(@"hh\:mm");
            if (this.lblTiempoRestante.Text == "00:00" && this.lActualizarTiempo == true)
            {
                MessageBox.Show("Tiempo de sesión del comité ha expirado.", "COMITÉ VIRTUAL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.habilitarControles(clsAcciones.DEFECTO);
            }
        }

        private void limpiarTiemposSesion()
        {
            this.lblEstado.Text = "NINGUNO";
            this.lblHoraIniProg.Text = "00:00";
            this.lblTiempoAmpliado.Text = "00:00";
            this.lblHoraFinProg.Text = "00:00";
            this.lblTiempoRestante.Text = "00:00";
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
                    MessageBox.Show("Tiempo de sesión del comité ha expirado.", "COMITÉ VIRTUAL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.habilitarControles(clsAcciones.DEFECTO);
                }
                else if (
                    !this.objComiteCreditoSesion.lTiempoAmpliado &&
                    this.objComiteCreditoSesion.lValidoParaAmpliacion &&
                    this.objComiteCreditoSesion.nTiempoAlerta >= 0 &&
                    this.objComiteCreditoSesion.nTiempoRestante == this.objComiteCreditoSesion.nTiempoAlerta)
                {
                    frmComiteCredSesionMensaje objFrmMensaje = new frmComiteCredSesionMensaje("El comité de créditos se cerrará en " +
                        this.objComiteCreditoSesion.nTiempoAlerta + " minutos.\n\n" +
                        "¿Desea solicitar tiempo adicional?", "SESIÓN DE COMITÉ", 20, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private bool validarParticipante()
        {
            clsUsuComite objParticipanteActivo = new clsUsuComite();
            this.dtgParticipantes.Rows.Clear();
            this.lstParticipantes.Clear();
            this.lstParticipantes.AddRange(objCNComites.obtenerParticipVirtual(this.idComiteCred));
            this.bsParticipantes.DataSource = this.lstParticipantes;
            this.bsParticipantes.ResetBindings(false);
            this.dtgParticipantes.Refresh();
            objParticipanteActivo = this.lstParticipantes.FirstOrDefault(x => x.idUsuario == clsVarGlobal.User.idUsuario);
            if (objParticipanteActivo != null)
            {
                if (objParticipanteActivo.idTipoParticip == 3)
                {
                    return true;
                }
                MessageBox.Show("Su tipo de participación debe ser VIRTUAL para continuar con la revisión de las solicitudes de crédito.", "COMITÉ VIRTUAL", 
                                                                                                                                            MessageBoxButtons.OK, 
                                                                                                                                            MessageBoxIcon.Information);
                this.habilitarControles(clsAcciones.DEFECTO);
                return false;
            }
            MessageBox.Show("Acaba de ser retirado de éste comité.", "COMITÉ VIRTUAL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.habilitarControles(clsAcciones.DEFECTO);
            return false;
        }

        private bool validaCredito()
        {
            this.dtgCreditos.Rows.Clear();
            this.lstEvalCred.Clear();
            this.lstEvalCred.AddRange(objCNComites.obtenerCreditoVirtual(this.idComiteCred));
            this.bsCreditos.DataSource = this.lstEvalCred;
            this.bsCreditos.ResetBindings(false);
            this.dtgCreditos.ClearSelection();
            this.dtgCreditos.Refresh();
            if (dtgCreditos.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        private void formatGridViewObservaciones()
        {
            foreach (DataGridViewRow dtRow in this.dtgObservaciones.Rows)
            {
                DataGridViewCell idUsuario = dtRow.Cells["idUsuReg"] as DataGridViewCell;
                if (clsVarGlobal.User.idUsuario == Convert.ToInt32(idUsuario.Value))
                {
                    dtRow.DefaultCellStyle.BackColor = System.Drawing.Color.GreenYellow;
                }
            }

            foreach (DataGridViewColumn column in this.dtgObservaciones.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dtgObservaciones.Columns["cTipObservacion"].DisplayIndex = 0;
            dtgObservaciones.Columns["cObservacion"].DisplayIndex = 1;
            dtgObservaciones.Columns["lSubsanado"].DisplayIndex = 2;

            dtgObservaciones.Columns["cTipObservacion"].Visible = true;
            dtgObservaciones.Columns["cObservacion"].Visible = true;
            dtgObservaciones.Columns["lSubsanado"].Visible = true;

            dtgObservaciones.Columns["cTipObservacion"].HeaderText = "Tipo ";
            dtgObservaciones.Columns["cObservacion"].HeaderText = "Observación";
            dtgObservaciones.Columns["lSubsanado"].HeaderText = "?";

            dtgObservaciones.Columns["cTipObservacion"].FillWeight = 50;
            dtgObservaciones.Columns["cObservacion"].FillWeight = 100;
            dtgObservaciones.Columns["lSubsanado"].FillWeight = 10;
        }

        private void formatGridView()
        {
            this.dtgObservaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgObservaciones.Margin = new System.Windows.Forms.Padding(0);
            this.dtgObservaciones.MultiSelect = false;
            this.dtgObservaciones.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgObservaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgObservaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dtgObservaciones.RowHeadersVisible = false;
            this.dtgObservaciones.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dtgObservaciones.ReadOnly = true;
        }

        private bool GrabarObservacionesAprobador()
        {
            clsCNObservacionAprobador objCNObsApro = new clsCNObservacionAprobador();
            DataTable dtRes = objCNObsApro.GrabarObservacionAprobador(this.objEvalCred.idEval, this.objEvalCred.idSolicitud, this.objEvalCred.idNivelAprobacion, this.objEvalCred.lstObsAprobador.GetXml());

            if (Convert.ToInt32(dtRes.Rows[0]["idError"]) == 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], "Error inesperado en observaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void ObtenerObservaciones()
        {
            clsCNObservacionAprobador objCNObsApro = new clsCNObservacionAprobador();
            objEvalCred.lstObsAprobador = objCNObsApro.ListarObsAprobador(this.idEvalCred);
            bsObservaciones.DataSource = objEvalCred.lstObsAprobador;
            dtgObservaciones.DataSource = bsObservaciones;
            formatGridView();
            formatGridViewObservaciones();
        }

        private void btnBandeja_Click(object sender, EventArgs e)
        {
            int idUsuario = clsVarGlobal.User.idUsuario;
            frmBandejaComiteVirtual objBandejaComiteVirtual = new frmBandejaComiteVirtual(idUsuario);
            objBandejaComiteVirtual.ShowDialog();

            if (objBandejaComiteVirtual.objUsuComite != null)
            {
                this.idComiteCred = objBandejaComiteVirtual.objUsuComite.idComiteCred;

                this.validarParticipante();
                this.validaCredito();

                this.txtAsesor.Text = objBandejaComiteVirtual.objUsuComite.cNombre;
                this.txtDatosComite.Text = objCNComites.obtenerDatosComite(this.idComiteCred);
                this.txtTipoParticipacion.Text = "";
                this.txtComentario.Text = "";
                this.dtgObservaciones.Rows.Clear();
                this.lblDatoEvaluacion.Text = "Ninguno";
                this.cboDecision.SelectedValue = 0;

                this.limpiarTiemposSesion();

                if (this.dtgCreditos.Rows.Count != 0)
                {
                    this.dtgCreditos.Rows[0].Selected = true;
                    DataTable dtDecision = objCNComites.obtenerDecisComiteVirtual();
                    this.cboDecision.DataSource = dtDecision;
                    this.cboDecision.DisplayMember = "cEstado";
                    this.cboDecision.ValueMember = "idEstDecisComiteVirtual";
                    this.cboDecision.SelectedValue = 0;
                    this.habilitarControles(clsAcciones.NUEVO);
                }
                else
                {
                    this.habilitarControles(clsAcciones.DEFECTO);
                }
            }
            conCreditoTasa.LimpiarFormulario();
        }

        private void btnRevisar_Click(object sender, EventArgs e)
        {
            if (!this.validarParticipante()) return;

            int idFilaTabla = 0;
            int nValidaCantidadCredito = this.dtgCreditos.Rows.Count;
            if (this.dtgCreditos.Rows.Count > 0) idFilaTabla = Convert.ToInt32(dtgCreditos.SelectedRows[0].Index);
            if (!this.validaCredito())
            {
                MessageBox.Show("No existe crédito asignado en este comité.", "COMITÉ VIRTUAL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.habilitarControles(clsAcciones.DEFECTO);
                return;
            }
            if (nValidaCantidadCredito != this.dtgCreditos.Rows.Count)
            {
                MessageBox.Show("Los créditos asignados para la revisión acaban de ser actualizados.", "COMITÉ VIRTUAL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtgCreditos.Rows[0].Selected = true; 
                return;
            }
            else if (this.dtgCreditos.Rows.Count > 0)
            {
                this.dtgCreditos.Rows[idFilaTabla].Selected = true;
            } 

            clsCreditoProp objCreditoProp = objCNAprobacionCredito.ObtenerCondicionesCredito(Convert.ToInt32(dtgCreditos.SelectedRows[0].Cells["idEval"].Value));
            conCreditoTasa.AsignarDatos(objCreditoProp);

            this.objComiteCreditoSesion = this.objCNComites.recuperarComiteCreditoSesion(this.idComiteCred);
            if (this.objComiteCreditoSesion.idComiteCreditoSesion == 0)
            {
                MessageBox.Show("El comité todavía no ha iniciado.", "COMITÉ VIRTUAL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.habilitarControles(clsAcciones.NUEVO);
                this.limpiarTiemposSesion();
            }
            else
            {
                if (this.objComiteCreditoSesion.idEstado == 28) //Inicializado
                {
                    this.objEvalCred = (clsEvalCredComite)dtgCreditos.SelectedRows[0].DataBoundItem;
                    this.idEvalCred = this.objEvalCred.idEval;
                    DataTable dtResultComentObs = objCNComites.obtenerComentObsComiteVirtual(idComiteCred, this.objEvalCred.idEval, clsVarGlobal.User.idUsuario);
                    if (Convert.ToInt32(dtResultComentObs.Rows[0]["idResultado"]) != 1)
                    {
                        MessageBox.Show("La evaluación N°. " + this.idEvalCred.ToString() + " ya tiene una decisión del PRESIDENTE.", "COMITÉ VIRTUAL", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        this.dtgCreditos.Rows.Clear();
                        this.lstEvalCred.AddRange(objCNComites.obtenerCreditoVirtual(this.idComiteCred));
                        this.bsCreditos.DataSource = this.lstEvalCred;
                        this.bsCreditos.ResetBindings(false);
                        this.dtgCreditos.Refresh();

                        this.txtTipoParticipacion.Text = "";
                        this.txtComentario.Text = "";
                        this.dtgObservaciones.Rows.Clear();
                        this.cboDecision.SelectedValue = 0;
                        this.habilitarControles(clsAcciones.NUEVO);
                        return;
                    }
                    if (Convert.ToInt32(dtResultComentObs.Rows[0]["idUsuResponsable"]) == clsVarGlobal.User.idUsuario)
                    {
                        this.txtTipoParticipacion.Text = cTipoRevisor;
                        this.txtComentario.Text = dtResultComentObs.Rows[0]["cComentRev"].ToString();
                        this.cboDecision.SelectedValue = Convert.ToInt32(dtResultComentObs.Rows[0]["lDecision"]);
                        this.ObtenerObservaciones();
                        this.habilitarControles(clsAcciones.INICIAR);
                    }
                    else
                    {
                        this.txtTipoParticipacion.Text = cTipoParticipante;
                        this.txtComentario.Text = "";
                        this.cboDecision.SelectedValue = Convert.ToInt32(dtResultComentObs.Rows[0]["lDecision"]);
                        this.ObtenerObservaciones();
                        this.habilitarControles(clsAcciones.VISTA);
                    }
                }
                else if (this.objComiteCreditoSesion.idEstado == 29) //Finalizado
                {
                    MessageBox.Show("El PRESIDENTE finalizó el comité.", "COMITÉ VIRTUAL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.habilitarControles(clsAcciones.DEFECTO);
                    this.objTimer.Close();
                    return;
                }
                this.finalizarComiteCreditoSesion();
                this.iniciarComiteCreditoSesion();
            }
        }

        private void btnExpediente_Click(object sender, EventArgs e)
        {
            if (!this.validarParticipante()) return;

            int idFilaTabla = 0;
            int nValidaCantidadCredito = this.dtgCreditos.Rows.Count;
            if (this.dtgCreditos.Rows.Count > 0) idFilaTabla = Convert.ToInt32(dtgCreditos.SelectedRows[0].Index);
            if (!this.validaCredito())
            {
                MessageBox.Show("No existe crédito asignado en este comité.", "COMITÉ VIRTUAL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.habilitarControles(clsAcciones.DEFECTO);
                return;
            }
            if (nValidaCantidadCredito != this.dtgCreditos.Rows.Count)
            {
                MessageBox.Show("Los créditos asignados para la revisión acaban de ser actualizados.", "COMITÉ VIRTUAL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtgCreditos.Rows[0].Selected = true;
                return;
            }
            else if (this.dtgCreditos.Rows.Count > 0)
            {
                this.dtgCreditos.Rows[idFilaTabla].Selected = true;
            } 

            clsEvalCredComite objEvalCred2 = new clsEvalCredComite();
            objEvalCred2 = (clsEvalCredComite)dtgCreditos.SelectedRows[0].DataBoundItem;
            if(objEvalCred2.idEstadoEvalCred == 7)
            {
                MessageBox.Show("El crédito fue DENEGADO por el presidente.", "COMITÉ VIRTUAL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmExpedienteLinea frmExpLinea = new frmExpedienteLinea(Convert.ToInt32(objEvalCred2.idSolicitud), Convert.ToInt32(objEvalCred2.idCli), "individual");
            frmExpLinea.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.lblDatoEvaluacion.Text = objCNComites.obtenerDatosEvalRevision(this.idComiteCred);
        }

        private void btnAddObs_Click(object sender, EventArgs e)
        {
            frmObsAprobacion frmEditObs = new frmObsAprobacion();
            frmEditObs.idOrigenObs = 1;

            clsObservacionAprobador objObservacion = new clsObservacionAprobador();

            objObservacion.idObsAprobador = 0;
            objObservacion.idTipObservacion = 0;
            objObservacion.cTipObservacion = string.Empty;
            objObservacion.cObservacion = string.Empty;
            objObservacion.lSubsanado = false;
            objObservacion.idUsuReg = clsVarGlobal.User.idUsuario;

            frmEditObs.objObservacion = objObservacion;
            frmEditObs.ShowDialog();

            if (!frmEditObs.lAceptado) return;

            objEvalCred.lstObsAprobador.Add(objObservacion);
            bsObservaciones.ResetBindings(false);
            formatGridViewObservaciones();
        }

        private void btnQuitObs_Click(object sender, EventArgs e)
        {
            if (dtgObservaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a eliminar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsObservacionAprobador objObservacion = (clsObservacionAprobador)dtgObservaciones.SelectedRows[0].DataBoundItem;

            if (objObservacion.idObsAprobador > 0)
            {
                MessageBox.Show("No se pueden eliminar las observaciones.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            objEvalCred.lstObsAprobador.Remove(objObservacion);
            bsObservaciones.ResetBindings(false);
            formatGridViewObservaciones();
        }

        private void btnEditObs_Click(object sender, EventArgs e)
        {
            if (dtgObservaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a editar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsObservacionAprobador objObservacion = dtgObservaciones.SelectedRows[0].DataBoundItem as clsObservacionAprobador;

            if (objObservacion.idObsAprobador != 0)
            {
                MessageBox.Show("Solo se pueden editar las observaciones nuevas.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmObsAprobacion frmEditObs = new frmObsAprobacion();
            frmEditObs.objObservacion = objObservacion;
            frmEditObs.ShowDialog();

            bsObservaciones.DataSource = objEvalCred.lstObsAprobador;
            bsObservaciones.ResetBindings(false);
            formatGridViewObservaciones();
        }

        private void btnOpinion_Click(object sender, EventArgs e)
        {
            DataTable dtResultComentObs2 = objCNComites.obtenerComentObsComiteVirtual(this.idComiteCred, this.idEvalCred, 0);
            if (Convert.ToInt32(dtResultComentObs2.Rows[0]["idResultado"]) != 1)
            {
                MessageBox.Show("La evaluación N°. " + this.idEvalCred.ToString() + " ya fue decidido por el PRESIDENTE.", "COMITÉ VIRTUAL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.habilitarControles(clsAcciones.NUEVO);
                this.idEvalCred = 0;
                return;
            }
            clsComiteCreditoSesion objComiteCreditoSesion2 = new clsComiteCreditoSesion();
            objComiteCreditoSesion2 = this.objCNComites.recuperarComiteCreditoSesion(this.idComiteCred);
            if (objComiteCreditoSesion2.idEstado == 29) //Finalizado
            {
                MessageBox.Show("El PRESIDENTE finalizó el comité.", "COMITÉ VIRTUAL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.habilitarControles(clsAcciones.DEFECTO);
                this.objTimer.Close();
                return;
            }
            if (this.txtComentario.Text.Length == 0 && this.txtTipoParticipacion.Text == cTipoRevisor)
            {
                MessageBox.Show("Debe asignar un breve comentario.", "COMITÉ VIRTUAL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.cboDecision.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una opinión.", "OPINIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                bool lDecision = true;
                if (Convert.ToInt32(this.cboDecision.SelectedValue) == 1)
                {
                    lDecision = true;
                }
                else if (Convert.ToInt32(this.cboDecision.SelectedValue) == 2)
                {
                    lDecision = false;
                }

                DataTable dtResCambiarOpinion = objCNComites.CambiarOpinionUsuComiteCred(this.idComiteCred, objEvalCred.idEval, clsVarGlobal.User.idUsuario, lDecision, clsVarGlobal.dFecSystem);
                if (Convert.ToInt32(dtResCambiarOpinion.Rows[0]["idError"]) == 0)
                {
                    if (this.GrabarObservacionesAprobador())
                    {
                        if (this.txtTipoParticipacion.Text == cTipoRevisor)
                        {
                            string cComentario = txtComentario.Text.Trim();
                            DataTable dtResGuardarComentObs = objCNComites.guardarComentObsComiteVirtual(this.idComiteCred, objEvalCred.idEval, clsVarGlobal.User.idUsuario, cComentario);

                            if (Convert.ToInt32(dtResGuardarComentObs.Rows[0]["idError"]) == 0)
                            {
                                MessageBox.Show("Opinión guardada correctamente.", cTituloMsjes,
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information);
                                this.habilitarControles(clsAcciones.NUEVO);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Opinión guardada correctamente.", cTituloMsjes,
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                            this.habilitarControles(clsAcciones.NUEVO);
                        }
                        this.dtgObservaciones.ClearSelection();
                    }
                }
                else
                {
                    MessageBox.Show("Error al guardar la opinión.", cTituloMsjes,
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Warning);
                }
            }
        }
    }
}
