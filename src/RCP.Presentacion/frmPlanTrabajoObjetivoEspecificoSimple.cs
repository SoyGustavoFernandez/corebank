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
    public partial class frmPlanTrabajoObjetivoEspecificoSimple : frmBase
    {
        
        #region Variables Globales
        public clsPlanTrabajoObjetivo objPlanTrabajoObjetivoEspecifico { get; set; }
        private clsCNPlanTrabajo objCNPlanTrabajo { get; set; }
        private List<clsPlanTrabajoObjetivo> lstObjetivoGeneral { get; set; }
        private DataTable dtSemanaMes { get; set; }
        private int idPlanTrabajoRecuperacion { get; set; }
        private int idPlanTrabajoObjetivo { get; set; }
        private bool lBloqueoEdicion { get; set; }

        #endregion
        public frmPlanTrabajoObjetivoEspecificoSimple()
        {
            InitializeComponent();
            cargarComponentes();
            asignarDatosDefecto();
        }

        public frmPlanTrabajoObjetivoEspecificoSimple(int _idPlanTrabajoRecuperacion, List<clsPlanTrabajoObjetivo> _lstObjetivoGeneral, bool _lBloqueoEdicion = false)
        {
            InitializeComponent();
            cargarComponentes(_idPlanTrabajoRecuperacion, _lstObjetivoGeneral);
            asignarDatosDefecto();
            lBloqueoEdicion = _lBloqueoEdicion;
        }
        #region Eventos
        private void frmPlanTrabajoObjetivoEspecifico_Load(object sender, EventArgs e)
        {
            if (objPlanTrabajoObjetivoEspecifico.idPlanTrabajoObjetivo == 0)
            {
                limpiar();
            }
            else
            {
                asignarDatos();
            }

            if(lBloqueoEdicion)
            {
                bloquearEdicion();
            }
        }

        private void cboObjetivoTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            objPlanTrabajoObjetivoEspecifico = obtenerObjetivosEspecificos();
        }

        private void cboObjetivoGeneral_SelectedIndexChanged(object sender, EventArgs e)
        {
            habilitarEventHandler(false);
            cargarDatosObjetivoGeneral();
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
            if (validar())
            {
                objPlanTrabajoObjetivoEspecifico = obtenerObjetivosEspecificos();

                string xmlPlanTrabajoObjetivoEspecifico     = objPlanTrabajoObjetivoEspecifico.GetXml();

                DataTable dtResultado = objCNPlanTrabajo.CNActualizarObjetivoEspecificoPlanTrabajo(objPlanTrabajoObjetivoEspecifico.idPlanTrabajoObjetivoPadre, xmlPlanTrabajoObjetivoEspecifico, objPlanTrabajoObjetivoEspecifico.idPlanTrabajoObjetivo);
                if(dtResultado.Rows.Count > 0)
                {
                    if(Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) == 1)
                    {
                        idPlanTrabajoObjetivo               = Convert.ToInt32(dtResultado.Rows[0]["idPlanTrabajoObjetivo"]);
                        objPlanTrabajoObjetivoEspecifico    = obtenerObjetivosEspecificos();

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
                    MessageBox.Show("Ocurrió un problema al momento de registrar el objetivo específico del plan de trabajo, inténtelo de nuevo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            objPlanTrabajoObjetivoEspecifico = new clsPlanTrabajoObjetivo();
            this.Dispose();
        }
        private void frmPlanTrabajoObjetivoEspecificoSimple_FormClosing(object sender, FormClosingEventArgs e)
        {
            objPlanTrabajoObjetivoEspecifico = new clsPlanTrabajoObjetivo();
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

        private void cargarComponentes(int _idPlanTrabajoRecuperacion, List<clsPlanTrabajoObjetivo> _lstObjetivoGeneral)
        {
            habilitarEventHandler(false);
            idPlanTrabajoRecuperacion   = _idPlanTrabajoRecuperacion;
            idPlanTrabajoObjetivo       = 0;

            objCNPlanTrabajo                    = new clsCNPlanTrabajo();
            objPlanTrabajoObjetivoEspecifico    = new clsPlanTrabajoObjetivo();

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
            }
            else
            {
                cboObjetivoTipo.SelectedIndexChanged    += new EventHandler(cboObjetivoTipo_SelectedIndexChanged);
                cboObjetivoGeneral.SelectedIndexChanged += new EventHandler(cboObjetivoGeneral_SelectedIndexChanged);
                cboObjetivoResumen.SelectedIndexChanged += new EventHandler(cboObjetivoResumen_SelectedIndexChanged);
                dtpFechaEspecifica.Leave                += new EventHandler(dtpFechaEspecifica_Leave);
                txtDescripcionObjetivoGeneral.Leave     += new EventHandler(txtDescripcionObjetivoGeneral_Leave);
                cboObjetivoGeneral.SelectedIndexChanged += new EventHandler(cboObjetivoGeneral_SelectedIndexChanged);
            }
        }

        private clsPlanTrabajoObjetivo obtenerObjetivosEspecificos()
        {
            clsPlanTrabajoObjetivo objObjetivoGeneral = ((clsPlanTrabajoObjetivo)cboObjetivoGeneral.SelectedItem == null) ? new clsPlanTrabajoObjetivo() : (clsPlanTrabajoObjetivo)cboObjetivoGeneral.SelectedItem;

            objPlanTrabajoObjetivoEspecifico.idPlanTrabajoRecuperacion          =  (objPlanTrabajoObjetivoEspecifico.idPlanTrabajoRecuperacion != 0) ? objPlanTrabajoObjetivoEspecifico.idPlanTrabajoRecuperacion : idPlanTrabajoRecuperacion;
            objPlanTrabajoObjetivoEspecifico.idPlanTrabajoObjetivo              = (objPlanTrabajoObjetivoEspecifico.idPlanTrabajoObjetivo != 0) ? objPlanTrabajoObjetivoEspecifico.idPlanTrabajoObjetivo : idPlanTrabajoObjetivo;
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
            cboObjetivoGeneral.SelectedValue    = objPlanTrabajoObjetivoEspecifico.idPlanTrabajoObjetivoPadre;
            cargarDatosObjetivoGeneral();
            cboObjetivoTipo.SelectedValue       = objPlanTrabajoObjetivoEspecifico.idObjetivoTipo;
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
            habilitarEventHandler(true);
        }

        private bool validar()
        {
            DateTime dFechaInicio   = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            DateTime dFechaFin      = dFechaInicio.AddMonths(1).AddDays(-1);

            DateTime dFechaInicioSemana     = clsVarGlobal.dFecSystem;
            DateTime dFechaFinSemana        = clsVarGlobal.dFecSystem;

            DataRow drFechaSeleccionado     = ((DataRowView)cboSemanaObjetivo.SelectedItem).Row;
            dFechaInicioSemana              = Convert.ToDateTime(drFechaSeleccionado["dFechaInicioSemana"]);
            dFechaFinSemana                 = Convert.ToDateTime(drFechaSeleccionado["dFechaFinSemana"]);

            bool lValor = true;
            if (cboObjetivoTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de objetivo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }

            if(!(dtpFechaEspecifica.Value >= dFechaInicioSemana && dtpFechaEspecifica.Value <= dFechaFinSemana))
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


        private void bloquearEdicion()
        {
            cboObjetivoTipo.Enabled                 = false;
            cboObjetivoGeneral.Enabled              = false;
            cboSemanaObjetivo.Enabled               = false;
            cboObjetivoResumen.Enabled              = false;
            dtpFechaEspecifica.Enabled              = false;
            txtDescripcionObjetivoGeneral.Enabled   = false;
            btnAceptar.Enabled                      = false;
        }

        private void cargarDatosObjetivoGeneral()
        {
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
        }
        #endregion

        #region Enumeradores
        private enum ObjetivoTipo
        {
            GENERAL     = 1,
            ESPECIFICO  = 2
        }
        #endregion
    }
}
