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

namespace GEN.ControlesBase
{
    public partial class frmPerfilBuscador : frmBase
    {
        private clsCNPerfilUsu objCNPerfil;
        private List<clsPerfil> lstPerfil;
        public clsPerfil objPerfil;
        public frmPerfilBuscador()
        {
            InitializeComponent();
            this.inicializarDatos();
        }
        private void inicializarDatos()
        {
            this.objCNPerfil = new clsCNPerfilUsu();
            this.lstPerfil = new List<clsPerfil>();
            this.objPerfil = new clsPerfil();

            this.bsPerfil.DataSource = this.lstPerfil;
        }
        private void buscarPerfil(string cValorBusqueda)
        {
            if (this.txtPerfil.Text.Length < 4)
            {
                MessageBox.Show("¡El valor buscado debe tener al menos 4 caracteres!",
                    "VALOR INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.lstPerfil.Clear();
            this.lstPerfil.AddRange(this.objCNPerfil.buscarPerfil(cValorBusqueda));
            if (this.lstPerfil.Count == 0)
            {
                MessageBox.Show("¡No se encontró ningún perfil que coincida con el valor de búsqueda!",
                    "RESULTADO VACIO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.limpiarControles();
                this.dtgPerfil.SelectionChanged -= dtgPerfil_SelectionChanged;
                this.dtgPerfil.ClearSelection();
                this.dtgPerfil.SelectionChanged += dtgPerfil_SelectionChanged;
            }
            this.habilitarControles(clsAcciones.DEFECTO);
            this.bsPerfil.ResetBindings(false);
            this.dtgPerfil.Refresh();
        }
        private void habilitarControles(int idAccion)
        {
            switch(idAccion)
            {
                case clsAcciones.DEFECTO:
                    this.btnAceptar.Enabled = false;
                    break;
                case clsAcciones.SELECCIONAR:
                    this.btnAceptar.Enabled = true;
                    break;
            }
        }
        private void limpiarControles()
        {
            this.txtPerfil.Text = string.Empty;
        }

        private void frmPerfilBuscador_Load(object sender, EventArgs e)
        {
            this.habilitarControles(clsAcciones.DEFECTO);
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            this.buscarPerfil(this.txtPerfil.Text);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgPerfil_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dtgPerfil.SelectedRows.Count == 0)
            {
                this.objPerfil = new clsPerfil();
            }
            else
            {
                int nIndice = this.dtgPerfil.SelectedRows[0].Index;
                this.objPerfil = this.lstPerfil[nIndice];
                this.habilitarControles(clsAcciones.SELECCIONAR);
            }
        }
        private void txtPerfil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.buscarPerfil(this.txtPerfil.Text);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.objPerfil = null;
            this.Close();
        }
    }
}
