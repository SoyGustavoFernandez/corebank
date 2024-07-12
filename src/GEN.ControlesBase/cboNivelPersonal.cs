using GEN.CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GRH.CapaNegocio;


namespace GEN.ControlesBase
{
    public partial class cboNivelPersonal : cboBase
    {
        public cboNivelPersonal()
        {
            InitializeComponent();
        }

        public cboNivelPersonal(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNListaNivelPersonal objProcJud = new clsCNListaNivelPersonal();
            DataTable dt = objProcJud.ListarNivel();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
    }
}
