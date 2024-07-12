#region Referencias
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using GEN.Funciones;
using CRE.CapaNegocio;

#endregion

namespace GEN.ControlesBase
{
    public partial class ConSolicitudSimp : UserControl
    {

        #region Variable Global
        public clsCNSolicitud objCNSolicitud = new clsCNSolicitud();
        private clsCNTasaCredito objCNTasa = new clsCNTasaCredito();
        private clsCNOperacionCre objCNOperacionCre = new clsCNOperacionCre();
        private clsCNTipoPeriodo objCNTipoPerido = new clsCNTipoPeriodo();
        private clsCNSector objCNSector = new clsCNSector();
        private clsCNModalidadCredito objCNModalidadCredito = new clsCNModalidadCredito();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public clsMsjError objErrores { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public clsSolicitudCredSimp objSolicitud = new clsSolicitudCredSimp();
        public clsCliente objCliente { get; set; }
        public int idTipEvalCred { get; set; }
        private List<clsConfigSolicitudCred> lstConfigSolCred { get; set; }
        private DataTable dtCreditosAmp = new DataTable();
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string cIDsTipEvalCred { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string cIDsSectorEcon { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string cNombreFormulario { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<int> lstTipoOperacionPermitido { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<clsProductoCredSimp> lstProductoSimp { get; set; }

        private clsCNPlanPago objCNPlanPago = new clsCNPlanPago();

        public int idProductoDefecto { get; set; }

        public event EventHandler EventoPostIntervinientes;
        public event EventHandler EventoPostTasaNegociable;

        public string cCumpleReglas = "";
        public event EventHandler EventoValidarReglas;
        public decimal nCapitalSolMinimo = 0.00m;

        public DataTable dtCreditoRelacionado
        {
            get
            {
                return (dtCreditosAmp != null) ? dtCreditosAmp : (new clsCNSolicitud()).CNRetCuentasAmpliadas(-1);
            }
        }

        public bool lEditable = false;
        #endregion

        #region Constructor

        public ConSolicitudSimp()
        {
            InitializeComponent();
        }

        #endregion

        #region Metodos
        public void InicializarComponentes()
        {
            lstTipoOperacionPermitido = new List<int>();
            lstTipoOperacionPermitido.Add(1);
            lstProductoSimp = new List<clsProductoCredSimp>();

            lstProductoSimp = objCNSolicitud.CNRecuperarProductoSimpTipEval(cIDsTipEvalCred);
        }

        public void CargarDatosComponentes()
        {
            HabilitarEventos(false);
            objErrores = new clsMsjError();
            objSolicitud = new clsSolicitudCredSimp();
            objCliente = new clsCliente();
            lstConfigSolCred = new List<clsConfigSolicitudCred>();

            #region Cargar Datos Componente
            idTipEvalCred = (!String.IsNullOrEmpty(cIDsTipEvalCred)) ? Convert.ToInt32((cIDsTipEvalCred.Split(','))[0]) : 0;

            DataTable dtOperacion = objCNOperacionCre.ListarOperacionCre();
            this.cboOperacionCre.DataSource = dtOperacion.AsEnumerable().Where(item => lstTipoOperacionPermitido.Contains(Convert.ToInt32(item["idOperacion"]))).CopyToDataTable();
            this.cboOperacionCre.ValueMember = dtOperacion.Columns["idOperacion"].ColumnName;
            this.cboOperacionCre.DisplayMember = dtOperacion.Columns["cOperacion"].ColumnName;

            DataTable dtSector = objCNSolicitud.CNRecuperarSectorEconomico(cIDsSectorEcon);
            this.cboSectorEconomico.DataSource = dtSector;
            this.cboSectorEconomico.ValueMember = dtSector.Columns["idSectorEcon"].ColumnName;
            this.cboSectorEconomico.DisplayMember = dtSector.Columns["cDescripcion"].ColumnName;

            DataTable dtTipoPeriodo = objCNTipoPerido.dtListaTipoPeriodo();
            this.cboTipoPeriodo.DataSource = dtTipoPeriodo.AsEnumerable().Where(item => Convert.ToInt32(item["idTipoPeriodo"]).In(1)).CopyToDataTable();
            this.cboTipoPeriodo.ValueMember = dtTipoPeriodo.Columns["idTipoPeriodo"].ColumnName;
            this.cboTipoPeriodo.DisplayMember = dtTipoPeriodo.Columns["cDescripTipoPeriodo"].ColumnName;

            DataTable dtModalidPago = objCNSolicitud.CNRecuperarModalidadPago();
            this.cboModalidadPago.DataSource = dtModalidPago.AsEnumerable().Where(item => Convert.ToInt32(item["idModalidadPago"]).In(1)).CopyToDataTable();
            this.cboModalidadPago.ValueMember = dtModalidPago.Columns["idModalidadPago"].ColumnName;
            this.cboModalidadPago.DisplayMember = dtModalidPago.Columns["cModalidadPago"].ColumnName;

            DataTable dtTipoCredito = objCNSolicitud.CNRecuperarTipoCredito();
            this.cboTipoCredito.DataSource = dtTipoCredito.AsEnumerable().Where(item => Convert.ToInt32(item["nIdTipoCre"]).In(2,12,13)).CopyToDataTable();
            this.cboTipoCredito.ValueMember = dtTipoCredito.Columns["nIdTipoCre"].ColumnName;
            this.cboTipoCredito.DisplayMember = dtTipoCredito.Columns["cTipoCredito"].ColumnName;

            this.cboMoneda.CargaDatos();
            this.cboDetalleGasto.listarDetalleGastoEnSolicitud();

            DataTable dtZonaCliente = objCNTipoPerido.dtListaTipoPeriodo();
            this.cboTipoPeriodo.DataSource = dtTipoPeriodo.AsEnumerable().Where(item => Convert.ToInt32(item["idTipoPeriodo"]).In(1)).CopyToDataTable();
            this.cboTipoPeriodo.ValueMember = dtTipoPeriodo.Columns["idTipoPeriodo"].ColumnName;
            this.cboTipoPeriodo.DisplayMember = dtTipoPeriodo.Columns["cDescripTipoPeriodo"].ColumnName;

            DataTable dtSectorCliente = objCNSector.CNListaSector();
            this.cboSectorCliente.DataSource = dtSectorCliente;
            this.cboSectorCliente.DisplayMember = dtSectorCliente.Columns["cSector"].ColumnName;
            this.cboSectorCliente.ValueMember = dtSectorCliente.Columns["idSector"].ColumnName;

            DataTable dtModalidaCredito = objCNModalidadCredito.CNListarModalidadCredito();
            this.cboModalidaCredito.DataSource = dtModalidaCredito;
            this.cboModalidaCredito.DisplayMember = dtModalidaCredito.Columns["cModalidadCredito"].ColumnName;
            this.cboModalidaCredito.ValueMember = dtModalidaCredito.Columns["idModalidadCredito"].ColumnName;


            dtpFechaRegistro.Value = clsVarGlobal.dFecSystem;
            dtpPrimeraCuota.Value = clsVarGlobal.dFecSystem;

            cboPersonalCreditos.ListarPersonal(clsVarGlobal.nIdAgencia);
            cboPersonalCreditos.SelectedValue = clsVarGlobal.User.idUsuario;
            cboPromotores.filtrarPorCanal(1);

            HabilitarEventos(true);

            #endregion

        }

        public void AsignarCliente(clsCliente _objCliente)
        {
            this.objCliente = _objCliente;

            DataTable dtSolEstado = objCNSolicitud.SolicitudClienteEstado(objCliente.idCli, 1);

            if (dtSolEstado.Rows.Count > 0)
            {
                int idSolicitud = Convert.ToInt32(dtSolEstado.Rows[0]["idSolicitud"]);
                CargarDatosSolicitud(idSolicitud);

                HabilitarControles(ACCION.RECUPERAR);
            }
            else
            {
                AsignarDatosDefecto();
                HabilitarControles(ACCION.NUEVO);
            }

            RecuperarDatosSolicitud();

            if (objCliente.idCli != 0)
            {
                deshabilitarTipoSeguro();
            }

        }

        public void RecuperarDatosSolicitud()
        {
            this.objSolicitud.idSolicitud               = (String.IsNullOrWhiteSpace(txtCodSolicitud.Text)) ? 0 : Convert.ToInt32(txtCodSolicitud.Text);
            this.objSolicitud.idCli                     = objCliente.idCli;
            this.objSolicitud.idProducto                = txtProducto.idObjeto;
            this.objSolicitud.objProductoCredSimp       = (clsProductoCredSimp)txtProducto.oObjeto;
            this.objSolicitud.idEstado                  = objSolicitud.idEstado;
            this.objSolicitud.idOperacion               = Convert.ToInt32(cboOperacionCre.SelectedValue);
            this.objSolicitud.idMoneda                  = Convert.ToInt32(cboMoneda.SelectedValue);
            this.objSolicitud.idUsuario                 = clsVarGlobal.User.idUsuario;
            this.objSolicitud.nCuotas                   = Convert.ToInt32(nudCuotas.Value);
            this.objSolicitud.nPlazoCuota               = Convert.ToInt32(nudDiaPagoFrecuencia.Value);
            this.objSolicitud.nCapitalSolicitado        = (String.IsNullOrWhiteSpace(txtMontoSolicitud.Text)) ? 0 : Convert.ToDecimal(txtMontoSolicitud.Text);
            this.objSolicitud.dFechaRegistro            = dtpFechaRegistro.Value;
            this.objSolicitud.dFechaDesembolsoSugerido  = dtpFechaDesembolso.Value;
            this.objSolicitud.tObservacion              = String.Empty;
            this.objSolicitud.idDestino                 = Convert.ToInt32(cboDestinoCredito.SelectedValue);
            this.objSolicitud.idTipoPeriodo             = Convert.ToInt32(cboTipoPeriodo.SelectedValue);
            this.objSolicitud.nDiasGracia               = Convert.ToInt32(nudDiasGracia.Value);
            this.objSolicitud.nCuotasGracia             = Convert.ToInt32(nudCuotaGracia.Value);
            this.objSolicitud.idAgencia                 = clsVarGlobal.nIdAgencia;
            this.objSolicitud.idModalidadDes            = 1;
            this.objSolicitud.idActividad               = Convert.ToInt32(conActividadCIIUSimp.cboCIIU.SelectedValue);
            this.objSolicitud.idRecurso                 = 1;
            this.objSolicitud.nMontoAmpliado            = objSolicitud.nMontoAmpliado;
            this.objSolicitud.nSaldoCreditos            = objSolicitud.nSaldoCreditos;
            this.objSolicitud.idModalidadCredito        = Convert.ToInt32(cboModalidaCredito.SelectedValue);
            this.objSolicitud.idActividadInterna        = Convert.ToInt32(conActividadCIIUSimp.cboActividadInterna1.SelectedValue);
            this.objSolicitud.nCuotaAprox               = (String.IsNullOrWhiteSpace(txtCuotaAprox.Text)) ? 0 : Convert.ToDecimal(txtCuotaAprox.Text);
            this.objSolicitud.dFechaPrimeraCuota        = dtpPrimeraCuota.Value;
            this.objSolicitud.idSectorEconomico         = Convert.ToInt32(cboSectorEconomico.SelectedValue);
            this.objSolicitud.idDetalleGasto            = Convert.ToInt32(cboDetalleGasto.SelectedValue);
            this.objSolicitud.nMontoSaldoRCC            = (String.IsNullOrWhiteSpace(txtSaldoRCC.Text)) ? 0 : Convert.ToDecimal(txtSaldoRCC.Text);
            this.objSolicitud.idZona                    = Convert.ToInt32(cboSectorCliente.SelectedValue);
            this.objSolicitud.idModalidadPago           = Convert.ToInt32(cboModalidadPago.SelectedValue);
            this.objSolicitud.idPromotor                = Convert.ToInt32(cboPromotores.SelectedValue);

            if(ValidarCondicionTasa())
            {
                this.objSolicitud.idTasa                = txtTasa.idObjeto;
                this.objSolicitud.objTasaCredSimp       = (clsTasaCredSimp)txtTasa.oObjeto;
                this.objSolicitud.nTasaCompensatoria    = objSolicitud.objTasaCredSimp.nTasaSeleccionada;
                this.objSolicitud.nTasaMoratoria        = objSolicitud.objTasaCredSimp.nTasaMoratoria;
                this.objSolicitud.lConTasaNegociable    = objSolicitud.objTasaCredSimp.lNegociable;


            }
            else
            {
                this.objSolicitud.idTasa                = 0;
                this.objSolicitud.objTasaCredSimp       = new clsTasaCredSimp();
                this.objSolicitud.nTasaCompensatoria    = 0;
                this.objSolicitud.nTasaMoratoria        = 0;
                this.objSolicitud.lConTasaNegociable    = false;
                this.txtTasa.TextChanged                -= new System.EventHandler(this.txtTasa_TextChanged);
                AsignarDatosTasa(0);
                this.txtTasa.TextChanged                += new System.EventHandler(this.txtTasa_TextChanged); 
            }
        }

        public bool ValidarCondicionTasa()
        {
            bool lValida = true;

            DataTable dtPlanPagoSimulado = objCNSolicitud.CNObtienePlanPagoSimulado(objSolicitud.dFechaDesembolsoSugerido, objSolicitud.nCuotas, objSolicitud.nDiasGracia, Convert.ToInt16(objSolicitud.idTipoPeriodo), objSolicitud.nPlazoCuota, objSolicitud.dFechaPrimeraCuota, objSolicitud.nCuotasGracia);
            int nTotalDias = dtPlanPagoSimulado.AsEnumerable().Sum(item => item.Field<int>("dias"));

            if (objSolicitud.nCapitalSolicitado < objSolicitud.objTasaCredSimp.nMontoMin || objSolicitud.nCapitalSolicitado > objSolicitud.objTasaCredSimp.nMontoMax)
                return false;
            if (objSolicitud.idProducto != objSolicitud.objTasaCredSimp.idProducto)
                return false;
            if (objSolicitud.idMoneda != objSolicitud.objTasaCredSimp.idMoneda)
                return false;
            if (nTotalDias < objSolicitud.objTasaCredSimp.nPlazoMin || nTotalDias > objSolicitud.objTasaCredSimp.nPlazoMax )
                return false;

            return lValida;
        }
        public void EditarSolicitud()
        {
            HabilitarControles(ACCION.EDITAR);
        }

        public clsMsjError GrabarSolicitud()
        {
            DataTable dtSolicitud = objCNSolicitud.ConsultaSolicitud(objSolicitud.idSolicitud);
            RecuperarDatosSolicitud();

            objErrores.clearList();
            objErrores = ValidarDatosSolicitud();

            if(objErrores.HasErrors)
            {
                MessageBox.Show(objErrores.GetErrors(), "Registro de Solicitud de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return objErrores;
            }

            foreach (DataColumn column in dtSolicitud.Columns)
            {
                column.ReadOnly = false;
                column.AllowDBNull = true;
            }

            //DataTable dtProducto = objCNSolicitud.CNRecuperarProductoTipEval(cIDsTipEvalCred);
            //List<clsProductoTipEval> listProdTipEval = DataTableToList.ConvertTo<clsProductoTipEval>(dtProducto) as List<clsProductoTipEval>;
            //objSolicitud.idProducto = listProdTipEval[0].idProducto;

            int idEstadoTemporal = 0;

            if(objSolicitud.idSolicitud == 0)
            {
                dtSolicitud.Rows.Clear();
                DataRow dr = dtSolicitud.NewRow();

                dr["nCapitalSolicitado"] = objSolicitud.nCapitalSolicitado;
                dr["IdMoneda"] = objSolicitud.idMoneda;
                dr["idOperacion"] = objSolicitud.idOperacion;
                dr["nCuotas"] = objSolicitud.nCuotas;
                dr["nPlazoCuota"] = objSolicitud.nPlazoCuota;
                dr["dFechaDesembolsoSugerido"] = objSolicitud.dFechaDesembolsoSugerido;
                dr["idEstado"] = idEstadoTemporal;
                dr["idUsuario"] = clsVarGlobal.User.idUsuario;
                dr["idProducto"] = objSolicitud.idProducto;
                dr["nTasaCompensatoria"] = objSolicitud.nTasaCompensatoria;
                dr["nTasaMoratoria"] = objSolicitud.nTasaMoratoria;
                dr["dFechaRegistro"] = objSolicitud.dFechaRegistro;
                dr["idCli"] = objSolicitud.idCli;
                dr["tObservacion"] = objSolicitud.tObservacion;
                dr["idDestino"] = objSolicitud.idDestino;
                dr["idTipoCli"] = objCliente.idTipoCliente;
                dr["idTasa"] = objSolicitud.idTasa;
                dr["idActividad"] = objSolicitud.idActividad;
                dr["ndiasgracia"] = objSolicitud.nDiasGracia;
                dr["idModalidadDes"] = objSolicitud.idModalidadDes;
                dr["idTipoPeriodo"] = objSolicitud.idTipoPeriodo;
                dr["idRecurso"] = objSolicitud.idRecurso;
                dr["idCuenta"] = 0;
                dr["idSoliCambio"] = 0;
                dr["nMontoAmpliado"] = objSolicitud.nMontoAmpliado;
                dr["nSaldoCreditos"] = objSolicitud.nSaldoCreditos;
                dr["idModalidadCredito"] = objSolicitud.idModalidadCredito;
                dr["idPromotor"] = objSolicitud.idPromotor;
                dr["cComentAproba"] = String.Empty;
                dr["idActividadInterna"] = objSolicitud.idActividadInterna;
                dr["nEvaluacion"] = 0;
                dr["cTipoEvaluacion"] = "";
                dr["idPreSolicitud"] = 0;
                dr["idAdeudado"] = 0;
                dr["nCuotasGracia"] = objSolicitud.nCuotasGracia;
                dr["idCreditosPreAprobados"] = 0;
                dr["idVisita"] = 0;
                dr["idEOBDesembolso"] = 0;
                dr["idTipoLocalActividad"] = 0;
                dr["idPerfil"] = clsVarGlobal.PerfilUsu.idPerfil;
                dr["idDetalleGasto"] = objSolicitud.idDetalleGasto;
                dr["dFechaPrimeraCuota"] = objSolicitud.dFechaPrimeraCuota;
                dr["idSectorEconomico"] = objSolicitud.idSectorEconomico;
                dr["idModalidadPago"] = objSolicitud.idModalidadPago;
                dtSolicitud.Rows.Add(dr);
            }
            else
            {
                dtSolicitud.Rows[0]["nCapitalSolicitado"] = objSolicitud.nCapitalSolicitado;
                dtSolicitud.Rows[0]["IdMoneda"] = objSolicitud.idMoneda;
                dtSolicitud.Rows[0]["idOperacion"] = objSolicitud.idOperacion;
                dtSolicitud.Rows[0]["nCuotas"] = objSolicitud.nCuotas;
                dtSolicitud.Rows[0]["nPlazoCuota"] = objSolicitud.nPlazoCuota;
                dtSolicitud.Rows[0]["dFechaDesembolsoSugerido"] = objSolicitud.dFechaDesembolsoSugerido;
                dtSolicitud.Rows[0]["idEstado"] = idEstadoTemporal;
                dtSolicitud.Rows[0]["idUsuario"] = clsVarGlobal.User.idUsuario;
                dtSolicitud.Rows[0]["idProducto"] = objSolicitud.idProducto;
                dtSolicitud.Rows[0]["nTasaCompensatoria"] = objSolicitud.nTasaCompensatoria;
                dtSolicitud.Rows[0]["nTasaMoratoria"] = objSolicitud.nTasaMoratoria;
                dtSolicitud.Rows[0]["dFechaRegistro"] = objSolicitud.dFechaRegistro;
                dtSolicitud.Rows[0]["idCli"] = objSolicitud.idCli;
                dtSolicitud.Rows[0]["tObservacion"] = objSolicitud.tObservacion;
                dtSolicitud.Rows[0]["idDestino"] = objSolicitud.idDestino;
                dtSolicitud.Rows[0]["idTipoCli"] = objCliente.idTipoCliente;
                dtSolicitud.Rows[0]["idTasa"] = objSolicitud.idTasa;
                dtSolicitud.Rows[0]["idActividad"] = objSolicitud.idActividad;
                dtSolicitud.Rows[0]["ndiasgracia"] = objSolicitud.nDiasGracia;
                dtSolicitud.Rows[0]["idModalidadDes"] = objSolicitud.idModalidadDes;
                dtSolicitud.Rows[0]["idTipoPeriodo"] = objSolicitud.idTipoPeriodo;
                dtSolicitud.Rows[0]["idRecurso"] = objSolicitud.idRecurso;
                dtSolicitud.Rows[0]["idCuenta"] = 0;
                dtSolicitud.Rows[0]["idSoliCambio"] = 0;
                dtSolicitud.Rows[0]["nMontoAmpliado"] = objSolicitud.nMontoAmpliado;
                dtSolicitud.Rows[0]["nSaldoCreditos"] = objSolicitud.nSaldoCreditos;
                dtSolicitud.Rows[0]["idModalidadCredito"] = objSolicitud.idModalidadCredito;
                dtSolicitud.Rows[0]["idPromotor"] = objSolicitud.idPromotor;
                dtSolicitud.Rows[0]["cComentAproba"] = String.Empty;
                dtSolicitud.Rows[0]["idActividadInterna"] = objSolicitud.idActividadInterna;
                dtSolicitud.Rows[0]["nEvaluacion"] = 0;
                dtSolicitud.Rows[0]["cTipoEvaluacion"] = "";
                dtSolicitud.Rows[0]["idPreSolicitud"] = 0;
                dtSolicitud.Rows[0]["idAdeudado"] = 0;
                dtSolicitud.Rows[0]["nCuotasGracia"] = objSolicitud.nCuotasGracia;
                dtSolicitud.Rows[0]["idCreditosPreAprobados"] = 0;
                dtSolicitud.Rows[0]["idVisita"] = 0;
                dtSolicitud.Rows[0]["idEOBDesembolso"] = 0;
                dtSolicitud.Rows[0]["idTipoLocalActividad"] = 0;
                dtSolicitud.Rows[0]["idPerfil"] = clsVarGlobal.PerfilUsu.idPerfil;
                dtSolicitud.Rows[0]["idDetalleGasto"] = objSolicitud.idDetalleGasto;
                dtSolicitud.Rows[0]["dFechaPrimeraCuota"] = objSolicitud.dFechaPrimeraCuota;
                dtSolicitud.Rows[0]["idSectorEconomico"] = objSolicitud.idSectorEconomico;
                dtSolicitud.Rows[0]["idModalidadPago"] = objSolicitud.idModalidadPago;
            }

            DataSet ds = new DataSet("dssolici");
            ds.Tables.Add(dtSolicitud);
            string XmlSoli = ds.GetXml();
            XmlSoli = clsCNFormatoXML.EncodingXML(XmlSoli);
            ds.Tables.Clear();

            string XmlCreAmp;
            XmlCreAmp = XmlCreditosAmpliados();

            clsCreditoProp objCreditoProp = retornaCreditoProp();
            string xmlCreditoProp = objCreditoProp.GetXml();

            bool lNuevaSolicitud = (objSolicitud.idSolicitud == 0) ? true : false;
            DataTable dtResultado = objCNSolicitud.InsertaActualizaSolicitud(XmlSoli, xmlCreditoProp, clsVarGlobal.nIdAgencia, 0, 0, XmlCreAmp, false, clsVarGlobal.dFecSystem, clsVarGlobal.User.idUsuario, 0, Convert.ToInt32(cboCanalVendedor.SelectedValue));
            this.objSolicitud.idSolicitud = Convert.ToInt32(dtResultado.Rows[0]["idCodSol"]);
            this.txtCodSolicitud.Text = Convert.ToString(this.objSolicitud.idSolicitud);

            if(dtResultado.Rows.Count > 0)
            {
                if(Convert.ToInt32(dtResultado.Rows[0]["idCodSol"]) == 0)
                {
                    objErrores.AddError(Convert.ToString(dtResultado.Rows[0]["cMensaje"]));
                }
            }
            else
            {
                objErrores.AddError("Ocurrió un problema al Registra la solicitud de Crédito.");
                return objErrores;
            }

            if (EventoValidarReglas != null)
            {
                EventoValidarReglas(null, null);
            }
            else
            {
                cCumpleReglas = "Cumple";
            }


            if (cCumpleReglas.Equals("Cumple") || cCumpleReglas.Equals("NoCumpleSoloExcp"))
            {
                objCNSolicitud.CNActualizaEstadoSolCre(objSolicitud.idSolicitud, 1);
                objSolicitud.idEstado = 1;
            }
            else
            {
                objSolicitud.idEstado = 0;
            }

            if(lNuevaSolicitud)
            {
                MessageBox.Show(String.Format("Solicitud N° {0} registrada correctamente.", objSolicitud.idSolicitud), "Registro de Solicitud de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show(String.Format("Solicitud N° {0} actualizada correctamente.", objSolicitud.idSolicitud), "Registro de Solicitud de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return new clsMsjError();

        }

        private string XmlCreditosAmpliados()
        {
            DataSet dsCreAmp = new DataSet("dsCreAmp");

            if (dtCreditosAmp == null)
            {
                DataTable newDtCreAmp = new DataTable("Table1");
                dsCreAmp.Tables.Add(newDtCreAmp);
            }
            else
            {
                dsCreAmp.Tables.Add(dtCreditosAmp);
            }
            string XmlCreAmp = dsCreAmp.GetXml();
            XmlCreAmp = clsCNFormatoXML.EncodingXML(XmlCreAmp);
            dsCreAmp.Tables.Clear();
            return XmlCreAmp;
        }

        public void EnviarSolicitud()
        {
            DataTable dtSolicitudEval = objCNSolicitud.ConsultaSolicitud(0);

            foreach (DataColumn column in dtSolicitudEval.Columns)
            {
                column.ReadOnly = false;
                column.AllowDBNull = true;
            }

            RecuperarDatosSolicitud();

            dtSolicitudEval.Rows.Clear();
            DataRow dr = dtSolicitudEval.NewRow();

            dr["idSolicitud"] = objSolicitud.idSolicitud;
            dr["nCapitalSolicitado"] = objSolicitud.nCapitalSolicitado;
            dr["IdMoneda"] = objSolicitud.idMoneda;
            dr["idOperacion"] = objSolicitud.idOperacion;
            dr["nCuotas"] = objSolicitud.nCuotas;
            dr["nPlazoCuota"] = objSolicitud.nPlazoCuota;
            dr["dFechaDesembolsoSugerido"] = objSolicitud.dFechaDesembolsoSugerido;
            dr["idEstado"] = 13;
            dr["idUsuario"] = clsVarGlobal.User.idUsuario;
            dr["idProducto"] = objSolicitud.idProducto;
            dr["nTasaCompensatoria"] = objSolicitud.nTasaCompensatoria;
            dr["nTasaMoratoria"] = objSolicitud.nTasaMoratoria;
            dr["dFechaRegistro"] = objSolicitud.dFechaRegistro;
            dr["idCli"] = objSolicitud.idCli;
            dr["tObservacion"] = objSolicitud.tObservacion;
            dr["idDestino"] = objSolicitud.idDestino;
            dr["idTipoCli"] = objSolicitud.idTipoCli;
            dr["idTasa"] = objSolicitud.idTasa;
            dr["idActividad"] = objSolicitud.idActividad;
            dr["ndiasgracia"] = objSolicitud.nDiasGracia;
            dr["idModalidadDes"] = objSolicitud.idModalidadDes;
            dr["idTipoPeriodo"] = objSolicitud.idTipoPeriodo;
            dr["idRecurso"] = objSolicitud.idRecurso;
            dr["idCuenta"] = 0;
            dr["idSoliCambio"] = 0;
            dr["nMontoAmpliado"] = objSolicitud.nMontoAmpliado;
            dr["nSaldoCreditos"] = objSolicitud.nSaldoCreditos;
            dr["idModalidadCredito"] = objSolicitud.idModalidadCredito;
            dr["idPromotor"] = objSolicitud.idPromotor;
            dr["cComentAproba"] = String.Empty;
            dr["idActividadInterna"] = objSolicitud.idActividadInterna;
            dr["nEvaluacion"] = 0;
            dr["cTipoEvaluacion"] = "";
            dr["idPreSolicitud"] = 0;
            dr["idAdeudado"] = 0;
            dr["nCuotasGracia"] = objSolicitud.nCuotasGracia;
            dr["idCreditosPreAprobados"] = 0;
            dr["idVisita"] = 0;
            dr["idEOBDesembolso"] = 0;
            dr["idTipoLocalActividad"] = 0;
            dr["idPerfil"] = clsVarGlobal.PerfilUsu.idPerfil;
            dr["idDetalleGasto"] = objSolicitud.idDetalleGasto;
            dr["dFechaPrimeraCuota"] = objSolicitud.dFechaPrimeraCuota;
            dr["idModalidadPago"] = objSolicitud.idModalidadPago;
            dtSolicitudEval.Rows.Add(dr);


            DataSet ds = new DataSet("dssolici");
            ds.Tables.Add(dtSolicitudEval);
            string XmlSoli = ds.GetXml();
            XmlSoli = clsCNFormatoXML.EncodingXML(XmlSoli);
            ds.Tables.Clear();

            clsCreditoProp objCreditoProp = retornaCreditoProp();
            string xmlCreditoProp = String.Empty;
            if (objCreditoProp != null)
            {
                xmlCreditoProp = objCreditoProp.GetXml();
            }
            else
            {
                xmlCreditoProp = new clsCreditoProp().GetXml();
            }

            clsDBResp objDbResp = new clsCNSolicitud().CNEnviaAEvaluacion(XmlSoli, xmlCreditoProp, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem.Date);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, "Registro de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objSolicitud.idEstado = 13;
                HabilitarControles(ACCION.RECUPERAR);
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, "Registro de Solicitud", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HabilitarControles(ACCION.EDITAR);
            }

        }

        private clsCreditoProp retornaCreditoProp()
        {
            return new clsCreditoProp()
            {
                idOrigenCredProp = 1,
                idSolicitud = 0,
                idSolAproba = 0,
                idNivelAprRanOpe = 0,
                nMonto = objSolicitud.nCapitalSolicitado,
                idMoneda = objSolicitud.idMoneda,
                nCuotas = objSolicitud.nCuotas,
                idTipoPeriodo = objSolicitud.idTipoPeriodo,
                nPlazoCuota = objSolicitud.nPlazoCuota,
                nDiasGracia = objSolicitud.nDiasGracia,
                idTasa = objSolicitud.idTasa,
                dFechaDesembolso = objSolicitud.dFechaDesembolsoSugerido,
                nTasaCompensatoria = objSolicitud.nTasaCompensatoria,
                nActivo = 0m,
                nPasivo = 0m,
                nInventario = 0m,
                nPatrimonio = 0m,
                nCostos = 0m,
                nDeudas = 0m,
                nNeto = 0m,
                nDisponible = 0m,
                nCuotaAprox = 0m,
                cComentarios = objSolicitud.tObservacion,
                nCuotasGracia = objSolicitud.nCuotasGracia
            };
        }

        public clsMsjError Validar()
        {
            objErrores = new clsMsjError();
            return objErrores;
        }

        public void Limpiar()
        {
            objErrores = new clsMsjError();
            objSolicitud = new clsSolicitudCredSimp();

            AsignarDatosDefecto();
        }

        public void CargarDatosSolicitud(int idSolicitud)
        {
            clsCNTasaCredito objCNTasa = new clsCNTasaCredito();
            clsCNProducto objCNProducto = new clsCNProducto();

            List<clsSolicitudCredSimp> lstSolCredSimp = new List<clsSolicitudCredSimp>();
            DataTable dtSolCred = objCNSolicitud.ConsultaSolicitud(idSolicitud);

            lstSolCredSimp = (dtSolCred.Rows.Count > 0) ? dtSolCred.ToList<clsSolicitudCredSimp>() as List<clsSolicitudCredSimp> : new List<clsSolicitudCredSimp>();

            HabilitarEventos(false);

            if (lstSolCredSimp.Count > 0)
            {
                objSolicitud = lstSolCredSimp[0];
                clsTasaCredSimp objTasaSimp = objCNTasa.CNRecuperarTasaSolicutdSimp(objSolicitud.idTasa, objSolicitud.nTasaCompensatoria);
                clsProductoCredSimp objProductoSimp = new clsProductoCredSimp();
                objSolicitud.objTasaCredSimp = objTasaSimp;
                objSolicitud.objProductoCredSimp = objProductoSimp;
                AsignarDatosSolicitud();
            }
            else
            {
                Limpiar();
                AsignarDatosDefecto();
            }

            if(lstProductoSimp.Any(item => item.idSubProducto == objSolicitud.idProducto))
            {
                reclasificarCredito();
            }


            HabilitarEventos(true);
        }

        public void AsignarDatosDefecto()
        {
            if(objCliente.idCli != 0)
            {
                cboOperacionCre.SelectedValue = Convert.ToInt32(1);
                dtpFechaRegistro.Value = clsVarGlobal.dFecSystem;
                decimal nSaldoRCC = 0;
                decimal nCuotaAprox = 0;

                AsignarDatosProducto(idProductoDefecto);

                conActividadCIIUSimp.cargarActividadInterna(objCliente.idActivEcoInt);

                cboTipoPeriodo.SelectedValue = 1;
                cboMoneda.SelectedValue = 1;
                cboModalidadPago.SelectedValue = 1;

                nudDiaPagoFrecuencia.Value = clsVarGlobal.dFecSystem.Day;
                nudDiasGracia.Value = 0;
                nudCuotaGracia.Value = 0;

                txtCuotaAprox.Text = Convert.ToString(nCuotaAprox);
                dtpFechaDesembolso.Value = clsVarGlobal.dFecSystem;
                dtpPrimeraCuota.Value = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, Convert.ToInt32(nudDiaPagoFrecuencia.Value)).AddMonths(1);
                txtSaldoRCC.Text = Convert.ToString(nSaldoRCC);

                DataTable dtSectorCli = objCNSolicitud.CNRecuperarSectorCliente(objCliente.idCli);
                int idSectorCli = (dtSectorCli.Rows.Count > 0) ? Convert.ToInt32(dtSectorCli.Rows[0]["idSector"]) : 0;

                cboSectorCliente.SelectedValue = idSectorCli;

                DataTable dtDatosCredito = objCNSolicitud.CNRecuperarDatosCreditoCliente(objCliente.idCli);
                int nCredPrincipal = 0;
                int nCredParalelo = 0;

                nCredPrincipal = (dtDatosCredito.Rows.Count > 0) ? (dtDatosCredito.AsEnumerable().Where(item => Convert.ToInt32(item.Field<int>("idModalidadCredito")) == 1).Count()) : 0;
                nCredParalelo = (dtDatosCredito.Rows.Count > 0) ? (dtDatosCredito.AsEnumerable().Where(item => Convert.ToInt32(item.Field<int>("idModalidadCredito")) == 2).Count()) : 0;
                if (dtDatosCredito.Rows.Count == 0)
                {
                    cboModalidaCredito.SelectedValue = 1;
                }
                else if (nCredPrincipal == 0)
                {
                    cboModalidaCredito.SelectedValue = 1;
                }
                else
                {
                    cboModalidaCredito.SelectedValue = 2;
                }

                CargarDatosRCC();
            }
        }

        public void AsignarDatosProducto(int idProducto)
        {
            cargaDestinoXOperacion();

            if (!lstProductoSimp.Any(item => item.idSubProducto == idProducto))
            {
                txtProducto.CargarDatosObjecto(idProducto, String.Empty, new clsProductoCredSimp());
            }
            else
            {
                clsProductoCredSimp objProducto = lstProductoSimp.FirstOrDefault(item => item.idSubProducto == idProducto);

                txtProducto.CargarDatosObjecto(objProducto.idSubProducto, objProducto.cNombreProductoCompuesto, objProducto);
                objSolicitud.idProducto = objSolicitud.idProducto;
                objSolicitud.objProductoCredSimp = objProducto;

                cboTipoCredito.SelectedValue = objSolicitud.objProductoCredSimp.idTipoProducto;
            }
        }

        public void AsignarDatosTasa(int idTasa)
        {
            if (idTasa == 0)
            {
                txtTasa.CargarDatosObjecto(0, String.Empty, new clsTasaCredSimp());
            }
            else
            {
                txtTasa.CargarDatosObjecto(objSolicitud.idTasa, objSolicitud.objTasaCredSimp.cNombreCompuesto, objSolicitud.objTasaCredSimp);
            }

            objSolicitud.idTasa = objSolicitud.objTasaCredSimp.idTasa;
            objSolicitud.nTasaMoratoria = objSolicitud.objTasaCredSimp.nTasaMoratoria;
            objSolicitud.nTasaCompensatoria = objSolicitud.objTasaCredSimp.nTasaSeleccionada;
            objSolicitud.lConTasaNegociable = objSolicitud.objTasaCredSimp.lNegociable;
        }


        public void AsignarDatosSolicitud()
        {

            txtCodSolicitud.Text                = Convert.ToString(objSolicitud.idSolicitud);
            cboOperacionCre.SelectedValue       = Convert.ToInt32(objSolicitud.idOperacion);
            dtpFechaRegistro.Value              = objSolicitud.dFechaRegistro;
            dtpFechaDesembolso.Value            = objSolicitud.dFechaDesembolsoSugerido;

            AsignarDatosProducto(objSolicitud.idProducto);

            cboSectorEconomico.SelectedValue    = objSolicitud.idSectorEconomico;
            conActividadCIIUSimp.cargarActividadInterna(objSolicitud.idActividadInterna);

            cboTipoPeriodo.SelectedValue        = objSolicitud.idTipoPeriodo;
            cboMoneda.SelectedValue             = objSolicitud.idMoneda;
            txtMontoSolicitud.Text              = Convert.ToString(objSolicitud.nCapitalSolicitado);
            cboModalidadPago.SelectedValue      = objSolicitud.idModalidadPago;

            this.txtTasa.TextChanged -= new System.EventHandler(this.txtTasa_TextChanged);
            AsignarDatosTasa(objSolicitud.idTasa);
            this.txtTasa.TextChanged += new System.EventHandler(this.txtTasa_TextChanged);

            nudCuotas.Value                 = objSolicitud.nCuotas;
            nudDiasGracia.Value             = objSolicitud.nDiasGracia;
            nudDiaPagoFrecuencia.Value      = objSolicitud.nPlazoCuota;
            nudCuotaGracia.Value            = objSolicitud.nCuotasGracia;
            txtCuotaAprox.Text              = Convert.ToString(objSolicitud.nCuotaAprox);
            dtpPrimeraCuota.Value           = objSolicitud.dFechaPrimeraCuota;
            txtSaldoRCC.Text                = "0";

            DataTable dtSectorCli = objCNSolicitud.CNRecuperarSectorCliente(objCliente.idCli);
            int idSectorCli = (dtSectorCli.Rows.Count > 0) ? Convert.ToInt32(dtSectorCli.Rows[0]["idSector"]) : 0;

            cboSectorCliente.SelectedValue = idSectorCli;
            cboModalidadPago.SelectedValue = objSolicitud.idModalidadPago;
            cboDetalleGasto.SelectedValue = objSolicitud.idDetalleGasto;

            cargaDestinoXOperacion();
            cboDestinoCredito.SelectedValue     = Convert.ToInt32(objSolicitud.idDestino);
            cboPersonalCreditos.SelectedValue   = Convert.ToInt32(objSolicitud.idUsuario);
            cboCanalVendedor.SelectedValue      = Convert.ToInt32(objSolicitud.idCanalVendedor);
            cboPromotores.SelectedValue         = Convert.ToInt32(objSolicitud.idPromotor);
            dtCreditosAmp                       = objCNSolicitud.CNRetCuentasAmpliadas(objSolicitud.idSolicitud);
            txtSaldoAmpliacion.Text             = objSolicitud.idOperacion == 4 ? dtCreditosAmp.Compute("Sum(nTotal)", "").ToString() : "";
            txtMontoAmpliacion.Text             = objSolicitud.idOperacion == 4 ? (decimal.Parse(txtMontoSolicitud.Text) - decimal.Parse(txtSaldoAmpliacion.Text)).ToString() : "";

            CalcularCuotaAproximada();
            CargarDatosRCC();

            if (!objSolicitud.idEstado.In(0,1))
            {
                HabilitarControles(ACCION.RECUPERAR);
            }

            cboModalidaCredito.SelectedValue = objSolicitud.idModalidadCredito;
        }

        private void cargaDestinoXOperacion()
        {
            int idProducto = objSolicitud.idProducto;

            if (Convert.ToInt32(cboOperacionCre.SelectedValue) == 2 || Convert.ToInt32(cboOperacionCre.SelectedValue) == 3 || Convert.ToInt32(cboOperacionCre.SelectedValue) == 6)
            {
                cboDestinoCredito.cargarEspeciales();
            }
            else if (idProducto > 0)
            {

                cboDestinoCredito.cargarEspecificos(idProducto);
            }
            else
            {
                cboDestinoCredito.cargar();
            }
        }

        private void deshabilitarTipoSeguro()
        {
            if (objCliente.IdTipoPersona == 1)
            {
                cboDetalleGasto.Enabled = true;
            }
            else
            {
                cboDetalleGasto.SelectedIndex = -1;
                cboDetalleGasto.Enabled = false;
            }
        }

        private void HabilitarControles(ACCION oAccion)
        {
            switch(oAccion)
            {
                case ACCION.REGISTRAR:
                case ACCION.RECUPERAR:
                case ACCION.DEFAULT:
                    txtCodSolicitud.Enabled         = false;
                    cboOperacionCre.Enabled         = false;
                    dtpFechaRegistro.Enabled        = false;
                    txtProducto.Enabled             = false;
                    cboSectorEconomico.Enabled      = false;
                    conActividadCIIUSimp.Enabled    = false;
                    cboTipoPeriodo.Enabled          = false;
                    cboMoneda.Enabled               = false;
                    txtMontoSolicitud.Enabled       = false;
                    txtTasa.Enabled                 = false;
                    nudCuotas.Enabled               = false;
                    nudDiaPagoFrecuencia.Enabled    = false;
                    nudCuotaGracia.Enabled          = false;
                    nudDiasGracia.Enabled           = false;
                    cboModalidaCredito.Enabled      = false;
                    txtCuotaAprox.Enabled           = false;
                    dtpPrimeraCuota.Enabled         = false;
                    txtSaldoRCC.Enabled             = false;
                    cboSectorCliente.Enabled        = false;
                    cboDestinoCredito.Enabled       = false;
                    cboDetalleGasto.Enabled         = false;
                    txtSaldoAmpliacion.Enabled      = false;
                    cboModalidadPago.Enabled        = false;
                    cboTipoCredito.Enabled          = false;
                    lEditable                       = false;
                    cboPersonalCreditos.Enabled     = false;
                    cboCanalVendedor.Enabled        = false;
                    cboPromotores.Enabled           = false;
                    txtMontoAmpliacion.Enabled      = false;
                    break;
                case ACCION.NUEVO:
                case ACCION.EDITAR:
                    HabilitarControlesBD();
                    txtSaldoAmpliacion.Enabled = objSolicitud.idOperacion == 4 ? true : false;
                    lEditable = true;
                    break;

                default:
                    txtCodSolicitud.Enabled         = false;
                    cboOperacionCre.Enabled         = false;
                    dtpFechaRegistro.Enabled        = false;
                    txtProducto.Enabled             = false;
                    cboSectorEconomico.Enabled      = false;
                    conActividadCIIUSimp.Enabled    = false;
                    cboTipoPeriodo.Enabled          = false;
                    cboMoneda.Enabled               = false;
                    txtMontoSolicitud.Enabled       = false;
                    txtTasa.Enabled                 = false;
                    nudCuotas.Enabled               = false;
                    nudDiaPagoFrecuencia.Enabled    = false;
                    nudCuotaGracia.Enabled          = false;
                    nudDiasGracia.Enabled           = false;
                    cboModalidaCredito.Enabled      = false;
                    txtCuotaAprox.Enabled           = false;
                    dtpPrimeraCuota.Enabled         = false;
                    txtSaldoRCC.Enabled             = false;
                    cboSectorCliente.Enabled        = false;
                    cboDestinoCredito.Enabled       = false;
                    cboDetalleGasto.Enabled         = false;
                    txtSaldoAmpliacion.Enabled      = false;
                    cboModalidadPago.Enabled        = false;
                    cboTipoCredito.Enabled          = false;
                    cboPersonalCreditos.Enabled     = false;
                    cboCanalVendedor.Enabled        = false;
                    cboPromotores.Enabled           = false;
                    txtMontoAmpliacion.Enabled      = false;
                    break;
            }

            btnInterviniente.Enabled = (objSolicitud.idSolicitud != 0) ? true : false ;
            btnTasaNegociada.Enabled = (objSolicitud.idSolicitud != 0) ? true : false;

        }

        public int ObtenerTotalDiasCredito()
        {
            return objCNSolicitud.ObtieneTotalDias(objSolicitud.dFechaDesembolsoSugerido, objSolicitud.nCuotas, objSolicitud.nDiasGracia, objSolicitud.idTipoPeriodo, objSolicitud.nPlazoCuota);
        }

        private void HabilitarControlesBD()
        {
            DataTable dtResultado = objCNSolicitud.CNRecuperarConfigSolicitudCred(idTipEvalCred);
            this.lstConfigSolCred = (dtResultado.Rows.Count > 0) ? dtResultado.ToList<clsConfigSolicitudCred>() as List<clsConfigSolicitudCred> : new List<clsConfigSolicitudCred>() ;

            txtCodSolicitud.Enabled         = false;
            cboOperacionCre.Enabled         = false;
            dtpFechaRegistro.Enabled        = false;
            txtProducto.Enabled             = false;
            cboSectorEconomico.Enabled      = false;
            conActividadCIIUSimp.Enabled    = false;
            cboTipoPeriodo.Enabled          = false;
            cboMoneda.Enabled               = false;
            txtMontoSolicitud.Enabled       = false;
            txtTasa.Enabled                 = false;
            nudCuotas.Enabled               = false;
            nudDiaPagoFrecuencia.Enabled    = false;
            nudDiasGracia.Enabled           = false;
            nudCuotaGracia.Enabled          = false;
            cboDetalleGasto.Enabled         = false;
            txtCuotaAprox.Enabled           = false;
            dtpPrimeraCuota.Enabled         = false;
            txtSaldoRCC.Enabled             = false;
            cboSectorCliente.Enabled        = false;
            cboDestinoCredito.Enabled       = false;
            cboModalidaCredito.Enabled      = false;
            cboModalidadPago.Enabled        = false;
            cboTipoCredito.Enabled          = false;
            cboPersonalCreditos.Enabled     = false;
            cboCanalVendedor.Enabled        = false;
            cboPromotores.Enabled           = false;
            txtMontoAmpliacion.Enabled      = false;

            foreach (Control control in this.grbDatosSolicitud.Controls)
            {
                if(!(control is Label || control is Button))
                {
                    clsConfigSolicitudCred objConfig = lstConfigSolCred.FirstOrDefault(item => item.cNombreComponente == control.Name);
                    bool lHabilitado = lstConfigSolCred.Any(item => item.cNombreComponente == control.Name && item.lEditable);
                    control.Enabled = lHabilitado;
                }
            }
        }

        private DataTable CalendarioCuotaConstante()
        {
            DataTable dtEmpty = new DataTable();
            DataTable dtResultado = new DataTable();

            dtResultado = this.objCNPlanPago.CalculaPpgCuotasConstantes(
                objSolicitud.nCapitalSolicitado,
                objSolicitud.nTasaCompensatoria / 100.00m,
                objSolicitud.dFechaDesembolsoSugerido,
                objSolicitud.nCuotas,
                objSolicitud.nDiasGracia,
                Convert.ToInt16(objSolicitud.idTipoPeriodo),
                objSolicitud.nPlazoCuota,
                0,
                dtEmpty,
                objSolicitud.idMoneda,
                dtEmpty,
                objSolicitud.dFechaPrimeraCuota
            );


            return dtResultado;

        }

        private DataTable CalendarioCuotasPeriodoGracia(DataTable dtCalendarioPagos)
        {
            DataTable dtEmpty = new DataTable();
            DataTable dtResultado = new DataTable();

            dtResultado = objCNPlanPago.CalcularCuotasGracia(
                dtCalendarioPagos,
                objSolicitud.nCapitalSolicitado,
                objSolicitud.nTasaCompensatoria / 100.00m,
                objSolicitud.dFechaDesembolsoSugerido,
                objSolicitud.nDiasGracia,
                Convert.ToInt16(objSolicitud.idTipoPeriodo),
                objSolicitud.nPlazoCuota,
                dtEmpty,
                objSolicitud.idMoneda,
                dtEmpty,
                objSolicitud.dFechaPrimeraCuota,
                objSolicitud.nCuotas,
                objSolicitud.nCuotasGracia
            );

            return dtResultado;

        }

        private void CalcularCuotaAproximada()
        {
            if (objSolicitud.nCuotas != 0 && objSolicitud.idTipoPeriodo != 0 && objSolicitud.nPlazoCuota != 0 && objSolicitud.nCapitalSolicitado != 0 && objSolicitud.nTasaCompensatoria != 0)
            {
                DataTable dtCalendario = CalendarioCuotaConstante();

                if (objSolicitud.nCuotasGracia > 0)
                {
                    dtCalendario = CalendarioCuotasPeriodoGracia(dtCalendario);

                    if (dtCalendario.Rows.Count > 0)
                    {
                        var lstCuotaConst = dtCalendario.AsEnumerable()
                                            .Where(item => item.Field<decimal>("capital") > 0)
                                            .Select(item => {
                                                return new
                                                {
                                                    nCapital = item.Field<decimal>("capital"),
                                                    nInteres = item.Field<decimal>("interes"),
                                                    nCuota = item.Field<decimal>("imp_cuota")
                                                };
                                            }).ToList();

                        var lstCuotaPGracia = dtCalendario.AsEnumerable()
                                            .Where(item => item.Field<decimal>("capital") == 0)
                                            .Select(item => {
                                                return new
                                                {
                                                    nCapital = item.Field<decimal>("capital"),
                                                    nInteres = item.Field<decimal>("interes"),
                                                    nCuota = item.Field<decimal>("imp_cuota")
                                                };
                                            }).ToList();

                        objSolicitud.nCuotaAprox = (lstCuotaConst.Count > 0) ? lstCuotaConst[0].nCuota : 0;
                        objSolicitud.nCuotaGraciaAprox = (lstCuotaPGracia.Count > 0) ? lstCuotaPGracia[0].nCuota : 0;
                    }
                }
                else
                {
                    objSolicitud.nCuotaAprox = (dtCalendario.Rows.Count > 0) ? Convert.ToDecimal(dtCalendario.Rows[0]["imp_cuota"]) : 0;
                    objSolicitud.nCuotaGraciaAprox = 0;
                }

                txtCuotaAprox.Text = objSolicitud.nCuotaAprox.ToString("N2");
            }
        }

        private void agregarCreditos(int idCuentaCre)
        {
            CRE.CapaNegocio.clsCNCredito credito = new CRE.CapaNegocio.clsCNCredito();
            clsCredito entCredito = credito.retornaDatosCredito(idCuentaCre);

            if (dtCreditosAmp.AsEnumerable().Any(x => x.Field<int>("idCuenta") == entCredito.idCuenta))
                return;

            if (entCredito.IdMoneda != Convert.ToInt32(cboMoneda.SelectedValue))
            {
                MessageBox.Show("Debe seleccionar creditos del mismo tipo de moneda", "Validación de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int? idOperacion = (int?)cboOperacionCre.SelectedValue;

            DataRow drCredito = dtCreditosAmp.NewRow();
            drCredito["idSolicitud"] = "0";
            drCredito["idCuenta"] = entCredito.idCuenta;
            drCredito["nTotal"] = (entCredito.nCapitalDesembolso - entCredito.nCapitalPagado) +
                                    (entCredito.nInteresDia - entCredito.nInteresPagado) +
                                    (entCredito.nMoraGenerado - entCredito.nMoraPagada) +
                                    (entCredito.nOtrosGenerado - entCredito.nOtrosPagado) +
                                    (entCredito.nInteresComp - entCredito.nInteresCompPago);
            drCredito["nSalCapital"] = (entCredito.nCapitalDesembolso - entCredito.nCapitalPagado);
            drCredito["nSalInteres"] = (entCredito.nInteresDia - entCredito.nInteresPagado);
            drCredito["nSalMora"] = (entCredito.nMoraGenerado - entCredito.nMoraPagada);
            drCredito["nSalOtros"] = (entCredito.nOtrosGenerado - entCredito.nOtrosPagado);
            drCredito["nSalIntComp"] = (entCredito.nInteresComp - entCredito.nInteresCompPago);
            drCredito["lPermQuitar"] = 1;
            drCredito["nTasaCompensatoria"] = entCredito.nTasaCompensatoria;
            drCredito["nTasaMoratoria"] = entCredito.nTasaMoratoria;
            drCredito["nCapitalDesembolso"] = entCredito.nCapitalDesembolso;

            dtCreditosAmp.Rows.Add(drCredito);

            ActualizarSaldoAmpliacion();

        }

        private void ActualizarSaldoAmpliacion()
        {
            txtSaldoAmpliacion.Text = dtCreditosAmp.Compute("Sum(nTotal)", "").ToString();
            txtMontoSolicitud.Text = txtSaldoAmpliacion.Text;
        }

        public void reclasificarCredito()
        {
            DataTable dtClasifCred = objCNSolicitud.CNClasificarCredito(objCliente.cDocumentoID);
            int idTipoProducto = Convert.ToInt32(dtClasifCred.Rows[0]["idProducto"]);

            if( idTipoProducto == objSolicitud.objProductoCredSimp.idTipoProducto)
            {
                return;
            }

            DataTable dtFamCred = objCNSolicitud.CNBusFamCred(idTipoProducto, objSolicitud.idProducto);
            if(dtFamCred.Rows.Count < 5)
            {
                return;
            }

            var lstProdfiltro = lstProductoSimp.Where(item => item.idTipoProducto == idTipoProducto ).ToList();

            int idProdClasificado = (lstProdfiltro.Count > 0 ) ? lstProdfiltro.Max(item => item.idSubProducto) : 0;

            if (idProdClasificado != 0)
            {
                AsignarDatosProducto(idProdClasificado);
            }
        }

        public void HabilitarEventos(bool lHabilita)
        {
            if(!lHabilita)
            {
                this.cboOperacionCre.SelectedIndexChanged       -= new System.EventHandler(this.cboOperacionCre_SelectedIndexChanged);
                this.dtpFechaRegistro.ValueChanged              -= new System.EventHandler(this.dtpFechaRegistro_ValueChanged);
                this.txtProducto.TextChanged                    -= new System.EventHandler(this.txtProducto_TextChanged); 
                this.txtMontoSolicitud.TextChanged              -= new System.EventHandler(this.txtMontoSolicitud_TextChanged); 
                this.cboMoneda.SelectedIndexChanged             -= new System.EventHandler(this.cboMoneda_SelectedIndexChanged); 
                this.nudCuotas.ValueChanged                     -= new System.EventHandler(this.nudCuotas_ValueChanged); 
                this.cboTipoPeriodo.SelectedIndexChanged        -= new System.EventHandler(this.cboTipoPeriodo_SelectedIndexChanged); 
                this.nudDiaPagoFrecuencia.ValueChanged          -= new System.EventHandler(this.nudDiaPagoFrecuencia_ValueChanged); 
                this.dtpPrimeraCuota.ValueChanged               -= new System.EventHandler(this.dtpPrimeraCuota_ValueChanged); 
                this.nudCuotaGracia.ValueChanged                -= new System.EventHandler(this.nudCuotaGracia_ValueChanged); 
                this.txtTasa.TextChanged                        -= new System.EventHandler(this.txtTasa_TextChanged); 
                this.txtSaldoAmpliacion.TextChanged             -= new System.EventHandler(this.txtSaldoAmpliacion_TextChanged); 
                this.cboDestinoCredito.SelectedIndexChanged     -= new System.EventHandler(this.cboDestinoCredito_SelectedIndexChanged); 
                this.cboDetalleGasto.SelectedIndexChanged       -= new System.EventHandler(this.cboDetalleGasto_SelectedIndexChanged); 
                this.txtCuotaAprox.TextChanged                  -= new System.EventHandler(this.txtCuotaAprox_TextChanged); 
                this.cboSectorEconomico.SelectedIndexChanged    -= new System.EventHandler(this.cboSectorEconomico_SelectedIndexChanged); 
                this.cboSectorCliente.SelectedIndexChanged      -= new System.EventHandler(this.cboSectorCliente_SelectedIndexChanged);
                this.txtSaldoRCC.TextChanged                    -= new System.EventHandler(this.txtSaldoRCC_TextChanged);
                this.cboModalidaCredito.SelectedIndexChanged    -= new System.EventHandler(this.cboModalidaCredito_SelectedIndexChanged);
                this.dtpFechaDesembolso.ValueChanged            -= new System.EventHandler(this.dtpFechaDesembolso_ValueChanged);
            }
            else
            {
                this.cboOperacionCre.SelectedIndexChanged       += new System.EventHandler(this.cboOperacionCre_SelectedIndexChanged);
                this.dtpFechaRegistro.ValueChanged              += new System.EventHandler(this.dtpFechaRegistro_ValueChanged);
                this.txtProducto.TextChanged                    += new System.EventHandler(this.txtProducto_TextChanged); 
                this.txtMontoSolicitud.TextChanged              += new System.EventHandler(this.txtMontoSolicitud_TextChanged); 
                this.cboMoneda.SelectedIndexChanged             += new System.EventHandler(this.cboMoneda_SelectedIndexChanged); 
                this.nudCuotas.ValueChanged                     += new System.EventHandler(this.nudCuotas_ValueChanged); 
                this.cboTipoPeriodo.SelectedIndexChanged        += new System.EventHandler(this.cboTipoPeriodo_SelectedIndexChanged); 
                this.nudDiaPagoFrecuencia.ValueChanged          += new System.EventHandler(this.nudDiaPagoFrecuencia_ValueChanged); 
                this.dtpPrimeraCuota.ValueChanged               += new System.EventHandler(this.dtpPrimeraCuota_ValueChanged); 
                this.nudCuotaGracia.ValueChanged                += new System.EventHandler(this.nudCuotaGracia_ValueChanged); 
                this.txtTasa.TextChanged                        += new System.EventHandler(this.txtTasa_TextChanged); 
                this.txtSaldoAmpliacion.TextChanged             += new System.EventHandler(this.txtSaldoAmpliacion_TextChanged); 
                this.cboDestinoCredito.SelectedIndexChanged     += new System.EventHandler(this.cboDestinoCredito_SelectedIndexChanged); 
                this.cboDetalleGasto.SelectedIndexChanged       += new System.EventHandler(this.cboDetalleGasto_SelectedIndexChanged); 
                this.txtCuotaAprox.TextChanged                  += new System.EventHandler(this.txtCuotaAprox_TextChanged); 
                this.cboSectorEconomico.SelectedIndexChanged    += new System.EventHandler(this.cboSectorEconomico_SelectedIndexChanged); 
                this.cboSectorCliente.SelectedIndexChanged      += new System.EventHandler(this.cboSectorCliente_SelectedIndexChanged);
                this.txtSaldoRCC.TextChanged                    += new System.EventHandler(this.txtSaldoRCC_TextChanged);
                this.cboModalidaCredito.SelectedIndexChanged    += new System.EventHandler(this.cboModalidaCredito_SelectedIndexChanged);
                this.dtpFechaDesembolso.ValueChanged            += new System.EventHandler(this.dtpFechaDesembolso_ValueChanged);
            }
        }

        public void CargarDatosRCC()
        {
            DataTable dtSaldoRCC = objCNSolicitud.CNRecuperarSaldoRCCCliente(objCliente.idCli);
            decimal nSaldoRCC = dtSaldoRCC.AsEnumerable().Sum(item => item.Field<decimal>("saldo"));
            txtSaldoRCC.Text = nSaldoRCC.ToString("N2");
        }

        public clsMsjError ValidarDatosSolicitud()
        {
            clsMsjError objError = new clsMsjError();

            if(objCliente.idCli == 0)
            {
                objError.AddError("Ingrese un Cliente para la solicitud de Crédito.");
            }
            if(objSolicitud.nCapitalSolicitado == 0)
            {
                objError.AddError("El monto Solicitado debe ser mayor a CERO.");
            }
            if(objSolicitud.nCuotas == 0)
            {
                objError.AddError("El número de cuotas debe ser mayor a CERO.");
            }
            if (objSolicitud.idTipoPeriodo == 0)
            {
                objError.AddError("Debe seleccionar el Tipo de Periodo");
            }
            if (objSolicitud.nPlazoCuota == 0)
            {
                objError.AddError("El Plazo debe ser mayor a CERO");
            }
            if (objSolicitud.idModalidadCredito == 0)
            {
                objError.AddError("Debe seleccionar la modalidad de Crédito.");
            }
            if (objSolicitud.idTipoPeriodo == 2 && objSolicitud.nCuotasGracia >= objSolicitud.nCuotas)
            {
                objError.AddError("El número de cuotas de gracia no puede ser mayor o igual al número de cuotas.");
            }
            if (objSolicitud.idActividadInterna == 0)
            {
                objError.AddError("Debe seleccionar la Actividad Económica del Cliente.");
            }
            if (objSolicitud.idProducto == 0)
            {
                objError.AddError("La solicitud no tiene un Sub Producto Seleccionado.");
            }
            if (objSolicitud.idDestino == 0)
            {
                objError.AddError("Debe seleccionar el Destino del Crédito.");
            }
            if (objSolicitud.idRecurso == 0)
            {
                objError.AddError("Debe seleccionar el Recurso del Crédito.");
            }
            if (objSolicitud.idTasa == 0)
            {
                objError.AddError("Debe configurar la Tasa de la Solicitud de Crédito.");
            }
            if (objSolicitud.idModalidadDes == 0)
            {
                objError.AddError("Debe seleccionar la Modalidad de Desembolso.");
            }
            if (objSolicitud.dFechaDesembolsoSugerido < clsVarGlobal.dFecSystem)
            {
                objError.AddError("La fecha de Desembolso no puede ser menor a la del sistema.");
            }
            if(objSolicitud.idSectorEconomico == 0)
            {
                objError.AddError("Debe Seleccionar el Sector Económico para la solicitud de Crédito.");
            }
            if (objSolicitud.idOperacion == 4)
            {
                if (objSolicitud.nCapitalSolicitado == decimal.Parse(txtSaldoAmpliacion.Text))
                {
                    objError.AddError("El capital solicitado debe ser mayor que el saldo de ampliación.");
                }
            }
            if (clsVarGlobal.lisVars.Any(item => item.cVariable.Contains("cProductoPymeFacilitoInhabilitado")))
            {
                clsVarGen objVarTipoPlantilla = clsVarGlobal.lisVars.Find(item => item.cVariable.Contains("cProductoPymeFacilitoInhabilitado"));
                string cProducto = Convert.ToString(objVarTipoPlantilla.cValVar);
                if (BuscarProducto(cProducto, objSolicitud.idProducto))
                {
                    objError.AddError("El Producto no esta permitido para el registro por este formulario.");
                }
            }
            if (Convert.ToInt32(cboDetalleGasto.SelectedValue) == 2)
            {
                DataTable dtValidacion = (new clsCNEvaluacion()).validarTipoSeguroConyugal(Convert.ToInt32(objCliente.idCli), Convert.ToDecimal(txtMontoSolicitud.Text));

                if (dtValidacion.Rows.Count > 0)
                {
                    if (!Convert.ToBoolean(dtValidacion.Rows[0]["lValido"]))
                    {
                        objError.AddError(dtValidacion.Rows[0]["cMensaje"].ToString());
                    }
                }
                else
                {
                    objError.AddError("Ocurrió un error al intentar validar el Tipo de Seguro Desgravamen");
                }
            }

            return objError;
        }

        public int GetIdSolicitud() {
            return String.IsNullOrEmpty(this.txtCodSolicitud.Text)? 0 : Convert.ToInt32(this.txtCodSolicitud.Text) ;
        }
        private bool BuscarProducto(string cadena, int valor)
        {
            string[] valores = cadena.Split(',');

            foreach (string item in valores)
            {
                if (Convert.ToInt32(item) == valor)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Eventos
        private void ConSolicitudSimp_Load(object sender, EventArgs e)
        {
            InicializarComponentes();

            HabilitarControles(ACCION.DEFAULT);

        }

        private void btnTasaNegociada_Click(object sender, EventArgs e)
        {
            frmSolCreTasaNegSimp frmTasaNegociada = new frmSolCreTasaNegSimp(objCliente.idCli, objSolicitud.idSolicitud);
            frmTasaNegociada.lSolicitudCargado = true;
            frmTasaNegociada.ShowDialog();

            if (EventoPostTasaNegociable != null)
                EventoPostTasaNegociable(sender, e);


        }

        private void btnInterviniente_Click(object sender, EventArgs e)
        {
            frmRegIntervCreSimp frmRegIntervCre = new frmRegIntervCreSimp();
            frmRegIntervCre.idSolicitud = objSolicitud.idSolicitud;
            frmRegIntervCre.lDatosDefecto = true;
            frmRegIntervCre.ShowDialog();

            if (EventoPostIntervinientes != null)
                EventoPostIntervinientes(sender, e);
        }

        private void txtTasa_ButtonClick(object sender, EventArgs e)
        {
            RecuperarDatosSolicitud();
            frmSolCreTasa frmTasa = new frmSolCreTasa();
            frmTasa.CargarDatos(objSolicitud, objCliente);
            frmTasa.ShowDialog();

            if (frmTasa.objTasaCredSimp.nTasaSeleccionada != 0)
            {
                objSolicitud.objTasaCredSimp = frmTasa.objTasaCredSimp;
                objSolicitud.idTasa = objSolicitud.objTasaCredSimp.idTasa;
            }
            
            this.txtTasa.TextChanged -= new System.EventHandler(this.txtTasa_TextChanged);
            AsignarDatosTasa(objSolicitud.idTasa);
            this.txtTasa.TextChanged += new System.EventHandler(this.txtTasa_TextChanged);

        }

        private void txtProducto_ButtonClick(object sender, EventArgs e)
        {
            RecuperarDatosSolicitud();
            frmSolCreProducto frmProducto = new frmSolCreProducto();
            if(objSolicitud.idProducto != 0)
            {
                frmProducto.CargarDatos(objSolicitud.idSolicitud, objSolicitud.idProducto, objSolicitud.objProductoCredSimp, cIDsTipEvalCred, 0);
            }
            frmProducto.ShowDialog();
            objSolicitud.idProducto = frmProducto.idProducto;
            objSolicitud.objProductoCredSimp = frmProducto.objProductoCredSimp;
            AsignarDatosProducto(objSolicitud.idProducto);
            cargaDestinoXOperacion();
        }

        private void nudCuotas_Enter(object sender, EventArgs e)
        {
            nudCuotas.Select(0, nudCuotas.Text.Length);
        }

        private void nudDiaPagoFrecuencia_Enter(object sender, EventArgs e)
        {
            nudDiaPagoFrecuencia.Select(0, nudDiaPagoFrecuencia.Text.Length);
        }

        private void nudCuotaGracia_Enter(object sender, EventArgs e)
        {
            nudCuotaGracia.Select(0, nudCuotaGracia.Text.Length);
        }

        private void txtSaldoAmpliacion_ButtonClick(object sender, EventArgs e)
        {
            frmCuentaCreditoVinculado frmCuentaVinculado = new frmCuentaCreditoVinculado();
            frmCuentaVinculado.CargarDatos(objSolicitud, objCliente, dtCreditosAmp);
            frmCuentaVinculado.ShowDialog();

            dtCreditosAmp = frmCuentaVinculado.dtCreditosAmp;

            if (dtCreditosAmp.Rows.Count > 0)
            {
                ActualizarSaldoAmpliacion();
            }
            else
            {
                MessageBox.Show("Se eliminaron todas las cuentas de crédito \n la operación se cambiará por otorgamiento", "Validación de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboOperacionCre.SelectedValue = 1;
                txtSaldoAmpliacion.Text = string.Empty;
                txtSaldoAmpliacion.Text = string.Empty;
                dtCreditosAmp.Clear();
            }
        }

        private void cboOperacionCre_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCuenta = 0;
            clsCNSolicitud nListCreditosAmp = new clsCNSolicitud();

            if (Convert.ToInt32(cboOperacionCre.SelectedValue) == 4)
            {
                if (objSolicitud.idSolicitud != 0)
                {
                    dtCreditosAmp = nListCreditosAmp.CNRetCuentasAmpliadas(objSolicitud.idSolicitud);
                    ActualizarSaldoAmpliacion();
                    txtSaldoAmpliacion.Enabled = Convert.ToInt32(cboOperacionCre.SelectedValue) == 4 ? true : false;
                }
                else
                {
                    if (objCliente.idCli == 0)
                    {
                        return;
                    }
                    int idCli = objCliente.idCli;
                    clsCNRetornsCuentaSolCliente RetornaCuentaSolCliente = new clsCNRetornsCuentaSolCliente();
                    DataTable dtDatosCuentaSolCliente = RetornaCuentaSolCliente.RetornaCuentaSolCliente(idCli, "C", "[5]");

                    if (dtDatosCuentaSolCliente.Rows.Count == 0)
                    {
                        MessageBox.Show("Cliente seleccionado no tiene cuentas en estado vigente", "Validación de Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboOperacionCre.SelectedValue = 1;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("A continuación seleccione el crédito a Ampliar", "Selección de crédito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        GEN.ControlesBase.FrmBuscaCuentaCliente frmBusCuenCli = new GEN.ControlesBase.FrmBuscaCuentaCliente();
                        frmBusCuenCli.CargarDatos(idCli, "C", "[5]");
                        frmBusCuenCli.ShowDialog();
                        idCuenta = Convert.ToInt32(frmBusCuenCli.cIdCreSol);
                        int idProducto = frmBusCuenCli.idProducto;
                        if (idCuenta == 0)
                        {
                            MessageBox.Show("No seleccionó una cuenta de crédito \n la operación se cambiará por otorgamiento", "Validación de cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboOperacionCre.SelectedValue = 1;
                            return;
                        }
                        else {
                            txtSaldoAmpliacion.Enabled = Convert.ToInt32(cboOperacionCre.SelectedValue) == 4 ? true : false;
                        }

                        dtCreditosAmp = nListCreditosAmp.CNRetCuentasAmpliadas(-1);

                        agregarCreditos(idCuenta);
                    }
                }
            }
            else
            {
                dtCreditosAmp = nListCreditosAmp.CNRetCuentasAmpliadas(-1);
                ActualizarSaldoAmpliacion();
                txtSaldoAmpliacion.Enabled = Convert.ToInt32(cboOperacionCre.SelectedValue) == 4 ? true : false;
            }
        }

        private void dtpFechaRegistro_ValueChanged(object sender, EventArgs e)
        {
            RecuperarDatosSolicitud();
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            RecuperarDatosSolicitud();
        }

        private void txtMontoSolicitud_TextChanged(object sender, EventArgs e)
        {
            RecuperarDatosSolicitud();
            CalcularMontoAmpliacion();
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecuperarDatosSolicitud();
        }

        private void nudCuotas_ValueChanged(object sender, EventArgs e)
        {
            RecuperarDatosSolicitud();
        }

        private void cboTipoPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecuperarDatosSolicitud();
        }

        private void nudDiaPagoFrecuencia_ValueChanged(object sender, EventArgs e)
        {

            RecuperarDatosSolicitud();
        }

        private void dtpPrimeraCuota_ValueChanged(object sender, EventArgs e)
        {
            int nDiaPago = Convert.ToInt32(dtpPrimeraCuota.Value.Day);
            nudDiaPagoFrecuencia.Value = nDiaPago;

            nudDiaPagoFrecuencia.BackColor = Color.White;

            if (this.objSolicitud.idTipoPeriodo == (int)TipoPeriodo.FechaFija)
            {
                if (nDiaPago > (int)clsVarApl.dicVarGen["nNumDiaPago"])
                {
                    this.nudDiaPagoFrecuencia.BackColor = Color.Red;
                }
            }

            int nDiasGracia = 0;

            DateTime dtFechaPrimeraCuota = dtpPrimeraCuota.Value;
            nDiasGracia = dtFechaPrimeraCuota.AddMonths(-1).Subtract(objSolicitud.dFechaDesembolsoSugerido).Days;
            
            if (nDiasGracia < nudDiasGracia.Minimum)
            {
                nudDiasGracia.Value = nudDiasGracia.Minimum;
            }
            else if (nDiasGracia > nudDiasGracia.Maximum)
            {
                nudDiasGracia.Value = nudDiasGracia.Maximum;
            }
            else
            {
                nudDiasGracia.Value = nDiasGracia;
            }

            RecuperarDatosSolicitud();
        }

        private void nudCuotaGracia_ValueChanged(object sender, EventArgs e)
        {
            RecuperarDatosSolicitud();
        }

        private void txtTasa_TextChanged(object sender, EventArgs e)
        {
            RecuperarDatosSolicitud();
        }

        private void txtSaldoAmpliacion_TextChanged(object sender, EventArgs e)
        {
            RecuperarDatosSolicitud();
        }

        private void cboDestinoCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecuperarDatosSolicitud();
        }

        private void cboDetalleGasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDetalleGasto.SelectedIndex == 2)
            {
                DialogResult drRespuesta = MessageBox.Show(cboDetalleGasto.cMsjSeguroDevolucion,
                    cboDetalleGasto.cTituloMsjSegDevolucion,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.No == drRespuesta)
                    cboDetalleGasto.SelectedIndex = 0;
            }
            RecuperarDatosSolicitud();
        }

        private void txtCuotaAprox_TextChanged(object sender, EventArgs e)
        {
            RecuperarDatosSolicitud();
        }

        private void cboSectorEconomico_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecuperarDatosSolicitud();
        }

        private void cboSectorCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecuperarDatosSolicitud();
        }

        private void txtSaldoRCC_TextChanged(object sender, EventArgs e)
        {
            RecuperarDatosSolicitud();
        }

        private void cboModalidaCredito_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecuperarDatosSolicitud();
        }

        #endregion

        private enum ACCION
        {
            REGISTRAR = 1,
            EDITAR = 2,
            RECUPERAR = 3,
            CANCELAR = 4,
            NUEVO   = 5,
            DEFAULT = 6
        }

        private void txtMontoSolicitud_Leave(object sender, EventArgs e)
        {
            int idTipoOperacion = Convert.ToInt32(cboOperacionCre.SelectedValue);
            if(idTipoOperacion.In(4))
            {
                decimal nCapitalSolNuevo = Convert.ToDecimal(txtMontoSolicitud.Text);
                if(nCapitalSolNuevo < nCapitalSolMinimo)
                {
                    txtMontoSolicitud.Text = Convert.ToString(nCapitalSolMinimo);
                }
            }
            CalcularCuotaAproximada();
            RecuperarDatosSolicitud();
        }

        private void CalcularMontoAmpliacion()
        {
            txtMontoAmpliacion.Text = objSolicitud.idOperacion == 4 ? (decimal.Parse(txtMontoSolicitud.Text) - decimal.Parse(txtSaldoAmpliacion.Text)).ToString() : "";
        }
        private void cboMoneda_Leave(object sender, EventArgs e)
        {
            CalcularCuotaAproximada();
            RecuperarDatosSolicitud();
        }

        private void cboTipoPeriodo_Leave(object sender, EventArgs e)
        {
            CalcularCuotaAproximada();
            RecuperarDatosSolicitud();
        }

        private void nudCuotas_Leave(object sender, EventArgs e)
        {
            CalcularCuotaAproximada();
            RecuperarDatosSolicitud();
        }

        private void nudDiaPagoFrecuencia_Leave(object sender, EventArgs e)
        {
            int idDiaPagoFrecuencia = Convert.ToInt32(nudDiaPagoFrecuencia.Value);
            DateTime dFechaPrimeraCuota = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, idDiaPagoFrecuencia).AddMonths(1);
            dtpPrimeraCuota.Value = dFechaPrimeraCuota;

            CalcularCuotaAproximada();
            RecuperarDatosSolicitud();
        }

        private void dtpPrimeraCuota_Leave(object sender, EventArgs e)
        {
            CalcularCuotaAproximada();
            RecuperarDatosSolicitud();
        }

        private void nudCuotaGracia_Leave(object sender, EventArgs e)
        {
            CalcularCuotaAproximada();
            RecuperarDatosSolicitud();
        }

        private void txtProducto_Leave(object sender, EventArgs e)
        {
            CalcularCuotaAproximada();
            RecuperarDatosSolicitud();
        }

        private void txtTasa_Leave(object sender, EventArgs e)
        {
            CalcularCuotaAproximada();
            RecuperarDatosSolicitud();
        }

        private void nudDiasGracia_Leave(object sender, EventArgs e)
        {

        }

        private void dtpFechaDesembolso_Leave(object sender, EventArgs e)
        {
            CalcularCuotaAproximada();
            RecuperarDatosSolicitud();
        }

        private void dtpFechaDesembolso_ValueChanged(object sender, EventArgs e)
        {
            int nDiasGracia = 0;

            nDiasGracia = objSolicitud.dFechaPrimeraCuota.AddMonths(-1).Subtract(objSolicitud.dFechaDesembolsoSugerido).Days;
            nudDiasGracia.Value = (nDiasGracia < 0) ? 0 : nDiasGracia;

            RecuperarDatosSolicitud();
        }

        private void txtMontoSolicitud_Enter(object sender, EventArgs e)
        {
            int idTipoOperacion = Convert.ToInt32(cboOperacionCre.SelectedValue);
            if(idTipoOperacion.In(4))
            {
                if(!String.IsNullOrWhiteSpace(txtSaldoAmpliacion.Text))
                {
                    nCapitalSolMinimo = Convert.ToDecimal(this.txtSaldoAmpliacion.Text);
                }
                else
                {
                    nCapitalSolMinimo = 0.00m;
                }
                
            }
            else
            {
                nCapitalSolMinimo = 0.00m;
            }
        }

        private void cboCanalVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPromotores.filtrarPorCanal(Convert.ToInt32(cboCanalVendedor.SelectedValue));
            int listItem = cboPromotores.Items.Count;
            if (listItem == 1)
            {
                cboPromotores.SelectedIndex = 0;
            }
            else
            {
                cboPromotores.SelectedValue = 0;
            }
        }
    }
}
