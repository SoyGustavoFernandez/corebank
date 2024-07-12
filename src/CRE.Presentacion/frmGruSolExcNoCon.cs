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
using GEN.CapaNegocio;
using EntityLayer;
using clsCNGrupoSolidario = CRE.CapaNegocio.clsCNGrupoSolidario;
#endregion

namespace CRE.Presentacion
{
    /**
     * 
     * GRUPO SOLIDARIO
     * SOLICITUD DE EXCEPCIONES NO CONTEMPLADAS
     * 
     */

    public partial class frmGruSolExcNoCon : frmBase
    {
        struct MensajesDelFormulario
        {
            public static string ERROR_EG_M4 = "La propuesta de crédito no puede tener más de 4 excepciones";
            public static string NO_DATOS_SOL = "No existen datos para solicitar.";
            public static string CONF_ANT_SOL = "¿Está seguro de Solicitar con estos datos la aprobación de la Excepción No Contemplada?, una vez hecha la solicitud no podrá editarla de nuevo.";
            public static string SUS_VAL = "Ingrese un sustento válido.";
            public static string SOL_EXT = "La solicitud se realizó correctamente.";
            public static string SOL_VALIDACION = "Debe completar los campos requeridos en DETALLES para el Reporte de Excepciones No Contempladas";
        }

