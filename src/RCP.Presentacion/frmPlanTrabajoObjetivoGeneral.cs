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
    public partial class frmPlanTrabajoObjetivoGeneral : frmBase
    {
        #region Variables Globales
        public clsPlanTrabajoObjetivo objPlanTrabajoObjetivoGeneral { get; set; }
        private clsCNPlanTrabajo objCNPlanTrabajo { get; set; }
        private int idPlanTrabajoRecuperacion { get; set; }
        private int idPlanTrabajoObjetivo { get; set; }
        private List<clsResumenObjetivoSemana> lstResumenObjetivoSemana { get; set; }
        private DataTable dtNombreSemana { get; set; }
        private bool lBloqueoEdicion { get; set; }
        #endregion
        public frmPlanTrabajoObjetivoGeneral()
        {
            InitializeComponent();
            cargarComponentes();
        }
        public frmPlanTrabajoObjetivoGeneral(int _idPlanTrabajoRecuperacion, List<clsResumenObjetivoSemana> _lstResumenObjetivoSemana, bool _lBloqueoEdicion = false)
        {
            InitializeComponent();
            cargarComponentes(_idPlanTrabajoRecuperacion, _lstResumenObjetivoSemana);
            lBloqueoEdicion = _lBloqueoEdicion;
        }
        #region Eventos
        private void frmPlanTrabajoObjetivoGeneral_Load(object sender, EventArgs e)
        {
            if (objPlanTrabajoObjetivoGeneral.idObjetivoTipo != 0)
            {
                asignarDatos();
            }
            else
            {
                limpiar();
            }
            if(lBloqueoEdicion)
            {
                bloquearEdicion();
            }
        }

        private void cboObjetivoTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            objPlanTrabajoObjetivoGeneral = obtenerObjetivosGenerales();
        }

        private void cboSemana_SelectedIndexChanged(object sender, EventArgs e)
        {
            objPlanTrabajoObjetivoGeneral = obtenerObjetivosGenerales();
        }

        private void cboObjetivoResumen_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idObjetivoGeneralSeleccionado = Convert.ToInt32(cboObjetivoResumen.SelectedValue);
            DataTable dtSemanaFiltro    = dtNombreSemana;
            cboSemana.DataSource        = dtSemanaFiltro;
            cboSemana.ValueMember       = dtSemanaFiltro.Columns["idSemana"].ColumnName;
            cboSemana.DisplayMember     = dtSemanaFiltro.Columns["cSemana"].ColumnName;

            objPlanTrabajoObjetivoGeneral = obtenerObjetivosGenerales();
        }

        private void txtDescripcionObjetivoGeneral_Leave(object sender, EventArgs e)
        {
            objPlanTrabajoObjetivoGeneral = obtenerObjetivosGenerales();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                objPlanTrabajoObjetivoGeneral = obtenerObjetivosGenerales();

                string xmlPlanTrabajoObjetivoGeneral = objPlanTrabajoObjetivoGeneral.GetXml();

                DataTable dtResultado = objCNPlanTrabajo.CNRegistrarActualizarObjetivoGeneralPlanTrabajo(xmlPlanTrabajoObjetivoGeneral, clsVarGlobal.User.idUsuario, clsVarGlobal.dFecSystem);
                if (dtResultado.Rows.Count > 0)
                {
                    
                    if (Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) == 1)
                    {
                        idPlanTrabajoObjetivo           = Convert.ToInt32(dtResultado.Rows[0]["idPlanTrabajoObjetivo"]);
                        objPlanTrabajoObjetivoGeneral   = obtenerObjetivosGenerales();
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
                    MessageBox.Show("Ocurrió un problema al momento de registrar el objetivo general del plan de trabajo, inténtelo de nuevo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            objPlanTrabajoObjetivoGeneral = new clsPlanTrabajoObjetivo();
            this.Dispose();
        }
        #endregion

        #region Metodos
        public void cargarDatos(clsPlanTrabajoObjetivo _objPlanTrabajoObjetivo)
        {
            idPlanTrabajoObjetivo           = _objPlanTrabajoObjetivo.idPlanTrabajoObjetivo;
            objPlanTrabajoObjetivoGeneral   = _objPlanTrabajoObjetivo;
        }
        private void cargarComponentes()
        {
            idPlanTrabajoRecuperacion = 0;
            habilitarEventHandler(false);
            objCNPlanTrabajo = new clsCNPlanTrabajo();
            objPlanTrabajoObjetivoGeneral = new clsPlanTrabajoObjetivo();

            DataTable dtObjetivoTipo = objCNPlanTrabajo.CNListarObjetivoTipo();
            DataTable dtResumenObjetivo = objCNPlanTrabajo.CNListarObjetivoResumen(0,(int)ObjetivoTipo.GENERAL);
            dtNombreSemana = objCNPlanTrabajo.CNListarNombreSemana();

            lstResumenObjetivoSemana = new List<clsResumenObjetivoSemana>();

            cboObjetivoTipo.DataSource      = dtObjetivoTipo;
            cboObjetivoTipo.DisplayMember   = dtObjetivoTipo.Columns["cObjetivoTipo"].ColumnName;
            cboObjetivoTipo.ValueMember     = dtObjetivoTipo.Columns["idObjetivoTipo"].ColumnName;
            cboObjetivoTipo.SelectedValue   = (int)ObjetivoTipo.GENERAL;

            cboSemana.DataSource        = dtNombreSemana;
            cboSemana.DisplayMember     = dtNombreSemana.Columns["cSemana"].ColumnName;
            cboSemana.ValueMember       = dtNombreSemana.Columns["idSemana"].ColumnName;

            cboObjetivoResumen.DataSource       = dtResumenObjetivo;
            cboObjetivoResumen.ValueMember      = dtResumenObjetivo.Columns["idPlanTrabajoResumenObjetivo"].ColumnName;
            cboObjetivoResumen.DisplayMember    = dtResumenObjetivo.Columns["cPlanTrabajoResumenObjetivo"].ColumnName;
            cboObjetivoResumen.SelectedIndex    = -1;

            habilitarEventHandler(true);
        }

        private void cargarComponentes(int _idPlanTrabajoRecuperacion, List<clsResumenObjetivoSemana> _lstResumenObjetivoSemana)
        {
            idPlanTrabajoRecuperacion       = _idPlanTrabajoRecuperacion;
            idPlanTrabajoObjetivo           = 0;
            habilitarEventHandler(false);
            objCNPlanTrabajo                = new clsCNPlanTrabajo();
            objPlanTrabajoObjetivoGeneral   = new clsPlanTrabajoObjetivo();

            DataTable dtObjetivoTipo        = objCNPlanTrabajo.CNListarObjetivoTipo();
            dtNombreSemana                  = objCNPlanTrabajo.CNListarNombreSemana();
            DataTable dtResumenObjetivo     = objCNPlanTrabajo.CNListarObjetivoResumen(0,(int)ObjetivoTipo.GENERAL);

            lstResumenObjetivoSemana        = _lstResumenObjetivoSemana;

            cboObjetivoTipo.DataSource      = dtObjetivoTipo;
            cboObjetivoTipo.DisplayMember   = dtObjetivoTipo.Columns["cObjetivoTipo"].ColumnName;
            cboObjetivoTipo.ValueMember     = dtObjetivoTipo.Columns["idObjetivoTipo"].ColumnName;
            cboObjetivoTipo.SelectedValue   = (int)ObjetivoTipo.GENERAL;

            cboSemana.DataSource            = dtNombreSemana;
            cboSemana.DisplayMember         = dtNombreSemana.Columns["cSemana"].ColumnName;
            cboSemana.ValueMember           = dtNombreSemana.Columns["idSemana"].ColumnName;

            cboObjetivoResumen.DataSource       = dtResumenObjetivo;
            cboObjetivoResumen.ValueMember      = dtResumenObjetivo.Columns["idPlanTrabajoResumenObjetivo"].ColumnName;
            cboObjetivoResumen.DisplayMember    = dtResumenObjetivo.Columns["cPlanTrabajoResumenObjetivo"].ColumnName;
            cboObjetivoResumen.SelectedIndex    = -1;

            habilitarEventHandler(true);
        }

        private void limpiar()
        {
            habilitarEventHandler(false);

            objPlanTrabajoObjetivoGeneral       = new clsPlanTrabajoObjetivo();
            cboObjetivoTipo.SelectedValue       = (int)ObjetivoTipo.GENERAL;
            cboSemana.SelectedIndex             = -1;
            txtDescripcionObjetivoGeneral.Text  = String.Empty;
            habilitarEventHandler(true);
        }

        private void habilitarEventHandler(bool lValor)
        {
            if(!lValor)
            {
                cboObjetivoTipo.SelectedIndexChanged    -= new EventHandler(cboObjetivoTipo_SelectedIndexChanged);
                cboSemana.SelectedIndexChanged          -= new EventHandler(cboSemana_SelectedIndexChanged);
                cboObjetivoResumen.SelectedIndexChanged -= new EventHandler(cboObjetivoResumen_SelectedIndexChanged);
                txtDescripcionObjetivoGeneral.Leave     -= new EventHandler(txtDescripcionObjetivoGeneral_Leave);
            }
            else
            {
                cboObjetivoTipo.SelectedIndexChanged    += new EventHandler(cboObjetivoTipo_SelectedIndexChanged);
                cboSemana.SelectedIndexChanged          += new EventHandler(cboSemana_SelectedIndexChanged);
                cboObjetivoResumen.SelectedIndexChanged += new EventHandler(cboObjetivoResumen_SelectedIndexChanged);
                txtDescripcionObjetivoGeneral.Leave     += new EventHandler(txtDescripcionObjetivoGeneral_Leave);
            }
        }

        private clsPlanTrabajoObjetivo obtenerObjetivosGenerales()
        {

            string cSemanaNombre = (cboSemana.SelectedItem == null) ? "" : Convert.ToString(((DataRowView)cboSemana.SelectedItem).Row["cSemanaNombre"]);

            objPlanTrabajoObjetivoGeneral.idPlanTrabajoRecuperacion         = idPlanTrabajoRecuperacion;
            objPlanTrabajoObjetivoGeneral.idPlanTrabajoObjetivo             = idPlanTrabajoObjetivo;
            objPlanTrabajoObjetivoGeneral.cDescripcionPlanTrabajoObjetivo   = txtDescripcionObjetivoGeneral.Text;
            objPlanTrabajoObjetivoGeneral.idObjetivoTipo                    = Convert.ToInt32(cboObjetivoTipo.SelectedValue);
            objPlanTrabajoObjetivoGeneral.cObjetivoTipo                     = Convert.ToString(cboObjetivoTipo.Text);
            objPlanTrabajoObjetivoGeneral.idPlanTrabajoResumenObjetivo      = Convert.ToInt32(cboObjetivoResumen.SelectedValue);
            objPlanTrabajoObjetivoGeneral.cPlanTrabajoResumenObjetivo       = cboObjetivoResumen.Text + " - "+ cSemanaNombre;
            objPlanTrabajoObjetivoGeneral.idPlanTrabajoObjetivoPadre        = 0;
            objPlanTrabajoObjetivoGeneral.nSemana                           = Convert.ToInt32(cboSemana.SelectedValue);
            objPlanTrabajoObjetivoGeneral.cSemana                           = cboSemana.Text;
            objPlanTrabajoObjetivoGeneral.nDia                              = 0;
            objPlanTrabajoObjetivoGeneral.dFechaRegistro                    = clsVarGlobal.dFecSystem;
            objPlanTrabajoObjetivoGeneral.lVigente                          = true;

            return objPlanTrabajoObjetivoGeneral;
        }
        private void asignarDatos()
        {
            habilitarEventHandler(false);
            cboObjetivoTipo.SelectedValue       = objPlanTrabajoObjetivoGeneral.idObjetivoTipo;
            cboSemana.SelectedValue             = objPlanTrabajoObjetivoGeneral.nSemana;
            cboObjetivoResumen.SelectedValue    = objPlanTrabajoObjetivoGeneral.idPlanTrabajoResumenObjetivo;
            txtDescripcionObjetivoGeneral.Text  = objPlanTrabajoObjetivoGeneral.cDescripcionPlanTrabajoObjetivo;
            habilitarEventHandler(true);
        }
        private bool validar()
        {
            bool lValor = true;
            if (cboObjetivoTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un tipo de objetivo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }
            if (cboSemana.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la semana del mes al que pertenece el objetivo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }
            if (cboSemana.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el resumen adecuado para el objetivo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }
            return lValor;
        }

        private void bloquearEdicion()
        {
            cboObjetivoTipo.Enabled                 = false;
            cboObjetivoResumen.Enabled              = false;
            cboSemana.Enabled                       = false;
            txtDescripcionObjetivoGeneral.Enabled   = false;
            btnAceptar.Enabled                      = false;
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
