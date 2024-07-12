using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNT.CapaNegocio;
using System.Data;
using EntityLayer;
namespace GEN.ControlesBase
{
    public partial class cboNaturalezaCnt : cboBase
    {
       
        public cboNaturalezaCnt()
        {
            InitializeComponent();
        }

        public cboNaturalezaCnt(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            ListarPromotoresCred();
        }
        private void ListarPromotoresCred()
        {
            clsCNNaturalezaCnt ListaNatCta = new clsCNNaturalezaCnt();
            DataTable dt = ListaNatCta.clsCNListarNaturalezaCnt();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
    }
}
