using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEN.CapaNegocio;
using EntityLayer;


namespace GEN.ControlesBase
{
    public partial class cboPerfil : cboBase
    {
        public cboPerfil()
        {
            InitializeComponent();
        }

        public cboPerfil(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public void cargarPerfilIds(string cIdsPerfiles)
        {
            clsCNPerfilUsu objCNPerfil = new clsCNPerfilUsu();
            List<clsPerfil> lstPerfil = objCNPerfil.listarPerfil(0, cIdsPerfiles);

            this.DataSource = lstPerfil;
            this.ValueMember = "idPerfil";
            this.DisplayMember = "cPerfil";
        }
    }
}
