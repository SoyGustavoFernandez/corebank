using ADM.CapaNegocio;
using CRE.CapaNegocio;
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

namespace CRE.Presentacion
{

    public partial class frmConfigurarPerfilesPaqSeguro : frmBase
    {
        #region Variables Globales
        public clsCNPaqueteSeguro PaqueteSeguro = new clsCNPaqueteSeguro();
        public int idPerfil, idZona, idEstablecimiento, idPaqueteSeguro, idUsuario = clsVarGlobal.User.idUsuario, Desactivado;
        public clsMantenimientoPaqueteSeguro clsMantenimientoPaqueteSeguro = new clsMantenimientoPaqueteSeguro();

        #endregion


        private void frmConfigurarPerfilesPaqSeguro_Load(object sender, EventArgs e)
        {
            activarControlObjetos(this, EventoFormulario.INICIO);
        }

        public frmConfigurarPerfilesPaqSeguro()
        {
            InitializeComponent();
        }

        public void asignarDatos(clsMantenimientoPaqueteSeguro _clsMantenimientoPaqueteSeguro)
        {
            clsMantenimientoPaqueteSeguro = _clsMantenimientoPaqueteSeguro;
            cboListaPerfil1.CargarPerfilOrdenadoAsc();
            cboListaPerfil1.SelectedIndex = 0;
        }        
        private void btnGrabar1_Click(object sender, EventArgs e)
        {
            AgregarPerfil();
            this.Close();
        }
        public void AgregarPerfil()
        {
            if (Convert.ToInt32(cboListaPerfil1.SelectedValue) == 0)
            {
                if (MessageBox.Show("En caso se marque esta opción se procederá a RESTABLECER la configuración para todos los perfiles.",
                    "Agregar perfil", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    clsMantenimientoPaqueteSeguro.listaPaqueteSeguroPerfil.RemoveAll(x => x.idPerfil != 0);
                }

            }
            else
            {
                clsMantenimientoPaqueteSeguro.listaPaqueteSeguroPerfil.RemoveAll(x => x.idPerfil == 0);
            }
            if (!validarAsignacion())
            {
                clsPerfil _clsclsPerfil = new clsPerfil();
                _clsclsPerfil.idPerfil = Convert.ToInt32(cboListaPerfil1.SelectedValue);
                _clsclsPerfil.cPerfil = cboListaPerfil1.Text;
                clsMantenimientoPaqueteSeguro.listaPaqueteSeguroPerfil.Add(_clsclsPerfil);
                MessageBox.Show("Se ha agregado correctamente", "Agregar Perfil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public bool validarAsignacion()
        {
            bool existeSimilitud = false;
            clsMantenimientoPaqueteSeguro.listaPaqueteSeguroPerfil.AsEnumerable
                ().ToList().ForEach(x =>
                {
                    if (x.idPerfil == Convert.ToInt32(cboListaPerfil1.SelectedValue))
                    {
                        existeSimilitud = true;
                        MessageBox.Show("El perfil ya se encuentra asignado.", "Agregar perfil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                });
            return existeSimilitud;
        }
    }
}
