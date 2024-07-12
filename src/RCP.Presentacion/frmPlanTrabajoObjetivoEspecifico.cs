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
using GEN.ControlesBase;
using EntityLayer;
using RCP.CapaNegocio;
using GEN.Funciones;
#endregion


namespace RCP.Presentacion
{
    public partial class frmPlanTrabajoObjetivoEspecifico : frmBase
    {
        
        #region Variables Globales
        private clsCNPlanTrabajo objCNPlanTrabajo { get; set; }
        private List<clsPlanTrabajoObjetivo> lstObjetivoGeneral { get; set; }
        private DataTable dtSemanaMes { get; set; }
        public clsPlanTrabajoObjetivo objPlanTrabajoObjetivoEspecifico { get; set; }
        public clsPlanTrabajoDetalleAccion objPlanTrabajoDetalleAccion { get; set; }
        public clsPlanTrabajoZonaVisita objPlanTrabajoZonaVisita { get; set; }
        private List<clsDatosCreditoClientePlanTrabajo> lstClientePlanTrabajo { get; set; }

        private List<clsDatosCreditoCliente> lstDatosCreditoCliente { get; set; }
        private BindingSource bsDatosCreditosCliente { get; set; }
        private int idUsuarioPlanTrabajo { get; set; }
        private int idUsuarioRevisionPlanTrabajo { get; set; }


        public DataTable dtDatosUsuarioZona { get; set; }
        private RolFormularioUsuario eRolActivo { get; set; }

        private int idPlanTrabajoRecuperacion { get; set; }
        private int idPlanTrabajoObjetivo { get; set; }
        private int idPlanTrabajoDetalleAccion { get; set; }
        private int idPlanTrabajoZonaVisita { get; set; }


        #endregion
        public frmPlanTrabajoObjetivoEspecifico()
        {
            InitializeComponent();
            cargarComponentes();
            asignarDatosDefecto();
        }

        public frmPlanTrabajoObjetivoEspecifico(int _idPlanTrabajoRecuperacion, List<clsPlanTrabajoObjetivo> _lstObjetivoGeneral, int _idUsuarioPlanTrabajo, int idRolActivo)
        {
            InitializeComponent();
            cargarComponentes(_idPlanTrabajoRecuperacion, _lstObjetivoGeneral, _idUsuarioPlanTrabajo, idRolActivo);
            asignarDatosDefecto();
            formatearGridDatosCreditoCliente();
        }
        #region Eventos
        private void frmPlanTrabajoObjetivoEspecifico_Load(object sender, EventArgs e)
        {
            if (objPlanTrabajoObjetivoEspecifico.idObjetivoTipo != 0)
            {
                asignarDatos();
            }
            else
            {
                limpiar();
            }
        }

        private void cboObjetivoTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            objPlanTrabajoObjetivoEspecifico = obtenerObjetivosEspecificos();
        }

        private void cboObjetivoGeneral_SelectedIndexChanged(object sender, EventArgs e)
        {
            habilitarEventHandler(false);
            clsPlanTrabajoObjetivo objGeneralSeleccionado = new clsPlanTrabajoObjetivo();
            objGeneralSeleccionado = (clsPlanTrabajoObjetivo)cboObjetivoGeneral.SelectedItem;

            DataTable dtObjetivoEspecificoResumen = objCNPlanTrabajo.CNListarObjetivoResumen(objGeneralSeleccionado.idPlanTrabajoResumenObjetivo, (int)ObjetivoTipo.ESPECIFICO);

            cboSemanaObjetivo.SelectedValue = objGeneralSeleccionado.nSemana;

            DataRow drFechaSemana = ((DataRowView)cboSemanaObjetivo.SelectedItem).Row;
            DateTime dFechaInicioSemana = Convert.ToDateTime(drFechaSemana["dFechaInicioSemana"]);

            dtpFechaEspecifica.Value = dFechaInicioSemana;

            cboObjetivoResumen.DataSource       = dtObjetivoEspecificoResumen;
            cboObjetivoResumen.DisplayMember    = dtObjetivoEspecificoResumen.Columns["cPlanTrabajoResumenObjetivo"].ColumnName;
            cboObjetivoResumen.ValueMember      = dtObjetivoEspecificoResumen.Columns["idPlanTrabajoResumenObjetivo"].ColumnName;
            cboObjetivoResumen.SelectedIndex    = -1;
            habilitarEventHandler(true);

            objPlanTrabajoObjetivoEspecifico = obtenerObjetivosEspecificos();
        }

        private void cboObjetivoResumen_SelectedIndexChanged(object sender, EventArgs e)
        {
            objPlanTrabajoObjetivoEspecifico = obtenerObjetivosEspecificos();
        }

        private void dtpFechaEspecifica_Leave(object sender, EventArgs e)
        {
            objPlanTrabajoObjetivoEspecifico = obtenerObjetivosEspecificos();
        }

