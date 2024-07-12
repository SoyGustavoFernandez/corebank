using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEN.BotonesBase;
using GEN.CapaNegocio;
using GEN.ControlesBase;
using GEN.LibreriaOffice;
using EntityLayer;

namespace SolIntEls
{
    public partial class frmPerfil : frmBase
    {
        #region
        
        List<clsPerfilUsu> _lisPerfiles;     

        public List<clsPerfilUsu> lisPerfiles
        {
            get { return _lisPerfiles; }
            set { _lisPerfiles = value; }
        }

        #endregion

        public frmPerfil()
        {
            InitializeComponent();
        }

        #region Eventos       

        private void frmPerfil_Load(object sender, EventArgs e)        
        {
            this.cboPerfiles.DisplayMember = "cPerfil";
            this.cboPerfiles.ValueMember = "idPerfilUsu";
            this.cboPerfiles.DataSource = _lisPerfiles;
            this.cboPerfiles.SelectedValue = clsVarGlobal.PerfilUsu.idPerfilUsu;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            clsVarGlobal.PerfilUsu = (clsPerfilUsu)this.cboPerfiles.SelectedItem;
            this.Close();
        }

        #endregion
    }
}
