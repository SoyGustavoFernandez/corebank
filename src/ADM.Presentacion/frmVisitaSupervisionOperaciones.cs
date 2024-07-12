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

namespace ADM.Presentacion
{
    public partial class frmVisitaSupervisionOperaciones : frmVisitaSupervision
    {
        #region Variables
        string cTipoSupervision = "SupervisionOperativa";
        #endregion

        public frmVisitaSupervisionOperaciones()
        {
            InitializeComponent();
        }
        #region Métodos
        private void mostrarResumenVisita()
        {
            frmVisitaSupervisionResumen frmResumen = new frmVisitaSupervisionResumen();

            DataGridViewRow dtRow = getDatosRowSeleccionado();

            frmResumen.idVisita = Convert.ToInt32(dtRow.Cells["idVisita"].Value);
            frmResumen.idTipoVisita = Convert.ToInt32(dtRow.Cells["idTipoVisita"].Value);
            frmResumen.idSupervisor = Convert.ToInt32(dtRow.Cells["idSupervisor"].Value);
            frmResumen.idEstablecimiento = Convert.ToInt32(dtRow.Cells["idEstablecimiento"].Value);
            frmResumen.ShowDialog();

            if (frmResumen.lFinalizado)
            {
                mostrarVisitas();
            }
        }
        #endregion
        #region Eventos
        private void btnRevisar1_Click(object sender, EventArgs e)
        {
            mostrarResumenVisita();
        }

        private void frmVisitaSupervisionOperaciones_Load(object sender, EventArgs e)
        {
            setearDatosIniciales(clsVarApl.dicVarGen["cPerfilSupervisionOficina"], clsVarGlobal.PerfilUsu.idPerfil, false, cTipoSupervision);
        }
        #endregion
    }
}
