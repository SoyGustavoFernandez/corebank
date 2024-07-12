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

namespace CRE.Presentacion
{
    public partial class frmBandejaSolicitudes : frmBase
    {
        public frmBandejaSolicitudes()
        {
            InitializeComponent();
        }
        #region Variables Generales
        public int idSolicitud = 0;
        private string cTituloFormulario = "Bandeja de solicitudes - " + clsVarGlobal.User.cWinUser;
        DataTable dtSolicitud = new DataTable();
        clsCNSolicitud obCNSolicitud = new clsCNSolicitud();
        #endregion


        #region Metodos
        #endregion

        #region Eventos
        private void frmBandejaSolicitudes_Load(object sender, EventArgs e)
        {
            this.Text = cTituloFormulario;
            dtSolicitud = obCNSolicitud.listarCreditosSolEvalAsesor(clsVarGlobal.User.idUsuario);
            dtgBase1.DataSource = dtSolicitud;
        }

        private void btnAceptar1_Click(object sender, EventArgs e)
        {
        if (dtgBase1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dtgBase1.SelectedRows[0];
                idSolicitud = Convert.ToInt32(row.Cells["idSolicitud"].Value);
            }
            this.Dispose();
        }
        private void btnSalir1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        #endregion



    }
}
