using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using CRE.CapaNegocio;
using GEN.CapaNegocio;
using GEN.Funciones;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace CRE.Presentacion
{
    public partial class frmControlComitesCred : frmBase
    {
        #region Variables Globales

        public clsComiteCred objComite = null;
        private const string cTituloMsjes = "Comité de créditos.";
        private clsCNComiteCreditos objCNComiteCred = new clsCNComiteCreditos();
        public bool lSoloLectura = false;
        private DateTime dFecMinValue = System.Data.SqlTypes.SqlDateTime.MinValue.Value;
        private DateTime dFecMaxValue = System.Data.SqlTypes.SqlDateTime.MaxValue.Value;
        private decimal nMontoSolicitado = 0;

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            dtgEvaluaciones.AutoGenerateColumns = false;
            dtgParticipantes.AutoGenerateColumns = false;
            dtgObservaciones.AutoGenerateColumns = false;
            dtgExcepciones.AutoGenerateColumns = false;
            dtgFiadorSolidario.AutoGenerateColumns = false;
            //dtgGarantias.AutoGenerateColumns = false;

            if (objComite != null)
            {
                HabilitarControlesComite(false);
                MapeaEntidadControles(objComite);
                if (lSoloLectura)
                {
                    FormSoloLectura();
                }
            }
            else
            {
                MessageBox.Show("No se encontró comite de créditos.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
            }
        }

        private void btnResponsable_Click(object sender, EventArgs e)
        {
            if (dtgEvaluaciones.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione una evaluación para la asignación del responsable de revisión.", cTituloMsjes,
                                                                                                            MessageBoxButtons.OK,
                                                                                                            MessageBoxIcon.Warning);
            }

            if (dtgParticipantes.SelectedRows.Count <= 0)
            {
                MessageBox.Show("No se seleccionó ningun usuario responsable de la revisión.", cTituloMsjes,
                                                                                                MessageBoxButtons.OK,
                                                                                                MessageBoxIcon.Warning);
                return;
            }

            clsEvalCredComite objEvalCred = (clsEvalCredComite)dtgEvaluaciones.SelectedRows[0].DataBoundItem;
            clsDecisComite objUsuResponsable = (clsDecisComite)dtgParticipantes.SelectedRows[0].DataBoundItem;

            if (objEvalCred.idAsesor == objUsuResponsable.idUsuComite)
            {
                MessageBox.Show("El asesor del crédito no puede ser el responsable de la revisión.", cTituloMsjes,
                                                                                                MessageBoxButtons.OK,
                                                                                                MessageBoxIcon.Warning);
                return;
            }

            if (objEvalCred.idUsuResponsable == objUsuResponsable.idUsuComite)
            {
                MessageBox.Show("El usuario ya es responsable de la revisión de la evaluación.", cTituloMsjes,
                                                                                                MessageBoxButtons.OK,
                                                                                                MessageBoxIcon.Warning);
                return;
            }

            if (objEvalCred.idUsuResponsable != null)
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea cambiar al responsable de la evaluación?", cTituloMsjes,
                                                                                                                        MessageBoxButtons.YesNo,
                                                                                                                        MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return;
                }
            }

            objComite.idUsuario = clsVarGlobal.User.idUsuario;
            objComite.dFecha = clsVarGlobal.dFecSystem.Date;

            clsDBResp objDbResp = objCNComiteCred.CNAsigUsuResponsableEval(objComite, objEvalCred, objUsuResponsable);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes,
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                dtgEvaluaciones.DataSource = objComite.lstEvalCred.ToList();
                dtgEvaluaciones.Focus();
                dtgEvaluaciones.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToInt32(x.Cells["idEval"].Value) == objEvalCred.idEval).First().Selected = true;
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes,
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Warning);
            }
        }

        private void btnOpinion_Click(object sender, EventArgs e)
        {
            if (dtgEvaluaciones.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione la evaluación de crédito.", cTituloMsjes,
                                                                                            MessageBoxButtons.OK,
                                                                                            MessageBoxIcon.Warning);
                return;
            }
            if (dtgParticipantes.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione el usuario del que desea actualizar la opinión.", cTituloMsjes,
                                                                                            MessageBoxButtons.OK,
                                                                                            MessageBoxIcon.Warning);
                return;
            }

            clsEvalCredComite objEval = (clsEvalCredComite)dtgEvaluaciones.SelectedRows[0].DataBoundItem;
            clsDecisComite objDecision = (clsDecisComite)dtgParticipantes.SelectedRows[0].DataBoundItem;

            DialogResult result = MessageBox.Show("¿Está seguro de cambiar su decisión?", cTituloMsjes,
                                                                                            MessageBoxButtons.YesNo,
                                                                                            MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }

            frmCredenciales frmCredenciales = new frmCredenciales();
            frmCredenciales.cWinUser = objDecision.cWinUser;
            frmCredenciales.ShowDialog();
            if (!frmCredenciales.lValido)
            {
                MessageBox.Show("Confirmación no realizada. Las credenciales no son válidas.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            objComite.dFecha = clsVarGlobal.dFecSystem.Date;

            clsDBResp objDbResp = objCNComiteCred.CNActualizaDecisUsuComite(objComite, objEval, objDecision);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                objEval.lstDecisComite = objCNComiteCred.CNGetDeciComiteCred(objEval);
                objEval.lstDecisComite.ForEach(x => { x.lResponsable = false; });
                if (objEval.idUsuResponsable != null)
                {
                    clsDecisComite objResponsable = objEval.lstDecisComite.FirstOrDefault(x => x.idUsuComite == objEval.idUsuResponsable);
                    if (objResponsable != null)
                    {
                        objResponsable.lResponsable = true;
                    }
                }
                dtgParticipantes.DataSource = objEval.lstDecisComite.ToList();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dtgEvaluaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgEvaluaciones.SelectedRows.Count > 0)
            {
                clsEvalCredComite objEvalCred = (clsEvalCredComite)dtgEvaluaciones.SelectedRows[0].DataBoundItem;

                objEvalCred.lstDecisComite.ForEach(x => { x.lResponsable = false; });
                if (objEvalCred.idUsuResponsable != null)
                {
                    clsDecisComite objResponsable = objEvalCred.lstDecisComite.FirstOrDefault(x => x.idUsuComite == objEvalCred.idUsuResponsable);
                    if (objResponsable != null)
                    {
                        objResponsable.lResponsable = true;
                    }
                }
                dtgParticipantes.DataSource = objEvalCred.lstDecisComite.ToList();
                MapeaEvaluacion(objEvalCred);

                if(lSoloLectura) return;

                btnIniciar.Enabled = (objEvalCred.idResultado == null);
                btnResponsable.Enabled = (objEvalCred.idResultado == null);
                //btnOpinion.Enabled = (objEvalCred.idResultado == null);
                //btnCancelar.Enabled = objEvalCred.idResultado == null && !btnIniciar.Enabled;

                if (objEvalCred.idResultado != null)
                {
                    DataRowView dr = (DataRowView)cboResultComite.SelectedItem;
                    bool lEditar = (bool)dr["lEditar"];
                    btnIniciar.Enabled = lEditar && !objEvalCred.lEstado && !objEvalCred.lEditar;
                }
            }
        }

        private void btnDecidir_Click(object sender, EventArgs e)
        {
            if (!ValidarDecision()) return;
            if (!ValidarReglas()) return;

            clsCreditoProp objCreditoProp = conCreditoTasa.ObtenerCreditoPropuesto();
            objCreditoProp.idOrigenCredProp = 3;
            objCreditoProp.nCuotaAprox = conCreditoTasa.CuotaAprox();
            objCreditoProp.lVerificacion = chcVerificacion.Checked;

            int idResultado = Convert.ToInt32(cboResultComite.SelectedValue);
            string cComentario = txtObservResultado.Text.Trim();
            string cComentRev = txtComentRev.Text.Trim();

            clsEvalCredComite objEvalCred = (clsEvalCredComite)dtgEvaluaciones.SelectedRows[0].DataBoundItem;

            objEvalCred.idResultado = idResultado;
            objEvalCred.cComentario = cComentario;
            objEvalCred.cComentRev = cComentRev;
            objEvalCred.lVerificacion = chcVerificacion.Checked;
            objEvalCred.idMotRechazo = idResultado == 2 ? Convert.ToInt32(cboMotRechazo.SelectedValue) : (int?)null;

            clsDBResp objDbResp = objCNComiteCred.CNDecisionFinalEvalComite(objEvalCred, objCreditoProp);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (objDbResp.idGenerado == 0)
                {
                    MessageBox.Show("Error al enviar correo electrónico a asesor.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (idResultado == 1)
                {
                    GeneraInformeRiesgos(objEvalCred);
                }

                //objEvalCred.ComiteCred =
                //objComite = objCNComiteCred.CNGetComitesCred(objEvalCred.ComiteCred.idComiteCred).FirstOrDefault();
                //objEvalCred = objComite.lstEvalCred.FirstOrDefault(x => x.idEval == objEvalCred.idEval);
                //dtgEvaluaciones.DataSource = objComite.lstEvalCred.ToList();
                //MapeaEvaluacion(objEvalCred);
                //HabilitarControlesComite(false);
                //if (objEvalCred.idResultado != null)
                //{
                //    DataRowView dr = (DataRowView)cboResultComite.SelectedItem;
                //    bool lEditar = (bool)dr["lEditar"];
                //    btnIniciar.Enabled = lEditar && !objEvalCred.lEstado;
                //}

                //HabilControlesDecision(objEvalCred);
                ActualizarData();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddObs_Click(object sender, EventArgs e)
        {
            if (dtgEvaluaciones.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione la evaluación de crédito.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAddEditObs frmEditObs = new frmAddEditObs();
            frmEditObs.idOrigenObs = 1;
            clsEvalCredComite objEvalCred = (clsEvalCredComite)dtgEvaluaciones.SelectedRows[0].DataBoundItem;

            if (objEvalCred.idUsuResponsable == null)
            {
                MessageBox.Show("Seleccione el responsable de la revisión de la evaluación.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsObservacion objObservacion = new clsObservacion();
            clsCreditoProp objCreditoProp = conCreditoTasa.ObtenerCreditoPropuesto();

            objObservacion.idObservacion = 0;
            objObservacion.idRegistro = objEvalCred.idSolicitud;
            objObservacion.idCli = objEvalCred.idCli;
            objObservacion.idTipoOperacion = 55;//Aprobaciones de créditos
            objObservacion.idUsuDestino = objCreditoProp.idAsesor;
            objObservacion.idOrigenObs = 1;//Comites
            objObservacion.idGrupoObs = 0;
            objObservacion.cGrupoObs = String.Empty;
            objObservacion.idTipObs = 0;
            objObservacion.cTipObs = String.Empty;
            objObservacion.cObservacion = String.Empty;
            objObservacion.lSubsanado = false;
            objObservacion.dFecha = clsVarGlobal.dFecSystem.Date;
            objObservacion.idUsuario = clsVarGlobal.User.idUsuario;

            frmEditObs.objObservacion = objObservacion;

            frmEditObs.ShowDialog();

            if (!frmEditObs.lAceptado) return;

            objEvalCred.lstObservaciones.Add(objObservacion);

            dtgObservaciones.DataSource = objEvalCred.lstObservaciones.ToList();
        }

        private void btnQuitObs_Click(object sender, EventArgs e)
        {
            if (dtgEvaluaciones.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione la evaluación de crédito.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtgObservaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a eliminar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsObservacion objObservacion = (clsObservacion)dtgObservaciones.SelectedRows[0].DataBoundItem;
            clsEvalCredComite objEvalCred = (clsEvalCredComite)dtgEvaluaciones.SelectedRows[0].DataBoundItem;

            if (objObservacion.idObservacion > 0)
            {
                MessageBox.Show("No se pueden eliminar las observaciones.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            objEvalCred.lstObservaciones.Remove(objObservacion);

            dtgObservaciones.DataSource = objEvalCred.lstObservaciones.ToList();
        }

        private void btnEditObs_Click(object sender, EventArgs e)
        {
            if (dtgEvaluaciones.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione la evaluación de crédito.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtgObservaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a editar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsEvalCredComite objEvalCred = (clsEvalCredComite)dtgEvaluaciones.SelectedRows[0].DataBoundItem;
            clsObservacion objObservacion = dtgObservaciones.SelectedRows[0].DataBoundItem as clsObservacion;

            if (objObservacion.idObservacion != 0)
            {
                MessageBox.Show("Solo se pueden editar las observaciones nuevas.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAddEditObs frmEditObs = new frmAddEditObs();

            frmEditObs.idOrigenObs = objObservacion.idOrigenObs;
            frmEditObs.objObservacion = objObservacion;
            frmEditObs.ShowDialog();

            dtgObservaciones.DataSource = objEvalCred.lstObservaciones.ToList();
        }

        private void btnSubsanar_Click(object sender, EventArgs e)
        {
            if (dtgObservaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione la observación a subsanar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            clsObservacion objObservacion = dtgObservaciones.SelectedRows[0].DataBoundItem as clsObservacion;
            if (objObservacion == null) return;

            if (objObservacion.idObservacion == 0)
            {
                MessageBox.Show("No se puede subsanar una observacion recien creada.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsEvalCredComite objEval = dtgEvaluaciones.SelectedRows[0].DataBoundItem as clsEvalCredComite;

            objObservacion.lSubsanado = true;
            objObservacion.dFecha = clsVarGlobal.dFecSystem.Date;
            objObservacion.idUsuario = clsVarGlobal.User.idUsuario;


            string xmlObservaciones = objEval.lstObservaciones.GetXml<clsObservacion>();
            clsDBResp objDbResp = new clsCNObservaciones().CNGuardarObservaciones(xmlObservaciones);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                objEval.lstObservaciones = new clsCNObservaciones().CNGetObservaciones(objEval.idSolicitud, 55);
                dtgObservaciones.DataSource = objEval.lstObservaciones.ToList();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPosIntInterv_Click(object sender, EventArgs e)
        {
            if (dtgEvaluaciones.SelectedRows.Count > 0)
            {
                clsEvalCredComite objEvalCred = (clsEvalCredComite)dtgEvaluaciones.SelectedRows[0].DataBoundItem;

                new frmPosicionInterv().MostrarReporte(objEvalCred.cDocumentoID, objEvalCred.cNombre, objEvalCred.idCli);
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (dtgEvaluaciones.SelectedRows.Count > 0)
            {
                clsEvalCredComite objEvalCred = (clsEvalCredComite)dtgEvaluaciones.SelectedRows[0].DataBoundItem;

                if (objEvalCred.idUsuResponsable == null)
                {
                    MessageBox.Show("Seleccione el usuario responsable de la revisión.", cTituloMsjes,
                                                                                    MessageBoxButtons.OK,
                                                                                    MessageBoxIcon.Warning);
                    return;
                }
                objEvalCred.ComiteCred.dFecha = clsVarGlobal.dFecSystem.Date;
                objEvalCred.ComiteCred.idUsuario = clsVarGlobal.User.idUsuario;
                clsDBResp objDbResp = objCNComiteCred.CNIniciarEvalComiteCred(objEvalCred);
                if (objDbResp.nMsje == 0)
                {
                    MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HabilitarControlesComite(true);
                }
                else
                {
                    MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //HabilControlesDecision(objEvalCred);
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (objComite.lstEvalCred.Any(x => x.idResultado == null))
            {
                MessageBox.Show("Existen créditos sin decisión. No se puede finalizar el comité.", cTituloMsjes,
                                                                                            MessageBoxButtons.OK,
                                                                                            MessageBoxIcon.Warning);
                return;
            }
            if (objComite.lstEvalCred.Any((x => x.idResultado == 3)))
            {
                DialogResult result = MessageBox.Show("Existen créditos en ajuste. ¿Está seguro de finalizar el comité?.", cTituloMsjes,
                                                                                                                        MessageBoxButtons.YesNo,
                                                                                                                        MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Está seguro de finalizar el comité?.", cTituloMsjes,
                                                                                            MessageBoxButtons.YesNo,
                                                                                            MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
            }

            objComite.idEstado = 3;
            objComite.dFecha = clsVarGlobal.dFecSystem.Date;
            objComite.idUsuario = clsVarGlobal.User.idUsuario;

            clsDBResp objDbResp = objCNComiteCred.CNFinalizaComite(objComite);

            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cboResultComite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboResultComite.SelectedValue != null)
            {
                DataRowView dv = cboResultComite.SelectedItem as DataRowView;
                if (dv != null)
                {
                    int idResultado = Convert.ToInt32(dv.Row["idResultado"]);
                    lblMotRechazo.Visible = idResultado == 2;
                    cboMotRechazo.Visible = idResultado == 2;
                }
            }
        }

        private void btnActaAprob_Click(object sender, EventArgs e)
        {
            if (dtgEvaluaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro para mostrar el reporte.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            clsEvalCredComite objEvalCred = dtgEvaluaciones.SelectedRows[0].DataBoundItem as clsEvalCredComite;

            if (!objEvalCred.idEstSol.In(2, 4))
            {
                MessageBox.Show("El crédito no está aprobado ni denegado.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cNomAgen = clsVarApl.dicVarGen["cNomAge"];

            int idSolicitud = objEvalCred.idSolicitud;

            DataSet dsData = new clsRPTCNCredito().CNGenActaAprobDenegCred(idSolicitud);

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

            string reportpath = "rptActaAprobacionCredito.rdlc";

            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //if (objComite != null)
            //{
            //    objComite = objCNComiteCred.CNGetComitesCred(objComite.idComiteCred).FirstOrDefault();

            //    HabilitarControlesComite(false);
            //    MapeaEntidadControles(objComite);
            //    if (lSoloLectura)
            //    {
            //        FormSoloLectura();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("No se encontró comite de créditos.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    this.Dispose();
            //}
            ActualizarData();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dtgEvaluaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una evaluación de créditos.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsEvalCredComite objEvalCred = dtgEvaluaciones.SelectedRows[0].DataBoundItem as clsEvalCredComite;
            frmExpEval frmExpEval = new frmExpEval(objEvalCred.idEval, objEvalCred.idSolicitud, objEvalCred.idTipEval);
            frmExpEval.ShowDialog();
        }

        #endregion

        #region Metodos

        public frmControlComitesCred()
        {
            InitializeComponent();
            cboAsesor.ListarPersonal(0, false);
            conCreditoTasa.AutoSize = false;
            conCreditoTasa.Size = new Size(628, 205);
            foreach (TabPage tbpage in tbcDetComite.TabPages)
            {
                tbpage.Show();
            }
            tbpCondCred.Show();
        }

        private void LimpiarControles()
        {
            txtNomComite.Text = String.Empty;
            txtDescComite.Text = String.Empty;

            dtgEvaluaciones.DataSource = new List<clsEvalCredComite>().ToList();

            dtgParticipantes.DataSource = new List<clsDecisComite>().ToList();
        }

        private void MapeaEntidadControles(clsComiteCred objComite)
        {
            LimpiarControles();

            txtNomComite.Text = objComite.cNomComite;
            txtDescComite.Text = objComite.cDescComite;
            txtAgencia.Text = objComite.cNombreAge;

            dtgEvaluaciones.DataSource = objComite.lstEvalCred.ToList();
        }

        private bool ValidarDecision()
        {
            if (dtgEvaluaciones.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Seleccione la evaluación de crédito.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboResultComite.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el resultado para la evaluación.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            clsEvalCredComite objEvalCred = (clsEvalCredComite)dtgEvaluaciones.SelectedRows[0].DataBoundItem;

            if (objEvalCred.idUsuResponsable == null)
            {
                MessageBox.Show("Seleccione el usuario responsable de la revisión de la evaluación.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (objEvalCred.idNivelAprRanOpe == null)
            {
                MessageBox.Show("El usuario no tiene niveles de aprobación para este producto.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Convert.ToInt32(cboResultComite.SelectedValue) == 1 && objEvalCred.lstObservaciones.Any(x=>!x.lSubsanado))
            {
                MessageBox.Show("No se puede aprobar. Existen observacion sin subsanar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToInt32(cboResultComite.SelectedValue) == 2 && cboMotRechazo.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el motivo de rechazo.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (String.IsNullOrEmpty(txtObservResultado.Text))
            {
                MessageBox.Show("Ingrese observación y/o comentario.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (String.IsNullOrEmpty(txtComentRev.Text))
            {
                MessageBox.Show("Ingrese el comentario de la revisión.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (Convert.ToInt32(cboResultComite.SelectedValue).In(3, 4))
            {
                if (!objEvalCred.lstObservaciones.Any())
                {
                    MessageBox.Show("Debe ingresar por lo menos una observación.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (conCreditoTasa.MontoPropuesto > nMontoSolicitado)
            {
                MessageBox.Show("El monto propuesto no puede aumentar.", "Valida Cambio de Estado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            clsMsjError objError = conCreditoTasa.Validar();

            if (objError.HasErrors)
            {
                MessageBox.Show("La propuesta contiene errores.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            clsCreditoProp objCreditoProp = conCreditoTasa.ObtenerCreditoPropuesto();

            if (objCreditoProp == null)
            {
                MessageBox.Show("La propuesta contiene errores.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void MapeaEvaluacion(clsEvalCredComite objEvalCred)
        {
            LimpiarControlesEval();
            clsCreditoProp objCreditoProp = new clsCNSolCre().GetCreditoPropSol(objEvalCred.idSolicitud);
            conCreditoTasa.AsignarDatos(objCreditoProp);
            nMontoSolicitado = objCreditoProp.nMonto;
            cboResultComite.SelectedValue = objEvalCred.idResultado ?? 0;
            txtNumEva.Text = objCreditoProp.idEvalCred.ToString();
            cboAsesor.SelectedValue = objCreditoProp.idAsesor;
            cboOperacionCre.SelectedValue = objCreditoProp.idOperacion;
            txtObservResultado.Text = objEvalCred.cComentario;
            txtNivelAproba.Text = objEvalCred.cNivelAproba;
            txtRangoAproba.Text = objEvalCred.cRangoAproba;
            chcVerificacion.Checked = objEvalCred.lVerificacion;
            cboMotRechazo.SelectedValue = objEvalCred.idMotRechazo ?? 0;
            txtComentRev.Text = objEvalCred.cComentRev;
            MostrarExcepciones(objEvalCred.idSolicitud);
            MostrarGarantias(objEvalCred.idSolicitud);

            conCreditoTasa.CuotasEnabled = objCreditoProp.idOperacion.In(1, 2, 3, 4);
            conCreditoTasa.DiasGraciaEnabled = objCreditoProp.idOperacion.In(1, 2, 4);
            conCreditoTasa.FechaDesembolsoEnabled = objCreditoProp.idOperacion.In(1, 2, 4);
            conCreditoTasa.MontoEnabled = objCreditoProp.idOperacion.In(1, 4);
            conCreditoTasa.PlazoCuotaEnabled = objCreditoProp.idOperacion.In(1, 2, 3, 4);
            //conCreditoTasa.TEAEnabled = objCreditoProp.idOperacion.In(1, 4);
            conCreditoTasa.TipoPeriodoEnabled = objCreditoProp.idOperacion.In(1, 2, 4);
            conCreditoTasa.TipoTasaCreditoEnabled = objCreditoProp.idOperacion.In(1, 2, 4);
            conCreditoTasa.TEAEnabled = !objCreditoProp.idOperacion.In(3);

            conCreditoTasa.NivelesProductoEnabled = false;
            conCreditoTasa.MonedaEnabled = false;

            //conImpFormatEval.cargarDatosEval(objEvalCred.idEval,objEvalCred.idSolicitud,objEvalCred.idTipEval);

            //btnIniciar.Enabled = (objEvalCred.idResultado == null);
            //btnResponsable.Enabled = (objEvalCred.idResultado == null);
            //btnOpinion.Enabled = (objEvalCred.idResultado == null);
            //btnCancelar.Enabled = objEvalCred.idResultado == null && !btnIniciar.Enabled;

            //if (objEvalCred.idResultado != null)
            //{
            //    DataRowView dr = (DataRowView)cboResultComite.SelectedItem;
            //    bool lEditar = (bool)dr["lEditar"];
            //    btnIniciar.Enabled = lEditar && !objEvalCred.lEstado;
            //}

            dtgObservaciones.DataSource = objEvalCred.lstObservaciones.ToList();

            //HabilControlesDecision(objEvalCred);
        }

        private void HabilitarControlesComite(bool lHabil)
        {
            tbpExpediente.Enabled = lHabil;
            tbpCondCred.Enabled = lHabil;
            tbpDecision.Enabled = lHabil;

            cboResultComite.Enabled = lHabil;
            txtObservResultado.Enabled = lHabil;
            dtgObservaciones.Enabled = lHabil;
            btnAddObs.Enabled = lHabil;
            btnQuitObs.Enabled = lHabil;
            btnEditObs.Enabled = lHabil;
            btnResponsable.Enabled = !lHabil;
            btnOpinion.Enabled = lHabil;
            btnActualizar.Enabled = !lHabil;
            txtComentRev.Enabled = lHabil;
            //dtgParticipantes.Enabled = !lHabil;

            dtgEvaluaciones.Enabled = !lHabil;
            btnIniciar.Enabled = !lHabil;
            //btnCancelar.Enabled = lHabil;
        }

        private void LimpiarControlesEval()
        {
            txtNumEva.Text = String.Empty;
            cboAsesor.SelectedIndex = -1;
            cboOperacionCre.SelectedIndex = -1;
            cboMotRechazo.SelectedIndex = -1;

            cboResultComite.SelectedIndex = -1;
            txtObservResultado.Text = String.Empty;
            dtgObservaciones.DataSource = null;
            txtComentRev.Text = String.Empty;
            chcVerificacion.Checked = false;
            chcOpinionRiesgos.Checked = false;

        }

        private bool ValidarReglas()
        {
            string cCumpleReglas = String.Empty;
            int nNivAuto = 0;
            DataTable dtParametros = ArmarTablaParametros();

            cCumpleReglas = new clsCNValidaReglasDinamicas().ValidarReglas(dtTablaParametros: dtParametros,
                                                                            cNombreFormulario: "frmRegComiteCred",
                                                                            idAgencia: clsVarGlobal.nIdAgencia,
                                                                            idCliente: 0,
                                                                            idEstadoOperac: 1,
                                                                            idMoneda: 1,
                                                                            idProducto: 1,
                                                                            nValAproba: 0,
                                                                            idDocument: 0,
                                                                            dFecSolici: clsVarGlobal.dFecSystem,
                                                                            idMotivo: 0,
                                                                            idEstadoSol: 1,
                                                                            idUsuRegist: clsVarGlobal.User.idUsuario,
                                                                            idSolApr: ref nNivAuto);

            if (cCumpleReglas.Equals("Cumple"))
            {
                return true;
            }
            return false;
        }

        private DataTable ArmarTablaParametros()
        {
            clsEvalCredComite objEvalCredComite = dtgEvaluaciones.SelectedRows[0].DataBoundItem as clsEvalCredComite;
            clsCreditoProp objCreditoProp = conCreditoTasa.ObtenerCreditoPropuesto();
            int idCli = objEvalCredComite.idCli;
            int idSolCred = objEvalCredComite.idSolicitud;
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            //Obtenemos los datos generales del cliente

            DataTable dtDatCli = new clsCNBuscarCli().GetDatosGenCli(idCli);

            foreach (DataColumn column in dtDatCli.Columns)
            {
                if (column.DataType == typeof(DateTime))
                {
                    dtTablaParametros.Rows.Add(column.ColumnName,
                        ((DateTime)dtDatCli.Rows[0][column.ColumnName]).ToString("yyyy-MM-dd"));
                }
                else
                {
                    dtTablaParametros.Rows.Add(column.ColumnName,
                        dtDatCli.Rows[0][column.ColumnName].ToString());
                }
            }

            DataTable dtDatSolCre = new clsCNSolicitud().CNGetDatGenCreSolCre(idSolCred);

            foreach (DataColumn column in dtDatSolCre.Columns)
            {
                if (column.DataType == typeof(DateTime))
                {
                    dtTablaParametros.Rows.Add(column.ColumnName,
                        ((DateTime)dtDatSolCre.Rows[0][column.ColumnName]).ToString("yyyy-MM-dd"));
                }
                else
                {
                    dtTablaParametros.Rows.Add(column.ColumnName,
                        dtDatSolCre.Rows[0][column.ColumnName].ToString());
                }
            }

            DataRow drfila = dtTablaParametros.NewRow();

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idResultado";
            drfila[1] = Convert.ToInt32(cboResultComite.SelectedValue);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTipCamFij";
            drfila[1] = Convert.ToDecimal(clsVarApl.dicVarGen["nTipCamFij"]);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nValAproba";
            drfila[1] = objCreditoProp.nMonto;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTasaCompForm";
            drfila[1] = objCreditoProp.nTasaCompensatoria;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMonedaForm";
            drfila[1] = objCreditoProp.idMoneda;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idOperacionForm";
            drfila[1] = objCreditoProp.idOperacion;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idProductoForm";
            drfila[1] = objCreditoProp.idProducto;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idNivelAprRanOpeForm";
            drfila[1] = objCreditoProp.idNivelAprRanOpe;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nCuotasForm";
            drfila[1] = objCreditoProp.nCuotas;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTEAForm";
            drfila[1] = objCreditoProp.nTea;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "lVerificacionForm";
            drfila[1] = chcVerificacion.Checked;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoOpe";
            drfila[1] = 55;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCliUser";
            drfila[1] = clsVarGlobal.User.idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idUserPersonal";
            drfila[1] = clsVarGlobal.User.idUsuario.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCli";
            drfila[1] = idCli.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaActual";
            drfila[1] = "'" + clsVarGlobal.dFecSystem.ToString("yyyy-MM-dd") + "'";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCanal";
            drfila[1] = clsVarGlobal.idCanal.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nIdAgencia";
            drfila[1] = clsVarGlobal.nIdAgencia.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nITF";
            drfila[1] = clsVarGlobal.nITF.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idPerfil";
            drfila[1] = clsVarGlobal.PerfilUsu.idPerfil.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaCese";
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "dFechaIngreso";
            drfila[1] = clsVarGlobal.User.dFechaIngreso.Year.ToString("yyyy-MM-dd");
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idCargo";
            drfila[1] = clsVarGlobal.User.idCargo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimOpePacSol";
            drfila[1] = clsVarApl.dicVarGen["nLimOpePacSol"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimOpePacDol";
            drfila[1] = clsVarApl.dicVarGen["nLimOpePacDol"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimIndividual";
            drfila[1] = clsVarApl.dicVarGen["nLimIndividual"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nLimGlobal";
            drfila[1] = clsVarApl.dicVarGen["nLimGlobal"];
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idModulo";
            drfila[1] = clsVarGlobal.idModulo.ToString();
            dtTablaParametros.Rows.Add(drfila);

            return dtTablaParametros;
        }

        private void FormSoloLectura()
        {
            tbpExpediente.Enabled = false;
            tbpCondCred.Enabled = false;
            tbpDecision.Enabled = false;

            btnResponsable.Enabled = false;
            btnOpinion.Enabled = false;
            txtComentRev.Enabled = false;

            btnIniciar.Enabled = false;
            //btnCancelar.Enabled = false;
            btnPosIntInterv.Enabled = true;
            btnFinalizar.Enabled = false;
            btnActaAprob.Enabled = false;

        }

        private void MostrarExcepciones(int idSolicitud)
        {
            DataTable dtData = objCNComiteCred.CNListExcepcionesSolCre(idSolicitud, 55);
            dtgExcepciones.DataSource = dtData;
        }

        private void MostrarGarantias(int idSolicitud)
        {
            DataSet dsGarantias = objCNComiteCred.CNLstGarantiasSolCre(idSolicitud);
            DataTable dtFiadorSolidario = dsGarantias.Tables[0];
            DataTable dtGarantias = dsGarantias.Tables[1];

            dtgFiadorSolidario.DataSource = dtFiadorSolidario;
            dtgGarantias.DataSource = InvertirCamporGarantias(dtGarantias);
            formatoDTGGarantias();
        }
        private void formatoDTGGarantias()
        {
            foreach (DataGridViewColumn item in this.dtgGarantias.Columns)
            {
                item.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", (float)(7.5));
            }
        }
        private void GeneraInformeRiesgos(clsEvalCredComite objEval)
        {
            int nNivAuto = 0;
            DataTable dtParametros = ArmarTablaParametros();
            DataSet dsSolInfRiesgo = new DataSet("dssolici");
            DataTable dtSolInfRiesgo = new DataTable("dtSolInfRiesgo");
            dtSolInfRiesgo.Columns.Add("nIdRegla", typeof(int));
            dtSolInfRiesgo.Columns.Add("cMensajeError", typeof(string));


            DataTable dtReglasConResultado = new clsCNValidaReglasDinamicas().ObtenerReglasConResultado(dtParametros, "frmRegComiteCred");

            var resultReglasRiesgos = dtReglasConResultado.AsEnumerable()
                                            .Where(x => Convert.ToBoolean(x["lAlertaRiesgo"])
                                                && x["lResul"].ToString().Trim().ToUpper().Equals("OK"));

            if (resultReglasRiesgos.Any() || chcOpinionRiesgos.Checked)
            {
                DataTable dtReglasRiesgos = null;
                DataRow drRegla = null;
                if (resultReglasRiesgos.Count() > 0)
                {
                    dtReglasRiesgos = resultReglasRiesgos.CopyToDataTable();
                    drRegla = dtReglasRiesgos.Rows[0];
                    DataRow drfila = dtSolInfRiesgo.NewRow();
                    drfila["nIdRegla"] = Convert.ToInt32(drRegla["nIdRegla"]);
                    drfila["cMensajeError"] = Convert.ToString(drRegla["cMensajeError"]);
                    dtSolInfRiesgo.Rows.Add(drfila);
                }
                if (chcOpinionRiesgos.Checked)
                {
                    DataRow drfila = dtSolInfRiesgo.NewRow();
                    drfila["nIdRegla"] = 0;
                    drfila["cMensajeError"] = "Solicitud de comité de créditos";
                    dtSolInfRiesgo.Rows.Add(drfila);
                }
                dsSolInfRiesgo.Tables.Add(dtSolInfRiesgo);
                string XmlSoli = dsSolInfRiesgo.GetXml();
                XmlSoli = clsCNFormatoXML.EncodingXML(XmlSoli);
                dsSolInfRiesgo.Clear();
                new clsCNInformeRiesgos().InsertSolicitudInformeRiesgos(XmlSoli, objEval.idSolicitud);

                MessageBox.Show("Se agregó el informe de riesgos para la solicitud.", "Actualizar estado de solicitud",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ActualizarData()
        {
            if (objComite != null)
            {
                objComite = objCNComiteCred.CNGetComitesCred(objComite.idComiteCred,0,dFecMinValue, dFecMaxValue).FirstOrDefault();

                HabilitarControlesComite(false);
                MapeaEntidadControles(objComite);
                if (lSoloLectura)
                {
                    FormSoloLectura();
                }
            }
            else
            {
                MessageBox.Show("No se encontró comite de créditos.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Dispose();
            }
        }
        private DataTable InvertirCamporGarantias(DataTable dtGarantias)
        {
            DataTable dtInvertidoGaranti = new DataTable();
            dtInvertidoGaranti.Columns.Add("Campo", typeof(String));
            if (dtGarantias.Rows.Count == 0)
            {
                DataRow drFila = dtInvertidoGaranti.NewRow();
                drFila["Campo"] = "Sin garantias";
                dtInvertidoGaranti.Rows.Add(drFila);
                return dtInvertidoGaranti;
            }
            for (int k = 1; k <= dtGarantias.Rows.Count; k++)
            {
                dtInvertidoGaranti.Columns.Add("Garantía_" + k, typeof(String));
            }
            for (int i = 0; i < dtGarantias.Columns.Count; i++)
            {
                if (dtGarantias.Columns[i].ColumnName == "idGarantia")
                {
                    break;
                }
                DataRow drFila = dtInvertidoGaranti.NewRow();
                if (String.Compare(dtGarantias.Columns[i].ColumnName,"cTipoGarantia") == 0)
                    drFila["Campo"] = "Tipo de Garantía";
                else if (String.Compare(dtGarantias.Columns[i].ColumnName,"cNombre") == 0)
                    drFila["Campo"] = "Propietario";
                else if (String.Compare(dtGarantias.Columns[i].ColumnName,"cGarantia") == 0)
                    drFila["Campo"] = "Descripción";
                else if (String.Compare(dtGarantias.Columns[i].ColumnName,"cUbigeo") == 0)
                    drFila["Campo"] = "Ubigeo";
                else if (String.Compare(dtGarantias.Columns[i].ColumnName, "nValorRealiza") == 0)
                    drFila["Campo"] = "Valor de realización";
                else if (String.Compare(dtGarantias.Columns[i].ColumnName, "dFecUltVal") == 0)
                    drFila["Campo"] = "Fecha de tasación";
                else
                    drFila["Campo"] = dtGarantias.Columns[i].ColumnName;
                for (int j = 0; j < dtGarantias.Rows.Count; j++)
                {
                    drFila["Garantía_" + (j+1)] = dtGarantias.Rows[j][i].ToString();
                }
                dtInvertidoGaranti.Rows.Add(drFila);
            }

            return dtInvertidoGaranti;
        }

        #endregion

    }
}
