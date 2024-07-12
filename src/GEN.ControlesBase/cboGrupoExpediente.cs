using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRE.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboGrupoExpediente : cboBase
    {
        clsCNControlExp ListaGrupoExp = new clsCNControlExp();

        public cboGrupoExpediente()
        {
            InitializeComponent();

            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboGrupoExpediente(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void cboCargarGrupoExpedientes(int idSolicitud, string cTipoSolicitud)
        {
            DataTable dt = ListaGrupoExp.CNListarGrupoExpediente(idSolicitud, cTipoSolicitud);
            this.DataSource = dt;
            this.DisplayMember = "cGrupo";
            this.ValueMember = "idGrupo";
        }
    }
}
