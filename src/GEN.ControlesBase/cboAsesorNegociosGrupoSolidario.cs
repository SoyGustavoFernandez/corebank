using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEN.ControlesBase
{
    public partial class cboAsesorNegociosGrupoSolidario : cboBase
    {
        public cboAsesorNegociosGrupoSolidario()
        {
            InitializeComponent();
        }

        public cboAsesorNegociosGrupoSolidario(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void ListarPorAgencia(int idAgencia)
        {
            clsCNPersonalCreditos ListaPersonalCre = new clsCNPersonalCreditos();
            DataTable dt = ListaPersonalCre.ListarAsesorNegGrupoSol(idAgencia);
            this.ValueMember = "idUsuario";
            this.DisplayMember = "cNombre";
            this.DataSource = dt;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
