using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using Microsoft.Reporting.WinForms;
using RPT.CapaNegocio;
using CRE.CapaNegocio;
using CRE.Presentacion;
using GEN.Funciones;
using CLI.Servicio;

namespace ADM.Presentacion
{
    public partial class frmAprobacionSolicitud : frmBase
    {

        #region Variables

        private clsCNAprobacion objAprobacion = new clsCNAprobacion();
        private DataTable dtSoliciAproba;
        private ADM.CapaNegocio.clsCNMantOperaciones objOperacion = new ADM.CapaNegocio.clsCNMantOperaciones();
        private const string cTituloMsjes = "Aprobación de solicitudes";
        private int idTipoOpe = 0;
        private ContextMenuStrip cmsOpciones = new ContextMenuStrip();
        private clsCreditoProp objCreditoProp;
        private decimal nValAprobaSol = 0m;
        private int idEstadoSolAproba = 0;
        private clsEvalCredComite objEvalCred = null;
        private int idDocumento = 0;
        private int idEstadoCartaFiaza = 0;

        DataTable dtVariable;
        private int nValVar = 0;

        DataTable dtVariableVB;
        private int nValVarVB = 0;

        public CRE.CapaNegocio.clsCNCredito cnCredito = new CRE.CapaNegocio.clsCNCredito();
        #endregion

        #region Eventos

        private void frmAprobacionSolicitud_Load(object sender, EventArgs e)
        {
            dtgObservaciones.AutoGenerateColumns = false;
            dtgLisSoliciAproba.ReadOnly = true;
            txtOpinion.Enabled = false;
            btnAprobar.Enabled = false;
            btnRechazar.Enabled = false;
            btnAprobar.Tag = 2;
            btnRechazar.Tag = 4;

            cmsOpciones.Items.Add("Ver Reportes", null, btnReportes_Click);
            cmsOpciones.Items.Add("Condiciones de crédito", null, CondCred_Click);
            cmsOpciones.Items.Add("Ver Detalle", null, DetalleSol_Click);
            cmsOpciones.Items.Add("Ver informe de riesgos", null, VerInformeRiesgos_Click);
            cmsOpciones.Items.Add("Ver Solicitud de Reasignación", null, mostrarReasignacion_Click);
            cmsOpciones.Items.Add("Ver Sustento Excepción Biométrica", null, mostrarSustentoExcpBiometrica_Click);

            // Aprobacion de Tasas Negociables - TIPO PRODUCTO
            dtVariable = objAprobacion.CNExtractTipoVariable("nIdPreAprobaTNegociable");
            if (dtVariable.Rows.Count > 0)
            {
                nValVar = Convert.ToInt32(dtVariable.Rows[0]["cValVar"].ToString());
            }

            dtVariableVB = objAprobacion.CNExtractTipoVariable("nIdVistoBuenoTasaNegociable");
            if (dtVariableVB.Rows.Count > 0)
            {
                nValVarVB = Convert.ToInt32(dtVariableVB.Rows[0]["cValVar"].ToString());
            }
            //

            cargarLisSoliciAproba();
            pnlRechazoCred.Visible = false;

            foreach (DataGridViewColumn item in dtgLisSoliciAproba.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            DataView dtvTipoOperacion = new DataView(dtSoliciAproba);
            DataTable dtTipoOperacion = dtvTipoOperacion.ToTable(true, "idTipoOperacion");

            if (dtTipoOperacion.Rows.Count > 0)
            {
                DataTable dtTipoOp = new DataTable();
                dtTipoOp = objOperacion.ListarTipoOperaciones();

                DataTable dtTipoOpeFill = (from t1 in dtTipoOp.AsEnumerable()
                                           join t2 in dtTipoOperacion.AsEnumerable() on t1.Field<int>("idTipoOperacion") equals t2.Field<int>("idTipoOperacion")
                                           select t1).CopyToDataTable();

                DataRow filaTodos = dtTipoOpeFill.NewRow();
                filaTodos["idTipoOperacion"] = "0";
                filaTodos["cTipoOperacion"] = "TODOS";
                dtTipoOpeFill.Rows.InsertAt(filaTodos, 0);
                cboTipoOperacion.ValueMember = "idTipoOperacion";
                cboTipoOperacion.DisplayMember = "cTipoOperacion";
                cboTipoOperacion.DataSource = dtTipoOpeFill;
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (chcAprob.Checked)
            {
                CargarSoliciAproba();
            }
            else
            {
                cargarLisSoliciAproba();
            }
        }

        private void dtgLisSoliciAproba_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //int iFilaTipOpe = e.RowIndex;
            int iFilaTipOpe = 0;

            if (!Convert.ToBoolean(dtgLisSoliciAproba.Rows[e.RowIndex].Cells["lAprobaLimiteExcep"].Value))
            {
                LimpiarControles();
                return;
            }

            int idSol = Convert.ToInt32(dtgLisSoliciAproba.Rows[e.RowIndex].Cells["idSolAproba"].Value);
            for (int i = 0; i < dtSoliciAproba.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtSoliciAproba.Rows[i]["idSolAproba"]) == idSol)
                {
                    iFilaTipOpe = i;
                    break;
                }
            }

            idTipoOpe = Convert.ToInt32(dtSoliciAproba.Rows[iFilaTipOpe]["idTipoOperacion"]);
            int idDocumentSol = Convert.ToInt32(dtSoliciAproba.Rows[iFilaTipOpe]["idDocument"]);

