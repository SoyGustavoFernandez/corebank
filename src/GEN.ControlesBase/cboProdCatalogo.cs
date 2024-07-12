using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOG.CapaNegocio;

namespace GEN.ControlesBase
{
    public partial class cboProdCatalogo : cboBase
    {
        public cboProdCatalogo()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboProdCatalogo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public void ListarProductosCatalogo(int idGrupoPadre)
        {
            DataTable dtResult = new clsCNActivos().CNListaProductosCatalogo(idGrupoPadre);
            this.DataSource = dtResult;
            this.ValueMember = "idCatalogo";
            this.DisplayMember = "cProducto";
        }
    }
}
