using ADM.CapaNegocio;
using EntityLayer;
using GEN.ControlesBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADM.Presentacion
{
    public partial class frmConfigurarPerfileSegOpt : frmBase
    {
        #region Variables Globales
        clsCNConfigurarSeguroOptativo clsMantenimiento   = new clsCNConfigurarSeguroOptativo();
        clsMantenimientoSeguroOptativo clsDatosSeguroOpt = new clsMantenimientoSeguroOptativo();
        public int idPerfil, idTipoSeguro, idUsuario = clsVarGlobal.User.idUsuario, nEdicion = 0;
        public bool lAutorizado;

        #region SeguroOncologico
        clsHistoricoSegurosOptativos objFrmEditarSeguroOptativo = new clsHistoricoSegurosOptativos();
        clsCNHistoricoSegurosOptativos _clsCNHistoricoSegurosOptativos = new clsCNHistoricoSegurosOptativos();
        #endregion

        #endregion

        public frmConfigurarPerfileSegOpt()
        {
            InitializeComponent();
        }

        public frmConfigurarPerfileSegOpt(clsMantenimientoSeguroOptativo _clsDatosSeguroOpt, clsHistoricoSegurosOptativos _objFrmEditarSeguroOptativo)
        {
            InitializeComponent();
            clsDatosSeguroOpt = _clsDatosSeguroOpt;
            objFrmEditarSeguroOptativo = _objFrmEditarSeguroOptativo;
        }

        #region Eventos
        private void frmAgregarPerfilesSegOpt_Load(object sender, EventArgs e)
        {
            cboListaPerfil1.CargarPerfilOrdenadoAsc();
            cboListaPerfil1.SelectedValue = 0;
            CargarDatos();
        }

        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            if (clsDatosSeguroOpt.nEstado == 0)
            {
                AgregarDatosPerfil();
            }
            else
            {
                EdidarDatosPerfil();
            }
        }

        private void cboListaPerfil1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboListaPerfil1.SelectedValue) == 0 && chbAutorizado.Checked == true && clsDatosSeguroOpt.nEstadoPerfil == 2)
            {
                MessageBox.Show("En caso se marque esta opción se procederá a RESTABLECER la configuración para todos los perfiles.", "Agregar perfil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void chbAutorizado_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAutorizado.Checked == true && Convert.ToInt32(cboListaPerfil1.SelectedValue) == 0 && clsDatosSeguroOpt.nEstadoPerfil == 2)
            {
                MessageBox.Show("En caso se marque esta opción se procederá a RESTABLECER la configuración para todos los perfiles.", "Agregar perfil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (chbAutorizado.Checked == false && Convert.ToInt32(cboListaPerfil1.SelectedValue) == 0 && clsDatosSeguroOpt.nEstadoPerfil == 2 && nEdicion == 1)
            {
                MessageBox.Show("En caso se desmarque esta opción se procederá a RESTABLECER la configuración para todos los perfiles.", "Agregar perfil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Metodos
        void CargarDatos()
        {
            if (clsDatosSeguroOpt.nEstado == 0)
            {
                return;
            }
            else
            {
                CargarDatosEditar();
            }
        }

        void CargarDatosEditar()
        {
            chbAutorizado.CheckedChanged -= new EventHandler(chbAutorizado_CheckedChanged);
            cboListaPerfil1.SelectedValue = clsDatosSeguroOpt.idPerfil;
            chbAutorizado.Checked         = clsDatosSeguroOpt.lAutorizadoPerfil;
            cboListaPerfil1.Enabled       = false;
            nEdicion                      = 1;
            chbAutorizado.CheckedChanged += new EventHandler(chbAutorizado_CheckedChanged);
        }

        void AgregarDatosPerfil()
        {
            idTipoSeguro = clsDatosSeguroOpt.idTipoSeguro;
            idPerfil     = Convert.ToInt32(cboListaPerfil1.SelectedValue);
            lAutorizado  = chbAutorizado.Checked;

            DataTable dtPefilSegOptConfig = clsMantenimiento.CNAgregarPefilProSegOptConfig(idTipoSeguro, idPerfil, idUsuario, lAutorizado);
            MessageBox.Show(dtPefilSegOptConfig.Rows[0]["cMensaje"].ToString(), "Agregar Pefil.", MessageBoxButtons.OK, ((int)dtPefilSegOptConfig.Rows[0]["idError"] == 0 ? MessageBoxIcon.Exclamation : MessageBoxIcon.Information));

            if ((int)dtPefilSegOptConfig.Rows[0]["idError"] == 1)
                _clsCNHistoricoSegurosOptativos.MapearHistoricoSeguroPerfil("REGISTRO DE PERFIL AGREGADO", AccionHistorico.AGREGAR,
                    new clsMantenimientoSeguroOptativo { idTipoSeguro = idTipoSeguro, idPerfil = idPerfil, lAutorizadoPerfil = lAutorizado }
                    , objFrmEditarSeguroOptativo);

            this.Dispose();
        }

        void EdidarDatosPerfil()
        {
            idTipoSeguro = clsDatosSeguroOpt.idTipoSeguro;
            idPerfil     = clsDatosSeguroOpt.idPerfil;
            lAutorizado  = chbAutorizado.Checked;
           
            DataTable dtEditarPerfilOpatativo = clsMantenimiento.CNEditarPefilProSegOptConfig(idTipoSeguro, idPerfil, idUsuario, lAutorizado);
            MessageBox.Show(dtEditarPerfilOpatativo.Rows[0]["cMensaje"].ToString(), "Editar de perfil.", MessageBoxButtons.OK, ((int)dtEditarPerfilOpatativo.Rows[0]["idError"] == 0 ? MessageBoxIcon.Exclamation : MessageBoxIcon.Information));
            this.Dispose();
            if ((int)dtEditarPerfilOpatativo.Rows[0]["idError"] == 1)
                _clsCNHistoricoSegurosOptativos.MapearHistoricoSeguroPerfil("REGISTRO DE PERFIL MODIFICADO", AccionHistorico.EDITAR,
                new clsMantenimientoSeguroOptativo { idTipoSeguro = idTipoSeguro, idPerfil = idPerfil, lAutorizadoPerfil = lAutorizado }
                , objFrmEditarSeguroOptativo);
        }
        #endregion
    }
}
