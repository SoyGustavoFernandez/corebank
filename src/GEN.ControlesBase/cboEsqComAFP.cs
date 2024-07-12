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
    public partial class cboEsqComAFP : cboBase
    {
        public cboEsqComAFP()
        {
            InitializeComponent();
        }

        public cboEsqComAFP(IContainer container)
        {
            container.Add(this);
                        
            InitializeComponent();
            clsCNEsquemaAFP objProcJud = new clsCNEsquemaAFP();
            DataTable dt = objProcJud.ListarEsquemaComAFP();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
    }
}