        private void txtDescripcionObjetivoGeneral_Leave(object sender, EventArgs e)
        {
            objPlanTrabajoObjetivoEspecifico = obtenerObjetivosEspecificos();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validar() && validarDetalleAccion() && validarZonaVisita())
            {
                objPlanTrabajoObjetivoEspecifico = obtenerObjetivosEspecificos();
                objPlanTrabajoDetalleAccion = obtenerDetalleAccion();
                objPlanTrabajoZonaVisita = obtenerZonaVisita();
                lstClientePlanTrabajo = filtrarPlanTrabajoDetalleAccionCliente();

                string xmlPlanTrabajoObjetivoEspecifico     = objPlanTrabajoObjetivoEspecifico.GetXml();
                string xmlPlanTrabajoDetalleAccion          = objPlanTrabajoDetalleAccion.GetXml();
                string xmlPlanTrabajoZonaVisita             = objPlanTrabajoZonaVisita.GetXml();
                string xmlPlanTrabajoCliente                = lstClientePlanTrabajo.GetXml();

                DataTable dtResultado = objCNPlanTrabajo.CNRegistrarObjetivoEspecificoPlanTrabajoCompleto(  objPlanTrabajoObjetivoEspecifico.idPlanTrabajoRecuperacion, objPlanTrabajoObjetivoEspecifico.idPlanTrabajoObjetivoPadre,
                                                                                                            xmlPlanTrabajoObjetivoEspecifico, xmlPlanTrabajoDetalleAccion , xmlPlanTrabajoZonaVisita, xmlPlanTrabajoCliente,
                                                                                                            clsVarGlobal.dFecSystem);
                if(dtResultado.Rows.Count > 0)
                {
                    if(Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) == 1)
                    {
                        idPlanTrabajoObjetivo               = Convert.ToInt32(dtResultado.Rows[0]["idPlanTrabajoObjetivo"]);
                        idPlanTrabajoDetalleAccion          = Convert.ToInt32(dtResultado.Rows[0]["idPlanTrabajoDetalleaccion"]);
                        idPlanTrabajoZonaVisita             = Convert.ToInt32(dtResultado.Rows[0]["idPlanTrabajoZonaVisita"]);
                        objPlanTrabajoObjetivoEspecifico    = obtenerObjetivosEspecificos();
                        objPlanTrabajoDetalleAccion         = obtenerDetalleAccion();
                        objPlanTrabajoZonaVisita            = obtenerZonaVisita();

                        MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show(Convert.ToString(dtResultado.Rows[0]["cMensaje"]), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrió un problema al momento de registrar el objetivo específico del plan de trabajo, intentelo de nuevo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            objPlanTrabajoObjetivoEspecifico    = new clsPlanTrabajoObjetivo();
            objPlanTrabajoDetalleAccion         = new clsPlanTrabajoDetalleAccion();
            objPlanTrabajoZonaVisita            = new clsPlanTrabajoZonaVisita();
            this.Dispose();
        }

        private void btnMiniBusq_Click(object sender, EventArgs e)
        {
            frmSeleccionarClientePlanTrabajo frmSeleccionarClientePlanTrabajo = new frmSeleccionarClientePlanTrabajo();
            frmSeleccionarClientePlanTrabajo.cargarDatos(idUsuarioPlanTrabajo);
            List<clsDatosCreditoCliente> _lstDatosCreditoCliente = new List<clsDatosCreditoCliente>();

            frmSeleccionarClientePlanTrabajo.ShowDialog();

            if (frmSeleccionarClientePlanTrabajo.lstDatosCreditoClienteSeleccionado.Count > 0)
            {
                _lstDatosCreditoCliente = frmSeleccionarClientePlanTrabajo.lstDatosCreditoClienteSeleccionado;
                agregarDetalleCreditoCliente(_lstDatosCreditoCliente);
            }
            objPlanTrabajoDetalleAccion = obtenerDetalleAccion();
        }

        private void btnMiniDetalle_Click(object sender, EventArgs e)
        {
            clsPlanTrabajoObjetivo objObjetivoEspecificoSeleccionado = objPlanTrabajoObjetivoEspecifico;
            clsPlanTrabajoObjetivo objObjetivoGeneralSeleccionado = lstObjetivoGeneral.FirstOrDefault(item => item.idPlanTrabajoObjetivo == objObjetivoEspecificoSeleccionado.idPlanTrabajoObjetivoPadre);
            List<clsDatosCreditoCliente> _lstDatosCreditoCliente = new List<clsDatosCreditoCliente>();
            objObjetivoGeneralSeleccionado = (objObjetivoGeneralSeleccionado == null) ? new clsPlanTrabajoObjetivo() : objObjetivoGeneralSeleccionado;
            frmSeleccionarClientePlanTrabajo frmSeleccionarClientePlanTrabajo = new frmSeleccionarClientePlanTrabajo();
            frmSeleccionarClientePlanTrabajo.cargarDatos(idUsuarioPlanTrabajo, clsVarGlobal.nIdAgencia, objObjetivoGeneralSeleccionado.idPlanTrabajoResumenObjetivo, objObjetivoEspecificoSeleccionado.idPlanTrabajoResumenObjetivo);
            frmSeleccionarClientePlanTrabajo.ShowDialog();

            if (frmSeleccionarClientePlanTrabajo.lstDatosCreditoClienteSeleccionado.Count > 0)
            {
                _lstDatosCreditoCliente = frmSeleccionarClientePlanTrabajo.lstDatosCreditoClienteSeleccionado;
                agregarDetalleCreditoCliente(_lstDatosCreditoCliente);
            }
            objPlanTrabajoDetalleAccion = obtenerDetalleAccion();
        }

        private void btnMiniAgregar_Click(object sender, EventArgs e)
        {
            frmBuscarCreditoCliente frmBuscarCreditoCliente = new frmBuscarCreditoCliente();
            clsDatosCreditoCliente objDatosCreditoCliente = new clsDatosCreditoCliente();
            frmBuscarCreditoCliente.ShowDialog();

            if (frmBuscarCreditoCliente.datosCreditoCliente.idCuenta != 0)
            {
                objDatosCreditoCliente = frmBuscarCreditoCliente.datosCreditoCliente;
                agregarDetalleCreditoCliente(objDatosCreditoCliente);
            }
            objPlanTrabajoDetalleAccion = obtenerDetalleAccion();
        }

        private void btnMiniQuitar_Click(object sender, EventArgs e)
        {
            eliminarDetalleCreditoCliente();
            objPlanTrabajoDetalleAccion = obtenerDetalleAccion();
        }

        private void cboAccionResumen_SelectedIndexChanged(object sender, EventArgs e)
        {
            objPlanTrabajoDetalleAccion = obtenerDetalleAccion();
        }

        private void txtDetalleAccion_Leave(object sender, EventArgs e)
        {
            objPlanTrabajoDetalleAccion = obtenerDetalleAccion();
        }

        private void dtgDetalleAccionCliente_Leave(object sender, EventArgs e)
        {
            objPlanTrabajoDetalleAccion = obtenerDetalleAccion();
        }

        private void cboZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDatosZona();
            objPlanTrabajoZonaVisita = obtenerZonaVisita();
        }

        private void cboAgencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDatosAgencia();
            objPlanTrabajoZonaVisita = obtenerZonaVisita();
        }

