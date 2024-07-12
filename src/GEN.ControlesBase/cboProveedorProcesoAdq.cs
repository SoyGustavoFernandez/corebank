using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEN.CapaNegocio;
using System.Data;
namespace GEN.ControlesBase
{
    public partial class cboProveedorProcesoAdq : cboBase
    {
        public cboProveedorProcesoAdq()
        {
            InitializeComponent();
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public cboProveedorProcesoAdq(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public void listarProveedoresProcAdq(int idProcAdq)
        {
            clsCNAdquisionesLogistica listTipoProceso = new clsCNAdquisionesLogistica();
            DataTable dt = listTipoProceso.listarProveedoresProcAdq(idProcAdq);
            this.DataSource = dt;
            this.ValueMember = dt.Columns[0].ToString();
            this.DisplayMember = dt.Columns[1].ToString();  
        }
    }
}
