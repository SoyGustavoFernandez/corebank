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
    public partial class cboTipMedJud : cboBase
    {
        clsCNProcJud objProcJud = new clsCNProcJud();
        public cboTipMedJud()
        {
            InitializeComponent();
        }

        public cboTipMedJud(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            
            DataTable dt = objProcJud.ListarTipMedJud();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTipoMedJud"].ToString();
            this.DisplayMember = dt.Columns["cTipoMedJud"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void cargarDatos()
        {
            DataTable dt = objProcJud.ListarTipMedJud();
            this.DataSource = dt;
            this.ValueMember = dt.Columns["idTipoMedJud"].ToString();
            this.DisplayMember = dt.Columns["cTipoMedJud"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
