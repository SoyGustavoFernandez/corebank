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
using GEN.ControlesBase;
using GEN.Funciones;
using GEN.LibreriaOffice;
using GEN.PrintHelper;
using CRE.CapaNegocio;

namespace CRE.Presentacion
{
    public partial class frmConfirmAsistComite : frmBase
    {
        #region Variables Globales

        public List<clsUsuComite> lstParticipantes = null;
        private const string cTituloMsjes = "Confirmación de asistencia a comités de créditos.";

        #endregion

        #region Eventos

        private void Form_Load(object sender, EventArgs e)
        {
            dtgParticipantes.AutoGenerateColumns = false;
            if (lstParticipantes != null)
            {
                dtgParticipantes.DataSource = lstParticipantes.ToList();
            }
            else
            {
                MessageBox.Show("No se encontraron participantes que deban confirmar su asistencia", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Dispose();
                return;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (dtgParticipantes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un participante.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            clsUsuComite objUsuario = (clsUsuComite)dtgParticipantes.SelectedRows[0].DataBoundItem;
            if (objUsuario.lConfirmAsis)
            {
                MessageBox.Show("Seleccione un participante que no haya confirmado su participación.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmCredenciales frmCredenciales = new frmCredenciales();
            frmCredenciales.cWinUser = objUsuario.cWinUser;
            frmCredenciales.ShowDialog();
            if (!frmCredenciales.lValido)
            {
                MessageBox.Show("Confirmación no realizada. Las credenciales no son válidas.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idComite = objUsuario.idComiteCred;
            int idUsuConfirm = objUsuario.idUsuario;
            int idUsuario = clsVarGlobal.User.idUsuario;
            DateTime dFecha = clsVarGlobal.dFecSystem.Date;

            clsDBResp objDbResp = new clsCNComiteCreditos().CNConfirmAsistUsuComite(idComite, idUsuConfirm, idUsuario, dFecha);
            if (objDbResp.nMsje == 0)
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Information);

                lstParticipantes = new clsCNComiteCreditos().CNGetUsuComiteCred(objUsuario.ComiteCred);
                dtgParticipantes.DataSource = lstParticipantes.ToList();
            }
            else
            {
                MessageBox.Show(objDbResp.cMsje, cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (lstParticipantes.Count(x => !(x.lConfirmAsis) && x.idTipoParticip == 1) > 0)
            {
                MessageBox.Show("Todos los participantes presenciales deben de confirmar su asistencia.", cTituloMsjes, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Dispose();
        }

        #endregion

        #region Metodos

        public frmConfirmAsistComite()
        {
            InitializeComponent();
        }


        #endregion

    }
}
