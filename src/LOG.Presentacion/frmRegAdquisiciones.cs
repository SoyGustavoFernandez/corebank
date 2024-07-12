using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using GEN.ControlesBase;
using EntityLayer;
using LOG.CapaNegocio;
using System.Data;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using GEN.Funciones;

namespace LOG.Presentacion
{
    public partial class frmRegAdquisiciones : frmBase
    {
        #region Variables

        clsCNProcesoAdjudicacion buscaProcesoAdj = new clsCNProcesoAdjudicacion();

        clslistaVinculoNotaPedido listNotPed = new clslistaVinculoNotaPedido();
        clsListaCalendarioAdj lstCalAdj = new clsListaCalendarioAdj();
        clsListaDetalleProcesoAdj lisDetProAdj = new clsListaDetalleProcesoAdj();
        clsListaPuntajeProcesoAdj lstPuntAdj = new clsListaPuntajeProcesoAdj();
        clsListaFactoresTecnicos lstFactorTecnico = new clsListaFactoresTecnicos();
        clsListaDocumentoPorCalendario pLstDocCal = new clsListaDocumentoPorCalendario();

        clsProcesoAdjudicacion ProcAdj = null;
        clsVinculoNotaPedido NotaPed = null;

        private string cOpcNuevEdit = "";
        private int nValTipEval = 0;
        private int idTipPedNota = 0;
        public int idProceso;
        private bool lConfirmado = false;
        private bool lIgv = false;

        #endregion

        #region Eventos

        private void frmRegAdquisiciones_Load(object sender, EventArgs e)
        {
            cboEstadoProcLog.listarEstadoProcesoAdj(3);
            dtpFechaSis.Value = clsVarGlobal.dFecSystem;
            txtUsuario.Text = clsVarGlobal.User.cWinUser;
            HablitarBotones(true);
            HabilitarControl(false);

            // dtgNotasPedido.DataSource = null;
            listNotPed = new clslistaVinculoNotaPedido();
            //  dtgNotasPedido.DataSource = listNotPed;

            dtgDetalleAdqui.DataSource = null;
            lisDetProAdj = new clsListaDetalleProcesoAdj();
            dtgDetalleAdqui.DataSource = lisDetProAdj;

            SumaValRefrencial();
            txtObservacion.Enabled = false;
            chbIGV.Enabled = false;

        }

        #region Botones

        private void btnCalendario_Click(object sender, EventArgs e)
        {
            int idTipoProceso = (int)this.cboTipoProcesoLog.SelectedValue;
            frmGenCalendarioPro frmCalPro = new frmGenCalendarioPro();
            frmCalPro.lConfirmado = lConfirmado;
            frmCalPro.IdTipoProceso = idTipoProceso;
            //frmCalPro.idProceso = ProcAdj.idProceso;
            frmCalPro.idProceso = idProceso;
            //frmCalPro.lstCalendario = lstCalAdj;
            frmCalPro.ShowDialog();
            //lstCalAdj = frmCalPro.lstCalendario;
        }

