using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.ControlesBase;
using GEN.CapaNegocio;
using System.Data;
using System.Windows.Forms;
namespace GEN.ControlesBase
{
    public partial class cboTipoValorado : cboBase
    {
        public cboTipoValorado()
        {
            InitializeComponent();
        }

        public cboTipoValorado(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            clsCNTipoValorado ListaTipoValorado = new clsCNTipoValorado();
            DataTable dt = ListaTipoValorado.CNTipoValorado();
            dt.DefaultView.RowFilter = ("idTipoValorado = 1 OR idTipoValorado = 2");
            this.DataSource = dt;
            this.ValueMember= dt.Columns["idTipoValorado"].ToString();
            this.DisplayMember = dt.Columns["cValorado"].ToString();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