        #region Variables
        private int idReglaNoContem = -1;
        private int idSolicitudCredGrupoSol = -1;
        private int idSolicitud = -1;
        private clsCNGrupoSolidario cngruposolidario = new clsCNGrupoSolidario();
        private clsCNSolicitud obCNSolicitud = new clsCNSolicitud();
        private DataSet dsMiembros = new DataSet();
        private int nExcepciones;
        private int idNivelAprob = 5;
        #endregion
        #region GettersSetters
        public int NExcepciones
        {
            get
            {
                return this.nExcepciones;
            }
            set
            {
                this.nExcepciones = value;
                this.txtExcepciones.Text = Convert.ToString(value);

                if (this.NExcepciones > 4)
                {
                    this.dtgReglas.DataSource = new DataTable();
                    MessageBox.Show("No se puede proceder con la solicitud de excepciones, porque hay mas de 4 excepciones automaticas/manuales generadas", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.activaBotonesReglas(false);
                }
                else { this.activaBotonesReglas(true); }
            }
        }
        #endregion
        #region Constructor
        public frmGruSolExcNoCon()
        {
            InitializeComponent();
        }
        #endregion
        #region Metodos
        private void activaBotonesReglas(bool lEstado)
        {
            this.btnOtrasRNC.Enabled = lEstado;
            this.btnDetalle1.Enabled = lEstado;
            this.btnSolicitar1.Enabled = lEstado;
        }
        private void cargarMiembros()
        {
            this.dsMiembros = cngruposolidario.solicitudMiembros(this.idSolicitudCredGrupoSol);
            this.NExcepciones = Convert.ToInt32(this.dsMiembros.Tables[2].Rows[0]["nExcepciones"]);
            if (!this.validarExcepciones())
            {
                return;
            }
            this.txtidSolicitudCredGrupoSol.Text = this.idSolicitudCredGrupoSol.ToString();

            if (this.dsMiembros.Tables.Count >= 1)
            {
                this.dtgMiembros.DataSource = this.dsMiembros.Tables[1];
                foreach (DataGridViewColumn oCol in this.dtgMiembros.Columns)
                {
                    oCol.Visible = false;
                    oCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                this.dtgMiembros.Columns["idSolicitud"].HeaderText = "Nº Solicitud";
                this.dtgMiembros.Columns["idSolicitud"].Visible = true;
                this.dtgMiembros.Columns["idSolicitud"].FillWeight = 40;
                DataGridViewImageColumn dtgcExcepciones = new DataGridViewImageColumn();
                dtgcExcepciones.Name = "imgRNC";
                dtgcExcepciones.HeaderText = "Excepciones";
                dtgcExcepciones.ValuesAreIcons = true;
                if (!this.dtgMiembros.Columns.Contains("imgRNC")) { this.dtgMiembros.Columns.Add(dtgcExcepciones); }
                this.dtgMiembros.Columns["imgRNC"].Visible = true;
                this.dtgMiembros.Columns["imgRNC"].DefaultCellStyle.NullValue = this.getIcon(Properties.Resources.loading);
                foreach (DataGridViewRow oRow in this.dtgMiembros.Rows)
                {
                    if (Convert.ToInt32(
                            oRow.Cells["nExcepciones"].Value != DBNull.Value
                            ? oRow.Cells["nExcepciones"].Value
                            : 0
                        ) > 0)
                    {
                        oRow.Cells["imgRNC"].Value = this.getIcon(Properties.Resources.warning);
                    }else
                        oRow.Cells["imgRNC"].Value = this.getIcon(Properties.Resources.success);
                }
                this.cargarReglas();
            }
        }
        private bool validarExcepciones()
        {
            if (this.NExcepciones > 4)
            {
                return false;
            }
            return true;
        }
        private Icon getIcon(Bitmap btmImg) { return Icon.FromHandle(((Bitmap)btmImg).GetHicon()); }
        private void cargarReglas()
        {
            if (this.NExcepciones > 4)
            {
                return;
            }

            if (this.dtgMiembros.SelectedRows.Count > 0)
            {
                DataRow drMiembro = ((DataRowView)dtgMiembros.SelectedRows[0].DataBoundItem).Row;
                this.idSolicitud = drMiembro.Table.Columns.Contains("idSolicitud") ? Convert.ToInt32(drMiembro["idSolicitud"]) : -1;
                this.txtidSolicitud.Text = this.idSolicitud.ToString();
                DataTable dtReglas = obCNSolicitud.listarReglaSolicitud(this.idSolicitud);
                dtgReglas.DataSource = dtReglas;

                if (dtReglas.Rows.Count > 0)
                {
                    this.btnOtrasRNC.Enabled = false;
                }
                else
                {
                    this.btnOtrasRNC.Enabled = true;
                }

                foreach (DataGridViewColumn oCol in this.dtgReglas.Columns)
                {
                    oCol.Visible = false;
                    oCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                    oCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                this.dtgReglas.Columns["nIdRegla"].HeaderText = "Nº de Regla";
                this.dtgReglas.Columns["nIdRegla"].Visible = true;
                this.dtgReglas.Columns["nIdRegla"].FillWeight = 20;
                this.dtgReglas.Columns["cMensajeError"].HeaderText = "Descripción";
                this.dtgReglas.Columns["cMensajeError"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dtgReglas.Columns["cMensajeError"].Visible = true;

                this.cargarRegla();
            }
        }
        private void cargarRegla()
        {
            if (this.dtgReglas.Rows.Count > 0)
            {
                DataRow drFila = ((DataRowView)dtgReglas.SelectedRows[0].DataBoundItem).Row;
                this.txtidRegla.Text = drFila["idExcepGen"].ToString();
                this.idReglaNoContem = Convert.ToInt32(drFila["nidRegla"]);
                this.txtMensajeError.Text = drFila["cMensajeError"].ToString();
                DataTable dtDatosENC = obCNSolicitud.obtenerDatosReporteRNC(this.idSolicitud, Convert.ToInt32(drFila["nIdRegla"]));
                if (dtDatosENC.Rows.Count > 0)
                {
                    this.txtSustento.Text = dtDatosENC.Rows[0]["cSustento"].ToString();
                }
                else
                {
                    this.txtSustento.Text = "";
                }
            }
            else
            {
                this.txtidRegla.Text = "";
                this.txtMensajeError.Text = "";
                this.txtSustento.Text = "";
            }
        }
        private void cargarMiembro()
        {
            if (this.dtgMiembros.SelectedRows.Count > 0)
            {
                DataRow oFila = ((DataRowView)this.dtgMiembros.SelectedRows[0].DataBoundItem).Row;
                this.txtNombreMiembro.Text = Convert.ToString(oFila["cNombre"]);
                this.txtExcepcionesAutomaticas.Text = Convert.ToString(oFila["nExcepcionesAutomaticas"]);
                this.txtExcepcionesManuales.Text = Convert.ToString(oFila["nExcepcionesManuales"]);
                this.NExcepciones = Convert.ToInt32(this.dsMiembros.Tables[2].Rows[0]["nExcepciones"]);
                this.txtRnc.Text = Convert.ToString(this.dsMiembros.Tables[2].Rows[0]["nReglaNoContempladas"]);
            }
            else
            {
                this.txtNombreMiembro.Text = "";
                this.txtExcepcionesAutomaticas.Text = "";
                this.txtExcepcionesManuales.Text = "";
                this.txtExcepciones.Text = "";
                this.txtRnc.Text = "";
            }
        }
        private bool yaSolicitoRegla()
        {
            var dtConsulta = obCNSolicitud.consultaSolReglaNoContemplada(
                        this.idSolicitud,
                        this.idReglaNoContem,
                        Convert.ToInt32(this.txtidRegla.Text),
                        idNivelAprob,
                        clsVarGlobal.User.idUsuario,
                        this.txtSustento.Text);
            int idFilas = Convert.ToInt32(dtConsulta.Rows[0]["filas"]);
            if (idFilas > 0)
                return true;
            else
                return false;
        }
        #endregion
        #region Eventos
        private void btnBusSolicitud1_Click(object sender, EventArgs e)
        {
            frmGruSolLisSolAgen frmselsolicitud = new frmGruSolLisSolAgen();
            frmselsolicitud.ShowDialog();
            this.idSolicitudCredGrupoSol = frmselsolicitud.idSolicitudCredGrupoSol;
            this.cargarMiembros();
        }
        private void btnDetalle1_Click(object sender, EventArgs e)
        {
            if (dtgReglas.SelectedRows.Count > 0 || this.txtidRegla.Text != "")
            {
                frmObtenerDatosReporteRNC obDatosReporte = new frmObtenerDatosReporteRNC(this.idSolicitud, this.idReglaNoContem);
                obDatosReporte.ShowDialog();
                this.txtSustento.Text = obDatosReporte.cSustento;
            }
        }
        private void btnSolicitar1_Click(object sender, EventArgs e)
        {
            if(this.NExcepciones > 4)
            {
                MessageBox.Show(
                    MensajesDelFormulario.ERROR_EG_M4,
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            if (dtgReglas.SelectedRows.Count > 0 || this.txtidRegla.Text != "")
            {
                if (String.IsNullOrEmpty(this.txtSustento.Text))
                {
                    MessageBox.Show(
                        MensajesDelFormulario.NO_DATOS_SOL,
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                DialogResult dlres = MessageBox.Show(
                    MensajesDelFormulario.CONF_ANT_SOL,
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (dlres == DialogResult.Yes)
                {
                    DataTable dtConsulta = new DataTable();
                    dtConsulta = obCNSolicitud.consultaSolReglaNoContemplada(
                        this.idSolicitud,
                        this.idReglaNoContem,
                        Convert.ToInt32(this.txtidRegla.Text),
                        idNivelAprob,
                        clsVarGlobal.User.idUsuario,
                        this.txtSustento.Text);
                    int idFilas = Convert.ToInt32(dtConsulta.Rows[0]["filas"]);

                    if (idFilas == 0)
                    {
                        if (this.txtSustento.Text.Length < 5)
                        {
                            MessageBox.Show(
                                MensajesDelFormulario.SUS_VAL,
                                "Información",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            DataTable dtSoli = obCNSolicitud.obtenerDatosReporteRNC(
                                this.idSolicitud,
                                this.idReglaNoContem);

                            if (dtSoli.Rows.Count > 0)
                            {
                                DataTable dtSolicitud = obCNSolicitud.insertarSolReglaNoContemplada(
                                        this.idSolicitud,
                                        this.idReglaNoContem,
                                        Convert.ToInt32(this.txtidRegla.Text),
                                        idNivelAprob,
                                        clsVarGlobal.User.idUsuario,
                                        this.txtSustento.Text);
                                MessageBox.Show(
                                    MensajesDelFormulario.SOL_EXT,
                                    "Éxito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                this.cargarMiembros();
                            }
                            else
                            {
                                MessageBox.Show(
                                    MensajesDelFormulario.SOL_VALIDACION,
                                    "Información",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }
        private void btnOtrasRNC_Click(object sender, EventArgs e)
        {
            if (this.NExcepciones >= 4)
            {
                MessageBox.Show(
                    MensajesDelFormulario.ERROR_EG_M4,
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            this.txtidRegla.Text = Convert.ToString(clsVarApl.dicVarGen["idExcepGenRNC"]);
            this.txtMensajeError.Text = "Otras Excepciones No Contempladas.";
            this.idReglaNoContem = Convert.ToInt32(clsVarApl.dicVarGen["idRNC"]);
        }
        private void dtgMiembros_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgMiembros.SelectedRows.Count > 0)
            {
                this.cargarMiembro();
                this.cargarReglas();
            }
        }
        private void dtgReglas_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgReglas.SelectedRows.Count > 0)
            {
                this.cargarRegla();
                this.btnSolicitar1.Enabled = !this.yaSolicitoRegla();
            }
        }
        #endregion
    }
}
