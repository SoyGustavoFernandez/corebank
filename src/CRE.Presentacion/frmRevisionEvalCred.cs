using CRE.CapaNegocio;
using EntityLayer;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.Funciones;

namespace CRE.Presentacion
{
    public partial class frmRevisionEvalCred : frmBase
    {
        #region Variables
        private clsCNAprobacionCredito objCNAprobacionCredito = new clsCNAprobacionCredito();
        private clsRevisionEvalCred objRevEvalCred = new clsRevisionEvalCred();
        private int idEvalCred;
        private const string cTituloMsjes = "Revisión de la evaluación.";
        private int nExcepciones = 0;
        #endregion

        #region Métodos
        public frmRevisionEvalCred()
        {
            InitializeComponent();

            conCreditoTasa.Enabled = false;
            lblComentario.Visible = false;
            btnEditarCondCredito.Enabled = true;
            btnGrabarCondCredito.Enabled = false;
            btnImprimir.Enabled = false;
            btnPosIntInterv.Enabled = false;

            grbObservaciones.Visible = false;

            this.idEvalCred = 0;
            this.objRevEvalCred = new clsRevisionEvalCred();

            this.HabilitarPanelDecision(false, 1);
        }

        private void nroExcepciones(int idSolicitud)
        {

            DataTable dtNroExcepciones = objCNAprobacionCredito.NroExcepcionesCredito(idSolicitud);
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

        private void CargarDatosAprobacionEvalCred()
        {
            conCreditoTasa.Enabled = false;
            lblComentario.Visible = false;
            btnEditarCondCredito.Enabled = true;
            btnGrabarCondCredito.Enabled = false;
            grbObservaciones.Visible = true;

            this.InicializarAprobacionEvalCred();

            if (this.objRevEvalCred == null)
            {
                this.HabilitarPanelDecision(false, 1);
                MessageBox.Show("Ha Ocurrido una Excepción Inesperada Al Intentar Inicializar La Aprobación", "EXEPCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsCreditoProp objCreditoProp = objCNAprobacionCredito.ObtenerCondicionesCredito(this.objRevEvalCred.idEvalCred);
            conCreditoTasa.AsignarDatos(objCreditoProp);

            this.txtNroDoc.Text = this.objRevEvalCred.cDocumentoID.ToString();
            this.txtNombre.Text = this.objRevEvalCred.cNombre.ToString();
            this.txtAsesor.Text = this.objRevEvalCred.cAsesor.ToString();

            this.txtIdSolicitud.Text = Convert.ToString(this.objRevEvalCred.idSolicitud);
            this.txtIdEvalCred.Text = Convert.ToString(this.objRevEvalCred.idEvalCred);
            this.txtOperacion.Text = this.objRevEvalCred.cOperacion;
            this.txtModCredito.Text = this.objRevEvalCred.cModalidadCredito;

            this.txtObservResultado.Text = this.objRevEvalCred.cComentario;
            this.cboDecisionRevisor.SelectedValue = (this.objRevEvalCred.idEstadoEvalCred==6)?5:this.objRevEvalCred.idEstadoEvalCred;
            this.chcVerificacion.Checked = this.objRevEvalCred.lVerificacion;


            bindingObservaciones.DataSource = this.objRevEvalCred.lstObsAprobador;
            dtgObservaciones.DataSource = bindingObservaciones;
            formatGridViewObservaciones();

            txtIdSolicitud.Text = this.objRevEvalCred.idSolicitud.ToString();

            this.HabilitarPanelDecision(true, 1);

            if (!(this.objRevEvalCred.idEstadoEvalCred == 6 || this.objRevEvalCred.idEstadoEvalCred==3))
            {
                this.HabilitarPanelDecision(false, 1);
                MessageBox.Show("Ya fue dada una decision para esta evalución,\nno se puede realizar ningun cambio", "SOLO VISUALIZACION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.nroExcepciones(objRevEvalCred.idSolicitud);
            this.MostrarGarantias(objRevEvalCred.idSolicitud);

            btnImprimir.Enabled = true;
            btnPosIntInterv.Enabled = true;
        }

        public void InicializarAprobacionEvalCred()
        {
            this.objRevEvalCred = this.objCNAprobacionCredito.InicializarRevisionEvalCred(this.idEvalCred, clsVarGlobal.PerfilUsu.idUsuario, clsVarGlobal.PerfilUsu.idPerfil, clsVarGlobal.dFecSystem);
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

        private void formatGridViewObservaciones()
        {
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
        #endregion

        #region Eventos

        #region Comite de Créditos
        private void btnDecidir_Click(object sender, EventArgs e)
        {
            if (this.GrabarObservacionesAprobador())
            {
                if (!this.ValidarRestriccionesAprobacion()) return;
                
                this.GuardarDecisionRevisor();
            }
        }

        public void GuardarDecisionRevisor()
        {
            int idResultado = Convert.ToInt32(cboDecisionRevisor.SelectedValue);
            string cComentario = txtObservResultado.Text.Trim();
            bool lVerificacion = chcVerificacion.Checked;

            DataTable dtRes = objCNAprobacionCredito.GuardarDecisionRevisor(this.objRevEvalCred.idSolicitud, this.objRevEvalCred.idEvalCred, this.objRevEvalCred.idUsuReg,
                       idResultado, this.objRevEvalCred.idNivelAprobacion, cComentario, lVerificacion, clsVarGlobal.dFecSystem);

            if (Convert.ToInt32(dtRes.Rows[0]["idError"]) == 0)
            {
                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], "DECISION REVISOR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.HabilitarPanelDecision(false, 1);
            }
            else
            {
                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarRestriccionesAprobacion()
        {
            if (this.cboDecisionRevisor.SelectedIndex < 0) return false;

            int nObsSinSubsanar = this.objRevEvalCred.lstObsAprobador.Count(x => x.lSubsanado == false);

            if (cboDecisionRevisor.SelectedIndex < 0) return false;

            if (Convert.ToInt32(cboDecisionRevisor.SelectedValue) == 5 && nObsSinSubsanar > 0)
            {
                MessageBox.Show("Quedan (" + nObsSinSubsanar + ") observaciones por subsanar, no se podrá APROBAR sin antes subsanar todas.", "OBSERVACIONES PENDIENTES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (nObsSinSubsanar == 0 && (Convert.ToInt32(cboDecisionRevisor.SelectedValue) == 8 || Convert.ToInt32(cboDecisionRevisor.SelectedValue) == 9))
            {
                MessageBox.Show("No se podrá DEVOLVER o enviar a AJUSTE sin antes registrar observaciones.", "REGISTRE OBSERVACIONES NUEVAS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private bool GrabarObservacionesAprobador()
        {
            clsCNObservacionAprobador objCNObsApro = new clsCNObservacionAprobador();
            DataTable dtRes = objCNObsApro.GrabarObservacionAprobador(this.objRevEvalCred.idEvalCred, this.objRevEvalCred.idSolicitud, this.objRevEvalCred.idNivelAprobacion, this.objRevEvalCred.lstObsAprobador.GetXml());

            if (Convert.ToInt32(dtRes.Rows[0]["idError"]) == 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], "ERROR INESPERADO EN OBSERVACIONES", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmExpEval frmExpEval = new frmExpEval(this.objRevEvalCred.idEvalCred, this.objRevEvalCred.idSolicitud, this.objRevEvalCred.idTipEval);
            frmExpEval.ShowDialog();
        }

        private void btnPosIntInterv_Click(object sender, EventArgs e)
        {
            new frmPosicionInterv().MostrarReporte(this.objRevEvalCred.cDocumentoID, this.objRevEvalCred.cNombre, this.objRevEvalCred.idCli);
        }

        private void btnExcepciones_Click(object sender, EventArgs e)
        {
            if (nExcepciones > 0)
            {
                int nNivelActual = this.objRevEvalCred.idNivelAprobacion;
                int nNivelAprobacion = 99;
                int idSolicitud = Convert.ToInt32(objRevEvalCred.idSolicitud);
                frmAprobaExcepcionesCred frmAprobaExcepciones = new frmAprobaExcepcionesCred(nNivelActual, nNivelAprobacion, idSolicitud, 0);

                frmAprobaExcepciones.ShowDialog();
            }
            else
            {
                MessageBox.Show("El crédito no presenta Excepciones", "Excepciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Condiciones del Crédito
        private void btnEditarCondCredito_Click(object sender, EventArgs e)
        {
            habilitarConCreditoTasa(true);
        }

        private void btnGrabarCondCredito_Click(object sender, EventArgs e)
        {
            clsMsjError objError = conCreditoTasa.Validar();

            if (objError.HasErrors)
            {
                MessageBox.Show("La propuesta contiene errores.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsCreditoProp objCredProp = conCreditoTasa.ObtenerCreditoPropuesto();

            clsCNAprobacionCredito objCNAproCred = new clsCNAprobacionCredito();
            DataTable dtRes = objCNAproCred.ActualizarCondicionesCredito(objCredProp.idEvalCred,objCredProp.idSolicitud, objCredProp.nMonto, objCredProp.nCuotas, objCredProp.idTipoPeriodo,
                objCredProp.nPlazoCuota, objCredProp.nPlazo, objCredProp.nCuotasGracia, objCredProp.nDiasGracia, objCredProp.dFechaDesembolso, objCredProp.idProducto, objCredProp.idTasa, objCredProp.nTasaCompensatoria);

            if (Convert.ToInt32(dtRes.Rows[0]["idError"]) == 0)
            {
                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], "ACTUALIZACIÓN CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("" + dtRes.Rows[0]["cMensaje"], "ERROR INESPERADO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


            //grabar en la Base de datos
            habilitarConCreditoTasa(false);
        }

        private void btnCancelarCondCredito_Click(object sender, EventArgs e)
        {
            habilitarConCreditoTasa(false);

            this.conCreditoTasa.AsignarDatos(this.objCNAprobacionCredito.ObtenerCondicionesCredito(this.objRevEvalCred.idEvalCred));
            // recuperar condiciones del credito de la base de datos
        }

        private void habilitarConCreditoTasa(bool lHabilitado)
        {
            conCreditoTasa.Enabled = lHabilitado;

            grbObservaciones.Enabled = !lHabilitado;
            //grbMiembros.Enabled = !lHabilitado;
            grbDecision.Enabled = !lHabilitado;
            btnImprimir.Enabled = !lHabilitado;
            btnPosIntInterv.Enabled = !lHabilitado;
            btnExcepciones.Enabled = !lHabilitado;
            chcVerificacion.Enabled = !lHabilitado;
            lblnroExcepciones.Enabled = !lHabilitado;
            //txtComentRev.Enabled = !lHabilitado;

            btnGrabarCondCredito.Enabled = lHabilitado;
            btnEditarCondCredito.Enabled = !lHabilitado;
            //btnCancelarCondCredito.Enabled = lHabilitado;
        }

        public void HabilitarPanelDecision(bool lAccion, int nPanel)
        {

            switch (nPanel)
            {
                case 1: this.tbpDecision.Enabled = lAccion; break;
            }
        }

        #endregion

        #region Observaciones
        private void btnAddObs_Click(object sender, EventArgs e)
        {
            frmObsAprobacion frmEditObs = new frmObsAprobacion();
            frmEditObs.idOrigenObs = 1;

            clsObservacionAprobador objObservacion = new clsObservacionAprobador();

            objObservacion.idObsAprobador = 0;
            //objObservacion.idSolicitud= objEvalCred.idSolicitud;
            objObservacion.idTipObservacion = 0;
            objObservacion.cTipObservacion = string.Empty;
            objObservacion.cObservacion = string.Empty;
            objObservacion.lSubsanado = false;
            objObservacion.idUsuReg = clsVarGlobal.User.idUsuario;

            frmEditObs.objObservacion = objObservacion;
            frmEditObs.ShowDialog();

            if (!frmEditObs.lAceptado) return;

            this.objRevEvalCred.lstObsAprobador.Add(objObservacion);
            bindingObservaciones.ResetBindings(false);
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

            this.objRevEvalCred.lstObsAprobador.Remove(objObservacion);
            //bindingObservaciones.DataSource = objEvalCred.lstObservaciones;
            bindingObservaciones.ResetBindings(false);
        }

        private void btnEditObs_Click(object sender, EventArgs e)
        {
            if (dtgObservaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el registro a editar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //dtgObservaciones.SelectedCells.co

            clsObservacionAprobador objObservacion = dtgObservaciones.SelectedRows[0].DataBoundItem as clsObservacionAprobador;

            if (objObservacion.idObsAprobador != 0)
            {
                MessageBox.Show("Solo se pueden editar las observaciones nuevas.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmObsAprobacion frmEditObs = new frmObsAprobacion();

            //frmEditObs.idOrigenObs = objObservacion.idOrigenObs;
            frmEditObs.objObservacion = objObservacion;
            frmEditObs.ShowDialog();

            bindingObservaciones.DataSource = this.objRevEvalCred.lstObsAprobador;
            bindingObservaciones.ResetBindings(false);
        }

        private void btnSubsanar_Click(object sender, EventArgs e)
        {
            if (dtgObservaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione la observación a subsanar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            clsObservacionAprobador objObservacion = dtgObservaciones.SelectedRows[0].DataBoundItem as clsObservacionAprobador;

            if (objObservacion == null) return;

            if (objObservacion.idObsAprobador == 0)
            {
                MessageBox.Show("No se puede subsanar una observacion recien creada.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            objObservacion.lSubsanado = true;
            this.bindingObservaciones.ResetBindings(false);
        }
        #endregion

        private void btnEliLista_Click(object sender, EventArgs e)
        {
            frmBusEvalCli frmBusEvalCli = new frmBusEvalCli(frmBusEvalCli.DEVOLVER_EVAL,2);
            frmBusEvalCli.MultiSeleccion = false;
            frmBusEvalCli.ShowDialog();


            if (frmBusEvalCli.LstEvalCredComites == null || frmBusEvalCli.LstEvalCredComites.Count==0) 
            {
                this.HabilitarPanelDecision(false, 1);
                return;
            }
           
            this.idEvalCred = frmBusEvalCli.LstEvalCredComites[0].idEval;
            this.CargarDatosAprobacionEvalCred();
        }

        #endregion

        private void MostrarGarantias(int idSolicitud)
        {
            DataSet dsGarantias = new clsCNComiteCreditos().CNLstGarantiasSolCre(idSolicitud);
            DataTable dtFiadorSolidario = dsGarantias.Tables[0];
            DataTable dtGarantias = dsGarantias.Tables[1];

            dtgFiadorSolidario.DataSource = dtFiadorSolidario;
            dtgGarantias.DataSource = InvertirCamporGarantias(dtGarantias);
            formatoDTGGarantias();
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
                if (String.Compare(dtGarantias.Columns[i].ColumnName, "cTipoGarantia") == 0)
                    drFila["Campo"] = "Tipo de Garantía";
                else if (String.Compare(dtGarantias.Columns[i].ColumnName, "cNombre") == 0)
                    drFila["Campo"] = "Propietario";
                else if (String.Compare(dtGarantias.Columns[i].ColumnName, "cGarantia") == 0)
                    drFila["Campo"] = "Descripción";
                else if (String.Compare(dtGarantias.Columns[i].ColumnName, "cUbigeo") == 0)
                    drFila["Campo"] = "Ubigeo";
                else if (String.Compare(dtGarantias.Columns[i].ColumnName, "nValorRealiza") == 0)
                    drFila["Campo"] = "Valor de realización";
                else if (String.Compare(dtGarantias.Columns[i].ColumnName, "dFecUltVal") == 0)
                    drFila["Campo"] = "Fecha de tasación";
                else
                    drFila["Campo"] = dtGarantias.Columns[i].ColumnName;
                for (int j = 0; j < dtGarantias.Rows.Count; j++)
                {
                    drFila["Garantía_" + (j + 1)] = dtGarantias.Rows[j][i].ToString();
                }
                dtInvertidoGaranti.Rows.Add(drFila);
            }

            return dtInvertidoGaranti;
        }

        private void formatoDTGGarantias()
        {
            foreach (DataGridViewColumn item in this.dtgGarantias.Columns)
            {
                item.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", (float)(7.5));
            }
        }

    }
}