        private void cboDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            objPlanTrabajoZonaVisita = obtenerZonaVisita();
        }

        private void txtDescripcionZonaVisita_Leave(object sender, EventArgs e)
        {
            objPlanTrabajoZonaVisita = obtenerZonaVisita();
        }

        #endregion

        #region Metodos
        public void cargarDatos(clsPlanTrabajoObjetivo _objPlanTrabajoObjetivo)
        {
            objPlanTrabajoObjetivoEspecifico = _objPlanTrabajoObjetivo;
        }

        private void cargarComponentes()
        {
            habilitarEventHandler(false);

            objCNPlanTrabajo = new clsCNPlanTrabajo();
            objPlanTrabajoObjetivoEspecifico = new clsPlanTrabajoObjetivo();

            DataTable dtObjetivoTipo    = objCNPlanTrabajo.CNListarObjetivoTipo();
            DataTable dtNombreSemana    = objCNPlanTrabajo.CNListarNombreSemana();
            lstObjetivoGeneral          = new List<clsPlanTrabajoObjetivo>();

            cboObjetivoTipo.DataSource      = dtObjetivoTipo;
            cboObjetivoTipo.DisplayMember   = dtObjetivoTipo.Columns["cObjetivoTipo"].ColumnName;
            cboObjetivoTipo.ValueMember     = dtObjetivoTipo.Columns["idObjetivoTipo"].ColumnName;
            cboObjetivoTipo.SelectedValue   = (int)ObjetivoTipo.ESPECIFICO;

            cboSemanaObjetivo.DataSource        = dtNombreSemana;
            cboSemanaObjetivo.DisplayMember     = dtNombreSemana.Columns["cSemana"].ColumnName;
            cboSemanaObjetivo.ValueMember       = dtNombreSemana.Columns["idSemana"].ColumnName;
            cboSemanaObjetivo.SelectedIndex     = -1;

            cboObjetivoGeneral.DataSource       = lstObjetivoGeneral;
            cboObjetivoGeneral.DisplayMember    = "cDescripcionPlanTrabajoObjetivo";
            cboObjetivoGeneral.ValueMember      = "idPlanTrabajoObjetivo";
            cboObjetivoGeneral.SelectedIndex    = -1;

            habilitarEventHandler(true);

        }

        private void cargarComponentes(int _idPlanTrabajoRecuperacion,  List<clsPlanTrabajoObjetivo> _lstObjetivoGeneral, int _idUsuarioPlanTrabajo, int _idRolActivo)
        {
            habilitarEventHandler(false);
            idPlanTrabajoRecuperacion           = _idPlanTrabajoRecuperacion;
            idPlanTrabajoObjetivo               = 0;
            idPlanTrabajoDetalleAccion          = 0;
            idPlanTrabajoZonaVisita             = 0;
            objCNPlanTrabajo                    = new clsCNPlanTrabajo();
            objPlanTrabajoObjetivoEspecifico    = new clsPlanTrabajoObjetivo();
            objPlanTrabajoDetalleAccion         = new clsPlanTrabajoDetalleAccion();
            objPlanTrabajoZonaVisita            = new clsPlanTrabajoZonaVisita();
            lstClientePlanTrabajo               = new List<clsDatosCreditoClientePlanTrabajo>();

            DataTable dtObjetivoTipo    = objCNPlanTrabajo.CNListarObjetivoTipo();
            DataTable dtNombreSemana    = objCNPlanTrabajo.CNListarNombreSemana();
            lstObjetivoGeneral          = _lstObjetivoGeneral;

            cboObjetivoTipo.DataSource      = dtObjetivoTipo;
            cboObjetivoTipo.DisplayMember   = dtObjetivoTipo.Columns["cObjetivoTipo"].ColumnName;
            cboObjetivoTipo.ValueMember     = dtObjetivoTipo.Columns["idObjetivoTipo"].ColumnName;
            cboObjetivoTipo.SelectedValue   = (int)ObjetivoTipo.ESPECIFICO;

            cboSemanaObjetivo.DataSource    = dtNombreSemana;
            cboSemanaObjetivo.DisplayMember = dtNombreSemana.Columns["cSemana"].ColumnName;
            cboSemanaObjetivo.ValueMember   = dtNombreSemana.Columns["idSemana"].ColumnName;
            cboSemanaObjetivo.SelectedIndex = -1;

            cboObjetivoGeneral.DataSource       = lstObjetivoGeneral;
            cboObjetivoGeneral.DisplayMember    = "cPlanTrabajoResumenObjetivo";
            cboObjetivoGeneral.ValueMember      = "idPlanTrabajoObjetivo";
            cboObjetivoGeneral.SelectedIndex    = -1;


            idUsuarioPlanTrabajo            = _idUsuarioPlanTrabajo;

            lstDatosCreditoCliente                  = new List<clsDatosCreditoCliente>();
            bsDatosCreditosCliente                  = new BindingSource();
            bsDatosCreditosCliente.DataSource       = lstDatosCreditoCliente;
            dtgDetalleAccionCliente.DataSource      = bsDatosCreditosCliente;
            
            DataTable dtResumenAccion       = objCNPlanTrabajo.CNListarAccion();
            cboAccionResumen.DataSource     = dtResumenAccion;
            cboAccionResumen.DisplayMember  = dtResumenAccion.Columns["cPlanTrabajoAccion"].ColumnName;
            cboAccionResumen.ValueMember    = dtResumenAccion.Columns["idPlanTrabajoAccion"].ColumnName;
            cboAccionResumen.SelectedIndex  = -1;

            eRolActivo                  = (RolFormularioUsuario)_idRolActivo;

            if (eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR)
            {
                int idUsuarioZona = clsVarGlobal.User.idUsuario;
                cboZona.cargarZonasAsignadas(idUsuarioZona);
                if (cboZona.Items.Count < 2)
                {
                    cboZona.cargarZona();
                }
            }
            else
            {
                cboZona.cargarZona();
            }
            cboAgencias.AgenciasYTodos();
            cargarDatosAgencia();

            habilitarEventHandler(true);

        }

        private void limpiar()
        {
            cboObjetivoTipo.SelectedValue       = (int)ObjetivoTipo.ESPECIFICO;
            cboObjetivoGeneral.SelectedIndex    = -1;
            cboSemanaObjetivo.SelectedIndex     = -1;
            cboObjetivoResumen.SelectedIndex    = -1;
            dtpFechaEspecifica.Value            = clsVarGlobal.dFecSystem;
            txtDescripcionObjetivoGeneral.Text  = String.Empty;
        }

        private void habilitarEventHandler(bool lValor)
        {
            if (!lValor)
            {
                cboObjetivoTipo.SelectedIndexChanged    -= new EventHandler(cboObjetivoTipo_SelectedIndexChanged);
                cboObjetivoGeneral.SelectedIndexChanged -= new EventHandler(cboObjetivoGeneral_SelectedIndexChanged);
                cboObjetivoResumen.SelectedIndexChanged -= new EventHandler(cboObjetivoResumen_SelectedIndexChanged);
                dtpFechaEspecifica.Leave                -= new EventHandler(dtpFechaEspecifica_Leave);
                txtDescripcionObjetivoGeneral.Leave     -= new EventHandler(txtDescripcionObjetivoGeneral_Leave);
                cboObjetivoGeneral.SelectedIndexChanged -= new EventHandler(cboObjetivoGeneral_SelectedIndexChanged);

                cboAccionResumen.SelectedIndexChanged   -= new EventHandler(cboAccionResumen_SelectedIndexChanged);
                txtDetalleAccion.Leave                  -= new EventHandler(txtDetalleAccion_Leave);

                cboZona.SelectedIndexChanged            -= new EventHandler(cboZona_SelectedIndexChanged);
                cboAgencias.SelectedIndexChanged        -= new EventHandler(cboAgencias_SelectedIndexChanged);
                cboDistrito.SelectedIndexChanged        -= new EventHandler(cboDistrito_SelectedIndexChanged);
                txtDescripcionZonaVisita.Leave          -= new EventHandler(txtDescripcionZonaVisita_Leave);
            }
            else
            {
                cboObjetivoTipo.SelectedIndexChanged    += new EventHandler(cboObjetivoTipo_SelectedIndexChanged);
                cboObjetivoGeneral.SelectedIndexChanged += new EventHandler(cboObjetivoGeneral_SelectedIndexChanged);
                cboObjetivoResumen.SelectedIndexChanged += new EventHandler(cboObjetivoResumen_SelectedIndexChanged);
                dtpFechaEspecifica.Leave                += new EventHandler(dtpFechaEspecifica_Leave);
                txtDescripcionObjetivoGeneral.Leave     += new EventHandler(txtDescripcionObjetivoGeneral_Leave);
                cboObjetivoGeneral.SelectedIndexChanged += new EventHandler(cboObjetivoGeneral_SelectedIndexChanged);

                cboAccionResumen.SelectedIndexChanged   += new EventHandler(cboAccionResumen_SelectedIndexChanged);
                txtDetalleAccion.Leave                  += new EventHandler(txtDetalleAccion_Leave);

                cboZona.SelectedIndexChanged            += new EventHandler(cboZona_SelectedIndexChanged);
                cboAgencias.SelectedIndexChanged        += new EventHandler(cboAgencias_SelectedIndexChanged);
                cboDistrito.SelectedIndexChanged        += new EventHandler(cboDistrito_SelectedIndexChanged);
                txtDescripcionZonaVisita.Leave          += new EventHandler(txtDescripcionZonaVisita_Leave);
            }
        }

        private clsPlanTrabajoObjetivo obtenerObjetivosEspecificos()
        {
            clsPlanTrabajoObjetivo objObjetivoGeneral = ((clsPlanTrabajoObjetivo)cboObjetivoGeneral.SelectedItem == null) ? new clsPlanTrabajoObjetivo() : (clsPlanTrabajoObjetivo)cboObjetivoGeneral.SelectedItem;

            objPlanTrabajoObjetivoEspecifico.idPlanTrabajoRecuperacion          = idPlanTrabajoRecuperacion;
            objPlanTrabajoObjetivoEspecifico.idPlanTrabajoObjetivo              = idPlanTrabajoObjetivo;
            objPlanTrabajoObjetivoEspecifico.cDescripcionPlanTrabajoObjetivo    = txtDescripcionObjetivoGeneral.Text;
            objPlanTrabajoObjetivoEspecifico.idObjetivoTipo                     = Convert.ToInt32(cboObjetivoTipo.SelectedValue);
            objPlanTrabajoObjetivoEspecifico.cObjetivoTipo                      = Convert.ToString(cboObjetivoTipo.Text);
            objPlanTrabajoObjetivoEspecifico.nSemana                            = Convert.ToInt32(cboSemanaObjetivo.SelectedValue);
            objPlanTrabajoObjetivoEspecifico.cSemana                            = cboSemanaObjetivo.Text;
            objPlanTrabajoObjetivoEspecifico.idPlanTrabajoObjetivoPadre         = objObjetivoGeneral.idPlanTrabajoObjetivo;
            objPlanTrabajoObjetivoEspecifico.cPlanTrabajoResumenObjetivoPadre   = cboObjetivoGeneral.Text;
            objPlanTrabajoObjetivoEspecifico.idPlanTrabajoResumenObjetivo       = Convert.ToInt32(cboObjetivoResumen.SelectedValue);
            objPlanTrabajoObjetivoEspecifico.cPlanTrabajoResumenObjetivo        = cboObjetivoResumen.Text;
            objPlanTrabajoObjetivoEspecifico.nDia                               = dtpFechaEspecifica.Value.Day;
            objPlanTrabajoObjetivoEspecifico.dFechaEspecifica                   = dtpFechaEspecifica.Value;
            objPlanTrabajoObjetivoEspecifico.dFechaRegistro                     = clsVarGlobal.dFecSystem;
            objPlanTrabajoObjetivoEspecifico.lVigente                           = true;

            return objPlanTrabajoObjetivoEspecifico;
        }

        private void asignarDatos()
        {
            habilitarEventHandler(false);
            cboObjetivoTipo.SelectedValue       = objPlanTrabajoObjetivoEspecifico.idObjetivoTipo;
            cboSemanaObjetivo.SelectedValue     = objPlanTrabajoObjetivoEspecifico.nSemana;
            cboObjetivoResumen.SelectedValue    = objPlanTrabajoObjetivoEspecifico.idPlanTrabajoResumenObjetivo;
            dtpFechaEspecifica.Value            = objPlanTrabajoObjetivoEspecifico.dFechaEspecifica;
            txtDescripcionObjetivoGeneral.Text  = objPlanTrabajoObjetivoEspecifico.cDescripcionPlanTrabajoObjetivo;
            habilitarEventHandler(true);
        }

        private void asignarDatosDefecto()
        {
            habilitarEventHandler(false);
            cboObjetivoTipo.SelectedValue       = (int)ObjetivoTipo.ESPECIFICO;
            cboObjetivoGeneral.SelectedIndex    = -1;
            cboSemanaObjetivo.SelectedIndex     = -1;
            cboObjetivoResumen.SelectedIndex    = -1;
            dtpFechaEspecifica.Value            = clsVarGlobal.dFecSystem;
            txtDescripcionObjetivoGeneral.Text  = String.Empty;


            dtDatosUsuarioZona      = objCNPlanTrabajo.CNObtenerDatosUsuarioZona(clsVarGlobal.User.idUsuario);
            int idZonaDefecto       = Convert.ToInt32(dtDatosUsuarioZona.Rows[0]["idZona"]);
            int idAgencia           = Convert.ToInt32(dtDatosUsuarioZona.Rows[0]["idAgencia"]);
            cboZona.SelectedValue       = idZonaDefecto;
            cargarDatosZona();
            cboAgencias.SelectedValue   = idAgencia;
            cargarDatosAgencia();
            cboZona.Enabled             = (eRolActivo == RolFormularioUsuario.REVISOR || (eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR && cboZona.Items.Count > 1 )) ? true : false;
            cboAgencias.Enabled         = (eRolActivo == RolFormularioUsuario.REVISOR) ? true : (eRolActivo == RolFormularioUsuario.ELABORADOR) ? false : true;

            habilitarEventHandler(true);
        }

        private bool validar()
        {
            DateTime dFechaInicio   = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            DateTime dFechaFin      = dFechaInicio.AddMonths(1).AddDays(-1);

            DateTime dFechaInicioSemana     = clsVarGlobal.dFecSystem;
            DateTime dFechaFinSemana        = clsVarGlobal.dFecSystem;

            bool lValor = true;

            if(cboObjetivoGeneral.SelectedIndex == -1 ||  cboSemanaObjetivo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un objetivo general.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }

            DataRow drFechaSeleccionado     = ((DataRowView)cboSemanaObjetivo.SelectedItem).Row;
            dFechaInicioSemana              = Convert.ToDateTime(drFechaSeleccionado["dFechaInicioSemana"]);
            dFechaFinSemana                 = Convert.ToDateTime(drFechaSeleccionado["dFechaFinSemana"]);

            if (cboObjetivoTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de objetivo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }

            if (!(dtpFechaEspecifica.Value >= dFechaInicioSemana && dtpFechaEspecifica.Value <= dFechaFinSemana))
            {
                MessageBox.Show("La fecha del objetivo debe estar dentro de la semana establecida del objetivo General", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }

            if (!(dtpFechaEspecifica.Value >= dFechaInicio && dtpFechaEspecifica.Value <= dFechaFin))
            {
                MessageBox.Show("La fecha del objetivo debe estar dentro del mes del plan de trabajo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }
            return lValor;
        }
        private void agregarDetalleCreditoCliente(List<clsDatosCreditoCliente> _lstDatosCreditoCliente)
        {
            List<clsDatosCreditoCliente> lstClienteFiltrado = _lstDatosCreditoCliente.Except(lstDatosCreditoCliente, new clsDatosCreditoClienteComparer()).ToList();

            lstDatosCreditoCliente.AddRange(lstClienteFiltrado);
            bsDatosCreditosCliente.ResetBindings(false);
            dtgDetalleAccionCliente.Refresh();
        }

        private void agregarDetalleCreditoCliente(clsDatosCreditoCliente _objDatosCreditoCliente)
        {
            bool lValida = lstDatosCreditoCliente.Any(item => item.idCliente == _objDatosCreditoCliente.idCliente && item.idCuenta == _objDatosCreditoCliente.idCuenta);
            if(!lValida)
            {
                lstDatosCreditoCliente.Add(_objDatosCreditoCliente);
            }
            bsDatosCreditosCliente.ResetBindings(false);
            dtgDetalleAccionCliente.Refresh();
        }

        private void eliminarDetalleCreditoCliente()
        {
            if (dtgDetalleAccionCliente.SelectedRows.Count > 0)
            {
                DialogResult drRespuesta = MessageBox.Show("Se eliminará el registro.\n ¿Está seguro de continuar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (drRespuesta == DialogResult.No)
                {
                    return;
                }
                foreach (DataGridViewRow dgvfila in dtgDetalleAccionCliente.SelectedRows)
                {
                    dtgDetalleAccionCliente.Rows.RemoveAt(dgvfila.Index);
                }
                dtgDetalleAccionCliente.Refresh();
            }
        }
        
        public void formatearGridDatosCreditoCliente()
        {
            foreach( DataGridViewColumn dgvColumna in dtgDetalleAccionCliente.Columns )
            {
                dgvColumna.Visible = false;
                dgvColumna.HeaderText = dgvColumna.Name;
            }

            dtgDetalleAccionCliente.Columns["idCuenta"].Visible             = true;
            dtgDetalleAccionCliente.Columns["cEstado"].Visible              = true;
            dtgDetalleAccionCliente.Columns["cNombre"].Visible              = true;
            dtgDetalleAccionCliente.Columns["idCliente"].Visible            = true;
            dtgDetalleAccionCliente.Columns["dFechaDesembolso"].Visible     = true;
            dtgDetalleAccionCliente.Columns["nFrecuencia"].Visible          = true;
            dtgDetalleAccionCliente.Columns["nMonto"].Visible               = true;
            dtgDetalleAccionCliente.Columns["nCuotas"].Visible              = true;
            dtgDetalleAccionCliente.Columns["cProducto"].Visible            = true;
            dtgDetalleAccionCliente.Columns["nMontoCuota"].Visible          = true;
            dtgDetalleAccionCliente.Columns["nAtraso"].Visible              = true;
            dtgDetalleAccionCliente.Columns["cDocumentoID"].Visible         = true;
            dtgDetalleAccionCliente.Columns["cDireccion"].Visible           = true;
            dtgDetalleAccionCliente.Columns["cCodCliente"].Visible          = true;
            dtgDetalleAccionCliente.Columns["cMoneda"].Visible              = true;
            
            dtgDetalleAccionCliente.Columns["idCuenta"].HeaderText          = "Nro. Cuenta";
            dtgDetalleAccionCliente.Columns["cEstado"].HeaderText           = "Estado";
            dtgDetalleAccionCliente.Columns["cNombre"].HeaderText           = "Nombre";
            dtgDetalleAccionCliente.Columns["idCliente"].HeaderText         = "Cod. Cliente";
            dtgDetalleAccionCliente.Columns["dFechaDesembolso"].HeaderText  = "Fecha Desembolso";
            dtgDetalleAccionCliente.Columns["nFrecuencia"].HeaderText       = "Frecuencia";
            dtgDetalleAccionCliente.Columns["nMonto"].HeaderText            = "Monto";
            dtgDetalleAccionCliente.Columns["nCuotas"].HeaderText           = "Cuotas";
            dtgDetalleAccionCliente.Columns["cProducto"].HeaderText         = "Producto";
            dtgDetalleAccionCliente.Columns["nMontoCuota"].HeaderText       = "Monto de cuota";
            dtgDetalleAccionCliente.Columns["nAtraso"].HeaderText           = "Atraso";
            dtgDetalleAccionCliente.Columns["cDocumentoID"].HeaderText      = "Nro. Documento";
            dtgDetalleAccionCliente.Columns["cDireccion"].HeaderText        = "Dirección";
            dtgDetalleAccionCliente.Columns["cCodCliente"].HeaderText       = "Cod. Comp. Cliente";
            dtgDetalleAccionCliente.Columns["cMoneda"].HeaderText           = "Moneda";

            dtgDetalleAccionCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private clsPlanTrabajoDetalleAccion obtenerDetalleAccion()
        {
            objPlanTrabajoDetalleAccion.idPlanTrabajoRecuperacion           = idPlanTrabajoRecuperacion;
            objPlanTrabajoDetalleAccion.idPlanTrabajoDetalleAccion          = idPlanTrabajoDetalleAccion;
            objPlanTrabajoDetalleAccion.cPlanTrabajoDetalleAccion           = txtDetalleAccion.Text;
            objPlanTrabajoDetalleAccion.idPlanTrabajoObjetivo               = objPlanTrabajoObjetivoEspecifico.idPlanTrabajoObjetivo;
            objPlanTrabajoDetalleAccion.idPlanTrabajoObjetivoGeneral        = objPlanTrabajoObjetivoEspecifico.idPlanTrabajoObjetivoPadre;
            objPlanTrabajoDetalleAccion.idPlanTrabajoAccion                 = Convert.ToInt32(cboAccionResumen.SelectedValue);
            objPlanTrabajoDetalleAccion.cPlanTrabajoObjetivo                = objPlanTrabajoObjetivoEspecifico.cPlanTrabajoResumenObjetivo;
            objPlanTrabajoDetalleAccion.cPlanTrabajoAccion                  = cboAccionResumen.Text;
            objPlanTrabajoDetalleAccion.dFechaAccion                        = dtpFechaEspecifica.Value;
            objPlanTrabajoDetalleAccion.lVigente                            = true;
            objPlanTrabajoDetalleAccion.lstDatosCreditoCliente              = lstDatosCreditoCliente;

            return objPlanTrabajoDetalleAccion;
        }

        private bool validarDetalleAccion()
        {
            DateTime dFechaInicio = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            DateTime dFechaFin = dFechaInicio.AddMonths(1).AddDays(-1);
            bool lValor = true;
            if(cboAccionResumen.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un resumen de detalle de acción del Objetivo Específico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }
            if (String.IsNullOrEmpty(txtDetalleAccion.Text))
            {
                MessageBox.Show("Ingrese una descripción del detalle de acción del Objetivo Específico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }
            return lValor;
        }

        private clsPlanTrabajoZonaVisita obtenerZonaVisita()
        {
            objPlanTrabajoZonaVisita.idPlanTrabajoZonaVisita        = idPlanTrabajoZonaVisita;
            objPlanTrabajoZonaVisita.idPlanTrabajoRecuperacion      = idPlanTrabajoRecuperacion;
            objPlanTrabajoZonaVisita.idPlanTrabajoObjetivo          = objPlanTrabajoObjetivoEspecifico.idObjetivoTipo;
            objPlanTrabajoZonaVisita.cPlanTrabajoObjetivo           = objPlanTrabajoObjetivoEspecifico.cPlanTrabajoResumenObjetivo;
            objPlanTrabajoZonaVisita.dFechaVisita                   = dtpFechaEspecifica.Value;
            objPlanTrabajoZonaVisita.idAgencia                      = Convert.ToInt32(cboAgencias.SelectedValue);
            objPlanTrabajoZonaVisita.cAgencia                       = cboAgencias.Text;
            objPlanTrabajoZonaVisita.idZona                         = Convert.ToInt32(cboZona.SelectedValue);
            objPlanTrabajoZonaVisita.cZona                          = cboZona.Text;
            objPlanTrabajoZonaVisita.idDistrito                     = Convert.ToInt32(cboDistrito.SelectedValue);
            objPlanTrabajoZonaVisita.cDistrito                      = cboDistrito.Text;
            objPlanTrabajoZonaVisita.cDescripcionZonaVisita         = txtDescripcionZonaVisita.Text;
            objPlanTrabajoZonaVisita.lVigente                       = true;

            return objPlanTrabajoZonaVisita;
        }

        private bool validarZonaVisita()
        {
            DateTime dFechaInicio = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            DateTime dFechaFin = dFechaInicio.AddMonths(1).AddDays(-1);
            bool lValor = true;
            if (!(dtpFechaEspecifica.Value >= dFechaInicio && dtpFechaEspecifica.Value <= dFechaFin))
            {
                MessageBox.Show("La fecha de visita debe estar dentro del mes del plan de trabajo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }

            if (cboZona.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la zona de visita del detalle del plan de trabajo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }
            if (cboAgencias.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la agencia de visita del detalle del plan de trabajo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }
            if (cboAgencias.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la distrito de visita del detalle del plan de trabajo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }
            if (String.IsNullOrEmpty(txtDescripcionZonaVisita.Text))
            {
                MessageBox.Show("Ingrese una descripción de la zona de visita.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }
            return lValor;
        }

        private void cargarDatosAgencia()
        {
            DataRow drAgencia           = (cboAgencias.SelectedItem == null) ? null : ((DataRowView)cboAgencias.SelectedItem).Row;
            int idUbigeoAgencia         = (drAgencia == null) ? 0 : Convert.ToInt32(drAgencia["idUbigeo"]);
            DataTable dtUbigeoPadre     = objCNPlanTrabajo.CNObtenerUbigeoPadreUbicacion(idUbigeoAgencia);
            int idUbigeoPadreDistrito   = (dtUbigeoPadre.Rows.Count > 0) ? Convert.ToInt32(dtUbigeoPadre.Rows[1]["idUbigeo"]) : 0;

            cboDistrito.SelectedIndexChanged -= new EventHandler(cboDistrito_SelectedIndexChanged);
            if (idUbigeoPadreDistrito != 0)
                cboDistrito.CargarUbigeo(idUbigeoPadreDistrito);
            cboDistrito.SelectedIndexChanged += new EventHandler(cboDistrito_SelectedIndexChanged);
        }

        private void cargarDatosZona()
        {
            int idZonaSeleccionada      = Convert.ToInt32(cboZona.SelectedValue);
            int idAgenciaDefecto        = Convert.ToInt32(dtDatosUsuarioZona.Rows[0]["idAgencia"]);
            cboAgencias.FiltrarPorZonaUbigeo(idZonaSeleccionada);
            cboAgencias.SelectedIndex   = -1;
        }

        private List<clsDatosCreditoClientePlanTrabajo> filtrarPlanTrabajoDetalleAccionCliente()
        {
            List<clsDatosCreditoCliente> lstCliente = objPlanTrabajoDetalleAccion.lstDatosCreditoCliente;
            
            List<clsDatosCreditoClientePlanTrabajo> lstClienteVinculado = lstCliente.OfType<clsDatosCreditoCliente>().Select(item => new clsDatosCreditoClientePlanTrabajo
            {
                    idCuenta                            = item.idCuenta,
                    idCliente                           = item.idCliente,
                    idPlanTrabajoRecuperacion           = objPlanTrabajoDetalleAccion.idPlanTrabajoRecuperacion,
                    idPlanTrabajoDetalleAccion          = objPlanTrabajoDetalleAccion.idPlanTrabajoDetalleAccion,
                    idPlanTrabajoObjetivoGeneral        = objPlanTrabajoDetalleAccion.idPlanTrabajoObjetivoGeneral,
                    idPlanTrabajoObjetivoEspecifico     = objPlanTrabajoDetalleAccion.idPlanTrabajoObjetivo,
                    dFechaAccion                        = objPlanTrabajoDetalleAccion.dFechaAccion,

                    idEstado                            = item.idEstado,
                    cEstado                             = item.cEstado,
                    cNombre                             = item.cNombre,
                    dFechaDesembolso                    = item.dFechaDesembolso,
                    nFrecuencia                         = item.nFrecuencia,
                    nMonto                              = item.nMonto,
                    nCuotas                             = item.nCuotas,
                    idMoneda                            = item.idMoneda,
                    idProducto                          = item.idProducto,
                    cProducto                           = item.cProducto,
                    nMontoCuota                         = item.nMontoCuota,
                    nAtraso                             = item.nAtraso,
                    cDocumentoID                        = item.cDocumentoID,
                    cDireccion                          = item.cDireccion,
                    cCodCliente                         = item.cCodCliente,
                    cMoneda                             = item.cMoneda,
                    idTipoDocumento                     = item.idTipoDocumento,
                    lCoberturaSegDesg                   = item.lCoberturaSegDesg,
                    lSeleccionado                       = item.lSeleccionado,
                
            }).ToList();

            return lstClienteVinculado;
        }
        #endregion

        #region Enumeradores
        private enum ObjetivoTipo
        {
            GENERAL = 1,
            ESPECIFICO = 2
        }
        private enum RolFormularioUsuario
        {
            ELABORADOR          = 1,
            ELABORADOR_REVISOR  = 2,
            REVISOR             = 3
        }
        #endregion
    }
}