            txtIdSolAproba.Text = dtSoliciAproba.Rows[iFilaTipOpe]["idSolAproba"].ToString();
            txtNomCliente.Text = dtSoliciAproba.Rows[iFilaTipOpe]["cNomCliente"].ToString();
            txtProducto.Text = dtSoliciAproba.Rows[iFilaTipOpe]["cProducto"].ToString();
            txtTipoOperacion.Text = dtSoliciAproba.Rows[iFilaTipOpe]["cTipoOperacion"].ToString();
            txtDocument.Text = idDocumentSol.ToString();
            txtMoneda.Text = dtSoliciAproba.Rows[iFilaTipOpe]["cMoneda"].ToString();
            txtValAproba.Text = dtSoliciAproba.Rows[iFilaTipOpe]["nValAproba"].ToString();
            txtMotivo.Text = dtSoliciAproba.Rows[iFilaTipOpe]["cMotivo"].ToString();
            txtSustento.Text = dtSoliciAproba.Rows[iFilaTipOpe]["cSustento"].ToString();
            txtOpinion.Text = dtSoliciAproba.Rows[iFilaTipOpe]["cOpinion"].ToString();
            txtFecSolici.Text = Convert.ToDateTime(dtSoliciAproba.Rows[iFilaTipOpe]["dFecSolici"]).ToShortDateString();
            this.idDocumento = idDocumentSol;
            cboMotRechazo.SelectedIndex = -1;

            dtgObservaciones.DataSource = new clsCNObservaciones().CNGetObservaciones(idDocumentSol,idTipoOpe).ToList();

            if (idTipoOpe == 55)
            {
                objEvalCred = new clsCNEvalCred().CNGetEvalCredSolCred(idDocumentSol);
            }

            if ( idTipoOpe == 120 )
            {
                DataTable dtDatosCarta = new clsCNCartaFianza().ObtenerDatosBasicos(idDocumentSol);
                if (dtDatosCarta.Rows.Count > 0)
                {
                    idEstadoCartaFiaza = Convert.ToInt32(dtDatosCarta.Rows[0]["idEstadoCartaFianza"]);
                }

            }

            bool lAprobRow = Convert.ToBoolean(dtSoliciAproba.Rows[iFilaTipOpe]["lAprob"]);
            bool lSoloComentRow = Convert.ToBoolean(dtSoliciAproba.Rows[iFilaTipOpe]["lSoloComent"]);

            btnAprobar.Enabled = !lAprobRow;
            btnDevolver.Visible = !(lAprobRow);
            btnAddObs.Enabled = !(lAprobRow);
            btnQuitObs.Enabled = !(lAprobRow);
            btnEditObs.Enabled = !(lAprobRow);
            btnSubsanar.Enabled = !(lAprobRow);
            btnAprobar.Text = lSoloComentRow ? "Revisar" : "Aprobar";
            btnRechazar.Enabled = !lSoloComentRow;
            btnActualizar.Enabled = true;

            txtOpinion.Enabled = dtSoliciAproba.Rows.Count > 0;

            btnConsultarSolCondonacion.Visible = (idTipoOpe == 7 || idTipoOpe == nValVar || idTipoOpe == nValVarVB);
            btnDevolver.Enabled = (idTipoOpe != nValVar && idTipoOpe != nValVarVB);

            int idTipoOpeGiro = 0;
            clsVarGen objVarTipoOpeGiro = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("nIdTipOpeGiroDesblClave"));
            idTipoOpeGiro = Convert.ToInt32(objVarTipoOpeGiro.cValVar);

