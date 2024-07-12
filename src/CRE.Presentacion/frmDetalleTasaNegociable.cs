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
#endregion

namespace CRE.Presentacion
{
    public partial class frmDetalleTasaNegociable : frmBase
    {
        #region Variables Globales
        public int idSolicitud { get; set; }
        public int idTasaNegociada { get; set; }
        public int idUsuario { get; set; }
        public string cTipoMotivo = "P";
        #endregion

        #region Constructores
        public frmDetalleTasaNegociable()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        public void cargarDetalleTasaNegociable(int _idSolicitud, int _idTasaNegociada, int _idUsuario)
        {
            this.idSolicitud = _idSolicitud;
            this.idTasaNegociada = _idTasaNegociada;
            this.idUsuario = _idUsuario;
        }
        #endregion

        #region Eventos
        private void frmDetalleTasaNegociable_Load(object sender, EventArgs e)
        {
            lblSolicitud.Text = Convert.ToString(this.idSolicitud);
            lblSolTasaNegociable.Text = Convert.ToString(this.idTasaNegociada);
            this.conRastreoTasaNegociable.cTipoMotivo = cTipoMotivo;
            this.conRastreoTasaNegociable.cargarDatos(this.idSolicitud, this.idTasaNegociada, this.idUsuario);
        }
        #endregion
    }

}
