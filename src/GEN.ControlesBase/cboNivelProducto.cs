using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GEN.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboNivelProducto : cboBase
    {
        public DataTable dtNivelProducto;

        public cboNivelProducto()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboNivelProducto(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            dtNivelProducto = new clsCNProducto().ListarNivelProducto();
            this.DataSource = dtNivelProducto;
            this.ValueMember = dtNivelProducto.Columns["idNivelProd"].ToString();
            this.DisplayMember = dtNivelProducto.Columns["cNivelProd"].ToString();
        }
    }
}