            if (idTipoOpe == 196)
            {
                btnDevolver.Visible = false;
            }
            btnVerAdjuntos.Visible = (idTipoOpe == idTipoOpeGiro);                        
        }

        private void AprobarRechazar_Click(object sender, EventArgs e)
        {
            if (dtgLisSoliciAproba.Rows.Count <= 0)
            {
                MessageBox.Show("No existe ninguna solicitud seleccionada", "Aprobación de Solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (String.IsNullOrEmpty(txtOpinion.Text.Trim()))
            {
                MessageBox.Show("Registrar Opinión", "Aprobación de solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtOpinion.Focus();
                return;
            }
            if (idTipoOpe == 55 && objEvalCred != null)
            {
                if (!objEvalCred.lFinalizoComite)
                {
                    MessageBox.Show("El comité de la evaluación no finalizó. No se puede aprobar ni denegar.", "Aprobación de solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (objEvalCred.lEditar)
                {
                    MessageBox.Show("La evaluación aun no fue devuelta para aprobación.", "Aprobación de solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if(idTipoOpe == frmControlLimitesBoveda.obtenerIdTipoOperacionSolicitud())
            {
                Int32 idAgencia = this.dtgLisSoliciAproba.SelectedRows.Count > 0 ? Convert.ToInt32(this.dtgLisSoliciAproba.SelectedRows[0].Cells["idAgencia"].Value) : 0;
                frmControlLimitesBoveda.mostrarNotificacionAprobador(idAgencia);
            }
            if ( idTipoOpe == 120 )
            {
                if ( idEstadoCartaFiaza > 0 && idEstadoCartaFiaza == 2 )
                {
                    MessageBox.Show("La carta fianza se encuentra devuelta. No puede realizar la aprobación", "Aprobación de solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }

            if (((Boton)sender).Name == "btnRechazar")
            {
                var Msg = MessageBox.Show("¿Está seguro de RECHAZAR la solicitud?", "Aprobación de Solicitudes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Msg != DialogResult.Yes)
                {
                    return;
                }
                if (idTipoOpe.In(55, 120))
                {
                    if (!pnlRechazoCred.Visible)
                    {
                        pnlRechazoCred.Visible = true;
                        btnAprobar.Enabled = false;
                        return;
                    }

                    if (cboMotRechazo.SelectedIndex == -1)
                    {
                        MessageBox.Show("Seleccione el motivo del rechazo del crédito.", "Aprobación de solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboMotRechazo.Focus();
                        return;
                    }
                }
            }

            int idSolAprobaSel = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idSolAproba"].Value);
            int idUsuario = Convert.ToInt32(clsVarGlobal.PerfilUsu.idUsuario);
            int idUsuarioRegistro = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idUsuRegist"].Value);
            int idPerfil = Convert.ToInt32(clsVarGlobal.PerfilUsu.idPerfil);

            if(idUsuario == idUsuarioRegistro)
            {
                MessageBox.Show("No puede aprobar o rechazar una solicitud que usted mismo registró.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.ConfigurarAprobSoli(idUsuario, idSolAprobaSel, idPerfil) == 0)
            {
                MessageBox.Show("Aprobación corresponde al nivel inmediato superior.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (((Boton)sender).Name == "btnAprobar")
            {
                if (dtgObservaciones.Rows.Cast<DataGridViewRow>().Count(x => !Convert.ToBoolean(x.Cells["lSubsanado"].Value)) > 0)
                {
                    MessageBox.Show("Para aprobar la solicitud debe de subsanar todas las observaciones.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                /** Confirmación de aprobación ***/
                if (
                    MessageBox.Show(
                        "¿Está seguro de APROBAR la solicitud?",
                        "Aprobación de Solicitudes",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                    ) == DialogResult.No
                )
                {
                    return;
                }
            }

            int iFilaTipOpe = dtgLisSoliciAproba.SelectedCells[0].RowIndex;
            int idSolAproba = (int)dtSoliciAproba.Rows[iFilaTipOpe]["idSolAproba"];
            int idNivelAprRanOpe = (int)dtSoliciAproba.Rows[iFilaTipOpe]["idNivelAprRanOpe"];
            int idEstado = Convert.ToInt16(((Boton)sender).Tag);
            idEstadoSolAproba = idEstado;
            string cOpinion = txtOpinion.Text;

            if (idTipoOpe.In(55,120))
            {
                if (objCreditoProp == null)
                {
                    int idSolicitud = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idDocument"].Value);
                    objCreditoProp = new clsCNSolCre().GetCreditoPropSol(idSolicitud);
                }
                if (idEstado == 4)
                {
                    objCreditoProp.idMotRechazo = Convert.ToInt32(cboMotRechazo.SelectedValue);
                }
            }
            else
            {
                objCreditoProp = new clsCreditoProp();
            }
            string cFecha = clsVarGlobal.dFecSystem.ToShortDateString();
            string cHora = DateTime.Now.ToString("hh:mm tt");
            string cFechayhora = cFecha + " " + cHora;

            DateTime dresultFechyHora;
            DateTime.TryParse(cFechayhora, out dresultFechyHora);

            RegAprobaSolicitud(idSolAproba, idNivelAprRanOpe, clsVarGlobal.User.idUsuario, idEstado,
                                cOpinion, dresultFechyHora, clsVarGlobal.PerfilUsu.idPerfil, objCreditoProp);
            if (chcAprob.Checked)
            {
                CargarSoliciAproba();
            }
            else
            {
                cargarLisSoliciAproba();
            }

        }

        private void chcAprob_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarControles();
            if (chcAprob.Checked)
            {
                CargarSoliciAprobadas();
                btnDevolver.Visible = false;
            }
            else
            {
                CargarSoliciNoAprobadas();
            }
        }

        private void btnAddObs_Click(object sender, EventArgs e)
        {
            frmAddEditObs frmEditObs = new frmAddEditObs();
            frmEditObs.idOrigenObs = 2;

            int idNivelAprRanOpe = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idNivelAprRanOpe"].Value);
            int idSolAproba = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idSolAproba"].Value);
            int idDocument = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idDocument"].Value);
            int idUsuDestino = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idUsuRegist"].Value);
            int idCli = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idCliente"].Value);

            clsObservacion objObservacion = new clsObservacion();

            objObservacion.idObservacion = 0;
            objObservacion.idRegistro = idDocument;
            objObservacion.idCli = idCli;
            objObservacion.idTipoOperacion = idTipoOpe;
            objObservacion.idUsuDestino = idUsuDestino;
            objObservacion.idSolAproba = idSolAproba;
            objObservacion.idNivelAprRanOpe = idNivelAprRanOpe;
            objObservacion.idOrigenObs = 2;//Aprobaciones
            objObservacion.idGrupoObs = 0;
            objObservacion.cGrupoObs = String.Empty;
            objObservacion.idTipObs = 0;
            objObservacion.cTipObs = String.Empty;
            objObservacion.cTipObs = String.Empty;
            objObservacion.cObservacion = String.Empty;
            objObservacion.lSubsanado = false;
            objObservacion.dFecha = clsVarGlobal.dFecSystem.Date;
            objObservacion.idUsuario = clsVarGlobal.User.idUsuario;

            frmEditObs.objObservacion = objObservacion;

            frmEditObs.ShowDialog();
            if (!frmEditObs.lAceptado) return;

            List<clsObservacion> lstObservaciones = dtgObservaciones.DataSource as List<clsObservacion>;
            lstObservaciones = lstObservaciones ?? new List<clsObservacion>();

            lstObservaciones.Add(objObservacion);

            dtgObservaciones.DataSource = lstObservaciones.ToList();
        }

        private void btnQuitObs_Click(object sender, EventArgs e)
        {
            if (dtgObservaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a eliminar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsObservacion objObservacion = (clsObservacion)dtgObservaciones.SelectedRows[0].DataBoundItem;

            if (objObservacion.idObservacion > 0)
            {
                MessageBox.Show("No se pueden eliminar las observaciones.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<clsObservacion> lstObservaciones = dtgObservaciones.DataSource as List<clsObservacion>;
            lstObservaciones = lstObservaciones ?? new List<clsObservacion>();
            lstObservaciones.Remove(objObservacion);
            dtgObservaciones.DataSource = lstObservaciones.ToList();
        }

        private void btnEditObs_Click(object sender, EventArgs e)
        {
            if (dtgObservaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a editar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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

            List<clsObservacion> lstObservaciones = dtgObservaciones.DataSource as List<clsObservacion>;
            lstObservaciones = lstObservaciones ?? new List<clsObservacion>();
            dtgObservaciones.DataSource = lstObservaciones.ToList();
        }

        private void btnSubsanar_Click(object sender, EventArgs e)
        {
            if (dtgObservaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione la observación a subsanar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idDocumentSol = (int)dtgLisSoliciAproba.SelectedRows[0].Cells["idDocument"].Value;
            int idNivelAprRanOpeSol = (int)dtgLisSoliciAproba.SelectedRows[0].Cells["idNivelAprRanOpe"].Value;
            clsObservacion objObservacion = dtgObservaciones.SelectedRows[0].DataBoundItem as clsObservacion;
            if (objObservacion == null) return;

            if (objObservacion.idObservacion == 0)
            {
                MessageBox.Show("No se puede subsanar una observacion recien creada.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (objObservacion.idNivelAprRanOpe != idNivelAprRanOpeSol)
            {
                MessageBox.Show("No se puede subsanar una observacion de otro nivel de aprobación.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (idTipoOpe == 55 && objEvalCred != null)
            {
                if (objEvalCred.lEditar)
                {
                    MessageBox.Show("La evaluación aun no fue devuelta por el asesor. No se puede subsanar.", "Aprobación de solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            objObservacion.lSubsanado = true;
            objObservacion.dFecha = clsVarGlobal.dFecSystem.Date;
            objObservacion.idUsuario = clsVarGlobal.User.idUsuario;

            List<clsObservacion> lstObservaciones = dtgObservaciones.DataSource as List<clsObservacion>;
            lstObservaciones = lstObservaciones ?? new List<clsObservacion>();
            string xmlObservaciones = lstObservaciones.GetXml<clsObservacion>();

            clsDBResp objDbResp = new clsCNObservaciones().CNGuardarObservaciones(xmlObservaciones);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                lstObservaciones = new clsCNObservaciones().CNGetObservaciones(idDocumentSol, idTipoOpe);
                dtgObservaciones.DataSource = lstObservaciones.ToList();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            int idTipoOpeGiro = 0;
            clsVarGen objVarTipoOpeGiro = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("nIdTipOpeGiroDesblClave"));
            idTipoOpeGiro = Convert.ToInt32(objVarTipoOpeGiro.cValVar);

            if (idTipoOpe == idTipoOpeGiro)
            {
                MessageBox.Show("No es posible Devolver la Solicitud con Este Tipo de Operación.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarDevolución()) return;

            List<clsObservacion> lstObservaciones = dtgObservaciones.DataSource as List<clsObservacion>;
            lstObservaciones = lstObservaciones ?? new List<clsObservacion>();
            string xmlObservaciones = lstObservaciones.GetXml<clsObservacion>();

            clsDBResp objDbResp = new clsCNObservaciones().CNGuardarObservaciones(xmlObservaciones);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (chcAprob.Checked)
                {
                    CargarSoliciAproba();
                }
                else
                {
                    cargarLisSoliciAproba();
                }
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (dtgLisSoliciAproba.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione la solicitud de aprobación de la que se mostrará el reporte", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (idTipoOpe == 55)//Aprobación de solicitud de créditos
            {
                if (objEvalCred == null)
                {
                    MessageBox.Show("No se encontró información.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //conImpFormatEval.cargarDatosEval(objEvalCred.idEval, objEvalCred.idSolicitud, objEvalCred.idTipEval);
                //conImpFormatEval.ImprimirCascada();
                frmExpEval frmExpEval = new frmExpEval(objEvalCred.idEval, objEvalCred.idSolicitud, objEvalCred.idTipEval);
                frmExpEval.ShowDialog();
            }
            if (idTipoOpe == 120)
            {

                DataTable dtDatosREAC = new clsCNCartaFianza().obtenerDatosClienteREAC(this.idDocumento);
                DataTable dtIntervinientes = new clsCNCartaFianza().listarIntervinientes(this.idDocumento);
                DataTable dtGarantias = new clsCNCartaFianza().listarGarantias(this.idDocumento);

                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                dtslist.Clear();

                paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));

                dtslist.Add(new ReportDataSource("dsIntervinientes", dtIntervinientes));
                dtslist.Add(new ReportDataSource("dsCartaFianza", dtDatosREAC));
                dtslist.Add(new ReportDataSource("dsGarantias", dtGarantias));

                string reportpath = "rptREAC.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void CondCred_Click(object sender, EventArgs e)
        {
            int idSolicitud = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idDocument"].Value);
            if (objCreditoProp == null || ((objCreditoProp != null) && (objCreditoProp.idSolicitud != idSolicitud)))
            {
                objCreditoProp = new clsCNSolCre().GetCreditoPropSol(idSolicitud);
            }
            frmCambiaCondSolCred frmPropuesta = new frmCambiaCondSolCred();
            frmPropuesta.idTipoOpe = idTipoOpe;
            frmPropuesta.ObjCreditoProp = objCreditoProp/*.Clone() as clsCreditoProp*/;
            frmPropuesta.ShowDialog();

            if (frmPropuesta.lAceptar)
            {
                objCreditoProp = frmPropuesta.ObjCreditoProp;
            }
        }

        private void DetalleSol_Click(object sender, EventArgs e)
        {
            if (dtgLisSoliciAproba.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione la solicitud de aprobación de la que se mostrará el detalle", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reportpath = String.Empty;

            if (idTipoOpe == 113)//Aprobación de solicitud de cambio de titulares de cuentas
            {
                int idSolicitud = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idSolAproba"].Value);
                int idCuenta = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idDocument"].Value);
                string cNomEmpresa = clsVarApl.dicVarGen["cNomEmpresa"];
                string cNomAgencia = clsVarApl.dicVarGen["cNomAge"];
                DateTime dFechaSis = clsVarGlobal.dFecSystem;

                clsRPTCNDeposito clsRPTCNDeposito = new clsRPTCNDeposito();
                DataTable dtDetSolCamTitu = clsRPTCNDeposito.CNRptDetalleSolCambioTitular(idSolicitud, idCuenta);

                if (dtDetSolCamTitu.Rows.Count > 0)
                {
                    List<ReportParameter> paramlist = new List<ReportParameter>();
                    paramlist.Clear();

                    paramlist.Add(new ReportParameter("x_cNomEmpresa", cNomEmpresa, false));
                    paramlist.Add(new ReportParameter("x_cNomAgen", cNomAgencia, false));
                    paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString("dd/MM/yyyy"), false));
                    paramlist.Add(new ReportParameter("x_cRutaLogo", new clsRPTCNAgencia().CNRutaLogo().Rows[0][0].ToString(), false));

                    List<ReportDataSource> dtslist = new List<ReportDataSource>();
                    dtslist.Clear();

                    dtslist.Add(new ReportDataSource("dsDetalleSolCambTitu", dtDetSolCamTitu));

                    reportpath = "RptDetalleSolCambioTitularesCta.rdlc";

                    new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
                }
                else
                {
                    MessageBox.Show("No Existen Datos para el Reporte", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void dtgLisSoliciAproba_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    dtgLisSoliciAproba.CurrentCell = dtgLisSoliciAproba.Rows[e.RowIndex].Cells[0];
                    if (dtgLisSoliciAproba.SelectedRows.Count > 0 && idTipoOpe.In(55, 113, 120, 196))
                    {
                        switch (idTipoOpe)
                        {
                            case 55:
                            case 120:
                                cmsOpciones.Items[0].Visible = true;
                                cmsOpciones.Items[1].Visible = false;
                                cmsOpciones.Items[2].Visible = false;
                                cmsOpciones.Items[3].Visible = true;
                                cmsOpciones.Items[4].Visible = false;
                                cmsOpciones.Items[5].Visible = false;
                                break;
                            case 113:
                                cmsOpciones.Items[0].Visible = false;
                                cmsOpciones.Items[1].Visible = false;
                                cmsOpciones.Items[2].Visible = true;
                                cmsOpciones.Items[3].Visible = false;
                                cmsOpciones.Items[4].Visible = false;
                                cmsOpciones.Items[5].Visible = false;
                                break;
                            case 196:
                                cmsOpciones.Items[0].Visible = false;
                                cmsOpciones.Items[1].Visible = false;
                                cmsOpciones.Items[2].Visible = false;
                                cmsOpciones.Items[3].Visible = false;
                                cmsOpciones.Items[4].Visible = true;
                                cmsOpciones.Items[5].Visible = false;
                                break;
                        }

                        cmsOpciones.Show(dtgLisSoliciAproba, dtgLisSoliciAproba.PointToClient(Cursor.Position));
                    }
                    else
                    {
                        if (idTipoOpe == Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeBiometricoRetiro"])
                            || idTipoOpe == Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeBiometricoCancelDep"])
                            || idTipoOpe == Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeBiometricoExtractoDep"])
                            || idTipoOpe == Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeBiometricoRefinanciacion"])
                            || idTipoOpe == Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeBiometricoNovacion"])
                            || idTipoOpe == Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeBiometricoColaborador"])
                            || idTipoOpe == Convert.ToInt32(clsVarApl.dicVarGen["idTipoOpeBiometricoDesembolso"]))
                        {
                            cmsOpciones.Items[0].Visible = false;
                            cmsOpciones.Items[1].Visible = false;
                            cmsOpciones.Items[2].Visible = false;
                            cmsOpciones.Items[3].Visible = false;
                            cmsOpciones.Items[4].Visible = false;
                            cmsOpciones.Items[5].Visible = true;
                        }

                        cmsOpciones.Show(dtgLisSoliciAproba, dtgLisSoliciAproba.PointToClient(Cursor.Position));
                    }
                }
            }
        }

        private void VerInformeRiesgos_Click(object sender, EventArgs e)
        {
            int idSolicitud = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idDocument"].Value);
            DataTable dtInfRiesgos = new clsCNInformeRiesgos().ObtenerInformeRiesgo(idSolicitud);
            if (dtInfRiesgos.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró el informe de riesgos.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idInfRiesgos = Convert.ToInt32(dtInfRiesgos.Rows[0]["idInfRiesgos"]);

            frmRegistroInformeRiesgos frmInformeRiesgos = new frmRegistroInformeRiesgos(idInfRiesgos);
            frmInformeRiesgos.ShowDialog();
        }

        private void btnConsultarSolCondonacion_Click(object sender, EventArgs e)
        {

            if (idTipoOpe == nValVar || idTipoOpe == nValVarVB)
            {
                int idSolAproba = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idSolAproba"].Value);
                int idSolicitud = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idDocument"].Value);
                int lAprob = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["lAprob"].Value);

                frmPreAprobaTasaNegociable frmAprobaTNegociable = new frmPreAprobaTasaNegociable(idSolAproba, idSolicitud, lAprob);
                frmAprobaTNegociable.ShowDialog();
            }
            else
            {
                frmSolicitudCondonacion _frmSolicitudCondonacion = new frmSolicitudCondonacion();
                int idSolicitud = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idDocument"].Value);
                _frmSolicitudCondonacion.conBusCuentaCli.cTipoBusqueda = "C";
                _frmSolicitudCondonacion.conBusCuentaCli.cEstado = "[5]";
                _frmSolicitudCondonacion.conBusCuentaCli.txtNroBusqueda.Text = idSolicitud.ToString();
                _frmSolicitudCondonacion.conBusCuentaCli.consultar();
                _frmSolicitudCondonacion.conBusCuentaCli.Enabled = false;
                _frmSolicitudCondonacion.LoadData();
                _frmSolicitudCondonacion.btnCancelar.Visible = false;
                _frmSolicitudCondonacion.btnEnviar.Visible = false;
                _frmSolicitudCondonacion.ShowDialog();
            }

        }

        private void btnImpActAprob_Click(object sender, EventArgs e)
        {
            new FrmActaAprobCredNivel().ShowDialog();
        }

        #endregion

        #region Métodos

        public frmAprobacionSolicitud()
        {
            InitializeComponent();
        }

        private void cargarLisSoliciAproba()
        {
            LimpiarControles();
            dtSoliciAproba = objAprobacion.CNLisSoliciAprobaPendiente(clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.dFecSystem, clsVarGlobal.nIdAgencia);
            dtgLisSoliciAproba.DataSource = dtSoliciAproba;

            dtgLisSoliciAproba.Columns["lAprobaLimiteExcep"].Visible = false;
            
        }

        private void RegAprobaSolicitud(int idSolAproba, int idNivelAprRanOpe, int idUsuario, int idEstado,
                                    string cOpinion, DateTime dFecSis, int idPerfil, clsCreditoProp objCreditoProp)
        {
            objCreditoProp.idOrigenCredProp = 4;
            objCreditoProp.idSolAproba = idSolAproba;
            objCreditoProp.idNivelAprRanOpe = idNivelAprRanOpe;
            string xmlPropSolCred = objCreditoProp.GetXml();
            nValAprobaSol = (idTipoOpe.In(55,120)) ? Convert.ToDecimal(dtgLisSoliciAproba.SelectedRows[0].Cells["nValAproba"].Value) : objCreditoProp.nMonto;
            DataTable dtAprobaSolicitud;
            if (!ValidarReglas()) return;

            string cFecha = clsVarGlobal.dFecSystem.ToShortDateString();
            string cHora = DateTime.Now.ToString("hh:mm tt");
            string cFechayhora = cFecha + " " + cHora;

            DateTime dresultFechyHora;
            DateTime.TryParse(cFechayhora, out dresultFechyHora);
            dtAprobaSolicitud = objAprobacion.CNRegAprobaSolicitud(idSolAproba, idNivelAprRanOpe, idUsuario, idEstado, cOpinion, dresultFechyHora, idPerfil, xmlPropSolCred);

            int idRpta = Convert.ToInt32(dtAprobaSolicitud.Rows[0]["idRpta"]);
            MessageBox.Show(dtAprobaSolicitud.Rows[0]["cMensage"].ToString(), "Aprobación de Solicitudes", MessageBoxButtons.OK, (idRpta == 0 ? MessageBoxIcon.Exclamation : MessageBoxIcon.Information));
            pnlRechazoCred.Visible = false;
        }

        private void CargarSoliciAproba()
        {
            LimpiarControles();
            dtSoliciAproba = objAprobacion.CNLisSoliciAproba(clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.dFecSystem);
            dtgLisSoliciAproba.DataSource = dtSoliciAproba;
            dtgLisSoliciAproba.Columns["lAprobaLimiteExcep"].Visible = false;
        }

        private void LimpiarControles()
        {
            idTipoOpe = 0;

            txtIdSolAproba.Text = String.Empty;
            txtNomCliente.Text = String.Empty;
            txtTipoOperacion.Text = String.Empty;
            txtMoneda.Text = String.Empty;
            txtValAproba.Text = String.Empty;
            txtDocument.Text = String.Empty;
            txtMotivo.Text = String.Empty;
            txtFecSolici.Text = String.Empty;
            txtProducto.Text = String.Empty;
            txtSustento.Text = String.Empty;
            txtOpinion.Text = String.Empty;

            btnDevolver.Visible = false;
            if (dtgObservaciones.DataSource != null)
                dtgObservaciones.DataSource = typeof (List<clsObservacion>);
            btnRechazar.Enabled = false;
            btnAprobar.Enabled = false;
            btnActualizar.Enabled = true;
            txtOpinion.Enabled = false;
            btnEditObs.Enabled = false;
            btnAddObs.Enabled = false;
            btnQuitObs.Enabled = false;
            btnSubsanar.Enabled = false;

        }

        private bool ValidarDevolución()
        {
            if (idTipoOpe == 55 && objEvalCred != null)
            {
                if (!objEvalCred.lFinalizoComite)
                {
                    MessageBox.Show("El comité de la evaluación no finalizó. No se puede devolver.", "Aprobación de solicitudes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            if (dtgObservaciones.Rows.Count == 0)
            {
                MessageBox.Show("Ingrese observaciones para la devoluciones.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dtgObservaciones.Rows.Cast<DataGridViewRow>().Count(x => !Convert.ToBoolean(x.Cells["lSubsanado"].Value)) == 0)
            {
                MessageBox.Show("Ya se subsanaron todas las observaciones. APRUEBE o RECHACE la solicitud.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidarReglas()
        {
            string cCumpleReglas = String.Empty;
            int nNivAuto = 0;
            DataTable dtParametros = ArmarTablaParametros();

            cCumpleReglas = new clsCNValidaReglasDinamicas().ValidarReglas( dtTablaParametros: dtParametros,
                                                                            cNombreFormulario: this.Name,
                                                                            idAgencia: clsVarGlobal.nIdAgencia,
                                                                            idCliente: 0,
                                                                            idEstadoOperac:1,
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
            int idCli = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idCliente"].Value);
            int idDocumentSol = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idDocument"].Value);
            int idSolAproba = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idSolAproba"].Value);
            int idNivelAprRanOpe = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idNivelAprRanOpe"].Value);
            int idMonedaForm = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idMoneda"].Value);
            DataTable dtTablaParametros = new DataTable();
            dtTablaParametros.Columns.Add("cNombreCampo");
            dtTablaParametros.Columns.Add("cValorCampo");

            //Obtenemos los datos generales del cliente

            DataTable dtDatCli = new clsCNBuscarCli().GetDatosGenCli(idCli);

            if (dtDatCli.Rows.Count > 0)
            {
                foreach (DataColumn column in dtDatCli.Columns)
                {
                    if (column.DataType == typeof(DateTime) && dtDatCli.Rows[0][column.ColumnName].ToString() != "")
                    {
                        dtTablaParametros.Rows.Add(column.ColumnName,
                            ((DateTime) dtDatCli.Rows[0][column.ColumnName]).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        dtTablaParametros.Rows.Add(column.ColumnName,
                            dtDatCli.Rows[0][column.ColumnName].ToString());
                    }
                }
            }

            if (idTipoOpe.In(55, 120))
            {
                DataTable dtDatSolCre = new clsCNSolicitud().CNGetDatGenCreSolCre(idDocumentSol);

                foreach (DataColumn column in dtDatSolCre.Columns)
                {
                    if (column.DataType == typeof (DateTime))
                    {
                        dtTablaParametros.Rows.Add(column.ColumnName,
                            ((DateTime) dtDatSolCre.Rows[0][column.ColumnName]).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        dtTablaParametros.Rows.Add(column.ColumnName,
                            dtDatSolCre.Rows[0][column.ColumnName].ToString());
                    }
                }
            }
            else
            {
                DataRow dr = dtTablaParametros.NewRow();
                dr = dtTablaParametros.NewRow();
                dr[0] = "idSolCre";
                dr[1] = 0;
                dtTablaParametros.Rows.Add(dr);

                dr = dtTablaParametros.NewRow();
                dr[0] = "idOperacionSol";
                dr[1] = 0;
                dtTablaParametros.Rows.Add(dr);

                dr = dtTablaParametros.NewRow();
                dr[0] = "idTipProd";
                dr[1] = 0;
                dtTablaParametros.Rows.Add(dr);

                dr = dtTablaParametros.NewRow();
                dr[0] = "lDecRiesgos";
                dr[1] = 0;
                dtTablaParametros.Rows.Add(dr);

                dr = dtTablaParametros.NewRow();
                dr[0] = "nSalCapTot";
                dr[1] = 0;
                dtTablaParametros.Rows.Add(dr);
            }

            DataRow drfila = dtTablaParametros.NewRow();

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idEstadoSolAproba";
            drfila[1] = idEstadoSolAproba;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nTipCamFij";
            drfila[1] = Convert.ToDecimal(clsVarApl.dicVarGen["nTipCamFij"]);
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idMonedaForm";
            drfila[1] = idMonedaForm;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idSolAproba";
            drfila[1] = idSolAproba;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idNivelAprRanOpe";
            drfila[1] = idNivelAprRanOpe;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "nValAproba";
            drfila[1] = nValAprobaSol;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idTipoOpe";
            drfila[1] = idTipoOpe;
            dtTablaParametros.Rows.Add(drfila);

            drfila = dtTablaParametros.NewRow();
            drfila[0] = "idDocument";
            drfila[1] = idDocumentSol;
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

        private void mostrarReasignacion_Click(object sender, EventArgs e)
        {
            int nIdReasignacionCartera = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idDocument"].Value);

            string cNombreDestino = "Destino Texto Aqui";//cboAseDes.Text;
            string lugarFecha = clsVarGlobal.cNomAge + ", " + clsVarGlobal.dFecSystem.ToString().ToUpperInvariant();

            List<ReportDataSource> dtslist = new List<ReportDataSource>();
            dtslist.Clear();


            dtslist.Add(new ReportDataSource("dsListaCreditosReasignados", cnCredito.ListCredReasignados(nIdReasignacionCartera)));

            List<ReportParameter> paramlist = new List<ReportParameter>();
            paramlist.Clear();
            paramlist.Add(new ReportParameter("cNombreOperador", clsVarGlobal.User.cNomUsu, false));
            paramlist.Add(new ReportParameter("nombreAsesorDestino", cNombreDestino, false));
            paramlist.Add(new ReportParameter("lugarFecha", lugarFecha, false));
            paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString(), false));
            paramlist.Add(new ReportParameter("cNomAgen", clsVarGlobal.cNomAge, false));
            paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"], false));
            paramlist.Add(new ReportParameter("cSustento", txtSustento.Text.ToLower(), false));

            string reportpath = "rptActaReasignacionCartera.rdlc";
            new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();

        }

        private void mostrarSustentoExcpBiometrica_Click(object sender, EventArgs e)
        {
            int idBiometriaExcep = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idDocument"].Value);

            DataTable dtResp = objAprobacion.CNObtenerExcepcionBiometrica(idBiometriaExcep);

            if (dtResp.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron la solicitud de excepción biométrica.", "Aprobación de Excepción Biométrica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToInt32(dtResp.Rows[0]["idTipoArchivo"]) == 3)
            {
                frmDisplayPDF pdf = new frmDisplayPDF(dtResp.Rows[0]["cNombreArchivo"].ToString(), dtResp.Rows[0]["cExtencion"].ToString(), Compresion.DescompressedByte((byte[])dtResp.Rows[0]["bArchivo"]));
                pdf.ShowDialog();
            }
            else if (Convert.ToInt32(dtResp.Rows[0]["idTipoArchivo"]) == 1)
            {
                frmMostrarImagen frmImagen = new frmMostrarImagen(dtResp.Rows[0]["cNombreArchivo"].ToString(), dtResp.Rows[0]["cExtencion"].ToString(), Compresion.DescompressedByte((byte[])dtResp.Rows[0]["bArchivo"]));
                frmImagen.ShowDialog();
            }
        }

        private int ConfigurarAprobSoli(int idUsuario, int idSolicitud, int idPerfil)
        {
            DataTable dtCofiguracion = objAprobacion.CNConfigurarAprobSoli(idUsuario, idSolicitud, idPerfil);
            return Convert.ToInt32(dtCofiguracion.Rows[0]["nAprobacion"]);
        }

        private void CargarSoliciAprobadas()
        {
            LimpiarControles();
            dtSoliciAproba = objAprobacion.CNListarSolAproba(clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.dFecSystem, Convert.ToInt32(cboTipoOperacion.SelectedValue));
            dtgLisSoliciAproba.DataSource = dtSoliciAproba;
            dtgLisSoliciAproba.Columns["lAprobaLimiteExcep"].Visible = false;
        }
        private void CargarSoliciNoAprobadas()
        {
            LimpiarControles();
            dtSoliciAproba = objAprobacion.CNListarSolAprobaPendiente(clsVarGlobal.User.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.dFecSystem, Convert.ToInt32(cboTipoOperacion.SelectedValue), clsVarGlobal.nIdAgencia);
            dtgLisSoliciAproba.DataSource = dtSoliciAproba;
            dtgLisSoliciAproba.Columns["lAprobaLimiteExcep"].Visible = false;
        }

        private void cboTipoOperacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (chcAprob.Checked)
                CargarSoliciAprobadas();
            else
                CargarSoliciNoAprobadas();
        }
        private void dtgLisSoliciAproba_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            bool valorDeLaColumna = Convert.ToBoolean(dtgLisSoliciAproba.Rows[e.RowIndex].Cells["lAprobaLimiteExcep"].Value);

            if (valorDeLaColumna == false)
            {
                dtgLisSoliciAproba.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Beige; // Color del texto
            }
            else
            {
                dtgLisSoliciAproba.Rows[e.RowIndex].DefaultCellStyle.BackColor = dtgLisSoliciAproba.DefaultCellStyle.BackColor;
                dtgLisSoliciAproba.Rows[e.RowIndex].DefaultCellStyle.ForeColor = dtgLisSoliciAproba.DefaultCellStyle.ForeColor;
            }
        }


        private void MostrarSustentoServicio()
        {
            int idServicioGiro = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idDocument"].Value);
            int idSolAproba = Convert.ToInt32(dtgLisSoliciAproba.SelectedRows[0].Cells["idSolAproba"].Value);

            DataTable dtResp = objAprobacion.CNObtenerGiroSolDesblContra(idServicioGiro, idSolAproba);

            if (dtResp.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró el Archivo de Sustento de la Solicitud de Debloqueo Clave de Giro.", "Aprobación de Desbloqueo de Clave - Giros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToInt32(dtResp.Rows[0]["idTipoArchivo"]) == 3)
            {
                if(dtResp.Rows[0]["cNombreArchivo"].ToString().Length > 0)
                {
                    frmDisplayPDF pdf = new frmDisplayPDF(dtResp.Rows[0]["cNombreArchivo"].ToString(), dtResp.Rows[0]["cExtencion"].ToString(), Compresion.DescompressedByte((byte[])dtResp.Rows[0]["bArchivo"]));
                    pdf.ShowDialog();
                }
                else {
                    MessageBox.Show("La solicitud no tiene un archivo adjunto.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }
        private void btnVerAdjuntos_Click(object sender, EventArgs e)
        {
            MostrarSustentoServicio();
        }
        #endregion

        
    }
}
