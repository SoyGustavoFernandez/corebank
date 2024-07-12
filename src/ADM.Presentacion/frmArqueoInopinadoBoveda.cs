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
    public partial class frmArqueoInopinadoBoveda : frmVisitaSupervision
    {
        #region Variables
        string cTipoSupervision = "ArqueoBoveda";
        #endregion

        public frmArqueoInopinadoBoveda()
        {
            InitializeComponent();
        }
        #region Métodos
        private void mostrarResumenVisita()
        {
            DataGridViewRow dtRow = getDatosRowSeleccionado();

            frmBilletaje frmBilletaje = new frmBilletaje();
            frmBilletaje.idVisita = Convert.ToInt32(dtRow.Cells["idVisita"].Value); ;
            frmBilletaje.cTipoVisita = cTipoSupervision;
            frmBilletaje.idSupervisor = Convert.ToInt32(dtRow.Cells["idSupervisor"].Value);
            frmBilletaje.idEstablecimiento = Convert.ToInt32(dtRow.Cells["idEstablecimiento"].Value);
            frmBilletaje.lBtnFinalizar = true;
            frmBilletaje.ShowDialog();

            if (frmBilletaje.lVisitaFinalizado)
            {
                mostrarVisitas();
            }
        }
        #endregion

        #region Eventos
        private void btnRevisar1_Click(object sender, EventArgs e)
        {
            this.mostrarResumenVisita();
        }

        private void frmVisitaSupervisionArqueoBoveda_Load(object sender, EventArgs e)
        {
            setearDatosIniciales(clsVarApl.dicVarGen["cPerfilSupervisionOficina"], clsVarGlobal.PerfilUsu.idPerfil, false, cTipoSupervision);
        }
        #endregion
    }
}
