#region
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using GEN.CapaNegocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
#endregion


namespace GEN.ControlesBase
{
    public partial class frmRastreoTasaNegociable : frmBase
    {
        #region Variables Globales
        clsRastreoTasaNegociable objRastreoTasaNegociable { get; set; }
        public string cTipoMotivo = "";
        #endregion

        #region Constructores
        public frmRastreoTasaNegociable()
        {
            InitializeComponent();
            cargarComponetes();
        }
        #endregion

        #region Metodos
        private void cargarComponetes()
        {
            objRastreoTasaNegociable = new clsRastreoTasaNegociable();
        }

        public void cargarRastreoTasaNegociable(clsRastreoTasaNegociable _objRastreoTasaNegociable)
        {
            this.objRastreoTasaNegociable = _objRastreoTasaNegociable;
        }

        private void asignarDatosRastreo()
        {
            txtNivelAprobacion.Text = this.objRastreoTasaNegociable.cNivelAprRanOpe;
            txtEstadoAprobacion.Text = this.objRastreoTasaNegociable.cEstado;
            txtUsuario.Text = this.objRastreoTasaNegociable.cWinUser;
            txtPerfil.Text = this.objRastreoTasaNegociable.cPerfilEmiteOpinion;
            txtTasaCompensatoria.Text = Convert.ToString(this.objRastreoTasaNegociable.nTasaPropuesta);
            txtTasaMora.Text = Convert.ToString(this.objRastreoTasaNegociable.nTasaMora);
            txtJustificacion.Text = this.objRastreoTasaNegociable.cOpinion;

            int nTiposolicitud = 0;
            if (cTipoMotivo == "P")
            {
                nTiposolicitud = 1;
            }
            else if (cTipoMotivo == "S") 
            {
                nTiposolicitud = 2;
            }

            DataTable dtSolTasaN = new clsCNSolicitud().CNObtenerMotivoSolicitudTasaNegociable(this.objRastreoTasaNegociable.idSolicitud, nTiposolicitud);
            if (dtSolTasaN.Rows.Count > 0)
            {
                listarMotivosTasa(Convert.ToInt32(dtSolTasaN.Rows[0]["IdMotivoTasa"]));
                txtOtros.Text = Convert.ToString(dtSolTasaN.Rows[0]["cComenMotivoTasa"]);
            }
        }
        private void listarMotivosTasa(int nItemvalue)
        {
            clsCNSolicitud cnsolicitudMT = new clsCNSolicitud();
            DataTable dtResultado = cnsolicitudMT.CNListaMotivosolicitudTasa(cTipoMotivo);
            cboMotivotipo.DataSource = dtResultado;
            cboMotivotipo.ValueMember = dtResultado.Columns[0].ToString();
            cboMotivotipo.DisplayMember = dtResultado.Columns[1].ToString();
            cboMotivotipo.SelectedValue = nItemvalue;
        }
        #endregion

        #region Eventos
        private void frmRastreoTasaNegociable_Load(object sender, EventArgs e)
        {
            asignarDatosRastreo();
        }
        #endregion
    }
}
