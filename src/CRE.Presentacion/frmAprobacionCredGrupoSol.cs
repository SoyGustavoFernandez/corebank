using CRE.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using GEN.Funciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using GEN.Servicio;

namespace CRE.Presentacion
{
    public partial class frmAprobacionCredGrupoSol : frmBase
    {
        #region Variables Globales

        private clsCNAprobacionCredito objCNAprobacionCredito = new clsCNAprobacionCredito();
        private clsSolicitudCredGrupoSol lstSolicitudCredGrupoSol = new clsSolicitudCredGrupoSol();
        private clsEvalCredGrupoSol objEvalCredGrupoSol = new clsEvalCredGrupoSol();
        private clsAproEvalCredGrupoSol objAproEvalCredGrupoSol = new clsAproEvalCredGrupoSol();
        private clsCreditoProp objCreditoProp;
        private clsCNGrupoSolidario objCNGrupoSol = new clsCNGrupoSolidario();
        private List<clsEvalCredIntegGrupoSol> lstEvalCredIntegGrupoSol = new List<clsEvalCredIntegGrupoSol>();
        private List<clsSolCredGSIntegrante> lstSolCredGSIntegrante = new List<clsSolCredGSIntegrante>();

        private const string cTituloForm = "Aprobación - Grupo Solidario";

        int idGrupoSolidario = 0;
        int idSolicitudCredGrupoSol = 0;
        int idEvalCredGrupoSol = 0;
        decimal nMontoSuma = 0;
        private int nExcepciones;

        private clsExpedienteLinea clsProcesoExp = new clsExpedienteLinea();
        #endregion Variables Globales

        public frmAprobacionCredGrupoSol()
        {
            CargarFormulario();
        }

        #region Metodos
        private void LimpiarControles()
        {
            CargarFormulario();

        }

        private void InsertarDatos()
        {

            this.txtObservResultado.Text = this.objAproEvalCredGrupoSol.cComentario;
            this.cboResultComite.SelectedValue = (this.objAproEvalCredGrupoSol.idEstadoEvalCred == 6) ? 5 : this.objAproEvalCredGrupoSol.idEstadoEvalCred;
            this.cboMotRechazo.SelectedValue = (this.objAproEvalCredGrupoSol.idMotRechazo != 0) ? this.objAproEvalCredGrupoSol.idMotRechazo : 0;
            //this.chcVerificacion.Checked = this.objAproEvalCredGrupoSol.lVerificacion;

            this.idSolicitudCredGrupoSol = this.objEvalCredGrupoSol.idSolicitudCredGrupoSol;
            this.idEvalCredGrupoSol = this.objEvalCredGrupoSol.idEvalCredGrupoSol;
            this.idGrupoSolidario = this.objEvalCredGrupoSol.idGrupoSolidario;

            this.ListarEvalCredsIntegsGrupoSol();
            this.IniciaAprobacionEvalCredGrupal();

            this.bdgObsAprobadorGrupoSol.DataSource = this.objAproEvalCredGrupoSol.lstObsAprobadorGrupoSol;
            this.dtgObservaciones.DataSource = this.bdgObsAprobadorGrupoSol;

            this.bdgIntegGrupoSol.DataSource = this.lstEvalCredIntegGrupoSol;
            this.dtgIntegrantes.DataSource = this.bdgIntegGrupoSol;

            nMontoSuma = this.lstEvalCredIntegGrupoSol.Sum(x => x.nMonto);

            this.txtIdGrupoSolidario.Text = this.objEvalCredGrupoSol.idGrupoSolidario.ToString();
            this.txtGrupoSolidario.Text = this.objEvalCredGrupoSol.cNombre;
            this.txtDireccion.Text = this.objEvalCredGrupoSol.cDireccion;
            this.dtFechaCreacion.Value = this.objEvalCredGrupoSol.dFechaCreacion;

            this.objCreditoProp = new clsCreditoProp();
            objCreditoProp.idMoneda = this.objEvalCredGrupoSol.idMoneda;
            objCreditoProp.nCuotas = this.objEvalCredGrupoSol.nCuotas;
            objCreditoProp.idTipoPeriodo = this.objEvalCredGrupoSol.idTipoPeriodo;
            objCreditoProp.nPlazoCuota = this.objEvalCredGrupoSol.nPlazoCuota;
            objCreditoProp.nDiasGracia = this.objEvalCredGrupoSol.nDiasGracia;
            objCreditoProp.nCuotasGracia = this.objEvalCredGrupoSol.nCuotasGracia;
            //objCreditoProp.dFechaDesembolso = this.objEvalCredGrupoSol.dFechaDesembolsoPropuesto;
            objCreditoProp.dFechaDesembolso = clsVarGlobal.dFecSystem;
            objCreditoProp.idAsesor = this.objEvalCredGrupoSol.idAsesor;
            objCreditoProp.idAgencia = clsVarGlobal.nIdAgencia;
            objCreditoProp.idProducto = this.objEvalCredGrupoSol.idProducto;
            objCreditoProp.idSubProducto = this.objEvalCredGrupoSol.idSubProducto;
            objCreditoProp.idOperacion = this.objEvalCredGrupoSol.idOperacion;
            objCreditoProp.idModalidadCredito = this.objEvalCredGrupoSol.idModalidadCredito;
            objCreditoProp.idModalidadDes = this.objEvalCredGrupoSol.idModalidadDes;
            objCreditoProp.idTasa = this.objEvalCredGrupoSol.idTasa;

            objCreditoProp.nMonto = nMontoSuma;
            objCreditoProp.nMontoSolicitado = nMontoSuma;
            objCreditoProp.nMontoMinimo = this.lstEvalCredIntegGrupoSol.Min(x => x.nMonto);
            objCreditoProp.nMontoMaximo = this.lstEvalCredIntegGrupoSol.Max(x => x.nMonto);

            this.txtMontoSuma.Text = this.objCreditoProp.nMonto.ToString();

            this.conCondiCreditoGrupoSol.AsignarDatos(this.objCreditoProp);
            this.conCondiCreditoGrupoSol.idTipoGrupoSolidario = this.objEvalCredGrupoSol.idGrupoSolidarioTipo;
            this.FormatearDataGridObservaciones();
            this.FormatearDataGridIntegrantes();

            lblnroExcepciones.Text = "No tiene Excepciones.";
            nExcepciones = 0;
            nroExcepciones(this.objAproEvalCredGrupoSol.idSolicitudCredGrupoSol);
        }

        private void IniciaAprobacionEvalCredGrupal()
        {
            this.objAproEvalCredGrupoSol = this.objCNAprobacionCredito.IniciaAprobacionEvalCredGrupal(this.idEvalCredGrupoSol, clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.dFecSystem);
        }

