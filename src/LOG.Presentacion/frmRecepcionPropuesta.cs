using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using LOG.CapaNegocio;
using System.Data;
using RPT.CapaNegocio;
using Microsoft.Reporting.WinForms;

namespace LOG.Presentacion
{
    public partial class frmRecepcionPropuesta : frmBase
    {

        #region Variables

        private const string cTituloMsjes = "Evaluacion de proceso de adjudicacción";
        private readonly DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;

        private clsProcesoAdjudicacion prsAdj;
        private clsCNProcesoAdjudicacion _objCNProceso;
        private clsCNProveedor _objCNProveedor;

        #endregion

        #region Constructores

        public frmRecepcionPropuesta()
        {
            InitializeComponent();
            _objCNProceso = new clsCNProcesoAdjudicacion();
            _objCNProveedor = new clsCNProveedor();
        }

        #endregion

        #region Eventos

        private void frmRegAdquisiciones_Load(object sender, EventArgs e)
        {
            dtpFechaSis.Value = dFechaSis;
            txtUsuario.Text = clsVarGlobal.User.cWinUser;
            cboEstadoProcLog.listarEstadoProcesoAdj(3);

            InitForm();
        }

        private void txtCodigoPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                BuscarProceso();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            frmBuscarRecepcionPropuesta frmBusProcAdj = new frmBuscarRecepcionPropuesta();
            frmBusProcAdj.ShowDialog();
            if (frmBusProcAdj.lAcepta)
            {
                int idProAdj = frmBusProcAdj.idProcesoAdj;
                txtCodigoPro.Text = idProAdj.ToString();
                BuscarProceso();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dtgGrupo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el grupo.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if(dtgProveedores.SelectedRows.Count > 0)
            {
                var objProveedor = dtgProveedores.SelectedCells[0].OwningRow.DataBoundItem as clsVinculoProveedor;

                if (dtgProveedores.Rows.Count > 0 && objProveedor.idEstadoEvaProveedor < 4 && objProveedor.nCalificacion > 0)
                {
                    MessageBox.Show("Existe seleccionado un proveedor en evaluación", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            int idGrupo = Convert.ToInt32(dtgGrupo.SelectedCells[0].OwningRow.Cells["Grupo"].Value);

            frmBusquedaProveedor frmBusProveedor = new frmBusquedaProveedor();
            frmBusProveedor.ShowDialog();
            if (frmBusProveedor.objProveedor == null)
            {
                MessageBox.Show("No se selecciono ningun proveedor", "Agregar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (prsAdj.LstProveedores.Any(x => x.idProveedor == frmBusProveedor.objProveedor.idProveedor && x.nGrupo == idGrupo))
            {
                MessageBox.Show("Ya Existe el Proveedor", "Validación de Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            //carga las notas de pedido a vincular con el proceso
            var VinProv = new clsVinculoProveedor();
            VinProv.cNroDocumento = frmBusProveedor.objProveedor.cDocumentoID;
            VinProv.cProveedor = frmBusProveedor.objProveedor.cNombreComercial;
            VinProv.dFechaReg = dFechaSis;
            VinProv.idUsuReg = clsVarGlobal.User.idUsuario;
            VinProv.idProcesoAdj = Convert.ToInt32(txtCodigoPro.Text.Trim());
            VinProv.idProveedor = frmBusProveedor.objProveedor.idProveedor;
            VinProv.idEstadoEvaProveedor = 0;
            VinProv.nCalificacion = 1;
            VinProv.nGrupo = idGrupo;
            VinProv.lContinuar = true;

            prsAdj.LstProveedores.Add(VinProv);
            FillProveedores(idGrupo);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgProveedores.SelectedRows.Count == 0)
                return;

            if (dtgGrupo.SelectedRows.Count == 0)
                return;

            int idGrupo = Convert.ToInt32(dtgGrupo.SelectedCells[0].OwningRow.Cells["Grupo"].Value);

            var objProveedor = dtgProveedores.SelectedRows[0].DataBoundItem as clsVinculoProveedor;
            if (objProveedor.idEstadoEvaProveedor > 0)
            {
                MessageBox.Show("No se puede eliminar proveedores con evaluaciones realizadas.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var result = MessageBox.Show("¿Está seguro de quitar al proveedor?", cTituloMsjes, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            prsAdj.LstProveedores.Remove(objProveedor);
            FillProveedores(idGrupo);
        }

        private void btnReqMinimo_Click(object sender, EventArgs e)
        {
            if (!ValidaOperacion())
                return;

            int idGrupo = Convert.ToInt32(dtgGrupo.SelectedRows[0].Cells["Grupo"].Value);
            var objProveedor = dtgProveedores.SelectedRows[0].DataBoundItem as clsVinculoProveedor;

            frmEvaReqMinimo frmEvamRepMin = new frmEvaReqMinimo(objProveedor.cProveedor);
            frmEvamRepMin.nGrupo = idGrupo;
            frmEvamRepMin.idVincuProveedor = objProveedor.idVinculoProveedor;
            frmEvamRepMin.pIdProveedor = objProveedor.idProveedor;
            frmEvamRepMin.pIdProceso = objProveedor.idProcesoAdj.Value;
            frmEvamRepMin.lstDetProAdj = prsAdj.listaDetalleProAdj;
            frmEvamRepMin.lConfirmado = prsAdj.lConfirmacion.Value;
            frmEvamRepMin.ShowDialog();

            if (!frmEvamRepMin.lFlagAcep)
                return;

            int idEstadoEvaProveedor = frmEvamRepMin.idEstadoEva;
            bool lcontinuar = frmEvamRepMin.lContinuar;

            if (objProveedor.idEstadoEvaProveedor < frmEvamRepMin.idEstadoEva)
                objProveedor.idEstadoEvaProveedor = frmEvamRepMin.idEstadoEva;

            objProveedor.lContinuar = lcontinuar;
            objProveedor.idVinculoProveedor = frmEvamRepMin.idVincuProveedor;
            prsAdj.idEstado = frmEvamRepMin.idEstaEva;

            cboEstadoProcLog.SelectedValue = frmEvamRepMin.idEstaEva;

            if (!lcontinuar)
                objProveedor.nCalificacion = 0;

            ActualizaDatosProveedor(objProveedor.idVinculoProveedor);
            FillProveedores(idGrupo, objProveedor.idProveedor);
        }

        private void btnDocumento_Click(object sender, EventArgs e)
        {
            if (!ValidaOperacion())
                return;

            int idGrupo = Convert.ToInt32(dtgGrupo.SelectedRows[0].Cells["Grupo"].Value);
            var objProveedor = dtgProveedores.SelectedRows[0].DataBoundItem as clsVinculoProveedor;

            if (objProveedor.idEstadoEvaProveedor < 1)
            {
                MessageBox.Show("Debe Realizar la Evaluacion de Requisitos Minimos", "Valida Evaluación de Requisitos Minimos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmDocEntregaAdjudicaccion frmRegDoc = new frmDocEntregaAdjudicaccion(objProveedor.cProveedor);
            frmRegDoc.idVincuProveedor = objProveedor.idVinculoProveedor;
            frmRegDoc.pIdProveedor = objProveedor.idProveedor;
            frmRegDoc.pIdProceso = (int)objProveedor.idProcesoAdj;
            frmRegDoc.lConfirmado = (bool)prsAdj.lConfirmacion;
            frmRegDoc.ShowDialog();

            if (!frmRegDoc.lFlagAcep)
                return;

            int idEstadoEvaProveedor = frmRegDoc.idEstadoEva;
            bool lcontinuar = frmRegDoc.lContinuar;

            if (objProveedor.idEstadoEvaProveedor < frmRegDoc.idEstadoEva)
                objProveedor.idEstadoEvaProveedor = frmRegDoc.idEstadoEva;

            objProveedor.lContinuar = lcontinuar;

            if (!lcontinuar)
                objProveedor.nCalificacion = 0;

            ActualizaDatosProveedor(objProveedor.idVinculoProveedor);
            FillProveedores(idGrupo, objProveedor.idProveedor);
        }

        private void btnFactorTecnico_Click(object sender, EventArgs e)
        {
            if (!ValidaOperacion())
                return;

            int idGrupo = Convert.ToInt32(dtgGrupo.SelectedRows[0].Cells["Grupo"].Value);
            var objProveedor = dtgProveedores.SelectedRows[0].DataBoundItem as clsVinculoProveedor;

            if (objProveedor.idEstadoEvaProveedor < 2)
            {
                MessageBox.Show("Debe Realizar la Evaluación de Documentos", "Valida Evaluación de Documentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            frmEvalFactorTecProceso frmFacTec = new frmEvalFactorTecProceso(objProveedor.cProveedor);
            frmFacTec.nGrupo = idGrupo;
            frmFacTec.pIdProceso = objProveedor.idProcesoAdj.Value;
            frmFacTec.idVincuProveedor = objProveedor.idVinculoProveedor;
            frmFacTec.lstDetProAdj = prsAdj.listaDetalleProAdj;
            frmFacTec.pIdProveedor = objProveedor.idProveedor;
            frmFacTec.lConfirmado = prsAdj.lConfirmacion.Value;
            frmFacTec.ShowDialog();

            if (!frmFacTec.lFlagAcep)
                return;

            int idEstadoEvaProveedor = frmFacTec.idEstadoEva;
            bool lcontinuar = frmFacTec.lContinuar;

            if (objProveedor.idEstadoEvaProveedor < frmFacTec.idEstadoEva)
                objProveedor.idEstadoEvaProveedor = frmFacTec.idEstadoEva;

            objProveedor.lContinuar = lcontinuar;

            if (!lcontinuar)
                objProveedor.nCalificacion = 0;

            ActualizaDatosProveedor(objProveedor.idVinculoProveedor);
            FillProveedores(idGrupo, objProveedor.idProveedor);
        }

        private void btnEvaEconomica_Click(object sender, EventArgs e)
        {
            if (!ValidaOperacion())
                return;

            int idGrupo = Convert.ToInt32(dtgGrupo.SelectedRows[0].Cells["Grupo"].Value);
            var objProveedor = dtgProveedores.SelectedRows[0].DataBoundItem as clsVinculoProveedor;

            if (objProveedor.idEstadoEvaProveedor < 3)
            {
                MessageBox.Show("Debe Realizar la Evaluación de Factores Técnicos", "Valida Evaluación de Factores Técnicos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmEvaluacionEconomica frmEvaEco = new frmEvaluacionEconomica();
            frmEvaEco.cProveedor = objProveedor.cProveedor;//.lstVinPro = plstVinPro;
            frmEvaEco.cCodigo = objProveedor.idProveedor.ToString();
            frmEvaEco.cNroDoc = objProveedor.cNroDocumento;
            frmEvaEco.idProceso = Convert.ToInt32(objProveedor.idProcesoAdj.ToString());
            frmEvaEco.lstDetallePro = prsAdj.listaDetalleProAdj;
            frmEvaEco.idVinculoPro = objProveedor.idVinculoProveedor;
            frmEvaEco.lConfirmado = (bool)prsAdj.lConfirmacion;
            frmEvaEco.pnGrupo = idGrupo;
            frmEvaEco.ShowDialog();

            if (!frmEvaEco.lFlagAcep)
                return;

            int idEstadoEvaProveedor = frmEvaEco.idEstadoEvaPro;

            if (objProveedor.idEstadoEvaProveedor < frmEvaEco.idEstadoEvaPro)
                objProveedor.idEstadoEvaProveedor = frmEvaEco.idEstadoEvaPro;

            ActualizaDatosProveedor(objProveedor.idVinculoProveedor);
            FillProveedores(idGrupo, objProveedor.idProveedor);
        }

        private void btnEvaluar_Click(object sender, EventArgs e)
        {
            if (!ValidaOperacion())
                return;

            var result = MessageBox.Show("¿Desea calificar al proveedor?", cTituloMsjes, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result != DialogResult.Yes)
                return;

            int idGrupo = Convert.ToInt32(dtgGrupo.SelectedRows[0].Cells["Grupo"].Value);
            var objProveedor = dtgProveedores.SelectedRows[0].DataBoundItem as clsVinculoProveedor;

            clsDBResp objDbResp = _objCNProveedor.CalificarProveedor(objProveedor.idVinculoProveedor, clsVarGlobal.User.idUsuario, dFechaSis);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizaDatosProveedor(objProveedor.idVinculoProveedor);
                FillProveedores(idGrupo, objProveedor.idProveedor);
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            #region Proceso Adjudicacion

            prsAdj.dFechaMod = clsVarGlobal.dFecSystem.Date;
            prsAdj.idUsuMod = clsVarGlobal.User.idUsuario;
            prsAdj.cObservacion = txtObservacion.Text;
            prsAdj.lConfirmacion = false;

            #endregion

            int nResp = 0;
            string msg = "";
            msg = new clsCNEvalProcAdj().GrabarProcesoEvaluacionAdj(prsAdj, ref nResp);
            if (nResp == 0)
            {
                MessageBox.Show(msg, "Proceso de Adjudicación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show(msg, "Proceso de Adjudicación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BuscarProceso();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (prsAdj == null || dtgGrupo.RowCount == 0)
            {
                MessageBox.Show("Ingrese Nº de  Proceso", "Validar Proceso de Adjudicaccion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoPro.Focus();
                return;
            }

            HabilitarControl(true);
            HabBotXEst(-1);

            btnEditar.Enabled = false;
            btnAgregar.Enabled = true;
            btnQuitar.Enabled = true;
            btnGrabar.Enabled = true;
            btnBuenaPro.Enabled = true;
            btnBusqueda.Enabled = false;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarControl(false);            
            LimpiarControles();
            InitForm();
        }

        private void dtgGrupo_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarDetalleGrupo();
        }

        private void dtgProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgProveedores.SelectedRows.Count == 0)
                return;

            var objProveedor = dtgProveedores.SelectedRows[0].DataBoundItem as clsVinculoProveedor;
            HabilitarBotonesEva();
            if (!objProveedor.lContinuar)
            {
                MessageBox.Show("Se ha descalificado a este proveedor, no se puede realizar ninguna otra modificación", "Distribuidor descalificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HabBotXEst(-1);
            }
        }

        private void cboTipoProcesoLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoProcesoLog.SelectedIndex < 0)
            {
                txtDesCorto.Text = string.Empty;
                return;
            }
            CargarDescorto(Convert.ToInt32(cboTipoProcesoLog.SelectedValue));
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dFechaSis = clsVarGlobal.dFecSystem.Date;
            string cNombreEmp = clsVarApl.dicVarGen["cNomEmpresa"];
            string cVarVal = clsVarApl.dicVarGen["CRUTALOGO"];
            int idProceso = Convert.ToInt32(txtCodigoPro.Text.Trim());

            if (!prsAdj.lConfirmacion.Value)
            {
                MessageBox.Show("Aun no se ha dado la Buena Pro a este proceso", "Buena Pro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dtBuenaPro = new clsRPTCNLogistica().CNImpresionBuenaPro(idProceso);
            if (dtBuenaPro.Rows.Count == 0)
            {
                MessageBox.Show("No existen datos para la Evaluación de Proveedores", "Evaluación de proveedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                List<ReportParameter> paramlist = new List<ReportParameter>();
                paramlist.Clear();
                paramlist.Add(new ReportParameter("idProceso", idProceso.ToString(), false));
                paramlist.Add(new ReportParameter("x_cNombreEmp", cNombreEmp, false));
                paramlist.Add(new ReportParameter("x_dFechaSis", dFechaSis.ToString("dd/MM/yyyy"), false));
                paramlist.Add(new ReportParameter("cNombreVariable", cVarVal, false));
                List<ReportDataSource> dtslist = new List<ReportDataSource>();
                dtslist.Clear();

                dtslist.Add(new ReportDataSource("dtsBuenaPro", dtBuenaPro));

                string reportpath = "RptBuenaPro.rdlc";
                new frmReporteLocal(dtslist, reportpath, paramlist).ShowDialog();
            }
        }

        private void btnBuenaPro_Click(object sender, EventArgs e)
        {
            var query = prsAdj.LstProveedores.Where(x => x.nCalificacion > 0);
            if (query.Any(x => x.idEstadoEvaProveedor < 5))
            {
                MessageBox.Show("Debe terminar la evaluación de todos los proveedores",
                                    cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (prsAdj.LstProveedores.Count == 0)
            {
                var resultQuestion = MessageBox.Show("Existen grupos sin ganador.¿Desea declarar desierto el proceso?",
                                                cTituloMsjes, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultQuestion != DialogResult.Yes)
                    return;

                clsDBResp objDbResp = _objCNProceso.CNDeclararDesiertoProceso(prsAdj.idProceso, clsVarGlobal.User.idUsuario, dFechaSis);
                if (objDbResp.nMsje == 0)
                {
                    MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BuscarProceso();
                }
                else
                {
                    MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }

            frmGanadoresProceso frmGanador = new frmGanadoresProceso(prsAdj);
            frmGanador.ShowDialog();

            bool lConfirmacion = frmGanador.lConfirmacion;
            if (!lConfirmacion)
                LimpiarGanadores();

            BuscarProceso();
        }

        #endregion

        #region Metodos

        private void BuscarProceso()
        {
            if (string.IsNullOrEmpty(txtCodigoPro.Text.Trim()))
            {
                MessageBox.Show("Ingrese Nº de proceso correcto.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarControles();
                InitForm();
                return;
            }
            int idProcesoAdj = Convert.ToInt32(txtCodigoPro.Text.Trim());
            prsAdj = _objCNProceso.buscarProcesoAdj(idProcesoAdj);
            if (prsAdj.idProceso == 0)
            {
                MessageBox.Show("No se encontraron datos del Nº de proceso.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarControles();
                InitForm();
                return;
            }

            //if (prsAdj.idEstado == 10) // proceso desierto
            //{
            //    MessageBox.Show("El proceso se ha declarado desierto", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    LimpiarControles();
            //    InitForm();
            //    return;
            //}

            clsDBResp objDbResp = _objCNProceso.ValidarProcesoAdjudicacion(prsAdj.idProceso);
            if (objDbResp.nMsje > 0)
            {
                MessageBox.Show(objDbResp.cMsje, "Proceso de Adjudicacción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarControles();
                InitForm();
                return;
            }

            cboTipoProcesoLog.SelectedValue = prsAdj.idTipoProceso;
            cboTipoPedidoLog.SelectedValue = prsAdj.idTipoPedido;
            cboEstadoProcLog.SelectedValue = prsAdj.idEstado;
            txtFecCul.Text = prsAdj.dfechaCulminacion;
            txtUsuario.Text = prsAdj.cUsuReg;
            dtpFechaSis.Value = prsAdj.dFechaReg.Value;
            cboMoneda.SelectedValue = prsAdj.idMoneda;
            txtObjeto.Text = prsAdj.cObjetoAdquisicion;
            txtObservacion.Text = prsAdj.cObservacion;
            prsAdj.LstProveedores = new clsCNProveedor().ListaVinculoProveedor(idProcesoAdj);

            HabilitarControl(false);

            FillGrupos();

            btnEditar.Enabled = !prsAdj.lConfirmacion.Value;
            btnImprimir.Enabled = prsAdj.lConfirmacion.Value;
            btnAgregar.Enabled = false;
            btnQuitar.Enabled = false;
            btnGrabar.Enabled = false;
            btnBuenaPro.Enabled = false;
            btnBusqueda.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void InitForm()
        {
            HabilitarControl(false);
            HabBotXEst(-1);
            txtCodigoPro.Focus();
            txtCodigoPro.SelectAll();

            btnEditar.Enabled = false;
            btnImprimir.Enabled = false;
            btnAgregar.Enabled = false;
            btnQuitar.Enabled = false;
            btnGrabar.Enabled = false;
            btnBuenaPro.Enabled = false;
            btnBusqueda.Enabled = true;
            btnCancelar.Enabled = false;
        }

        private void ActualizaDatosProveedor(int idVinculoProveedor)
        {
            var objProv = prsAdj.LstProveedores.First(x => x.idVinculoProveedor == idVinculoProveedor);
            var objNuevoProv = _objCNProveedor.ObtieneVinculoProveedor(idVinculoProveedor);

            int index = prsAdj.LstProveedores.IndexOf(objProv);
            if (index != -1)
                prsAdj.LstProveedores[index] = objNuevoProv;
        }

        private bool ValidaOperacion()
        {
            if (dtgProveedores.RowCount == 0)
            {
                MessageBox.Show("Agregue un proveedor para la evaluación.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dtgProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el proveedor a evaluar.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dtgGrupo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione el grupo.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarControles()
        {
            txtDesCorto.Text = string.Empty;
            txtCodigoPro.Text = string.Empty;
            cboTipoProcesoLog.SelectedIndex = -1;
            cboTipoPedidoLog.SelectedIndex = -1;
            cboEstadoProcLog.SelectedIndex = -1;
            dtpFechaSis.Value = clsVarGlobal.dFecSystem.Date;
            txtFecCul.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            cboMoneda.SelectedIndex = -1;
            txtObjeto.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            txtValRef.Text = "0.00";

            if (dtgGrupo.RowCount > 0)
                dtgGrupo.Rows.Clear();
            dtgDetalleAdqui.DataSource = null;
            dtgProveedores.DataSource = null;
        }

        private void CargarDescorto(int idTipoProceso)
        {
            foreach (DataRow item in cboTipoProcesoLog.dt.Rows)
            {
                if (Convert.ToInt32(item["idTipoProceso"]) == idTipoProceso)
                {
                    txtDesCorto.Text = item["cDescCorta"].ToString();
                    break;
                }
            }
        }

        private void FillGrupos()
        {
            dtgGrupo.SelectionChanged -= dtgGrupo_SelectionChanged;

            if (dtgGrupo.RowCount > 0)
                dtgGrupo.Rows.Clear();

            var grupos = prsAdj.listaDetalleProAdj.GroupBy(x => new { x.idGrupo, x.cDesGrupo });
            foreach (var grupo in grupos)
            {
                dtgGrupo.Rows.Add(grupo.Key.idGrupo, grupo.Key.cDesGrupo);
            }

            dtgGrupo.ClearSelection();

            dtgGrupo.SelectionChanged += dtgGrupo_SelectionChanged;

            if (dtgGrupo.RowCount > 0)
                dtgGrupo.Rows[0].Selected = true;
        }

        private void HabilitarControl(bool lactvia)
        {
            txtCodigoPro.Enabled = !lactvia;
            txtObservacion.Enabled = lactvia;
        }

        private void ActualizarDetalleGrupo()
        {
            if (dtgGrupo.RowCount <= 0)
                return;

            if (dtgGrupo.SelectedRows.Count == 0)
                return;

            int idGrupo = Convert.ToInt32(dtgGrupo.SelectedRows[0].Cells["Grupo"].Value);

            dtgDetalleAdqui.DataSource = prsAdj.listaDetalleProAdj.Where(x => x.idGrupo == idGrupo).ToList();
            FillProveedores(idGrupo);
            txtValRef.Text = prsAdj.listaDetalleProAdj.Where(x => x.idGrupo == idGrupo).Sum(x => x.nsubTotal).ToString();
        }

        private void HabilitarBotonesEva()
        {
            if (dtgProveedores.RowCount <= 0)
                return;

            if (dtgProveedores.SelectedRows.Count == 0)
                return;

            var objProveedor = dtgProveedores.SelectedRows[0].DataBoundItem as clsVinculoProveedor;

            HabBotXEst(objProveedor.idEstadoEvaProveedor);
        }

        private void HabBotXEst(int idEstado)
        {
            btnReqMinimo.Enabled = false;
            btnDocumento.Enabled = false;
            btnFactorTecnico.Enabled = false;
            btnEvaEconomica.Enabled = false;
            btnEvaluar.Enabled = false;

            switch (idEstado)
            {
                case 0:
                    btnReqMinimo.Enabled = true;
                    break;
                case 1:
                    btnReqMinimo.Enabled = true;
                    btnDocumento.Enabled = true;
                    break;
                case 2:
                    btnReqMinimo.Enabled = true;
                    btnDocumento.Enabled = true;
                    btnFactorTecnico.Enabled = true;
                    break;
                case 3:
                    btnReqMinimo.Enabled = true;
                    btnDocumento.Enabled = true;
                    btnFactorTecnico.Enabled = true;
                    btnEvaEconomica.Enabled = true;
                    break;
                case 4:
                    btnReqMinimo.Enabled = true;
                    btnDocumento.Enabled = true;
                    btnFactorTecnico.Enabled = true;
                    btnEvaEconomica.Enabled = true;
                    btnEvaluar.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void FillProveedores(int idGrupo,int idProveedor = 0)
        {
            dtgProveedores.SelectionChanged -= dtgProveedores_SelectionChanged;

            dtgProveedores.DataSource = prsAdj.LstProveedores.Where(x => x.nGrupo == idGrupo).ToList();
            dtgProveedores.ClearSelection();

            dtgProveedores.SelectionChanged += dtgProveedores_SelectionChanged;

            if (idProveedor > 0)
            {
                var result = dtgProveedores.Rows.Cast<DataGridViewRow>()
                                        .FirstOrDefault(x => Convert.ToInt32(x.Cells["idProveedorDataGridViewTextBoxColumn"].Value) == idProveedor);
                if (result == null)
                    return;

                result.Selected = true;
            }
            else
            {
                if (dtgProveedores.RowCount > 0)
                    dtgProveedores.Rows[0].Selected = true;
            }

        }

        private void LimpiarGanadores()
        {
            foreach (var prov in prsAdj.LstProveedores)
            {
                prov.lGanadorTemp = false;
            }
        }

        #endregion

    }
}