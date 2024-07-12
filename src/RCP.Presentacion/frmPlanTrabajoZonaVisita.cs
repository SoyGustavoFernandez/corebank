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
    public partial class frmPlanTrabajoZonaVisita : frmBase
    {
        #region Variables Globales
        public DataTable dtDatosUsuarioZona { get; set; }
        public clsPlanTrabajoZonaVisita objPlanTrabajoZonaVisita { get; set; }
        private RolFormularioUsuario eRolActivo { get; set; }
        private clsCNPlanTrabajo objCNPlanTrabajo { get; set; }
        private List<clsPlanTrabajoObjetivo> lstObjetivoEspecifico { get; set; }
        private int idPlanTrabajoRecuperacion { get; set; }
        private int idPlanTrabajoZonaVisita { get; set; }
        private bool lBloqueoEdicion { get; set; }
        #endregion
        public frmPlanTrabajoZonaVisita()
        {
            InitializeComponent();
            cargarComponentes();
        }
        public frmPlanTrabajoZonaVisita(int _idPlanTrabajoRecuperacion, List<clsPlanTrabajoObjetivo> _lstObjetivoEspecifico, int idRolActivo, bool _lBloqueEdicion = false)
        {
            InitializeComponent();
            cargarComponentes(_idPlanTrabajoRecuperacion, _lstObjetivoEspecifico, idRolActivo);
            lBloqueoEdicion = _lBloqueEdicion;
        }

        #region Eventos
        private void frmPlanTrabajoZonaVisita_Load(object sender, EventArgs e)
        {
            if(objPlanTrabajoZonaVisita.idPlanTrabajoZonaVisita == 0)
            {
                limpiar();
                asignarDatosDefecto();
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

        private void dtpFechaVisita_Leave(object sender, EventArgs e)
        {
            objPlanTrabajoZonaVisita = obtenerZonaVisita();
        }

        private void cboObjetivoVisita_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsPlanTrabajoObjetivo objPlanTrabajoObjetivoSeleccionado = (cboObjetivoVisita.SelectedItem == null) ? new clsPlanTrabajoObjetivo() : (clsPlanTrabajoObjetivo)cboObjetivoVisita.SelectedItem;
            dtpFechaVisita.Value = (cboObjetivoVisita.SelectedItem == null) ? clsVarGlobal.dFecSystem : objPlanTrabajoObjetivoSeleccionado.dFechaEspecifica;
            objPlanTrabajoZonaVisita = obtenerZonaVisita();
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(validar())
            {
                objPlanTrabajoZonaVisita = obtenerZonaVisita();

                string xmlPlanTrabajoZonaVisita = objPlanTrabajoZonaVisita.GetXml();

                DataTable dtResultado = objCNPlanTrabajo.CNRegistrarActualizarZonaVisitaPlanTrabajo(objPlanTrabajoZonaVisita.idPlanTrabajoZonaVisita, objPlanTrabajoZonaVisita.idPlanTrabajoRecuperacion,
                                                                                                    objPlanTrabajoZonaVisita.idPlanTrabajoObjetivo, xmlPlanTrabajoZonaVisita, clsVarGlobal.dFecSystem);

                if (dtResultado.Rows.Count > 0)
                {

                    if (Convert.ToInt32(dtResultado.Rows[0]["idRegistro"]) == 1)
                    {
                        idPlanTrabajoZonaVisita     = Convert.ToInt32(dtResultado.Rows[0]["idPlanTrabajoZonaVisita"]);
                        objPlanTrabajoZonaVisita    = obtenerZonaVisita();
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
                    MessageBox.Show("Ocurrió un problema al momento de registrar la zona de visita del plan de trabajo, inténtelo de nuevo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                };
            }
            else
            {
                limpiar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            objPlanTrabajoZonaVisita = new clsPlanTrabajoZonaVisita();
            this.Dispose();
        }
        #endregion

        #region Metodos
        public void cargarDatos(clsPlanTrabajoZonaVisita _objPlanTrabajoZonaVisita)
        {
            objPlanTrabajoZonaVisita = _objPlanTrabajoZonaVisita;
        }

        private void cargarComponentes()
        {
            objCNPlanTrabajo               = new clsCNPlanTrabajo();
            objPlanTrabajoZonaVisita    = new clsPlanTrabajoZonaVisita();
            dtDatosUsuarioZona = objCNPlanTrabajo.CNObtenerDatosUsuarioZona(clsVarGlobal.User.idUsuario);
        }

        private void cargarComponentes(int _idPlanTrabajoRecuperacion, List<clsPlanTrabajoObjetivo> _lstObjetivoEspecifico, int _idRolActivo)
        {
            habilitarEventHandler(false);
            idPlanTrabajoRecuperacion   = _idPlanTrabajoRecuperacion;
            idPlanTrabajoZonaVisita     = 0;
            objCNPlanTrabajo            = new clsCNPlanTrabajo();
            objPlanTrabajoZonaVisita    = new clsPlanTrabajoZonaVisita();
            lstObjetivoEspecifico       = _lstObjetivoEspecifico;
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

            cboObjetivoVisita.DataSource    = lstObjetivoEspecifico;
            cboObjetivoVisita.DisplayMember = "cPlanTrabajoResumenObjetivo";
            cboObjetivoVisita.ValueMember   = "idPlanTrabajoObjetivo";
            habilitarEventHandler(true);

            dtDatosUsuarioZona = objCNPlanTrabajo.CNObtenerDatosUsuarioZona(clsVarGlobal.User.idUsuario);

        }


        private void limpiar()
        {
            habilitarEventHandler(false);

            dtpFechaVisita.Value                = clsVarGlobal.dFecSystem;
            cboObjetivoVisita.SelectedIndex     = -1;
            txtDescripcionZonaVisita.Text       = String.Empty;

            habilitarEventHandler(true);
        }

        private void habilitarEventHandler(bool lValor)
        {
            if(!lValor)
            {
                dtpFechaVisita.Leave                    -= new EventHandler(dtpFechaVisita_Leave);
                cboObjetivoVisita.SelectedIndexChanged  -= new EventHandler(cboObjetivoVisita_SelectedIndexChanged);
                cboZona.SelectedIndexChanged            -= new EventHandler(cboZona_SelectedIndexChanged);
                cboAgencias.SelectedIndexChanged        -= new EventHandler(cboAgencias_SelectedIndexChanged);
                cboDistrito.SelectedIndexChanged        -= new EventHandler(cboDistrito_SelectedIndexChanged);
                txtDescripcionZonaVisita.Leave          -= new EventHandler(txtDescripcionZonaVisita_Leave);
            }
            else
            {
                dtpFechaVisita.Leave                    += new EventHandler(dtpFechaVisita_Leave);
                cboObjetivoVisita.SelectedIndexChanged  += new EventHandler(cboObjetivoVisita_SelectedIndexChanged);
                cboZona.SelectedIndexChanged            += new EventHandler(cboZona_SelectedIndexChanged);
                cboAgencias.SelectedIndexChanged        += new EventHandler(cboAgencias_SelectedIndexChanged);
                cboDistrito.SelectedIndexChanged        += new EventHandler(cboDistrito_SelectedIndexChanged);
                txtDescripcionZonaVisita.Leave          += new EventHandler(txtDescripcionZonaVisita_Leave);
            }
        }

        private clsPlanTrabajoZonaVisita obtenerZonaVisita()
        {
            clsPlanTrabajoObjetivo objObjetivoEspecifico            = (cboObjetivoVisita.SelectedItem == null) ? new clsPlanTrabajoObjetivo() : (clsPlanTrabajoObjetivo)cboObjetivoVisita.SelectedItem;

            objPlanTrabajoZonaVisita.idPlanTrabajoRecuperacion      = (objPlanTrabajoZonaVisita.idPlanTrabajoRecuperacion != 0) ? objPlanTrabajoZonaVisita.idPlanTrabajoRecuperacion : idPlanTrabajoRecuperacion;
            objPlanTrabajoZonaVisita.idPlanTrabajoZonaVisita        = (objPlanTrabajoZonaVisita.idPlanTrabajoZonaVisita != 0) ? objPlanTrabajoZonaVisita.idPlanTrabajoZonaVisita: idPlanTrabajoZonaVisita;
            objPlanTrabajoZonaVisita.idPlanTrabajoObjetivo          = Convert.ToInt32(cboObjetivoVisita.SelectedValue);
            objPlanTrabajoZonaVisita.cPlanTrabajoObjetivo           = cboObjetivoVisita.Text;
            objPlanTrabajoZonaVisita.dFechaVisita                   = dtpFechaVisita.Value;
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

        private void asignarDatos()
        {
            
            habilitarEventHandler(false);
            cboZona.SelectedValue               = objPlanTrabajoZonaVisita.idZona;
            cargarDatosZona();
            cboAgencias.SelectedValue           = objPlanTrabajoZonaVisita.idAgencia;
            cargarDatosAgencia();
            cboDistrito.SelectedValue           = objPlanTrabajoZonaVisita.idDistrito;
            dtpFechaVisita.Value                = objPlanTrabajoZonaVisita.dFechaVisita;
            txtDescripcionZonaVisita.Text       = objPlanTrabajoZonaVisita.cDescripcionZonaVisita;
            habilitarEventHandler(true);

            cboZona.Enabled = (eRolActivo == RolFormularioUsuario.REVISOR || (eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR && cboZona.Items.Count > 1)) ? true : false;
            cboAgencias.Enabled = (eRolActivo == RolFormularioUsuario.REVISOR) ? true : (eRolActivo == RolFormularioUsuario.ELABORADOR) ? false : true;
        }

        private void asignarDatosDefecto()
        {
            

            int idZonaDefecto   = Convert.ToInt32(dtDatosUsuarioZona.Rows[0]["idZona"]);
            int idAgencia       = Convert.ToInt32(dtDatosUsuarioZona.Rows[0]["idAgencia"]);

            habilitarEventHandler(false);
            cboZona.SelectedValue       = idZonaDefecto;
            cargarDatosZona();
            cboAgencias.SelectedValue   = idAgencia;
            cargarDatosAgencia();
            habilitarEventHandler(true);

            cboZona.Enabled = (eRolActivo == RolFormularioUsuario.REVISOR || (eRolActivo == RolFormularioUsuario.ELABORADOR_REVISOR && cboZona.Items.Count > 1)) ? true : false;
            cboAgencias.Enabled = (eRolActivo == RolFormularioUsuario.REVISOR) ? true : (eRolActivo == RolFormularioUsuario.ELABORADOR) ? false : true;

        }

        private bool validar()
        {
            DateTime dFechaInicio = new DateTime(clsVarGlobal.dFecSystem.Year, clsVarGlobal.dFecSystem.Month, 1);
            DateTime dFechaFin = dFechaInicio.AddMonths(1).AddDays(-1);
            bool lValor = true;
            if (!(dtpFechaVisita.Value >= dFechaInicio && dtpFechaVisita.Value <= dFechaFin))
            {
                MessageBox.Show("La fecha de visita debe estar dentro del mes del plan de trabajo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }
            if (cboObjetivoVisita.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un objetivo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }
            
            if (cboZona.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la zona de visita del detalle del plan de trabajo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }
            if(cboAgencias.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione la agencia de visita del detalle del plan de trabajo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return lValor = false;
            }
            if (String.IsNullOrEmpty(txtDescripcionZonaVisita.Text))
            {
                MessageBox.Show("Ingrese una descripción de la zona de visita", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (idUbigeoPadreDistrito != 0)
                cboDistrito.CargarUbigeo(idUbigeoPadreDistrito);
        }

        private void cargarDatosZona()
        {
            int idZonaSeleccionada      = Convert.ToInt32(cboZona.SelectedValue);
            int idAgenciaDefecto        = Convert.ToInt32(dtDatosUsuarioZona.Rows[0]["idAgencia"]);
            cboAgencias.FiltrarPorZonaUbigeo(idZonaSeleccionada);
            cboAgencias.SelectedIndex   = -1;
            
        }

        private void bloquearEdicion()
        {
            cboObjetivoVisita.Enabled           = false;
            dtpFechaVisita.Enabled              = false;
            cboZona.Enabled                     = false;
            cboAgencias.Enabled                 = false;
            cboDistrito.Enabled                 = false;
            txtDescripcionZonaVisita.Enabled    = false;
            btnAceptar.Enabled                  = false;
        }



        #endregion

        #region Enumeradores
        private enum RolFormularioUsuario
        {
            ELABORADOR          = 1,
            ELABORADOR_REVISOR  = 2,
            REVISOR             = 3
        }
        #endregion
    }

}