        private void ListarEvalCredsIntegsGrupoSol()
        {
            this.lstEvalCredIntegGrupoSol = this.objCNGrupoSol.ListarEvalCredsIntegsGrupoSol(this.objEvalCredGrupoSol.idGrupoSolidario, this.objEvalCredGrupoSol.idEvalCredGrupoSol);
        }

        private void FormatearDataGridObservaciones()
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
        private void FormatearDataGridIntegrantes()
        {
            foreach (DataGridViewColumn column in this.dtgIntegrantes.Columns)
            {
                column.Visible = false;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }


            dtgIntegrantes.Columns["nNro"].DisplayIndex = 0;
            dtgIntegrantes.Columns["idSolicitud"].DisplayIndex = 1;
            dtgIntegrantes.Columns["cNombre"].DisplayIndex = 2;
            dtgIntegrantes.Columns["nMonto"].DisplayIndex = 3;
            dtgIntegrantes.Columns["nTEA"].DisplayIndex = 4;
            dtgIntegrantes.Columns["nTIM"].DisplayIndex = 5;
            dtgIntegrantes.Columns["nCuotaAprox"].DisplayIndex = 6;
            dtgIntegrantes.Columns["nCuotaGraciaAprox"].DisplayIndex = 7;
            dtgIntegrantes.Columns["cActividadInterna"].DisplayIndex = 8;

            dtgIntegrantes.Columns["nNro"].Visible = true;
            dtgIntegrantes.Columns["idSolicitud"].Visible = true;
            dtgIntegrantes.Columns["cNombre"].Visible = true;
            dtgIntegrantes.Columns["nMonto"].Visible = true;
            dtgIntegrantes.Columns["nTEA"].Visible = true;
            dtgIntegrantes.Columns["nTIM"].Visible = true;
            dtgIntegrantes.Columns["nCuotaAprox"].Visible = true;
            dtgIntegrantes.Columns["nCuotaGraciaAprox"].Visible = true;
            dtgIntegrantes.Columns["cActividadInterna"].Visible = true;

            dtgIntegrantes.Columns["nNro"].HeaderText = "N.";
            dtgIntegrantes.Columns["idSolicitud"].HeaderText = "Cod. Solicitud";
            dtgIntegrantes.Columns["cNombre"].HeaderText = "Cliente";
            dtgIntegrantes.Columns["nMonto"].HeaderText = "Monto S.";
            dtgIntegrantes.Columns["nTEA"].HeaderText = "TEA";
            dtgIntegrantes.Columns["nTIM"].HeaderText = "TIM";
            dtgIntegrantes.Columns["nCuotaAprox"].HeaderText = "Cuota Aprox.";
            dtgIntegrantes.Columns["nCuotaGraciaAprox"].HeaderText = "Cuota Gracia Aprox.";
            dtgIntegrantes.Columns["cActividadInterna"].HeaderText = "Actividad";

            dtgIntegrantes.Columns["nNro"].FillWeight = 10;
            dtgIntegrantes.Columns["idSolicitud"].FillWeight = 15;
            dtgIntegrantes.Columns["cNombre"].FillWeight = 55;
            dtgIntegrantes.Columns["nMonto"].FillWeight = 25;
            dtgIntegrantes.Columns["nTEA"].FillWeight = 15;
            dtgIntegrantes.Columns["nTIM"].FillWeight = 15;
            dtgIntegrantes.Columns["nCuotaAprox"].FillWeight = 15;
            dtgIntegrantes.Columns["nCuotaGraciaAprox"].FillWeight = 15;
            dtgIntegrantes.Columns["cActividadInterna"].FillWeight = 40;


            dtgIntegrantes.Columns["nMonto"].DefaultCellStyle.Format = "### ### ##0.00";
            dtgIntegrantes.Columns["nTEA"].DefaultCellStyle.Format = "##0.00";
            dtgIntegrantes.Columns["nTIM"].DefaultCellStyle.Format = "##0.00";

            dtgIntegrantes.Columns["cNombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }


        private void CargarFormulario()
        {

            InitializeComponent();

            /*this.lstObsAprobadorGrupoSol = new List<clsObsAprobadorGrupoSol>();

            this.bdgObsAprobadorGrupoSol.DataSource = this.lstObsAprobadorGrupoSol;*/
            this.dtgObservaciones.DataSource = this.bdgObsAprobadorGrupoSol;



            habilitarConCreditoTasa(false);

            btnGrabarCondCredito.Enabled = false;
            btnCancelarCondCredito.Enabled = false;

        }

        private void habilitarConCreditoTasa(bool lHabilitado)
        {
            this.conCondiCreditoGrupoSol.Enabled = lHabilitado;
            this.dtgIntegrantes.Enabled = lHabilitado;

            /*grbObservaciones.Enabled = !lHabilitado;
            //grbMiembros.Enabled = !lHabilitado;
            grbDecision.Enabled = !lHabilitado;
            btnImprimir.Enabled = !lHabilitado;
            //btnPosIntInterv.Enabled = !lHabilitado;
            btnExcepciones.Enabled = !lHabilitado;
            //chcVerificacion.Enabled = !lHabilitado;
            lblnroExcepciones.Enabled = !lHabilitado;
            //txtComentRev.Enabled = !lHabilitado;

            btnGrabarCondCredito.Enabled = lHabilitado;
            btnEditarCondCredito.Enabled = !lHabilitado;*/
            //btnCancelarCondCredito.Enabled = lHabilitado;
        }

        private bool GrabarObservacionesAprobador()
        {
            clsCNObservacionAprobador objCNObsApro = new clsCNObservacionAprobador();
            DataTable dtRes = objCNObsApro.GrabarObsAprobadorGrupoSol(this.objAproEvalCredGrupoSol.idEvalCredGrupoSol, this.objAproEvalCredGrupoSol.idSolicitudCredGrupoSol, this.objAproEvalCredGrupoSol.idNivelAprobacion, this.objAproEvalCredGrupoSol.lstObsAprobadorGrupoSol.GetXml());

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

        private bool ValidarRestriccionesAprobacion()
        {
            if (cboResultComite.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una decisión", "No seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int idResultado = Convert.ToInt32(cboResultComite.SelectedValue);

            if (idResultado == 7 && cboMotRechazo.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un motivo de rechazo", "No seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if ((idResultado == 5 || idResultado == 7) && (this.txtObservResultado.Text.Equals(string.Empty)))
            {
                MessageBox.Show("El Comentario de la decisión es obligatorio", "Comentario pendiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            int nObsSinSubsanar = this.objAproEvalCredGrupoSol.lstObsAprobadorGrupoSol.Count(x => x.lSubsanado == false);

            if (idResultado == 5)
            {
                if (nObsSinSubsanar > 0)
                {
                    MessageBox.Show("Quedan ( " + nObsSinSubsanar + " ) observaciones por subsanar, no se podrá APROBAR sin antes subsanar todas.", "Observaciones pendientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else
                {
                    /*clsCNExcepcionesCreditos objCNExcepCred = new clsCNExcepcionesCreditos();
                    DataTable dtRes = objCNExcepCred.ContExcepcionesPorEstado(this.objAproEvalCred.idSolicitud);

                    if (dtRes.Rows.Count == 0)
                    {
                    }
                    else if (Convert.ToInt32(dtRes.Rows[0]["nDesestimados"]) > 0)
                    {
                        MessageBox.Show("La solicitud tiene ( " + dtRes.Rows[0]["nDesestimados"] + " ) excepciones desestimadas por lo que no podra ser aprobado", "Excepciones desestimadas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else if (Convert.ToInt32(dtRes.Rows[0]["nSolicitados"]) > 0)
                    {
                        MessageBox.Show("La solicitud tiene ( " + dtRes.Rows[0]["nSolicitados"] + " ) excepciones solicitadas que deben ser aceptadas", "Excepciones solicitadas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }*/
                }

            }
            else if (nObsSinSubsanar == 0 && (idResultado == 8 || idResultado == 9))
            {
                MessageBox.Show("No se podra DEVOLVER sin antes registrar observaciones nuevas.", "Registre observaciones nuevas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void GestionarAprobacion()
        {
            //this.objCreditoProp = conCreditoTasa.ObtenerCreditoPropuesto();
            int idResultado = Convert.ToInt32(cboResultComite.SelectedValue);
            DataTable dtExcepciones = (new clsCNGrupoSolidario()).ExcepcionesGrupoDetalle(this.idSolicitudCredGrupoSol);
            DataTable dtExcepcionesAceptado = (new clsCNGrupoSolidario()).ExcepcionesGrupoEstado(this.idSolicitudCredGrupoSol, 1);
            //DataTable dtExcepcionesDesestimado = (new clsCNGrupoSolidario()).ExcepcionesGrupoEstado(this.idSolicitudCredGrupoSol, 2);
            int totalExcepciones = dtExcepciones.Rows.Count;
            int ExcepAceptado = dtExcepcionesAceptado.Rows.Count;
            //int ExcepDesestimado = dtExcepcionesDesestimado.Rows.Count;

            string cMensajeError = "Aún existen Excepciones sin aceptar.";
            int ExcepcionesTotalAceptadas = 0;
            if (totalExcepciones == ExcepAceptado)
            {
                if (this.objCNGrupoSol.comprobarExcepcionesRNC(this.idSolicitudCredGrupoSol))
                {
                    ExcepcionesTotalAceptadas = 1;
                }
                else
                {
                    cMensajeError = "La solicitud de crédito tiene EXCEPCIONES NO CONTEMPLADAS pendientes de aprobación.";
                    ExcepcionesTotalAceptadas = 0;
                }
            }
            else
            {
                ExcepcionesTotalAceptadas = 0;
            }

            if (ExcepcionesTotalAceptadas == 1)
            {
                if (idResultado == 5)
                {
                    this.nMontoSuma = this.lstEvalCredIntegGrupoSol.Sum(x => x.nMonto);
                    DataTable dtGes = objCNAprobacionCredito.GestionarAprobacionGrupal(this.idSolicitudCredGrupoSol, this.idEvalCredGrupoSol, clsVarGlobal.nIdAgencia, this.nMontoSuma);
                    List<clsAprobacionCredito> objAproCred = new List<clsAprobacionCredito>();
                    objAproCred = DataTableToList.ConvertTo<clsAprobacionCredito>(dtGes) as List<clsAprobacionCredito>;

                    if (objAproCred[0].idError == 0)
                    {
                        DialogResult dlres = MessageBox.Show("" + objAproCred[0].cMensaje, "Aprobacion en proceso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlres == DialogResult.Yes)
                        {
                            this.GuardarDecisionAprobadorGrupal(objAproCred[0].idEstadoEvalCred, 5, objAproCred[0].idNivelAprobacion, objAproCred[0].lEnviaSolInfRiesgos, objAproCred[0].lRevision);
                        }
                        else
                        {
                            this.HabilitarControlesDecision(true);
                            this.HabilitarControlesObservacion(true);
                            btnEditarCondCredito.Enabled = true;
                            btnExcepciones.Enabled = true;
                        }
                    }
                    else if (objAproCred[0].idError == 1)
                    {
                        MessageBox.Show("" + objAproCred[0].cMensaje, "Error al intentar consultar aprobacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    this.GuardarDecisionAprobadorGrupal(idResultado, 5, this.objEvalCredGrupoSol.idNivelAprobacion, false, false);
                }
            }
            else
            {
                MessageBox.Show(cMensajeError, "Validación de Excepciones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.HabilitarControlesDecision(true);
                this.HabilitarControlesObservacion(true);
                habilitarControlesActualizar(true);
                btnEditarCondCredito.Enabled = true;
                btnExcepciones.Enabled = true;
            }
        }

        public void GuardarDecisionAprobadorGrupal(int idEstadoEvalCred, int idEtapaEvalCred, int idNivelAprobacion, bool lEnviaSolInfRiesgos, bool lRevision)
        {

            string cComentario = txtObservResultado.Text.Trim();
            //bool lVerificacion = chcVerificacion.Checked;
            bool lVerificacion = true;
            int idMotRechazo = idEstadoEvalCred == 7 ? Convert.ToInt32(cboMotRechazo.SelectedValue) : 0;

            DataTable dtRes = objCNAprobacionCredito.GuardarDecisionAprobadorGrupal(this.objAproEvalCredGrupoSol.idSolicitudCredGrupoSol, this.objAproEvalCredGrupoSol.idEvalCredGrupoSol,
                this.XmlIdsEvalCredIntegGrupoSol(), this.objAproEvalCredGrupoSol.idUsuReg,
                       idEstadoEvalCred, idEtapaEvalCred, idNivelAprobacion, lEnviaSolInfRiesgos, lRevision,
                       cComentario, lVerificacion, idMotRechazo, clsVarGlobal.dFecSystem);

            if (Convert.ToInt32(dtRes.Rows[0]["idError"]) == 0)
            {
                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], "Decisión aprobador", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (idEstadoEvalCred == 5)
                {
                    this.btnImprimir.Enabled = true;
                }
                btnEditarCondCredito.Enabled = false;

                if (idEstadoEvalCred == 7 || idEstadoEvalCred == 5)
                {
                    /*  Guardar Expedientes - Grupo Aprobacion GS */
                    clsProcesoExp.guardarCopiaExpediente("GS - Aprobacion de Credito", this.objAproEvalCredGrupoSol.idSolicitudCredGrupoSol, this, "grupal");
                }
            }
            else
            {
                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.HabilitarControlesDecision(true);
                this.HabilitarControlesObservacion(true);
                btnEditarCondCredito.Enabled = true;
            }
        }

        private bool validarReglas()
        {
            obtenerSolicitudGrupo();
            obtenerSolicitudes();
            string cNombreFormulario = this.Name;
            frmReglasGrupo frmExcepcionesGrupo = new frmReglasGrupo(3, cNombreFormulario, lstSolicitudCredGrupoSol, lstSolCredGSIntegrante);
            frmExcepcionesGrupo.ShowDialog();
            lstSolCredGSIntegrante.Clear();
            return frmExcepcionesGrupo.lEstado;
        }

        private void obtenerSolicitudGrupo()
        {
            lstSolicitudCredGrupoSol.idSolicitudCredGrupoSol = this.objEvalCredGrupoSol.idSolicitudCredGrupoSol;
            lstSolicitudCredGrupoSol.idGrupoSolidario = this.objEvalCredGrupoSol.idGrupoSolidario;
            lstSolicitudCredGrupoSol.idProducto = objCreditoProp.idProducto;
            lstSolicitudCredGrupoSol.idModalidadCredito = this.objEvalCredGrupoSol.idModalidadCredito;
            lstSolicitudCredGrupoSol.dFecDesemb = this.objEvalCredGrupoSol.dFechaDesembolso;
            lstSolicitudCredGrupoSol.dFechaPrimeraCuota = conCondiCreditoGrupoSol.dFechaPrimeraCuota();
            lstSolicitudCredGrupoSol.nCuotas = objCreditoProp.nCuotas;
            lstSolicitudCredGrupoSol.nPlazoCuota = objCreditoProp.nPlazoCuota;
            lstSolicitudCredGrupoSol.idAgencia = Convert.ToInt32(clsVarGlobal.nIdAgencia);
            lstSolicitudCredGrupoSol.idTipoPeriodo = objCreditoProp.idTipoPeriodo;
            lstSolicitudCredGrupoSol.cNombreGrupo = this.objEvalCredGrupoSol.cNombre;
            lstSolicitudCredGrupoSol.idGrupoSolidarioCiclo = this.objEvalCredGrupoSol.idGrupoSolidarioCiclo;
        }

        private void obtenerSolicitudes()
        {
            for (int i = 0; i < this.dtgIntegrantes.Rows.Count; i++)
            {
                lstSolCredGSIntegrante.Add(
                    new clsSolCredGSIntegrante()
                    {
                        idSolicitud = Convert.ToInt32(this.dtgIntegrantes.Rows[i].Cells["idSolicitud"].Value),
                        idSolicitudCredGrupoSol = this.objEvalCredGrupoSol.idSolicitudCredGrupoSol,
                        idCli = Convert.ToInt32(this.dtgIntegrantes.Rows[i].Cells["idCli"].Value),
                        nMonto = Convert.ToDecimal(this.dtgIntegrantes.Rows[i].Cells["nMonto"].Value),
                        //idDestino = Convert.ToInt32(this.dtgIntegrantes.Rows[i].Cells["idDestino"].Value),
                        cNombreCompleto = Convert.ToString(this.dtgIntegrantes.Rows[i].Cells["cNombre"].Value),
                    }
                );
            }
        }

        private string XmlIdsEvalCredIntegGrupoSol()
        {
            DataSet dsIntegrantesGrupoSol = new DataSet("lstEvalCredIntegGrupoSol");

            DataTable dtIdsIntegGrupoSol = new DataTable("clsEvalCredIntegGrupoSol");
            dtIdsIntegGrupoSol.Columns.Add("idEvalCred", typeof(int));
            dtIdsIntegGrupoSol.Columns.Add("idSolicitud", typeof(int));
            dtIdsIntegGrupoSol.Columns.Add("nMonto", typeof(decimal));

            dtIdsIntegGrupoSol.Columns.Add("idTasa", typeof(int));
            dtIdsIntegGrupoSol.Columns.Add("nTEA", typeof(decimal));
            dtIdsIntegGrupoSol.Columns.Add("nTIM", typeof(decimal));
            dtIdsIntegGrupoSol.Columns.Add("nCuotaAprox", typeof(decimal));
            dtIdsIntegGrupoSol.Columns.Add("nCuotaGraciaAprox", typeof(decimal));
            dtIdsIntegGrupoSol.Columns.Add("idTipoPeriodo", typeof(int));
            dtIdsIntegGrupoSol.Columns.Add("nPlazo", typeof(int));
            dtIdsIntegGrupoSol.Columns.Add("nCuotas", typeof(int));
            dtIdsIntegGrupoSol.Columns.Add("dFechaDesembolso", typeof(DateTime));
            dtIdsIntegGrupoSol.Columns.Add("dFechaPrimeraCuota", typeof(DateTime));
            dtIdsIntegGrupoSol.Columns.Add("nDiasGracia", typeof(int));
            dtIdsIntegGrupoSol.Columns.Add("nCuotasGracia", typeof(int));

            dtIdsIntegGrupoSol.Columns.Add("nSaldoCapital", typeof(decimal));
            dtIdsIntegGrupoSol.Columns.Add("nIntMoraOtros", typeof(decimal));
            dtIdsIntegGrupoSol.Columns.Add("nMontoAmpliado", typeof(decimal));

            for (int i = 0; i < this.dtgIntegrantes.Rows.Count; i++)
            {
                dtIdsIntegGrupoSol.Rows.Add(
                    Convert.ToInt32(this.dtgIntegrantes.Rows[i].Cells["idEvalCred"].Value),
                    Convert.ToInt32(this.dtgIntegrantes.Rows[i].Cells["idSolicitud"].Value),
                    Convert.ToDecimal(this.dtgIntegrantes.Rows[i].Cells["nMonto"].Value),

                    Convert.ToDecimal(this.dtgIntegrantes.Rows[i].Cells["idTasa"].Value),
                    Convert.ToDecimal(this.dtgIntegrantes.Rows[i].Cells["nTEA"].Value),
                    Convert.ToDecimal(this.dtgIntegrantes.Rows[i].Cells["nTIM"].Value),
                    Convert.ToDecimal(this.dtgIntegrantes.Rows[i].Cells["nCuotaAprox"].Value),
                    Convert.ToDecimal(this.dtgIntegrantes.Rows[i].Cells["nCuotaGraciaAprox"].Value),
                    Convert.ToInt32(this.dtgIntegrantes.Rows[i].Cells["idTipoPeriodo"].Value),
                    Convert.ToInt32(this.dtgIntegrantes.Rows[i].Cells["nPlazoCuota"].Value),
                    Convert.ToInt32(this.dtgIntegrantes.Rows[i].Cells["nCuotas"].Value),
                    Convert.ToDateTime(this.dtgIntegrantes.Rows[i].Cells["dFechaDesembolso"].Value),
                    conCondiCreditoGrupoSol.dFechaPrimeraCuota(),
                    Convert.ToInt32(this.dtgIntegrantes.Rows[i].Cells["nDiasGracia"].Value),
                    Convert.ToInt32(this.dtgIntegrantes.Rows[i].Cells["nCuotasGracia"].Value),

                    Convert.ToDecimal(this.dtgIntegrantes.Rows[i].Cells["nSaldoCapital"].Value),
                    Convert.ToDecimal(this.dtgIntegrantes.Rows[i].Cells["nIntMoraOtros"].Value),
                    Convert.ToDecimal(this.dtgIntegrantes.Rows[i].Cells["nMontoAmpliado"].Value)
                );
            }

            dsIntegrantesGrupoSol.Tables.Add(dtIdsIntegGrupoSol);

            return dsIntegrantesGrupoSol.GetXml();
        }

        private void habilitarControlesActualizar(bool lEstado)
        {
            this.btnEditarCondCredito.Enabled = !lEstado;
            this.btnGrabarCondCredito.Enabled = lEstado;
            this.btnCancelarCondCredito.Enabled = lEstado;
            this.btnMiniEditarMontoIntegrante.Enabled = lEstado;
            this.conCondiCreditoGrupoSol.bloquearMoneda(!lEstado);
            this.conCondiCreditoGrupoSol.bloquearNivelesProducto(!lEstado);
            this.conCondiCreditoGrupoSol.bloquearDestinoCredito(!lEstado);
            this.conCondiCreditoGrupoSol.bloquearTasaCredito(!lEstado);
        }

        private void HabilitarControlesDecision(bool lEstado)
        {
            this.btnDecidir.Enabled = lEstado;
            this.cboResultComite.Enabled = lEstado;
            this.txtObservResultado.Enabled = lEstado;
            this.cboMotRechazo.Enabled = lEstado;
        }

        private void HabilitarControlesObservacion(bool lEstado)
        {
            this.dtgObservaciones.Enabled = lEstado;
            this.btnAddObs.Enabled = lEstado;
            this.btnEditObs.Enabled = lEstado;
            this.btnQuitObs.Enabled = lEstado;
            this.btnSubsanar.Enabled = lEstado;
        }

        private void editarMonto()
        {

            if (this.dtgIntegrantes.SelectedRows.Count <= 0) return;

            int nRowIndex = this.dtgIntegrantes.SelectedRows[0].Index;

            clsMsjError objError = conCondiCreditoGrupoSol.Validar();

            if (objError.HasErrors)
            {
                MessageBox.Show(objError.GetErrors(), "Solicitud creditos grupos solidarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal nMonto = Convert.ToDecimal(this.dtgIntegrantes.Rows[nRowIndex].Cells["nMonto"].Value);
            decimal nMontoMax = Convert.ToDecimal(this.dtgIntegrantes.Rows[nRowIndex].Cells["nMontoMax"].Value);

            clsEvalCredIntegGrupoSol objEdit = (clsEvalCredIntegGrupoSol)this.dtgIntegrantes.SelectedRows[0].DataBoundItem;
            frmCondiSolCredIntegrante objCondiCredInt = new frmCondiSolCredIntegrante(obtenerSolCreditoIndividual(objEdit), 3);
            objCondiCredInt.nMontoModificado = objEdit.nMonto;
            objCondiCredInt.nMontoMax = objEdit.nMontoMax;

            objCondiCredInt.ShowDialog();

            if (!objCondiCredInt.lAcepta)
                return;

            nMonto = objCondiCredInt.nMontoModificado;
            this.dtgIntegrantes.Rows[nRowIndex].Cells["nMonto"].Value = nMonto;

            //this.objCreditoProp.nMonto = lstEvalCredIntegGrupoSol.Sum(x => x.nMonto);
            //this.objCreditoProp.nMontoMinimo = lstEvalCredIntegGrupoSol.Min(x => x.nMonto);
            //this.objCreditoProp.nMontoMaximo = lstEvalCredIntegGrupoSol.Max(x => x.nMonto);
            lstEvalCredIntegGrupoSol[nRowIndex].idTasa = objCondiCredInt.objCreditoProp.idTasa;
            lstEvalCredIntegGrupoSol[nRowIndex].nTEA = objCondiCredInt.objCreditoProp.nTasaCompensatoria;
            lstEvalCredIntegGrupoSol[nRowIndex].nTIM = objCondiCredInt.objCreditoProp.nTasaMoratoria;
            lstEvalCredIntegGrupoSol[nRowIndex].nTEM = objCondiCredInt.objCreditoProp.nTem;
            lstEvalCredIntegGrupoSol[nRowIndex].nMonto = objCondiCredInt.objCreditoProp.nMonto;
            lstEvalCredIntegGrupoSol[nRowIndex].nCuotaAprox = objCondiCredInt.objCreditoProp.nCuotaAprox;
            lstEvalCredIntegGrupoSol[nRowIndex].nCuotaGraciaAprox = objCondiCredInt.objCreditoProp.nCuotaGraciaAprox;

            lstEvalCredIntegGrupoSol[nRowIndex].nMontoAmpliado = objCondiCredInt.objCreditoProp.nMonto - (objEdit.nSaldoCapital + objEdit.nIntMoraOtros);

            this.dtgIntegrantes.Refresh();
        }
        private void nroExcepciones(int idSolicitudCredGrupoSol)
        {

            DataTable dtNroExcepciones = objCNAprobacionCredito.NroExcepcionesCreditoGrupoSolidario(idSolicitudCredGrupoSol);
            nExcepciones = Convert.ToInt32(dtNroExcepciones.Rows[0][0].ToString());
            if (nExcepciones > 0)
            {
                lblnroExcepciones.Text = "Tiene " + nExcepciones.ToString() + " Excepciones.";

            }
            else
            {
                lblnroExcepciones.Text = "No tiene Excepciones.";
            }

        }
        #endregion Metodos

        #region Eventos
        private void frmAprobacionCredGrupoSol_Load(object sender, EventArgs e)
        {
            this.Text = cTituloForm;
            this.HabilitarControlesDecision(false);
            this.HabilitarControlesObservacion(false);
            //this.habilitarControlesActualizar(false);
            this.btnEditarCondCredito.Enabled = false;
            this.btnImprimir.Enabled = false;
            this.btnExcepciones.Enabled = false;
        }

        private void btnDecidir_Click(object sender, EventArgs e)
        {
            clsCreditoProp obj = conCondiCreditoGrupoSol.ObtenerCreditoPropuesto();

            this.HabilitarControlesDecision(false);
            this.HabilitarControlesObservacion(false);
            habilitarControlesActualizar(false);
            btnEditarCondCredito.Enabled = false;
            btnExcepciones.Enabled = false;

            if (this.GrabarObservacionesAprobador())
            {
                if (!this.ValidarRestriccionesAprobacion())
                {
                    this.HabilitarControlesDecision(true);
                    this.HabilitarControlesObservacion(true);
                    habilitarControlesActualizar(true);
                    btnEditarCondCredito.Enabled = true;
                    btnExcepciones.Enabled = true;
                    return;
                }

                if (Convert.ToInt32(cboResultComite.SelectedValue).In(5))
                {
                    if (!this.validarReglas())
                    {
                        this.HabilitarControlesDecision(true);
                        this.HabilitarControlesObservacion(true);
                        habilitarControlesActualizar(true);
                        btnEditarCondCredito.Enabled = true;
                        btnExcepciones.Enabled = true;

                        return;
                    }
                }

                this.GestionarAprobacion();


            }
            else
            {
                this.HabilitarControlesDecision(true);
                this.HabilitarControlesObservacion(true);
                habilitarControlesActualizar(true);
                btnEditarCondCredito.Enabled = true;
                btnExcepciones.Enabled = true;
            }
        }



        private void btnEliLista_Click(object sender, EventArgs e)
        {
            frmBandejaEvalCredGrupoSol objBandejaEvalCredGS = new frmBandejaEvalCredGrupoSol();
            objBandejaEvalCredGS.ShowDialog();

            if (!objBandejaEvalCredGS.lResultado || objBandejaEvalCredGS.objEvalCredGrupoSol == null)
            {
                return;
            }
            else
            {
                this.HabilitarControlesDecision(true);
                this.HabilitarControlesObservacion(true);
                this.btnEditarCondCredito.Enabled = true;
                this.btnExcepciones.Enabled = true;
            }



            if (this.objAproEvalCredGrupoSol == null)
            {
                //this.HabilitarPanelDecision(false, 1);
                MessageBox.Show("Ha Ocurrido una Excepción Inesperada Al Intentar Inicializar La Aprobación", "EXEPCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.objEvalCredGrupoSol = objBandejaEvalCredGS.objEvalCredGrupoSol;

            btnVincularVisita1.idGrupoSolidario = this.objEvalCredGrupoSol.idGrupoSolidario;
            btnVincularVisita1.idSolicitudGrupoSol = this.objEvalCredGrupoSol.idSolicitudCredGrupoSol;
            btnVincularVisita1.lLectura = true;
            this.InsertarDatos();


        }

        private void btnEditarCondCredito_Click(object sender, EventArgs e)
        {
            habilitarConCreditoTasa(true);
            habilitarControlesActualizar(true);
            HabilitarControlesDecision(false);
            HabilitarControlesObservacion(false);
        }

        private void btnGrabarCondCredito_Click(object sender, EventArgs e)
        {

            this.btnGrabarCondCredito.Enabled = false;

            clsMsjError objError = this.conCondiCreditoGrupoSol.Validar();

            if (objError.HasErrors)
            {
                MessageBox.Show("Condiciones de crédito no válidas.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsCreditoProp objCredProp = this.conCondiCreditoGrupoSol.ObtenerCreditoPropuesto();

            DataTable dtRes = objCNGrupoSol.ActualizarCondicionesCreditoGS(
                this.objAproEvalCredGrupoSol.idEvalCredGrupoSol,
                this.nMontoSuma,
                objCreditoProp.idTasa,
                objCreditoProp.nTea,
                objCreditoProp.nTIM,
                objCreditoProp.nCuotas,
                objCreditoProp.idTipoPeriodo,
                objCreditoProp.nPlazoCuota,
                objCreditoProp.nDiasGracia,
                objCreditoProp.nCuotasGracia,
                objCreditoProp.dFechaDesembolso,
                clsVarGlobal.PerfilUsu.idUsuario,
                clsVarGlobal.dFecSystem,
                XmlIdsEvalCredIntegGrupoSol());

            if (Convert.ToInt32(dtRes.Rows[0]["idError"]) == 0)
            {
                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], "ACTUALIZACIÓN CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                habilitarConCreditoTasa(false);
                habilitarControlesActualizar(false);
                HabilitarControlesDecision(true);
                HabilitarControlesObservacion(true);
            }
            else
            {
                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], "ERROR INESPERADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnGrabarCondCredito.Enabled = true;
            }
        }

        private void btnCancelarCondCredito_Click(object sender, EventArgs e)
        {
            habilitarConCreditoTasa(false);
            habilitarControlesActualizar(false);
            LimpiarControles();
        }

        private void btnEditObs_Click(object sender, EventArgs e)
        {
            if (dtgObservaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a editar.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsObsAprobadorGrupoSol objObservacion = dtgObservaciones.SelectedRows[0].DataBoundItem as clsObsAprobadorGrupoSol;

            if (objObservacion.idObsAprobadorGrupoSol != 0)
            {
                MessageBox.Show("Solo se pueden editar las observaciones nuevas.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmObsAprobacionGrupoSol frmEditObs = new frmObsAprobacionGrupoSol();
            frmEditObs.objObservacion = objObservacion;
            frmEditObs.ShowDialog();

            this.bdgObsAprobadorGrupoSol.DataSource = this.objAproEvalCredGrupoSol.lstObsAprobadorGrupoSol;
            bdgObsAprobadorGrupoSol.ResetBindings(false);
        }

        private void btnSubsanar_Click(object sender, EventArgs e)
        {
            if (dtgObservaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione la observación a subsanar.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            clsObsAprobadorGrupoSol objObservacion = dtgObservaciones.SelectedRows[0].DataBoundItem as clsObsAprobadorGrupoSol;

            if (objObservacion == null) return;

            if (objObservacion.idObsAprobadorGrupoSol == 0)
            {
                MessageBox.Show("No se puede subsanar una observacion recien creada.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            objObservacion.lSubsanado = true;
            this.bdgObsAprobadorGrupoSol.ResetBindings(false);
        }

        private void btnAddObs_Click(object sender, EventArgs e)
        {
            frmObsAprobacionGrupoSol frmEditObs = new frmObsAprobacionGrupoSol();
            frmEditObs.idOrigenObs = 1;

            clsObsAprobadorGrupoSol objObsGrupoSol = new clsObsAprobadorGrupoSol();

            objObsGrupoSol.idObsAprobadorGrupoSol = 0;
            objObsGrupoSol.idTipObservacion = 0;
            objObsGrupoSol.cTipObservacion = string.Empty;
            objObsGrupoSol.cObservacion = string.Empty;
            objObsGrupoSol.lSubsanado = false;
            objObsGrupoSol.idUsuReg = clsVarGlobal.User.idUsuario;

            frmEditObs.objObservacion = objObsGrupoSol;
            frmEditObs.ShowDialog();

            if (!frmEditObs.lAceptado) return;

            this.objAproEvalCredGrupoSol.lstObsAprobadorGrupoSol.Add(objObsGrupoSol);
            bdgObsAprobadorGrupoSol.ResetBindings(false);
        }

        private void btnQuitObs_Click(object sender, EventArgs e)
        {
            if (dtgObservaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a eliminar.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsObsAprobadorGrupoSol objObservacion = (clsObsAprobadorGrupoSol)dtgObservaciones.SelectedRows[0].DataBoundItem;

            if (objObservacion.idObsAprobadorGrupoSol > 0)
            {
                MessageBox.Show("No se pueden eliminar las observaciones.", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.objAproEvalCredGrupoSol.lstObsAprobadorGrupoSol.Remove(objObservacion);
            bdgObsAprobadorGrupoSol.ResetBindings(false);
        }
        private void btnExcepciones_Click(object sender, EventArgs e)
        {
            if (nExcepciones > 0)
            {
                int nNivelActual = this.objAproEvalCredGrupoSol.idNivelAprobacion;
                int nNivelAprobacion = 99;
                int idSolicitudCredGrupoSol = Convert.ToInt32(this.objEvalCredGrupoSol.idSolicitudCredGrupoSol);
                frmAprobaExcepcionesCred frmAprobaExcepciones = new frmAprobaExcepcionesCred(nNivelActual, nNivelAprobacion, 0, idSolicitudCredGrupoSol);

                frmAprobaExcepciones.ShowDialog();
            }
            else
            {
                MessageBox.Show("El crédito no presenta Excepciones", "Excepciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        #endregion Eventos

        private void cboResultComite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboResultComite.SelectedValue != null)
            {
                DataRowView dv = cboResultComite.SelectedItem as DataRowView;
                if (dv != null)
                {
                    int idResultado = Convert.ToInt32(dv.Row["idResultado"]);

                    lblComentario.Visible = (idResultado == 5 || idResultado == 7);
                    txtObservResultado.Visible = (idResultado == 5 || idResultado == 7);
                    cboMotRechazo.Visible = (idResultado == 7);
                    lblMotRechazo.Visible = (idResultado == 7);
                    //grbObservaciones.Visible = (idResultado == 8 || idResultado == 9);
                    grbObservaciones.Visible = true;
                }
            }
        }

        private void btnMiniEditarMontoIntegrante_Click(object sender, EventArgs e)
        {
            editarMonto();
        }

        private void dtgIntegrantes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtgIntegrantes.Rows[0].Selected = false;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ActaCredGrupoSol();
        }

        private void ActaCredGrupoSol()
        {

            if (this.idGrupoSolidario == 0)
            {
                return;
            }

            string idGrupo = Convert.ToString(idGrupoSolidario);
            string cNomAgen = clsVarGlobal.cNomAge.ToString();

            DataTable dtData = objCNAprobacionCredito.ActaCreditoGrupoSol(idGrupoSolidario, objEvalCredGrupoSol.idSolicitudCredGrupoSol);
            DataTable dtData2 = objCNAprobacionCredito.ActaCreditoGrupoSol2(idGrupoSolidario, objEvalCredGrupoSol.idSolicitudCredGrupoSol);
            DataTable dtData3 = objCNAprobacionCredito.ActaCreditoGrupoSol3(idGrupoSolidario, objEvalCredGrupoSol.idSolicitudCredGrupoSol);
            DataTable dtData4 = objCNAprobacionCredito.ActaCreditoGrupoSol4(idGrupoSolidario, objEvalCredGrupoSol.idSolicitudCredGrupoSol);
            DataTable dtNivelesAprob = objCNAprobacionCredito.LisNivelAprobaSolCredGrupoSol(objEvalCredGrupoSol.idSolicitudCredGrupoSol);

            if (dtData.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();

                dtsList.Add(new ReportDataSource("dsSoli1", dtData));
                dtsList.Add(new ReportDataSource("dsSoli2", dtData2));
                dtsList.Add(new ReportDataSource("dsSoli3", dtData3));
                dtsList.Add(new ReportDataSource("dsExcepciones", dtData4));
                dtsList.Add(new ReportDataSource("dsNivelAproGrupoSol", dtNivelesAprob));

                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Add(new ReportParameter("idGrupo", idGrupo.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen, false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cRutaLogo", clsVarApl.dicVarGen["CRUTALOGO"]));

                string reportPath = "rptActaCrediSolidario.rdlc";  //rptCliMejorarCalificacion.rdl -> cambiar
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();


            }
            else
            {
                MessageBox.Show("No existen datos para esta Evaluación. ", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImprimirEvalCualit_Click(object sender, EventArgs e)
        {
            if (this.objEvalCredGrupoSol == null) return;

            DataSet ds = (new clsCNGrupoSolidario()).ObtenerFichaEvalCualitativa(this.objEvalCredGrupoSol.idEvalCredGrupoSol);
            string cNomAgen = clsVarGlobal.cNomAge.ToString();
            if (ds.Tables.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsSolicitud", ds.Tables[0]));
                dtsList.Add(new ReportDataSource("dsEvalCualita", ds.Tables[1]));
                dtsList.Add(new ReportDataSource("dsDescripcion", ds.Tables[2]));
                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("idEvalCredGrupoSol", this.objEvalCredGrupoSol.idEvalCredGrupoSol.ToString(), false));
                paramlist.Add(new ReportParameter("dFechaSis", clsVarGlobal.dFecSystem.ToString("dd/MM/yyyy"), false));
                //paramlist.Add(new ReportParameter("cNomAgen", cNomAgen.ToString(), false));

                string reportPath = "rptEvalCualitativaGrupoSol.rdlc";
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para esta evaluación ", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImprimirEERR_Click(object sender, EventArgs e)
        {
            if (this.objEvalCredGrupoSol == null) return;

            clsCNGrupoSolidario cnRep = new clsCNGrupoSolidario();
            string idEval = Convert.ToString(this.objEvalCredGrupoSol.idEvalCredGrupoSol);
            int nIdEval = Convert.ToInt32(idEval);
            DateTime dFecOpe = clsVarGlobal.dFecSystem;
            string cNomAgen = clsVarGlobal.cNomAge;

            DataTable dtData2 = cnRep.ReporteEvaluacion(nIdEval);
            DataTable dtData3 = cnRep.ReporteEvaluacion3(nIdEval);
            DataTable dtData4 = cnRep.ReporteEvaluacion4(nIdEval);
            DataTable dtData5 = cnRep.ReporteEvaluacion5(nIdEval);
            DataTable dtData6 = cnRep.ReporteEvaluacion6(nIdEval);
            DataTable dtData7 = cnRep.ReporteEvaluacion7(nIdEval);

            if (dtData2.Rows.Count > 0)
            {
                List<ReportDataSource> dtsList = new List<ReportDataSource>();
                dtsList.Add(new ReportDataSource("dsResEvalGrupal2", dtData2));
                dtsList.Add(new ReportDataSource("dsResEvalGrupal3", dtData3));
                dtsList.Add(new ReportDataSource("dsResEvalGrupal4", dtData4));
                dtsList.Add(new ReportDataSource("dsSoli2", dtData5));
                dtsList.Add(new ReportDataSource("dsExcepciones", dtData6));
                dtsList.Add(new ReportDataSource("dsExcepcionesIndividuales", dtData7));
                List<ReportParameter> paramlist = new List<ReportParameter>();

                paramlist.Add(new ReportParameter("idEvalCredGrupoSol", idEval.ToString(), false));
                paramlist.Add(new ReportParameter("dFecOpe", dFecOpe.ToString(), false));
                paramlist.Add(new ReportParameter("cNomAgen", cNomAgen.ToString(), false));

                string reportPath = "rptResuEvalGrupal.rdlc";  //rptCliMejorarCalificacion.rdl -> cambiar
                new frmReporteLocal(dtsList, reportPath, paramlist).ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen datos para esta evaluación ", cTituloForm, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void conCondiCreditoGrupoSol_ChangeCondiCredito(object sender, EventArgs e)
        {
            actualizarCondCredIntegrantes();
        }

        private void actualizarCondCredIntegrantes()
        {
            if (dtgIntegrantes.DataSource == null)
                return;

            int nRowIndex = -1;

            clsMsjError objError = conCondiCreditoGrupoSol.Validar();
            clsCreditoProp objProp = conCondiCreditoGrupoSol.ObtenerCreditoPropuesto();

            if (objError.HasErrors)
            {
                return;
            }

            foreach (clsEvalCredIntegGrupoSol objEvalCredIntegGrupoSol in lstEvalCredIntegGrupoSol)
            {
                clsCreditoProp objPropIndividual = obtenerSolCreditoIndividual(objEvalCredIntegGrupoSol);
                if(objPropIndividual.nMonto > 0)
                {
                    frmCondiSolCredIntegrante objCondiCredInt = new frmCondiSolCredIntegrante(objPropIndividual, 3);
                    objCondiCredInt.CalcularCuotaAproxIntegrante(false);
                    objEvalCredIntegGrupoSol.nCuotaAprox = objCondiCredInt.objCreditoProp.nCuotaAprox;
                    objEvalCredIntegGrupoSol.nCuotaGraciaAprox = objCondiCredInt.objCreditoProp.nCuotaGraciaAprox;

                    objEvalCredIntegGrupoSol.nCuotasGracia = objProp.nCuotasGracia;
                    objEvalCredIntegGrupoSol.idTipoPeriodo = objProp.idTipoPeriodo;
                    objEvalCredIntegGrupoSol.nCuotas = objProp.nCuotas;
                    objEvalCredIntegGrupoSol.nPlazoCuota = objProp.nPlazoCuota;
                    objEvalCredIntegGrupoSol.nDiasGracia = objProp.nDiasGracia;
                    objEvalCredIntegGrupoSol.dFechaDesembolso = objProp.dFechaDesembolso;
                }

            }
            this.dtgIntegrantes.Refresh();
        }

        private clsCreditoProp obtenerSolCreditoIndividual(clsEvalCredIntegGrupoSol objEvalCredIntegGrupoSol)
        {
            clsEvalCredIntegGrupoSol obj = objEvalCredIntegGrupoSol;
            clsCreditoProp objObt = conCondiCreditoGrupoSol.ObtenerCondicionesCreditoGrupoSol(0);
            objObt.idOperacion = obj.idOperacion;
            objObt.idTasa = obj.idTasa;
            objObt.nTasaCompensatoria = obj.nTEA;
            objObt.nTasaMoratoria = obj.nTIM;
            objObt.idActividad = obj.idActividad;
            objObt.nMonto = obj.nMonto;
            objObt.cNombreGrupoSol = txtGrupoSolidario.Text;
            objObt.cNombreCli = obj.cNombre;
            objObt.idCli = obj.idCli;
            objObt.idActividad = obj.idActividad;
            objObt.idActividadInterna = obj.idActividadInterna;
            objObt.idSolicitud = obj.idSolicitud;
            objObt.lConTasaNegociable = obj.lConTasaNegociable;
            objObt.idModalidadCredito = obj.idModalidadCredito;
            objObt.idClasificacionInterna = obj.idClasificacionInterna;
            objObt.idDetalleGasto = obj.idDetalleGasto;

            objObt.nMontoCancelacion = obj.nSaldoCapital + obj.nIntMoraOtros;
            objObt.nMontoAmpliar = obj.nMontoAmpliado;

            return objObt;
        }

        private void btnImprimir1_Click(object sender, EventArgs e)
        {
            string cMsjCaption = "Expediente Grupo Solidario";
            if (this.objEvalCredGrupoSol == null)
            {
                MessageBox.Show("No se ha seleccionado un Grupo Solidario", cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.objEvalCredGrupoSol.idSolicitudCredGrupoSol == 0)
            {
                MessageBox.Show("No se ha ingresado la solicitud", cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.objEvalCredGrupoSol.idGrupoSolidario == 0)
            {
                MessageBox.Show("No se ha ingresado el Grupo Solidario", cMsjCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmExpedienteLinea frmExpLinea = new frmExpedienteLinea(this.objEvalCredGrupoSol.idSolicitudCredGrupoSol, this.objEvalCredGrupoSol.idGrupoSolidario, "grupal");
            frmExpLinea.ShowDialog();
        }

    }
}
