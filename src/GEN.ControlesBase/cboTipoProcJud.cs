using CRE.CapaNegocio;
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
    public partial class cboTipoProcJud : cboBase
    {
        clsCNProcJud objProcJud = new clsCNProcJud();
        public cboTipoProcJud()
        {
            InitializeComponent();
        }

        public cboTipoProcJud(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            DataTable dt = objProcJud.ListarTipoProcJud();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTipoProcJud"].ToString();
            this.DisplayMember = dt.Columns["cTipoProcJud"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void cargarDatos()
        {
            DataTable dt = objProcJud.ListarTipoProcJud();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTipoProcJud"].ToString();
            this.DisplayMember = dt.Columns["cTipoProcJud"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
