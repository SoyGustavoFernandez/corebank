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

namespace GEN.ControlesBase
{
    public partial class cboTipContratoPersonal : cboBase
    {
        public cboTipContratoPersonal()
        {
            InitializeComponent();
        }

        public cboTipContratoPersonal(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            clsCNListarTipContrPers objProcJud = new clsCNListarTipContrPers();
            DataTable dt = objProcJud.ListarTipContrPers();
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();
        }
    }
}