        private void btnPuntaje_Click(object sender, EventArgs e)
        {
            CargaProcesoAdqui();


            if (Convert.ToInt32(cboTipoEvalAdjudicacion.SelectedValue) <= 0)
            {
                MessageBox.Show("Seleccione Tipo de Grupo", "Valida Tipo de Grupo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lisDetProAdj.Where(x => x.idGrupo == null).Count() > 0)
            {
                MessageBox.Show("Existen Items sin grupo. Todos los items deben de estar en un grupo.", "Valida Tipo de Grupo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProcAdj.idProceso = idProceso;

            frmRegPuntajeProceso frmPuntaje = new frmRegPuntajeProceso();
            frmPuntaje.idProceso = idProceso;
            frmPuntaje.listNotPed = listNotPed;
            frmPuntaje.ProcAdj = ProcAdj;
            frmPuntaje.lisDetProAdj = lisDetProAdj;
            frmPuntaje.lConfirmado = lConfirmado;
            frmPuntaje.idTipoPedido = Convert.ToInt16(cboTipoPedidoLog.SelectedValue);
            frmPuntaje.ShowDialog();
            idProceso = frmPuntaje.idProceso;
            ProcAdj.idProceso = idProceso;

            if (idProceso > 0)
            {
                this.txtCodigoPro.Text = idProceso.ToString();
                this.btnCalendario.Enabled = true;
                this.btnFactorTecnico.Enabled = true;
                this.btnDocumento.Enabled = true;
                this.btnReqMinimo.Enabled = true;
            }
        }

        private void btnFactorTecnico_Click(object sender, EventArgs e)
        {
            if (idProceso <= 0)
            {
                MessageBox.Show("Registre el Puntaje para Calificación", "Registro de Puntaje para calificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmGenFactorTecnico frmFacTec = new frmGenFactorTecnico();
            frmFacTec.lConfirmado = lConfirmado;
            frmFacTec.lstdetProAdj = lisDetProAdj;
            frmFacTec.idProceso = idProceso;
            frmFacTec.idTipoPedido = Convert.ToInt32(cboTipoPedidoLog.SelectedValue);
            //      frmFacTec.lstCriEva = lstFactorTecnico;
            frmFacTec.ShowDialog();
            // lstFactorTecnico = frmFacTec.lstCriEva;
        }

        private void btnReqMinimo_Click(object sender, EventArgs e)
        {
            if (lisDetProAdj.Count() <= 0)
            {
                MessageBox.Show("Registre Nota de Pedido", "Validar Requesitos Minimos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idNotaPedido = 0;
            if (!string.IsNullOrEmpty(this.txtNroNotaPedido.Text.Trim()))
            {
                idNotaPedido = Convert.ToInt32(this.txtNroNotaPedido.Text.Trim()); //((clsVinculoNotaPedido)(dtgNotasPedido.CurrentRow.DataBoundItem)).idNotaPedido;
            }

            //clsCNNotaPedido objCNNotPed = new clsCNNotaPedido();
            //List<clsDetalleNotaPedido> lstDetNota = objCNNotPed.buscarDetalleNotaPedido(idNotaPedido);

            clsCNNotaPedido clsNotPedido = new clsCNNotaPedido();
            clsNotaPedido objNotaPedido;
            //List<clsDetalleNotaPedido> 
            objNotaPedido = clsNotPedido.CNRetornaDatosNPbyIDGEN(idNotaPedido);
            frmRequisitosMin frmReqMin = new frmRequisitosMin();
            //frmReqMin.cProcesoOper = "GEN_PRO_ADJ";
            //Retorna Requisitos Minimos

            List<clsEvaRequisitosMinimos> lstReqMin = new clsCNNotaPedido().CNRetornaReqMin(objNotaPedido.idNotaPedido);
            foreach (var objDetNP in objNotaPedido.lstDetNotPedido)
            {
                objDetNP.lstReqMin = lstReqMin.Where(x => x.idDetalleNotaPedido == objDetNP.idDetalleNotaPedido).ToList();
            }

            frmReqMin.xIdNotaPedido = idNotaPedido;
            frmReqMin.pLstDetNot = objNotaPedido.lstDetNotPedido;
            frmReqMin.pLstReqMin = objNotaPedido.lstReqMin;  //revisar
            frmReqMin.cTipoOpe = "N";
            frmReqMin.lEditable = true;
            frmReqMin.ShowDialog();

            List<clsDetalleNotaPedido> lsDetNot = frmReqMin.pLstDetNot;
            string xmlDetNot = lsDetNot.GetXml<clsDetalleNotaPedido>();

            clsCNProcesoAdjudicacion objProcAdj = new clsCNProcesoAdjudicacion();
            DataTable dtResult = objProcAdj.CNGuardarReqMinProcAdj(xmlDetNot);

        }



        private void btnDocumento_Click(object sender, EventArgs e)
        {
            lstCalAdj = buscaProcesoAdj.buscaCalendarioProAdj(idProceso);
            if (lstCalAdj.Count <= 0)
            {
                MessageBox.Show("Registre Calendario del Proceso de Adquisición", "Validar Calendario Proceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Int32 idTipoProceso = (Int32)this.cboTipoProcesoLog.SelectedValue;
            frmRegDocSolProceso frmRegDoc = new frmRegDocSolProceso();
            frmRegDoc.idProceso = idProceso;
            frmRegDoc.idTipoProceso = idTipoProceso;
            frmRegDoc.LstCalendarioAdj = lstCalAdj;
            //  frmRegDoc.lstDocCal = pLstDocCal;
            frmRegDoc.ShowDialog();
            //     pLstDocCal = frmRegDoc.lstDocCal;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarGrabacion())
                return;

            if (cOpcNuevEdit == "N")
            {
                ProcAdj = new clsProcesoAdjudicacion();
                ProcAdj.idProceso = idProceso;
                ProcAdj.idTipoProceso = Convert.ToInt32(cboTipoProcesoLog.SelectedValue.ToString());
                ProcAdj.idUsuReg = clsVarGlobal.User.idUsuario;
                ProcAdj.dFechaReg = clsVarGlobal.dFecSystem;
                ProcAdj.idEstado = Convert.ToInt32(cboEstadoProcLog.SelectedValue);
                ProcAdj.idTipoEvaluacion = Convert.ToInt32(cboTipoEvalAdjudicacion.SelectedValue);
                ProcAdj.cObservacion = txtObservacion.Text;
                ProcAdj.cObjetoAdquisicion = txtObjeto.Text;
                ProcAdj.idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
                ProcAdj.idTipoPedido = Convert.ToInt32(cboTipoPedidoLog.SelectedValue);
                ProcAdj.lConfirmacion = lConfirmado;
            }

            ProcAdj.cObservacion = txtObservacion.Text;
            ProcAdj.cObjetoAdquisicion = txtObjeto.Text;
            ProcAdj.lIgv = chbIGV.Checked;
            ProcAdj.nMontoTotalIgv = Convert.ToDecimal(txtValRef.Text);

            clsDBResp objDbResp = buscaProcesoAdj.GrabarNuevaAdjudicaccion(ProcAdj, lisDetProAdj, listNotPed, lstPuntAdj, lstFactorTecnico, lstCalAdj, pLstDocCal);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, "Registro de Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buscarProcesoAdjudicaccion(objDbResp.idGenerado);
                cOpcNuevEdit = "";

                HablitarBotones(true);
                btnGrupo.Enabled = false;
                btnPuntaje.Enabled = false;
                btnCalendario.Enabled = false;
                btnDocumento.Enabled = false;
                btnFactorTecnico.Enabled = false;
                btnReqMinimo.Enabled = false;
                btnEditar.Enabled = true;
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, "Registro de Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cOpcNuevEdit = "N";
            idProceso = 0;
            LimpiarListas();
            HablitarBotones(false);
            HabilitarControl(true);
            btnBusqueda.Enabled = true;
            txtCodigoPro.Clear();
            ProcAdj = new clsProcesoAdjudicacion();
            ProcAdj.idProceso = 0;
            btnEditar.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (ProcAdj == null)
            {
                MessageBox.Show("No Existe el Proceso de Adquisición", "Valida Proceso Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cOpcNuevEdit = "E";
            HablitarBotones(false);
            HabilitarControl(true);
            //cboTipoProcesoLog.Enabled = true;
            btnPuntaje.Enabled = true;
            btnCalendario.Enabled = true;
            btnDocumento.Enabled = true;
            btnFactorTecnico.Enabled = true;
            btnReqMinimo.Enabled = true;
            btnEditar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarListas();
            limpiarDatosNP();
            HablitarBotones(true);
            HabilitarControl(false);
            cOpcNuevEdit = "";
            txtObservacion.Enabled = false;
            txtCodigoPro.Focus();
            btnBusqueda.Enabled = false;
        }

        private void limpiarDatosNP()
        {
            txtNroNotaPedido.Clear();
            txtAgenciaNP.Clear();
            txtUsuarioNP.Clear();
            cboTipoPedidoLog.SelectedIndex = -1;
            txtFechaNP.Clear();
            txtAreaNP.Clear();
            cboMoneda.SelectedIndex = -1;

        }
        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            frmBuscarNotaPedido frmBscNotaPed = new frmBuscarNotaPedido();
            frmBscNotaPed.opcFrm = 1;
            frmBscNotaPed.ShowDialog();

            if (frmBscNotaPed.objNotaPedido == null)
            {
                return;
            }

            DataTable dtRest = new clsCNProcesoAdjudicacion().CNValidaNotaPedidoEnProceso(frmBscNotaPed.objNotaPedido.idNotaPedido);
            if (dtRest.Rows.Count > 0)
            {
                MessageBox.Show("La nota de pedido Nro.: " + frmBscNotaPed.objNotaPedido.idNotaPedido + ", ya esta viculada o otro proceso de adquisición", "Proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lisDetProAdj.Clear();
            //carga las notas de pedido a vincular con el proceso
            NotaPed = new clsVinculoNotaPedido();
            NotaPed.idNotaPedido = frmBscNotaPed.objNotaPedido.idNotaPedido;
            NotaPed.dFechaVinculacion = clsVarGlobal.dFecSystem;
            NotaPed.idUsuReg = clsVarGlobal.User.idUsuario;
            NotaPed.lVigente = true;

            NotaPed.cAgencia = frmBscNotaPed.objNotaPedido.cAgencia;
            NotaPed.cArea = frmBscNotaPed.objNotaPedido.cArea;
            NotaPed.idMoneda = frmBscNotaPed.objNotaPedido.idMoneda;
            NotaPed.cUsuReg = frmBscNotaPed.objNotaPedido.cUsuarioGen;
            NotaPed.idTipoPed = frmBscNotaPed.objNotaPedido.idTipoPedido;
            listNotPed.Add(NotaPed);

            if (frmBscNotaPed.objNotaPedido.nIGV > 0)
            {
                chbIGV.Checked = true;
                lIgv = true;
            }
            else
            {
                chbIGV.Checked = false;
                lIgv = false;
            }

            idTipPedNota = NotaPed.idTipoPed;

            CargarDetalleNotas();

            //cargar detalle de Adjudicaccion

            List<clsDetalleNotaPedido> lisDetNota = new List<clsDetalleNotaPedido>();
            lisDetNota = new clsCNNotaPedido().buscarDetalleNotaPedidoGen(NotaPed.idNotaPedido, lIgv);
            int nItems = lisDetProAdj.Count;

            foreach (var item in lisDetNota)
            {
                lisDetProAdj.Add(new clsDetalleProcesoAdj()
                {
                    idProceso = idProceso,
                    idDetalleNotapedido = Convert.ToInt32(item.idDetalleNotaPedido),
                    idNotPedido = item.idNotaPedido,
                    nItem = nItems + item.nItem,
                    idCatalogo = item.idCatalogo,
                    cProducto = item.cProducto,
                    idUnidad = item.idUnidad,
                    cUnidad = item.cUnidad,
                    nCantidad = item.nCantidad,
                    nPrecioUnit = item.nPrecioUnit,
                    nsubTotal = item.nSubTotal

                });
            }

            SumaValRefrencial();
            //Retornando el tipo del proceso al que pertenece
            DataTable dtTipoProceso = new clsCNTipoProcAdj().RetornaTipoProcesobyNP(NotaPed.idTipoPed, Convert.ToDecimal(txtValRef.Text.Trim()));
            if (dtTipoProceso.Rows.Count == 0)
            {
                MessageBox.Show("Tipo de proceso no encontrado", "Registro de Adquisiciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.cboTipoProcesoLog.SelectedValue = Convert.ToInt32(dtTipoProceso.Rows[0]["idTipoProceso"].ToString());
            this.cboTipoEvalAdjudicacion.SelectedValue = Convert.ToInt32(dtTipoProceso.Rows[0]["idTipoEvaluacion"].ToString());
        }

        private void btnGrupo_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoEvalAdjudicacion.SelectedValue) <= 0)
            {
                MessageBox.Show("Seleccione Tipo de Grupo", "Valida Tipo de Grupo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmRegistroGrupos frmGrupo = new frmRegistroGrupos();
            frmGrupo.nOpcion = Convert.ToInt16(cboTipoEvalAdjudicacion.SelectedValue);
            frmGrupo.lisDetProAdj = lisDetProAdj;
            frmGrupo.ShowDialog();

            dtgDetalleAdqui.DataSource = null;
            lisDetProAdj = frmGrupo.lisDetProAdj;
            dtgDetalleAdqui.DataSource = lisDetProAdj;
        }

        #endregion

        #region Textbox

        private void txtCodigoPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (string.IsNullOrEmpty(txtCodigoPro.Text.Trim()))
                {
                    MessageBox.Show("Ingrese Nº de Proceso Correcto...", "Buscar Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimpiarListas();
                    return;
                }
                idProceso = Convert.ToInt32(txtCodigoPro.Text);
                buscarProcesoAdjudicaccion(idProceso);
                verificarSiRegistraronPropuesta(idProceso);
                btnCancelar.Enabled = true;
            }
        }

        #endregion

        #region Combobox

        private void cboTipoProcesoLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDescorto(cboTipoProcesoLog.SelectedValue.ToString());
        }

        private void cboTipoEvalAdjudicacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (listNotPed == null)
            {
                MessageBox.Show("Agregue notas de pedido, no puede crear grupos sin no tiene notas de pedido.", "Registro de Procesol de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTipoEvalAdjudicacion.SelectedIndex = -1;
                return;
            }
            int nValNuevo = Convert.ToInt16(cboTipoEvalAdjudicacion.SelectedValue.ToString());
            if (nValTipEval == nValNuevo)
                return;

            nValTipEval = nValNuevo;

            if (nValTipEval == 1) //Todo en un solo Grupo
            {
                foreach (var item in lisDetProAdj)
                {
                    item.idGrupo = 1;
                    item.cDesGrupo = "TODOS";
                }
                btnGrupo.Enabled = false;
            }
            else if (nValTipEval == 2)//por items
            {
                foreach (var item in lisDetProAdj)
                {
                    item.idGrupo = item.nItem;
                    item.cDesGrupo = "ITEM " + item.nItem.ToString();
                }
                btnGrupo.Enabled = false;
            }
            else
            {
                foreach (var item in lisDetProAdj)
                {
                    item.idGrupo = null;
                    item.cDesGrupo = null;
                }
                btnGrupo.Enabled = true;
            }
        }

        #endregion

        #endregion

        #region Metodos

        public frmRegAdquisiciones()
        {
            InitializeComponent();
        }

        private void buscarProcesoAdjudicaccion(int idProceso)
        {
            ProcAdj = buscaProcesoAdj.buscarProcesoAdj(idProceso);

            if (ProcAdj.idProceso != 0)
            {
                this.txtCodigoPro.Enabled = false;
                this.btnCancelar.Enabled = true;
                CargarDatosProcesoAdj();
                cboTipoProcesoLog.SelectedValue = ProcAdj.idTipoProceso;
                listNotPed = ProcAdj.listarVinNotapedido;

                CargarDetalleNotas();
                dtgDetalleAdqui.DataSource = null;
                lisDetProAdj = ProcAdj.listaDetalleProAdj;
                dtgDetalleAdqui.DataSource = lisDetProAdj;
                SumaValRefrencial();
                txtObservacion.Enabled = false;
                this.chbIGV.Checked = ProcAdj.lIgv;

            }
            else
            {
                LimpiarListas();
                MessageBox.Show("No Existe el Proceso de Adquisición Nº " + txtCodigoPro.Text, "Buscar Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoPro.Focus();
                txtCodigoPro.SelectAll();
            }
        }

        private void CargaProcesoAdqui()
        {
            if (cOpcNuevEdit == "N")
            {
                #region ProcesoAdjucicacion
                ProcAdj = new clsProcesoAdjudicacion();

                ProcAdj.idProceso = 0;
                ProcAdj.idTipoProceso = Convert.ToInt32(cboTipoProcesoLog.SelectedValue.ToString());
                ProcAdj.idUsuReg = clsVarGlobal.User.idUsuario;
                ProcAdj.dFechaReg = clsVarGlobal.dFecSystem;
                ProcAdj.idEstado = Convert.ToInt32(cboEstadoProcLog.SelectedValue);
                ProcAdj.idTipoEvaluacion = Convert.ToInt32(cboTipoEvalAdjudicacion.SelectedValue);
                ProcAdj.cObservacion = txtObservacion.Text;
                ProcAdj.cObjetoAdquisicion = txtObjeto.Text;
                ProcAdj.idMoneda = Convert.ToInt32(cboMoneda.SelectedValue);
                ProcAdj.idTipoPedido = Convert.ToInt32(cboTipoPedidoLog.SelectedValue);
                ProcAdj.lIgv = chbIGV.Checked;
                ProcAdj.nMontoTotalIgv = Convert.ToDecimal(txtValRef.Text);
                #endregion
            }

        }

        private void CargarDatosProcesoAdj()
        {
            if (ProcAdj != null)
            {
                if (ProcAdj.cUsuReg != null)
                {
                    dtpFechaSis.Value = (DateTime)ProcAdj.dFechaReg;
                }
                txtUsuario.Text = ProcAdj.cUsuReg;
                txtObjeto.Text = ProcAdj.cObjetoAdquisicion;
                txtObservacion.Text = ProcAdj.cObservacion;
                cboTipoEvalAdjudicacion.SelectedValue = ProcAdj.idTipoEvaluacion;
                cboEstadoProcLog.SelectedValue = ProcAdj.idEstado;
                lConfirmado = (bool)ProcAdj.lConfirmacion;
                if (lConfirmado)
                {
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = false;
                    this.btnCancelar.Enabled = false;
                    this.btnPuntaje.Enabled = true;
                    this.btnCalendario.Enabled = true;
                    this.btnDocumento.Enabled = true;
                    this.btnReqMinimo.Enabled = true;
                    this.btnFactorTecnico.Enabled = true;
                }
                else
                {
                    this.btnGrabar.Enabled = false;
                    this.btnEditar.Enabled = true;
                    this.btnCancelar.Enabled = false;
                    this.btnPuntaje.Enabled = false;
                    this.btnCalendario.Enabled = false;
                    this.btnDocumento.Enabled = false;
                    this.btnReqMinimo.Enabled = false;
                    this.btnFactorTecnico.Enabled = false;
                }
            }
            else
            {
                txtUsuario.Text = clsVarGlobal.User.cWinUser;
                dtpFechaSis.Value = clsVarGlobal.dFecSystem;
                txtObjeto.Clear();
                txtObservacion.Clear();
                cboTipoEvalAdjudicacion.SelectedIndex = -1;
                cboEstadoProcLog.SelectedValue = 6;
                lConfirmado = false;
            }

        }

        private void CargarDescorto(string idTipoProceso)
        {
            foreach (DataRow item in cboTipoProcesoLog.dt.Rows)
            {
                if (item["idTipoProceso"].ToString().Equals(idTipoProceso))
                {
                    txtDesCorto.Text = item["cDescCorta"].ToString();
                }

            }
        }

        public void CargarDetalleNotas()
        {
            if (listNotPed.Count > 0)
            {
                var itemselec = (clsVinculoNotaPedido)listNotPed.First();
                cboMoneda.SelectedValue = itemselec.idMoneda;
                cboTipoPedidoLog.SelectedValue = itemselec.idTipoPed;
                this.txtNroNotaPedido.Text = itemselec.idNotaPedido.ToString();
                this.txtAgenciaNP.Text = itemselec.cAgencia;
                this.txtFechaNP.Text = itemselec.dFechaVinculacion.ToString();
                this.txtAreaNP.Text = itemselec.cArea;
                this.txtUsuarioNP.Text = itemselec.cUsuReg;
            }

        }

        private void SumaValRefrencial()
        {
            txtValRef.Text = lisDetProAdj.Sum(x => x.nsubTotal).ToString();
        }

        private void HablitarBotones(bool lActivo)
        {
            btnGrabar.Enabled = !lActivo;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = lActivo;
            //  btnEditar.Enabled = !lActivo;

        }

        private void LimpiarListas()
        {
            ProcAdj = null;
            NotaPed = null;
            CargarDatosProcesoAdj();

            //    dtgNotasPedido.DataSource = null;
            listNotPed.Clear();
            //      dtgNotasPedido.DataSource = listNotPed;

            dtgDetalleAdqui.DataSource = null;
            lisDetProAdj.Clear();
            dtgDetalleAdqui.DataSource = lisDetProAdj;
            chbIGV.Checked = false;

            lstCalAdj.Clear();
            lstPuntAdj.Clear();
            pLstDocCal.Clear();
            lstFactorTecnico.Clear();
            txtValRef.Text = "0.00";
            this.txtCodigoPro.Clear();
        }

        private void HabilitarControl(bool lactvia)
        {
            //cboEstadoProcLog.Enabled = false;
            //cboTipoPedidoLog.Enabled = false;
            //cboMoneda.Enabled = false;
            grbBase5.Enabled = lactvia;
            this.btnGrupo.Enabled = lactvia;
            this.btnPuntaje.Enabled = lactvia;
            this.btnFactorTecnico.Enabled = !lactvia;
            this.btnDocumento.Enabled = !lactvia;
            this.btnReqMinimo.Enabled = !lactvia;
            this.btnCalendario.Enabled = !lactvia;
            //  cboTipoProcesoLog.Enabled = lactvia;
            //  cboTipoEvalAdjudicacion.Enabled = lactvia;
            txtCodigoPro.Enabled = !lactvia;
            txtObjeto.Enabled = lactvia;
            txtObservacion.Enabled = !lactvia;
            //btnAgregar.Enabled = lactvia;
            //btnQuitar.Enabled = lactvia;
        }

        private bool ValidarGrabacion()
        {
            if (listNotPed == null)
            {
                MessageBox.Show("Realice la búsqueda una Nota de Pedido para el Proceso de Adquisición", "Registro del Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (this.dtgDetalleAdqui.Rows.Count < 1)
            {
                MessageBox.Show("No se Cuenta con un detalle de la Nota de Pedido para el Proceso de Adquisición", "Registro de Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(this.txtCodigoPro.Text.Trim()))
            {

                MessageBox.Show("Ingrese el Puntaje para los grupos del Proceso de Adquisición", "Registro de Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            //if (this.lstCalAdj.Count < 1)
            //{
            //    MessageBox.Show("Ingrese el calendario para el Proceso de Adquisición", "Registro de Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}

            //if (this.pLstDocCal.Count < 1)
            //{
            //    MessageBox.Show("No existen documentos por etapa del Proceso de Adquisición.\nIngrese los documentos para continuar.", "Registro de Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}

            //if (this.lstFactorTecnico.Count < 1)
            //{
            //    MessageBox.Show("No se registraron los factores tecnicos del proceso.", "Registro de Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}

            return true;
        }
        private void verificarSiRegistraronPropuesta(int idProceso)
        {
            DataTable dtRes = buscaProcesoAdj.CNVerificaSiHayVinculadosAlProceso(idProceso);
            if (dtRes.Rows.Count != 0 && !lConfirmado)
            {
                MessageBox.Show("Actualmente ya se ha registrado una propuesta para este proceso. \n NO SE PUEDEN REALIZAR MODIFICACIONES", "Registro de Proceso de Adquisición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lConfirmado = true;
                btnGrabar.Enabled = false;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = false;
                btnPuntaje.Enabled = true;
                btnCalendario.Enabled = true;
                btnDocumento.Enabled = true;
                btnReqMinimo.Enabled = true;
                btnFactorTecnico.Enabled = true;
            }
        }
        #endregion

    }
}
